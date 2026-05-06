using FileReaderMcpServer.Search;
using System.IO;

namespace TestUnit
{
    [TestClass]
    public sealed class TestBM25Search: TestBase
    {
        [TestMethod]
        public void TestSearchZh()
        {
            var searchDir = Path.Join(TestDataDirectory, "search");
            var docs = new List<Document>();
            foreach (var file in Directory.EnumerateFiles(searchDir, "zh*.txt", SearchOption.TopDirectoryOnly))
            {
               var content =File.ReadAllText(file);
                var doc = new Document
                {
                    FilePath = file,
                    Content = content,
                    Tokens = Tokenizer.Tokenize(content, "zh")
                };
                docs.Add(doc);
            }

            var searcher = new BM25Search(docs);
            var results = searcher.Search(new List<string> { "单元测试", "搜索", "智能体", "编码", "蛋炒饭", "蛋糕", "烘培" });
            foreach (var doc in results)
            {
                TestContext.WriteLine(doc.FilePath);
            }
        }
    }
}
