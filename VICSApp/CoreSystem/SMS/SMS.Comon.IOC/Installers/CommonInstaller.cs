using System.Reflection;
using SimpleInjector;
using SMS.Common; 

namespace SMS.Comon.IOC.Installers
{
    public class CommonInstaller : ContainerInstaller
    {
        public override void Register(Container container)
        {
             
        }

        public override Assembly GetAssembly()
        {
            return typeof(ActionManagerException).Assembly;
        }

        public override int Index
        {
            get { return 100; }
        }
    }
}