using System.Configuration;
using System.Xml;

namespace SMS.Common.Configuration
{
    public class ConfigurationTextElement : ConfigurationElement
    {
        private string value;
        protected override void DeserializeElement(XmlReader reader,
                                bool serializeCollectionKey)
        {
            value = (string)reader.ReadElementContentAs(typeof(string), null);
            if (value.StartsWith("<![CDATA[)"))
            {
                 value = value.TrimStart("<![CDATA[".ToCharArray());
            }
            if (value.EndsWith("]]>"))
            {
                value = value.TrimEnd("]]>".ToCharArray());
            }
            
        }

        public string Value
        {
            get { return value; }
        }
    }
}
