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
    /// 1.6 Thông báo điều chỉnh thông tin về loại chứng khoán (phổ thông, hạn chế chuyển nhượng)
    /// </summary>
    public class RevisingSecuritiesInfomationActionHandler : BaseOnlyResponseActionHandler
    {
        private readonly IModelMapperService mappingService;
        private readonly IMapper mapper;
        private readonly IDomainDataHandler domainDataHandler;

        public RevisingSecuritiesInfomationActionHandler(IModelMapperService mappingService,
            IMapper mapper,
            IDomainDataHandler domainDataHandler)
        {
            this.mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
        }
        public override string BussinessId => BusinessIdProviderConstant.RevisingSecuritiesInfomation;
        public override async Task<bool> ProcessMessageReceived(CsBag bag)
        {
            var mode = mappingService.Map(bag, () => new Custody508Model());
            var request = new CustodyRequestModel()
            {
                BusinessId = BussinessId,
                Content = mode.Base64ProtoBufSerialize(),
                ContentClrType = typeof(Custody508Model).FullName,
                Status = CustodyRequestStatus.ResponseInfo, 
            };
            await domainDataHandler.SendCommand(
                new AuditHistoryCommand(mapper.Map<CustodyRequestHistory>(request)));
            return true;
        }
    }
}
