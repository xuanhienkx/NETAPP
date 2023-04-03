using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using PTStock;

namespace PTConnectorWS
{
   /// <summary>
   /// Summary description for PTConnectorWS
   /// </summary>
   [WebService(Namespace = "http://tempuri.org/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [ToolboxItem(false)]
   // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   // [System.Web.Script.Services.ScriptService]
   public class PTConnectorWS : System.Web.Services.WebService
   {

      [WebMethod]
      public PT_ADVERTISEMENT[] GetAdvOrders()
      {
         return PT.linqGetAdvOrders();
      }
      [WebMethod]
      public PT_ADVERTISEMENT_ANNOUCEMENT[] GetAdvAnnounces()
      {
         return PT.linqGetAdvAnnounces();
      }
      [WebMethod]
      public PT_ONE_FIRM_DEAL[] Get1FirmOrders()
      {
         return PT.linqGet1FirmOrders();
      }
      [WebMethod]
      public PT_TWO_FIRM_DEAL_BUYER[] GetBuyerOrders()
      {
         return PT.linqGetBuyerOrders();
      }
      [WebMethod]
      public PT_TWO_FIRM_DEAL_SELLER[] GetSellerOrders()
      {
         return PT.linqGetSellerOrders();
      }

      //-----------get messages according to message status USING LINQ -----------

      [WebMethod]
      public PT_ADVERTISEMENT[] GetAdvOrdersByStatusLINQ(string messageStatus)
      {
         return PT.linqGetAdvOrders(messageStatus);
      }
      [WebMethod]
      public PT_ADVERTISEMENT_ANNOUCEMENT[] GetAdvAnnouncesByStatusLINQ(string messageStatus)
      {
         return PT.linqGetAdvAnnounces(messageStatus);
      }
      [WebMethod]
      public PT_ONE_FIRM_DEAL[] Get1FirmOrdersByStatusLINQ(string messageStatus)
      {
         return PT.linqGet1FirmOrders(messageStatus);
      }
      [WebMethod]
      public PT_TWO_FIRM_DEAL_BUYER[] GetBuyerOrdersByStatusLINQ(string messageStatus)
      {
         return PT.linqGetBuyerOrders(messageStatus);
      }
      [WebMethod]
      public PT_TWO_FIRM_DEAL_SELLER[] GetSellerOrdersByStatusLINQ(string messageStatus)
      {
         return PT.linqGetSellerOrders(messageStatus);
      }

      //-----------get messages according to message status USE SqlData as normal (NOT LINQ) -----------

      [WebMethod]
      public ADVERTISEMENT[] GetAdvOrdersByStatus(string messageStatus)
      {
         return PT.ptGetAdvOrdersList(messageStatus).ToArray();
      }
      [WebMethod]
      public ADVERTISEMENT_ANNOUCEMENT[] GetAdvAnnouncesByStatus(string messageStatus)
      {
         return PT.ptGetAdvAnnouncementList(messageStatus).ToArray();
      }
      [WebMethod]
      public ONE_FIRM_DEAL[] Get1FirmOrdersByStatus(string messageStatus)
      {
         List<ONE_FIRM_DEAL> lst = PT.ptGet1FirmOrdersList(messageStatus);
         if (lst != null) return lst.ToArray(); else return null;
      }
      [WebMethod]
      public TWO_FIRM_DEAL_BUYER[] GetBuyerOrdersByStatus(string messageStatus)
      {
         return PT.ptGetBuyerOrdersList(messageStatus).ToArray();
      }
      [WebMethod]
      public TWO_FIRM_DEAL_SELLER[] GetSellerOrdersByStatus(string messageStatus)
      {
         return PT.ptGetSellerOrdersList(messageStatus).ToArray();
      }

      //------------- UPDATE MESSAGE STATUS ------------------
      [WebMethod]
      public int UpdateSeller(long DealID, string NewStatus, int ConfirmNumber, string Side)
      {
         return PT.ptUpdateSeller(DealID, NewStatus, ConfirmNumber, Side);
      }
      [WebMethod]
      public int UpdateBuyer(long DealID, string NewStatus, int ConfirmNumber)
      {
         return PT.ptUpdateBuyer(DealID, NewStatus, ConfirmNumber);
      }
      [WebMethod]
      public int Update1Firm(long DealID, string NewStatus, int ConfirmNumber)
      {
         return PT.ptUpdate1Firm(DealID, NewStatus, ConfirmNumber);
      }
      [WebMethod]
      public int UpdateBuyerStatus(long DealID, string NewStatus)
      {
         return PT.ptUpdateBuyerStatus(DealID, NewStatus);
      }
      [WebMethod]
      public int UpdateBuyerStatusByUser(long DealID, string NewStatus, string USERNAME)
      {
         return PT.ptUpdateBuyerStatusByUser(DealID, NewStatus, USERNAME);
      }
      [WebMethod]
      public int UpdateBuyerStatusByConfirmNumber(int CONFIRM_NUMBER, string NewStatus)
      {
         return PT.ptUpdateBuyerStatusByConfirmNumber(CONFIRM_NUMBER, NewStatus);
      }
      [WebMethod]
      public int UpdateSellerStatus(long DealID, string NewStatus)
      {
         return PT.ptUpdateSellerStatus(DealID, NewStatus);
      }
      [WebMethod]
      public int UpdateSellerStatusByUser(long DealID, string NewStatus, string USERNAME)
      {
         return PT.ptUpdateSellerStatusByUser(DealID, NewStatus, USERNAME);
      }
      [WebMethod]
      public int UpdateSellerStatusByConfirmNumber(int CONFIRM_NUMBER, string NewStatus)
      {
         return PT.ptUpdateSellerStatusByConfirmNumber(CONFIRM_NUMBER, NewStatus);
      }
      [WebMethod]
      public int UpdateBuyerConfirmNumber(long DealID, int ConfirmNumber)
      {
         return PT.ptUpdateBuyerConfirmNumber(DealID, ConfirmNumber);
      }
      [WebMethod]
      public int UpdateSellerConfirmNumber(long DealID, int ConfirmNumber)
      {
         return PT.ptUpdateSellerConfirmNumber(DealID, ConfirmNumber);
      }
      [WebMethod]
      public int Update1FirmConfirmNumber(long DealID, int ConfirmNumber)
      {
         //return PT.ptUpdate1FirmConfirmNumber(DealID, ConfirmNumber);
         return PT.ptUpdate1FirmConfirmNumber(DealID, ConfirmNumber);
      }
      [WebMethod]
      public int Update1FirmStatus(long DealID, string NewStatus)
      {
         return PT.ptUpdate1FirmStatus(DealID, NewStatus);
      }
      [WebMethod]
      public int Update1FirmStatusByConfirmNumber(int CONFIRM_NUMBER, string NewStatus)
      {
         return PT.ptUpdate1FirmStatusByConfirmNumber(CONFIRM_NUMBER, NewStatus);
      }
      [WebMethod]
      public int Update1FirmStatusByUser(long DealID, string NewStatus, string UserName)
      {
         return PT.ptUpdate1FirmStatusByUser(DealID, NewStatus, UserName);
      }
      [WebMethod]
      public int UpdateAdvStatus(long ID, string NewStatus)
      {
         return PT.ptUpdateAdvStatus(ID, NewStatus);
      }
      [WebMethod]
      public int UpdateAdvStatusByUser(long ID, string NewStatus, string UserName)
      {
         return PT.ptUpdateAdvStatusByUser(ID, NewStatus, UserName);
      }
      [WebMethod]
      public int UpdateAdvAnnouncementStatus(long ID, string NewStatus)
      {
         return PT.ptUpdateAdvAnnouncementStatus(ID, NewStatus);
      }

      //-------------- Insert -----------------
      [WebMethod]
      public int InsertBuyerDeal(string MESSAGE_STATUS, int BUYER_FIRM, int BUYER_TRADER_ID
                      , string SIDE, int SELLER_CONTRA_FIRM, int SELLER_TRADER_ID, string SECURITY_SYMBOL, double VOLUME, double PRICE
                      , string BOARD, int CONFIRM_NUMBER, string RECEIVED_BY, string APPROVED_BY)
      {
         return PT.linqInsertBuyerDeal(MESSAGE_STATUS, BUYER_FIRM, BUYER_TRADER_ID
                     , SIDE, SELLER_CONTRA_FIRM, SELLER_TRADER_ID, SECURITY_SYMBOL, VOLUME, PRICE
                     , BOARD, CONFIRM_NUMBER, RECEIVED_BY, APPROVED_BY);
      }
      [WebMethod]
      public int InsertAdvAnnouncement(string MESSAGE_STATUS, int FIRM, int TRADER_ID, string SECURITY_SYMBOL
              , string SIDE, double VOLUME, double PRICE, string BOARD, string TIME, string ADD_CANCEL_FLAG, string CONTACT,
              string RECEIVED_BY, string APPROVED_BY)
      {
         return PT.linqInsertAdvAnnouncement(MESSAGE_STATUS, FIRM, TRADER_ID, SECURITY_SYMBOL
             , SIDE, VOLUME, PRICE, BOARD, TIME, ADD_CANCEL_FLAG, CONTACT,
             RECEIVED_BY, APPROVED_BY);
      }
      [WebMethod]
      public int InsertSellerDeal(string MessageStatus, int SellerFirm, int SellerTraderID, string SellerID, int BuyerFirm
                  , int BuyerTraderID, string StockCode
                  , string Price, string BoardType, double BrokerPortfolioVolume, double BrokerClientVolume
                  , double BrokerMutualFundVolume, double BrokerForeignVolume, string ReceivedBy, string ApprovedBy)
      {
         return PT.linqInsertSellerDeal(MessageStatus, SellerFirm, SellerTraderID, SellerID, BuyerFirm
                 , BuyerTraderID, StockCode
                 , Price, BoardType, BrokerPortfolioVolume, BrokerClientVolume
                 , BrokerMutualFundVolume, BrokerForeignVolume, ReceivedBy, ApprovedBy);
      }
      [WebMethod]
      public int Insert1FirmDeal(string MESSAGE_STATUS, int FIRM, int TRADER_ID, string BUYER_CLIENT_ID
          , string SELLER_CLIENT_ID, string SECURITY_SYMBOL, double PRICE, string BOARD, double BUYER_PORTFOLIO_VOLUME
          , double BUYER_CLIENT_VOLUME, double BUYER_MUTUAL_FUND_VOLUME, double BUYER_FOREIGN_VOLUME
          , double SELLER_PORTFOLIO_VOLUME, double SELLER_CLIENT_VOLUME, double SELLER_MUTUAL_FUND_VOLUME, double SELLER_FOREIGN_VOLUME
          , string RECEIVED_BY, string APPROVED_BY)
      {
         return PT.linqInsert1FirmDeal(MESSAGE_STATUS, FIRM, TRADER_ID, BUYER_CLIENT_ID
         , SELLER_CLIENT_ID, SECURITY_SYMBOL, PRICE, BOARD, BUYER_PORTFOLIO_VOLUME
         , BUYER_CLIENT_VOLUME, BUYER_MUTUAL_FUND_VOLUME, BUYER_FOREIGN_VOLUME
         , SELLER_PORTFOLIO_VOLUME, SELLER_CLIENT_VOLUME, SELLER_MUTUAL_FUND_VOLUME, SELLER_FOREIGN_VOLUME
         , RECEIVED_BY, APPROVED_BY);
      }
      [WebMethod]
      public int InsertAdv(string MESSAGE_STATUS, string MESSAGE_TYPE, int FIRM, int TRADER_ID, string SECURITY_SYMBOL, string SIDE
              , double VOLUME, double PRICE, string BOARD, string TIME, string ADD_CANCEL_FLAG,
              string CONTACT, string RECEIVED_BY, string APPROVED_BY)
      {
         return PT.linqInsertAdv(MESSAGE_STATUS, MESSAGE_TYPE, FIRM, TRADER_ID, SECURITY_SYMBOL, SIDE
             , VOLUME, PRICE, BOARD, TIME, ADD_CANCEL_FLAG,
             CONTACT, RECEIVED_BY, APPROVED_BY);
      }

      [WebMethod]
      public int Get1FirmOrderSeqBuy(int OrderNumber)
      {
         return PT.ptGet1FirmOrderSeqBuy(OrderNumber);
      }
      [WebMethod]
      public int Get1FirmOrderSeqSell(int OrderNumber)
      {
         return PT.ptGet1FirmOrderSeqSell(OrderNumber);
      }
      [WebMethod]
      public int GetSellerOrderSeq(int OrderNumber)
      {
         return PT.ptGetSellerOrderSeq(OrderNumber);
      }
      [WebMethod]
      public int GetBuyerOrderSeq(int OrderNumber)
      {
         return PT.ptGetBuyerOrderSeq(OrderNumber);
      }

      /////////////// Vinh - refactoring ////////////
      [WebMethod]
      public int UpdateAdvACFlag(long id, string newFlag)
      {
         return PT.ptUpdateAdvACFlag(id, newFlag);
      }

      [WebMethod]
      public DataTable GetBuyerOrdersByTraderID(string messageStatus, int TraderID)
      {
         return PT.ptGetBuyerOrdersByTraderID(messageStatus, TraderID);
      }

      [WebMethod]
      public List<PT_FIRM> GetAllFirms()
      {
         return Firm.GetAllFirms();
      }

      [WebMethod]
      public List<PT_FIRM> GetFirmsAreNotCurrentFirm(int currentFirm)
      {
         return Firm.GetFirmsAreNotCurrentFirm(currentFirm);
      }

      [WebMethod]
      public List<PT_TRADER> GetTraders(int firmId)
      {
         return Firm.GetTraders(firmId);
      }

      [WebMethod]
      public int GetTraderIdByUser(string username)
      {
         return Firm.GetTraderIdByUser(username);
      }

      [WebMethod]
      public LoginResult Login(string username, string password)
      {
         return Authen.login(username, password);
      }

      [WebMethod]
      public int PTInsertAdv(object MESSAGE_STATUS, object MESSAGE_TYPE, object FIRM, object TRADER_ID, object SECURITY_SYMBOL, object SIDE
              , object VOLUME, object PRICE, object BOARD, object TIME, object ADD_CANCEL_FLAG,
                object CONTACT, object RECEIVED_BY, object APPROVED_BY)
      {
         return PT.ptInsertAdv(MESSAGE_STATUS, MESSAGE_TYPE, FIRM, TRADER_ID, SECURITY_SYMBOL, SIDE
              , VOLUME, PRICE, BOARD, TIME, ADD_CANCEL_FLAG,
                 CONTACT, RECEIVED_BY, APPROVED_BY);
      }

      [WebMethod]
      public int PTInsertSellerDeal(object MessageStatus, object SellerFirm, object SellerTraderID, object SellerID, object BuyerFirm
                    , object BuyerTraderID, object StockCode
                    , object Price, object BoardType, object BrokerPortfolioVolume, object BrokerClientVolume
                    , object BrokerMutualFundVolume, object BrokerForeignVolume, object ReceivedBy,
                    object ApprovedBy, object CoreOrderSeq)
      {
         return PT.ptInsertSellerDeal(MessageStatus, SellerFirm, SellerTraderID, SellerID, BuyerFirm
                    , BuyerTraderID, StockCode
                    , Price, BoardType, BrokerPortfolioVolume, BrokerClientVolume
                    , BrokerMutualFundVolume, BrokerForeignVolume, ReceivedBy,
                     ApprovedBy, CoreOrderSeq);
      }

      [WebMethod]
      public int PTInsert1FirmDeal(object MESSAGE_STATUS, object FIRM, object TRADER_ID, object BUYER_CLIENT_ID
         , object SELLER_CLIENT_ID, object SECURITY_SYMBOL, object PRICE, object BOARD, object BUYER_PORTFOLIO_VOLUME
         , object BUYER_CLIENT_VOLUME, object BUYER_MUTUAL_FUND_VOLUME, object BUYER_FOREIGN_VOLUME
         , object SELLER_PORTFOLIO_VOLUME, object SELLER_CLIENT_VOLUME, object SELLER_MUTUAL_FUND_VOLUME, object SELLER_FOREIGN_VOLUME
            , object RECEIVED_BY, object APPROVED_BY, object CORE_ORDER_SEQ_BUY, object CORE_ORDER_SEQ_SELL)
      {
         return PT.ptInsert1FirmDeal(MESSAGE_STATUS, FIRM, TRADER_ID, BUYER_CLIENT_ID
         , SELLER_CLIENT_ID, SECURITY_SYMBOL, PRICE, BOARD, BUYER_PORTFOLIO_VOLUME
         , BUYER_CLIENT_VOLUME, BUYER_MUTUAL_FUND_VOLUME, BUYER_FOREIGN_VOLUME
         , SELLER_PORTFOLIO_VOLUME, SELLER_CLIENT_VOLUME, SELLER_MUTUAL_FUND_VOLUME, SELLER_FOREIGN_VOLUME
            , RECEIVED_BY, APPROVED_BY, CORE_ORDER_SEQ_BUY, CORE_ORDER_SEQ_SELL);
      }

      [WebMethod]
      public void ResetIdentityPTDealTables()
      {
         PT.ResetIdentityPTDealTables();
      }

      [WebMethod]
      public void ResetPTDealTables()
      {
         PT.ResetPTDealTables();
      }

      [WebMethod]
      public int UpdateBuyerStatusByUserWithOldStatus(object DealID, object OldStatus, object NewStatus, object USERNAME)
      {
         return PT.ptUpdateBuyerStatusByUser(DealID, OldStatus, NewStatus, USERNAME);
      }

      [WebMethod]
      public int UpdateBuyerClient(object DealID, object BuyerClient)
      {
         return PT.ptUpdateBuyerClient(DealID, BuyerClient);
      }

      [WebMethod]
      public int UpdateBuyerCoreSeq(object DealID, object Seq)
      {
         return PT.ptUpdateBuyerCoreSeq(DealID, Seq);
      }

      [WebMethod]
      public int GetBuyerOrdersCountByTrader(string messageStatus, int traderID)
      {
         return PT.ptGetBuyerOrdersCountByTrader(messageStatus, traderID);
      }
   }
}
