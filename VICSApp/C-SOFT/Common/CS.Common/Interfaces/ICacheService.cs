﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Domain;

namespace CS.Common.Interfaces
{
    public interface ICacheService
    {
        Task<TModel> Set<TKey, TModel>(Func<bool> allowCache, Func<Task<TModel>> model) where TModel : IResource<TKey>;
        Task Remove<TKey, TModel>(Func<bool> allowCache, TKey id) where TModel : IResource<TKey>;
        Task<TModel> GetOrAdd<TKey, TModel>(Func<bool> allowCache, TKey id, Func<Task<TModel>> getModel) where TModel : IResource<TKey>;
        TModel Get<TKey, TModel>(TKey id) where TModel : IResource<TKey>;
        Task<T> Get<T>(string key, T @default);
        Task Update<T>(string key, T value);
    }
}
