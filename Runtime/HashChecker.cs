using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Achieve.DataProtector
{
    public static class HashChecker
    {
        /// <summary>
        /// byte[]의 Hash 값을 뽑아옵니다.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ComputeHash(byte[] data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }

        /// <summary>
        /// string의 Hash 값을 뽑아옵니다.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return string.Concat(hash.Select(b => b.ToString("x2")));
            }
        }

        /// <summary>
        /// 두 해시 값을 비교합니다.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expectedHash"></param>
        /// <returns></returns>
        public static bool ValidateHash(byte[] data, byte[] expectedHash)
        {
            byte[] actualHash = ComputeHash(data);
            return actualHash.SequenceEqual(expectedHash);
        }
    }
}