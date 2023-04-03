using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DO.Common.Std
{
    public interface IApiWebRequest
    {
        Task<RequestResult<string>> PostAsync<T>(string path, T content, string requestId = null);
        Task<RequestResult<TR>> PostAsync<T, TR>(string path, T content, string requestId = null);
        Task<RequestResult<T>> GetAsync<T>(string path, string requestId = null);
        Task<RequestResult<IList<T>>> GetListAsync<T>(string path);
        Task<RequestResult<bool>> DeleteAsync(string path, string requestId = null);
        Task<RequestResult<TR>> PutAsync<T, TR>(string path, T content, string requestId = null);
        Task<RequestResult<T>> PutAsync<T>(string path, T content, string requestId = null);
        Task<RequestResult<T>> PatchAsync<T>(string path, T content, string requestId = null);
    }

    public class ApiProvider
    {
        public static void Initialize(string baseUriString, long bufferSize, double timeoutInSecond, string contentType, Func<string, string> translate)
        {
            Instance = new ApiProvider(baseUriString, bufferSize, timeoutInSecond, contentType, translate);
        }
        public static ApiProvider Instance { get; private set; }

        public string AuthenticationToken { get; private set; }
        public Uri BaseUri { get; }

        private readonly double timeoutInSecond;
        private readonly string contentType;
        private readonly long bufferSize;
        private readonly Func<string, string> translate;

        ApiProvider(string baseUriString, long bufferSize, double timeoutInSecond, string contentType, Func<string, string> translate)
        {
            BaseUri = new Uri(baseUriString);
            this.bufferSize = bufferSize;
            this.timeoutInSecond = timeoutInSecond;
            this.contentType = contentType;
            this.translate = translate;
        }

        public void SetToken(string token)
        {
            AuthenticationToken = token;
        }

        public async Task<RequestResult<T>> GetAsync<T>(Func<IApiWebRequest, Task<RequestResult<T>>> execution, Action<Exception> onException)
        {
            string errorMessage;
            try
            {
                return await execution(new ApiWebRequest(CreateHttpClient, contentType));
            }
            catch (JsonReaderException jEx)
            {
                onException?.Invoke(jEx);
                errorMessage = translate("ApiProvider_JsonReaderException");
            }
            catch (HttpRequestException httpEx)
            {
                onException?.Invoke(httpEx);
                errorMessage = $"{translate("ApiProvider_HttpRequestException")} {httpEx.InnerException?.Message}";
            }
            catch (Exception eX)
            {
                onException?.Invoke(eX);
                errorMessage = translate("ApiProvider_Exception");
            }

            return new RequestResult<T>
            {
                ErrorMessages = new[] { errorMessage }
            };
        }

        public async Task Download(string file, string toLocalFile, Action<AsyncCompletedEventArgs> action)
        {
            using (var webClient = new WebClient())
            {
                var handler = new AsyncCompletedEventHandler((sender, args) => action?.Invoke(args));

                webClient.Headers.Add("Authorization", $"Bearer {AuthenticationToken}");
                webClient.DownloadFileCompleted += handler;

                var url = new Uri(BaseUri, file);
                await webClient.DownloadFileTaskAsync(url, toLocalFile);

                webClient.DownloadFileCompleted -= handler;
            }
        }

        public void Download(string file, Action<DownloadDataCompletedEventArgs> action)
        {
            using (var webClient = new WebClient())
            {
                var handler = new DownloadDataCompletedEventHandler((sender, args) =>
                {
                    action?.Invoke(args);
                });

                webClient.Headers.Add("Authorization", $"Bearer {AuthenticationToken}");
                webClient.DownloadDataCompleted += handler;

                var url = new Uri(BaseUri, file);
                webClient.DownloadDataAsync(url);
                webClient.DownloadDataCompleted -= handler;
            }
        }

        private HttpClient CreateHttpClient(string mediaContentType = null)
        {
            var httpClient = new HttpClient { BaseAddress = BaseUri };

            if (!string.IsNullOrEmpty(AuthenticationToken))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaContentType ?? contentType));
            httpClient.DefaultRequestHeaders.Add("Accept-Language", System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(DeviceInfo.Instance.Value.DeviceDetail);
            httpClient.MaxResponseContentBufferSize = bufferSize;
            httpClient.Timeout = TimeSpan.FromSeconds(timeoutInSecond);

            return httpClient;
        }

        #region WebApi helper

        class ApiWebRequest : IApiWebRequest
        {
            private readonly Func<string, HttpClient> httpClientProvider;
            private readonly string mediaType;

            public ApiWebRequest(Func<string, HttpClient> httpClientProvider, string mediaType)
            {
                this.httpClientProvider = httpClientProvider;
                this.mediaType = mediaType;
            }

            public async Task<RequestResult<T>> GetAsync<T>(string path, string requestId = null)
            {
                using (var httpClient = httpClientProvider(mediaType))
                {
                    if (!string.IsNullOrEmpty(requestId))
                        httpClient.DefaultRequestHeaders.Add(GlobalConstantsProvider.RequestId, requestId);

                    var response = await httpClient.GetAsync(CleanUpPath(path));
                    return await Result<T>(response, mediaType);
                }
            }

            public async Task<RequestResult<IList<T>>> GetListAsync<T>(string path)
            {
                using (var httpClient = httpClientProvider(mediaType))
                {
                    var response = await httpClient.GetAsync(CleanUpPath(path));
                    return await Result<IList<T>>(response, mediaType);
                }
            }

            public async Task<RequestResult<string>> PostAsync<T>(string path, T content, string requestId = null)
            {
                using (var httpClient = httpClientProvider(mediaType))
                {
                    if (!string.IsNullOrEmpty(requestId))
                        httpClient.DefaultRequestHeaders.Add(GlobalConstantsProvider.RequestId, requestId);

                    var response = await httpClient.PostAsync(CleanUpPath(path), PackContent(content, mediaType));
                    return await Result<string>(response, mediaType);
                }
            }

            public async Task<RequestResult<TR>> PostAsync<T, TR>(string path, T content, string requestId = null)
            {
                using (var httpClient = httpClientProvider(mediaType))
                {
                    if (!string.IsNullOrEmpty(requestId))
                        httpClient.DefaultRequestHeaders.Add(GlobalConstantsProvider.RequestId, requestId);

                    var response = await httpClient.PostAsync(CleanUpPath(path), PackContent(content, mediaType));
                    return await Result<TR>(response, mediaType);
                }
            }

            public async Task<RequestResult<bool>> DeleteAsync(string path, string requestId = null)
            {
                using (var httpClient = httpClientProvider(mediaType))
                {
                    if (!string.IsNullOrEmpty(requestId))
                        httpClient.DefaultRequestHeaders.Add(GlobalConstantsProvider.RequestId, requestId);

                    var response = await httpClient.DeleteAsync(CleanUpPath(path));
                    return await Result<bool>(response, mediaType);
                }
            }

            public async Task<RequestResult<TR>> PutAsync<T, TR>(string path, T content, string requestId = null)
            {
                using (var httpClient = httpClientProvider(mediaType))
                {
                    if (!string.IsNullOrEmpty(requestId))
                        httpClient.DefaultRequestHeaders.Add(GlobalConstantsProvider.RequestId, requestId);

                    var response = await httpClient.PutAsync(CleanUpPath(path), PackContent(content, mediaType));
                    return await Result<TR>(response, mediaType);
                }
            }

            public async Task<RequestResult<T>> PutAsync<T>(string path, T content, string requestId = null)
            {
                using (var httpClient = httpClientProvider(mediaType))
                {
                    if (!string.IsNullOrEmpty(requestId))
                        httpClient.DefaultRequestHeaders.Add(GlobalConstantsProvider.RequestId, requestId);

                    var response = await httpClient.PutAsync(CleanUpPath(path), PackContent(content, mediaType));
                    return await Result<T>(response, mediaType);
                }
            }

            public async Task<RequestResult<T>> PatchAsync<T>(string path, T content, string requestId = null)
            {
                // for patch, it must use json-patch
                using (var httpClient = httpClientProvider("application/json-patch"))
                {
                    if (!string.IsNullOrEmpty(requestId))
                        httpClient.DefaultRequestHeaders.Add(GlobalConstantsProvider.RequestId, requestId);

                    var response = await httpClient.SendAsync(new HttpRequestMessage
                    {
                        Method = new HttpMethod("PATCH"),
                        RequestUri = new Uri(CleanUpPath(path), UriKind.RelativeOrAbsolute),
                        Content = PackContent(content, mediaType)
                    });

                    return await Result<T>(response, mediaType);
                }
            }

            private static HttpContent PackContent<T>(T model, string mediaType)
            {
                if (mediaType.Contains("protobuf"))
                {
                    using (var stream = new MemoryStream())
                    {
                        ProtoBuf.Serializer.Serialize(stream, model);

                        return new ByteArrayContent(stream.ToArray());
                    }
                }
                // json as default
                return new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, mediaType);
            }

            private static async Task<RequestResult<T>> Result<T>(HttpResponseMessage response, string mediaType)
            {
                try
                {
                    if (mediaType.Contains("protobuf"))
                    {
                        var content = await response.Content.ReadAsStreamAsync();
                        return ProtoBuf.Serializer.Deserialize<RequestResult<T>>(content);
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Json content: {0}", content);
                        return JsonConvert.DeserializeObject<RequestResult<T>>(content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Get result error: {0}", ex.Message);
                    return new RequestResult<T>
                    {
                        ErrorMessages = new[] { response.ReasonPhrase }
                    };
                }
            }

            private static string CleanUpPath(string path)
            {
                return path.Trim('/', '\\');
            }
        }

        #endregion
    }
}
