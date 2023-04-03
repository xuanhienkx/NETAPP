using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
//using System.Data.Linq;
using GWStock;
using Microsoft.Practices.EnterpriseLibrary.Data;
using OrderChecker;
using OrderChecker.Business;

namespace GWConnectorWS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GWConnectorWS : System.Web.Services.WebService
    {                        
        /// <summary>
        /// ----------- HOGW MARKET ----------------
        /// </summary>        
        [WebMethod]
        public string GetMarketStatusHOSE()
        {            
            return GWMarket.getMarketStatusHOSE();
        }
        [WebMethod]
        public string GetMarketStatusWithDate()
        {
            return GWMarket.getMarketStatusWithDate();
        }
        [WebMethod]
        public string GetLastTradingDaySC()
        {
            return GWMarket.getLastTradingDaySC();
        }
        [WebMethod]
        public GWTradingDay[] GetLastTradingDaysSU()
        {
            return GWMarket.getLastTradingDaysSU();
        }
        [WebMethod]
        public string GetLastTradingDaySU()
        {
            return GWMarket.getLastTradingDaySU();
        }
        [WebMethod]
        public GWStockData[] getStockCodesByType(string stockType)            
        {
            return GWStock.GWStock.getStockCodes(stockType);
        }
        [WebMethod]
        public GWStockData[] getStockCodes()
        {
            return GWStock.GWStock.getStockCodes();
        }
        [WebMethod]
        public GWStockPrice[] getStockPricesByType(string stockType)
        {
            return GWStock.GWStock.getStockPrices(stockType);
        }
        [WebMethod]
        public GWStockPrice[] getStockPrices()                    
        {
            return GWStock.GWStock.getStockPrices();
        }
        //chuyen gia tu double thanh decimal
        [WebMethod]
        public HOGWValidOutput ValidateOrder(string customerid, string stockcode, string pricetype, string marketstatus, 
            string ordertype, string orderside,int traderid, decimal price, double volume, double publishedvolume, int ptordertype, 
            string ordersession)
        {
            try
            {
                Database dbHOGW = DatabaseFactory.CreateDatabase("ConnStrHOGW");
                HOGWValidInput input = new HOGWValidInput(customerid, stockcode, pricetype, marketstatus, ordertype, orderside,
                    traderid, (decimal)price, volume, publishedvolume, ptordertype, ordersession);
                HOGWValidation valid = new HOGWValidation(dbHOGW);
                return valid.CheckOrder(input);
            }
            catch
            {
                return null;
            }
        }
    }
}
