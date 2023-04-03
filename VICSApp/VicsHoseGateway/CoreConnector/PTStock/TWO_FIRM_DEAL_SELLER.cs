using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace PTStock
{
    public class TWO_FIRM_DEAL_SELLER
    {
        private string _MESSAGE_STATUS;

        public string MESSAGE_STATUS
        {
            get { return _MESSAGE_STATUS; }
            set { _MESSAGE_STATUS = value; }
        }

        private string _MESSAGE_TYPE;

        public string MESSAGE_TYPE
        {
            get { return _MESSAGE_TYPE; }
            set { _MESSAGE_TYPE = value; }
        }

        private System.Nullable<int> _SELLER_FIRM;

        public System.Nullable<int> SELLER_FIRM
        {
            get { return _SELLER_FIRM; }
            set { _SELLER_FIRM = value; }
        }

        private System.Nullable<int> _SELLER_TRADER_ID;

        public System.Nullable<int> SELLER_TRADER_ID
        {
            get { return _SELLER_TRADER_ID; }
            set { _SELLER_TRADER_ID = value; }
        }

        private string _SELLER_CLIENT_ID;

        public string SELLER_CLIENT_ID
        {
            get { return _SELLER_CLIENT_ID; }
            set { _SELLER_CLIENT_ID = value; }
        }

        private System.Nullable<int> _BUYER_FIRM;

        public System.Nullable<int> BUYER_FIRM
        {
            get { return _BUYER_FIRM; }
            set { _BUYER_FIRM = value; }
        }

        private System.Nullable<int> _BUYER_TRADER_ID;

        public System.Nullable<int> BUYER_TRADER_ID
        {
            get { return _BUYER_TRADER_ID; }
            set { _BUYER_TRADER_ID = value; }
        }

        private string _SECURITY_SYMBOL;

        public string SECURITY_SYMBOL
        {
            get { return _SECURITY_SYMBOL; }
            set { _SECURITY_SYMBOL = value; }
        }

        private System.Nullable<double> _PRICE;

        public System.Nullable<double> PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }

        private string _BOARD;

        public string BOARD
        {
            get { return _BOARD; }
            set { _BOARD = value; }
        }

        private int _DEAL_ID;

        public int DEAL_ID
        {
            get { return _DEAL_ID; }
            set { _DEAL_ID = value; }
        }

        private System.Nullable<double> _BROKER_PORTFOLIO_VOLUME;

        public System.Nullable<double> BROKER_PORTFOLIO_VOLUME
        {
            get { return _BROKER_PORTFOLIO_VOLUME; }
            set { _BROKER_PORTFOLIO_VOLUME = value; }
        }

        private System.Nullable<double> _BROKER_CLIENT_VOLUME;

        public System.Nullable<double> BROKER_CLIENT_VOLUME
        {
            get { return _BROKER_CLIENT_VOLUME; }
            set { _BROKER_CLIENT_VOLUME = value; }
        }

        private System.Nullable<double> _BROKER_MUTUAL_FUND_VOLUME;

        public System.Nullable<double> BROKER_MUTUAL_FUND_VOLUME
        {
            get { return _BROKER_MUTUAL_FUND_VOLUME; }
            set { _BROKER_MUTUAL_FUND_VOLUME = value; }
        }

        private System.Nullable<double> _BROKER_FOREIGN_VOLUME;

        public System.Nullable<double> BROKER_FOREIGN_VOLUME
        {
            get { return _BROKER_FOREIGN_VOLUME; }
            set { _BROKER_FOREIGN_VOLUME = value; }
        }

        private string _RECEIVED_BY;

        public string RECEIVED_BY
        {
            get { return _RECEIVED_BY; }
            set { _RECEIVED_BY = value; }
        }

        private string _APPROVED_BY;

        public string APPROVED_BY
        {
            get { return _APPROVED_BY; }
            set { _APPROVED_BY = value; }
        }

        private System.Nullable<int> _CONFIRM_NUMBER;

        public System.Nullable<int> CONFIRM_NUMBER
        {
            get { return _CONFIRM_NUMBER; }
            set { _CONFIRM_NUMBER = value; }
        }

        private string _SIDE;

        public string SIDE
        {
            get { return _SIDE; }
            set { _SIDE = value; }
        }

        private System.DateTime _ENTRY_DATE;

        public System.DateTime ENTRY_DATE
        {
            get { return _ENTRY_DATE; }
            set { _ENTRY_DATE = value; }
        }
    }
}
