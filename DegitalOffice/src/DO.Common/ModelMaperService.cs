using DO.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace DO.Common;

public class ModelMaperService : IModelMapperService
{
    private readonly ILogger<ModelMaperService> logger;

    public ModelMaperService(ILogger<ModelMaperService> logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public T Map<T>(CsBag bag, Func<T> constructor)
    {
        var model = constructor();
        return (T)ConvertBagToModel(model, typeof(T), bag);
    }

    public IDictionary<string, object> Serialize<T>(T model)
    {
        var json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        return JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
    }

    public object MapByType(CsBag csvBags, Type type)
    {
        if (type == null)
            return null;

        var model = Activator.CreateInstance(type);
        return ConvertBagToModel(model, type, csvBags);
    }

    private object ConvertBagToModel(object model, Type type, CsBag bag)
    {
        foreach (var key in bag.Keys)
        {
            var prop = type.GetProperty(key);
            if (prop == null || bag[key] == null) continue;
            logger.LogDebug($"Process: Key [{key}] value [{bag[key]}] property [{prop.PropertyType}]");
            if (prop.PropertyType.IsEnum)
            {
                var enumType = prop.PropertyType;
                foreach (var name in Enum.GetNames(enumType))
                {
                    if (enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true).Any())
                    {
                        var enumMemberAttribute =
                        ((EnumMemberAttribute[])enumType.GetField(name)
                            .GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                        if (enumMemberAttribute.Value != bag[key].ToString()) continue;
                        var value = Enum.Parse(enumType, name);
                        prop.SetValue(model, value, null);
                    }
                    else
                    {
                        if (!string.Equals(name, bag[key].ToString(), StringComparison.Ordinal) &&
                            enumType.GetEnumName(bag[key]) != name) continue;
                        var value = Enum.Parse(enumType, name);
                        prop.SetValue(model, value, null);
                    }
                }
            }
            else if (prop.PropertyType.IsGenericType && bag[key] is JArray bagItems)
            {
                var genericType = prop.PropertyType.GenericTypeArguments[0];
                var items = prop.GetValue(model);

                foreach (var bagItem in bagItems)
                {
                    var listItems = bagItem.ToObject<IList<CsBagItem>>();
                    var item = MapByType(new CsBag(listItems), genericType);
                    items.GetType().GetMethod("Add").Invoke(items, new[] { item });
                }
            }
            else
            {
                object value = null;
                if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                    value = DateTime.Parse(bag[key].ToString());
                else if (prop.PropertyType == typeof(Guid) || prop.PropertyType == typeof(Guid?))
                    value = (Guid?)new Guid(bag[key].ToString());
                else
                    value = Convert.ChangeType(bag[key], prop.PropertyType);
                prop.SetValue(model, value, null);
            }
        }
        return model;
    }
}
