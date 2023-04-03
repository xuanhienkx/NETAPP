using IdentityServer4.Models;
namespace ServerAuthorization;

public class Config
{

    public static IEnumerable<IdentityResource> IdentityResources =>
        new[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string> { "role" }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new[] {
            new ApiScope("DSoftAPI.read"),
            new ApiScope("DSoftAPI.write")
        };
    public static IEnumerable<ApiResource> ApiResources =>
        new[]
        {
            new ApiResource("DSoftAPI")
            {
                Scopes = new List<string> { "DSoftAPI.read", "DSoftAPI.write" },
                ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                UserClaims = new List<string> { "role" }
            }
        };

    public static IEnumerable<Client> Clients =>
        new[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "DO.InfoGateway",
                ClientName = "InfoGateway",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("InfoGatewayClientSecret".Sha256()) },
                AllowedScopes = { "DSoftAPI.read", "DSoftAPI.write" }
            },
            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("interactiveClientSecret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5444/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:5444/signout-callback-oidc" },
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "DSoftAPI.read" },
                RequirePkce = true,
                RequireConsent = true,
                AllowPlainTextPkce = false
            }
        };
}
