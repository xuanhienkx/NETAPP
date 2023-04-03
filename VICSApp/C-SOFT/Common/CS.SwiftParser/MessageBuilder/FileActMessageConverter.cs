using CS.Common;
using CS.Common.Interfaces;
using CS.SwiftParser.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CS.Common.Std;
using CS.Common.Std.Configuration;
using CS.Common.Std.Extensions;

namespace CS.SwiftParser.MessageBuilder
{
    public class FileActMessageConverter : IMessageConverter
    {
        private readonly IConfigurationRoot configuration;
        private readonly IValueConverter valueConverter;
        private readonly ILogger<FileActMessageConverter> logger;
        private readonly SwiftSetting swiftSetting;
        private readonly string vsdSettingPath;

        public FileActMessageConverter(IValueConverter valueConverter, SwiftSetting swiftSetting, IConfigurationRoot configuration, ILogger<FileActMessageConverter> logger)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.swiftSetting = swiftSetting ?? throw new ArgumentNullException(nameof(swiftSetting));
            vsdSettingPath = configuration?["gateway:settingPath"] ?? throw new ArgumentNullException("gateway:settingPath");
        }

        protected MessageType MessageType => MessageType.FileACT;
        public bool CanParse(IList<KeyValuePair<string, string>> blocks)
        {
            var fileName = blocks.SingleOrDefault(x => x.Key == BusinessIdProviderConstant.FileName).Value;
            logger.LogDebug("Filename: {0}", fileName);

            var configFile = swiftSetting.BusinessUnits.SingleOrDefault(x
                => x.Messages.Any(m => m.Type == MessageType.FileACT && fileName.Contains(m.KeyValue.ToLowerInvariant())));

            if (string.IsNullOrEmpty(configFile.Id))
                return false;

            var code = configFile.Messages.Single(x => x.Type == MessageType.FileACT && fileName.Contains(x.KeyValue.ToLowerInvariant())).KeyValue;
            logger.LogDebug("BusinessId: {0} - messageId: {1} - file: {2}", configFile.Id, code, fileName);

            // append two last block for getting infomation later on the parse method
            blocks.Add(new KeyValuePair<string, string>(BusinessIdProviderConstant.ReportCode, code));
            blocks.Add(new KeyValuePair<string, string>(BusinessIdProviderConstant.BusinessId, configFile.Id));

            return !string.IsNullOrEmpty(configFile.Id);
        }

        public T Parse<T>(IList<KeyValuePair<string, string>> blocks) where T : CsBag
        {
            var rawData = blocks.SingleOrDefault(x => x.Key == BusinessIdProviderConstant.CsvData).Value;
            var code = blocks.SingleOrDefault(x => x.Key == BusinessIdProviderConstant.ReportCode).Value;
            var businessId = blocks.SingleOrDefault(x => x.Key == BusinessIdProviderConstant.BusinessId).Value; 
            var bag = new SwiftBag(MessageType.FileACT)
            {
                [BusinessIdProviderConstant.ReportCode] = code,
                [BusinessIdProviderConstant.MessageId] = code,
                [BusinessIdProviderConstant.BusinessId] = businessId
            };

            // build fileACT fields 
            var fields = rawData.Split(new[] { Environment.NewLine, ConstantFieldProvider.ActNewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields)
            {
                var index = field.IndexOf('=');
                var key = field.Substring(0, index);
                var value = field.Substring(++index).Trim(' ', '\r');
                logger.LogDebug("fieldKey: [{0}], \t fieldValue: [{1}]", key, value);
                bag[key] = value;
            }

            var fileCsvName = bag[ConstantFieldProvider.LogicalName].ToString();
            var receivePath = configuration["vsd:receivePath"].ToLowerInvariant();
            var configId = $"{businessId}/{code}_Response.json";
            logger.LogInformation($"File structure: [{configId}]");
            var csvConfig = ObjectLoader.FromFile<FileActSetting>(Path.Combine(vsdSettingPath, "Messages", configId));
            var csvFile = Path.Combine(receivePath, fileCsvName);
            var listPartToLine = JsonConvert.SerializeObject(csvConfig.Fields).Base64Encode();
            File.AppendAllLines(csvFile, new[] { listPartToLine });



            return bag as T;
        }

        private CsBag ParseFromCsvFields(IList<Part> parts, string data)
        {
            var bag = new CsBag();
            var idx = 0;

            var pReader = new ItemReader<Part>(parts);
            var start = pReader.Current.Start;
            while (pReader.MoveNext())
            {
                var end = $"{pReader.Current.End}{pReader.Next.Start}";
                var value = data.Between(start, end, idx, out idx);

                logger.LogDebug("Start: {0}, end: {1}, index: {2},name: {3}, value: [{4}]", start, end, idx, pReader.Current.Name, value);
                start = end;

                bag[pReader.Current.Name] = valueConverter.Parse(value, pReader.Current.Type, pReader.Current.Format);
            }

            return bag;
        }

        public bool CanBuild(CsBag messageBag)
        {
            return false;
        }

        public string Build(CsBag messsageBag)
        {
            return null;
        }

        public void CollectLiteralData(CsBag messsageBag)
        {
            // build value for Parameters
            if (!messsageBag.TryGet(BusinessIdProviderConstant.ReportCode, out string reportCode))
                return;
            if (!messsageBag.TryGet(BusinessIdProviderConstant.ReportSetParam, out bool isSeparam) || !isSeparam)
                return;

            var configFile = swiftSetting.BusinessUnits.SingleOrDefault(x
                => x.Messages.Any(m => m.Type == MessageType.FileACT && m.KeyValue.Equals(reportCode, StringComparison.OrdinalIgnoreCase)));

            if (string.IsNullOrEmpty(configFile.Id))
                throw new ArgumentNullException($"Cannot find config file for request code: {reportCode}");

            var fileName = $"{configFile.Id}/{reportCode}_Response.json";
            var reportConfig = ObjectLoader.FromFile<FileActSetting>(Path.Combine(vsdSettingPath, "Messages", fileName));
            logger.LogDebug("BusinessId: {0} - report code: {1} - file: {2}", configFile.Id, reportCode, fileName);

            if (!reportConfig.Parameter.Any())
                return;

            var paramBuilder = new StringBuilder();
            foreach (var part in reportConfig.Parameter)
            {
                var value = valueConverter.ToString(messsageBag[part.Name], part.Type, part.Format);
                paramBuilder.Append($"{part.Start}{value}{part.End}");
                // paramBuilder.AppendFormat("{0}:{1}{2}", part.Name, value, ConstantFieldProvider.NewLine);
            }
            var paramstring = paramBuilder.ToString();
            logger.LogDebug($"Parameter for report [{reportCode}] is:[{paramstring}]");
            messsageBag[BusinessIdProviderConstant.Parameters] = paramstring;
        }

    }
}
