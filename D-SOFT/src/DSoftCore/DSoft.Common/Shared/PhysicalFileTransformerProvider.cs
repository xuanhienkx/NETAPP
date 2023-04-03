using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Interfaces;
using Microsoft.Extensions.Logging;
namespace DSoft.Common.Shared;
public class PhysicalFileTransformerProvider : IFileTransformerProvider
{
    private readonly ILogger<PhysicalFileTransformerProvider> logger;

    public PhysicalFileTransformerProvider(ILogger<PhysicalFileTransformerProvider> logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public bool CanUse(string fileName)
    {
        return !fileName.ToLowerInvariant().StartsWith("ftp://");
    }

    public Task EnsurePath(string path)
    {
        logger.LogDebug("EnsurePath: {0}", path);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        return Task.CompletedTask;
    }

    public Task<Stream> LoadStream(string fileName)
    {
        return Task.FromResult<Stream>(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
    }
    public Task<Stream> LoadStream(FileInfo file)
    {
        return Task.FromResult<Stream>(new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
    }
    public Task<Stream> PlushStreamAsync(string fileName)
    {
        return Task.FromResult<Stream>(File.Create(fileName, ProviderConstants.BufferSize, FileOptions.WriteThrough));
    }

    public Task Delete(string fileName)
    {
        File.Delete(fileName);
        return Task.CompletedTask;
    }


}
