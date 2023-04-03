using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

namespace HnxWebService.Domain
{

   public static class Util
   {
      public const string HNXBoard = "S";

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
