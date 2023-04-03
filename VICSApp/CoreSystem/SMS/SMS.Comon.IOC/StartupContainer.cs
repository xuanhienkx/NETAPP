using System;
using System.Linq;
using SimpleInjector;
using SMS.Common;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.Data.Services.UnitsOfWork;

namespace SMS.Comon.IOC
{
    public static class StartupContainer
    {
        public static Lifestyle Lifestyle = Lifestyle.Singleton;
        public static Container Initialize(Type decoratorLogger = null)
        {
            // Create IoC container
            var container = new Container();

            // init logger
            var logger = new Logger();
            container.Register<ILogger>(() => logger, Lifestyle.Singleton);
            if (decoratorLogger != null)
            {
                container.RegisterDecorator(typeof(ILogger), decoratorLogger, Lifestyle.Singleton);
            }

            logger.Log("Start to register dependencies...");
            
            // container.Options.AllowOverridingRegistrations = true;
             
            //// Register dependencies
            InitializeContainer(container);
            // Register all instances:
            RegisterAllInstallers(container, logger);

            logger.Log("All dependencies are loaded!");

            return container;
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IDisposable, Disposable>(Lifestyle);
            container.Register<ISmsDataContext, SmsDataContext>(Lifestyle);
            container.Register<ISbsDataContext, SbsDataContext>(Lifestyle);
            container.Register<ISbsUnitOfWork, SbsUnitOfWork>(Lifestyle);
            container.Register<ISmsUnitOfWork, SmsUnitOfWork>(Lifestyle);
        }

        private static void RegisterAllInstallers(Container container, ILogger logger)
        {
            var installerType = typeof(ContainerInstaller);
            var installers = installerType.Assembly.GetTypes()
                .Where(type => type.BaseType == installerType)
                .Select(type => (ContainerInstaller)Activator.CreateInstance(type))
                .OrderByDescending(o => o.Index);

            foreach (var installer in installers)
            {
                container.CreateInstaller(installer, logger.Log);
            }
        }

        private static void RegisterAllScope(Container container)
        {
            // container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(Lifestyle);
            // container.Register<IDbContextCollection, DbContextCollection>(Lifestyle.Transient);
            // container.Register<IDbContextFactory, DbContextFactory>(Lifestyle);
            //  container.Register<IDbContextReadOnlyScope, DbContextReadOnlyScope>(Lifestyle.Scoped);
            // container.Register<IDbContextScope, DbContextScope>(Lifestyle.Scoped);  
            //  container.Register<IDbContextScopeFactory, DbContextScopeFactory>(Lifestyle);  
        }

    }
}