using DO.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace DO.Common.Extensions;
public enum Lifetime
{
    Transient,
    Scoped,
    Singleton
}
public static class ServiceCollectionExtensions
{
    public static void ConfigureWritable<T>(
        this IServiceCollection services,
        string sectionName,
        string rootPath,
        string file) where T : class, new()
    {
        services.AddTransient<IWritableOptions<T>>(provider =>
        {
            var options = provider.GetService<IOptionsMonitor<T>>();
            return new WritableOptions<T>(options, sectionName, rootPath, file);
        });
    }

    public static IServiceCollection AddServices(this IServiceCollection services, Assembly assembly, Lifetime lifetime, Func<Type, bool> classFilter, Func<Type, bool> serviceFilter = null)
    {
        Console.WriteLine($"[AUTO-REG] Assembly {assembly.GetName().Name}");

        var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract && classFilter(t));

        foreach (var type in classTypes)
        {
            var interfaces = serviceFilter != null
                ? type.ImplementedInterfaces.Where(serviceFilter).Select(i => i.GetTypeInfo())
                : type.ImplementedInterfaces.Select(i => i.GetTypeInfo());
            foreach (var handlerType in interfaces)
            {
                if (serviceFilter != null && !serviceFilter.Invoke(handlerType))
                    continue;

                Console.WriteLine($"{lifetime} registered {handlerType} -> {type.Name}");
                switch (lifetime)
                {
                    case Lifetime.Transient:
                        services.AddTransient(handlerType.AsType(), type.AsType());
                        break;
                    case Lifetime.Scoped:
                        services.AddScoped(handlerType.AsType(), type.AsType());
                        break;
                    case Lifetime.Singleton:
                        services.AddSingleton(handlerType.AsType(), type.AsType());
                        break;
                }
            }
        }

        return services;
    }

    public static IServiceCollection Decorate<TService>(this IServiceCollection services, Func<TService, IServiceProvider, TService> decorator)
    {
        var descriptors = services.GetDescriptors<TService>();

        foreach (var descriptor in descriptors)
        {
            services.Replace(descriptor.Decorate(decorator));
        }

        return services;
    }

    public static IServiceCollection Decorate<TService>(this IServiceCollection services, Func<TService, TService> decorator)
    {
        var descriptors = services.GetDescriptors<TService>();

        foreach (var descriptor in descriptors)
        {
            services.Replace(descriptor.Decorate(decorator));
        }

        return services;
    }

    private static IList<ServiceDescriptor> GetDescriptors<TService>(this IServiceCollection services)
    {
        var descriptors = services.Where(service => service.ServiceType == typeof(TService)).ToList();

        if (descriptors.Count == 0)
        {
            throw new InvalidOperationException($"Could not find any registered services for type '{typeof(TService).FullName}'.");
        }

        return descriptors;
    }

    private static ServiceDescriptor Decorate<TService>(this ServiceDescriptor descriptor, Func<TService, IServiceProvider, TService> decorator)
    {
        return descriptor.WithFactory(provider => decorator((TService)descriptor.GetInstance(provider), provider));
    }

    private static ServiceDescriptor Decorate<TService>(this ServiceDescriptor descriptor, Func<TService, TService> decorator)
    {
        return descriptor.WithFactory(provider => decorator((TService)descriptor.GetInstance(provider)));
    }

    private static ServiceDescriptor WithFactory(this ServiceDescriptor descriptor, Func<IServiceProvider, object> factory)
    {
        return ServiceDescriptor.Describe(descriptor.ServiceType, factory, descriptor.Lifetime);
    }

    private static object GetInstance(this ServiceDescriptor descriptor, IServiceProvider provider)
    {
        if (descriptor.ImplementationInstance != null)
        {
            return descriptor.ImplementationInstance;
        }

        if (descriptor.ImplementationType != null)
        {
            return provider.GetServiceOrCreateInstance(descriptor.ImplementationType);
        }

        return descriptor.ImplementationFactory(provider);
    }

    private static object GetServiceOrCreateInstance(this IServiceProvider provider, Type type)
    {
        return ActivatorUtilities.GetServiceOrCreateInstance(provider, type);
    }
}
