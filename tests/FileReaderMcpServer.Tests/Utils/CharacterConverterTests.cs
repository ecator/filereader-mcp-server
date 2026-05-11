using FileReaderMcpServer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReaderMcpServer.Tests.Utils
{
    [TestClass]
    public sealed class CharacterConverterTests : TestBase
    {
        [TestMethod]
        public void ToFullWidth_Numbers_ReturnsFullWidth()
        {
            string input = "0123456789";
            string expected = "０１２３４５６７８９";
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input));
        }

        [TestMethod]
        public void ToFullWidth_Letters_ReturnsFullWidth()
        {
            string input = "ABCxyz";
            string expected = "ＡＢＣｘｙｚ";
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input));
        }

        [TestMethod]
        public void ToFullWidth_Symbols_ReturnsFullWidth()
        {
            string input = "!@#$%^&*()_+";
            string expected = "！＠＃＄％＾＆＊（）＿＋";
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input));
        }

        [TestMethod]
        public void ToFullWidth_Katakana_ReturnsFullWidth()
        {
            string input = "ｱｲｳｴｵｶﾞｷﾞｸﾞｹﾞｺﾞ";
            string expected = "アイウエオガギグゲゴ";
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input));
        }

        [TestMethod]
        public void ToFullWidth_Mixed_ReturnsFullWidth()
        {
            string input = "Hello 123 ﾃｽﾄ!";
            string expected = "Ｈｅｌｌｏ　１２３　テスト！";
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input));
        }

        [TestMethod]
        public void ToHalfWidth_Numbers_ReturnsHalfWidth()
        {
            string input = "０１２３４５６７８９";
            string expected = "0123456789";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input));
        }

        [TestMethod]
        public void ToHalfWidth_Letters_ReturnsHalfWidth()
        {
            string input = "ＡＢＣｘｙｚ";
            string expected = "ABCxyz";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input));
        }

        [TestMethod]
        public void ToHalfWidth_Symbols_ReturnsHalfWidth()
        {
            string input = "！＠＃＄％＾＆＊（）＿＋";
            string expected = "!@#$%^&*()_+";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input));
        }

        [TestMethod]
        public void ToHalfWidth_Katakana_ReturnsHalfWidth()
        {
            string input = "アイウエオガギグゲゴ";
            string expected = "ｱｲｳｴｵｶﾞｷﾞｸﾞｹﾞｺﾞ";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input));
        }

        [TestMethod]
        public void ToHalfWidth_Mixed_ReturnsHalfWidth()
        {
            string input = "Ｈｅｌｌｏ　１２３　テスト！";
            string expected = "Hello 123 ﾃｽﾄ!";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input));
        }

        [TestMethod]
        public void RoundTrip_MaintainsConsistency()
        {
            string original = "Hello 123! This is a ﾃｽﾄ. アイウエオ.";
            string full = CharacterConverter.ToFullWidth(original);
            string back = CharacterConverter.ToHalfWidth(full);

            string expectedBack = "Hello 123! This is a ﾃｽﾄ. ｱｲｳｴｵ.";
            Assert.AreEqual(expectedBack, back);
        }

        [TestMethod]
        public void ToFullWidth_Space_ReturnsFullWidthSpace()
        {
            Assert.AreEqual("　", CharacterConverter.ToFullWidth(" "));
        }

        [TestMethod]
        public void ToHalfWidth_Space_ReturnsHalfWidthSpace()
        {
            Assert.AreEqual(" ", CharacterConverter.ToHalfWidth("　"));
        }

        [TestMethod]
        public void ToFullWidth_UnconvertibleCharacters_RemainsUnchanged()
        {
            // Test Chinese characters and Hiragana (they don't have corresponding half-width counterparts, or don't need to be converted by this method)
            string input = "这是一个测试ひらがな";
            Assert.AreEqual(input, CharacterConverter.ToFullWidth(input));
        }

        [TestMethod]
        public void ToHalfWidth_UnconvertibleCharacters_RemainsUnchanged()
        {
            string input = "这是一个测试ひらがな";
            Assert.AreEqual(input, CharacterConverter.ToHalfWidth(input));
        }

        [TestMethod]
        public void ToFullWidth_SemiVoicedAndSpecialKatakana_ReturnsFullWidth()
        {
            // Includes semi-voiced marks (ﾊﾟﾋﾟﾌﾟﾍﾟﾎﾟ), special sounds (ｳﾞ), and half-width Japanese punctuation (｢｣｡､･)
            string input = "ﾊﾟﾋﾟﾌﾟﾍﾟﾎﾟ ｳﾞ ｢ﾃｽﾄ｣｡､･";
            string expected = "パピプペポ　ヴ　「テスト」。、・";
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input));
        }

        [TestMethod]
        public void ToHalfWidth_SemiVoicedAndSpecialKatakana_ReturnsHalfWidth()
        {
            string input = "パピプペポ　ヴ　「テスト」。、・";
            string expected = "ﾊﾟﾋﾟﾌﾟﾍﾟﾎﾟ ｳﾞ ｢ﾃｽﾄ｣｡､･";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input));
        }

        [TestMethod]
        public void ToFullWidth_EdgeAsciiSymbols_ReturnsFullWidth()
        {
            // Test the ends of the ASCII range and symbols that are prone to errors
            string input = " `~\\|{[}]";
            string expected = "　｀～＼｜｛［｝］";
            // Note: The full-width character corresponding to the backslash '\' might be '＼' (U+FF0C) or '￥' (U+FFE5), depending on specific business requirements.
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input));
        }

        [TestMethod]
        public void ToFullWidth_WithSpecificFlags_ConvertsOnlySelectedTypes()
        {
            string input = "A1! ﾃｽﾄ";
            // Only numbers and letters
            var type = CharacterConverter.ConvertType.Numbers | CharacterConverter.ConvertType.Letters;
            string expected = "Ａ１! ﾃｽﾄ";
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input, type));
        }

        [TestMethod]
        public void ToHalfWidth_WithSpecificFlags_ConvertsOnlySelectedTypes()
        {
            string input = "Ａ１！　テスト";
            // Only symbols and spaces
            var type = CharacterConverter.ConvertType.Symbols | CharacterConverter.ConvertType.Space;
            string expected = "Ａ１! テスト";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input, type));
        }

        [TestMethod]
        public void ToFullWidth_NoneFlag_ReturnsOriginalString()
        {
            string input = "A1! ﾃｽﾄ";
            Assert.AreEqual(input, CharacterConverter.ToFullWidth(input, CharacterConverter.ConvertType.None));
        }

        [TestMethod]
        public void ToHalfWidth_KatakanaOnly_ConvertsOnlyKatakana()
        {
            string input = "Ａ１！　テスト";
            var type = CharacterConverter.ConvertType.Katakana;
            string expected = "Ａ１！　ﾃｽﾄ";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input, type));
        }

        [TestMethod]
        public void ToFullWidth_NumbersOnly_ConvertsOnlyNumbers()
        {
            string input = "A1! ﾃｽﾄ";
            var type = CharacterConverter.ConvertType.Numbers;
            string expected = "A１! ﾃｽﾄ";
            Assert.AreEqual(expected, CharacterConverter.ToFullWidth(input, type));
        }

        [TestMethod]
        public void ToHalfWidth_NumbersOnly_ConvertsOnlyNumbers()
        {
            string input = "Ａ１！　测试";
            var type = CharacterConverter.ConvertType.Numbers;
            string expected = "Ａ1！　测试";
            Assert.AreEqual(expected, CharacterConverter.ToHalfWidth(input, type));
        }

        [TestMethod]
        public void Normalize_MixedInput_ReturnsNormalizedString()
        {
            // Input: Full-width ABC, Full-width 123, Half-width Katakana, Mixed Case
            string input = "ＡＢＣ １２３ ｱｲｳｴｵ Test ﾃｽﾄ";
            // 1. Katakana to full-width: ｱｲｳｴｵ -> アイウエオ, ﾃｽﾄ -> テスト
            // 2. Alphanumeric to half-width: ＡＢＣ -> ABC, １２３ -> 123
            // 3. Lowercase: No (default)
            string expected = "ABC 123 アイウエオ Test テスト";
            Assert.AreEqual(expected, CharacterConverter.Normalize(input));
        }

        [TestMethod]
        public void Normalize_WithToLower_ReturnsLowercasedString()
        {
            string input = "ＡＢＣ １２３ ｱｲｳｴｵ Test ﾃｽﾄ";
            string expected = "abc 123 アイウエオ test テスト";
            Assert.AreEqual(expected, CharacterConverter.Normalize(input, toLower: true));
        }

        [TestMethod]
        public void Normalize_WithSymbols_DoesNotConvertSymbolsToHalfWidth()
        {
            string input = "ＡＢＣ！ １２３？";
            // ABC -> ABC, 123 -> 123, symbols ! and ? remain full-width
            string expected = "ABC！ 123？";
            Assert.AreEqual(expected, CharacterConverter.Normalize(input));
        }

        [TestMethod]
        public void Normalize_EmptyOrNull_ReturnsSame()
        {
            Assert.IsNull(CharacterConverter.Normalize(null!));
            Assert.AreEqual("", CharacterConverter.Normalize(""));
        }
    }
}
