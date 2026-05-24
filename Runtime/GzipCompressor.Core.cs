using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Achieve.DataProtector
{
    public sealed partial class GzipCompressor
    {
        private static byte[] CompressInternal(string text)
            => CompressInternal(Encoding.UTF8.GetBytes(text));

        private static byte[] CompressInternal(byte[] data)
        {
            using (var output = new MemoryStream())
            {
                using (var gzip = new GZipStream(output, CompressionLevel.Optimal))
                    gzip.Write(data, 0, data.Length);

                return output.ToArray();
            }
        }

        private static byte[] DecompressInternal(string text)
            => DecompressInternal(Convert.FromBase64String(text));

        private static byte[] DecompressInternal(byte[] compressedData)
        {
            using (var input = new MemoryStream(compressedData))
            using (var output = new MemoryStream())
            {
                using (var gzip = new GZipStream(input, CompressionMode.Decompress))
                    gzip.CopyTo(output);

                return output.ToArray();
            }
        }
    }
}
