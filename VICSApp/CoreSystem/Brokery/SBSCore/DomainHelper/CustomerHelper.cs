using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CommonDomain;
using SBSCore.Common;
using System.Data;
using SBSCore.Security;

namespace SBSCore.DomainHelper
{
   public static class CustomerHelper
   {
      private static void PasreFromDataReader(IDataReader dataReader, Customer customer)
      {
         customer.CustomerId = dataReader["CustomerId"].ToString();
         customer.TradeCode = dataReader["TradeCode"].ToString();
         customer.CustomerName = dataReader["CustomerName"].ToString();
         customer.CustomerNameViet = dataReader["CustomerNameViet"].ToString();
         customer.CardIdentity = dataReader["CardIdentity"].ToString();
         customer.PostType = Convert.ToInt32(dataReader["PostType"]);
         customer.AccountStatus = Convert.ToString(dataReader["AccountStatus"]);
         customer.Mobile = dataReader["Mobile"].ToString();
         customer.AddressViet = Convert.ToString(dataReader["AddressViet"]);
         customer.Email = Convert.ToString(dataReader["Email"]);
         if (!dataReader.IsDBNull(dataReader.GetOrdinal("BankCode")))
            customer.BankCode = Convert.ToString(dataReader["BankCode"]);
         if (!dataReader.IsDBNull(dataReader.GetOrdinal("CIF")))
            customer.CIF = Convert.ToString(dataReader["CIF"]);
         if (dataReader["SignatureImage1"] != DBNull.Value)
            customer.SignatureImage1 = (byte[])dataReader["SignatureImage1"];
         if (dataReader["SignatureImage2"] != DBNull.Value)
            customer.SignatureImage2 = (byte[])dataReader["SignatureImage2"];
      }

      public static Customer GetCustomer(string customerId, string branchCode, UserLite uInfo)
      {
         Customer customer = null;

         string sql = SqlHelper.BuildGetCustomerSql(true, customerId, string.Empty, string.Empty, branchCode, 0, uInfo);
         using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
         {
            customer = new Customer();
            customer.BranchCode = branchCode;

            if (dataReader.Read())
               PasreFromDataReader(dataReader, customer);
            dataReader.Close();
         }

         if (customer == null)
            throw new Exception("Không tìm thấy tài khoản khách hàng");
         if (customer.AccountStatus == "C")
            throw new Exception("Tài khoản khách hàng đã bị đóng");

         return customer;
      }

      public static List<Customer> Find(string customerId, string customserName, string cardID, string branchCode, UserLite uInfo)
      {
         List<Customer> result = new List<Customer>();

         string sql = SqlHelper.BuildGetCustomerSql(false, customerId, customserName, cardID, branchCode, 0, uInfo);
         using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
         {
            while (dataReader.Read())
            {
               Customer customer = new Customer();
               customer.BranchCode = branchCode;
               PasreFromDataReader(dataReader, customer);

               result.Add(customer);
            }
            dataReader.Close();
         }

         return result;
      }

      public static List<Customer> FindByTakeCared(string branchCode, UserLite uInfo)
      {
          List<Customer> result = new List<Customer>();

          string sql = SqlHelper.BuildGetCustomerSql(false, string.Empty, string.Empty, string.Empty, branchCode, uInfo.UserId, uInfo);
          using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
          {
              while (dataReader.Read())
              {
                  Customer customer = new Customer();
                  PasreFromDataReader(dataReader, customer);
                  customer.BranchCode = branchCode;
                  result.Add(customer);
              }
              dataReader.Close();
          }

          return result;
      }

      private static class SqlHelper
      {
         internal static string BuildGetCustomerSql(bool isAbsCustId, string customerid, string customserName, string cardID, string branchCode, int userTakeCared, UserLite uInfo)
         {
            StringBuilder sql = new StringBuilder();

           // sql.Append("select c.customerid, c.TradeCode, c.CustomerName, c.CustomerNameViet,c.CardIdentity, c.PostType, c.AccountStatus, b.BankCode, b.CIF, c.SignatureImage1, c.SignatureImage2 ");
            sql.Append("select  c.*, b.BankCode, b.CIF ");
            sql.Append("from customers c left join customerbank b on c.customerid = b.customerid ");
            if (uInfo.IsAgencyUser)
               sql.Append("join agencycustomer a on c.customerid = a.customerid ");

            sql.Append(" where c.AccountStatus != 'C' ");
            if (!string.IsNullOrEmpty(branchCode))
               sql.AppendFormat(" and branchcode = '{0}' ", LiteralUtil.GetLiteral(branchCode));

            if (uInfo.IsAgencyUser) //user thuoc VICS duoc phep xem tat ca cac khach hang
               sql.AppendFormat("and a.agencytradecode = '{0}' ", LiteralUtil.GetLiteral(uInfo.TradeCode));

            if (isAbsCustId)
               sql.AppendFormat(" and c.customerid = '{0}' ", LiteralUtil.GetLiteral(customerid));
            else
            {
               if (!string.IsNullOrEmpty(customerid))
                  sql.AppendFormat(" and c.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerid));
               if (!string.IsNullOrEmpty(customserName))
                  sql.AppendFormat(" and c.customername like '%{0}%' ", LiteralUtil.GetLiteral(customserName));
               if (!string.IsNullOrEmpty(cardID))
                  sql.AppendFormat(" and c.cardidentity like '%{0}' ", LiteralUtil.GetLiteral(cardID));
               if (userTakeCared!=0)
                   sql.AppendFormat(" and (c.UserTakeCared = {0} or c.UserTakeCared IS NULL) ", userTakeCared);
               sql.Append(" order by c.customerid ");
            }
            return sql.ToString();
         }

      }

      public static void Register(string customerId, string customerTradeCode, string agencyTradeCode, SBSCore.Security.UserLite uInfo)
      {
         StringBuilder sql = new StringBuilder();
         sql.AppendFormat("IF NOT EXISTS(SELECT * FROM dbo.AgencyCustomer WHERE AgencyTradeCode = '{0}' AND CustomerId = '{1}') \n",
            agencyTradeCode, LiteralUtil.GetLiteral(customerId));
         sql.Append("INSERT INTO dbo.AgencyCustomer(AgencyTradeCode,CustomerId,CustomerTradeCode,LastUpdate,Username) \n");
         sql.AppendFormat("VALUES ('{0}','{1}','{2}',GETDATE(),'{3}')",
            agencyTradeCode, LiteralUtil.GetLiteral(customerId), LiteralUtil.GetLiteral(customerTradeCode), uInfo.UserName);

         DBUtil.ExecuteNonQuery(sql.ToString());
      }

      public static int CheckRegister(string customerId, string agencyTradeCode)
      {
          int result = 0;
          StringBuilder sql = new StringBuilder();
          sql.AppendFormat(
              "SELECT * FROM dbo.AgencyCustomer WHERE AgencyTradeCode <> '{0}' AND CustomerId = '{1}' \n",
              agencyTradeCode, LiteralUtil.GetLiteral(customerId));
          DataTable dataTable = DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
          if (dataTable.Rows.Count > 0)
          {
              result = 1;
          }
          else
          {
              sql = new StringBuilder();
              sql.AppendFormat(
                  "SELECT * FROM dbo.AgencyCustomer WHERE AgencyTradeCode = '{0}' AND CustomerId = '{1}' \n",
                  agencyTradeCode, LiteralUtil.GetLiteral(customerId));
              dataTable = DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
              if (dataTable.Rows.Count > 0)
              {
                  result = 2;
              }

          }

          return result;
       }

      public static void UnRegister(string customerId)
      {
         string sql = string.Format("DELETE FROM dbo.AgencyCustomer WHERE CustomerId = '{0}'",
            LiteralUtil.GetLiteral(customerId));
         DBUtil.ExecuteNonQuery(sql);
      }


   }
}
