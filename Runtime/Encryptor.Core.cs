using System;
using System.Security.Cryptography;
using System.Text;

namespace Achieve.DataProtector
{
    public sealed partial class Encryptor
    {
        private const int NonceSizeBytes = 12;
        private const int TagSizeBytes = 16;

        private static byte[] DeriveKey(string key)
        {
            using (var sha256 = SHA256.Create())
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        }

        private static byte[] EncryptInternal(string text, string key)
            => EncryptInternal(Encoding.UTF8.GetBytes(text), key);

        private static byte[] EncryptInternal(byte[] data, string key)
        {
            byte[] compressed = GzipCompressor.Compress(data);
            byte[] keyBytes = DeriveKey(key);

            byte[] nonce = new byte[NonceSizeBytes];
            RandomNumberGenerator.Fill(nonce);

            byte[] tag = new byte[TagSizeBytes];
            byte[] ciphertext = new byte[compressed.Length];

            using (var aesGcm = new AesGcm(keyBytes))
                aesGcm.Encrypt(nonce, compressed, ciphertext, tag);

            byte[] result = new byte[NonceSizeBytes + TagSizeBytes + ciphertext.Length];
            Buffer.BlockCopy(nonce, 0, result, 0, NonceSizeBytes);
            Buffer.BlockCopy(tag, 0, result, NonceSizeBytes, TagSizeBytes);
            Buffer.BlockCopy(ciphertext, 0, result, NonceSizeBytes + TagSizeBytes, ciphertext.Length);
            return result;
        }

        private static byte[] DecryptInternal(string cipherText, string key)
            => DecryptInternal(Convert.FromBase64String(cipherText), key);

        private static byte[] DecryptInternal(byte[] cipherBytes, string key)
        {
            if (cipherBytes.Length < NonceSizeBytes + TagSizeBytes)
                throw new ArgumentException("Invalid ciphertext length.", nameof(cipherBytes));

            byte[] keyBytes = DeriveKey(key);

            byte[] nonce = new byte[NonceSizeBytes];
            byte[] tag = new byte[TagSizeBytes];
            byte[] encryptedData = new byte[cipherBytes.Length - NonceSizeBytes - TagSizeBytes];

            Buffer.BlockCopy(cipherBytes, 0, nonce, 0, NonceSizeBytes);
            Buffer.BlockCopy(cipherBytes, NonceSizeBytes, tag, 0, TagSizeBytes);
            Buffer.BlockCopy(cipherBytes, NonceSizeBytes + TagSizeBytes, encryptedData, 0, encryptedData.Length);

            byte[] compressed = new byte[encryptedData.Length];

            using (var aesGcm = new AesGcm(keyBytes))
                aesGcm.Decrypt(nonce, encryptedData, tag, compressed);

            return GzipCompressor.Decompress(compressed);
        }
    }
}
