using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DO.Common;
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
    public static string GetFileName(string fileName)
    {
        return fileName.Split('/', '\\').Last();
    }
    public static byte[] GetBytes(string fileName)
    {
        var str = LoadFromFile(fileName);
        var bytes = new byte[str.Length * sizeof(char)];
        Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
    public static T FromFile<T>(string fileName)
    {
        var raw = LoadFromFile(fileName);
        return JsonConvert.DeserializeObject<T>(raw);
    }
    public static T Deserialize<T>(string fileName)
    {
        var param = GetBytes(fileName);
        using MemoryStream ms = new MemoryStream(param);
        IFormatter br = new BinaryFormatter();
        return (T)br.Deserialize(ms);
    }
    public static T ParseConfig<T>(string configFile = "config.json")
    {
        return FromFile<T>(configFile);
    }
    // Convert a byte array to an Object

}