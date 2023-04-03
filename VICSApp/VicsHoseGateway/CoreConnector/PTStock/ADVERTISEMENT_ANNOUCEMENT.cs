using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace PTStock
{
    public class ADVERTISEMENT_ANNOUCEMENT
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

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

        private System.Nullable<int> _SECURITY_NUMBER;

        public System.Nullable<int> SECURITY_NUMBER
        {
            get { return _SECURITY_NUMBER; }
            set { _SECURITY_NUMBER = value; }
        }

        private System.Nullable<double> _VOLUME;

        public System.Nullable<double> VOLUME
        {
            get { return _VOLUME; }
            set { _VOLUME = value; }
        }

        private System.Nullable<double> _PRICE;

        public System.Nullable<double> PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }

        private System.Nullable<int> _FIRM;

        public System.Nullable<int> FIRM
        {
            get { return _FIRM; }
            set { _FIRM = value; }
        }

        private System.Nullable<int> _TRADER_ID;

        public System.Nullable<int> TRADER_ID
        {
            get { return _TRADER_ID; }
            set { _TRADER_ID = value; }
        }

        private string _SIDE;

        public string SIDE
        {
            get { return _SIDE; }
            set { _SIDE = value; }
        }

        private string _BOARD;

        public string BOARD
        {
            get { return _BOARD; }
            set { _BOARD = value; }
        }

        private string _TIME;

        public string TIME
        {
            get { return _TIME; }
            set { _TIME = value; }
        }

        private string _ADD_CANCEL_FLAG;

        public string ADD_CANCEL_FLAG
        {
            get { return _ADD_CANCEL_FLAG; }
            set { _ADD_CANCEL_FLAG = value; }
        }

        private string _CONTACT;

        public string CONTACT
        {
            get { return _CONTACT; }
            set { _CONTACT = value; }
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

        private string _SECURITY_SYMBOL;

        public string SECURITY_SYMBOL
        {
            get { return _SECURITY_SYMBOL; }
            set { _SECURITY_SYMBOL = value; }
        }

        private System.DateTime _ENTRY_DATE;

        public System.DateTime ENTRY_DATE
        {
            get { return _ENTRY_DATE; }
            set { _ENTRY_DATE = value; }
        }
    }
}
