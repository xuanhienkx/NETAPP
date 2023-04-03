using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Data.Core;
using Api.Data.Models;
using Api.Data.SBSModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace WebAPI
{
    public class Startup
    {
        readonly IConfigurationRoot config;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(GlobalConstantsProvider.ApplicationSettingFile, optional: true, reloadOnChange: true);

            if (!string.IsNullOrEmpty(env.EnvironmentName))
                builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();

            config = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(config);

            services.AddScoped<IStockInfoRepository, StockInfoRepository>();

            // Add cors
            services.AddCors();
            services.AddMvc();

            // add swagger
            services.AddSwagger(config);
            // Add authentication
            services.AddSecurity(config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            if (bool.TryParse(config["useSwagger"], out bool userSwagger) && userSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    var appRoot = config["applicationRoot"];
                    var schemaUrl = string.IsNullOrEmpty(appRoot)
                        ? "/swagger/v1/swagger.json"
                        : $"/{appRoot}/swagger/v1/swagger.json";
                    s.SwaggerEndpoint(schemaUrl, "ExternalServices API v1.1");
                });
            }
        }
    }
}
