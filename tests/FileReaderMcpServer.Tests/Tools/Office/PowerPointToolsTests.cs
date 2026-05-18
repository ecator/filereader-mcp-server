using FileReaderMcpServer.Tools.Office;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ModelContextProtocol;

namespace FileReaderMcpServer.Tests.Tools.Office
{
    [TestClass]
    public sealed class PowerPointToolsTests : TestBase
    {
        private string _pptFilePath = string.Empty;

        [TestInitialize]
        public void Setup()
        {
            _pptFilePath = Path.Combine(TestDataDirectory, "office", "pr1.pptx");
        }

        [TestMethod]
        public void GetSlideCount_ValidFile_ReturnsCorrectFormat()
        {
            // Act
            var result = PowerPointTools.GetSlideCount(_pptFilePath);

            // Assert
            // We'll just assert it starts with the expected format, we might need to adjust the exact slide count later.
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex($@"Total `\d+` slides in the PowerPoint file `{System.Text.RegularExpressions.Regex.Escape(_pptFilePath)}`\."));
        }

        [TestMethod]
        public void GetSlideCount_FileDoesNotExist_ThrowsException()
        {
            // Arrange
            var nonExistentFile = Path.Combine(TestDataDirectory, "non_existent.pptx");
            var expectedMessage = $"File '{nonExistentFile}' does not exist.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PowerPointTools.GetSlideCount(nonExistentFile));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Read_ValidSlideRange_ReturnsContent()
        {
            // Act
            var result = PowerPointTools.Read(_pptFilePath, 1, 1);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public void Read_InvalidSlideRange_ReturnsEmpty()
        {
            // Act
            var result = PowerPointTools.Read(_pptFilePath, 9999, 1);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Find_PatternExists_ReturnsMatchedSlides()
        {
            // Arrange
            var files = new[] { _pptFilePath };
            // Using a very common vowel or character to ensure it exists in the test document
            var pattern = "e";

            // Act
            var result = PowerPointTools.Find(files, pattern);

            // Assert
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex(@"Found a total of `\d+` results for `e` in all files\."));
        }

        [TestMethod]
        public void Find_PatternDoesNotExist_ReturnsZeroResults()
        {
            // Arrange
            var files = new[] { _pptFilePath };
            var pattern = "NON_EXISTENT_PATTERN_" + Guid.NewGuid().ToString();
            var expectedStart = $"Found a total of `0` results for `{pattern}` in all files.";

            // Act
            var result = PowerPointTools.Find(files, pattern);

            // Assert
            Assert.StartsWith(expectedStart, result);
        }

        [TestMethod]
        public void Find_FileDoesNotExist_ReturnsErrorMessageInResult()
        {
            // Arrange
            var nonExistentFile = Path.Combine(TestDataDirectory, "non_existent.pptx");
            var files = new[] { _pptFilePath, nonExistentFile };
            var expectedError = $"Error checking file `{nonExistentFile}`: File '{nonExistentFile}' does not exist.";

            // Act
            var result = PowerPointTools.Find(files, "a");

            // Assert
            StringAssert.Contains(result, expectedError);
        }

        [TestMethod]
        public void Find_NullFiles_ThrowsException()
        {
            // Arrange
            string[] files = null!;
            var expectedMessage = "The full path list of the PowerPoint file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PowerPointTools.Find(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_EmptyFiles_ThrowsException()
        {
            // Arrange
            var files = new string[0];
            var expectedMessage = "The full path list of the PowerPoint file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PowerPointTools.Find(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_InvalidPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _pptFilePath };
            var pattern = "[";
            var expectedMessageStart = "Invalid regex pattern: ";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PowerPointTools.Find(files, pattern));
            Assert.StartsWith(expectedMessageStart, exception.Message);
        }

        [TestMethod]
        public void Find_NullPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _pptFilePath };
            string pattern = null!;
            var expectedMessage = "The regex pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PowerPointTools.Find(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_EmptyPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _pptFilePath };
            var pattern = "";
            var expectedMessage = "The regex pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PowerPointTools.Find(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}
