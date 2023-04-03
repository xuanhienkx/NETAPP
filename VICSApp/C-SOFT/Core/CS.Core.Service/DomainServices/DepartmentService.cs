using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;
using System;
using System.Linq;

namespace CS.Core.Service.DomainServices
{
    public sealed class DepartmentService : CommonServiceBase<long, DepartmentModel, Department>
    {
        private readonly IDomainDataHandler domainDataHandler;

        public DepartmentService(IDataFactory dataFactory, IDomainDataHandler domainDataHandler, ICacheService cacheService)
            : base(dataFactory, cacheService)
        {
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));

            EntityIncludedPaths.Add(department => department.Branch);
        }

        protected override bool ValidateInsert(DepartmentModel model)
        {
            var exitedName = Query.Queryable().Any(b => b.Name.Equals(model.Name));
            if (!exitedName) return true;

            domainDataHandler.RaiseError($"Name {model.Name} have used by other Department.");
            return false;
        }

        protected override bool ValidateUpdate(DepartmentModel model)
        {
               
            var exitedName = Query.Queryable().Any(b => b.Name.Equals(model.Name) && b.Id != model.Id);
            if (!exitedName) return true;

            domainDataHandler.RaiseError($"Name {model.Name} have used by other Department.");
            return false;
        }

        protected override bool ValidateDelete(Department deletedEntity)
        {
            return true;
        }

        protected override bool UseCache => true;
    }
}