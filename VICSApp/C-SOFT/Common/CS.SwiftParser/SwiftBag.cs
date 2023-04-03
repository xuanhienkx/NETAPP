using CS.Common;
using CS.SwiftParser.Configuration;
using System;
using CS.Common.Std;

namespace CS.SwiftParser
{
    public class SwiftBag : CsBag
    {
        public SwiftBag(MessageType messageType)
        {
            this.MessageType = messageType;
            this[BusinessIdProviderConstant.MessageType] = messageType;

            ObseverValueChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals(BusinessIdProviderConstant.MessageId, StringComparison.OrdinalIgnoreCase))
                    MessageId = (string) this[BusinessIdProviderConstant.MessageId];
            };
        }

        public MessageType MessageType { get; }
        public string MessageId { get; private set; }
    }
}
