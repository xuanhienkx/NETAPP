using CS.Common;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.Domain.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 5.1 Thông báo mã chứng khoán đăng ký mới
    /// </summary>
    public class InformNewRegistedStockActionHandler : BaseOnlyResponseActionHandler
    {
        private readonly ILogger<InformNewRegistedStockActionHandler> logger; 
        private readonly IDomainService<long, AssetModel, Asset> service;
        private readonly IModelMapperService mappingService;

        public InformNewRegistedStockActionHandler(
            IDomainService<long, AssetModel, Asset> service,
            IModelMapperService mappingService, 
            ILogger<InformNewRegistedStockActionHandler> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            this.mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public override string BussinessId => BusinessIdProviderConstant.InformNewRegistedStock;

        public override async Task<bool> ProcessMessageReceived(CsBag bag)
        {
            var asset = mappingService.Map(bag, () => new AssetModel(AssetType.Stock)
            {
                ParValue = 10000,
                Version = 0,
                IsActive = true
            });

            var exited = await service.Query.FilterAsync(x => x.Code.Equals(asset.Code));
            if (exited.Any())
            {
                logger.LogInformation($"Stock ready existed  {asset.Code}");
                return true;
            }
            asset.BoardName = asset.BoardName ?? asset.BoardType.ToString();
            asset.NameLocal = asset.Name;
            asset.Name = asset.Name.ConvertToUnSign();
            asset.Code = asset.Code ?? IsinToStockCode.Convert(asset.IsinCode);
            var result = await service.Insert(asset);
            return result != null;
        }
    }
}
