using ModelContextProtocol;
using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using FileReaderMcpServer.Tools;
using FileReaderMcpServer.Search;
using SearchDocument = FileReaderMcpServer.Search.Document;
using Microsoft.Office.Interop.Word;
using FileReaderMcpServer.Validation;
using Newtonsoft.Json;
using FileReaderMcpServer.Tools.Office;
namespace FileReaderMcpServer.Tools.FileSystem;

[McpServerToolType]
public static class FileTools

{

    
    [McpServerTool(Name = "list_allowed_directories"), Description("Get all the allowed directories that this server can read files from.")]
    public static string ListAllowedDirectories()
    {
        var cnt = GlobalState.AllowedDirectories.Count;
        var result = $"There are {cnt} allowed directories:";
        for(var i=0; i<cnt; i++)
        {
            result += $"\n{i+1}. {GlobalState.AllowedDirectories[i]}";
        }
        return result;
    }

    [McpServerTool(Name = "list_allowed_extensions"), Description("Get all the allowed file extensions that this server can read.")]
    public static string ListAllowedExtensions()
    {
        var cnt = GlobalState.ALLOWED_EXTENSIONS.Length;
        var result = $"There are {cnt} allowed file extensions:";
        for(var i=0; i<cnt; i++)
        {
            result += $"\n{i+1}. {GlobalState.ALLOWED_EXTENSIONS[i]}";
        }
        return result;
    }

    [McpServerTool(Name = "list_files"), Description("List files in a directory with optional keyword filtering and BM25 search on file and directory name.\nWhen the returned results are insufficient, keyword match will be used as a fallback.")]
    public static string ListFiles(
        [Description("The directory path to list files from.")] string directory,
        [Description("Optional array of keywords to filter and rank files by file and directory name. If not specified, all files will be included.")] string[]? keywords = null,
        [Description("Optional array of file extensions to include (e.g. 'xlsx', 'txt'). If not specified, all allowed extensions will be included. You can call `list_allowed_extensions` to see all allowed extensions.")] string[]? extensions = null,
        [Description("Whether to search recursively in all subdirectories.")] bool recurse = false,
        [Description("The maximum number of files to return.")] int top = 10)
    {
        directory = FileChecker.CheckDirectory(directory);

        if (extensions == null || extensions.Length == 0)
        {
            extensions = GlobalState.ALLOWED_EXTENSIONS;
        }

        var searchOption = recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        var extSet = new HashSet<string>(extensions.Select(e => e.TrimStart('.')), StringComparer.OrdinalIgnoreCase);

        List<string> matchedFiles = new List<string>();
        try
        {
            foreach (var file in Directory.EnumerateFiles(directory, "*.*", searchOption))
            {
                var ext = Path.GetExtension(file).TrimStart('.');
                if (extSet.Contains(ext))
                {
                    matchedFiles.Add(file);
                }
            }
        }
        catch (Exception ex)
        {
            throw new McpException($"{ex.Message}");
        }

        var relativePaths = new List<string>();
        string dirPrefix = directory;
        if (!dirPrefix.EndsWith(Path.DirectorySeparatorChar.ToString()) && !dirPrefix.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
        {
            dirPrefix += Path.DirectorySeparatorChar;
        }

        foreach (var f in matchedFiles)
        {
            if (f.StartsWith(dirPrefix, StringComparison.OrdinalIgnoreCase))
            {
                relativePaths.Add(f.Substring(dirPrefix.Length));
            }
            else
            {
                relativePaths.Add(f);
            }
        }

        List<string> resultsToReturn = new List<string>();
        if (keywords == null || keywords.Length == 0)
        {
            resultsToReturn = relativePaths.Take(top).ToList();
        }
        else
        {
            var docs = new List<SearchDocument>();

            foreach (var f in relativePaths)
            {
                string fileName = Path.GetFileNameWithoutExtension(f);
                var TokensContent = f.Substring(0, f.Length - Path.GetExtension(f).Length).Replace(Path.DirectorySeparatorChar.ToString(), "\n").Replace(Path.AltDirectorySeparatorChar.ToString(), "\n");
                var doc = new SearchDocument
                {
                    FilePath = f,
                    Tokens = Tokenizer.Tokenize(TokensContent)
                };
                docs.Add(doc);
            }

            var bm25Search = new BM25Search(docs);
            var queryTokens = keywords.Select(kw => kw.ToLowerInvariant()).ToList();
            var searchResults = bm25Search.Search(queryTokens, top);
            resultsToReturn = searchResults.Select(d => d.FilePath).ToList();
            if (resultsToReturn.Count < top)
            {
                foreach (var doc in docs)
                {
                    foreach (var kw in queryTokens)
                    {
                        if (doc.FilePath.Contains(kw, StringComparison.OrdinalIgnoreCase) && !resultsToReturn.Contains(doc.FilePath))
                        {
                            resultsToReturn.Add(doc.FilePath);
                            break;
                        }
                    }
                    if (resultsToReturn.Count >= top)
                    {
                        break;
                    }
                }
            }
        }


        var sb = new StringBuilder();
        sb.AppendLine($"There are {resultsToReturn.Count} matched files in {directory}:");
        for (int i = 0; i < resultsToReturn.Count; i++)
        {
            sb.AppendLine($"{i + 1}. {resultsToReturn[i]}");
        }

        return sb.ToString().TrimEnd();
    }

    [McpServerTool(Name = "list_directory_tree"), Description("List the directory tree structure up to a specified depth.")]
    public static string ListDirectoryTree(
        [Description("The base directory path to start listing from.")] string directory,
        [Description("The maximum depth of the directory tree to output.")] int maxDepth = 5)
    {
        directory = FileChecker.CheckDirectory(directory);

        var sb = new StringBuilder();
        sb.AppendLine(directory);
        BuildDirectoryTree(directory, sb, 0, maxDepth);

        return sb.ToString().TrimEnd();
    }

    private static void BuildDirectoryTree(string dir, StringBuilder sb, int currentDepth, int maxDepth)
    {
        if (currentDepth >= maxDepth)
        {
            return;
        }

        try
        {
            var subDirs = Directory.GetDirectories(dir);
            Array.Sort(subDirs);
            foreach (var subDir in subDirs)
            {
                var dirName = Path.GetFileName(subDir);
                sb.AppendLine(new string(' ', (currentDepth + 1) * 2) + dirName);
                BuildDirectoryTree(subDir, sb, currentDepth + 1, maxDepth);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Ignore directories we don't have access to
        }
        catch (Exception)
        {
            // Ignore other exceptions
        }
    }

    [McpServerTool(Name = "search_files"), Description("Search files in a directory by their content using BM25 ranking.\nWhen BM25 results are insufficient, keyword match on file content is used as fallback.\nReturns a table showing the file path and the specific page/sheet where the keywords were found.")]
    public static string SearchFiles(
        [Description("The directory path to search files in.")] string directory,
        [Description("Keywords to match against file content.")] string[] keywords,
        [Description("Optional array of file extensions to include (e.g. 'xlsx', 'txt'). If not specified, all allowed extensions will be included. You can call `list_allowed_extensions` to see all allowed extensions.")] string[]? extensions = null,
        [Description("Whether to search recursively in all subdirectories.")] bool recurse = false,
        [Description("The maximum number of matched documents to return.")] int top = 10)
    {
        directory = FileChecker.CheckDirectory(directory);

        if (extensions == null || extensions.Length == 0)
        {
            extensions = GlobalState.ALLOWED_EXTENSIONS;
        }

        var searchOption = recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        var extSet = new HashSet<string>(extensions.Select(e => e.TrimStart('.')), StringComparer.OrdinalIgnoreCase);
        var excelExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_EXCEL, StringComparer.OrdinalIgnoreCase);
        var wordExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_WORD, StringComparer.OrdinalIgnoreCase);
        var pptExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_PPT, StringComparer.OrdinalIgnoreCase);
        var textExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_TEXT, StringComparer.OrdinalIgnoreCase);

        // Collect matched files
        List<string> matchedFiles = new List<string>();
        try
        {
            foreach (var file in Directory.EnumerateFiles(directory, "*.*", searchOption))
            {
                var ext = Path.GetExtension(file).TrimStart('.').ToLowerInvariant();
                if (extSet.Contains(ext))
                {
                    matchedFiles.Add(file);
                }
            }
        }
        catch (Exception ex)
        {
            throw new McpException($"{ex.Message}");
        }

        // Load documents (one per page/sheet/slide) from each file
        var allDocs = new List<SearchDocument>();

        ExcelSession? excelSession = null;
        WordSession? wordSession = null;
        PowerPointSession? pptSession = null;

        try
        {
            foreach (var file in matchedFiles)
            {
                var ext = Path.GetExtension(file).TrimStart('.').ToLowerInvariant();
                try
                {
                    if (excelExtSet.Contains(ext))
                    {
                        excelSession ??= new ExcelSession();
                        var docs = CacheReader.ReadExcelFileDocument(excelSession, file);
                        allDocs.AddRange(docs);
                    }
                    else if (wordExtSet.Contains(ext))
                    {
                        wordSession ??= new WordSession();
                        var docs = CacheReader.ReadWordFileDocument(wordSession, file);
                        allDocs.AddRange(docs);
                    }
                    else if (pptExtSet.Contains(ext))
                    {
                        pptSession ??= new PowerPointSession();
                        var docs = CacheReader.ReadPowerPointFileDocument(pptSession, file);
                        allDocs.AddRange(docs);
                    }
                    else if (textExtSet.Contains(ext))
                    {
                        var doc = CacheReader.ReadTextFileDocument(file);
                        allDocs.Add(doc);
                    }
                }
                catch (Exception)
                {
                    // Skip files that cannot be read
                }
            }
        }
        finally
        {
            excelSession?.Dispose();
            wordSession?.Dispose();
            pptSession?.Dispose();
        }

        // BM25 search on document content tokens
        var queryTokens = keywords.Select(kw => kw.ToLowerInvariant()).ToList();
        var bm25Search = new BM25Search(allDocs);
        var searchResults = bm25Search.Search(queryTokens, top);
        var resultsToReturn = searchResults.ToList();

        // Fallback: keyword match on content if not enough results
        if (resultsToReturn.Count < top)
        {
            var resultPaths = new HashSet<string>(
                resultsToReturn.Select(d => $"{d.FilePath}#{GetPageSheet(d)}"),
                StringComparer.OrdinalIgnoreCase);

            foreach (var doc in allDocs)
            {
                var docKey = $"{doc.FilePath}#{GetPageSheet(doc)}";
                if (resultPaths.Contains(docKey)) continue;

                foreach (var kw in queryTokens)
                {
                    var ext = Path.GetExtension(doc.FilePath).TrimStart('.').ToLowerInvariant();
                    var content = doc.Content;
                    if (excelExtSet.Contains(ext))
                    {
                        content = string.Join("\n",JsonConvert.DeserializeObject<Dictionary<string,object>>(doc.Content).Select(kv => kv.Value.ToString()));

                    }
                    if (content.Contains(kw, StringComparison.OrdinalIgnoreCase))
                    {
                        resultsToReturn.Add(doc);
                        resultPaths.Add(docKey);
                        break;
                    }
                }

                if (resultsToReturn.Count >= top) break;
            }
        }

        // Build output table
        var sb = new StringBuilder();
        sb.AppendLine($"There are {resultsToReturn.Count} matched documents in {directory}:");
        if (resultsToReturn.Count > 0)
        {
            sb.AppendLine("No|File|Page/Sheet");
            sb.AppendLine("---|---|---");
        }
        for (int i = 0; i < resultsToReturn.Count; i++)
        {
            var doc = resultsToReturn[i];
            var ext = Path.GetExtension(doc.FilePath).TrimStart('.').ToLowerInvariant();
            string pageSheet = GetPageSheet(doc);
            sb.AppendLine($"{i + 1}|{doc.FilePath}|{pageSheet}");
        }

        return sb.ToString().TrimEnd();
    }

    /// <summary>
    /// Returns a unique key string representing the page/sheet/slide of a document, used for deduplication.
    /// </summary>
    private static string GetPageSheet(SearchDocument doc)
    {
        if (doc.Metadata.TryGetValue("SheetName", out var sheet))
            return $"{sheet}";
        if (doc.Metadata.TryGetValue("PageNumber", out var page))
            return $"{page}";
        if (doc.Metadata.TryGetValue("SlideNumber", out var slide))
            return $"{slide}";
        return string.Empty;
    }
}
