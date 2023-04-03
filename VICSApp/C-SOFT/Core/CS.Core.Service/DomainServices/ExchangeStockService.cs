using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;

namespace CS.Core.Service.DomainServices
{
    public class ExchangeStockService : CommonServiceBase<long, ExchangeStockModel, ExchangeStock>
    {
        protected ExchangeStockService(IDataFactory dataFactory, ICacheService cacheService) : base(dataFactory, cacheService)
        {
        }

        protected override bool UseCache => throw new System.NotImplementedException();

        protected override bool ValidateDelete(ExchangeStock deletedEntity)
        {
            return true;
        }

        protected override bool ValidateInsert(ExchangeStockModel model)
        {
            return true;
        }

        protected override bool ValidateUpdate(ExchangeStockModel model)
        {
            return true;
        }
    }
}