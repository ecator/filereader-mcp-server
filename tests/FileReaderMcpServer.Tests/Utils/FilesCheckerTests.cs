using System;
using System.IO;
using System.Text.RegularExpressions;
using FileReaderMcpServer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelContextProtocol;

namespace FileReaderMcpServer.Tests.Utils
{
    [TestClass]
    public class FilesCheckerTests : TestBase
    {
        private static readonly object _lock = new object();
        [TestInitialize]
        public void Setup()
        {
            var testFilePath = Path.Combine(TestDataDirectory, "test.md");
            lock (_lock)
            {
                File.WriteAllText(testFilePath, $"This is a test file for FilesCheckerTests. {DateTime.Now.ToString()}");
            }
        }

        [TestMethod]
        public void CheckFileIsAllowed_ValidPathInsideAllowedDirectory_ReturnsTrue()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "test.md");

            // Act
            var result = FileChecker.CheckFileIsAllowed(filePath);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckFileIsAllowed_PathOutsideAllowedDirectory_ThrowsMcpException()
        {
            // Arrange
            var filePath = Path.GetFullPath(@"C:\Windows\System32\drivers\etc\hosts");

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckFileIsAllowed(filePath));
        }

        [TestMethod]
        public void CheckFileIsAllowed_PathOutsideAllowedDirectoryNoThrow_ReturnsFalse()
        {
            // Arrange
            var filePath = Path.GetFullPath(@"C:\Windows\System32\drivers\etc\hosts");

            // Act
            var result = FileChecker.CheckFileIsAllowed(filePath, throwError: false);

            // Assert
            // Note: Since C:\Windows... is unlikely to be in TestDataDirectory, this should be false.
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckFileIsAllowed_ExcludedByPattern_ThrowsMcpException()
        {
            // Arrange
            GlobalState.ExcludePattern = new Regex("test\\.md", RegexOptions.IgnoreCase);
            var filePath = Path.Combine(TestDataDirectory, "test.md");

            try
            {
                // Act & Assert
                Assert.Throws<McpException>(() => FileChecker.CheckFileIsAllowed(filePath));
            }
            finally
            {
                GlobalState.ExcludePattern = null;
            }
        }

        [TestMethod]
        public void CheckFileIsAllowed_RelativePath_ThrowsMcpException()
        {
            // Arrange
            var filePath = "test.md";

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckFileIsAllowed(filePath));
        }

        [TestMethod]
        public void CheckFileIsAllowed_DirectoryPathEqualsAllowed_ReturnsTrue()
        {
            // Arrange
            var dirPath = TestDataDirectory.TrimEnd(Path.DirectorySeparatorChar);

            // Act
            var result = FileChecker.CheckFileIsAllowed(dirPath);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDirectory_ExistingDirectoryInsideAllowed_ReturnsTrue()
        {
            // Arrange
            var dirPath = Path.Combine(TestDataDirectory, "search");
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

            // Act
            var result = FileChecker.CheckDirectory(dirPath);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDirectory_NonExistingDirectory_ThrowsMcpException()
        {
            // Arrange
            var dirPath = Path.Combine(TestDataDirectory, "non_existing_dir_xyz");

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckDirectory(dirPath));
        }

        [TestMethod]
        public void CheckFile_ExistingFileInsideAllowed_ReturnsTrue()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "test.md");
            if (!File.Exists(filePath)) File.WriteAllText(filePath, "test content");

            // Act
            var result = FileChecker.CheckFile(filePath);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckFile_NonExistingFile_ThrowsMcpException()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "non_existing_file_xyz.txt");

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckFile(filePath));
        }

        [TestMethod]
        public void CheckTextFile_ValidExtension_ReturnsTrue()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "test.md");
            if (!File.Exists(filePath)) File.WriteAllText(filePath, "test content");

            // Act
            var result = FileChecker.CheckTextFile(filePath);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckTextFile_InvalidExtension_ThrowsMcpException()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "test.docx");

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckTextFile(filePath));
        }

        [TestMethod]
        public void CheckExcelFile_InvalidExtension_ThrowsMcpException()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "test.md");

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckExcelFile(filePath));
        }

        [TestMethod]
        public void CheckWordFile_InvalidExtension_ThrowsMcpException()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "test.md");

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckWordFile(filePath));
        }

        [TestMethod]
        public void CheckPowerPointFile_InvalidExtension_ThrowsMcpException()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "test.md");

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckPowerPointFile(filePath));
        }

        [TestMethod]
        public void CheckPdfFile_InvalidExtension_ThrowsMcpException()
        {
            // Arrange
            var filePath = Path.Combine(TestDataDirectory, "test.md");

            // Act & Assert
            Assert.Throws<McpException>(() => FileChecker.CheckPdfFile(filePath));
        }
    }
}
