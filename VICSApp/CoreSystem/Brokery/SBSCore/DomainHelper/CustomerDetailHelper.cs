using System;
using System.Text;
using System.Data.SqlClient;
using CommonDomain;
using System.Data;

namespace SBSCore.DomainHelper
{
   public sealed class CustomerDetailHelepr
   {
      private static void PasreFromDataReader(IDataReader dataReader, CustomerDetail customerDetail)
      {
          try
          {
              customerDetail.BranchCode = dataReader["BranchCode"].ToString();
              customerDetail.CustomerId = dataReader["CustomerId"].ToString();
              customerDetail.CustomerName = dataReader["CustomerName"].ToString();
              customerDetail.CustomerNameViet = dataReader["CustomerNameViet"].ToString();
              customerDetail.ContractNumber = dataReader["ContractNumber"].ToString();
              if (dataReader["Dob"] != DBNull.Value)
                customerDetail.Dob = Convert.ToDateTime(dataReader["Dob"]);
              customerDetail.Sex = dataReader["Sex"].ToString();
              //if (dataReader["SignatureImage1"] != DBNull.Value)
              //    customerDetail.SignatureImage1 = (byte[])dataReader["SignatureImage1"];
              //if (dataReader["SignatureImage2"] != DBNull.Value)
              //    customerDetail.SignatureImage2 = (byte[])dataReader["SignatureImage2"];
              customerDetail.CardIdentity = dataReader["CardIdentity"].ToString();
              if (dataReader["CardType"] != DBNull.Value)
                  customerDetail.CardType = Convert.ToInt32(dataReader["CardType"]);
              if (dataReader["CardDate"] != DBNull.Value)
                   customerDetail.CardDate = Convert.ToDateTime(dataReader["CardDate"]);
              customerDetail.CardIssuer = dataReader["CardIssuer"].ToString();
              customerDetail.Address = dataReader["Address"].ToString();
              customerDetail.AddressViet = dataReader["AddressViet"].ToString();
              customerDetail.Mobile = dataReader["Mobile"].ToString();
              customerDetail.Email = dataReader["Email"].ToString();
              if (dataReader["ProxyStatus"] != DBNull.Value)
                   customerDetail.ProxyStatus = Convert.ToInt32(dataReader["ProxyStatus"]);
              if (dataReader["PostType"] != DBNull.Value)
                   customerDetail.PostType = Convert.ToInt32(dataReader["PostType"]);
              customerDetail.Notes = dataReader["Notes"].ToString();
              customerDetail.Country = dataReader["Country"].ToString();
              customerDetail.MoneyDepositeNumber = dataReader["MoneyDepositeNumber"].ToString();
              customerDetail.MoneyDepositeLocation = dataReader["MoneyDepositeLocation"].ToString();
              customerDetail.UserIntroduceName = dataReader["UserIntroduceName"].ToString();
              customerDetail.UserTakeCaredName = dataReader["UserTakeCaredName"].ToString();
              customerDetail.BrokerName = dataReader["BrokerName"].ToString();
          }
          catch
          {
              throw new Exception("Không lấy được thông tin chi tiết khách hàng");
          }
      }

      public static CustomerDetail GetCustomerDetail(string customerId)
      {
         CustomerDetail customerDetail = null;
         string sql = SqlHelper.BuildGetCustomerSql(customerId);
         using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
         {
             customerDetail = new CustomerDetail();
            if (dataReader.Read())
               PasreFromDataReader(dataReader, customerDetail);
            dataReader.Close();
         }
         if (customerDetail == null)
            throw new Exception("Không tìm thấy tài khoản khách hàng");
         return customerDetail;
      }


      private static class SqlHelper
      {
         internal static string BuildGetCustomerSql(string customerid)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT *,(SELECT FullName FROM dbo.Users WHERE UserId=customers.UserIntroduce) AS 'UserIntroduceName', ");
            sql.Append("(SELECT FullName FROM dbo.Users WHERE UserId=customers.UserTakeCared) AS 'UserTakeCaredName', ");
            sql.Append("(SELECT FullName FROM dbo.Users WHERE UserId=customers.BrokerId) AS 'BrokerName' FROM customers ");
            sql.AppendFormat("WHERE CustomerId='{0}'", customerid);
            return sql.ToString();
         }
      }

   }
}
