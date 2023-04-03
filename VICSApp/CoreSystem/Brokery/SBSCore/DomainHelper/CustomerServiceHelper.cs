using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CommonDomain;
using SBSCore.Common;

namespace SBSCore.DomainHelper
{
   public static class CustomerServiceHelper
   {
      public static List<CustomerService> CustomerServiceGetList(string customerId)
      {
         List<CustomerService> result = new List<CustomerService>();

         StringBuilder sql = new StringBuilder();
         sql.Append("SELECT a.[ServiceCode],a.[CustomerId],a.Mobile,a.Mobile2,a.[BeginDate],a.[EndDate],a.[Status],c.[ServiceName],a.Reserved ");
	      sql.Append("FROM [CustomerService] a left join [Service] c on a.servicecode = c.servicecode ");
         sql.AppendFormat("WHERE a.CustomerID = '{0}'", LiteralUtil.GetLiteral(customerId));

         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql.ToString()))
         {
            CustomerService item;
            while (reader.Read())
            {
               item = new CustomerService();
               if (reader["ServiceCode"] != DBNull.Value)
                  item.ServiceCode = reader["ServiceCode"].ToString();
               if (reader["ServiceName"] != DBNull.Value)
                  item.ServiceName = reader["ServiceName"].ToString();
               if (reader["Mobile"] != DBNull.Value)
                   item.Mobile = reader["Mobile"].ToString();
               if (reader["Mobile2"] != DBNull.Value)
                   item.Mobile2 = reader["Mobile2"].ToString();
               if (reader["Reserved"] != DBNull.Value)
                   item.Reserved = reader["Reserved"].ToString();
               item.CustomerId = reader["CustomerId"].ToString();
               if (reader["BeginDate"] != DBNull.Value)
                  item.BeginDate = Convert.ToDateTime(reader["BeginDate"]).Date;
               if (reader["EndDate"] != DBNull.Value)
                  item.EndDate = (DateTime?)reader["EndDate"];
               if (reader["Status"] != DBNull.Value)
                  item.Status = reader["Status"].ToString();
               result.Add(item);
            }
         }
         return result;
      }



   }
}
