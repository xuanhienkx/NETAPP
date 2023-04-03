using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std.Extensions;

namespace CS.UI.Common.Extensions
{
    public static class CommonExtensions
    {
        /// <summary>
        /// Check the current login user has access right and type. If the login user is admin
        /// role, the check right will be ignored
        /// </summary>
        /// <param name="user"></param>
        /// <param name="right"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasRight(this IUserLogin user, AccessRight right, AccessType type)
        {
            return CurrentPrincipal.Instance.IsInRole(UserRoleType.Admin)
                   || user.Has(right, type);
        }

        public static void RemoveWhen<T>(this ObservableCollection<T> source, Func<T, bool> canRemove)
        {
            foreach (var deleted in source.Where(canRemove).ToList())
                source.Remove(deleted);
        }

        public static void Update<T>(this ObservableCollection<T> source, IEnumerable<T> newSource)
        {
            if (newSource == null) return;

            source.Clear(); 
            foreach (var item in newSource)
                source.Add(item);
        }

        public static IEnumerable<T> RecursiveLookup<T, TKey>(this IList<T> source, T resource, Func<T, TKey> lookupSelector)
            where T : IResource<TKey>
        {
            var lookup = source.ToLookup(lookupSelector);
            var result = lookup[resource.Id].SelectRecursive(x => lookup[x.Id]);

            return result.Union(source.Where(x => x.Id.Equals(resource.Id)));
        }

        public static IList<Country> GetListCountry()
        {
            var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID));

            var countries = regions.Select(region => new Country()
            {
                Name = region.NativeName,
                Code = region.Name
            });

            return countries.GroupBy(test => test.Code)
                .Select(grp => grp.First())
                .OrderBy(x => x.Name)
                .ToList();
        }

        public static T LoadFromSource<T>(this Assembly assembly, string configPath)
        {
            // This implementation is because not agains the rule CA2202: Do not dispose objects multiple times
            Stream stream = null;
            try
            {
                stream = assembly.GetManifestResourceStream(configPath);
                using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
                {
                    stream = null;
                    var result = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            finally
            {
                stream?.Dispose();
            }
        }
    }
}
