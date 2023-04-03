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
    public class SecuritiesReceverTransferActionHandler : BaseOnlyResponseActionHandler
    {
        private readonly IDomainDataHandler domainDataHandler;
        private readonly IModelMapperService mappingService;

        public SecuritiesReceverTransferActionHandler(IDomainDataHandler domainDataHandler, IModelMapperService mappingService)
        {
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
            this.mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
        }
        public override string BussinessId => BusinessIdProviderConstant.SecuritiesReceverTransfer;
        public override async Task<bool> ProcessMessageReceived(CsBag bag)
        {
            // Hach toan so du chung khoan khi nhan dien chuyen chung khoan 
            var model = mappingService.Map(bag, () => new Custody544Model());
            model.Code = model.Code ?? IsinToStockCode.Convert(model.IsinCode);

            //Todo: when core implement process will be Move to history
            var request = new CustodyRequestModel()
            {
                CreatedDate = DateTime.Now,
                ContentClrType = typeof(Custody544Model).FullName,
                BusinessId = BussinessId,
                Content = model.Base64ProtoBufSerialize(),
                RequestType = CustodyRequestType.Response,
                Status = CustodyRequestStatus.ResponseInfo,
            };
            await domainDataHandler.SendCommand(new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));
             
            return true;
        }
    }
}