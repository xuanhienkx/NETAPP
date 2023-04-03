using CS.Common.Contract;
using CS.Common.Domain.Interfaces;
using FluentValidation;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;

namespace CS.Core.Service.Validators
{
    public abstract class BaseValidator<T, TKey> : AbstractValidator<T> where T : IResource<TKey>
    {
        protected readonly string[] RestrictedNames = { "admin", "csoft", "service", "administrator", "manager", "superadmin", "c-soft", "sa" };

        protected readonly ICSoftDataContext Context;

        protected BaseValidator(ICSoftDataContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected IRuleBuilderOptions<T, T> AppendUnique<TValue, TEntity>(IRuleBuilderOptions<T, T> ruleBuilder,
            Func<T, TValue> field,
            Expression<Func<TEntity, TValue>> entityField)
            where TEntity : class, IIdentityEntity<TKey>
        {
            return ruleBuilder.Must(model =>
            {
                var value = field(model);
                if (value == null)
                    return true;
                return !Context.Set<TEntity>().Any(x => value.Equals(entityField.Compile().Invoke(x)) &&
                                                        (model.Id.Equals(default(TKey)) || !x.Id.Equals(model.Id)));
            });
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id).NotEqual(default(TKey));
        }
    }
}