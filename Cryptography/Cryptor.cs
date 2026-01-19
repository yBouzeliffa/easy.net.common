using ClawSwipe.InfrastructureShared.Security.Models;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Cryptography;

namespace ClawSwipe.InfrastructureShared.Security.Helpers
{
    public class Cryptor
    {
        public static byte[] Encrypt(byte[] plainText, KeyNonce keyNonce, byte[]? associatedData = null)
        {
            GcmBlockCipher cipher = new(new AesEngine());
            AeadParameters parameters = new(new KeyParameter(keyNonce.Key), 128, keyNonce.Nonce, associatedData);

            cipher.Init(true, parameters);

            byte[] output = new byte[cipher.GetOutputSize(plainText.Length)];

            int bytesWritten = cipher.ProcessBytes(plainText, 0, plainText.Length, output, 0);
            bytesWritten += cipher.DoFinal(output, bytesWritten);

            byte[] cipherWithTag = new byte[bytesWritten];
            Array.Copy(output, 0, cipherWithTag, 0, bytesWritten);

            return cipherWithTag;
        }

        public static byte[] Decrypt(byte[] cipherWithTag, KeyNonce keyNonce, byte[]? associatedData = null)
        {
            GcmBlockCipher cipher = new(new AesEngine());
            AeadParameters parameters = new(new KeyParameter(keyNonce.Key), 128, keyNonce.Nonce, associatedData);

            cipher.Init(false, parameters);

            byte[] output = new byte[cipher.GetOutputSize(cipherWithTag.Length)];

            int bytesWritten = cipher.ProcessBytes(cipherWithTag, 0, cipherWithTag.Length, output, 0);
            bytesWritten += cipher.DoFinal(output, bytesWritten);

            byte[] plainText = new byte[bytesWritten];
            Array.Copy(output, 0, plainText, 0, bytesWritten);

            return plainText;
        }

        public static byte[] Nonce()
        {
            byte[] nonce = new byte[12]; // 12 octets => recommandé pour GCM
            RandomNumberGenerator.Fill(nonce);
            return nonce;
        }

        public static KeyNonce KeyNonce()
        {
            byte[] key = new byte[32];   // 32 octets => AES-256
            byte[] nonce = new byte[12]; // 12 octets => recommandé pour GCM

            RandomNumberGenerator.Fill(key);
            RandomNumberGenerator.Fill(nonce);

            return new KeyNonce(key, nonce);
        }
    }
}
