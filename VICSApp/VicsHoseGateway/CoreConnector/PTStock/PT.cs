using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Linq;
using System.Data.Linq;
using System.Configuration;

namespace PTStock
{
    public class PT
    {
        static public void ResetPTDealTables()
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            //delete all records and reset identity
            DbPTCore.ExecuteNonQuery(CommandType.StoredProcedure, "DayAction");
        }
        static public void ResetIdentityPTDealTables()
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            //delete all records and reset identity
            try
            {
                DbPTCore.ExecuteNonQuery(CommandType.StoredProcedure, "DayActionIdentity");
            }
            catch (Exception ex)
            {
               
                throw;
            }
            
        }
        //----------------------------------------
        //-------------- LINQ --------------------
        //----------------------------------------

        static private PTDBDataContext dataContext = new PTDBDataContext(ConfigurationManager.ConnectionStrings["ConnStrPTCore"].ConnectionString);
        static public PT_ADVERTISEMENT[] linqGetAdvOrders()
        {
            var db = from c in dataContext.PT_ADVERTISEMENTs select c;
            return db.ToArray();
        }
        static public PT_ADVERTISEMENT_ANNOUCEMENT[] linqGetAdvAnnounces()
        {
            var db = from c in dataContext.PT_ADVERTISEMENT_ANNOUCEMENTs select c;
            return db.ToArray();
        }
        static public PT_ONE_FIRM_DEAL[] linqGet1FirmOrders()
        {
            var db = from c in dataContext.PT_ONE_FIRM_DEALs select c;
            return db.ToArray();
        }
        static public PT_TWO_FIRM_DEAL_SELLER[] linqGetSellerOrders()
        {
            var db = from c in dataContext.PT_TWO_FIRM_DEAL_SELLERs select c;
            return db.ToArray();
        }
        static public PT_TWO_FIRM_DEAL_BUYER[] linqGetBuyerOrders()
        {
            var db = from c in dataContext.PT_TWO_FIRM_DEAL_BUYERs select c;
            return db.ToArray();
        }
        
        //-----------get messages according to message status-----------

        static public PT_ADVERTISEMENT[] linqGetAdvOrders(string messageStatus)
        {
            var db = from c in dataContext.PT_ADVERTISEMENTs where c.MESSAGE_STATUS == messageStatus select c;
            return db.ToArray();
        }
        static public PT_ADVERTISEMENT_ANNOUCEMENT[] linqGetAdvAnnounces(string messageStatus)
        {
            var db = from c in dataContext.PT_ADVERTISEMENT_ANNOUCEMENTs where c.MESSAGE_STATUS == messageStatus select c;
            return db.ToArray();
        }
        static public PT_ONE_FIRM_DEAL[] linqGet1FirmOrders(string messageStatus)
        {
            var db = from c in dataContext.PT_ONE_FIRM_DEALs where c.MESSAGE_STATUS == messageStatus select c;
            return db.ToArray();
        }
        static public PT_TWO_FIRM_DEAL_SELLER[] linqGetSellerOrders(string messageStatus)
        {
            var db = from c in dataContext.PT_TWO_FIRM_DEAL_SELLERs where c.MESSAGE_STATUS == messageStatus select c;
            return db.ToArray();
        }
        static public PT_TWO_FIRM_DEAL_BUYER[] linqGetBuyerOrders(string messageStatus)
        {
            var db = from c in dataContext.PT_TWO_FIRM_DEAL_BUYERs where c.MESSAGE_STATUS == messageStatus select c;
            return db.ToArray();
        }

        //------------- UPDATE MESSAGE STATUS ------------------

        static public int linqUpdateSeller(object DealID, object NewStatus, object ConfirmNumber, object Side)
        {
            try{
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_SELLERs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                sel.CONFIRM_NUMBER = Convert.ToInt32(ConfirmNumber);
                sel.SIDE = Convert.ToChar(Side);
                dataContext.SubmitChanges();
                return 1;
            }catch {return -1;}
        }
        static public int linqUpdateBuyer(object DealID, object NewStatus, object ConfirmNumber)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_BUYERs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                sel.CONFIRM_NUMBER = Convert.ToInt32(ConfirmNumber);
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdate1Firm(object DealID, object NewStatus, object ConfirmNumber)
        {
            try
            {
                var sel = (from row in dataContext.PT_ONE_FIRM_DEALs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                sel.CONFIRM_NUMBER = Convert.ToInt32(ConfirmNumber);
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdateBuyerStatus(object DealID, object NewStatus)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_BUYERs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdateBuyerStatusByUser(object DealID, object NewStatus, object USERNAME)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_BUYERs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                sel.APPROVED_BY = USERNAME.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdateBuyerStatusByConfirmNumber(object CONFIRM_NUMBER, object NewStatus)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_BUYERs where row.CONFIRM_NUMBER == Convert.ToInt32(CONFIRM_NUMBER) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdateSellerStatus(object DealID, object NewStatus)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_SELLERs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }               
        }
        static public int linqUpdateSellerStatusByUser(object DealID, object NewStatus, object USERNAME)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_SELLERs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                sel.APPROVED_BY = USERNAME.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }               
        }
        static public int linqUpdateSellerStatusByConfirmNumber(object CONFIRM_NUMBER, object NewStatus)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_SELLERs where row.CONFIRM_NUMBER == Convert.ToInt32(CONFIRM_NUMBER) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdateBuyerConfirmNumber(object DealID, object ConfirmNumber)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_BUYERs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.CONFIRM_NUMBER = Convert.ToInt32(ConfirmNumber);
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }
        }
        static public int linqUpdateSellerConfirmNumber(object DealID, object ConfirmNumber)
        {
            try
            {
                var sel = (from row in dataContext.PT_TWO_FIRM_DEAL_SELLERs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.CONFIRM_NUMBER = Convert.ToInt32(ConfirmNumber);
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdate1FirmConfirmNumber(object DealID, object ConfirmNumber)
        {
            try
            {
                var sel = (from row in dataContext.PT_ONE_FIRM_DEALs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.CONFIRM_NUMBER = Convert.ToInt32(ConfirmNumber);
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdate1FirmStatus(object DealID, object NewStatus)
        {
            try
            {
                var sel = (from row in dataContext.PT_ONE_FIRM_DEALs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdate1FirmStatusByConfirmNumber(object CONFIRM_NUMBER, object NewStatus)
        {
            try
            {
                var sel = (from row in dataContext.PT_ONE_FIRM_DEALs where row.CONFIRM_NUMBER == Convert.ToInt32(CONFIRM_NUMBER) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdate1FirmStatusByUser(object DealID, object NewStatus, object UserName)
        {
            try
            {
                var sel = (from row in dataContext.PT_ONE_FIRM_DEALs where row.DEAL_ID == Convert.ToInt64(DealID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                sel.APPROVED_BY = UserName.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }            
        }
        static public int linqUpdateAdvStatus(object ID, object NewStatus)
        {
            try
            {
                var sel = (from row in dataContext.PT_ADVERTISEMENTs where row.ID == Convert.ToInt64(ID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }              
        }
        static public int linqUpdateAdvStatusByUser(object ID, object NewStatus, object UserName)
        {
            try
            {
                var sel = (from row in dataContext.PT_ADVERTISEMENTs where row.ID == Convert.ToInt64(ID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                sel.APPROVED_BY = UserName.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }              
        }
        static public int linqUpdateAdvAnnouncementStatus(object ID, object NewStatus)
        {
            try
            {
                var sel = (from row in dataContext.PT_ADVERTISEMENT_ANNOUCEMENTs where row.ID == Convert.ToInt64(ID) select row).Single();
                sel.MESSAGE_STATUS = NewStatus.ToString();
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }              
        }        

        //--------------------  INSERT MESSAGES -------------------

        static public int linqInsertBuyerDeal(object MESSAGE_STATUS, object BUYER_FIRM, object BUYER_TRADER_ID
                        , object SIDE, object SELLER_CONTRA_FIRM, object SELLER_TRADER_ID, object SECURITY_SYMBOL, object VOLUME, object PRICE
                        , object BOARD, object CONFIRM_NUMBER, object RECEIVED_BY, object APPROVED_BY)
        {
            try
            {
                PT_TWO_FIRM_DEAL_BUYER deal = new PT_TWO_FIRM_DEAL_BUYER();
                deal.APPROVED_BY = APPROVED_BY.ToString();
                deal.RECEIVED_BY = RECEIVED_BY.ToString();
                deal.BOARD = Convert.ToChar(BOARD);
                deal.BUYER_FIRM = Convert.ToInt32(BUYER_FIRM);
                deal.BUYER_TRADER_ID = Convert.ToInt32(BUYER_TRADER_ID);
                deal.CONFIRM_NUMBER = Convert.ToInt32(CONFIRM_NUMBER);
                deal.ENTRY_DATE = DateTime.Now;
                deal.MESSAGE_STATUS = MESSAGE_STATUS.ToString();
                deal.MESSAGE_TYPE = "1G";
                deal.PRICE = Convert.ToDecimal(PRICE);
                deal.VOLUME = Convert.ToDecimal(VOLUME);
                deal.SECURITY_SYMBOL = SECURITY_SYMBOL.ToString();
                deal.SELLER_CONTRA_FIRM = Convert.ToInt32(SELLER_CONTRA_FIRM);
                deal.SELLER_TRADER_ID = Convert.ToInt32(SELLER_TRADER_ID);
                deal.SIDE = Convert.ToChar(SIDE);
                dataContext.PT_TWO_FIRM_DEAL_BUYERs.InsertOnSubmit(deal);
                dataContext.SubmitChanges();
                return 1;
            }
            catch { return -1; }
        }
        static public int linqInsertAdvAnnouncement(object MESSAGE_STATUS, object FIRM, object TRADER_ID, object SECURITY_SYMBOL
                , object SIDE, object VOLUME, object PRICE, object BOARD, object TIME, object ADD_CANCEL_FLAG, object CONTACT,
                object RECEIVED_BY, object APPROVED_BY)
        {
            try{
            PT_ADVERTISEMENT_ANNOUCEMENT deal = new PT_ADVERTISEMENT_ANNOUCEMENT();
            deal.APPROVED_BY = APPROVED_BY.ToString();
            deal.RECEIVED_BY = RECEIVED_BY.ToString();
            deal.BOARD = Convert.ToChar(BOARD);
            deal.FIRM = Convert.ToInt32(FIRM);
            deal.TRADER_ID = Convert.ToInt32(TRADER_ID);
            deal.MESSAGE_STATUS = MESSAGE_STATUS.ToString();
            deal.PRICE = Convert.ToDecimal(PRICE);
            deal.VOLUME = Convert.ToDecimal(VOLUME);
            deal.SECURITY_SYMBOL = SECURITY_SYMBOL.ToString();
            deal.SIDE = Convert.ToChar(SIDE);
            deal.CONTACT = CONTACT.ToString();
            deal.ADD_CANCEL_FLAG = Convert.ToChar(ADD_CANCEL_FLAG);
            deal.TIME = TIME.ToString();
            deal.ENTRY_DATE = DateTime.Now;
            deal.MESSAGE_TYPE = "1E";
            dataContext.PT_ADVERTISEMENT_ANNOUCEMENTs.InsertOnSubmit(deal);
            dataContext.SubmitChanges();
            return 1;
            }
            catch { return -1; }
        }
        static public int linqInsertSellerDeal(object MessageStatus, object SellerFirm, object SellerTraderID, object SellerID, object BuyerFirm
                    , object BuyerTraderID, object StockCode
                    , object Price, object BoardType, object BrokerPortfolioVolume, object BrokerClientVolume
                    , object BrokerMutualFundVolume, object BrokerForeignVolume, object ReceivedBy, object ApprovedBy)
        {
            try
            {
            PT_TWO_FIRM_DEAL_SELLER deal = new PT_TWO_FIRM_DEAL_SELLER();
            deal.ENTRY_DATE = DateTime.Now;
            deal.MESSAGE_TYPE = "1G";
            deal.PRICE = Convert.ToDecimal(Price);
            deal.BROKER_CLIENT_VOLUME = Convert.ToDecimal(BrokerClientVolume);
            deal.BROKER_FOREIGN_VOLUME = Convert.ToDecimal(BrokerForeignVolume);
            deal.BROKER_MUTUAL_FUND_VOLUME = Convert.ToDecimal(BrokerMutualFundVolume);
            deal.BROKER_PORTFOLIO_VOLUME = Convert.ToDecimal(BrokerPortfolioVolume);
            deal.MESSAGE_STATUS = MessageStatus.ToString();
            deal.SECURITY_SYMBOL = StockCode.ToString();
            deal.SELLER_FIRM = Convert.ToInt32(SellerFirm);
            deal.SELLER_TRADER_ID = Convert.ToInt32(SellerTraderID);
            deal.SELLER_CLIENT_ID = SellerID.ToString();
            deal.BUYER_FIRM = Convert.ToInt32(BuyerFirm);
            deal.BUYER_TRADER_ID = Convert.ToInt32(BuyerTraderID);
            deal.SELLER_FIRM = Convert.ToInt32(SellerFirm);
            deal.APPROVED_BY = ApprovedBy.ToString();
            deal.RECEIVED_BY = ReceivedBy.ToString();
            deal.BOARD = Convert.ToChar(BoardType);

            dataContext.PT_TWO_FIRM_DEAL_SELLERs.InsertOnSubmit(deal);
            dataContext.SubmitChanges();
            return 1;
            }
            catch { return -1; }
        }
        static public int linqInsert1FirmDeal(object MESSAGE_STATUS, object FIRM, object TRADER_ID, object BUYER_CLIENT_ID
            , object SELLER_CLIENT_ID, object SECURITY_SYMBOL, object PRICE, object BOARD, object BUYER_PORTFOLIO_VOLUME
            , object BUYER_CLIENT_VOLUME, object BUYER_MUTUAL_FUND_VOLUME, object BUYER_FOREIGN_VOLUME
            , object SELLER_PORTFOLIO_VOLUME, object SELLER_CLIENT_VOLUME, object SELLER_MUTUAL_FUND_VOLUME, object SELLER_FOREIGN_VOLUME
            , object RECEIVED_BY, object APPROVED_BY)
        {
            try{
            PT_ONE_FIRM_DEAL deal = new PT_ONE_FIRM_DEAL();
            deal.ENTRY_DATE = DateTime.Now;
            deal.MESSAGE_TYPE = "1F";
            deal.PRICE = Convert.ToDecimal(PRICE);
            deal.BOARD = Convert.ToChar(BOARD);
            deal.BUYER_CLIENT_VOLUME = Convert.ToDecimal(BUYER_CLIENT_VOLUME);
            deal.BUYER_FOREIGN_VOLUME = Convert.ToDecimal(BUYER_FOREIGN_VOLUME);
            deal.BUYER_MUTUAL_FUND_VOLUME = Convert.ToDecimal(BUYER_MUTUAL_FUND_VOLUME);
            deal.BUYER_PORTFOLIO_VOLUME = Convert.ToDecimal(BUYER_PORTFOLIO_VOLUME);
            deal.SELLER_CLIENT_VOLUME = Convert.ToDecimal(SELLER_CLIENT_VOLUME);
            deal.SELLER_FOREIGN_VOLUME = Convert.ToDecimal(SELLER_FOREIGN_VOLUME);
            deal.SELLER_MUTUAL_FUND_VOLUME = Convert.ToDecimal(SELLER_MUTUAL_FUND_VOLUME);
            deal.SELLER_PORTFOLIO_VOLUME = Convert.ToDecimal(SELLER_PORTFOLIO_VOLUME);
            deal.MESSAGE_STATUS = MESSAGE_STATUS.ToString();
            deal.SECURITY_SYMBOL = SECURITY_SYMBOL.ToString();
            deal.FIRM = Convert.ToInt32(FIRM);
            deal.TRADER_ID = Convert.ToInt32(TRADER_ID);
            deal.SELLER_CLIENT_ID = SELLER_CLIENT_ID.ToString();
            deal.BUYER_CLIENT_ID = BUYER_CLIENT_ID.ToString();
            deal.APPROVED_BY = APPROVED_BY.ToString();
            deal.RECEIVED_BY = RECEIVED_BY.ToString();

            dataContext.PT_ONE_FIRM_DEALs.InsertOnSubmit(deal);
            dataContext.SubmitChanges();
            return 1;
            }
            catch { return -1; }
        }
        static public int linqInsertAdv(object MESSAGE_STATUS, object MESSAGE_TYPE, object FIRM, object TRADER_ID, object SECURITY_SYMBOL, object SIDE
                , object VOLUME, object PRICE, object BOARD, object TIME, object ADD_CANCEL_FLAG,
                object CONTACT, object RECEIVED_BY, object APPROVED_BY)
        {
            try{
            PT_ADVERTISEMENT deal = new PT_ADVERTISEMENT();
            deal.APPROVED_BY = APPROVED_BY.ToString();
            deal.RECEIVED_BY = RECEIVED_BY.ToString();
            deal.BOARD = Convert.ToChar(BOARD);
            deal.FIRM = Convert.ToInt32(FIRM);
            deal.TRADER_ID = Convert.ToInt32(TRADER_ID);
            deal.MESSAGE_STATUS = MESSAGE_STATUS.ToString();
            deal.PRICE = Convert.ToDecimal(PRICE);
            deal.VOLUME = Convert.ToDecimal(VOLUME);
            deal.SECURITY_SYMBOL = SECURITY_SYMBOL.ToString();
            deal.SIDE = Convert.ToChar(SIDE);
            deal.CONTACT = CONTACT.ToString();
            deal.ADD_CANCEL_FLAG = Convert.ToChar(ADD_CANCEL_FLAG);
            deal.TIME = TIME.ToString();
            deal.ENTRY_DATE = DateTime.Now;
            deal.MESSAGE_TYPE = "1E";
            dataContext.PT_ADVERTISEMENTs.InsertOnSubmit(deal);
            dataContext.SubmitChanges();
            return 1;
            }
            catch { return -1; }
        }        

        //----------------------------------------
        //-------------- END LINQ ----------------
        //----------------------------------------
        
        // ------------------- for PT CORE by BSC ----------------------
        static public int ptGet1FirmOrderSeqBuy(object OrderNumber)
        {
            string sql = "select CORE_ORDER_SEQ_BUY from PT_ONE_FIRM_DEAL where CONFIRM_NUMBER = @CON_NUM";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@CON_NUM", DbType.Int32, OrderNumber);
            object o = DbHOGW.ExecuteScalar(cmd);
            if (o == null) return -1;
            return Convert.ToInt32(o);
        }
        static public int ptGet1FirmOrderSeqSell(object OrderNumber)
        {
            string sql = "select CORE_ORDER_SEQ_SELL from PT_ONE_FIRM_DEAL where CONFIRM_NUMBER = @CON_NUM";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@CON_NUM", DbType.Int32, OrderNumber);
            object o = DbHOGW.ExecuteScalar(cmd);
            if (o == null) return -1;
            return Convert.ToInt32(o);
        }
        static public int ptGetSellerOrderSeq(object OrderNumber)
        {
            string sql = "select CORE_ORDER_SEQ from PT_TWO_FIRM_DEAL_SELLER where CONFIRM_NUMBER = @CON_NUM";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@CON_NUM", DbType.Int32, OrderNumber);
            object o = DbHOGW.ExecuteScalar(cmd);
            if (o == null) return -1;
            return Convert.ToInt32(o);
        }
        static public int ptGetBuyerOrderSeq(object OrderNumber)
        {
            string sql = "select CORE_ORDER_SEQ from PT_TWO_FIRM_DEAL_BUYER where CONFIRM_NUMBER = @CON_NUM";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@CON_NUM", DbType.Int32, OrderNumber);
            object o = DbHOGW.ExecuteScalar(cmd);
            if (o == null) return -1;
            return Convert.ToInt32(o);
        }
        static public DataTable ptGetBuyerOrders()
        {
            string sql = "SELECT DEAL_ID,MESSAGE_STATUS,MESSAGE_TYPE,BUYER_FIRM,BUYER_TRADER_ID, BUYER_CLIENT_ID " +
                    ",SIDE,SELLER_CONTRA_FIRM,SELLER_TRADER_ID,SECURITY_SYMBOL,VOLUME,PRICE " +
                    ",BOARD,CONFIRM_NUMBER,RECEIVED_BY,APPROVED_BY,ENTRY_DATE " +
                  "FROM PT_TWO_FIRM_DEAL_BUYER order by DEAL_ID";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            return DbPTCore.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
        static public List<TWO_FIRM_DEAL_BUYER> ptGetBuyerOrdersList()
        {
            SqlDataReader rd = null;
            try{
                string sql = "SELECT DEAL_ID,MESSAGE_STATUS,MESSAGE_TYPE,BUYER_FIRM,BUYER_TRADER_ID,BUYER_CLIENT_ID " +
                        ",SIDE,SELLER_CONTRA_FIRM,SELLER_TRADER_ID,SECURITY_SYMBOL,VOLUME,PRICE " +
                        ",BOARD,CONFIRM_NUMBER,RECEIVED_BY,APPROVED_BY,ENTRY_DATE " +
                      "FROM PT_TWO_FIRM_DEAL_BUYER order by DEAL_ID";
                Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
                rd = (SqlDataReader)DbPTCore.ExecuteReader(CommandType.Text, sql);
                List<TWO_FIRM_DEAL_BUYER> lstDeals = new List<TWO_FIRM_DEAL_BUYER>();
                while (rd.Read())
                {
                    TWO_FIRM_DEAL_BUYER deal = new TWO_FIRM_DEAL_BUYER();
                    deal.DEAL_ID = rd["DEAL_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["DEAL_ID"]);
                    deal.MESSAGE_STATUS = rd["MESSAGE_STATUS"] == DBNull.Value ? "" : rd["MESSAGE_STATUS"].ToString();
                    deal.MESSAGE_TYPE = Convert.ToString(rd["MESSAGE_TYPE"]);
                    deal.BUYER_FIRM = rd["BUYER_FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["BUYER_FIRM"]);
                    deal.BUYER_TRADER_ID = rd["BUYER_TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["BUYER_TRADER_ID"]);
                    deal.BUYER_CLIENT_ID = rd["BUYER_CLIENT_ID"] == DBNull.Value ? "" : rd["BUYER_CLIENT_ID"].ToString();
                    deal.SIDE = Convert.ToString(rd["SIDE"]);
                    deal.SELLER_CONTRA_FIRM = rd["SELLER_CONTRA_FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["SELLER_CONTRA_FIRM"]);
                    deal.SELLER_TRADER_ID = rd["SELLER_TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["SELLER_TRADER_ID"]);
                    deal.SECURITY_SYMBOL = rd["SECURITY_SYMBOL"] == DBNull.Value ? "" : rd["SECURITY_SYMBOL"].ToString();
                    deal.VOLUME = rd["VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["VOLUME"]);
                    deal.PRICE = rd["PRICE"] == DBNull.Value ? 0 : Convert.ToDouble(rd["PRICE"]);
                    deal.BOARD = Convert.ToString(rd["BOARD"]);
                    deal.CONFIRM_NUMBER = rd["CONFIRM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(rd["CONFIRM_NUMBER"]);
                    deal.RECEIVED_BY = rd["RECEIVED_BY"] == DBNull.Value ? "" : rd["RECEIVED_BY"].ToString();
                    deal.APPROVED_BY = rd["APPROVED_BY"] == DBNull.Value ? "" : rd["APPROVED_BY"].ToString();
                    deal.ENTRY_DATE = rd["ENTRY_DATE"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rd["ENTRY_DATE"]);
                    lstDeals.Add(deal);
                }
                rd.Close();
                return lstDeals;
            }
            catch
            {
                if (rd != null && !rd.IsClosed) rd.Close(); return null;
            }
        }
        static public DataTable ptGetBuyerOrders(string messageStatus)
        {
            string sql = "SELECT DEAL_ID,MESSAGE_STATUS,MESSAGE_TYPE,BUYER_FIRM,BUYER_TRADER_ID,BUYER_CLIENT_ID " +
                    ",SIDE,SELLER_CONTRA_FIRM,SELLER_TRADER_ID,SECURITY_SYMBOL,VOLUME,PRICE " +
                    ",BOARD,CONFIRM_NUMBER,RECEIVED_BY,APPROVED_BY,ENTRY_DATE " +
                  "FROM PT_TWO_FIRM_DEAL_BUYER where MESSAGE_STATUS = @MESSAGE_STATUS";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
            return DbPTCore.ExecuteDataSet(cmd).Tables[0];
        }
        static public DataTable ptGetBuyerOrdersByTraderID(string messageStatus, int TraderID)
        {
            string sql = "SELECT DEAL_ID,MESSAGE_STATUS,MESSAGE_TYPE,BUYER_FIRM,BUYER_TRADER_ID,BUYER_CLIENT_ID " +
                    ",SIDE,SELLER_CONTRA_FIRM,SELLER_TRADER_ID,SECURITY_SYMBOL,VOLUME,PRICE " +
                    ",BOARD,CONFIRM_NUMBER,RECEIVED_BY,APPROVED_BY,ENTRY_DATE " +
                  "FROM PT_TWO_FIRM_DEAL_BUYER where MESSAGE_STATUS = @MESSAGE_STATUS and BUYER_TRADER_ID = @TRADER_ID";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
            DbPTCore.AddInParameter(cmd, "@TRADER_ID", DbType.Int32, TraderID);
            return DbPTCore.ExecuteDataSet(cmd).Tables[0];
        }
        static public List<TWO_FIRM_DEAL_BUYER> ptGetBuyerOrdersList(string messageStatus)
        {
            SqlDataReader rd = null;
            try
            {
                string sql = "SELECT DEAL_ID,MESSAGE_STATUS,MESSAGE_TYPE,BUYER_FIRM,BUYER_TRADER_ID,BUYER_CLIENT_ID " +
                        ",SIDE,SELLER_CONTRA_FIRM,SELLER_TRADER_ID,SECURITY_SYMBOL,VOLUME,PRICE " +
                        ",BOARD,CONFIRM_NUMBER,RECEIVED_BY,APPROVED_BY,ENTRY_DATE " +
                      "FROM PT_TWO_FIRM_DEAL_BUYER where MESSAGE_STATUS = @MESSAGE_STATUS";
                Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
                DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
                DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
                rd = (SqlDataReader)DbPTCore.ExecuteReader(cmd);
                List<TWO_FIRM_DEAL_BUYER> lstDeals = new List<TWO_FIRM_DEAL_BUYER>();
                while (rd.Read())
                {
                    TWO_FIRM_DEAL_BUYER deal = new TWO_FIRM_DEAL_BUYER();
                    deal.DEAL_ID = rd["DEAL_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["DEAL_ID"]);
                    deal.MESSAGE_STATUS = rd["MESSAGE_STATUS"] == DBNull.Value ? "" : rd["MESSAGE_STATUS"].ToString();
                    deal.MESSAGE_TYPE = Convert.ToString(rd["MESSAGE_TYPE"]);
                    deal.BUYER_FIRM = rd["BUYER_FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["BUYER_FIRM"]);
                    deal.BUYER_TRADER_ID = rd["BUYER_TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["BUYER_TRADER_ID"]);
                    deal.BUYER_CLIENT_ID = rd["BUYER_CLIENT_ID"] == DBNull.Value ? "" : rd["BUYER_CLIENT_ID"].ToString();
                    deal.SIDE = Convert.ToString(rd["SIDE"]);
                    deal.SELLER_CONTRA_FIRM = rd["SELLER_CONTRA_FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["SELLER_CONTRA_FIRM"]);
                    deal.SELLER_TRADER_ID = rd["SELLER_TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["SELLER_TRADER_ID"]);
                    deal.SECURITY_SYMBOL = rd["SECURITY_SYMBOL"] == DBNull.Value ? "" : rd["SECURITY_SYMBOL"].ToString();
                    deal.VOLUME = rd["VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["VOLUME"]);
                    deal.PRICE = rd["PRICE"] == DBNull.Value ? 0 : Convert.ToDouble(rd["PRICE"]);
                    deal.BOARD = Convert.ToString(rd["BOARD"]);
                    deal.CONFIRM_NUMBER = rd["CONFIRM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(rd["CONFIRM_NUMBER"]);
                    deal.RECEIVED_BY = rd["RECEIVED_BY"] == DBNull.Value ? "" : rd["RECEIVED_BY"].ToString();
                    deal.APPROVED_BY = rd["APPROVED_BY"] == DBNull.Value ? "" : rd["APPROVED_BY"].ToString();                    
                    deal.ENTRY_DATE = rd["ENTRY_DATE"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rd["ENTRY_DATE"]);
                    lstDeals.Add(deal);
                }
                rd.Close();
                return lstDeals;
            }
            catch
            {
                if (rd != null && !rd.IsClosed) rd.Close(); return null;
            }
        }
        static public int ptGetBuyerOrdersCount(string messageStatus)
        {
            string sql = "SELECT count(*) as BuyerDealCount " +
                  "FROM PT_TWO_FIRM_DEAL_BUYER where MESSAGE_STATUS = @MESSAGE_STATUS";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
            object o = DbPTCore.ExecuteScalar(cmd);
            if (o == null) return -1;
            return Convert.ToInt32(o);
        }
        static public int ptGetBuyerOrdersCountByTrader(string messageStatus, int traderID)
        {
            string sql = "SELECT count(*) as BuyerDealCount " +
                  "FROM PT_TWO_FIRM_DEAL_BUYER where MESSAGE_STATUS = @MESSAGE_STATUS and BUYER_TRADER_ID = @TRADER_ID";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
            DbPTCore.AddInParameter(cmd, "@TRADER_ID", DbType.Int32, traderID);
            object o = DbPTCore.ExecuteScalar(cmd);
            if (o == null) return -1;
            return Convert.ToInt32(o);
        }
        static public DataTable ptGetSellerOrders()
        {
            string sql = "SELECT MESSAGE_STATUS,MESSAGE_TYPE,SELLER_FIRM,SELLER_TRADER_ID,SELLER_CLIENT_ID " +
                            ",BUYER_FIRM,BUYER_TRADER_ID,SECURITY_SYMBOL,PRICE,BOARD,DEAL_ID " +
                            ", case when seller_client_id like '%C%' then broker_client_volume when seller_client_id like '%F%' then "+
                            "broker_foreign_volume when seller_client_id like '%P%' then broker_portfolio_volume when seller_client_id like '%M%' then " +
                            "broker_mutual_fund_volume else 0 end as VOLUME "+
                            ",BROKER_PORTFOLIO_VOLUME,BROKER_CLIENT_VOLUME,BROKER_MUTUAL_FUND_VOLUME,BROKER_FOREIGN_VOLUME " +
                            ",RECEIVED_BY,APPROVED_BY,ENTRY_DATE,CONFIRM_NUMBER, SIDE " +
                          "FROM PT_TWO_FIRM_DEAL_SELLER";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            return DbPTCore.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
        static public DataTable ptGetSellerOrders(string messageStatus)
        {
            string sql = "SELECT MESSAGE_STATUS,MESSAGE_TYPE,SELLER_FIRM,SELLER_TRADER_ID,SELLER_CLIENT_ID " +
                            ",BUYER_FIRM,BUYER_TRADER_ID,SECURITY_SYMBOL,PRICE,BOARD,DEAL_ID " +
                            ", case when seller_client_id like '%C%' then broker_client_volume when seller_client_id like '%F%' then " +
                            "broker_foreign_volume when seller_client_id like '%P%' then broker_portfolio_volume when seller_client_id like '%M%' then " +
                            "broker_mutual_fund_volume else 0 end as VOLUME " +
                            ",BROKER_PORTFOLIO_VOLUME,BROKER_CLIENT_VOLUME,BROKER_MUTUAL_FUND_VOLUME,BROKER_FOREIGN_VOLUME " +
                            ",RECEIVED_BY,APPROVED_BY,ENTRY_DATE,CONFIRM_NUMBER, SIDE " +
                          "FROM PT_TWO_FIRM_DEAL_SELLER where MESSAGE_STATUS = @MESSAGE_STATUS";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
            return DbPTCore.ExecuteDataSet(cmd).Tables[0];
        }
        static public List<TWO_FIRM_DEAL_SELLER> ptGetSellerOrdersList(string messageStatus)
        {
            SqlDataReader rd = null;
            try
            {
                string sql = "SELECT MESSAGE_STATUS,MESSAGE_TYPE,SELLER_FIRM,SELLER_TRADER_ID,SELLER_CLIENT_ID " +
                                ",BUYER_FIRM,BUYER_TRADER_ID,SECURITY_SYMBOL,PRICE,BOARD,DEAL_ID " +
                                ", case when seller_client_id like '%C%' then broker_client_volume when seller_client_id like '%F%' then " +
                                "broker_foreign_volume when seller_client_id like '%P%' THEN broker_portfolio_volume when seller_client_id like '%M%' then " +
                                "broker_mutual_fund_volume else 0 end as VOLUME " +
                                ",BROKER_PORTFOLIO_VOLUME,BROKER_CLIENT_VOLUME,BROKER_MUTUAL_FUND_VOLUME,BROKER_FOREIGN_VOLUME " +
                                ",RECEIVED_BY,APPROVED_BY,ENTRY_DATE,CONFIRM_NUMBER, SIDE " +
                              "FROM PT_TWO_FIRM_DEAL_SELLER where MESSAGE_STATUS = @MESSAGE_STATUS";
                Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
                DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
                DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
                rd = (SqlDataReader)DbPTCore.ExecuteReader(cmd);
                List<TWO_FIRM_DEAL_SELLER> lstDeals = new List<TWO_FIRM_DEAL_SELLER>();
                while (rd.Read())
                {
                    TWO_FIRM_DEAL_SELLER deal = new TWO_FIRM_DEAL_SELLER();
                    deal.MESSAGE_STATUS = rd["MESSAGE_STATUS"] == DBNull.Value ? "" : rd["MESSAGE_STATUS"].ToString();
                    deal.MESSAGE_TYPE = Convert.ToString(rd["MESSAGE_TYPE"]);
                    deal.SELLER_FIRM = rd["SELLER_FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["SELLER_FIRM"]);
                    deal.SELLER_TRADER_ID = rd["SELLER_TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["SELLER_TRADER_ID"]);
                    deal.SELLER_CLIENT_ID = rd["SELLER_CLIENT_ID"] == DBNull.Value ? "" : rd["SELLER_CLIENT_ID"].ToString();
                    deal.BUYER_FIRM = rd["BUYER_FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["BUYER_FIRM"]);
                    deal.BUYER_TRADER_ID = rd["BUYER_TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["BUYER_TRADER_ID"]);
                    deal.SECURITY_SYMBOL = rd["SECURITY_SYMBOL"] == DBNull.Value ? "" : rd["SECURITY_SYMBOL"].ToString();
                    deal.PRICE = rd["PRICE"] == DBNull.Value ? 0 : Convert.ToDouble(rd["PRICE"]);
                    deal.BOARD = Convert.ToString(rd["BOARD"]);
                    deal.DEAL_ID = rd["DEAL_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["DEAL_ID"]);
                    deal.BROKER_PORTFOLIO_VOLUME = rd["BROKER_PORTFOLIO_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BROKER_PORTFOLIO_VOLUME"]);
                    deal.BROKER_CLIENT_VOLUME = rd["BROKER_CLIENT_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BROKER_CLIENT_VOLUME"]);
                    deal.BROKER_MUTUAL_FUND_VOLUME = rd["BROKER_MUTUAL_FUND_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BROKER_MUTUAL_FUND_VOLUME"]);
                    deal.BROKER_FOREIGN_VOLUME = rd["BROKER_FOREIGN_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BROKER_FOREIGN_VOLUME"]);
                    deal.RECEIVED_BY = rd["RECEIVED_BY"] == DBNull.Value ? "" : rd["RECEIVED_BY"].ToString();
                    deal.APPROVED_BY = rd["APPROVED_BY"] == DBNull.Value ? "" : rd["APPROVED_BY"].ToString();
                    deal.CONFIRM_NUMBER = rd["CONFIRM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(rd["CONFIRM_NUMBER"]);
                    deal.SIDE = Convert.ToString(rd["SIDE"]);
                    deal.ENTRY_DATE = rd["ENTRY_DATE"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rd["ENTRY_DATE"]);
                    lstDeals.Add(deal);
                }
                rd.Close();
                return lstDeals;
            }
            catch
            {
                if (rd != null && !rd.IsClosed) rd.Close(); return null;
            }
        }
        static public DataTable ptGet1FirmOrders()
        {
            string sql = "SELECT MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,BUYER_CLIENT_ID,SELLER_CLIENT_ID " +
                            ",SECURITY_SYMBOL,PRICE,BOARD,DEAL_ID,BUYER_PORTFOLIO_VOLUME,BUYER_CLIENT_VOLUME " +
                            ", case when seller_client_id like '%C%' then seller_client_volume when seller_client_id like '%F%' then " +
                            "seller_foreign_volume when seller_client_id like '%P%' THEN seller_portfolio_volume when seller_client_id like '%M%' then " +
                            "seller_mutual_fund_volume else 0 end as SELLER_VOLUME " +
                            ", case when BUYER_CLIENT_ID like '%C%' then buyer_client_volume when BUYER_CLIENT_ID like '%F%' then " +
                            "buyer_foreign_volume when BUYER_CLIENT_ID like '%P%' then buyer_portfolio_volume when BUYER_CLIENT_ID like '%M%' then " +
                            "buyer_mutual_fund_volume else 0 end as BUYER_VOLUME " +
                            ",BUYER_MUTUAL_FUND_VOLUME,BUYER_FOREIGN_VOLUME,SELLER_PORTFOLIO_VOLUME,SELLER_CLIENT_VOLUME " +
                            ",SELLER_MUTUAL_FUND_VOLUME,SELLER_FOREIGN_VOLUME,RECEIVED_BY,APPROVED_BY,ENTRY_DATE,CONFIRM_NUMBER " +
                          "FROM PT_ONE_FIRM_DEAL";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            return DbPTCore.ExecuteDataSet(CommandType.Text,sql).Tables[0];
        }
        static public DataTable ptGet1FirmOrders(string messageStatus)
        {
            string sql = "SELECT MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,BUYER_CLIENT_ID,SELLER_CLIENT_ID " +
                            ",SECURITY_SYMBOL,PRICE,BOARD,DEAL_ID,BUYER_PORTFOLIO_VOLUME,BUYER_CLIENT_VOLUME " +
                            ", case when seller_client_id like '%C%' then seller_client_volume when seller_client_id like '%F%' then " +
                            "seller_foreign_volume when seller_client_id like '%P%' THEN seller_portfolio_volume when seller_client_id like '%M%' then " +
                            "seller_mutual_fund_volume else 0 end as SELLER_VOLUME " +
                            ", case when BUYER_CLIENT_ID like '%C%' then buyer_client_volume when BUYER_CLIENT_ID like '%F%' then " +
                            "buyer_foreign_volume when BUYER_CLIENT_ID like '%P%' then buyer_portfolio_volume when BUYER_CLIENT_ID like '%M%' then " +
                            "buyer_mutual_fund_volume else 0 end as BUYER_VOLUME " +
                            ",BUYER_MUTUAL_FUND_VOLUME,BUYER_FOREIGN_VOLUME,SELLER_PORTFOLIO_VOLUME,SELLER_CLIENT_VOLUME " +
                            ",SELLER_MUTUAL_FUND_VOLUME,SELLER_FOREIGN_VOLUME,RECEIVED_BY,APPROVED_BY,ENTRY_DATE,CONFIRM_NUMBER " +
                          "FROM PT_ONE_FIRM_DEAL where MESSAGE_STATUS = @MESSAGE_STATUS";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
            return DbPTCore.ExecuteDataSet(cmd).Tables[0];
        }
        static public List<ONE_FIRM_DEAL> ptGet1FirmOrdersList(string messageStatus)
        {
            SqlDataReader rd = null;
            try
            {
                string sql = "SELECT MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,BUYER_CLIENT_ID,SELLER_CLIENT_ID " +
                            ",SECURITY_SYMBOL,PRICE,BOARD,DEAL_ID,BUYER_PORTFOLIO_VOLUME,BUYER_CLIENT_VOLUME " +
                            ", case when seller_client_id like '%C%' then seller_client_volume when seller_client_id like '%F%' then " +
                            "seller_foreign_volume when seller_client_id like '%P%' THEN seller_portfolio_volume when seller_client_id like '%M%' then " +
                            "seller_mutual_fund_volume else 0 end as SELLER_VOLUME " +
                            ", case when BUYER_CLIENT_ID like '%C%' then buyer_client_volume when BUYER_CLIENT_ID like '%F%' then " +
                            "buyer_foreign_volume when BUYER_CLIENT_ID like '%P%' then buyer_portfolio_volume when BUYER_CLIENT_ID like '%M%' then " +
                            "buyer_mutual_fund_volume else 0 end as BUYER_VOLUME " +
                            ",BUYER_MUTUAL_FUND_VOLUME,BUYER_FOREIGN_VOLUME,SELLER_PORTFOLIO_VOLUME,SELLER_CLIENT_VOLUME " +
                            ",SELLER_MUTUAL_FUND_VOLUME,SELLER_FOREIGN_VOLUME,RECEIVED_BY,APPROVED_BY,ENTRY_DATE,CONFIRM_NUMBER " +
                            "FROM PT_ONE_FIRM_DEAL where MESSAGE_STATUS = @MESSAGE_STATUS";
                Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
                DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
                DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
                rd = (SqlDataReader)DbPTCore.ExecuteReader(cmd);
                List<ONE_FIRM_DEAL> lstDeals = new List<ONE_FIRM_DEAL>();
                while (rd.Read())
                {
                    ONE_FIRM_DEAL deal = new ONE_FIRM_DEAL();
                    deal.MESSAGE_STATUS = rd["MESSAGE_STATUS"] == DBNull.Value ? "" : rd["MESSAGE_STATUS"].ToString();
                    deal.MESSAGE_TYPE = Convert.ToString(rd["MESSAGE_TYPE"]);
                    deal.FIRM = rd["FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["FIRM"]);
                    deal.TRADER_ID = rd["TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["TRADER_ID"]);
                    deal.BUYER_CLIENT_ID = rd["BUYER_CLIENT_ID"] == DBNull.Value ? "" : rd["BUYER_CLIENT_ID"].ToString();
                    deal.SELLER_CLIENT_ID = rd["SELLER_CLIENT_ID"] == DBNull.Value ? "" : rd["SELLER_CLIENT_ID"].ToString();
                    deal.SECURITY_SYMBOL = rd["SECURITY_SYMBOL"] == DBNull.Value ? "" : rd["SECURITY_SYMBOL"].ToString();
                    deal.PRICE = rd["PRICE"] == DBNull.Value ? 0 : Convert.ToDouble(rd["PRICE"]);
                    deal.BOARD = Convert.ToString(rd["BOARD"]);
                    deal.DEAL_ID = rd["DEAL_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["DEAL_ID"]);
                    deal.BUYER_PORTFOLIO_VOLUME = rd["BUYER_PORTFOLIO_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BUYER_PORTFOLIO_VOLUME"]);
                    deal.BUYER_CLIENT_VOLUME = rd["BUYER_CLIENT_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BUYER_CLIENT_VOLUME"]);
                    deal.BUYER_MUTUAL_FUND_VOLUME = rd["BUYER_MUTUAL_FUND_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BUYER_MUTUAL_FUND_VOLUME"]);
                    deal.BUYER_FOREIGN_VOLUME = rd["BUYER_FOREIGN_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["BUYER_FOREIGN_VOLUME"]);
                    deal.SELLER_PORTFOLIO_VOLUME = rd["SELLER_PORTFOLIO_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["SELLER_PORTFOLIO_VOLUME"]);
                    deal.SELLER_CLIENT_VOLUME = rd["SELLER_CLIENT_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["SELLER_CLIENT_VOLUME"]);
                    deal.SELLER_MUTUAL_FUND_VOLUME = rd["SELLER_MUTUAL_FUND_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["SELLER_MUTUAL_FUND_VOLUME"]);
                    deal.SELLER_FOREIGN_VOLUME = rd["SELLER_FOREIGN_VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["SELLER_FOREIGN_VOLUME"]);
                    deal.RECEIVED_BY = rd["RECEIVED_BY"] == DBNull.Value ? "" : rd["RECEIVED_BY"].ToString();
                    deal.APPROVED_BY = rd["APPROVED_BY"] == DBNull.Value ? "" : rd["APPROVED_BY"].ToString();
                    deal.ENTRY_DATE = rd["ENTRY_DATE"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rd["ENTRY_DATE"]);
                    deal.CONFIRM_NUMBER = rd["CONFIRM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(rd["CONFIRM_NUMBER"]);                    
                    lstDeals.Add(deal);
                }
                rd.Close();
                return lstDeals;
            }
            catch
            {
                if (rd != null && !rd.IsClosed) rd.Close(); return null;
            }
        }
        static public DataTable ptGetAdvAnnouncement()
        {
            string sql = "SELECT [ID],[MESSAGE_STATUS],[MESSAGE_TYPE],[SECURITY_NUMBER],[VOLUME],[PRICE],[FIRM],[TRADER_ID],[SIDE] " +
                          ",[BOARD],[TIME],[ADD_CANCEL_FLAG],[CONTACT],[RECEIVED_BY],[APPROVED_BY], ENTRY_DATE,[SECURITY_SYMBOL] " +
                     "FROM [PT_SBS].[dbo].[PT_ADVERTISEMENT_ANNOUCEMENT]";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            return DbPTCore.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
        static public DataTable ptGetAdvAnnouncement(string messageStatus)
        {
            string sql = "SELECT [ID],[MESSAGE_STATUS],[MESSAGE_TYPE],[SECURITY_NUMBER],[VOLUME],[PRICE],[FIRM],[TRADER_ID],[SIDE] "+
                          ",[BOARD],[TIME],[ADD_CANCEL_FLAG],[CONTACT],[RECEIVED_BY],[APPROVED_BY], ENTRY_DATE,[SECURITY_SYMBOL] " +
                     "FROM [PT_SBS].[dbo].[PT_ADVERTISEMENT_ANNOUCEMENT] where MESSAGE_STATUS = @MESSAGE_STATUS";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
            return DbPTCore.ExecuteDataSet(cmd).Tables[0];
        }
        static public DataTable ptGetAdvAnnouncementBySide(string side)
        {
            string sql = "SELECT [ID],[MESSAGE_STATUS],[MESSAGE_TYPE],[SECURITY_NUMBER],[VOLUME],[PRICE],[FIRM],[TRADER_ID],[SIDE] " +
                          ",[BOARD],[TIME],[ADD_CANCEL_FLAG],[CONTACT],[RECEIVED_BY],[APPROVED_BY], ENTRY_DATE,[SECURITY_SYMBOL] " +
                     "FROM [PT_SBS].[dbo].[PT_ADVERTISEMENT_ANNOUCEMENT] where SIDE = @SIDE";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@SIDE", DbType.String, side);
            return DbPTCore.ExecuteDataSet(cmd).Tables[0];
        }
        static public List<ADVERTISEMENT_ANNOUCEMENT> ptGetAdvAnnouncementList(string messageStatus)
        {
            SqlDataReader rd = null;
            try
            {
                string sql = "SELECT [ID],[MESSAGE_STATUS],[MESSAGE_TYPE],[SECURITY_NUMBER],[VOLUME],[PRICE],[FIRM],[TRADER_ID],[SIDE] " +
                              ",[BOARD],[TIME],[ADD_CANCEL_FLAG],[CONTACT],[RECEIVED_BY],[APPROVED_BY],[SECURITY_SYMBOL], [ENTRY_DATE] " +
                         "FROM [PT_SBS].[dbo].[PT_ADVERTISEMENT_ANNOUCEMENT] where MESSAGE_STATUS = @MESSAGE_STATUS";
                Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
                DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
                DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
                rd = (SqlDataReader)DbPTCore.ExecuteReader(cmd);
                List<ADVERTISEMENT_ANNOUCEMENT> lstDeals = new List<ADVERTISEMENT_ANNOUCEMENT>();
                while (rd.Read())
                {
                    ADVERTISEMENT_ANNOUCEMENT deal = new ADVERTISEMENT_ANNOUCEMENT();
                    deal.ID = rd["ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["ID"]);
                    deal.MESSAGE_STATUS = rd["MESSAGE_STATUS"] == DBNull.Value ? "" : rd["MESSAGE_STATUS"].ToString();
                    deal.MESSAGE_TYPE = Convert.ToString(rd["MESSAGE_TYPE"]);
                    deal.SECURITY_NUMBER = rd["SECURITY_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(rd["SECURITY_NUMBER"]);
                    deal.VOLUME = rd["VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["VOLUME"]);
                    deal.PRICE = rd["PRICE"] == DBNull.Value ? 0 : Convert.ToDouble(rd["PRICE"]);
                    deal.FIRM = rd["FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["FIRM"]);
                    deal.TRADER_ID = rd["TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["TRADER_ID"]);
                    deal.SIDE = Convert.ToString(rd["SIDE"]);
                    deal.BOARD = Convert.ToString(rd["BOARD"]);
                    deal.TIME = Convert.ToString(rd["TIME"]);
                    deal.ADD_CANCEL_FLAG = Convert.ToString(rd["ADD_CANCEL_FLAG"]);
                    deal.CONTACT = rd["CONTACT"] == DBNull.Value ? "" : rd["CONTACT"].ToString();
                    deal.RECEIVED_BY = rd["RECEIVED_BY"] == DBNull.Value ? "" : rd["RECEIVED_BY"].ToString();
                    deal.APPROVED_BY = rd["APPROVED_BY"] == DBNull.Value ? "" : rd["APPROVED_BY"].ToString();
                    deal.SECURITY_SYMBOL = rd["SECURITY_SYMBOL"] == DBNull.Value ? "" : rd["SECURITY_SYMBOL"].ToString();
                    deal.ENTRY_DATE = rd["ENTRY_DATE"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rd["ENTRY_DATE"]);
                    lstDeals.Add(deal);
                }
                rd.Close();
                return lstDeals;
            }
            catch
            {
                if (rd != null && !rd.IsClosed) rd.Close(); return null;
            }
        }
        static public DataTable ptGetAdvOrders()
        {
            string sql = "SELECT ID,MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,SECURITY_SYMBOL " +
                            ",SIDE,VOLUME,PRICE,BOARD,TIME,ADD_CANCEL_FLAG,CONTACT,RECEIVED_BY,APPROVED_BY,ENTRY_DATE " +
                             "FROM PT_ADVERTISEMENT";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            return DbPTCore.ExecuteDataSet(CommandType.Text,sql).Tables[0];
        }
        static public DataTable ptGetAdvOrders(string messageStatus)
        {
            string sql = "SELECT ID,MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,SECURITY_SYMBOL " +
                            ",SIDE,VOLUME,PRICE,BOARD,TIME,ADD_CANCEL_FLAG,CONTACT,RECEIVED_BY,APPROVED_BY,ENTRY_DATE " +
                             "FROM PT_ADVERTISEMENT where MESSAGE_STATUS = @MESSAGE_STATUS";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
            return DbPTCore.ExecuteDataSet(cmd).Tables[0];
        }

        static public List<ADVERTISEMENT> ptGetAdvOrdersList(string messageStatus)
        {
            SqlDataReader rd = null;
            try
            {
                string sql = "SELECT ID,MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,SECURITY_SYMBOL " +
                                ",SIDE,VOLUME,PRICE,BOARD,TIME,ADD_CANCEL_FLAG,CONTACT,RECEIVED_BY,APPROVED_BY,ENTRY_DATE " +
                                 "FROM PT_ADVERTISEMENT where MESSAGE_STATUS = @MESSAGE_STATUS";
                Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
                DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
                DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, messageStatus);
                rd = (SqlDataReader)DbPTCore.ExecuteReader(cmd);
                List<ADVERTISEMENT> lstDeals = new List<ADVERTISEMENT>();
                while (rd.Read())
                {
                    ADVERTISEMENT deal = new ADVERTISEMENT();
                    deal.ID = rd["ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["ID"]);
                    deal.MESSAGE_STATUS = rd["MESSAGE_STATUS"] == DBNull.Value ? "" : rd["MESSAGE_STATUS"].ToString();
                    deal.MESSAGE_TYPE = rd["MESSAGE_TYPE"] == DBNull.Value ? "" : rd["MESSAGE_TYPE"].ToString();
                    deal.FIRM = rd["FIRM"] == DBNull.Value ? 0 : Convert.ToInt32(rd["FIRM"]);
                    deal.TRADER_ID = rd["TRADER_ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["TRADER_ID"]);
                    deal.SECURITY_SYMBOL = rd["SECURITY_SYMBOL"] == DBNull.Value ? "" : rd["SECURITY_SYMBOL"].ToString();
                    deal.SIDE = Convert.ToString(rd["SIDE"]);
                    deal.VOLUME = rd["VOLUME"] == DBNull.Value ? 0 : Convert.ToDouble(rd["VOLUME"]);
                    deal.PRICE = rd["PRICE"] == DBNull.Value ? 0 : Convert.ToDouble(rd["PRICE"]);
                    deal.BOARD = Convert.ToString(rd["BOARD"]);
                    deal.TIME = Convert.ToString(rd["TIME"]);
                    deal.ADD_CANCEL_FLAG = Convert.ToString(rd["ADD_CANCEL_FLAG"]);
                    deal.CONTACT = rd["CONTACT"] == DBNull.Value ? "" : rd["CONTACT"].ToString();
                    deal.RECEIVED_BY = rd["RECEIVED_BY"] == DBNull.Value ? "" : rd["RECEIVED_BY"].ToString();
                    deal.APPROVED_BY = rd["APPROVED_BY"] == DBNull.Value ? "" : rd["APPROVED_BY"].ToString();
                    deal.ENTRY_DATE = rd["ENTRY_DATE"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rd["ENTRY_DATE"]);
                    lstDeals.Add(deal);
                }
                rd.Close();
                return lstDeals;
            }
            catch
            {
                if (rd != null && !rd.IsClosed) rd.Close(); return null;
            }
        }
        static public int ptUpdateSeller(object DealID, object NewStatus, object ConfirmNumber, object Side)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_SELLER set MESSAGE_STATUS = @NewStatus, CONFIRM_NUMBER = @ConfirmNumber, SIDE = @Side where DEAL_ID = @DealID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@ConfirmNumber", DbType.String, ConfirmNumber);
            DbPTCore.AddInParameter(cmd, "@Side", DbType.String, Side);
            DbPTCore.AddInParameter(cmd, "@DealID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateBuyer(object DealID, object NewStatus, object ConfirmNumber)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_BUYER set MESSAGE_STATUS = @NewStatus, CONFIRM_NUMBER = @ConfirmNumber where DEAL_ID = @DealID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@ConfirmNumber", DbType.String, ConfirmNumber);
            DbPTCore.AddInParameter(cmd, "@DealID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmCoreSeqBuy(object DealID, object Seq)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set CORE_ORDER_SEQ_BUY = @BUY_SEQ where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@BUY_SEQ", DbType.Int32, Seq);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmCoreSeqSell(object DealID, object Seq)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set CORE_ORDER_SEQ_SELL = @SELL_SEQ where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@SELL_SEQ", DbType.Int32, Seq);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1Firm(object DealID, object NewStatus, object ConfirmNumber)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set MESSAGE_STATUS = @NewStatus, CONFIRM_NUMBER = @ConfirmNumber where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@ConfirmNumber", DbType.String, ConfirmNumber);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateBuyerStatus(object DealID, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_BUYER set MESSAGE_STATUS = @NewStatus where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateBuyerClient(object DealID, object BuyerClient)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_BUYER set BUYER_CLIENT_ID = @BuyerClient where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@BuyerClient", DbType.String, BuyerClient);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateBuyerStatusByUser(object DealID, object NewStatus, object USERNAME)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_BUYER set MESSAGE_STATUS = @NewStatus, APPROVED_BY = @USERNAME where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@USERNAME", DbType.String, USERNAME);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateBuyerStatusByUser(object DealID, object OldStatus, object NewStatus, object USERNAME)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_BUYER set MESSAGE_STATUS = @NewStatus, APPROVED_BY = @USERNAME where DEAL_ID = @ID and MESSAGE_STATUS = @OldStatus");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@USERNAME", DbType.String, USERNAME);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            DbPTCore.AddInParameter(cmd, "@OldStatus", DbType.String, OldStatus);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateBuyerStatusByConfirmNumber(object CONFIRM_NUMBER, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_BUYER set MESSAGE_STATUS = @NewStatus where CONFIRM_NUMBER = @CONFIRM_NUMBER");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@CONFIRM_NUMBER", DbType.Decimal, CONFIRM_NUMBER);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateSellerStatus(object DealID, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_SELLER set MESSAGE_STATUS = @NewStatus where DEAL_ID = @DealID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@DealID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateSellerStatusByUser(object DealID, object NewStatus, object USERNAME)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_SELLER set MESSAGE_STATUS = @NewStatus, APPROVED_BY = @USERNAME where DEAL_ID = @DealID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@USERNAME", DbType.String, USERNAME);
            DbPTCore.AddInParameter(cmd, "@DealID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateSellerStatusByConfirmNumber(object CONFIRM_NUMBER, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_SELLER set MESSAGE_STATUS = @NewStatus where CONFIRM_NUMBER = @CONFIRM_NUMBER");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@CONFIRM_NUMBER", DbType.Decimal, CONFIRM_NUMBER);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmStatus(object DealID, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set MESSAGE_STATUS = @NewStatus where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmStatus(object DealID, object OldStatus, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set MESSAGE_STATUS = @NewStatus where DEAL_ID = @ID and MESSAGE_STATUS = @OldStatus");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            DbPTCore.AddInParameter(cmd, "@OldStatus", DbType.String, OldStatus);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmStatusByConfirmNumber(object CONFIRM_NUMBER, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set MESSAGE_STATUS = @NewStatus where CONFIRM_NUMBER = @CONFIRM_NUMBER");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@CONFIRM_NUMBER", DbType.Decimal, CONFIRM_NUMBER);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmStatusByConfirmNumber(object CONFIRM_NUMBER, object OldStatus, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set MESSAGE_STATUS = @NewStatus where CONFIRM_NUMBER = @CONFIRM_NUMBER and MESSAGE_STATUS = @OldStatus");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@CONFIRM_NUMBER", DbType.Decimal, CONFIRM_NUMBER);
            DbPTCore.AddInParameter(cmd, "@OldStatus", DbType.String, OldStatus);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmStatusByUser(object DealID, object NewStatus, object UserName)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set MESSAGE_STATUS = @NewStatus, APPROVED_BY = @UserName where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@UserName", DbType.String, UserName);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmStatusByUser(object DealID, object OldStatus, object NewStatus, object UserName)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set MESSAGE_STATUS = @NewStatus, APPROVED_BY = @UserName where DEAL_ID = @ID and MESSAGE_STATUS = @OldStatus");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@UserName", DbType.String, UserName);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            DbPTCore.AddInParameter(cmd, "@OldStatus", DbType.String, OldStatus);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateAdvStatus(object ID, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ADVERTISEMENT set MESSAGE_STATUS = @NewStatus where ID = @ID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, ID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateAdvStatusByUser(object ID, object NewStatus, object UserName)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ADVERTISEMENT set MESSAGE_STATUS = @NewStatus, APPROVED_BY = @UserName where ID = @ID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@UserName", DbType.String, UserName);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, ID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateAdvACFlag(object ID, object NewFlag)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ADVERTISEMENT set ADD_CANCEL_FLAG = @ACF where ID = @ID");
            DbPTCore.AddInParameter(cmd, "@ACF", DbType.String, NewFlag);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, ID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateAdvAnnouncementStatus(object ID, object NewStatus)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ADVERTISEMENT_ANNOUCEMENT set MESSAGE_STATUS = @NewStatus where ID = @ID");
            DbPTCore.AddInParameter(cmd, "@NewStatus", DbType.String, NewStatus);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, ID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateBuyerConfirmNumber(object DealID, object ConfirmNumber)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_BUYER set CONFIRM_NUMBER = @ConfirmNumber where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@ConfirmNumber", DbType.String, ConfirmNumber);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateBuyerCoreSeq(object DealID, object Seq)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_BUYER set CORE_ORDER_SEQ = @SEQ where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@SEQ", DbType.Int32, Seq);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }        
        static public int ptUpdateSellerConfirmNumber(object DealID, object ConfirmNumber)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_SELLER set CONFIRM_NUMBER = @ConfirmNumber where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@ConfirmNumber", DbType.String, ConfirmNumber);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdate1FirmConfirmNumber(object DealID, object ConfirmNumber)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_ONE_FIRM_DEAL set CONFIRM_NUMBER = @ConfirmNumber where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@ConfirmNumber", DbType.String, ConfirmNumber);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptUpdateSellerCoreSeq(object DealID, object Seq)
        {
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand("update PT_TWO_FIRM_DEAL_SELLER set CORE_ORDER_SEQ = @SEQ where DEAL_ID = @ID");
            DbPTCore.AddInParameter(cmd, "@SEQ", DbType.Int32, Seq);
            DbPTCore.AddInParameter(cmd, "@ID", DbType.Decimal, DealID);
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptInsertBuyerDeal(object MESSAGE_STATUS, object BUYER_FIRM, object BUYER_TRADER_ID
                        , object SIDE, object SELLER_CONTRA_FIRM, object SELLER_TRADER_ID, object SECURITY_SYMBOL, object VOLUME, object PRICE
                        ,object BOARD, object CONFIRM_NUMBER, object RECEIVED_BY, object APPROVED_BY)
        {
            string sql = "INSERT INTO PT_TWO_FIRM_DEAL_BUYER(MESSAGE_STATUS,MESSAGE_TYPE,BUYER_FIRM,BUYER_TRADER_ID " +
                        ",SIDE,SELLER_CONTRA_FIRM,SELLER_TRADER_ID,SECURITY_SYMBOL,VOLUME,PRICE " +
                        ",BOARD,CONFIRM_NUMBER,RECEIVED_BY,APPROVED_BY,ENTRY_DATE) " +
                    "VALUES(@MESSAGE_STATUS,'1G',@BUYER_FIRM,@BUYER_TRADER_ID " +
                        ",@SIDE,@SELLER_CONTRA_FIRM,@SELLER_TRADER_ID,@SECURITY_SYMBOL,@VOLUME,@PRICE " +
                        ",@BOARD,@CONFIRM_NUMBER,@RECEIVED_BY,@APPROVED_BY,@ENTRY_DATE)";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, MESSAGE_STATUS);
            DbPTCore.AddInParameter(cmd, "@BUYER_FIRM", DbType.Int32, BUYER_FIRM);
            DbPTCore.AddInParameter(cmd, "@BUYER_TRADER_ID", DbType.Int32, BUYER_TRADER_ID);
            DbPTCore.AddInParameter(cmd, "@SIDE", DbType.String, SIDE);
            DbPTCore.AddInParameter(cmd, "@SELLER_CONTRA_FIRM", DbType.Int32, SELLER_CONTRA_FIRM);
            DbPTCore.AddInParameter(cmd, "@SELLER_TRADER_ID", DbType.Int32, SELLER_TRADER_ID);
            DbPTCore.AddInParameter(cmd, "@SECURITY_SYMBOL", DbType.String, SECURITY_SYMBOL);
            DbPTCore.AddInParameter(cmd, "@VOLUME", DbType.Decimal, VOLUME);
            DbPTCore.AddInParameter(cmd, "@PRICE", DbType.Decimal, PRICE);
            DbPTCore.AddInParameter(cmd, "@BOARD", DbType.String, BOARD);
            DbPTCore.AddInParameter(cmd, "@CONFIRM_NUMBER", DbType.Int32, CONFIRM_NUMBER);
            DbPTCore.AddInParameter(cmd, "@RECEIVED_BY", DbType.String, RECEIVED_BY);
            DbPTCore.AddInParameter(cmd, "@APPROVED_BY", DbType.String, APPROVED_BY);
            DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.DateTime, DateTime.Now);
            //DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.String, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptInsertAdvAnnouncement(object MESSAGE_STATUS, object FIRM, object TRADER_ID, object SECURITY_SYMBOL
                , object SIDE, object VOLUME, object PRICE, object BOARD, object TIME, object ADD_CANCEL_FLAG, object CONTACT,
                object RECEIVED_BY, object APPROVED_BY)
        {
            string sql = "insert into PT_ADVERTISEMENT_ANNOUCEMENT(MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,SECURITY_SYMBOL " +
                        ",SIDE,VOLUME,PRICE,BOARD,TIME,ADD_CANCEL_FLAG,CONTACT,RECEIVED_BY,APPROVED_BY,ENTRY_DATE) " +
                        "values(@MESSAGE_STATUS,'1E',@FIRM,@TRADER_ID,@SECURITY_SYMBOL " +
                        ",@SIDE,@VOLUME,@PRICE,@BOARD,@TIME,@ADD_CANCEL_FLAG,@CONTACT,@RECEIVED_BY,@APPROVED_BY,@ENTRY_DATE)";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, MESSAGE_STATUS);
            DbPTCore.AddInParameter(cmd, "@FIRM", DbType.Int32, FIRM);
            DbPTCore.AddInParameter(cmd, "@TRADER_ID", DbType.Int32, TRADER_ID);
            DbPTCore.AddInParameter(cmd, "@SECURITY_SYMBOL", DbType.String, SECURITY_SYMBOL);
            DbPTCore.AddInParameter(cmd, "@SIDE", DbType.String, SIDE);
            DbPTCore.AddInParameter(cmd, "@VOLUME", DbType.Decimal, VOLUME);
            DbPTCore.AddInParameter(cmd, "@PRICE", DbType.Decimal, PRICE);
            DbPTCore.AddInParameter(cmd, "@BOARD", DbType.String, BOARD);
            DbPTCore.AddInParameter(cmd, "@TIME", DbType.String, TIME);
            DbPTCore.AddInParameter(cmd, "@ADD_CANCEL_FLAG", DbType.String, ADD_CANCEL_FLAG);
            DbPTCore.AddInParameter(cmd, "@CONTACT", DbType.String, CONTACT);
            DbPTCore.AddInParameter(cmd, "@RECEIVED_BY", DbType.String, RECEIVED_BY);
            DbPTCore.AddInParameter(cmd, "@APPROVED_BY", DbType.String, APPROVED_BY);
            DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.DateTime, DateTime.Now);
            //DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.String, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return DbPTCore.ExecuteNonQuery(cmd);
        }       
        static public int ptInsertSellerDeal(object MessageStatus, object SellerFirm, object SellerTraderID, object SellerID, object BuyerFirm
                    , object BuyerTraderID, object StockCode
                    , object Price, object BoardType, object BrokerPortfolioVolume, object BrokerClientVolume
                    , object BrokerMutualFundVolume, object BrokerForeignVolume, object ReceivedBy,
                    object ApprovedBy, object CoreOrderSeq)
        {
            string sql = "INSERT INTO PT_TWO_FIRM_DEAL_SELLER "+
                            "(MESSAGE_STATUS,MESSAGE_TYPE,SELLER_FIRM,SELLER_TRADER_ID,SELLER_CLIENT_ID "+
		                    ",BUYER_FIRM,BUYER_TRADER_ID,SECURITY_SYMBOL,PRICE,BOARD "+
		                    ",BROKER_PORTFOLIO_VOLUME,BROKER_CLIENT_VOLUME,BROKER_MUTUAL_FUND_VOLUME,BROKER_FOREIGN_VOLUME "+
                            ",RECEIVED_BY,APPROVED_BY,ENTRY_DATE,SIDE,CORE_ORDER_SEQ) " +
                         "VALUES(@MESSAGE_STATUS,'1G',@SELLER_FIRM,@SELLER_TRADER_ID,@SELLER_CLIENT_ID " +
                            ",@BUYER_FIRM,@BUYER_TRADER_ID,@SECURITY_SYMBOL,@PRICE,@BOARD " +
                            ",@BROKER_PORTFOLIO_VOLUME,@BROKER_CLIENT_VOLUME,@BROKER_MUTUAL_FUND_VOLUME,@BROKER_FOREIGN_VOLUME " +
                            ",@RECEIVED_BY,@APPROVED_BY,@ENTRY_DATE,'S',@CORE_ORDER_SEQ)";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, MessageStatus);
            DbPTCore.AddInParameter(cmd, "@SELLER_FIRM", DbType.Int32, SellerFirm);
            DbPTCore.AddInParameter(cmd, "@SELLER_TRADER_ID", DbType.Int32, SellerTraderID);
            DbPTCore.AddInParameter(cmd, "@SELLER_CLIENT_ID", DbType.String, SellerID);
            DbPTCore.AddInParameter(cmd, "@BUYER_FIRM", DbType.Int32, BuyerFirm);
            DbPTCore.AddInParameter(cmd, "@BUYER_TRADER_ID", DbType.Int32, BuyerTraderID);
            DbPTCore.AddInParameter(cmd, "@SECURITY_SYMBOL", DbType.String, StockCode);
            DbPTCore.AddInParameter(cmd, "@PRICE", DbType.Decimal, Price);
            DbPTCore.AddInParameter(cmd, "@BOARD", DbType.String, BoardType);
            DbPTCore.AddInParameter(cmd, "@BROKER_PORTFOLIO_VOLUME", DbType.Decimal, BrokerPortfolioVolume);
            DbPTCore.AddInParameter(cmd, "@BROKER_CLIENT_VOLUME", DbType.Decimal, BrokerClientVolume);
            DbPTCore.AddInParameter(cmd, "@BROKER_MUTUAL_FUND_VOLUME", DbType.Decimal, BrokerMutualFundVolume);
            DbPTCore.AddInParameter(cmd, "@BROKER_FOREIGN_VOLUME", DbType.Decimal, BrokerForeignVolume);
            DbPTCore.AddInParameter(cmd, "@RECEIVED_BY", DbType.String, ReceivedBy);
            DbPTCore.AddInParameter(cmd, "@APPROVED_BY", DbType.String, ApprovedBy);
            DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.DateTime, DateTime.Now);
            DbPTCore.AddInParameter(cmd, "@CORE_ORDER_SEQ", DbType.Int32, CoreOrderSeq);
            //DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.String, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptInsert1FirmDeal(object MESSAGE_STATUS,object FIRM,object TRADER_ID,object BUYER_CLIENT_ID
			,object SELLER_CLIENT_ID,object SECURITY_SYMBOL,object PRICE,object BOARD,object BUYER_PORTFOLIO_VOLUME
			,object BUYER_CLIENT_VOLUME,object BUYER_MUTUAL_FUND_VOLUME,object BUYER_FOREIGN_VOLUME
			,object SELLER_PORTFOLIO_VOLUME,object SELLER_CLIENT_VOLUME,object SELLER_MUTUAL_FUND_VOLUME,object SELLER_FOREIGN_VOLUME
            , object RECEIVED_BY, object APPROVED_BY, object CORE_ORDER_SEQ_BUY, object CORE_ORDER_SEQ_SELL)
        {
            string sql = "INSERT INTO PT_ONE_FIRM_DEAL "+
                        "(MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,BUYER_CLIENT_ID "+
			                        ",SELLER_CLIENT_ID,SECURITY_SYMBOL,PRICE,BOARD,BUYER_PORTFOLIO_VOLUME "+
			                        ",BUYER_CLIENT_VOLUME,BUYER_MUTUAL_FUND_VOLUME,BUYER_FOREIGN_VOLUME "+
			                        ",SELLER_PORTFOLIO_VOLUME,SELLER_CLIENT_VOLUME,SELLER_MUTUAL_FUND_VOLUME,SELLER_FOREIGN_VOLUME "+
                                    ",RECEIVED_BY,APPROVED_BY,ENTRY_DATE, CORE_ORDER_SEQ_BUY, CORE_ORDER_SEQ_SELL) " +
                        "values(@MESSAGE_STATUS,'1F',@FIRM,@TRADER_ID,@BUYER_CLIENT_ID "+
			                        ",@SELLER_CLIENT_ID,@SECURITY_SYMBOL,@PRICE,@BOARD,@BUYER_PORTFOLIO_VOLUME "+
			                        ",@BUYER_CLIENT_VOLUME,@BUYER_MUTUAL_FUND_VOLUME,@BUYER_FOREIGN_VOLUME "+
			                        ",@SELLER_PORTFOLIO_VOLUME,@SELLER_CLIENT_VOLUME,@SELLER_MUTUAL_FUND_VOLUME,@SELLER_FOREIGN_VOLUME "+
                                    ",@RECEIVED_BY,@APPROVED_BY,@ENTRY_DATE, @CORE_ORDER_SEQ_BUY, @CORE_ORDER_SEQ_SELL)";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, MESSAGE_STATUS);
            DbPTCore.AddInParameter(cmd, "@FIRM", DbType.Int32, FIRM);
            DbPTCore.AddInParameter(cmd, "@TRADER_ID", DbType.Int32, TRADER_ID);
            DbPTCore.AddInParameter(cmd, "@BUYER_CLIENT_ID", DbType.String, BUYER_CLIENT_ID);
            DbPTCore.AddInParameter(cmd, "@SELLER_CLIENT_ID", DbType.String, SELLER_CLIENT_ID);
            DbPTCore.AddInParameter(cmd, "@SECURITY_SYMBOL", DbType.String, SECURITY_SYMBOL);
            DbPTCore.AddInParameter(cmd, "@PRICE", DbType.Decimal, PRICE);
            DbPTCore.AddInParameter(cmd, "@BOARD", DbType.String, BOARD);

            DbPTCore.AddInParameter(cmd, "@BUYER_PORTFOLIO_VOLUME", DbType.Decimal, BUYER_PORTFOLIO_VOLUME);
            DbPTCore.AddInParameter(cmd, "@BUYER_CLIENT_VOLUME", DbType.Decimal, BUYER_CLIENT_VOLUME);
            DbPTCore.AddInParameter(cmd, "@BUYER_MUTUAL_FUND_VOLUME", DbType.Decimal, BUYER_MUTUAL_FUND_VOLUME);
            DbPTCore.AddInParameter(cmd, "@BUYER_FOREIGN_VOLUME", DbType.Decimal, BUYER_FOREIGN_VOLUME);

            DbPTCore.AddInParameter(cmd, "@SELLER_PORTFOLIO_VOLUME", DbType.Decimal, SELLER_PORTFOLIO_VOLUME);
            DbPTCore.AddInParameter(cmd, "@SELLER_CLIENT_VOLUME", DbType.Decimal, SELLER_CLIENT_VOLUME);
            DbPTCore.AddInParameter(cmd, "@SELLER_MUTUAL_FUND_VOLUME", DbType.Decimal, SELLER_MUTUAL_FUND_VOLUME);
            DbPTCore.AddInParameter(cmd, "@SELLER_FOREIGN_VOLUME", DbType.Decimal, SELLER_FOREIGN_VOLUME);

            DbPTCore.AddInParameter(cmd, "@RECEIVED_BY", DbType.String, RECEIVED_BY);
            DbPTCore.AddInParameter(cmd, "@APPROVED_BY", DbType.String, APPROVED_BY);

            DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.DateTime, DateTime.Now);
            DbPTCore.AddInParameter(cmd, "@CORE_ORDER_SEQ_BUY", DbType.Int32, CORE_ORDER_SEQ_BUY);
            DbPTCore.AddInParameter(cmd, "@CORE_ORDER_SEQ_SELL", DbType.Int32, CORE_ORDER_SEQ_SELL);
            //DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.String, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return DbPTCore.ExecuteNonQuery(cmd);
        }
        static public int ptInsertAdv(object MESSAGE_STATUS,object MESSAGE_TYPE,object FIRM,object TRADER_ID,object SECURITY_SYMBOL,object SIDE
		        ,object VOLUME,object PRICE,object BOARD,object TIME,object ADD_CANCEL_FLAG,
                object CONTACT, object RECEIVED_BY, object APPROVED_BY)
        {
            string sql = "INSERT INTO PT_ADVERTISEMENT "+
	                        "(MESSAGE_STATUS,MESSAGE_TYPE,FIRM,TRADER_ID,SECURITY_SYMBOL,SIDE "+
		                        ",VOLUME,PRICE,BOARD,TIME,ADD_CANCEL_FLAG, "+
		                        "CONTACT,RECEIVED_BY,APPROVED_BY,ENTRY_DATE) "+
                        "values (@MESSAGE_STATUS,'1E',@FIRM,@TRADER_ID,@SECURITY_SYMBOL,@SIDE "+
	                        ",@VOLUME,@PRICE,@BOARD,@TIME,@ADD_CANCEL_FLAG, "+
	                        "@CONTACT,@RECEIVED_BY,@APPROVED_BY,@ENTRY_DATE)";
            Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrPTCore");
            DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
            DbPTCore.AddInParameter(cmd, "@MESSAGE_STATUS", DbType.String, MESSAGE_STATUS);
            DbPTCore.AddInParameter(cmd, "@FIRM", DbType.Int32, FIRM);
            DbPTCore.AddInParameter(cmd, "@TRADER_ID", DbType.Int32, TRADER_ID);
            DbPTCore.AddInParameter(cmd, "@SECURITY_SYMBOL", DbType.String, SECURITY_SYMBOL);
            DbPTCore.AddInParameter(cmd, "@SIDE", DbType.String, SIDE);
            DbPTCore.AddInParameter(cmd, "@VOLUME", DbType.Decimal, VOLUME);
            DbPTCore.AddInParameter(cmd, "@PRICE", DbType.Decimal, PRICE);
            DbPTCore.AddInParameter(cmd, "@BOARD", DbType.String, BOARD);
            DbPTCore.AddInParameter(cmd, "@TIME", DbType.Decimal, TIME);
            DbPTCore.AddInParameter(cmd, "@ADD_CANCEL_FLAG", DbType.String, ADD_CANCEL_FLAG);
            DbPTCore.AddInParameter(cmd, "@CONTACT", DbType.String, CONTACT);            
            DbPTCore.AddInParameter(cmd, "@RECEIVED_BY", DbType.String, RECEIVED_BY);
            DbPTCore.AddInParameter(cmd, "@APPROVED_BY", DbType.String, APPROVED_BY);
            DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.DateTime, DateTime.Now);
            //DbPTCore.AddInParameter(cmd, "@ENTRY_DATE", DbType.String, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return DbPTCore.ExecuteNonQuery(cmd);
        }        
    }
   
}
