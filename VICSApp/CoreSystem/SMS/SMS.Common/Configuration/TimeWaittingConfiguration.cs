using System.Configuration;

namespace SMS.Common.Configuration
{// <TimeWaitting   Matched="30"  SendSms="45"  Debit="120"/>
    public sealed class TimeWaittingConfiguration : ConfigurationElement
    {
        public const string SectionName = "TimeWaitting";
        [ConfigurationProperty("Matched", IsRequired = true)]
        public int Matched
        {
            get { return (int)this["Matched"]; }
        }
        [ConfigurationProperty("SendSms", IsRequired = true)]
        public int SendSms
        {
            get { return (int)this["SendSms"]; }
        }
        [ConfigurationProperty("Debit", IsRequired = true)]
        public int Debit
        {
            get { return (int)this["Debit"]; }
        }
        [ConfigurationProperty("FirstDate", IsRequired = true)]
        public int FirstDate
        {
            get { return (int)this["FirstDate"]; }
        }
    }
}