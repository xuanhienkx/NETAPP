using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vrm
{
    class CustomerMargin
    {
        private int customerid;
        private int marginrate;
        private string createdusername;
        private DateTime modifieddate;
        private string modifiedbyusername;

        public CustomerMargin(int cusid, int marrate, String creusername, DateTime moddate, String modusername)
        {
            this.customerid = cusid;
            this.marginrate = marrate;
            this.createdusername = creusername;
            this.modifieddate = moddate;
            this.modifiedbyusername = modusername;
        }
        public int CustomerId
        {
            get { return customerid; }
            set { this.customerid = value; }
        }
        public int MarginRate
        {
            get { return marginrate; }
            set { this.marginrate = value; }
        }
        public String CreatedUserName
        {
            get { return createdusername; }
            set { this.createdusername = value; }
        }
        public DateTime ModifiedDate
        {
            get { return modifieddate; }
            set { this.modifieddate = value; }
        }
        public String ModifiedByUserName
        {
            get { return modifiedbyusername; }
            set { this.modifiedbyusername = value; }
        }
    }
}

