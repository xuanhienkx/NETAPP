using DO.Common.Contract;

namespace DO.Common.Domain.Interfaces;

public interface IRepository<in TKey, TModel> where TModel : IResource<TKey>
{
    Task<bool> Delete(TKey id, bool ignoreValidation);

    Task<TModel> Insert(TModel resource);

    Task<TModel> Update(TModel resource);
    TModel GetById(TKey id);
}