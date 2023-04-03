using DO.Common.Std;
using Microsoft.Extensions.Logging;

namespace DO.Common.FileTransfer;

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
        return Task.FromResult<Stream>(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read));
    }

    public Task<Stream> PlushStreamAsync(string fileName)
    {
        return Task.FromResult<Stream>(File.Create(fileName, BusinessIdProviderConstant.BufferSize, FileOptions.WriteThrough));
    }

    public Task Delete(string fileName)
    {
        File.Delete(fileName);
        return Task.CompletedTask;
    }
}
