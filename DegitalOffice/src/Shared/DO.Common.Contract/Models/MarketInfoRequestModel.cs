using DO.Common.Contract.Enums;
using ProtoBuf;
using System;

namespace DO.Common.Contract.Models
{
    [ProtoContract]
    public class MarketInfoRequestModel : DataContract, ICommonResource<long>
    {
        public MarketInfoRequestModel()
        {
            CreatedDate = DateTime.Now;
            ActionType = ActionType.Insert;
        }

        public MarketInfoRequestModel(string messageName) : this()
        {
            MessageName = messageName;
        }
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string MessageName { get; set; }

        [ProtoMember(3)]
        public string Content { get; set; }
        [ProtoMember(4)]
        public string Description { get; set; }
        [ProtoMember(5)]
        public ActionType ActionType { get; set; }
        [ProtoMember(6)]
        public DateTime CreatedDate { get; set; }
        [ProtoMember(7)]
        public DateTime? ModifiedDate { get; set; }
        [ProtoMember(8)]
        public string TradingDate { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Content), "MarketInfoRequestModel_Content_Validation", () => !string.IsNullOrEmpty(Content));
            rules.Add(nameof(MessageName), "MarketInfoRequestModel_BusinessId_Validation", () => !string.IsNullOrEmpty(MessageName));
        }
    }
}