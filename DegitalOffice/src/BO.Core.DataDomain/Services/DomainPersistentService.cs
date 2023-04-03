using BO.Core.DataCommon;
using BO.Core.DataCommon.Entities;
using BO.Core.DataCommon.Settings;
using BO.Core.DataCommon.Shared.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Concurrent;

namespace BO.Core.DataDomain.Services
{
    public class DomainPersistentService : PersistentService<DomainPersistentService>
    {
        private static readonly IDictionary<Type, string> PredefinedPersistentNames = new Dictionary<Type, string>
        {
            {typeof(MarketInfoRequest), ProviderConstants.MarketInfoRequestCollectionName},
            {typeof(User), ProviderConstants.UserCollectionName},
            {typeof(MarketData), ProviderConstants.MarketDataCollectionName},
        };

        private readonly IDictionary<string, object> collections;

        private static readonly object Lock = new object();

        //public DomainPersistentService(DatabaseSettings dbSettings, ILogger logger) : base(dbSettings, logger)
        //{
        //}
        public DomainPersistentService(IConfigurationRoot configuration, ILogger<DomainPersistentService> logger)
        : base(configuration.GetSection(ProviderConstants.DomainDatabaseSettings).Get<DatabaseSettings>(), logger)
        {
            lock (Lock)
            {
                collections = new ConcurrentDictionary<string, object>();
            }
        }

        public override IMongoCollection<T> GetCollection<T>()
        {
            lock (Lock)
            {
                if (!PredefinedPersistentNames.TryGetValue(typeof(T), out var collectionName))
                    throw new InvalidOperationException($"Collection for entity {typeof(T).Name} not found");

                if (collections.ContainsKey(collectionName))
                    return collections[collectionName] as IMongoCollection<T>;

                var collection = Database.GetCollection<T>(collectionName);
                collections.Add(collectionName, collection);

                return collection;
            }
        }
    }
}