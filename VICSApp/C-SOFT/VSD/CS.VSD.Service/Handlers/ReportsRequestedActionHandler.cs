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
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 4 Tra xuất báo cáo nghiệp vụ
    /// </summary>
    public class ReportsRequestedActionHandler : BaseBusinessActionHandler<IReportRequest>
    {

        public ReportsRequestedActionHandler(
            IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer<ReportsRequestedActionHandler> localizer,
            ILogger<ReportsRequestedActionHandler> logger) :
            base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer, logger)
        {
        }
        public override string BussinessId => BusinessIdProviderConstant.ReportsRequested;
        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            if (!bag.TryGet(BusinessIdProviderConstant.ReportCode, out string reportType) || string.IsNullOrEmpty(reportType))
                throw new InvalidDataException("Cannot find the report code");

            var model = MappingService.Map(bag, () => new FileActModel());
            var contenet = model.Base64ProtoBufSerialize();
            // create custody request
            var respose = new CustodyRequestModel()
            {
                CreatedDate = DateTime.Now,
                ContentClrType = model.GetType().FullName,
                BusinessId = BussinessId,
                Content = contenet,
                RequestType = CustodyRequestType.Response,
                Status = CustodyRequestStatus.ResponseReportInfo,
            };

            await Service.Insert(respose);
            return true;
        }

        public override Task<string> ProcessMessageRejectedReceived(CsBag bag)
        {
            throw new NotImplementedException();
        }

        public string Name => "Tra xuất báo cáo nghiệp vụ";
        public override IDictionary<string, object> ExtendBag(IDictionary<string, object> dictionary, IReportRequest model)
        {
            if (dictionary.TryGetValue("BoardType", out object type))
            {
                dictionary["BoardType"] = $"{(long)type:D3}";
            }
            dictionary.Add("SubMessageType", SubMessageType.ReportsRequested);
            dictionary.Add(BusinessIdProviderConstant.ReportSetParam, true);
            return base.ExtendBag(dictionary, model);
        }
    }
}
