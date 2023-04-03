using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using CommonDomain;
using log4net.Util;
using ProviderDataAcess;
using SBSCore.Security;
using SBSCore.Common;
using CustomerDebitLimit = CommonDomain.CustomerDebitLimit;
using CustomerDebitLimitLog = CommonDomain.CustomerDebitLimitLog;

namespace SBSCore.DomainHelper
{
   public static class CustomerDebitLimitHelper
   {

      public static void CustomerDebitLimitInsert(CustomerDebitLimit customerDebitLimit, DateTime transDate, UserLite uInfo)
      {
         if (!uInfo.IsAgencyUser && uInfo.TradeCode != Util.BranchTradeCode[uInfo.BranchCode])
            throw new InvalidOperationException("Không thể thực hiện được việc cấp hạn mức. Xin vui lòng liên hệ IT để được giúp đỡ.");

         using (var transaction = new TransactionScope())
         {
            var context = DBUtil.CreateContext();
             var tradeCode = string.Empty;
             var agencay = context.AgencyCustomers.SingleOrDefault(x => x.CustomerId == customerDebitLimit.CustomerID);
             if (agencay != null)
             {
                 tradeCode = agencay.AgencyTradeCode;
             }
             else
             {
                 tradeCode = uInfo.TradeCode;
             }
                
            var groupDebitLimit = context.vrm_DebitLimits.SingleOrDefault(
               x => x.TradeCode == tradeCode &&
               x.TradingDate == transDate.ToString("dd/MM/yyyy"));
            if (groupDebitLimit == null)
               throw new NotImplementedException("Chưa thiết lập hạn mức tín dụng đầu ngày. Xin vui lòng liên hệ cán bộ kiểm soát để cấp hạn mức.");

            var oldDebitLimit =
               context.CustomerDebitLimits.Where(x => x.CustomerId == customerDebitLimit.CustomerID)
                  .Select(x => x.LimitValue)
                  .FirstOrDefault();
            if (customerDebitLimit.LimitValue - oldDebitLimit > groupDebitLimit.CurrentDebitLimit)
               throw new InvalidOperationException(string.Format("Tổng hạn mức còn lại là {0:n0}. Không đủ để cấp cho khách hàng.", groupDebitLimit.CurrentDebitLimit));

            var oldCustomerDebitLimit = context.CustomerDebitLimits
                                               .Where(x => x.CustomerId == customerDebitLimit.CustomerID)
                                               .Select(x => x.LimitValue).SingleOrDefault();


            context.CustomerDebitLimit_Insert(customerDebitLimit.CustomerID, customerDebitLimit.LimitValue,
               customerDebitLimit.Activate, customerDebitLimit.CurrentLimitValue,
               transDate.TrimTimeSpan(), DateTime.Now.ToString("hh:mm:ss"), uInfo.UserName,
               customerDebitLimit.FromDate.TrimTimeSpan(),
               customerDebitLimit.ToDate.TrimTimeSpan(), customerDebitLimit.DebitLimitType);

            //SqlParameter p1 = new SqlParameter("@CustomerId", SqlDbType.VarChar);
            //p1.Value = customerDebitLimit.CustomerID;
            //SqlParameter p2 = new SqlParameter("@LimitValue", SqlDbType.Decimal);
            //p2.Value = customerDebitLimit.LimitValue;
            //SqlParameter p3 = new SqlParameter("@IsActive", SqlDbType.Bit);
            //p3.Value = customerDebitLimit.Activate;
            //SqlParameter p4 = new SqlParameter("@CurrentLimitValue", SqlDbType.Decimal);
            //p4.Value = customerDebitLimit.CurrentLimitValue;
            //SqlParameter p5 = new SqlParameter("@TransactionDate", SqlDbType.DateTime);
            //p5.Value = transDate.TrimTimeSpan();
            //SqlParameter p6 = new SqlParameter("@TransactionTime", SqlDbType.VarChar);
            //p6.Value = DateTime.Now.ToString("hh:mm:ss");
            //SqlParameter p7 = new SqlParameter("@UserEnter", SqlDbType.VarChar);
            //p7.Value = uInfo.UserName;
            //SqlParameter p8 = new SqlParameter("@FromDate", SqlDbType.DateTime);
            //p8.Value = customerDebitLimit.FromDate.TrimTimeSpan();
            //SqlParameter p9 = new SqlParameter("@ToDate", SqlDbType.DateTime);
            //p9.Value = customerDebitLimit.ToDate.TrimTimeSpan();
            //SqlParameter p10 = new SqlParameter("@DebitLimitType", SqlDbType.Char);
            //p10.Value = customerDebitLimit.DebitLimitType;

            //DBUtil.SPExecuteNonQuery(ProviderConstants.SP_SBS_INSERTCUSTOMERDEBITLIMIT, p1, p2, p3, p4, p5, p6, p7, p8,
            //                         p9, p10);

            // update the total debit amount
            var addedDebitLimit = customerDebitLimit.LimitValue - oldCustomerDebitLimit;
            groupDebitLimit.DebitLimitDay = groupDebitLimit.DebitLimitDay + addedDebitLimit;
            groupDebitLimit.CurrentDebitLimit = groupDebitLimit.CurrentDebitLimit - addedDebitLimit;

            context.SubmitChanges();
            transaction.Complete();
         }
      }

      public static CustomerDebitLimit FindCustomerDebitLimit(string customerId, DateTime tradingDate,
         UserLite userInfo)
      {
         var context = DBUtil.CreateContext();
         var customers = context.Customers.Where(x => x.CustomerId.EndsWith(customerId));
         if (userInfo.BranchCode!="200")
         {
             customers = customers.Where(x => x.BranchCode == userInfo.BranchCode);
             if (userInfo.IsAgencyUser)
             {
                 customers = customers.Join(context.AgencyCustomers.Where(x => x.AgencyTradeCode == userInfo.TradeCode),
                     customer => customer.CustomerId, customer => customer.CustomerId,
                     (customer, agencyCustomer) => customer);
             }
             else if (userInfo.BranchCode=="100")
             {
                 // use left join to get all 100 branch agency customers
                 var agenciesCustomers =
                     context.AgencyCustomers.Where(x => Util.AgencyAsBranch.Contains(x.AgencyTradeCode)).Select(x=>x.CustomerId);

                 customers = customers.Where(x => agenciesCustomers.All(ax => ax != x.CustomerId));
             }
         }
         var c = customers.FirstOrDefault(x=>x.AccountStatus == 'O' );
         if (c == null)
            return null;

         var debit = context.CustomerDebitLimits.SingleOrDefault(x => x.CustomerId == c.CustomerId);
         if (debit == null)
            return new CustomerDebitLimit() {CustomerID = c.CustomerId};
         return new CustomerDebitLimit()
                {
                   CustomerID = debit.CustomerId,
                   Activate = debit.IsActive,
                   CurrentLimitValue = debit.CurrentLimitValue,
                   DebitLimitType = debit.DebitLimitType,
                   FromDate = debit.FromDate,
                   ToDate = debit.ToDate,
                   LimitValue = debit.LimitValue
                };
      }

       public static List<CustomerDebitLimit> CustomerDebitLimitGet(string customerId, DateTime tradingDate,
           UserLite userInfo)
       {
           var result = new List<CustomerDebitLimit>();
           var sql = new StringBuilder();
           sql.AppendLine(
               "SELECT d.[CustomerId],[LimitValue],[DayLimitValue],[IsActive],[CurrentLimitValue],[FromDate],[ToDate],[DebitLimitType] ");
           sql.AppendLine("FROM CustomerDebitLimit d JOIN [Customers] c on d.[CustomerId] = c.[CustomerId] ");
           sql.AppendLine("LEFT JOIN [AgencyCustomer] a on d.[CustomerId] = a.[CustomerId] ");
           
           sql.AppendFormat(" WHERE @TransactionDate between fromdate and todate and c.BranchCode = @BranchCode \n");
           if (userInfo.IsAgencyUser)
               sql.AppendFormat("and [AgencyTradeCode] = '{0}' \n", userInfo.TradeCode);
           else
               sql.AppendLine("and isnull([AgencyTradeCode], '"+userInfo.TradeCode+"') not in ('" + string.Join("','", Util.AgencyAsBranch) + "')");

           if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("AND d.[CustomerId] like '%{0}' ", LiteralUtil.GetLiteral(customerId));
           var transactionDate = new SqlParameter("@TransactionDate", tradingDate.TrimTimeSpan());
           var branchCode = new SqlParameter("@BranchCode", userInfo.BranchCode);

           using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql.ToString(), transactionDate, branchCode))
           {
               while (reader.Read())
               {
                   result.Add(new CustomerDebitLimit
                   {
                       CurrentLimitValue = Convert.ToDecimal(reader["CurrentLimitValue"]),
                       LimitValue = Convert.ToDecimal(reader["LimitValue"]),
                       CustomerID = Convert.ToString(reader["CustomerId"]),
                       Activate = Convert.ToBoolean(reader["IsActive"]),
                       FromDate = Convert.ToDateTime(reader["FromDate"]),
                       ToDate = Convert.ToDateTime(reader["ToDate"]),
                       DebitLimitType = Convert.ToChar(reader["DebitLimitType"])
                   });
               }
               reader.Close();
           }
           return result;
       }

       public static List<CustomerDebitLimitLog> CustomerDebitLimitGetHistoryLog(string customerId, DateTime fromDate, DateTime toDate, UserLite user)
      {
         var context = DBUtil.CreateContext();
         
         var dbLogs = context.CustomerDebitLimitLogs.Where(x => x.CustomerId.Contains(customerId)
                                                                && x.TransactionDate >= fromDate.TrimTimeSpan() &&
                                                                x.TransactionDate <= toDate.TrimTimeSpan())
            .Join(context.Customers.Where(c => c.BranchCode==user.BranchCode), log => log.CustomerId,
                  customer => customer.CustomerId,
                  (log, customer) => new { CustomerName = customer.CustomerNameViet, DebitLog = log });
         
         if (user.IsAgencyUser)
            dbLogs = dbLogs.Join(context.AgencyCustomers.Where(x => x.AgencyTradeCode == user.TradeCode), log => log.DebitLog.CustomerId,
                        agency => agency.CustomerId, (log, customer) => log);
         
         else if (user.BranchCode!="200")
             dbLogs = dbLogs.Join(context.AgencyCustomers.Where(x =>!Util.AgencyAsBranch.Contains(x.AgencyTradeCode)), log => log.DebitLog.CustomerId,
                                    agency => agency.CustomerId, (log, customer) => log);

         return dbLogs.ToList().Select(x => new CustomerDebitLimitLog()
                                               {
                                                  CustomerId = x.DebitLog.CustomerId,
                                                  FromDate = x.DebitLog.FromDate.GetValueOrDefault(),
                                                  LimitValue = x.DebitLog.LimitValue.GetValueOrDefault(0),
                                                  OldFromDate = x.DebitLog.OldFromDate.GetValueOrDefault(),
                                                  CustomerName = x.CustomerName,
                                                  OldLimitValue = x.DebitLog.OldLimitValue.GetValueOrDefault(),
                                                  OldToDate = x.DebitLog.OldToDate.GetValueOrDefault(),
                                                  ToDate = x.DebitLog.ToDate.GetValueOrDefault(),
                                                  TransactionDate = x.DebitLog.TransactionDate,
                                                  TransactionTime = x.DebitLog.TransactionTime,
                                                  UserEnter = x.DebitLog.UserEnter
                                               }).ToList();
      }

      public static void SetGroupDebitLimit(string branchCode, string tradeCode, decimal debitLimit, DateTime tradingDate, UserLite user)
      {
         using (var trans = new TransactionScope())
         {
            var context = DBUtil.CreateContext();
            var currentTradingDate = tradingDate.ToString("dd/MM/yyyy");
            var currentDebit = context.vrm_DebitLimits.SingleOrDefault(x => x.TradeCode == tradeCode &&
                                                                            x.BranchCode == branchCode &&
                                                                            x.TradingDate == currentTradingDate);

            if (currentDebit != null && currentDebit.DebitLimitDay > debitLimit)
               throw new InvalidOperationException("Bạn không thể thay đổi được hạn mức đã cấp vì tổng hạn mức đã cấp lớn hơn tổng hạn mức mới.");

            // kiem tra neu la dai ly
            byte unitType = 1; // la dai ly
            if (currentDebit != null)
               unitType = currentDebit.UnitType;
            else
            {
                if (Util.BranchTradeCode.Values.Any(x => x == tradeCode) || Util.AgencyAsBranch.Contains(tradeCode))
                  unitType = 0;
            }

            if (unitType == 1) // dai ly
            {
               var branchDebit = context.vrm_DebitLimits.SingleOrDefault(x => x.TradeCode == Util.BranchTradeCode[branchCode] &&
                                                                              x.BranchCode == branchCode &&
                                                                              x.TradingDate == currentTradingDate);
               if (branchDebit == null)
                  throw new InvalidOperationException("Bạn không thể cấp hạn mức cho đại lý, xin vui lòng cấp hạn mức cho chi nhánh trước.");

               var currentDebitLimitAmount = currentDebit != null ? currentDebit.DebitLimitAmount : 0;

               if (branchDebit.CurrentDebitLimit < debitLimit - currentDebitLimitAmount)
                  throw new InvalidOperationException("Tổng hạn mức còn lại của chi nhánh không đủ để bạn cấp hạn mức cho đại lý.");

               // cap nhat tong han muc cua chi nhanh
               branchDebit.CurrentDebitLimit = branchDebit.CurrentDebitLimit - debitLimit + currentDebitLimitAmount;
               branchDebit.DebitLimitDay = branchDebit.DebitLimitDay + debitLimit - currentDebitLimitAmount;
            }

            if (currentDebit == null)
            {
               currentDebit = new vrm_DebitLimit()
                                 {
                                    BranchCode = branchCode,
                                    TradeCode = tradeCode,
                                    TradingDate = currentTradingDate,
                                    CreatedBy = user.UserName,
                                    CreatedDate = DateTime.Now,
                                    CurrentDebitLimit = debitLimit,
                                    DebitLimitDay = 0,
                                    DebitLimitAmount = debitLimit,
                                    UnitType = unitType
                                 };
               context.vrm_DebitLimits.InsertOnSubmit(currentDebit);
            }
            else
            {
               currentDebit.DebitLimitAmount = debitLimit;
               currentDebit.CurrentDebitLimit = debitLimit - currentDebit.DebitLimitDay.GetValueOrDefault(0);
               currentDebit.ModifiedBy = user.UserName;
               currentDebit.ModifiedDate = DateTime.Now;
            }

            context.SubmitChanges();
            trans.Complete();
         }
      }

      public static List<GroupDebitLimit> GetGroupDebitLimits(DateTime tradingDate, UserLite user)
      {
         var context = DBUtil.CreateContext();
         var debitLimits = context.vrm_DebitLimits.Where(x=>x.TradingDate == tradingDate.ToString("dd/MM/yyyy"))
                                                  .Join(context.UnitTradeCodes, limit => limit.TradeCode, code => code.TradeCode,
                                                         (limit, code) => new { DebitLimit = limit, Name = code.UnitName });

         if (!user.IsAgencyUser && user.BranchCode != "200")
            debitLimits = debitLimits.Where(x => x.DebitLimit.BranchCode == user.BranchCode && !Util.AgencyAsBranch.Contains(x.DebitLimit.TradeCode));

         if (user.IsAgencyUser)
            debitLimits = debitLimits.Where(x => x.DebitLimit.TradeCode == user.TradeCode && x.DebitLimit.BranchCode == user.BranchCode);

         return debitLimits.ToList().Select(limit => new GroupDebitLimit()
                                               {
                                                  BranchCode = limit.DebitLimit.BranchCode,
                                                  TradeCode = limit.DebitLimit.TradeCode,
                                                  CreatedDate = limit.DebitLimit.CreatedDate,
                                                  CreatedBy = limit.DebitLimit.CreatedBy,
                                                  CurrentDebitLimit = limit.DebitLimit.CurrentDebitLimit,
                                                  DebitLimitAmount = limit.DebitLimit.DebitLimitAmount,
                                                  DebitLimitDay = limit.DebitLimit.DebitLimitDay.GetValueOrDefault(),
                                                  TradingDate = limit.DebitLimit.TradingDate,
                                                  ModifiedBy = limit.DebitLimit.ModifiedBy,
                                                  ModifiedDate = limit.DebitLimit.ModifiedDate.GetValueOrDefault(),
                                                  Name = limit.Name,
                                                  UnitType = limit.DebitLimit.UnitType
                                               }).ToList();
      }
   }
}
