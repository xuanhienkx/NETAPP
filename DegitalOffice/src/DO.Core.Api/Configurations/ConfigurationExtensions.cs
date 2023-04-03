using DO.Common;
using DO.Common.Contract;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Models;
using System.Globalization;

namespace DO.Core.Api.Configurations
{
    public static class ConfigurationExtensions
    {
        internal static void AddSecurity(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddAuthentication("Bearer")
                 .AddIdentityServerAuthentication(options =>
             {
                 options.Authority = config["Security.Authority"];
                 options.RequireHttpsMetadata = bool.Parse(config["Security.RequireHttpsMetadata"]);
                 options.ApiName = config["Security.ApiName"];
             });
        }

        internal static void AddSwagger(this IServiceCollection services, IConfigurationRoot config)
        {
            if (bool.TryParse(config["useSwagger"], out bool userSwagger) && userSwagger)
            {
                services.AddSwaggerGen(option =>
                 {
                     option.SwaggerDoc("v1", new OpenApiInfo { Title = "DSoft API", Version = "v1" });
                     option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                     {
                         In = ParameterLocation.Header,
                         Description = "Please enter a valid token",
                         Name = "Authorization",
                         Type = SecuritySchemeType.Http,
                         BearerFormat = "JWT",
                         Scheme = "Bearer"
                     });
                     option.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                 });
                 });
            }
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
            DataContractResourceManager.Current.UseResource("DO.Common.Resources.DataContractResources", typeof(LocalizationFactory).Assembly);
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