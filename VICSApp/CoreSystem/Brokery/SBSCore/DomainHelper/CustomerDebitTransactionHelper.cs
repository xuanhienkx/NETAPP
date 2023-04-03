using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CommonDomain;
using SBSCore.Common;
using System.Data;
using SBSCore.PorscheGateway;
using SBSCore.Security;

namespace SBSCore.DomainHelper
{
   public static class CustomerDebitTransactionHelper
   {
     
      internal static void Insert(CustomerDebitTransaction debitTrans)
      {
         using (SqlCommand command = new SqlCommand(ProviderConstants.SP_SBS_INSERTDEBITTRANSACTION, AccessFactory.CurrentInstance().Connection))
         {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = debitTrans.CustomerID;
            command.Parameters.Add("@TransDate", SqlDbType.SmallDateTime).Value = debitTrans.TransDate;
            command.Parameters.Add("@Type", SqlDbType.Char).Value = debitTrans.Type;
            command.Parameters.Add("@UserEnter", SqlDbType.VarChar).Value = debitTrans.UserEnter;
            command.Parameters.Add("@Amount", SqlDbType.Decimal).Value = debitTrans.Amount;
            command.Parameters.Add("@BranchCode", SqlDbType.VarChar).Value = debitTrans.BranchCode;
            command.ExecuteNonQuery();
         }
      }

      internal static CustomerDebitTransaction Initialize(InquiryData orderInfo, SBSCore.Security.UserLite uInfo, DateTime transDate, decimal avlAmount)
      {
         CustomerDebitTransaction debitTrans = new CustomerDebitTransaction();
         debitTrans.Amount = Math.Abs(avlAmount);
         debitTrans.BranchCode = uInfo.BranchCode;
         debitTrans.CustomerID = orderInfo.Customer.CustomerId;
         debitTrans.TransDate = transDate;
         debitTrans.Type = "D";
         debitTrans.UserEnter = uInfo.UserName;
         return debitTrans;
      }

      public static List<CustomerDebitTransaction> Get(string customerId, UserLite user)
      {
         var context = DBUtil.CreateContext();
         var dbObjs = context.CustomerDebitLimitTransactions.Where(x => x.BranchCode == user.BranchCode);
         if (!string.IsNullOrEmpty(customerId))
            dbObjs = dbObjs.Where(x => x.CustomerId.Contains(customerId));
         if (user.IsAgencyUser)
            dbObjs = dbObjs.Join(context.AgencyCustomers.Where(x => x.AgencyTradeCode == user.TradeCode),
               transaction => transaction.CustomerId, customer => customer.CustomerId,
               (transaction, customer) => transaction);
         return dbObjs.Select(x => new CustomerDebitTransaction()
                                   {
                                      Amount = x.Amount,
                                      BeforeLimitValue = x.BeforeLimitValue,
                                      BranchCode = x.BranchCode,
                                      CurrentLimitValue = x.CurrentLimitValue,
                                      CustomerID = x.CustomerId,
                                      TransDate = x.TransDate,
                                      Type = x.Type.ToString(),
                                      UserEnter = x.UserEnter
                                   }).ToList();
      }
   }
}
