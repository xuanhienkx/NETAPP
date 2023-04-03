using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace SBSCore.Common
{
   public static class Util
   {
      public const int HOSE_MAX_VOLUME = 500000;
      public const int HNX_MAX_VOLUME = 100000;
      public const int UPCOM_MAX_VOLUME = 100000;
      public const string HOSEBoard = "M";
      public const string HNXBoard = "S";
      public const string UpComBoard = "O";

      private static IEnumerable<string> agencyAsBranch;

      public static IEnumerable<string> AgencyAsBranch
      {
         get {
            return agencyAsBranch ??
                   (agencyAsBranch = new List<string>(ConfigurationManager.AppSettings["AgencyAsBranch"].Split(';')));
         }
      }

      public static IDictionary<string, string> BranchTradeCode
      {
         get
         {
            return new Dictionary<string, string>()
                      {
                         {"100", "VICS"},
                         {"200", "VICSHCM"},
                         {"300", "VICSHUE"},
                      };
         }
      }

      public static string SBSConnectionString
      {
         get { return ConfigurationManager.ConnectionStrings["SBSConnection"].ConnectionString; }
      }

      public static string CoreGatewayUserName
      {
         get { return ConfigurationManager.AppSettings["CoreGatewayUserName"]; }
      }

      public static string CoreGatewayPassword
      {
         get { return ConfigurationManager.AppSettings["CoreGatewayPassword"]; }
      }

      private static SBSBankGateway.Service sBSBankService;
      public static SBSBankGateway.Service SBSBankService
      {
         get
         {
            if (sBSBankService == null)
            {
               sBSBankService = new SBSCore.SBSBankGateway.Service();
               sBSBankService.Url = System.Configuration.ConfigurationManager.AppSettings["SBSCore_SBSBankGateway_Service"];
               Util.SBSBankService.Timeout = 60000;
            }
            return sBSBankService;
         }
      }

      private static PorscheGateway.SBSGateway porscheService;
      public static PorscheGateway.SBSGateway PorscheService
      {
          get
          {
              if (porscheService == null)
              {
                  porscheService = new PorscheGateway.SBSGateway();
                  porscheService.Url = System.Configuration.ConfigurationManager.AppSettings["SBSCore_PorscheGateway_SBSGateway"];
                  Util.PorscheService.Timeout = 60000;
              }
              return porscheService;
          }
      }

      private static HnxGateway.Gateway hnxGateway;
      public static HnxGateway.Gateway HNXGateway
      {
         get
         {
            if (hnxGateway == null)
            {
               hnxGateway = new SBSCore.HnxGateway.Gateway();
               hnxGateway.Url = System.Configuration.ConfigurationManager.AppSettings["SBSCore_HnxGateway_Gateway"];
               hnxGateway.Timeout = 60000;
            }
            return hnxGateway;
         }
      }

      private static HoseGateway.Gateway hoseGateway;
      public static HoseGateway.Gateway HoseGateWay
      {
         get
         {
            if (hoseGateway == null)
            {
               hoseGateway = new SBSCore.HoseGateway.Gateway();
               hoseGateway.Url = System.Configuration.ConfigurationManager.AppSettings["SBSCore_HoseGateway_Gateway"];
               hoseGateway.Timeout = 60000;
            }
            return hoseGateway;
         }
      }

      private static CoreCommonService.CommonService commonService;
      public static CoreCommonService.CommonService CommonService
      {
         get
         {
            if (commonService == null)
            {
               commonService = new CoreCommonService.CommonService();
               commonService.Url = System.Configuration.ConfigurationManager.AppSettings["SBSCore_CommonService_Gateway"];
               commonService.Timeout = 60000;
            }
            return commonService;
         }
      }

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
