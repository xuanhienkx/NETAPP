using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;
using System;
using System.Linq;

namespace CS.Core.Service.DomainServices
{
    public class BranchService : CommonServiceBase<long, BranchModel, Branch>
    {
        private readonly IDomainDataHandler domainDataHandler;

        public BranchService(IDataFactory dataFactory, IDomainDataHandler domainDataHandler, ICacheService cacheService)
            : base(dataFactory, cacheService)
        {
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));

            EntityIncludedPaths.Add(b => b.Parent);
            EntityIncludedPaths.Add(b => b.Settings);
        }

        protected override bool ValidateInsert(BranchModel model)
        {
            var exitedBranchCode = Query.Queryable().Any(b => b.BranchCode.Equals(model.BranchCode));
            if (!exitedBranchCode) return true;

            domainDataHandler.RaiseError($"BranchCode {model.BranchCode} existed in system.");
            return false;
        }

        protected override bool ValidateUpdate(BranchModel model)
        {
            var exitedBranchCode = Query.Queryable().Any(b => b.BranchCode.Equals(model.BranchCode) && b.Id != model.Id);
            if (!exitedBranchCode) return true;

            domainDataHandler.RaiseError($"BranchCode {model.BranchCode} have used by other Branch.");
            return false;
        }

        protected override bool ValidateDelete(Branch deletedEntity)
        {
            return true;
        }

        protected override bool UseCache => true;
    }
}