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
    public class CustomerCommandBuilder : CommandBuilder<Guid, CustomerModel>
    {
        public CustomerCommandBuilder(ICSoftDataContext dataContext)
            : base(dataContext)
        {}

        public override IRequest<CustomerModel> BuildInsert(CustomerModel model)
        {
            return BuildCommand(dataContext => new ActionCommand<CustomerModel>(model, ActionType.Insert, new CustomerInsertValidator(dataContext)));
        }

        public override IRequest<CustomerModel> BuildUpdate(CustomerModel model)
        {
            return BuildCommand(dataContext => new ActionCommand<CustomerModel>(model, ActionType.Update, new CustomerInsertValidator(dataContext)));
        }

        public override IRequest<bool> BuildDelete(Guid id)
        {
            return new DeleteActionCommand<CustomerModel, Guid>(id);
        }
    }
}
