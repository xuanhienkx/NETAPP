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
    /// 1.2.1 Ký gửi chứng khoán thông thường (có yêu cầu từ TVLK)
    /// </summary>
    public class CustodySecuritiesActionHandler : BaseBusinessActionHandler<CustodySecurityModel>
    {
        public CustodySecuritiesActionHandler(
            IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer<CustodySecuritiesActionHandler> localizer,
            ILogger<CustodySecuritiesActionHandler> logger) :
            base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer, logger)
        {
        }
        public override string BussinessId => BusinessIdProviderConstant.CustodySecurities;
        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            // Hach toan chung khoan cho nghiep vu lu ky chung khoan 544
            var model = MappingService.Map(bag, () => new Custody544Model());
            model.Code = model.Code ?? IsinToStockCode.Convert(model.IsinCode);

            var request = new CustodyRequestModel()
            {
                CreatedDate = DateTime.Now,
                ContentClrType = typeof(Custody544Model).FullName,
                BusinessId = BussinessId,
                Content = model.Base64ProtoBufSerialize(),
                RequestType = CustodyRequestType.Response,
                Status = CustodyRequestStatus.ResponseInfo,
            };
            await DomainDataHandler.SendCommand(
                new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));
             
            //Todo: when core implement process will be return true
            return false;
        }

        public override Task<string> ProcessMessageRejectedReceived(CsBag bag)
        {
            var model = MappingService.Map(bag, () => new Custody548Model());
            var errorMessage = $"Status:{model.Status} ErrorCode:{model.ReasionCode} Error:{model.ErrorMessage}";
            return Task.FromResult(errorMessage);
        }

    }

}
