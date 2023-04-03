namespace DSoft.Common.Shared.Base
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
        public const string MediaResourceCollectionName = "resources";
        public const string DefaultCulture = "vi";
        public const string FallbackCulture = "en";
        public const string MarketInfoCollectionName = "market_info";
        #region MarketInfo
        public const string MessageName = "MessageName";
        public const string UpdateType = "UpdateType";
        public const string MarketMessageConfig = "marketMessageConfig";
        public const string TradingDate = "TradingDate";
        public const string MarketPrs = "MarketPrs";
        public const string RequestId = "req:id";
        public static int BufferSize = 2048;
        public const string SessionNumber = "SessionNumber";
        public const string InputSequenceNumber = "InputSequenceNumber";
        #endregion
        public const string AccessToken = "AccessToken";
        public const string RefreshToken = "RefreshToken";
        public const string ForceLogOut = "FORCE_LOGOUT";
        public const string InvalidToken = "INVALID_TOKEN";
        public const string MessageLastReadInfoLength = "File message read {0} has last visit length [{1:N0}]";
    }

}