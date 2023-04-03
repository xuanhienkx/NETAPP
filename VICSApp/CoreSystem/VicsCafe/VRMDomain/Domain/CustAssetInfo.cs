using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using VRMDomain.Common;
using System.Data.SqlClient;

namespace VRMDomain.Domain
{
   public sealed class CustAssetInfo
   {
      public CustAssetInfo() { }

      public decimal TongNo;
      public decimal TongTS;
      public decimal TyLeF1;
      public decimal TyLeF2;
      public decimal TyLeNo;
      public decimal SoTienDuocRut;
      public decimal HanMucToiDa;
      public decimal TienBanCKChoVe;
      public decimal CKHienTai;
      public decimal CKMuaChoVe;
      public decimal NoQuaHanHD;
      public decimal NoTrongHanHD;
      public decimal NoQuaHan;
      public decimal NoTrongHan;
      public decimal PhaiTraTrongNgay;
      public decimal SoDuHienTai;
      public decimal TienBanUngTruoc;
      public decimal TienMuaCKChuaHachToan;
      public decimal TyLeHopTac;
      public string CustomerID;
      public string CustomerName;
      public string SoHD;
      public ContractType LoaiHopHong;

      public decimal CoTucBangTien;
      public decimal CoTucBangChungKhoan;
      public decimal QuyenMuaChungKhoan;
      public decimal TienMuaQuyen;
      public string NVChamSoc;
      public string TradeCode;
      public decimal RCKHienTai;
      public decimal RCKMuaChoVe;
      public decimal RCoTucBangChungKhoan;
      public decimal RQuyenMuaChungKhoan;
      public decimal RTongTS;

      public DateTime NgayKetThucHD = DateTime.MinValue;
      public DateTime NgayHD = DateTime.MinValue;

      private static CustAssetInfo DB2Object(IDataReader r)
      {
         CustAssetInfo result;
         if (TryParse(r, out result, null))
            return result;
         return null;
      }

      private static bool TryParse(IDataReader r, out CustAssetInfo cinfo, List<Predicate<CustAssetInfo>> filters)
      {
         CustAssetInfo result = new CustAssetInfo();

         result.TienBanCKChoVe = r["tienbanckchove"] == DBNull.Value ? 0M : (decimal)r["tienbanckchove"];
         result.CKHienTai = r["ckhientai"] == DBNull.Value ? 0M : (decimal)r["ckhientai"];
         result.CKMuaChoVe = r["ckmuachove"] == DBNull.Value ? 0M : (decimal)r["ckmuachove"];
         result.RCKHienTai = r["rckhientai"] == DBNull.Value ? 0M : (decimal)r["rckhientai"];
         result.RCKMuaChoVe = r["rckmuachove"] == DBNull.Value ? 0M : (decimal)r["rckmuachove"];
         result.NoQuaHanHD = r["noquahanHD"] == DBNull.Value ? 0M : (decimal)r["noquahanHD"];
          result.NoTrongHanHD = 0;//r["notronghanHD"] == DBNull.Value ? 0M : (decimal)r["notronghanHD"];
         result.NoQuaHan = r["noquahan"] == DBNull.Value ? 0M : (decimal)r["noquahan"];
          result.NoTrongHan = 0;//r["notronghan"] == DBNull.Value ? 0M : (decimal)r["notronghan"];
         result.PhaiTraTrongNgay = r["phaitratrongngay"] == DBNull.Value ? 0M : (decimal)r["phaitratrongngay"];
         result.SoDuHienTai = r["currentbalance"] == DBNull.Value ? 0M : (decimal)r["currentbalance"];
         result.TienBanUngTruoc = r["tienbanungtruoc"] == DBNull.Value ? 0M : (decimal)r["tienbanungtruoc"];
         result.TienMuaCKChuaHachToan = r["tienmuachuahachtoan"] == DBNull.Value ? 0M : (decimal)r["tienmuachuahachtoan"];
         result.NVChamSoc = r["username"] == DBNull.Value ? string.Empty : (string)r["username"];
         result.TradeCode = r["TradeCode"] == DBNull.Value ? string.Empty : (string)r["TradeCode"];
         result.CustomerID = (string)r["customerid"];
         result.CustomerName = (string)r["customernameviet"];
         //if (r["ContractID"] != DBNull.Value)
         //{
         //   result.SoHD = (string)r["ContractID"];
         //   result.LoaiHopHong = (ContractType)Enum.Parse(typeof(ContractType), r["contracttype"].ToString());
         //   result.NgayHD = (DateTime)r["duedate"];
         //   result.NgayKetThucHD = (DateTime)r["expireddate"];
         //}
         if (r["contracttype"] != DBNull.Value)
         result.LoaiHopHong = (ContractType)Enum.Parse(typeof(ContractType), r["contracttype"].ToString());

         result.CoTucBangTien = r["cotuctien"] == DBNull.Value ? 0M : (decimal)r["cotuctien"];
         result.CoTucBangChungKhoan = r["cotucck"] == DBNull.Value ? 0M : (decimal)r["cotucck"];
         result.QuyenMuaChungKhoan = r["quyenmuack"] == DBNull.Value ? 0M : (decimal)r["quyenmuack"];
         result.RCoTucBangChungKhoan = r["rcotucck"] == DBNull.Value ? 0M : (decimal)r["rcotucck"];
         result.RQuyenMuaChungKhoan = r["rquyenmuack"] == DBNull.Value ? 0M : (decimal)r["rquyenmuack"];
         result.TienMuaQuyen = r["tienmuaquyen"] == DBNull.Value || result.QuyenMuaChungKhoan == 0M ? 0M : (decimal)r["tienmuaquyen"];
         
          //GD T2 no tu ngay T0
         result.TongNo = result.NoQuaHan + result.TienMuaCKChuaHachToan;
         //result.TongNo = result.NoTrongHan + result.NoQuaHan + result.TienMuaCKChuaHachToan;
         result.TongTS = result.SoDuHienTai + result.CKHienTai + result.TienBanCKChoVe + result.CKMuaChoVe - result.TienBanUngTruoc;
         result.RTongTS = result.SoDuHienTai + result.RCKHienTai + result.TienBanCKChoVe + result.RCKMuaChoVe - result.TienBanUngTruoc +
               result.RCoTucBangChungKhoan + result.CoTucBangTien + result.RQuyenMuaChungKhoan - result.TienMuaQuyen;

         if (Util.RightAndEPSAsCredit)
            result.TongTS += result.CoTucBangTien + result.CoTucBangChungKhoan + result.QuyenMuaChungKhoan - result.TienMuaQuyen;

         result.TyLeF1 = result.TongTS != result.SoDuHienTai ? Math.Max(0M, (result.TongNo - result.SoDuHienTai) * 100M / (result.TongTS - result.SoDuHienTai)) : 0M;
         result.TyLeF2 = result.TongTS - result.SoDuHienTai - result.TienBanCKChoVe + result.TienBanUngTruoc != 0 ? Math.Max(0M, (result.TongNo - result.SoDuHienTai - result.TienBanCKChoVe + result.TienBanUngTruoc) * 100M / (result.TongTS - result.SoDuHienTai - result.TienBanCKChoVe + result.TienBanUngTruoc)) : 0M;
         result.TyLeNo = result.TongTS == 0 ? 0M : Math.Round(result.TongNo * 100M / result.TongTS, 0);


         if (r["marginrate"] != DBNull.Value)
         {
            result.TyLeHopTac = (byte)r["marginrate"];

            if (result.TongTS * result.TyLeHopTac > 0 && result.TyLeHopTac > result.TongNo * 100 / result.TongTS)
               result.SoTienDuocRut = Math.Min(result.SoDuHienTai, result.TongTS - result.TongNo * 100 / result.TyLeHopTac);
            else
               result.SoTienDuocRut = 0M;

            if (result.TyLeHopTac > 0 && result.LoaiHopHong == ContractType.KhongThoiHan)
               result.HanMucToiDa = Math.Max(0M, (result.TongTS * result.TyLeHopTac - result.TongNo * 100M) / (100M - result.TyLeHopTac));
            //result.HanMucToiDa = Math.Max(0M, (result.TongTS - result.TongNo) * 100M / (100M - result.TyLeHopTac) - result.TongTS); // CT cua Trinh
         }
         if (filters != null)
         {
            foreach (Predicate<CustAssetInfo> pred in filters)
            {
               if (pred(result))
                  continue;
               cinfo = null;
               return false;
            }
         }
         cinfo = result;
         return true;
      }


      public static CustAssetInfo GetCustomerAssetInfo(string customerId, DateTime transDate, UserLite user, bool isGetTopOne)
      {
         CustAssetInfo result = null;
         string sql = SqlHelper.BuildGetCustomerAssetInfo(customerId, transDate, user, 0, false, isGetTopOne, ContractType.Both);
         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
         {
            if (r.Read())
               result = DB2Object(r);
            r.Close();
            r.Close();
            r.Dispose();
         }
         return result;
      }

      public static List<CustAssetInfo> GetCustomerAssetInfoList(string customerId, DateTime transDate, UserLite user, int userTakeCareID, bool forDebitLimit, decimal limitDebtRatio, bool showWarning, ContractType contractType)
      {
         List<CustAssetInfo> result = new List<CustAssetInfo>();

         string sql = SqlHelper.BuildGetCustomerAssetInfo(customerId, transDate, user, userTakeCareID, forDebitLimit, false, contractType);
         CustAssetInfo obj;
         List<Predicate<CustAssetInfo>> filters = new List<Predicate<CustAssetInfo>>();
         filters.Add(new Predicate<CustAssetInfo>(delegate(CustAssetInfo c) { return c.TongTS > 0 || c.TongNo > 0 || c.QuyenMuaChungKhoan + c.CoTucBangTien + c.CoTucBangChungKhoan > 0; }));// taisan no hoac co tuc phai co         
         if (limitDebtRatio > 0M)
             filters.Add(new Predicate<CustAssetInfo>(delegate(CustAssetInfo c) { return c.TyLeNo >= limitDebtRatio; })); // checkrate
         if (showWarning)
             filters.Add(new Predicate<CustAssetInfo>(delegate(CustAssetInfo c) { return (c.TyLeNo > 0 && c.TyLeNo >= c.TyLeHopTac); }));// ti le no vi pham
         if (!forDebitLimit)
             filters.Add(new Predicate<CustAssetInfo>(delegate(CustAssetInfo c) { return c.TongNo > 0; }));

         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
         {
             while (r.Read())
             {
                 if (TryParse(r, out obj, filters))
                     result.Add(obj);
             }
             r.Close();
             r.Dispose();
         }
         return result;
      }

      public static List<CustAssetInfo> GetCustomerAssetInfoListForDebt(string customerId, DateTime transDate, UserLite user, int userTakeCareID, bool isOverT2Debt)
      {
         List<CustAssetInfo> result = new List<CustAssetInfo>();

         string sql = SqlHelper.BuildGetCustomerAssetInfo(customerId, transDate, user, userTakeCareID, isOverT2Debt, false, ContractType.Both);
         CustAssetInfo obj;
         List<Predicate<CustAssetInfo>> filters = new List<Predicate<CustAssetInfo>>();
         if (isOverT2Debt)
            filters.Add(new Predicate<CustAssetInfo>(delegate(CustAssetInfo c) { return c.NoQuaHan > 0M; }));
         else
            filters.Add(new Predicate<CustAssetInfo>(delegate(CustAssetInfo c) { return c.NoQuaHanHD > 0M; }));

         using (SqlDataReader r = DBUtil.ExecuteDataReader(sql))
         {
            while (r.Read())
            {
               if (TryParse(r, out obj, filters))
                  result.Add(obj);
            }
            r.Close();
            r.Dispose();
         }
         return result;
      }

      private static class SqlHelper
      {

         internal static string BuildGetCustomerAssetInfo(string customerId, DateTime transDate, UserLite user, int userTakeCareID, bool forDebitLimit, bool isGetTopOne, ContractType contractType)
         {
            StringBuilder sql = new StringBuilder();

            // NTV: ap dung tu ngay 1/1/2016 giao dich T2, no tu T0
            //sql.Append("DECLARE @preT3 smalldatetime, @preT2 smalldatetime \n");
            //sql.AppendFormat("SET @preT3 = dbo.TransDateMinus({0},3,0) \n", LiteralUtil.GetLiteral(transDate));
            //sql.AppendFormat("SET @preT2 = dbo.TransDateMinus({0},2,0) \n", LiteralUtil.GetLiteral(transDate));
            sql.Append("DECLARE @preT2 smalldatetime \n");
            sql.AppendFormat("SET @preT2 = dbo.TransDateMinus({0},2,0) \n", LiteralUtil.GetLiteral(transDate));

            // select 
            sql.AppendFormat("select {0} ", isGetTopOne ? "top 1" : string.Empty);
            sql.Append("c.customerid, c.customernameviet, b.currentbalance,v.marginrate,c.BranchCode, c.TradeCode, \n");
            sql.Append("s.ckhientai, s.ckmuachove, s.tienbanckchove, notronghan, noquahan,tienbanungtruoc,tienmuachuahachtoan, \n");
            sql.Append("cotuctien,cotucck,tienmuaquyen,quyenmuack,u.username, vrm.contracttype, \n");
            sql.Append("s.rckhientai, s.rckmuachove,rcotucck,rquyenmuack, phaitratrongngay, notronghanHD, noquahanHD ");

            sql.Append("from customers c \n");
            sql.AppendFormat("{0} join (select distinct customerid, contracttype from vrm_contract where status not in (0,4)) vrm on c.customerid = vrm.customerid {1} \n",
               contractType == ContractType.Both? "left" : string.Empty,
               contractType != ContractType.Both? string.Format("and contracttype = {0}", (int)contractType) : string.Empty); 

            sql.Append("left join users u on c.usertakecared = u.userid \n");

            if (user.IsAgencyMember)
               sql.Append("join agencycustomer a on c.customerid = a.customerid ");

            sql.Append("left join vrm_customer v on c.customerid = v.customerid \n");
            sql.Append("left join balance b on c.customerid = b.accountid and b.bankgl = '324111' \n");

            // chung khoan: hien tai, cho ve
            sql.Append("left join \n");
            sql.Append("(select tp.accountid, sum(vprice*quantity*1000) as ckhientai, sum(vprice*isnull(buyquantity,0)*1000) as ckmuachove, sum(sellvalue) as tienbanckchove 	 \n");
            sql.Append("   , sum(price*quantity*1000) as rckhientai, sum(price*isnull(buyquantity,0)*1000) as rckmuachove \n");
            sql.Append("from 	( \n");
            sql.Append("select  isnull(s.accountid, g.customerid) as accountid, isnull(s.stockcode,g.stockcode) as stockcode, \n");
            sql.Append("  isnull(s.quantity, 0) as quantity, buyquantity, sellvalue \n");
            sql.Append("from ( \n");
            sql.Append("	select [AccountId], sc.[StockCode], [Quantity] - isnull(sellvol, 0) as quantity from securities sc \n");
            sql.Append("left join (select customerid, stockcode, sum(matchedvolume) as sellvol from tradingresult \n");
            sql.Append("where dayid = 0 and orderside = 's' group by customerid, stockcode) trs on sc.accountid = trs.customerid and sc.stockcode = trs.stockcode \n");
            sql.Append("	where [BankGl] like '012121') s \n");
            sql.Append("full join ( \n");
            sql.Append("	select customerid, stockcode,  \n");
            sql.Append("	sum(isnull(buyquantity,0)) as buyquantity,  \n");
            sql.Append("	sum(isnull([sellvalue],0)) as sellvalue \n");
            sql.Append("	from  \n");
            sql.Append("	(select [CustomerId], [StockCode],  \n");
            sql.Append("		case when orderside = 'b' then matchedvolume end as buyquantity,  \n");
            sql.Append("		case when orderside = 's' then matchedvolume*matchedprice*(0.999-feerate)*1000 end as sellvalue \n");
            sql.Append("		from (select [CustomerId], [stockcode], [MatchedVolume], orderside, matchedprice,feerate  from tradingresult  \n");
            sql.Append("		union all select [CustomerId], [stockcode], [MatchedVolume], orderside, matchedprice,feerate  \n");
            sql.Append("		from [TradingResultHist] tr join ClearingDay cd on tr.ClearingCode = cd.ClearingCode and tr.[DayId]  = cd.Id and cd.IsLastDay = 0  \n");
            sql.Append("		where transactiondate >=  @preT2    \n");
            // chung khoan nhan cho duyet
            sql.Append("	)t  union all select [AccountId], [StockCode], [Quantity], 0 from [dbo].[ContigenStockDay] \n");
            sql.Append("   where [BankGl] = '012121' and Debitorcredit = 'C' and [Approved] = 'N' ) x \n");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("    where customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));

            sql.Append("group by [customerid], [StockCode]) g on s.[accountid] = g.customerid and s.stockcode = g.stockcode \n");
            sql.Append("	) tp   \n");
            sql.Append("   left join (  \n");

            if (Util.UseCellingPrice)
               sql.Append("	select x.stockcode, case when cellingfixedprice < price then cellingfixedprice else price end * valuerate /100 as vprice, price  \n");
            else
               sql.Append("	select x.stockcode, price * valuerate /100 as vprice, price  \n");

            sql.Append("		from vrm_stock vs  \n");
            sql.Append("		right join (select stockcode, case closeprice when 0 then basicprice else closeprice end as price   \n");
            sql.Append("			  from stockprice ) x on vs.stockcode = x.stockcode  \n");
            sql.Append("	) sp on tp.stockcode = sp.stockcode  \n");
            sql.Append(" group by tp.[accountid] \n");
            sql.Append(") s on c.customerid = s.accountid \n");

            //so tien no (hop tac kinh doanh co ky han va khong ky han
            sql.Append("left join( \n");
            if (contractType == ContractType.CoThoiHan)
            {
               sql.Append("select [CustomerId], null as notronghanHD, null as noquahanHD, null as debit, null as phaitratrongngay, \n");
               sql.AppendFormat("	sum(case when {0} <= [ExpiredDate] then [DisbursedAmount] - isnull([WithdrawAmount], 0) end) as notronghan, \n", LiteralUtil.GetLiteral(transDate));
               sql.AppendFormat("	sum(case when {0} > [ExpiredDate] then [DisbursedAmount] - isnull([WithdrawAmount], 0) end) as noquahan \n", LiteralUtil.GetLiteral(transDate));
               sql.Append("from [dbo].[vrm_Contract] where [ContractType] = 0 and [Status] = 3 ");
               if (!string.IsNullOrEmpty(customerId))
                  sql.AppendFormat("and [CustomerId] like '%{0}' ", LiteralUtil.GetLiteral(customerId));
               sql.Append("group by [CustomerId] ");
            }
            else if (contractType == ContractType.KhongThoiHan)
            {
                sql.Append("select kth.[CustomerId], null as notronghanHD, null as noquahanHD, debit as notronghan, debit as noquahan, debit as phaitratrongngay from \n");
               //sql.Append("    sum(case when TradingDate > @preT3 then CurrentDebit end) as notronghan, \n");
               //sql.Append("    sum(case when TradingDate <= @preT3 then CurrentDebit end) as noquahan, \n");
               //sql.Append("    sum(case when TradingDate = @preT2 then CurrentDebit end) as phaitratrongngay \n");
                sql.Append("(select d.CustomerId, sum(d.CurrentDebit) as debit ");
               sql.Append("from deferredbalance d join vrm_contract v on d.CustomerId = v.CustomerId \n");
               sql.Append("where v.[ContractType] = 1 and [Status] = 2 ");
               if (!string.IsNullOrEmpty(customerId))
                  sql.AppendFormat("and d.[CustomerId] like '%{0}' ", LiteralUtil.GetLiteral(customerId));
               sql.Append("group by d.[CustomerId]) kth");
            }
            else
            {
               sql.Append("SELECT x.customerid, \n");
               sql.Append("   isnull(damount, currentdebit) as notronghan, \n");
               sql.Append("   case when x.contracttype = 1 then currentdebit else 0 end as noquahan, \n");
               sql.Append("   case when x.contracttype = 1 then currentdebit else 0 end as phaitratrongngay, \n");

               //sql.Append("   isnull(damount, notronghan) as notronghan, \n");
               //sql.Append("   case when x.contracttype = 1 then noquahan else 0 end as noquahan, \n");
               //sql.Append("   case when x.contracttype = 1 then phaitratrongngay else 0 end as phaitratrongngay, \n");
              
               sql.AppendFormat("   case when {0} <= expdate then isnull(damount, currentdebit) end as notronghanHD, \n", LiteralUtil.GetLiteral(transDate));
               sql.AppendFormat("	case when {0} > expdate then isnull(damount, currentdebit) end as noquahanHD \n", LiteralUtil.GetLiteral(transDate));
               sql.Append("from (select [CustomerId], [ContractType], sum([DisbursedAmount] - isnull([WithdrawAmount], 0)) as damount, min([ExpiredDate]) as expdate \n");
               sql.Append("from vrm_contract where status not in (0,4) group by [CustomerId], [ContractType]) x left join ( \n");
               sql.Append("    select [CustomerId], sum(CurrentDebit) as currentdebit \n");
               //sql.Append("    sum(case when TradingDate > @preT3 then CurrentDebit end) as notronghan, \n");
               //sql.Append("    sum(case when TradingDate <= @preT3 then CurrentDebit end) as noquahan, \n");
               //sql.Append("    sum(case when TradingDate = @preT2 then CurrentDebit end) as phaitratrongngay \n");
               sql.Append("    from deferredbalance ");
               if (!string.IsNullOrEmpty(customerId))
                  sql.AppendFormat("where [CustomerId] like '%{0}' ", LiteralUtil.GetLiteral(customerId));
               sql.Append("group by [CustomerID]) b on x.customerid = b.customerid \n");

               if (!string.IsNullOrEmpty(customerId))
                  sql.AppendFormat("and x.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            }
            sql.Append(") d1 on c.customerid  = d1.customerid \n");

            //TIEN UNG TRUOC 
            sql.Append("left JOIN( \n");
            sql.Append("	select customerid, sum(advanceamount + advancefee) as tienbanungtruoc \n");
            sql.Append("	from (  \n");
            sql.Append("      SELECT customerid, advanceamount, advancefee,status FROM BuyCashContract \n");
            sql.Append("      union all SELECT customerid, advanceamount, advancefee,status FROM advancecontractall) x \n");
            sql.Append("   where status = 'T' ");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("and customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            sql.Append("	group by customerid \n");
            sql.Append(") ung on c.customerid = ung.customerid \n");

            //SO TIEN MUA CHUNG KHOAN CHUA DUOC HACH TOAN 
            sql.Append("left join \n");
            sql.Append("	(select customerid, sum(matchedvalue + feerate*matchedvalue) as tienmuachuahachtoan \n");
            sql.Append("	from tradingresult where orderside = 'B' and dayid = 0 \n");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("and customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            sql.Append("	group by customerid \n");
            sql.Append(") nab on c.customerid = nab.customerid \n");

            //CO TUC BANG TIEN, CO PHIEU VA MUA QUYEN
            sql.Append("LEFT JOIN ( \n");
            sql.Append("SELECT el.CustomerId  \n");
            // co tuc bang chung khoan
            sql.Append("		,sum(case e.RightType when 'S' then CASE RoundType \n");
            sql.Append("			WHEN 0 THEN floor(isnull(l.Quantity, el.Quantity) * RateA / RateB) \n");
            sql.Append("			WHEN 1 THEN floor(isnull(l.Quantity, el.Quantity) * RateA / RateB/10) * 10 \n");
            sql.Append("			WHEN 2 THEN floor(isnull(l.Quantity, el.Quantity) * RateA / RateB/100) * 100 \n");
            sql.Append("			WHEN 3 THEN floor(isnull(l.Quantity, el.Quantity) * RateA / RateB/1000) * 1000 \n");
            if (Util.UseCellingPrice)
               sql.Append("		END * case when isnull(cellingfixedprice,0) < price then isnull(cellingfixedprice,0) else price end * isnull(valuerate,0) * 10 end)  AS cotucck \n");
            else
               sql.Append("		END * price * isnull(valuerate,0) * 10 end) AS cotucck \n");
            sql.Append("		,sum(case e.RightType when 'S' then CASE RoundType \n"); // co tuc bang ck that
            sql.Append("			WHEN 0 THEN floor(isnull(l.Quantity, el.Quantity) * RateA / RateB) \n");
            sql.Append("			WHEN 1 THEN floor(isnull(l.Quantity, el.Quantity) * RateA / RateB/10) * 10 \n");
            sql.Append("			WHEN 2 THEN floor(isnull(l.Quantity, el.Quantity) * RateA / RateB/100) * 100 \n");
            sql.Append("			WHEN 3 THEN floor(isnull(l.Quantity, el.Quantity) * RateA / RateB/1000) * 1000 \n");
            sql.Append("		END * price * 1000 end) AS rcotucck \n");
            // co tuc bang tien
            sql.Append("     ,sum(case e.RightType when 'M' then floor(0.95 * el.Quantity * s.ParValue * e.RateA / e.RateB) end) AS cotuctien \n"); // thue 5%

            sql.Append("	FROM RightExecListDetail el  \n");
            sql.Append("   left join RightExecList l on el.customerid = l.customerid and el.RightExecId = l.RightExecId \n");
            sql.Append("	JOIN RightExec e ON el.RightExecId = e.Id \n");
            sql.Append("	left JOIN dbo.vrm_Stock vs ON e.StockCode = vs.StockCode \n");
            sql.Append("	join (select stockcode, case boardtype when 'S' then averageprice else case closeprice when 0 then basicprice else closeprice end end as price   \n");
            sql.Append("		from stockprice ) x on vs.stockcode = x.stockcode  \n");
            sql.Append("	JOIN dbo.GlStockCode s ON e.StockCode = s.StockCode \n");
            sql.AppendFormat("	WHERE el.Status not like '[TX]' and isnull(l.Status, '') <> 'T' AND e.RightType like '[MS]' and ([DatePay] is null or {0} < [DatePay]) \n", LiteralUtil.GetLiteral(transDate));
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("and el.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            sql.Append("   group by el.customerid \n");
            sql.Append(") ct ON c.CustomerId = ct.CustomerId \n");

            sql.Append("LEFT JOIN ( \n"); // mua quyen
            sql.Append("SELECT CustomerId, sum(case when x.[Status] ='A' then 0 else [RightExecPrice] * [RegisteredQuantity] end) as tienmuaquyen,   \n");
            sql.Append("sum([RegisteredQuantity] * isnull(valuerate,0) * 10 * case when isnull(cellingfixedprice,0) < price then isnull(cellingfixedprice,0) else price end)  AS quyenmuack,  \n");
            sql.Append("sum([RegisteredQuantity] * 1000 * price)  AS rquyenmuack  \n");
            sql.Append("from \n");
            sql.Append("(  \n");
            sql.Append("select rg.[RegisteredQuantity], rg.[Status], rg.[CustomerId], [RightExecPrice], [StockCode] \n");
            sql.Append("	from [dbo].[RightExec] r join [dbo].[RightExecRegister] rg on r.id = rg.[RightExecId]  \n");
            sql.AppendFormat("	where rg.[Status] not like '[TX]' and ([DatePay] is null or {0} < [DatePay]) \n", LiteralUtil.GetLiteral(transDate));
            sql.Append("union all  \n");
            sql.Append("select [Quantity] * [RateA] / [RateB], d.[Status], d.[CustomerId], [RightExecPrice], r.[StockCode] \n");
            sql.AppendFormat("	from [dbo].[RightExec] r join [dbo].[RightExecListDetail] d on r.id = d.[RightExecId] where d.[Status] = 'N' and [EndRegisterDate] >= {0} \n", LiteralUtil.GetLiteral(transDate));
            sql.Append(") x  \n");
            sql.Append("left join dbo.vrm_Stock vs ON x.StockCode = vs.StockCode  \n");
            sql.Append("join (select stockcode, case boardtype when 'S' then averageprice else case closeprice when 0 then basicprice else closeprice end end as price \n");
            sql.Append("		from stockprice ) s on x.stockcode = s.stockcode   \n");
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("and x.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            sql.Append("   group by x.customerid");
            sql.Append(") quyen ON c.CustomerId = quyen.CustomerId \n");

            // dieu kien
            sql.AppendFormat("where c.branchcode = '{0}' ", user.BranchCode);
            if (!string.IsNullOrEmpty(customerId))
               sql.AppendFormat("and c.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
            if (userTakeCareID != 0)
               sql.AppendFormat("and c.UserTakeCared = {0} ", userTakeCareID);
            if (user.IsAgencyMember)
               sql.AppendFormat("and a.agencytradecode = '{0}' ", user.TradeCode);
            // loai tru cac khach hang dac biet
            if (!user.IsBranchAdmin && !user.Rights.Contains(GlobalConstants.SR_KHDB))
               sql.AppendFormat("and isnull(v.isspecial, 0) = 0 ");
            sql.Append("order by c.customerid");
            return sql.ToString();
         }
      }

      public static DataTable GetRightExecNotPayYet(string stockCode, string customerId, UserLite user)
      {
         StringBuilder sql = new StringBuilder();

         sql.Append("select e.Id, e.Description,e.StockCode, e.RightType, e.DateNoRight, e.DateOwnerConfirm, e.DatePay, l.CustomerId, c.CustomerNameViet, \n");
         sql.Append("isnull(el.Quantity, l.Quantity) as Quantity, e.RateA,e.RateB, e.RoundType, isnull(el.Amount,l.Amount) as Amount, ");
         sql.Append("case e.righttype when 'M' then floor(l.Quantity * s.ParValue * e.RateA / e.RateB) ");
         sql.Append("   when 'S' then ");
         sql.Append("		CASE RoundType \n");
         sql.Append("			WHEN 0 THEN floor(isnull(el.Quantity, l.Quantity) * RateA / RateB) \n");
         sql.Append("			WHEN 1 THEN floor(isnull(el.Quantity, l.Quantity) * RateA / RateB/10) * 10 \n");
         sql.Append("			WHEN 2 THEN floor(isnull(el.Quantity, l.Quantity) * RateA / RateB/100) * 100 \n");
         sql.Append("			WHEN 3 THEN floor(isnull(el.Quantity, l.Quantity) * RateA / RateB/1000) * 1000  end end as returnamount \n");
         sql.Append("from dbo.RightExec e \n");
         sql.Append("join dbo.RightExecListDetail l on e.Id = l.RightExecId \n");
         sql.Append("left join [dbo].[RightExecList] el on l.[CustomerId] = el.[CustomerId] and l.[RightExecId] = el.[RightExecId] \n");
         sql.Append("join dbo.Customers c on c.CustomerId = l.CustomerId \n");
         sql.Append("join dbo.GlStockCode s ON e.StockCode = s.StockCode \n");
         sql.AppendFormat("where c.branchcode = '{0}' and c.[AccountStatus] <> 'C' ", user.BranchCode);
         sql.Append("and l.Status not like '[TX]' and isnull(el.Status, '') <> 'T' and e.RightType like '[SM]' \n");
         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("and l.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
         if (!string.IsNullOrEmpty(stockCode))
            sql.AppendFormat("and e.StockCode = '{0}' ", LiteralUtil.GetLiteral(stockCode));
         if (user.IsAgencyMember)
            sql.AppendFormat("and c.tradecode = '{0}' ", user.TradeCode);

         sql.Append("order by e.StockCode, l.CustomerId ");

         return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }

      public static DataTable GetRightExecRegisterNotPayYet(string stockCode, string customerId, DateTime transDate, UserLite user)
      {
         StringBuilder sql = new StringBuilder();

         sql.Append("with r (id, [Description], [StockCode], [RightType], [DateNoRight], [DateOwnerConfirm], [DatePay], [RateA], [RateB], [RightExecPrice], [EndRegisterDate]) \n");
         sql.Append("as (select id, [Description], [StockCode], [RightType], [DateNoRight], [DateOwnerConfirm], [DatePay], [RateA], [RateB], [RightExecPrice], [EndRegisterDate] \n");
         sql.Append("	from [dbo].[RightExec] \n");
         sql.AppendFormat("	where righttype = 'R' and ([DatePay] is null or {0} <= [DatePay] or [EndRegisterDate] >= {0}) \n", LiteralUtil.GetLiteral(transDate));
         if (!string.IsNullOrEmpty(stockCode))
            sql.AppendFormat("and StockCode = '{0}' \n", LiteralUtil.GetLiteral(stockCode));
         sql.Append(") \n");
         sql.Append("select id, [Description], [StockCode], [RightType], [DateNoRight], [DateOwnerConfirm], [DatePay], [RateA], [RateB], [RightExecPrice], \n");
         sql.Append("	c.[CustomerId], [CustomerNameViet], [AllowBuyQuantity], [InTransferQuantity], [OutTransferQuantity], [RegisteredAmount], [RegisteredQuantity], \n");
         sql.Append("	[Quantity], [Status] \n");
         sql.Append("from customers c join \n");
         sql.Append("( \n");
         sql.Append("select r.id, [Description], r.[StockCode], r.[RightType], [DateNoRight], [DateOwnerConfirm], [DatePay], [RateA], [RateB], [RightExecPrice],  \n");
         sql.Append("	rg.[AllowBuyQuantity], rg.[InTransferQuantity], rg.[OutTransferQuantity], rg.[RegisteredAmount], rg.[RegisteredQuantity],  \n");
         sql.Append("	rg.[Quantity], rg.[Status], rg.[CustomerId] \n");
         sql.Append("	from r join [dbo].[RightExecRegister] rg on r.id = rg.[RightExecId] where rg.[Status] not like '[TX]' \n");
         sql.Append("union all \n");
         sql.Append("select r.id, [Description], r.[StockCode], r.[RightType], [DateNoRight], [DateOwnerConfirm], [DatePay], [RateA], [RateB], [RightExecPrice],  \n");
         sql.Append("	d.[Quantity]*[RateA]/[RateB], 0, 0, 0, 0, d.[Quantity], d.[Status], d.[CustomerId] \n");
         sql.Append("	from r join [dbo].[RightExecListDetail] d on r.id = d.[RightExecId] where d.[Status] = 'N' ");
         sql.AppendFormat("and [EndRegisterDate] >= {0} \n", LiteralUtil.GetLiteral(transDate));
         sql.Append(") x on c.[CustomerId] = x.[CustomerId] \n");
         sql.AppendFormat("where c.branchcode = '{0}' ", user.BranchCode);
         if (!string.IsNullOrEmpty(customerId))
            sql.AppendFormat("and c.customerid like '%{0}' ", LiteralUtil.GetLiteral(customerId));
         if (user.IsAgencyMember)
            sql.AppendFormat("and c.tradecode = '{0}' ", user.TradeCode);

         sql.Append("order by x.StockCode, c.CustomerId ");

         return DBUtil.ExecuteDataSet(sql.ToString()).Tables[0];
      }

      public static void CancelRightExec(int rightId, string customerId, bool isRegistered)
      {
         StringBuilder sql = new StringBuilder();

         if (isRegistered)
            sql.AppendFormat("update [dbo].[RightExecRegister] set [Status] = 'X' where [RightExecId] = {0} and [CustomerId] = '{1}' and [Status] <> 'T' \n",
              rightId, LiteralUtil.GetLiteral(customerId));
         else
            sql.AppendFormat("update [dbo].[RightExecList] set [Status] = 'X' where [RightExecId] = {0} and [CustomerId] = '{1}' and [Status] <> 'T' \n",
              rightId, LiteralUtil.GetLiteral(customerId));

         sql.AppendFormat("update [dbo].[RightExecListDetail] set [Status] = 'X' where [RightExecId] = {0} and [CustomerId] = '{1}' and [Status] <> 'T'\n",
                    rightId, LiteralUtil.GetLiteral(customerId));

         DBUtil.ExecuteNonQuery(sql.ToString());
      }
   }
}
