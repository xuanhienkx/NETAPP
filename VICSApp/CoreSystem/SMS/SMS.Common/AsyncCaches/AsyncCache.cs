using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SMS.Common.AsyncCaches
{
    public class AsyncCache<TKey, TValue>
    {
        private readonly Func<TKey, Task<TValue>> _valueFactory;
        private readonly ConcurrentDictionary<TKey, Lazy<Task<TValue>>> _map;

        public AsyncCache(Func<TKey, Task<TValue>> valueFactory)
        {
            if (valueFactory == null) throw new ArgumentNullException("valueFactory");
            _valueFactory = valueFactory;
            _map = new ConcurrentDictionary<TKey, Lazy<Task<TValue>>>();
        }

        public Task<TValue> this[TKey key]
        {
            get
            {
                if (key == null) throw new ArgumentNullException("key");
                return _map.GetOrAdd(key, toAdd =>
                    new Lazy<Task<TValue>>(() => _valueFactory(toAdd))).Value;
            }
        }
    }
}