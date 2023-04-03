using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using VRMDomain.Common;
using System.Data;

namespace VRMDomain.Domain
{
   public sealed class DebtInfo
   {
      public DebtInfo() { }
      public decimal OverdueDebt;
      public decimal IndueDebt;

      internal static DebtInfo GetDebtInfo(string customerId, DateTime transDate, UserLite user)
      {
         Contract currentC = Contract.GetCurrentContract(customerId, user);
         return GetDebtInfo(customerId, transDate, currentC.ContractType, user);
      }

      internal static DebtInfo GetDebtInfo(string customerId, DateTime transDate, ContractType contractType, UserLite user)
      {
         string sql = SqlHelper.BuildGet(customerId, contractType, user);
         return DB2Object(DBUtil.ExecuteDataReader(sql));
      }

      private static DebtInfo DB2Object(SqlDataReader sqlDataReader)
      {
         DebtInfo result = new DebtInfo();
         if (sqlDataReader.Read())
         {
            if (sqlDataReader["OverdueDebt"] != DBNull.Value)
               result.OverdueDebt = (decimal)sqlDataReader["OverdueDebt"];
            if (sqlDataReader["IndueDebt"] != DBNull.Value)
               result.IndueDebt = (decimal)sqlDataReader["IndueDebt"];
         }
         sqlDataReader.Close();
         return result;
      }

      public static DataTable GetDebitLimitInfo(string customerId)
      {
         StringBuilder sql = new StringBuilder();

         sql.Append("select cb.limitvalue, cb.currentlimitvalue, t.matechebuyingdordervalue,x.totalbuyingordervalue,th.LastMonthTradingValue \n");
         sql.AppendFormat("from customers c left join customerdebitlimit cb on c.customerid = cb.customerid and cb.customerid = '{0}' and cb.isactive=1 \n", customerId);
         sql.AppendFormat("left join (select '{0}' as customerid, sum(matchedvalue) as matechebuyingdordervalue from tradingresult \n", customerId);
         sql.AppendFormat("where orderside = 'B' and customerid = '{0}') t on c.customerid = t.customerid \n", customerId);
         sql.AppendFormat("left join (select '{0}' as customerid, sum((s.ordervolume - isnull(c.cancelledvolume, 0)) * s.orderprice * 1000) as totalbuyingordervalue \n", customerId);
         sql.AppendFormat("from stockorder s left join tradingorder c on c.orderseq = s.orderseq \n", customerId);
         sql.AppendFormat("where s.orderside = 'B' and s.customerid = '{0}' and s.orderstatus in ('R','P','S','E') \n", customerId);
         sql.Append(") x on c.customerid = x.customerid \n");
         sql.AppendFormat("left join (select '{0}' as customerid, sum(matchedvalue) as LastMonthTradingValue from tradingresulthist \n", customerId);
         sql.AppendFormat("where customerid = '{0}' and year(transactiondate) = year(dateadd(month,-1,getdate())) \n", customerId);
         sql.Append("and month(transactiondate)=month(dateadd(month,-1,getdate()))) th on c.customerid = th.customerid \n");
         sql.AppendFormat("where c. customerid = '{0}' ", customerId);

         return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }

      private sealed class SqlHelper
      {
         internal static string BuildGet(string customerId, ContractType contractType, UserLite user)
         {
            StringBuilder sql = new StringBuilder();

            if (contractType == ContractType.KhongThoiHan)// không kỳ hạn
            {
               sql.Append("SELECT ");
               sql.Append("SUM(CASE WHEN TradingDate BETWEEN DueDate AND ExpiredDate THEN CurrentDebit END) AS IndueDebt, \n");
               sql.Append("SUM(CASE WHEN TradingDate > ExpiredDate THEN CurrentDebit END) AS OverdueDebt \n");
               sql.Append("FROM dbo.DeferredBalance \n");
               sql.Append("JOIN dbo.vrm_Contract ON dbo.DeferredBalance.CustomerID = dbo.vrm_Contract.CustomerId AND ContractType = 1 \n");
               if (!string.IsNullOrEmpty(customerId))
                  sql.AppendFormat("WHERE dbo.vrm_Contract.CustomerId = '{0}' ", LiteralUtil.GetLiteral(customerId));
            }
            else // có kỳ hạn
            {
               sql.Append("SELECT \n");
               sql.Append("SUM(CASE WHEN ExpiredDate >= GETDATE() THEN x.Amount END) AS IndueDebt, \n");
               sql.Append("SUM(CASE WHEN ExpiredDate < GETDATE() THEN x.Amount END) AS OverdueDebt \n");
               sql.Append("FROM dbo.vrm_Contract JOIN (SELECT c.AccountId, c.Amount \n");
               sql.Append("FROM dbo.TransactionHist c \n");
               sql.Append("JOIN dbo.TransactionHist d ON c.BranchCode = d.BranchCode AND c.TransactionNumber = d.TransactionNumber AND c.TransactionDate = d.TransactionDate \n");
               sql.Append("WHERE c.DebitOrCredit = 'C' AND d.DebitOrCredit = 'D' AND d.BankGl = '135400' \n");
               sql.Append("UNION SELECT c.AccountId, c.Amount FROM dbo.TransactionDay c \n");
               sql.Append("JOIN dbo.TransactionDay d ON c.BranchCode = d.BranchCode AND c.TransactionNumber = d.TransactionNumber AND c.TransactionDate = d.TransactionDate \n");
               sql.Append("WHERE c.DebitOrCredit = 'C' AND d.DebitOrCredit = 'D' AND d.BankGl = '135400' \n");
               sql.Append(") x ON x.AccountId = dbo.vrm_Contract.CustomerId WHERE ContractType = 0 \n");
               if (!string.IsNullOrEmpty(customerId))
                  sql.AppendFormat("AND dbo.vrm_Contract.CustomerId = '{0}' ", LiteralUtil.GetLiteral(customerId));
            }

            return sql.ToString();
         }
      }
   }
}
