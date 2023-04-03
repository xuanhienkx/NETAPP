using DSoft.Common.Shared.Base;
using System.Linq.Expressions;

namespace DSoft.Common.Queries
{
    public class GetAllQuery<T> : BaseQuery<List<T>> where T : class
    {
        public object[] Arguments { get; }

        public GetAllQuery(params object[] arguments)
        {
            Arguments = arguments;
        }
        public bool IsGetAll { get; set; }

        public bool TryGet<TValue>(int index, out TValue value)
        {
            if (Arguments.Length <= index)
            {
                value = default;
                return false;
            }

            value = (TValue)Arguments[index];
            return true;
        }
    }

    public class GetAllByExpressionQuery<T> : BaseQuery<List<T>> where T : class
    {
        public Expression<Func<T, bool>> Filter { get; }

        public GetAllByExpressionQuery(Expression<Func<T, bool>> filter)
        {
            Filter = filter;
        }
    }
}
