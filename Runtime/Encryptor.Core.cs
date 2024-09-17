using Achieve.DataProtector;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Achieve.DataProtector
{
    public sealed partial class Encryptor
    {
        private static byte[] EncryptInternal(byte[] compressedData, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.GenerateIV();

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(compressedData, 0, compressedData.Length);
                        csEncrypt.FlushFinalBlock();
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        private static byte[] EncryptInternal(string text, string key)
        {
            byte[] compressedData = GzipCompressor.Compress(Encoding.UTF8.GetBytes(text));
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.GenerateIV();

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(compressedData, 0, compressedData.Length);
                        csEncrypt.FlushFinalBlock();
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        private static byte[] DecryptInternal(byte[] cipherBytes, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
            {
                byte[] iv = new byte[16]; // 동일한 IV 사용
                msDecrypt.Read(iv, 0, iv.Length);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    aesAlg.IV = iv;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream resultStream = new MemoryStream())
                        {
                            csDecrypt.CopyTo(resultStream);
                            byte[] decompressedData = GzipCompressor.Decompress(resultStream.ToArray());
                            return decompressedData;
                        }
                    }
                }
            }
        }

        private static byte[] DecryptInternal(string cipherText, string key)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
            {
                byte[] iv = new byte[16]; // 동일한 IV 사용
                msDecrypt.Read(iv, 0, iv.Length);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    aesAlg.IV = iv;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream resultStream = new MemoryStream())
                        {
                            csDecrypt.CopyTo(resultStream);
                            byte[] decompressedData = GzipCompressor.Decompress(resultStream.ToArray());
                            return decompressedData;
                        }
                    }
                }
            }
        }
    }
}