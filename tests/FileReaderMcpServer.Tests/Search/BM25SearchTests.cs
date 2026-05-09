using FileReaderMcpServer.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileReaderMcpServer.Tests.Search
{
    [TestClass]
    public sealed class BM25SearchTests : TestBase
    {
        private List<Document> LoadTestDocuments()
        {
            var docs = new List<Document>();
            var searchDir = Path.Combine(TestDataDirectory, "search");
            if (!Directory.Exists(searchDir))
            {
                return docs;
            }

            foreach (var file in Directory.GetFiles(searchDir, "*.txt"))
            {
                var content = File.ReadAllText(file);
                var doc = new Document
                {
                    FilePath = file,
                    Content = content,
                    Tokens = Tokenizer.Tokenize(content, "zh")
                };
                docs.Add(doc);
            }
            return docs;
        }

        [TestMethod]
        public void Search_WithRealData_ReturnsRankedResults()
        {
            var docs = LoadTestDocuments();
            Assert.IsNotEmpty(docs, "No test documents found in test-data/search");

            var searcher = new BM25Search(docs);

            // Searching for "MCP" should bring zh1.txt to the top
            var results = searcher.Search(new List<string> { "mcp" });
            Assert.IsNotEmpty(results);
            Assert.Contains("zh1", Path.GetFileName(results[0].FilePath), "zh1.txt should be the top result for 'MCP'");

            // Searching for "Agent" or "智能体" should bring zh2.txt high
            results = searcher.Search(new List<string> { "智能", "体" });
            Assert.IsNotEmpty(results);
            Assert.IsTrue(results.Any(d => Path.GetFileName(d.FilePath).Contains("zh2")), "zh2.txt should be in results for '智能体'");
        }

        [TestMethod]
        public void Search_WithNonExistentKeyword_ReturnsEmptyList()
        {
            var docs = LoadTestDocuments();
            var searcher = new BM25Search(docs);

            var results = searcher.Search(new List<string> { "nonexistentkeyword12345" });
            Assert.IsEmpty(results, "Should return no results for non-existent keyword");
        }

        [TestMethod]
        public void Search_WithEmptyQuery_ReturnsEmptyList()
        {
            var docs = LoadTestDocuments();
            var searcher = new BM25Search(docs);

            var results = searcher.Search(new List<string>());
            Assert.IsEmpty(results, "Should return no results for empty query");
        }

        [TestMethod]
        public void Search_WithMultiWordQuery_ReturnsRankedResults()
        {
            var docs = LoadTestDocuments();
            var searcher = new BM25Search(docs);

            // Search for something that appears in multiple documents but with different relevance
            var results = searcher.Search(new List<string> { "模型", "协议" });
            Assert.IsNotEmpty(results);
            // Check if the top result is indeed more relevant (likely zh1.txt)
            Assert.Contains("zh1", Path.GetFileName(results[0].FilePath), "zh1.txt should be the top result for '模型 协议'");

        }

        [TestMethod]
        public void Search_WithDifferentTermFrequencies_RanksHigherFrequencyFirst()
        {
            var docs = new List<Document>
            {
                new Document { FilePath = "doc1", Content = "apple apple", Tokens = new List<string> { "apple", "apple" } },
                new Document { FilePath = "doc2", Content = "apple", Tokens = new List<string> { "apple" } },
                new Document { FilePath = "doc3", Content = "banana", Tokens = new List<string> { "banana" } }
            };

            var searcher = new BM25Search(docs);
            var results = searcher.Search(new List<string> { "apple" });

            Assert.HasCount(2, results);
            Assert.AreEqual("doc1", results[0].FilePath, "Doc with more occurrences should rank higher");
            Assert.AreEqual("doc2", results[1].FilePath);
        }

        [TestMethod]
        public void Search_WithMultipleLanguages_ReturnsCorrectMatches()
        {
            var docs = new List<Document>
            {
                new Document { FilePath = "en1", Content = "I am a developer", Tokens = Tokenizer.Tokenize("I am a developer", "en") },
                new Document { FilePath = "ja1", Content = "私は開発者です", Tokens = Tokenizer.Tokenize("私は開発者です", "ja") },
                new Document { FilePath = "zh1", Content = "我是一个开发者", Tokens = Tokenizer.Tokenize("我是一个开发者", "zh") }
            };

            var searcher = new BM25Search(docs);

            // English search: "developer" stems to "develop"
            var results = searcher.Search(Tokenizer.Tokenize("developer", "en"));
            Assert.IsNotEmpty(results, "Should find 'en1' when searching for 'developer'");
            Assert.AreEqual("en1", results[0].FilePath);

            // Japanese search
            results = searcher.Search(Tokenizer.Tokenize("開発者", "ja"));
            Assert.IsNotEmpty(results, "Should find 'ja1' when searching for '開発者'");
            Assert.AreEqual("ja1", results[0].FilePath);

            // Chinese search
            results = searcher.Search(Tokenizer.Tokenize("开发者", "zh"));
            Assert.IsNotEmpty(results, "Should find 'zh1' when searching for '开发者'");
            Assert.AreEqual("zh1", results[0].FilePath);
        }
    }
}
