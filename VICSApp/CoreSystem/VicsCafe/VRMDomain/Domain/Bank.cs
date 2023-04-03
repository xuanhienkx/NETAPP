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
    public sealed class Bank
    {
        public string BankCode;
        public string FullName;
        public string ShortName;
        public string Description;
        public Boolean IsPayment;
        public string DelegatePerson;
        public string Department;
        public string Position;
        public string Mobile;
        public string Tel;
        public string Fax;
        public string Email;
        public string Address;

        public Bank() { }

        private static Bank DB2Object(IDataReader reader)
        {
            Bank result = new Bank();
            result.BankCode = reader["BankCode"].ToString();
            result.FullName = reader["FullName"].ToString();
            result.ShortName = reader["ShortName"].ToString();
            result.IsPayment = (Boolean)reader["IsPayment"];
            result.DelegatePerson = reader["DelegatePerson"].ToString();
            result.Department = reader["Department"].ToString();
            result.Position = reader["Position"].ToString();
            result.Mobile = reader["Mobile"].ToString();
            result.Tel = reader["Tel"].ToString();
            result.Fax = reader["Fax"].ToString();
            result.Email = reader["Email"].ToString();
            result.Address = reader["Address"].ToString();
            return result;
        }

        public static void InsertBank(Bank bank) {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO vrm_TransferBank (BankCode, FullName, ShortName, Description, DelegatePerson, Department, Position, Mobile, Tel, Fax, Email, Address) ");
            sql.Append(" VALUES (");
            sql.AppendFormat("'{0}' ,", bank.BankCode);
            sql.AppendFormat("N'{0}' ,", bank.FullName);
            sql.AppendFormat("N'{0}' ,", bank.ShortName);
            sql.AppendFormat("N'{0}' ,", bank.Description);
            //sql.AppendFormat("'{0}',", bank.IsPayment.ToString());
            sql.AppendFormat("N'{0}' ,", bank.DelegatePerson);
            sql.AppendFormat("N'{0}' ,", bank.Department);
            sql.AppendFormat("N'{0}' ,", bank.Position);
            sql.AppendFormat("'{0}' ,", bank.Mobile);
            sql.AppendFormat("'{0}' ,", bank.Tel);
            sql.AppendFormat("'{0}' ,", bank.Fax);
            sql.AppendFormat("'{0}' ,", bank.Email);
            sql.AppendFormat("N'{0}'", bank.Address);
            sql.Append(" )");
            DBUtil.ExecuteNonQuery(sql.ToString());
        
        }

        public static void UpdateBank(Bank bank)
        {
            StringBuilder sql = new StringBuilder();
		    sql.Append("UPDATE vrm_TransferBank SET ");
			 sql.AppendFormat(" FullName = N'{0}', ",bank.FullName);
			 sql.AppendFormat( " ShortName = N'{0}', ",bank.ShortName);
			 sql.AppendFormat( " Description = N'{0}', ",bank.Description);
			 //sql.AppendFormat( " IsPayment = {0}, ",bank.IsPayment);
			 sql.AppendFormat( " DelegatePerson = N'{0}', ",bank.DelegatePerson);
			 sql.AppendFormat( " Department = N'{0}', ",bank.Department);
			 sql.AppendFormat( " Position =N'{0}' , ",bank.Position);
			 sql.AppendFormat( " Mobile = '{0}', ",bank.Mobile);
			 sql.AppendFormat( " Tel = '{0}', ",bank.Tel);
			 sql.AppendFormat( " Fax = '{0}', ",bank.Fax);
			 sql.AppendFormat( " Email = '{0}', ",bank.Email);
			 sql.AppendFormat( " Address = N'{0}' ",bank.Address);
			 sql.AppendFormat( " WHERE (BankCode = '{0}')",bank.BankCode);

             DBUtil.ExecuteNonQuery(sql.ToString());
        }

        public static int DeleteBank(string BankCode)
        {
            if (BankBranch.GetBankBranchList(BankCode).Count > 0)
                throw new OperationCanceledException("Bạn phải xóa chi nhánh trước");

            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM vrm_TransferBank WHERE BankCode = '{0}'",BankCode);
            result = DBUtil.ExecuteNonQuery(sql.ToString());
            return result;
        }


        public static Bank GetBank(string bankCode)
        {
            Bank result = new Bank();
            string sql = string.Format("SELECT * FROM vrm_TransferBank WHERE BankCode = {0}",bankCode);
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


        public static List<Bank> GetBankList()
        {
            List<Bank> result = new List<Bank>();
            string sql = "SELECT * FROM vrm_TransferBank";
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


    public sealed class BankBranch
    {
        public string BankBranchCode;
        public string FullName;
        public string ShortName;
        public string Description;
        public Boolean IsPayment;
        public string DelegatePerson;
        public string Department;
        public string Position;
        public string Mobile;
        public string Tel;
        public string Fax;
        public string Email;
        public string Address;
        public string ProvinceCode;
        public string BankCode;

        public BankBranch() { }

        private static BankBranch DB2Object(IDataReader reader)
        {
            BankBranch result = new BankBranch();
            result.BankBranchCode = reader["BankBranchCode"].ToString();
            result.FullName = reader["FullName"].ToString();
            result.ShortName = reader["ShortName"].ToString();
            result.IsPayment = (Boolean)reader["IsPayment"];
            result.DelegatePerson = reader["DelegatePerson"].ToString();
            result.Department = reader["Department"].ToString();
            result.Position = reader["Position"].ToString();
            result.Mobile = reader["Mobile"].ToString();
            result.Tel = reader["Tel"].ToString();
            result.Fax = reader["Fax"].ToString();
            result.Email = reader["Email"].ToString();
            result.Address = reader["Address"].ToString();
            result.ProvinceCode = reader["ProvinceCode"].ToString();
            result.BankCode = reader["BankCode"].ToString();
            return result;
        }

        public static void InsertBankBranch(BankBranch bankBranch)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO vrm_TransferBankBranch (BankBranchCode, FullName, ShortName, Description, DelegatePerson, Department, Position, Mobile, Tel, Fax, Email, Address, ProvinceCode, BankCode) ");
            sql.Append(" VALUES (");
            sql.AppendFormat("'{0}' ,", bankBranch.BankBranchCode);
            sql.AppendFormat("N'{0}' ,", bankBranch.FullName);
            sql.AppendFormat("N'{0}' ,", bankBranch.ShortName);
            sql.AppendFormat("N'{0}' ,", bankBranch.Description);
            //sql.AppendFormat("{0},", bankBranch.IsPayment);
            sql.AppendFormat("N'{0}' ,", bankBranch.DelegatePerson);
            sql.AppendFormat("N'{0}' ,", bankBranch.Department);
            sql.AppendFormat("N'{0}' ,", bankBranch.Position);
            sql.AppendFormat("'{0}' ,", bankBranch.Mobile);
            sql.AppendFormat("'{0}' ,", bankBranch.Tel);
            sql.AppendFormat("'{0}' ,", bankBranch.Fax);
            sql.AppendFormat("'{0}' ,", bankBranch.Email);
            sql.AppendFormat("N'{0}' ,", bankBranch.Address);
            sql.AppendFormat("'{0}' ,", bankBranch.ProvinceCode);
            sql.AppendFormat("'{0}'", bankBranch.BankCode);
            sql.Append(" )");
            DBUtil.ExecuteNonQuery(sql.ToString());

        }

        public static void UpdateBankBranch(BankBranch bankBranch)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE vrm_TransferBankBranch SET ");
            sql.AppendFormat(" FullName = N'{0}', ", bankBranch.FullName);
            sql.AppendFormat(" ShortName = N'{0}', ", bankBranch.ShortName);
            sql.AppendFormat(" Description = N'{0}', ", bankBranch.Description);
            //sql.AppendFormat(" IsPayment = {0}, ", bankBranch.IsPayment);
            sql.AppendFormat(" DelegatePerson = N'{0}', ", bankBranch.DelegatePerson);
            sql.AppendFormat(" Department = N'{0}', ", bankBranch.Department);
            sql.AppendFormat(" Position =N'{0}' , ", bankBranch.Position);
            sql.AppendFormat(" Mobile = '{0}', ", bankBranch.Mobile);
            sql.AppendFormat(" Tel = '{0}', ", bankBranch.Tel);
            sql.AppendFormat(" Fax = '{0}', ", bankBranch.Fax);
            sql.AppendFormat(" Email = '{0}', ", bankBranch.Email);
            sql.AppendFormat(" Address = N'{0}', ", bankBranch.Address);
            sql.AppendFormat(" ProvinceCode = '{0}', ", bankBranch.ProvinceCode);
            sql.AppendFormat(" BankCode = '{0}' ", bankBranch.BankCode);
            sql.AppendFormat(" WHERE (BankBranchCode = '{0}')", bankBranch.BankBranchCode);

            DBUtil.ExecuteNonQuery(sql.ToString());
        }

        public static int DeleteBankBranch(string BankBranchCode)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM vrm_TransferBankBranch WHERE BankBranchCode = '{0}'", BankBranchCode);
            result = DBUtil.ExecuteNonQuery(sql.ToString());
            return result;
        }


        public static BankBranch GetBankBranch(string bankBranchCode)
        {
            BankBranch result = new BankBranch();
            string sql = string.Format("SELECT * FROM vrm_TransferBankBranch WHERE BankBranchCode = '{0}'", bankBranchCode);
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


        public static List<BankBranch> GetBankBranchList(string bankCode)
        {
            List<BankBranch> result = new List<BankBranch>();
            string sql = string.Format("SELECT * FROM vrm_TransferBankBranch WHERE BankCode = '{0}'", bankCode);
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

        public static DataTable GetAllProvinceCode()
        {
            string sql = "SELECT * FROM Province";
            DataTable result = DBUtil.ExecuteDataSet(sql).Tables[0];
            return result;
        }


    }//EndClass
}
