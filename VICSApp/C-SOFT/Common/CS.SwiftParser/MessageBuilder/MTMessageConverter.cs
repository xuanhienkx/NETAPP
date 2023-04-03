using CS.Common;
using CS.Common.Interfaces;
using CS.SwiftParser.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using CS.Common.Std.Configuration;

namespace CS.SwiftParser.MessageBuilder
{
    public class MTMessageConverter : SwiftMessageConverter, IMessageConverter
    {
        public MTMessageConverter(IValueConverter valueConverter,IFieldConfigurator fieldConfigurator, SwiftSetting swiftSetting, ILogger<MTMessageConverter> logger) 
            : base(valueConverter, fieldConfigurator, swiftSetting, logger)
        { }

        public bool CanParse(IList<KeyValuePair<string, string>> blocks)
        {
            var firstBlock = blocks.FirstOrDefault();
            return firstBlock.Value.StartsWith(ConstantFieldProvider.MTMessageStartFilter, StringComparison.OrdinalIgnoreCase);
        }

        protected override MessageType MessageType => MessageType.MT;

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
