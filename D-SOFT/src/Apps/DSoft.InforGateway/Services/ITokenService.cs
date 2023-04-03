using IdentityModel.Client;

namespace DSoft.InforGateway.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken();
    }
}
