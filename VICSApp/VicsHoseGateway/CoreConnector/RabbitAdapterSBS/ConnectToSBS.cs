using System;
using System.Collections.Generic;
using System.Text;

namespace HOGW_CoreConnector
{
    public partial class ConnectToSBS
    {
        //private static readonly BIDVAccessPoint.AccountWebserviceService ws = new BSC.TradeAgent.Engine.BIDVAccessPoint.AccountWebserviceService();

        protected SBSGateway.CommonService ws;

        public ConnectToSBS(SBSGateway.CommonService ws)
        {
            this.ws = ws;
        }

        private ConnectToSBS()
        {
            // hide this constructor
        }



        public string createOrder(string gwUser, string gwPass, string orderdate, string orderside,
          string ordertype, string stockcode,
          decimal ordervolume, decimal orderprice, string customerid,
          string branchcode, string tradecode,
          string receivedby, string notes, string refno, string isApproved)
        {
            return ws.CreateStockOrder(gwUser, gwPass, orderdate, orderside,
           ordertype, stockcode,
           ordervolume.ToString(), orderprice.ToString(), customerid,
           branchcode, tradecode,
           receivedby, "", notes, refno, isApproved);
        }

        public string deleteOrder(string gwUser, string gwPass, string orderdate, string orderseq)
        {
            return ws.OrderAgentDelete(gwUser, gwPass, orderdate, orderseq);
        }

        public string getTranDate(string gwUser, string gwPass, string branchcode)
        {
            try
            {
                return ws.GetCurrentTransactionDate(gwUser, gwPass, branchcode);
            }
            catch
            {
                return System.DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        public string getAvailableBalance(string gwUser, string gwPass, string customerid)
        {
            return ws.GetMoneyAmount(gwUser, gwPass, customerid);
        }

        public string getCustomerBalanceInfo(string gwUser, string gwPass, string customerid)
        {
            return ws.GetCustomerBalanceInformation(gwUser, gwPass, customerid);
        }
    }
}
