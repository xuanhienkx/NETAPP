using IdentityServer4.Models;

namespace DSoft.Authen;

public class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResources.Address(),
            new IdentityResource
            {
                Name = "role",
                Enabled = true,
                DisplayName = "Roles",
                UserClaims = new List<string> { "role" }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new[] {                                              
            new ApiScope("DSoftApi","DSoftApi"),
            new ApiScope("DSoftApi.Read","DSoftApi Read"),
            new ApiScope("DSoftApi.Write","DSoftApi Write")
        };
    public static IEnumerable<ApiResource> ApiResources =>
        new[]
        {
            new ApiResource("DSoftApi")
            {
                Scopes = new List<string> { "DSoftApi","DSoftApi.Read", "DSoftApi.Write" },
                ApiSecrets = new List<Secret> { new Secret("DSoftApi".Sha256()) },
                Enabled =true,
                UserClaims = new List<string> { "role" }
            }
        };

    public static IEnumerable<Client> Clients =>
        new[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "dsoft_info_gateway",
                ClientName = "DSoft Info Gateway",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("dsoft_info_gateway".Sha256()) },
                AllowedScopes = { "DSoftApi" }
            },
             // m2m client credentials flow client
            new Client
            {
                ClientId = "dsoft_info_client_machain",
                ClientName = "DSoft Info Client GET",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("dsoft_info_client_machain".Sha256()) },
                AllowedScopes = { "DSoftApi.Read" }
            }
        };
}
