using FileReaderMcpServer.Tools.Pdf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ModelContextProtocol;

namespace FileReaderMcpServer.Tests.Tools.Pdf
{
    [TestClass]
    public sealed class PdfToolsTests : TestBase
    {
        private string _pdfFilePath = string.Empty;

        [TestInitialize]
        public void Setup()
        {
            _pdfFilePath = Path.Combine(TestDataDirectory, "pdf", "pdf1.pdf");
        }

        [TestMethod]
        public void GetPageCount_ValidFile_ReturnsCorrectPageCount()
        {
            // Arrange
            var expected = $"Total `56` pages in the PDF file `{_pdfFilePath}`.";


            // Act
            var result = PdfTools.GetPageCount(_pdfFilePath);

            // Assert
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void GetPageCount_FileDoesNotExist_ThrowsException()
        {
            // Arrange
            var nonExistentFile = Path.Combine(TestDataDirectory, "non_existent.pdf");
            var expectedMessage = $"File '{nonExistentFile}' does not exist.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PdfTools.GetPageCount(nonExistentFile));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Read_ValidPageRange_ReturnsContent()
        {
            // Act
            var result = PdfTools.Read(_pdfFilePath, 1, 1);
            var expectedStart = "1中国共享经济发展报告";
            var expectedEnd = "35";

            // Assert
            Assert.StartsWith(expectedStart, result);
            Assert.EndsWith(expectedEnd, result);
        }

        [TestMethod]
        public void Read_InvalidPageRange_ReturnsEmpty()
        {
            // Act
            var result = PdfTools.Read(_pdfFilePath, 9999, 1);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Find_PatternExists_ReturnsMatchedPages()
        {
            // Arrange
            var files = new[] { _pdfFilePath };
            var pattern = "中国.*?２０２１";
            var expectedStart = $"Found a total of `4` results for `{pattern}` in all files.";

            // Act
            var result = PdfTools.Find(files, pattern);

            // Assert
            Assert.StartsWith(expectedStart, result);
        }

        [TestMethod]
        public void Find_PatternDoesNotExist_ReturnsZeroResults()
        {
            // Arrange
            var files = new[] { _pdfFilePath };
            var pattern = "NON_EXISTENT_PATTERN_" + Guid.NewGuid().ToString();
            var expectedStart = $"Found a total of `0` results for `{pattern}` in all files.";

            // Act
            var result = PdfTools.Find(files, pattern);

            // Assert
            Assert.StartsWith(expectedStart, result);
        }

        [TestMethod]
        public void Find_FileDoesNotExist_ReturnsErrorMessageInResult()
        {
            // Arrange
            var nonExistentFile = Path.Combine(TestDataDirectory, "non_existent.pdf");
            var files = new[] { _pdfFilePath, nonExistentFile };
            var expectedError = $"Error checking file `{nonExistentFile}`: File '{nonExistentFile}' does not exist.";

            // Act
            var result = PdfTools.Find(files, "test");

            // Assert
            Assert.Contains(expectedError, result);
        }

        [TestMethod]
        public void Find_NullFiles_ThrowsException()
        {
            // Arrange
            string[] files = null;
            var expectedMessage = "The full path list of the PDF file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PdfTools.Find(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_EmptyFiles_ThrowsException()
        {
            // Arrange
            var files = new string[0];
            var expectedMessage = "The full path list of the PDF file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PdfTools.Find(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_InvalidPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _pdfFilePath };
            var pattern = "[";
            var expectedMessageStart = "Invalid regex pattern: ";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PdfTools.Find(files, pattern));
            Assert.StartsWith(expectedMessageStart, exception.Message);
        }

        [TestMethod]
        public void Find_NullPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _pdfFilePath };
            string pattern = null;
            var expectedMessage = "The search pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PdfTools.Find(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_EmptyPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _pdfFilePath };
            var pattern = "";
            var expectedMessage = "The search pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => PdfTools.Find(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}
