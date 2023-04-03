using api.common;
using api.common.Settings;
using api.domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api
{
    static class Register
    {
        internal static void AddComponents(this IServiceCollection services, IConfigurationRoot config)
        {
            common.CommonRegister.Register(services, config);

            // register all components from other resources
            resources.ComponentRegister.Register(services, config);
            domain.ComponentRegister.Register(services);
            audit.ComponentRegister.Register(services, config);
        }

        internal static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT"
                });

                // Swagger 2.+ support
                var security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new List<string>()
                    }
                };
                c.AddSecurityRequirement(security);
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Meeting Online API",
                });
                c.DescribeAllParametersInCamelCase();
                c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\api.xml");
            });
        }

        internal static void UseSeedData(this IApplicationBuilder appBuilder, UserManager<IdentityUser> userManager)
        {
            var serviceProvider = appBuilder.ApplicationServices;
            var seedTask = MigrationData.SeedData(
                userManager,
                serviceProvider.GetRequiredService<IConfigurationRoot>().GetSection(ProviderConstants.DomainDatabaseSettings).Get<DatabaseSettings>()
                );

            Task.WaitAll(seedTask);
        }

        internal static void UseLocalization(this IApplicationBuilder app)
        {
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOptions.Value);
        }
    }
}
