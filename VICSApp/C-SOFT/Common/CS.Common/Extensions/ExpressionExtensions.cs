using System;
using System.Linq.Expressions;
using CS.Common.Contract;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;

namespace CS.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TTo, bool>> ConvertFilter<TFrom, TTo>(this Expression<Func<TFrom, bool>> target)
        {
            return (Expression<Func<TTo, bool>>)new WhereReplacerVisitor<TFrom, TTo>().Visit(target);
        }

        private class WhereReplacerVisitor<TFrom, TTo> : ExpressionVisitor
        {
            private readonly ParameterExpression parameter = Expression.Parameter(typeof(TTo), "c");

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                // replace parameter here
                return Expression.Lambda(Visit(node.Body), parameter);
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                // replace parameter member access with new type
                if (node.Member.DeclaringType == typeof(TFrom) && node.Expression is ParameterExpression)
                {
                    return Expression.PropertyOrField(parameter, node.Member.Name);
                }
                return base.VisitMember(node);
            }
        }

        public static IQuery<TIdentity, TServiceModel, TEntityModel> Include<TIdentity, TServiceModel, TEntityModel,
            TProperty>(this IQuery<TIdentity, TServiceModel, TEntityModel> query,
            Expression<Func<TEntityModel, TProperty>> path)
            where TServiceModel : IResource<TIdentity>
            where TEntityModel : class, IIdentityEntity<TIdentity>
        {
            return query;
        }
    }
}