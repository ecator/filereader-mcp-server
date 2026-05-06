using System;
using System.Collections.Generic;
using System.Linq;

namespace FileReaderMcpServer.Search;

public class BM25Search
{
    private double k1 = 1.5;
    private double b = 0.75;
    private Dictionary<string, double> idf = new Dictionary<string, double>();
    private List<Document> documents;
    private double avgdl;

    public BM25Search(List<Document> docs)
    {
        documents = docs;
        var docFreq = new Dictionary<string, int>();
        int totalLen = 0;

        foreach (var doc in docs)
        {
            var tokens = doc.Tokens ?? new List<string>();
            totalLen += tokens.Count;
            var uniqueTokens = new HashSet<string>(tokens);
            foreach (var token in uniqueTokens)
            {
                if (!docFreq.ContainsKey(token)) docFreq[token] = 0;
                docFreq[token]++;
            }
        }

        avgdl = docs.Count > 0 ? (double)totalLen / docs.Count : 0;
        int N = docs.Count;

        foreach (var kvp in docFreq)
        {
            idf[kvp.Key] = Math.Log(1.0 + (N - kvp.Value + 0.5) / (kvp.Value + 0.5));
        }
    }

    public List<Document> Search(List<string> keywords, int top = 10)
    {
        var scores = new List<(Document Item, double Score)>();

        for (int i = 0; i < documents.Count; i++)
        {
            double score = Score(keywords, i);
            if (score > 0)
            {
                scores.Add((documents[i], score));
            }
        }

        return scores.OrderByDescending(s => s.Score).Take(top).Select(s => s.Item).ToList();
    }

    private double Score(List<string> keywords, int docIndex)
    {
        var docTokens = documents[docIndex].Tokens ?? new List<string>();
        var docLen = docTokens.Count;
        var freqs = new Dictionary<string, int>();
        foreach (var token in docTokens)
        {
            if (!freqs.ContainsKey(token)) freqs[token] = 0;
            freqs[token]++;
        }

        double score = 0.0;
        foreach (var q in keywords)
        {
            if (!freqs.ContainsKey(q) || !idf.ContainsKey(q)) continue;
            int f = freqs[q];
            double idfVal = idf[q];
            score += idfVal * (f * (k1 + 1)) / (f + k1 * (1 - b + b * (docLen / avgdl)));
        }
        return score;
    }
}
