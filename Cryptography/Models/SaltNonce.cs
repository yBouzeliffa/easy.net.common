namespace ClawSwipe.InfrastructureShared.Security.Models
{
    public class SaltNonce
    {
        public byte[] Nonce { get; init; }
        public byte[] Salt { get; init; }

        public SaltNonce(byte[] salt, byte[] nonce)
        {
            Salt = salt;
            Nonce = nonce;
        }
    }
}
