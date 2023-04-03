using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GridMvc.Filtering;

namespace SMS.Common.Models
{
    public class SortField
    {
        public SortField(string fieldName, bool isAsc)
        {
            FieldName = fieldName;
            IsAscending = isAsc;
        }
        public string FieldName { get; set; }
        public bool IsAscending { get; set; }
    }
    public static class ModelExtensions
    {
        public static List<T> GetPage<T>(this IOrderedQueryable<T> query, int page, int pageSize) where T : class
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, IList<SortField> sortFields)
            where T : class
        {
            return sortFields.Aggregate(query, (current, sortField) => current.OrderBy(sortField)) as IOrderedQueryable<T>;
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, SortField sortField) where T : class
        {
            string method = string.Format("OrderBy{0}", sortField.IsAscending ? string.Empty : "Descending");
            var parameter = Expression.Parameter(query.ElementType, "p");
            var memberAccess = sortField.FieldName.Split('.')
                .Aggregate<string, Expression>(null, (current, name) => Expression.Property(current ?? parameter, name));
            var orderByLambda = Expression.Lambda(memberAccess, parameter);

            var result = Expression.Call(
                typeof(Queryable),
                method,
                new[] { query.ElementType, memberAccess.Type },
                query.Expression,
                Expression.Quote(orderByLambda));
            return query.Provider.CreateQuery<T>(result) as IOrderedQueryable<T>;
        }

        public static IQueryable<T> WithFilter<T>(this IQueryable<T> query, IEnumerable<ColumnFilterValue> filters) where T : class
        {
            return filters.Aggregate(query, (current, filter) => current.WithFilter(filter));
        }


        public static IQueryable<T> WithFilter<T>(this IQueryable<T> query, ColumnFilterValue filter) where T : class
        {
            if (string.IsNullOrEmpty(filter.ColumnName))
                return query;

            var parameter = Expression.Parameter(query.ElementType, "p");
            var memberAccess = filter.ColumnName.Split('.')
                .Aggregate<string, Expression>(null, (current, name) => Expression.Property(current ?? parameter, name));

            var filterCondition = Expression.Constant(Convert.ChangeType(filter.FilterValue, memberAccess.Type));

            Expression condition;

            switch (filter.FilterType)
            {
                case GridFilterType.Equals:
                    condition = Expression.Equal(memberAccess, filterCondition);
                    break;
                case GridFilterType.StartsWith:
                    condition = Expression.Call(memberAccess, typeof(string).GetMethod("StartsWith"),
                        filterCondition);
                    break;
                case GridFilterType.EndsWidth:
                    condition = Expression.Call(memberAccess, typeof(string).GetMethod("EndsWith"),
                        filterCondition);
                    break;
                case GridFilterType.Contains:
                    condition = Expression.Call(memberAccess, typeof(string).GetMethod("Contains"),
                        filterCondition);
                    break;
                case GridFilterType.GreaterThan:
                    condition = Expression.GreaterThanOrEqual(memberAccess, filterCondition);
                    break;
                case GridFilterType.LessThan:
                    condition = Expression.LessThanOrEqual(memberAccess, filterCondition);
                    break;
                default:
                    throw new NotSupportedException("not support this filter type");
            }


            var whereLambda = Expression.Lambda(condition, parameter);
            MethodCallExpression result = Expression.Call(
                typeof(Queryable), "Where",
                new[] { query.ElementType },
                query.Expression,
                whereLambda);

            return query.Provider.CreateQuery<T>(result);
        }



    }
}