using System;
using System.IO;
using System.Linq;
using ModelContextProtocol;
using ModelContextProtocol.Server;

namespace FileReaderMcpServer.Utils;

public static class FileChecker
{
    public static bool CheckFileIsAllowed(string filePath, bool throwError = true)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            if (throwError) throw new McpException("Path is required.");
            return false;
        }

        if (!Path.IsPathFullyQualified(filePath))
        {
            if (throwError) throw new McpException($"Path '{filePath}' must be a fully qualified absolute path.");
            return false;
        }

        if (GlobalState.ExcludePattern != null && GlobalState.ExcludePattern.IsMatch(filePath))
        {
            if (throwError) throw new McpException($"The provided path '{filePath}' is excluded by the exclude pattern.");
            return false;
        }

        var normalizedPath = filePath.Replace("\\", "/");
        foreach (var allowedDir in GlobalState.AllowedDirectories)
        {
            var normalizedAllowedDir = allowedDir.Replace("\\", "/").TrimEnd('/');
            if (normalizedPath.StartsWith(normalizedAllowedDir + "/", StringComparison.OrdinalIgnoreCase) || 
                normalizedPath.Equals(normalizedAllowedDir, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        if (throwError) throw new McpException($"The provided path '{filePath}' is not in the allowed directories.");
        return false;
    }
    
    public static bool CheckDirectory(string directory, bool throwError = true)
    {
        if (string.IsNullOrWhiteSpace(directory))
        {
            if (throwError) throw new McpException("Directory is required.");
            return false;
        }

        if (!Path.IsPathFullyQualified(directory))
        {
            if (throwError) throw new McpException($"Directory path '{directory}' must be a fully qualified absolute path.");
            return false;
        }

        if (!CheckFileIsAllowed(directory, throwError))
        {
            return false;
        }

        if (!Directory.Exists(directory))
        {
            if (throwError) throw new McpException($"Directory '{directory}' does not exist.");
            return false;
        }

        return true;
    }

    public static bool CheckFile(string file, bool throwError = true)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            if (throwError) throw new McpException("File path is required.");
            return false;
        }

        if (!Path.IsPathFullyQualified(file))
        {
            if (throwError) throw new McpException($"File path '{file}' must be a fully qualified absolute path.");
            return false;
        }

        if (!CheckFileIsAllowed(file, throwError))
        {
            return false;
        }

        if (!File.Exists(file))
        {
            if (throwError) throw new McpException($"File '{file}' does not exist.");
            return false;
        }

        return true;
    }

    public static bool CheckTextFile(string file, bool throwError = true) => CheckFileExtension(file, GlobalState.ALLOWED_EXTENSIONS_TEXT, "Text", throwError);

    public static bool CheckExcelFile(string file, bool throwError = true) => CheckFileExtension(file, GlobalState.ALLOWED_EXTENSIONS_EXCEL, "Excel", throwError);

    public static bool CheckWordFile(string file, bool throwError = true) => CheckFileExtension(file, GlobalState.ALLOWED_EXTENSIONS_WORD, "Word", throwError);

    public static bool CheckPowerPointFile(string file, bool throwError = true) => CheckFileExtension(file, GlobalState.ALLOWED_EXTENSIONS_PPT, "PowerPoint", throwError);

    public static bool CheckPdfFile(string file, bool throwError = true) => CheckFileExtension(file, GlobalState.ALLOWED_EXTENSIONS_PDF, "PDF", throwError);

    private static bool CheckFileExtension(string file, string[] allowedExtensions, string typeName, bool throwError)
    {
        var extension = Path.GetExtension(file).TrimStart('.').ToLowerInvariant();
        if (!allowedExtensions.Contains(extension))
        {
            if (throwError) throw new McpException($"File '{file}' is not a valid {typeName} file. Supported extensions: {string.Join(", ", allowedExtensions)}");
            return false;
        }
        return CheckFile(file, throwError);
    }
}
