using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace CS.Common.Contract
{
    public abstract class ValidableModel : ModelBase, IDataErrorInfo
    {
        protected readonly Lazy<RuleCollection> Rules = new Lazy<RuleCollection>(() => new RuleCollection());
        private readonly ConcurrentDictionary<string, string> errorResult = new ConcurrentDictionary<string, string>();

        #region Data Validation

        [JsonIgnore]
        public bool IsValid => errorResult.All(x => string.IsNullOrEmpty(x.Value));
        [JsonIgnore]
        public string Error => string.Join(Environment.NewLine, errorResult.Select(x => $"{x.Key}: {x.Value}"));
        [JsonIgnore]
        string IDataErrorInfo.this[string propertyName] => Validate(propertyName);

        #endregion

        #region Methods

        public string Validate<TProperty>(Expression<Func<TProperty>> property)
        {
            if (property.Body is MemberExpression memberExpression)
                return Validate(memberExpression.Member.Name);
            return null;
        }

        public string Validate(string propertyName)
        {
            // validate the rules
            if (EnsureRulesInitialized())
            {
                var errorMessage = Rules.Value.Apply(propertyName);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = DataContractResourceManager.Current.Translate(errorMessage);
                    errorResult[propertyName] = errorMessage;
                    return errorMessage;
                }
            }

            // validate extended runtime rules
            if (EnablePropertyChange && ExtendValidators.TryGetValue(propertyName, out var validator))
            {
                var errorMessage = validator.Compile().Invoke();
                errorResult[propertyName] = errorMessage;
                return errorMessage;
            }

            errorResult[propertyName] = null;
            return null;
        }

        private bool EnsureRulesInitialized()
        {
            if (!Rules.IsValueCreated)
                SetupRules(Rules.Value);

            return  Rules.Value.Any();
        }

        protected virtual void SetupRules(RuleCollection rules) { }

        public List<string> Validate()
        {
            if (!EnsureRulesInitialized())
                return null;

            return Rules.Value.ApplyAll(s => DataContractResourceManager.Current.Translate(s)).Values
                .ToList();
        }

        #endregion
    }

    public abstract class DataContract : ValidableModel
    {
        #region Clone methods

        public T Clone<T>() where T : DataContract
        {
            return Helper.Clone((T)this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is IResource<long> longObj && this is IResource<long> longThis)
                return longThis.Id.Equals(longObj.Id);

            if (obj is IResource<Guid> uqObj && this is IResource<Guid> uqThis)
                return uqThis.Id.Equals(uqObj.Id);

            return base.Equals(obj);
        }

        public override int GetHashCode() => base.GetHashCode();

        public string Translate(string key)
            => DataContractResourceManager.Current.Translate(key);

        #endregion
    }
}
