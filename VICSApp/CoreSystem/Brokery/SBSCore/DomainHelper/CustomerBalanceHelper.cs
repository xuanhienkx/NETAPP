using System;
using System.Data.SqlClient;
using System.Data;
using CommonDomain;
using SBSCore.Common;

namespace SBSCore.DomainHelper
{
   public static class CustomerBalanceHelper
   {
      
      public static CustomerBalance GetCustomerBalance(string customerID)
      {
         CustomerBalance balance = null;
         SqlParameter p1 = new SqlParameter("@CustomerID", SqlDbType.VarChar);
         p1.Value = customerID;
         using (SqlDataReader reader = DBUtil.SBExecuteDataReader(Common.ProviderConstants.SP_SBS_GETCUSTOMERBALANCE, p1))
         {
            if (reader.Read())
            {
               balance = new CustomerBalance();
               balance.AvailBalance = (decimal)reader["AvailBalance"];
               balance.Balance = (decimal)reader["Balance"];
               balance.BlockBalance = (decimal)reader["BlockBalance"];
               balance.CustomerID = reader["CustomerID"].ToString();
               balance.DayBlock = (decimal)reader["DayBlock"];
               balance.DayCredit = (decimal)reader["DayCredit"];
               balance.DayDebit = (decimal)reader["DayDebit"];
               balance.DayUnBlock = (decimal)reader["DayUnBlock"];
               balance.DayBankBlock = (decimal)reader["DayBankBlock"];
               balance.DayBankUnBlock = (decimal)reader["DayBankUnBlock"];
            }
            reader.Close();
         }
         return balance;
      }

      public static CustomerBalance GetCustomerBalanceBySBSBankService(bool inquiryOnline, DateTime transactionDate, string customerId, string bankCode, string branchCode, string username)
      {
         CustomerBalance balance = null;

            SBSBankGateway.InquiryAmountResult result;

            if (inquiryOnline)
            {
               result = Util.SBSBankService.InquiryOnline(transactionDate.ToString("dd/MM/yyyy"), customerId, bankCode, branchCode, username);
            }
            else
            {
               result = Util.SBSBankService.InquiryOffline(transactionDate.ToString("dd/MM/yyyy"), customerId, bankCode, branchCode, username);
            }

            if (result.Successful)
            {
               balance = new CustomerBalance();
               balance.AvailBalance = result.AvailBalance;
               balance.Balance = result.Balance;
               balance.LocalAvailBalance = result.LocalAvailBalance;
               balance.LocalBalance = result.LocalBalance;
               balance.BankBalance = result.BankBalance;
               balance.BankAvailBalance = result.BankAvailBalance;
               balance.LasttimeInquiry = result.LastTimeInquiry.ToString("hh:mm:ss:ffff");
               balance.BlockBalance = GetCustomerBalance(customerId).BlockBalance;
            } else
               throw new OperationCanceledException("Không lấy được số dư tiền của khách hàng tại ngân hàng. Error: " + result.ErrorMessage);
         return balance;
      }

      public static decimal CustomerCreditUnBlock(string customerId, DateTime transDate, decimal amount, string userEnter, string branchCode)
      {
         SqlParameter p1 = new SqlParameter("@CustomerId", SqlDbType.VarChar);
         SqlParameter p2 = new SqlParameter("@TransDate", SqlDbType.SmallDateTime);
         SqlParameter p3 = new SqlParameter("@Amount", SqlDbType.Decimal);
         SqlParameter p4 = new SqlParameter("@UserEnter", SqlDbType.VarChar);
         SqlParameter p5 = new SqlParameter("@BranchCode", SqlDbType.VarChar);
         SqlParameter po1 = new SqlParameter("@AmountCreditUnBlock", SqlDbType.Decimal);
         po1.Direction = ParameterDirection.Output;
         p1.Value = customerId;
         p2.Value = transDate;
         p3.Value = amount;
         p4.Value = userEnter;
         p5.Value = branchCode;

         DBUtil.SPExecuteNonQuery(ProviderConstants.SP_SBS_CUSTOMERCREDITUNBLOCK, p1, p2, p3, p4, p5, po1);

         return (decimal)po1.Value;
      }

      public static decimal GetCustomerDebitLimitCurrentValue(string customerId)
      {
         SqlParameter p1 = new SqlParameter("@CustomerId", SqlDbType.VarChar);
         SqlParameter po1 = new SqlParameter("@CurrentLimitValue", SqlDbType.Decimal);
         p1.Value = customerId;
         po1.Direction = ParameterDirection.Output;

         DBUtil.SPExecuteNonQuery(ProviderConstants.SP_SBS_GETCUSTOMERCURRENTLIMITVALUE, p1, po1);

         return (po1.Value != DBNull.Value) ? (decimal)po1.Value : 0M;
      }
   }
}
