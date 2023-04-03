using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vrm
{
    class StockMargin
    {
        private string stockcode;
        private int valuerate;
        private string branchcode;
        private string cellingfixprice;
        private string createdbyusername;
        private string modifiedbyusername;
        private DateTime createddate;
        private DateTime modifieddate;


        public StockMargin(String stocode, int valrate, String bracode, String celfixprice, String crebyusername, String modbyusername, DateTime credate, DateTime moddate)
        {
            stockcode = stocode;
            valuerate = valrate;
            branchcode = bracode;
            cellingfixprice = celfixprice;
            createdbyusername = crebyusername;
            modifiedbyusername = modbyusername;
            createddate = credate;
            modifieddate = moddate;
        }
        public String StockCode
        {
            get { return stockcode; }
            set { this.stockcode = value; }
        }
        public int ValueRate
        {
            get { return valuerate; }
            set { this.valuerate = value; }
        }
        public String BranchCode
        {
            get { return branchcode; }
            set { this.branchcode = value; }
        }
        public String CellingFixPrice
        {
            get { return cellingfixprice; }
            set { this.cellingfixprice = value; }
        }
        public String CreateByUserName
        {
            get { return createdbyusername; }
            set { this.createdbyusername = value; }
        }
        public String ModifiedByUserName
        {
            get { return modifiedbyusername; }
            set { this.modifiedbyusername = value; }
        }
        public DateTime CreatedDate
        {
            get { return createddate; }
            set { this.createddate = value; }
        }
        public DateTime ModifiedDate
        {
            get { return modifieddate; }
            set { this.modifieddate = value; }
        }
        

    }
}
