using Easy.Net.Common.Cryptography.Models;
using System.Security.Cryptography;

namespace Easy.Net.Common.Cryptography
{
    public static class GetKeyFromPasswordHelper
    {
        public static byte[] RestoreKey(string password, byte[] salt)
        {
            return DeriveKeyFromPassword(password, salt).Key;
        }

        public static KeySalt CreateKey(string password)
        {
            byte[] salt = GenerateRandomSalt();
            return DeriveKeyFromPassword(password, salt);
        }

        private static KeySalt DeriveKeyFromPassword(string password, byte[] salt, int iterations = 150_000, int keySize = 32)
        {
            if (salt == null)
                throw new ArgumentNullException(nameof(salt));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            using var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            return new KeySalt(deriveBytes.GetBytes(keySize), salt);
        }

        private static byte[] GenerateRandomSalt(int saltSize = 16)
        {
            byte[] salt = new byte[saltSize];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }
    }
}
