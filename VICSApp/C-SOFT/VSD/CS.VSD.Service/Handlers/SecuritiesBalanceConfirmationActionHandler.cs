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
    /// 1.8 Xác nhận/hủy xác nhận số dư chứng khoán
    /// </summary>
    public class SecuritiesBalanceConfirmationActionHandler : Custody598ConfirmActionHandler
    {  
        public override string BussinessId => BusinessIdProviderConstant.SecuritiesBalanceConfirmation; 
        public SecuritiesBalanceConfirmationActionHandler(
            IValidationService validationService, 
            ICustomerRepository customerRepository, 
            IDomainService<long, CustodyRequestModel, CustodyRequest> service, 
            IModelMapperService mappingService, 
            IDomainService<long, FileActModel, FileAct> fileActService, 
            IDomainDataHandler domainDataHandler, 
            IMapper mapper, 
            IStringLocalizer<SecuritiesBalanceConfirmationActionHandler> localizer, 
            ILogger<SecuritiesBalanceConfirmationActionHandler> logger) 
            : base(validationService, customerRepository, service, mappingService, fileActService, domainDataHandler, mapper, localizer, logger)
        {
        }

        public override ReportType ReportType => ReportType.Confirm;
    }
}
