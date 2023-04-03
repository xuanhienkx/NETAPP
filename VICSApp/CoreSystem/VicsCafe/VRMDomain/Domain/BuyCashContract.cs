using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRMDomain.Common;
using System.Data.SqlClient;
using System.Data;

namespace VRMDomain.Domain
{
   public class BuyCashContract
   {
      public string ContractId, BranchCode, CustomerId, CustomerName, CardIdentity, CardIssuer, CustomerTel, CustomerAddress;
      public string StockType, RateType, Status, UserCreate, Notes, TradeCodeCreate;
      public DateTime CardDate, OrderDate, DateContract, PaymentDate;
      public decimal AdvanceAmount, AdvanceFee, AdvanceFeeRate, ManageFee, PendingAmount, OrderFeeValue, OrderFeeRate, AmountLeft;
      public int NumberOfDate;
      public Guid Id;
      public bool SoldMortage;

      public static List<BuyCashContract> GetList(DateTime createdDate, string status, UserLite user)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("select * from Luantx_Charly_BuyCashContractRequest ");
         sql.AppendFormat("where BranchCode = '{0}' and DateContract = {1} ", user.BranchCode, LiteralUtil.GetLiteral(createdDate));
         if (!string.IsNullOrEmpty(status))
            sql.AppendFormat("and Status = '{0}'", LiteralUtil.GetLiteral(status));
         sql.Append("\n order by customerid");

         List<BuyCashContract> result = new List<BuyCashContract>();
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql.ToString()))
         {
            while (r.Read())
            {
               result.Add(DB2Obj(r));
            }
            r.Close();
            r.Dispose();
         }
         return result;
      }

      public static void ChangeStatus(Guid id, string status, UserLite user)
      {
         string sql = string.Format("update Luantx_Charly_BuyCashContractRequest set status = '{0}' where id = '{1}'",
            LiteralUtil.GetLiteral(status),
            id.ToString());
         DBUtil.ExecuteNonQuery(sql);
      }

      private static BuyCashContract DB2Obj(SqlDataReader r)
      {
         BuyCashContract obj = new BuyCashContract();
         obj.ContractId = (string)r["ContractId"];
         obj.BranchCode = (string)r["BranchCode"];
         obj.CustomerId = (string)r["CustomerId"];
         obj.CustomerName = (string)r["CustomerName"];
         obj.CardIdentity = (string)r["CardIdentity"];
         obj.CardIssuer = (string)r["CardIssuer"];
         obj.CustomerTel = (string)r["CustomerTel"];
         obj.CustomerAddress = (string)r["CustomerAddress"];
         obj.StockType = (string)r["StockType"];
         obj.RateType = (string)r["RateType"];
         obj.Status = (string)r["Status"];
         obj.UserCreate = (string)r["UserCreate"];
         obj.Notes = (string)r["Notes"];
         obj.TradeCodeCreate = (string)r["TradeCodeCreate"];

         obj.CardDate = (DateTime)r["CardDate"];
         obj.OrderDate = (DateTime)r["OrderDate"];
         obj.DateContract = (DateTime)r["DateContract"];
         obj.PaymentDate = (DateTime)r["PaymentDate"];

         obj.AdvanceAmount = (decimal)r["AdvanceAmount"];
         obj.AdvanceFee = (decimal)r["AdvanceFee"];
         obj.AdvanceFeeRate = (decimal)r["AdvanceFeeRate"];
         obj.ManageFee = (decimal)r["ManageFee"];
         obj.PendingAmount = (decimal)r["PendingAmount"];
         obj.OrderFeeValue = (decimal)r["OrderFeeValue"];
         obj.OrderFeeRate = (decimal)r["OrderFeeRate"];
         obj.AmountLeft = (decimal)r["AmountLeft"];

         obj.NumberOfDate = (int)r["NumberOfDate"];
         obj.Id = (Guid)r["Id"];
         obj.SoldMortage = (bool)r["SoldMortage"];

         return obj;
      }

      public static DataTable GetBuyCashContractReport(DateTime fromDate, DateTime toDate, string status, string stockType, int dateType, bool isSoldMortage, UserLite user)
      {
         StringBuilder sql = new StringBuilder();
         sql.AppendLine("declare @t3Day smalldatetime");
         sql.AppendFormat("set @t3Day = dbo.fc_GetTDate ('{0}', {1} ,0,3 )", user.BranchCode, LiteralUtil.GetLiteral(fromDate));

         sql.AppendLine("SELECT a.ContractID, a.CustomerName, a.CustomerID, TransactionDate,a.DateContract,");
         sql.AppendLine("a.PaymentDate,a.NumberOfDate, a.AdvanceAmount,a.AdvanceFee, a.ManageFee, a.AdvanceAmount + a.AdvanceFee + a.ManageFee as TotalMoneyContract,");
         sql.AppendLine("isnull(b.MatchedValue,0) as MatchedValue,isnull(c.CIF,'') as CIF , isnull(c.BankCode,'') as CusBankCode,a.Notes");
         sql.AppendLine("from BuyCashContract a left join ");
         sql.AppendLine("(select CustomerId, TransactionDate, sum((MatchedValue - (MatchedValue * FeeRate))) as MatchedValue  ");
         sql.AppendLine("from (select * from dbo.TradingResult union all select * from TradingResultHist) x ");
         sql.AppendFormat("where x.BranchCode = '{0}' and x.TransactionDate between @t3Day and {1} \n",
            user.BranchCode, LiteralUtil.GetLiteral(toDate));
         sql.AppendFormat("and OrderSide = 'S' And OrderSeq IS not NULL And NoPost <> '1' \n");
         sql.AppendFormat("group by x.CustomerId, x.TransactionDate ) b on a.CustomerId = b.CustomerId and	a.OrderDate =  b.TransactionDate ");
         sql.AppendLine("left join CustomerBank c on a.CustomerID = c.CustomerID ");
         sql.AppendFormat("where a.BranchCode = '{0}' and a.StockType like '{1}' \n", user.BranchCode, stockType == "S" ? "[SU]" : "D");
         if (!string.IsNullOrEmpty(status))
            sql.AppendFormat("and a.Status = '{0}' \n", LiteralUtil.GetLiteral(status));
         if (user.IsAgencyMember)
            sql.AppendFormat("and a.TradeCodeCreate = '{0}' \n", user.TradeCode);
         sql.AppendFormat("and a.SoldMortage = {0} \n", LiteralUtil.GetLiteral(isSoldMortage));
         if (dateType == 0)
            sql.AppendFormat("and DateContract between {0} and {1} \n", LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate));
         else if (dateType == 1)
            sql.AppendFormat("and PaymentDate between {0} and {1} \n", LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate));
         else
            sql.AppendFormat("and a.OrderDate between {0} and {1} \n", LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate));

         sql.AppendFormat("and ( c.Activate is null or ( c.Activate = '1' and c.Status = 'O' )) \n");
         sql.AppendLine("order by datecontract,customerid");

         return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }
   }
}
