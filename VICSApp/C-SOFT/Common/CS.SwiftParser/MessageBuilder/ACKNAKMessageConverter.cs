using CS.Common;
using CS.Common.Interfaces;
using CS.Common.Std.Configuration;
using CS.SwiftParser.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.SwiftParser.MessageBuilder
{
    public class ACKNAKMessageConverter : SwiftMessageConverter, IMessageConverter
    {
        public ACKNAKMessageConverter(IValueConverter valueConverter, IFieldConfigurator fieldConfigurator,
            SwiftSetting swiftSetting, ILogger<ACKNAKMessageConverter> logger)
            : base(valueConverter, fieldConfigurator, swiftSetting, logger)
        { }

        public bool CanParse(IList<KeyValuePair<string, string>> blocks)
        {
            var firstBlock = blocks.FirstOrDefault();
            Logger.LogDebug("First block value: {0}", firstBlock.Value);

            return firstBlock.Value.StartsWith(ConstantFieldProvider.ACKNAKMessageStartFilter, StringComparison.OrdinalIgnoreCase);
        }

        protected override MessageType MessageType => MessageType.ACKNAK;

        public T Parse<T>(IList<KeyValuePair<string, string>> blocks) where T : CsBag
        {
            return base.ParseToBag(blocks) as T;
        }

        public bool CanBuild(CsBag messageBag)
        {
            return base.CanBuildMessage(messageBag as SwiftBag);
        }

        public string Build(CsBag messsageBag)
        {
            return base.BuildMessage(messsageBag as SwiftBag);
        }

        public void CollectLiteralData(CsBag messsageBag)
        {
            // do nothing 
        }
    }
}