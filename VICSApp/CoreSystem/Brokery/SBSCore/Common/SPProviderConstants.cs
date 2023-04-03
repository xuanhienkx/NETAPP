using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBSCore.Common
{
   public static class ProviderConstants
   {
      public const string SP_SBS_GETTRANSACTIONDAYSTATUS = "Luantx_charly_gettransactiondaystatus";
      public const string SP_SBS_REPORTBUYCASHCONTRACTLIST = "Luantx_charly_Report_BuycashContractList";

      public const string SP_SBS_INSERTCUSTOMERDEBITLIMIT = "CustomerDebitLimit_Insert";
      public const string SP_SBS_INSERTCUSTOMERTRANSACTIONDAY = "CustomerTransactionDay_Insert";
      public const string SP_SBS_INSERTTRADINGCHANGE = "TradingChange_Insert";
      
      public const string SP_SBS_INSERTCUSTOMERTRANSACTIONDAYAPPROVE = "CustomerTransactionDay_Approve";
      //public const string SP_SBS_INSERTORDER = "Order_Insert";
      public const string SP_SBS_INSERTORDER = "Order_Insert_Agency";
      public const string SP_SBS_INSERTDEBITTRANSACTION = "CustomerDebitLimitTransaction_Insert";
      public const string SP_SBS_INSERTUSERGROUP = "UserGroup_Insert";
      public const string SP_SBS_UPDATEUSERGROUP = "UserGroup_Update";
      public const string SP_SBS_CHANGEPASSWORD = "User_ChangePassword";

      public const string SP_SBS_CUSTOMERSTOCKENQUIRY = "Customer_StockEnquiry";
      public const string SP_SBS_GLSTOCKCODEGETPRICE = "GLStockCode_GetPrice";
      public const string SP_SBS_CUSTOMERCREDITUNBLOCK = "CustomerDebitLimit_CreditUnBlock";
      public const string SP_SBS_GETCUSTOMERPROXY = "CustomerProxy_Get";

      public const string SP_SBS_GETBANKACCOUNTINFOR = "BankAccountInfor_Get";
      public const string SP_SBS_GETCUSTOMERSTOCKDETAIL = "GetCustomerStockDetails";
      public const string SP_SBS_GETCUSTOMERCASHDETAIL = "GetCustomerCashDetails";
      public const string SP_SBS_GETORDERFEE = "GetOrderFee";
      public const string SP_SBS_GETCUSTOMERBALANCE = "CustomerBalance_Get";
      public const string SP_SBS_GETCUSTOMERBANK = "CustomerBank_Get";
      public const string SP_SBS_GETCUSTOMER = "Customer_Get";
      public const string SP_SBS_GETCUSTOMERCURRENTLIMITVALUE = "CustomerDebitLimit_CurrentLimitValue";
      public const string SP_SBS_GETCURRENTSESSION = "OrderSession_GetSession";
      public const string SP_SBS_GETORDERLIST = "Agency_Order_List";
      public const string SP_SBS_GETCUSTOMERSERVICE = "CustomerService_GetList";
      public const string SP_SBS_GETONLINEBANK = "OnlineBank_GetList";
      public const string SP_SBS_GETTDATE = "System_GetTDate";
      public const string SP_SBS_GETDEBITLIMITHISTORYLOG = "CustomerDebitLimitLog_Get";

      public const string SP_SBS_DELETEORDER = "Order_Delete";
      public const string SP_SBS_APPROVEORDER = "Order_Approve";

      public const string SP_SBS_REPORT_MATCHEDORDER = "Agency_Report_MatchedOrder";
      public const string SP_SBS_REPORT_MONTHLYTRADINGRESULT = "Agency_Report_GetMonthlyTradingResult";
      public const string SP_SBS_REPORT_TRANSFERFEEAGENT = "Report_TransferFeeAgent";

      public const string SP_SBS_UPCOM_GETORDERLISTFORCANCELREPLACE = "Luantx_charly_Order_List_4cancelchange";
      public const string SP_SBS_UPCOM_CANCELREPLACEORDER = "Luantx_charly_UPCOM_OrderCancelchange_Insert";
      public const string SP_SBS_UPCOM_GETORDERREQUESTSTATUS = "Luantx_charly_UPCOMOrderCancelChangeReq_getlist";
   }
}
