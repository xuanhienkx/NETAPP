using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SMS.Common.Models;

namespace SMS.Common.Configuration
{
    public class ApiEmsConfiguration : ConfigurationSection
    { 
        public const string SectionName = "EsmsApi";
        private static ApiEmsConfiguration configuration;
        private SmsClient smsClient;

        

        [ConfigurationProperty("ApiKey", IsRequired = true)]
        public string ApiKey
        {
            get { return (string)this["ApiKey"]; }
        }

        [ConfigurationProperty("SecretKey", IsRequired = true)]
        public string SecretKey
        {
            get { return (string)this["SecretKey"]; }
        }

        [ConfigurationProperty("SandBox", IsRequired = true)]
        public byte SandBox
        {
            get { return (byte)this["SandBox"]; }
        }

        [ConfigurationProperty("ResponseTimeOut", IsRequired = true)]
        public int ResponseTimeOut
        {
            get { return (int)this["ResponseTimeOut"]; }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(ApiEmsConfiguration), AddItemName = "template")]
        public EsmsTemplateConfigurationCollection Templates
        {
            get { return (EsmsTemplateConfigurationCollection)this[""]; }
        }

        [ConfigurationProperty("BrandName")]
        public string BrandName
        {
            get { return (string)this["BrandName"]; }
        }

        [ConfigurationProperty("Telecome", IsRequired = false)]
        public string Telecome
        {
            get { return (string)this["Telecome"]; }
        }
        public static ApiEmsConfiguration Current
        {
            get { return configuration ?? (configuration = LoadConfiguration()); }
        }

        private static ApiEmsConfiguration LoadConfiguration()
        {
            return (ApiEmsConfiguration)ConfigurationManager.GetSection(SectionName);
        }

        public SmsClient SmsClient
        {
            get
            {
                return smsClient ?? (smsClient = new SmsClient()
                {
                    Apikey = ApiKey,
                    Secretkey = SecretKey,
                    SanbBox = SandBox,
                    Brandname = BrandName
                });
            }
        }

    }

    public class EsmsTemplateConfigurationCollection : ConfigurationElementCollection,
        IEnumerable<EsmsTemplateConfiguration>
    {
        private readonly List<EsmsTemplateConfiguration> esmsTemplatesList;

        public EsmsTemplateConfigurationCollection()
        {
            esmsTemplatesList = new List<EsmsTemplateConfiguration>();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            var el = new EsmsTemplateConfiguration();
            esmsTemplatesList.Add(el);
            return el;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EsmsTemplateConfiguration)element).Name;
        }

        public IEnumerator<EsmsTemplateConfiguration> GetEnumerator()
        {
            return esmsTemplatesList.GetEnumerator();
        }

    }
    public class EsmsTemplateConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
        }

        [ConfigurationProperty("Url", IsRequired = true)]
        public string Url
        {
            get { return (string)this["Url"]; }
        }

        [ConfigurationProperty("Body", IsRequired = true)]
        public ConfigurationTextElement Body
        {
            get { return (ConfigurationTextElement)this["Body"]; }
        }

    }

}