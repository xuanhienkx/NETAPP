namespace Api.Data.Core
{
    public static class GlobalConstantsProvider
    {
        #region Connection Strings

        public const string QuoteConnectionString = "quoteConnection";
        public const string SbsConnectionString = "sbsConnection";
        public const string TokenKey = "token:key";
        public const string TokenIssuer = "token:issuer";
        public const string TokenAudience = "token:audience";
        public const string TokenExpiryInHours = "token:tokenExpiryInHours";
        public const string ServiceSecrectKey = "serviceSecrectKey";
        #endregion 
        #region Settings

        public const string ApplicationSettingFile = "appsettings.json";

        #endregion
    }
}