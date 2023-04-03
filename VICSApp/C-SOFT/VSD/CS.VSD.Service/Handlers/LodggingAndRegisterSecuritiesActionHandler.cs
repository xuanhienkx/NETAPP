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
    /// 1.2.3 Ký gửi chứng khoán đồng thời với đăng ký chứng khoán, ký gửi trái phiếu/tín phiếu chính phủ
    /// </summary>
    public class LodggingAndRegisterSecuritiesActionHandler : BaseOnlyResponseActionHandler
    {
        private readonly IModelMapperService mappingService;
        private readonly IMapper mapper;
        private readonly IDomainDataHandler domainDataHandler;

        public LodggingAndRegisterSecuritiesActionHandler(
            IModelMapperService mappingService,
            IMapper mapper,
            IDomainDataHandler domainDataHandler)
        { 
            this.mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
        }
        public override string BussinessId => BusinessIdProviderConstant.LodggingAndRegisterSecurities;
        
        public override async Task<bool> ProcessMessageReceived(CsBag bag)
        {
            var mode = mappingService.Map(bag, () => new Custody544Model());
            var request = new CustodyRequestModel()
            {
                BusinessId = BussinessId,
                Content = mode.Base64ProtoBufSerialize(),
                ContentClrType = typeof(Custody544Model).FullName,
                Status = CustodyRequestStatus.ResponseInfo 
            };
            await domainDataHandler.SendCommand(
                new AuditHistoryCommand(mapper.Map<CustodyRequestHistory>(request)));
            return true;
        } 
    }
}
