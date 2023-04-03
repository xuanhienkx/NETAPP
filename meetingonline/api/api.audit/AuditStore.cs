using System;
using System.Threading.Tasks;
using api.common;
using api.common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace api.audit
{
    public interface IAuditStore
    {
        Task Audit<T>(T notification, string collectionName) where T : class;
    }

    public class AuditStore : IAuditStore
    {
        private readonly IMongoDatabase database;
        private readonly ILogger<AuditStore> logger;

        public AuditStore(IConfigurationRoot configuration, ILogger<AuditStore> logger)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            var settings = configuration.GetSection(ProviderConstants.AuditDatabaseSettings).Get<DatabaseSettings>();

            this.database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Audit<T>(T notification, string collectionName) where T : class
        {
            logger.LogDebug($"Audit log: {collectionName}");
            return database.GetCollection<T>(collectionName).InsertOneAsync(notification);
        }
    }
}
