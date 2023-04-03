using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CS.Common.Contract;

namespace CS.UI.Common
{
    public class EnumItem<T>
    {
        public T Value { get; set; }
        public string DisplayValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is T type)
                return Value.Equals(type);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class EnumCollection<T> : Collection<EnumItem<T>> where T : struct
    {
        public EnumCollection()
        {
            InitializeItems(null);
        }
        public EnumCollection(IReadOnlyList<T> exclude)
        {
            InitializeItems(exclude);
        }

        public EnumCollection(params T[] defaultValues)
        {
            InitializeItems(null, defaultValues);
        }

        private void InitializeItems(IReadOnlyList<T> exclude, params T[] defaultValues)
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException($"{typeof(T).Name} is not Enum!");

            var enumType = typeof(T);
            var allValues = defaultValues.Any() ? defaultValues : Enum.GetValues(enumType);

            foreach (T item in allValues)
            {
                if (exclude != null && exclude.Contains(item))
                    continue;

                var resourceKey = $"Enum_{enumType.Name}_{item}";
                Add(new EnumItem<T> { Value = item, DisplayValue = DataContractResourceManager.Current.Translate(resourceKey) });
            }
        }

        public EnumCollection<T> Exclude(params T[] excludes)
        {
            if (excludes.Any())
            {
                Items.Where(x => excludes.Contains(x.Value))
                     .ToList()
                     .ForEach(x => Items.Remove(x));
            }
            return this;
        }

        public bool Has(T value)
        {
            return Items.Any(x => x.Value.Equals(value));
        }
    }
}
