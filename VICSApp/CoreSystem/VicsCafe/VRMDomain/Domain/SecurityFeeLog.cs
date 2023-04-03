using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using Microsoft.SqlServer.Server;
using VRMDomain.Common;

namespace VRMDomain.Domain
{
    public class SecurityFeeLog
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string StockCode { get; set; }
        public int Quantity { get; set; }
        public decimal FeeRate { get; set; }
        public decimal FeeAmount { get; set; }
        public int DayCount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CallDate { get; set; }
        public string BranchCode { get; set; }
        public string Accountref { get; set; }
        public int CustomerSecurityFeeId { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }


        public static SecurityFeeLog Db2Obj(DataRow dr)
        {
            return new SecurityFeeLog
            {
                Id = (int)dr["Id"],
                CustomerId = dr["CustomerId"].ToString()
            };
        }
        public static List<SecurityFeeLog> GetCustomerSecurityFeeDetails(UserLite user, DateTime calldate, string customerId, double freeRate, bool isSellT3 = true)
        {
            double fee = freeRate *1.00;
            var pCallDate = new SqlParameter("@CallDate", SqlDbType.DateTime) { Value = calldate.Date };
            var pFeeRate = new SqlParameter("@FeeRate", SqlDbType.Decimal) { Value = fee,Precision = 4, Scale = 2 };
            var branchCode = new SqlParameter("@BranchCode", SqlDbType.VarChar) { Value = user.BranchCode };
            var accountId = new SqlParameter("@AccountId", SqlDbType.VarChar) { Value = customerId };
            var isCallT3 = new SqlParameter("@isSellT3", SqlDbType.Bit) { Value = isSellT3 };
            var callAll = new SqlParameter("@callAll", SqlDbType.Bit) { Value = 0 };
            try
            {
                var dataset = DBUtil.SPExecuteDataSet("Vrm_GetCustomerSecurityFeeDetails", pCallDate, pFeeRate, branchCode, accountId, isCallT3, callAll);
                return dataset.Tables[0].ToList<SecurityFeeLog>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static SecuriryCallResult PutFeeCustody(string customerId, decimal amount, DateTime interestedDate, UserLite user)
        {
            SecuriryCallResult callResult = new SecuriryCallResult();
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    var customer = Customer.GetCustomer(customerId, user);
                    if (customer == null)
                        return callResult;
                    var transactionResult = TransactionUtil.CreateTransaction(
                           BalanceAccount.Get_324111(customer.CustomerId, user),
                           BalanceAccount.Get_511611(customer.CustomerId, user),
                           GlobalConstants.SBS_TINHFEE_LUUKY,
                           amount,
                           string.Format("THU PHI LUU KY TK {0} NGAY CHOT {1}", customer.CustomerId, interestedDate.ToString("dd/MM/yyyy")),
                           customer.CustomerId,
                           user);
                    callResult.Transaction = transactionResult;

                    // update interest vrm_CustomerSecurityFee
                    var sql = new StringBuilder();
                    sql.AppendFormat("update vrm_CustomerSecurityFee set IsLasted = 0 where AccountId = '{0}' \n", LiteralUtil.GetLiteral(customer.CustomerId));
                    sql.Append("insert into vrm_CustomerSecurityFee(AccountId ,FeeAmount ,FeeDate ,Status ,IsLasted ,CreatedBy ,BranchCode ,TradeCode,TransactionDate)");
                    sql.AppendFormat(" values ('{0}',{1},{2},'A',1,'{3}','{4}','{5}',{6})",
                       LiteralUtil.GetLiteral(customer.CustomerId), LiteralUtil.GetNumericLiteral(amount),
                       LiteralUtil.GetLiteral(interestedDate), LiteralUtil.GetLiteral(user.UserName),
                       LiteralUtil.GetLiteral(customer.BranchCode ?? user.BranchCode), LiteralUtil.GetLiteral(customer.TradeCode), LiteralUtil.DateTime2String(DateTime.Today)
                       );

                    DBUtil.ExecuteNonQuery(sql.ToString());
                    var strSql =
                        string.Format(
                            " select top 1 Id from  vrm_CustomerSecurityFee where AccountId='{0}' and TransactionDate={1} and Status='A' and IsLasted =1 and FeeDate={2}",
                            LiteralUtil.GetLiteral(customer.CustomerId), LiteralUtil.DateTime2String(DateTime.Today),
                            LiteralUtil.GetLiteral(interestedDate));
                    var id = (int)DBUtil.ExecuteScalar(strSql);
                    callResult.CusSecFeeId = id;
                    scope.Complete();

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
            return callResult;
        }

        public static void UpdateSecurityLog(List<SecurityFeeLog> securityFeeLogs, SecuriryCallResult callResult)
        {


            // update interest vrm_SecurityFeeLog
            var sql2 = new StringBuilder();
            foreach (var securiry in securityFeeLogs)
            {
                sql2.AppendFormat("update vrm_SecurityFeeLog set Accountref='{0}', CustomerSecurityFeeId={1} ",
                    callResult.Transaction.TransactionNumber, callResult.CusSecFeeId);
                sql2.AppendFormat(" where Id={0} and CustomerId='{1}' ", securiry.Id, securiry.CustomerId);
            }

            DBUtil.ExecuteNonQuery(sql2.ToString());
        }

        public static bool IsAccoutingCustody(string accountId, DateTime feeDate)
        {
            var sql =
                string.Format(
                    "select top 1 id from  vrm_CustomerSecurityFee where AccountId='{0}' and FeeDate={1} and IsLasted=1 and Status='A' ",
                    LiteralUtil.GetLiteral(accountId), LiteralUtil.GetLiteral(feeDate));
            var db = DBUtil.ExecuteScalar(sql);
            return db != null;
        }

        public static List<SummaryCustody> SummaryCustody(DateTime fromDate, DateTime toDate, decimal feeRate = 0.4M)
        {
            List<SummaryCustody> list = new List<SummaryCustody>();
            var pFromDate = new SqlParameter("@fromdate", SqlDbType.DateTime) { Value = fromDate.Date };
            var pToDate = new SqlParameter("@toDate", SqlDbType.DateTime) { Value = toDate.Date };
            try
            {
                var dataset = DBUtil.SPExecuteDataSet("vrm_SummaryCustody", pFromDate, pToDate);
                DataTable table = dataset.Tables[0];
                if (table != null)
                {
                    foreach (DataRow dr in table.AsEnumerable().ToList())
                    {
                        var s = new SummaryCustody();
                        s.BankGl = dr[0].ToString();
                        s.Quantity = Convert.ToInt32(dr[1]);
                        s.Amount = s.Quantity * feeRate * (decimal)toDate.Subtract(fromDate).TotalDays / 30;
                        list.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
    public class SecuriryCallResult
    {
        public TransactionResult Transaction;
        public int CusSecFeeId;
    }

    public class SummaryCustody
    {
        public string BankGl { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}