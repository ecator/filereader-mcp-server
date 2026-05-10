using ModelContextProtocol;
using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FileReaderMcpServer.Search;
using FileReaderMcpServer.Utils;

namespace FileReaderMcpServer.Tools.Pdf;

[McpServerToolType]
public static class PdfTools
{

    [McpServerTool(Name = "get_pdf_pages"), Description("Get the total number of pages in a PDF file.")]
    public static string GetPageCount([Description("The absolute path of the PDF file.")] string file)
    {
        var data = new StringBuilder();
        var count = 0;
        data.AppendLine();
        FileChecker.CheckPdfFile(file);
        var docs = CacheReader.ReadPdfFileDocument(file);
        count = docs.Count;
        data.Insert(0, $"Total `{count}` pages in the PDF file `{file}`.");
        return data.ToString();
    }

    [McpServerTool(Name = "read_pdf"), Description("Read text content from a PDF file, starting from a specific page.")]
    public static string Read([Description("The absolute path of the PDF file.")] string file
        , [Description("The starting page number (1-indexed) to read.")] int fromPage = 1
        , [Description("The number of pages to read.")] int? count = 10
        )
    {
        var data = "";
        FileChecker.CheckPdfFile(file);
        var docs = CacheReader.ReadPdfFileDocument(file);
        var pages = docs.Select(doc => doc.Content).ToList();
        data = string.Join(Environment.NewLine, pages.Skip(fromPage - 1).Take(count.Value));
        return data;
    }

    [McpServerTool(Name = "grep_pdf_files"), Description("Search for a regex pattern across multiple PDF files, returning matched pages.")]
    public static string Find([Description("A list of absolute paths to PDF files to search.")] string[] files
    , [Description("The regular expression pattern to match against each page.")] string pattern
    , [Description("The maximum number of matched pages to return across all files.")] int max = 100)
    {
        var data = new StringBuilder();
        var totalCount = 0;
        if (files == null || files.Length == 0)
        {
            throw new McpException("The full path list of the PDF file cannot be empty or null.");
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

        foreach (var file in files)
        {
            if (totalCount >= max) break;
            try
            {
                FileChecker.CheckPdfFile(file);

            }
            catch (Exception ex)
            {
                data.AppendLine($"Error checking file `{file}`: {ex.Message}");
                continue;
            }
            var docs = CacheReader.ReadPdfFileDocument(file);
            var tableBody = new List<List<object?>>();
            foreach (var doc in docs)
            {
                if (doc.Content != null && regex.IsMatch(CharacterConverter.Normalize(doc.Content)))
                {
                    totalCount++;
                    tableBody.Add(new List<object?> { doc.Metadata["PageNumber"], doc.Content });
                    if (totalCount >= max) break;
                }
            }
            if (tableBody.Count > 0)
            {
                data.AppendLine($"`{tableBody.Count}` results in `{file}`:");
                data.AppendLine(MarkdownHelper.MakeMarkdownTable(new List<string> { "Page", "Content" }, tableBody));
            }
        }

        data.Insert(0, $"Found a total of `{totalCount}` results for `{pattern}` in all files.");
        return data.ToString();
    }
}
