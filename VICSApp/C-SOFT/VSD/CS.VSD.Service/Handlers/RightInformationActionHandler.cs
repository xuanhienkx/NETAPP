using AutoMapper;
using CS.Common;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.Domain.Audit.Entities;
using CS.Domain.Data.Entities;
using System;
using System.Threading.Tasks;

namespace CS.VSD.Service.Handlers
{
    public class RightInformationActionHandler : BaseOnlyResponseActionHandler
    {
        private readonly IDomainDataHandler domainDataHandler;
        private readonly IDomainService<long, RightInformationModel, RightInformation> service;
        private readonly IModelMapperService mappingService;
        private readonly IMapper mapper;

        public RightInformationActionHandler(
            IDomainService<long, RightInformationModel, RightInformation> service,
            IDomainDataHandler domainDataHandler,
            IModelMapperService mappingService, 
            IMapper mapper)
        {
            this.domainDataHandler = domainDataHandler;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
        }

        public override string BussinessId => BusinessIdProviderConstant.RightInformation;                         

        public override async Task<bool> ProcessMessageReceived(CsBag bag)
        {                                                              
            var rightInformation = mappingService.Map(bag, () => new RightInformationModel());
            if (rightInformation != null && rightInformation.IsValid)
            {                                                
                var inserted = await service.Insert(rightInformation);
                var request = new CustodyRequestModel()
                {
                    BusinessId = BussinessId,
                    Content = inserted.Base64ProtoBufSerialize(),
                    Status = CustodyRequestStatus.ResponseInfo,
                    CreatedDate = DateTime.Now,
                    ContentClrType = typeof(RightInformationModel).FullName,
                };
                // clean up all custody request to history,  
                if (inserted != null)
                    await domainDataHandler.SendCommand(new AuditHistoryCommand(mapper.Map<CustodyRequestHistory>(request)));
                return inserted != null;
            }
            return false;
        } 
    }
}