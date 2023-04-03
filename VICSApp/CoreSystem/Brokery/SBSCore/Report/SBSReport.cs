using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBSCore.Common;
using SBSCore.PorscheGateway;
using SBSCore.Security;
using System.Configuration;

namespace SBSCore.Report
{
   public static class SBSReport
   {
      public static PorscheCredentials PorscheCredentials(UserLite user)
      {
         PorscheCredentials porscheCredentials = new PorscheCredentials();
         porscheCredentials.SBSUser = new PorscheCredentialsUser();
         porscheCredentials.SBSUser.BranchCode = user.BranchCode;
         porscheCredentials.SBSUser.UserName = user.UserName;
         porscheCredentials.SBSUser.TradeCode = user.TradeCode;
         porscheCredentials.GatewayUsername = ConfigurationManager.AppSettings["PorscheUserName"];
         porscheCredentials.GatewayPassword = ConfigurationManager.AppSettings["PorschePassword"];
         porscheCredentials.RequestType = "BackOffice";
         porscheCredentials.ClientInfor = new ClientInformation();
         porscheCredentials.ClientInfor.ClientName = string.Format("VICSAgency-{0}", user.ClientIP);
         porscheCredentials.ClientInfor.ClientIp = user.ClientIP;
         return porscheCredentials;
      }

      #region Customers

      public static BalanceTransactionDataSource GetBalanceTransaction(UserLite user, string bankGl, string sectionGl, string accountId, string accountType, DateTime fromDate, DateTime toDate)
      {
         PorscheCredentials porscheCredentials = new PorscheCredentials();
         porscheCredentials.GatewayUsername = ConfigurationManager.AppSettings["PorscheUserName"];
         porscheCredentials.GatewayPassword = ConfigurationManager.AppSettings["PorschePassword"];

         ClientParam clientParam = new ClientParam();
         clientParam.BranchCode = user.BranchCode;
         clientParam.BankGl = bankGl;
         clientParam.SectionGl = sectionGl;
         clientParam.AccountId = accountId;
         clientParam.AccountType = accountType;
         clientParam.FromDate = fromDate;
         clientParam.ToDate = toDate;

         TransactionDateData firstTransactionDate = Util.PorscheService.GetFirstTransactionDate(porscheCredentials, clientParam);
         if (firstTransactionDate.Code != "Normal")
            throw new InvalidProgramException(firstTransactionDate.Message);
         if (firstTransactionDate.TransactionDate > toDate)
            throw new InvalidProgramException(string.Format("Không có dữ liệu vì ngày giao dịch chính thức bắt đầu từ ngày {0}", firstTransactionDate.TransactionDate));

         clientParam.FromDate = firstTransactionDate.TransactionDate;
         clientParam.GlChartAccountCustomerFilter = string.Empty;
         clientParam.AllowInquiryCompanyPrivateAccount = true;

         return Util.PorscheService.GetBalanceTransaction(porscheCredentials, clientParam);
      }

      public static ContigenTransactionDataSource GetContigenTransaction(UserLite user, string bankGl, string sectionGl, string accountId, string accountType, DateTime fromDate, DateTime toDate)
      {

         PorscheCredentials porscheCredentials = new PorscheCredentials();
         porscheCredentials.GatewayUsername = ConfigurationManager.AppSettings["PorscheUserName"];
         porscheCredentials.GatewayPassword = ConfigurationManager.AppSettings["PorschePassword"];
         ClientParam clientParam = new ClientParam();
         clientParam.BranchCode = user.BranchCode;
         clientParam.BankGl = bankGl;
         clientParam.SectionGl = sectionGl;
         clientParam.AccountId = accountId;
         clientParam.AccountType = accountType;
         clientParam.FromDate = fromDate;
         clientParam.ToDate = toDate;

         TransactionDateData firstTransactionDate = Util.PorscheService.GetFirstTransactionDate(porscheCredentials, clientParam);
         if (firstTransactionDate.Code != "Normal")
            throw new InvalidProgramException(firstTransactionDate.Message);
         if (firstTransactionDate.TransactionDate > toDate)
            throw new InvalidProgramException(string.Format("Không có dữ liệu vì ngày giao dịch chính thức bắt đầu từ ngày {0}", firstTransactionDate.TransactionDate));

         clientParam.FromDate = firstTransactionDate.TransactionDate;
         clientParam.GlChartAccountCustomerFilter = string.Empty;
         clientParam.AllowInquiryCompanyPrivateAccount = true;
         return Util.PorscheService.GetContigenTransaction(porscheCredentials, clientParam);

      }

      public static DataTable GetAccountName(string accountID, string branchCode)
      {
          var sql = new StringBuilder();
          sql.AppendFormat("select * from Balance where AccountId = '{0}' AND BranchCode='{1}'", accountID, branchCode);
          return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }

      public static DataTable GetCustomerStockEnquiry(string AccountID, string BranchCode, DateTime TradingDate)
      {
         SqlParameter[] sqlParams = new SqlParameter[] { 
                new SqlParameter("@AccountID", AccountID), 
                new SqlParameter("@BranchCode", BranchCode), 
                new SqlParameter("@TradingDate", TradingDate) 
          };
         return DBUtil.SPExecuteDataSet(ProviderConstants.SP_SBS_CUSTOMERSTOCKENQUIRY, sqlParams).Tables[0];
      }

      public static DataTable GetCustomerOrder3DayEarly(string AccountID, string BranchCode, DateTime TradingDate)
      {
         DateTime t3date = TradingDate;
         SqlParameter paramTdate = new SqlParameter("@TDate", t3date);
         paramTdate.Direction = ParameterDirection.Output;
         SqlParameter[] GetDateParams = new SqlParameter[] { 
                new SqlParameter("@BranchCode", BranchCode), 
                new SqlParameter("@TransactionDate", TradingDate), 
                new SqlParameter("@GetFutureDate", "0"),
                new SqlParameter("@NumberOfDay", "3"),
                paramTdate
          };
         DBUtil.SPExecuteNonQuery("System_GetTDate", GetDateParams);
         return GetCustomerOrderHistory(AccountID, Convert.ToDateTime(paramTdate.Value), TradingDate);
      }

      public static DataTable GetCustomerOrderHistory(string AccountID, DateTime fromDate, DateTime toDate)
      {
         SqlParameter[] GetOrderParams = new SqlParameter[] { 
                new SqlParameter("@FromDate", fromDate), 
                new SqlParameter("@ToDate", toDate), 
                new SqlParameter("@CustomerID", AccountID)
          };
         return DBUtil.SPExecuteDataSet("Report_GetOrderHistory", GetOrderParams).Tables[0];
      }

      public static decimal GetCustomerCurrentBalance(string AccountID, string BranchCode, DateTime TradingDate)
      {
         SqlParameter[] sqlParams = new SqlParameter[] { 
                new SqlParameter("@CustomerID", AccountID), 
                new SqlParameter("@TransDate",TradingDate), 
                new SqlParameter("@BranchCode",BranchCode) 
          };
         return Convert.ToDecimal(DBUtil.SPExecuteDataSet("CustomerCurrentBalance_Hist_Get", sqlParams).Tables[0].Rows[0][0]);
      }

      public static DataTable GetCustomerLostAndProfit(string AccountID, DateTime fromDate)
      {
         SqlParameter[] sqlParams = new SqlParameter[] { 
              new SqlParameter("@FromDate",fromDate),
              new SqlParameter("@CustomerID", AccountID)
          };
         return DBUtil.SPExecuteDataSet("Customer_Report_LostAndProfit", sqlParams).Tables[0];
      }

      public static DataTable GetCustomerOrderReport(string customerId, DateTime tradingDate)
      {
         return DBUtil.ExecuteDataSet(SqlHelper.BuildGetCustomerOrderReportSql(customerId, tradingDate)).Tables[0];
      }

      public static DataTable GetCustomerSubTradingResult(string customerId, DateTime tradingDate)
      {
         SqlParameter[] sqlParams = new SqlParameter[] { 
              new SqlParameter("@TradingDate",tradingDate.ToString("dd/MM/yyyy")),
              new SqlParameter("@CustomerID", customerId)
          };
         return DBUtil.SPExecuteDataSet("Report_GetCustomerSubTradingResult", sqlParams).Tables[0];
      }




      #endregion

      #region AgencyReport

      public static DataTable GetAgencyOrderReport(UserLite user, DateTime tradingDate, string boardType, string orderSide, string customerId)
      {
         return DBUtil.ExecuteDataSet(SqlHelper.BuildGetAgencyOrderReportSql(user, tradingDate, boardType, orderSide, customerId)).Tables[0];
      }

      public static DataTable GetAgencyMatchedOrderReport(UserLite user, DateTime fromDate, DateTime toDate, string boardType, string orderSide, string stockType)
      {
         SqlParameter[] GetOrderParams = new SqlParameter[] { 
                new SqlParameter("@FromDate", fromDate), 
                new SqlParameter("@ToDate", toDate), 
                new SqlParameter("@BranchCode", user.BranchCode),
                new SqlParameter("@TradeCode", user.TradeCode),
                new SqlParameter("@BoardType", boardType),
                new SqlParameter("@StockType", stockType),
                new SqlParameter("@OrderSide", orderSide),
                new SqlParameter("@BankCode", string.Empty)
          };

         var storeName = ProviderConstants.SP_SBS_REPORT_MATCHEDORDER;
         if (!user.IsAgencyUser) storeName = storeName.Replace("Agency_", string.Empty);
         return DBUtil.SPExecuteDataSet(storeName, GetOrderParams).Tables[0];
      }

      public static DataTable GetMonthlyTradingResultReport(UserLite user, DateTime fromDate, DateTime toDate, string boardType)
      {
         SqlParameter[] GetOrderParams = new SqlParameter[] { 
                new SqlParameter("@FromDate", fromDate), 
                new SqlParameter("@ToDate", toDate), 
                new SqlParameter("@BranchCode", user.BranchCode),
                new SqlParameter("@TradeCode", user.TradeCode),
                new SqlParameter("@BoardType", boardType),
                new SqlParameter("@AllowInquiryCompanyPrivateAccount", 1),
                new SqlParameter("@BankCode", string.Empty)
          };

         var storeName = ProviderConstants.SP_SBS_REPORT_MONTHLYTRADINGRESULT;
         if (!user.IsAgencyUser) storeName = storeName.Replace("Agency_", string.Empty);
         return DBUtil.SPExecuteDataSet(storeName, GetOrderParams).Tables[0];
      }

      public static DataTable GetTransferFeeAgentReport(UserLite user, DateTime fromDate, DateTime toDate)
      {
         SqlParameter[] GetOrderParams = new SqlParameter[] { 
                new SqlParameter("@FromDate", fromDate), 
                new SqlParameter("@ToDate", toDate), 
                new SqlParameter("@BranchCode", user.BranchCode),
                new SqlParameter("@TradeCode", user.TradeCode),
          };
         return DBUtil.SPExecuteDataSet(ProviderConstants.SP_SBS_REPORT_TRANSFERFEEAGENT, GetOrderParams).Tables[0];
      }

      #endregion

      #region SqlHelper

      private sealed class SqlHelper
      {
         internal static string BuildGetAgencyOrderReportSql(UserLite user, DateTime tradingDate, string boardType, string orderSide, string customerId)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT [OrderDate], CONVERT(NVarChar,[OrderSeq]) AS [OrderSeq], [OrderSide], [StockOrderHist].[CustomerId], \n");
            sql.Append("[CustomerBranchCode], [StockOrderHist].[CustomerTradeCode], [StockCode], [TransactionDate], [OrderType], [OrderVolume], \n");
            sql.Append("[OrderPrice] * 1000 AS [OrderPrice], [OrderTime], [ReceivedBy] FROM [dbo].[StockOrderHist] ");
            if (user.IsAgencyUser)
               sql.AppendFormat("JOIN AgencyCustomer ON StockOrderHist.CustomerId = AgencyCustomer.CustomerId AND AgencyCustomer.AgencyTradeCode= '{0}' \n", user.TradeCode);
            sql.AppendFormat("WHERE ([BranchCode] = '{0}') ", user.BranchCode);
            sql.AppendFormat("AND [TransactionDate] = {0} ", LiteralUtil.GetLiteral(tradingDate));
            if (!string.IsNullOrEmpty(boardType))
               sql.AppendFormat("AND [BoardType] = '{0}' ", LiteralUtil.GetLiteral(boardType));
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("AND [CustomerId] LIKE '{0}' ", LiteralUtil.GetLiteral(customerId));
            if (!string.IsNullOrEmpty(orderSide))
               sql.AppendFormat("AND [OrderSide] = '{0}' \n", LiteralUtil.GetLiteral(orderSide));

            sql.Append("UNION ALL SELECT [OrderDate], CONVERT(NVarChar,[OrderSeq]) AS [OrderSeq], [OrderSide], [StockOrder].[CustomerId], \n");
            sql.Append("[CustomerBranchCode], [StockOrder].[CustomerTradeCode], [StockCode], [TransactionDate], [OrderType], [OrderVolume], \n");
            sql.Append("[OrderPrice] * 1000 AS [OrderPrice], [OrderTime], [ReceivedBy] FROM [dbo].[StockOrder] ");
            if (user.IsAgencyUser)
                sql.AppendFormat("JOIN AgencyCustomer ON StockOrder.CustomerId = AgencyCustomer.CustomerId AND AgencyCustomer.AgencyTradeCode= '{0}' \n", user.TradeCode);
            sql.AppendFormat("WHERE ([BranchCode] = '{0}') ", user.BranchCode);
            //sql.AppendFormat("AND [TransactionDate] = {0} ", LiteralUtil.GetLiteral(tradingDate));
            if (!string.IsNullOrEmpty(boardType))
               sql.AppendFormat("AND [BoardType] = '{0}' ", LiteralUtil.GetLiteral(boardType));
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("AND [CustomerId] LIKE '{0}' ", LiteralUtil.GetLiteral(customerId));
            if (!string.IsNullOrEmpty(orderSide))
               sql.AppendFormat("AND [OrderSide] = '{0}' ", LiteralUtil.GetLiteral(orderSide));

            return sql.ToString();
         }

         internal static string BuildGetCustomerOrderReportSql(string customerId, DateTime tradingDate)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT [t0].[OrderDate], [t0].[OrderNo], [t0].[TradeCode], CONVERT(NVarChar,[t0].[OrderSeq]) AS [OrderSeq], \n");
            sql.Append("[t0].[OrderSide], [t0].[CustomerId], [t0].[BoardType], [t0].[StockCode], [t0].[MatchedVolume], [t0].[MatchedPrice], [t0].[MatchedValue], \n");
            sql.Append("[t0].[FeeRate], [t0].[TransactionDate], [t0].[FeeRate] * [t0].[MatchedValue] AS [FeeValue], [t1].[OrderType] AS [OrderType], [t1].[OrderVolume] \n");
            sql.Append("AS [OrderVolume], [t1].[OrderPrice] AS [OrderPrice] \n");
            sql.Append("FROM [dbo].[TradingResult] AS [t0] \n");
            
            sql.Append("LEFT OUTER JOIN [dbo].[TradingOrder] AS [t1] ON [t0].[OrderDate] = [t1].[OrderDate] AND [t0].[OrderNo] = [t1].[OrderNo] \n");
            sql.AppendFormat("WHERE [t0].[CustomerId] = '{0}' AND [t0].[NoPost] != 1 AND [t0].[OrderSeq] IS NOT NULL ", LiteralUtil.GetLiteral(customerId));
            //sql.AppendFormat("AND [t0].[TransactionDate] = {0} \n", LiteralUtil.GetLiteral(tradingDate));

            sql.Append("UNION ALL SELECT [t0].[OrderDate], [t0].[OrderNo], [t0].[TradeCode], CONVERT(NVarChar,[t0].[OrderSeq]) AS [OrderSeq], \n");
            sql.Append("[t0].[OrderSide], [t0].[CustomerId], [t0].[BoardType], [t0].[StockCode], [t0].[MatchedVolume], [t0].[MatchedPrice], [t0].[MatchedValue], \n");
            sql.Append("[t0].[FeeRate], [t0].[TransactionDate], [t0].[FeeRate] * [t0].[MatchedValue] AS [FeeValue], [t1].[OrderType] AS [OrderType], [t1].[OrderVolume] \n");
            sql.Append("AS [OrderVolume], [t1].[OrderPrice] AS [OrderPrice] \n");
            sql.Append("FROM [dbo].[TradingResultHist] AS [t0] \n");
            sql.Append("LEFT OUTER JOIN [dbo].[TradingOrderHist] AS [t1] ON [t0].[OrderDate] = [t1].[OrderDate] AND [t0].[OrderNo] = [t1].[OrderNo] \n");
            sql.AppendFormat("WHERE [t0].[CustomerId] = '{0}' AND [t0].[NoPost] != 1 AND [t0].[OrderSeq] IS NOT NULL ", LiteralUtil.GetLiteral(customerId));
            sql.AppendFormat("AND [t0].[TransactionDate] = {0} ", LiteralUtil.GetLiteral(tradingDate));
            sql.Append("ORDER BY [t0].[TransactionDate], [t0].[BoardType], [t0].[CustomerId] ");

            return sql.ToString();
         }
      }

      #endregion
   }
}
