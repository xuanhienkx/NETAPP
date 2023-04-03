using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BO.Core.DataCommon.Shared.Interfaces
{
    public interface IJwtTokenIssuer
    {
        // string CreateJwtToken(IdentityUser user, string timestamp);
        bool ValidateNonceToken(ClaimsPrincipal user, ConnectionInfo connection);
    }
}