using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using VRMDomain.Common;

namespace VRMDomain.Domain
{
   public class BalanceAccount
   {
      public string BankGl;
      public string SectionGl;
      public string AccountID;
      public string AccountName;
      public decimal BeginCredit;
      public decimal BeginDay;
      public decimal YearDebit;
      public decimal YearCredit;
      public decimal MonthDebit;
      public decimal MonthCredit;
      public decimal DayDebit;
      public decimal DayCredit;
      public decimal CurrentBalance;
      public string DebitOrCredit;

      public BalanceAccount() { }


       internal static BalanceAccount Get(string bankGl, string sectionGl, string accountId, UserLite user)
      {
         string sql = string.Format("select {0} from balance where BankGl = '{1}' and SectionGl = '{2}' and AccountID = '{3}' and branchcode = '{4}' ",
            "BankGl, SectionGl, AccountID, AccountName, BeginCredit, BeginDay, YearDebit, YearCredit, MonthDebit, MonthCredit, DayDebit, DayCredit, CurrentBalance,DebitOrCredit",
            LiteralUtil.GetLiteral(bankGl),
            LiteralUtil.GetLiteral(sectionGl),
            LiteralUtil.GetLiteral(accountId),
            user.BranchCode);

         BalanceAccount result = null;
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
         {
            if (r.Read())
            {
                result = new BalanceAccount
                {
                    BankGl = r["BankGl"].ToString(),
                    SectionGl = r["SectionGl"].ToString(),
                    AccountID = r["AccountID"].ToString(),
                    AccountName = r["AccountName"].ToString(),
                    BeginCredit = (decimal) r["BeginCredit"],
                    BeginDay = (decimal) r["BeginDay"],
                    YearDebit = (decimal) r["YearDebit"],
                    YearCredit = (decimal) r["YearCredit"],
                    MonthDebit = (decimal) r["MonthDebit"],
                    MonthCredit = (decimal) r["MonthCredit"],
                    DayDebit = (decimal) r["DayDebit"],
                    DayCredit = (decimal) r["DayCredit"],
                    CurrentBalance = (decimal) r["CurrentBalance"],
                    DebitOrCredit = r["DebitOrCredit"].ToString()
                };
            }
            r.Close();
            r.Dispose();
         }

         return result;
      }

       public static List<BalanceAccount> GetDefinedBalanceAccounts(string code, UserLite user)
       {
           var result = new List<BalanceAccount>();
           using (SqlDataReader r = DBUtil.SBExecuteDataReader("vrm_GetDefinedBalanceAccount",
               new SqlParameter("@code", code),
               new SqlParameter("@branchCode", user.BranchCode)))
           {
               while (r.Read())
               {
                   result.Add(new BalanceAccount
                   {
                       BankGl = r["BankGl"].ToString(),
                       SectionGl = r["SectionGl"].ToString(),
                       AccountID = r["AccountID"].ToString(),
                       AccountName = r["AccountName"].ToString(),
                       BeginCredit = (decimal)r["BeginCredit"],
                       BeginDay = (decimal)r["BeginDay"],
                       YearDebit = (decimal)r["YearDebit"],
                       YearCredit = (decimal)r["YearCredit"],
                       MonthDebit = (decimal)r["MonthDebit"],
                       MonthCredit = (decimal)r["MonthCredit"],
                       DayDebit = (decimal)r["DayDebit"],
                       DayCredit = (decimal)r["DayCredit"],
                       CurrentBalance = (decimal)r["CurrentBalance"],
                       DebitOrCredit = r["DebitOrCredit"].ToString()
                   });
               }
               r.Close();
               r.Dispose();
           }
           return result;
       }

       private static void Create(BalanceAccount account, UserLite user)
      {
         SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_BALANCEOBJECT_CREATE);

         cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
         cmd.Parameters.AddWithValue("@BankGL", account.BankGl);
         cmd.Parameters.AddWithValue("@SectionGL", account.SectionGl);
         cmd.Parameters.AddWithValue("@AccountId", account.AccountID);
         cmd.Parameters.AddWithValue("@CurrencyCode", "VND");
         cmd.Parameters.AddWithValue("@AccountName", account.AccountName);
         cmd.Parameters.AddWithValue("@OpenDate", DateTime.Today);
         cmd.Parameters.AddWithValue("@DebitOrCredit", account.DebitOrCredit);

         cmd.ExecuteNonQuery();
      }

      /// <summary>
      /// PHAI THU NDT HD KHONG KY HAN 
      /// </summary>
      internal static BalanceAccount Get_135211(string customerID, UserLite user)
      {
         BalanceAccount r = Get("135211", "9999", customerID, user);
         if (r == null && Util.IsAutoGenerateAccount)
         {
            r = new BalanceAccount
            {
               BankGl = "135211",
               SectionGl = "9999",
               AccountID = customerID,
               AccountName = string.Format("PHAI THU NDT HD KHONG KY HAN TK{0}", customerID),
               DebitOrCredit = "L"
            };
            Create(r, user);
         }
         return r;
      }

      /// <summary>
      /// PHAI THU NDT HD CO KY HAN 
      /// </summary>
      internal static BalanceAccount Get_135411(string customerID, UserLite user)
      {
         BalanceAccount r = Get("135411", "9999", customerID, user);
         if (r == null && Util.IsAutoGenerateAccount)
         {
            r = new BalanceAccount
            {
               BankGl = "135411",
               SectionGl = "9999",
               AccountID = customerID,
               AccountName = string.Format("PHAI THU NDT HD CO KY HAN TK{0}", customerID),
               DebitOrCredit = "L"
            };
            Create(r, user);
         }
         return r;
      }

      /// <summary>
      /// THANH TOAN BU TRU GD CHUNG KHOAN NIEM YET
      /// </summary>
      internal static BalanceAccount Get_321111(UserLite user)
      {
         return Get("321111", "9999", "3211110001", user);
      }

      /// <summary>
      /// PHAI TRA NOI BO - MOI GIOI (13/02-16/02/09)
      /// </summary>
      internal static BalanceAccount Get_336111(UserLite user)
      {
         return Get("336111", "9999", "3361110001", user);
      }

      /// <summary>
      /// TAI KHOAN TIEN MAT KHACH HANG
      /// </summary>
      internal static BalanceAccount Get_324111(string customerID, UserLite user)
      {
         return Get("324111", "3241", customerID, user);
      }

      /// <summary>
      /// DOANH THU TU HD HTKD KHONG THOI HAN
      /// </summary>
      internal static BalanceAccount Get_511861(string customerID, UserLite user)
      {
         BalanceAccount r = Get("511861", "9999", customerID, user);
         if (r == null && Util.IsAutoGenerateAccount)
         {
            r = new BalanceAccount
            {
               BankGl = "511861",
               SectionGl = "9999",
               AccountID = customerID,
               AccountName = string.Format("DOANH THU TU HD HTKD KHONG THOI HAN TK{0}", customerID),
               DebitOrCredit = "L"
            };
            Create(r, user);
         }
         return r;
      }

      /// <summary>
      /// PHI LUU KY CHUNG KHOAN
      /// </summary>
      internal static BalanceAccount Get_511611(string customerID, UserLite user)
      {
          BalanceAccount r = Get("511611", "9999", customerID, user);

          if (r == null && Util.IsAutoGenerateAccount)
          {
              r = new BalanceAccount
              {
                  BankGl = "511611",
                  SectionGl = "9999",
                  AccountID = customerID,
                  AccountName = string.Format("PHI LUU KY CHUNG KHOAN TK{0}", customerID),
                  DebitOrCredit = "L"
              };
              Create(r, user);
          }
          return r;
      }

      /// <summary>
      /// DOANH THU TU HD HTKD CO THOI HAN 
      /// </summary>
      internal static BalanceAccount Get_511871(string customerID, UserLite user)
      {
         BalanceAccount r = Get("511871", "9999", customerID, user);
         if (r == null && Util.IsAutoGenerateAccount)
         {
            r = new BalanceAccount
            {
               BankGl = "511871",
               SectionGl = "9999",
               AccountID = customerID,
               AccountName = string.Format("DOANH THU TU HD HTKD CO THOI HAN TK{0}", customerID),
               DebitOrCredit = "L"
            };
            Create(r, user);
         }
         return r;
      }

      /// <summary>
      /// DOANH THU MOI GIOI CK NIEM YET CHO NGUOI DAU TU
      /// </summary>
      internal static BalanceAccount Get_511111(UserLite user)
      {
         return Get("511111", "9999", "5111110001", user);
      }

      public static DataSet ShowBalanceAccountTransaction(string bankGl, string sectionGl, string accountId, DateTime fromDate, DateTime toDate, bool isGetBeginDay, UserLite user)
      {
         StringBuilder sql = new StringBuilder();
         if (isGetBeginDay)
         {
            if (string.IsNullOrEmpty(accountId))
               sql.Append("select sum(isnull([CurrentBalance], 0)) as balance, '' as AccountName \n");
            else
               sql.Append("select isnull([CurrentBalance], 0) as balance, AccountName \n");
            sql.AppendFormat("from (select * from [dbo].[BalanceHist] union all select *, [dbo].[CurrentTransDate]('{0}') from [dbo].[Balance]) x1 \n", user.BranchCode);
            sql.AppendFormat("join (select [AccountId], max([TransactionDate]) as tdate from (select * from [dbo].[BalanceHist] union all select *, [dbo].[CurrentTransDate]('{0}') from [dbo].[Balance]) x \n", user.BranchCode);
            sql.AppendFormat("where [BranchCode] = '{0}' and [BankGl] = '{1}' and [SectionGl] = '{2}' and [x].[TransactionDate] <= {3} \n",
               user.BranchCode, LiteralUtil.GetLiteral(bankGl), LiteralUtil.GetLiteral(sectionGl), LiteralUtil.GetLiteral(fromDate));
            if (!string.IsNullOrEmpty(accountId))
               sql.AppendFormat("and accountid = '{0}' ", LiteralUtil.GetLiteral(accountId));
            sql.AppendFormat("group by [x].[AccountId]) x2 on [x1].[AccountId] = [x2].[AccountId] and x1.[TransactionDate] = [x2].[tdate] \n\n");
         }

         sql.AppendFormat("select [AccountId], {0} as buttoan, [TransactionTime] as thoigianduyet, [TransactionDate] as ngayGD, \n",
            string.IsNullOrEmpty(accountId) ? "[AccountId]" : "[TransactionNumber]");
         sql.Append("case [DebitOrCredit] when 'C' then [Amount] end as phatsinhco,case [DebitOrCredit] when 'D' then [Amount] end as phatsinhno, lower([Description]) as noidung  \n");
         sql.Append("from (select * from [dbo].[TransactionDay] union all select * from [dbo].[TransactionHist]) x \n");
         sql.AppendFormat("where x.[Approved] = 'Y' and [x].[BranchCode] = '{0}' and [x].[TransactionDate] between {1} and {2} \n",
            user.BranchCode, LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate));
         sql.AppendFormat("and [x].[BankGl] = '{0}' and [x].[SectionGl] = '{1}' ", LiteralUtil.GetLiteral(bankGl), LiteralUtil.GetLiteral(sectionGl));
         if (!string.IsNullOrEmpty(accountId))
            sql.AppendFormat("and [x].[AccountId] = '{0}' \n", LiteralUtil.GetLiteral(accountId));
         sql.Append("order by x.[TransactionTime] ");

         return DBUtil.ExecuteDataSet(sql.ToString(), 600000);
      }

      public static DataTable GetAdvanceBankTransactionReport(DateTime fromDate, DateTime toDate, string bankCode, string contractStatus, string stockType, int dateType, bool isSoldMortage, string branchCode, UserLite user)
      {
         StringBuilder sql = new StringBuilder();
         sql.AppendLine("declare @t3Day smalldatetime");
         sql.AppendFormat("set @t3Day = dbo.fc_GetTDate ('{0}', {1} ,0,3 )", user.BranchCode, LiteralUtil.GetLiteral(fromDate));

         sql.AppendLine("SELECT a.ContractID, a.CustomerName, ac.abbid as CustomerID, a.cardidentity,a.cardissuer,a.carddate,d.addressviet as customeraddress, d.dob,");
         sql.AppendLine("a.PaymentDate,a.NumberOfDate, a.AdvanceAmount,a.AdvanceFee, a.ManageFee, a.AdvanceAmount + a.AdvanceFee + a.ManageFee as TotalMoneyContract ");
         sql.AppendLine("from AdvanceContractAll a left join Luantx_charly_ABBcustomers ac on a.CustomerID = ac.CustomerID \n");
         sql.AppendLine("left join (select CustomerId, TransactionDate, sum((MatchedValue - (MatchedValue * FeeRate))) as MatchedValue  ");
         sql.AppendLine("from (select * from dbo.TradingResult union all select * from TradingResultHist) x ");
         sql.AppendFormat("where x.TransactionDate between @t3Day and {0} \n", LiteralUtil.GetLiteral(toDate));
         if (!string.IsNullOrEmpty(branchCode))
            sql.AppendFormat("and x.BranchCode = '{0}' \n", LiteralUtil.GetLiteral(branchCode));
         sql.AppendFormat("and OrderSide = 'S' And OrderSeq IS not NULL And NoPost <> '1' \n");
         sql.AppendFormat("group by x.CustomerId, x.TransactionDate ) b on a.CustomerId = b.CustomerId and	a.OrderDate =  b.TransactionDate ");
         sql.AppendLine("left join CustomerBank c on a.CustomerID = c.CustomerID ");
         sql.AppendLine("join Customers d on a.CustomerID = d.CustomerID ");
         sql.AppendFormat("where a.StockType like '{0}' \n", stockType == "S" ? "[SU]" : "D");
         if (!string.IsNullOrEmpty(branchCode))
            sql.AppendFormat("and a.BranchCode = '{0}' \n", LiteralUtil.GetLiteral(branchCode));
         if (!string.IsNullOrEmpty(contractStatus))
            sql.AppendFormat("and a.Status = '{0}' \n", LiteralUtil.GetLiteral(contractStatus));
         if (user.IsAgencyMember)
            sql.AppendFormat("and a.TradeCodeCreate = '{0}' \n", user.TradeCode);
         sql.AppendFormat("and a.SoldMortage = {0} \n", LiteralUtil.GetLiteral(isSoldMortage));
         if (dateType == 0)
            sql.AppendFormat("and DateContract between {0} and {1} \n", LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate));
         else if (dateType == 1)
            sql.AppendFormat("and PaymentDate between {0} and {1} \n", LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate));
         else
            sql.AppendFormat("and a.OrderDate between {0} and {1} \n", LiteralUtil.GetLiteral(fromDate), LiteralUtil.GetLiteral(toDate));

         sql.AppendFormat("and ( c.Activate is null or ( c.Activate = '1' and c.Status = 'O' )) and a.BankCode = '{0}' \n", LiteralUtil.GetLiteral(bankCode));
         sql.AppendLine("order by contractid");

         return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }
   }
}
