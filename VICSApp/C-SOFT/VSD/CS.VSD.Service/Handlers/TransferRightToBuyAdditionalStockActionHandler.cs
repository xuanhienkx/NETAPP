using AutoMapper;
using CS.Common;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Core.Service.Base;
using CS.Domain.Audit.Entities;
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std;
using CS.Common.Std.Extensions;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 2.3 Chuyển nhượng quyền mua
    /// </summary>
    public class TransferRightToBuyAdditionalStockActionHandler : BaseBusinessActionHandler<Custody542TranferModel>
    {
        public TransferRightToBuyAdditionalStockActionHandler(
            IValidationService validationService, 
            ICustomerRepository customerRepository, 
            IDomainService<long, CustodyRequestModel, CustodyRequest> service, 
            IModelMapperService mappingService, 
            IDomainDataHandler domainDataHandler, 
            IMapper mapper, 
            IStringLocalizer<TransferRightToBuyAdditionalStockActionHandler> localizer, 
            ILogger<TransferRightToBuyAdditionalStockActionHandler> logger) 
            : base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer, logger)
        {
        }
        public override string BussinessId => BusinessIdProviderConstant.TransferRightToBuyAdditionalStock;
        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            // Hoach toan nghiep chuyen nhung quyen mua khi nhan dien 546  
            var model = MappingService.Map(bag, () => new Custody546Model());
            model.Code = model.Code ?? IsinToStockCode.Convert(model.IsinCode);
            //Move to hystory
            var request = new CustodyRequestModel()
            {
                CreatedDate = DateTime.Now,
                ContentClrType = typeof(Custody546Model).FullName,
                BusinessId = BussinessId,
                Content = model.Base64ProtoBufSerialize(),
                RequestType = CustodyRequestType.Response,
                Status = CustodyRequestStatus.PendingProcess,
            };


            await DomainDataHandler.SendCommand(
                new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));

            return false;
        }

        public override async Task<string> ProcessMessageRejectedReceived(CsBag bag)
        {
            var model = MappingService.Map(bag, () => new Custody548Model());
            var errorMessage = $"Status:{model.Status} ErrorCode:{model.ReasionCode} Error:{model.ErrorMessage}";
            //Move to hystory
            var request = new CustodyRequest()
            {
                CreatedDate = DateTime.Now,
                ContentClrType = typeof(Custody548Model).FullName,
                BusinessId = BussinessId,
                Content = model.Base64ProtoBufSerialize(),
                RequestType = CustodyRequestType.Response,
                Status = CustodyRequestStatus.PendingProcess,
                Notes = errorMessage
            };
            await DomainDataHandler.SendCommand(new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));
            return errorMessage;
        }


       
    }
}
