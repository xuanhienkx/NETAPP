using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using VRMDomain.Common;
using System.Data;

namespace VRMDomain.Domain
{
   public sealed class Customer
   {
      // Properties
      public string AccountStatus;
      public string BranchCode;
      public string CustomerId;
      public string CustomerName;
      public string TradeCode;

      public byte? MarginRate;
      public bool IsSpecial;
      public string TakeCareUserName;
      public int TakeCareUserId;
      public string IntroduceUserName;
      public int IntroduceUserId;

      public string CardIdentity;
      public string CardDate;
      public string CardIssuer;
      public string AddressViet;
      public string Telephone;
      public string MobilePhone1;
      public string MobilePhone2;

      public Customer() { }

      private static void PasreFromDataReader(IDataReader dataReader, Customer customer)
      {
         customer.CustomerId = dataReader["CustomerId"].ToString();
         customer.TradeCode = dataReader["TradeCode"].ToString();
         customer.CustomerName = dataReader["CustomerNameViet"].ToString();
         customer.AccountStatus = Convert.ToString(dataReader["AccountStatus"]);
         if (!dataReader.IsDBNull(dataReader.GetOrdinal("MarginRate")))
            customer.MarginRate = (byte)dataReader["MarginRate"];
         if (!dataReader.IsDBNull(dataReader.GetOrdinal("UserIntroduce")))
            customer.IntroduceUserId = (int)dataReader["UserIntroduce"];
         if (!dataReader.IsDBNull(dataReader.GetOrdinal("IntroUserName")))
            customer.IntroduceUserName = Convert.ToString(dataReader["IntroUserName"]);
         if (dataReader["UserTakeCared"] != DBNull.Value)
            customer.TakeCareUserId = (int)dataReader["UserTakeCared"];
         if (dataReader["TakeCareUserName"] != DBNull.Value)
            customer.TakeCareUserName = Convert.ToString(dataReader["TakeCareUserName"]);

         if (dataReader["CardIdentity"] != DBNull.Value)
             customer.CardIdentity = Convert.ToString(dataReader["CardIdentity"]);
         if (dataReader["CardDate"] != DBNull.Value)
             customer.CardDate = Convert.ToDateTime(dataReader["CardDate"]).ToString("dd/MM/yyyy");
         if (dataReader["CardIssuer"] != DBNull.Value)
             customer.CardIssuer = Convert.ToString(dataReader["CardIssuer"]);
         if (dataReader["AddressViet"] != DBNull.Value)
             customer.AddressViet = Convert.ToString(dataReader["AddressViet"]);
         if (dataReader["Tel"] != DBNull.Value)
            customer.Telephone = Convert.ToString(dataReader["Tel"]);
         if (dataReader["mobile"] != DBNull.Value)
            customer.MobilePhone1 = Convert.ToString(dataReader["mobile"]);
         if (dataReader["mobile2"] != DBNull.Value)
            customer.MobilePhone2 = Convert.ToString(dataReader["mobile2"]);
         if (dataReader["isspecial"] != DBNull.Value)
            customer.IsSpecial = Convert.ToBoolean(dataReader["isspecial"]);
      }

      public static Customer GetCustomer(string customerId, UserLite user)
      {
         Customer customer = null;

         string sql = SqlHelper.BuildGetCustomerSql(true, customerId, 0, user, false);
         using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
         {
            customer = new Customer();
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

      public static List<Customer> Find(string customerId, int userTakeCare, UserLite user)
      {
         List<Customer> result = new List<Customer>();

         string sql = SqlHelper.BuildGetCustomerSql(false, customerId, userTakeCare, user, false);
         using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
         {
            while (dataReader.Read())
            {
               Customer customer = new Customer();
               PasreFromDataReader(dataReader, customer);

               result.Add(customer);
            }
            dataReader.Close();
         }

         return result;
      }

      public static void SetUserTakeCare(string customerId, int userTakeCareId)
      {
         string sql = string.Format("UPDATE dbo.Customers SET UserTakeCared = {0} WHERE CustomerId = '{1}'",
            userTakeCareId, LiteralUtil.GetLiteral(customerId));
         DBUtil.ExecuteNonQuery(sql);
      }

      private static class SqlHelper
      {
         internal static string BuildGetCustomerSql(bool isAbsCustId, string customerid, int userTakeCare, UserLite user, bool showForDebitLimit)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT c.customerid, c.TradeCode, c.CustomerNameViet,c.CardIdentity,c.CardDate,c.CardIssuer,c.AddressViet,c.AccountStatus, v.MarginRate, v.IsSpecial, c.BranchCode, ");
            sql.Append("c.UserIntroduce, c.UserTakeCared, intro.UserName as IntroUserName, tk.UserName as TakeCareUserName, c.[Tel], c.[mobile], c.[mobile2] ");
            sql.Append("FROM customers c left JOIN vrm_customer v on c.customerid = v.customerid ");
            sql.Append("LEFT JOIN dbo.Users intro ON c.UserIntroduce = intro.UserId ");
            sql.Append("LEFT JOIN dbo.Users tk ON c.UserTakeCared = tk.UserId ");

            if (user.IsAgencyMember)
               sql.AppendFormat("join agencycustomer a on c.customerid = a.customerid and a.agencytradecode = '{0}' ", user.TradeCode);

            sql.AppendFormat("where c.branchcode = '{0}' ", user.BranchCode);

            if (userTakeCare > 0)
               sql.AppendFormat("and UserTakeCared = {0} ", userTakeCare > 0 ? userTakeCare : user.UserId);

            if (isAbsCustId)
               sql.AppendFormat("and c.customerid = '{0}' ", LiteralUtil.GetLiteral(customerid));
            else
            {
               if (!string.IsNullOrEmpty(customerid))
                  sql.AppendFormat(" and c.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerid));

               sql.Append(" and c.AccountStatus != 'C' ");
            }
            //loai khach hang dac biet ra
            if (!user.IsBranchAdmin && !user.Rights.Contains(GlobalConstants.SR_KHDB))
               sql.Append("and isnull(v.isspecial, 0) = 0 ");

            sql.Append(" order by c.customerid");
            return sql.ToString();
         }
      }

      public static void UpdateVRMCustomerInfo(string customerId, byte rate, bool isSpecial, UserLite user)
      {
         StringBuilder sql = new StringBuilder();

         sql.AppendFormat("if exists(select * from vrm_customer where customerid = '{0}') \n", customerId);
         sql.AppendFormat("update vrm_customer set marginrate = {0}, isSpecial={1} where customerid = '{2}' \n", 
            rate, LiteralUtil.GetLiteral(isSpecial), customerId);
         sql.AppendFormat("else \n insert into vrm_customer(customerid, marginrate,isSpecial) values ('{0}', {1}, {2})",
            customerId, rate, LiteralUtil.GetLiteral(isSpecial));

         DBUtil.ExecuteNonQuery(sql.ToString());
      }

      public static DataTable GetCustomerStockEnquiry(string customerId, DateTime transDate, UserLite user)
      {
         SqlParameter accountId = new SqlParameter("@AccountId", SqlDbType.VarChar);
         accountId.Value = customerId;
         SqlParameter branchCode = new SqlParameter("@BranchCode", SqlDbType.VarChar);
         branchCode.Value = user.BranchCode;
         SqlParameter tradingDate = new SqlParameter("@TradingDate", SqlDbType.DateTime);
         tradingDate.Value = transDate;

         return DBUtil.SPExecuteDataSet(GlobalConstants.SPSBS_CUSTOMERSTOCKENQUIRY, accountId, branchCode, tradingDate).Tables[0];
      }

      public static DataTable GetBlockBalanceAndDebitLimitInfo(string customerId, UserLite user)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("select top 1 c.[CustomerId], c.[CustomerNameViet], u.[FullName], cb.[DayBlock], cb.[DayUnBlock], cb.[BlockBalance],  \n");
         sql.Append("cb.[DayBankBlock], cb.[DayBankUnblock], cb.[Balance], cd.[CurrentLimitValue], BeginCredit+YearCredit-YearDebit as LastBalance \n");
         sql.Append("from [dbo].[Customers] c join [dbo].[Balance] b on c.[CustomerId] = b.[AccountId] and b.[BankGl] = '324111' \n");
         sql.Append("join [dbo].[CustomerBalance] cb on c.[CustomerId] = cb.[CustomerId] \n");
         sql.Append("left join [dbo].[CustomerDebitLimit] cd on c.[CustomerId] = cd.[CustomerId] and cd.[IsActive] = 1 \n");
         sql.Append("left join [dbo].[Users] u on c.[UserTakeCared] = u.[UserId] \n");
         if (user.IsAgencyMember)
            sql.AppendFormat("join agencycustomer a on c.customerid = a.customerid and a.agencytradecode = '{0}' ", user.TradeCode);

         sql.AppendFormat("where c.[CustomerId] like '%{0}' and [c].[BranchCode] = '{1}' ", LiteralUtil.GetLiteral(customerId), user.BranchCode);

         return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }
   }
}
