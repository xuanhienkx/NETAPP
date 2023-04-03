using System;
using System.ComponentModel;
using System.EnterpriseServices;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Data;
using CommonDomain;
using SBSCore.Security;
using SBSCore.Common;
using SBSCore.DomainHelper;
using SBSCore;
using System.Xml;
using SBSCore.Report;

namespace CoreWebService
{
    /// <summary>
    /// Summary description for GateWay
    /// </summary>
    [WebService(Namespace = "http://www.vics.com.vn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Brokery : WebService
    {
        #region Private

        private const string MESSAGE = @"Thông tin đăng nhập bị sai hoặc đã hết phiên làm việc. Yêu cầu đăng nhập lại";

        private UserLite Authorize(string key)
        {
            var uInfo = Session[CryptoEngine.Decrypt(key)] as UserLite;
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

        [WebMethod(EnableSession = true)]
        public string GetAuthorize(string username, string password)
        {
           Session.RemoveAll();
            UserLite u = UserLite.GetUser(CryptoEngine.Decrypt(username), Context.Request.UserHostAddress);
            if (u == null || LiteralUtil.Encrypt(CryptoEngine.Decrypt(password)) != u.Password)
                return string.Empty;

            string key = Guid.NewGuid().ToString();
            Session[key] = u;
            return key;
        }

        [WebMethod(EnableSession = true)]
        public void ClearTokenKey(string key)
        {
           Session.Remove(CryptoEngine.Decrypt(key));
        }

        [WebMethod(EnableSession = true)]
        public UserLite GetUser(string key, string username)
        {
            UserLite uInfo = Authorize(key);
            if (uInfo != null)
                return uInfo;
            return UserLite.GetUser(username, string.Empty);
        }

        [WebMethod(EnableSession = true)]
        public List<UserLite> FindUsers(string key, string username)
        {
            UserLite uInfo = Authorize(key);
            return UserLite.Find(username, uInfo);
        }

        [WebMethod(EnableSession = true)]
        public List<UserLite> GetUserList(string key, int groupId)
        {
            UserLite uInfo = Authorize(key);
            return UserLite.GetList(groupId, uInfo);
        }

        [WebMethod(EnableSession = true)]
        public UserLite InsertOrUpdateUser(string key, UserLite user)
        {
            UserLite uInfo = Authorize(key);
            return UserLite.InsertOrUpdate(uInfo, user);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteUser(string key, int userId)
        {
            UserLite uInfo = Authorize(key);
            UserLite.Delete(userId);
        }

        [WebMethod(EnableSession = true)]
        public void ChangeUserPassword(string key, int userId, string newPassword)
        {
            Authorize(key);
            UserLite.ChangePassword(userId, newPassword);
        }

        [WebMethod(EnableSession = true)]
        public List<UserGroup> GetGroups(string key)
        {
            UserLite user = Authorize(key);
            return UserGroup.GetList(user.BranchCode, user.TradeCode);
        }

        [WebMethod(EnableSession = true)]
        public DateTime GetCurrentTransactionDate(string key)
        {
            UserLite uInfo = Authorize(key);
            return SBSDal.GetCurrentTransaction(uInfo.BranchCode);
        }

        [WebMethod(EnableSession = true)]
        public DateTime GetTDate(string key, DateTime tradingDate, int numberOfDay, bool isNextDay)
        {
            UserLite uInfo = Authorize(key);
            return SBSDal.GetT3Date(uInfo.BranchCode, Convert2SmallDateTime(tradingDate), numberOfDay, isNextDay);
        }

        [WebMethod(EnableSession = true)]
        public List<GLStockCode> GetStockList(string key, string board)
        {
            UserLite uInfo = Authorize(key);
            return GLStockCodeHelper.GetStockList(board);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetGroupPermission(string key, int groupId)
        {
            UserLite uInfo = Authorize(key);
            if (groupId > 0)
                return UserGroup.GetGroupPermission(groupId);
            return UserGroup.GetGroupPermission(uInfo.GroupId);
        }

        [WebMethod(EnableSession = true)]
        public void SetGroupPermission(string key, int groupId, List<string> rights)
        {
            UserLite uInfo = Authorize(key);
            UserGroup.SetGroupPermission(groupId, rights);
        }

        [WebMethod(EnableSession = true)]
        public UserGroup InsertOrUpdateUserGroup(string key, UserGroup group)
        {
            UserLite uInfo = Authorize(key);
            return UserGroup.InsertOrUpdate(uInfo, group);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteUserGroup(string key, int groupId)
        {
            UserLite uInfo = Authorize(key);
            UserGroup.Delete(groupId);
        }

        [WebMethod(EnableSession = true)]
        public List<Department> GetDepartmentList(string key)
        {
            UserLite uInfo = Authorize(key);
            return DepartmentHelper.GetList(uInfo.BranchCode);
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

        [WebMethod(EnableSession = true)]
        public InquiryData GetInquiryData(string key, InquiryData order, DateTime tradingDate)
        {
            try
            {
                UserLite uInfo = Authorize(key);
                return InquiryDataHelper.GetData(order, Convert2SmallDateTime(tradingDate), uInfo);
            }
            catch (Exception ex)
            {
                throw new SoapException(ex.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, this.GenXMLError(1, ex.Message));
            }
        }

        [WebMethod(EnableSession = true)]
        public List<Order> SubmitOrderInfo(string key, InquiryData orderInfo, DateTime tradingDate)
        {
            try
            {
                UserLite uInfo = Authorize(key);
                List<Order> result = new List<Order>();
                if (orderInfo.TradingStock.BoardType == Util.HOSEBoard && orderInfo.TradingStockVolume >= Util.HOSE_MAX_VOLUME)
                {
                    result.AddRange(OrderHelper.SubmitOrderInfoForMany(orderInfo, Convert2SmallDateTime(tradingDate), uInfo));
                }
                else
                {
                    result.Add(OrderHelper.SubmitInfo(orderInfo, Convert2SmallDateTime(tradingDate), uInfo));
                }
                return result;
            }
            catch (Exception e)
            {
                throw new SoapException(e.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, e);
            }
        }

        [WebMethod(EnableSession = true)]
        public List<Order> GetOrderList(string key, DateTime orderDate, string customerId, string stockCode, string orderStatus, string receivedBy, string orderSide, int session, string boardType)
        {
            UserLite uInfo = Authorize(key);
            return OrderHelper.GetList(Convert2SmallDateTime(orderDate),
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

        [WebMethod(EnableSession = true)]
        public List<Order> GetMatchedOrderList(string key, DateTime orderDate, string customerId, string stockCode, string orderSide, string boardType)
        {
            UserLite uInfo = Authorize(key);
            return OrderHelper.GetMatchedOrderList(Convert2SmallDateTime(orderDate),
               uInfo.BranchCode,
               uInfo.TradeCode,
               stockCode,
               customerId,
               orderSide,
               boardType);
        }

        [WebMethod(EnableSession = true)]
        public List<Order> GetListForCancel(string key, string boardType, string customerId, string stockCode, string orderSide, DateTime transDate)
        {
            try
            {
                UserLite user = Authorize(key);
                return OrderHelper.GetListForCancel(boardType, customerId, stockCode, orderSide, Convert2SmallDateTime(transDate), user);
            }
            catch (Exception ex)
            {
                throw new SoapException(ex.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, this.GenXMLError(1, ex.Message));
            }

        }

        [WebMethod(EnableSession = true)]
        public void CancelOrder(string key, string boardType, string orderNumber)
        {
            UserLite user = Authorize(key);
            OrderHelper.Cancel(boardType, orderNumber, user.UserName);
        }

        [WebMethod(EnableSession = true)]
        public void ApproveOrder(string key, DateTime tradingDate, string boardType, int orderSeq)
        {
            UserLite user = Authorize(key);
            OrderHelper.approveOrder(Convert2SmallDateTime(tradingDate), orderSeq, user.UserName, user.BranchCode);
        }

        [WebMethod(EnableSession = true)]
        public void DeleteOrder(string key, DateTime tradingDate, int orderSeq)
        {
            UserLite user = Authorize(key);
            OrderHelper.deleteOrder(Convert2SmallDateTime(tradingDate), orderSeq, user.UserName);
        }

        [WebMethod(EnableSession = true)]
        public List<Order> GetDayCanceledOrModifiedList(string key, string boardType, bool forCancel, DateTime transDate)
        {
            UserLite user = Authorize(key);
            return OrderHelper.GetDayCanceledOrModifiedList(boardType, Convert2SmallDateTime(transDate), forCancel, user);
        }

        [WebMethod(EnableSession = true)]
        public void ModifyHnxAndUpcomOrder(string key, string boardType, int orderSeq, string orderNumber, InquiryData orderInfo, InquiryData modifiedOrderInfo, DateTime transDate, decimal newHoldValue)
        {
            UserLite uInfo = Authorize(key);
            OrderHelper.ModifyHnxAndUpcomOrder(boardType, orderSeq, orderNumber, orderInfo, modifiedOrderInfo, transDate, uInfo, newHoldValue);
        }

        [WebMethod(EnableSession = true)]
        public string GetCurrentTradingSession(string key, string stockCode, string boardType)
        {
            UserLite user = Authorize(key);
            return Util.CommonService.GetCurrentTradingSession(Util.CoreGatewayUserName, Util.CoreGatewayPassword, stockCode,
                                                        boardType);
        }

        #endregion

        #region Customer

        [WebMethod(EnableSession = true)]
        public Customer GetCustomerForRegister(string key, string customerId)
        {
            UserLite uInfor = Authorize(key);
            // lam the nay de lay het tat ca cac user
            var branchCode = uInfor.TradeCode == "VICSHCM" ? string.Empty : uInfor.BranchCode;
            return CustomerHelper.GetCustomer(customerId, branchCode, uInfor); // tradecode = empty to get all the customerid belongs to branch
        }

        [WebMethod(EnableSession = true)]
        public List<Customer> FindCustomers(string key, string customerId, string customserName, string cardID, string branchCode, string unitTradeCode)
        {
            UserLite uInfor = Authorize(key);
            var clonedUser = uInfor.Clone();
            if (!string.IsNullOrEmpty(branchCode) && !string.IsNullOrEmpty(unitTradeCode))
            {
                clonedUser.BranchCode = branchCode;
                clonedUser.TradeCode = unitTradeCode;
            }
            return CustomerHelper.Find(customerId, customserName, cardID, clonedUser.BranchCode, clonedUser);
        }

        [WebMethod(EnableSession = true)]
        public List<Customer> GetCustomersTakeCared(string key)
        {
            UserLite uInfor = Authorize(key);
            return CustomerHelper.FindByTakeCared(uInfor.BranchCode, uInfor);
        }

        [WebMethod(EnableSession = true)]
        public List<InquiryStock> GetCustomerStocks(string key, string customerId, DateTime tradingDate)
        {
            UserLite uInfor = Authorize(key);
            return InquiryStockHelper.GetStock(customerId, uInfor.BranchCode, Convert2SmallDateTime(tradingDate));
        }

        [WebMethod(EnableSession = true)]
        public List<CustomerService> GetCustomerServices(string key, string customerId)
        {
            UserLite uInfor = Authorize(key);
            return CustomerServiceHelper.CustomerServiceGetList(customerId);
        }

        [WebMethod(EnableSession = true)]
        public List<OnlineBank> GetOnlineBank(string key)
        {
            UserLite uInfor = Authorize(key);
            return OnlineBankHelper.GetList(uInfor.BranchCode);
        }

        [WebMethod(EnableSession = true)]
        public void RegisterCustomer(string key, string customerId, string customerTradeCode, string agencyTradeCode)
        {
            UserLite uInfo = Authorize(key);
            CustomerHelper.Register(customerId, customerTradeCode, agencyTradeCode, uInfo);
        }

        [WebMethod(EnableSession = true)]
        public void UnRegisterCustomer(string key, string customerId)
        {
            UserLite uInfo = Authorize(key);
            if (uInfo != null)
                CustomerHelper.UnRegister(customerId);
        }
        [WebMethod(EnableSession = true)]
        public int CheckRegisterCustomer(string key, string customerId, string tradeCode)
        {
            int returntype = 0;
            UserLite uInfo = Authorize(key);
            if (uInfo != null)
                returntype = CustomerHelper.CheckRegister(customerId, tradeCode);
            return returntype;
        }

        [WebMethod(EnableSession = true)]
        public CustomerProxy GetCustomerProxy(string key, string customerId)
        {
            UserLite uInfor = Authorize(key);
            return CustomerProxyHelper.GetCustomerProxy(customerId);
        }

        [WebMethod(EnableSession = true)]
        public CustomerDetail GetCustomerDetail(string key, string customerId)
        {
            UserLite uInfor = Authorize(key);
            return CustomerDetailHelepr.GetCustomerDetail(customerId);
        }


        #endregion

        #region Agency

        [WebMethod(EnableSession = true)]
        public AgencyFee GetAgencyFee(string key, int Id)
        {
            UserLite uInfor = Authorize(key);
            return AgencyFeeHelper.GetAgencyFee(Id);
        }

        [WebMethod(EnableSession = true)]
        public List<AgencyFee> GetAgencyFeeByTradeCode(string key)
        {
            UserLite uInfor = Authorize(key);
            return AgencyFeeHelper.GetAgencyFeeByTradeCode(uInfor.TradeCode);
        }

        [WebMethod(EnableSession = true)]
        public void NewAgencyFee(string key, int valueFrom, int toValue, decimal fee, string note)
        {
            UserLite uInfor = Authorize(key);
            AgencyFeeHelper.NewAgencyFee(uInfor.TradeCode, valueFrom, toValue, fee, note);
        }

        [WebMethod(EnableSession = true)]
        public void EditAgencyFee(string key, int ID, int valueFrom, int toValue, decimal fee, string note)
        {
            UserLite uInfor = Authorize(key);
            AgencyFeeHelper.EditAgencyFee(uInfor.TradeCode, ID, valueFrom, toValue, fee, note);
        }


        [WebMethod(EnableSession = true)]
        public void DeleteAgencyFee(string key, int Id)
        {
            UserLite uInfor = Authorize(key);
            AgencyFeeHelper.DeleteAgencyFee(Id);
        }

        [WebMethod(EnableSession = true)]
        public List<UnitTrade> GetUnitTradeCodes(string key)
        {
            var user = Authorize(key);
            return AgencyHelper.GetUnitTradeCode(user);
        }

        #endregion

        #region Report

        [WebMethod(EnableSession = true)]
        public SBSCore.PorscheGateway.BalanceTransactionDataSource GetBalanceTransaction(string key, string bankGl, string sectionGl, string accountId, string accountType, DateTime fromDate, DateTime toDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetBalanceTransaction(user, bankGl, sectionGl, accountId, accountType,
               Convert2SmallDateTime(fromDate),
               Convert2SmallDateTime(toDate));
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetAccountNameBalanceTransaction(string key, string accountId)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetAccountName(accountId, user.BranchCode);
        }

        [WebMethod(EnableSession = true)]
        public SBSCore.PorscheGateway.ContigenTransactionDataSource GetContigenTransaction(string key, string bankGl, string sectionGl, string accountId, string accountType, DateTime fromDate, DateTime toDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetContigenTransaction(user, bankGl, sectionGl, accountId, accountType,
               Convert2SmallDateTime(fromDate),
               Convert2SmallDateTime(toDate));
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetCustomerStockEnquiry(string key, string accountId, DateTime TradingDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetCustomerStockEnquiry(accountId, user.BranchCode, Convert2SmallDateTime(TradingDate));
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetCustomerOrder3DayEarly(string key, string accountId, DateTime TradingDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetCustomerOrder3DayEarly(accountId, user.BranchCode, Convert2SmallDateTime(TradingDate));
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetCustomerOrderHistory(string key, string accountId, DateTime fromDate, DateTime toDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetCustomerOrderHistory(accountId, Convert2SmallDateTime(fromDate), Convert2SmallDateTime(toDate));
        }

        [WebMethod(EnableSession = true)]
        public Decimal GetCustomerCurrentBalance(string key, string accountId, string BranchCode, DateTime TradingDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetCustomerCurrentBalance(accountId, BranchCode, Convert2SmallDateTime(TradingDate));
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetCustomerLostAndProfit(string key, string accountId, DateTime fromDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetCustomerLostAndProfit(accountId, Convert2SmallDateTime(fromDate));
        }


        [WebMethod(EnableSession = true)]
        public DataTable GetAgencyStockOrder(string key, DateTime tradingDate, string boardType, string orderSide)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetAgencyOrderReport(user, Convert2SmallDateTime(tradingDate), boardType, orderSide, "");
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetAgencyOrderHistory(string key, DateTime fromDate, DateTime toDate, string boardType, string orderSide, string stockType)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetAgencyMatchedOrderReport(user, Convert2SmallDateTime(fromDate), Convert2SmallDateTime(toDate), boardType, orderSide, stockType);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetMonthlyTradingResultReport(string key, DateTime fromDate, DateTime toDate, string boardType)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetMonthlyTradingResultReport(user, Convert2SmallDateTime(fromDate), Convert2SmallDateTime(toDate), boardType);
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetTransferFeeAgentReport(string key, DateTime fromDate, DateTime toDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetTransferFeeAgentReport(user, Convert2SmallDateTime(fromDate), Convert2SmallDateTime(toDate));
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetCustomerOrderReport(string key, string CustomerID, DateTime tradingDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetCustomerOrderReport(CustomerID, Convert2SmallDateTime(tradingDate));
        }

        [WebMethod(EnableSession = true)]
        public DataTable GetCustomerSubTradingResult(string key, string CustomerID, DateTime tradingDate)
        {
            UserLite user = Authorize(key);
            return SBSReport.GetCustomerSubTradingResult(CustomerID, Convert2SmallDateTime(tradingDate));
        }



        #endregion

        #region DebitLimit

        [WebMethod(EnableSession = true)]
        public List<CustomerDebitLimit> GetCustomerDebitLimit(string key, string customerId, DateTime tradingDate)
        {
            UserLite uInfor = Authorize(key);
            return CustomerDebitLimitHelper.CustomerDebitLimitGet(customerId, tradingDate, uInfor);
        }

        [WebMethod(EnableSession = true)]
        public List<CustomerDebitTransaction> GetCustomerDebitTransactions(string key, string customerid)
        {
            var user = Authorize(key);
            return CustomerDebitTransactionHelper.Get(customerid, user);
        }
        [WebMethod(EnableSession = true)]
        public void CreateCustomerDebitLimit(string key, CustomerDebitLimit debitLimit, DateTime transDate)
        {
            try
            {
                UserLite uInfor = Authorize(key);
                CustomerDebitLimitHelper.CustomerDebitLimitInsert(debitLimit, transDate, uInfor);
            }
            catch (Exception ex)
            {
                throw new SoapException(ex.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, this.GenXMLError(1, ex.Message));
            }
        }

        [WebMethod(EnableSession = true)]
        public List<CustomerDebitLimitLog> GetCustomerDebitLimitLog(string key, string customerId, DateTime fromDate, DateTime toDate)
        {
            UserLite uInfor = Authorize(key);
            return CustomerDebitLimitHelper.CustomerDebitLimitGetHistoryLog(customerId, fromDate, toDate, uInfor);
        }

        [WebMethod(EnableSession = true)]
        public void CreateUnitDebitLimit(string key, string branchCode, string tradeCode, decimal debitLimit, DateTime tradingDate)
        {
            var user = Authorize(key);
            CustomerDebitLimitHelper.SetGroupDebitLimit(branchCode, tradeCode, debitLimit, tradingDate, user);
        }

        [WebMethod(EnableSession = true)]
        public List<GroupDebitLimit> GetUnitDebitLimits(string key, DateTime tradingDate)
        {
            var user = Authorize(key);
            return CustomerDebitLimitHelper.GetGroupDebitLimits(tradingDate, user);
        }

        [WebMethod(EnableSession = true)]
        public List<CustomerDebitTransaction> GetCustomerDebitFindCustomerDebitLimitTransactions(string key, string customerid)
        {
            var user = Authorize(key);
            return CustomerDebitTransactionHelper.Get(customerid, user);
        }

        [WebMethod(EnableSession = true)]
        public CustomerDebitLimit FindCustomerDebitLimit(string key, string customerid, DateTime tradingDate)
        {
            var user = Authorize(key);
            return CustomerDebitLimitHelper.FindCustomerDebitLimit(customerid, tradingDate, user);
        }

        #endregion
    }
}
