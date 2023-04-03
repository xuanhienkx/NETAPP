using AutoMapper;
using CS.Common;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Core.Service.Base;
using CS.Core.Service.DomainHandlers.Commands;
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 1.1 Cập nhật mở/đóng tài khoản giao dịch chứng khoán của NĐT
    /// </summary>
    public class OpenOrCloseAccountActionHandler : BaseBusinessActionHandler<CustomerModel>
    {
        public OpenOrCloseAccountActionHandler(IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer<OpenOrCloseAccountActionHandler> localizer,
            ILogger<OpenOrCloseAccountActionHandler> logger) :
            base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer, logger)
        {
        }
        public override string BussinessId => BusinessIdProviderConstant.OpenOrCloseAccount;
        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            var customer = MappingService.Map(bag, () => new CustomerModel());
            // Cập nhật lại trạng thái đóng hoặc mở cho khác hàng khi VSD gửi điện 598 chấp nhận
            await DomainDataHandler.SendCommand(new CustomerStatusUpdateCommand(customer));
            return true;
        }

        public override IDictionary<string, object> ExtendBag(IDictionary<string, object> dictionary, CustomerModel model)
        {
            dictionary.Add("AccountProcessInstruction",
                model.Status == CustomerStatus.PendingClose ? "ACLS" : "AOPN");
            dictionary.Remove(nameof(model.SignatureImage1));
            dictionary.Remove(nameof(model.SignatureImage2));
            dictionary.Remove(nameof(model.Broker));
            dictionary.Remove(nameof(model.Branch));
            dictionary.Remove(nameof(model.Contacts));
            return dictionary;
        }

        public override Task<string> ProcessMessageRejectedReceived(CsBag bag)
        {
            var notes = bag[BusinessIdProviderConstant.RejectionMessage].ToString();
            return Task.FromResult(notes);
        }

        public override bool ExtendValidtion(CustomerModel model)
        {
            switch (model.Status)
            {
                case CustomerStatus.Initial:
                case CustomerStatus.PendingOpen:
                    model.Status = CustomerStatus.PendingOpen;
                    break;
                case CustomerStatus.RequestDeleted:
                case CustomerStatus.PendingClose:
                    model.Status = CustomerStatus.PendingClose;
                    break;
                default:
                    DomainDataHandler.RaiseError(Localizer["VSDPublishFailed_InvalidCustomerStatus"]);
                    return false;
            }
            return true;
        }

        public override async Task UpdateContentStatus(object contentModel, bool isRevertState)
        {
            if (!(contentModel is CustomerModel customer))
                return;

            if (isRevertState)
            {
                customer.Status = customer.Status == CustomerStatus.PendingClose
                    ? CustomerStatus.Open
                    : CustomerStatus.Initial;
            }

            //update customer status
            Logger.LogDebug($"Update Customer status: [{customer.Status}]");
            await DomainDataHandler.SendCommand(new CustomerStatusUpdateCommand(customer));
        }
    }
}
