namespace ClawSwipe.InfrastructureShared.Security.Models
{
    public record KeySalt
    {
        public byte[] Key { get; init; }
        public byte[] Salt { get; init; }

        public KeySalt(byte[] key, byte[] salt)
        {
            Key = key;
            Salt = salt;
        }
    }
}
