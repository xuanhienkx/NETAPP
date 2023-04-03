namespace BO.Core.DataCommon
{
    public static class ProviderConstants
    {
        public const string DomainDatabaseSettings = "domainMongoDbSettings";
        public const string AuditDatabaseSettings = "auditMongoDbSettings";
        public const string HangfireDatabaseSettings = "hangfireMongoDbSettings";

        public const string CorsPolicy = "Cors";
        public const string ApplicationSettingsFile = "appsettings.json";

        public const string WebSocketSegment = "/ws";
        public const string MessageAccessToken = "access_token";

        public const string LoginProvider = "[skylar-tech.com]";
        public const string AuthenticatorKeyTokenName = "meetingonline-auth-key";
        public const string RecoveryCodeTokenName = "meetingonline-recode";

        public const string MarketDataCollectionName = "market_data";
        public const string MeetingRoleCollectionName = "meeting_roles";
        public const string UserCollectionName = "users";
        public const string MediaResourceCollectionName = "resources";
        public const string MarketInfoRequestCollectionName = "market_info_request";

        public const string ElectionYes = "vote.options.yes";
        public const string ElectionNo = "vote.options.no";
        public const string ElectionIgnore = "vote.options.ignore";

        public const string AllowUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

        public const string DefaultCulture = "vi";
        public const string FallbackCulture = "en";

        public const string ForceLogOut = "FORCE_LOGOUT";
        public const string InvalidToken = "INVALID_TOKEN";
        public const string MediaResourceLinkProvider = "Url";
    }
}
