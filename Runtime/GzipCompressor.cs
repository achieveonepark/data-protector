using System;
using System.Text;

namespace Achieve.DataProtector
{
    public sealed partial class GzipCompressor
    {
        public static byte[] Compress(byte[] data) => CompressInternal(data);
        public static byte[] Compress(string text) => CompressInternal(text);
        public static string CompressToString(byte[] data) => Convert.ToBase64String(CompressInternal(data));
        public static string CompressToString(string text) => Convert.ToBase64String(CompressInternal(text));
        public static byte[] Decompress(byte[] data) => DecompressInternal(data);
        public static byte[] Decompress(string text) => DecompressInternal(text);
        public static string DecompressToString(byte[] data) => Encoding.UTF8.GetString(DecompressInternal(data));
        public static string DecompressToString(string text) => Encoding.UTF8.GetString(DecompressInternal(text));
    }
}