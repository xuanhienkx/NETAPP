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
    /// 1.2.4 Ký gửi chứng khoán phát hành thêm từ quyền
    /// </summary>
    public class LoggingAdditionalSecuritiesActionHandler : Custody598ConfirmActionHandler
    {
        public override string BussinessId => BusinessIdProviderConstant.LoggingAdditionalSecurities;
        public string Name => "Ký gửi chứng khoán phát hành thêm từ quyền"; 

        public LoggingAdditionalSecuritiesActionHandler(IValidationService validationService, ICustomerRepository customerRepository, IDomainService<long, CustodyRequestModel, CustodyRequest> service, IModelMapperService mappingService, IDomainService<long, FileActModel, FileAct> fileActService, IDomainDataHandler domainDataHandler, IMapper mapper, IStringLocalizer<LoggingAdditionalSecuritiesActionHandler> localizer, ILogger<LoggingAdditionalSecuritiesActionHandler> logger) : base(validationService, customerRepository, service, mappingService, fileActService, domainDataHandler, mapper, localizer, logger)
        {
        }

        public override ReportType ReportType => ReportType.Info;
    }
}
