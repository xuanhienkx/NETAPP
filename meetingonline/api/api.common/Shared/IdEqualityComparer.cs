using System.Collections.Generic;
using api.common.Shared.Base;

namespace api.common.Shared
{
    public class IdEqualityComparer<T> : IEqualityComparer<T> where T : ILiteralId
    {
        public bool Equals(T x, T y)
        {
            return y != null && (x != null && x.Id.Equals(y.Id));
        }

        public int GetHashCode(T obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}