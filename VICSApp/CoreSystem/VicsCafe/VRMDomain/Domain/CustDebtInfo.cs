using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRMDomain.Domain
{
   public sealed class CustDebtInfo
   {
      public CustDebtInfo() { }

      public string CustomerID;
      public string CustomerName;
      public string NhanVienQuanLy;
      public string LoaiSanPhamNo;
      public decimal TongTaiSan;

      public decimal TienBanCKChoVe;
      public decimal TienBanDaUngTruoc;

      public decimal TiLe1;
      public decimal TiLe2;
      public decimal TiLeDuocNo;

      public decimal SoTienDuocRut; // ty le han muc con duoc su dung

      public decimal NoChamTienMuaTrongHan;
      public decimal NoChamTienMuaQuaHan;
      public decimal TongNo;


      //
      public decimal SoDuHienTai;
      public decimal GiaTriCKTrongTK;
      public decimal GiaTriCKChoTT;
      public decimal TienMuaChuaHachToan;
      public decimal TienNoTrongNgay;
      public decimal TongTienNoHienTai;
      public decimal SoTienLai;
      public decimal LaiSuat;

      public CustDebtInfo() { }

      internal static DataSet GetAllAssestAndDefered(string branchCode, string customerId, string refusedStocks, string introduceUserName, bool showOverDebt)
      {
         return GetAllAssestAndDefered(branchCode, customerId, refusedStocks, introduceUserName, showOverDebt, false, true);
      }

      /// <summary>
      /// Get all customer which is including debit
      /// </summary>
      /// <param name="branchCode"></param>
      /// <param name="customerId"></param>
      /// <param name="refusedStocks"></param>
      /// <param name="introduceUserName"></param>
      /// <param name="showOverDebt"></param>
      /// <param name="getDebtLimit"></param>
      /// <returns></returns>
      internal static DataSet GetAllAssestAndDefered(string branchCode, string customerId, string refusedStocks, string introduceUserName, bool onlyShowOverDebt, bool getDebtLimit)
      {
         return GetAllAssestAndDefered(branchCode, customerId, refusedStocks, introduceUserName, onlyShowOverDebt, getDebtLimit, true);
      }

      internal static DataSet GetAllAssestAndDefered(string branchCode, string customerId, string refusedStocks, string introduceUserName, bool onlyShowOverDebt, bool getDebtLimit, bool hasDebt)
      {
         StringBuilder sql = new StringBuilder();

         SqlHelper.BuildDeclareVariables(sql, branchCode);
         SqlHelper.AppendBuildDefaultSelect(sql);
         sql.AppendLine(",NotAccountedBuyAmount"); //13
         sql.AppendLine(",u.username ");            //14
         if (getDebtLimit)
            sql.AppendLine(",dl.limitvalue ");  // 15
         sql.AppendLine("FROM ");
         sql.AppendLine("customers c ");
         sql.AppendLine("left join [users] u on c.UserIntroduce = u.userid ");
         sql.AppendLine("	--- SO DU HIEN THOI ---");
         sql.AppendLine("left join");
         sql.AppendLine("	balance b on c.customerid = b.accountid and b.bankgl = '324111' ");

         SqlHelper.AppendBuildCurrentStockValue(sql, customerId, refusedStocks);
         SqlHelper.AppendBuildPendingSellValue(sql, customerId);
         SqlHelper.AppendBuildAdvancedAccountPaid(sql, customerId);
         SqlHelper.AppendBuildDeferedPerDay(sql, customerId);
         SqlHelper.AppendBuildNotAccountedBuyAmount(sql, customerId);

         if (getDebtLimit)
            sql.AppendLine("left join customerdebitlimit dl on c.customerid = dl.customerid ");

         // BUILD WHERE
         sql.AppendFormat("where c.branchcode = '{0}' \n", branchCode);
         if (hasDebt)
            sql.AppendLine("and exists(select * from deferredbalance d where d.customerid = c.customerid) ");
         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("and c.customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
         if (!string.IsNullOrEmpty(introduceUserName))
            sql.AppendFormat("and u.username like '%{0}%' \n", DBUtil.GetLiteral(introduceUserName));
         if (onlyShowOverDebt)
            sql.AppendLine("and overDueDefferedDebit > 0 \n");
         sql.AppendLine("order by c.customerid");

         return DBUtil.ExecuteDataSet(sql.ToString(), SBSConnection, SBSTransaction);
      }

      internal static DataSet GetLiquidLimitDebit(string branchCode, string customerId, string refusedStocks, string introduceUserName)
      {
         StringBuilder sql = new StringBuilder();

         SqlHelper.BuildDeclareVariables(sql, branchCode);
         SqlHelper.AppendBuildDefaultSelect(sql);
         sql.AppendLine(",NotAccountedBuyAmount"); //12
         sql.AppendLine(",u.username ");            //13
         sql.AppendLine("FROM ");
         sql.AppendLine("customers c ");
         sql.AppendLine("left join [users] u on c.UserIntroduce = u.userid ");
         sql.AppendLine("	--- SO DU HIEN THOI ---");
         sql.AppendLine("left join");
         sql.AppendLine("	balance b on c.customerid = b.accountid and b.bankgl = '324111' ");

         SqlHelper.AppendBuildCurrentStockValue(sql, customerId, refusedStocks);
         SqlHelper.AppendBuildPendingSellValue(sql, customerId);
         SqlHelper.AppendBuildAdvancedAccountPaid(sql, customerId);
         SqlHelper.AppendBuildDeferedPerDay(sql, customerId);
         SqlHelper.AppendBuildNotAccountedBuyAmount(sql, customerId);

         // inner join to filter customer
         sql.AppendFormat("inner join (select distinct customerid from tradingresult where branchcode='{0}' ", branchCode);
         sql.AppendLine("and orderside = 'B' and matchedvolume > 0 ) t on c.customerid = t.customerid ");

         // BUILD WHERE
         sql.AppendFormat("where c.branchcode = '{0}' \n", branchCode);
         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("and c.customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
         if (!string.IsNullOrEmpty(introduceUserName))
            sql.AppendFormat("and u.username like '%{0}%' \n", DBUtil.GetLiteral(introduceUserName));
         sql.AppendLine("order by c.customerid");

         return DBUtil.ExecuteDataSet(sql.ToString(), SBSConnection, SBSTransaction);
      }

      internal static DataSet GetDebtForPurchasingOrSelling(string branchCode, string customerId, string refusedStocks, string introduceUserName, bool isForSelling)
      {
         StringBuilder sql = new StringBuilder();

         SqlHelper.BuildDeclareVariables(sql, branchCode);
         SqlHelper.AppendBuildDefaultSelect(sql);
         sql.AppendLine(",DaydeferredDebit"); //13
         sql.AppendLine(",DaydeferredCredit"); //14
         sql.AppendLine(",u.username ");            //15
         sql.AppendLine(",NotAccountedBuyAmount"); // 16
         if (isForSelling) //17, 18, 19, 20
            sql.AppendLine(",PendingSellMoneyT,PendingSellMoneyTminus1,PendingSellMoneyTminus2,PendingSellMoneyTminus3"); //14
         sql.AppendLine("FROM ");
         sql.AppendLine("customers c ");
         sql.AppendLine("left join [users] u on c.UserIntroduce = u.userid ");
         sql.AppendLine("	--- SO DU HIEN THOI ---");
         sql.AppendLine("left join");
         sql.AppendLine("	balance b on c.customerid = b.accountid and b.bankgl = '324111' ");

         SqlHelper.AppendBuildCurrentStockValue(sql, customerId, refusedStocks);
         SqlHelper.AppendBuildPendingSellValue(sql, customerId);
         SqlHelper.AppendBuildAdvancedAccountPaid(sql, customerId);
         SqlHelper.AppendBuildDeferedPerDay(sql, customerId);
         SqlHelper.AppendBuildDayCreditAndDebit(sql, customerId);
         SqlHelper.AppendBuildNotAccountedBuyAmount(sql, customerId);
         if (isForSelling)
            SqlHelper.AppendBuildPendingSellMoney(sql, customerId);

         // BUILD WHERE
         sql.AppendFormat("where c.branchcode = '{0}' \n", branchCode);
         sql.AppendLine("and exists(select * from deferredbalance d where d.customerid = c.customerid) ");
         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("and c.customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
         if (!string.IsNullOrEmpty(introduceUserName))
            sql.AppendFormat("and u.username like '%{0}%' \n", DBUtil.GetLiteral(introduceUserName));
         sql.AppendLine("order by c.customerid");

         return DBUtil.ExecuteDataSet(sql.ToString(), SBSConnection, SBSTransaction);
      }

      public static Report.DataSet.BankTransDataTable GetBankTransactionList(DateTime tranDate, string bankgl, string sectiongl, string accountid)
      {
         Report.DataSet.BankTransDataTable result = new Asos.Report.DataSet.BankTransDataTable();

         StringBuilder sql = new StringBuilder();
         sql.Append("select transactionnumber,description, case when debitorcredit = 'C' then amount end as amountcredit, case when debitorcredit = 'D' then amount end as amountdebit ");
         sql.Append("from (select transactionnumber,description,debitorcredit,amount,transactiondate,id,bankgl,sectiongl,accountid from transactionday where approved <> 'X' ");
         sql.Append("union all ");
         sql.Append("select transactionnumber,description,debitorcredit,amount,transactiondate,id,bankgl,sectiongl,accountid from transactionhist where approved <> 'X' and transactiondate >= '09/15/2008' ) x ");
         sql.AppendFormat("where transactiondate = {0} and bankgl='{1}' and sectiongl = '{2}' and accountid= '{3}' ", DBUtil.GetLiteral(tranDate), DBUtil.GetLiteral(bankgl), DBUtil.GetLiteral(sectiongl), DBUtil.GetLiteral(accountid));
         sql.Append("order by transactiondate,id ");

         SqlDataReader r = DBUtil.ExecuteDataReader(sql.ToString(), SBSConnection, SBSTransaction);
         while (r.Read())
         {
            DataRow row = result.Rows.Add();
            row[result.TranCodeColumn.ColumnName] = r.GetString(0);
            row[result.DescriptionColumn.ColumnName] = r.GetString(1);
            row[result.PayAmountColumn.ColumnName] = r.IsDBNull(2) ? 0M : r.GetDecimal(2);
            row[result.ReceivedAmountColumn.ColumnName] = r.IsDBNull(3) ? 0M : r.GetDecimal(3);
         }
         r.Close();

         return result;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="branchCode"></param>
      /// <param name="fromDate"></param>
      /// <param name="toDate"></param>
      /// <param name="status"></param>
      /// <param name="stockType"></param>
      /// <param name="bankCode"></param>
      /// <param name="soldMortage"></param>
      /// <param name="tradeCodeCreated"></param>
      /// <param name="dateType">0: loc theo ngay hop dong, 1 loc theo ngay thanh toan, 2 loc theo ngay ban chung khoan</param>
      /// <returns></returns>
      public static Report.DataSet.AdvanceContractDataTable GetAdvanceContractList(string branchCode, DateTime fromDate, DateTime toDate, string status, string stockType, string bankCode, int soldMortage, string tradeCodeCreated, int dateType)
      {
         Report.DataSet.AdvanceContractDataTable result = new Asos.Report.DataSet.AdvanceContractDataTable();

         string sql = SqlHelper.BuildGetAdvanceContractListSql(branchCode, fromDate, toDate, status, stockType, bankCode, soldMortage, tradeCodeCreated, dateType);
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql.ToString(), SBSConnection, SBSTransaction))
         {
            while (r.Read())
            {
               DataRow row = result.Rows.Add();
               row[result.ContractIdColumn.ColumnName] = r.GetString(0);
               row[result.CustNameColumn.ColumnName] = r.GetString(1);
               row[result.CustIdColumn.ColumnName] = r.GetString(2);
               row[result.CustIdentityColumn.ColumnName] = r.IsDBNull(3) ? string.Empty : r.GetString(3);
               row[result.CustIDPlaceColumn.ColumnName] = r.IsDBNull(4) ? string.Empty : r.GetString(4);
               row[result.CustIDIssuedColumn.ColumnName] = r.IsDBNull(5) ? string.Empty : Util.FormatDate(r.GetDateTime(5));
               row[result.CustAddressColumn.ColumnName] = r.IsDBNull(6) ? string.Empty : r.GetString(6);
               row[result.CustBirthdayColumn.ColumnName] = r.IsDBNull(7) ? string.Empty : Util.FormatDate(r.GetDateTime(7));
               row[result.ContractDateColumn.ColumnName] = Util.FormatDate(r.GetDateTime(8));
               row[result.PayDateColumn.ColumnName] = Util.FormatDate(r.GetDateTime(9));
               row[result.NumberOfDayColumn.ColumnName] = r.GetInt32(10);
               row[result.AdvFeeColumn.ColumnName] = r.IsDBNull(11) ? 0M : r.GetDecimal(11);
               row[result.AmountColumn.ColumnName] = r.GetDecimal(12);
               row[result.FeeColumn.ColumnName] = r.GetDecimal(13);
            }
            r.Close();
         }

         return result;
      }

      private static class SqlHelper
      {
         internal static string BuildQueryForDeferedList(string board, string customerId)
         {
            StringBuilder sql = new StringBuilder();

            sql.Append("select accountid, accountname, matched, fee, currentbalance, deferredamount from (select customerid, Sum(matchedvalue) as matched, sum(matchedvalue*feerate) as fee, sum(deferredAmount) as deferredamount from tradingresult ");
            sql.AppendFormat("where orderside = 'B' and dayid <> 1 and customerid <> '076P000001' ");
            sql.AppendFormat("and customerbranchcode = '{0}' ", Util.LoggedUser.BranchCode);
            if (!string.IsNullOrEmpty(board))
               sql.AppendFormat("and boardtype = '{0}' ", board);
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("and customerid like '%{0}' ", DBUtil.GetLiteral(customerId));
            sql.Append("group by customerid) as q join balance b on q.customerid = b.AccountId ");
            sql.Append("where b.bankgl = '324111'");

            return sql.ToString();
         }

         internal static void AppendBuildNotAccountedBuyAmount(StringBuilder sql, string customerId)
         {
            sql.AppendLine("	-- SO TIEN MUA CHUNG KHOAN CHUA DUOC HACH TOAN ---");
            sql.AppendLine("left join");
            sql.AppendLine("	(select customerid, sum(matchedvalue + feerate*matchedvalue) as NotAccountedBuyAmount");
            sql.AppendLine("	from tradingresult where orderside = 'B' and dayid = 0");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("		and (customerid like '%{0}') \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	group by customerid");
            sql.AppendLine(") nab on c.customerid = nab.customerid");
         }

         internal static void AppendBuildDayDeferedCredit(StringBuilder sql, string customerId)
         {
            sql.AppendLine("	--- SO TIEN TRA NO TRONG NGAY ---");
            sql.AppendLine("left join");
            sql.AppendLine("	(select customerid, sum(isnull(x,0) - isnull(y, 0)) as DayDeferredCredit");
            sql.AppendLine("	from (");
            sql.AppendLine("		select customerid, amount as x, 0 as y from DeferredTransactionDay ");
            sql.AppendFormat("		where transcode = 'C' and transactionnumber is not null and customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("		union all");
            sql.AppendLine("		select customerid, 0 as x, amount as y from DeferredTransactionDay ");
            sql.AppendLine("		where transcode = 'R' ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("		and (customerid like '%{0}') \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	) tmp");
            sql.AppendLine("	group by customerid");
            sql.AppendLine(") ddc on c.customerid = ddc.customerid");
         }

         internal static void AppendBuildPendingSellMoney(StringBuilder sql, string customerId)
         {
            sql.AppendLine("	--- SO TIEN BAN NGAY T, T-1, T-2, T-3 (CO TRU UNG TRUOC) ---");
            sql.AppendLine("left join");
            sql.AppendLine("	(select v.customerid, sum(x1) as PendingSellMoneyT, sum(x2) as PendingSellMoneyTminus1, sum(x3) as PendingSellMoneyTminus2, sum(x4) as PendingSellMoneyTminus3 ");
            sql.AppendLine("	from (select g.customerid, ");
            sql.AppendLine("		x1	= sum(case when orderdate = @currDate then isnull(s,0) end),");
            sql.AppendLine("		x2 = sum(case when orderdate = @preT1 then isnull(s,0) end),");
            sql.AppendLine("		x3 = sum(case when orderdate = @preT2 then isnull(s,0) end),");
            sql.AppendLine("		x4 = sum(case when orderdate = @preT3 then isnull(s,0) end)");
            sql.AppendLine("    from ");
            sql.AppendLine("	(select customerid, transactiondate as orderdate, matchedvalue - matchedvalue*feerate as s");
            sql.AppendLine("		from tradingresulthist where orderside = 'S' and dayid = 1 ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("		and (customerid like '%{0}') \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	 union all");
            sql.AppendLine("	 select customerid, transactiondate as orderdate, matchedvalue - matchedvalue*feerate as s ");
            sql.AppendLine("		from tradingresult where orderside = 'S' ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("		and (customerid like '%{0}') \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	 union all");
            sql.AppendLine("	 select customerid, orderdate, 0 - advanceamount - AdvanceFee - ManageFee as s from AdvanceContractAll ");
            sql.AppendLine("		where  Status = 'T' ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("		and (customerid like '%{0}') \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	 union all");
            sql.AppendLine("	 select customerid, orderdate, 0 - advanceamount - AdvanceFee - ManageFee as s from BuyCashContract ");
            sql.AppendLine("		where Status = 'T' ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("		and (customerid like '%{0}') \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	) g group by g.customerid, g.orderdate) v group by v.customerid ");
            sql.AppendLine(") tmin on c.customerid = tmin.customerid");
         }

         internal static void AppendBuildDeferedPerDay(StringBuilder sql, string customerId)
         {
            sql.AppendLine("	--- SO TIEN DANG NO T2, QUA HAN T2, CHUA QUA HAN T2 -- SO TIEN KH PHAI THANH TOAN T, T-1, T-2 ---");
            sql.AppendLine("left join");
            sql.AppendLine("	(select customerid, ");
            sql.AppendLine("		   overDueDefferedDebit = sum(case when @accounted = 1 and tradingdate <= @preT2 then currentdebit");
            sql.AppendLine("										   when @accounted = 0 and tradingdate <= @preT3 then currentdebit end),");
            sql.AppendLine("		   DueDefferedDebit     = sum(case when @accounted = 1 and tradingdate > @preT2 then currentdebit ");
            sql.AppendLine("										   when @accounted = 0 and tradingdate > @preT3 then currentdebit end),");
            sql.AppendLine("		   todayDefferedDebit		= sum(case when tradingdate = @currDate then currentdebit end),");
            sql.AppendLine("		   YesterdayDefferedDebit	= sum(case when tradingdate = @preT1 then currentdebit end),");
            sql.AppendLine("		   MustPayNowDefferedDebit	= sum(case when tradingdate = @preT2 then currentdebit end),");
            sql.AppendLine("		   LongestDefferedDateIssued	= min(tradingdate)");
            sql.AppendLine("	from DeferredBalance ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("	where customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	group by customerid");
            sql.AppendLine(") d on c.customerid = d.customerid");
         }

         internal static void AppendBuildAdvancedAccountPaid(StringBuilder sql, string customerId)
         {
            sql.AppendLine("	--- TIEN UNG TRUOC CHUA THANH TOAN ---");
            sql.AppendLine("left join");
            sql.AppendLine("	(select curA.customerid, sum(isnull(curA.advanceamount, 0) + isnull(curA.advancefee, 0)) as advancedpaid");
            sql.AppendLine("	from (select customerid, advanceamount, advancefee,datecontract,status from advancecontractall ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("			where customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("		  union all");
            sql.AppendLine("		  select customerid, advanceamount, advancefee,datecontract,status from BuyCashContract ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("			where customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	) curA where curA.datecontract between @preT3 ");
            sql.AppendLine("		  and @currDate and status = 'T' ");
            sql.AppendLine("	group by curA.customerid");
            sql.AppendLine(") ung on c.customerid = ung.customerid");
         }

         internal static void AppendBuildPendingSellValue(StringBuilder sql, string customerId)
         {
            sql.AppendLine("	--- TIEN BAN CHO VE ---");
            sql.AppendLine("left join");
            sql.AppendLine("	(select customerid, sum(isnull(stockvalue,0)) as pendingSellValue");
            sql.AppendLine("	from");
            sql.AppendLine("		(select customerid, matchedvolume*matchedprice*(1-feerate)*1000 as stockvalue");
            sql.AppendLine("		from tradingresulthist ");
            sql.AppendLine("		where transactiondate between @preT3 and @currDate ");
            sql.AppendLine("			  and orderside = 'S' and dayid = 1 ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("						and customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("		union all");
            sql.AppendLine("		select customerid, matchedvolume*matchedprice*(1-feerate)*1000 as stockvalue");
            sql.AppendLine("		from tradingresult ");
            sql.AppendLine("		where orderside = 'S' ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("						and customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	) curC ");
            sql.AppendLine("	group by curC.customerid								");
            sql.AppendLine(") cash on c.customerid = cash.customerid");
         }

         internal static void AppendBuildCurrentStockValue(StringBuilder sql, string customerId, string exceptStocks)
         {
            sql.AppendLine("	--- SO DU CHUNG KHOAN ---");
            sql.AppendLine("left join ");
            sql.AppendLine("	(select curS.accountid,");
            sql.AppendLine("	sum(isnull(curS.currentquantity, 0) * s.price * 1000 * isnull(ts.valuepercent / 100, 1)) as currentstockvalue,");
            sql.AppendLine("	sum(isnull(curS.pendingquantity, 0) * s.price * 1000 * isnull(ts.valuepercent / 100, 1)) as pendingstockvalue");
            sql.AppendLine("	from");
            sql.AppendLine("		(select stockcode, case boardtype when 'S' then averageprice else case closeprice when 0 then basicprice else closeprice end end as price ");
            sql.AppendLine("         from stockprice ");
            if (!string.IsNullOrEmpty(exceptStocks))
               sql.AppendFormat("		 where stockcode not in ({0}) \n", exceptStocks);
            sql.AppendLine("		) s ");

            // left join with tiny stock to recalculate the exactly value of each stock
            sql.AppendFormat("left join [{0}].dbo.tinystock ts on s.stockcode = ts.stockcode \n", Util.ASOSContext.Connection.Database);

            sql.AppendLine("			-- tinh so co phieu hien tai");
            sql.AppendLine("inner join (select srt.accountid, srt.stockcode, sum(srt.quantity - isnull(tds.matched, 0)) as currentquantity , 0 as pendingquantity");
            sql.AppendLine("				 from securities srt ");
            sql.AppendLine("				 left join ");
            sql.AppendLine("					(select customerid, stockcode, sum(matchedvolume) as matched ");
            sql.AppendLine("					 from tradingresult where orderside = 'S' ");
            sql.AppendLine("					 group by customerid, stockcode) tds ");
            sql.AppendLine("                    on srt.accountid = tds.customerid and srt.stockcode = tds.stockcode ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("				 and srt.accountid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("				 where srt.bankGL = dbo.SecuritiesAccount('N', 'D', 1)	-- CK giao dich KH trong nuoc");
            sql.AppendLine("					   and srt.SectionGL = dbo.SecuritiesAccount('N', 'D', 0) ");
            sql.AppendLine("				 group by srt.accountid, srt.stockcode");
            sql.AppendLine("			union all");
            sql.AppendLine("			-- tinh so co phieu dang ve");
            sql.AppendLine("			select x.customerid, x.stockcode, 0 as currentquantity, sum(x.quantity) as pendingquantity");
            sql.AppendLine("				 from");
            sql.AppendLine("					(select customerid, stockcode, matchedvolume as quantity ");
            sql.AppendLine("					 from tradingresulthist where transactiondate between @preT3 and @currDate ");
            sql.AppendLine("				 		and orderside = 'B' and dayid = 1 ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("						and customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            if (!string.IsNullOrEmpty(exceptStocks))
               sql.AppendFormat("                  and stockcode not in ({0}) \n", exceptStocks);
            sql.AppendLine("					 union all");
            sql.AppendLine("					 select customerid, stockcode, matchedvolume as quantity ");
            sql.AppendLine("					 from tradingresult where orderside = 'B' ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("						and customerid like '%{0}' \n", DBUtil.GetLiteral(customerId));
            if (!string.IsNullOrEmpty(exceptStocks))
               sql.AppendFormat("                  and stockcode not in ({0}) \n", exceptStocks);
            sql.AppendLine("					 union all");
            sql.AppendLine("					 select accountid as customerid, stockcode, quantity ");
            sql.AppendLine("					 from contigenstockday where bankgl = '012121' AND Debitorcredit = 'C' AND Approved = 'N' ");
            sql.AppendFormat("						and (accountid like '%{0}')  \n", DBUtil.GetLiteral(customerId));
            if (!string.IsNullOrEmpty(exceptStocks))
               sql.AppendFormat(" and stockcode not in ({0})", exceptStocks);
            sql.AppendLine("				) x group by x.customerid, x.stockcode");
            sql.AppendLine("			) curS ");
            sql.AppendLine("			on s.stockcode = curS.stockcode");
            sql.AppendLine("		inner join ");
            sql.AppendLine("			glstockcode g ");
            sql.AppendLine("			on g.stockcode = s.stockcode");
            sql.AppendLine("	group by curS.accountid");
            sql.AppendLine(") stock on c.customerid = stock.accountid");
         }

         internal static void AppendBuildDayCreditAndDebit(StringBuilder sql, string customerId)
         {
            sql.AppendLine("	-- PHAT SINH NO TRONG NGAY ---");
            sql.AppendLine("left join");
            sql.AppendLine("   (select x.customerid, sum(isnull(x.x1, 0)) as DayDeferredCredit,sum(isnull(x.x2, 0)) as DayDeferredDebit ");
            sql.AppendLine(" from (select customerid, case when transcode = 'C' then amount when transcode = 'R' then 0 - amount end as x1,case when transcode = 'D' then amount end as x2");
            sql.AppendLine("from DeferredTransactionDay ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("where (customerid like '%{0}') \n", DBUtil.GetLiteral(customerId));
            sql.AppendLine("	) x group by x.customerid");
            sql.AppendLine(") ps on c.customerid = ps.customerid ");
         }

         /// <summary>
         /// @currDate smalldatetime, @preT1 smalldatetime, @preT2 smalldatetime, @preT3 smalldatetime, @accounted bit
         /// </summary>
         /// <param name="sql"></param>
         /// <param name="branchCode"></param>
         internal static void BuildDeclareVariables(StringBuilder sql, string branchCode)
         {
            BuildDeclareVariables(sql, branchCode, DateTime.MaxValue);
         }

         /// <summary>
         /// @currDate smalldatetime, @preT1 smalldatetime, @preT2 smalldatetime, @preT3 smalldatetime, @accounted bit
         /// </summary>
         /// <param name="sql"></param>
         /// <param name="branchCode"></param>
         /// <param name="curTransDate"></param>
         internal static void BuildDeclareVariables(StringBuilder sql, string branchCode, DateTime curTransDate)
         {
            sql.AppendLine("declare @currDate smalldatetime, @preT1 smalldatetime, @preT2 smalldatetime, @preT3 smalldatetime");
            sql.AppendLine("declare @accounted bit");
            sql.AppendFormat("select @accounted = case when dbo.{0}('{1}') = 'E' then 1 else 0 end \n", ConfigurationSettings.AppSettings["SP_SBS_GETTRANSACTIONDAYSTATUS"], branchCode);
            if (curTransDate == DateTime.MaxValue || curTransDate == DateTime.MinValue)
               sql.AppendFormat("set @currDate = dbo.currenttransdate('{0}') \n", branchCode);
            else
               sql.AppendFormat("set @currDate = {0} \n", DBUtil.GetLiteral(curTransDate));
            sql.AppendLine("set @preT1 = dbo.TransDateMinus(@currDate,1,0)");
            sql.AppendLine("set @preT2 = dbo.TransDateMinus(@currDate,2,0)");
            sql.AppendLine("set @preT3 = dbo.TransDateMinus(@currDate,3,0)");
         }

         /// <summary>
         /// 13 default field in select involved here
         /// </summary>
         /// <param name="sql"></param>
         internal static void AppendBuildDefaultSelect(StringBuilder sql)
         {
            sql.AppendLine("SELECT ");
            sql.AppendLine("	c.customerid");               //0
            sql.AppendLine("	,c.customernameviet");        //1
            sql.AppendLine("	,b.currentbalance");          //2
            sql.AppendLine("	,pendingSellValue");          //3
            sql.AppendLine("	,advancedpaid");              //4
            sql.AppendLine("	,currentstockvalue");         //5
            sql.AppendLine("	,pendingstockvalue");         //6
            sql.AppendLine("	,overDueDefferedDebit");      //7
            sql.AppendLine("	,DueDefferedDebit");          //8
            sql.AppendLine("	,todayDefferedDebit");        //9
            sql.AppendLine("	,YesterdayDefferedDebit");    //10
            sql.AppendLine("	,MustPayNowDefferedDebit");   //11
            sql.AppendLine("	,LongestDefferedDateIssued"); //12
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="branchCode"></param>
         /// <param name="fromDate"></param>
         /// <param name="toDate"></param>
         /// <param name="status"></param>
         /// <param name="stockType"></param>
         /// <param name="bankCode"></param>
         /// <param name="soldMortage"></param>
         /// <param name="tradeCodeCreated"></param>
         /// <param name="dateType">0: loc theo ngay hop dong, 1 loc theo ngay thanh toan, 2 loc theo ngay ban chung khoan</param>
         /// <returns></returns>
         internal static string BuildGetAdvanceContractListSql(string branchCode, DateTime fromDate, DateTime toDate, string status, string stockType, string bankCode, int soldMortage, string tradeCodeCreated, int dateType)
         {
            StringBuilder sql = new StringBuilder();

            if (stockType == "S")
               stockType.PadRight(1, 'U');
            sql.Append("declare @fromdate smalldatetime, @todate smalldatetime \n");
            sql.AppendFormat("set @fromdate = dbo.fc_GetTDate ('{0}', {1} ,0,3) \n", branchCode, DBUtil.GetLiteral(fromDate));
            sql.AppendFormat("set @todate = dbo.fc_GetTDate ('{0}', {1} ,1,3) \n", branchCode, DBUtil.GetLiteral(toDate));

            sql.Append("SELECT  ");
            sql.Append("contractid, a.CustomerName, a.CustomerID as CustomerID, ");
            sql.Append("a.cardidentity,a.cardissuer,a.carddate,d.addressviet as customeraddress,d.dob,a.DateContract, ");
            sql.Append("a.PaymentDate, a.NumberOfDate,sadv.sadvFee As PreviousAdvAmount,a.AdvanceAmount,a.AdvanceFee ");
            sql.Append("from ");
            sql.Append("AdvanceContractAll a ");
            sql.Append("left join CustomerBank c on a.CustomerID = c.CustomerID ");
            sql.Append("left join Customers d on a.CustomerID = d.CustomerID ");
            if (bankCode == "ABB") // find something better than this
               sql.Append("left join Luantx_charly_Abbcustomers s on a.customerid = s.customerid ");
            sql.Append("left join (SELECT CustomerID, StockType, DateContract, Sum(AdvanceFee) as sadvFee FROM AdvanceContractAll WHERE  Status in ('O','A','T') group by CustomerID, StockType, DateContract ");
            sql.Append(") sadv on a.CustomerID = sadv.CustomerID And sadv.StockType  = a.StockType And sadv.DateContract < a.DateContract ");
            sql.Append("left join (select customerid, convert(datetime,orderDate,103) as orderdate,sum(MatchedValue - (MatchedValue * FeeRate)) as MatchedValue ");
            sql.Append("from (select customerid, orderdate, matchedvalue, feerate, orderside, orderseq, nopost from TradingResult ");
            sql.Append("union all ");
            sql.Append("select customerid, orderdate, matchedvalue, feerate, orderside, orderseq, nopost from TradingResultHist) x ");
            sql.Append("where convert(datetime,orderDate,103) between @fromdate and @todate And OrderSide = 'S' And OrderSeq IS not NULL And NoPost <> '1' ");
            sql.Append("group by customerid, orderdate ");
            sql.Append(") b on 	a.CustomerId = b.CustomerId and	a.OrderDate =  b.OrderDate ");
            sql.Append("where ");
            sql.AppendFormat("a.BranchCode = '{0}' ", branchCode);
            if (!string.IsNullOrEmpty(status))
               sql.AppendFormat("And a.Status = '{0}' ", status);
            sql.AppendFormat("And a.Status <> 'X' And a.StockType like '[{0}]' ", stockType);
            if (!string.IsNullOrEmpty(bankCode))
               sql.AppendFormat("and a.BankCode = '{0}' ", bankCode);
            if (soldMortage > 0)
               sql.AppendFormat("and a.SoldMortage = {0} ", soldMortage);
            if (!string.IsNullOrEmpty(tradeCodeCreated))
               sql.AppendFormat("and a.TradeCodeCreate = '{0}' ", DBUtil.GetLiteral(tradeCodeCreated));
            if (dateType == 0)
               sql.AppendFormat("And Convert(smallDateTime,a.DateContract,103) Between {0} And {1} ", DBUtil.GetLiteral(fromDate), DBUtil.GetLiteral(toDate));
            else if (dateType == 1)
               sql.AppendFormat("And Convert(smallDateTime,a.PaymentDate,103) Between {0} And {1} ", DBUtil.GetLiteral(fromDate), DBUtil.GetLiteral(toDate));
            else
               sql.AppendFormat("And Convert(smallDateTime,a.OrderDate,103) Between {0} And {1} ", DBUtil.GetLiteral(fromDate), DBUtil.GetLiteral(toDate));

            sql.Append("and (  c.Activate is null  or ( c.Activate = '1' and c.Status = 'O' )) ");
            sql.Append("order by right(a.ContractID,5) ");

            return sql.ToString();
         }
      }

      internal static SqlDataReader GetContigenEntryList(string stockCode)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("select a.Accountid,a.Accountname,case a.Debitorcredit when 'D' then a.quantity end as Debitamount,case a.Debitorcredit when 'C' then a.quantity end as Creditamount ");
         sql.Append("from ContigenStockDay a, Contigenday b where a.transactionnumber = b.transactionnumber and a.approved = 'N' and LEFT(b.TransactionCode, 5) like 'APTT3%' ");
         if (!string.IsNullOrEmpty(stockCode))
            sql.AppendFormat(" and a.stockcode = '{0}' ", DBUtil.GetLiteral(stockCode));
         sql.Append("order by a.accountid ");

         return DBUtil.ExecuteDataReader(sql.ToString(), SBSConnection, SBSTransaction);
      }

      internal static SqlDataReader GetTransactionResultList(DateTime tranDate, string boardType, string stockCode, string customerId)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("select stockcode,customerid,matchedprice,matchedvolume,orderside from tradingresulthist ");
         sql.AppendFormat("where transactiondate = {0} ", DBUtil.GetLiteral(tranDate));
         if (!string.IsNullOrEmpty(boardType))
            sql.AppendFormat(" and boardtype = '{0}' ", DBUtil.GetLiteral(boardType));
         if (!string.IsNullOrEmpty(stockCode))
            sql.AppendFormat(" and stockCode = '{0}' ", DBUtil.GetLiteral(stockCode));
         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat(" and customerId like '%{0}' ", DBUtil.GetLiteral(customerId));
         sql.Append("order by customerid ");

         return DBUtil.ExecuteDataReader(sql.ToString(), SBSConnection, SBSTransaction);
      }

      /// <summary>
      /// limitvalue, currentlimitvalue,matechebuyingdordervalue,totalbuyingordervalue,LastMonthTradingValue
      /// </summary>
      /// <param name="customerId"></param>
      /// <returns></returns>
      internal static SqlDataReader GetDebitLimitInfo(string customerId)
      {
         StringBuilder sql = new StringBuilder();

         sql.Append("select cb.limitvalue, cb.currentlimitvalue, t.matechebuyingdordervalue,x.totalbuyingordervalue,th.LastMonthTradingValue ");
         sql.AppendFormat("from customers c left join customerdebitlimit cb on c.customerid = cb.customerid and cb.customerid = '{0}' ", customerId);
         sql.AppendFormat("left join (select '{0}' as customerid, sum(matchedvalue) as matechebuyingdordervalue from tradingresult ", customerId);
         sql.AppendFormat("where orderside = 'B' and customerid = '{0}') t on c.customerid = t.customerid ", customerId);
         sql.AppendFormat("left join (select '{0}' as customerid, sum((s.ordervolume - isnull(c.cancelledvolume, 0)) * s.orderprice * 1000) as totalbuyingordervalue ", customerId);
         sql.AppendFormat("from stockorder s left join tradingorder c on c.orderseq = s.orderseq ", customerId);
         sql.AppendFormat("where s.orderside = 'B' and s.customerid = '{0}' and s.orderstatus in ('R','P','S','E') ", customerId);
         sql.Append(") x on c.customerid = x.customerid ");
         sql.AppendFormat("left join (select '{0}' as customerid, sum(matchedvalue) as LastMonthTradingValue from tradingresulthist ", customerId);
         sql.AppendFormat("where customerid = '{0}' and year(transactiondate) = year(dateadd(month,-1,getdate())) ", customerId);
         sql.Append("and month(transactiondate)=month(dateadd(month,-1,getdate()))) th on c.customerid = th.customerid ");
         sql.AppendFormat("where c. customerid = '{0}' ", customerId);

         return DBUtil.ExecuteDataReader(sql.ToString(), SBSConnection, SBSTransaction);
      }

      internal static SqlDataReader GetCustomerStockEnquiry(string customerId)
      {
         SqlParameter accountId = new SqlParameter("@AccountId", SqlDbType.VarChar);
         accountId.Value = customerId;
         SqlParameter branchCode = new SqlParameter("@BranchCode", SqlDbType.VarChar);
         branchCode.Value = Util.LoggedUser.BranchCode;
         SqlParameter tradingDate = new SqlParameter("@TradingDate", SqlDbType.DateTime);
         tradingDate.Value = Util.CurrentTransactionDate;

         return DBUtil.SBExecuteDataReader(ConfigurationManager.AppSettings["SP_SBS_CUSTOMERSTOCKENQUIRY"], SBSConnection, SBSTransaction, accountId, branchCode, tradingDate);
      }

      internal static SqlDataReader GetCustomerDeferredBalance(string customerId, string branchCode, DateTime tranDate)
      {
         StringBuilder sql = new StringBuilder();

         SqlHelper.BuildDeclareVariables(sql, branchCode, tranDate);
         sql.Append("select d.customerid,c.customernameviet, sum( ");
         sql.Append("case when ((@accounted = 0 and tradingdate > @preT3) or (@accounted = 1 and tradingdate > @preT2)) and transcode like '[DR]' then amount ");
         sql.Append("when ((@accounted = 0 and tradingdate > @preT3) or (@accounted = 1 and tradingdate > @preT2)) and transcode like '[CX]' then -amount end ");
         sql.Append(") as duedefered, sum( ");
         sql.Append("case when ((@accounted = 0 and tradingdate <= @preT3) or (@accounted = 1 and tradingdate <= @preT2)) and transcode like '[DR]' then amount ");
         sql.Append("when ((@accounted = 0 and tradingdate <= @preT3) or (@accounted = 1 and tradingdate <= @preT2)) and transcode like '[CX]' then -amount end ");
         sql.AppendFormat(") as overduedefered from DeferredTransactionDayHist d ,customers c where d.customerid = c.customerid and d.transdate <  @currDate ");
         sql.AppendFormat("and d.customerid = '{0}' group by d.customerid, c.customernameviet", DBUtil.GetLiteral(customerId));

         return DBUtil.ExecuteDataReader(sql.ToString(), SBSConnection, SBSTransaction);
      }


      /// <summary>
      /// Should be obsoleted
      /// </summary>
      /// <param name="customerId"></param>
      /// <param name="branchCode"></param>
      /// <param name="fromDate"></param>
      /// <param name="toDate"></param>
      /// <param name="defType"></param>
      /// <returns></returns>
      internal static DataSet GetCustomerDeferredTranList(string customerId, string branchCode, DateTime fromDate, DateTime toDate, Asos.Accountant.DeferedType defType)
      {
         StringBuilder sql = new StringBuilder();

         sql.Append("select customerid, transdate, tradingdate, ");
         sql.Append("sum(case when transcode = 'D' then amount when transcode = 'X' then -amount else 0 end) as debit, ");
         sql.Append("sum(case when transcode = 'C' then amount when transcode = 'R' then -amount else 0 end) as credit, ");
         sql.Append("dbo.TransDatePlus(tradingdate,2,0) as t3day ");
         sql.Append("from DeferredTransactionDay ");
         sql.AppendFormat("where branchcode = '{0}' ", branchCode);
         sql.AppendFormat("and transdate between {0} and {1} ", DBUtil.GetLiteral(fromDate), DBUtil.GetLiteral(toDate));

         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("and customerid like '%{0}' ", DBUtil.GetLiteral(customerId));

         if (defType == Asos.Accountant.DeferedType.OverDueDeffered)
         {
            sql.Append("and ((transcode like '[CR]' and transdate >= dbo.TransDatePlus(tradingdate,2,0)) ");
            sql.AppendFormat("or (transcode like '[DX]' and transdate <= dbo.TransDateMinus({0},2,0)))", DBUtil.GetLiteral(toDate));
         }
         else if (defType == Asos.Accountant.DeferedType.DueDeffered)
         {
            sql.Append("and ((transcode like '[CR]' and transdate < dbo.TransDatePlus(tradingdate,2,0)) ");
            sql.AppendFormat("or (transcode like '[DX]' and transdate > dbo.TransDateMinus({0},2,0)))", DBUtil.GetLiteral(toDate));
         }

         sql.Append("group by customerid, tradingdate, transdate ");
         sql.Append("union all ");
         sql.Append("select customerid, transdate, tradingdate, ");
         sql.Append("sum(case when transcode = 'D' then amount when transcode = 'X' then -amount else 0 end) as debit, ");
         sql.Append("sum(case when transcode = 'C' then amount when transcode = 'R' then -amount else 0 end) as credit, ");
         sql.Append("dbo.TransDatePlus(tradingdate,3,0) as t3day ");
         sql.Append("from DeferredTransactionDayHist ");
         sql.AppendFormat("where branchcode = '{0}' ", branchCode);
         sql.AppendFormat("and transdate between {0} and {1} ", DBUtil.GetLiteral(fromDate), DBUtil.GetLiteral(toDate));

         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("and customerid like '%{0}' ", DBUtil.GetLiteral(customerId));

         if (defType == Asos.Accountant.DeferedType.OverDueDeffered)
         {
            sql.Append("and ((transcode like '[CR]' and transdate >= dbo.TransDatePlus(tradingdate,3,0)) ");
            sql.AppendFormat("or (transcode like '[DX]' and transdate <= dbo.TransDateMinus({0},3,0)))", DBUtil.GetLiteral(toDate));
         }
         else if (defType == Asos.Accountant.DeferedType.DueDeffered)
         {
            sql.Append("and ((transcode like '[CR]' and transdate < dbo.TransDatePlus(tradingdate,3,0)) ");
            sql.AppendFormat("or (transcode like '[DX]' and transdate > dbo.TransDateMinus({0},3,0)))", DBUtil.GetLiteral(toDate));
         }

         sql.Append("group by customerid, tradingdate, transdate ");
         sql.Append("order by customerid, tradingdate asc, transdate asc ");

         return DBUtil.ExecuteDataSet(sql.ToString(), SBSConnection, SBSTransaction);
      }

      internal static DataSet GetCustomerDeferredTranList(string customerId, string branchCode, DateTime fromDate, DateTime toDate, Asos.Accountant.DeferedType defType, string tradeCode)
      {
         StringBuilder sql = new StringBuilder();

         sql.Append("select c.customerid, c.customernameviet, ");
         sql.Append("d.tradingdate as ngayno, ");
         sql.Append("d.daydebit as sotienno, ");
         sql.Append("dbo.TransDatePlus(d.tradingdate,2,0) as ngayphaitrano, ");
         sql.Append("t.transdate as ngaytrano,");
         sql.Append("t.credit as sotientra , d.currentdebit as nohientai ");
         sql.Append("from ");

         sql.Append("customers c ");

         if (!string.IsNullOrEmpty(tradeCode))
            sql.AppendFormat("inner join unittradecode u on c.tradecode = u.tradecode and c.tradecode = '{0}'  ", tradeCode);
         sql.Append("left join ");
         sql.Append("(");
         sql.Append("SELECT CustomerID, DayCredit, DayDebit, CurrentDebit, TradingDate ");
         sql.Append("FROM DeferredBalance ");
         sql.AppendFormat("WHERE [BranchCode] = '{0}' ", branchCode);
         sql.AppendFormat("AND [TradingDate] <= {0} ", DBUtil.GetLiteral(toDate));

         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("AND [CustomerID] like '%{0}' ", DBUtil.GetLiteral(customerId));
         sql.Append("union all ");
         sql.Append("SELECT CustomerID, DayCredit, DayDebit, CurrentDebit, TradingDate ");
         sql.Append("FROM DeferredBalanceHist ");
         sql.AppendFormat("WHERE [BranchCode] = '{0}' ", branchCode);
         sql.AppendFormat("AND [TradingDate] <= {0} ", DBUtil.GetLiteral(toDate));

         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("AND [CustomerID] like '%{0}' ", DBUtil.GetLiteral(customerId));
         sql.Append("and DayDebit > 0) d on c.customerid = d.customerid ");
         sql.Append("left join ");
         sql.Append("(");
         sql.Append("select customerid, transdate, tradingdate, ");
         sql.Append("		sum(case when transcode = 'C' then amount when transcode = 'R' then -amount else 0 end) as credit ");
         sql.Append("from DeferredTransactionDay ");
         sql.AppendFormat("WHERE [BranchCode] = '{0}' ", branchCode);
         sql.AppendFormat("AND [transdate] <= {0} ", DBUtil.GetLiteral(toDate));

         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("		AND [CustomerID] like '%{0}' ", DBUtil.GetLiteral(customerId));

         sql.Append("		and transcode like '[CR]' ");
         sql.Append("group by customerid, transdate, tradingdate ");
         sql.Append("union all ");
         sql.Append("select customerid, transdate, tradingdate, ");
         sql.Append("	sum(case when transcode = 'C' then amount when transcode = 'R' then -amount else 0 end) as credit ");
         sql.Append("from DeferredTransactionDayHist ");
         sql.AppendFormat("WHERE [BranchCode] = '{0}' ", branchCode);
         sql.AppendFormat("AND [transdate] <= {0} ", DBUtil.GetLiteral(toDate));

         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("AND [CustomerID] like '%{0}' ", DBUtil.GetLiteral(customerId));

         sql.Append("	and transcode like '[CR]' ");
         sql.Append("group by customerid, transdate, tradingdate ");
         sql.Append(") t on d.customerid = t.customerid and d.TradingDate = t.tradingdate ");

         sql.Append("left join (select cid.date, dich.customerid from [asos].dbo.DeferedInterestCalcHist dich ");
         sql.Append("inner join [asos].dbo.CalcIntDate cid on dich.CalcIntDateId = cid.id and dich.DefferedType = 0) h on c.customerid = h.customerid ");

         sql.Append("where currentdebit is not null ");
         sql.Append("and (date is null or (t.transdate is null or t.transdate > h.date)) ");
         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("AND c.[CustomerID] like '%{0}' ", DBUtil.GetLiteral(customerId));
         sql.AppendFormat("and c.branchcode = '{0}' and dbo.TransDatePlus(d.tradingdate,2,0) <= {1} ", branchCode, DBUtil.GetLiteral(toDate));
         if (fromDate != DateTime.MinValue)
            sql.Append("and (currentdebit = 0 or (t.transdate is not null and t.tradingdate is not null)) ");
         sql.Append("order by c.customerid, d.tradingdate asc, t.transdate asc ");

         return DBUtil.ExecuteDataSet(sql.ToString(), SBSConnection, SBSTransaction);
      }

      internal static SqlDataReader GetUserList(string username)
      {
         string sql = string.Format("select username, fullname from users where branchcode = '{0}' and username like '%{1}%' order by username", Util.LoggedUser.BranchCode, DBUtil.GetLiteral(username));
         return DBUtil.ExecuteDataReader(sql, SBSConnection, SBSTransaction);
      }

      internal static List<UnitPlace> GetUnitPlaces(string branchCode)
      {
         List<UnitPlace> result = new List<UnitPlace>();
         string sql = string.Format("select tradecode, unitname, unittype from unittradecode where branchcode = '{0}' and isshow = 1 order by unittype", branchCode);
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql, SBSConnection, SBSTransaction))
         {
            while (r.Read())
               result.Add(new UnitPlace(r.GetString(0), r.GetString(1), r.GetInt32(2)));
            r.Close();
         }
         return result;
      }

      internal static SqlDataReader GetCashAndStockTransaction(string customerId, DateTime fromDate, DateTime toDate, string branchCode)
      {
         StringBuilder sql = new StringBuilder();

         sql.Append("select transactionnumber, description, transactiontype, transactiondate, amount ");
         sql.Append("from ( ");
         sql.Append("select transactionnumber,description,Debitorcredit as transactiontype, transactiondate, amount, id, transactiondate as transactiontime ");
         sql.Append("from transactionhistvics ");
         sql.AppendFormat("where (transactiondate between {0} and {1}) and accountid = '{2}' ",
            DBUtil.GetLiteral(fromDate), DBUtil.GetLiteral(toDate), DBUtil.GetLiteral(customerId));
         sql.Append("union all ");
         sql.Append("select transactionnumber,description,Debitorcredit as transactiontype, transactiondate, amount, id, transactiontime ");
         sql.Append("from transactionhist where ");
         sql.Append("((bankgl='353111'and transactiondate < cast('2008-09-15 00:00:00' as datetime)) or ");
         sql.Append("(bankgl='324111'and transactiondate >= cast('2008-09-15 00:00:00' as datetime))) and approved <> 'X' ");
         sql.AppendFormat("and (transactiondate between {0} and {1}) and accountid= '{2}' ",
            DBUtil.GetLiteral(fromDate), DBUtil.GetLiteral(toDate), DBUtil.GetLiteral(customerId));
         sql.Append("union all ");
         sql.Append("select transactionnumber,description,Debitorcredit as transactiontype, transactiondate, amount, id, transactiontime ");
         sql.Append("from transactionday where  bankgl='324111' and approved <> 'X' ");
         sql.AppendFormat("and (transactiondate between {0} and {1}) and accountid= '{2}' ",
            DBUtil.GetLiteral(fromDate), DBUtil.GetLiteral(toDate), DBUtil.GetLiteral(customerId));
         sql.Append(") x order by transactiondate, transactiontime, id ");

         return DBUtil.ExecuteDataReader(sql.ToString(), SBSConnection, SBSTransaction);
      }

      internal static decimal GetBeginBalance(string customerId, DateTime fromDate)
      {
         StringBuilder sql = new StringBuilder();

         sql.Append("declare @transdate smalldatetime \n");
         sql.AppendFormat("if exists(select * from TRANSDATEHIST where transdate = {0}) set @transdate= {0}\n", DBUtil.GetLiteral(fromDate));
         sql.AppendFormat("else select @transdate = min(transdate) from TRANSDATEHIST where transdate > {0} ", DBUtil.GetLiteral(fromDate));

         sql.AppendFormat("if exists(select * from transdate where currenttransdate = @transdate and branchcode = '{0}') \n", Util.LoggedUser.BranchCode);
         sql.AppendFormat("select beginday from balance where bankgl = '324111' and accountid = '{0}' \n", DBUtil.GetLiteral(customerId));
         sql.Append("else if @transdate  > cast('2009-03-13 00:00:00' as datetime) \n");
         sql.AppendFormat("select beginday from balancehist where bankgl = '324111' and accountid = '{0}' and transactiondate = @transdate \n", DBUtil.GetLiteral(customerId));
         sql.Append("else if @transdate  = cast('2009-03-13 00:00:00' as datetime) \n");
         sql.AppendFormat("select amount from transactionhist where bankgl = '324111' and accountid = '{0}' and transactioncode = '' \n", DBUtil.GetLiteral(customerId));
         sql.Append("else if @transdate >= cast('2008-09-15 00:00:00' as datetime) \n");
         sql.AppendFormat("select beginday from balancehist where bankgl = '353111' and accountid = '{0}' and transactiondate = @transdate \n", DBUtil.GetLiteral(customerId));
         sql.AppendFormat("else select top 1  begincredit from transactionhistvics where accountid = '{0}' and transactiondate >= @transdate \n", DBUtil.GetLiteral(customerId));

         object obj = DBUtil.ExecuteScalar(sql.ToString(), SBSConnection, SBSTransaction);
         if (obj != null)
            return (decimal)obj;
         return 0M;
      }

      internal static decimal GetFeeValue(string customerId, string stockCode, decimal tradingValue)
      {
         decimal result = 0M;
         using (SqlCommand command = new SqlCommand(ConfigurationManager.AppSettings["SP_SBS_GETORDERFEE"], SBSConnection, SBSTransaction))
         {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = customerId;
            command.Parameters.Add("@StockCode", SqlDbType.VarChar).Value = stockCode;
            command.Parameters.Add("@OrderValue", SqlDbType.Decimal).Value = tradingValue;
            command.Parameters.Add("@FeeRate", SqlDbType.Decimal);
            command.Parameters["@FeeRate"].Direction = ParameterDirection.Output;
            command.Parameters["@FeeRate"].Precision = 0x12;
            command.Parameters["@FeeRate"].Scale = 5;

            command.ExecuteNonQuery();
            if (command.Parameters["@FeeRate"].Value != DBNull.Value)
               result = Convert.ToDecimal(command.Parameters["@FeeRate"].Value) * tradingValue;
         }
         return result;
      }

      public static Asos.Report.DataSet.DebtAndAssetRow GetCustomerInfo(string customerId)
      {
         Asos.Report.DataSet.DebtAndAssetDataTable table = new Asos.Report.DataSet.DebtAndAssetDataTable();
         Asos.Report.DataSet.DebtAndAssetRow result = table.Rows.Add() as Asos.Report.DataSet.DebtAndAssetRow;

         DataSet ds = GetAllAssestAndDefered(Util.LoggedUser.BranchCode, customerId, Util.ExceptStocks, string.Empty, false, false, false);
         if (ds.Tables == null || ds.Tables[0].Rows.Count <= 0)
            return null; ;

         decimal balance, pStock, advPaid, stock, pSell, dueDebt, overDebt, yetActDebt, total, reXDebt, f1, f2;
         DataRow r = ds.Tables[0].Rows[0];

         balance = r.IsNull(2) ? 0 : decimal.Parse(r[2].ToString());
         pSell = r.IsNull(3) ? 0 : decimal.Parse(r[3].ToString());
         advPaid = r.IsNull(4) ? 0 : decimal.Parse(r[4].ToString());
         stock = r.IsNull(5) ? 0 : decimal.Parse(r[5].ToString());
         pStock = r.IsNull(6) ? 0 : decimal.Parse(r[6].ToString());

         total = balance + pStock - advPaid + stock + pSell;
         if (total == 0)
            return null;

         overDebt = r.IsNull(7) ? 0 : decimal.Parse(r[7].ToString());
         dueDebt = r.IsNull(8) ? 0 : decimal.Parse(r[8].ToString());
         yetActDebt = r.IsNull(13) ? 0 : decimal.Parse(r[13].ToString());

         f1 = f2 = 0;
         reXDebt = (dueDebt + overDebt + yetActDebt) - balance;
         if (reXDebt > 0 && total - balance > 0)
            f1 = reXDebt / (total - balance);
         reXDebt = reXDebt - pSell + advPaid;
         if (reXDebt > 0 && stock + pStock > 0)
            f2 = reXDebt / (stock + pStock);

         result.CustId = r[0].ToString();
         result.CustName = r[1].ToString();
         result.Balance = balance;                             //"Số dư hiện tại";
         result.PendingSell = pSell;                               //"Tiền bán CK chờ TT";
         result.AdvanceContactAmount = advPaid;                             //"Tiền bán đã ư. trước";
         result.StockValue = stock;                               //"Giá trị CK trong TK";
         result.PendingStock = pStock;                              //"Giá trị CK chờ TT";
         result.Total = total;                               //"Tổng TS";
         result.DueDebt = dueDebt;                             //"No trong han";
         result.OverDebt = overDebt;                            //"No qua han";
         result.TotalDebt = dueDebt + overDebt;                  //"Tong no";
         result.YetAccountDebt = yetActDebt;                          //"Tiền mua CK chưa HT";
         result.DebtRate = Util.FormatRate((dueDebt + overDebt) / total, true);     //"Tỉ lệ nợ";
         result.F1 = Util.FormatRate(f1, true);  //f1
         result.F2 = Util.FormatRate(f2, true);  //f2
         result.MustPay = r.IsNull(11) ? 0 : decimal.Parse(r[11].ToString());

         return result;
      }
   }
}