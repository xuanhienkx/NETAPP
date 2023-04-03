using api.common.Models;
using api.common.Settings;
using api.common.Shared;
using api.common.Shared.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace api.resources.Services
{
    public class PhysicLocalFileService : IFileService
    {
        private readonly ICurrentUser currentUser;
        private readonly ApplicationSettings settings;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly ILogger<PhysicLocalFileService> logger;

        private const string ProviderName = "LocalDisk";

        public PhysicLocalFileService(ICurrentUser currentUser, ApplicationSettings settings, IWebHostEnvironment hostEnvironment, ILogger<PhysicLocalFileService> logger)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<MediaResource>> Upload(Stream stream, string fileName, CancellationToken cancellationToken)
        {
            await using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream, cancellationToken);

            // Check if the file is empty or exceeds the size limit.
            if (memoryStream.Length == 0)
                return Result.Error<MediaResource>("File", "The file is empty.");

            if (memoryStream.Length > settings.DataFileSizeLimit)
                return Result.Error<MediaResource>("File", "The file is too large.");

            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            if (!IsValidFileExtensionAndSignature(fileName, ext, memoryStream))
                return Result.Error<MediaResource>("The file type isn't permitted or the file's signature doesn't match the file's extension.");

            // write down to physical location
            var fileId = $"{currentUser.UserId}_{Path.GetRandomFileName()}";
            fileId = Path.ChangeExtension(fileId, ext);

            var fileFullName = Path.Combine(settings.DataFileLocation, fileId);
            await using (var targetStream = File.Create(fileFullName))
            {
                await targetStream.WriteAsync(memoryStream.ToArray(), cancellationToken);
                logger.LogDebug($"Uploaded file '{WebUtility.HtmlEncode(fileName)}' saved to '{fileFullName}'");
            }

            return Result.Value(new MediaResource
            {
                Name = WebUtility.HtmlEncode(fileName),
                FileId = fileId,
                Provider = ProviderName
            });
        }

        public Task<bool> Delete(MediaResource media)
        {
            if (media.Provider != ProviderName)
                return Task.FromResult(false);
            
            var fileFullName = Path.Combine(settings.DataFileLocation, media.FileId);
            if (File.Exists(fileFullName))
            {
                File.Delete(fileFullName);
            }

            return Task.FromResult(false);
        }

        public string Load(string fileName)
        { 
            using var stream = new FileStream(fileName, FileMode.Open);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public void Save(string fileName, StringBuilder contentBuilder)
        {
            using var stream = new FileStream(fileName, FileMode.OpenOrCreate);
            using var writer = new StreamWriter(stream);
            writer.Write(contentBuilder);
        }

        public string GetPath(string filePath)
        {
            if (hostEnvironment.IsProduction())
                return Path.Combine(this.hostEnvironment.ContentRootPath, filePath);

            return Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), filePath);
        }

        private bool IsValidFileExtensionAndSignature(string fileName, string ext, Stream data)
        {
            if (string.IsNullOrEmpty(fileName) || data == null || data.Length == 0)
                return false;

            if (string.IsNullOrEmpty(ext) || !FileConfiguration.FileSignature.Keys.Contains(ext))
                return false;

            if (!settings.DataSignatureCheck)
                return true;

            data.Position = 0;
            using var reader = new BinaryReader(data);

            // File signature check
            // --------------------
            // With the file signatures provided in the _fileSignature
            // dictionary, the following code tests the input content's
            // file signature.
            var signatures = FileConfiguration.FileSignature[ext];
            var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

            return signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));
        }
    }
}
