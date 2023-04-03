using System;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Core.Service.Base;
using CS.Core.Service.Validators;
using MediatR;

namespace CS.Core.Service.DomainHandlers.Commands
{
    public class GroupCommandBuilder : CommandBuilder<Guid, GroupModel>
    {
        public GroupCommandBuilder(ICSoftDataContext dataContext)
            : base(dataContext)
        { }

        public override IRequest<GroupModel> BuildInsert(GroupModel model)
        {
            return BuildCommand(dataContext => new ActionCommand<GroupModel>(model, ActionType.Insert, new GroupInsertValidator(dataContext)));
        }

        public override IRequest<GroupModel> BuildUpdate(GroupModel model)
        {
            return BuildCommand(dataContext => new ActionCommand<GroupModel>(model, ActionType.Update, new GroupUpdateValidator(dataContext)));
        }

        public override IRequest<bool> BuildDelete(Guid id)
        {
            return new DeleteActionCommand<GroupModel, Guid>(id);
        }
    }
}