using FileReaderMcpServer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReaderMcpServer.Tests.Utils
{
    [TestClass]
    public sealed class CsvHelperTests : TestBase
    {
        [TestMethod]
        public void EscapeCsvValue_NullOrEmpty_ReturnsEmptyString()
        {
            Assert.AreEqual("", CsvHelper.EscapeCsvValue(null!));
            Assert.AreEqual("", CsvHelper.EscapeCsvValue(""));
        }

        [TestMethod]
        public void EscapeCsvValue_SimpleValue_ReturnsOriginal()
        {
            string input = "SimpleValue";
            Assert.AreEqual(input, CsvHelper.EscapeCsvValue(input));
        }

        [TestMethod]
        public void EscapeCsvValue_ValueWithComma_Quoted()
        {
            string input = "Value, With Comma";
            string expected = "\"Value, With Comma\"";
            Assert.AreEqual(expected, CsvHelper.EscapeCsvValue(input));
        }

        [TestMethod]
        public void EscapeCsvValue_ValueWithQuote_QuotedAndEscaped()
        {
            string input = "Value \"With\" Quote";
            string expected = "\"Value \"\"With\"\" Quote\"";
            Assert.AreEqual(expected, CsvHelper.EscapeCsvValue(input));
        }

        [TestMethod]
        public void EscapeCsvValue_ValueWithNewLine_Quoted()
        {
            string input = "Line 1\nLine 2";
            string expected = "\"Line 1\nLine 2\"";
            Assert.AreEqual(expected, CsvHelper.EscapeCsvValue(input));
        }

        [TestMethod]
        public void MakeCsv_ValidInput_WithHeader_ReturnsFormattedCsv()
        {
            var header = new List<string> { "Name", "City", "Notes" };
            var body = new List<List<object?>>
            {
                new List<object?> { "Alice", "New York", "She said \"Hello\"" },
                new List<object?> { "Bob", "San, Francisco", "Line 1\nLine 2" }
            };

            string result = CsvHelper.MakeCsv(body, header);

            string expected = "Name,City,Notes\r\nAlice,New York,\"She said \"\"Hello\"\"\"\r\nBob,\"San, Francisco\",\"Line 1\nLine 2\"";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MakeCsv_ValidInput_WithoutHeader_ReturnsFormattedCsv()
        {
            var body = new List<List<object?>>
            {
                new List<object?> { "Alice", "New York" },
                new List<object?> { "Bob", "San Francisco" }
            };

            string result = CsvHelper.MakeCsv(body);

            string expected = "Alice,New York\r\nBob,San Francisco";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MakeCsv_NullHeader_HandlesGracefully()
        {
            var body = new List<List<object?>> { new List<object?> { "V1" } };
            string result = CsvHelper.MakeCsv(body, null);
            Assert.AreEqual("V1", result);
        }

        [TestMethod]
        public void MakeCsv_EmptyHeader_HandlesGracefully()
        {
            var body = new List<List<object?>> { new List<object?> { "V1" } };
            string result = CsvHelper.MakeCsv(body, new List<string>());
            Assert.AreEqual("V1", result);
        }

        [TestMethod]
        public void MakeCsv_NullBody_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => CsvHelper.MakeCsv(null!));
        }

        [TestMethod]
        public void MakeCsv_EmptyBody_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => CsvHelper.MakeCsv(new List<List<object?>>()));
        }

        [TestMethod]
        public void MakeCsv_MismatchedColumnCount_ThrowsArgumentException()
        {
            var header = new List<string> { "H1", "H2" };
            var body = new List<List<object?>>
            {
                new List<object?> { "V1" }
            };
            Assert.Throws<ArgumentException>(() => CsvHelper.MakeCsv(body, header));
        }
    }
}
