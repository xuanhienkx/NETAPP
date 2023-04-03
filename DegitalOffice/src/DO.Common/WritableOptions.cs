using DO.Common.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DO.Common;
public class WritableOptions<T> : IWritableOptions<T> where T : class, new()
{
    private readonly IOptionsMonitor<T> options;
    private readonly string section;
    private readonly string rootPath;
    private readonly string file;

    public WritableOptions(
        IOptionsMonitor<T> options,
        string section,
        string rootPath,
        string file)
    {
        this.options = options;
        this.section = section;
        this.rootPath = rootPath;
        this.file = file;
    }

    public T Value => options.CurrentValue;
    public T Get(string name) => options.Get(name);

    public void Update(Action<T> applyChanges)
    {
        var physicalPath = Path.Combine(rootPath, file);

        var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath));
        var sectionObject = jObject.TryGetValue(this.section, out JToken jToken) ?
            JsonConvert.DeserializeObject<T>(jToken.ToString()) : (Value ?? new T());

        applyChanges(sectionObject);

        jObject[this.section] = JObject.Parse(JsonConvert.SerializeObject(sectionObject));
        File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
    }
}
