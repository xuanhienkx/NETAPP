using MediatR;

namespace api.common.Shared.Base
{
    public abstract class BaseCommand<T> : IRequest<Result<T>>
    {

    }
}
