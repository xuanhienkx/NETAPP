using DSoft.InforGateway.Services;
using IdentityModel.Client;

namespace DSoft.InforGateway.Helpers
{
    public class OperationLogger
    {
        private readonly ITokenService tokenService;
        public OperationLogger(ITokenService tokenService)
        {
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        public async Task<TokenResponse> GetToken()
        {
            var tokenResponse = await tokenService.GetToken("DSoft.read");
            return tokenResponse;
        }
    }
}
