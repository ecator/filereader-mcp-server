# FileReader MCP Server

Windows MCP Server for searching and reading Office (Word, Excel, PowerPoint), PDF, Markdown, and Text files using the Model Context Protocol (MCP).

## Language

Please answer in the same language as the user's query, but strictly use English for tool parameters (names, values, and any JSON fields) and code comments.

## Project Overview

- **Technology Stack:** .NET 10.0, [Model Context Protocol CSharp SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- **Key Capabilities:**
  - Content extraction from Word (`.docx`, `.doc`, `.docm`, `.rtf`), Excel (`.xlsx`, `.xls`, `.xlsm`), PowerPoint (`.ppt`, `.pptm`, `.pptx`), PDF, and Text/Markdown files.
  - Full-text search across multiple files using **BM25 ranking**.
  - File system navigation within allowed directories.
  - Multi-language support (English, Chinese, Japanese) for tokenization (using Jieba.NET and MeCab.DotNet).
- **Architecture:** 
  - Standard MCP server using Stdio transport.
  - Tools are automatically discovered from the assembly using the `[McpServerTool]` attribute.
  - **Constraints:** Windows-only due to reliance on Microsoft Office Interop (requires Office 2016+ 64-bit) and avoid MIP(Microsoft Information Protection) prombles.

## Building and Running

### Prerequisites
- .NET 10 SDK
- Microsoft Office 2016 or later (64-bit)

### Build
```powershell
dotnet build
```

### Run
The server requires one or more directory paths as arguments to define the "allowed" scope.
```powershell
dotnet run --project filereader-mcp-server -- "C:\Path\To\MyDocuments" "D:\Work\Projects"
```

### Environment Variables
- `LANGUAGE`: Set to `en`, `zh`, or `ja` to specify the primary language for search tokenization. Defaults to `en`.
- `TIMEOUT`: Set to the timeout in seconds for `search_files` tool. Defaults to `180`.
- `EXCLUDE`: Set to a regular expression pattern to exclude files from search. Defaults to `""`. 
  - Example: `"Tools\.xlsm|SharePoint|OneDrive"`.
    - This will match "Tools.xlsm", "SharePoint", and "OneDrive" in file full path (case-insensitive).

## Testing
The project uses MSTest for unit testing.
```powershell
dotnet test
```
Tests are located in the `test-unit` project and cover search tokenization, BM25 ranking, and tool logic.

## Key Tools

### File System
- `list_allowed_directories`: List directories the server is permitted to read.
- `list_allowed_extensions`: List supported file formats.
- `list_files`: Search and list files in a directory (supports BM25 ranking on file names).
- `list_directory_tree`: View folder structure.
- `search_files`: Full-text search across all supported files in a directory using BM25.

### Content Reading

#### Text / Markdown
- `text_read`: Read content from a text file, optionally from a specific line and for a specific number of lines.
- `text_get_lines`: Get the total number of lines in a text file.
- `text_grep_files`: Search for a regex pattern across multiple text files, returning matched lines with line numbers.

#### Word
- `word_get_page_count`: Get the total number of pages in a Word document.
- `word_read`: Read text content from a Word document, starting from a specific page.
- `word_grep_files`: Search for a regex pattern across multiple Word files, returning matched pages.

#### Excel
- `excel_get_sheets`: Get all sheet names of an Excel file.
- `excel_read`: Read the value of a cell or range of cells from a specified worksheet.
- `excel_read_used_range`: Read all non-empty cells in the used range of a specified worksheet.
- `excel_grep_files`: Search for a regex pattern across cells in multiple Excel files.

#### PowerPoint
- `powerpoint_get_slide_count`: Get the total number of slides in a PowerPoint file.
- `powerpoint_read`: Read text content from a PowerPoint file, starting from a specific slide.
- `powerpoint_grep_files`: Search for a regex pattern across multiple PowerPoint files, returning matched slides.

#### PDF
- `pdf_get_page_count`: Get the total number of pages in a PDF file.
- `pdf_read`: Read text content from a PDF file, starting from a specific page.
- `pdf_grep_files`: Search for a regex pattern across multiple PDF files, returning matched pages.

## Development Conventions

- **Tool Registration:** Use `[McpServerTool(Name = "...", Description = "...")]` and `[Description("...")]` for parameters on public static methods within classes decorated with `[McpServerToolType]`. Note that `Name` and `Description` are strictly in English, even if the user's query is in another language.
- **Validation:** Always use `FileChecker.CheckFile(path)` or `FileChecker.CheckDirectory(path)` before accessing the file system to ensure the path is within `GlobalState.AllowedDirectories`.
- **Error Handling:** Throw `McpException` to return structured errors to the MCP client.
- **Office Interop:** Use `WordSession`, `ExcelSession`, or `PowerPointSession` (IDisposable) to manage Office application instances.
- **Logging:** All application logs must go to `stderr` to avoid interfering with the MCP Stdio protocol.
