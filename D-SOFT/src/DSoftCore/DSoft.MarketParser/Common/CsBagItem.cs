using System.Collections;
using System.ComponentModel;

namespace DSoft.MarketParser.Common;
public class CsBagItem
{
    public string Key { get; set; }
    public object Value { get; set; }

    public CsBagItem() { }
    public CsBagItem(string key) : this(key, null) { }
    public CsBagItem(string key, object value)
    {
        Key = key;
        Value = value;
    }
}

public class CsBag : IEnumerable<CsBagItem>
{
    public IList<CsBagItem> Items { get; set; }

    protected event PropertyChangingEventHandler ObseverValueChanged;

    public CsBag() => Items = new List<CsBagItem>();

    public CsBag(IList<CsBagItem> bagItems)
    {
        Items = bagItems;
    }

    public CsBag(IDictionary<string, object> dictionary)
    {
        Items = dictionary.Select(x => new CsBagItem(x.Key, x.Value)).ToList();
    }

    public object this[string name]
    {
        get => Items.FirstOrDefault(x => x.Key == name)?.Value;
        set
        {
            var item = Items.FirstOrDefault(x => x.Key == name);
            if (item == null)
            {
                item = new CsBagItem(name, value);
                Items.Add(item);
            }
            else
                item.Value = value;

            ObseverValueChanged?.Invoke(this, new PropertyChangingEventArgs(name));
        }
    }


    public IEnumerable<string> Keys => Items.Select(x => x.Key);

    public void AddRange(CsBag bag)
    {
        foreach (var key in bag.Keys)
        {
            this[key] = bag[key];
        }
    }

    public bool TryGet<T>(string key, out T value)
    {
        if (Items == null)
        {
            value = default(T);
            return false;
        }
        var item = Items.FirstOrDefault(x => x.Key == key);
        if (item == null)
        {
            value = default(T);
            return false;
        }
        value = (T)item.Value;
        return true;
    }

    public IDictionary<string, object> GetDictionary()
    {
        return Items.ToDictionary(x => x.Key, x => x.Value);
    }

    public IEnumerator<CsBagItem> GetEnumerator()
    {
        return Items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
