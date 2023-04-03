using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

namespace HoseWebService.Common
{
   public static class Util
   {
      public const string HOSEBoard = "M";

      private static CultureInfo culture;
      public static CultureInfo CurrentCulture
      {
         get
         {
            if (culture == null)
            {
               culture = new CultureInfo("vi-VN", true);
               culture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
               culture.DateTimeFormat.LongDatePattern = "dd-MM-yyyy HH:mm:ssf";
               culture.NumberFormat.CurrencyDecimalDigits = culture.NumberFormat.NumberDecimalDigits = 0;
               culture.NumberFormat.PercentDecimalDigits = 1;
            }
            return culture;
         }
      }
   }
}
