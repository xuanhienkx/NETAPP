using System;
using System.Data.SqlClient;
using System.Data;
using CommonDomain;
using SBSCore.Common;
using SBSCore.Security;

namespace SBSCore.DomainHelper
{
   public static class CustomerTransactionDayHelper
   {
      internal static CustomerTransactionDay Initialize(InquiryData orderInfo, UserLite uInfo, DateTime transDate, decimal amount, string transCode, string description)
      {
          CustomerTransactionDay ctd = new CustomerTransactionDay();

          ctd.BankCode = orderInfo.Customer.BankCode;
          ctd.BranchCode = uInfo.BranchCode;
          ctd.CIF = orderInfo.Customer.CIF;
          ctd.CustomerBranchCode = orderInfo.Customer.BranchCode;
          ctd.CustomerID = orderInfo.Customer.CustomerId;
          ctd.CustomerName = orderInfo.Customer.CustomerName;
          ctd.EntryCode = "NONE"; // enum value = 8
          ctd.IsGenerateEntry = false;
          ctd.Status = "N";
          ctd.TaskCode = "ORDER";
          ctd.TransCode = transCode;
          ctd.TransDate = transDate;
          ctd.UserEnter = uInfo.UserName;
          ctd.UserApprove = uInfo.UserName;
          ctd.WithApproved = true;
          ctd.Amount = amount;
          ctd.Description = description;

          return ctd;
      }
      internal static void Insert(CustomerTransactionDay ctd)
      {
         Logger.Info(ctd.Description);

         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_INSERTCUSTOMERTRANSACTIONDAY);

         cmd.Parameters.Add("@BranchCode", SqlDbType.VarChar).SqlValue = ctd.BranchCode;
         cmd.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).SqlValue = ctd.CustomerBranchCode;
         cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).SqlValue = ctd.CustomerID;
         cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).SqlValue = ctd.CustomerName;
         cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).SqlValue = ctd.BankCode;
         cmd.Parameters.Add("@CIF", SqlDbType.VarChar).SqlValue = ctd.CIF;
         cmd.Parameters.Add("@TransDate", SqlDbType.SmallDateTime).SqlValue = ctd.TransDate; 
         cmd.Parameters.Add("@TransCode", SqlDbType.VarChar).SqlValue = ctd.TransCode;
         cmd.Parameters.Add("@TaskCode", SqlDbType.VarChar).SqlValue = ctd.TaskCode;
         cmd.Parameters.Add("@EntryCode", SqlDbType.VarChar).SqlValue = ctd.EntryCode;
         cmd.Parameters.Add("@Amount", SqlDbType.Decimal).SqlValue = ctd.Amount;
         cmd.Parameters.Add("@Description", SqlDbType.VarChar).SqlValue = ctd.Description;
         cmd.Parameters.Add("@Status", SqlDbType.VarChar).SqlValue = ctd.Status;
         cmd.Parameters.Add("@IsGenerateEntry", SqlDbType.Bit).SqlValue = ctd.IsGenerateEntry;
         cmd.Parameters.Add("@UserEnter", SqlDbType.VarChar).SqlValue = ctd.UserEnter;
         cmd.Parameters.Add("@UserApprove", SqlDbType.VarChar).SqlValue = ctd.UserApprove;
         cmd.Parameters.Add("@TransSeq", SqlDbType.Int).Direction = ParameterDirection.Output;

         cmd.ExecuteNonQuery();

         ctd.TransSeq = Convert.ToInt32(cmd.Parameters["@TransSeq"].Value);

         // APPROVE
         cmd = DBUtil.CreateSqlCommmandToExecSP(ProviderConstants.SP_SBS_INSERTCUSTOMERTRANSACTIONDAYAPPROVE);
         cmd.Parameters.Add("@TransSeq", SqlDbType.Int).Value = ctd.TransSeq;
         cmd.Parameters.Add("@BranchCode", SqlDbType.VarChar).Value = ctd.BranchCode;
         cmd.Parameters.Add("@UserApprove", SqlDbType.VarChar).Value = ctd.UserEnter;
         
         cmd.ExecuteNonQuery();
      }
  }
}
