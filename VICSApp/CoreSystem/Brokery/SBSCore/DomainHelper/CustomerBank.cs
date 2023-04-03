using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SBSCore.Common;

namespace SBSCore.Domain
{
   public sealed class CustomerBank
   {
      public bool Activate;
      public string BankCode;
      public string CIF;
      public string CitizenNumber;
      public string CustomerBankId;
      public string CustomerID;
      public string CustomerName;

      public static CustomerBank GetCustomerBank(string customerId)
      {
         CustomerBank bank = null;

         SqlParameter p1 = new SqlParameter("@CustomerID", customerId);

         using (SqlDataReader reader = DBUtil.SBExecuteDataReader(ProviderConstants.SP_SBS_GETCUSTOMERBANK, p1))
         {
            if (reader.Read() && reader.HasRows)
            {
               bank = new CustomerBank();
               bank.CustomerID = reader["CustomerID"].ToString();
               bank.BankCode = reader["BankCode"].ToString();
               bank.CIF = reader["CIF"].ToString();
               bank.Activate = (bool)reader["Activate"];
               bank.CustomerName = reader["CustomerName"].ToString();
               bank.CustomerBankId = reader["CustomerBankID"].ToString();
               bank.CitizenNumber = reader["CitizenNumber"].ToString();
            }
            reader.Close();
         }
         return bank;
      }

      public static bool IsOnlineBank(string bankCode)
      {
         return bankCode == "";
      }
   }
}
