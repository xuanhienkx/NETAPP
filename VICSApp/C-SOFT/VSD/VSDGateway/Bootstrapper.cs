using CS.Common;
using CS.Common.Converter;
using CS.Common.Extensions;
using CS.Common.FileTransfer;
using CS.Common.Interfaces;
using CS.SwiftParser;
using CS.SwiftParser.Configuration;
using CS.SwiftParser.MessageBuilder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using CS.Common.Std;

namespace VSDGateway
{
    public static class Bootstrapper
    {
        public static IConfigurationRoot Init(string environment)
        {
            // initialize application settings
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(GlobalConstantsProvider.ApplicationSettingFile, optional: true, reloadOnChange: true);

            if (!string.IsNullOrEmpty(environment))
                builder.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();

            return builder.Build();
        }

        public static void RegisterComponents(IServiceCollection services, IConfigurationRoot config)
        {
            var configFile = Path.Combine(config["gateway:settingPath"], "SwiftSettings.json");
            var swiftSetting = ObjectLoader.FromFile<SwiftSetting>(configFile);
            if (swiftSetting == null)
                throw new ArgumentNullException($"swiftConfig", $"Cannot load swiftsetting from path: {configFile}");

            // register all services
            services.AddSingleton<IConfigurationRoot>(config);
            services.AddSingleton(swiftSetting);
            services.AddSingleton<IFieldConfigurator, FieldConfigurator>();
            services.AddSingleton<IStringEncoder, LatinStringEncode>();
            services.AddSingleton<IGatewayService, GatewayService>();
            services.AddScoped<IValueConverter, NullValueConverter>();
            services.Decorate<IValueConverter>(inner => new TimeValueConverter(inner));
            services.Decorate<IValueConverter>(inner => new DateValueConverter(inner));
            services.Decorate<IValueConverter>(inner => new DecimalValueConverter(inner));
            services.Decorate<IValueConverter>(inner => new NumberValueConverter(inner));
            services.Decorate<IValueConverter>((inner, p) => new StringValueConverter(inner, p.GetService<IStringEncoder>()));

            services.AddSingleton<IMessageConverter, MTMessageConverter>();
            services.AddSingleton<IMessageConverter, ACKNAKMessageConverter>();
            services.AddSingleton<IMessageConverter, FileActMessageConverter>();
            services.AddSingleton<IMessageBuilder, SwiftMessageBuilder>();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFileTransformerProvider, PhysicalFileTransformerProvider>();
            services.AddSingleton<IFileTransformerProvider, FtpFileTransformerProvider>();

            // register all execution task
            services.AddSingleton<IGatewayService, GatewayService>();
            services.AddTransient<IDirectoryObservationService, DirectoryObservationService>();
            services.AddSingleton<ITargetTask, DirectoryObserverTask>();
            services.AddSingleton<ITargetTask, MessageSubscriberTask>();
            services.AddSingleton<GatewayFactory>();
        }
    }
}
