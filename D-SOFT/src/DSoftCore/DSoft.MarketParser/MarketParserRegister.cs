using DSoft.Common.Domain.Services;
using DSoft.Common.Shared.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSoft.MarketParser;
public static class MarketParserRegister
{
    public static void Register(IServiceCollection services, IConfigurationRoot configration)
    {
        services.AddScoped<IPersistentService<DomainPersistentService>, DomainPersistentService>();
        // services.AddSingleton<IMarketMessageConverter, PrsMessageConverter>();
        // mediatR
        services.AddMediatR(typeof(MarketParserRegister).Assembly);
    }
}
