using Brokery.AgencyWebService;
using Brokery.Controls;
using Brokery.Properties;
using CommonDomain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Services.Protocols;
using Customer = Brokery.AgencyWebService.Customer;
using GLStockCode = Brokery.AgencyWebService.GLStockCode;
using InquiryData = Brokery.AgencyWebService.InquiryData;

namespace Brokery.Framework
{
    public static class Util
    {
        public const int HOSE_MAX_VOLUME = 500000;
        public const int HNX_MAX_VOLUME = int.MaxValue;
        public const int UPCOM_MAX_VOLUME = int.MaxValue;
        public const string HOSEBoard = "M";
        public const string HNXBoard = "S";
        public const string UPCOMBoard = "O";

        private static AgencyWebService.Brokery agencyGateway;
        public static AgencyWebService.Brokery AgencyGateway
        {
            get
            {
                return agencyGateway ??
                       (agencyGateway =
                        new AgencyWebService.Brokery
                           {
                               Url = Settings.Default.AgencyApp_AgencyWebService_GateWay,
                               Timeout = 600000
                           });
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

        private static List<GLStockCode> hnxStock;
        public static List<GLStockCode> HNXStock
        {
            get
            {
                if (hnxStock == null)
                {
                    hnxStock = new List<GLStockCode>();
                    GLStockCode[] GLStockCodes = AgencyGateway.GetStockList(TokenKey, HNXBoard);
                    if (!(GLStockCodes == null))
                        foreach (GLStockCode s in GLStockCodes)
                            hnxStock.Add(s);
                }
                return hnxStock;
            }
        }

        private static List<GLStockCode> hoseStock;
        public static List<GLStockCode> HOSEStock
        {
            get
            {
                if (hoseStock == null)
                {
                    hoseStock = new List<GLStockCode>();
                    GLStockCode[] GLStockCodes = AgencyGateway.GetStockList(TokenKey, HOSEBoard);
                    if (!(GLStockCodes == null))
                        foreach (GLStockCode s in GLStockCodes)
                            hoseStock.Add(s);
                }
                return hoseStock;
            }
        }

        private static List<GLStockCode> upcomStock;
        public static List<GLStockCode> UPCOMStock
        {
            get
            {
                if (upcomStock == null)
                {
                    upcomStock = new List<GLStockCode>();
                    GLStockCode[] GLStockCodes = AgencyGateway.GetStockList(TokenKey, UPCOMBoard);
                    if (GLStockCodes != null)
                        foreach (GLStockCode s in GLStockCodes)
                            upcomStock.Add(s);
                }
                return upcomStock;
            }
        }

        private static List<string> groupAccess;

        public static bool CheckAccess(IEnumerable<AccessPermission> permissions)
        {
            var requiredPermission = new List<AccessPermission>(permissions);
            if (requiredPermission.Contains(AccessPermission.None))
                return true;
            return requiredPermission.TrueForAll(CheckAccess);
        }

        public static bool CheckAccess(AccessPermission permission)
        {
            return CheckAccess(permission.ToString());
        }

        public static bool CheckAccess(string permission)
        {
            if (String.IsNullOrEmpty(permission) || permission == AccessPermission.None.ToString())
                return true;
            if (groupAccess == null || groupAccess.Count == 0 || !IsAuthenticated())
                return false;
            return groupAccess.Exists(rule => rule.Equals(permission, StringComparison.CurrentCultureIgnoreCase));
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
            hnxStock = null;
            hoseStock = null;
            groupAccess = null;
            loginUser = null;
            currentTran = T3Date = DateTime.MinValue;
        }

        public static string MoneyAsString(decimal? money)
        {
            if (!money.HasValue)
                money = 0M;
            return String.Format("{0:c0}", Decimal.Round(money.Value));
        }

        public static string FormatNumber(decimal? d)
        {
            if (!d.HasValue)
                d = 0M;
            return String.Format("{0:n0}", d);
        }

        public static string FormatRate(decimal? d, bool isPercent)
        {
            return FormatRate(d, 1, isPercent);
        }

        public static string FormatRate(decimal? d, int decimalDigits, bool isPercent)
        {
            if (d == null || d == 0M)
                return String.Empty;

            CultureInfo provider = CurrentCulture.Clone() as CultureInfo;
            provider.NumberFormat.PercentDecimalDigits = decimalDigits;

            if (isPercent)
                return String.Format(provider, "{0:p}", d);
            return String.Format(provider, "{0:0.0####}", d);
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

        internal static string FormatDate(DateTime? d)
        {
            if (!d.HasValue || d.Value == DateTime.MinValue || d.Value == DateTime.MaxValue)
                return String.Empty;
            return d.Value.ToString("dd/MM/yyyy");
        }

        internal static int GetNumberOfOverDueDays(DateTime payDate, DateTime loanDate, DateTime overDueDate)
        {
            if (loginUser.BranchCode == "100")
            {
                if (payDate >= overDueDate)
                    return (int)(payDate - loanDate).TotalDays;
            }
            else
            {
                if (payDate >= overDueDate)
                    return (int)(payDate - overDueDate).TotalDays;
            }
            return 0;
        }

        private static IEnumerable<int> groupAdminIds;
        internal static bool IsAdminGroup(int groupId)
        {
            if (groupAdminIds == null)
            {
                var ids =
                    ConfigurationManager.AppSettings["GroupIdAdmin"].Split(',')
                        .ToList()
                        .AsEnumerable()
                        .Select(int.Parse);
                groupAdminIds = ids;

            }
            return groupAdminIds.Contains(groupId);
        }

        public const string HOSEETFType = "E";

        internal static bool Authorize(string username, string password)
        {
            string encryptedName = CryptoEngine.Encrypt(username);
            string encryptedPass = CryptoEngine.Encrypt(password);
            string key = string.Empty;
            try
            {
                key = AgencyGateway.GetAuthorize(encryptedName, encryptedPass);
            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                if (response.StatusCode == HttpStatusCode.Found)
                {
                    AgencyGateway.Url = new Uri(new Uri(AgencyGateway.Url), response.Headers["Location"]).AbsoluteUri;
                    key = AgencyGateway.GetAuthorize(encryptedName, encryptedPass);
                }
            }

            if (String.IsNullOrEmpty(key))
                return false;
            // set token key
            TokenKey = key;
            // get login user detail
            loginUser = AgencyGateway.GetUser(TokenKey, username);

            // get curent transaction date
            currentTran = AgencyGateway.GetCurrentTransactionDate(TokenKey);

            // get T+3 date
            T3Date = AgencyGateway.GetTDate(TokenKey, currentTran, 3, true);

            // get the current access rule for user
            var accessCollection = Enum.GetNames(typeof(AccessPermission));
            if (!IsAdminGroup(loginUser.GroupId))
                accessCollection = AgencyGateway.GetGroupPermission(TokenKey, 0);

            groupAccess = new List<string>(accessCollection);
            return true;
        }

        internal static bool IsAuthenticated()
        {
            return LoginUser != null;
        }

        private static Dictionary<string, Customer> customerInfoList = new Dictionary<string, Customer>();
        internal static InquiryData GetInquiryData(InquiryData curentInquiryData)
        {
            InquiryData result = new InquiryData();

            // must do a workaround to make it effeciency
            if (customerInfoList.ContainsKey(curentInquiryData.Customer.CustomerId))
                result.Customer = customerInfoList[curentInquiryData.Customer.CustomerId];
            try
            {
                result = AgencyGateway.GetInquiryData(TokenKey, curentInquiryData, CurrentTransactionDate);
                customerInfoList[curentInquiryData.Customer.CustomerId] = result.Customer;
            }
            catch (SoapException ex)
            {
                throw new Exception(String.Format(ex.Detail.ChildNodes[0].Attributes[1].Value));
            }
            return result;
        }

        internal static Customer GetCustomer(string customerId)
        {
            if (customerInfoList.ContainsKey(customerId))
                return customerInfoList[customerId];

            Customer[] cList = AgencyGateway.FindCustomers(TokenKey, customerId, String.Empty, String.Empty,
               Util.loginUser.BranchCode, Util.loginUser.TradeCode);
            if (cList == null || cList.Length == 0)
                return null;

            customerInfoList.Add(customerId, cList[0]);
            return cList[0];
        }

        public static string GetBankGl(string customerId, AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Balance:
                    if (!customerId.StartsWith(ConfigurationManager.AppSettings["Company_PrefixF"]))
                        return ConfigurationManager.AppSettings["BankGlBalanceDomesticCustomer"];
                    return ConfigurationManager.AppSettings["BankGlBalanceForeignCustomer"];

                case AccountType.Contigen:
                    if (!customerId.StartsWith(ConfigurationManager.AppSettings["Company_PrefixF"]))
                        return ConfigurationManager.AppSettings["BankGlContigenDomesticCustomer"];
                    return ConfigurationManager.AppSettings["BankGlContigenForeignCustomer"];
            }
            return String.Empty;
        }



        public static string GetSectionGl(string customerId, AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Balance:
                    if (!customerId.StartsWith(ConfigurationManager.AppSettings["Company_PrefixF"]))
                        return ConfigurationManager.AppSettings["SectionGlBalanceDomesticCustomer"];
                    return ConfigurationManager.AppSettings["SectionGlBalanceForeignCustomer"];

                case AccountType.Contigen:
                    if (!customerId.StartsWith(ConfigurationManager.AppSettings["Company_PrefixF"]))
                        return ConfigurationManager.AppSettings["SectionGlContigenDomesticCustomer"];
                    return ConfigurationManager.AppSettings["SectionGlContigenForeignCustomer"];
            }
            return String.Empty;
        }


        public static string GetReportLocation()
        {
            return String.Format("{0}, ngày {1} tháng {2} năm {3}.",
               Parameters.AgencyLocation,
               DateTime.Now.Day,
               DateTime.Now.Month,
               DateTime.Now.Year);
        }

        //[Obsolete("Nên sửa lại là tên của hội sở hay chi nhánh")]
        public static string GetHeadOfficeOrBranchName()
        {
            if (LoginUser.BranchCode == "100")
                return ConfigurationManager.AppSettings["VICS_Name"];
            if (LoginUser.BranchCode == "200")
                return ConfigurationManager.AppSettings["VICSHCM_Name"];
            if (LoginUser.BranchCode == "300")
                return ConfigurationManager.AppSettings["VICSHUE_Name"];
            return String.Empty;
        }

        //[Obsolete("Nên sửa lại là tên của phòng giao dịch")]
        public static string GetAgencyName()
        {
            return Parameters.AgencyName;
        }

        //[Obsolete("Nên sửa lại là địa chỉ và điện thoại của hội sở hoặc chi nhánh")]
        public static string GetHeadOfficeOrBranchAddress()
        {
            if (LoginUser.BranchCode == "100")
                return ConfigurationManager.AppSettings["VICS_Address"];
            if (LoginUser.BranchCode == "200")
                return ConfigurationManager.AppSettings["VICSHCM_Address"];
            if (LoginUser.BranchCode == "300")
                return ConfigurationManager.AppSettings["VICSHUE_Address"];
            return String.Empty;
        }

        //[Obsolete("Nên sửa lại là địa chỉ và điện thoại của phòng giao dịch")]
        public static string GetAgencyAddressAndTelephone()
        {
            return Parameters.AgencyAddressAndTelephone;
        }

        public static Dictionary<string, Loading> Loading = new Dictionary<string, Loading>();

        internal static string BoardTypeDescription(string boardType)
        {
            if (boardType == Util.HNXBoard)
                return "Chứng khoán niêm yết HNX";
            if (boardType == Util.HOSEBoard)
                return "Chứng khoán niêm yết HSX";
            if (boardType == Util.UPCOMBoard)
                return "UPCOM";
            return string.Empty;
        }


        internal static void UpdateAllStocks(GLStockCode[] hoseStocks, GLStockCode[] hnxStocks, GLStockCode upcomStocks)
        {
            hoseStock = hoseStocks == null ? new List<GLStockCode>() : new List<GLStockCode>(hoseStocks);
            hnxStock = hnxStocks == null ? new List<GLStockCode>() : new List<GLStockCode>(hnxStocks);
            upcomStock = upcomStocks == null ? new List<GLStockCode>() : new List<GLStockCode>(upcomStock);
        }

    }
}
