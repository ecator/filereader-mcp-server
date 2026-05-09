using ModelContextProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Text.RegularExpressions;
using Microsoft.Office.Core;
using FileReaderMcpServer.Utils;

namespace FileReaderMcpServer.Tools.Office;

/// <summary>
/// Manages an PowerPoint Application instance and its associated COM objects, ensuring proper release.
/// Implements IDisposable for use with 'using' statements.
/// </summary>
public class PowerPointSession : Session<PowerPoint.Application>
{
    /// <summary>
    /// Initializes a new PowerPoint session with lazy Application creation.
    /// The PowerPoint COM application is NOT started until first use.
    /// </summary>
    /// <param name="visible">Whether the PowerPoint application should be visible.</param>
    /// <param name="displayAlerts">Whether PowerPoint should display alerts (e.g., save prompts).</param>
    public PowerPointSession(bool visible = true, bool displayAlerts = false)
        : base(visible, displayAlerts) { }

    /// <inheritdoc/>
    protected override void EnsureApplicationInitialized()
    {
        if (Application != null) return;
        try
        {
            Application = new PowerPoint.Application();
            Application.Visible = _visible ? MsoTriState.msoTrue : MsoTriState.msoFalse;
            Application.DisplayAlerts = _displayAlerts ? PowerPoint.PpAlertLevel.ppAlertsAll : PowerPoint.PpAlertLevel.ppAlertsNone;
            RegisterComObject(Application);
        }
        catch (Exception ex)
        {
            Dispose(true);
            throw new McpException($"Failed to create PowerPoint application: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Open a PowerPoint file.
    /// </summary>
    /// <param name="fullName">The full path of the PowerPoint file to open</param>
    /// <param name="readOnly">ReadOnly mode</param>
    /// <returns></returns>
    public PowerPoint.Presentation OpenPresentation(string fullName, bool readOnly)
    {
        EnsureApplicationInitialized();
        PowerPoint.Presentation pr = null;
        try
        {

            PowerPoint.Presentations prs = Application.Presentations;
            RegisterComObject(prs);
            pr = prs.Open(fullName, readOnly ? MsoTriState.msoTrue : MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoTrue);
        }
        catch (Exception ex)
        {
            throw new McpException($"Failed to open PowerPoint: {ex.Message}", ex);
        }
        RegisterComObject(pr);
        return pr;
    }

    /// <summary>
    /// Get the number of slides of the presentation.
    /// </summary>
    /// <param name="pr">Presentation</param>
    /// <returns></returns>
    /// <exception cref="McpException"></exception>
    public int GetSlideCount(PowerPoint.Presentation pr)
    {
        var slides = pr.Slides;
        RegisterComObject(slides);

        return slides.Count;
    }

    /// <summary>
    /// Get the text of shapes.
    /// </summary>
    /// <param name="shapes">Shapes</param>
    /// <returns></returns>
    /// <exception cref="McpException"></exception>
    public Dictionary<string, string> GetShapesText(PowerPoint.Shapes shapes)
    {
        var dic = new Dictionary<string, string>();
        for (var i = 1; i <= shapes.Count; i++)
        {
            PowerPoint.Shape shape = shapes[i];
            RegisterComObject(shape);
            if (shape.HasTextFrame == MsoTriState.msoTrue)
            {
                var textFrame = shape.TextFrame;
                RegisterComObject(textFrame);
                if (textFrame.HasText == MsoTriState.msoTrue)
                {
                    var textRange = textFrame.TextRange;
                    RegisterComObject(textRange);
                    dic[shape.Name] = textRange.Text;
                }

            }
            if (shape.Type == MsoShapeType.msoTable)
            {
                var table = shape.Table;
                RegisterComObject(table);
                var rows = table.Rows;
                RegisterComObject(rows);
                var columns = table.Columns;
                RegisterComObject(columns);
                var tableText = new StringBuilder();
                var line = new string[columns.Count];
                for (var r = 1; r <= rows.Count; r++)
                {
                    if (r == 2)
                    {
                        Array.Fill(line, "---");
                        tableText.AppendLine(string.Join("|", line));
                    }
                    for (var c = 1; c <= columns.Count; c++)
                    {
                        var cell = table.Cell(r, c);
                        RegisterComObject(cell);
                        var cellShape = cell.Shape;
                        RegisterComObject(cellShape);
                        var cellText = string.Empty;
                        if (cellShape.HasTextFrame == MsoTriState.msoTrue)
                        {
                            var cellTextFrame = cellShape.TextFrame;
                            RegisterComObject(cellTextFrame);
                            if (cellTextFrame.HasText == MsoTriState.msoTrue)
                            {
                                var cellTextRange = cellTextFrame.TextRange;
                                RegisterComObject(cellTextRange);
                                cellText = MarkdownHelper.EscapeMarkdownTableValue(cellTextRange.Text);
                            }
                        }
                        line[c - 1] = cellText;
                    }
                    tableText.AppendLine(string.Join("|", line));
                }
                dic[shape.Name] = tableText.ToString();
            }
        }

        return dic;
    }

}
