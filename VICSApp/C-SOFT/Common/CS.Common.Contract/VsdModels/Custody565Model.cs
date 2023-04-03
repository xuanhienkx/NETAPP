using System;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable]
    public class Custody565Model : BaseVsdCustomerStockRequest
    {
        public Custody565Model()
        {
            UnitType = UnitType.StockUnit;
        }
        [ProtoMember(1)]
        public string OrigTransferRef { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(2)]
        public CardType CardType { get; set; }
        [ProtoMember(3)]
        public string CardIdentity { get; set; }
        [ProtoMember(4)]
        public DateTime CardIssuedDate { get; set; }
        [ProtoMember(5)]
        public int IdentifiAdditional { get; set; }
        public string LinkMessageId { get; set; }//:LINK//565 cho trường hợp 23G=CANC; now not use
        public string OfficialEventReference { get; set; }// now not use
        public string PreviousReferen { get; set; }// now not use

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(OrigTransferRef), "CustodyModel_OrigTransferRef_Validation", () => !string.IsNullOrEmpty(OrigTransferRef)); 
            base.SetupRules(rules);
        }

    }
}