using DO.Common.Std;

namespace DO.Common.Extensions
{
    public class EntityNotSameVersionException<T> : CsException
    {
        private readonly T identity;
        private readonly int version;

        public EntityNotSameVersionException(T identity, int version)
        {
            this.identity = identity;
            this.version = version;
        }

        protected override string Detail()
        {
            return $"Entity identity [{identity}] not same version {version}";
        }
    }
}