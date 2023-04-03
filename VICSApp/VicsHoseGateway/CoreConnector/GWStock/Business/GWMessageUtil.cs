using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using GWStock.Business;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GWStock
{
    public class GWMessageUtil
    {
        static public string getFirm()
        {
            return ConfigurationManager.AppSettings["FirmID"].ToString();            
        }
        static string getTypeFromMessage(string message)
        {
            return message.Substring(0,2);
        }
        static public DataTable getMessage(string MessageType)
        {
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DataSet ds = DbHOGW.ExecuteDataSet("GetMessages", MessageType);
            return ds.Tables[0];
        }
        static public DataTable getMessage(Database db, string MessageType)
        {
            DataSet ds = db.ExecuteDataSet("GetMessages", MessageType);
            return ds.Tables[0];
        }
        static public DataTable get2GMessageFor1I(Database db)
        {
            DataSet ds = db.ExecuteDataSet("Get2GMessagesFor1I");
            return ds.Tables[0];
        }
        static public HOGW_1I get1I(Database db, int OrderNumber)
        {
            SqlDataReader rd = null;
            try
            {
                string sql = "select * from HOGW_1I where order_number = @OrderNumber";
                Database DbPTCore = DatabaseFactory.CreateDatabase("ConnStrHOGW");
                DbCommand cmd = DbPTCore.GetSqlStringCommand(sql);
                DbPTCore.AddInParameter(cmd, "@OrderNumber", DbType.Int32, OrderNumber);
                rd = (SqlDataReader)DbPTCore.ExecuteReader(cmd);
                HOGW_1I order = null; 
                while (rd.Read())
                {
                    order = new HOGW_1I();
                    order.BOARD = Convert.ToChar(rd["board"]);
                    order.CLIENT_ID = rd["client_id"].ToString();
                    order.FIRM = rd["firm"] == DBNull.Value ? 0 : Convert.ToInt32(rd["firm"]);
                    order.ID = rd["ID"] == DBNull.Value ? 0 : Convert.ToInt32(rd["ID"]);
                    order.LAST_MODIFIED = Convert.ToDateTime(rd["last_modified"]);
                    order.MESSAGE_STATUS = Convert.ToChar(rd["message_status"]);
                    order.MESSAGE_TYPE = Convert.ToString(rd["MESSAGE_TYPE"]);
                    order.ORDER_NUMBER = rd["ORDER_NUMBER"] == DBNull.Value ? 0 : Convert.ToDecimal(rd["ORDER_NUMBER"]);
                    order.PORT_CLIENT_FLAG = Convert.ToChar(rd["PORT_CLIENT_FLAG"]);
                    order.PRICE = Convert.ToString(rd["PRICE"]);
                    order.PUBLISHED_VOLUME = rd["PUBLISHED_VOLUME"] == DBNull.Value ? 0 : Convert.ToDecimal(rd["PUBLISHED_VOLUME"]);
                    order.SECURITY_SYMBOL = Convert.ToString(rd["security_symbol"]);
                    order.SIDE = Convert.ToChar(rd["SIDE"]);
                    order.TRADER_ID = Convert.ToString(rd["trader_id"]);
                    order.VOLUME = rd["VOLUME"] == DBNull.Value ? 0 : Convert.ToDecimal(rd["VOLUME"]);
                    order.ORDER_SESSION = Convert.ToString(rd["ORDER_SESSION"]);
                    //order.FILLER1 = Convert.ToString(rd["filler1"]);
                }
                rd.Close();
                return order;
            }
            catch
            {
                if (rd != null && !rd.IsClosed) rd.Close(); return null;
            }
        }
        //------ BUYER nhan 2L so sanh voi 3B da gui di truoc do (de approve cho seller) de xac nhan deal da KHOP ---
        //------ Da nhan tu 2L tuc la deal da duoc khop cho phia BUYER
        static public DataTable getData2L3B()
        {
            string sql = "select A.FIRM, A.CONTRA_FIRM, A.VOLUME, A.PRICE, A.CONFIRM_NUMBER, A.DEAL_ID, A.ID ID_2L, "+
                            "B.BUYER_CLIENT_ID, B.REPLY_CODE, B.ID ID_3B, B.Deal_id deal_id_3b " +
                        "from hogw_2l A INNER JOIN HOGW_3B B ON A.CONFIRM_NUMBER = B.CONFIRM_NUMBER "+
                        "WHERE B.message_status = 'S'";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DataSet ds = DbHOGW.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }
        static public DataTable getUnmatchedOrders()
        {
            string sql = "select A.ID AS ID_1I, A.MESSAGE_STATUS, A.FIRM,A.TRADER_ID,A.ORDER_NUMBER,A.CLIENT_ID,A.SECURITY_SYMBOL "+
                          ",A.SIDE,A.VOLUME,A.PUBLISHED_VOLUME,A.PRICE,A.BOARD,A.PORT_CLIENT_FLAG "+
                          ",B.ID as ID_2B,B.MESSAGE_TYPE,B.ORDER_NUMBER,B.ORDER_ENTRY_DATE, "+
                          "A.LAST_MODIFIED AS INSERT_DATE, B.LAST_MODIFIED AS REPLY_DATE "+
	                    "FROM HOGW_1I A inner join HOGW_2B B on A.ORDER_NUMBER = B.ORDER_NUMBER AND A.FIRM = B.FIRM "+
	                    "where A.ORDER_NUMBER NOT IN  "+
	                    "(	SELECT G.ORDER_NUMBER  "+
		                    "FROM HOGW_2E G inner join HOGW_2B H "+
		                    "on G.FIRM = H.FIRM AND G.ORDER_NUMBER = H.ORDER_NUMBER AND  "+
                            "G.ORDER_ENTRY_DATE = H.ORDER_ENTRY_DATE ) "+
                        " and A.MESSAGE_STATUS='S'";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DataSet ds = DbHOGW.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }        
        //-------- SELLER nhan 3B do BUYER gui qua HOSE de biet duoc deal duoc approve hay disapprove
        static public DataTable getData1G3B(string REPLY_CODE)
        {
            string sql = "SELECT A.[LAST_MODIFIED] " +
              ",A.[FIRM],A.[CONFIRM_NUMBER],A.[DEAL_ID], A.REPLY_CODE, A.[BUYER_CLIENT_ID],A.[BROKER_PORTFOLIO_VOLUME] " +
              ",A.[BROKER_CLIENT_VOLUME],A.[BROKER_MUTUAL_FUND_VOLUME],A.[BROKER_FOREIGN_VOLUME],B.[SELLER_FIRM] " +
              ",B.[SELLER_TRADER_ID],B.[SELLER_CLIENT_ID],B.BUYER_CONTRA_FIRM,B.[BUYER_TRADER_ID],B.[SECURITY_SYMBOL] " +
              ",B.[PRICE],B.[BOARD], A.ID AS ID_3B, B.ID AS ID_1G " +
            "FROM HOGW_3B A inner join HOGW_1G B " +
            "on A.DEAL_ID = B.DEAL_ID " +
            "where A.[MESSAGE_STATUS]='R' AND B.[MESSAGE_STATUS] = 'S' and A.REPLY_CODE = @REPLY_CODE";
            Database DbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
            DbCommand cmd = DbHOGW.GetSqlStringCommand(sql);
            DbHOGW.AddInParameter(cmd, "@REPLY_CODE", DbType.String, REPLY_CODE);
            DataSet ds = DbHOGW.ExecuteDataSet(cmd);
            return ds.Tables[0];
        }  
        static public void resetCTCITables()
        {
            Database DbHOGW = DatabaseFactory.CreateDatabase();
            //delete all records and reset identity
            DbHOGW.ExecuteNonQuery(CommandType.StoredProcedure, "ResetCTCITables");
        }
        static public void resetCTCITablesFlush()
        {
            Database DbHOGW = DatabaseFactory.CreateDatabase();
            //delete all records and reset identity
            DbHOGW.ExecuteNonQuery(CommandType.StoredProcedure, "ResetCTCITablesFlush");
        }
        static public void resetIdentityCTCITables()
        {
            Database DbHOGW = DatabaseFactory.CreateDatabase();
            //delete all records and reset identity
            DbHOGW.ExecuteNonQuery(CommandType.StoredProcedure, "ResetIdentityCTCITables");
        }
        static public void resetPRSTables()
        {
            Database DbHOGW = DatabaseFactory.CreateDatabase();
            //delete all records and reset identity
            DbHOGW.ExecuteNonQuery(CommandType.StoredProcedure, "ResetPRSTables");
        }
        static public void resetIdentityPRSTables()
        {
            Database DbHOGW = DatabaseFactory.CreateDatabase();
            //delete all records and reset identity
            DbHOGW.ExecuteNonQuery(CommandType.StoredProcedure, "ResetIdentityPRSTables");
        }
        static public void createTestData()
        {
            Database DbHOGW = DatabaseFactory.CreateDatabase();
            DbHOGW.ExecuteNonQuery(CommandType.StoredProcedure, "CreateTestData");
        }
        static public int GetTraderIDByUser(Database db, object User)
        {
            string sql = "select TRADER_ID from MAP_TRADER where CORE_USER = @CoreUser";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@CoreUser", DbType.String, User);
            object o = db.ExecuteScalar(cmd);
            if (o != null)
                return (int)o;
            else return -1; 
        }
        static public int GetTraderIDByTradeCode(Database db, object TradeCode)
        {
            string sql = "select TRADER_ID from MAP_TRADER where CORE_TRADE_CODE = @TradeCode";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@TradeCode", DbType.String, TradeCode);
            object o = db.ExecuteScalar(cmd);
            if (o != null)
                return (int)o;
            else return -1;
        }
        //------------------------------------------
        //------------------------------------------

        static public int insert1F(Database db, object firmID, object BuyerTraderID, object BuyerID, object SellerID, object StockCode
                    , object OrderPrice, object BoardType, object DealID, object BuyerPortfolioVolume, object BuyerClientVolume
                    , object BuyerMutualFundVolume, object BuyerForeignVolume, object SellerPortfolioVolume, object SellerClientVolume
                    , object SellerMutualFundVolume, object SellerForeignVolume)
        {
            return db.ExecuteNonQuery("Insert_1F", firmID, BuyerTraderID, BuyerID, SellerID, StockCode
            , OrderPrice, BoardType, DealID, BuyerPortfolioVolume, BuyerClientVolume
            , BuyerMutualFundVolume, BuyerForeignVolume, SellerPortfolioVolume, SellerClientVolume
            , SellerMutualFundVolume, SellerForeignVolume);
        }
        static public int insert1G(Database db, object SellerFirm, object SellerTraderID, object SellerID, object BuyerFirm
                    , object BuyerTraderID, object StockCode
                    , object OrderPrice, object BoardType, object DealID, object BrokerPortfolioVolume, object BrokerClientVolume
                    , object BrokerMutualFundVolume, object BrokerForeignVolume)
        {
            return db.ExecuteNonQuery("Insert_1G", SellerFirm, SellerTraderID, SellerID, BuyerFirm
                    , BuyerTraderID, StockCode
                    , OrderPrice, BoardType, DealID, BrokerPortfolioVolume, BrokerClientVolume
                    , BrokerMutualFundVolume, BrokerForeignVolume);
        }
        static public int insert1E(Database db, object Firm, object TraderID, object SecuritySymbol
            , object Side, object Volume, object Price, object Board, object Time, object AddCancel, object Contact)
        {
            return db.ExecuteNonQuery("Insert_1E", Firm, TraderID, SecuritySymbol
                , Side, Volume, Price, Board, Time, AddCancel, Contact);
        }
        static public int insert1I(Database db, object Firm, object TraderID, object OrderNumber, object ClientID, object SecuritySymbol
                , object Side, object Volume, object PublishedVolume, object Price, object Board, object PortFlag, object OrderSession)
        {
            return db.ExecuteNonQuery("Insert_1I", Firm, TraderID, OrderNumber, ClientID, SecuritySymbol
                , Side, Volume, PublishedVolume, Price, Board, PortFlag, OrderSession);
        }
        static public int insert1C(Database db, object Firm, object OrderNumber, object OrderEntryDate)                
        {
            return db.ExecuteNonQuery("Insert_1C", Firm, OrderNumber, OrderEntryDate);
        }
        static public int insert1D(Database db, object Firm, object OrderNumber, object OrderEntryDate, object ClientID)
        {
            return db.ExecuteNonQuery("Insert_1D", Firm, OrderNumber, OrderEntryDate, ClientID);
        }                            
        static public int insert3B(Database db, object BuyerFirm, object ConfirmNumber, object DealID, object BuyerClientID, object ReplyCode, 
            object BrokerPortfolioVolume, object BrokerClientVolume, object BrokerMutualFundVolume, object BrokerForeignVolume)
        {
            int r = db.ExecuteNonQuery("Insert_3B", BuyerFirm, ConfirmNumber, DealID, BuyerClientID, ReplyCode, 
                BrokerPortfolioVolume, BrokerClientVolume, BrokerMutualFundVolume, BrokerForeignVolume);
            return r;
        }
        static public int insert3D(Database db, object Firm, object ConfirmNumber, object ReplyCode)
        {
            return db.ExecuteNonQuery("Insert_3D", Firm, ConfirmNumber, ReplyCode);
        }
        static public int insert3C(Database db, object Firm, object ContraFirm, object SellerTraderID, object ConfirmNumber,
               object SecuritySymbol, object Side)
        {
            return db.ExecuteNonQuery("Insert_3C", Firm, ContraFirm, SellerTraderID, ConfirmNumber, SecuritySymbol, Side);
        }
        static public int updateMessageStatus(Database db, object MessageType, object ID, object NewStatus)
        {
            return db.ExecuteNonQuery("UpdateMessageStatus", MessageType, ID, NewStatus);
        }
              
    }
}
