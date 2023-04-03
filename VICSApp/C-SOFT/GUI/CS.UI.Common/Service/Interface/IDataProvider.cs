using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Std;

namespace CS.UI.Common.Service.Interface
{
    public interface IDataProvider
    {
        void Reset();
        Task<RequestResult<T>> Get<T>(Guid id, string path, string requestId = null) where T : IResource<Guid>;
        Task<RequestResult<T>> Get<T>(long id, string path, string requestId = null) where T : IResource<long>;
        Task<RequestResult<T>> Get<T>(string path, string requestId = null);
        Task<RequestResult<TR>> Post<T, TR>(string path, T model, string requestId = null);
        Task<RequestResult<T>> Put<T>(string path, T model, string requestId = null);
        Task<RequestResult<TR>> Put<T, TR>(string path, T model, string requestId = null);
        Task<RequestResult<bool>> Delete(string path, string requestId = null);
        Task<RequestResult<IList<T>>> GetList<T>(string path, bool useCache = false);
        Task<RequestResult<ListPaged<T>>> GetListPage<T>(string path, IDictionary<string, string> filterOptions);
    }
}