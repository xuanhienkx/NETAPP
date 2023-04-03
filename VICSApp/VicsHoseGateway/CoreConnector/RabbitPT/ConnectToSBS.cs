using System;
using System.Collections.Generic;
//using System.Linq;
using System.Globalization;
using System.Text;

namespace HOGW_PT_Dealer
{
   public partial class ConnectToSBS
   {
      public string createOrder(string gwUser, string gwPass, string orderdate, string orderside,
        string ordertype, string stockcode,
        decimal ordervolume, decimal orderprice, string customerid,
        string branchcode, string tradecode,
        string receivedby, string notes, string refno, string isApproved)
      {
         return Util.SBSCommonGW.CreateStockOrder(gwUser, gwPass, orderdate, orderside, ordertype, stockcode,
                                                  ordervolume.ToString(CultureInfo.InvariantCulture),
                                                  orderprice.ToString(CultureInfo.InvariantCulture), "0", "0",
                                                  customerid, branchcode, tradecode, receivedby, "pt", notes);
      }

      public string deleteOrder(string gwUser, string gwPass, string orderdate, string orderseq)
      {
         return Util.SBSGW.OrderAgentDelete(gwUser, gwPass, orderdate, orderseq);
      }

      public string getTranDate(string gwUser, string gwPass, string branchcode)
      {
         try
         {
            return Util.SBSGW.GetCurrentTransactionDate(gwUser, gwPass, branchcode);
         }
         catch
         {
            return System.DateTime.Now.ToString("dd/MM/yyyy");
         }
      }

      public string getAvailableBalance(string gwUser, string gwPass, string customerid)
      {
         return Util.SBSGW.GetMoneyAmount(gwUser, gwPass, customerid);
      }

      public string getCustomerBalanceInfo(string gwUser, string gwPass, string customerid)
      {
         return Util.SBSGW.GetCustomerBalanceInformation(gwUser, gwPass, customerid);
      }
      public string getStockEnquiry(string gwUser, string gwPass, string cusID, string transDate)
      {
         return Util.SBSGW.GetStockEnquiry(gwUser, gwPass, cusID, transDate);
      }
   }
}
