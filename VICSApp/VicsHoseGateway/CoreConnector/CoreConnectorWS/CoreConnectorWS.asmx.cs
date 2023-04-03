using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using CoreStock;

namespace CoreConnectorWS
{
   /// <summary>
   /// Summary description for Service1
   /// </summary>
   [WebService(Namespace = "http://tempuri.org/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [ToolboxItem(false)]
   // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   // [System.Web.Script.Services.ScriptService]
   public class CoreConnectorWS : System.Web.Services.WebService
   {
      [WebMethod]
      public int GetNextOrderSeq()
      {
         return CoreUtil.linqGetNextOrderSeq();
      }
      [WebMethod]
      public StockOrder[] GetStockOrders(string status)
      {
         //return CoreUtil.linqGetStockOrders(status);
         return CoreUtil.getStockOrdersArray(status);
      }
      [WebMethod]
      public StockOrder[] GetStockOrdersBySeq(int lastSeq, string status)
      {
         return CoreUtil.linqGetStockOrders(lastSeq, status);
      }
      [WebMethod]
      public CoreStockOrderCancel[] GetStockOrdersForCancel()
      {
         return CoreUtil.getStockOrdersForCancelArray();
      }
      [WebMethod]
      public CoreStockOrderChange[] GetStockOrdersToChange()
      {
         return CoreUtil.getStockOrdersForChangeArray();
      }
      [WebMethod]
      public Branch[] GetBranches()
      {
         return CoreUtil.linqGetBranches();
      }
      //----------- UPDATE STOCK_ORDER ----------------
      [WebMethod]
      public int UpdateOrderStatusBySeq(int orderSeq, string newStatus, string notes)
      {
         //return CoreUtil.linqUpdateOrderStatusBySeq(orderSeq, newStatus);
         if (string.IsNullOrEmpty(notes))
            return CoreUtil.updateOrderStatusBySeq(orderSeq, newStatus, null);
         else
            return CoreUtil.updateOrderStatusBySeq(orderSeq, newStatus, notes);
      }
      [WebMethod]
      public int UpdateChangeOrderStatusBySeq(int orderSeq, string newStatus)
      {
         //return CoreUtil.linqUpdateOrderStatusBySeq(orderSeq, newStatus);
         return CoreUtil.updateChangeOrderStatusBySeq(orderSeq, newStatus);
      }
      [WebMethod]
      public int UpdateCancelOrderStatusBySeq(int orderSeq, string newStatus)
      {
         //return CoreUtil.linqUpdateOrderStatusBySeq(orderSeq, newStatus);
         return CoreUtil.updateCancelOrderStatusBySeq(orderSeq, newStatus);
      }
      [WebMethod]
      public int UpdateOrderStatusByOrderNo(string orderNo, string newStatus)
      {
         //return CoreUtil.linqUpdateOrderStatusByOrderNo(orderNo, newStatus);
         return CoreUtil.updateOrderStatusByOrderNo(orderNo, newStatus);
      }
      [WebMethod]
      public int UpdateOrderStatus(string OrderDate, int OrderSeq, string newStatus)
      {
         //return CoreUtil.linqUpdateOrderStatus(OrderDate, OrderSeq, newStatus);
         return CoreUtil.updateOrderStatus(OrderDate, OrderSeq, newStatus);
      }
      [WebMethod]
      public int UpdateOrderNotes(int OrderSeq, string Notes)
      {
         //return CoreUtil.linqUpdateOrderStatus(OrderDate, OrderSeq, newStatus);
         return CoreUtil.updateOrderNotes(OrderSeq, Notes);
      }
      //---------- customers ----------
      [WebMethod]
      public CustomerCompact[] GetAllCustomersCompact()
      {
         return CustomerCompact.getAllCustomersCompact();
      }
      [WebMethod]
      public Customer[] GetAllCustomers()
      {
         return Customer.getAllCustomers();
      }
      [WebMethod]
      public CustomerBalance[] GetAllCustomersBalance()
      {
         return CustomerBalance.getAllCustomerBalances();
      }
      [WebMethod]
      public Securities[] GetSecurities(string CustomerID)
      {
         return CustomerSecurities.getSecurities(CustomerID);
      }
      [WebMethod]
      public Securities GetSecurity(string CustomerID, string StockCode)
      {
         return CustomerSecurities.getSecurity(CustomerID, StockCode);
      }
   }
}
