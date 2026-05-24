using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Achieve.DataProtector
{
    public static class HashChecker
    {
        public static byte[] ComputeHash(byte[] data)
        {
            using (var sha256 = SHA256.Create())
                return sha256.ComputeHash(data);
        }

        public static string ComputeHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return string.Concat(hash.Select(b => b.ToString("x2")));
            }
        }

        public static bool ValidateHash(byte[] data, byte[] expectedHash)
        {
            byte[] actualHash = ComputeHash(data);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }
}