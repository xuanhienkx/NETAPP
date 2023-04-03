using api.common;
using api.common.Settings;
using api.common.Shared.Interfaces;
using api.resources.Services;
using Hangfire;
using Hangfire.Mongo;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;

namespace api.resources
{
    public static class ComponentRegister
    {
        public static void Register(IServiceCollection services, IConfigurationRoot configration)
        {
            // configuration
            services.Configure<EmailProviderSettings>(configration.GetSection(nameof(EmailProviderSettings)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<EmailProviderSettings>>().Value);
            services.AddSingleton<IContentProviderService, ContentProviderService>();
            services.AddSingleton<ILocalizer, Localizer>();

            services.AddScoped<IEmailService, DefaultEmailService>();
            services.AddScoped<IFileService, PhysicLocalFileService>();
            services.AddScoped<ILoadDataService, ReadExcelService>();
            services.AddScoped<IContentTransformerService, ContentTransformerService>();
            
            // mediatR
            services.AddMediatR(typeof(ComponentRegister).Assembly);

            // localization
            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(ProviderConstants.DefaultCulture),
                    new CultureInfo(ProviderConstants.FallbackCulture)
                };
                
                options.DefaultRequestCulture = new RequestCulture(ProviderConstants.DefaultCulture);
                // Formatting numbers, dates, etc.
                options.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new IRequestCultureProvider[] {new AcceptLanguageHeaderRequestCultureProvider()};
            });

            // hangfire
            services.AddHangfire(config =>
            {
                var dbSettings = configration.GetSection(ProviderConstants.HangfireDatabaseSettings)
                    .Get<DatabaseSettings>();
                var migrationOptions = new MongoMigrationOptions
                {
                    MigrationStrategy = new DropMongoMigrationStrategy(),
                    BackupStrategy = new NoneMongoBackupStrategy()
                };

                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
                config.UseSimpleAssemblyNameTypeSerializer();
                config.UseRecommendedSerializerSettings();
                config.UseMongoStorage($"{dbSettings.ConnectionString}/{dbSettings.DatabaseName}", new MongoStorageOptions {   MigrationOptions = migrationOptions });

            });
            services.AddHangfireServer();
        }
    }
}
