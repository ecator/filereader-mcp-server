using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using ModelContextProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace FileReaderMcpServer.Tools.Office;

/// <summary>
/// Manages an Excel Application instance and its associated COM objects, ensuring proper release.
/// Implements IDisposable for use with 'using' statements.
/// </summary>
public class ExcelSession : Session<Excel.Application>
{
    /// <summary>
    /// Initializes a new Excel session with lazy Application creation.
    /// The Excel COM application is NOT started until first use.
    /// </summary>
    /// <param name="visible">Whether the Excel application should be visible.</param>
    /// <param name="displayAlerts">Whether Excel should display alerts (e.g., save prompts).</param>
    public ExcelSession(bool visible = false, bool displayAlerts = false)
        : base(visible, displayAlerts) { }

    /// <inheritdoc/>
    protected override void EnsureApplicationInitialized()
    {
        if (Application != null) return;
        try
        {
            Application = new Excel.Application { Visible = _visible, DisplayAlerts = _displayAlerts };
            RegisterComObject(Application);
        }
        catch (Exception ex)
        {
            Dispose(true);
            throw new McpException($"Failed to create Excel application: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Open a Excel file.
    /// </summary>
    /// <param name="fullName">The full path of the Excel file to open</param>
    /// <param name="readOnly">ReadOnly mode</param>
    /// <returns></returns>
    public Excel.Workbook OpenWorkbook(string fullName, bool readOnly)
    {
        EnsureApplicationInitialized();
        Excel.Workbook wk = null;
        try
        {
            Excel.Workbooks wks = Application.Workbooks;
            RegisterComObject(wks);
            wk = wks.Open(fullName, Excel.XlUpdateLinks.xlUpdateLinksNever, readOnly, Type.Missing);
        }
        catch (Exception ex)
        {
            throw new McpException($"Failed to open Excel workbook: {ex.Message}", ex);
        }
        RegisterComObject(wk);
        return wk;
    }



    /// <summary>
    /// Get worksheet list.
    /// </summary>
    /// <param name="wk">Workbook</param>
    /// <returns></returns>
    /// <exception cref="McpException"></exception>
    public List<Excel.Worksheet> GetSheets(Excel.Workbook wk)
    {
        Excel.Sheets shs = wk.Sheets;
        RegisterComObject(shs);
        List<Excel.Worksheet> worksheets = new List<Excel.Worksheet>();
        foreach(Excel.Worksheet sh in shs)
        {
            RegisterComObject(sh);
            worksheets.Add(sh);
        }

        return worksheets;
    }


    /// <summary>
    /// Get worksheet by name.
    /// </summary>
    /// <param name="wk">Workbook</param>
    /// <param name="sheetName">Sheet name</param>
    /// <returns></returns>
    /// <exception cref="McpException"></exception>
    public Excel.Worksheet GetSheet(Excel.Workbook wk, string sheetName)
    {
        Excel.Sheets shs = wk.Sheets;
        RegisterComObject(shs);
        Excel.Worksheet sh = null;
        try
        {
            sh = (Excel.Worksheet)shs[sheetName];
        }
        catch (Exception ex)
        {
            throw new McpException($"{sheetName} not exist in {wk.FullName}.", ex);
        }

        RegisterComObject(sh);
        return sh;
    }

    /// <summary>
    /// Get range of worksheet based on the specified start and end columns and rows.
    /// </summary>
    /// <param name="sh">Worksheet</param>
    /// <param name="startColumn">Start column</param>
    /// <param name="startRow">Start row number</param>
    /// <param name="endColumn">End column</param>
    /// <param name="endRow">End row number</param>
    /// <returns></returns>
    public Excel.Range GetRange(Excel.Worksheet sh, string startColumn, int startRow, string endColumn, int? endRow)
    {
        var usedRange = sh.UsedRange;
        RegisterComObject(usedRange);
        var startRange = sh.Range[$"{startColumn}{startRow}"];
        RegisterComObject(startRange);
        var endRange = sh.Range[$"{startColumn}{startRow}"];
        RegisterComObject(endRange);
        if (string.IsNullOrEmpty(endColumn) && !endRow.HasValue)
        {
            // If both endColumn and endRow are not specified, use xlToRight and xlDown
            endRange = endRange.End[Excel.XlDirection.xlToRight];
            RegisterComObject(endRange);
            endRange = endRange.End[Excel.XlDirection.xlDown];
            RegisterComObject(endRange);
        }
        else if (!string.IsNullOrEmpty(endColumn) && !endRow.HasValue)
        {
            // If only endColumn is specified, use xlDown
            endRange = sh.Range[$"{endColumn}{startRow}"];
            RegisterComObject(endRange);
            endRange = endRange.End[Excel.XlDirection.xlDown];
            RegisterComObject(endRange);
        }
        else if (string.IsNullOrEmpty(endColumn) && endRow.HasValue)
        {
            // If only endRow is specified, use xlToRight
            endRange = sh.Range[$"{startColumn}{endRow.Value}"];
            RegisterComObject(endRange);
            endRange = endRange.End[Excel.XlDirection.xlToRight];
            RegisterComObject(endRange);
        }
        else
        {
            // If both are specified, use the specified values
            endRange = sh.Range[$"{endColumn}{endRow.Value}"];
            RegisterComObject(endRange);
        }
        var rows = sh.Rows;
        RegisterComObject(rows);
        if (endRange.Row == rows.Count)
        {
            var cells = sh.Cells;
            RegisterComObject(cells);
            endRange = (Excel.Range)cells[startRange.Row, endRange.Column];
            RegisterComObject(endRange);
        }
        var cols = sh.Columns;
        RegisterComObject(cols);
        if (endRange.Column == cols.Count)
        {
            var cells = sh.Cells;
            RegisterComObject(cells);
            endRange = (Excel.Range)cells[endRange.Row, startRange.Column];
            RegisterComObject(endRange);
        }
        var range = sh.Range[startRange, endRange];
        RegisterComObject(range);
        return range;
    }

    /// <summary>
    /// Reads all values from a range in a single COM call and returns a 1-based 2D array.
    /// Handles both single-cell (scalar) and multi-cell (array) cases.
    /// </summary>
    /// <param name="range">The Excel range to read.</param>
    /// <returns>A 1-based 2D object array containing the range values.</returns>
    public static object[,] GetRangeValues(Excel.Range range)
    {
        var value = range.Value;
        if (value is object[,] array)
        {
            return array;
        }
        // Single cell case: wrap in a 1-based 2D array
        var result = (object[,])Array.CreateInstance(typeof(object), new[] { 1, 1 }, new[] { 1, 1 });
        result[1, 1] = value;
        return result;
    }


    /// <summary>
    /// Converts a 1-based column index to an Excel column letter (e.g., 1 → "A", 27 → "AA").
    /// </summary>
    /// <param name="columnIndex">1-based column index</param>
    /// <returns>Excel column letter</returns>
    public static string ColumnIndexToLetter(int columnIndex)
    {
        var result = new StringBuilder();
        while (columnIndex > 0)
        {
            columnIndex--;
            result.Insert(0, (char)('A' + columnIndex % 26));
            columnIndex /= 26;
        }
        return result.ToString();
    }


    /// <summary>
    /// Converts an Excel column letter to a 1-based column index (e.g., "A" → 1, "AA" → 27).
    /// </summary>
    /// <param name="columnLetter">Excel column letter</param>
    /// <returns>1-based column index</returns>
    public static int ColumnLetterToIndex(string columnLetter)
    {
        int index = 0;
        foreach (char c in columnLetter.ToUpper())
        {
            index = index * 26 + (c - 'A' + 1);
        }
        return index;
    }

}
