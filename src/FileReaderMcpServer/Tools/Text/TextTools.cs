using ModelContextProtocol;
using ModelContextProtocol.Server;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using FileReaderMcpServer.Search;
using FileReaderMcpServer.Utils;

namespace FileReaderMcpServer.Tools.Text;

[McpServerToolType]
public static class TextTools
{
    [McpServerTool(Name = "text_read"), Description("Read content from a text file, optionally from a specific line and for a specific number of lines.")]
    public static string Read(
        [Description("The absolute path of the text file to read.")] string file,
        [Description("The starting line number (1-indexed).")] int startLine = 1,
        [Description("The number of lines to read.")] int count = 1000)
    {
        FileChecker.CheckTextFile(file);

        if (startLine < 1)
        {
            startLine = 1;
        }
        
        if (count < 1)
        {
            count = 1000;
        }

        try
        {
            var doc = CacheReader.ReadTextFileDocument(file);
            var content = doc.Content;
            var lines = content.Replace("\r\n", "\n").Split('\n').Skip(startLine - 1).Take(count);
            var result = string.Join(Environment.NewLine, lines);
            return result;
        }
        catch (Exception ex)
        {
            throw new McpException($"{ex.Message}");
        }
    }

    [McpServerTool(Name = "text_get_lines"), Description("Get the number of lines in a text file.")]
    public static string GetLines(
        [Description("The absolute path of the text file.")] string file)
    {
        FileChecker.CheckTextFile(file);

        try
        {
            var doc = CacheReader.ReadTextFileDocument(file);
            var content = doc.Content;
            var lineCount = content.Split('\n').Length;
            return $"The file '{file}' has {lineCount} lines";
        }
        catch (Exception ex)
        {
            throw new McpException($"{ex.Message}");
        }
    }

    [McpServerTool(Name = "text_grep_files"), Description("Search for a regex pattern in multiple text files.")]
    public static string GrepFiles(
        [Description("The list of text files to search.")] string[] files,
        [Description("The regular expression pattern to match against each line.")] string pattern,
        [Description("The maximum number of matched lines to return across all files.")] int max = 1000)
    {
        if (files == null || files.Length == 0) return "No files provided.";
        if (string.IsNullOrEmpty(pattern)) return "Pattern cannot be empty.";
        if (max < 1) max = 1000;

        Regex regex;
        try
        {
            regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        catch (Exception ex)
        {
            throw new McpException($"Invalid regex pattern: {ex.Message}");
        }

        var sb = new StringBuilder();
        int totalMatches = 0;

        foreach (var file in files)
        {
            if (totalMatches >= max) break;

            try
            {
                FileChecker.CheckTextFile(file);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"- Error accessing {file}: {ex.Message}");
                continue;
            }

            var fileMatches = new List<(int lineNumber, string lineContent)>();

            try
            {
                int lineNumber = 0;
                var doc = CacheReader.ReadTextFileDocument(file);
                var content = doc.Content;
                var lines = content.Replace("\r\n", "\n").Split('\n');
                foreach (var line in lines)
                {
                    lineNumber++;
                    if (regex.IsMatch(line))
                    {
                        fileMatches.Add((lineNumber, line));
                        if (totalMatches + fileMatches.Count >= max)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"- Error reading {file}: {ex.Message}");
                continue;
            }

            if (fileMatches.Count > 0)
            {
                sb.AppendLine($"- {fileMatches.Count} matched lines in {file}");
                foreach (var match in fileMatches)
                {
                    sb.AppendLine($"  - {match.lineNumber} : {match.lineContent}");
                }
                totalMatches += fileMatches.Count;
            }
        }

        if(totalMatches == 0)
        {
            sb.AppendLine("No matches found.");
        }

        return sb.ToString().TrimEnd();
    }
}
