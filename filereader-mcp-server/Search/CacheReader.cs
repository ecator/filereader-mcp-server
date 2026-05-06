using FileReaderMcpServer.Tools.Office;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace FileReaderMcpServer.Search
{
    public static class CacheReader
    {
        public static string EnsureAndGetCacheFolder()
        {
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var cachePath = Path.Combine(userProfile, ".filereader-mcp-server", ".cache");
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            return cachePath;
        }

        public static string EnsureAndGetCacheFolder(string key)
        {
            var cachePath = Path.Combine(EnsureAndGetCacheFolder(), GetSha256(key));
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            return cachePath;
        }

        public static string GetKeyFromFilePath(string file)
        {
            file = file.Replace("\\", "/");
            foreach (var allowedDir in GlobalState.AllowedDirectories)
            {
                if (file.StartsWith(allowedDir.Replace("\\", "/") + "/", StringComparison.OrdinalIgnoreCase))
                {
                    return allowedDir.ToLowerInvariant();
                }
            }
            throw new ArgumentException($"File '{file}' is not in an allowed directory.");
        }

        public static Document ReadTextFileDocument(string file)
        {
            file = file.ToLowerInvariant();
            var key = GetKeyFromFilePath(file);
            var fileName = GetSha256(file) + ".json";
            var cachePath = Path.Combine(EnsureAndGetCacheFolder(key), fileName);
            Document doc = null;
            var overwriteCache = false;
            if (File.Exists(cachePath))
            {
                var fileUpdatedTime = File.GetLastWriteTime(file);
                var cacheUpdatedTime = File.GetLastWriteTime(cachePath);
                if (fileUpdatedTime > cacheUpdatedTime)
                {
                    overwriteCache = true;
                }
                else
                {
                    doc = JsonConvert.DeserializeObject<Document>(File.ReadAllText(cachePath));
                    if(doc == null)
                    {
                        overwriteCache = true;
                    }
                }
                
            }
            else
            {
                overwriteCache = true;
            }

            if (overwriteCache)
            {
                var fileContent = File.ReadAllText(file);
                doc = new Document
                {
                    FilePath = file,
                    Content = fileContent,
                    Tokens = Tokenizer.Tokenize(fileContent, GlobalState.Language)

                };
                File.WriteAllText(cachePath, JsonConvert.SerializeObject(doc), new UTF8Encoding(false));
            }

            return doc;

        }

        public static List<Document> ReadExcelFileDocument(ExcelSession session, string file)
        {
            file = file.ToLowerInvariant();
            var key = GetKeyFromFilePath(file);
            var fileName = GetSha256(file) + ".json";
            var cachePath = Path.Combine(EnsureAndGetCacheFolder(key), fileName);
            var docs = new List<Document>();
            Document doc = null;
            var overwriteCache = false;
            if (File.Exists(cachePath))
            {
                var fileUpdatedTime = File.GetLastWriteTime(file);
                var cacheUpdatedTime = File.GetLastWriteTime(cachePath);
                if (fileUpdatedTime > cacheUpdatedTime)
                {
                    overwriteCache = true;
                }
                else
                {
                    docs = JsonConvert.DeserializeObject<List<Document>>(File.ReadAllText(cachePath));
                    if (docs == null)
                    {
                        overwriteCache = true;
                    }
                }

            }
            else
            {
                overwriteCache = true;
            }

            if (overwriteCache)
            {
                var wk = session.OpenWorkbook(file, true);

                foreach (Excel.Worksheet sh in session.GetSheets(wk))
                {
                    var values = new Dictionary<string, object>();
                    var range = sh.UsedRange;
                    session.RegisterComObject(range);
                    // Bulk read: one COM call for the entire range instead of per-cell access
                    object[,] data = ExcelSession.GetRangeValues(range);
                    int baseRow = range.Row;
                    int baseCol = range.Column;
                    var rows = range.Rows;
                    session.RegisterComObject(rows);
                    var cols = range.Columns;
                    session.RegisterComObject(cols);
                    int rowCount = rows.Count;
                    int colCount = cols.Count;
                    int endRow = baseRow + rowCount - 1;
                    int endCol = baseCol + colCount - 1;
                    var sb = new StringBuilder();
                    for (int i = 1; i <= rowCount; i++)
                    {
                        var lineValues = new List<string>();
                        for (int j = 1; j <= colCount; j++)
                        {
                            var val = data[i, j];
                            if (val is null) continue;
                            string address = $"{ExcelSession.ColumnIndexToLetter(baseCol + j - 1)}{baseRow + i - 1}";
                            values[address] = val;
                            lineValues.Add(session.EscapeMarkdownTableValue(val.ToString()));
                        }
                        sb.AppendLine(string.Join("\t",lineValues));
                    }
                    var metadata = new Dictionary<string, object>();
                    metadata["SheetName"] = sh.Name;
                    metadata["BaseRow"] = baseRow;
                    metadata["BaseCol"] = baseCol;
                    metadata["EndRow"] = endRow;
                    metadata["EndCol"] = endCol;

                    doc = new Document
                    {
                        FilePath = file,
                        Content = JsonConvert.SerializeObject(values),
                        Tokens = Tokenizer.Tokenize(sb.ToString(), GlobalState.Language),
                        Metadata = metadata

                    };
                    docs.Add(doc);
                }
                
                File.WriteAllText(cachePath, JsonConvert.SerializeObject(docs), new UTF8Encoding(false));
            }

            return docs;

        }

        public static List<Document> ReadWordFileDocument(WordSession session, string file)
        {
            file = file.ToLowerInvariant();
            var key = GetKeyFromFilePath(file);
            var fileName = GetSha256(file) + ".json";
            var cachePath = Path.Combine(EnsureAndGetCacheFolder(key), fileName);
            var docs = new List<Document>();
            Document doc = null;
            var overwriteCache = false;
            if (File.Exists(cachePath))
            {
                var fileUpdatedTime = File.GetLastWriteTime(file);
                var cacheUpdatedTime = File.GetLastWriteTime(cachePath);
                if (fileUpdatedTime > cacheUpdatedTime)
                {
                    overwriteCache = true;
                }
                else
                {
                    docs = JsonConvert.DeserializeObject<List<Document>>(File.ReadAllText(cachePath));
                    if (docs == null)
                    {
                        overwriteCache = true;
                    }
                }

            }
            else
            {
                overwriteCache = true;
            }

            if (overwriteCache)
            {
                var wd = session.OpenDocument(file, true);
                var pages = session.GetPageText(wd);

                for (var i= 0 ;i < pages.Count;i++)
                {
                    var page = pages[i];
                    var metadata = new Dictionary<string, object>();
                    metadata["PageNumber"] = i + 1;
                    doc = new Document
                    {
                        FilePath = file,
                        Content = page,
                        Tokens = Tokenizer.Tokenize(page, GlobalState.Language),
                        Metadata = metadata

                    };
                    docs.Add(doc);
                }

                File.WriteAllText(cachePath, JsonConvert.SerializeObject(docs), new UTF8Encoding(false));
            }

            return docs;

        }

        public static List<Document> ReadPowerPointFileDocument(PowerPointSession session, string file)
        {
            file = file.ToLowerInvariant();
            var key = GetKeyFromFilePath(file);
            var fileName = GetSha256(file) + ".json";
            var cachePath = Path.Combine(EnsureAndGetCacheFolder(key), fileName);
            var docs = new List<Document>();
            Document doc = null;
            var overwriteCache = false;
            if (File.Exists(cachePath))
            {
                var fileUpdatedTime = File.GetLastWriteTime(file);
                var cacheUpdatedTime = File.GetLastWriteTime(cachePath);
                if (fileUpdatedTime > cacheUpdatedTime)
                {
                    overwriteCache = true;
                }
                else
                {
                    docs = JsonConvert.DeserializeObject<List<Document>>(File.ReadAllText(cachePath));
                    if (docs == null)
                    {
                        overwriteCache = true;
                    }
                }

            }
            else
            {
                overwriteCache = true;
            }

            if (overwriteCache)
            {
                var pr = session.OpenPresentation(file, true);
                var slides = pr.Slides;
                session.RegisterComObject(slides);
                for (var i = 1; i <= slides.Count; i++)
                {
                    var slideName = $"Slide{i}";
                    var slide = slides[i];
                    session.RegisterComObject(slide);
                    var shapes = slide.Shapes;
                    session.RegisterComObject(shapes);
                    var shapesText = session.GetShapesText(shapes);
                    var pageText = string.Join("\n",shapesText.Select(kvp =>$"{kvp.Key}\n{kvp.Value}").ToList());
                    var notesPage = slide.NotesPage;
                    session.RegisterComObject(notesPage);
                    var notesShapes = notesPage.Shapes;
                    session.RegisterComObject(notesShapes);
                    var notesShapesText = session.GetShapesText(notesShapes);
                    var notesText = string.Join("\n", notesShapesText.Select(kvp => $"{kvp.Key}\n{kvp.Value}").ToList());
                    var pageContent = $"{pageText}\n\n{notesText}";
                    var metadata = new Dictionary<string, object>();
                    metadata["SlideNumber"] = i;
                    doc = new Document
                    {
                        FilePath = file,
                        Content = pageContent,
                        Tokens = Tokenizer.Tokenize(pageContent, GlobalState.Language),
                        Metadata = metadata

                    };
                    docs.Add(doc);
                }

                File.WriteAllText(cachePath, JsonConvert.SerializeObject(docs), new UTF8Encoding(false));
            }

            return docs;

        }

        public static string GetSha256(string input)
        {
            var hashBytes = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(hashBytes).ToLower();
        }
    }
}
