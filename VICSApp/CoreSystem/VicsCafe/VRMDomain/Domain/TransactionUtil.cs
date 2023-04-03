using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using VRMDomain.Common;
using System.Data;

namespace VRMDomain.Domain
{
   public class TransactionResult
   {
      public string TransactionNumber;
      public string TransactionCode;
   }

   public static class TransactionUtil
   {
      private static string GetTransactionNumber(string branchCode, string userName)
      {
         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_BALANCE_SELECTTRANSACTIONNUMBER);
         cmd.Parameters.AddWithValue("@BranchCode", branchCode);
         cmd.Parameters.AddWithValue("@UserName", userName);
         return (string)cmd.ExecuteScalar();
      }

      public static TransactionResult CreateTransaction(BalanceAccount debitAccount, BalanceAccount creditAccount, decimal amount, string description, string customerId, UserLite user)
      {
         return CreateTransaction(debitAccount, creditAccount, string.Empty, amount, description, customerId, user);
      }

      public static TransactionResult CreateTransaction(BalanceAccount debitAccount, BalanceAccount creditAccount, string professionlTaskCode, decimal amount, string description, string customerId, UserLite user)
      {
         TransactionResult result = new TransactionResult();
         result.TransactionNumber = TransactionUtil.GetTransactionNumber(user.BranchCode, user.UserName);
         result.TransactionCode = string.IsNullOrEmpty(professionlTaskCode) ? string.Empty : TransactionUtil.GetTransactionCode(professionlTaskCode, user.BranchCode);

         InsertTransactionDay(debitAccount, result.TransactionCode, result.TransactionNumber, "D", description, amount, customerId, user);
         InsertTransactionDay(creditAccount, result.TransactionCode, result.TransactionNumber, "C", description, amount, customerId, user);
         return result;
      }

      private static string GetTransactionCode(string professionlTaskCode, string branchCode)
      {
         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_GETTRANSACTIONCODENUMBER);
         cmd.Parameters.AddWithValue("@BranchCode", branchCode);
         cmd.Parameters.AddWithValue("@ProfessionalTask", professionlTaskCode);
         cmd.Parameters.Add(new SqlParameter("@CurrentTransCode", System.Data.SqlDbType.VarChar, 10));
         cmd.Parameters["@CurrentTransCode"].Direction = System.Data.ParameterDirection.Output;
         cmd.ExecuteNonQuery();
         return (string)cmd.Parameters["@CurrentTransCode"].Value;
      }

      public static void InsertTransactionDay(BalanceAccount account, string tranCode, string tranNumber, string tranType, string desc, decimal amount, string customerId, UserLite user)
      {
         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_BALANCEENTRY_INSERT);

         cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
         cmd.Parameters.AddWithValue("@BankGL", account.BankGl);
         cmd.Parameters.AddWithValue("@SectionGL", account.SectionGl);
         cmd.Parameters.AddWithValue("@AccountID", account.AccountID);
         cmd.Parameters.AddWithValue("@AccountName", account.AccountName);
         if (string.IsNullOrEmpty(tranCode))
            cmd.Parameters.AddWithValue("@TransactionCode", DBNull.Value);
         else
            cmd.Parameters.AddWithValue("@TransactionCode", tranCode);
         cmd.Parameters.AddWithValue("@TransactionNumber", tranNumber);
         cmd.Parameters.AddWithValue("@DebitOrCredit", tranType);
         cmd.Parameters.AddWithValue("@Description", desc);
         cmd.Parameters.AddWithValue("@UserName", user.UserName);
         cmd.Parameters.AddWithValue("@Amount", amount);
         cmd.Parameters.AddWithValue("@Notes", customerId);
         cmd.Parameters.AddWithValue("@TradeCode", user.TradeCode);
         cmd.Parameters.AddWithValue("@DepartmentCode", string.IsNullOrEmpty(tranCode) ? "VRM" : tranCode.Substring(0, 5)); // lay 5 ky tu dau tien cua tranCode

         cmd.ExecuteNonQuery();
      }

      public static System.Data.DataTable GetIssuedTransactionList(string userTranscode, string vrmCode, string status, string accountid, UserLite user)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("select t.[TransactionCode], t.[TransactionNumber], [BankGl]+'.'+[SectionGl]+'.'+[AccountId] as accountid, ");
         sql.Append("[AccountName], [Description], [Amount], [Approver],[UserName],[DebitOrCredit], [notes] from [dbo].[TransactionDay] t \n");
         sql.Append("join (select distinct [TransactionCode], [TransactionNumber], [BranchCode] from [dbo].[TransactionDay] \n");
         sql.AppendFormat("where [BranchCode] = '{0}' and [Approved] = '{1}' ", user.BranchCode, LiteralUtil.GetLiteral(status));
         if (!string.IsNullOrEmpty(userTranscode))
            sql.AppendFormat("and [TransactionNumber] like '{0}%' ", LiteralUtil.GetLiteral(userTranscode));
         if (!string.IsNullOrEmpty(accountid))
            sql.AppendFormat("and [AccountId] = '{0}' ", LiteralUtil.GetLiteral(accountid));
         if (!string.IsNullOrEmpty(vrmCode))
            sql.AppendFormat("and [DepartmentCode] = '{0}' ", vrmCode);
         sql.Append(") x on t.[BranchCode] = [x].[BranchCode] and t.[TransactionCode] = [x].[TransactionCode] and t.[TransactionNumber] = x.[TransactionNumber] \n");
         sql.Append("order by t.[TransactionCode], t.[TransactionNumber], [t].[DebitOrCredit]");

         return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }

      public static void DeleteIssuedTransaction(string customerId, string vrmCode, string status, UserLite user)
      {
         // bo het cac but toan duoc sinh ra lien quan den khach hang va nghiep vu dang xoa
         StringBuilder sql = new StringBuilder();
         StringBuilder sqlBuilder = new StringBuilder();
         sql.Append("select distinct [TransactionNumber], description from [dbo].[TransactionDay] ");
         sql.AppendFormat("where [Notes] = '{0}' and [DepartmentCode] = '{1}' and [Approved] = '{2}' ",
            LiteralUtil.GetLiteral(customerId), LiteralUtil.GetLiteral(vrmCode), status);
         Dictionary<string, string> trans = new Dictionary<string, string>();
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql.ToString()))
         {
            while (r.Read())
            {
               trans.Add((string)r["TransactionNumber"], (string)r["description"]);

               sqlBuilder.AppendFormat("exec {0} @BranchCode = '{1}', @TransactionNumber = '{2}', @Approver = '{3}' \n",
                  status == "Y" ? GlobalConstants.SPSBS_BALANCEENTRY_DELETEAPPROVED : GlobalConstants.SPSBS_BALANCEENTRY_DELETENOTAPPROVED,
                  user.BranchCode,
                  (string)r["TransactionNumber"],
                  user.UserName);
            }
            r.Close();
            r.Dispose();
         }

         if (sqlBuilder.Length == 0)
            return;

         if (vrmCode == GlobalConstants.SBS_HTBUTRU_TIENMUACK)
         {
            // bo het cac but toan ghi thieu no tien mua ngay T
            sql = new StringBuilder();
            sql.Append("select dayamount, currentdebit, d.tradingdate from deferredbalance d join \n");
            sql.Append("(select sum(case [TransCode] when 'D' then [Amount] else - [Amount] end) as dayamount, [TradingDate] from [dbo].[DeferredTransactionDay] ");
            sql.AppendFormat("where [TransCode] like '[DX]' and [CustomerID] = '{0}' group by [TradingDate]) x on x.tradingdate = d.tradingdate and d.customerid = '{0}'",
               LiteralUtil.GetLiteral(customerId));
            using (SqlDataReader r = DBUtil.ExecuteDataReader(sql.ToString()))
            {
               if (r.Read())
               {
                  if ((decimal)r["dayamount"] > (decimal)r["currentdebit"])
                     throw new InvalidOperationException("Số tiền thiếu cần hủy lớn hơn số tiền thiếu hiện tại");

                  // phai xoa vi khong the loai tru duoc cac but toan bi xoa duoi dang danh dau X
                  sqlBuilder.AppendFormat("delete from deferredtransactionday where customerid = '{0}' and transcode like '[DX]' \n", customerId);
                  sqlBuilder.AppendFormat("delete from deferredbalance where customerid = '{0}' and tradingdate = {1} \n",
                     customerId, LiteralUtil.GetLiteral((DateTime)r["tradingdate"]));
               }
               r.Close();
               r.Dispose();
            }
            // cap nhat lai trang thai cua tradingresult
            sqlBuilder.AppendFormat("update [dbo].[TradingResult] set [DayId] = 0, [DeferredAmount] = 0 where [CustomerId] = '{0}' and [OrderSide] = 'B' and [DayId] != 0 \n", LiteralUtil.GetLiteral(customerId));
         }
         else if (vrmCode == GlobalConstants.SBS_CHAMTIENT)
         {
            // bo het cac but toan ghi tra no tien mua ngay T
            sql = new StringBuilder();
            sql.Append("select [BranchCode], [CustomerBranchCode], [CustomerName], [TransDate], [TradingDate], [Amount], [Description], [TransactionNumber] from [dbo].[DeferredTransactionDay] ");
            sql.AppendFormat("where [TransCode] = 'C' and [CustomerID] = '{0}' and [TransactionNumber] in ('{1}') order by [TransSeq] ",
             LiteralUtil.GetLiteral(customerId), string.Join("','", trans.Keys.ToArray()));

            using (SqlDataReader r = DBUtil.ExecuteDataReader(sql.ToString()))
            {
               sqlBuilder.AppendFormat("declare @seq bigint \n");
               while (r.Read())
               {
                  sqlBuilder.AppendFormat("exec {0} @BranchCode = '{1}',@CustomerBranchCode = '{2}',@CustomerID = '{3}',@CustomerName = '{4}',@TransDate = '{5}',@TradingDate = '{6}',@TransCode = 'R',@Amount = {7},@Description = 'HUY {8}',@UserEnter = '{9}',@DeferredType = 'CLEARING',@TransSeq = @seq output,@TransactionNumber = '{10}' \n",
                     GlobalConstants.SPSBS_DEFEREDTRANSACTIONDAY_INSERT,
                     (string)r["BranchCode"],
                     (string)r["CustomerBranchCode"],
                     customerId,
                     LiteralUtil.GetLiteral((string)r["CustomerName"]),
                     ((DateTime)r["TransDate"]).ToString("yyyy-MM-dd 00:00:00"),
                     ((DateTime)r["TradingDate"]).ToString("yyyy-MM-dd 00:00:00"),
                     LiteralUtil.GetNumericLiteral((decimal)r["Amount"]),
                     (string)r["Description"],
                     user.UserName,
                     (string)r["TransactionNumber"]);
                  sqlBuilder.AppendFormat("exec {0} @TransSeq = @seq,@BranchCode = '{1}',@Tradingdate = '{2}',@DeferredType = 'CLEARING' \n",
                     GlobalConstants.SPSBS_DEFEREDTRANSACTIONDAY_APPROVE,
                     (string)r["BranchCode"],
                     ((DateTime)r["TradingDate"]).ToString("yyyy-MM-dd 00:00:00"));
               }
               r.Close();
               r.Dispose();
            }
         }
         else if (vrmCode == GlobalConstants.SBS_TINHLAI)
         {
            List<string> ngay = new List<string>();
            foreach (KeyValuePair<string, string> k in trans)
               ngay.Add(k.Value.Substring(k.Value.LastIndexOf(' ') + 1));
               
            sqlBuilder.AppendFormat("update vrm_interestdate set islatest = 0, [status] = 'X' where customerid = '{0}' and convert(varchar(10), [date], 103) in ('{1}') \n", 
               LiteralUtil.GetLiteral(customerId), string.Join("','", ngay.ToArray()));
            sqlBuilder.AppendFormat("update vrm_interestdate set islatest = 1 where customerid = '{0}' and [date] = (select max([Date]) from [dbo].[vrm_InterestDate] where customerid = '{0}' and [status] != 'X') \n",
               LiteralUtil.GetLiteral(customerId));
         }
             //cập nhật lại trạng thái khi xoa but toan tinh phi luu ky
         else if (vrmCode == GlobalConstants.SBS_TINHFEE_LUUKY)
         {
             List<string> ngay = new List<string>();
             foreach (KeyValuePair<string, string> k in trans)
                 ngay.Add(k.Value.Substring(k.Value.LastIndexOf(' ') + 1));
             //cập nhật lại log call
             sqlBuilder.AppendFormat(" delete vrm_SecurityFeeLog where CustomerId='{0}' and CONVERT(varchar(10), CallDate,103) in('{1}') \n",
             //sqlBuilder.AppendFormat("update vrm_SecurityFeeLog set CustomerSecurityFeeId = null, AccountRef = null where CustomerId='{0}' and CONVERT(varchar(10), CallDate,103) in('{1}') \n",
              LiteralUtil.GetLiteral(customerId), string.Join("','", ngay.ToArray()));
             // cập nhật lại CustomerSecurityFee
             sqlBuilder.AppendFormat("update vrm_CustomerSecurityFee set IsLasted = 0, [Status] = 'X' where AccountId = '{0}' and convert(varchar(10), [FeeDate], 103) in ('{1}') \n",
                LiteralUtil.GetLiteral(customerId), string.Join("','", ngay.ToArray()));
             sqlBuilder.AppendFormat("update vrm_CustomerSecurityFee set IsLasted = 1 where AccountId = '{0}' and [FeeDate] = (select max([FeeDate]) from [dbo].[vrm_CustomerSecurityFee] where AccountId = '{0}' and [Status] != 'X') \n",
                LiteralUtil.GetLiteral(customerId));
         }
         else if (vrmCode == GlobalConstants.HACHTOAN_GIAINGANHDKH)
         {
            sqlBuilder.Append("declare @damount money, @contractid int \n");
            sqlBuilder.AppendFormat("select @contractid = id from [dbo].[vrm_Contract] where [CustomerId] = '{0}' and [ContractType]= {1} and [DisbursedDate] = {2} \n",
               LiteralUtil.GetLiteral(customerId), (byte)ContractType.CoThoiHan, LiteralUtil.GetLiteral(DateTime.Today));
            sqlBuilder.AppendFormat("select @damount = sum(amount) from vrm_contract_transaction where contractid = @contractid and transactionday = {0} and transactioncode = '{1}' and transactionnumber in ('{2}') and isDeleted = 0 \n",
               LiteralUtil.GetLiteral(DateTime.Today), GlobalConstants.HD_GIAINGAN, string.Join("','", trans.Keys.ToArray()));

            sqlBuilder.AppendFormat("update [dbo].[vrm_Contract] set [Status] = case when @damount = [DisbursedAmount] then {0} else {1} end, [DisbursedAmount] = [DisbursedAmount] - @damount, [DisbursedBy] = '{2}', [DisbursedDate] = {3} where id = @contractid \n",
               (byte)ContractStatus.DaDuyet, (byte)ContractStatus.DaGiaiNgan, user.UserName, LiteralUtil.GetLiteral(DateTime.Today));
            sqlBuilder.AppendFormat("update dbo.vrm_Contract_Transaction set IsDeleted = 1 where contractid = @contractid and transactioncode = '{0}' and transactionnumber in ('{1}') \n",
               GlobalConstants.HD_GIAINGAN, string.Join("','", trans.Keys.ToArray()));
         }
         else if (vrmCode == GlobalConstants.HACHTOAN_THANHLYHDKH)
         {
            sqlBuilder.Append("declare @amount money, @iamount money, @contractid int \n");
            sqlBuilder.AppendFormat("select @contractid = id from [dbo].[vrm_Contract] where [CustomerId] = '{0}' and [ContractType]= {1} and [WithdrawDate] = {2} \n",
               LiteralUtil.GetLiteral(customerId), (byte)ContractType.CoThoiHan, LiteralUtil.GetLiteral(DateTime.Today));
            sqlBuilder.AppendFormat("select @amount = sum(amount) from vrm_contract_transaction where contractid = @contractid and transactionday = {0} and transactioncode = '{1}' and transactionnumber in ('{2}') and isDeleted = 0 \n",
               LiteralUtil.GetLiteral(DateTime.Today), GlobalConstants.HD_THANHLY_THUNOGOC, string.Join("','", trans.Keys.ToArray()));
            sqlBuilder.AppendFormat("select @iamount = sum(amount) from vrm_contract_transaction where contractid = @contractid and transactionday = {0} and transactioncode = '{1}' and transactionnumber in ('{2}') and isDeleted = 0 \n",
               LiteralUtil.GetLiteral(DateTime.Today), GlobalConstants.HD_THANHLY_THULAI, string.Join("','", trans.Keys.ToArray()));

            sqlBuilder.AppendFormat("update [dbo].[vrm_Contract] set [Status] = {0}, [withdrawAmount] = [withdrawAmount] - @amount, [InterestAmount] = [InterestAmount] - @iamount, [WithdrawBy] = '{1}', [WithdrawDate] = {2} where id = @contractid \n",
               (byte)ContractStatus.DaGiaiNgan, user.UserName, LiteralUtil.GetLiteral(DateTime.Today));
            sqlBuilder.AppendFormat("update dbo.vrm_Contract_Transaction set IsDeleted = 1 where contractid = @contractid and transactioncode in ('{0}', '{1}') and transactionnumber in ('{2}') \n",
               GlobalConstants.HD_THANHLY_THULAI, GlobalConstants.HD_THANHLY_THUNOGOC, string.Join("','", trans.Keys.ToArray()));
         }
         if (sqlBuilder.Length > 0)
            DBUtil.ExecuteNonQuery(sqlBuilder.ToString());
      }

      public static void ApprovingTransaction(string customerId, string transNumber, DateTime transDate, UserLite user)
      {
         if (Util.AutoUnblockedCustomerBalance && (user.IsBranchAdmin || user.Rights.Contains("KeToan_TuDongGiaiToaTien")))
         {
            DataTable data = Customer.GetBlockBalanceAndDebitLimitInfo(customerId, user);
            if (data != null && data.Rows.Count > 0)
            {
               decimal currentDebit = data.Rows[0].IsNull("CurrentLimitValue") ? 0M : (decimal)data.Rows[0]["CurrentLimitValue"];
               decimal localBlockedAmount = (decimal)data.Rows[0]["BlockBalance"];
               decimal bankBlockedAmount = (decimal)data.Rows[0]["Balance"];
               UnBlockBalanceAmount(customerId, currentDebit, localBlockedAmount, bankBlockedAmount, transDate, user);
            }
         }

         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_BALANCEENTRY_APPROVING);
         cmd.Parameters.AddWithValue("@TransactionNumber", transNumber);
         cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
         cmd.Parameters.AddWithValue("@Approver", user.UserName);
         cmd.ExecuteNonQuery();
      }

      public static void UnBlockBalanceAmount(string customerId, decimal unBlockedCreditAmount, decimal unBlockedLocalAmount, decimal unBlockedBankAmount, DateTime transDate, UserLite user)
      {
         if (unBlockedCreditAmount > 0)
         {
            SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_CUSTOMERCREDITUNBLOCK);
            cmd.Parameters.AddWithValue("@CustomerId", LiteralUtil.GetLiteral(customerId));
            cmd.Parameters.AddWithValue("@TransDate", transDate);
            cmd.Parameters.AddWithValue("@Amount", unBlockedCreditAmount);
            cmd.Parameters.AddWithValue("@UserEnter", user.UserName);
            cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
            cmd.Parameters.Add(new SqlParameter("@AmountCreditUnBlock", System.Data.SqlDbType.Decimal));
            cmd.Parameters["@AmountCreditUnBlock"].Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();
         }

         string bankCode, cif, customerName;
         bankCode = cif = customerName = string.Empty;
         using (SqlDataReader r = DBUtil.SBExecuteDataReader(GlobalConstants.SPSBS_GETCUSTOMERBANK, new SqlParameter("@customerid", customerId)))
         {
            if (r.Read())
            {
               bankCode = (string)r["bankcode"];
               cif = (string)r["cif"];
               customerName = (string)r["customername"];
            }
            r.Close();
            r.Dispose();
         }

         UnBlockBankAmount(customerId, bankCode, cif, customerName, unBlockedLocalAmount, "U", transDate, user);
         UnBlockBankAmount(customerId, bankCode, cif, customerName, unBlockedBankAmount, "R", transDate, user);
      }

      private static void UnBlockBankAmount(string customerId, string bankCode, string cif, string customerName, decimal amount, string transCode, DateTime transDate, UserLite user)
      {
         if (amount == 0)
            return;

         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_INSERTCUSTOMERTRANSACTIONDAY);
         cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
         cmd.Parameters.AddWithValue("@CustomerBranchCode", user.BranchCode);
         cmd.Parameters.AddWithValue("@CustomerId", customerId);
         cmd.Parameters.AddWithValue("@CustomerName", customerName);
         cmd.Parameters.AddWithValue("@BankCode", bankCode);
         cmd.Parameters.AddWithValue("@CIF", cif);
         cmd.Parameters.AddWithValue("@TransDate", transDate);
         cmd.Parameters.AddWithValue("@TransCode", transCode);
         cmd.Parameters.AddWithValue("@TaskCode", "ORDER");
         cmd.Parameters.AddWithValue("@EntryCode", "NONE");
         cmd.Parameters.AddWithValue("@Amount", amount);
         cmd.Parameters.AddWithValue("@Description", transCode == "U" ? "GIAI TOA NOI BO" : "GIAI TOA NGAN HANG");
         cmd.Parameters.AddWithValue("@Status", "N");
         cmd.Parameters.AddWithValue("@IsGenerateEntry", false);
         if (transCode == "R")
         {
            int tranNo = (int)DBUtil.ExecuteScalar(string.Format(
               "update [dbo].[BankTransactionDayNumber] set [CurrentValue] = [CurrentValue] + 1 output inserted.[CurrentValue] - 1 where [BankCode] = '{0}' and [TransactionType] = 'UNHOLD'",
               bankCode));
            cmd.Parameters.AddWithValue("@Ref", string.Format("002-U-{0:00000#}.{1:yyyyMMdd.hh:mm:ss:fff}", tranNo, transDate));
         }
         else
            cmd.Parameters.AddWithValue("@Ref", DBNull.Value);
         cmd.Parameters.AddWithValue("@UserEnter", user.UserName);
         cmd.Parameters.AddWithValue("@UserApprove", string.Empty);
         cmd.Parameters.Add(new SqlParameter("@TransSeq", System.Data.SqlDbType.Int));
         cmd.Parameters["@TransSeq"].Direction = System.Data.ParameterDirection.Output;
         cmd.ExecuteNonQuery();

         int tranSeq = (int)cmd.Parameters["@TransSeq"].Value;
         cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_INSERTCUSTOMERTRANSACTIONDAYAPPROVE);
         cmd.Parameters.AddWithValue("@TransSeq", tranSeq);
         cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
         cmd.Parameters.AddWithValue("@UserApprove", user.UserName);
         cmd.ExecuteNonQuery();
      }
   }
}
