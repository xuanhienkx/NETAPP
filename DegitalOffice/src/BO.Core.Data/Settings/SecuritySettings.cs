namespace BO.Core.DataCommon.Settings
{
    public class SecuritySettings
    {
        public string SuperAdminEmail { get; set; }
        public string TokenKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryInHours { get; set; }
        public bool RequiredNonceValidation { get; set; }
    }
}
