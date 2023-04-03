using System.Configuration;

namespace SMS.Common.Configuration
{
    public sealed class StandSettingConfiguration : ConfigurationElement
    {
        public const string SectionName = "StandSetting";
        [ConfigurationProperty("SandBox", IsRequired = true)]
        public int SandBox
        {
            get { return (int)this["SandBox"]; }
        }
        [ConfigurationProperty("ResponseTimeOut", IsRequired = false)]
        public int TimeOut
        {
            get { return (int)this["ResponseTimeOut"]; }
        }
    }

    public sealed class AccessESmsConfiguration : ConfigurationElement
    {
        public const string SectionName = "AccessESms";
        [ConfigurationProperty("APIKey", IsRequired = true)]
        public string APIKey
        {
            get { return (string)this["APIKey"]; }
        }
        [ConfigurationProperty("SecretKey", IsRequired = true)]
        public string SecretKey
        {
            get { return (string)this["SecretKey"]; }
        }
       
    }

    public sealed class AccessUrlConfiguration : ConfigurationElement
    {
        public const string SectionName = "AccessUrl";
        [ConfigurationProperty("UrlSendSms", IsRequired = true)]
        public string UrlSendSms
        {
            get { return (string)this["UrlSendSms"]; }
        }
        [ConfigurationProperty("UrlSmsBrandName", IsRequired = true)]
        public string UrlSmsBrandName
        {
            get { return (string)this["UrlSmsBrandName"]; }
        }
        [ConfigurationProperty("UrlGetStatus", IsRequired = true)]
        public string UrlGetStatus
        {
            get { return (string)this["UrlGetStatus"]; }
        }
    }

    public sealed class BrandNameWorkConfiguration : ConfigurationElement
    {
        public const string SectionName = "BrandNameWork"; 
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
        }

        [ConfigurationProperty("Telecome", IsRequired = true)]
        public string Telecome
        {
            get { return (string)this["Telecome"]; }
        }
    }
}