using System.Collections.Generic;
using System.Linq;
using JiebaNet.Segmenter;
using MeCab;

namespace FileReaderMcpServer.Search;

public static class Tokenizer
{
    // We instantiate the segmenters once as they load dictionaries.
    private static readonly JiebaSegmenter jiebaSegmenter = new JiebaSegmenter();
    private static readonly MeCabTagger mecabTagger = MeCabTagger.Create(new MeCabParam());

    /// <summary>
    /// Tokenizes the given text. Uses MeCab for Japanese, and Jieba for Chinese and English.
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
        else
        {
            var tokens = jiebaSegmenter.Cut(text).Select(x => x.ToLowerInvariant()).ToList();
            return tokens;
        }
    }
}
