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
    /// 3.2 Thông báo tổng hợp kết quả bù trừ và thông báo điều chỉnh kết quả bù trừ
    /// </summary>
    public class ClearingAndSettlementConfirmationActionHandler : Custody598ConfirmActionHandler
    {
        public override string BussinessId => BusinessIdProviderConstant.ClearingAndSettlementConfirmation;

        public ClearingAndSettlementConfirmationActionHandler(
            IValidationService validationService, 
            ICustomerRepository customerRepository, 
            IDomainService<long, CustodyRequestModel, CustodyRequest> service, 
            IModelMapperService mappingService, 
            IDomainService<long, FileActModel, FileAct> fileActService, 
            IDomainDataHandler domainDataHandler, 
            IMapper mapper, 
            IStringLocalizer<ClearingAndSettlementConfirmationActionHandler> localizer, 
            ILogger<ClearingAndSettlementConfirmationActionHandler> logger) 
            : base(validationService, customerRepository, service, mappingService, fileActService, domainDataHandler, mapper, localizer, logger)
        {
        }

        public override ReportType ReportType => ReportType.Info;
    }
}
