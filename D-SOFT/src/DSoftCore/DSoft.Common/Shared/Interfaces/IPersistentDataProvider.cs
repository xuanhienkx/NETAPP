namespace DSoft.Common.Shared.Interfaces;

public interface IPersistentDataProvider
{
    bool TryGet<T>(string key, out T message);
    void Set<T>(string key, T message);
    T Get<T>(string key);
    void Reset(string key);
    void TryUpdate<T>(string id, Func<T, T> update);
}