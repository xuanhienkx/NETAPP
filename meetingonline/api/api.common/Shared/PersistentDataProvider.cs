using api.common.Shared.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace api.common.Shared
{
    public class PersistentDataProvider : IPersistentDataProvider
    {
        private readonly IMemoryCache memoryCache;

        public PersistentDataProvider(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public void Reset(string key)
        {
            if (string.IsNullOrEmpty(key))
                return;

            memoryCache.Remove(key);
        }

        public bool TryGet<T>(string key, out T message)
        {
            if (string.IsNullOrEmpty(key))
            {
                message = default;
                return false;
            }

            return memoryCache.TryGetValue(key, out message);
        }

        public void TryUpdate<T>(string key, Func<T, T> update)
        {
            if (string.IsNullOrEmpty(key))
                return;

            if (memoryCache.TryGetValue<T>(key, out var message))
            {
                memoryCache.Set(key, update(message));
            }
        }

        public void Set<T>(string key, T message)
        {
            if (string.IsNullOrEmpty(key))
                return;

            memoryCache.Set(key, message);
        }

        public T Get<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                return default;

            return memoryCache.Get<T>(key);
        }
    }
}
