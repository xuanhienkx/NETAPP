using DSoft.Common.Extensions;
using DSoft.InforGateway.Helpers;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DSoft.InforGateway.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> identityServerSettings;
        private readonly ILogger<TokenService> logger;
        public DiscoveryDocumentResponse discoveryDocument;

        public TokenService(IOptions<IdentityServerSettings> identityServerSettings, ILogger<TokenService> logger )
        {
            this.identityServerSettings = identityServerSettings ?? throw new ArgumentNullException(nameof(identityServerSettings));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TokenResponse> GetToken()
        {

            HttpClient httpClient = new HttpClient();
            Executor.Try(() =>
            {
                discoveryDocument = httpClient.GetDiscoveryDocumentAsync(this.identityServerSettings.Value.DiscoveryUrl).Result;

            },
           (e) => logger.LogError("Unable to get discovery document {0}", discoveryDocument.Exception));

             return await Executor.TryAsync(
                    async () =>
                    {
                        var clientRequets = new ClientCredentialsTokenRequest
                        {
                            Address = discoveryDocument.TokenEndpoint,
                            ClientId = identityServerSettings.Value.ClientId,
                            ClientSecret = identityServerSettings.Value.ClientPassword,
                            Scope = identityServerSettings.Value.Scope
                        };

                        var rs = await httpClient.RequestClientCredentialsTokenAsync(clientRequets);
                        logger.LogInformation("Token :{0}", rs.AccessToken);
                        return rs;
                    }, (e) => new Exception(e.StackTrace), true);

        }
    }
}
