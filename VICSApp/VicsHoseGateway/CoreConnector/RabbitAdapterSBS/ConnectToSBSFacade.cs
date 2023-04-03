using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Xml;
using InterStock;

namespace HOGW_CoreConnector
{
    public enum TranState
    {
        Success = 0,
        NotEnoughMoney = 5,
        Orthers = 100
    }

    public enum TranType
    {
        BalanceInquiry = 0,
        Hold = 1,
        UnHold = 2,
        TranStatusInquiry = 3,
        ManualHold = 4,
        ManualUnhold = 5,
        BatchAccounting = 6,
        BatchAccountingStatusInquiry = 7,
        BatchUnhold = 8,
        BatchUnholdStatusInquiry = 9,
        Accounting = 10,
        BuyCashAccounting = 11,
        SellCashAccounting = 12,
        BuyFeeAccounting = 13,
        SellFeeAccounting = 14

    }

    public enum TranCode
    {
        BalanceInquiry = 1000,
        Hold = 1001,
        Unhold = 1002,
        BuyCashAccounting = 1101,
        SellCashAccounting = 1101,
        BuyFeeAccounting = 1102,
        SellFeeAccounting = 1103
    }

    public struct CreateOrderResult
    {
        public string xmlResponse;
        public string OrderTime;
        public int OrderSeq;
        public int Transtate;
        public string Message;
    }

    public struct DeleteOrderResult
    {
        public string xmlResponse;
        public int Transtate;
        public string Message;
    }

    public struct GetMoneyResult
    {
        public string xmlResponse;
        public decimal availBalance;
        public int Transtate;
        public string Message;
    }


    public struct CustomerBalanceInfoResult
    {
        public string xmlResponse;
        public string customerId;
        public decimal dayCreadit;
        public decimal dayDebit;
        public decimal dayBlock;//Tong tien phong toa noi bo trong ngay
        public decimal dayUnBlock;//Tong tien giai phong toa noi bo trong ngay
        public decimal blockBalance;//So tien dang block noi bo hien tai
        public decimal buyingBalance; //Tien mua CK bi phong toa (trong gio GD=tong hold mua CK, het gio = tien thanh toan mau CK)
        public decimal sellingBalance; // Tien cho cho thanh toan ban CK
        public decimal currLimitValue; //So tien KH dang thieu
        public decimal limitValue; //Tong han muc cap trong ngay
        public decimal balance; //So du hien tai tren TK
        public decimal availBalance; //Kha dung dat lenh
        public int Transtate;
        public string Message;
    }



    public partial class ConnectToSBSFacade
    {
        protected static ConnectToSBS gateway = new ConnectToSBS(new SBSGateway.CommonService());

        public static CreateOrderResult CreateOrder(string orderdate, string orderside,
           string ordertype, string stockcode,
           decimal ordervolume, decimal orderprice, string customerid,
           string branchcode, string tradecode,
           string receivedby, string notes, int refno)
        {
            CreateOrderResult ret = new CreateOrderResult();
            string sret = "";
            try
            {
                sret = gateway.createOrder(CommonSettings.SBSGatewayUsername, CommonSettings.SBSGatewayPassword,
                        orderdate, orderside,
                        ordertype, stockcode,
                        ordervolume, orderprice, customerid,
                        branchcode, tradecode,
                        receivedby, notes, refno.ToString(),"0");
                sret = string.Format(@"<?xml version=""1.0"" encoding=""utf-8"" ?><string xmlns=""http://tempuri.org/"">{0}</string>", sret);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sret);
                XmlNodeList list = doc.DocumentElement.ChildNodes;
                foreach (XmlNode item in list)
                {
                    switch (item.Name)
                    {
                        case "ResponseCode":
                            ret.Transtate = ConvertUtils.ToInt32(item.InnerText, -1);
                            break;
                        case "Message":
                            ret.Message = item.InnerText;
                            break;
                        case "OrderSeq":
                            ret.OrderSeq = ConvertUtils.ToInt32(item.InnerText, -1);
                            break;
                        case "OrderTime":
                            ret.OrderTime = item.InnerText;
                            break;
                        default:
                            break;
                    }
                }

                ret.xmlResponse = sret;
            }
            catch
            {
                ret.xmlResponse = "";
                ret.OrderSeq = -1;
                ret.OrderTime = "";
                ret.Transtate = -1;
                ret.Message = "Không kết nối được Webservice";
                return ret;
            }



            return ret;
        }

        public static GetMoneyResult getAvailableMoney(string customerid)
        {
            GetMoneyResult ret = new GetMoneyResult();
            string sret = "";
            try
            {
                sret = gateway.getAvailableBalance("pm", "pm", customerid);
                sret = string.Format(@"<?xml version=""1.0"" encoding=""utf-8"" ?><string xmlns=""http://tempuri.org/"">{0}</string>", sret);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sret);
                XmlNodeList list = doc.DocumentElement.ChildNodes;
                foreach (XmlNode item in list)
                {
                    switch (item.Name)
                    {
                        case "ResponseCode":
                            ret.Transtate = ConvertUtils.ToInt32(item.InnerText, -1);
                            break;
                        case "Message":
                            ret.Message = item.InnerText;
                            break;
                        case "CustomerBalance":
                            foreach (XmlNode item1 in item.ChildNodes)
                            {
                                switch (item1.Name)
                                {
                                    case "AvailBalance":
                                        ret.availBalance = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                ret.xmlResponse = sret;
            }
            catch
            {
                ret.xmlResponse = "";
                ret.availBalance = 0;
                ret.Transtate = -1;
                ret.Message = "Không kết nối được Webservice";
                return ret;
            }



            return ret;
        }

        public static string GetCurrentTranDay(string branchcode)
        {
            return gateway.getTranDate("pm", "pm", branchcode);
        }


        public static CustomerBalanceInfoResult getCustomerBalanceInfo(string customerid)
        {
            CustomerBalanceInfoResult ret = new CustomerBalanceInfoResult();
            string sret = "";
            try
            {
                sret = gateway.getCustomerBalanceInfo("pm", "pm", customerid);
                sret = string.Format(@"<?xml version=""1.0"" encoding=""utf-8"" ?><string xmlns=""http://tempuri.org/"">{0}</string>", sret);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sret);
                XmlNodeList list = doc.DocumentElement.ChildNodes;
                foreach (XmlNode item in list)
                {
                    switch (item.Name)
                    {
                        case "ResponseCode":
                            ret.Transtate = ConvertUtils.ToInt32(item.InnerText, -1);
                            break;
                        case "Message":
                            ret.Message = item.InnerText;
                            break;
                        case "CustomerBalanceInformation":
                            foreach (XmlNode item1 in item.ChildNodes)
                            {
                                switch (item1.Name)
                                {
                                    case "CustomerId":
                                        ret.customerId = item1.InnerText;
                                        break;
                                    case "DayCredit":
                                        ret.dayCreadit = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "DayDebit":
                                        ret.dayDebit = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "DayBlock":
                                        ret.dayBlock = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "DayUnBlock":
                                        ret.dayUnBlock = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "BlockBalance":
                                        ret.blockBalance = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "BuyingBalance":
                                        ret.buyingBalance = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "SellingBalance":
                                        ret.sellingBalance = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "CurentLimitValue":
                                        ret.currLimitValue = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "LimitValue":
                                        ret.limitValue = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "Balance":
                                        ret.balance = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;
                                    case "AvaiBalance":
                                        ret.availBalance = ConvertUtils.ToDecimal(item1.InnerText, 0);
                                        break;

                                    default:
                                        break;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                ret.xmlResponse = sret;
            }
            catch
            {
                ret.xmlResponse = "";
                ret.Transtate = -1;
                ret.customerId = "";
                ret.dayCreadit = 0;
                ret.dayDebit = 0;
                ret.dayBlock = 0;
                ret.dayUnBlock = 0;
                ret.blockBalance = 0;
                ret.buyingBalance = 0;
                ret.sellingBalance = 0;
                ret.currLimitValue = 0;
                ret.limitValue = 0;
                ret.balance = 0;
                ret.availBalance = 0;

                ret.Message = "Không kết nối được Webservice";
                return ret;
            }



            return ret;
        }


        public static DeleteOrderResult deleteOrder(string orderdate, string orderseq)
        {
            DeleteOrderResult ret = new DeleteOrderResult();
            string sret = "";
            try
            {
                sret = gateway.deleteOrder("pm", "pm", orderdate, orderseq);
                sret = string.Format(@"<?xml version=""1.0"" encoding=""utf-8"" ?><string xmlns=""http://tempuri.org/"">{0}</string>", sret);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sret);
                XmlNodeList list = doc.DocumentElement.ChildNodes;
                foreach (XmlNode item in list)
                {
                    switch (item.Name)
                    {
                        case "ResponseCode":
                            ret.Transtate = ConvertUtils.ToInt32(item.InnerText, -1);
                            break;
                        case "Message":
                            ret.Message = item.InnerText;
                            break;
                        default:
                            break;
                    }
                }

                ret.xmlResponse = sret;
            }
            catch
            {
                ret.xmlResponse = "";
                ret.Transtate = -1;
                ret.Message = "Không kết nối được Webservice";
                return ret;
            }



            return ret;
        }

    }
}
