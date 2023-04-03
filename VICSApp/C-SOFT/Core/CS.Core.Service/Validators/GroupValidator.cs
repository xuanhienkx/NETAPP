using System;
using System.Linq;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data.Entities;
using FluentValidation;

namespace CS.Core.Service.Validators
{
    public abstract class GroupValidator : AbstractValidator<GroupModel>
    {
        private readonly ICSoftDataContext context;

        protected GroupValidator(ICSoftDataContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void ValidateId()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty);
        }
        public void ValidateName()
        {
            RuleFor(x => x)
                .Must(g => !context.Set<Group>()
                           .Any(x => x.Name.Equals(g.Name) && (g.Id == Guid.Empty || !x.Id.Equals(g.Id))))
                .WithMessage(model => $"{nameof(model.Name)}: {model.Name} have used by other group");
        }
        public void CommonValidate()
        {
            RuleFor(x => x)
                .Must(BranchValidate)
                .WithMessage(m => "GroupService_BranchMustBeTheSameWithParent_Validation");

        }
        private bool BranchValidate(GroupModel model)
        {
            if (model.Parent != null && model.Parent.Branch.Id != model.Branch.Id)
            {
                return false;
            }
            return true;
        }
    }
}