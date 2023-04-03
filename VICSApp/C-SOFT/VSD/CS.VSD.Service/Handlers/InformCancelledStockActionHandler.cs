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
    /// 5.3 Thông báo mã chứng khoán hủy đăng ký
    /// </summary>
    public class InformCancelledStockActionHandler : BaseOnlyResponseActionHandler
    {
        private readonly ILogger<InformCancelledStockActionHandler> logger; 
        private readonly IDomainService<long, AssetModel, Asset> service;
        private readonly IModelMapperService mappingService;

        public override string BussinessId => BusinessIdProviderConstant.InformCancelledStock;
        public string Name => "Thông báo mã chứng khoán hủy đăng ký";

        public InformCancelledStockActionHandler(
            IModelMapperService mappingService,
            IDomainService<long, AssetModel, Asset> service, 
            ILogger<InformCancelledStockActionHandler> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
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

            dbStock.IsActive = false;
            var reuslt = await service.Update(dbStock);
            return reuslt != null;
        } 
    }
}
