using BO.Core.DataCommon.Commands;
using BO.Core.DataCommon.Shared;
using BO.Core.DataCommon.Shared.Base;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Reflection;

namespace BO.Core.DataCommon.Shared
{
    public static class CommonExtensions
    {
        public static void SetPropertyValue<T, TValue>(this T target, Expression<Func<T, TValue>> memberLamda, TValue value)
        {
            if (memberLamda.Body is MemberExpression memberSelectorExpression)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(target, value, null);
                }
            }
        }

        public static IFindFluent<T, T> Exclude<T>(this IFindFluent<T, T> find, params Expression<Func<T, object>>[] fields)
        {
            if (fields == null || fields.Length == 0)
                return find;

            var projection = Builders<T>.Projection.Exclude(fields[0]);
            for (var i = 1; i < fields.Length; i++)
            {
                projection = projection.Exclude(fields[i]);
            }

            return find.Project<T>(projection);
        }

        public static IFindFluent<T, T> Include<T>(this IFindFluent<T, T> find, params Expression<Func<T, object>>[] fields)
        {
            if (fields == null || fields.Length == 0)
                return find;

            var projection = Builders<T>.Projection.IncludeMany(fields);
            return find.Project<T>(projection);
        }

        public static ProjectionDefinition<T> IncludeMany<T>(this ProjectionDefinitionBuilder<T> builder, params Expression<Func<T, object>>[] fields)
        {
            return builder.Combine(fields.Select(builder.Include));
        }

        public static IFindFluent<T, TOut> Project<T, TOut>(this IFindFluent<T, T> find, params Expression<Func<T, object>>[] fields)
        where T : TOut
        {
            var projection = Builders<T>.Projection.Include(fields[0]);
            for (var i = 1; i < fields.Length; i++)
            {
                projection = projection.Include(fields[i]);
            }

            return find.Project<TOut>(projection);
        }

        public static UpdateManyByIdCommand<T> With<T>(this UpdateManyByIdCommand<T> command,
            Expression<Func<T, object>> field, object value)
        where T : ILiteralId
        {
            command.UpdateFields.Add(new Tuple<Expression<Func<T, object>>, object>(field, value));
            return command;
        }

        public static PersistentHandlerOptions<T> Set<T>(this PersistentHandlerOptions<T> options, Expression<Func<T, object>> field,
            object value)
        {
            options.UpdateFields.Add(Builders<T>.Update.Set(field, value));
            return options;
        }

        public static PersistentHandlerOptions<T> AddToList<T>(this PersistentHandlerOptions<T> options, Expression<Func<T, IEnumerable<object>>> field,
            object value)
        {
            options.UpdateFields.Add(Builders<T>.Update.AddToSet(field, value));
            return options;
        }

        public static PersistentHandlerOptions<T> SetInc<T>(this PersistentHandlerOptions<T> options, Expression<Func<T, int>> field, int value = 1)
        {
            options.UpdateFields.Add(Builders<T>.Update.Inc(field, value));
            return options;
        }

        public static PersistentHandlerOptions<T> Where<T>(this PersistentHandlerOptions<T> options, Expression<Func<T, bool>> expression)
        {
            options.FilterFields.Add(Builders<T>.Filter.Where(expression));
            return options;
        }

        public static PersistentHandlerOptions<T> Where<T>(this PersistentHandlerOptions<T> options, Expression<Func<T, object>> field,
            object value)
        {
            options.FilterFields.Add(Builders<T>.Filter.Eq(field, value));
            return options;
        }

        public static FilterDefinition<T> WhereAll<T>(this FilterDefinitionBuilder<T> builder, params Expression<Func<T, bool>>[] expressions)
        {
            return builder.And(expressions.Select(builder.Where));
        }

        public static IFindFluent<T, T> Where<T>(this IMongoCollection<T> collection, params Expression<Func<T, bool>>[] expressions)
        {
            var filter = Builders<T>.Filter.And(expressions.Select(Builders<T>.Filter.Where));
            return collection.Find(filter);
        }
        public static void AddRange<K, V>(this Dictionary<K, V> distDictionary, Dictionary<K, V> srcDictionary)
        {
            srcDictionary.ToList()
                .ForEach(pair => distDictionary[pair.Key] = pair.Value);
        }

        public static string[] NumberArrayString(this int number)
        {
            var rs = new List<string>();
            for (var i = 1; i <= number; i++)
            {
                rs.Add($"{i}");
            }

            return rs.ToArray();
        }


    }
}
