using ModelContextProtocol;
using FileReaderMcpServer.Tools.Text;
using J2N.Text;
using JiebaNet.Segmenter.Common;
using Lucene.Net.Util;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Cecil.Cil;
using System;
using System.IO;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.RegularExpressions;
using YamlDotNet.Core;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace FileReaderMcpServer.Tests.Tools.Text
{
    [TestClass]
    public sealed class TextToolsTests : TestBase
    {
        [TestMethod]
        public void Read_LinesRangeFromStart_ReturnsCorrectLines()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "search", "zh1.txt");
            var expected = string.Join(Environment.NewLine, File.ReadAllLines(filePath).Take(5));

            // Act
            var result = TextTools.Read(filePath, 1, 5);
            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            
            // Assert
            Assert.HasCount(5, lines);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Read_LinesRangeFromMiddle_ReturnsCorrectLines()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "search", "zh1.txt");
            var expected = string.Join(Environment.NewLine, File.ReadAllLines(filePath).Skip(8).Take(5));

            // Act
            var result = TextTools.Read(filePath, 9, 5);
            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
           
            // Assert
            Assert.HasCount(5, lines);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetLines_ValidFile_ReturnsLineCountString()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "search", "zh1.txt");
            var expectedLines = File.ReadAllLines(filePath).Length;
            var expected = $"The file '{filePath}' has {expectedLines} lines.";

            // Act
            var result = TextTools.GetLines(filePath);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("MCP", 10)]
        [DataRow("MCP", 16)]
        public void GrepFiles_PatternExists_ReturnsMatchedLines(string pattern,int top)
        {
            // Arrange
            GlobalState.Language = "zh";
            var searchDir = Path.Combine(TestDataDirectory, "search");
            var matchedFilePath = Path.Combine(searchDir, "zh1.txt");
            var matchedLines = File.ReadAllLines(matchedFilePath);
            var files = Directory.GetFiles(searchDir, "zh*.txt");
            var expected = new StringBuilder();
            expected.AppendLine($"- {top} matched lines in {matchedFilePath}");
            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var count = 0;
            for(var i=0; i< matchedLines.Length; i++)
            {
                if(regex.IsMatch(matchedLines[i]))
                {
                    expected.AppendLine($"  - {i + 1} : {matchedLines[i]}");
                    count++;
                    if(count >= top)
                    {
                        break;
                    }
                }
            }

            // Act
            var result = TextTools.GrepFiles(files, pattern, top);

            // Assert
            Assert.AreEqual(expected.ToString().TrimEnd(), result.TrimEnd());
        }

        [TestMethod]
        public void GrepFiles_PatternDoesNotExist_ReturnsNoMatches()
        {
            // Arrange
            var searchDir = Path.Combine(TestDataDirectory, "search");
            var files = Directory.GetFiles(searchDir, "*.txt");

            // Act
            var resultNoMatch = TextTools.GrepFiles(files, "NON_EXISTENT_PATTERN_12345");

            // Assert
            StringAssert.Contains(resultNoMatch, "No matches found.");
        }
        [TestMethod]
        public void GrepFiles_NullFiles_ThrowsException()
        {
            // Arrange
            string[] files = null;
            var expectedMessage = "The full path list of the text file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => TextTools.GrepFiles(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void GrepFiles_EmptyFiles_ThrowsException()
        {
            // Arrange
            var files = new string[0];
            var expectedMessage = "The full path list of the text file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => TextTools.GrepFiles(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void GrepFiles_InvalidPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { Path.Combine(TestDataDirectory, "search", "zh1.txt") };
            var pattern = "[";
            var expectedMessageStart = "Invalid regex pattern: ";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => TextTools.GrepFiles(files, pattern));
            Assert.StartsWith(expectedMessageStart, exception.Message);
        }

        [TestMethod]
        public void GrepFiles_EmptyPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { Path.Combine(TestDataDirectory, "search", "zh1.txt") };
            var pattern = "";
            var expectedMessage = "The search pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => TextTools.GrepFiles(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}
