using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Exceptions;
using CS.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS.Domain.Data.Repositories
{
    public class UserSqlRepository : RepositoryBase<Guid, UserModel, User>, IUserRepository
    {
        public UserSqlRepository(CSoftDataContext dataContext, IMapper mapper)
            : base(dataContext, mapper)
        {
        }

        protected override User StartPreparingForInsert(UserModel model)
        {
            model.CreatedDate = DateTime.Now;
            return new User
            {
                Id = Guid.NewGuid(),
                IsActive = true
            };
        }

        protected override User StartPreparingForUpdate(UserModel userModel)
        {
            userModel.ModifiedDate = DateTime.UtcNow;

            var userEntity = DataContext.Set<User>()
                .FirstOrDefault(x => x.Id == userModel.Id);

            if (userEntity == null)
                throw new EntityNotFoundException<UserModel>(userModel);
            if (userEntity.Version != userModel.Version)
                throw new EntityNotSameVersionException<UserModel>(userModel, userModel.Version);

            userEntity.BranchId = userModel.Branch.Id;
            userEntity.ModifiedByUserId = userModel.ModifiedBy?.Id;
            userEntity.ModifiedDate = userModel.ModifiedDate;
            userEntity.Version = userModel.Version + 1;

            return userEntity;
        }

        public async Task<bool> UpdateStatus(Guid id, bool isActive)
        {
            var userEntity = DataContext.Set<User>()
                .SingleOrDefault(x => x.Id == id);

            if (userEntity == null)
                throw new EntityNotFoundException<Guid>(id);

            userEntity.IsActive = isActive;
            userEntity.Version += 1;
            userEntity.ModifiedDate = DateTime.Now;

            DataContext.Set<User>().Update(userEntity);
            return await DataContext.SaveChangesAsync() > 0;
        }

        protected override void RecoveredModel(User db, UserModel resource)
        {
            resource.Version = db.Version;
            resource.Branch = Mapper.Map<BranchModel>(Get<Branch, long>(db.BranchId));
            resource.Department =
                Mapper.Map<DepartmentModel>(Get<Department, long>(db.DepartmentId.GetValueOrDefault()));
        }
    }
}