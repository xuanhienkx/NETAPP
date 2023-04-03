using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace VRMDomain.Common
{
   public static class LiteralUtil
   {
      internal static string GetLiteral(string s)
      {
         return s.Replace("'", "''");
      }

      internal static string GetLiteral(DateTime? d)
      {
         if (d.HasValue)
            return GetLiteral(d.Value);
         return GetLiteral(DateTime.MinValue);
      }

      internal static string GetLiteral(DateTime d)
      {
         if (d == DateTime.MinValue || d == DateTime.MaxValue)
            return " NULL ";
         return string.Format(" CAST('{0}' AS DATETIME) ", d.ToString("yyyy-MM-dd 00:00:00"));
      }

      internal static string DateTime2String(DateTime d)
      {
          if (d == DateTime.MinValue || d == DateTime.MaxValue)
              return " NULL ";
          return string.Format(" CAST('{0}' AS DATETIME) ", d.ToString("yyyy-MM-dd HH:mm:ss"));
      }


      internal static string GetNumericLiteral(object n)
      {
         return Convert.ToString(n, System.Globalization.NumberFormatInfo.InvariantInfo);
      }

      public static string Encrypt(string sourceString)
      {
         UnicodeEncoding encoding = new UnicodeEncoding();
         MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
         return BitConverter.ToString(provider.ComputeHash(encoding.GetBytes(sourceString))).Replace("-", "");
      }

      internal static string FormatDate(DateTime? d)
      {
         if (!d.HasValue || d.Value == DateTime.MinValue || d.Value == DateTime.MaxValue)
            return string.Empty;
         return d.Value.ToString("dd/MM/yyyy");
      }

      internal static string GetLiteralForSP(DateTime d)
      {
         return string.Format("'{0}') ", d.ToString("yyyy-MM-dd HH:mm:ssf"));
      }

      internal static object GetLiteral(bool b)
      {
         return b ? 1 : 0;
      }
   }
}
