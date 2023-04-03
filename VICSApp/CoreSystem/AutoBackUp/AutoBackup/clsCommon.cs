using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace AutoBackup
{
   internal class clsCommon
   {
   }

   public class ftpSettingElements : ConfigurationElement
   {
      public ftpSettingElements()
      {
      }

      [ConfigurationProperty("key", IsRequired = true)]
      public String Key
      {
         get
         {
            return (String) this["key"];
         }
         set
         {
            this["key"] = value;
         }
      }

      [ConfigurationProperty("serverAddress", DefaultValue = "127.0.0.1", IsRequired = true)]
      public String serverAddress
      {
         get
         {
            return (String) this["serverAddress"];
         }
         set
         {
            this["serverAddress"] = value;
         }
      }

      [ConfigurationProperty("FolderName", IsRequired = true)]
      public String FolderName
      {
         get
         {
            return (String) this["FolderName"];
         }
         set
         {
            this["FolderName"] = value;
         }
      }

      [ConfigurationProperty("Username", IsRequired = true)]
      public String Username
      {
         get
         {
            return (String) this["Username"];
         }
         set
         {
            this["Username"] = value;
         }
      }

      [ConfigurationProperty("Password", IsRequired = true)]
      public String Password
      {
         get
         {
            return (String) this["Password"];
         }
         set
         {
            this["Password"] = value;
         }
      }

      [ConfigurationProperty("isActive", DefaultValue = "1", IsRequired = false)]
      public String isActive
      {
         get
         {
            return (String) this["isActive"];
         }
         set
         {
            this["isActive"] = value;
         }
      }
   }

   public class ftpSettingCollection : System.Configuration.ConfigurationElementCollection
   {
      public ftpSettingElements this[int index]
      {
         get
         {
            return base.BaseGet(index) as ftpSettingElements;
         }
         set
         {
            if (base.BaseGet(index) != null)
            {
               base.BaseRemoveAt(index);
            }
            this.BaseAdd(index, value);
         }
      }

      protected override System.Configuration.ConfigurationElement CreateNewElement()
      {
         return new ftpSettingElements();
      }

      protected override object GetElementKey(System.Configuration.ConfigurationElement element)
      {
         return ((ftpSettingElements) element).Key;
      }
   }


   public class FTPConfiguration : System.Configuration.ConfigurationSection
   {
      private static string sConfigurationSectionConst = "ftpConfiguration";

      /// <summary>
      /// Returns an shiConfiguration instance
      /// </summary>
      public FTPConfiguration GetConfig()
      {
         return
            (FTPConfiguration)
               System.Configuration.ConfigurationManager.GetSection(FTPConfiguration.sConfigurationSectionConst) ??
            new FTPConfiguration();
      }

      [System.Configuration.ConfigurationProperty("ftpSettings")]
      public ftpSettingCollection ftpSettings
      {
         get
         {
            return (ftpSettingCollection) this["ftpSettings"] ?? new ftpSettingCollection();
         }
      }
   }
}
