using DSoft.Common.Extensions;
using DSoft.Common.Shared;
using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DSoft.InforGateway.Services
{
    public abstract class BaseService
    {
        protected readonly IHttpClientFactory httpClientFactory;   
        protected bool IsAuthen = false;
        protected ILogger<BaseService> Logger;
        HttpClient Client;   

        protected BaseService(IHttpClientFactory httpClientFactory,
            ITokenService tokenService, ILogger<BaseService> logger)
        {
            if (tokenService is null)
            {
                throw new ArgumentNullException(nameof(tokenService));
            }   
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Client = httpClientFactory.CreateClient("BackendApi");
            var tokenResponse =  tokenService.GetToken().Result;  
            Client.SetBearerToken(tokenResponse.AccessToken);
        }


        public async Task<Result<T>> GetAsync<T>(string url, bool isSecuredServie = false)
        {
           
            return await Client.GetFromJsonAsync<Result<T>>(url, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }

       
        public async Task<Result<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest requestContent, bool isSecuredServie = true)
        {

            var result = await Executor.TryAsync(async () =>
                {
                    
                    StringContent httpContent = null;
                    if (requestContent != null)
                    {
                        var json = JsonSerializer.Serialize(requestContent);
                        httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    }

                    var response = await Client.PostAsync(url, httpContent);
                    var body = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return JsonSerializer.Deserialize<Result<TResponse>>(body, new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true 
                        });
                    }

                    return new Result<TResponse>()
                    {                                             
                        Errors = new[] { $"Eror: {response.StatusCode} -{response.EnsureSuccessStatusCode} -{response.ReasonPhrase}" }
                    };

                },
                e => Logger.LogError("Api Error [{0}]", e.Message));
            return result;

        }

        public async Task<Result<bool>> PutAsync<TRequest, TResponse>(string url, TRequest requestContent, bool isSecuredServie = true)
        {
            
            HttpContent httpContent = null;
            if (requestContent != null)
            {
                var json = JsonSerializer.Serialize(requestContent);
                httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            }
            var response = await Client.PutAsJsonAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Result<bool>>(body, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
