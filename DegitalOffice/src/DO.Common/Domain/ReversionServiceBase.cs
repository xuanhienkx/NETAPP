using DO.Common.Contract;
using DO.Common.Domain.Interfaces;
using DO.Common.Interfaces;

namespace DO.Common.Domain
{
    public abstract class ReversionServiceBase<TKey, TModel, TEntity> : IDomainService<TKey, TModel, TEntity>
        where TModel : IReversionResource<TKey>
        where TEntity : class, IReversionEntity<TKey>, new()
    {
        private readonly IDataFactory dataFactory;

        protected ReversionServiceBase(IDataFactory dataFactory)
        {
            this.dataFactory = dataFactory ?? throw new ArgumentNullException(nameof(dataFactory));
        }

        private IRepository<TKey, TModel> repository;
        protected IRepository<TKey, TModel> Repository => repository ?? (repository = dataFactory.CreateReversionRepository<TKey, TModel, TEntity>(ValidateDelete));

        private IQuery<TKey, TModel, TEntity> query;
        public IQuery<TKey, TModel, TEntity> Query => query ?? (query = dataFactory.CreateQuery<TKey, TModel, TEntity>());

        protected abstract bool ValidateInsert(TModel model);
        protected abstract bool ValidateUpdate(TModel model);
        protected abstract bool ValidateDelete(TEntity deletedEntity);

        public virtual Task<TModel> Insert(TModel model)
        {
            return ValidateInsert(model)
                ? Repository.Insert(model)
                : Task.FromResult(model);
        }

        public virtual Task<TModel> Update(TModel model)
        {
            return ValidateUpdate(model)
                ? Repository.Update(model)
                : Task.FromResult(model);
        }

        public virtual Task<bool> Delete(TKey id, bool ignoreValidation = false)
        {
            return Repository.Delete(id, ignoreValidation);
        }

        public async Task<TModel> UpdateSpecific(TKey key, Action<TEntity> onUpdatedEntity)
        {
            return await dataFactory.UpdateSpecific<TKey, TModel, TEntity>(key, onUpdatedEntity);
        }
    }
}