using ModelContextProtocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Word = Microsoft.Office.Interop.Word;
using Outlook = Microsoft.Office.Interop.Outlook;




namespace FileReaderMcpServer.Tools.Office;

/// <summary>
/// Manages an COM Application instance and its associated COM objects, ensuring proper release.
/// Implements IDisposable for use with 'using' statements.
/// </summary>
public abstract class Session<TApplication> : IDisposable where TApplication : class
{
    protected bool _visible;
    protected bool _displayAlerts;

    protected TApplication Application { get; set; }
    protected List<object> _comObjectsToRelease = new List<object>();
    protected bool _disposed = false;

    /// <summary>
    /// Initializes a new session with the specified visibility and alert settings.
    /// The Application COM object is NOT created here; it is deferred to <see cref="EnsureApplicationInitialized"/>.
    /// </summary>
    /// <param name="visible">Whether the application should be visible.</param>
    /// <param name="displayAlerts">Whether the application should display alerts.</param>
    protected Session(bool visible = false, bool displayAlerts = false)
    {
        _visible = visible;
        _displayAlerts = displayAlerts;
    }

    /// <summary>
    /// Ensures the Application COM object is created (lazy initialization).
    /// Called before the first use of <see cref="Application"/>.
    /// </summary>
    protected abstract void EnsureApplicationInitialized();


    /// <summary>
    /// Registers a COM object to be released when the session is disposed.
    /// </summary>
    /// <typeparam name="T">The type of the COM object.</typeparam>
    /// <param name="obj">The COM object instance.</param>
    public void RegisterComObject<T>(T obj) where T : class
    {
        if (obj != null && Marshal.IsComObject(obj))
        {
            _comObjectsToRelease.Add(obj);
        }
    }

    /// <summary>
    /// Releases a single COM object.
    /// </summary>
    /// <param name="obj">The COM object to release.</param>
    private void ReleaseSingleComObject(object obj)
    {
        if (obj != null && Marshal.IsComObject(obj))
        {
            try
            {
                // Loop to ensure all references are released
                while (Marshal.ReleaseComObject(obj) > 0) { }
            }
            catch (Exception ex)
            {
                // Log or handle the exception if needed, but don't rethrow
                Console.Error.WriteLine($"Warning: Failed to release COM object: {ex.Message}");
            }
        }
    }



    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Prevent finalizer from running
    }

    /// <summary>
    /// Releases all COM objects.
    /// </summary>
    /// <param name="disposing">True if called from Dispose(), false if called from finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            // Release managed resources here if any
        }

        // Release unmanaged resources (COM objects)
        if (Application != null)
        {
            try
            {
                // Before quitting, set DisplayAlerts to false to avoid "Save changes?" prompts
                dynamic dynamicApp = Application;
                if (dynamicApp is Excel.Application)
                {
                    dynamicApp.DisplayAlerts = false;
                    var wks = dynamicApp.Workbooks as Excel.Workbooks;
                    RegisterComObject(wks);
                    // Iterate backwards to safely close all workbooks
                    for (var i = wks.Count; i >= 1; i--)
                    {
                        var wk = wks[i];
                        RegisterComObject(wk);
                        try { wk.Saved = true; } catch { } // Mark as saved to be double sure
                        wk.Close(false);
                    }
                }
                else if (dynamicApp is Word.Application)
                {
                    dynamicApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                    var docs = dynamicApp.Documents as Word.Documents;
                    RegisterComObject(docs);
                    // Iterate backwards to safely close all documents
                    for (var i = docs.Count; i >= 1; i--)
                    {
                        var doc = docs[i];
                        RegisterComObject(doc);
                        try { doc.Saved = true; } catch { } // Mark as saved to be double sure
                        doc.Close(false);
                    }
                }
                else if (dynamicApp is PowerPoint.Application)
                {
                    dynamicApp.DisplayAlerts = PowerPoint.PpAlertLevel.ppAlertsNone;
                    var prs = dynamicApp.Presentations as PowerPoint.Presentations;
                    RegisterComObject(prs);
                    // Iterate backwards to safely close all presentations
                    for (var i = prs.Count; i >= 1; i--)
                    {
                        var pr = prs[i];
                        RegisterComObject(pr);
                        try { pr.Saved = (dynamic)(-1); } catch { } // msoTrue is -1
                        pr.Close();
                    }
                }
                if (!(dynamicApp is Outlook.Application))
                {
                    dynamicApp.Quit();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Warning: Failed to quit COM Application: {ex.Message}");
            }
            finally
            {
                // Release unmanaged resources (COM objects)
                for (int i = _comObjectsToRelease.Count - 1; i >= 0; i--)
                {
                    ReleaseSingleComObject(_comObjectsToRelease[i]);
                }
                _comObjectsToRelease.Clear();
            }
        }

        _disposed = true;
    }

    /// <summary>
    /// Finalizer (destructor) in case Dispose is not called explicitly.
    /// </summary>
    ~Session()
    {
        Dispose(false);
    }
}
