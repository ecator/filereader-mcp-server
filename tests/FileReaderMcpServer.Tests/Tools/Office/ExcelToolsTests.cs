using FileReaderMcpServer.Tools.Office;
using FileReaderMcpServer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelContextProtocol;
using System.Text;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace FileReaderMcpServer.Tests.Tools.Office
{
    [TestClass]
    public sealed class ExcelToolsTests : TestBase
    {
        private string _xlsFilePath = string.Empty;
        private string _xlsxFilePath = string.Empty;
        private string _xlsmFilePath = string.Empty;
        private static readonly ISerializer _yamlSerializer = new SerializerBuilder().Build();

        [TestInitialize]
        public void Setup()
        {
            _xlsFilePath = Path.Combine(TestDataDirectory, "office", "wk0.xls");
            _xlsxFilePath = Path.Combine(TestDataDirectory, "office", "customers-10000.xlsx");
            _xlsmFilePath = Path.Combine(TestDataDirectory, "office", "wk1.xlsm");
        }

        [TestMethod]
        public void GetSheets_ValidFile_ReturnsSheetList()
        {
            // Arrange
            var expected = new StringBuilder();
            expected.AppendLine($"Total `1` sheets in the Excel file `{_xlsxFilePath}`:");
            expected.AppendLine("1. customers-10000");


            // Act
            var result = ExcelTools.GetSheets(_xlsxFilePath);

            // Assert
            Assert.AreEqual(expected.ToString(), result);
        }

        [TestMethod]
        public void GetSheets_XlsxFile_ReturnsSheetList()
        {
            // Arrange
            var expected = new StringBuilder();
            expected.AppendLine($"Total `3` sheets in the Excel file `{_xlsFilePath}`:");
            expected.AppendLine("1. Sheet1");
            expected.AppendLine("2. Sheet2");
            expected.AppendLine("3. こんにちは");


            // Act
            var result = ExcelTools.GetSheets(_xlsFilePath);

            // Assert
            Assert.AreEqual(expected.ToString(), result);
        }

        [TestMethod]
        public void GetSheets_FileDoesNotExist_ThrowsException()
        {
            // Arrange
            var nonExistentFile = Path.Combine(TestDataDirectory, "non_existent.xls");
            var expectedMessage = $"File '{nonExistentFile}' does not exist.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => ExcelTools.GetSheets(nonExistentFile));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Read_ValidSheetAllCells_ReturnsYamlContent()
        {
            // Arrange
            var sheetName = "Sheet1";
            var startColumn = "A";
            var startRow = 1;
            var endColumn = "B";
            var endRow = 1;
            var expected = new Dictionary<string, object>
            {
                { "A1", "你好" },
                { "B1", "大家好" }
            };

            // Act
            var result = ExcelTools.Read(_xlsFilePath, sheetName, startColumn, startRow, endColumn, endRow);

            // Assert
            Assert.AreEqual(_yamlSerializer.Serialize(expected), result);
        }

        [TestMethod]
        public void Read_ValidSheetEmptyCells_ReturnsYamlContent()
        {
            // Arrange
            var sheetName = "Sheet2";
            var startColumn = "C";
            var expected = new Dictionary<string, object>
            {
                { "C2", "哈哈哈" },
                { "C3", "大家好吗?" },
                { "D3", "哈哈" }
            };

            // Act
            var result = ExcelTools.Read(_xlsFilePath, sheetName, startColumn);

            // Assert
            Assert.AreEqual(_yamlSerializer.Serialize(expected), result);
        }

        [TestMethod]
        public void Read_InvalidSheet_ThrowsException()
        {
            // Arrange
            var sheetName = "NonExistentSheet";
            var expectedMessage = $"The specified sheet '{sheetName}' does not exist in the Excel file.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => ExcelTools.Read(_xlsFilePath, sheetName));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void ReadUsedRange_ValidSheet_ReturnsYamlContent()
        {
            // Arrange
            var sheetName = "Sheet1";
            var expected = new Dictionary<string, object>
            {
                { "A1", "你好" },
                { "B1", "大家好" },
                { "C1", "哈哈" },
                { "B2", "吃了吗" }
            };

            // Act
            var result = ExcelTools.ReadUsedRange(_xlsmFilePath, sheetName);

            // Assert
            Assert.AreEqual(_yamlSerializer.Serialize(expected), result);
        }

        [TestMethod]
        public void Find_PatternExists_ReturnsMatchedCells()
        {
            // Arrange
            var files = new[] { _xlsFilePath,_xlsmFilePath };
            var pattern = "^１$";
            var header = new List<string>{ "Sheet", "Address", "Value" };
            var expected = new StringBuilder();
            expected.AppendLine($"Found a total of `4` results for `{pattern}` in all files.");
            expected.AppendLine();
            expected.AppendLine($"`1` results in `{_xlsFilePath}`:");
            expected.AppendLine(MarkdownHelper.MakeMarkdownTable(header,new List<List<object?>> { new List<object?> { "Sheet2","A1","1" } }));
            expected.AppendLine($"`3` results in `{_xlsmFilePath}`:");
            expected.AppendLine(MarkdownHelper.MakeMarkdownTable(header, new List<List<object?>> { new List<object?> { "Sheet2", "B3", "1" }, 
                                                                                                   new List<object?> { "こんにちは", "L13", "1" }, 
                                                                                                   new List<object?> { "Sheet3", "L20", "1" } 
                                                                                                  }));

            // Act
            var result = ExcelTools.Find(files, pattern);

            // Assert
            Assert.AreEqual(expected.ToString(), result);
        }

        [TestMethod]
        public void Find_PatternDoesNotExist_ReturnsZeroResults()
        {
            // Arrange
            var files = new[] { _xlsFilePath };
            var pattern = "NON_EXISTENT_PATTERN_" + Guid.NewGuid().ToString();
            var expectedStart = $"Found a total of `0` results for `{pattern}` in all files.";

            // Act
            var result = ExcelTools.Find(files, pattern);

            // Assert
            Assert.StartsWith(expectedStart, result);
        }

        [TestMethod]
        public void Find_NullFiles_ThrowsException()
        {
            // Arrange
            string[] files = null;
            var expectedMessage = "The full path list of the Excel file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => ExcelTools.Find(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_EmptyFiles_ThrowsException()
        {
            // Arrange
            var files = new string[0];
            var expectedMessage = "The full path list of the Excel file cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => ExcelTools.Find(files, "test"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_InvalidPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _xlsFilePath };
            var pattern = "[";
            var expectedMessageStart = "Invalid regex pattern: ";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => ExcelTools.Find(files, pattern));
            Assert.StartsWith(expectedMessageStart, exception.Message);
        }

        [TestMethod]
        public void Find_NullPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _xlsFilePath };
            string pattern = null;
            var expectedMessage = "The regex pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => ExcelTools.Find(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Find_EmptyPattern_ThrowsException()
        {
            // Arrange
            var files = new[] { _xlsFilePath };
            var pattern = "";
            var expectedMessage = "The regex pattern cannot be empty or null.";

            // Act & Assert
            var exception = Assert.Throws<McpException>(() => ExcelTools.Find(files, pattern));
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}
