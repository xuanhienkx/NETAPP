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
    /// 2.4 Đăng ký đặt mua
    /// </summary>
    public class RegisterRightToBuyAdditionalStockActionHandler : BaseBusinessActionHandler<Custody565Model>
    {
        public RegisterRightToBuyAdditionalStockActionHandler(
            IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer<RegisterRightToBuyAdditionalStockActionHandler> localizer,
            ILogger<RegisterRightToBuyAdditionalStockActionHandler> logger)
            : base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer, logger)
        {
        }
        public override string BussinessId => BusinessIdProviderConstant.RegisterRightToBuyAdditionalStock;
        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            // hach toan tat toan tai khoan khi nhan dien 546 
            var model = MappingService.Map(bag, () => new Custody566Model());
            bag.TryGet("IsinCode", out string isIncode);
            model.Code = model.Code ?? IsinToStockCode.Convert(isIncode);

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
            return Task.FromResult(string.Empty);
        }
    }
}
