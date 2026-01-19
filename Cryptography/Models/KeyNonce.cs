namespace Easy.Net.Common.Cryptography.Models
{
    public record KeyNonce
    {
        public byte[] Key { get; init; }
        public byte[] Nonce { get; init; }

        public KeyNonce(byte[] key, byte[] nonce)
        {
            Key = key;
            Nonce = nonce;
        }
    }
}
