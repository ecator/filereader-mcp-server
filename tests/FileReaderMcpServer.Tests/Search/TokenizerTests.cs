using FileReaderMcpServer.Search;

namespace FileReaderMcpServer.Tests.Search
{
    [TestClass]
    public sealed class TokenizerTests: TestBase
    {
        [TestMethod]
        public void Tokenize_ChineseText_ReturnsExpectedTokens()
        {
            var content = @"我只是一个过客，我的名字叫Ｍａｒｔｉｎ，我有２个苹果";
            var tokens = Tokenizer.Tokenize(content, "zh");
            var expectedTokens = new List<string> { "我", "只是", "一个", "过客", "，", "我", "的", "名字", "叫", "martin", "，", "我", "有", "2", "个", "苹果" };
            CollectionAssert.AreEqual(expectedTokens, tokens);
        }
        [TestMethod]
        public void Tokenize_JapaneseText_ReturnsExpectedTokens()
        {
            var content = @"私はただの通りすがりです。私の名前はMartinです。2台のﾊﾟｿｺﾝとｸｰﾗｰを買いました。CATが好きです。";
            var tokens = Tokenizer.Tokenize(content, "ja");
            var expectedTokens = new List<string> { "私", "は", "ただ", "の", "通りすがり", "です", "。", "私", "の", "名前", "は", "martin", "です", "。", "2", "台", "の", "パソコン", "と", "クーラー", "を", "買い", "まし", "た", "。", "cat", "が", "好き", "です", "。" };
            CollectionAssert.AreEqual(expectedTokens, tokens);
        }
        [TestMethod]
        public void Tokenize_EnglishText_ReturnsExpectedTokens()
        {
            var content = @"I am just a passerby called Ｍａｒｔｉｎ, I have ２ apples";
            var tokens = Tokenizer.Tokenize(content, "en");
            var expectedTokens = new List<string> { "i", "am", "just", "passerbi", "call", "martin", "i", "have", "2", "appl" };
            CollectionAssert.AreEqual(expectedTokens, tokens);
        }
    }
}
