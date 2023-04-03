using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using VRMDomain.Common;

namespace VRMDomain.Domain
{
   public static class DeferredUtil
   {
      private class Order
      {
         public string OrderDate;
         public string BoardType;
         public string ConfirmNo;
         public string OrderNo;
         public decimal MatchedValue;
         public decimal Fee;
         public string CustomerName;
         public Guid Id;
         public DateTime TransactionDate;
      }

      public static DataTable GetDefferedTDayList(UserLite user, DateTime tradingDate, string customerId)
      {
         string sql = SqlHelper.BuildGetDefferedTDayList(user, tradingDate, customerId);
         return DBUtil.ExecuteDataSet(sql).Tables[0];
      }

      public static DataTable GetDefferedList(UserLite user, DateTime transDate, string customerID)
      {
         string sql = SqlHelper.BuildGetDefferedList(user, transDate, customerID);
         return DBUtil.ExecuteDataSet(sql).Tables[0];
      }

      public static DataTable GetCustomerDeferredTranList(string customerId, DateTime prvInterestDate, DateTime interestDate, UserLite user)
      {
         string sql = SqlHelper.BuildGetCustomerDeferredTranList(prvInterestDate, interestDate, customerId, user);
         return DBUtil.ExecuteDataSet(sql).Tables[0];
      }

      public static void DeferringTDay(string customerId, decimal payMatchedAmount, decimal payFeeAmount, decimal deferredMatchedAmount, decimal deferredFeeAmount, UserLite user)
      {
         string sql = "select id,orderdate,boardtype,confirmno,orderno,matchedvalue,matchedvalue*feerate as fee,customername,transactiondate from " +
                      "tradingresult JOIN customers ON dbo.TradingResult.CustomerId = dbo.Customers.CustomerId " +
                      string.Format("where orderside = 'B' and dbo.Customers.CustomerId = '{0}' and dayid = 0 ", customerId);

         List<Order> orders = new List<Order>();
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
         {
            Order o;
            while (r.Read())
            {
               o = new Order();
               o.TransactionDate = (DateTime)r["transactiondate"];
               o.OrderDate = r["orderdate"].ToString();
               o.BoardType = r["boardtype"].ToString();
               o.ConfirmNo = r["confirmno"].ToString();
               o.OrderNo = r["orderno"].ToString();

               o.MatchedValue = (decimal)r["matchedvalue"];
               o.Fee = (decimal)r["fee"];
               o.CustomerName = r["customername"].ToString();
               o.Id = (Guid)r["id"];

               orders.Add(o);
            }
            r.Close();
            r.Dispose();
         }

         decimal deferred, buyingDeferred;
         buyingDeferred = deferredFeeAmount + deferredMatchedAmount;

         // hach toan cho no
         foreach (Order o in orders)
         {
            if (buyingDeferred > 0)
            {
               if (deferredFeeAmount > 0)
                  deferred = buyingDeferred > o.MatchedValue + o.Fee ? o.MatchedValue + o.Fee : buyingDeferred;
               else
                  deferred = buyingDeferred > o.MatchedValue ? o.MatchedValue : buyingDeferred;

               SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_CLEARINGTRADING_SETDEFERRED);
               cmd.Parameters.AddWithValue("@orderdate", o.OrderDate);
               cmd.Parameters.AddWithValue("@Orderno", o.OrderNo);
               cmd.Parameters.AddWithValue("@Confirmno", o.ConfirmNo);
               cmd.Parameters.AddWithValue("@Boardtype", o.BoardType);
               cmd.Parameters.AddWithValue("@Beginamount", 0);
               cmd.Parameters.AddWithValue("@TargetAmount", deferred);
               cmd.ExecuteNonQuery();

               cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_DEFEREDTRANSACTIONDAY_INSERT);
               cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
               cmd.Parameters.AddWithValue("@CustomerBranchCode", user.BranchCode);
               cmd.Parameters.AddWithValue("@CustomerID", customerId);
               cmd.Parameters.AddWithValue("@CustomerName", o.CustomerName);
               cmd.Parameters.AddWithValue("@TransDate", o.TransactionDate);
               cmd.Parameters.AddWithValue("@TradingDate", o.TransactionDate);
               cmd.Parameters.AddWithValue("@TransCode", "D");
               cmd.Parameters.AddWithValue("@Amount", deferred);
               cmd.Parameters.AddWithValue("@Description", string.Format("CHAM TIEN NGAY {0} KHACH HANG {1} SO TIEN {2:n0}", o.OrderDate, customerId, deferred));
               cmd.Parameters.AddWithValue("@UserEnter", user.UserName);
               cmd.Parameters.AddWithValue("@DeferredType", "CLEARING");
               cmd.Parameters.AddWithValue("@TransactionNumber", DBNull.Value);
               cmd.Parameters.Add(new SqlParameter("@TransSeq", System.Data.SqlDbType.Int));
               cmd.Parameters["@TransSeq"].Direction = System.Data.ParameterDirection.Output;
               cmd.ExecuteNonQuery();

               int orderSeq = (int)cmd.Parameters["@TransSeq"].Value;
               cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_DEFEREDTRANSACTIONDAY_APPROVE);
               cmd.Parameters.AddWithValue("@TransSeq", orderSeq);
               cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
               cmd.Parameters.AddWithValue("@DeferredType", "CLEARING");
               cmd.Parameters.AddWithValue("@TradingDate", o.TransactionDate);
               cmd.ExecuteNonQuery();

               buyingDeferred -= deferred;
            }
            // hoan tat, set dayid
            DBUtil.ExecuteNonQuery(SqlHelper.UpdateNopostToTradingResult(customerId, o.Id));
         }

         // tao but thu tien
         BalanceAccount b1352 = BalanceAccount.Get_135211(customerId, user);
         BalanceAccount b3241 = BalanceAccount.Get_324111(customerId, user);
         BalanceAccount bCredit = user.BranchCode == "100" ? BalanceAccount.Get_321111(user) : BalanceAccount.Get_336111(user);
         if (payFeeAmount > 0)
         {
            // thu phi
            TransactionUtil.CreateTransaction(
               b3241,
               BalanceAccount.Get_511111(user),
               GlobalConstants.SBS_HTBUTRU_TIENMUACK,
               payFeeAmount,
               string.Format("THU PHI MUA CHUNG KHOAN NGAY {0} - SO TIEN {1:n0}", DateTime.Today.ToString("dd/MM/yyyy"), payFeeAmount),
               customerId,
               user);
         }

         // thu tien mua
         if (payMatchedAmount > 0)
         {
            TransactionUtil.CreateTransaction(
               b3241,
               bCredit,
               GlobalConstants.SBS_HTBUTRU_TIENMUACK,
               payMatchedAmount,
               string.Format("THU {0}TIEN MUA CHUNG KHOAN NGAY {1} - SO TIEN {2:n0}", deferredMatchedAmount > 0 ? "1 PHAN " : string.Empty, DateTime.Today.ToString("dd/MM/yyyy"), payMatchedAmount),
               customerId,
               user);
         }

         // no phi
         if (deferredFeeAmount > 0)
         {
            TransactionUtil.CreateTransaction(
               b1352,
               BalanceAccount.Get_511111(user),
               GlobalConstants.SBS_HTBUTRU_TIENMUACK,
               deferredFeeAmount,
               string.Format("NO PHI MUA CHUNG KHOAN NGAY {0} - SO TIEN {1:n0}", DateTime.Today.ToString("dd/MM/yyyy"), deferredFeeAmount),
               customerId,
               user);
         }

         // no tien mua
         if (deferredMatchedAmount > 0)
         {
            TransactionUtil.CreateTransaction(
               b1352,
               bCredit,
               GlobalConstants.SBS_HTBUTRU_TIENMUACK,
               deferredMatchedAmount,
               string.Format("NO {0} TIEN MUA CHUNG KHOAN NGAY {1} - SO TIEN {2:n0}", payMatchedAmount > 0 ? "1 PHAN" : string.Empty, DateTime.Today.ToString("dd/MM/yyyy"), deferredMatchedAmount),
               customerId,
               user);
         }
      }

      private static class SqlHelper
      {
         internal static string BuildGetDefferedTDayList(UserLite user, DateTime tradingDate, string customerId)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("select accountid, accountname,matched, fee, currentbalance, case when c.[ContractID] is null then 0 else 1 end as hd \n");
            sql.Append("from (select t.customerid, Sum(matchedvalue) as matched, sum(matchedvalue*feerate) as fee, sum(matchedvalue * (1+feerate)) as amount, \n");
            sql.Append("sum(deferredamount) as deferredamount from tradingresult t  \n");
            sql.Append("where orderside = 'B' and dayid = 0 and t.customerid <> '076P000001' \n");
            sql.Append("and clearingcode is not null ");
            sql.AppendFormat("and customerbranchcode = '{0}' group by t.customerid \n", user.BranchCode);
            sql.Append(") q join balance b on q.customerid = b.AccountId  \n");
            sql.Append("left join vrm_contract c on q.customerid = c.customerid and contracttype = 1 and c.[status] = 2  \n");
            sql.Append("where b.bankgl = '324111' and deferredamount = 0 ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat(" and q.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            sql.Append("order by c.[ContractID] desc, [q].[CustomerId]");

            return sql.ToString();
         }

         internal static string UpdateNopostToTradingResult(string customerId, Guid id)
         {
             return string.Format("update TradingResult set DayId = cd.Id from ClearingDay cd where TradingResult.ClearingCode = cd.ClearingCode and DayId = 0 and CustomerId = '{0}' and orderside = 'B' and TradingResult.id = '{1}' ", 
                 LiteralUtil.GetLiteral(customerId), id);
         }

         internal static string BuildGetCustomerDeferredTranList(DateTime prvInterestDate, DateTime interestDate, string customerId, UserLite user)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("select cust.customerid, cust.customernameviet, d.tradingdate as ngayno, sotienno, ngaytrano, sotientra , nohientai, i.date as ngaychotlai,b.currentbalance,  \n");
            sql.Append("case when d.tradingdate >= '2016-01-01' then d.tradingdate else dbo.TransDatePlus(d.tradingdate,2,0) end as ngayquahan ");
            if (prvInterestDate != DateTime.MinValue)
               sql.Append(",ip.date as ngaythu \n");
            else
               sql.Append(",i.date as ngaythu \n");

            sql.Append("from customers cust \n");

            sql.Append("left join ( \n");
            if (prvInterestDate == DateTime.MinValue)
            {
               sql.Append("   select customerid, date from vrm_interestdate where islatest = 1 and [status] != 'X') i on cust.customerid = i.customerid \n");
            }
            else
            {
               sql.AppendFormat("   select customerid, max(date) as date from dbo.vrm_InterestDate where date <= {0} and [status] != 'X' group by CustomerID \n", LiteralUtil.GetLiteral(prvInterestDate));
               sql.Append(") i on cust.customerid = i.customerid \n");
               sql.Append("left join ( \n");
               sql.Append("select customerid, date from dbo.vrm_InterestDate where [IsLatest]  = 1 and [status] != 'X') ip on cust.customerid = ip.customerid \n");
            }

            if (user.IsAgencyMember)
               sql.AppendFormat("inner join unittradecode u on cust.tradecode = u.tradecode and cust.tradecode = '{0}'  ", user.TradeCode);
            sql.Append("join ( \n");
            sql.Append(" select vay.CustomerID, DayDebit as sotienno, CurrentDebit as nohientai, vay.TradingDate, branchcode, [TransactionDate] as ngaytrano, [Amount] as sotientra  \n");
            sql.Append("	from (\n");
            sql.Append("		select TradingDate, CurrentDebit, CustomerID, BranchCode, DayDebit from dbo.DeferredBalance\n");
            sql.Append("		union all\n");
            sql.Append("		select TradingDate, CurrentDebit, CustomerID, BranchCode, DayDebit from dbo.DeferredBalanceHist\n");
            sql.Append("	) vay\n");
            sql.Append("	left join ( \n");
            sql.Append("		select [AccountId], [Description], [TransactionDate], [Amount] \n");
            sql.Append("		from ( \n");
            sql.Append("			select * from [dbo].[TransactionDay]  \n");
            sql.Append("			union all \n");
            sql.Append("			select * from [dbo].[TransactionHist] \n");
            sql.AppendFormat("		) x where [BranchCode] = '{0}' and [DebitOrCredit] = 'D' and [Approved] = 'Y' and [x].[TransactionCode] like 'DEFER%' \n", user.BranchCode);
            sql.Append("	) thanhtoan on vay.CustomerID = [AccountId] and [thanhtoan].[Description] like '%'+ convert(varchar(10), vay.tradingdate, 103) +'%' \n");
            sql.Append(") d on  cust.customerid = d.customerid  \n");
            sql.Append("JOIN dbo.Balance b ON b.AccountId = cust.CustomerId  \n");

            sql.AppendFormat("where  cust.branchcode = '{0}' AND b.BankGl = '324111' AND d.sotienno > 0 and cust.customerid not in ({1}) \n", user.BranchCode, Util.VIPAccount);
            sql.Append(" AND (d.nohientai > 0 or i.Date is null or d.ngaytrano >= i.Date) \n");
            if (prvInterestDate == DateTime.MinValue)
               sql.AppendFormat("and (i.date is null or i.date < {0})", LiteralUtil.GetLiteral(interestDate));

            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("AND cust.[CustomerID] like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            sql.AppendFormat(" and d.tradingdate <= {0} order by cust.customerid, d.tradingdate asc, d.ngaytrano asc", LiteralUtil.GetLiteral(interestDate));

            return sql.ToString();
         }

         internal static string BuildGetDefferedList(UserLite user, DateTime transDate, string customerID)
         {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT AccountId, AccountName, nohientai, CurrentBalance, 0.0 AS nosethu FROM dbo.Balance b \n");
            sql.Append("JOIN (SELECT CustomerID, SUM(CurrentDebit) AS nohientai FROM dbo.DeferredBalance \n");
            sql.Append("GROUP BY CustomerID ) d ON AccountId = d.CustomerID \n");
            sql.Append("JOIN dbo.vrm_Contract v ON  AccountId = v.CustomerId \n");
            sql.AppendFormat("WHERE BankGl = '324111' AND b.BranchCode = '{0}' AND nohientai > 0 AND CurrentBalance > 0 ", user.BranchCode);
            sql.Append("AND ContractType = 1 AND v.Status = '2' \n");
            if (!string.IsNullOrEmpty(customerID))
               sql.AppendFormat("and Accountid like '%{0}' ", LiteralUtil.GetLiteral(customerID));
            sql.Append("ORDER BY AccountId\n");

            return sql.ToString();
         }

         internal static string BuildFindDeferredTDayList(int takeCareId, string contractTypeString, string customerID, UserLite user)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("select c.[CustomerId], c.[CustomerName], b.[CurrentBalance], [tienmua], [tienno], v.[ContractID], v.[ContractType], u.[UserName] from [dbo].[Customers] c \n");
            sql.Append("join [dbo].[Balance] b on c.[CustomerId] = b.[AccountId] \n");
            sql.Append("join (select sum([MatchedValue] * (1 + [FeeRate])) as tienmua, sum([DeferredAmount]) as tienno, [CustomerId] from [dbo].[TradingResult] \n");
            sql.Append("where [OrderSide] = 'B' and dayid = 0 group by [CustomerId]) m on [b].[AccountId] = [m].[CustomerId] \n");
            sql.Append("left join [dbo].[vrm_Contract] v on [m].[CustomerId] = [v].[CustomerId] \n");
            sql.Append("left join [dbo].[Users] u on c.[UserTakeCared] = u.[UserId] \n");
            sql.AppendFormat("where b.[BankGl] = '324111' and c.[BranchCode] = '{0}' and [tienmua] > b.[CurrentBalance] \n",
               user.BranchCode);
            if (takeCareId != 0)
               sql.AppendFormat("and c.[UserTakeCared] = {0} ", takeCareId);
            if (!string.IsNullOrEmpty(customerID))
               sql.AppendFormat("and c.[CustomerId] like '%{0}' ", LiteralUtil.GetLiteral(customerID));
            if (contractTypeString == "OFFTERM")
               sql.Append("and v.[ContractID] is null ");
            else if (contractTypeString == "OUTTERM")
               sql.AppendFormat("and v.[ContractID] is not null and v.[ContractType] = {0} and isnull(v.status, 1) like '[123]' ", (byte)ContractType.KhongThoiHan);
            else if (contractTypeString == "INTERM")
               sql.AppendFormat("and v.[ContractID] is not null and v.[ContractType] = {0} ", (byte)ContractType.CoThoiHan);
            sql.Append("order by c.[CustomerId]");

            return sql.ToString();
         }

         internal static string BuildOutTermContractStatusReportSQL(string customerId, DateTime tranDate, DateTime exprireDate, bool isExactlyExp, int inDebtType, UserLite user)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("with #x (customerid, name, ngayno, tienno, ngaytra, tientra, nohientai, ngaychot, ngayhd, ngayhh, songayno) as ( \n");
            sql.Append("select cust.customerid, cust.[CustomerNameViet], d.tradingdate as ngayno, sotienno, ngaytrano, sotientra , nohientai, i.date as ngaychotlai, [DueDate], [ExpiredDate], \n");
            sql.AppendFormat("	datediff(dayofyear, case when i.date is not null and d.tradingdate < i.date then i.date else d.tradingdate end, isnull(ngaytrano, {0})) as songayno \n",
               LiteralUtil.GetLiteral(tranDate));
            sql.Append("from customers cust  \n");
            sql.Append("join [dbo].[vrm_Contract] on [cust].[CustomerId] = [dbo].[vrm_Contract].[CustomerId] \n");
            sql.Append("left join (  \n");
            sql.Append("   select customerid, date from vrm_interestdate where islatest = 1 and [status] != 'X') i on cust.customerid = i.customerid  \n");
            sql.Append("join (  \n");
            sql.Append(" select vay.CustomerID, daydebit as sotienno, CurrentDebit as nohientai, vay.TradingDate, branchcode, [TransactionDate] as ngaytrano, [Amount] as sotientra  \n");
            sql.Append("	from ( \n");
            sql.Append("		select TradingDate, CurrentDebit, CustomerID, BranchCode, DayDebit from dbo.DeferredBalance \n");
            sql.Append("		union all \n");
            sql.Append("		select TradingDate, CurrentDebit, CustomerID, BranchCode, DayDebit from dbo.DeferredBalanceHist \n");
            sql.Append("	) vay \n");
            sql.Append("	left join (  \n");
            sql.Append("		select [AccountId], [Description], [TransactionDate], [Amount] \n");
            sql.Append("		from ( \n");
            sql.Append("			select * from [dbo].[TransactionDay]  \n");
            sql.Append("			union all \n");
            sql.Append("			select * from [dbo].[TransactionHist] \n");
            sql.AppendFormat("		) x where [BranchCode] = '{0}' and [DebitOrCredit] = 'D' and [Approved] = 'Y' and [x].[TransactionCode] like 'DEFER%' \n", user.BranchCode);
            sql.Append("	) thanhtoan on vay.CustomerID = [AccountId] and [thanhtoan].[Description] like '%'+ convert(varchar(10), vay.tradingdate, 103) +'%' \n");
            sql.Append(") d on  cust.customerid = d.customerid   \n");
            sql.AppendFormat("where  cust.branchcode = '{0}' and [ContractType] = 1 and [dbo].[vrm_Contract].[Status] = 2 \n", user.BranchCode);
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat(" and cust.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            sql.AppendFormat(" and [ExpiredDate] {0} {1} \n", isExactlyExp ? "=" : "<=", LiteralUtil.GetLiteral(exprireDate));
            sql.Append("and d.sotienno > 0 and (i.Date is null or [d].[ngaytrano] is null or d.ngaytrano > i.Date)  \n");
            sql.AppendFormat("and (i.date is null or i.date <  {0}) and d.tradingdate <= {0} \n",
               LiteralUtil.GetLiteral(tranDate));
            if (inDebtType != 0)
               sql.AppendFormat("and {0} exists(select * from [dbo].[DeferredBalance] db where db.[CustomerId] = cust.[CustomerId]) \n", inDebtType == 1 ? string.Empty : "not");
            sql.Append("and ([d].[ngaytrano] is null or [d].[sotientra] > 0)) --end as \n");
            // end As
            sql.Append("select [customerid], [name], [ngayhd], [ngayhh], [ngayno], [tienno], [ngaychot], [ngaytra], [tientra],  \n");
            sql.AppendFormat("	isnull([tientra], [tienno]) as tientinhlai, [songayno], [songayno] * {0} * isnull([tientra], [tienno]) as tienlai, {0} as laisuat \n",
               LiteralUtil.GetNumericLiteral(Util.OutTermInterestRate));
            sql.Append("from #x  \n");
            sql.Append("union all \n");
            sql.Append("select [customerid], [name], [ngayhd], [ngayhh], [ngayno], [tienno], [ngaychot], null, null, [nohientai],  \n");
            sql.AppendFormat("datediff(dayofyear, case when ngayno < [ngaychot] then ngaychot else [ngayno] end, {0}), \n", LiteralUtil.GetLiteral(tranDate));
            sql.AppendFormat("datediff(dayofyear, case when ngayno < [ngaychot] then ngaychot else [ngayno] end, {0}) * {1} * [nohientai] as tienlai, \n",
               LiteralUtil.GetLiteral(tranDate), LiteralUtil.GetNumericLiteral(Util.OutTermInterestRate));
            sql.AppendFormat("{0} as laisuat from #x where [nohientai] > 0 and [ngaytra] is not null \n", LiteralUtil.GetNumericLiteral(Util.OutTermInterestRate));
            sql.Append("order by customerid, ngayno asc, [ngaytra] asc \n");

            return sql.ToString();
         }
      }

      public static void Withdraw(string customerId, decimal amount, UserLite user, DateTime transDate)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("SELECT CustomerName, CurrentDebit, TradingDate \n");
         sql.AppendFormat("FROM dbo.DeferredBalance WHERE CustomerID = '{0}' AND CurrentDebit > 0 Order By tradingdate", LiteralUtil.GetLiteral(customerId));
         DataTable defData = DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
         SqlCommand cmd;
         decimal payAmount;
         string customerName = (string)defData.Rows[0]["CustomerName"];
         string description = string.Empty;
         foreach (DataRow r in defData.Rows)
         {
            payAmount = (decimal)r["CurrentDebit"];
            description = (payAmount > amount) ? string.Format("THANH TOAN 1 PHAN TIEN THIEU NGAY {0} SO TIEN {1:n0}", ((DateTime)r["TradingDate"]).ToString("dd/MM/yyyy"), amount) :
                string.Format("THANH TOAN TIEN THIEU NGAY {0} SO TIEN {1:n0}", ((DateTime)r["TradingDate"]).ToString("dd/MM/yyyy"), payAmount);

            if (payAmount > amount)
               payAmount = amount;

            TransactionResult tran = TransactionUtil.CreateTransaction(
               BalanceAccount.Get_324111(customerId, user),
               BalanceAccount.Get_135211(customerId, user),
               GlobalConstants.SBS_CHAMTIENT,
               payAmount,
               description,
               customerId,
               user);

            cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_DEFEREDTRANSACTIONDAY_INSERT);
            cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
            cmd.Parameters.AddWithValue("@CustomerBranchCode", user.BranchCode);
            cmd.Parameters.AddWithValue("@CustomerID", customerId);
            cmd.Parameters.AddWithValue("@CustomerName", customerName);
            cmd.Parameters.AddWithValue("@TransDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@TradingDate", r["TradingDate"]);
            cmd.Parameters.AddWithValue("@TransCode", "C");
            cmd.Parameters.AddWithValue("@Amount", payAmount);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@UserEnter", user.UserName);
            cmd.Parameters.AddWithValue("@DeferredType", "CLEARING");
            cmd.Parameters.AddWithValue("@TransactionNumber", tran.TransactionNumber);
            cmd.Parameters.Add(new SqlParameter("@TransSeq", System.Data.SqlDbType.Int));
            cmd.Parameters["@TransSeq"].Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            int orderSeq = (int)cmd.Parameters["@TransSeq"].Value;
            cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_DEFEREDTRANSACTIONDAY_APPROVE);
            cmd.Parameters.AddWithValue("@TransSeq", orderSeq);
            cmd.Parameters.AddWithValue("@BranchCode", user.BranchCode);
            cmd.Parameters.AddWithValue("@DeferredType", "CLEARING");
            cmd.Parameters.AddWithValue("@TradingDate", r["TradingDate"]);
            cmd.ExecuteNonQuery();

            amount -= payAmount;
            if (amount <= 0)
               return;
         }
      }

      public static void RetreiveInterest(BalanceAccount account, string customerid, decimal amount, DateTime interestedDate, UserLite user)
      {
         TransactionUtil.CreateTransaction(
            BalanceAccount.Get_324111(customerid, user),
            account ?? BalanceAccount.Get_511861(customerid, user),
            GlobalConstants.SBS_TINHLAI,
            amount,
            string.Format("TK {0} RUT TIEN PHI CHOT NGAY {1:dd/MM/yyyy}", customerid, interestedDate),
            customerid,
            user);

         // update interest date
         StringBuilder sql = new StringBuilder();
         sql.AppendFormat("update vrm_InterestDate set islatest = 0 where customerid = '{0}' \n", LiteralUtil.GetLiteral(customerid));
         sql.AppendFormat("insert into vrm_InterestDate(date, customerid, interestamount, islatest, calculatedby) values ({0},'{1}',{2},1,'{3}')",
            LiteralUtil.GetLiteral(interestedDate), LiteralUtil.GetLiteral(customerid), LiteralUtil.GetNumericLiteral(amount), LiteralUtil.GetLiteral(user.UserName));
         DBUtil.ExecuteNonQuery(sql.ToString());
      }

      public static Result CreateDebitLimit(string customerId, DateTime transDate, decimal debitAmount, UserLite user)
      {
         Result r = new Result();
         if (debitAmount == 0M)
         {
            r.IsSuccess = true;
            return r;
         }

         string sql = string.Format("select LimitValue from dbo.CustomerDebitLimit WHERE CustomerId = '{0}' AND IsActive = 1 AND DebitLimitType = 'D'",
            LiteralUtil.GetLiteral(customerId));
         object val = DBUtil.ExecuteScalar(sql);
         if (val != null)
         {
            r.IsSuccess = false;
            r.Message = "Hạn mức đã được cấp";
            r.Value = val;
            return r;
         }

         sql = string.Format("select status from dbo.vrm_contract WHERE CustomerId = '{0}' AND contracttype = {1} and status = {2}",
            LiteralUtil.GetLiteral(customerId), (byte)ContractType.KhongThoiHan, (byte)ContractStatus.DaDuyet);
         val = DBUtil.ExecuteScalar(sql);
         if (val == null)
         {
            r.IsSuccess = false;
            r.Message = "Khách hàng chưa tạo hợp đồng hay hợp đồng chưa duyệt";
            r.Value = 0;
            return r;
         }

         // cap han muc
         using (SqlCommand cmd = DBUtil.CreateSqlCommmandToExecSP(GlobalConstants.SPSBS_CUSTOMERDEBITLIMIT_INSERT))
         {
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            cmd.Parameters.AddWithValue("@LimitValue", debitAmount);
            cmd.Parameters.AddWithValue("@IsActive", 1);
            cmd.Parameters.AddWithValue("@CurrentLimitValue", 0);
            cmd.Parameters.AddWithValue("@TransactionTime", transDate.TimeOfDay.ToString());
            cmd.Parameters.AddWithValue("@TransactionDate", transDate.Add(-transDate.TimeOfDay));
            cmd.Parameters.AddWithValue("@UserEnter", user.UserName);
            cmd.Parameters.AddWithValue("@FromDate", transDate.Add(-transDate.TimeOfDay));
            cmd.Parameters.AddWithValue("@ToDate", transDate.Add(-transDate.TimeOfDay));
            cmd.Parameters.AddWithValue("@DebitLimitType", "D");

            cmd.ExecuteNonQuery();
         }
         r.Value = debitAmount;
         r.IsSuccess = true;
         return r;
      }

      public static DataTable GetInterestTransactionList(string customerId, DateTime fromDate, DateTime toDate, UserLite user)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("select Date ,v.CustomerID,c.customernameviet as [name] ,InterestAmount ,IsLatest ,CalculatedBy, transactiondate from vrm_interestdate v join customers c on v.customerid = c.customerid ");
         sql.AppendFormat("where c.branchcode = '{0}' and v.[status] != 'X' ", user.BranchCode);
         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("and v.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
         if (fromDate != DateTime.MinValue && fromDate != DateTime.MaxValue)
            sql.AppendFormat("and date >= {0} ", LiteralUtil.GetLiteral(fromDate));
         if (toDate != DateTime.MinValue && toDate != DateTime.MaxValue)
            sql.AppendFormat("and date <= {0} ", LiteralUtil.GetLiteral(toDate));
         sql.Append("order by v.customerid, date desc");

         return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }

      public static DataTable GetUserTransCode(UserLite user)
      {
         SqlParameter branchCode = new SqlParameter("@BranchCode", SqlDbType.VarChar);
         branchCode.Value = user.BranchCode;
         return DBUtil.SPExecuteDataSet(GlobalConstants.SPSBS_BALANCEENTRYGETUSERTRANSCODE, branchCode).Tables[0];
      }

      public static DataTable FindDeferredTDayList(int takeCareId, string contractTypeString, string customerID, UserLite user)
      {
         return DBUtil.ExecuteDataSet(SqlHelper.BuildFindDeferredTDayList(takeCareId, contractTypeString, customerID, user)).Tables[0];
      }

      public static DataTable GetExpireContractStatusReport(ContractType contractType, DateTime tranDate, DateTime exprireDate, bool isExactlyExp, string customerId, int inDebtType, UserLite user)
      {
         string sql = string.Empty;
         if (contractType == ContractType.KhongThoiHan)
            sql = SqlHelper.BuildOutTermContractStatusReportSQL(customerId, tranDate, exprireDate, isExactlyExp, inDebtType, user);

         if (!string.IsNullOrEmpty(sql))
            return DBUtil.ExecuteDataSet(sql).Tables[0];
         return null;
      }
   }
}
