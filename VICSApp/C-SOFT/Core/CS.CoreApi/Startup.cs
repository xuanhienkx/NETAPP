using AutoMapper;
using CS.Common;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.CoreApi.Configurations;
using CS.Domain.Audit;
using CS.Domain.Data;
using CS.Domain.Identity;
using CS.Domain.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using CS.Common.Contract;
using CS.Common.Std;
using CS.Common.Std.Extensions;

namespace CS.CoreApi
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
            services.AddDbContext<CSoftDataContext>(
                opt => opt.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning)));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 3;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.User.AllowedUserNameCharacters =
                            @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    })
                .AddEntityFrameworkStores<IdentityLoginDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<CSoftDataContext>();
            services.AddScoped<IdentityLoginDbContext>();
            services.AddScoped<AuditDbContext>();

            // db initializer
            services.AddTransient<IDbInitializer, CSoftDataInitializer>();
            services.AddTransient<IDbInitializer, IdentityLoginDataInitializer>();
            services.AddTransient<IDbInitializer, AuditDataInitializer>();

            // add distributed cached
            services.AddDistributedCache(config);

            // add localizer
            services.AddLocalizer(config);

            // Add MVC with api
            services.AddWebApi(config, options =>
                {
                    var apiVersion = config["apiVersion"].Trim('/');
                    apiVersion = string.IsNullOrEmpty(apiVersion) ? apiVersion : $"/{apiVersion}";
                    options.UseCentralRoutePrefix(new RouteAttribute($"api{apiVersion}"));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            // add swagger
            services.AddSwagger(config);

            // Add auto mapper
            services.AddAutoMapper();

            // Add MediaR
            services.AddMediatR();

            // Add SignalR
            services.AddSignalR();

            // Add authentication
            services.AddSecurity(config);

            // Register all commponents
            Executor.Try(
                () => RegisterAllComponents(services),
                exception => Debug.WriteLine($"[REGISTER] FAILED: {exception}"),
                true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IEnumerable<IDbInitializer> dbInitializers)
        {
            loggerFactory.AddFile(config.GetSection("Logging"));
            
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRequestLocalization();
            app.UseSignalR(builder => builder.MapHub<NotificationHub>(NotificationHub.ProxyName));
            app.UseMvc();

            if (bool.TryParse(config["useSwagger"], out bool userSwagger) && userSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "C-Soft API v1.1");
                    s.ShowRequestHeaders();
                });
            }

            await DataContextInitilizer.Init(app.ApplicationServices, dbInitializers);
        }

        private void RegisterAllComponents(IServiceCollection services)
        {
            Register(() =>
            {
                services.AddSingleton<IStringLocalizerFactory, LocalizationFactory>();
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                // register all repositories
                Core.Service.DependencyInjectorBootstrapper.Register(services);

                // register VSD gateway service
                VSD.Service.DependencyInjectorBootstrapper.Register(services);

                // register ApI core services
                services.AddScoped<IDomainDataHandler, DomainDataHandler>();
                services.AddSingleton(Mapper.Configuration);
                services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

                services.AddScoped<IMediator, Mediator>();
                services.AddTransient<SingleInstanceFactory>(sp => sp.GetService);
                services.AddTransient<IApplicationUserAccessor, ApplicationUserAccessor>();
                services.AddTransient<IUserIdentityService, UserIdentityService>();

                services.AddSingleton<INotificationPublisher, NotificationPublisher>();

                //domain event
                services.AddScoped<IDomainEventHandler<NotificationMessage>, DomainEventNotificationHandler>();
            });
        }

        private static void Register(Action register)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            register();

            stopWatch.Stop();
            Debug.WriteLine("[REGISTER] Finished in {0} ms", stopWatch.ElapsedMilliseconds);
        }
    }
}
