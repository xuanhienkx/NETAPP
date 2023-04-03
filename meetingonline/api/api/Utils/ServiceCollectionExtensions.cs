using api.common;
using api.common.Settings;
using api.common.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable 1591

namespace api.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSecurity(this IServiceCollection services, SecuritySettings settings)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(JwtTokenIssuer.UserNameClaimType);
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var audience = settings.Audience;
                    var issuer = settings.Issuer;
                    var tokenKey = settings.TokenKey;

                    options.SaveToken = true;
                    options.ClaimsIssuer = issuer;
                    options.Audience = audience;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtTokenIssuer.UserNameClaimType,
                        RoleClaimType = JwtTokenIssuer.UserRoleClaimType,
                        
                        ValidateAudience = !string.IsNullOrEmpty(audience),
                        ValidAudience = audience,

                        ValidateIssuer = !string.IsNullOrEmpty(issuer),
                        ValidIssuer = issuer,

                        ValidateLifetime = settings.ExpiryInHours > 0,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query[ProviderConstants.MessageAccessToken];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments(ProviderConstants.WebSocketSegment)))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            // user login
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = ProviderConstants.AllowUserNameCharacters;
                options.User.RequireUniqueEmail = true;
            });

            // bson conversation
            ConventionRegistry.Register("EnumStringConvention", new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            }, t => true);
        }

        public static void AddMultipartBodyGuard(this IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                // Set the limit to 50 MB
                options.MultipartBodyLengthLimit = 52428800;
            });
        }
    }
}