using api.common.Shared.Base;
using api.common.Shared.Interfaces;

namespace api.common.Commands
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
