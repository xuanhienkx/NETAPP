using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data;
using CS.Domain.Data.Entities;
using FluentValidation;
using System;
using System.Linq;

namespace CS.Core.Service.Validators
{
    public class CustomerInsertValidator : CustomerValidator
    {
        public CustomerInsertValidator(ICSoftDataContext context) : base(context)
        {
            ValidateUnique();
        }
    }

    public class CustomerUpdateStatusValidator : CustomerValidator
    {
        public CustomerUpdateStatusValidator(CSoftDataContext context) : base(context)
        {
            ValidateCustomer();
        }
    }

    public class CustomerUpdateValidator : CustomerValidator
    {
        public CustomerUpdateValidator(CSoftDataContext context) : base(context)
        {
            ValidateId();
            ValidateUnique();
        }
    }

    public class CustomerDeleteValidator : CustomerValidator
    {
        public CustomerDeleteValidator(CSoftDataContext context) : base(context)
        {
            ValidateId();
        }
    }

    public abstract class CustomerValidator : BaseValidator<CustomerModel, Guid>
    {
        protected CustomerValidator(ICSoftDataContext context) : base(context)
        {
        }

        protected void ValidateCustomer()
        {
            RuleFor(c => c.AccountLogin)
                .Must(username => RestrictedNames.All(n => !n.Equals(username, StringComparison.OrdinalIgnoreCase)));
            RuleFor(c => c.CustomerNumber).NotEmpty().Length(10);
        }

        protected IRuleBuilderOptions<CustomerModel, CustomerModel> ValidateUnique()
        {
            var ruleBuilder = RuleFor(x => x)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(model => model != null);

            AppendUnique<string, Customer>(ruleBuilder, customer => customer.CustomerNumber, entity => entity.CustomerNumber)
                .WithMessage(model => $"{nameof(model.CustomerNumber)}: {model.CustomerNumber} have used by other Customer");

            AppendUnique<string, Customer>(ruleBuilder, customer => customer.CardIdentity, entity => entity.CardIdentity)
                .WithMessage(model => $"{nameof(model.CardIdentity)}: {model.CardIdentity} have used by other Customer");

            AppendUnique<string, Customer>(ruleBuilder, x => x.AccountLogin, e => e.AccountLogin)
                .WithMessage(model => $"{nameof(model.AccountLogin)}: {model.AccountLogin} have used by other login");

            AppendUnique<string, Customer>(ruleBuilder, x => x.Email, e => e.Email)
                .WithMessage(model => $"{nameof(model.Email)}: {model.Email} have used by other login");
        
            return ruleBuilder;
        }
    }
}