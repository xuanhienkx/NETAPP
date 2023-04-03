using System;
using System.Data.SqlClient;
using System.Data;
using CommonDomain;
using SBSCore.Security;
using SBSCore.Common;

namespace SBSCore.DomainHelper
{
    public static class InquiryDataHelper
    {
        
        private static void UpdateCustomerCashDetails(InquiryData info, DateTime tradingDate)
        {
            using (SqlCommand command = new SqlCommand(ProviderConstants.SP_SBS_GETCUSTOMERCASHDETAIL, AccessFactory.CurrentInstance().Connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = info.Customer.CustomerId;
                command.Parameters.Add("@TradingDate", SqlDbType.SmallDateTime).Value = tradingDate;
                command.Parameters.Add("@AvailBalance", SqlDbType.Decimal).Value = info.CustomerBalance.AvailBalance;
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
                info.AvaiableBalance = info.CustomerBalance.AvailBalance;
                info.BlockBalance = info.CustomerBalance.BlockBalance;
            }
        }

        private static void UpdateCustomerStockDetail(InquiryData info, DateTime tradingDate)
        {
            using (SqlCommand command = new SqlCommand(ProviderConstants.SP_SBS_GETCUSTOMERSTOCKDETAIL, AccessFactory.CurrentInstance().Connection))
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
                info.SoldStockNoPost = Convert.ToInt64(command.Parameters["@SoldStockNoPost"].Value);
            }
        }

        public static InquiryData GetData(InquiryData order, DateTime tradingDate, UserLite uInfo)
        {
           if (string.IsNullOrEmpty(order.Customer.BranchCode))
           {
              order.Customer = CustomerHelper.GetCustomer(order.Customer.CustomerId, uInfo.BranchCode, uInfo);
              if (order.Customer == null)
                 throw new Exception(
                    "Không xác định được khách hàng hoặc bạn không có quyền truy vấn thông tin của khác hàng");
           }

           if (order.TradingStockVolume.HasValue && order.TradingStockPrice.HasValue)
            {
               order.TradingValue = order.TradingStockVolume.Value * order.TradingStockPrice.Value * 1000M;
               order.TradingFee = SBSDal.GetFeeValue(order.Customer.CustomerId, order.TradingStock.StockCode, order.TradingValue);
            }

            // update stock info when order side is SELL
            if (order.OrderSide == OrderSide.S)
                UpdateCustomerStockDetail(order, tradingDate);
            // update cash info when order side is BUY
            else if (order.OrderSide == OrderSide.B)
            {
               order.CustomerBalance = CustomerBalanceHelper.GetCustomerBalanceBySBSBankService(false, tradingDate, order.Customer.CustomerId,
                                              order.Customer.BankCode, uInfo.BranchCode, uInfo.UserName);


                if (order.CustomerBalance == null)
                    throw new Exception(string.Format("Không xác định được số tiền của khách hàng {0}", order.Customer.CustomerId));

                InquiryDataHelper.UpdateCustomerCashDetails(order, tradingDate);
            }

            return order;
        }

        
    }
}
