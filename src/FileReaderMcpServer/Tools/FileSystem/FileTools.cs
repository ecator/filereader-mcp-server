using ElBruno.BM25;
using FileReaderMcpServer.Search;
using FileReaderMcpServer.Tools;
using FileReaderMcpServer.Tools.Office;
using FileReaderMcpServer.Utils;
using JiebaNet.Segmenter.Common;
using Microsoft.Office.Interop.Word;
using ModelContextProtocol;
using ModelContextProtocol.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using SearchDocument = FileReaderMcpServer.Search.Document;
namespace FileReaderMcpServer.Tools.FileSystem;

[McpServerToolType]
public static class FileTools

{

    
    [McpServerTool(Name = "list_allowed_directories"), Description("Get all the allowed directories.")]
    public static string ListAllowedDirectories()
    {
        var cnt = GlobalState.AllowedDirectories.Count;
        var sb = new StringBuilder();
        sb.AppendLine($"There are {cnt} allowed directories:");
        for(var i=0; i<cnt; i++)
        {
            sb.AppendLine($"{i+1}. {GlobalState.AllowedDirectories[i]}");
        }
        return sb.ToString();
    }

    [McpServerTool(Name = "list_allowed_extensions"), Description("Get all the allowed file extensions.")]
    public static string ListAllowedExtensions()
    {
        var cnt = GlobalState.ALLOWED_EXTENSIONS.Length;
        var sb  = new StringBuilder();
        sb.AppendLine($"There are {cnt} allowed file extensions:");
        sb.AppendLine("- Excel");
        foreach(var ext in GlobalState.ALLOWED_EXTENSIONS_EXCEL)
        {
            sb.AppendLine($"  - {ext}");
        }
        sb.AppendLine("- Word");
        foreach (var ext in GlobalState.ALLOWED_EXTENSIONS_WORD)
        {
            sb.AppendLine($"  - {ext}");
        }
        sb.AppendLine("- PowerPoint");
        foreach (var ext in GlobalState.ALLOWED_EXTENSIONS_PPT)
        {
            sb.AppendLine($"  - {ext}");
        }
        sb.AppendLine("- PDF");
        foreach (var ext in GlobalState.ALLOWED_EXTENSIONS_PDF)
        {
            sb.AppendLine($"  - {ext}");
        }
        sb.AppendLine("- Text");
        foreach (var ext in GlobalState.ALLOWED_EXTENSIONS_TEXT)
        {
            sb.AppendLine($"  - {ext}");
        }

        return sb.ToString();
    }

    [McpServerTool(Name = "list_files"), Description("List and rank files in a directory using BM25 search on names, with keyword fallback.")]
    public static string ListFiles(
        [Description("The directory path to list files from.")] string directory,
        [Description("Optional array of keywords to filter and rank files by file and directory name. If not specified, all files will be included.")] string[]? keywords = null,
        [Description("Optional array of file extensions to include (e.g. 'xlsx', 'txt'). If not specified, all allowed extensions will be included. You can call `list_allowed_extensions` to see all allowed extensions.")] string[]? extensions = null,
        [Description("Whether to search recursively in all subdirectories.")] bool recurse = false,
        [Description("The maximum number of files to return.")] int top = 10)
    {
        FileChecker.CheckDirectory(directory);

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

        var resultsToReturn = new List<string>();
        var searchResults = new List<SearchDocument>();
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

            // BM25 search on document content tokens
            var bm25Search = new BM25Search(docs);
            var queryTokens = keywords.Select(kw => Tokenizer.Tokenize(kw, GlobalState.Language)).SelectMany(t => t).ToList();
            searchResults = bm25Search.Search(queryTokens);
            resultsToReturn = searchResults.Take(top).Select(d => d.FilePath).ToList();

            // Fallback: keyword match on content if not enough results
            if (resultsToReturn.Count < top)
            {
                foreach (var doc in docs)
                {
                    foreach (var kw in keywords)
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
        if (searchResults.Count > top)
        {
            sb.AppendLine($"There are {searchResults.Count} matched files in '{directory}' but only the top {top} are shown:");
        }
        else
        {
            sb.AppendLine($"There are {resultsToReturn.Count} matched files in '{directory}':");
        }

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
        FileChecker.CheckDirectory(directory);

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

    [McpServerTool(Name = "search_files"), Description("Full-text search across files in a directory using BM25 ranking with keyword fallback.")]
    public static string SearchFiles(
        [Description("The directory path to search files in.")] string directory,
        [Description("Keywords to match against file content.")] string[] keywords,
        [Description("Optional array of file extensions to include (e.g. 'xlsx', 'txt'). If not specified, all allowed extensions will be included.")] string[]? extensions = null,
        [Description("Whether to search recursively in all subdirectories.")] bool recurse = false,
        [Description("The maximum number of matched documents to return.")] int top = 10)
    {
        FileChecker.CheckDirectory(directory);

        if (extensions == null || extensions.Length == 0)
        {
            extensions = GlobalState.ALLOWED_EXTENSIONS;
        }

        var searchOption = recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        var extSet = new HashSet<string>(extensions.Select(e => e.TrimStart('.')), StringComparer.OrdinalIgnoreCase);
        var excelExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_EXCEL, StringComparer.OrdinalIgnoreCase);
        var wordExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_WORD, StringComparer.OrdinalIgnoreCase);
        var pptExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_PPT, StringComparer.OrdinalIgnoreCase);
        var pdfExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_PDF, StringComparer.OrdinalIgnoreCase);
        var textExtSet = new HashSet<string>(GlobalState.ALLOWED_EXTENSIONS_TEXT, StringComparer.OrdinalIgnoreCase);

        // Collect matched files
        List<string> matchedFiles = new List<string>();
        try
        {
            foreach (var file in Directory.EnumerateFiles(directory, "*.*", searchOption))
            {
                var ext = Path.GetExtension(file).TrimStart('.').ToLowerInvariant();
                if (extSet.Contains(ext) && FileChecker.CheckFileIsAllowed(file, false))
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
        bool timedOut = false;

        ExcelSession? excelSession = null;
        WordSession? wordSession = null;
        PowerPointSession? pptSession = null;

        var stopwatch = Stopwatch.StartNew();
        var timeoutSeconds = GlobalState.Timeout;

        try
        {
            foreach (var file in matchedFiles)
            {
                // Check timeout before processing each file
                if (stopwatch.Elapsed.TotalSeconds >= timeoutSeconds)
                {
                    timedOut = true;
                    break;
                }

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
                    else if (pdfExtSet.Contains(ext))
                    {
                        var docs = CacheReader.ReadPdfFileDocument(file);
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
        var queryTokens = keywords.Select(kw => Tokenizer.Tokenize(kw, GlobalState.Language)).SelectMany(t => t).ToList();
        var bm25Search = new BM25Search(allDocs);
        var searchResults = bm25Search.Search(queryTokens);
        var resultsToReturn = searchResults.Take(top).ToList();

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

                foreach (var kw in keywords)
                {
                    var ext = Path.GetExtension(doc.FilePath).TrimStart('.').ToLowerInvariant();
                    var content = doc.Tokens.Join("");
                    if (GlobalState.Language == "en")
                    {
                        content = doc.Tokens.Join(" ");
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

        // Build output csv
        var sb = new StringBuilder();
        var csvBody = new List<List<object>>();
        if (timedOut)
        {
            sb.AppendLine($"[WARNING] File loading timed out after {timeoutSeconds} seconds. Only {allDocs.Count} documents from {matchedFiles.Count} files were indexed, results may be incomplete.");
        }
        if(searchResults.Count > top)
        {
            sb.AppendLine($"There are {searchResults.Count} matched documents in '{directory}' but only the top {top} are shown:");
        }
        else
        {
            sb.AppendLine($"There are {resultsToReturn.Count} matched documents in '{directory}':");
        }
        
        for (int i = 0; i < resultsToReturn.Count; i++)
        {
            var doc = resultsToReturn[i];
            string pageSheet = GetPageSheet(doc);
            csvBody.Add(new List<object> { i + 1, doc.FilePath, pageSheet });
        }
        if (csvBody.Count > 0)
        {
            sb.AppendLine("```csv");
            sb.AppendLine(CsvHelper.MakeCsv(csvBody, new List<string> { "No", "File", "Page/Sheet" }));
            sb.AppendLine("```");
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
