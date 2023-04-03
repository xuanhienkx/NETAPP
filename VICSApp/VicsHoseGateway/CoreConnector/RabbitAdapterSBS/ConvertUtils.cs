using System;
using System.Collections.Generic;
using System.Text;

namespace HOGW_CoreConnector
{
    public class ConvertUtils
    {
        public static bool IsNull(object o)
        {
            return o == null || Convert.IsDBNull(o);
        }

        public static double ToDouble(object o)
        {
            if (IsNull(o))
            {
                return 0;
            }

            double retVal;
            try
            {
                retVal = Convert.ToDouble(o);
            }
            catch
            {
                retVal = 0;
            }
            return retVal;
        }

        public static int ToInt32(object o)
        {
            if (IsNull(o))
            {
                return 0;
            }

            int retVal;
            try
            {
                retVal = Convert.ToInt32(o);
            }
            catch
            {
                retVal = 0;
            }
            return retVal;
        }

        public static decimal ToDecimal(object o, decimal defaultvalue)
        {
            if (IsNull(o))
            {
                return defaultvalue;
            }

            decimal retVal;
            try
            {
                retVal = Convert.ToDecimal(o);
            }
            catch
            {
                retVal = defaultvalue;
            }
            return retVal;
        }

        public static int ToInt32(object o, int defaultValue)
        {
            if (IsNull(o))
            {
                return defaultValue;
            }

            int retVal;
            try
            {
                retVal = Convert.ToInt32(o);
            }
            catch
            {
                retVal = defaultValue;
            }
            return retVal;
        }

        public static Int64 ToInt64(object o)
        {
            if (IsNull(o))
            {
                return 0;
            }

            Int64 retVal;
            try
            {
                retVal = Convert.ToInt64(o);
            }
            catch
            {
                retVal = 0;
            }
            return retVal;
        }

        public static Int64 ToInt64(object o, int defaultValue)
        {
            if (IsNull(o))
            {
                return defaultValue;
            }

            Int64 retVal;
            try
            {
                retVal = Convert.ToInt64(o);
            }
            catch
            {
                retVal = defaultValue;
            }
            return retVal;
        }

        public static string ToString(object o)
        {
            if (IsNull(o))
            {
                return String.Empty;
            }

            string retVal;
            try
            {
                retVal = Convert.ToString(o);
            }
            catch
            {
                retVal = String.Empty;
            }
            return retVal;
        }

        public static string ToString(object o, string defaultValue)
        {
            if (IsNull(o))
            {
                return defaultValue;
            }

            string retVal;
            try
            {
                retVal = Convert.ToString(o);
            }
            catch
            {
                retVal = defaultValue;
            }
            return retVal;
        }

        public static DateTime ToDateTime(object o, IFormatProvider provider)
        {
            if (IsNull(o))
            {
                return DateTime.MinValue;
            }

            DateTime retVal;
            try
            {
                if (provider != null)
                    retVal = Convert.ToDateTime(o, provider);
                else
                    retVal = Convert.ToDateTime(o);
            }
            catch
            {
                retVal = DateTime.MinValue;
            }
            return retVal;
        }

        public static DateTime ToDateTime(object o)
        {
            return ToDateTime(o, null);
        }
        public static DateTime ToDateTime(object o, DateTime defaultValue)
        {
            return ToDateTime(o, defaultValue, null);
        }

        public static DateTime ToDateTime(object o, DateTime defaultValue, IFormatProvider provider)
        {
            if (IsNull(o))
            {
                return defaultValue;
            }

            DateTime retVal;
            try
            {
                if (provider != null)
                    retVal = Convert.ToDateTime(o, provider);
                else
                    retVal = Convert.ToDateTime(o);
            }
            catch
            {
                retVal = defaultValue;
            }
            return retVal;
        }

        public static bool ToBoolean(object o)
        {
            if (IsNull(o))
            {
                return false;
            }

            bool retVal;
            try
            {
                retVal = Convert.ToBoolean(o);
            }
            catch
            {
                retVal = false;
            }
            return retVal;
        }

        public static bool ToBoolean(object o, bool defaultValue)
        {
            if (IsNull(o))
            {
                return defaultValue;
            }

            bool retVal;
            try
            {
                retVal = Convert.ToBoolean(o);
            }
            catch
            {
                retVal = defaultValue;
            }
            return retVal;
        }

        public static byte[] ToByteArray(object o)
        {
            byte[] retVal;
            try
            {
                retVal = (byte[])o;
            }
            catch
            {
                retVal = new byte[0];
            }
            return retVal;
        }

        public static string ToShortDateString(string trandate)
        {
            string[] d = trandate.Split('/');
            DateTime dm = new DateTime(ToInt32(d[2]), ToInt32(d[1]), ToInt32(d[0]));
            return dm.ToShortDateString();
        }

    }
}
