using System.Reflection;
using SimpleInjector;

namespace SMS.Comon.IOC
{
    public abstract class ContainerInstaller
    {
        public abstract void Register(Container container);
        public abstract Assembly GetAssembly();
        public abstract int Index { get; }
    }
}