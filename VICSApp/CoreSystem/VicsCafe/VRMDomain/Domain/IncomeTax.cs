using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace VRMDomain.Domain
{
    public class IncomeTax
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string TransactionNumber { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Transactiondate { get; set; }
        public string BranchCode { get; set; }
        public string TradeCode { get; set; }
        public string CardIdentity { get; set; }

        public static IncomeTax DB2Object(SqlDataReader r)
        {
            IncomeTax s = new IncomeTax();
            s.AccountId = r["AccountID"].ToString();
            s.AccountName = r["AccountName"].ToString();
            s.TransactionNumber = r["TransactionNumber"].ToString();
            s.Description = r["Description"].ToString();
            s.Transactiondate = (DateTime) r["Transactiondate"];
            s.Amount = (decimal)r["Amount"];
            s.BranchCode = r["BranchCode"].ToString();
            s.TradeCode = r["TradeCode"].ToString();
            s.CardIdentity = r["CardIdentity"].ToString();
            return s;
        }
        public static IncomeTax DB2ObjectAccount(SqlDataReader r)
        {
            IncomeTax s = new IncomeTax();
            s.AccountId = r["ma_khach"].ToString();
            s.AccountName = r["tenkhach"].ToString();
            s.TransactionNumber = r["soct"].ToString();
            s.Description = r["noidung"].ToString();
            s.Transactiondate = (DateTime)r["ngay"];
            s.Amount = (decimal)r["sotien"];
            s.BranchCode = r["brd"].ToString();

            return s;
        }

        public static List<IncomeTax> GetList(string brancode, DateTime from, DateTime to, string accountNumner)
        {
            List<IncomeTax> result = new List<IncomeTax>();
            string sql = string.Format(
                @"select AccountID,AccountName,TransactionNumber,[Description], Transactiondate,t.BranchCode,amount, c.TradeCode, c.CardIdentity
                from transactionhist t join Customers c on t.AccountId=c.CustomerId
                 where bankgl = '{2}' and  transactiondate BETWEEN '{0}' AND '{1}'  and approved = 'Y' ",
                from.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd"), accountNumner);
            if (brancode.Equals("All") == false)
            {
                sql = sql + string.Format(" AND t.BranchCode='{0}' ", brancode);
            }
            sql = sql + string.Format(" ORDER BY Transactiondate,AccountID ");
            using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
            {
                while (r.Read())
                    result.Add(DB2Object(r));
                r.Close();
                r.Dispose();
            }
            return result;
        }

     
        public static List<IncomeTax> GetKtList(string branch, DateTime from, DateTime to, string accountNumner)
        {
            List<IncomeTax> result = new List<IncomeTax>();
            string sql = string.Format("select loai_ct,soct,ngay,noidung,sotien,tkno,tkco,ma_khach,tenkhach,brd from ketoan WHERE tkco='{2}' and ngay BETWEEN '{0}' AND '{1}'  AND loai_ct = 'PIT' ",
                   from.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd"), accountNumner);
            if (branch.Equals("All") == false)
            {
                sql = sql + string.Format("AND brd='{0}'", branch);
            }
            sql = sql + string.Format(" ORDER BY ngay,ma_khach "); 
            using (SqlDataReader r = DBUtil.ExecuteDataReader(sql,true))
            {
                while (r.Read())
                    result.Add(DB2ObjectAccount(r));

                r.Close();
                r.Dispose();
            }
            return result;
        }

    
        public static void ImportIncomeTax(string branch, DateTime fromdate, DateTime toDate, string accountNumner)
        {
            var sbsData = GetList(branch, fromdate, toDate, accountNumner);
            if (!sbsData.Any())
            {
                return;
            }
            DeleteExistedData(branch, fromdate, toDate, accountNumner);
            foreach (var tax in sbsData)
            {
                InsertIncomeTax(tax.BranchCode, tax.TransactionNumber, tax.Transactiondate, tax.AccountId,
                    tax.AccountName, tax.Amount, tax.Description, accountNumner);
            }
        }

        private static void DeleteExistedData(string branch, DateTime fromdate, DateTime toDate, string accountNumner)
        {
            string delete_sql = string.Format("delete ketoan WHERE ngay BETWEEN '{0}' AND '{1}'  AND tkco='{2}' AND loai_ct = 'PIT'",
                    fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), accountNumner);
            if (!branch.Equals("All"))
            {
                delete_sql += string.Format("AND brd={0}",branch);
            }
            try
            {
                DBUtil.ExecuteNonQuery(delete_sql, true);
                
            }
            catch (Exception ex)
            {
                
              var err=ex.Message;
            }
            
        }

        private static void InsertIncomeTax(string branchCode, string transactionNumber, DateTime transactionDate, string accountid, string accountName, decimal amount, string description,string accountNumner)
        {
            SqlParameter[] Params1 = new SqlParameter[] { 
                  new SqlParameter("@BranchCode", branchCode ), 
                  new SqlParameter("@transactionnumber", transactionNumber), 
                  new SqlParameter("@transactiondate", Convert2SmallDateTime(transactionDate)),
                  new SqlParameter("@accountid", accountid ), 
                  new SqlParameter("@accountname", accountName ), 
                  new SqlParameter("@amount", amount), 
                  new SqlParameter("@description", description), 
                  new SqlParameter("@amountnumber", accountNumner), 
            };
            DBUtil.SPExecuteNonQuery("vics_ktImport",true, Params1);
            
        }

        public static DateTime Convert2SmallDateTime(DateTime time)
        {
            return time.Add(-time.TimeOfDay);
        }

    }
}