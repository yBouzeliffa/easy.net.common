using System.ComponentModel;

namespace Easy.Net.Common
{
    public enum TwoFactorCodeType
    {
        [Description("SignInEmail")]
        SignInEmail,
        [Description("SignInSms")]
        SignInSms,
        [Description("PhoneVerification")]
        PhoneVerification,
        [Description("Totp2fa")]
        Totp2fa,
    }
}
