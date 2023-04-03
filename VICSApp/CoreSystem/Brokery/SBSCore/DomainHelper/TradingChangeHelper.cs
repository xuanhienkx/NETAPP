using System.Data.SqlClient;
using System.Data;
using CommonDomain;
using SBSCore.Common;

namespace SBSCore.DomainHelper
{
   public static class TradingChangeHelper
   {
       
       internal static TradingChange Initialize(int orderSeq, string orderNo, string branchCode, string customerBranchCode, string customerID,
            string customerName, decimal valueChange, string description, string userName)
       {
           TradingChange ctd = new TradingChange();

           ctd.OrderSeq = orderSeq;
           ctd.OrderNo = orderNo;
           ctd.BranchCode = branchCode;
           ctd.CustomerBranchCode = customerBranchCode;
           ctd.CustomerID = customerID;
           ctd.CustomerName = customerName;
           ctd.ValueChange = valueChange;
           ctd.Description = description;
           ctd.UserEnter = userName;
           ctd.UserApprove = userName;
          ctd.Status = "N";

           return ctd;
       }
       internal static void Insert(TradingChange ctd)
       {

           SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_INSERTTRADINGCHANGE);

           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@OrderSeq", SqlDbType.VarChar).SqlValue = ctd.OrderSeq;
           cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).SqlValue = ctd.OrderNo;
           cmd.Parameters.Add("@BranchCode", SqlDbType.VarChar).SqlValue = ctd.BranchCode;
           cmd.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).SqlValue = ctd.CustomerBranchCode;
           cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).SqlValue = ctd.CustomerID;
           cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).SqlValue = ctd.CustomerName;
           cmd.Parameters.Add("@ValueChange", SqlDbType.Decimal).SqlValue = ctd.ValueChange;
           cmd.Parameters.Add("@Description", SqlDbType.VarChar).SqlValue = ctd.Description;
           cmd.Parameters.Add("@UserEnter", SqlDbType.VarChar).SqlValue = ctd.UserEnter;
           cmd.Parameters.Add("@UserApprove", SqlDbType.VarChar).SqlValue = ctd.UserApprove;

           cmd.ExecuteNonQuery();
       }

    }

 }
