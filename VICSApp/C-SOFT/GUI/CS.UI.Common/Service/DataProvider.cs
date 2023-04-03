using CS.UI.Common.Service.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Std;

namespace CS.UI.Common.Service
{
    public class DataProvider : IDataProvider
    {
        private ObjectCache cache;
        private readonly ILogger logger;

        public DataProvider(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.cache = MemoryCache.Default;
        }

        public void Reset()
        {
            cache = MemoryCache.Default;
        }

        public async Task<RequestResult<T>> Get<T>(Guid id, string path, string requestId = null) where T : IResource<Guid>
        {
            return await Get<T>($"{path}/{id}", requestId);
        }

        public async Task<RequestResult<T>> Get<T>(long id, string path, string requestId = null) where T : IResource<long>
        {
            return await Get<T>($"{path}/{id}", requestId);
        }

        public async Task<RequestResult<T>> Get<T>(string path, string requestId = null)
        {
            return await ApiProvider.Instance.GetAsync(api => api.GetAsync<T>(path, requestId), exception => OnException(exception, path));
        }

        public async Task<RequestResult<IList<T>>> GetList<T>(string path, bool useCache = false)
        {
            if (useCache && cache.Contains(path))
                return cache.Get(path) as RequestResult<IList<T>>;

            var result = await ApiProvider.Instance.GetAsync(api => api.GetListAsync<T>(path), exception => OnException(exception, path));
            if (useCache)
                cache.Add(path, result, DateTimeOffset.MaxValue);

            return result;
        }

        public async Task<RequestResult<ListPaged<T>>> GetListPage<T>(string path, IDictionary<string, string> filterOptions)
        {
            return await ApiProvider.Instance.GetAsync(
                api => api.PostAsync<IDictionary<string, string>, ListPaged<T>>(path, filterOptions), 
                exception => OnException(exception, path));
        }

        public async Task<RequestResult<TR>> Post<T, TR>(string path, T model, string requestId = null)
        {
            cache.Remove(path);
            return await ApiProvider.Instance.GetAsync(api => api.PostAsync<T, TR>(path, model, requestId), exception => OnException(exception, path));
        }

        public async Task<RequestResult<T>> Put<T>(string path, T model, string requestId = null)
        {
            cache.Remove(path);
            return await ApiProvider.Instance.GetAsync(api => api.PutAsync(path, model, requestId), exception => OnException(exception, path));
        }

        public async Task<RequestResult<TR>> Put<T, TR>(string path, T model, string requestId = null)
        {
            cache.Remove(path);
            return await ApiProvider.Instance.GetAsync(api => api.PutAsync<T,TR>(path, model, requestId), exception => OnException(exception, path));
        }

        public async Task<RequestResult<bool>> Delete(string path, string requestId = null)
        {
            cache.Remove(path);
            return await ApiProvider.Instance.GetAsync(api => api.DeleteAsync(path, requestId), exception => OnException(exception, path));
        }

        private void OnException(Exception exception, string path)
        {
            Console.WriteLine(exception);
            logger.Error(exception, "Path: {0}", path);
        }
    }
}
