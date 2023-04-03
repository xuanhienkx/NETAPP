using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VRMDomain.Domain
{
    public class SecuriryForCallFee
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string StockCode { get; set; }
        public string BangGl { get; set; }
        public int TotalQty { get; set; }

        public static SecuriryForCallFee DB2Object(SqlDataReader r)
        {
            SecuriryForCallFee s = new SecuriryForCallFee(); 
            s.AccountId = r["accountid"].ToString();
            s.AccountName = r["accountName"].ToString();
            s.TotalQty = (int)r["Quantity"]; 
            s.StockCode = r["StockCode"].ToString();
            s.BangGl =  r["BankGl"].ToString();
            return s;
        }

        public static List<SecurityCalFee> GetKtList(UserLite user, string branch, string customerId, DateTime from)
        {
            List<SecurityCalFee> result = new List<SecurityCalFee>();
            SqlParameter branchCode = new SqlParameter("@BranchCode", SqlDbType.VarChar);
            branchCode.Value = user.BranchCode;
            SqlParameter fromDate = new SqlParameter("@fromDate", SqlDbType.DateTime);
            fromDate.Value = @from;

            var dataset = DBUtil.SPExecuteDataSet("GetSecurityForCallFee", fromDate, branchCode);

            return result;
        }
    }
}