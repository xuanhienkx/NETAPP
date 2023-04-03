using System.Threading.Tasks;
using CS.Common.Contract;

namespace CS.Common.Domain.Interfaces
{
    public interface IRepository<in TKey, TModel> where TModel : IResource<TKey>
    {
        Task<bool> Delete(TKey id, bool ignoreValidation);

        Task<TModel> Insert(TModel resource);

        Task<TModel> Update(TModel resource);
    }
}
