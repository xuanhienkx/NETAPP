using System;
using System.Collections.Generic;
using System.Configuration;

namespace SMS.Common.Configuration
{
    public sealed class SmsConfiguration : ConfigurationSection
    {
        private static SmsConfiguration smsConfiguration;
        private const string SectionPropertyName = "smsConfiguration";

        [ConfigurationProperty(TimeExecuteConfiguration.SectionName)]
        public TimeExecuteConfiguration TimeExecuteConfig
        {
            get
            {
                return (TimeExecuteConfiguration)this[TimeExecuteConfiguration.SectionName];
            }
        }
        [ConfigurationProperty(TimeWaittingConfiguration.SectionName)]
        public TimeWaittingConfiguration TimeWaittingConfig
        {
            get
            {
                return (TimeWaittingConfiguration)this[TimeWaittingConfiguration.SectionName];
            }
        }

        [ConfigurationProperty(BaseSettingConfiguration.SectionName)]
        public BaseSettingConfiguration BaseConfig
        {
            get
            {
                return (BaseSettingConfiguration)this[BaseSettingConfiguration.SectionName];
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(SmsConfiguration), AddItemName = "template")]
        public MessageTemplateConfigurationCollection Templates
        {
            get { return (MessageTemplateConfigurationCollection)this[""]; }
        }

        public static SmsConfiguration Current
        {
            get
            {
                return smsConfiguration ?? (smsConfiguration = LoadConfiguration());
            }
        }

        private static SmsConfiguration LoadConfiguration()
        {
            return (SmsConfiguration)ConfigurationManager.GetSection(SectionPropertyName);
        }

        public bool AllowSendSMS
        {
            get
            {
                bool allowSend;
                return bool.TryParse(ConfigurationManager.AppSettings["allowSendSmS"], out allowSend) && allowSend;
            }
        }

    }
    public class MessageTemplateConfigurationCollection : ConfigurationElementCollection,
        IEnumerable<MessageTemplateConfiguration>
    {
        private readonly List<MessageTemplateConfiguration> elements;

        public MessageTemplateConfigurationCollection()
        {
            elements = new List<MessageTemplateConfiguration>();
        }
        protected override ConfigurationElement CreateNewElement()
        {
            var element = new MessageTemplateConfiguration();
            elements.Add(element);
            return element;

        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MessageTemplateConfiguration)element).Name;
        }

        public new IEnumerator<MessageTemplateConfiguration> GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }

    public class MessageTemplateConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
        }

        [ConfigurationProperty("Body", IsRequired = true)]
        public ConfigurationTextElement Body
        {
            get { return (ConfigurationTextElement)this["Body"]; }
        }
    }
    // <Transaction BankGl="112;118" MinimumAmount="1,000,000" />
    public sealed class BaseSettingConfiguration : ConfigurationElement
    {
        public const string SectionName = "BaseSetting";
        [ConfigurationProperty("DebitOrCreditFormat", IsRequired = true)]
        public string DebitOrCreditFormat
        {
            get
            {
                return (string)this["DebitOrCreditFormat"];
            }
        }
        [ConfigurationProperty("BuyOrSelFormat", IsRequired = true)]
        public string BuyOrSelFormat
        {
            get
            {
                return (string)this["BuyOrSelFormat"];
            }
        }
        [ConfigurationProperty("BankList", IsRequired = true)]
        public string BankList
        {
            get
            {
                return (string)this["BankList"];
            }
        }
        [ConfigurationProperty("MinimumAmount", IsRequired = true)]
        public decimal MinimumAmount
        {
            get
            {
                var str = (string)this["MinimumAmount"];
                return Convert.ToDecimal(string.IsNullOrEmpty(str) ? "0" : str.Replace(",", ""));
            }
        }
        public List<string> BankGl
        {
            get { return new List<string>(BankList.Split(';')); }
        }

        public string BuyFormat
        {
            get { return BuyOrSelFormat.Split('/')[0]; }
        }

        public string SellFormat
        {
            get { return BuyOrSelFormat.Split('/')[1]; }
        }

        //
        public string DebitFormat
        {
            get { return DebitOrCreditFormat.Split('/')[0]; }
        }

        public string CreditFormat
        {
            get { return DebitOrCreditFormat.Split('/')[1]; }
        }

    }

   
}