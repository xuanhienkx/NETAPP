using DO.Common.Std;

namespace DO.Common.Extensions
{
    public class EntityNotFoundException<T> : CsException
    {
        private readonly T identity;

        public EntityNotFoundException(T identity)
        {
            this.identity = identity;
        }

        protected override string Detail()
        {
            return $"Entity identity [{identity}] cannot found";
        }
    }

    public class BusinessPendingApprovalException<T> : CsException
    {
        private readonly string businessId;

        public BusinessPendingApprovalException(string businessId)
        {
            this.businessId = businessId;
        }
        protected override string Detail()
        {
            return $"Business [{businessId}] pending process with {nameof(T)} approval";
        }
    }
}
