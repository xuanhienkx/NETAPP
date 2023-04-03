using System;
using System.Text.RegularExpressions;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable] 
    [ProtoInclude(301, typeof(Custody565Model))]
    [ProtoInclude(302, typeof(Custody566Model))]
    [ProtoInclude(303, typeof(Custody567Model))]
    public abstract class BaseVsdCustomerStockRequest : VsdCustomerStock
    { 
        [ProtoMember(1)]
        [JsonConverter(typeof(StringEnumConverter))]
        public UnitType UnitType { get; set; } 
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Quantity), "CustodyModel_Quantity_Validation", () => Quantity > 0 && Regex.IsMatch(Quantity.ToString(), Helper.NumberOnly)); 
            base.SetupRules(rules);
        }
    }
}