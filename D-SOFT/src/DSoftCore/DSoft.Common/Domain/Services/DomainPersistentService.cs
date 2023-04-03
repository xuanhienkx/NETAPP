using DSoft.Common.Models;
using DSoft.Common.Settings;
using DSoft.Common.Shared.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Concurrent;

namespace DSoft.Common.Domain.Services
{
    public class DomainPersistentService : PersistentService<DomainPersistentService>
    {
        private static readonly IDictionary<Type, string> PredefinedPersistentNames = new Dictionary<Type, string>
        {
              {typeof(MarketInfo), ProviderConstants.MarketInfoCollectionName},
        };

        private readonly IDictionary<string, object> collections;

        private static readonly object Lock = new object();

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
