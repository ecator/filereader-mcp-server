using System;
using System.Collections.Generic;
using System.Text;

namespace FileReaderMcpServer.Utils
{
    public static class HashSum
    {
        public static string GetSha256(string input)
        {
            var hashBytes = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return GetSha256(hashBytes);
        }
        public static string GetSha256(byte[] input)
        {
            return Convert.ToHexString(input).ToLower();
        }
    }
}
