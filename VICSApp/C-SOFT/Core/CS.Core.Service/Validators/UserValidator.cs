using System;
using System.Linq;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data;
using CS.Domain.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace CS.Core.Service.Validators
{
    public class UserInsertValidator : UserValidator
    {
        public UserInsertValidator(ICSoftDataContext context) : base(context)
        {
            ValidateUnique();
        }
    }

    public class UserUpdateValidator : UserValidator
    {
        public UserUpdateValidator(CSoftDataContext context) : base(context)
        {
            ValidateId();
            ValidateUnique();
        }
    }

    public class UserUpdateStatusValidator : UserValidator
    {
        public UserUpdateStatusValidator(ICSoftDataContext context) : base(context)
        {
            ValidateId();
        }
    }

    public class UserDeleteValidator : UserValidator
    {
        public UserDeleteValidator(CSoftDataContext context) : base(context)
        {
            ValidateId();
        }
    }

    public abstract class UserValidator : BaseValidator<UserModel, Guid>
    {
        protected UserValidator(ICSoftDataContext context) : base(context)
        {
        }

        protected void ValidateUser()
        {
            RuleFor(c => c.AccountLogin)
                .Must(username => RestrictedNames.All(n => !n.Equals(username, StringComparison.OrdinalIgnoreCase)));
        }

        protected IRuleBuilderOptions<UserModel, UserModel> ValidateUnique()
        {
            var ruleBuilder = RuleFor(x => x)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(model => model != null);

            AppendUnique<string, Customer>(ruleBuilder, x => x.AccountLogin, e => e.AccountLogin)
                .WithMessage(model => $"{nameof(model.AccountLogin)}: {model.AccountLogin} have used by other login");

            AppendUnique<string, Customer>(ruleBuilder, x => x.Email, e => e.Email)
                .WithMessage(model => $"{nameof(model.Email)}: {model.Email} have used by other login");

            return ruleBuilder;
        }
    }
}