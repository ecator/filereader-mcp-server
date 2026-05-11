using Microsoft.Office.Interop.Excel;
using ModelContextProtocol;
using ModelContextProtocol.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CacheReader = FileReaderMcpServer.Search.CacheReader;
using Excel = Microsoft.Office.Interop.Excel;
using FileReaderMcpServer.Utils;

namespace FileReaderMcpServer.Tools.Office;

[McpServerToolType]
public static class ExcelTools

{
    private static readonly ISerializer _yamlSerializer = new SerializerBuilder().Build();

    [McpServerTool(Name = "get_excel_sheets"), Description("Get all the sheet names of the specified Excel file.")]
    public static string GetSheets([Description("The absolute path of the Excel file.")] string file)
    {
        var data = new StringBuilder();
        var count = 0;
        data.AppendLine();
        FileChecker.CheckExcelFile(file);
        using (var session = new ExcelSession())
        {
            var docs = CacheReader.ReadExcelFileDocument(session, file);
            foreach (var doc in docs)
            {
                count++;
                data.AppendLine($"{count}. {doc.Metadata["SheetName"].ToString()}");
            }
        }
        data.Insert(0, $"Total `{count}` sheets in the Excel file `{file}`:");
        return data.ToString();
    }



    [McpServerTool(Name = "read_excel"), Description("Read the value of a cell or a range of cells from the specified worksheet in YAML format.\nIf a cell is empty, it will not be included in the returned result set.")]
    public static string Read([Description("The absolute path of the Excel file.")] string file
        , [Description("The sheet name of the Excel file.")] string sheetName
        , [Description("The starting column letter (e.g., 'A').")] string startColumn = "A"
        , [Description("The first row number.")] int startRow = 1
        , [Description("The ending column letter (e.g., 'Z'). If empty, reads to the last used column in the row.")] string? endColumn = null
        , [Description("The last row number to read. If empty, reads to the last used row in the column.")] int? endRow = null)
    {
        var allValues = new Dictionary<string, object>();
        var values = new Dictionary<string, object>();

        var found = false;
        FileChecker.CheckExcelFile(file);
        using (var session = new ExcelSession())
        {
            var docs = CacheReader.ReadExcelFileDocument(session, file);
            foreach (var doc in docs)
            {
                if (doc.Metadata["SheetName"].ToString() == sheetName)
                {
                    allValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(doc.Content);
                    found = true;
                    int startColumnIndex = ExcelSession.ColumnLetterToIndex(startColumn);
                    int endColumnIndex = endColumn != null ? ExcelSession.ColumnLetterToIndex(endColumn) : Convert.ToInt32(doc.Metadata["EndCol"]);
                    int endRowIndex = endRow != null ? (int)endRow : Convert.ToInt32(doc.Metadata["EndRow"]);
                    for (var i = startRow; i <= endRowIndex; i++)
                    {
                        for(var j= startColumnIndex; j <= endColumnIndex; j++)
                        {
                            var key = $"{ExcelSession.ColumnIndexToLetter(j)}{i}";
                            if (allValues.ContainsKey(key))
                            {
                                values[key] = allValues[key];
                            }
                        }
                    }
                    break;
                }
            }
        }

        if (!found)
        {
            throw new McpException($"The specified sheet '{sheetName}' does not exist in the Excel file.");
        }

        return _yamlSerializer.Serialize(values);
    }
    [McpServerTool(Name = "read_excel_used_range"), Description("Read the value of used range of cells from the specified worksheet in YAML format.\nIf a cell is empty, it will not be included in the returned result set.")]
    public static string ReadUsedRange([Description("The absolute path of the Excel file.")] string file
        , [Description("The sheet name of the Excel file.")] string sheetName)
    {
        var values = new Dictionary<string, object>();
        var found = false;
        FileChecker.CheckExcelFile(file);
        using (var session = new ExcelSession())
        {
            var docs = CacheReader.ReadExcelFileDocument(session, file);
            foreach(var doc in docs)
            {
                if (doc.Metadata["SheetName"].ToString() == sheetName)
                {
                    values =JsonConvert.DeserializeObject<Dictionary<string, object>>(doc.Content);
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            throw new McpException($"The specified sheet '{sheetName}' does not exist in the Excel file.");
        }

        return _yamlSerializer.Serialize(values);
    }

    [McpServerTool(Name = "grep_excel_files"), Description("Search for a regex pattern across cells in multiple Excel files.")]
    public static string Find([Description("A list of absolute paths to Excel files to search.")] string[] files
    , [Description("The regular expression pattern to match against each cell.")] string pattern
    , [Description("The maximum number of matched cells to return across all files.")] int max = 1000)
    {
        var data = new StringBuilder();
        var totalCount = 0;

        if (files == null || files.Length == 0)
        {
            throw new McpException("The full path list of the Excel file cannot be empty or null.");
        }
        if (string.IsNullOrWhiteSpace(pattern))
        {
            throw new McpException("The regex pattern cannot be empty or null.");
        }
        data.AppendLine();
        data.AppendLine();
        Regex regex;
        try
        {
            regex = new Regex(CharacterConverter.Normalize(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        catch (Exception ex)
        {
            throw new McpException($"Invalid regex pattern: {ex.Message}");
        }
        using (var session = new ExcelSession())
        {
            foreach (var file in files)
            {
                if (totalCount >= max) break;
                try
                {
                    FileChecker.CheckExcelFile(file);

                }
                catch (Exception ex)
                {
                    data.AppendLine($"Error checking file `{file}`: {ex.Message}");
                    continue;
                }
                var docs = CacheReader.ReadExcelFileDocument(session, file);
                var tableBody = new List<List<object?>>();
                foreach (var doc in docs)
                {
                    var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(doc.Content);
                    
                    foreach (var kvp in values)
                    {
                        if (kvp.Value != null && regex.IsMatch(CharacterConverter.Normalize(kvp.Value.ToString())))
                        {
                            totalCount++;
                            tableBody.Add(new List<object?> { doc.Metadata["SheetName"], kvp.Key, kvp.Value });
                            if (totalCount >= max) break;
                        }
                    }
                    if (totalCount >= max) break;
                }
                if (tableBody.Count > 0)
                {
                    data.AppendLine($"`{tableBody.Count}` results in `{file}`:");
                    data.AppendLine(MarkdownHelper.MakeMarkdownTable(new List<string> { "Sheet", "Address", "Value" }, tableBody));
                }
            }

        }
        data.Insert(0, $"Found a total of `{totalCount}` results for `{pattern}` in all files.");
        return data.ToString();
    }
}
