using System;
using System.Data.SqlClient;
using CommonDomain;
using SBSCore.Common;
using System.Data;

namespace SBSCore.DomainHelper
{
   public static class CustomerProxyHelper
   {
      private static void PasreFromDataReader(IDataReader dataReader, CustomerProxy customerProxy)
      {
          customerProxy.CustomerId = dataReader["CustomerId"].ToString();
          customerProxy.BranchCode = dataReader["BranchCode"].ToString();
          customerProxy.ProxyCustomerId = dataReader["ProxyCustomerId"].ToString();
          if (dataReader["DateProxy"] != DBNull.Value)
            customerProxy.DateProxy = Convert.ToDateTime(dataReader["DateProxy"]);
          customerProxy.ProxyName = dataReader["ProxyName"].ToString();
          customerProxy.ProxyNameViet = dataReader["ProxyNameViet"].ToString();
          if (dataReader["Dob"] != DBNull.Value)
              customerProxy.Dob = Convert.ToDateTime(dataReader["Dob"]);
          if (dataReader["SignatureImage1"] != DBNull.Value)
              customerProxy.SignatureImage1 = (byte[])dataReader["SignatureImage1"];
          if (dataReader["SignatureImage2"] != DBNull.Value)
              customerProxy.SignatureImage2 = (byte[])dataReader["SignatureImage2"];
          customerProxy.CardIdentity = dataReader["CardIdentity"].ToString();
          if (dataReader["CardDate"] != DBNull.Value)
              customerProxy.CardDate = Convert.ToDateTime(dataReader["CardDate"]);
          customerProxy.CardIssuer = dataReader["CardIssuer"].ToString();
          customerProxy.ProxyType = dataReader["ProxyType"].ToString();
          customerProxy.Address = dataReader["Address"].ToString();
          customerProxy.AddressViet = dataReader["AddressViet"].ToString();
          customerProxy.Mobile = dataReader["Mobile"].ToString();
          customerProxy.Email = dataReader["Email"].ToString();
          customerProxy.Country = dataReader["Country"].ToString();
          if (dataReader["BeginProxyDate"] != DBNull.Value)
              customerProxy.BeginProxyDate = Convert.ToDateTime(dataReader["BeginProxyDate"]);
          if (dataReader["EndProxyDate"] != DBNull.Value)
              customerProxy.EndProxyDate = Convert.ToDateTime(dataReader["EndProxyDate"]);


      }

      public static CustomerProxy GetCustomerProxy(string customerId)
      {
         CustomerProxy customerProxy = null;
         SqlParameter p1 = new SqlParameter("@CustomerID",SqlDbType.VarChar);
         p1.Value = customerId;
         using (SqlDataReader dataReader = DBUtil.SBExecuteDataReader(ProviderConstants.SP_SBS_GETCUSTOMERPROXY,p1))
         {
             customerProxy = new CustomerProxy();
            if (dataReader.Read())
                PasreFromDataReader(dataReader, customerProxy);
            dataReader.Close();
         }
         if (customerProxy == null)
            throw new Exception("Không tìm thấy tài khoản ủy quyền của khách hàng");

         return customerProxy;
      }


   }
}
