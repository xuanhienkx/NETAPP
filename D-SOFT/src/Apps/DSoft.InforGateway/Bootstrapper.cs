using DSoft.Common.Shared;
using DSoft.Common.Shared.Interfaces;
using DSoft.InforGateway.Helpers;
using DSoft.InforGateway.Services;
using DSoft.MarketParser;
using DSoft.MarketParser.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace DSoft.InforGateway
{
    public static class Bootstrapper
    {
        public static void RegisterComponents(IServiceCollection services, IConfiguration config)
        {

            services.AddLogging(builder =>
            {
                var logger = new LoggerConfiguration()
                             .ReadFrom.Configuration(config)
                             .Enrich.FromLogContext()
                             .Enrich.With(new SimpleClassEnricher())
                             .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                             .CreateLogger();
                builder.ClearProviders();
                builder.AddSerilog(logger);

            });
            // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);


            //Config Identity
            services.Configure<IdentityServerSettings>(config.GetSection("IdentityServerSettings"));
            services.AddAuthentication();
            services.AddHttpClient("BackendApi", options =>
                    {
                        options.BaseAddress = new Uri(config["CoreApi:apiUrl"]);  
                    })
                    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback =
                           (httpRequestMessage, cert, cetChain, policyErrors) =>
                           {
                               return true;
                           }
                    });
            services.AddDistributedMemoryCache();
             
            //  register all services  
            services.AddSingleton<IDirectoryObservationService, DirectoryObservationService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFileTransformerProvider, PhysicalFileTransformerProvider>();
            services.AddSingleton<IFileTransformerProvider, FtpFileTransformerProvider>();
            services.AddSingleton<IHoseMessageConverter, PrsMessageConverter>();
            services.AddSingleton<IHoseMessageConverter, IndexMessageConverter>();
            services.AddSingleton<IGatewayService, GatewayService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddSingleton<GatewayFactory>();
            // register all execution task                                           
            services.AddSingleton<ITargetTask, HsxMarketObserverTask>();
        }
    }
}
