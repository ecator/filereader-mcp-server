using JiebaNet.Segmenter.Common;
using System.Text;

namespace FileReaderMcpServer.Utils;

/// <summary>
/// Provides helper methods for formatting CSV content.
/// </summary>
public static class CsvHelper
{
    /// <summary>
    /// Creates a CSV string from a body and an optional header.
    /// </summary>
    /// <param name="body">The 2D list of table body values.</param>
    /// <param name="header">The optional list of column headers.</param>
    /// <returns>A formatted CSV string.</returns>
    /// <exception cref="ArgumentException">Thrown when body is invalid or row counts mismatch.</exception>
    public static string MakeCsv(List<List<object?>> body, List<string>? header = null)
    {
        if (body == null || body.Count == 0)
        {
            throw new ArgumentException("Body cannot be null or empty.");
        }

        StringBuilder sb = new StringBuilder();

        int? columnCount = null;

        // Build header row if provided
        if (header != null && header.Count > 0)
        {
            columnCount = header.Count;
            sb.AppendLine(header.Select(i => EscapeCsvValue(i)).Join(","));
        }

        // Build body rows
        foreach (var row in body)
        {
            if (!columnCount.HasValue)
            {
                columnCount = row.Count;
            }
            else if (row.Count != columnCount.Value)
            {
                throw new ArgumentException($"Row column count ({row.Count}) does not match expected column count ({columnCount.Value}).");
            }

            sb.AppendLine(row.Select(i => EscapeCsvValue(i?.ToString() ?? "")).Join(","));
        }

        return sb.ToString().TrimEnd();
    }

    /// <summary>
    /// Escape the value for CSV format
    /// </summary>
    /// <param name="val">Value that requires escaping.</param>
    /// <returns></returns>
    public static string EscapeCsvValue(string val)
    {
        if (string.IsNullOrEmpty(val))
        {
            return "";
        }

        bool needsQuotes = val.Contains(",") || val.Contains("\"") || val.Contains("\n") || val.Contains("\r");
        if (needsQuotes)
        {
            val = val.Replace("\"", "\"\"");
            return $"\"{val}\"";
        }
        return val;
    }
}
