using AutoMapper;
using CS.Common;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.Core.Service.Base;
using CS.Domain.Audit.Entities;
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 1.3 Chuyển khoản chứng khoán
    /// </summary>
    public class TransferSecuritiesActionHandler : BaseBusinessActionHandler<Custody542TranferModel>
    {
        public TransferSecuritiesActionHandler(
            IValidationService validationService, 
            ICustomerRepository customerRepository, 
            IDomainService<long, CustodyRequestModel, CustodyRequest> service, 
            IModelMapperService mappingService, 
            IDomainDataHandler domainDataHandler, 
            IMapper mapper, 
            IStringLocalizer<TransferSecuritiesActionHandler> localizer, 
            ILogger<TransferSecuritiesActionHandler> logger) 
            : base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer, logger)
        {
        }

        public override string BussinessId => BusinessIdProviderConstant.TransferSecurities;
        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            // Hach toan chung khoan cho nghiep vu chuyen chung khoan 546
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
                Status = CustodyRequestStatus.ResponseInfo,
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
