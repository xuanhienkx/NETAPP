using DSoft.Common.Extensions;
using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Interfaces;
using DSoft.MarketParser.Common;
using DSoft.MarketParser.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

namespace DSoft.MarketParser
{
    public class InfogateMessageConverter : IHnxMessageConverter
    {
        private readonly ILogger<InfogateMessageConverter> logger;
        private readonly IConfigurationRoot settings;
        private readonly IValueConverter valueconvertor;
        int lastVisitLenght = 0;
        private byte[] buffers = new byte[2 * 2048];
        MarketSetting infogateSeting;
        List<Part> listHear = new List<Part>();
        public InfogateMessageConverter(ILogger<InfogateMessageConverter> logger, IConfigurationRoot settings, IValueConverter valueconvertor)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.valueconvertor = valueconvertor ?? throw new ArgumentNullException(nameof(valueconvertor));
            var configFileInfogateHeader = Path.Combine(settings["gateway:settingPath"], "InforgateHeaderSetting.json");
            listHear = ObjectLoader.FromFile<List<Part>>(configFileInfogateHeader);
            if (listHear == null)
                throw new ArgumentNullException($"MarketSetting", $"Cannot load parts Setting  from path: {configFileInfogateHeader}");
            var configFileInfogate = Path.Combine(settings["gateway:settingPath"], "InfogateSetting.json");
            infogateSeting = ObjectLoader.FromFile<MarketSetting>(configFileInfogate);
            if (infogateSeting == null)
                throw new ArgumentNullException($"MarketSetting", $"Cannot load MarketSetting Setting  from path: {configFileInfogate}");
        }

        public async Task<T> Read<T>(string file) where T : CsBag
        {
            var endOfStream = false;
            var bag = new PrsBag("InfoGate");
            char b = '\u0001';
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            using (var stream = new StreamReader(fs, Encoding.UTF8))
            {
                string readText;
                int lineReadCount = 0;
                while ((readText = await stream.ReadLineAsync())!= null)  
                {                                
                    var bodyLeng = readText.Between($"8=HNX.TDS.1{b}9=", $"{b}35=", 0, out int lastIndex);
                    var msgType = readText.Between($"{b}35=", $"{b}49=HNX", 0, out lastIndex); 
                    var msgSetting = infogateSeting.Messages.FirstOrDefault(x => x.Type.Equals(msgType, StringComparison.OrdinalIgnoreCase));
                    if (msgSetting == null)
                    {
                       // logger.LogWarning("Do not has setting with message type {0} with body lenght [{1}]", msgType, bodyLeng);
                        continue;
                    }

                    var listLine = readText.Split(b);          
                    listHear.AddRange(msgSetting.Parts);
                    var lengthOfBody = int.Parse(bodyLeng);
                   // logger.LogInformation("Convert message {0} with body lenght [{1}]", msgType, bodyLeng);
                    
                    foreach (var item in listLine)
                    {
                        if (string.IsNullOrEmpty(item))
                            break;

                        var datas = item.Split("=");
                        int tag = int.Parse(datas[0]);
                        var part = listHear.FirstOrDefault(x => x.Tag == tag);
                        if (part != null)
                        {
                            var valuepart = datas[1];
                            object rsValue = null;
                          //  logger.LogDebug("Data part-- Name [{0}] type:{1} Format {2}, --tag:[{3}] value: ({4})--", part.Name, part.Type, part.Format, tag, valuepart);
                            if (part.Format != null)
                                rsValue = valueconvertor.Parse(valuepart, part.Type, part.Format);
                            else
                                rsValue = valuepart;
                            var name = $"{msgType}{lineReadCount++}.{part.Name}";
                           // logger.LogDebug("----name [{0}] value: ({1})---", name, rsValue);
                            bag[name] = rsValue;
                        }
                    }
                    
                } 

            }

            return bag as T;
        }
    }
}
