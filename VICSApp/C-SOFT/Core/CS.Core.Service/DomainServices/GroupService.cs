/*using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;

namespace CS.Core.Service.DomainServices
{
    public class GroupService : CommonServiceBase<Guid, GroupModel, Group>
    {
        private readonly IStringLocalizer<GroupService> localizer;
        private readonly IDomainDataHandler domainDataHandler;

        public GroupService(IDataFactory dataFactory, IDomainDataHandler domainDataHandler, ICacheService cacheService, IStringLocalizer<GroupService> localizer)
            : base(dataFactory, cacheService)
        {
            this.localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));

            EntityIncludedPaths.Add(group => group.Branch);
            EntityIncludedPaths.Add(group => group.Parent);
        }

        private bool CommonValidate(GroupModel model)
        {
            if (model.Parent != null && model.Parent.Branch.Id != model.Branch.Id)
            {
                domainDataHandler.RaiseError(localizer["GroupService_BranchMustBeTheSameWithParent_Validation"]);
                return false;
            }
            return true;
        }

        protected override bool ValidateInsert(GroupModel model)
        {
            if (!CommonValidate(model))
                return false;

            var exitedName = Query.Queryable().Any(b => b.BranchId == model.Branch.Id && b.Name.Equals(model.Name));
            if (!exitedName) return true;

            domainDataHandler.RaiseError(string.Format(localizer["GroupService_UniqueName_Validation"], model.Name));
            return false;
        }

        protected override bool ValidateUpdate(GroupModel model)
        {
            if (!CommonValidate(model))
                return false;

            if (Query.Queryable().Any(b => b.Id != model.Id && b.BranchId == model.Branch.Id && b.Name.Equals(model.Name)))
            {
                domainDataHandler.RaiseError(string.Format(localizer["GroupService_UniqueName_Validation"], model.Name));
                return false;
            }

            return true;
        }

        protected override bool ValidateDelete(Group deletedEntity)
        {
            return true;
        }

        protected override bool UseCache => true;
    }
}*/