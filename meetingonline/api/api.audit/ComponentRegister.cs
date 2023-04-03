using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.audit
{
    public static class ComponentRegister
    {
        public static void Register(IServiceCollection services, IConfigurationRoot config)
        {
            // components
            services.AddScoped<IAuditStore, AuditStore>();
            
            // mediatR
            services.AddMediatR(typeof(ComponentRegister).Assembly);
        }
    }
}
