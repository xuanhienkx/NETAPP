using AutoMapper;
using CS.Common;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Core.Service.Base;
using CS.Core.Service.DomainHandlers.Commands;
using CS.Domain.Audit.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Core.Service.DomainHandlers
{
    public class CustomerCommandHandler : ActionCommandHandler<CustomerModel, Guid>, IRequestHandler<CustomerStatusUpdateCommand, CustomerModel>
    {
        private readonly IMapper mapper;
        private readonly IDomainDataHandler domainDataHandler;
        private readonly IUserIdentityService userIdentityService;
        private readonly ICustomerRepository repository;

        public CustomerCommandHandler(
            ICustomerRepository repository,
            IValidationService validationService,
            IDomainDataHandler domainDataHandler,
            IUserIdentityService userIdentityService,
            ICacheService cacheService,
            IMapper mapper)
            : base(validationService, cacheService)
        {
            this.mapper = mapper;
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
            this.userIdentityService = userIdentityService ?? throw new ArgumentNullException(nameof(userIdentityService));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public override bool UseCache => true;

        public async Task<CustomerModel> Handle(CustomerStatusUpdateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidationService.Validate(message))
                return message.Model;

            var updated = await repository.UpdateStatus(message.Model.CustomerNumber, message.Model.Status, message.Model.Notes);
            var auditEntity = mapper.Map<CustomerAudit>(updated);

            // if this is deleted, lockout the login user
            if (message.Model.Status == CustomerStatus.RequestDeleted)
            {
                await userIdentityService.LockoutUser(message.Model.Id);
                auditEntity.AuditType = CustomerAuditType.Closed;
            }
            else
                auditEntity.AuditType = CustomerAuditType.Modifiled;

            await domainDataHandler.SendCommand(new AuditEventCommand(auditEntity));

            return updated;
        }

        protected override async Task<bool> Delete(Guid id)
        {
            var model = await Handle(new CustomerStatusUpdateCommand(new CustomerModel()
            {
                Id = id,
                Status = CustomerStatus.RequestDeleted
            }), CancellationToken.None);
            return model != null;
        }

        protected override async Task<CustomerModel> Update(CustomerModel model)
        {
            model.ModifiedBy = domainDataHandler.GetUserLogin();
            model.ModifiedDate = DateTime.UtcNow;
            
            var updated = await repository.Update(model);

            var auditEntity = mapper.Map<CustomerAudit>(updated);
            auditEntity.AuditType = CustomerAuditType.Modifiled;

            await domainDataHandler.SendCommand(new AuditEventCommand(auditEntity));

            return updated;
        }

        protected override async Task<CustomerModel> Insert(CustomerModel model)
        {
            model.CreatedBy = domainDataHandler.GetUserLogin();
            model.CreatedDate = DateTime.UtcNow;

            // create new customer
            var customer = await repository.Insert(model);

            // generate the account number
            if (string.IsNullOrEmpty(customer.CustomerNumber))
                customer.CustomerNumber = await repository.GenerateCustomerAccount(customer);

            var auditEntity = mapper.Map<CustomerAudit>(customer);
            auditEntity.AuditType = CustomerAuditType.Created;

            await domainDataHandler.SendCommand(new AuditEventCommand(auditEntity));
            return customer;
        }
    }
}
