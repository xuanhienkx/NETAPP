using DO.Common.Contract;
using System.Linq.Expressions;

namespace DO.Common.Domain.Interfaces;

public interface IDataFactory
{
    IRepository<TKey, TModel> CreateRepository<TKey, TModel, TEntity>(Func<TEntity, bool> predecateDeleted = null)
        where TModel : ICommonResource<TKey>
        where TEntity : class, ICommonEntity<TKey>, new();

    IRepository<TKey, TModel> CreateReversionRepository<TKey, TModel, TEntity>(Func<TEntity, bool> predecateDeleted = null)
        where TModel : IReversionResource<TKey>
        where TEntity : class, IReversionEntity<TKey>, new();

    IQuery<TKey, TModel, TEntity> CreateQuery<TKey, TModel, TEntity>(params Expression<Func<TEntity, object>>[] includePaths)
        where TModel : IResource<TKey>
        where TEntity : class, IIdentityEntity<TKey>, new();

    Task<TModel> UpdateSpecific<TKey, TModel, TEntity>(TKey key, Action<TEntity> onUpdatedEntity)
        where TModel : IResource<TKey>
        where TEntity : class, IIdentityEntity<TKey>, new();
}