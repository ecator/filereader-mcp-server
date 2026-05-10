using System.Text;

namespace FileReaderMcpServer.Utils;

/// <summary>
/// Provides methods for converting between full-width (Zenkaku) and half-width (Hankaku) characters.
/// Supports numbers, English letters, common symbols, and Japanese Katakana.
/// </summary>
public static class CharacterConverter
{
    private const int ZenkakuOffset = 0xFEE0;
    private const char HalfWidthSpace = ' ';
    private const char FullWidthSpace = '　';

    /// <summary>
    /// Specifies the types of characters to convert between full-width and half-width.
    /// </summary>
    [Flags]
    public enum ConvertType : byte
    {
        /// <summary>No conversion.</summary>
        None = 0,
        /// <summary>Convert spaces.</summary>
        Space = 1 << 0,
        /// <summary>Convert symbols and punctuation.</summary>
        Symbols = 1 << 1,
        /// <summary>Convert numbers (0-9).</summary>
        Numbers = 1 << 2,
        /// <summary>Convert English letters (A-Z, a-z).</summary>
        Letters = 1 << 3,
        /// <summary>Convert Japanese Katakana and associated punctuation.</summary>
        Katakana = 1 << 4,
        /// <summary>Convert all supported character types.</summary>
        All = Space | Symbols | Numbers | Letters | Katakana
    }

    private static readonly Dictionary<string, string> HalfToFullKatakana = new()
    {
        { "ｱ", "ア" }, { "ｲ", "イ" }, { "ｳ", "ウ" }, { "ｴ", "エ" }, { "ｵ", "オ" },
        { "ｶ", "カ" }, { "ｷ", "キ" }, { "ｸ", "ク" }, { "ｹ", "ケ" }, { "ｺ", "コ" },
        { "ｻ", "サ" }, { "ｼ", "シ" }, { "ｽ", "ス" }, { "ｾ", "セ" }, { "ｿ", "ソ" },
        { "ﾀ", "タ" }, { "ﾁ", "チ" }, { "ﾂ", "ツ" }, { "ﾃ", "テ" }, { "ﾄ", "ト" },
        { "ﾅ", "ナ" }, { "ﾆ", "ニ" }, { "ﾇ", "ヌ" }, { "ﾈ", "ネ" }, { "ﾉ", "ノ" },
        { "ﾊ", "ハ" }, { "ﾋ", "ヒ" }, { "ﾌ", "フ" }, { "ﾍ", "ヘ" }, { "ﾎ", "ホ" },
        { "ﾏ", "マ" }, { "ﾐ", "ミ" }, { "ﾑ", "ム" }, { "ﾒ", "メ" }, { "ﾓ", "モ" },
        { "ﾔ", "ヤ" }, { "ﾕ", "ユ" }, { "ﾖ", "ヨ" },
        { "ﾗ", "ラ" }, { "ﾘ", "リ" }, { "ﾙ", "ル" }, { "ﾚ", "レ" }, { "ﾛ", "ロ" },
        { "ﾜ", "ワ" }, { "ｦ", "ヲ" }, { "ﾝ", "ン" },
        { "ｧ", "ァ" }, { "ｨ", "ィ" }, { "ｩ", "ゥ" }, { "ｪ", "ェ" }, { "ｫ", "ォ" },
        { "ｯ", "ッ" }, { "ｬ", "ャ" }, { "ｭ", "ュ" }, { "ｮ", "ョ" },
        { "ｳﾞ", "ヴ" }, { "ｶﾞ", "ガ" }, { "ｷﾞ", "ギ" }, { "ｸﾞ", "グ" }, { "ｹﾞ", "ゲ" }, { "ｺﾞ", "ゴ" },
        { "ｻﾞ", "ザ" }, { "ｼﾞ", "ジ" }, { "ｽﾞ", "ズ" }, { "ｾﾞ", "ゼ" }, { "ｿﾞ", "ゾ" },
        { "ﾀﾞ", "ダ" }, { "ﾁﾞ", "ヂ" }, { "ﾂﾞ", "ヅ" }, { "ﾃﾞ", "デ" }, { "ﾄﾞ", "ド" },
        { "ﾊﾞ", "バ" }, { "ﾋﾞ", "ビ" }, { "ﾌﾞ", "ブ" }, { "ﾍﾞ", "ベ" }, { "ﾎﾞ", "ボ" },
        { "ﾊﾟ", "パ" }, { "ﾋﾟ", "ピ" }, { "ﾌﾟ", "プ" }, { "ﾍﾟ", "ペ" }, { "ﾎﾟ", "ポ" },
        { "ﾜﾞ", "ヷ" }, { "ｲﾞ", "ヸ" }, { "ｴﾞ", "ヹ" }, { "ｦﾞ", "ヺ" },
        { "｡", "。" }, { "｢", "「" }, { "｣", "」" }, { "､", "、" }, { "･", "・" },
        { "ｰ", "ー" }, { "ﾞ", "゛" }, { "ﾟ", "゜" }
    };

    private static readonly Dictionary<string, string> FullToHalfKatakana;

    static CharacterConverter()
    {
        FullToHalfKatakana = new Dictionary<string, string>();
        foreach (var kvp in HalfToFullKatakana)
        {
            // For full-to-half, we map the full-width character to its half-width representation.
            // Some full-width characters map to multiple half-width characters (e.g. ガ -> ｶﾞ)
            if (!FullToHalfKatakana.ContainsKey(kvp.Value))
            {
                FullToHalfKatakana.Add(kvp.Value, kvp.Key);
            }
        }
    }

    /// <summary>
    /// Converts a string containing half-width characters to full-width characters.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <param name="convertType">The types of characters to convert (default is all).</param>
    /// <returns>A string with half-width characters replaced by their full-width equivalents.</returns>
    public static string ToFullWidth(string input, ConvertType convertType = ConvertType.All)
    {
        if (string.IsNullOrEmpty(input)) return input;

        StringBuilder sb = new StringBuilder(input.Length);
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            // 1. Handle space
            if (c == HalfWidthSpace)
            {
                if ((convertType & ConvertType.Space) != 0)
                {
                    sb.Append(FullWidthSpace);
                    continue;
                }
            }

            // 2. Handle ASCII (numbers, letters, symbols)
            if (c >= 0x21 && c <= 0x7E)
            {
                bool shouldConvert = false;
                if (c >= '0' && c <= '9')
                {
                    shouldConvert = (convertType & ConvertType.Numbers) != 0;
                }
                else if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    shouldConvert = (convertType & ConvertType.Letters) != 0;
                }
                else
                {
                    shouldConvert = (convertType & ConvertType.Symbols) != 0;
                }

                if (shouldConvert)
                {
                    sb.Append((char)(c + ZenkakuOffset));
                    continue;
                }
            }

            // 3. Handle Katakana (checking for combined characters first)
            if ((convertType & ConvertType.Katakana) != 0)
            {
                if (i + 1 < input.Length)
                {
                    string pair = input.Substring(i, 2);
                    if (HalfToFullKatakana.TryGetValue(pair, out string? fullPair))
                    {
                        sb.Append(fullPair);
                        i++; // Skip next character
                        continue;
                    }
                }

                string single = c.ToString();
                if (HalfToFullKatakana.TryGetValue(single, out string? fullSingle))
                {
                    sb.Append(fullSingle);
                    continue;
                }
            }

            // No conversion
            sb.Append(c);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Converts a string containing full-width characters to half-width characters.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <param name="convertType">The types of characters to convert (default is all).</param>
    /// <returns>A string with full-width characters replaced by their half-width equivalents.</returns>
    public static string ToHalfWidth(string input, ConvertType convertType = ConvertType.All)
    {
        if (string.IsNullOrEmpty(input)) return input;

        StringBuilder sb = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            // 1. Handle space
            if (c == FullWidthSpace)
            {
                if ((convertType & ConvertType.Space) != 0)
                {
                    sb.Append(HalfWidthSpace);
                    continue;
                }
            }

            // 2. Handle full-width ASCII
            if (c >= 0xFF01 && c <= 0xFF5E)
            {
                bool shouldConvert = false;
                if (c >= 0xFF10 && c <= 0xFF19) // Full-width numbers
                {
                    shouldConvert = (convertType & ConvertType.Numbers) != 0;
                }
                else if ((c >= 0xFF21 && c <= 0xFF3A) || (c >= 0xFF41 && c <= 0xFF5A)) // Full-width letters
                {
                    shouldConvert = (convertType & ConvertType.Letters) != 0;
                }
                else
                {
                    shouldConvert = (convertType & ConvertType.Symbols) != 0;
                }

                if (shouldConvert)
                {
                    sb.Append((char)(c - ZenkakuOffset));
                    continue;
                }
            }

            // 3. Handle full-width Katakana
            if ((convertType & ConvertType.Katakana) != 0)
            {
                string single = c.ToString();
                if (FullToHalfKatakana.TryGetValue(single, out string? half))
                {
                    sb.Append(half);
                    continue;
                }
            }

            // No conversion
            sb.Append(c);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Normalizes the input text by:
    /// 1. Converting half-width Katakana to full-width.
    /// 2. Converting full-width numbers and English letters to half-width.
    /// 3. Converting all characters to lowercase.
    /// </summary>
    /// <param name="input">The string to normalize.</param>
    /// <returns>The normalized string.</returns>
    public static string Normalize(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        // 1. Convert half-width Katakana to full-width
        string result = ToFullWidth(input, ConvertType.Katakana);

        // 2. Convert full-width numbers and English letters to half-width
        result = ToHalfWidth(result, ConvertType.Numbers | ConvertType.Letters);

        // 3. Convert all characters to lowercase
        return result.ToLowerInvariant();
    }
}
