using FileReaderMcpServer.Search;

namespace TestUnit
{
    [TestClass]
    public sealed class TestTokenizer: TestBase
    {
        [TestMethod]
        public void TestTokenizerZh()
        {
            var content = @"我只是一个过客，我的名字叫Martin";
            var tokens = Tokenizer.Tokenize(content, "zh");
            var expectedTokens = new List<string> { "我", "只是", "一个", "过客", "，", "我", "的", "名字", "叫", "martin" };
            CollectionAssert.AreEqual(expectedTokens, tokens);
        }
        [TestMethod]
        public void TestTokenizerJa()
        {
            var content = @"私はただの通りすがりです。私の名前はMartinです。";
            var tokens = Tokenizer.Tokenize(content, "ja");
            var expectedTokens = new List<string> { "私", "は", "ただ", "の", "通りすがり", "です", "。", "私", "の", "名前", "は", "martin", "です", "。" };
            CollectionAssert.AreEqual(expectedTokens, tokens);
        }
        [TestMethod]
        public void TestTokenizerEn()
        {
            var content = @"I am just a passerby";
            var tokens = Tokenizer.Tokenize(content, "en");
            var expectedTokens = new List<string> { "i", "am", "just", "passerbi" };
            CollectionAssert.AreEqual(expectedTokens, tokens);
        }
    }
}
