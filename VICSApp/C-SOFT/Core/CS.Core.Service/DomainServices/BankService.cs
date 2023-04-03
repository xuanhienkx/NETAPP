using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;

namespace CS.Core.Service.DomainServices
{
    public class BankService : CommonServiceBase<long, BankModel, Bank>
    {
        public BankService(IDataFactory dataFactory, ICacheService cacheService) : base(dataFactory, cacheService)
        {
        }

        protected override bool ValidateDelete(Bank deletedEntity)
        {
            return true;
        }

        protected override bool ValidateInsert(BankModel model)
        {
            return true;
        }

        protected override bool ValidateUpdate(BankModel model)
        {
            return true;
        }
        protected override bool UseCache => true;
    }
}