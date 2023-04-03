using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRMDomain.Common
{
   public static class GlobalConstants
   {
      public const string HOSEBoard = "M";
      public const string HNXBoard = "S";

      public const string SBS_HTBUTRU_TIENMUACK = "APTT3"; // hach toan tu dong tien mua ck ngay T
      public const string SBS_TINHLAI = "INTER"; //tinh lai
      public const string SBS_TINHFEE_LUUKY = "CTODY"; //tinh fee luu ly
      public const string SBS_CHAMTIENT = "DEFER"; //cham tien ngay T

      public const string HACHTOAN_GIAINGANHDKH = "VRMDC"; // Deburse - interm Contract
      public const string HACHTOAN_THANHLYHDKH = "VRMWC";  // Withdraw - interm Contract

      public const string HD_GIAINGAN = "D";
      public const string HD_THANHLY_THULAI = "I";
      public const string HD_THANHLY_THUNOGOC = "W";

      public const string ADMIN_BRANCH_RIGHT = "AdminBranch";
      public const string ADMIN_LOCAL_RIGHT = "AdminLocal";
      public const string SR_KHDB = "QTRR_TheoGioiKhachHangDacBiet";

      //public const string SP_SBS_GETTRANSACTIONDAYSTATUS = "Luantx_charly_gettransactiondaystatus";
      //public const string SP_SBS_REPORTBUYCASHCONTRACTLIST = "Luantx_charly_Report_BuycashContractList";

      //public const string SP_SBS_INSERTCUSTOMERDEBITLIMIT = "CustomerDebitLimit_Insert";
      //public const string SP_SBS_INSERTORDER = "Order_Insert";
      //public const string SP_SBS_INSERTDEBITTRANSACTION = "CustomerDebitLimitTransaction_Insert";
      //public const string SP_SBS_INSERTUSERGROUP = "UserGroup_Insert";
      //public const string SP_SBS_UPDATEUSERGROUP = "UserGroup_Update";
      //public const string SP_SBS_CHANGEPASSWORD = "User_ChangePassword";

      //public const string SP_SBS_CUSTOMERSTOCKENQUIRY = "Customer_StockEnquiry";
      //public const string SP_SBS_GLSTOCKCODEGETPRICE = "GLStockCode_GetPrice";

      //public const string SP_SBS_GETBANKACCOUNTINFOR = "BankAccountInfor_Get";
      //public const string SP_SBS_GETCUSTOMERSTOCKDETAIL = "GetCustomerStockDetails";
      //public const string SP_SBS_GETCUSTOMERCASHDETAIL = "GetCustomerCashDetails";
      //public const string SP_SBS_GETORDERFEE = "GetOrderFee";
      //public const string SP_SBS_GETCUSTOMERBALANCE = "CustomerBalance_Get";
      //public const string SP_SBS_GETCUSTOMERDEBITLIMIT = "CustomerDebitLimit_Get";
      //public const string SP_SBS_GETCUSTOMER = "Customer_Get";
      //public const string SP_SBS_GETCUSTOMERCURRENTLIMITVALUE = "CustomerDebitLimit_CurrentLimitValue";
      //public const string SP_SBS_GETCURRENTSESSION = "OrderSession_GetSession";
      //public const string SP_SBS_GETORDERLIST = "Order_List";
      //public const string SP_SBS_GETCUSTOMERSERVICE = "CustomerService_GetList";
      //public const string SP_SBS_GETONLINEBANK = "OnlineBank_GetList";
      //public const string SP_SBS_GETTDATE = "System_GetTDate";

      //public const string SP_SBS_DELETEORDER = "Order_Delete";
      //public const string SP_SBS_APPROVEORDER = "pr_OrderApprove";

      //public const string SP_SBS_REPORT_MATCHEDORDER = "Report_MatchedOrder";
      //public const string SP_SBS_REPORT_MONTHLYTRADINGRESULT = "Report_GetMonthlyTradingResult";
      //public const string SP_SBS_REPORT_TRANSFERFEEAGENT = "Report_TransferFeeAgent";

      public const string SPSBS_CUSTOMERSTOCKENQUIRY = "Customer_StockEnquiry";
      public const string SPSBS_CHANGEPASSWORD = "User_ChangePassword";

      public const string SPSBS_BALANCE_SELECTTRANSACTIONNUMBER = "Balance_SelectTransactionNumber";
      public const string SPSBS_GETTRANSACTIONCODENUMBER = "GetTransactionCodeNumber";

      public const string SPSBS_BALANCEENTRY_INSERT = "BalanceEntry_Insert";
      public const string SPSBS_CLEARINGTRADING_SETDEFERRED = "ClearingTrading_SetDeferred";
      public const string SPSBS_DEFEREDTRANSACTIONDAY_INSERT = "DeferredTransactionDay_Insert";
      public const string SPSBS_DEFEREDTRANSACTIONDAY_APPROVE = "DeferredTransactionDay_Approve";

      public const string SPSBS_BALANCEOBJECT_CREATE = "BalanceObject_Create";
      public const string SPSBS_CUSTOMERDEBITLIMIT_INSERT = "CustomerDebitLimit_Insert";
      public const string SPSBS_BALANCEENTRYGETUSERTRANSCODE = "BalanceEntry_GetUserTransCode";
      public const string SPSBS_BALANCEENTRY_DELETEAPPROVED = "vrm_BalanceEntry_DeleteApproved";
      public const string SPSBS_BALANCEENTRY_DELETENOTAPPROVED = "vrm_BalanceEntry_DeleteNotApproved";
      public const string SPSBS_BALANCEENTRY_APPROVING = "BalanceEntry_Approving";

      public const string SPSBS_GETCUSTOMERBANK = "CustomerBank_Get";
      public const string SPSBS_CUSTOMERCREDITUNBLOCK = "CustomerDebitLimit_CreditUnBlock";
      public const string SPSBS_INSERTCUSTOMERTRANSACTIONDAY = "CustomerTransactionDay_Insert";
      public const string SPSBS_INSERTCUSTOMERTRANSACTIONDAYAPPROVE = "CustomerTransactionDay_Approve";

   }
}
