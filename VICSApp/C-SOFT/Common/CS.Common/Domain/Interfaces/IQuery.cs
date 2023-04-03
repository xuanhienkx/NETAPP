using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CS.Common.Contract;

namespace CS.Common.Domain.Interfaces
{
    public interface IQuery<in TIdentity, TServiceModel, TEntityModel> 
        where TServiceModel : IResource<TIdentity>
        where TEntityModel : class, IIdentityEntity<TIdentity>
    {
        TServiceModel Get(TIdentity id);
        Task<TServiceModel> GetAsync(TIdentity id);

        IList<TServiceModel> GetAll();
        Task<IList<TServiceModel>> GetAllAsync();

        IList<TServiceModel> Filter(Expression<Func<TEntityModel, bool>> filter, params Expression<Func<TEntityModel, object>>[] excludePaths);
        Task<IList<TServiceModel>> FilterAsync(Expression<Func<TEntityModel, bool>> filter, params Expression<Func<TEntityModel, object>>[] excludePaths);
        ListPaged<TServiceModel> FilterAsync(IDictionary<string, string> filter, params Expression<Func<TEntityModel, object>>[] excludePaths);
        IQueryable<TEntityModel> Queryable(params Expression<Func<TEntityModel, object>>[] excludePaths);   
    }
}
