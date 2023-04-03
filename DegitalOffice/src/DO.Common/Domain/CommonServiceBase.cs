using DO.Common.Contract;
using DO.Common.Domain.Interfaces;
using DO.Common.Interfaces;
using System.Linq.Expressions;

namespace DO.Common.Domain
{
    public abstract class CommonServiceBase<TKey, TModel, TEntity> : IDomainService<TKey, TModel, TEntity>
        where TModel : ICommonResource<TKey>
        where TEntity : class, ICommonEntity<TKey>, new()
    {
        private readonly ICacheService cacheService;
        private readonly IDataFactory dataFactory;

        protected CommonServiceBase(IDataFactory dataFactory, ICacheService cacheService)
        {
            this.cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this.dataFactory = dataFactory ?? throw new ArgumentNullException(nameof(dataFactory));
        }

        private IRepository<TKey, TModel> repository;
        protected IRepository<TKey, TModel> Repository => repository ?? (repository = dataFactory.CreateRepository<TKey, TModel, TEntity>(ValidateDelete));

        private IQuery<TKey, TModel, TEntity> query;
        public IQuery<TKey, TModel, TEntity> Query => query ?? (query = dataFactory.CreateQuery<TKey, TModel, TEntity>(EntityIncludedPaths.ToArray()));

        protected abstract bool ValidateInsert(TModel model);
        protected abstract bool ValidateUpdate(TModel model);
        protected abstract bool ValidateDelete(TEntity deletedEntity);
        protected abstract bool UseCache { get; }
        protected readonly IList<Expression<Func<TEntity, object>>> EntityIncludedPaths = new List<Expression<Func<TEntity, object>>>();

        public async Task<TModel> Insert(TModel model)
        {
            if (!ValidateInsert(model))
                return model;

            return await cacheService.Set<TKey, TModel>(() => UseCache, () => Repository.Insert(model));
        }

        public async Task<TModel> Update(TModel model)
        {
            if (!ValidateUpdate(model))
                return model;

            return await cacheService.Set<TKey, TModel>(() => UseCache, () => Repository.Update(model));
        }

        public async Task<bool> Delete(TKey id, bool ignoreValidation)
        {
            var isDeleted = await Repository.Delete(id, ignoreValidation);

            await cacheService.Remove<TKey, TModel>(() => isDeleted && UseCache, id);

            return isDeleted;
        }

        public async Task<TModel> UpdateSpecific(TKey key, Action<TEntity> onUpdatedEntity)
        {
            return await cacheService.Set<TKey, TModel>(
                () => UseCache,
                () => dataFactory.UpdateSpecific<TKey, TModel, TEntity>(key, onUpdatedEntity));
        }
    }
}