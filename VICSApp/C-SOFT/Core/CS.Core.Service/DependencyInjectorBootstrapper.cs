using CS.Common;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Extensions;
using CS.Common.FileTransfer;
using CS.Common.Interfaces;
using CS.Core.Service.Base;
using CS.Domain.Audit.Repositories;
using CS.Domain.Data;
using CS.Domain.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CS.Core.Service
{
    public class DependencyInjectorBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IModelMapperService, ModelMaperService>();
            services.AddSingleton<ICacheService, CacheService>();

            services.AddScoped<IDataFactory, DataContextFactory>();
            services.AddScoped<ICSoftDataContext, CSoftDataContext>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IAuditEventRepository, AuditEventRepository>();
            services.AddScoped<IMessagePublisherFactory, MessagePublisherFactory>();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFileTransformerProvider, PhysicalFileTransformerProvider>();
            services.AddSingleton<IFileTransformerProvider, FtpFileTransformerProvider>();

            var assembly = typeof(DependencyInjectorBootstrapper).Assembly;
            services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("Service"), service => service.IsGenericType);
            services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("CommandBuilder"), service => service.IsGenericType);
            services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("CommandHandler"), service => service.IsGenericType);
            services.AddServices(assembly, Lifetime.Scoped, type => type.Name.EndsWith("CommandValidator"), service => service.IsGenericType);

            assembly = typeof(CustomerSqlRepository).Assembly;
            services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("SqlRepository"), service => !service.IsGenericType);
            //services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("EntityQuery"), service => service.IsInterface);
        }
    }
}
