using AutoMapper;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Core.Service.Base;
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 3.1 Xác nhận/Hủy xác nhận kết quả giao dịch
    /// </summary>
    public class TradingResultConfirmationActionHandler : Custody598ConfirmActionHandler
    {
        public TradingResultConfirmationActionHandler(
            IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainService<long, FileActModel, FileAct> fileActService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer<TradingResultConfirmationActionHandler> localizer, 
            ILogger<TradingResultConfirmationActionHandler> logger) 
            : base(validationService, customerRepository, service,
            mappingService, fileActService, domainDataHandler, mapper, localizer, logger)
        {
        }

        public override string BussinessId => BusinessIdProviderConstant.TradingResultConfirmation;
        public override ReportType ReportType => ReportType.Confirm;
    }
}
