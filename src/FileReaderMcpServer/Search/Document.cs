using System;
using System.Collections.Generic;

namespace FileReaderMcpServer.Search;

/// <summary>
/// Represents a document (file) in the search system.
/// </summary>
public class Document
{
    public string FilePath { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<string>? Tokens { get; set; }
    public string? Snippet { get; set; }
    public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
}
