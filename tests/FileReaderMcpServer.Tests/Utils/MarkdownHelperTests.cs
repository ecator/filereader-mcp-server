using FileReaderMcpServer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReaderMcpServer.Tests.Utils
{
    [TestClass]
    public sealed class MarkdownHelperTests : TestBase
    {
        [TestMethod]
        public void EscapeMarkdownTableValue_NullOrEmpty_ReturnsOriginal()
        {
            Assert.IsNull(MarkdownHelper.EscapeMarkdownTableValue(null));
            Assert.AreEqual("", MarkdownHelper.EscapeMarkdownTableValue(""));
        }

        [TestMethod]
        public void EscapeMarkdownTableValue_NewLine_ReplacedWithBr()
        {
            string input = "Line 1\nLine 2";
            string expected = "Line 1<br>Line 2";
            Assert.AreEqual(expected, MarkdownHelper.EscapeMarkdownTableValue(input));
        }

        [TestMethod]
        public void EscapeMarkdownTableValue_CarriageReturn_Removed()
        {
            string input = "Line 1\r\nLine 2";
            string expected = "Line 1<br>Line 2";
            Assert.AreEqual(expected, MarkdownHelper.EscapeMarkdownTableValue(input));
        }

        [TestMethod]
        public void EscapeMarkdownTableValue_Backslash_Escaped()
        {
            string input = @"C:\Path\To\File";
            string expected = @"C:\\Path\\To\\File";
            Assert.AreEqual(expected, MarkdownHelper.EscapeMarkdownTableValue(input));
        }

        [TestMethod]
        public void EscapeMarkdownTableValue_Pipe_Escaped()
        {
            string input = "Column 1 | Column 2";
            string expected = @"Column 1 \| Column 2";
            Assert.AreEqual(expected, MarkdownHelper.EscapeMarkdownTableValue(input));
        }

        [TestMethod]
        public void EscapeMarkdownTableValue_ComplexString_FormattedCorrectly()
        {
            string input = "Backslash: \\, Pipe: |, NewLine: \r\nEnd";
            string expected = @"Backslash: \\, Pipe: \|, NewLine: <br>End";
            Assert.AreEqual(expected, MarkdownHelper.EscapeMarkdownTableValue(input));
        }

        [TestMethod]
        public void MakeMarkdownTable_ValidInput_ReturnsFormattedTable()
        {
            var header = new List<string> { "Name\n", "Age" };
            var body = new List<List<object?>>
            {
                new List<object?> { "Alice", 30 },
                new List<object?> { "Bob|\\", 25 }
            };

            string result = MarkdownHelper.MakeMarkdownTable(header, body);

            string expected = "Name<br>|Age\r\n---|---\r\nAlice|30\r\nBob\\|\\\\|25";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MakeMarkdownTable_NullHeader_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => MarkdownHelper.MakeMarkdownTable(null!, new List<List<object?>>()));
        }

        [TestMethod]
        public void MakeMarkdownTable_EmptyHeader_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => MarkdownHelper.MakeMarkdownTable(new List<string>(), new List<List<object?>>()));
        }

        [TestMethod]
        public void MakeMarkdownTable_NullBody_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => MarkdownHelper.MakeMarkdownTable(new List<string> { "H1" }, null!));
        }

        [TestMethod]
        public void MakeMarkdownTable_EmptyBody_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => MarkdownHelper.MakeMarkdownTable(new List<string> { "H1" }, new List<List<object?>>()));
        }

        [TestMethod]
        public void MakeMarkdownTable_MismatchedColumnCount_ThrowsArgumentException()
        {
            var header = new List<string> { "H1", "H2" };
            var body = new List<List<object?>>
            {
                new List<object?> { "V1" } // Only one column
            };
            Assert.Throws<ArgumentException>(() => MarkdownHelper.MakeMarkdownTable(header, body));
        }
    }
}
