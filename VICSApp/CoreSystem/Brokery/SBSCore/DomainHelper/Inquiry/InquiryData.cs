using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBSCore.Common;
using System.Data;
using System.Data.SqlClient;

namespace SBSCore.Domain.Inquiry
{
   public sealed class InquiryData
   {
      // Properties
      public string CustomerId;
      public decimal AvailBalance;
      public decimal Balance;
      public decimal BankAvailBalance;
      public decimal BankBalance;
      public decimal BlockBalance;
      public decimal BoughtCash;
      public decimal CurrentLimitValue;
      public decimal CustomerFee;
      public decimal LimitValue;

      public List<StockInquiry> StockInquiries;

      public InquiryData() { }

      public static InquiryData GetInquiryData(OrderInfo order, DateTime transDate)
      {
         InquiryData result = new InquiryData();
         SBSBankGateway.InquiryResult inqResult = Util.SBSBankService.Inquiry(transDate.ToString("dd/MM/yyyy"),
            order.Customer.CustomerId, order.Customer.BankCode, order.Customer.BranchCode, Util.SBSServiceUserName);

         if (!inqResult.Successful)
            throw new Exception("Không vấn tin được số dư tại tài khoản ngân hàng.");

         result.AvailBalance = inqResult.AvailBalance;
         result.BankAvailBalance = inqResult.BankAvailBalance;
         result.BankBalance = inqResult.BankBalance;
         result.Balance = inqResult.Balance;

         CustomerBalance customerBalance = CustomerBalance.GetCustomerBalance(order.Customer.CustomerId);
         result.BlockBalance = customerBalance.BlockBalance;

         if (order.OrderSide == OrderSide.B)
         {
            GetCustomerCashDetails(order, transDate, result);
         }
         else
         {
            result.BoughtCash = cashInfor.BoughtCash;
         }

         CustomerDebitLimit customerDebitLimit = this.GetCustomerDebitLimit(customer);
         if (customerDebitLimit != null)
         {
            result.CurrentLimitValue = customerDebitLimit.CurrentLimitValue;
            result.LimitValue = customerDebitLimit.LimitValue;
         }
         break;
      }

      internal static void GetCustomerCashDetails(OrderInfo info, DateTime tradingDate)
      {
         using (SqlCommand command = new SqlCommand(ConfigurationManager.AppSettings["SP_SBS_GETCUSTOMERCASHDETAIL"],
            SBSDal.SBSConnection, SBSDal.SBSTransaction))
         {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = info.Customer.CustomerId;
            command.Parameters.Add("@TradingDate", SqlDbType.SmallDateTime).Value = tradingDate;
            command.Parameters.Add("@AvailBalance", SqlDbType.Decimal).Value = info.Customer.Balance.AvailBalance;
            command.Parameters.Add("@CustomerLimitDebit", SqlDbType.Decimal);
            command.Parameters["@CustomerLimitDebit"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@CurrentLimitValue", SqlDbType.Decimal);
            command.Parameters["@CurrentLimitValue"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@LimitValue", SqlDbType.Decimal);
            command.Parameters["@LimitValue"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@IsActive", SqlDbType.Bit);
            command.Parameters["@IsActive"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@BoughtCash", SqlDbType.Decimal);
            command.Parameters["@BoughtCash"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            info.CurrentLimitValue = Convert.ToDecimal(command.Parameters["@CurrentLimitValue"].Value);
            info.CustomerLimitDebit = Convert.ToDecimal(command.Parameters["@CustomerLimitDebit"].Value);
            info.BoughtCash = Convert.ToDecimal(command.Parameters["@BoughtCash"].Value);
            info.LitmitValue = Convert.ToDecimal(command.Parameters["@LimitValue"].Value);
            info.IsActive = Convert.ToBoolean(command.Parameters["@IsActive"].Value);
            if (!info.IsActive)
            {
               info.LitmitValue = 0M;
            }
            info.AvaiableBalance = info.Customer.Balance.AvailBalance;
            info.BlockBalance = info.Customer.Balance.BlockBalance;
         }
      }

      internal static void GetCustomerStockDetail(OrderInfo info, DateTime tradingDate)
      {
         using (SqlCommand command = new SqlCommand(ConfigurationManager.AppSettings["SP_SBS_GETCUSTOMERSTOCKDETAIL"],
            SBSDal.SBSConnection, SBSDal.SBSTransaction))
         {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = info.Customer.CustomerId;
            command.Parameters.Add("@TradingDate", SqlDbType.SmallDateTime).Value = tradingDate;
            command.Parameters.Add("@StockCode", SqlDbType.VarChar).Value = info.TradingStock.StockCode;
            command.Parameters.Add("@BeginStock", SqlDbType.BigInt);
            command.Parameters["@BeginStock"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@PendingStock", SqlDbType.BigInt);
            command.Parameters["@PendingStock"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@MortageStock", SqlDbType.BigInt);
            command.Parameters["@MortageStock"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@SoldStock", SqlDbType.BigInt);
            command.Parameters["@SoldStock"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@SoldStockNoPost", SqlDbType.BigInt);
            command.Parameters["@SoldStockNoPost"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            info.BeginStock = Convert.ToInt64(command.Parameters["@BeginStock"].Value);
            info.SoldStock = Convert.ToInt64(command.Parameters["@SoldStock"].Value);
            info.MortageStock = Convert.ToInt64(command.Parameters["@MortageStock"].Value);
         }
      }

   }
}
