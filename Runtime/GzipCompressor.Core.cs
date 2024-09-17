using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Achieve.DataProtector
{
    public sealed partial class GzipCompressor
    {
        public static byte[] CompressInternal(byte[] data)
        {
            using (var output = new MemoryStream())
            {
                using (var gzip = new GZipStream(output, System.IO.Compression.CompressionLevel.Optimal))
                {
                    gzip.Write(data, 0, data.Length);
                }
                return output.ToArray();
            }
        }

        public static byte[] CompressInternal(string text)
        {
            var data = Encoding.UTF8.GetBytes(text);
            using (var output = new MemoryStream())
            {
                using (var gzip = new GZipStream(output, System.IO.Compression.CompressionLevel.Optimal))
                {
                    gzip.Write(data, 0, data.Length);
                }
                return output.ToArray();
            }
        }

        public static byte[] DecompressInternal(byte[] compressedData)
        {
            using (var input = new MemoryStream(compressedData))
            {
                using (var output = new MemoryStream())
                {
                    using (var gzip = new GZipStream(input, CompressionMode.Decompress))
                    {
                        gzip.CopyTo(output);
                    }
                    return output.ToArray();
                }
            }
        }

        public static byte[] DecompressInternal(string text)
        {
            var compressedData = Convert.FromBase64String(text);

            using (var input = new MemoryStream(compressedData))
            {
                using (var output = new MemoryStream())
                {
                    using (var gzip = new GZipStream(input, CompressionMode.Decompress))
                    {
                        gzip.CopyTo(output);
                    }
                    return output.ToArray();
                }
            }
        }
    }
}