using System;
using System.Collections.Generic;
using System.Globalization;

namespace SMS.Common.Action
{
    public static class ExtensionMethods
    {
        public static string LowerString(this object value)
        {
            return Convert.ToString(value, CultureInfo.CurrentCulture).ToLower(CultureInfo.CurrentCulture);
        }

        public static object GetValueFromToken(this Dictionary<string, object> claim, string key)
        {
            return claim.ContainsKey(key) ? claim[key] : null;
        }
    }
}