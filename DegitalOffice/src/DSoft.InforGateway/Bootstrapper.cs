using DO.Common;
using DO.Common.FileTransfer;
using DO.Common.Interfaces;
using DO.MarketParser.Configuration;
using DO.MarketParser.MessageBuilder;
using DSoft.InforGateway.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DSoft.InforGateway
{
    public static class Bootstrapper
    {
        public static void RegisterComponents(IServiceCollection services, IConfiguration config)
        {
            //Config logging
            var logConfig = config.GetSection("Logging");
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole(p => p.LogToStandardErrorThreshold = LogLevel.Debug);
                builder.AddFile(logConfig);
                builder.AddJsonConsole();
                builder.AddDebug();
                builder.SetMinimumLevel(LogLevel.Debug);

            });
            services.AddHttpClient();

            //Config Identity
            services.Configure<IdentityServerSettings>(config.GetSection("IdentityServerSettings"));
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                     .AddOpenIdConnect(
                         OpenIdConnectDefaults.AuthenticationScheme,
                         options =>
                         {
                             options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                             options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
                             options.Authority = config["InteractiveServiceSettings:AuthorityUrl"];
                             options.ClientId = config["InteractiveServiceSettings:ClientId"];
                             options.ClientSecret = config["InteractiveServiceSettings:ClientSecret"];

                             options.ResponseType = "code";
                             options.SaveTokens = true;
                             options.GetClaimsFromUserInfoEndpoint = true;
                         }
                     );

            var configFile = Path.Combine(config["gateway:settingPath"], "PrsSetting.json");
            var prsSetting = ObjectLoader.FromFile<PrsSetting>(configFile);
            if (prsSetting == null)
                throw new ArgumentNullException($"PrsSetting", $"Cannot load swiftsetting from path: {configFile}");
            services.AddSingleton(prsSetting);

            //  register all services

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFileTransformerProvider, PhysicalFileTransformerProvider>();
            services.AddSingleton<IMarketMessageConverter, PrsMessageConverter>();
            services.AddSingleton<IGatewayService, GatewayService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddSingleton<GatewayFactory>();
        }
    }
}
