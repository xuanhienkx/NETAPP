using System;

namespace OrderChecker.Business
{
    public class MarketInfo
    {
        private DateTime lastModified;
        private string systemControlCode;
        private string timeStamp;

        public DateTime LastModified
        {
            get
            {
                return this.lastModified;
            }
            set
            {
                this.lastModified = value;
            }
        }

        public string SystemControlCode
        {
            get
            {
                return this.systemControlCode;
            }
            set
            {
                this.systemControlCode = value;
            }
        }

        public string TimeStamp
        {
            get
            {
                return this.timeStamp;
            }
            set
            {
                this.timeStamp = value;
            }
        }
    }
}

