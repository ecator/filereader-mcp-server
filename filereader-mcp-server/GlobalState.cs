using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FileReaderMcpServer
{
    public static class GlobalState
    {
        public static List<string> AllowedDirectories { get; } = new List<string>();
        public static string Language { get; set; } = "en";
        public static int Timeout { get; set; } = 180;
        public static Regex? ExcludePattern { get; set; } = null;

        public static string[] ALLOWED_LANGUAGE { get; } = new string[] { "zh", "ja", "en" };
        public static string[] ALLOWED_EXTENSIONS { get => new List<string>().Concat(ALLOWED_EXTENSIONS_TEXT).Concat(ALLOWED_EXTENSIONS_WORD).Concat(ALLOWED_EXTENSIONS_EXCEL).Concat(ALLOWED_EXTENSIONS_PPT).Concat(ALLOWED_EXTENSIONS_PDF).ToArray(); }
        public static string[] ALLOWED_EXTENSIONS_TEXT { get; } = new string[] { "txt", "md" };
        public static string[] ALLOWED_EXTENSIONS_WORD { get; } = new string[] { "docx", "doc", "docm", "rtf" };
        public static string[] ALLOWED_EXTENSIONS_EXCEL { get; } = new string[] { "xlsx", "xls", "xlsm" };
        public static string[] ALLOWED_EXTENSIONS_PPT { get; } = new string[] { "ppt", "pptm", "pptx" };
        public static string[] ALLOWED_EXTENSIONS_PDF { get; } = new string[] { "pdf" };

    }
}
