using DSoft.Common.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace DSoft.Common.Shared;

/// <summary>
/// https://www.codeproject.com/Tips/443588/Simple-Csharp-FTP-Class
/// </summary>
public class FtpFileTransformerProvider : IFileTransformerProvider
{
    private readonly ILogger<FtpFileTransformerProvider> logger;
    private readonly IConfigurationSection ftpConfigurationSection;
    private readonly int bufferSize = 2048;

    public FtpFileTransformerProvider(IConfigurationRoot config, ILogger<FtpFileTransformerProvider> logger)
    {
        if (config == null)
            throw new ArgumentNullException(nameof(config));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

        ftpConfigurationSection = config.GetSection("ftp");
    }

    public Task EnsurePath(string path)
    {
        logger.LogWarning("FTP provider requires all directory must be created");
        return Task.CompletedTask;
    }

    public bool CanUse(string fileName)
    {
        return fileName.ToLowerInvariant().StartsWith("ftp://");
    }

    public async Task<Stream> LoadStream(string fileName)
    {
        return await TryExecute(async request =>
        {
            var ftpResponse = await request.GetResponseAsync();
            return ftpResponse.GetResponseStream();
        }, fileName, WebRequestMethods.Ftp.DownloadFile);
    }
    public async Task<Stream> LoadStream(FileInfo file)
    {
        //return await TryExecute(async request =>
        //{
        //    var ftpResponse = await request.GetResponseAsync();
        //    return ftpResponse.GetResponseStream();
        //}, file.FullName, WebRequestMethods.Ftp.DownloadFile);
        return await LoadStream(file.FullName);
    }

    public async Task<Stream> PlushStreamAsync(string fileName)
    {
        return await TryExecute(request => request.GetRequestStreamAsync(), fileName, WebRequestMethods.Ftp.UploadFile);
    }

    public async Task Upload(string remoteFile, string localFile)
    {
        await TryExecute(async request =>
        {
            var ftpStream = request.GetRequestStream();
            var localFileStream = new FileStream(localFile, FileMode.Create);

            var byteBuffer = new byte[bufferSize];
            var bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
            /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
            try
            {
                while (bytesSent != 0)
                {
                    await ftpStream.WriteAsync(byteBuffer, 0, bytesSent);
                    bytesSent = await localFileStream.ReadAsync(byteBuffer, 0, bufferSize);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            localFileStream.Close();
            ftpStream.Close();

            return true;
        }, remoteFile, WebRequestMethods.Ftp.UploadFile);
    }

    public async Task Download(string remoteFile, string localFile)
    {
        await TryExecute(async request =>
        {
            var ftpResponse = (FtpWebResponse)request.GetResponse();
            var ftpStream = ftpResponse.GetResponseStream();

            var localFileStream = new FileStream(localFile, FileMode.Create);

            byte[] byteBuffer = new byte[bufferSize];
            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);

            try
            {
                while (bytesRead > 0)
                {
                    await localFileStream.WriteAsync(byteBuffer, 0, bytesRead);
                    bytesRead = await ftpStream.ReadAsync(byteBuffer, 0, bufferSize);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            localFileStream.Close();
            ftpStream.Close();
            ftpResponse.Close();

            return true;
        }, remoteFile, WebRequestMethods.Ftp.UploadFile);
    }

    public async Task Delete(string deleteFile)
    {
        await TryExecute(request => request.GetRequestStreamAsync(), deleteFile, WebRequestMethods.Ftp.DeleteFile);
    }

    public async Task CreateDirectory(string path)
    {
        await TryExecute(request => request.GetRequestStreamAsync(), path, WebRequestMethods.Ftp.MakeDirectory);
    }

    private async Task<T> TryExecute<T>(Func<WebRequest, Task<T>> action, string pathOrFileName, string requestMethod)
    {
        try
        {
            var ftpRequest = (FtpWebRequest)WebRequest.Create(pathOrFileName);
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;
            ftpRequest.Credentials = CreateCredential(pathOrFileName);
            ftpRequest.Method = requestMethod;

            return await action.Invoke(ftpRequest);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{0} - {1}", requestMethod, pathOrFileName);
            return default(T);
        }
    }

    private ICredentials CreateCredential(string fileName)
    {
        fileName = fileName.ToLowerInvariant();
        var ftp = ftpConfigurationSection.GetChildren()
            .FirstOrDefault(x => fileName.StartsWith(x["root"].ToLowerInvariant()));
        if (ftp == null)
            throw new NotImplementedException($"Required FTP config to process the file {fileName}");

        var userName = ftp["userName"];
        var password = ftp["password"];
        logger.LogDebug("NetworkCredential for {0}: {1}/{2}", ftp["root"], userName, password);

        return new NetworkCredential(userName, password);
    }

}