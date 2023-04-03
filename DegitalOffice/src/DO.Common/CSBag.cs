using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DO.Common
{
    [DataContract]
    public class CsBagItem
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public object Value { get; set; }

        public CsBagItem() { }
        public CsBagItem(string key) : this(key, null) { }
        public CsBagItem(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    [DataContract]
    public class CsBag : IEnumerable<CsBagItem>
    {
        [DataMember]
        public IList<CsBagItem> Items { get; set; }

        protected event PropertyChangingEventHandler ObseverValueChanged;

        public CsBag()
        {
            Items = new List<CsBagItem>();
        }

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

        [IgnoreDataMember]
        [JsonIgnore]
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
}
