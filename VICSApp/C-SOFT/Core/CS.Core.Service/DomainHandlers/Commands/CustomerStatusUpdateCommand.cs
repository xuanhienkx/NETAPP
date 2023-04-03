using CS.Common.Contract.Models;
using MediatR;

namespace CS.Core.Service.DomainHandlers.Commands
{
    public class CustomerStatusUpdateCommand : IRequest<CustomerModel>
    {
        public CustomerModel Model { get; }

        public CustomerStatusUpdateCommand(CustomerModel customer)
        {
            Model = customer;
        }
    }
}