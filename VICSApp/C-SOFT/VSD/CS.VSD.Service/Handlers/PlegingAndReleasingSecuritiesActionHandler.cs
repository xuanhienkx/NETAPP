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
    /// 1.5 Phong tỏa và giải tỏa chứng khoán
    /// </summary>
    public class PlegingAndReleasingSecuritiesActionHandler : BaseBusinessActionHandler<Custody524Model>
    {
        public PlegingAndReleasingSecuritiesActionHandler(
            IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer<PlegingAndReleasingSecuritiesActionHandler> localizer,
            ILogger<PlegingAndReleasingSecuritiesActionHandler> logger)
            : base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer, logger)
        {
        }
        public override string BussinessId => BusinessIdProviderConstant.PlegingAndReleasingSecurities;
        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            // hoac toan nghiep phong toả giải toản chung khoan khi nhan dien 508
            var model = MappingService.Map(bag, () => new Custody508Model());
            model.Code = model.Code ?? IsinToStockCode.Convert(model.IsinCode);
            //Todo: when core implement process will be Move to hystory
            //Move to hystory
            var request = new CustodyRequestModel()
            {
                CreatedDate = DateTime.Now,
                ContentClrType = typeof(Custody508Model).FullName,
                BusinessId = BussinessId,
                Content = model.Base64ProtoBufSerialize(),
                RequestType = CustodyRequestType.Response,
                Status = CustodyRequestStatus.ResponseInfo,
            };
            await DomainDataHandler.SendCommand(
                new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));

            //throw new BusinessPendingApprovalException<Custody508Model>(BussinessId);
            //Todo: when core implement process will be return true
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
