using System;
using System.Collections.Generic;
using System.Windows;

namespace CS.UI.Common
{
    /// <summary>
    /// The shared resource dictionary is a specialized resource dictionary
    /// that loads it content only once. If a second instance with the same source
    /// is created, it only merges the resources from the cache.
    /// http://www.wpftutorial.net/MergedDictionaryPerformance.html
    /// https://codeblitz.wordpress.com/2010/08/25/resourcedictionary-use-with-care/
    /// </summary>
    public class SharedResourceDictionary : ResourceDictionary
    {
        private static readonly Dictionary<Uri, WeakReference> Cache;

        static SharedResourceDictionary()
        {
            Cache = new Dictionary<Uri, WeakReference>();
        }

        private Uri source;

        public new Uri Source
        {
            get => source;
            set
            {
                source = value;
                if (!Cache.ContainsKey(source))
                {
                    AddToCache();
                }
                else
                {
                    var weakReference = Cache[source];
                    if (weakReference != null && weakReference.IsAlive)
                    {
                        MergedDictionaries.Add((ResourceDictionary)weakReference.Target);
                    }
                    else
                    {
                        AddToCache();
                    }
                }

            }
        }

        private void AddToCache()
        {
            base.Source = source;
            if (Cache.ContainsKey(source))
            {
                Cache.Remove(source);
            }
            Cache.Add(source, new WeakReference(this, false));
        }
    }
}
