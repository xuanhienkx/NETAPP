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
    /// 1.4 Tất toán tài khoản giao dịch/Chuyển khoản toàn bộ chứng khoán
    /// </summary>
    public class FinalSettlementAccountActionHandler : BaseBusinessActionHandler<Custody598FinalSettAccountModel>
    {
        public FinalSettlementAccountActionHandler(
            IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer<FinalSettlementAccountActionHandler> localizer,
            ILogger<FinalSettlementAccountActionHandler> logger)
            : base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer, logger)
        {
        }

        public override string BussinessId => BusinessIdProviderConstant.FinalSettlementAccount;
        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            // hach toan tat toan tai khoan khi nhan dien 546 
            var model = MappingService.Map(bag, () => new Custody546Model());
            model.Code = model.Code ?? IsinToStockCode.Convert(model.IsinCode);

            //Todo: when core implement process will be Move to hystory
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
            //Todo: when core implement process will be return true 
        }

        public override Task<string> ProcessMessageRejectedReceived(CsBag bag)
        {
            var model = MappingService.Map(bag, () => new Custody548Model());
            var errorMessage = $"Status:{model.Status} ErrorCode:{model.ReasionCode} Error:{model.ErrorMessage}";
            return Task.FromResult(errorMessage);
        } 
         
    }
}
