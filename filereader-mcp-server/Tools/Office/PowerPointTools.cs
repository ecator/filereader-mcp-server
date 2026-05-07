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
using FileReaderMcpServer.Utilities;

namespace FileReaderMcpServer.Tools.Office;

[McpServerToolType]
public static class PowerPointTools

{

    [McpServerTool(Name = "powerpoint_get_slide_count"), Description("Get all the number of the slides of the specified PowerPoint file.")]
    public static string GetSlideCount([Description("The path of the PowerPoint file.")] string file
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

    [McpServerTool(Name = "powerpoint_read"), Description("Get the text content of the specified PowerPoint file.")]
    public static string Read([Description("The path of the PowerPoint file.")] string file
        , [Description("The starting slide number to read.")] int fromSlide = 1
        , [Description("The slide number to read.")] int? count = 10)
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

    [McpServerTool(Name = "powerpoint_grep_files"), Description("Find value from PowerPoint files.")]
    public static string Find([Description("The list of full path of PowerPoint files that need to be searched for.")] string[] files
    , [Description("The regular expression pattern to match against each slide.")] string pattern
    , [Description("The maximum number of matched slides to return across all files.")] int max = 100)
    {
        var data = new StringBuilder();
        var foundData = new StringBuilder();
        var line = new string[2];
        var totalCount = 0;
        var count = 0;
        if (files == null || files.Length == 0)
        {
            throw new McpException("The full path list of the PowerPoint file cannot be empty or null.");
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
                count = 0;
                foundData.Clear();
                foundData.AppendLine();
                foreach (var doc in docs)
                {


                    if (doc.Content != null && regex.IsMatch(doc.Content))
                    {
                        if (count == 0)
                        {
                            foundData.AppendLine($"SlideNumber|Content");
                            foundData.AppendLine($"---|---");
                        }
                        totalCount++;
                        count++;
                        line[0] = doc.Metadata["SlideNumber"].ToString();
                        line[1] = MarkdownHelper.EscapeMarkdownTableValue(doc.Content);
                        foundData.AppendLine(string.Join("|", line));

                    }
                }
                if (count > 0)
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
