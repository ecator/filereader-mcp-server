using ModelContextProtocol;
using ModelContextProtocol.Server;
using Newtonsoft.Json;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CacheReader = FileReaderMcpServer.Search.CacheReader;
using Word = Microsoft.Office.Interop.Word;

namespace FileReaderMcpServer.Tools.Office;

[McpServerToolType]
public static class WordTools

{

    [McpServerTool(Name = "word_get_page_count"), Description("Get all the number of the pages of the specified Word file.")]
    public static string GetPageCount([Description("The path of the Word file.")] string file)
    {
        var data = new StringBuilder();
        var count = 0;
        data.AppendLine();
        var checkedFile = Validation.FileChecker.CheckFile(file);
        using (var session = new WordSession())
        {
            var docs = CacheReader.ReadWordFileDocument(session, checkedFile);

            count = docs.Count;
        }
        data.Insert(0, $"Total `{count}` pages in the Word file `{checkedFile}`.");
        return data.ToString();
    }

    [McpServerTool(Name = "word_read"), Description("Get the text content of the specified Word file.")]
    public static string Read([Description("The path of the Word file.")] string file
        , [Description("The starting page number (1-indexed) to read.")] int fromPage = 1
        , [Description("The page number to read.")] int? count = 10
        )
    {
        var data = "";
        var checkedFile = Validation.FileChecker.CheckFile(file);
        using (var session = new WordSession())
        {
            var docs = CacheReader.ReadWordFileDocument(session, checkedFile);

            var pages = docs.Select(doc => doc.Content).ToList();
            data = string.Join(Environment.NewLine, pages.Skip(fromPage-1).Take(count.Value));
        }
        return data;
    }

    [McpServerTool(Name = "word_grep_files"), Description("Find value from Word files.")]
    public static string Find([Description("The list of full path of Word files that need to be searched for.")] string[] files
    , [Description("The regular expression pattern to match against each page.")] string pattern
    , [Description("The maximum number of matched pages to return across all files.")] int max = 100)
    {
        var data = new StringBuilder();
        var foundData = new StringBuilder();
        var line = new string[2];
        var totalCount = 0;
        var count = 0;
        if (files == null || files.Length == 0)
        {
            throw new McpException("The full path list of the Word file cannot be empty or null.");
        }
        Regex regex;
        try
        {
            regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        catch (Exception ex)
        {
            throw new McpException($"Invalid regex pattern: {ex.Message}");
        }
        data.AppendLine();
        data.AppendLine();
        using (var session = new WordSession())
        {

            foreach (var file in files)
            {
                var checkedFile = Validation.FileChecker.CheckFile(file);
                var docs = CacheReader.ReadWordFileDocument(session, checkedFile);
                count = 0;
                foundData.Clear();
                foundData.AppendLine();
                foreach (var doc in docs)
                {


                    if (doc.Content != null && regex.IsMatch(doc.Content))
                    {
                        if (count == 0)
                        {
                            foundData.AppendLine($"Page|Content");
                            foundData.AppendLine($"---|---");
                        }
                        totalCount++;
                        count++;
                        line[0] = doc.Metadata["PageNumber"].ToString();
                        line[1] = session.EscapeMarkdownTableValue(doc.Content);
                        foundData.AppendLine(string.Join("|", line));
                        if (totalCount >= max)
                        {
                            break;
                        }

                    }
                }
                if (count > 0)
                {
                    foundData.Insert(0, $"`{count}` results in `{checkedFile}`:");
                    data.AppendLine(foundData.ToString());
                }
            }

        }
        data.Insert(0, $"Found a total of `{totalCount}` results for `{pattern}` in all files.");
        return data.ToString();
    }
}
