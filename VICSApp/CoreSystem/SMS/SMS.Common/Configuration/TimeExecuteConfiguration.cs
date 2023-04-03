using System;
using System.Configuration;

namespace SMS.Common.Configuration
{
    public sealed class TimeExecuteConfiguration : ConfigurationElement
    {
        public const string SectionName = "TimeExecute";
        [ConfigurationProperty("StartDealTime", IsRequired = true)]
        public TimeSpan StartDealTime
        {
            get
            {
                string startTime = this["StartDealTime"].ToString();
                var time = TimeSpan.Parse(startTime);
                return time;

            }
        }

        [ConfigurationProperty("EndDealTime", IsRequired = true)]
        public TimeSpan EndDealTime
        {
            get
            {
                string endTime = (string)this["EndDealTime"].ToString();
                var time = TimeSpan.Parse(endTime);
                return time;
            }
        }

        [ConfigurationProperty("EndSendTime", IsRequired = true)]
        public TimeSpan EndSendTime
        {
            get
            {
                string endCloseTime = this["EndSendTime"].ToString();
                var time = TimeSpan.Parse(endCloseTime);
                return time;
            }
        }
        [ConfigurationProperty("EndCloseTime", IsRequired = true)]
        public TimeSpan EndCloseTime
        {
            get
            {
                string endCloseTime = this["EndCloseTime"].ToString();
                var time = TimeSpan.Parse(endCloseTime);
                return time;
            }
        }
        [ConfigurationProperty("TransactionDate")]
        public DateTime TransactionDate
        {
            get
            {
                var tranDate = this["TransactionDate"].ToString();
                DateTime input;
                if (!DateTime.TryParse(tranDate, out input)) return DateTime.Today;
                return DateTime.MinValue != input ? input : DateTime.Today;
            }
        } 
    }
}