using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.UI.MobileControls;
using HoseWebService.Domain;
using System.Collections.Generic;
using HoseWebService.Common;

namespace HoseWebService
{
   /// <summary>
   /// Summary description for Service1
   /// </summary>
   [WebService(Namespace = "http://vics.com.vn/")]
   [ToolboxItem(false)]
   public class Gateway : System.Web.Services.WebService
   {

      [WebMethod]
      public List<HoseMsgOrder> GetListForCancel(string customerid, string stockcode, string orderside)
      {
         return HoseMsgOrder.GetListForCancel(customerid, stockcode, orderside);
      }

      [WebMethod]
      public void CancelOrder(string orderNumber, string canceledBy)
      {
         HoseDal.CancelOrder(orderNumber, canceledBy);
      }

      [WebMethod]
      public List<HoseMsgOrder> GetDayCancelList()
      {
         return HoseMsgOrder.GetDayCancelList();
      }

      [WebMethod]
      public string GetCurrentSession()
      {
          return HoseDal.GetCurrentSession();
      }


      [WebMethod]
      public string CheckStockHalt(string stockCode)
      {
          return HoseDal.getStockHalted(stockCode);
      }

   }
}
