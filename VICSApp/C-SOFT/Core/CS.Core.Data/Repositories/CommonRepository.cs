using System;
using System.Linq;
using AutoMapper;
using CS.Common.Contract;
using CS.Common.Domain.Interfaces;
using CS.Common.Exceptions;

namespace CS.Domain.Data.Repositories
{
    public class CommonRepository<TIdentity, TServiceModel, TEntityModel> : RepositoryBase<TIdentity, TServiceModel, TEntityModel>
        where TServiceModel : ICommonResource<TIdentity>
        where TEntityModel : class, ICommonEntity<TIdentity>, new()
    {
        private readonly Func<TEntityModel, bool> predicateDeletedEntity;

        public CommonRepository(CSoftDataContext dataContext, IMapper mapper, Func<TEntityModel, bool> predicateDeletedEntity)
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
            // do nothing
        }
    }
}
