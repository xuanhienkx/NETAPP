using IdentityServer4.Models;
namespace DSoft.Authen.Configuration;
public class IdentityData
{
    public List<Role> Roles { get; set; }
    public List<User> Users { get; set; }
}
public class Role
{
    public string Name { get; set; }
    public List<Claim> Claims { get; set; } = new List<Claim>();
}
public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Claim> Claims { get; set; } = new List<Claim>();
    public List<string> Roles { get; set; } = new List<string>();
}
public class Claim
{
    public string Type { get; set; }
    public string Value { get; set; }
}
public class Client : global::IdentityServer4.Models.Client
{
    public List<Claim> ClientClaims { get; set; } = new List<Claim>();
}
public class IdentityServerData
{
    public List<Client> Clients { get; set; } = new List<Client>();
    public List<IdentityResource> IdentityResources { get; set; } = new List<IdentityResource>();
    public List<ApiResource> ApiResources { get; set; } = new List<ApiResource>();
    public List<ApiScope> ApiScopes { get; set; } = new List<ApiScope>();
}
