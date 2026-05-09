using ModelContextProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace FileReaderMcpServer.Tools.Office;

/// <summary>
/// Manages an Word Application instance and its associated COM objects, ensuring proper release.
/// Implements IDisposable for use with 'using' statements.
/// </summary>
public class WordSession : Session<Word.Application>
{

    /// <summary>
    /// Initializes a new Word session with lazy Application creation.
    /// The Word COM application is NOT started until first use.
    /// </summary>
    /// <param name="visible">Whether the Word application should be visible.</param>
    /// <param name="displayAlerts">Whether Word should display alerts (e.g., save prompts).</param>
    public WordSession(bool visible = false, bool displayAlerts = false)
        : base(visible, displayAlerts) { }

    /// <inheritdoc/>
    protected override void EnsureApplicationInitialized()
    {
        if (Application != null) return;
        try
        {
            Application = new Word.Application
            {
                Visible = _visible,
                DisplayAlerts = _displayAlerts ? Word.WdAlertLevel.wdAlertsAll : Word.WdAlertLevel.wdAlertsNone
            };
            RegisterComObject(Application);
        }
        catch (Exception ex)
        {
            Dispose(true);
            throw new McpException($"Failed to create Word application: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Open a Word file.
    /// </summary>
    /// <param name="fullName">The full path of the Word file to open</param>
    /// <param name="readOnly">ReadOnly mode</param>
    /// <returns></returns>
    public Word.Document OpenDocument(string fullName, bool readOnly)
    {
        EnsureApplicationInitialized();
        Word.Document doc = null;
        try
        {
            
            Word.Documents docs = Application.Documents;
            RegisterComObject(docs);

            doc = docs.Open(fullName, Type.Missing, readOnly, Type.Missing);

        }
        catch (Exception ex)
        {
            throw new McpException($"Failed to open Word document: {ex.Message}", ex);
        }
        RegisterComObject(doc);
        return doc;
    }


    /// <summary>
    /// Get the number of pages of the document.
    /// </summary>
    /// <param name="doc">Document</param>
    /// <returns></returns>
    /// <exception cref="McpException"></exception>
    public int GetPageCount(Word.Document doc)
    {
        var pageCount = doc.ComputeStatistics(Word.WdStatistic.wdStatisticPages);

        return pageCount;
    }

    /// <summary>
    /// Get text content of pages.
    /// </summary>
    /// <param name="doc">Document</param>
    /// <returns></returns>
    public List<string> GetPageText(Word.Document doc)
    {
        List<string> pageTexts = new List<string>();
        try
        {
            Word.Range content = doc.Content;
            RegisterComObject(content);
            int pageCount = GetPageCount(doc);
            for (int i = 1; i <= pageCount; i++)
            {
                Word.Range pageRange = doc.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, i);
                RegisterComObject(pageRange);
                var pageRangeEnd = content.End;
                if (i < pageCount)
                {
                    var nextPage = doc.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, i + 1);
                    RegisterComObject(nextPage);
                    pageRangeEnd = nextPage.Start;
                }
                pageRange.End = pageRangeEnd;
                string pageText = pageRange.Text;
                pageTexts.Add(pageText);
            }
        }
        catch (Exception ex)
        {
            throw new McpException($"Failed to get page text: {ex.Message}", ex);
        }
        return pageTexts;
    }

}
