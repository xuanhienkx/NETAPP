namespace DSoft.Common.Shared.Interfaces;

public interface IFileService
{
    void EnsurePath(string path);
    Task Move(string fromFile, string path);
    Task Transfer(Stream fromStream, Stream toStream);
    Task<Stream> Read(string fileName, bool useCircuitBreaker = false);
    Task<Stream> Read(FileInfo file, bool useCircuitBreaker = false);
    Task<Stream> Open(string tempFilePath, bool useCircuitBreaker = false);
    Task Delete(string fileName, bool useCircuitBreaker = false);
    string GetFileName(string fileName);
}
public interface IFileTransformerProvider
{
    bool CanUse(string fileName);
    Task EnsurePath(string path);
    Task<Stream> LoadStream(string fileName);
    Task<Stream> LoadStream(FileInfo file);
    Task<Stream> PlushStreamAsync(string fileName);
    Task Delete(string fileName);
}
public interface IFileWatcher
{
    bool HasChangeOrActive();
}