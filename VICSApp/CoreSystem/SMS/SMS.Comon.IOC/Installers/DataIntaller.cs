using System.Reflection;
using SimpleInjector;
using SMS.Data.Services.UnitsOfWork;

namespace SMS.Comon.IOC.Installers
{
    public class DataIntaller: ContainerInstaller
    {
        private readonly Assembly _assembly = typeof(UnitOfWork).Assembly;
        public override void Register(Container container)
        {
        }

        public override Assembly GetAssembly()
        {
            return _assembly;
        }

        public override int Index
        {
            get { return 30; }
        }
    }
}