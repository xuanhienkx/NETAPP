namespace DO.Common.Domain.Interfaces;

public interface IDomainEventHandler<T>
{
    void Raise(T message, string notifierKey = null);
    IEnumerable<T> GetAll();
}