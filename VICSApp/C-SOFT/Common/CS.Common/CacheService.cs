using CS.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Std.Extensions;

namespace CS.Common
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache cache;

        public CacheService(IDistributedCache cache)
        {
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<TModel> Set<TKey, TModel>(Func<bool> allowCache, Func<Task<TModel>> model) where TModel : IResource<TKey>
        {
            var obj = await model();

            if (!allowCache())
                return obj;

            await cache.SetAsync(BuildKey<TKey, TModel>(obj.Id), obj.ProtoBufSerialize());
            return obj;
        }

        public async Task Remove<TKey, TModel>(Func<bool> allowCache, TKey id) where TModel : IResource<TKey>
        {
            if (allowCache())
            {
                var key = BuildKey<TKey, TModel>(id);
                await cache.RemoveAsync(key);
            }
        }

        public async Task<TModel> GetOrAdd<TKey, TModel>(Func<bool> allowCache, TKey id, Func<Task<TModel>> getModel)
            where TModel : IResource<TKey>
        {
            if (!allowCache())
                return await getModel();

            var key = BuildKey<TKey, TModel>(id);
            var data = await cache.GetAsync(key);
            if (data == null)
            {
                var model = await getModel();
                await cache.SetAsync(key, model.ProtoBufSerialize());
                return model;
            }
            return data.ProtoBufDeserialize<TModel>();
        }

        public TModel Get<TKey, TModel>(TKey id) where TModel : IResource<TKey>
        {
            if (id == null)
                return default(TModel);

            var key = BuildKey<TKey, TModel>(id);
            var data = cache.Get(key);
            if (data == null)
                return default(TModel);
            return data.ProtoBufDeserialize<TModel>();
        }

        public async Task<T> Get<T>(string key, T @default)
        {
            var data = await cache.GetAsync(key);
            if (data != null)
                return data.ProtoBufDeserialize<T>();

            if (@default != null)
                await cache.SetAsync(key, @default.ProtoBufSerialize());
            return @default;
        }

        public async Task Update<T>(string key, T value)
        {
            await cache.SetAsync(key, value.ProtoBufSerialize());
        }

        private static string BuildKey<TKey, TModel>(TKey id) where TModel : IResource<TKey>
        {
            return $"{typeof(TModel).Name}{id}";
        }


    }
}
