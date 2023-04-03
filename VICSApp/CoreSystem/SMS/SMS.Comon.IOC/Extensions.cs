using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Extensions;
using SMS.Common;

namespace SMS.Comon.IOC
{
    public static class Extensions
    {
        private static readonly string[] Suffixes = new[]
        { 
            "Repository" ,
            "DataService" 
        };
        internal static void CreateInstaller(this Container container, ContainerInstaller installer, Action<string> auditAction)
        {
            var assembly = installer.GetAssembly();
            if (assembly == null) return;

            var sw = new Stopwatch();
            sw.Start();

            /*container.RegisterManyForOpenGeneric(typeof(IRepository<>), assembly);
            container.RegisterManyForOpenGeneric(typeof(IUnitOfWork), assembly);*/
            installer.Register(container);
            // auto register for alls decorators'
            container.RegisterFor(assembly, Suffixes);
          


            sw.Stop();
            
            if (auditAction != null)
                auditAction(string.Format("{0} finished register in {1}ms.", assembly.FullName, sw.ElapsedMilliseconds));
        }

        internal static void RegisterFor(this Container container, Assembly assembly, params string[] subffixes)
        {
            foreach (var subffix in subffixes)
            {
                var allT = assembly.GetExportedTypes();


                var registrations = from type in allT
                                    where type.IsAbstract == false && type.Name.EndsWith(subffix, StringComparison.CurrentCultureIgnoreCase)
                                    let i = type.GetInterfaces().SingleOrDefault(x => x.Name.EndsWith(subffix, StringComparison.CurrentCultureIgnoreCase))
                                    where i != null
                                    select new { Service = i, Implementation = type };

                foreach (var reg in registrations)
                {
                    bool isDecorated =
                      reg.Implementation.GetConstructors()
                          .Any(x => x.GetParameters().Any(p => p.ParameterType == reg.Service));

                    if (isDecorated)
                        container.RegisterDecorator(reg.Service, reg.Implementation, StartupContainer.Lifestyle);
                    else
                        container.Register(reg.Service, reg.Implementation, StartupContainer.Lifestyle);
                }
            }
        }
    }
}