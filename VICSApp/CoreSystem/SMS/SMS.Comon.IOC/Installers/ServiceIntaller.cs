using System.Reflection;
using SimpleInjector;
using SMS.Business.Service.Services;

namespace SMS.Comon.IOC.Installers
{
    public class ServiceIntaller : ContainerInstaller
    {
        private readonly Assembly _assembly = typeof(FirstDayDataService).Assembly;
        public override void Register(Container container)
        { 
        }

        public override Assembly GetAssembly()
        {
            return _assembly;
        }

        public override int Index
        {
            get { return 10; }
        }
    }
}