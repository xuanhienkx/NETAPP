namespace CS.Common.Std
{
    public static class GlobalConstantsProvider
    {
        #region Connection Strings

        public const string CoreConnectionString = "coreConnection";
        public const string SecurityConnectionString = "securityConnection";
        public const string AuditConnectionString = "auditConnection";

        #endregion

        #region Settings

        public const string ApplicationSettingFile = "appsettings.json";
        public const string CsAdminUniqueId = "68182305-4B95-4E15-BEDB-9C4CC68B65A6";
        public const string CsServiceUniqueId = "E8EF177C-572C-44E3-8E3B-D60A534B1499";

        public const string TokenKey = "token:key";
        public const string TokenIssuer = "token:issuer";
        public const string TokenAudience = "token:audience";
        public const string TokenExpiryInHours = "token:tokenExpiryInHours";
        public const string ServiceSecrectKey = "serviceSecrectKey";

        public const string AspNetEnvironment = "ASPNETCORE_ENVIRONMENT";

        public const string RequestId = "req:id";
        public const string UserPermission = "USER_PERMISSION";

        #endregion

    }
}
