using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;
using System;
using System.Linq;

namespace CS.Core.Service.DomainServices
{
    public class AssetService : CommonServiceBase<long, AssetModel, Asset>
    {
        private readonly IDomainDataHandler domainDataHandler;

        public AssetService(IDataFactory dataFactory, IDomainDataHandler domainDataHandler, ICacheService cacheService)
            : base(dataFactory, cacheService)
        {
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
        }

        protected override bool ValidateInsert(AssetModel model)
        {
            var exitedCode = Query.Queryable().Any(b => b.Code.Equals(model.Code));
            if (!exitedCode) return true;

            domainDataHandler.RaiseError($"BranchCode {model.Code} existed in system.");
            return false;
        }

        protected override bool ValidateUpdate(AssetModel model)
        {
            var exitedCode = Query.Queryable().Any(b => b.Code.Equals(model.Code) && b.Id != model.Id);
            if (!exitedCode) return true;

            domainDataHandler.RaiseError($"BranchCode {model.Code} have used by other Asset.");
            return false;
        }

        protected override bool ValidateDelete(Asset deletedEntity)
        {
            return true;
        }

        protected override bool UseCache => false;
    }
}