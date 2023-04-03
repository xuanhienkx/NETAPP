using CS.Common;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 5.2 Thông báo mã chứng khoán chuyển sàn
    /// </summary>
    public class InformTransferStockBoardActionHandler : BaseOnlyResponseActionHandler
    {
        private readonly ILogger<InformTransferStockBoardActionHandler> logger;
        private readonly IDomainDataHandler domainDataHandler;
        private readonly IDomainService<long, AssetModel, Asset> service;
        private readonly IModelMapperService mappingService;

        public override string BussinessId => BusinessIdProviderConstant.InformTransferStockBoard;

        public InformTransferStockBoardActionHandler(
            IModelMapperService mappingService, 
            IDomainService<long, AssetModel, Asset> service, 
            IDomainDataHandler domainDataHandler,
            ILogger<InformTransferStockBoardActionHandler> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
        }
        public override async Task<bool> ProcessMessageReceived(CsBag bag)
        {
            var asset = mappingService.Map(bag, () => new AssetModel(AssetType.Stock)
            {
                ParValue = 10000,
                Version = 0,
            });
            asset.Code = asset.Code ?? IsinToStockCode.Convert(asset.IsinCode);
            var dbStock = service.Query.Filter(s => s.Code.Equals(asset.Code)).SingleOrDefault(); 
            if (dbStock == null)
            { 
                logger.LogInformation($"Entity not found code {asset.Code}");
                return true;
            }

            dbStock.BoardType = asset.BoardType;
            dbStock.BoardName = asset.BoardName;
            return await service.Update(dbStock)!=null;
        } 
    }
}
