using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CSM.Common
{
    public static class FilterExtension
    {
        public static Expression<Func<T, bool>> ToExpression<T>(this Filter filter)
        {
            Expression predicateBody = null;
            var parameter = Expression.Parameter(typeof(T), typeof(T).Name);

            foreach (var criterion in filter.Criteria.Where(x => x.Type != CriterionType.Not))
            {
                var criterionExpression = criterion.ToExpression<T>(parameter);
                predicateBody = predicateBody != null
                    ? (criterion.Type == CriterionType.AndAlso? Expression.AndAlso(predicateBody, criterionExpression) : Expression.And(predicateBody, criterionExpression))
                    : criterionExpression;
            }

            return Expression.Lambda<Func<T, bool>>(predicateBody, parameter);
        }

        public static Expression ToExpression<T>(this Criterion criterion, ParameterExpression parameterExpression)
        {
            var argProperty = parameterExpression ?? Expression.Parameter(typeof(T), typeof(T).Name);
            var nameProperty = Expression.Property(argProperty, criterion.Field);
            var value = Expression.Constant(criterion.Value);
            return BuildOperatorLambda(criterion.Operator, nameProperty, value);
        }

        private static Expression BuildOperatorLambda(Operator filterOpertator, Expression field, Expression value)
        {
            switch (filterOpertator)
            {
                case Operator.Contains:
                    return Expression.Call(field, typeof(string).GetMethod("Contains", new[] { typeof(string) }), value);
                case Operator.DifferenceOf:
                    return Expression.NotEqual(field, value);
                case Operator.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(field, value);
                case Operator.GreaterThan:
                    return Expression.GreaterThan(field, value);
                case Operator.LessThanOrEqual:
                    return Expression.LessThanOrEqual(field, value);
                case Operator.LessThan:
                    return Expression.LessThan(field, value); 
                default:
                    return Expression.Equal(field, value);
            }
        }
    }
    public static class SortExtension
    {
        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>
        (this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            bool descending)
        {
            return descending ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }

        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>
        (this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            bool descending)
        {
            return descending ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }

    }
    public static class ModelExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, IList<SortField> sortFields)
            where T : class 
        {
            return sortFields.Aggregate(query, (current, sortField) => current.OrderBy(sortField)) as IOrderedQueryable<T>;
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, SortField sortField) 
        {
            string method = $"OrderBy{(sortField.IsAscending ? string.Empty : "Descending")}";
            var parameter = Expression.Parameter(query.ElementType, "p");
            var memberAccess = sortField.FieldName.Split('.')
                .Aggregate<string, Expression>(null, (current, name) 
                  => Expression.Property(current ?? parameter, name));
            var orderByLambda = Expression.Lambda(memberAccess, parameter);

            var result = Expression.Call(
                typeof(Queryable),
                method,
                new[] { query.ElementType, memberAccess.Type },
                query.Expression,
                Expression.Quote(orderByLambda));
            return query.Provider.CreateQuery<T>(result) as IOrderedQueryable<T>;
        }
 

      
    
    } 
}
