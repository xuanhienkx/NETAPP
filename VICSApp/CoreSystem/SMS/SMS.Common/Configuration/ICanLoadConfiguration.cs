using System.Xml;

namespace SMS.Common.Configuration
{
    public interface ICanLoadConfiguration
    {
        void LoadConfiguration(XmlNode section);
    }
}
