namespace DSoft.Common.Shared.Interfaces;

public interface IApiWebRequest
{
    Task<Result<string>> PostAsync<T>(string path, T content, string requestId = null);
    Task<Result<TR>> PostAsync<T, TR>(string path, T content, string requestId = null);
    Task<Result<T>> GetAsync<T>(string path, string requestId = null);
    Task<Result<IList<T>>> GetListAsync<T>(string path);
    Task<Result<bool>> DeleteAsync(string path, string requestId = null);
    Task<Result<TR>> PutAsync<T, TR>(string path, T content, string requestId = null);
    Task<Result<T>> PutAsync<T>(string path, T content, string requestId = null);
    Task<Result<T>> PatchAsync<T>(string path, T content, string requestId = null);
}
