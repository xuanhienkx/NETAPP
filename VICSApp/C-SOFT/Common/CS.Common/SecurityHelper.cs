using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Security.Principal;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Std;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CS.Common
{
    public static class SecurityHelper
    {
        private const string DefaultSecrect = "92afc6b0-9557-4476-93e4-c96dee4fec8a";
        public static string CreateCryptoToken(string source, string secret)
        {
            secret = secret ?? DefaultSecrect;
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(source);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        public static bool ValidateNonceToken(ClaimsPrincipal principal, ConnectionInfo connection, string tokenKey, IConfigurationSection configuration)
        {
            var nonceClaim = principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Nonce);
            if (nonceClaim == null)
                return false;

            var nonce = principal.IsInRole(UserRoleType.Service)
                ? CreateCryptoToken(configuration[GlobalConstantsProvider.ServiceSecrectKey], tokenKey)
                : CreateNonce(connection, tokenKey);

            return nonceClaim.Value == nonce;
        }

        public static SecurityToken CreateToken(IList<Claim> identityClaims, ConnectionInfo connection, IConfigurationSection section)
        {
            var tokeyKey = section[GlobalConstantsProvider.TokenKey];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokeyKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            if (connection != null)
                identityClaims.Add(new Claim(JwtRegisteredClaimNames.Nonce, CreateNonce(connection, tokeyKey)));

            if (!int.TryParse(section[GlobalConstantsProvider.TokenExpiryInHours], out var expiry))
                expiry = 8;

            var expired = DateTime.MaxValue;
            if (expiry > 0)
            {
                expired = DateTime.UtcNow.AddHours(expiry);
                var endDay = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
                if (expired > endDay)
                    expired = endDay;
            }


            return new JwtSecurityToken(
                issuer: section[GlobalConstantsProvider.TokenIssuer],
                audience: section[GlobalConstantsProvider.TokenAudience],
                claims: identityClaims,
                signingCredentials: creds,
                notBefore: DateTime.UtcNow,
                expires: expired
            );
        }

        public static string GenerateServiceToken(IConfigurationSection section)
        {
            var tokeyKey = section[GlobalConstantsProvider.TokenKey];
            var serviceKey = section[GlobalConstantsProvider.ServiceSecrectKey];
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Role, UserRoleType.Service.ToString()),
                new Claim(JwtRegisteredClaimNames.Nonce, CreateCryptoToken(serviceKey, tokeyKey))
            };
            var token = CreateToken(claims, null, section);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string CreateNonce(ConnectionInfo connection, string tokeyKey)
        {
            var connectionAddress = $"{connection.LocalIpAddress}:{connection.RemoteIpAddress}";
            return CreateCryptoToken(connectionAddress, tokeyKey);
        }

        public static Guid? GetUserId(this IPrincipal principal)
        {
            if (!principal.Identity.IsAuthenticated || principal.IsInRole(UserRoleType.Service))
                return null;
            return new Guid(principal.Identity.Name);
        }
    }
}
