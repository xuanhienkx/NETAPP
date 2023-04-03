using CS.Common;
using CS.CoreApi.Authorization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Std;
using WebApiContrib.Core.Formatter.Protobuf;

namespace CS.CoreApi.Configurations
{
    public static class ConfigurationExtensions
    {
        internal static void AddSecurity(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Service", policy => policy.RequireRole(UserRoleType.Service.ToString()));
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
                        s.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                        {
                            In = "header",
                            Description = "JWT token: Bearer {JWT token from security/auth/login}",
                            Name = "Authorization",
                            Type = "apiKey"
                        });
                        s.SwaggerDoc("v1", new Info
                        {
                            Version = "v1",
                            Title = "C-Soft Api Service",
                            Description = "C-Soft API Swagger",
                            Contact = new Contact
                            {
                                Name = "Nguyen Thanh Vinh",
                                Email = "vinhnt@vics.com.vn",
                                Url = "http://c-soft.vn"
                            },
                            License = new License
                            {
                                Name = "@Copyright, C-Soft 2017",
                                Url = "http://c-soft.vn/LICENSE"
                            }
                        });
                    }
                );
            }
        }

        internal static IMvcBuilder AddWebApi(this IServiceCollection services, IConfigurationRoot config, Action<MvcOptions> setupAction)
        {
            services.AddMvc()
                .AddProtobufFormatters();

            var builder = services.AddMvcCore();
            builder.AddJsonFormatters();
            builder.AddApiExplorer();
            builder.AddCors();
            builder.AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider =
                    (type, factory) => factory.Create("CS.Core.Resource.DataAnotation", "CS.Core.Resource");
            });
            builder.AddFluentValidation(cfg =>
            {
                cfg.LocalizationEnabled = true;
            });
            services.AddSignalR();
            
            var mvcBuilder = new MvcBuilder(builder.Services, builder.PartManager);
            builder.Services.Configure(setupAction);

            return mvcBuilder;
        }

        internal static void AddLocalizer(this IServiceCollection services, IConfigurationRoot config)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("vi"),
            };

            services.AddLocalization();
            // setup localization
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var defaultCulture = config["defaultCulture"];
                if (string.IsNullOrEmpty(defaultCulture) || supportedCultures.All(x => !x.TwoLetterISOLanguageName.Equals(defaultCulture, StringComparison.OrdinalIgnoreCase)))
                    defaultCulture = supportedCultures.First().TwoLetterISOLanguageName;

                options.DefaultRequestCulture = new RequestCulture(culture: defaultCulture, uiCulture: defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new IRequestCultureProvider[]
                {
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });

            // set localiser resources
            DataContractResourceManager.Current.UseResource("CS.Common.Resources.DataContractResources", typeof(LocalizationFactory).Assembly);
        }

        internal static void AddDistributedCache(this IServiceCollection services, IConfigurationRoot config)
        {
            var cacheProvider = config["cache:provider"].ToLowerInvariant();
            if (cacheProvider == "memory")
            {
                Console.WriteLine("DISTRIBUTED CACHE: In Memory");
                services.AddDistributedMemoryCache();
            }
            else if (cacheProvider == "redis")
            {
                services.AddDistributedRedisCache(options =>
                {
                    options.InstanceName = "CSoft";
                    options.Configuration = config["cache:connection"];

                    Console.WriteLine($"DISTRIBUTED CACHE: Redis - {options.Configuration} - instance: {options.InstanceName}");
                });
            }
        }
        
    }
}