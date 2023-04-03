using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class CustodyRequestModel : DataContract, ICommonResource<long>
    {
        public CustodyRequestModel()
        {
            CreatedDate = DateTime.Now;
            Priority = MessagePriority.Normal;
            RequestType = CustodyRequestType.New;
            VsdBicCode = "VSDSVN01";
            Status = CustodyRequestStatus.Published;
        }

        public CustodyRequestModel(string businessId) : this()
        {
            BusinessId = businessId;
        }
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string BusinessId { get; set; }
        [ProtoMember(3)]
        public CustodyRequestStatus Status { get; set; }
        [ProtoMember(4)]
        public DateTime CreatedDate { get; set; }
        [ProtoMember(5)]
        public DateTime? ModifiedDate { get; set; }
        [ProtoMember(6)]
        public string Content { get; set; }
        [ProtoMember(7)]
        public string Notes { get; set; }
        [ProtoMember(8)]
        public MessagePriority Priority { get; set; }
        [ProtoMember(9)]
        public string VsdBicCode { get; set; }
        [ProtoMember(10)]
        public CustodyRequestType RequestType { get; set; }
        [ProtoMember(11)]
        public string ContentClrType { get; set; }
        [ProtoMember(12)]
        public string Description { get; set; }
        public object ContentModel { get=>Get<object>(); set=>Set(value); }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Content), "CustodyRequestModel_Content_Validation", () => !string.IsNullOrEmpty(Content));
            rules.Add(nameof(BusinessId), "CustodyRequestModel_BusinessId_Validation", () => !string.IsNullOrEmpty(BusinessId));
        }
    }
}