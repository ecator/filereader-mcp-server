using FileReaderMcpServer.Tools.Office;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ModelContextProtocol;

namespace FileReaderMcpServer.Tests.Tools.Office
{
    [TestClass]
    public sealed class WordToolsTests : TestBase
    {
        private string _wordFilePath = string.Empty;

        [TestInitialize]
        public void Setup()
        {
            _wordFilePath = Path.Combine(TestDataDirectory, "office", "doc1.docx");
        }

        [TestMethod]
        public void GetPageCount_ValidFile_ReturnsCorrectFormat()
        {
            // Act
            var result = WordTools.GetPageCount(_wordFilePath);

            var expected = $"Total `3` pages in the Word file `{_wordFilePath}`.\r\n";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPageCount_FileDoesNotExist_ThrowsException()
        {
            // Arrange
            var nonExistentFile = Path.Combine(TestDataDirectory, "non_existent.docx");
            var expectedMessage = $"File '{nonExistentFile}' does not exist.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => WordTools.GetPageCount(nonExistentFile));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Read_ValidPageRange_ReturnsContent()
        {
            // Act
            var result = WordTools.Read(_wordFilePath, 1, 1);

            var expectedStart = "这是一只猫";
            var expectedEnd = "阿邦。\r";
            // Assert
            Assert.IsTrue(result.StartsWith(expectedStart));
            Assert.IsTrue(result.EndsWith(expectedEnd));
        }

        [TestMethod]
        public void Read_InvalidPageRange_ReturnsEmpty()
        {
            // Act
            var result = WordTools.Read(_wordFilePath, 9999, 1);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Find_PatternExists_ReturnsMatchedPages()
        {
            // Arrange
            var files = new[] { _wordFilePath };
            // Using a very common vowel or letter to ensure it exists in the test document
            var pattern = "阿邦";

            // Act
            var result = WordTools.Find(files, pattern);
            var expectedStart = $"Found a total of `2` results for `阿邦` in all files.";

            // Assert
            Assert.IsTrue(result.StartsWith(expectedStart));
        }

        [TestMethod]
        public void Find_PatternDoesNotExist_ReturnsZeroResults()
        {
            // Arrange
            var files = new[] { _wordFilePath };
            var pattern = "NON_EXISTENT_PATTERN_" + Guid.NewGuid().ToString();
            var expectedStart = $"Found a total of `0` results for `{pattern}` in all files.";

            // Act
            var result = WordTools.Find(files, pattern);

            // Assert
            Assert.StartsWith(expectedStart, result);
        }

        [TestMethod]
        public void Find_FileDoesNotExist_ReturnsErrorMessageInResult()
        {
            // Arrange
            var nonExistentFile = Path.Combine(TestDataDirectory, "non_existent.docx");
            var files = new[] { _wordFilePath, nonExistentFile };
            var expectedError = $"Error checking file `{nonExistentFile}`: File '{nonExistentFile}' does not exist.";

            // Act
            var result = WordTools.Find(files, "a");

            // Assert
            Assert.Contains(expectedError, result);
        }

        [TestMethod]
        public void Find_NullFiles_ThrowsException()
        {
            // Arrange
            string[] files = null!;
            var expectedMessage = "The full path list of the Word file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => WordTools.Find(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_EmptyFiles_ThrowsException()
        {
            // Arrange
            var files = new string[0];
            var expectedMessage = "The full path list of the Word file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => WordTools.Find(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_InvalidPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _wordFilePath };
            var pattern = "[";
            var expectedMessageStart = "Invalid regex pattern: ";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => WordTools.Find(files, pattern));
            Assert.StartsWith(expectedMessageStart, exception.Message);
        }

        [TestMethod]
        public void Find_NullPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _wordFilePath };
            string pattern = null!;
            var expectedMessage = "The regex pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => WordTools.Find(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_EmptyPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _wordFilePath };
            var pattern = "";
            var expectedMessage = "The regex pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => WordTools.Find(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}
