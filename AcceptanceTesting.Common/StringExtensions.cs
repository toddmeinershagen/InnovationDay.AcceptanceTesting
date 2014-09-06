using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AcceptanceTesting.Common
{
    public static class StringExtensions
    {
        static readonly byte[] Bytes = Encoding.ASCII.GetBytes("ZeroCool");

        public static string Encrypt(this string value)
        {
            using (var provider = new DESCryptoServiceProvider())
            {
                using (var stream = new MemoryStream())
                {
                    using (var crypto = new CryptoStream(stream, provider.CreateEncryptor(Bytes, Bytes), CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(crypto))
                        {
                            writer.Write(value);
                            writer.Flush();
                            crypto.FlushFinalBlock();
                            writer.Flush();
                            return Convert.ToBase64String(stream.GetBuffer(), 0, (int) stream.Length);
                        }
                    }
                }
            }
        }

        public static string Decrypt(this string value)
        {
            using (var provider = new DESCryptoServiceProvider())
            {
                using (var stream = new MemoryStream(Convert.FromBase64String(value)))
                {
                    using (var crypto = new CryptoStream(stream, provider.CreateDecryptor(Bytes, Bytes), CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(crypto))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}