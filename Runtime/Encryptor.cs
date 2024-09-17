using System;
using System.Text;

namespace Achieve.DataProtector
{
    public sealed partial class Encryptor
    {
        /// <summary>
        /// string을 Gzip Compress, Encrypt 후 byte[]로 반환합니다.
        /// </summary>
        /// <param name="text">Encrypt 할 내용</param>
        /// <param name="key">내부에서 사용할 Key (16 || 32 byte)</param>
        /// <returns></returns>
        public static byte[] Encrypt(string text, string key) => EncryptInternal(text, key);
        
        /// <summary>
        /// byte[]를 Gzip Compress, Encrypt 후 byte[]로 반환합니다.
        /// </summary>
        /// <param name="bytes">Encrypt 할 내용</param>
        /// <param name="key">내부에서 사용할 Key (16 || 32 byte)</param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] bytes, string key) => EncryptInternal(bytes, key);

        /// <summary>
        /// string을 Gzip Compress, Encrypt 후 string으로 반환합니다.
        /// </summary>
        /// <param name="text">Encrypt 할 내용</param>
        /// <param name="key">내부에서 사용할 Key (16 || 32 byte)</param>
        /// <returns></returns>
        public static string EncryptToString(string text, string key) => Convert.ToBase64String(EncryptInternal(text, key));

        /// <summary>
        /// byte[]를 Gzip Compress, Encrypt 후 string으로 반환합니다.
        /// </summary>
        /// <param name="bytes">Encrypt 할 내용</param>
        /// <param name="key">내부에서 사용할 Key (16 || 32 byte)</param>
        /// <returns></returns>
        public static string EncryptToString(byte[] bytes, string key) => Convert.ToBase64String(EncryptInternal(bytes, key));

        /// <summary>
        /// string을 Gzip Decompress, Decrypt 후 byte[]로 반환합니다.
        /// </summary>
        /// <param name="text">Decrypt 할 내용</param>
        /// <param name="key">내부에서 사용할 Key (16 || 32 byte)</param>
        /// <returns></returns>
        public static byte[] Decrypt(string text, string key) => DecryptInternal(text, key);

        /// <summary>
        /// byte[]를 Gzip Decompress, Decrypt 후 byte[]로 반환합니다.
        /// </summary>
        /// <param name="bytes">Decrypt 할 내용</param>
        /// <param name="key">내부에서 사용할 Key (16 || 32 byte)</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] bytes, string key) => DecryptInternal(bytes, key);

        /// <summary>
        /// string을 Gzip Decompress, Decrypt 후 string으로 반환합니다.
        /// </summary>
        /// <param name="text">Decrypt 할 내용</param>
        /// <param name="key">내부에서 사용할 Key (16 || 32 byte)</param>
        /// <returns></returns>
        public static string DecryptToString(string text, string key) => Encoding.UTF8.GetString(DecryptInternal(text, key));

        /// <summary>
        /// byte[]를 Gzip Decompress, Decrypt 후 string으로 반환합니다.
        /// </summary>
        /// <param name="bytes">Decrypt 할 내용</param>
        /// <param name="key">내부에서 사용할 Key (16 || 32 byte)</param>
        /// <returns></returns>
        public static string DecryptToString(byte[] bytes, string key) => Encoding.UTF8.GetString(DecryptInternal(bytes, key));
    }
}