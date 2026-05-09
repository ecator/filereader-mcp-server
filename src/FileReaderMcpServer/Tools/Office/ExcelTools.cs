using Microsoft.Office.Interop.Excel;
using ModelContextProtocol;
using ModelContextProtocol.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

    [McpServerTool(Name = "excel_get_sheets"), Description("Get all the sheet names of the specified Excel file.")]
    public static string GetSheets([Description("The Excel file.")] string file)
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



    [McpServerTool(Name = "excel_read"), Description("Read the value of a cell or a range of cells from the specified worksheet.\nIf a cell is empty, it will not be included in the returned result set.")]
    public static string Read([Description("The path of the Excel file.")] string file
        , [Description("The sheet name of the Excel file.")] string sheetName
        , [Description("The first column as a letter.(such as A)")] string startColumn = "A"
        , [Description("The first row number.")] int startRow = 1
        , [Description("The last column as a letter.(such as Z) If empty, then use xlToRight relative to startColumn")] string? endColumn = null
        , [Description("The last row number. If empty, then use xlDown relative to startRow")] int? endRow = null)
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

        return JsonConvert.SerializeObject(values);
    }
    [McpServerTool(Name = "excel_read_used_range"), Description("Read the value of used range of cells from the specified worksheet.\nIf a cell is empty, it will not be included in the returned result set.")]
    public static string ReadUsedRange([Description("The path of the Excel file.")] string file
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

        return JsonConvert.SerializeObject(values);
    }

    [McpServerTool(Name = "excel_grep_files"), Description("Find value from Excel files.")]
    public static string Find([Description("The list of full path of Excel files that need to be searched for.")] string[] files
    , [Description("The regular expression pattern to match against each cell.")] string pattern
    , [Description("The maximum number of matched cells to return across all files.")] int max = 1000)
    {
        var data = new StringBuilder();
        var foundData = new StringBuilder();
        var line = new string[3];
        var totalCount = 0;
        var count = 0;

        if (files == null || files.Length == 0)
        {
            throw new McpException("The full path list of the Excel file cannot be empty or null.");
        }
        data.AppendLine();
        data.AppendLine();
        Regex regex;
        try
        {
            regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
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
                count = 0;
                foundData.Clear();
                foundData.AppendLine();
                foreach (var doc in docs)
                {
                    var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(doc.Content);
                    
                    foreach (var kvp in values)
                    {
                        if (kvp.Value != null && regex.IsMatch(kvp.Value.ToString()))
                        {
                            if (count == 0)
                            {
                                foundData.AppendLine($"Sheet|Address|Value");
                                foundData.AppendLine($"---|---|---");
                            }
                            totalCount++;
                            count++;
                            line[0] = doc.Metadata["SheetName"].ToString();
                            line[1] = kvp.Key;
                            line[2] = MarkdownHelper.EscapeMarkdownTableValue(Convert.ToString(kvp.Value));
                            foundData.AppendLine(string.Join("|", line));
                        }

                    }
                }
                if(count > 0)
                {
                    foundData.Insert(0, $"`{count}` results in `{file}`:");
                    data.AppendLine(foundData.ToString());
                }
            }

        }
        data.Insert(0, $"Found a total of `{totalCount}` results for `{pattern}` in all files.");
        return data.ToString();
    }
}
