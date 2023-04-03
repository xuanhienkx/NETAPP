using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using HnxWebService.Domain;

namespace HnxWebService
{
   /// <summary>
   /// Summary description for Gateway
   /// </summary>
   [WebService(Namespace = "http://www.vics.com.vn")]
   [ToolboxItem(false)]
   public class Gateway : System.Web.Services.WebService
   {
      [WebMethod]
      public HnxTradingSession GetTradingSession(string boardCodeList)
      {
         return HNXDal.GetTradingSession(boardCodeList);
      }

      [WebMethod]
      public List<HnxMsgOrder> GetListForCancel(string customerId, string stockCode, string orderside)
      {
         return HnxMsgOrder.GetListForCancel(customerId, stockCode, orderside);
      }

      [WebMethod]
      public void CancelOrder(string orderNumber, string canceledBy)
      {
         HNXDal.CancelOrder(orderNumber);
      }

      [WebMethod]
      public List<HnxMsgOrder> GetDayCanceledList()
      {
         return HnxMsgOrder.GetDayCanceledList();
      }

      [WebMethod]
      public List<HnxMsgOrder> GetDayModifiedList()
      {
         return HnxMsgOrder.GetDayModifiedList();
      }

      [WebMethod]
      public void ModifyOrder(string orderNumber, decimal oldVolume, decimal newPrice, decimal? newVolume, decimal? newStopPrice, decimal? newIcebergVolume)
      {
         HNXDal.ModifyOrder(orderNumber, oldVolume, newPrice, newVolume, newStopPrice, newIcebergVolume);
      }
   }
}
