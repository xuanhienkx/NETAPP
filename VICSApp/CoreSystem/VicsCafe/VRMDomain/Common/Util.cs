using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using VRMDomain.Domain;

namespace VRMDomain.Common
{
   public static class Util
   {
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

      static bool? isAutoGenerateAccount;
      public static bool IsAutoGenerateAccount
      {
         get
         {
            if (!isAutoGenerateAccount.HasValue)
               isAutoGenerateAccount = bool.Parse(ConfigurationManager.AppSettings["AutoGenerateAccount"]);
            return isAutoGenerateAccount.Value;
         }
      }

      static bool? useCellingPrice;
      internal static bool UseCellingPrice
      {
         get
         {
            if (!useCellingPrice.HasValue)
               useCellingPrice = bool.Parse(ConfigurationManager.AppSettings["UseCellingPrice"]);
            return useCellingPrice.Value;
         }
      }

      static bool? rightAndEPSAsCredit;
      internal static bool RightAndEPSAsCredit
      {
         get
         {
            if (!rightAndEPSAsCredit.HasValue)
               rightAndEPSAsCredit = bool.Parse(ConfigurationManager.AppSettings["RightAndEPSAsCredit"]);
            return rightAndEPSAsCredit.Value;
         }
      }

      static bool? autoUnblockedCustomerBalance;
      internal static bool AutoUnblockedCustomerBalance
      {
         get
         {
            if (!autoUnblockedCustomerBalance.HasValue)
               autoUnblockedCustomerBalance = bool.Parse(ConfigurationManager.AppSettings["AutoUnblockedCustomerBalance"]);
            return autoUnblockedCustomerBalance.Value;
         }
      }

      static decimal? outTermInterestRate;
      internal static decimal OutTermInterestRate
      {
         get
         {
            if (!outTermInterestRate.HasValue)
               outTermInterestRate = decimal.Parse(ConfigurationManager.AppSettings["OutTermInterestRate"]);
            return outTermInterestRate.Value;
         }
      }

      static string vipAccount;
      internal static string VIPAccount
      {
         get
         {
            if (string.IsNullOrEmpty(vipAccount))
            {
               vipAccount = ConfigurationManager.AppSettings["VIPAccount"];
               if (string.IsNullOrEmpty(vipAccount))
                  vipAccount = "''";
            }
            return vipAccount;
         }
      }

       public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
      {
          var dataList = new List<TSource>();

          const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
          var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                               select new
                               {
                                   Name = aProp.Name,
                                   Type = Nullable.GetUnderlyingType(aProp.PropertyType) ??
                           aProp.PropertyType
                               }).ToList();
          var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                   select new
                                   {
                                       Name = aHeader.ColumnName,
                                       Type = aHeader.DataType
                                   }).ToList();
          var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

          foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
          {
              var aTSource = new TSource();
              foreach (var aField in commonFields)
              {
                  PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                  var value = (dataRow[aField.Name] == DBNull.Value) ?
                  null : dataRow[aField.Name]; //if database field is nullable
                  propertyInfos.SetValue(aTSource, value, null);
              }
              dataList.Add(aTSource);
          }
          return dataList;
      } 
   }
}
