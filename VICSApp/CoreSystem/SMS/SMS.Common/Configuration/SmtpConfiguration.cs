using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace SMS.Common.Configuration
{
    public class SmtpConfiguration : ConfigurationSection
    {
        public const string SectionName = "smtp";
        private static SmtpConfiguration configuration;
        private SmtpClient smtpClient;

        [ConfigurationProperty("account", IsRequired = true)]
        public string Account
        {
            get { return (string)this["account"]; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
        }

        [ConfigurationProperty("host", IsRequired = true)]
        public string Host
        {
            get { return (string)this["host"]; }
        }

        [ConfigurationProperty("port", IsRequired = true)]
        public int Port
        {
            get { return (int)this["port"]; }
        }

        [ConfigurationProperty("enableSsl", DefaultValue = true)]
        public bool EnableSsl
        {
            get { return (bool)this["enableSsl"]; }
        }

        [ConfigurationProperty("deliveryMethod", DefaultValue = SmtpDeliveryMethod.Network)]
        public SmtpDeliveryMethod DeliveryMethod
        {
            get { return (SmtpDeliveryMethod)this["deliveryMethod"]; }
        }

        [ConfigurationProperty("timeOut", DefaultValue = 1000)]
        public int TimeOut
        {
            get { return (int)this["timeOut"]; }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(SmtpConfiguration), AddItemName = "template")]
        public EmailTemplateConfigurationCollection Templates
        {
            get { return (EmailTemplateConfigurationCollection)this[""]; }
        }

        public static SmtpConfiguration Current
        {
            get { return configuration ?? (configuration = LoadConfiguration()); }
        }

        private static SmtpConfiguration LoadConfiguration()
        {
            return (SmtpConfiguration)ConfigurationManager.GetSection(SectionName);
        }

        public SmtpClient SmtpClient
        {
            get
            {
                return smtpClient ?? (smtpClient = new SmtpClient(Host)
                {
                    Port = Port,
                    EnableSsl = EnableSsl,
                    DeliveryMethod = DeliveryMethod,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Account, Password),
                    Timeout = TimeOut
                });
            }
        }
    }

    public class EmailTemplateConfigurationCollection : ConfigurationElementCollection, IEnumerable<EmailTemplateConfiguration>
    {
        private readonly List<EmailTemplateConfiguration> elements;

        public EmailTemplateConfigurationCollection()
        {
            elements = new List<EmailTemplateConfiguration>();
        }
        protected override ConfigurationElement CreateNewElement()
        {
            var element = new EmailTemplateConfiguration();
            elements.Add(element);
            return element;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EmailTemplateConfiguration)element).Name;
        }

        public new IEnumerator<EmailTemplateConfiguration> GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }

    public class EmailTemplateConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
        }

        [ConfigurationProperty("from", IsRequired = true)]
        public string FromAddress
        {
            get { return (string)this["from"]; }
        }

        [ConfigurationProperty("fromName")]
        public string FromName
        {
            get { return (string)this["fromName"]; }
        }

        [ConfigurationProperty("subject", IsRequired = true)]
        public ConfigurationTextElement Subject
        {
            get { return (ConfigurationTextElement)this["subject"]; }
        }

        [ConfigurationProperty("body", IsRequired = true)]
        public ConfigurationTextElement Body
        {
            get { return (ConfigurationTextElement)this["body"]; }
        }

        [ConfigurationProperty("isHtml", DefaultValue = false)]
        public bool BodyIsHtml
        {
            get { return (bool)this["isHtml"]; }
        }
    } 
}
