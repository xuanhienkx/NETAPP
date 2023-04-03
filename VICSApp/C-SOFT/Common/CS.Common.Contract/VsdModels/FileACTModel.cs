using CS.Common.Contract.Enums;
using Newtonsoft.Json;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    public class FileActModel : DataContract, ICommonResource<long>
    {
        [ProtoMember(1)]
        public string OrigTransferRef { get; set; }
        [ProtoMember(2)]
        public string ReportCode { get; set; }
        [ProtoMember(4)]
        public string SwiftTime { get; set; }
        public string DeliveryTime { get; set; }
        [ProtoMember(5)]
        public string LogicalName { get; set; }
        [ProtoMember(6)]
        public string RequestRef { get; set; }
        [ProtoMember(7)]
        public string TransferRef { get; set; }
        [ProtoMember(8)]
        public string TransferDescription { get; set; }
        [ProtoMember(9)]
        public string TransferInfo { get; set; }
        [ProtoMember(10)]
        public string FileInfo { get; set; }
        [ProtoMember(11)]
        public string FileDescription { get; set; }
        [ProtoMember(12)]
        public long Id { get; set; }
        [ProtoMember(13)]
        public ReportType ReportType { get; set; }
        [ProtoMember(14)]
        public ReportStatus ReportStatus { get; set; }
        [ProtoMember(15)]
        public string BusinessId { get; set; }
        [ProtoIgnore]
        [JsonIgnore]
        public string StockCode => !string.IsNullOrEmpty(LogicalName) ? LogicalName.Split('\'')[0].ToUpper() : null;
    }
}
