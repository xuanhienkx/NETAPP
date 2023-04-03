using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.Contract;
using CS.Common.Domain.Interfaces;
using CS.Common.Exceptions;

namespace CS.Domain.Data.Repositories
{
    public abstract class RepositoryBase<TIdentity, TServiceModel, TEntityModel> : IRepository<TIdentity, TServiceModel>
        where TServiceModel : IResource<TIdentity>
        where TEntityModel : class, IIdentityEntity<TIdentity>
    {
        protected readonly IMapper Mapper;
        protected readonly CSoftDataContext DataContext;

        protected RepositoryBase(CSoftDataContext dataContext, IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        protected abstract TEntityModel StartPreparingForInsert(TServiceModel model);
        protected abstract TEntityModel StartPreparingForUpdate(TServiceModel model);

        protected virtual void CleanupForDelete(TIdentity id)
        {
            //Do nothing
        }
        protected virtual void CleanupBeforeDelete(TIdentity id)
        {
            //Do nothing
        }

        protected virtual bool ValidateDelete(TEntityModel deleted)
        {
            return true;
        }

        public async Task<bool> Delete(TIdentity id, bool ignoreValidation)
        {
            var deleted = DataContext.Set<TEntityModel>().FirstOrDefault(x => x.Id.Equals(id));
            if (deleted == null)
                throw new EntityNotFoundException<TIdentity>(id);

            if (!ignoreValidation && !ValidateDelete(deleted))
                return false;

            CleanupBeforeDelete(id);
            DataContext.Set<TEntityModel>().Remove(deleted);
            CleanupForDelete(id);

            var result = await DataContext.SaveChangesAsync();
            return result >= 0;
        }

        public async Task<TServiceModel> Insert(TServiceModel resource)
        {
            var dbModel = StartPreparingForInsert(resource);
            Mapper.Map(resource, dbModel);

            var db = DataContext.Set<TEntityModel>().Add(dbModel).Entity;
            await DataContext.SaveChangesAsync();

            RecoveredModel(db, resource);
            resource.Id = db.Id;

            return resource;
        }

        public async Task<TServiceModel> Update(TServiceModel resource)
        {
            var updated = StartPreparingForUpdate(resource);
            Mapper.Map(resource, updated);
            var db = DataContext.Set<TEntityModel>().Update(updated).Entity;
            await DataContext.SaveChangesAsync();

            RecoveredModel(db, resource);
            return resource;
        }

        protected abstract void RecoveredModel(TEntityModel db, TServiceModel resource);

        protected T Get<T, TKey>(TKey id) where T : class, IIdentityEntity<TKey>
        {
            return DataContext.Set<T>().SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
