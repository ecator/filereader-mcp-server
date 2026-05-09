using System.Collections.Generic;
using System.IO;
using System.Linq;
using JiebaNet.Segmenter;
using Lucene.Net.Analysis.En;
using Lucene.Net.Analysis.TokenAttributes;
using Lucene.Net.Util;
using MeCab;

namespace FileReaderMcpServer.Search;

public static class Tokenizer
{
    private const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;

    // We instantiate the segmenters once as they load dictionaries.
    private static readonly JiebaSegmenter jiebaSegmenter = new JiebaSegmenter();
    private static readonly MeCabTagger mecabTagger = MeCabTagger.Create(new MeCabParam());
    private static readonly EnglishAnalyzer englishAnalyzer = new EnglishAnalyzer(AppLuceneVersion);

    /// <summary>
    /// Tokenizes the given text. Uses MeCab for Japanese, Lucene for English, and Jieba for Chinese and others.
    /// </summary>
    public static List<string> Tokenize(string text, string? language = null)
    {
        if (string.IsNullOrWhiteSpace(text)) return new List<string>();
        language ??= GlobalState.Language;
        
        if (language == "ja")
        {
            var tokens = new List<string>();
            var nodes = mecabTagger.ParseToNodes(text);
            foreach (var node in nodes)
            {
                // CharType > 0 usually skips BOS/EOS (Begin/End of Sentence) nodes
                if (node.CharType > 0 && !string.IsNullOrWhiteSpace(node.Surface))
                {
                    tokens.Add(node.Surface.ToLowerInvariant());
                }
            }
            return tokens;
        }
        else if (language == "en")
        {
            var tokens = new List<string>();
            using (var reader = new StringReader(text))
            {
                using var tokenStream = englishAnalyzer.GetTokenStream(string.Empty, reader);
                var termAttr = tokenStream.AddAttribute<ICharTermAttribute>();
                tokenStream.Reset();
                while (tokenStream.IncrementToken())
                {
                    tokens.Add(termAttr.ToString());
                }
                tokenStream.End();
            }
            return tokens;
        }
        else
        {
            var tokens = jiebaSegmenter.Cut(text).Select(x => x.ToLowerInvariant()).ToList();
            return tokens;
        }
    }
}
