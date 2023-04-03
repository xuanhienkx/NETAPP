using BO.Core.DataCommon.Shared.Base;
using BO.Core.DataCommon.Shared.Interfaces;

namespace BO.Core.DataCommon.Commands
{
    public class CreateEntityCommand<T> : BaseCommand<T> where T : IPersistentEntity
    {
        public T Entity { get; }

        public CreateEntityCommand(T entity)
        {
            Entity = entity;
        }
    }
}
