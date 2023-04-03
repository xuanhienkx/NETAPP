using AutoMapper;
using CS.Common;
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
using System;
using System.IO;
using System.Threading.Tasks;

namespace CS.VSD.Service.Handlers
{
    public abstract class Custody598ConfirmActionHandler : BaseBusinessActionHandler<Custody598Confirm>
    {
        private readonly IDomainService<long, FileActModel, FileAct> fileActService; 
        protected Custody598ConfirmActionHandler(
            IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainService<long, FileActModel, FileAct> fileActService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer localizer,
            ILogger<Custody598ConfirmActionHandler> logger )
            : base(validationService, customerRepository, service, mappingService, domainDataHandler, mapper, localizer,
                logger)
        { 
            this.fileActService = fileActService ?? throw new ArgumentNullException(nameof(fileActService));
        }

        public abstract ReportType ReportType { get; }

        public override async Task<bool> ProcessMessageApprovedReceived(CsBag bag)
        {
            if (!bag.TryGet(BusinessIdProviderConstant.ReportCode, out string reportType) ||
                string.IsNullOrEmpty(reportType))
                throw new InvalidDataException("Cannot find the report code");

            var model = MappingService.Map(bag, () => new FileActModel());
            model.ReportType = ReportType;
            model.ReportStatus = ReportStatus.Receive;
            model.BusinessId = BussinessId;
            await fileActService.Insert(model);
            return true;
        }

        public override Task<string> ProcessMessageRejectedReceived(CsBag bag)
        {
            return Task.FromResult(string.Empty);
        }

        public override Task ProcessExtentInformed(CustodyRequestModel request, Custody598Confirm model)
        {
            if (request.Status == CustodyRequestStatus.PendingProcess)
            {
                fileActService.UpdateSpecific(model.FileActId, act => act.ReportStatus = ReportStatus.Confirmed);
            }
            else 
            {
                fileActService.UpdateSpecific(model.FileActId, act => act.ReportStatus = ReportStatus.RequestConfirm);
            }
            //Delete if right is expired date
            //Todo: Implement later
            /* var fileAct = await fileActService.Query.FilterAsync(x => x.LogicalName == model.LogicalName && x.ReportCode == model.ReportCode);
             if (fileAct.Any())
                 await fileActService.Delete(fileAct.Single().Id, true);

             request.Status = CustodyRequestStatus.Finished;
             await DomainDataHandler.SendCommand(
                 new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));
             await Service.Delete(request.Id, true);*/
            return Task.CompletedTask;

        } 
    }
}