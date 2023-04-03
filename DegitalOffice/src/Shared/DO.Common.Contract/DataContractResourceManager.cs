using System.Reflection;
using System.Resources;

namespace DO.Common.Contract
{
    public class DataContractResourceManager
    {
        private static DataContractResourceManager instance;
        public static DataContractResourceManager Current => instance ?? (instance = new DataContractResourceManager());

        private ResourceManager resourceManager;

        DataContractResourceManager()
        { }

        public void UseResource(string baseName, Assembly assembly)
        {
            resourceManager = new ResourceManager(baseName, assembly);
        }

        public string Translate(string key)
        {
            var translatedValue = resourceManager?.GetString(key);
            return translatedValue ?? $"[{key}]";
        }
    }
}
