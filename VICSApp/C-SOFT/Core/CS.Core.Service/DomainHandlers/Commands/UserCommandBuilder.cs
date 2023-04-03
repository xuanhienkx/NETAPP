using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Core.Service.Base;
using CS.Core.Service.Validators;
using MediatR;
using System;

namespace CS.Core.Service.DomainHandlers.Commands
{
    public class UserCommandBuilder : CommandBuilder<Guid, UserModel>
    {
        public UserCommandBuilder(ICSoftDataContext dataContext)
            : base(dataContext)
        {
        }

        public override IRequest<UserModel> BuildInsert(UserModel model)
        {
            return BuildCommand(dataContext => new ActionCommand<UserModel>(model, ActionType.Insert, new UserInsertValidator(dataContext)));
        }

        public override IRequest<UserModel> BuildUpdate(UserModel model)
        {
            return BuildCommand(dataContext => new ActionCommand<UserModel>(model, ActionType.Update, new UserInsertValidator(dataContext)));
        }

        public override IRequest<bool> BuildDelete(Guid id)
        {
            return new DeleteActionCommand<UserModel, Guid>(id);
        }
    }
}
