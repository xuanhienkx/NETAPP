using api.common.Models.Identity;
using api.common.Settings;
using api.common.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;

namespace api.common.Shared
{
    public class JwtTokenIssuer : IJwtTokenIssuer
    {
        public const string UserIdClaimType = JwtRegisteredClaimNames.Sid;
        public const string UserRoleClaimType = "role";
        public const string UserNameClaimType = JwtRegisteredClaimNames.UniqueName;
        public const string EmailClaimType = JwtRegisteredClaimNames.Email;
        public const string PhoneClaimType = "tel";

        private readonly ApplicationSettings applicationSettings;
        private readonly IHttpContextAccessor context;
        private readonly ICipherService cipherService;
        private readonly IPersistentDataProvider dataProvider;
        private readonly ILogger<JwtTokenIssuer> logger;

        public JwtTokenIssuer(
            ApplicationSettings applicationSettings, IHttpContextAccessor context, 
            ICipherService cipherService, IPersistentDataProvider dataProvider,
            ILogger<JwtTokenIssuer> logger
            )
        {
            this.applicationSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.cipherService = cipherService ?? throw new ArgumentNullException(nameof(cipherService));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string CreateJwtToken(IdentityUser user, string timestamp)
        {
            var roleClaim = user.Claims.First(x => x.ClaimType == UserRoleClaimType);
            var identityClaims = new List<Claim>()
            {
                new Claim(UserIdClaimType, user.Id),
                new Claim(UserNameClaimType, user.UserName),
                new Claim(roleClaim.ClaimType, roleClaim.ClaimValue)
            };

            //if (user.Email != null)
            //    identityClaims.Add(new Claim(EmailClaimType, user.Email.Value));
            //if (user.PhoneNumber != null)
            //    identityClaims.Add(new Claim(PhoneClaimType, user.PhoneNumber.Value));

            // nonce
            if (applicationSettings.SecuritySettings.RequiredNonceValidation)
            {
                var nonce = CreateNonce(context.HttpContext.Connection, timestamp);
                var cipherKey = cipherService.GenerateCipherKey(user.Id);
                nonce = cipherService.Encrypt(nonce, cipherKey);
                identityClaims.Add(new Claim(JwtRegisteredClaimNames.Nonce, nonce));
            }

            var token = CreateToken(identityClaims, applicationSettings.SecuritySettings);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateNonceToken(ClaimsPrincipal principal, ConnectionInfo connection)
        {
            var userId = principal.Claims.FirstOrDefault(x => x.Type == UserIdClaimType)?.Value;
            if (!dataProvider.TryGet(userId, out Message message))
                return false;

            var nonceClaim = principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Nonce);
            if (nonceClaim == null)
                return false;
            
            var cipherKey = cipherService.GenerateCipherKey(userId);
            var originalNonce = cipherService.Decrypt(nonceClaim.Value, cipherKey);
            var currentNonce = CreateNonce(context.HttpContext.Connection, message.Data);

            logger.LogDebug($"originalNonce: {originalNonce} - currentNonce: {currentNonce} - valid: { originalNonce == currentNonce}");
            return originalNonce == currentNonce;
        }

        private SecurityToken CreateToken(IList<Claim> identityClaims, SecuritySettings settings)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.TokenKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // expiry
            var expiry = applicationSettings.SecuritySettings.ExpiryInHours;
            DateTime? expired = null;
            if (expiry > 0)
            {
                expired = DateTime.UtcNow.AddHours(expiry);
                var endDay = DateTime.UtcNow.AddHours(23).AddMinutes(59).AddSeconds(59);
                if (expired > endDay)
                    expired = endDay;
            }

            return new JwtSecurityToken(
                settings.Issuer,
                settings.Audience,
                identityClaims,
                signingCredentials: credential,
                notBefore: DateTime.UtcNow,
                expires: expired
            );
        }

        private string CreateNonce(ConnectionInfo connection, string timestamp)
        {
            return $"{timestamp}@{connection.RemoteIpAddress.MapToIPv4()}";
        }
    }
}