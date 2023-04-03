using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common;
using CS.Common.Contract;
using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Exceptions;
using CS.Common.Interfaces;
using CS.Domain.Data.Queries;
using CS.Domain.Data.Repositories;
using Microsoft.AspNetCore.Http;

namespace CS.Domain.Data
{
    public class DataContextFactory : IDataFactory
    {
        private readonly ICacheService cacheService;
        private readonly IHttpContextAccessor httpContext;
        private readonly CSoftDataContext dataContext;
        private readonly IMapper mapper;

        private readonly Dictionary<Type, object> repositories;

        public DataContextFactory(CSoftDataContext dataContext, IMapper mapper, ICacheService cacheService, IHttpContextAccessor httpContext)
        {
            this.cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this.httpContext = httpContext;
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            repositories = new Dictionary<Type, object>();
        }

        public IRepository<T, TModel> CreateRepository<T, TModel, TEntity>(Func<TEntity, bool> predicateDeletedEntity = null)
            where TModel : ICommonResource<T>
            where TEntity : class, ICommonEntity<T>, new()
        {
            var type = typeof(TModel);
            if (repositories.ContainsKey(type))
                return repositories[type] as CommonRepository<T, TModel, TEntity>;

            var repository = new CommonRepository<T, TModel, TEntity>(dataContext, mapper, predicateDeletedEntity);
            repositories[type] = repository;
            return repository;
        }

        public IRepository<T, TModel> CreateReversionRepository<T, TModel, TEntity>(Func<TEntity, bool> predicateDeletedEntity = null)
            where TModel : IReversionResource<T> 
            where TEntity : class, IReversionEntity<T>, new()
        {
            var type = typeof(TModel);
            if (repositories.ContainsKey(type))
                return repositories[type] as ReversionRepository<T, TModel, TEntity>;

            var repository = new ReversionRepository<T, TModel, TEntity>(dataContext, mapper, predicateDeletedEntity);
            repositories[type] = repository;
            return repository;
        }
        
        public IQuery<T, TModel, TEntity> CreateQuery<T, TModel, TEntity>(params Expression<Func<TEntity, object>>[] includePaths)
            where TModel : IResource<T>
            where TEntity : class, IIdentityEntity<T>, new()
        {
            return new CachedQuery<T, TModel, TEntity>(cacheService, 
                new EntityQuery<T, TModel, TEntity>(httpContext, GetUserLogin(), dataContext, mapper, includePaths));
        }

        public async Task<TModel> UpdateSpecific<TKey, TModel, TEntity>(TKey key, Action<TEntity> onUpdatedEntity) 
            where TModel : IResource<TKey> 
            where TEntity : class, IIdentityEntity<TKey>, new()
        {
            var entity = dataContext.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(key));
            if (entity == null)
                throw new EntityNotFoundException<TKey>(key);

            onUpdatedEntity.Invoke(entity);

            if (entity is IReversionEntity<TKey> reversionEntity)
                reversionEntity.Version = reversionEntity.Version + 1;

            dataContext.Set<TEntity>().Update(entity);
            await dataContext.SaveChangesAsync();

            return mapper.Map<TModel>(entity);
        }

        private UserModel GetUserLogin()
        {
            var userId = httpContext.HttpContext.User.GetUserId();
            if (userId == null)
                return null;
            return cacheService.Get<Guid, UserModel>(userId.Value);
        }
    }
}
