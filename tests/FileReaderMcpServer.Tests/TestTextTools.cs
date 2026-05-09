using FileReaderMcpServer.Tools.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestUnit
{
    [TestClass]
    public sealed class TestTextTools : TestBase
    {
        [TestMethod]
        public void TestRead()
        {
            var filePath = Path.Combine(TestDataDirectory, "search", "zh1.txt");
            
            // Test reading the first 5 lines
            var result1 = TextTools.Read(filePath, 1, 5);
            var lines1 = result1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.HasCount(5, lines1);
            StringAssert.Contains(lines1[0], "Model Context Protocol");

            // Test reading starting from line 9
            var result2 = TextTools.Read(filePath, 9, 5);
            var lines2 = result2.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.HasCount(5, lines2);
            StringAssert.Contains(lines2[0], "MCP 的架构基于一种简单的");
        }

        [TestMethod]
        public void TestGetLines()
        {
            var filePath = Path.Combine(TestDataDirectory, "search", "zh1.txt");
            var result = TextTools.GetLines(filePath);
            
            // We need to know the exact number of lines in zh1.txt
            StringAssert.Contains(result, "The file");
            StringAssert.Contains(result, "lines");
            
            // Get actual line count from file system to verify
            var expectedLines = File.ReadAllText(filePath).Replace("\r\n", "\n").Split('\n').Length;
            StringAssert.Contains(result, $"{expectedLines} lines");
        }

        [TestMethod]
        public void TestGrepFiles()
        {
            var searchDir = Path.Combine(TestDataDirectory, "search");
            var files = Directory.GetFiles(searchDir, "*.txt");
            
            // Grep for "MCP"
            var result = TextTools.GrepFiles(files, "MCP", 10);
            
            StringAssert.Contains(result, "matched lines in");
            StringAssert.Contains(result, "zh1.txt");
            
            // Grep for non-existent pattern
            var resultNoMatch = TextTools.GrepFiles(files, "NON_EXISTENT_PATTERN_12345");
            StringAssert.Contains(resultNoMatch, "No matches found.");
        }
    }
}
