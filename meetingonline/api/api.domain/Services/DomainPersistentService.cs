using api.common;
using api.common.Models;
using api.common.Models.Identity;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using api.common.Settings;

namespace api.domain.Services
{
    public class DomainPersistentService : PersistentService<DomainPersistentService>
    {
        private static readonly IDictionary<Type, string> PredefinedPersistentNames = new Dictionary<Type, string>
        {
            {typeof(MeetingRole), ProviderConstants.MeetingRoleCollectionName},
            {typeof(Meeting), ProviderConstants.MeetingCollectionName},
            {typeof(IdentityUser), ProviderConstants.UserCollectionName},
            {typeof(MediaResource), ProviderConstants.MediaResourceCollectionName},
            {typeof(DelegateRequest), ProviderConstants.DelegateRequestCollectionName},
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
