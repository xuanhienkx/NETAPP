using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;

namespace CS.Common.Domain
{
    public class CachedQuery<TIdentity, TServiceModel, TEntityModel> 
        : IQuery<TIdentity, TServiceModel, TEntityModel>
        where TServiceModel : IResource<TIdentity>
        where TEntityModel : class, IIdentityEntity<TIdentity>
    {
        private readonly ICacheService cacheService;
        private readonly IQuery<TIdentity, TServiceModel, TEntityModel> query;

        public CachedQuery(ICacheService cacheService, IQuery<TIdentity, TServiceModel, TEntityModel> query)
        {
            this.cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public TServiceModel Get(TIdentity id)
        {
            return cacheService.GetOrAdd(() => true, id, () => Task.FromResult(query.Get(id))).Result;
        }

        public async Task<TServiceModel> GetAsync(TIdentity id)
        {
            return await cacheService.GetOrAdd(() => true, id, () => Task.FromResult(query.Get(id)));
        }

        public IList<TServiceModel> GetAll()
        {
            return query.GetAll();
        }

        public Task<IList<TServiceModel>> GetAllAsync()
        {
            return query.GetAllAsync();
        }

        public IList<TServiceModel> Filter(Expression<Func<TEntityModel, bool>> filter, params Expression<Func<TEntityModel, object>>[] excludePaths)
        {
            return query.Filter(filter, excludePaths);
        }

        public Task<IList<TServiceModel>> FilterAsync(Expression<Func<TEntityModel, bool>> filter, params Expression<Func<TEntityModel, object>>[] excludePaths)
        {
            return query.FilterAsync(filter, excludePaths);
        }

        public ListPaged<TServiceModel> FilterAsync(IDictionary<string, string> filter, params Expression<Func<TEntityModel, object>>[] excludePaths)
        {
            return query.FilterAsync(filter, excludePaths);
        }

        public IQueryable<TEntityModel> Queryable(params Expression<Func<TEntityModel, object>>[] excludePaths)
        {
            return query.Queryable(excludePaths);
        }

    }
}
