using System;
using System.Threading.Tasks;
using CS.Common.Contract;

namespace CS.Common.Domain.Interfaces
{
    public interface IDomainService<in TKey, TModel, TEntity>
        where TModel : IResource<TKey>
        where TEntity : class, IIdentityEntity<TKey>
    {
        IQuery<TKey, TModel, TEntity> Query { get; }
        Task<bool> Delete(TKey id, bool ignoreValidation = false);
        Task<TModel> Insert(TModel resource);
        Task<TModel> Update(TModel resource);
        Task<TModel> UpdateSpecific(TKey key, Action<TEntity> onUpdatedEntity);
    }
}