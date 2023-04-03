using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace DSoft.InforGateway.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> identityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocument;

        public TokenService(IOptions<IdentityServerSettings> identityServerSettings, HttpClient httpClient)
        {
            this.identityServerSettings = identityServerSettings ?? throw new ArgumentNullException(nameof(identityServerSettings));
            discoveryDocument = httpClient.GetDiscoveryDocumentAsync(this.identityServerSettings.Value.DiscoveryUrl).Result;

            if (discoveryDocument.IsError)
            {
                throw new Exception("Unable to get discovery document", discoveryDocument.Exception);
            }

        }
        public async Task<TokenResponse> GetToken(string scope)
        {
            var clientRequets = new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = identityServerSettings.Value.ClientId,
                ClientSecret = identityServerSettings.Value.ClientPassword,
                Scope = scope
            };
            var httpClient = new HttpClient();
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(clientRequets);

            if (tokenResponse.IsError)
            {
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse;
        }
    }
}
