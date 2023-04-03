using System;
using System.Runtime.Loader;

namespace CS.Common
{
    public static class AssemblyLoader
    {
        public static T Get<T>(string service, string basePath) where T : class
        {
            var parts = service.Split(',');
            var path = $"{basePath}/{parts[1].Trim()}.dll";
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);

            return (T)Activator.CreateInstance(assembly.GetType(parts[0].Trim()));
        }
    }
}
