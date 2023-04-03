using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace DO.Common.Contract
{
    public class Rule
    {
        public string PropertyName { get; }
        public string ErrorMessageKey { get; }

        private readonly Expression<Func<bool>> rule;

        public Rule(string propertyName, string errorMesssageKey, Expression<Func<bool>> rule)
        {
            this.PropertyName = propertyName;
            this.ErrorMessageKey = errorMesssageKey;
            this.rule = rule;
        }

        public bool Apply()
        {
            return rule.Compile().Invoke();
        }
    }

    public class RuleCollection : Collection<Rule>
    {
        public RuleCollection Add<TProperty>(Expression<Func<TProperty>> propertySelector, string messageKey, Expression<Func<bool>> rule)
        {
            if (propertySelector.Body is MemberExpression property)
                this.Add(property.Member.Name, messageKey, rule);
            return this;
        }

        public RuleCollection Add(string propertyName, string messageKey, Expression<Func<bool>> rule)
        {
            this.Add(new Rule(propertyName, messageKey, rule));
            return this;
        }

        public string Apply(string propertyName)
        {
            foreach (var rule in this)
            {
                if (string.IsNullOrEmpty(propertyName) || rule.PropertyName.Equals(propertyName))
                {
                    if (!rule.Apply())
                        return rule.ErrorMessageKey;
                }
            }
            return null;
        }

        public IDictionary<string, string> ApplyAll(Func<string, string> translate)
        {
            var result = new Dictionary<string, string>();
            foreach (var rule in this)
            {
                if (!rule.Apply())
                {
                    if (translate != null)
                        result[rule.PropertyName] = translate(rule.ErrorMessageKey) ?? $"[{rule.ErrorMessageKey}]";
                    else
                        result[rule.PropertyName] = rule.ErrorMessageKey;
                }
            }
            return result;
        }
    }
}
