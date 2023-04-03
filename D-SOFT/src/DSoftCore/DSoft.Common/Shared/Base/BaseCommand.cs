using MediatR;

namespace DSoft.Common.Shared.Base;

public abstract class BaseCommand<T> : IRequest<Result<T>>
{

}
public abstract class BaseQuery<T> : BaseCommand<T>
{

}