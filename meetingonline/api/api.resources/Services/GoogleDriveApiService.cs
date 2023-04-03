//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Drive.v3.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using System.IO;
//using System.Threading.Tasks;
//using api.common.Shared;
//using api.common.Shared.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using File = Google.Apis.Drive.v3.Data.File;

//namespace api.resources.Services
//{
//    public class GoogleDriveApiService : IFileUploadService
//    {
//        private readonly ICurrentUser currentUser;
//        private readonly ILogger<GoogleDriveApiService> logger;

//        public GoogleDriveApiService(ICurrentUser currentUser, ILogger<GoogleDriveApiService> logger)
//        {
//            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
//            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
//        }

//        public async Task<string> Upload(byte[] content, string contentType, CancellationToken cancellationToken)
//        {
//            using var service = CreateService(360);
//            await using var stream = new MemoryStream(content);

//            var file = new File()
//            {
//                DriveId = "1HCKrSgIB_ONHw6dtTtLoNIoJ1KVeEifv",
//            };
//            var request = service.Files.Create(file, stream, contentType);
//            var result = await request.UploadAsync(cancellationToken);
//            logger.LogDebug($"Upload {result.Status} bytes: {result.BytesSent} - file id: {file.Id}");
//            return file.Id;
//        }

//        public async Task<List<string>> Upload(List<IFormFile> files, CancellationToken cancellationToken)
//        {
//            using var service = CreateService(360);
//            var result = new List<string>();
//            foreach (var file in files)
//            {
//                await using var stream = new MemoryStream();
//                await file.CopyToAsync(stream, cancellationToken);

//                var gfile = new File()
//                {
//                    DriveId = "1HCKrSgIB_ONHw6dtTtLoNIoJ1KVeEifv",
//                };
//                var request = service.Files.Create(gfile, stream, file.ContentType);
//                var rResult = await request.UploadAsync(cancellationToken);

//                result.Add(gfile.Id);
//                logger.LogDebug($"Upload {rResult.Status} bytes: {rResult.BytesSent} - file id: {gfile.Id}");
//            }

//            return result;
//        }


//        private DriveService CreateService(int secondTimeout)
//        {
//            string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile };
//            var clientId = "1039737655298-naspqnlq9qmp01aaojmqf7o7399hmphg.apps.googleusercontent.com";
//            var clientSecret = "05ARbhRxx1zdMvboJAtXLt-U";
//             here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
//            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
//            {
//                ClientId = clientId,
//                ClientSecret = clientSecret
//            },
//                scopes,
//                Environment.UserName,
//                CancellationToken.None,
//                new FileDataStore("google-drive.token.json", true)).Result;

//            Once consent is received, your token will be stored locally on the AppData directory, so that next time you won't be prompted for consent. 
//            return new DriveService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = "Meeting Online",
//            })
//            { HttpClient = { Timeout = TimeSpan.FromSeconds(secondTimeout) } };

//        }

//        private static string GetMimeType(string fileName)
//        {
//            string mimeType = "application/unknown";
//            string ext = System.IO.Path.GetExtension(fileName).ToLower();
//            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
//            if (regKey != null && regKey.GetValue("Content Type") != null)
//                mimeType = regKey.GetValue("Content Type").ToString();
//            return mimeType;
//        }
//    }
//}
