using System.Security.Claims;
using api.common.Models.Identity;
using Microsoft.AspNetCore.Http;

namespace api.common.Shared.Interfaces
{
    public interface IJwtTokenIssuer
    {
        string CreateJwtToken(IdentityUser user, string timestamp);
        bool ValidateNonceToken(ClaimsPrincipal user, ConnectionInfo connection);
    }
}