using DO.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Market.Service;

public static class DependencyInjectorBootstrapper
{
    public static void Register(IServiceCollection services)
    {
        Debug.WriteLine("Registering components for Market info gateway service");

        var assembly = typeof(IBusinessActionHandler).Assembly;

        services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("ActionHandler"), service => service.IsInterface);
        services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("Service"), service => service.IsInterface);

        //  services.AddTransient<IMessagePublisher, MessagePublisher>();
    }
}
