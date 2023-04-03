using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using VRMDomain.Common;
//Minhns-09/04/2011 -for OnlineTranfer Module
namespace VRMDomain.Domain
{
    public sealed class AccountTransfer
    {

		public string AccountID;
		public string CustomerID;
		public string AccountName;
        public string isAuthorization;
		public string BankCode;
		public string BankBranchCode;
        public string CardIdentity;
        public DateTime CardDate;
        public string CardIssuer;
        public string UserCreate;
        public DateTime DateCreate;
        public bool Active;

        public AccountTransfer() { }

        private static AccountTransfer DB2Object(IDataReader reader)
        {
            AccountTransfer result = new AccountTransfer();
            result.AccountID = reader["AccountID"].ToString();
            result.CustomerID = reader["CustomerID"].ToString();
            result.AccountName = reader["AccountName"].ToString();
            result.isAuthorization = reader["isAuthorization"].ToString();
            result.BankCode = reader["BankCode"].ToString();
            result.BankBranchCode = reader["BankBranchCode"].ToString();
            result.CardIdentity = reader["CardIdentity"].ToString();
            if (reader["CardDate"] != DBNull.Value)
                result.CardDate = Convert.ToDateTime(reader["CardDate"]);
            result.CardIssuer = reader["CardIssuer"].ToString();
            result.UserCreate = reader["UserCreate"].ToString();
            if (reader["DateCreate"] != DBNull.Value)
                result.DateCreate = Convert.ToDateTime(reader["DateCreate"]);
            if (reader["Active"] != DBNull.Value)
                result.Active = Convert.ToBoolean(reader["Active"]);


            return result;
        }

        public static void InsertAccountTransfer(AccountTransfer accountTransfer,string userCreate)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO vrm_AccountTransfer (AccountID, CustomerID, AccountName, isAuthorization, BankCode, BankBranchCode,CardIdentity,CardDate,CardIssuer, UserCreate, DateCreate,Active)");
            sql.Append(" VALUES (");
            sql.AppendFormat("'{0}' ,", accountTransfer.AccountID);
            sql.AppendFormat("'{0}' ,", accountTransfer.CustomerID);
            sql.AppendFormat("N'{0}' ,", accountTransfer.AccountName);
            sql.AppendFormat("'{0}' ,", accountTransfer.isAuthorization);
            sql.AppendFormat("'{0}' ,", accountTransfer.BankCode);
            sql.AppendFormat("'{0}' ,", accountTransfer.BankBranchCode);
            sql.AppendFormat("'{0}' ,", accountTransfer.CardIdentity);
            sql.AppendFormat("{0} ,",LiteralUtil.GetLiteral(accountTransfer.CardDate));
            sql.AppendFormat("N'{0}' ,", accountTransfer.CardIssuer);
            sql.AppendFormat("'{0}' ,", userCreate);
            sql.AppendFormat("getdate(),");
            sql.AppendFormat("'{0}'", accountTransfer.Active);
            sql.Append(" )");
            DBUtil.ExecuteNonQuery(sql.ToString());
        
        }

        public static void UpdateAccountTransfer(AccountTransfer accountTransfer,string userCreate)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE vrm_AccountTransfer SET ");
            sql.AppendFormat(" AccountName = N'{0}', ", accountTransfer.AccountName);
            sql.AppendFormat(" isAuthorization = '{0}', ", accountTransfer.isAuthorization);
            sql.AppendFormat(" BankCode = '{0}', ", accountTransfer.BankCode);
            sql.AppendFormat(" BankBranchCode = '{0}', ", accountTransfer.BankBranchCode);
            sql.AppendFormat(" CardIdentity = '{0}', ", accountTransfer.CardIdentity);
            sql.AppendFormat(" CardDate = {0}, ", LiteralUtil.GetLiteral(accountTransfer.CardDate));
            sql.AppendFormat(" CardIssuer = N'{0}', ", accountTransfer.CardIssuer);
            sql.AppendFormat(" UserCreate = '{0}', ", userCreate);
            sql.AppendFormat(" Active = '{0}' ", accountTransfer.Active);
            sql.AppendFormat(" WHERE (AccountID = '{0}' AND CustomerID = '{1}')", accountTransfer.AccountID,accountTransfer.CustomerID);

             DBUtil.ExecuteNonQuery(sql.ToString());
        }

        public static int DeleteAccountTransfer(string accountID,string customerID)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE vrm_AccountTransfer SET Active = 'False' WHERE AccountID = '{0}' AND CustomerID = '{1}'", accountID, customerID);
            result = DBUtil.ExecuteNonQuery(sql.ToString());
            return result;
        }


        public static AccountTransfer GetAccountTransfer(string accountID,string customerID)
        {
            AccountTransfer result = new AccountTransfer();
            string sql = string.Format("SELECT * FROM vrm_AccountTransfer WHERE AccountID = '{0}' AND customerID = '{1}'", accountID, customerID);
            using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
            {
                if(dataReader.Read())
                {
                    result = DB2Object(dataReader);
                }
                dataReader.Close();
            }
            return result;
        }


        public static List<AccountTransfer> GetAccountTransferList(string customerID,string accountID,string branchCode)
        {
            List<AccountTransfer> result = new List<AccountTransfer>();
            string sql;
            if (branchCode.Equals("100"))
                sql = string.Format("SELECT * FROM vrm_AccountTransfer WHERE CustomerID like '%{0}' AND AccountID like '%{1}'",customerID,accountID);
            else
                sql = string.Format("SELECT A.* FROM vrm_AccountTransfer A,dbo.Customers C WHERE A.CustomerID = C.CustomerId AND A.CustomerID like '%{0}' AND AccountID like '%{1}'  AND C.BranchCode = '{2}'", customerID, accountID,branchCode);

            using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
            {
                while (dataReader.Read())
                {
                    result.Add(DB2Object(dataReader));
                }
                dataReader.Close();
            }
            return result;
        }
    }//EndClass


    public sealed class OnlineTransfer
    {

        public Int64 TransferID;
        public DateTime TransferDate;
        public string CustomerID;
        public string ToAccountID;
        public decimal Amount;
        public decimal CurrentAmount;
        public string Description;
        public decimal TransferFee;
        public string BankCode;
        public string BankBrachCode;
        public string Status;
        public string TransferType;
        public string UserProcess;
        public DateTime DateProcess;
        public string Reject;
        public string ContractID;

        public OnlineTransfer() { }

        private static OnlineTransfer DB2Object(IDataReader reader)
        {
            OnlineTransfer result = new OnlineTransfer();

            if (reader["TransferID"] != DBNull.Value)
                result.TransferID = Convert.ToInt64(reader["TransferID"]);
            if (reader["TransferDate"] != DBNull.Value)
                result.TransferDate = Convert.ToDateTime(reader["TransferDate"]);

            result.CustomerID = reader["CustomerID"].ToString();
            result.ToAccountID = reader["ToAccountID"].ToString();

            if (reader["Amount"] != DBNull.Value)
                result.Amount = Convert.ToDecimal(reader["Amount"]);
            if (reader["CurrentAmount"] != DBNull.Value)
                result.CurrentAmount = Convert.ToDecimal(reader["CurrentAmount"]);

            result.Description = reader["Description"].ToString();

            if (reader["TransferFee"] != DBNull.Value)
                result.TransferFee = Convert.ToDecimal(reader["TransferFee"]);

            result.BankCode = reader["BankCode"].ToString();
            result.BankBrachCode = reader["BankBrachCode"].ToString();
            result.Status = reader["Status"].ToString();
            result.TransferType =reader["TransferType"].ToString();
            result.UserProcess = reader["UserProcess"].ToString();
            if (reader["DateProcess"] != DBNull.Value)
                result.DateProcess = Convert.ToDateTime(reader["DateProcess"]);
            result.Reject = reader["Reject"].ToString();
            result.ContractID = reader["ContractID"].ToString();

            return result;
        }

        //public static void InsertOnlineTransfer(OnlineTransfer onlineTransfer)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("INSERT INTO vrm_AccountTransfer (AccountID, CustomerID, AccountName, AccountType, BankCode, BankBranchCode)");
        //    sql.Append(" VALUES (");
        //    sql.AppendFormat("'{0}' ,", accountTransfer.AccountID);
        //    sql.AppendFormat("'{0}' ,", accountTransfer.CustomerID);
        //    sql.AppendFormat("'{0}' ,", accountTransfer.AccountName);
        //    sql.AppendFormat("'{0}' ,", accountTransfer.AccountType);
        //    sql.AppendFormat("'{0}' ,", accountTransfer.BankCode);
        //    sql.AppendFormat("'{0}' ,", accountTransfer.BankBranchCode);
        //    sql.Append(" )");
        //    DBUtil.ExecuteNonQuery(sql.ToString());

        //}

        //public static void UpdateOnlineTransfer(OnlineTransfer onlineTransfer)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("UPDATE vrm_AccountTransfer SET ");
        //    sql.AppendFormat(" CustomerID = '{0}', ", accountTransfer.CustomerID);
        //    sql.AppendFormat(" AccountName = '{0}', ", accountTransfer.AccountName);
        //    sql.AppendFormat(" AccountType = '{0}', ", accountTransfer.AccountType);
        //    sql.AppendFormat(" BankCode = '{0}', ", accountTransfer.BankCode);
        //    sql.AppendFormat(" BankBranchCode = {0}, ", accountTransfer.BankBranchCode);
        //    sql.AppendFormat(" WHERE (AccountID = '{0}')", accountTransfer.AccountID);

        //    DBUtil.ExecuteNonQuery(sql.ToString());
        //}


        public static int OnlineTransferChangeStatus(Int64 transferID, string userProcess, string status, string reject, decimal transferFee)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE vrm_OnlineTransfer SET Status = '{0}', UserProcess='{1}',reject =N'{2}',transferFee = {3}, DateProcess = getdate() WHERE TransferID = {4}",status, userProcess,reject,transferFee, transferID);
            result = DBUtil.ExecuteNonQuery(sql.ToString());
            return result;
            //Mot so ham xu ly tren SBS
        }


        public static OnlineTransfer GetOnlineTransfer(Int64 transferID)
        {
            OnlineTransfer result = new OnlineTransfer();
            string sql = string.Format("SELECT * FROM vrm_OnlineTransfer WHERE TransferID = {0}", transferID);
            using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
            {
                if (dataReader.Read())
                {
                    result = DB2Object(dataReader);
                }
                dataReader.Close();
            }
            return result;
        }


        public static List<OnlineTransfer> GetOnlineTransferList(string customerID,string AccountID,DateTime fromDate,DateTime toDate,string Status, string branchCode)
        {
            List<OnlineTransfer> result = new List<OnlineTransfer>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT O.* FROM vrm_OnlineTransfer O,Customers C WHERE O.CustomerID = C.CustomerID ");
            sql.AppendFormat(" AND TransferDate BETWEEN {0} AND {1} ", LiteralUtil.GetLiteral(fromDate),string.Format(" CAST('{0} 23:59:59' AS DATETIME) ", toDate.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(customerID))
                sql.AppendFormat(" AND O.CustomerID = '{0}'", customerID);
            if (!string.IsNullOrEmpty(AccountID))
                sql.AppendFormat(" AND O.AccountID = '{0}'", AccountID);
            if (!string.IsNullOrEmpty(Status))
                sql.AppendFormat(" AND O.Status = '{0}'", Status);
            if(!branchCode.Equals("100"))
                sql.AppendFormat(" AND C.BranchCode = '{0}'", branchCode);

            using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql.ToString()))
            {
                while (dataReader.Read())
                {
                    result.Add(DB2Object(dataReader));
                }
                dataReader.Close();
            }
            return result;
        }


        public static DataTable GetOnlineTransferReport(DateTime fromDate, DateTime toDate, string Status,string branchCode)
        {
            DataTable tbl = new DataTable();
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT A.CustomerID,CustomerNameViet,AccountID,AccountName,FullName AS bank,Amount,TransferFee,O.Status,O.Reject FROM dbo.vrm_OnlineTransfer O,dbo.vrm_TransferBank B, ");
            sql.Append("dbo.vrm_AccountTransfer A,dbo.Customers C WHERE O.ToAccountID = A.AccountID AND a.CustomerID = c.CustomerId AND o.BankCode = b.BankCode ");
            sql.AppendFormat(" AND O.TransferDate BETWEEN {0} AND {1} ", LiteralUtil.GetLiteral(fromDate), string.Format(" CAST('{0} 23:59:59' AS DATETIME) ", toDate.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(Status))
                sql.AppendFormat(" AND O.Status IN ({0})", Status);
            if (!branchCode.Equals("100"))
                sql.AppendFormat(" AND C.BranchCode = '{0}'", branchCode);



            ds =DBUtil.ExecuteDataSet(sql.ToString());
            if (ds.Tables.Count > 0)
                tbl = ds.Tables[0];
            return tbl;
        }

        public static DataTable GetOnlineRegistedReport(DateTime fromDate, DateTime toDate, string Active, string branchCode)
        {
            DataTable tbl = new DataTable();
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT A.CustomerID,CustomerNameViet,AccountID,AccountName,A.CardIdentity,A.CardDate,A.CardIssuer,BankCode,A.UserCreate ");
            sql.Append(" FROM dbo.vrm_AccountTransfer A,dbo.Customers C  WHERE a.CustomerID = c.CustomerId ");
            if (Active.Equals("1"))
                sql.AppendFormat(" AND A.DateCreate BETWEEN {0} AND {1} ", LiteralUtil.GetLiteral(fromDate), string.Format(" CAST('{0} 23:59:59' AS DATETIME) ", toDate.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrEmpty(Active))
                sql.AppendFormat(" AND A.Active = {0}", Active);
            if (!branchCode.Equals("100"))
                sql.AppendFormat(" AND C.BranchCode = '{0}'", branchCode);



            ds = DBUtil.ExecuteDataSet(sql.ToString());
            if (ds.Tables.Count > 0)
                tbl = ds.Tables[0];
            return tbl;
        }

    }//End class


 
}
