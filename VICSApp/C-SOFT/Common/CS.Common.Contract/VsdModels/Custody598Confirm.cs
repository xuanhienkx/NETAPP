using System;
using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    public class Custody598Confirm : DataContract, IVsdCommon
    {
        public Custody598Confirm()
        {
            BoardType = BoardType.Hnx;
            SettlementDate = DateTime.Now;
            ConfirmType = ConfirmType.Confirm; 
        }
        [ProtoMember(1)]
        public string OrigTransferRef { get; set; }
        [ProtoMember(2)]
        public string PreviousReference { get; set; }
        [ProtoMember(3)]
        public string ReportCode { get; set; }
        [ProtoMember(4)]
        public DateTime SettlementDate { get; set; }
        [ProtoMember(5)]
        public BoardType BoardType { get; set; }
        [ProtoMember(6)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConfirmType ConfirmType { get; set; }
        [ProtoMember(7)]
        public string LogicalName { get; set; }
        [ProtoMember(8)]
        public string StockCode { get; set; }
        [ProtoMember(9)]
        public string ReportName { get; set; }
        [ProtoMember(10)]
        public long FileActId { get; set; }
        [ProtoMember(11)]
        public ReportStatus ReportStatus { get; set; }
        [ProtoIgnore]
        public SubMessageType SubMessageType =>
            ConfirmType == ConfirmType.Confirm ? SubMessageType.AprovalConfirm : SubMessageType.RejectedConfirm;
    }
}
