using System.Collections.Generic;
using Api.Data.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace WebAPI
{
    public static class ConfigurationExtensions
    {
        internal static void AddSecurity(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Service", policy => policy.RequireRole("Service"));
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(JwtRegisteredClaimNames.Sid);
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var security = config.GetSection("security");
                    var audience = security[GlobalConstantsProvider.TokenAudience];
                    var issuer = security[GlobalConstantsProvider.TokenIssuer];
                    var tokenKey = security[GlobalConstantsProvider.TokenKey];

                    options.SaveToken = true;
                    options.ClaimsIssuer = issuer;
                    options.Audience = audience;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtRegisteredClaimNames.Sid,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = audience,

                        ValidateIssuer = true,
                        ValidIssuer = issuer,

                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenKey))
                    };
                    options.Events = new ClaimFilterJwtBearerEvents(tokenKey, security);
                });
        }

        internal static void AddSwagger(this IServiceCollection services, IConfigurationRoot config)
        {
            if (bool.TryParse(config["useSwagger"], out bool userSwagger) && userSwagger)
            {
                services.AddSwaggerGen(s =>
                { 
                    s.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter JWT with Bearer into field",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                    s.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                        { "Bearer", Enumerable.Empty<string>() },
                    });
                    s.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "VICS Api Service",
                        Description = "VICS API Swagger",
                        Contact = new Contact
                        {
                            Name = "VICS",
                            Email = "info@vics.com.vn",
                            Url = "http://vics.vn"
                        },
                        License = new License
                        {
                            Name = "@Copyright, vics 2018",
                            Url = "http://vics.vn/LICENSE"
                        }
                    });
                }
                );
            }
        }
    }

}
