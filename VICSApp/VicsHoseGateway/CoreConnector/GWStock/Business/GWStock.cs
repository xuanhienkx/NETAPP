using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace GWStock
{
    public class GWBoardType
    {
        public GWBoardType(string boardName, string boardType)
        {
            BoardType = boardType;
            BoardName = boardType + " - " + boardName;
        }
        public string BoardName { get; set; }
        public string BoardType {get;set;}        
    }
    public class GWBrokerStatus
    {
        public GWBrokerStatus()
        {
        }
        public GWBrokerStatus(int firmid, string matchinghalt, string pthalt)
        {
            FirmID = firmid;
            MatchingHalt = matchinghalt;
            PTHalt = pthalt;
        }
        public int FirmID { get; set; }
        public string MatchingHalt { get; set; }
        public string PTHalt { get; set; }
    }
    public class GWTraderStatus
    {
        public GWTraderStatus()
        {
        }
        public GWTraderStatus(int firmid, int traderid, string traderstatus)
        {
            FirmID = firmid;
            TraderID = traderid;
            TraderStatus = traderstatus;
        }
        public int FirmID { get; set; }
        public int TraderID { get; set; }
        public string TraderStatus { get; set; }        
    }
    public class GWStockData
    {
        public string Split { get; set; }
        public string Suspension {get;set;}
        public string Halt {get;set;}
        public string Delist {get;set;}
        public string StockCode  {get;set;}
        public string StockName {get;set;}
        public string StockType {get;set;}
        public string StockBoard {get;set;}
    }
    public class GWStockPrice
    {
        public string StockCode { get; set; }
        public string TradingDate {get;set;}
        public double CeilingPrice {get;set;}
        public double BasicPrice {get;set;}
        public double OpenPrice {get;set;}
        public double ClosePrice {get;set;}
        public double FloorPrice {get;set;}        
    }
    public class GWStock
    {
        /// <summary>
        /// Cac thong tin ve gia va chung khoan duoc lay tu database HOSE GW
        /// </summary>       
        public static GWStockData[] getStockCodes(string stockType)
        {
            string sql = "select y.*, z.TOTAL_ROOM, z.CURRENT_ROOM  from ( " +
                        "select case when last_date_su >= last_date_ss or last_date_ss is null then last_date_su else last_date_ss end as last_modified, " +
                            "security_symbol, security_name, par_value, security_type, board_lot,  " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then ceiling_price_su else ceiling_price_ss end as ceiling_price, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then floor_price_su else floor_price_ss end as floor_price, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then last_sale_price_su else prior_close_price_ss end as prior_close_price, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then halt_su else halt_ss end as halt_resume_flag, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then suspension_su else suspension_ss end as suspension, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then split_su else split_ss end as split, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then delist_su else delist_ss end as delist, " +
                            "security_number_old, security_number_new, market_id " +
                        "from ( " +
                            "select a.last_modified last_date_ss, b.last_modified last_date_su, " +
                                "ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, isnull(b.board_lot,a.board_lot) as board_lot,  " +
                                "a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, " +
                                "b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su, " +
                                "a.HALT_RESUME_FLAG as halt_ss, a.suspension as suspension_ss, a.split as split_ss, a.delist as delist_ss, " +
                                "b.HALT_RESUME_FLAG as halt_su, b.suspension as suspension_su, b.split as split_su, b.delist as delist_su, " +
                                "b.security_number_old, b.security_number_new, b.market_id " +
                            "from (select * from (select dense_rank()  " +
                                    "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum " +
                                    ", * from hose_su) X where RankNum = 1 " +
                            ") b left outer join (select * from (select dense_rank()  " +
                                    "over(partition by security_number order by security_number, last_modified desc) as RankNum " +
                                    ", * from hose_ss) X where RankNum = 1 " +
                            ") a ON a.security_number = b.security_number_new " +
                        ") X " +
                    ") Y left outer join ( select * from (select dense_rank()  " +
                            "over(partition by security_number order by security_number, last_modified desc) as RankNum, * from hose_tr) X " +
                        "where RankNum = 1 " +
                    ") Z on Y.security_number_new = Z.security_number "+
                    "WHERE Y.security_type = @StockType order by Y.security_symbol";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@StockType", DbType.String, stockType);
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(cmd);
            List<GWStockData> lstData = new List<GWStockData>();
            while (rd.Read())
            {
                GWStockData data = new GWStockData();
                data.Delist = rd["delist"] == DBNull.Value ? "" : rd["delist"].ToString();
                data.Suspension = rd["suspension"] == DBNull.Value ? "" : rd["suspension"].ToString();
                data.Halt = rd["halt_resume_flag"] == DBNull.Value ? "" : rd["halt_resume_flag"].ToString();
                data.Split = rd["split"] == DBNull.Value ? "" : rd["split"].ToString();
                data.StockBoard = rd["delist"] == DBNull.Value ? "" : rd["delist"].ToString();
                data.StockCode = rd["security_symbol"] == DBNull.Value ? "" : rd["security_symbol"].ToString();
                data.StockName = rd["security_name"] == DBNull.Value ? "" : rd["security_name"].ToString();
                data.StockName = data.StockCode + " - " + data.StockName;
                data.StockType = stockType;
                lstData.Add(data);
            }
            rd.Close();
            return lstData.ToArray();            
        }
        public static GWStockData[] getStockCodes()
        {
            string sql = "select y.*, z.TOTAL_ROOM, z.CURRENT_ROOM  from ( " +
                        "select case when last_date_su >= last_date_ss or last_date_ss is null then last_date_su else last_date_ss end as last_modified, " +
                            "security_symbol, security_name, par_value, security_type, board_lot,  " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then ceiling_price_su else ceiling_price_ss end as ceiling_price, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then floor_price_su else floor_price_ss end as floor_price, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then last_sale_price_su else prior_close_price_ss end as prior_close_price, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then halt_su else halt_ss end as halt_resume_flag, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then suspension_su else suspension_ss end as suspension, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then split_su else split_ss end as split, " +
                            "case when last_date_su >= last_date_ss or last_date_ss is null then delist_su else delist_ss end as delist, " +
                            "security_number_old, security_number_new, market_id " +
                        "from ( " +
                            "select a.last_modified last_date_ss, b.last_modified last_date_su, " +
                                "ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, isnull(b.board_lot,a.board_lot) as board_lot,  " +
                                "a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, " +
                                "b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su, " +
                                "a.HALT_RESUME_FLAG as halt_ss, a.suspension as suspension_ss, a.split as split_ss, a.delist as delist_ss, " +
                                "b.HALT_RESUME_FLAG as halt_su, b.suspension as suspension_su, b.split as split_su, b.delist as delist_su, " +
                                "b.security_number_old, b.security_number_new, b.market_id " +
                            "from (select * from (select dense_rank()  " +
                                    "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum " +
                                    ", * from hose_su) X where RankNum = 1 " +
                            ") b left outer join (select * from (select dense_rank()  " +
                                    "over(partition by security_number order by security_number, last_modified desc) as RankNum " +
                                    ", * from hose_ss) X where RankNum = 1 " +
                            ") a ON a.security_number = b.security_number_new " +
                        ") X " +
                    ") Y left outer join ( select * from (select dense_rank()  " +
                            "over(partition by security_number order by security_number, last_modified desc) as RankNum, * from hose_tr) X " +
                        "where RankNum = 1 " +
                    ") Z on Y.security_number_new = Z.security_number " +
                    "order by Y.security_symbol";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(CommandType.Text,sql);
            List<GWStockData> lstData = new List<GWStockData>();
            while (rd.Read())
            {
                GWStockData data = new GWStockData();
                data.Delist = rd["delist"] == DBNull.Value ? "" : rd["delist"].ToString();
                data.Suspension = rd["suspension"] == DBNull.Value ? "" : rd["suspension"].ToString();
                data.Halt = rd["halt_resume_flag"] == DBNull.Value ? "" : rd["halt_resume_flag"].ToString();
                data.Split = rd["split"] == DBNull.Value ? "" : rd["split"].ToString();
                data.StockBoard = rd["delist"] == DBNull.Value ? "" : rd["delist"].ToString();
                data.StockCode = rd["security_symbol"] == DBNull.Value ? "" : rd["security_symbol"].ToString();
                data.StockName = rd["security_name"] == DBNull.Value ? "" : rd["security_name"].ToString();
                data.StockName = data.StockCode + " - " + data.StockName;
                data.StockType = rd["security_type"] == DBNull.Value ? "" : rd["security_type"].ToString();
                lstData.Add(data);
            }
            rd.Close();
            return lstData.ToArray();       
        }
        public static GWStockPrice[] getStockPrices(string stockType)
        {
            string sql = "select case when last_date_su >= last_date_ss or last_date_ss is null then last_date_su else last_date_ss end as last_modified, " +
	                    "security_symbol, security_name, par_value, security_type, board_lot, "+
                        "case when last_date_su >= last_date_ss or last_date_ss is null then ceiling_price_su else ceiling_price_ss end as ceiling_price, " +
                        "case when last_date_su >= last_date_ss or last_date_ss is null then floor_price_su else floor_price_ss end as floor_price, " +
                        "case when last_date_su >= last_date_ss or last_date_ss is null then last_sale_price_su else prior_close_price_ss end as prior_close_price " +
                    "from ( "+
	                    "select a.last_modified last_date_ss, b.last_modified last_date_su, "+
		                    "ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, isnull(b.board_lot,a.board_lot) as board_lot,  "+
		                    "a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, "+
		                    "b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su	 "+
                        "from ( " +
                            "select * from (select dense_rank()  " +
                                "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum " +
                                ", * from hose_su) X  " +
                            "where RankNum = 1 " +
                        ") b left outer join ( " +
		                    "select * from (select dense_rank()  "+
			                    "over(partition by security_number order by security_number, last_modified desc) as RankNum "+
			                    ", * from hose_ss) X  "+
		                    "where RankNum = 1 "+
	                    ") a ON a.security_number = b.security_number_new and b.security_type = @StockType " +
	                    //"and b.security_symbol = 'vis' "+
                    ") F ";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@StockType", DbType.String, stockType);
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(cmd);
            List<GWStockPrice> lstData = new List<GWStockPrice>();
            while (rd.Read())
            {
                GWStockPrice data = new GWStockPrice();
                data.BasicPrice = rd["prior_close_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["prior_close_price"]);
                data.CeilingPrice = rd["ceiling_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["ceiling_price"]);
                data.ClosePrice = rd["prior_close_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["prior_close_price"]);
                data.FloorPrice = rd["floor_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["floor_price"]);
                //data.OpenPrice = rd["open_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["open_price"]);
                data.StockCode = rd["security_symbol"] == DBNull.Value ? "" : rd["security_symbol"].ToString();
                data.TradingDate = rd["last_modified"] == DBNull.Value ? "" : rd["last_modified"].ToString();
                lstData.Add(data);
            }
            rd.Close();
            return lstData.ToArray();
        }
        public static GWStockPrice[] getStockPrices()
        {
            string sql = "select case when last_date_su >= last_date_ss or last_date_ss is null then last_date_su else last_date_ss end as last_modified, " +
                        "security_symbol, security_name, par_value, security_type, board_lot, " +
                        "case when last_date_su >= last_date_ss or last_date_ss is null then ceiling_price_su else ceiling_price_ss end as ceiling_price, " +
                        "case when last_date_su >= last_date_ss or last_date_ss is null then floor_price_su else floor_price_ss end as floor_price, " +
                        "case when last_date_su >= last_date_ss or last_date_ss is null then last_sale_price_su else prior_close_price_ss end as prior_close_price " +
                    "from ( " +
                        "select a.last_modified last_date_ss, b.last_modified last_date_su, " +
                            "ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, isnull(b.board_lot,a.board_lot) as board_lot,  " +
                            "a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, " +
                            "b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su	 " +
                        "from ( " +
                            "select * from (select dense_rank()  " +
                                "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum " +
                                ", * from hose_su) X  " +
                            "where RankNum = 1 " +
                        ") b left outer join ( " +
                            "select * from (select dense_rank()  " +
                                "over(partition by security_number order by security_number, last_modified desc) as RankNum " +
                                ", * from hose_ss) X  " +
                            "where RankNum = 1 " +
                        ") a ON a.security_number = b.security_number_new " +
                //"and b.security_symbol = 'vis' "+
                    ") F ";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(CommandType.Text,sql);
            List<GWStockPrice> lstData = new List<GWStockPrice>();
            while (rd.Read())
            {
                GWStockPrice data = new GWStockPrice();
                data.BasicPrice = rd["prior_close_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["prior_close_price"]);
                data.CeilingPrice = rd["ceiling_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["ceiling_price"]);
                data.ClosePrice = rd["prior_close_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["prior_close_price"]);
                data.FloorPrice = rd["floor_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["floor_price"]);
                //data.OpenPrice = rd["open_price"] == DBNull.Value ? 0 : Convert.ToDouble(rd["open_price"]);
                data.StockCode = rd["security_symbol"] == DBNull.Value ? "" : rd["security_symbol"].ToString();
                data.TradingDate = rd["last_modified"] == DBNull.Value ? "" : rd["last_modified"].ToString();
                lstData.Add(data);
            }
            rd.Close();
            return lstData.ToArray();
        }                       
    }
    public class GWTradingDay
    {
        public string LastTradingDate { get; set; }
        public int LastDateCount { get; set; }
    }
    public class GWMarket
    {
        ///////////////////////////////////////////////////////
        //-------------- Khong can gan DATABASE -------------//
        ///////////////////////////////////////////////////////
        public static string getMarketStatusHOSE()
        {
            string sql = "select top 1 SYSTEM_CONTROL_CODE FROM HOSE_SC order by ID desc";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            object o = DbHOGW.ExecuteScalar(CommandType.Text, sql);
            if (o == null) return "";
            return o.ToString();
        }
        public static string getMarketStatusWithDate()
        {
            string sql = "select top 1 convert(varchar,last_modified,103) + ' : ' + SYSTEM_CONTROL_CODE " +
                            "as MarketStatus FROM HOSE_SC order by ID desc";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            object o = DbHOGW.ExecuteScalar(CommandType.Text, sql);
            if (o == null) return "";
            return o.ToString();
        }
        public static string getLastTradingDaySC()
        {
            string sql = "select top 1 convert(varchar,last_modified,103) as LastTradingDate from HOSE_SC " +
                            "order by last_modified desc";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            object o = DbHOGW.ExecuteScalar(CommandType.Text, sql);
            if (o == null) return "";
            return o.ToString();
        }
        //Lay cac gia tri ngay gan nhat trong bang SU va count cua chung        
        public static GWTradingDay[] getLastTradingDaysSU()
        {
            string sql = "SELECT convert(varchar,last_modified,103) as LastTradingDate, count(*) as LastDateCount from ( " +
                            "select * from (select dense_rank() " +
                                "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum " +
                                ", * from hose_su) X where RankNum = 1 " +
                        ") A group by convert(varchar,last_modified,103)";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(CommandType.Text, sql);
            List<GWTradingDay> lstDates = new List<GWTradingDay>();
            while(rd.Read())
            {
                GWTradingDay date = new GWTradingDay();
                date.LastDateCount = rd["LastDateCount"] == DBNull.Value ? 0 : Convert.ToInt32(rd["LastDateCount"]);
                date.LastTradingDate = rd["LastTradingDate"] == DBNull.Value ? "" : rd["LastTradingDate"].ToString();
                lstDates.Add(date);
            }
            rd.Close();
            return lstDates.ToArray();
        }
        //Chi lay 1 ngay gan nhat trong SU
        public static string getLastTradingDaySU()
        {
            string sql = "SELECT convert(varchar,max(last_modified),103) as LastTradingDate from ( " +
                            "select * from (select dense_rank() " +
                                "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum " +
                                ", * from hose_su) X where RankNum = 1 " +
                        ") A";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            object o = DbHOGW.ExecuteScalar(CommandType.Text, sql);
            if (o == null) return "";
            return o.ToString();
        }
        //Trang thai cua Broker, A = halted, null = khong halt
        //bi halt matching <> halt PT (2 cai doc lap)
        //co truong firm de chi ra cong ty nao bi halt
        static public DataTable getBrokerStatusTable()
        {
            string sql = "select * from (select dense_rank() over(partition by firm order by ID desc) as RankNum,* from hose_bs) A where RankNum = 1";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DataSet ds = DbHOGW.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }
        static public GWBrokerStatus[] getBrokerStatusArray()
        {
            string sql = "select * from (select dense_rank() over(partition by firm order by ID desc) as RankNum,* from hose_bs) A where RankNum = 1";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(CommandType.Text, sql);
            List<GWBrokerStatus> lstBS = new List<GWBrokerStatus>();
            while (rd.Read())
            {
                GWBrokerStatus bs = new GWBrokerStatus();
                bs.FirmID = DBNull.Value == rd["FIRM"] ? 0 : Convert.ToInt32(rd["FIRM"]);
                bs.MatchingHalt = DBNull.Value == rd["AUTOMATCH_HALT_FLAG"] ? "" : rd["AUTOMATCH_HALT_FLAG"].ToString();
                bs.PTHalt = DBNull.Value == rd["PT_HALT_FLAG"] ? "" : rd["PT_HALT_FLAG"].ToString();
                lstBS.Add(bs);
            }
            rd.Close();
            return lstBS.ToArray();
        }
        static public GWBrokerStatus getBrokerStatus(int firmID)
        {
            string sql = "select * from (select dense_rank() over(partition by firm order by ID desc) "+ 
            "as RankNum,* from hose_bs) A where RankNum = 1 and firm = @firmid";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@firmid", DbType.Int32, firmID);
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(cmd);
            GWBrokerStatus bs = new GWBrokerStatus();
            bs.FirmID = firmID;
            while (rd.Read())
            {
                bs.MatchingHalt = DBNull.Value == rd["AUTOMATCH_HALT_FLAG"] ? "" : rd["AUTOMATCH_HALT_FLAG"].ToString();
                bs.PTHalt = DBNull.Value == rd["PT_HALT_FLAG"] ? "" : rd["PT_HALT_FLAG"].ToString();
            }
            rd.Close();
            return bs;
        }

        //Trang thai cua Broker, A = halted, null = khong halt
        //bi halt matching <> halt PT (2 cai doc lap)
        //co truong firm de chi ra cong ty nao bi halt
        static public DataTable getTraderStatusTable()
        {
            string sql = "select * from (select dense_rank() over(partition by trader_id order by ID desc) " +
                            "as RankNum,* from hose_tc) A where RankNum = 1";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DataSet ds = DbHOGW.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }
        static public GWTraderStatus[] getTraderStatusArray()
        {
            string sql = "select * from (select dense_rank() over(partition by trader_id order by ID desc) "+
                            "as RankNum,* from hose_tc) A where RankNum = 1";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(CommandType.Text, sql);
            List<GWTraderStatus> lstTC = new List<GWTraderStatus>();
            while (rd.Read())
            {
                GWTraderStatus tc = new GWTraderStatus();
                tc.FirmID = DBNull.Value == rd["FIRM"] ? 0 : Convert.ToInt32(rd["FIRM"]);
                tc.TraderID = DBNull.Value == rd["TRADER_ID"] ? 0 : Convert.ToInt32(rd["TRADER_ID"]);
                tc.TraderStatus = DBNull.Value == rd["TRADER_STATUS"] ? "" : rd["TRADER_STATUS"].ToString();
                lstTC.Add(tc);
            }
            rd.Close();
            return lstTC.ToArray();
        }
        static public GWTraderStatus getTraderStatus(int traderid)
        {
            string sql = "select * from (select dense_rank() over(partition by trader_id order by ID desc) "+
                            "as RankNum,* from hose_tc) A where RankNum = 1 and trader_id = @trader_id";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@trader_id", DbType.Int32, traderid);
            SqlDataReader rd = (SqlDataReader)DbHOGW.ExecuteReader(cmd);
            GWTraderStatus tc = new GWTraderStatus();
            tc.TraderID = traderid;
            while (rd.Read())
            {
                tc.FirmID = DBNull.Value == rd["FIRM"] ? 0 : Convert.ToInt32(rd["FIRM"]);                
                tc.TraderStatus = DBNull.Value == rd["TRADER_STATUS"] ? "" : rd["TRADER_STATUS"].ToString();
            }
            rd.Close();
            return tc;
        }

        ///////////////////////////////////////////////////////
        //-------------- Phai truyen DATABASE ---------------//
        ///////////////////////////////////////////////////////
        public static string getMarketStatusHOSE(Database db)
        {
            string sql = "select top 1 SYSTEM_CONTROL_CODE FROM HOSE_SC order by ID desc";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            object o = db.ExecuteScalar(CommandType.Text, sql);
            if (o == null) return "";
            return o.ToString();
        }
        public static string getMarketStatusWithDate(Database db)
        {
            string sql = "select top 1 convert(varchar,last_modified,103) + ' : ' + SYSTEM_CONTROL_CODE "+
                            "as MarketStatus FROM HOSE_SC order by ID desc";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            object o = db.ExecuteScalar(CommandType.Text, sql);
            if (o == null) return "";
            return o.ToString();
        }
        public static string getLastTradingDaySC(Database db)
        {
            string sql = "select top 1 convert(varchar,last_modified,103) as LastTradingDate from HOSE_SC "+
                            "order by last_modified desc";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            object o = db.ExecuteScalar(CommandType.Text, sql);
            if (o == null) return "";
            return o.ToString();
        }
        //Lay cac gia tri ngay gan nhat trong bang SU va count cua chung
        public static DataTable getLastTradingDaysSU(Database db)
        {
            string sql = "SELECT convert(varchar,last_modified,103) as LastTradingDate, count(*) as LastDateCount from ( "+
                            "select * from (select dense_rank() "+
                                "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum "+
                                ", * from hose_su) X where RankNum = 1 "+
                        ") A group by convert(varchar,last_modified,103)";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
        //Chi lay 1 ngay gan nhat trong SU
        public static string getLastTradingDaySU(Database db)
        {
            string sql = "SELECT convert(varchar,max(last_modified),103) as LastTradingDate from ( " +
                            "select * from (select dense_rank() " +
                                "over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum " +
                                ", * from hose_su) X where RankNum = 1 " +
                        ") A";
            object o = db.ExecuteScalar(CommandType.Text, sql);
            if (o == null) return "";
            return o.ToString();
        }
        //Trang thai cua Broker, A = halted, null = khong halt
        //bi halt matching <> halt PT (2 cai doc lap)
        //co truong firm de chi ra cong ty nao bi halt
        static public DataTable getBrokerStatusTable(Database db)
        {
            string sql = "select * from (select dense_rank() over(partition by firm order by ID desc) as RankNum,* from hose_bs) A where RankNum = 1";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }
        static public GWBrokerStatus[] getBrokerStatusArray(Database db)
        {
            string sql = "select * from (select dense_rank() over(partition by firm order by ID desc) as RankNum,* from hose_bs) A where RankNum = 1";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            SqlDataReader rd = (SqlDataReader)db.ExecuteReader(CommandType.Text, sql);
            List<GWBrokerStatus> lstBS = new List<GWBrokerStatus>();
            while (rd.Read())
            {
                GWBrokerStatus bs = new GWBrokerStatus();
                bs.FirmID = DBNull.Value == rd["FIRM"] ? 0 : Convert.ToInt32(rd["FIRM"]);
                bs.MatchingHalt = DBNull.Value == rd["AUTOMATCH_HALT_FLAG"] ? "" : rd["AUTOMATCH_HALT_FLAG"].ToString();
                bs.PTHalt = DBNull.Value == rd["PT_HALT_FLAG"] ? "" : rd["PT_HALT_FLAG"].ToString();
                lstBS.Add(bs);
            }
            rd.Close();
            return lstBS.ToArray();
        }
        static public GWBrokerStatus getBrokerStatus(Database db, int firmID)
        {
            string sql = "select * from (select dense_rank() over(partition by firm order by ID desc) " +
            "as RankNum,* from hose_bs) A where RankNum = 1 and firm = @firmid";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@firmid", DbType.Int32, firmID);
            SqlDataReader rd = (SqlDataReader)db.ExecuteReader(cmd);
            GWBrokerStatus bs = null;
            
            while (rd.Read())
            {
                bs = new GWBrokerStatus();
                bs.FirmID = firmID;
                bs.MatchingHalt = DBNull.Value == rd["AUTOMATCH_HALT_FLAG"] ? "" : rd["AUTOMATCH_HALT_FLAG"].ToString();
                bs.PTHalt = DBNull.Value == rd["PT_HALT_FLAG"] ? "" : rd["PT_HALT_FLAG"].ToString();
            }
            rd.Close();
            return bs;
        }

        //Trang thai cua Broker, A = halted, null = khong halt
        //bi halt matching <> halt PT (2 cai doc lap)
        //co truong firm de chi ra cong ty nao bi halt
        static public DataTable getTraderStatusTable(Database db)
        {
            string sql = "select * from (select dense_rank() over(partition by trader_id order by ID desc) " +
                            "as RankNum,* from hose_tc) A where RankNum = 1";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }
        static public GWTraderStatus[] getTraderStatusArray(Database db)
        {
            string sql = "select * from (select dense_rank() over(partition by trader_id order by ID desc) " +
                            "as RankNum,* from hose_tc) A where RankNum = 1";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            SqlDataReader rd = (SqlDataReader)db.ExecuteReader(CommandType.Text, sql);
            List<GWTraderStatus> lstTC = new List<GWTraderStatus>();
            while (rd.Read())
            {
                GWTraderStatus tc = new GWTraderStatus();
                tc.FirmID = DBNull.Value == rd["FIRM"] ? 0 : Convert.ToInt32(rd["FIRM"]);
                tc.TraderID = DBNull.Value == rd["TRADER_ID"] ? 0 : Convert.ToInt32(rd["TRADER_ID"]);
                tc.TraderStatus = DBNull.Value == rd["TRADER_STATUS"] ? "" : rd["TRADER_STATUS"].ToString();
                lstTC.Add(tc);
            }
            rd.Close();
            return lstTC.ToArray();
        }
        static public GWTraderStatus getTraderStatus(Database db, int traderid)
        {
            string sql = "select * from (select dense_rank() over(partition by trader_id order by ID desc) " +
                            "as RankNum,* from hose_tc) A where RankNum = 1 and trader_id = @trader_id";
            //Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@trader_id", DbType.Int32, traderid);
            SqlDataReader rd = (SqlDataReader)db.ExecuteReader(cmd);
            GWTraderStatus tc = null;
            
            while (rd.Read())
            {
                tc = new GWTraderStatus();
                tc.TraderID = traderid;
                tc.FirmID = DBNull.Value == rd["FIRM"] ? 0 : Convert.ToInt32(rd["FIRM"]);
                tc.TraderStatus = DBNull.Value == rd["TRADER_STATUS"] ? "" : rd["TRADER_STATUS"].ToString();
            }
            rd.Close();
            return tc;
        }

    }
}

