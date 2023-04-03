using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DSoft.Common.Shared.Base;

public class ObjectLoader
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
        return File.ReadAllBytes(fileName);
    }
    public static async Task<byte[]> GetBytesAsync(string fileName)
    {
        return await File.ReadAllBytesAsync(fileName);
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

    public static string GetLastFile(string fileName, Encoding encoding, int count)
    {
        var fileBytes = GetBytes(fileName);
        var flenght = fileBytes.Length;
        byte[] outBytes = new byte[flenght];
        var startIndex = flenght - count;
        Array.Copy(fileBytes, startIndex, outBytes, 0, count);
        var partValue = encoding.GetString(outBytes, 0, count);
        return partValue;
    }
    // Convert a byte array to an Object
}
