using CS.Common.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CS.Common.Std;

namespace CS.Common.FileTransfer
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> logger;
        private readonly IEnumerable<IFileTransformerProvider> fileTransformers;
        
        public FileService(IEnumerable<IFileTransformerProvider> fileTransformers, ILogger<FileService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.fileTransformers = fileTransformers ?? throw new ArgumentNullException(nameof(fileTransformers));
        }

        public async Task Move(string fromFile, string path)
        {
            if (!TryGetProvider(fromFile, out var fromProvider))
                throw new NotImplementedException($"Cannot find file transfer provider for file {fromFile}");

            if (!TryGetProvider(path, out var toProvider))
                throw new NotImplementedException($"Cannot find file transfer provider for file {path}");

            var toFile = $"{path}/{ GetFileName(fromFile)}";
            using (var fromStream = await fromProvider.LoadStream(fromFile))
            using (var toStream = await toProvider.PlushStreamAsync(toFile))
            {
                await Transfer(fromStream, toStream);
            }
            logger.LogDebug("Moved {0} to {1}", fromFile, toFile);

            // remove file
            await fromProvider.Delete(fromFile);
            logger.LogDebug("Deleted file {0}", fromFile);
        }

        public string GetFileName(string fileName)
        {
            return fileName.Split('/', '\\').Last();
        }

        public void EnsurePath(string path)
        {
            if (!TryGetProvider(path, out var provider))
                throw new NotImplementedException($"Cannot find file transfer provider for file {path}");

            provider.EnsurePath(path);
        }

        public async Task Transfer(Stream fromStream, Stream toStream)
        {
            var byteBuffer = new byte[BusinessIdProviderConstant.BufferSize];
            var bytesRead = fromStream.Read(byteBuffer, 0, BusinessIdProviderConstant.BufferSize);
            try
            {
                while (bytesRead > 0)
                {
                    await toStream.WriteAsync(byteBuffer, 0, bytesRead);
                    bytesRead = await fromStream.ReadAsync(byteBuffer, 0, BusinessIdProviderConstant.BufferSize);
                }
                await toStream.FlushAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        public async Task<Stream> Read(string fileName, bool useCircuitBreaker = false)
        {
            if (!TryGetProvider(fileName, out var provider))
                throw new NotImplementedException($"Cannot find file transfer provider for file {fileName}");

            var stream = await Execute(() => provider.LoadStream(fileName), useCircuitBreaker);
            if (stream == null)
                throw new OperationCanceledException($"Cannot read {fileName}. Check log for more detail");

            return stream;
        }

        public async Task<Stream> Open(string fileName, bool useCircuitBreaker = false)
        {
            if (!TryGetProvider(fileName, out var provider))
                throw new NotImplementedException($"Cannot find file transfer provider for file {fileName}");

            return await Execute(() => provider.PlushStreamAsync(fileName), useCircuitBreaker);
        }

        public async Task Delete(string fileName, bool useCircuitBreaker = false)
        {
            if (!TryGetProvider(fileName, out var provider))
                throw new NotImplementedException($"Cannot find file transfer provider for file {fileName}");

            await Execute(() => provider.Delete(fileName), useCircuitBreaker);
        }

        private bool TryGetProvider(string fileOrPath, out IFileTransformerProvider provider)
        {
            provider = fileTransformers.SingleOrDefault(x => x.CanUse(fileOrPath));
            return provider != null;
        }
        
        private async Task Execute(Func<Task> action, bool useCircuitBreaker)
        {
            if (useCircuitBreaker)
                await action.CircuitBreakerExecuteAsync();
            else
                await action.Invoke();
        }

        private async Task<T> Execute<T>(Func<Task<T>> action, bool useCircuitBreaker)
        {
            return useCircuitBreaker
                ? await action.CircuitBreakerExecuteAsync()
                : await action.Invoke();
        }
    }
}