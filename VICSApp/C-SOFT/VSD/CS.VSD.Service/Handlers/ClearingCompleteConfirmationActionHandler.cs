using AutoMapper;
using CS.Common;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Audit.Entities;
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
    /// 3.3 Thông báo về việc thanh toán hoàn tất với TVLK
    /// </summary>
    public class ClearingCompleteConfirmationActionHandler : BaseOnlyResponseActionHandler
    {
        private readonly IMapper mapper;
        private readonly IModelMapperService mappingService;
        private readonly IDomainDataHandler domainDataHandler;

        public ClearingCompleteConfirmationActionHandler(
            IModelMapperService mappingService,
            IMapper mapper,
            IDomainDataHandler domainDataHandler)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
        }
        public override string BussinessId => BusinessIdProviderConstant.ClearingCompleteConfirmation;
        public override async Task<bool> ProcessMessageReceived(CsBag bag)
        {
            var mode = mappingService.Map(bag, () => new ClearingCompleteConfirmationModel());
            var request = new CustodyRequestModel()
            {
                BusinessId = BussinessId,
                Content = mode.Base64ProtoBufSerialize(),
                ContentClrType = typeof(ClearingCompleteConfirmationModel).FullName,
                Status = CustodyRequestStatus.ResponseInfo,
                Notes = mode.Content
            };
            await domainDataHandler.SendCommand(
                new AuditHistoryCommand(mapper.Map<CustodyRequestHistory>(request)));
            return true;
        }
    }
}
