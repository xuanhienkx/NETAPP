using CS.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using CS.Common.MessageQueue;

namespace CS.VSD.Service
{
    public static class DependencyInjectorBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            Debug.WriteLine("Registering components for VSD gateway service");

            var assembly = typeof(IBusinessActionHandler).Assembly;

            services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("ActionHandler"), service => service.IsInterface);
            services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("Service"), service => service.IsInterface);

            services.AddTransient<IMessagePublisher, VsdMessagePublisher>();
        }
    }
}
