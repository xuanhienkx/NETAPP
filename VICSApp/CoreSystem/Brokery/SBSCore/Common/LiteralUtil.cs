using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SBSCore.Common
{
   public static class LiteralUtil
   {
      internal static string GetLiteral(string s)
      {
         return s.Replace("'", "''");
      }

      internal static string GetLiteral(DateTime d)
      {
         return string.Format(" CAST('{0}' AS DATETIME) ", d.ToString("yyyy-MM-dd HH:mm:ss.f"));
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

      internal static DateTime TrimTimeSpan(this DateTime d)
      {
         return d.Add(-d.TimeOfDay);
      }

      internal static string GetLiteralForSP(DateTime d)
      {
         return string.Format("'{0}') ", d.ToString("yyyy-MM-dd HH:mm:ssf"));
      }

      public static bool Contains(this IDataReader reader, string fieldName)
      {
         try
         {
            return reader.GetOrdinal(fieldName) >= 0;
         }
         catch (IndexOutOfRangeException)
         {
            return false;
         }
      }
   }
}
