using DO.Common;
using DO.Common.Domain.Interfaces;
using DO.Common.Extensions;
using DO.Common.FileTransfer;
using DO.Common.Interfaces;
using DO.Core.Service.Base;
using Microsoft.Extensions.DependencyInjection;

namespace DO.Core.Service;

public class DependencyInjectorBootstrapper
{
    public static void Register(IServiceCollection services)
    {
        services.AddSingleton<IModelMapperService, ModelMaperService>();
        services.AddSingleton<ICacheService, CacheService>();


        services.AddScoped<IValidationService, ValidationService>();


        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IFileTransformerProvider, PhysicalFileTransformerProvider>();
        services.AddSingleton<IFileTransformerProvider, FtpFileTransformerProvider>();

        var assembly = typeof(DependencyInjectorBootstrapper).Assembly;
        services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("Service"), service => service.IsGenericType);
        services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("CommandBuilder"), service => service.IsGenericType);
        services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("CommandHandler"), service => service.IsGenericType);
        services.AddServices(assembly, Lifetime.Scoped, type => type.Name.EndsWith("CommandValidator"), service => service.IsGenericType);

        // assembly = typeof(GroupSqlRepository).Assembly;
        services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("SqlRepository"), service => !service.IsGenericType);
        services.AddServices(assembly, Lifetime.Transient, type => type.Name.EndsWith("EntityQuery"), service => service.IsInterface);
    }
}
