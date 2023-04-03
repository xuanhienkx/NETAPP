using System;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Data;
using SBSCore.HnxGateway;
using SBSCore.Security;
using SBSCore.Domain;
using SBSCore.Common;
using SBSCore;
using System.Xml;
using SBSCore.Report;

namespace AgencyWebService
{
   /// <summary>
   /// Summary description for GateWay
   /// </summary>
   [WebService(Namespace = "http://www.vics.com.vn/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [ToolboxItem(false)]
   public class GateWay : WebService
   {
      #region Private

      private const string MESSAGE = "Thông tin đăng nhập bị sai hoặc đã hết phiên làm việc. Yêu cầu đăng nhập lại";

      private static UserLite Authorize(string key)
      {
         UserLite uInfo = TokenKey.GetCache(CryptoEngine.Decrypt(key)) as UserLite;
         if (uInfo == null)
            throw new Exception(MESSAGE);
         return uInfo;
      }

      private static DateTime Convert2SmallDateTime(DateTime time)
      {
         return time.Add(-time.TimeOfDay);
      }

      #endregion

      #region Security & Common

      [WebMethod]
      public string HelloVics()
      {
         return "Hello Vics";
      }

      [WebMethod]
      public string GetAuthorize(string username, string password)
      {
         return TokenKey.GetAuthorizeAndCreateKey(username, password, Context.Request.UserHostAddress);
      }

      [WebMethod]
      public void ClearTokenKey(string key)
      {
         TokenKey.RemoveKey(CryptoEngine.Decrypt(key));
      }

      [WebMethod]
      public UserLite GetUser(string key, string username)
      {
         UserLite uInfo = Authorize(key);
         if (uInfo != null)
            return uInfo;
         return UserLite.GetUser(username, string.Empty);
      }

      [WebMethod]
      public List<UserLite> FindUsers(string key, string username)
      {
         UserLite uInfo = Authorize(key);
         return UserLite.Find(username, uInfo);
      }

      [WebMethod]
      public List<UserLite> GetUserList(string key, int groupId)
      {
         UserLite uInfo = Authorize(key);
         return UserLite.GetList(groupId, uInfo);
      }

      [WebMethod]
      public UserLite InsertOrUpdateUser(string key, UserLite user)
      {
         UserLite uInfo = Authorize(key);
         return UserLite.InsertOrUpdate(uInfo, user);
      }

      [WebMethod]
      public void DeleteUser(string key, int userId)
      {
         UserLite uInfo = Authorize(key);
         UserLite.Delete(userId);
      }

      [WebMethod]
      public void ChangeUserPassword(string key, int userId, string newPassword)
      {
         Authorize(key);
         UserLite.ChangePassword(userId, newPassword);
      }

      [WebMethod]
      public List<UserGroup> GetGroups(string key)
      {
         UserLite user = Authorize(key);
         return UserGroup.GetList(user.BranchCode, user.TradeCode);
      }

      [WebMethod]
      public DateTime GetCurrentTransactionDate(string key)
      {
         UserLite uInfo = Authorize(key);
         return SBSDal.GetCurrentTransaction(uInfo.BranchCode);
      }

      [WebMethod]
      public DateTime GetTDate(string key, DateTime tradingDate, int numberOfDay, bool isNextDay)
      {
         UserLite uInfo = Authorize(key);
         return SBSDal.GetT3Date(uInfo.BranchCode, Convert2SmallDateTime(tradingDate), numberOfDay, isNextDay);
      }

      [WebMethod]
      public List<GLStockCode> GetStockList(string key, string board)
      {
         UserLite uInfo = Authorize(key);
         return GLStockCode.GetStockList(board);
      }

      [WebMethod]
      public List<string> GetGroupPermission(string key, int groupId)
      {
         UserLite uInfo = Authorize(key);
         if (groupId > 0)
            return UserGroup.GetGroupPermission(groupId);
         return UserGroup.GetGroupPermission(uInfo.GroupId);
      }

      [WebMethod]
      public void SetGroupPermission(string key, int groupId, List<string> rights)
      {
         UserLite uInfo = Authorize(key);
         UserGroup.SetGroupPermission(groupId, rights);
      }

      [WebMethod]
      public UserGroup InsertOrUpdateUserGroup(string key, UserGroup group)
      {
         UserLite uInfo = Authorize(key);
         return UserGroup.InsertOrUpdate(uInfo, group);
      }

      [WebMethod]
      public void DeleteUserGroup(string key, int groupId)
      {
         UserLite uInfo = Authorize(key);
         UserGroup.Delete(groupId);
      }

      [WebMethod]
      public List<Department> GetDepartmentList(string key)
      {
         UserLite uInfo = Authorize(key);
         return Department.GetList(uInfo.BranchCode);
      }

      private System.Xml.XmlNode GenXMLError(int intErrorCode, string strErrorMsg)
      {

         // Build the detail element of the SOAP fault.
         System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
         System.Xml.XmlNode node = doc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

         System.Xml.XmlNode details = doc.CreateNode(XmlNodeType.Element, "ErrorDescription", "http://vics.com.vn/");
         XmlAttribute attrErrorCode = doc.CreateAttribute("C", "ErrorCode", "http://vics.com.vn/");
         attrErrorCode.Value = intErrorCode.ToString();
         details.Attributes.Append(attrErrorCode);

         XmlAttribute attrErrorMsg = doc.CreateAttribute("M", "ErrorMessage", "http://vics.com.vn/");
         attrErrorMsg.Value = strErrorMsg;
         details.Attributes.Append(attrErrorMsg);

         // Append the two child elements to the detail node.
         node.AppendChild(details);

         return node;
      }


      #endregion

      #region Order

      //[WebMethod]
      //public TradingSession GetTradingSession(string key, string boardTypeList)
      //{
      //   try
      //   {
      //      UserLite uInfo = Authorize(key);

      //      var tradingSession = Util.HNXGateway.GetTradingSession(boardTypeList);
      //      if (tradingSession.TradingSessionStatus == TradingSessionStatus.Normal ||
      //       tradingSession.TradingSessionStatus == TradingSessionStatus.AfterCb ||
      //       tradingSession.TradingSessionStatus == TradingSessionStatus.Prolong)
      //      {
      //         var modeString = tradingSession.TradingSessionMode.ToString();
      //         if (modeString.EndsWith("UP"))
      //            modeString = modeString.Substring(0, modeString.Length - 2);
      //         if (modeString.EndsWith("BL"))
      //            modeString = modeString.Substring(0, modeString.Length - 3);
      //         return (TradingSession)Enum.Parse(typeof(TradingSession), modeString);
      //      }
      //      return TradingSession.NONE;
      //   }
      //   catch (Exception ex)
      //   {
      //      throw new SoapException(ex.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, this.GenXMLError(1, ex.Message));
      //   }
      //}

      [WebMethod]
      public InquiryData GetInquiryData(string key, InquiryData order, DateTime tradingDate)
      {
         try
         {
            UserLite uInfo = Authorize(key);
            return InquiryData.GetData(order, Convert2SmallDateTime(tradingDate), uInfo);
         }
         catch (Exception ex)
         {
            throw new SoapException(ex.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, this.GenXMLError(1, ex.Message));
         }
      }

      [WebMethod]
      public List<Order> SubmitOrderInfo(string key, InquiryData orderInfo, DateTime tradingDate)
      {
         try
         {
            UserLite uInfo = Authorize(key);
            List<Order> result = new List<Order>();
            result.Add(Order.SubmitInfo(orderInfo, Convert2SmallDateTime(tradingDate), uInfo));
            return result;
         }
         catch (Exception e)
         {
            throw new SoapException(e.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, e);
         }
      }

      [WebMethod]
      public List<Order> GetOrderList(string key, DateTime orderDate, string customerId, string stockCode, string orderStatus, string receivedBy, string orderSide, int session, string boardType)
      {
         UserLite uInfo = Authorize(key);
         return Order.GetList(Convert2SmallDateTime(orderDate),
            uInfo.BranchCode,
            uInfo.TradeCode,
            stockCode,
            customerId,
            orderStatus,
            receivedBy,
            orderSide,
            session,
            boardType,
            string.Empty,
            false);
      }

      [WebMethod]
      public List<Order> GetListForCancel(string key, string boardType, string customerId, string stockCode, string orderSide, DateTime transDate)
      {
         try
         {
            UserLite user = Authorize(key);
            return Order.GetListForCancel(boardType, customerId, stockCode, orderSide, Convert2SmallDateTime(transDate), user);
         }
         catch (Exception ex)
         {
            throw new SoapException(ex.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, this.GenXMLError(1, ex.Message));
         }

      }

      [WebMethod]
      public void CancelOrder(string key, string boardType, string orderNumber)
      {
         UserLite user = Authorize(key);
         Order.Cancel(boardType, orderNumber, user.UserName);
      }

      [WebMethod]
      public void ApproveOrder(string key, DateTime tradingDate, string boardType, int orderSeq)
      {
         UserLite user = Authorize(key);
         Order.approveOrder(Convert2SmallDateTime(tradingDate), orderSeq, user.UserName, user.BranchCode);
      }

      [WebMethod]
      public void DeleteOrder(string key, DateTime tradingDate, int orderSeq)
      {
         UserLite user = Authorize(key);
         Order.deleteOrder(Convert2SmallDateTime(tradingDate), orderSeq, user.UserName);
      }

      [WebMethod]
      public List<Order> GetDayCanceledOrModifiedList(string key, string boardType, bool forCancel, DateTime transDate)
      {
         UserLite user = Authorize(key);
         return Order.GetDayCanceledOrModifiedList(boardType, Convert2SmallDateTime(transDate), forCancel, user);
      }

      [WebMethod]
      public void ModifyHnxAndUpcomOrder(string key, string boardType, int orderSeq, string orderNumber, InquiryData orderInfo, InquiryData modifiedOrderInfo, DateTime transDate, decimal newHoldValue)
      {
         UserLite uInfo = Authorize(key);
         Order.ModifyHnxAndUpcomOrder(boardType, orderSeq, orderNumber, orderInfo, modifiedOrderInfo, transDate, uInfo, newHoldValue);
      }

      [WebMethod]
      public string GetCurrentTradingSession(string key, string stockCode, string boardType)
      {
         UserLite user = Authorize(key);
         return Util.CommonService.GetCurrentTradingSession(Util.CoreGatewayUserName, Util.CoreGatewayPassword, stockCode,
                                                     boardType);
      }

      #endregion

      #region Customer

      [WebMethod]
      public Customer GetCustomerForRegister(string key, string customerId)
      {
         UserLite uInfor = Authorize(key);
         return Customer.GetCustomer(customerId, uInfor.BranchCode, string.Empty); // tradecode = empty to get all the customerid belongs to branch
      }

      [WebMethod]
      public List<Customer> FindCustomers(string key, string customerId, string customserName, string cardID)
      {
         UserLite uInfor = Authorize(key);
         return Customer.Find(customerId, customserName, cardID, uInfor.BranchCode, uInfor.TradeCode);
      }

      [WebMethod]
      public List<Customer> GetCustomersTakeCared(string key)
      {
         UserLite uInfor = Authorize(key);
         return Customer.FindByTakeCared(uInfor.BranchCode, uInfor.TradeCode, uInfor.UserId);
      }

      [WebMethod]
      public List<InquiryStock> GetCustomerStocks(string key, string customerId, DateTime tradingDate)
      {
         UserLite uInfor = Authorize(key);
         return InquiryStock.GetStock(customerId, uInfor.BranchCode, Convert2SmallDateTime(tradingDate));
      }

      [WebMethod]
      public List<CustomerService> GetCustomerServices(string key, string customerId)
      {
         UserLite uInfor = Authorize(key);
         return CustomerService.CustomerServiceGetList(customerId);
      }

      [WebMethod]
      public List<OnlineBank> GetOnlineBank(string key)
      {
         UserLite uInfor = Authorize(key);
         return OnlineBank.GetList(uInfor.BranchCode);
      }

      [WebMethod]
      public void RegisterCustomer(string key, string customerId, string customerTradeCode)
      {
         UserLite uInfo = Authorize(key);
         Customer.Register(customerId, customerTradeCode, uInfo);
      }

      [WebMethod]
      public void UnRegisterCustomer(string key, string customerId)
      {
         UserLite uInfo = Authorize(key);
         Customer.UnRegister(customerId, uInfo);
      }

      [WebMethod]
      public CustomerProxy GetCustomerProxy(string key, string customerId)
      {
         UserLite uInfor = Authorize(key);
         return CustomerProxy.GetCustomerProxy(customerId);
      }

      [WebMethod]
      public CustomerDetail GetCustomerDetail(string key, string customerId)
      {
         UserLite uInfor = Authorize(key);
         return CustomerDetail.GetCustomerDetail(customerId);
      }


      #endregion

      #region Agency

      [WebMethod]
      public AgencyFee GetAgencyFee(string key, int Id)
      {
         UserLite uInfor = Authorize(key);
         return AgencyFee.GetAgencyFee(Id);
      }

      [WebMethod]
      public List<AgencyFee> GetAgencyFeeByTradeCode(string key)
      {
         UserLite uInfor = Authorize(key);
         return AgencyFee.GetAgencyFeeByTradeCode(uInfor.TradeCode);
      }

      [WebMethod]
      public void NewAgencyFee(string key, int valueFrom, int toValue, decimal fee, string note)
      {
         UserLite uInfor = Authorize(key);
         AgencyFee.NewAgencyFee(uInfor.TradeCode, valueFrom, toValue, fee, note);
      }

      [WebMethod]
      public void EditAgencyFee(string key, int ID, int valueFrom, int toValue, decimal fee, string note)
      {
         UserLite uInfor = Authorize(key);
         AgencyFee.EditAgencyFee(uInfor.TradeCode, ID, valueFrom, toValue, fee, note);
      }


      [WebMethod]
      public void DeleteAgencyFee(string key, int Id)
      {
         UserLite uInfor = Authorize(key);
         AgencyFee.DeleteAgencyFee(Id);
      }
      #endregion

      #region Report

      [WebMethod]
      public SBSCore.PorscheGateway.BalanceTransactionDataSource GetBalanceTransaction(string key, string bankGl, string sectionGl, string accountId, string accountType, DateTime fromDate, DateTime toDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetBalanceTransaction(user, bankGl, sectionGl, accountId, accountType,
            Convert2SmallDateTime(fromDate),
            Convert2SmallDateTime(toDate));
      }

      [WebMethod]
      public SBSCore.PorscheGateway.ContigenTransactionDataSource GetContigenTransaction(string key, string bankGl, string sectionGl, string accountId, string accountType, DateTime fromDate, DateTime toDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetContigenTransaction(user, bankGl, sectionGl, accountId, accountType,
            Convert2SmallDateTime(fromDate),
            Convert2SmallDateTime(toDate));
      }

      [WebMethod]
      public DataTable GetCustomerStockEnquiry(string key, string accountId, DateTime TradingDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetCustomerStockEnquiry(accountId, user.BranchCode, Convert2SmallDateTime(TradingDate));
      }

      [WebMethod]
      public DataTable GetCustomerOrder3DayEarly(string key, string accountId, DateTime TradingDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetCustomerOrder3DayEarly(accountId, user.BranchCode, Convert2SmallDateTime(TradingDate));
      }

      [WebMethod]
      public DataTable GetCustomerOrderHistory(string key, string accountId, DateTime fromDate, DateTime toDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetCustomerOrderHistory(accountId, Convert2SmallDateTime(fromDate), Convert2SmallDateTime(toDate));
      }

      [WebMethod]
      public Decimal GetCustomerCurrentBalance(string key, string accountId, string BranchCode, DateTime TradingDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetCustomerCurrentBalance(accountId, BranchCode, Convert2SmallDateTime(TradingDate));
      }

      [WebMethod]
      public DataTable GetCustomerLostAndProfit(string key, string accountId, DateTime fromDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetCustomerLostAndProfit(accountId, Convert2SmallDateTime(fromDate));
      }


      [WebMethod]
      public DataTable GetAgencyStockOrder(string key, DateTime tradingDate, string boardType, string orderSide)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetAgencyOrderReport(user, Convert2SmallDateTime(tradingDate), boardType, orderSide, "");
      }

      [WebMethod]
      public DataTable GetAgencyOrderHistory(string key, DateTime fromDate, DateTime toDate, string boardType, string orderSide, string stockType)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetAgencyMatchedOrderReport(user, Convert2SmallDateTime(fromDate), Convert2SmallDateTime(toDate), boardType, orderSide, stockType);
      }

      [WebMethod]
      public DataTable GetMonthlyTradingResultReport(string key, DateTime fromDate, DateTime toDate, string boardType)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetMonthlyTradingResultReport(user, Convert2SmallDateTime(fromDate), Convert2SmallDateTime(toDate), boardType);
      }

      [WebMethod]
      public DataTable GetTransferFeeAgentReport(string key, DateTime fromDate, DateTime toDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetTransferFeeAgentReport(user, Convert2SmallDateTime(fromDate), Convert2SmallDateTime(toDate));
      }

      [WebMethod]
      public DataTable GetCustomerOrderReport(string key, string CustomerID, DateTime tradingDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetCustomerOrderReport(CustomerID, Convert2SmallDateTime(tradingDate));
      }

      [WebMethod]
      public DataTable GetCustomerSubTradingResult(string key, string CustomerID, DateTime tradingDate)
      {
         UserLite user = Authorize(key);
         return SBSReport.GetCustomerSubTradingResult(CustomerID, Convert2SmallDateTime(tradingDate));
      }



      #endregion
   }
}
