using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.UI.Common.Service.Interface;

namespace CS.UI.Common.Extensions
{
    public static class DataProviderExtensions
    {
        public static async Task<T> GetValue<TId, T>(this IDataProvider dataProvider, TId id, string path) where T : IResource<TId>
        {
            var result = await dataProvider.Get<T>($"{path}/{id}");
            return result.HasResult ? result.Value : default(T);
        }

        public static async Task<IList<T>> GetListValue<T>(this IDataProvider dataProvider, string path, bool useCache = false)
        {
            var result = await dataProvider.GetList<T>(path, useCache);
            return result.HasResult ? result.Value : new List<T>();
        }
    }
}
