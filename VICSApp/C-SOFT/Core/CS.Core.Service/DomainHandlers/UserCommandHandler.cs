using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Core.Service.Base;
using CS.Core.Service.DomainHandlers.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Core.Service.DomainHandlers
{
    public class UserCommandHandler : ActionCommandHandler<UserModel, Guid>,
                                      IRequestHandler<UserUpdateStatusCommand, bool>
    {
        private readonly IUserIdentityService userIdentityService;
        private readonly IUserRepository repository;

        public UserCommandHandler(
            IValidationService validationService,
            IUserRepository repository,
            ICacheService cacheService,
            IUserIdentityService userIdentityService)
            : base(validationService, cacheService)
        {
            this.userIdentityService = userIdentityService ?? throw new ArgumentNullException(nameof(userIdentityService));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public override bool UseCache => true;

        public async Task<bool> Handle(UserUpdateStatusCommand message, CancellationToken cancellationToken)
        {
            if (!ValidationService.Validate(message))
                return false;

            if (message.IsActive == false)
            {
                try
                {
                    var resultDel = await repository.Delete(message.Id, true);
                    if (resultDel)
                    {
                        await userIdentityService.Delete(message.Id);
                    }
                    return resultDel;
                }
                catch // khong xoa duoc update lai trang thai 
                {
                    var result = await repository.UpdateStatus(message.Id, message.IsActive);
                    if (result)
                        await userIdentityService.LockoutUser(message.Id, !message.IsActive);
                    return result;
                }
            }
            else
            {
                var result = await repository.UpdateStatus(message.Id, message.IsActive);
                if (result)
                    await userIdentityService.LockoutUser(message.Id, !message.IsActive);
                return result;
            }

        }

        protected override async Task<bool> Delete(Guid id)
        {
            var result = await repository.Delete(id, false);
            if (result)
            {
                await userIdentityService.Delete(id);
            }
            else
            {
                result = await repository.UpdateStatus(id, false);
                await userIdentityService.LockoutUser(id);
            }

            return result;
        }

        protected override async Task<UserModel> Update(UserModel model)
        {
            var user = await repository.Update(model);
            var userLogin = await userIdentityService.GetUserNameById(user.Id);
            if (userLogin == null)
                await userIdentityService.CreateUser(user);
            else
                await userIdentityService.LockoutUser(model.Id, !model.IsActive);

            return user;
        }

        protected override async Task<UserModel> Insert(UserModel model)
        {
            var user = await repository.Insert(model);
            if (user != null && user.Id != Guid.Empty)
                await userIdentityService.CreateUser(user);
            return user;
        }
    }
}