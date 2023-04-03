using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using VRMApp.Brokerage;
using VRMApp.VRMGateway;

namespace VRMApp.Framework
{
   public static class Util
   {
      public const int HOSE_MAX_VOLUME = 20000;
      public const int HNX_MAX_VOLUME = 100000;
      public const int UPCOM_MAX_VOLUME = 100000;
      public const string HOSEBoard = "M";
      public const string HNXBoard = "S";
      public const string UPCOMBoard = "U";
      private static VRMGateway.VRMService vrmService;
      public static VRMGateway.VRMService VRMService
      {
         get
         {
            if (vrmService == null)
            {
               vrmService = new VRMGateway.VRMService();
#if DEBUG
               vrmService.Url = "http://localhost/cafegateway/VRMService.asmx";
#else
               vrmService.Url = VRMApp.Properties.Settings.Default.VRMApp_VRMGateway_VRMService;
#endif
               vrmService.Timeout = 90000;
            }
            return vrmService;
         }
      }

      private static string authenticationTokenKey;
      public static string TokenKey
      {
         get { return CryptoEngine.Encrypt(authenticationTokenKey); }
         set { authenticationTokenKey = value; }
      }

      private static UserLite loginUser;
      public static UserLite LoginUser
      {
         get { return loginUser; }
      }

      private static DateTime currentTran;
      public static DateTime CurrentTransactionDate
      {
         get { return currentTran; }
      }

      public static DateTime T3Date;

      public static void SetCurrentTime(TimeSpan time)
      {
         currentTran = currentTran.Add(time);
      }

      private static CultureInfo culture;
      public static CultureInfo CurrentCulture
      {
         get
         {
            if (culture == null)
            {
               culture = new CultureInfo("vi-VN", true);
               culture.DateTimeFormat.ShortDatePattern = "d-M-yyyy";
               culture.NumberFormat.CurrencyDecimalDigits = culture.NumberFormat.NumberDecimalDigits = 0;
               culture.NumberFormat.PercentDecimalDigits = 1;
            }
            return culture;
         }
      }

      private static MDI mdi;
      public static MDI MainMDI
      {
         get
         {
            if (mdi == null)
               mdi = new MDI();
            return mdi;
         }
      }

      private static List<string> groupAccess;
      public static bool CheckAccess(AccessPermission permission)
      {
         if (IsAdmin(AccessPermission.AdminLocal))
            return true;
         return CheckAccess(permission, groupAccess);
      }
      public static bool CheckAccess(string permission)
      {
         if (IsAdmin(AccessPermission.AdminLocal))
            return true;
         return CheckAccess(permission, groupAccess);
      }
      public static bool IsAdmin(AccessPermission adminRight)
      {
         return IsAdmin(adminRight, groupAccess);
      }

      public static bool CheckAccess(AccessPermission permission, List<string> accessList)
      {
         return CheckAccess(permission.ToString(), accessList);
      }
      public static bool CheckAccess(string permission, List<string> accessList)
      {
         if (string.IsNullOrEmpty(permission) || permission == AccessPermission.None.ToString() || IsAdmin(AccessPermission.AdminBranch, accessList))
            return true;
         if (accessList == null || accessList.Count == 0 || !IsAuthenticated())
            return false;
         return accessList.Exists(new Predicate<string>(delegate(string rule)
            {
               return rule.Equals(permission, StringComparison.CurrentCultureIgnoreCase);
            }));
      }
      public static bool IsAdmin(AccessPermission adminRight, List<string> accessList)
      {
         if (adminRight != AccessPermission.AdminBranch && adminRight != AccessPermission.AdminLocal)
            return false;

         if (accessList == null || accessList.Contains(AccessPermission.AdminBranch.ToString()))
            return true;
         if (accessList.Contains(AccessPermission.AdminBranch.ToString()) && adminRight == AccessPermission.AdminLocal)
            return true;
         return false;
      }

      private static Parameter param;
      public static Parameter Parameters
      {
         get
         {
            if (param == null)
               param = new Parameter();
            return param;
         }
      }

      public static void ResetStaticVariables()
      {
         loginUser = null;
         currentTran = T3Date = DateTime.MinValue;
      }

      /// <summary>
      /// Encrypt password only
      /// </summary>
      /// <param name="sourceString"></param>
      /// <returns></returns>
      public static string Encrypt(string sourceString)
      {
         UnicodeEncoding encoding = new UnicodeEncoding();
         MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
         return BitConverter.ToString(provider.ComputeHash(encoding.GetBytes(sourceString))).Replace("-", "");
      }

      internal static bool Authorize(string username, string password)
      {
         string encryptedName = CryptoEngine.Encrypt(username);
         string encryptedPass = CryptoEngine.Encrypt(password);
         string key = string.Empty;
         try
         {
               key = VRMService.GetAuthorize(encryptedName, encryptedPass);
         }
         catch (WebException ex)
         {

            var response = (HttpWebResponse) ex.Response;
            if (response.StatusCode==HttpStatusCode.Found)
            {
               VRMService.Url = new Uri(new Uri(VRMService.Url), response.Headers["Location"]).AbsoluteUri;
               key = VRMService.GetAuthorize(encryptedName, encryptedPass);
            }
         }

         
         if (string.IsNullOrEmpty(key))
            return false;
         Version v = VRMVersion();
         // set token key
         TokenKey =string.Format("{0}|{1}.{2}.{3}", key, v.Major, v.Minor, v.Build);
         // get login user detail
         loginUser = VRMService.GetUser(TokenKey, username);
         // get curent transaction date
         currentTran = VRMService.GetCurrentTransactionDate(TokenKey);
         // get the current access rule for user
         groupAccess = new List<string>(VRMService.GetUserAccessString(TokenKey, loginUser.UserId));

         return true;
      }

      internal static bool IsAuthenticated()
      {
         return LoginUser != null;
      }

      private static Dictionary<string, Customer> customerInfoList = new Dictionary<string, Customer>();
      internal static Customer GetCustomer(string customerId)
      {
         if (customerInfoList.ContainsKey(customerId))
            return customerInfoList[customerId];

         Customer c = VRMService.GetCustomer(TokenKey, customerId);
         if (string.IsNullOrEmpty(c.CustomerId))
            return null;

         customerInfoList.Add(customerId, c);
         return c;
      }

      internal static Version VRMVersion()
      {
         System.Reflection.Assembly[] assemblies = Thread.GetDomain().GetAssemblies();
         foreach (System.Reflection.Assembly assembly in assemblies)
         {
            if (assembly.GetName().Name == "VRMApp")
               return assembly.GetName().Version;
         }
         return null;
      }


      public static string ConverNumberToMoney(string number)
      {
          string[] arrNumber = number.Split('.');
          var strResult = "";
          switch (arrNumber.Length)
          {
              case 1:
                  strResult += ChangeNumberToText(arrNumber[0]);
                  break;
              case 2:
                  strResult += ChangeNumberToText(arrNumber[0]) + " ngàn, ";
                  if (arrNumber[1] != "000")
                  {
                      strResult += ChangeNumberToText(arrNumber[1]);
                  }
                  break;
              case 3:
                  strResult += ChangeNumberToText(arrNumber[0]) + " triệu, ";
                  if (arrNumber[1] != "000")
                  {
                      strResult += ChangeNumberToText(arrNumber[1]) + " ngàn, ";
                  }
                  if (arrNumber[2] != "000")
                  {
                      strResult += ChangeNumberToText(arrNumber[2]);
                  }
                  break;
              case 4:
                  strResult += ChangeNumberToText(arrNumber[0]) + " tỷ, ";
                  if (arrNumber[1] != "000")
                  {
                      strResult += ChangeNumberToText(arrNumber[1]) + " triệu, ";
                  }
                  if (arrNumber[2] != "000")
                  {
                      strResult += ChangeNumberToText(arrNumber[2]) + " ngàn, ";
                  }
                  if (arrNumber[3] != "000")
                  {
                      strResult += ChangeNumberToText(arrNumber[3]);
                  }
                  break;

          }
          if (strResult.LastIndexOf(", ") == strResult.Length - 2)
          {
              strResult = strResult.Substring(0, strResult.Length - 2);
          }
          strResult += " đồng";

          return strResult;
      }
      private static string ChangeNumberToText(string number)
      {
          char[] arrNumber = number.ToCharArray();
          switch (arrNumber.Length)
          {
              case 3:
                  return ThreeNumberToText(int.Parse(arrNumber[0].ToString()), int.Parse(arrNumber[1].ToString()), int.Parse(arrNumber[2].ToString()));
              case 2:
                  return TwoNumberToText(int.Parse(arrNumber[0].ToString()), int.Parse(arrNumber[1].ToString()));
              case 1:
                  return OneNumberToText(int.Parse(arrNumber[0].ToString()));
              default:
                  return null;
          }
      }
      private static string OneNumberToText(int number)
      {
          switch (number)
          {
              case 0:
                  return "không";
              case 1:
                  return "một";
              case 2:
                  return "hai";
              case 3:
                  return "ba";
              case 4:
                  return "bốn";
              case 5:
                  return "năm";
              case 6:
                  return "sáu";
              case 7:
                  return "bảy";
              case 8:
                  return "tám";
              case 9:
                  return "chín";
              default:
                  return null;
          }
      }
      private static string TwoNumberToText(int number1, int number2)
      {
          if (number1 == 0)
          {
              return OneNumberToText(number2);
          }

          if (number1 == 1)
          {
              if (number2 == 0)
              {
                  return "mười";
              }
              else if (number2 == 5)
              {
                  return "mười lăm";
              }
              else
              {
                  return "mười " + OneNumberToText(number2);
              }
          }
          else
          {
              if (number2 == 0)
              {
                  return OneNumberToText(number1) + " mươi";
              }
              else if (number2 == 1)
              {
                  return OneNumberToText(number1) + " mươi mốt";
              }
              else if (number2 == 4)
              {
                  return OneNumberToText(number1) + " mươi tư";
              }
              else if (number2 == 5)
              {
                  return OneNumberToText(number1) + " mươi lăm";
              }
              else
              {
                  return OneNumberToText(number1) + " mươi " + OneNumberToText(number2);
              }
          }
      }
      private static string ThreeNumberToText(int number1, int number2, int number3)
      {
          if (number1 == 0)
          {
              return TwoNumberToText(number2, number3);
          }

          if (number2 == 0)
          {
              if (number3 == 0)
              {
                  return OneNumberToText(number1) + " trăm";
              }
              else
              {
                  return OneNumberToText(number1) + " trăm linh " + OneNumberToText(number3);
              }
          }
          else
          {
              return OneNumberToText(number1) + " trăm " + TwoNumberToText(number2, number3);
          }
      }
      private static Dictionary<DateTime, decimal> interestRate;
      public static Dictionary<DateTime, decimal> InterestRate 
       {
          get
          {
              if (interestRate == null)
              {
                  DataTable rateList = Util.VRMService.GetInterestRate(TokenKey);
                  interestRate = new Dictionary<DateTime, decimal>();
                  foreach (DataRow it in rateList.Rows)
                  {
                      interestRate.Add((DateTime)it["BeginDate"], (decimal)it["rate"]);
                  }
                  var lastRate = interestRate.OrderBy(r => r.Key).LastOrDefault().Value;
                  interestRate.Add(DateTime.MaxValue, lastRate);
              }
              return interestRate;
          }
       }
      public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
      {
          DataTable dt = new DataTable("DataTable");
          Type t = typeof(T);
          PropertyInfo[] pia = t.GetProperties();

          //Inspect the properties and create the columns in the DataTable
          foreach (PropertyInfo pi in pia)
          {
              Type ColumnType = pi.PropertyType;
              if ((ColumnType.IsGenericType))
              {
                  ColumnType = ColumnType.GetGenericArguments()[0];
              }
              dt.Columns.Add(pi.Name, ColumnType);
          }

          //Populate the data table
          foreach (T item in collection)
          {
              DataRow dr = dt.NewRow();
              dr.BeginEdit();
              foreach (PropertyInfo pi in pia)
              {
                  if (pi.GetValue(item, null) != null)
                  {
                      dr[pi.Name] = pi.GetValue(item, null);
                  }
              }
              dr.EndEdit();
              dt.Rows.Add(dr);
          }
          return dt;
      }

      public static void ExcelExport(DataSet data, string fileName, bool openAfter)
      {
          //export a DataTable to Excel
          DialogResult retry = DialogResult.Retry;

          while (retry == DialogResult.Retry)
          {
              try
              {
                  using (ExcelWriter writer = new ExcelWriter(fileName))
                  {
                      writer.WriteStartDocument();

                      // Write the worksheet contents 
                      foreach (DataTable table in data.Tables)
                      {
                          writer.WriteStartWorksheet("Buttoan"); 

                          //Write header row
                          writer.WriteStartRow();
                          foreach (DataColumn col in table.Columns)
                              writer.WriteExcelUnstyledCell(col.Caption);
                          writer.WriteEndRow();

                          //write data
                          foreach (DataRow row in table.Rows)
                          {
                              writer.WriteStartRow();
                              foreach (object o in row.ItemArray)
                              {
                                  writer.WriteExcelAutoStyledCell(o, false);
                              }
                              writer.WriteEndRow();
                          }
                          writer.WriteEndWorksheet();
                      }
                      // Close up the document
                      writer.WriteEndDocument();
                      writer.Close();
                      if (openAfter)
                          OpenFile(fileName);
                      retry = DialogResult.Cancel;
                  }
              }
              catch (Exception myException)
              {
                  retry = MessageBox.Show(myException.Message, "Excel Export", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
              }
          }
      }

      private static void OpenFile(string fileName)
      {
          System.Diagnostics.Process.Start(fileName);
      }

       public static DataTable GridToTable(this DataGridView dgv)
       {
           DataTable dt = new DataTable();
           foreach (DataGridViewColumn col in dgv.Columns)
           {
               dt.Columns.Add(col.HeaderText);
           }

           foreach (DataGridViewRow row in dgv.Rows)
           {
               DataRow dRow = dt.NewRow();
               foreach (DataGridViewCell cell in row.Cells)
               {
                   dRow[cell.ColumnIndex] = cell.Value;
               }
               dt.Rows.Add(dRow);
           }
           return dt;
       }

   }
}
