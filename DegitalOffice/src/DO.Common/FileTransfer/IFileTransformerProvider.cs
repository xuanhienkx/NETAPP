namespace DO.Common.FileTransfer;

public interface IFileTransformerProvider
{
    bool CanUse(string fileName);
    Task EnsurePath(string path);
    Task<Stream> LoadStream(string fileName);
    Task<Stream> PlushStreamAsync(string fileName);
    Task Delete(string fileName);
}
public interface IFileWatcher
{
    bool HasChangeOrActive();
}