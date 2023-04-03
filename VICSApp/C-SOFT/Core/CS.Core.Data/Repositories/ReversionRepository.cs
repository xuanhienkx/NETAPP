using System;
using System.Linq;
using AutoMapper;
using CS.Common.Contract;
using CS.Common.Domain.Interfaces;
using CS.Common.Exceptions;

namespace CS.Domain.Data.Repositories
{
    public class ReversionRepository<TIdentity, TServiceModel, TEntityModel> : RepositoryBase<TIdentity, TServiceModel, TEntityModel>
        where TServiceModel : IReversionResource<TIdentity>
        where TEntityModel : class, IReversionEntity<TIdentity>, new()
    {
        private readonly Func<TEntityModel, bool> predicateDeletedEntity;

        public ReversionRepository(CSoftDataContext dataContext, IMapper mapper, Func<TEntityModel, bool> predicateDeletedEntity) 
            : base(dataContext, mapper)
        {
            this.predicateDeletedEntity = predicateDeletedEntity;
        }

        protected override TEntityModel StartPreparingForInsert(TServiceModel model)
        {
            return new TEntityModel();
        }

        protected override TEntityModel StartPreparingForUpdate(TServiceModel model)
        {
            var entity = DataContext.Set<TEntityModel>().FirstOrDefault(x => Equals(x.Id, model.Id));
            if (entity == null)
                throw new EntityNotFoundException<TServiceModel>(model);

            if (model.Version != entity.Version)
                throw new EntityNotSameVersionException<TIdentity>(model.Id, model.Version);

            model.Version++;

            return entity;
        }

        protected override bool ValidateDelete(TEntityModel deleted)
        {
            if (predicateDeletedEntity == null)
                return true;

            return predicateDeletedEntity.Invoke(deleted);
        }

        protected override void RecoveredModel(TEntityModel db, TServiceModel resource)
        {
            resource.Version = db.Version;
        }
    }
}