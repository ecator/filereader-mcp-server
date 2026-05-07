namespace FileReaderMcpServer.Utilities;

/// <summary>
/// Provides helper methods for formatting Markdown content.
/// </summary>
public static class MarkdownHelper
{
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
