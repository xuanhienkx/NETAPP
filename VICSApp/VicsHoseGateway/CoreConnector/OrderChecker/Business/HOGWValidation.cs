using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace OrderChecker.Business
{
    public class HOGWValidation
    {
        private Database dbHOGW;
        private Dictionary<string, StockInfo> dictStockInfo;
        private Dictionary<string, StockInfo> dictStockInfoFromCore;
        private bool isLoadInfo;

        public HOGWValidation(Database pDBHOGW)
        {
            string str;
            this.dictStockInfo = new Dictionary<string, StockInfo>();
            this.dictStockInfoFromCore = new Dictionary<string, StockInfo>();
            this.dbHOGW = pDBHOGW;
            this.isLoadInfo = this.LoadStockInfo2Dict(out str);
        }

        public HOGWValidOutput CheckOrder(HOGWValidInput orderIn)
        {
            int num;
            HOGWValidOutput output = new HOGWValidOutput();
            if (!this.isLoadInfo)
            {
                output.ErrCode = 10;
                output.ErrDesc = "NO STOCK INFORMATION LOADED.";
                output.IsOK = false;
                return output;
            }
            StockInfo info = null;
            if (this.dictStockInfo.ContainsKey(orderIn.StockCode))
            {
                info = this.dictStockInfo[orderIn.StockCode];
            }
            if (info == null)
            {
                output.ErrCode = 11;
                output.ErrDesc = "NO INFORMATION from this stock.";
                output.IsOK = false;
                return output;
            }
            if (orderIn.Price < 10M)
            {
                num = 10;
            }
            else if (orderIn.Price >= 50M)
            {
                num = 100;
            }
            else
            {
                num = 50;
            }
            if ((!string.IsNullOrEmpty(info.Halt) && (info.Halt.Trim().Length > 0)) && (info.Halt.Trim() == "H"))
            {
                output.ErrCode = 0x4bb;
                output.ErrDesc = "Halt in both AOM and PT!";
                output.IsOK = false;
                return output;
            }
            if ((!string.IsNullOrEmpty(info.Suspension) && !string.IsNullOrEmpty(info.Delist)) && ((info.Suspension.Trim().Length > 0) || (info.Delist.Trim().Length > 0)))
            {
                output.ErrCode = 0x4bc;
                output.ErrDesc = "Suspension!";
                output.IsOK = false;
                return output;
            }
            if ((!string.IsNullOrEmpty(info.Suspension) && !string.IsNullOrEmpty(info.Delist)) && ((info.Suspension.Trim().Length > 0) || (info.Delist.Trim().Length > 0)))
            {
                output.ErrCode = 0x4bd;
                output.ErrDesc = "Delist!";
                output.IsOK = false;
                return output;
            }
            if ((orderIn.OrderType == "X") || (orderIn.OrderType == "C"))
            {
                if (orderIn.MarketStatus != "O")
                {
                    output.ErrCode = 43;
                    output.ErrDesc = orderIn.MarketStatus;
                    output.IsOK = false;
                    return output;
                }
                output.ErrCode = 0;
                output.ErrDesc = "OK";
                output.IsOK = true;
                return output;
            }
            int num2 = ((int)(orderIn.Price * 1000M)) % num;
            if ((info.StockType != "D") && (num2 >= 1))
            {
                output.ErrCode = 13;
                output.ErrDesc = "Price is NOT in correct spread.";
                output.IsOK = false;
                return output;
            }
            if (orderIn.Volume != orderIn.PublishedVolume)
            {
                output.ErrCode = 15;
                output.ErrDesc = "Volume # published volume.";
                output.IsOK = false;
                return output;
            }
            if (this.IsCustomerEnterContraSideOrder(this.dbHOGW, orderIn.CustomerID, orderIn.StockCode, orderIn.OrderSide))
            {
                output.ErrCode = 42;
                string str = orderIn.OrderSide == "B" ? "S" : "B";
                output.ErrDesc = "Customer " + orderIn.CustomerID + " already has incompleted entered order with stock=" + orderIn.StockCode + ", side=" + str;
                output.IsOK = false;
                return output;
            }
            if (orderIn.PTOrderType == 0)
            {
                if ((!string.IsNullOrEmpty(info.Halt) && (info.Halt.Trim().Length > 0)) && (info.Halt.Trim() == "A"))
                {
                    output.ErrCode = 0x2f4f;
                    output.ErrDesc = "Halt in AOM transaction!";
                    output.IsOK = false;
                    return output;
                }
                if (info.StockType == "D")
                {
                    output.ErrCode = 0x6f;
                    output.ErrDesc = "BONDS are NOT allowed in MATCHING orders!";
                    output.IsOK = false;
                    return output;
                }
                if (info.SecurityNumber == info.SecurityNumberOld)
                {
                    if (orderIn.Price > info.PriceCeiling)
                    {
                        output.ErrCode = 0x79;
                        output.ErrDesc = "Price > CEILING price!";
                        output.IsOK = false;
                        return output;
                    }
                    if (orderIn.Price < info.PriceFloor)
                    {
                        output.ErrCode = 0x7a;
                        output.ErrDesc = "Price < FLOOR price).";
                        output.IsOK = false;
                        return output;
                    }
                }
                if ((orderIn.Volume % ((double)info.BoardLot)) != 0.0)
                {
                    output.ErrCode = 14;
                    output.ErrDesc = "Volume is NOT in correct board lot.";
                    output.IsOK = false;
                    return output;
                }
                bool flag = false;
                int.Parse(DateTime.Now.ToString("HHmm"));
                if ((((orderIn.MarketStatus != null) && (orderIn.MarketStatus != string.Empty)) && ((orderIn.MarketStatus != " ") && (orderIn.MarketStatus != ""))) && (((orderIn.MarketStatus != "O") && (orderIn.MarketStatus != "P")) && (orderIn.MarketStatus != "A")))
                {
                    flag = true;
                    output.ErrCode = 0xe7;
                    output.ErrDesc = "Matching order must be in P/O/A session.";
                }
                else if ((orderIn.PriceType == "ATO") && (((orderIn.MarketStatus == "O") || (orderIn.MarketStatus == "A")) || (orderIn.MarketStatus == "C")))
                {
                    flag = true;
                    output.ErrCode = 0x8a3;
                    output.ErrDesc = "ATO does NOT match session. Cancelled.";
                }
                else if ((((orderIn.PriceType == "ATO") && (orderIn.MarketStatus != "P")) && ((orderIn.MarketStatus != null) && (orderIn.MarketStatus != string.Empty))) && ((orderIn.MarketStatus != " ") && (orderIn.MarketStatus != "")))
                {
                    flag = true;
                    output.ErrCode = 0x8a4;
                    output.ErrDesc = "ATO does NOT match session. Waiting.";
                }
                else if ((orderIn.PriceType == "ATC") && (orderIn.MarketStatus != "A"))
                {
                    flag = true;
                    output.ErrCode = 0x8ae;
                    output.ErrDesc = "ATC does NOT match session. Wait";
                }
                else if ((orderIn.PriceType == "MP") && ((orderIn.MarketStatus == "A") || (orderIn.MarketStatus == "C")))
                {
                    flag = true;
                    output.ErrCode = 0x8b6;
                    output.ErrDesc = "MP does NOT match session. Cancelled";
                }
                else if ((((orderIn.PriceType == "MP") && (orderIn.MarketStatus != "O")) && ((orderIn.MarketStatus != null) && (orderIn.MarketStatus != string.Empty))) && ((orderIn.MarketStatus != " ") && (orderIn.MarketStatus != "")))
                {
                    flag = true;
                    output.ErrCode = 0x8b7;
                    output.ErrDesc = "MP does NOT match session. Waiting.";
                }
                if (flag)
                {
                    output.IsOK = false;
                    return output;
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(info.Halt) && (info.Halt.Trim().Length > 0)) && (info.Halt.Trim() == "P"))
                {
                    output.ErrCode = 0x2f50;
                    output.ErrDesc = "Halt in PT transaction!";
                    output.IsOK = false;
                    return output;
                }
                if (info.SecurityNumber != info.SecurityNumberOld)
                {
                    output.ErrCode = 0x1f;
                    output.ErrDesc = "Newly-listed stocks are not allowed in PT deals in the first day!";
                    output.IsOK = false;
                    return output;
                }
                if (orderIn.Price > info.PriceCeiling)
                {
                    output.ErrCode = 0x20;
                    output.ErrDesc = "Price > CEILING price!";
                    output.IsOK = false;
                    return output;
                }
                if (orderIn.Price < info.PriceFloor)
                {
                    output.ErrCode = 0x21;
                    output.ErrDesc = "Price < FLOOR price).";
                    output.IsOK = false;
                    return output;
                }
                //Fixed khoi luong toi da 500000 theo cv 840 22/06/2016
                if (Convert.ToDouble(orderIn.Volume) > 500000.0 && orderIn.OrderType != "PT")
                {
                    output.IsOK = false;
                    output.ErrCode = 0x3e7;
                    output.ErrDesc = "Matching Order Volume > 500000";
                }
                if ((info.StockType != "D") && (orderIn.Volume < 20000.0) && orderIn.OrderType == "PT")
                {
                    output.ErrCode = 0x23;
                    output.ErrDesc = "PT Deals for Stock must have volume >= 20000.";
                    output.IsOK = false;
                    return output;
                }
                if (orderIn.PTOrderType != 3)
                {
                    int pTOrderType = orderIn.PTOrderType;
                }
            }
            if (orderIn.PTOrderType != 3)
            {
                if (orderIn.CustomerID[3] == 'P')
                {
                    output.PCFlag = "P";
                }
                else if (((orderIn.CustomerID[3] == 'A') || (orderIn.CustomerID[3] == 'B')) || ((orderIn.CustomerID[3] == 'a') || (orderIn.CustomerID[3] == 'b')))
                {
                    output.PCFlag = "M";
                }
                else if (((orderIn.CustomerID[3] == 'F') || (orderIn.CustomerID[3] == 'E')) || ((orderIn.CustomerID[3] == 'f') || (orderIn.CustomerID[3] == 'e')))
                {
                    output.PCFlag = "F";
                }
                else
                {
                    output.PCFlag = "C";
                }
                if (((orderIn.PTOrderType != 4) && (output.PCFlag == "F")) && ((orderIn.Volume > info.RoomCurrent) && (orderIn.OrderSide == "B")))
                {
                    output.IsOK = false;
                    output.ErrCode = 0x29;
                    output.ErrDesc = "VOLUME > current ROOM.";
                    return output;
                }
            }
            output.StockType = info.StockType;
            output.ErrCode = 0;
            output.ErrDesc = "OK";
            output.IsOK = true;
            return output;
        }

        public MarketInfo getCurrentMarketInfo(Database db)
        {
            try
            {
                string commandText = "SELECT top 1 [LAST_MODIFIED],[SYSTEM_CONTROL_CODE],[TIMESTAMP] FROM [HOSE_SC] order by ID desc";
                SqlDataReader reader = (SqlDataReader)db.ExecuteReader(CommandType.Text, commandText);
                MarketInfo info = new MarketInfo();
                while (reader.Read())
                {
                    info.LastModified = Convert.ToDateTime(reader["last_modified"]);
                    info.SystemControlCode = reader["system_control_code"].ToString();
                    info.TimeStamp = reader["timestamp"].ToString();
                }
                reader.Close();
                return info;
            }
            catch
            {
                return null;
            }
        }

        public bool IsCustomerEnterContraSideOrder(Database db, string customerID, string stockCode, string side)
        {
            try
            {
                string str = (side == "S") ? "BUYER_ORDER_NUMBER" : "SELLER_ORDER_NUMBER";
                string query = string.Format(
                                            @"SELECT COUNT(*) FROM dbo.HOGW_1I i LEFT JOIN ( SELECT SUM(VOLUME) AS vol, ORDER_NUMBER  
                                            FROM (SELECT VOLUME, ORDER_NUMBER FROM dbo.HOGW_2E  
                                            UNION ALL  
                                            SELECT VOLUME, {0} from HOGW_2I) x GROUP BY x.ORDER_NUMBER )
                                            e ON i.ORDER_NUMBER = e.ORDER_NUMBER 
                                            WHERE i.VOLUME <> ISNULL(e.vol, 0) AND i.SIDE <> @side AND i.CLIENT_ID = @cus AND i.SECURITY_SYMBOL = @stock  
                                            AND NOT EXISTS(SELECT * FROM dbo.HOGW_2C WHERE ORDER_NUMBER = i.ORDER_NUMBER)",
                                            str);
                DbCommand sqlStringCommand = db.GetSqlStringCommand(query);
                db.AddInParameter(sqlStringCommand, "@cus", DbType.String, customerID);
                db.AddInParameter(sqlStringCommand, "@stock", DbType.String, stockCode);
                db.AddInParameter(sqlStringCommand, "@side", DbType.String, side);
                object obj2 = db.ExecuteScalar(sqlStringCommand);
                const string str2 = @" select top 1 SYSTEM_CONTROL_CODE from HOSE_SC order by ID desc ";
                string tradingStarus = "O";
                var hosesc = db.ExecuteScalar(CommandType.Text, str2);
                if (hosesc != null)
                {
                    tradingStarus = (string)hosesc;
                }
                int num = 0;
                if (obj2 != null)
                {
                    num = (int)obj2;
                }
                return (num > 0 && tradingStarus != "O");
            }
            catch
            {
                return false;
            }
        }

        public bool IsMarketAvailable(string marketStatus, bool isPT, bool isBond)
        {
            if (isPT)
            {
                if (((!(marketStatus == "") && !(marketStatus == " ")) && ((marketStatus != null) && !(marketStatus == "P"))) && (!(marketStatus == "O") && !(marketStatus == "A")))
                {
                    return (marketStatus == "C");
                }
                return true;
            }
            if (((!(marketStatus == "") && !(marketStatus == " ")) && ((marketStatus != null) && !(marketStatus == "P"))) && !(marketStatus == "O"))
            {
                return (marketStatus == "A");
            }
            return true;
        }

        private bool LoadStockInfo2Dict(out string err)
        {
            err = "";
            try
            {
                if (this.dbHOGW == null)
                {
                    err = "Database HOGW in HOGWValidation instance is NULL";
                    return false;
                }
                string commandText = "select y.*, z.TOTAL_ROOM, z.CURRENT_ROOM  from ( select case when last_date_su >= last_date_ss or last_date_ss is null then last_date_su else last_date_ss end as last_modified, security_symbol, security_name, par_value, security_type, board_lot,  case when last_date_su >= last_date_ss or last_date_ss is null then ceiling_price_su else ceiling_price_ss end as ceiling_price, case when last_date_su >= last_date_ss or last_date_ss is null then floor_price_su else floor_price_ss end as floor_price, case when last_date_su >= last_date_ss or last_date_ss is null then last_sale_price_su else prior_close_price_ss end as prior_close_price, case when last_date_su >= last_date_ss or last_date_ss is null then halt_su else halt_ss end as halt_resume_flag, case when last_date_su >= last_date_ss or last_date_ss is null then suspension_su else suspension_ss end as suspension, case when last_date_su >= last_date_ss or last_date_ss is null then split_su else split_ss end as split, case when last_date_su >= last_date_ss or last_date_ss is null then delist_su else delist_ss end as delist, security_number_old, security_number_new, market_id from ( select a.last_modified last_date_ss, b.last_modified last_date_su, ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, ISNULL(B.board_lot,A.BOARD_LOT) AS BOARD_LOT,  a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su, a.HALT_RESUME_FLAG as halt_ss, a.suspension as suspension_ss, a.split as split_ss, a.delist as delist_ss, b.HALT_RESUME_FLAG as halt_su, b.suspension as suspension_su, b.split as split_su, b.delist as delist_su, b.security_number_old, b.security_number_new, b.market_id from (select * from (select dense_rank()  over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum , * from hose_su) X where RankNum = 1 ) b LEFT OUTER JOIN (select * from (select dense_rank()  over(partition by security_number order by security_number, last_modified desc) as RankNum , * from hose_ss) X where RankNum = 1 ) a ON a.security_number = b.security_number_new ) X ) Y left outer join ( select * from (select dense_rank()  over(partition by security_number order by security_number, last_modified desc) as RankNum, * from hose_tr) X where RankNum = 1 ) Z on Y.security_number_new = Z.security_number";
                SqlDataReader reader = (SqlDataReader)this.dbHOGW.ExecuteReader(CommandType.Text, commandText);
                while (reader.Read())
                {
                    string str2 = reader["security_type"].ToString();
                    string key = reader["security_symbol"].ToString().Trim();
                    int num = 0;
                    switch (str2)
                    {
                        case "S": num = 1; break;
                        case "D": num = 2; break;
                        case "U": num = 3; break;
                        case "W": num = 5; break;
                        case "E": num = 6; break;
                    }
                    StockInfo info = new StockInfo
                    {
                        StockCode = key,
                        StockType = str2,
                        TradingDate = DateTime.Now,
                        PriceBasic = (reader["prior_close_price"] == DBNull.Value) ? 0M : Convert.ToDecimal(reader["prior_close_price"]),
                        PriceCeiling = (reader["CEILING_PRICE"] == DBNull.Value) ? 0M : Convert.ToDecimal(reader["CEILING_PRICE"]),
                        PriceFloor = (reader["floor_price"] == DBNull.Value) ? 0M : Convert.ToDecimal(reader["floor_price"])
                    };
                    if (info.StockType == "E"|| info.StockType == "W")
                    {
                        info.PriceStep = 10;
                    }
                    else  if (info.PriceBasic >= 5000M)
                    {
                        info.PriceStep = 100;
                    }
                    else if (info.PriceBasic < 1000M)
                    {
                        info.PriceStep = 10;
                    }
                    else
                    {
                        info.PriceStep = 50;
                    }
                    info.SecurityNumber = Convert.ToInt32(reader["security_number_new"]);
                    info.SecurityNumberOld = Convert.ToInt32(reader["security_number_old"]);
                    info.RoomCurrent = (reader["current_room"] == DBNull.Value) ? -1L : Convert.ToInt64(reader["current_room"]);
                    info.MarketCode = reader["market_id"].ToString();
                    info.Suspension = reader["suspension"].ToString();
                    info.Halt = reader["halt_resume_flag"].ToString();
                    info.Delist = reader["delist"].ToString();
                    info.Split = reader["split"].ToString();
                    info.StockName = reader["security_name"].ToString();
                    info.Par = (reader["par_value"] == DBNull.Value) ? 0M : Convert.ToDecimal(reader["par_value"]);
                    info.VolumeLimit = num;
                    info.BoardLot = (reader["board_lot"] == DBNull.Value) ? 0L : Convert.ToInt64(reader["board_lot"]);
                    if (!this.dictStockInfo.ContainsKey(key))
                    {
                        this.dictStockInfo.Add(key, info);
                    }
                }
                reader.Close();
                return true;
            }
            catch (Exception exception)
            {
                err = exception.Message;
                return false;
            }
        }

        private bool LoadStockInfoFromCore2Dict(out string err)
        {
            err = "";
            try
            {
                Database database = DatabaseFactory.CreateDatabase("ConnStrCore");
                string commandText = "select A.*, B.BoardLot, B.Name from ( select a.*, b.StepValue from (select a.BasicPrice, a.FloorPrice, a.CeilingPrice, b.StockCode, b.BoardType, b.StockType from StockPrice a inner join GLStockCode b on a.StockCode = b.StockCode where b.BoardType = 'M') A inner join StepPrice b on a.BoardType = B.BoardType where a.BasicPrice*1000 between b.FromPrice and b.ToPrice ) A inner join TradingBoard B on A.BoardType = B.BoardType ";
                SqlDataReader reader = (SqlDataReader)database.ExecuteReader(CommandType.Text, commandText);
                while (reader.Read())
                {
                    string str2 = reader["StockType"].ToString();
                    string key = reader["StockCode"].ToString().Trim();
                    int num = 0;
                    switch (str2)
                    {
                        case "S":
                            num = 1;
                            break;

                        case "D":
                            num = 2;
                            break;

                        case "U":
                            num = 3;
                            break;
                        case "W":
                            num = 5;
                            break;
                        case "E":
                            num = 6;
                            break;
                    }
                    StockInfo info = new StockInfo
                    {
                        StockCode = key,
                        StockType = reader["StockType"].ToString(),
                        TradingDate = DateTime.Now,
                        PriceBasic = (reader["BasicPrice"] == DBNull.Value) ? 0M : Convert.ToDecimal(reader["BasicPrice"]),
                        PriceCeiling = (reader["CeilingPrice"] == DBNull.Value) ? 0M : Convert.ToDecimal(reader["CeilingPrice"]),
                        PriceFloor = (reader["FloorPrice"] == DBNull.Value) ? 0M : Convert.ToDecimal(reader["FloorPrice"]),
                        PriceStep = (reader["StepValue"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StepValue"]),
                        VolumeLimit = num,
                        BoardLot = (reader["BoardLot"] == DBNull.Value) ? 0L : Convert.ToInt64(reader["BoardLot"])
                    };
                    if (!this.dictStockInfoFromCore.ContainsKey(key))
                    {
                        this.dictStockInfoFromCore.Add(key, info);
                    }
                }
                reader.Close();
                return true;
            }
            catch (Exception exception)
            {
                err = exception.Message;
                return false;
            }
        }

        public bool OrderHasConfirmedByExchange(Database db, int firmID, int orderNumber, int entryDate)
        {
            int num = -1;
            try
            {
                string query = "SELECT count(*) as 2B_COUNT FROM HOGW_2B WHERE FIRM = @FIRM AND ORDER_NUMBER=@ORDERNUMBER AND ORDER_ENTRY_DATE=@ORDER_ENTRY_DATE";
                DbCommand sqlStringCommand = db.GetSqlStringCommand(query);
                db.AddInParameter(sqlStringCommand, "@FIRM", DbType.Int32, firmID);
                db.AddInParameter(sqlStringCommand, "@ORDERNUMBER", DbType.Int32, orderNumber);
                db.AddInParameter(sqlStringCommand, "@ORDER_ENTRY_DATE", DbType.Int32, entryDate);
                object obj2 = db.ExecuteScalar(sqlStringCommand);
                if (obj2 != null)
                {
                    num = (int)obj2;
                }
                else
                {
                    num = -1;
                }
                return (num == 1);
            }
            catch
            {
                return false;
            }
        }

        public bool IsLoadInfo
        {
            get
            {
                return this.isLoadInfo;
            }
        }
    }
}

