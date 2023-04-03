using DSoft.Common.Extensions;
using DSoft.Common.Settings;
using DSoft.Common.Shared;
using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Converter;
using DSoft.Common.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace DSoft.Common;
public static class ComponentRegister
{
    public static void Register(IServiceCollection services, IConfigurationRoot configration)
    {
        // configuration
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IPersistentDataProvider, PersistentDataProvider>();
        services.AddSingleton<IWebSocketService, WebSocketService>();
        services.AddHttpContextAccessor();
        services.AddSingleton<ILocalizer, Localizer>();           
        services.AddScoped<IValueConverter, NullValueConverter>();
        services.Decorate<IValueConverter>(inner => new DateValueConverter(inner));
        services.Decorate<IValueConverter>(inner => new TimeValueConverter(inner));
        services.Decorate<IValueConverter>((inner) => new StringValueConverter(inner));
        services.Decorate<IValueConverter>(inner => new NumberValueConverter(inner));
        services.Decorate<IValueConverter>((inner) => new DoubleValueConverter(inner));
        services.Decorate<IValueConverter>(inner => new DecimalValueConverter(inner));
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
            options.RequestCultureProviders = new IRequestCultureProvider[] { new AcceptLanguageHeaderRequestCultureProvider() };
        });

        services.AddSingleton(sp => sp.GetRequiredService<IOptions<ApplicationSettings>>().Value);
        services.AddSingleton<IMemoryCache, MemoryCache>();

        services.AddSingleton<ICipherService, AesCipherService>();


        // configuration
        services.Configure<ApplicationSettings>(configration.GetSection(nameof(ApplicationSettings)));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<ApplicationSettings>>().Value);

    }
}
