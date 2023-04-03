using DSoft.Common.Shared.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DSoft.Common.Shared.Base;

public class ApiProvider
{
    public static void Initialize(
        string baseUriString,
        long bufferSize,
        double timeoutInSecond,
        string contentType,
        Func<string, string> translate)
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
    ApiProvider(string baseUriString,
        long bufferSize,
        double timeoutInSecond,
        string contentType,
        Func<string, string> translate)
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
    public async Task<Result<T>> GetAsync<T>(Func<IApiWebRequest, Task<Result<T>>> execution, Action<Exception> onException)
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

        return new Result<T>
        {
            Errors = new[] { errorMessage }
        };
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

        public async Task<Result<T>> GetAsync<T>(string path, string requestId = null)
        {
            using (var httpClient = httpClientProvider(mediaType))
            {
                if (!string.IsNullOrEmpty(requestId))
                    httpClient.DefaultRequestHeaders.Add(ProviderConstants.RequestId, requestId);

                var response = await httpClient.GetAsync(CleanUpPath(path));
                return await Result<T>(response, mediaType);
            }
        }

        public async Task<Result<IList<T>>> GetListAsync<T>(string path)
        {
            using (var httpClient = httpClientProvider(mediaType))
            {
                var response = await httpClient.GetAsync(CleanUpPath(path));
                return await Result<IList<T>>(response, mediaType);
            }
        }

        public async Task<Result<string>> PostAsync<T>(string path, T content, string requestId = null)
        {
            using (var httpClient = httpClientProvider(mediaType))
            {
                if (!string.IsNullOrEmpty(requestId))
                    httpClient.DefaultRequestHeaders.Add(ProviderConstants.RequestId, requestId);

                var response = await httpClient.PostAsync(CleanUpPath(path), PackContent(content, mediaType));
                return await Result<string>(response, mediaType);
            }
        }

        public async Task<Result<TR>> PostAsync<T, TR>(string path, T content, string requestId = null)
        {
            using (var httpClient = httpClientProvider(mediaType))
            {
                if (!string.IsNullOrEmpty(requestId))
                    httpClient.DefaultRequestHeaders.Add(ProviderConstants.RequestId, requestId);

                var strContent = PackContent(content, mediaType);
                var response = await httpClient.PostAsync(CleanUpPath(path), strContent);
                return await Result<TR>(response, mediaType);
            }
        }

        public async Task<Result<bool>> DeleteAsync(string path, string requestId = null)
        {
            using (var httpClient = httpClientProvider(mediaType))
            {
                if (!string.IsNullOrEmpty(requestId))
                    httpClient.DefaultRequestHeaders.Add(ProviderConstants.RequestId, requestId);

                var response = await httpClient.DeleteAsync(CleanUpPath(path));
                return await Result<bool>(response, mediaType);
            }
        }

        public async Task<Result<TR>> PutAsync<T, TR>(string path, T content, string requestId = null)
        {
            using (var httpClient = httpClientProvider(mediaType))
            {
                if (!string.IsNullOrEmpty(requestId))
                    httpClient.DefaultRequestHeaders.Add(ProviderConstants.RequestId, requestId);

                var response = await httpClient.PutAsync(CleanUpPath(path), PackContent(content, mediaType));
                return await Result<TR>(response, mediaType);
            }
        }

        public async Task<Result<T>> PutAsync<T>(string path, T content, string requestId = null)
        {
            using (var httpClient = httpClientProvider(mediaType))
            {
                if (!string.IsNullOrEmpty(requestId))
                    httpClient.DefaultRequestHeaders.Add(ProviderConstants.RequestId, requestId);

                var response = await httpClient.PutAsync(CleanUpPath(path), PackContent(content, mediaType));
                return await Result<T>(response, mediaType);
            }
        }

        public async Task<Result<T>> PatchAsync<T>(string path, T content, string requestId = null)
        {
            // for patch, it must use json-patch
            using (var httpClient = httpClientProvider("application/json-patch"))
            {
                if (!string.IsNullOrEmpty(requestId))
                    httpClient.DefaultRequestHeaders.Add(ProviderConstants.RequestId, requestId);

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
            // json as default
            var str = JsonConvert.SerializeObject(model);
            return new StringContent(str, Encoding.UTF8, mediaType);
        }

        private static async Task<Result<T>> Result<T>(HttpResponseMessage response, string mediaType)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Json content: {0}", content);
                return JsonConvert.DeserializeObject<Result<T>>(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get result error: {0}", ex.Message);
                return new Result<T>
                {
                    Errors = new[] { response.ReasonPhrase }
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