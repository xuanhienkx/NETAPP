using CS.Common;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 5.4: Thông báo mã đợt đăng ký bổ sung (Tăng vốn /phát hành)
    /// </summary>
    public class InformIssuingProcedureActionHandler : BaseOnlyResponseActionHandler
    { 
        private readonly IDomainService<long, AssetModel, Asset> service;
        private readonly ILogger<InformIssuingProcedureActionHandler> logger;
        private readonly IModelMapperService mappingService;

        public InformIssuingProcedureActionHandler(
            IModelMapperService mappingService,
            IDomainService<long, AssetModel, Asset> service,  
            ILogger<InformIssuingProcedureActionHandler> logger)
        { 
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
        }

        public override string BussinessId => BusinessIdProviderConstant.InformIssuingProcedure;
        public string Name => "Thông báo mã đợt đăng ký bổ sung (phát hành)";

        public override async Task<bool> ProcessMessageReceived(CsBag bag)
        {
            var asset = mappingService.Map(bag, () => new AssetModel(AssetType.Stock)
            {
                ParValue = 10000,
                Version = 0,
                IsActive = true
            });

            asset.Code = asset.Code ?? IsinToStockCode.Convert(asset.IsinCode); 
            var dbStock = service.Query.Filter(s => s.Code.Equals(asset.Code)).SingleOrDefault(); 
            
            if (dbStock == null)
            {
                logger.LogInformation($"Entity not found code {asset.Code}");
                return true;
            } 
            dbStock.TotalIssue = dbStock.TotalIssue + asset.TotalIssue;
            dbStock.TradeDate = asset.TradeDate;
            var result = await service.Update(dbStock);
            return result != null;
        } 
    }
}
