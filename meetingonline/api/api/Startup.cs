using api.common;
using api.common.Settings;
using api.common.Shared;
using api.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using Hangfire;
using IdentityUser = api.common.Models.Identity.IdentityUser;
#pragma warning disable 1591

namespace api
{
    public class Startup
    {
        readonly IConfigurationRoot configuration;
        readonly ApplicationSettings applicationSettings;

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(ProviderConstants.ApplicationSettingsFile, optional: true, reloadOnChange: true);

            Console.Out.WriteLine($"ENVIRONMENT: {env.EnvironmentName} - Is Production: {env.IsProduction()}");

            if (!string.IsNullOrEmpty(env.EnvironmentName))
            {
                var jsonFile = $"appsettings.{env.EnvironmentName}.json";
                Console.Out.WriteLine($" -> configuration file: {jsonFile}");

                builder.AddJsonFile(jsonFile, optional: true);
            }

            builder.AddEnvironmentVariables();

            configuration = builder.Build();
            applicationSettings = configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(configuration);
            services.AddCors(options => options.AddPolicy(ProviderConstants.CorsPolicy, builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader();

                if (applicationSettings.EnableSignalR)
                    builder.WithOrigins(applicationSettings.ClientUrl).AllowCredentials();
                else
                    builder.AllowAnyOrigin();
            }));

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.UseCamelCasing(false);
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // register components to DI
            services.AddComponents(configuration);
            // add logging
            services.AddLogging();
            // add authentication
            services.AddSecurity(applicationSettings.SecuritySettings);
            // add multipart guard
            services.AddMultipartBodyGuard();

            services.AddConnections();
            services.AddSignalR(options =>
            {
                options.KeepAliveInterval = TimeSpan.FromSeconds(5);
            });

            // add swagger
            if (applicationSettings.UseSwagger)
                services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (applicationSettings.UseSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Meeting Online API v1.1");
                });
            }

            // For nginx server
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseCors(ProviderConstants.CorsPolicy);
            app.UseSeedData(userManager);
            app.UseLocalization();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<IdentityUserReadyMiddleware>();

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            //app.UseMiddleware<JwtNonceValidationMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                if (applicationSettings.EnableSignalR)
                    endpoints.MapHub<ApplicationStateHub>(ProviderConstants.WebSocketSegment);

                endpoints.MapControllers();
            });
        }
    }
}
