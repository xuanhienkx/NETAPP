using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace CS.Common
{
    public static class ObjectLoader
    {
        public static string LoadFromFile(string fileName)
        {
            string raw;
            using (var sr = File.OpenText(fileName))
            {
                raw = sr.ReadToEnd();
            }
            return raw.Trim();
        }

        public static T FromFile<T>(string fileName)
        {
            var raw = LoadFromFile(fileName);
            return JsonConvert.DeserializeObject<T>(raw);
        }

        public static T ParseConfig<T>(string configFile = "config.json")
        {
            return FromFile<T>(configFile);
        }
    }
}
