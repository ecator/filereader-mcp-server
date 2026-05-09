using JiebaNet.Segmenter.Common;
using System.Text;

namespace FileReaderMcpServer.Utils;

/// <summary>
/// Provides helper methods for formatting Markdown content.
/// </summary>
public static class MarkdownHelper
{
    /// <summary>
    /// Creates a markdown table from a header and a body.
    /// </summary>
    /// <param name="header">The list of column headers.</param>
    /// <param name="body">The 2D list of table body values.</param>
    /// <returns>A formatted markdown table string.</returns>
    /// <exception cref="ArgumentException">Thrown when header or body is invalid.</exception>
    public static string MakeMarkdownTable(List<string> header, List<List<object?>> body)
    {
        if (header == null || header.Count == 0)
        {
            throw new ArgumentException("Header cannot be null or empty.");
        }

        if (body == null || body.Count == 0)
        {
            throw new ArgumentException("Body cannot be null or empty.");
        }

        int columnCount = header.Count;

        StringBuilder sb = new StringBuilder();

        // Build header row
        sb.AppendLine(header.Select(i => EscapeMarkdownTableValue(i)).Join("|"));

        // Build separator row
        sb.AppendLine(Enumerable.Repeat("---", columnCount).Join("|"));

        // Build body rows
        foreach (var row in body)
        {
            if (row.Count != columnCount)
            {
                throw new ArgumentException($"Row column count ({row.Count}) does not match header column count ({columnCount}).");
            }
            sb.AppendLine(row.Select(i => EscapeMarkdownTableValue(i?.ToString() ?? "")).Join("|"));
        }

        return sb.ToString().TrimEnd();
    }

    /// <summary>
    /// Escape the value of the markdown table
    /// </summary>
    /// <param name="val">Value that requires escaping.</param>
    /// <returns></returns>
    public static string EscapeMarkdownTableValue(string val)
    {
        if (string.IsNullOrEmpty(val))
        {
            return val;
        }
        val = val.Replace("\n", "<br>");
        val = val.Replace("\r", "");
        val = val.Replace("\\", "\\\\");
        val = val.Replace("|", "\\|");
        return val;
    }
}
