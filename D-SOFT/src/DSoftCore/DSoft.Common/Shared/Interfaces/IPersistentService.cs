using MongoDB.Driver;

namespace DSoft.Common.Shared.Interfaces
{
    public interface IPersistentService<TComponent>
    {
        IMongoCollection<T> GetCollection<T>() where T : IPersistentEntity;
        IMongoDatabase Database { get; }
        bool HasSession { get; }
        IClientSessionHandle Session { get; }
        Task StartSession(string path);
        Task Rollback(string path);
        Task Commit(string path);
    }
}
