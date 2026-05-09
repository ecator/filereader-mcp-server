using System;
using System.Collections.Generic;
using System.Text;
using FileReaderMcpServer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReaderMcpServer.Tests.Utils
{
    [TestClass]
    public sealed class HashSumTests : TestBase
    {
        [TestMethod]
        public void GetSha256_String_Empty_ReturnsCorrectHash()
        {
            // Arrange
            string input = "";
            string expected = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";

            // Act
            string actual = HashSum.GetSha256(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSha256_String_HelloWorld_ReturnsCorrectHash()
        {
            // Arrange
            string input = "Hello World";
            string expected = "a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e";

            // Act
            string actual = HashSum.GetSha256(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSha256_ByteArray_ReturnsCorrectHex()
        {
            // Arrange
            byte[] input = new byte[] { 0x00, 0x01, 0x02, 0x03, 0xFF };
            string expected = "00010203ff";

            // Act
            string actual = HashSum.GetSha256(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
