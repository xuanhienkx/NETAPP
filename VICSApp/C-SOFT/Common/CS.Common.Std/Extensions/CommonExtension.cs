using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace CS.Common.Std.Extensions
{
    public static class CommonExtension
    {
       

        #region Collection

        public static int IndexOf<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            var index = -1;
            foreach (var item in collection)
            {
                index++;
                if (predicate(item))
                    return index;
            }
            return index;
        }

        #endregion

        #region Likeness

        public static bool IsIn<T>(this T obj, params T[] args)
        {
            return args.Any(x => x.Equals(obj));
        }

        public static bool NotIn<T>(this T obj, params T[] args)
        {
            return args.All(x => !x.Equals(obj));
        }

        public static T AsEnum<T>(this string str)
        {
            return (T) Enum.Parse(typeof(T), str);
        }

        public static T Get<T>(this IServiceProvider serviceProvider)
        {
            return (T) serviceProvider.GetService(typeof(T));
        }

        public static string GetFieldName(this Expression expression)
        {
            if (expression is UnaryExpression unary)
                return GetFieldName(unary.Operand);
            if (expression is MemberExpression member)
                return member.Member.Name;
            return null;
        }

        #endregion

        #region Enum

        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            var memberInfo = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();

            if (memberInfo != null)
                return (TAttribute)memberInfo.GetCustomAttributes(typeof(TAttribute), false).FirstOrDefault();
            return null;
        }

        public static string DisplayName(this Enum enumValue)
        {
            return enumValue.GetAttribute<EnumMemberAttribute>().Value;
        }

        #endregion

        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;

            // go through the items in the dictionary and copy over the key value pairs)
            foreach (var kvp in dictionary)
            {
                // if the value can also be turned into an ExpandoObject, then do it!
                if (kvp.Value is IDictionary<string, object>)
                {
                    var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
                    expandoDic.Add(kvp.Key, expandoValue);
                }
                else if (kvp.Value is ICollection)
                {
                    // iterate through the collection and convert any strin-object dictionaries
                    // along the way into expando objects
                    var itemList = new List<object>();
                    foreach (var item in (ICollection)kvp.Value)
                    {
                        if (item is IDictionary<string, object>)
                        {
                            var expandoItem = ((IDictionary<string, object>)item).ToExpando();
                            itemList.Add(expandoItem);
                        }
                        else
                        {
                            itemList.Add(item);
                        }
                    }

                    expandoDic.Add(kvp.Key, itemList);
                }
                else
                {
                    expandoDic.Add(kvp);
                }
            }

            return expando;
        }

    }
}
