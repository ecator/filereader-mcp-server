using System;
using System.IO;
using ModelContextProtocol;
using ModelContextProtocol.Server;

namespace FileReaderMcpServer.Validation;

public static class FileChecker
{
    public static bool CheckFileIsAllowed(string filePath)
    {
        if (!Path.IsPathFullyQualified(filePath))
        {
            filePath = Path.GetFullPath(filePath);
        }
        foreach (var allowedDir in GlobalState.AllowedDirectories)
        {
            if (filePath.StartsWith(allowedDir, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
    
    public static string CheckDirectory(string directory)
    {
        if (string.IsNullOrWhiteSpace(directory))
        {
            throw new McpException("Directory is required.");
        }

        if (!CheckFileIsAllowed(directory))
        {
            throw new McpException("The provided directory is not in the allowed directories.");
        }

        if (!Path.IsPathFullyQualified(directory))
        {
            directory = Path.GetFullPath(directory);
        }
        
        if (!Directory.Exists(directory))
        {
            throw new McpException($"Directory '{directory}' does not exist.");
        }

        return directory;
    }

    public static string CheckFile(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            throw new McpException("File path is required.");
        }

        if (!CheckFileIsAllowed(file))
        {
            throw new McpException("The provided file is not in the allowed directories.");
        }

        if (!Path.IsPathFullyQualified(file))
        {
            file = Path.GetFullPath(file);
        }

        if (!File.Exists(file))
        {
            throw new McpException($"File '{file}' does not exist.");
        }

        return file;
    }
}
