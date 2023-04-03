using CS.Common.Std;

namespace CS.Common.Exceptions
{
    public class EntityDuplicatedException<T> : CsException
    {
        private readonly T identity;

        public EntityDuplicatedException(T identity)
        {
            this.identity = identity;
        }

        protected override string Detail()
        {
            return $"Entity identity [{identity}] already existed";
        }
    }
}
