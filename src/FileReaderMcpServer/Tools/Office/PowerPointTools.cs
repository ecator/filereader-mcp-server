using ModelContextProtocol;
using ModelContextProtocol.Server;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using Newtonsoft.Json;
using FileReaderMcpServer.Search;
using FileReaderMcpServer.Utils;

namespace FileReaderMcpServer.Tools.Office;

[McpServerToolType]
public static class PowerPointTools

{

    [McpServerTool(Name = "get_ppt_slides"), Description("Get the total number of slides in a PowerPoint file.")]
    public static string GetSlideCount([Description("The absolute path of the PowerPoint file.")] string file
       )
    {
        var data = new StringBuilder();
        var count = 0;
        data.AppendLine();
        FileChecker.CheckPowerPointFile(file);
        using (var session = new PowerPointSession())
        {
            var docs = CacheReader.ReadPowerPointFileDocument(session, file);

            count = docs.Count;
        }
        data.Insert(0, $"Total `{count}` slides in the PowerPoint file `{file}`.");
        return data.ToString();
    }

    [McpServerTool(Name = "read_ppt"), Description("Read text content from a PowerPoint file, starting from a specific slide.")]
    public static string Read([Description("The absolute path of the PowerPoint file.")] string file
        , [Description("The starting slide number to read.")] int fromSlide = 1
        , [Description("The number of slides to read.")] int? count = 10)
    {
        var data = "";
        FileChecker.CheckPowerPointFile(file);
        using (var session = new PowerPointSession())
        {
            var docs = CacheReader.ReadPowerPointFileDocument(session, file);

            var pages = docs.Select(doc => doc.Content).ToList();
            data = string.Join(Environment.NewLine, pages.Skip(fromSlide - 1).Take(count.Value));
        }
        return data;
    }

    [McpServerTool(Name = "grep_ppt_files"), Description("Search for a regex pattern across multiple PowerPoint files, returning matched slides.")]
    public static string Find([Description("A list of absolute paths to PowerPoint files to search.")] string[] files
    , [Description("The regular expression pattern to match against each slide.")] string pattern
    , [Description("The maximum number of matched slides to return across all files.")] int max = 100)
    {
        var data = new StringBuilder();
        var totalCount = 0;
        if (files == null || files.Length == 0)
        {
            throw new McpException("The full path list of the PowerPoint file cannot be empty or null.");
        }
        Regex regex;
        try
        {
            regex = new Regex(CharacterConverter.Normalize(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        catch (Exception ex)
        {
            throw new McpException($"Invalid regex pattern: {ex.Message}");
        }
        data.AppendLine();
        data.AppendLine();
        using (var session = new PowerPointSession())
        {

            foreach (var file in files)
            {
                if (totalCount >= max) break;
                try
                {
                    FileChecker.CheckPowerPointFile(file);

                }
                catch (Exception ex)
                {
                    data.AppendLine($"Error checking file `{file}`: {ex.Message}");
                    continue;
                }
                var docs = CacheReader.ReadPowerPointFileDocument(session, file);
                var tableBody = new List<List<object?>>();
                foreach (var doc in docs)
                {
                    if (doc.Content != null && regex.IsMatch(CharacterConverter.Normalize(doc.Content)))
                    {
                        totalCount++;
                        tableBody.Add(new List<object?> { doc.Metadata["SlideNumber"], doc.Content });
                        if (totalCount >= max) break;
                    }
                }
                if (tableBody.Count > 0)
                {
                    data.AppendLine($"`{tableBody.Count}` results in `{file}`:");
                    data.AppendLine(MarkdownHelper.MakeMarkdownTable(new List<string> { "SlideNumber", "Content" }, tableBody));
                }
            }

        }
        data.Insert(0, $"Found a total of `{totalCount}` results for `{pattern}` in all files.");
        return data.ToString();
    }
}
