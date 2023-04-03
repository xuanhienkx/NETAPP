using System;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable]
    public abstract class BaseVsdRejectRequestModel
    {
        [ProtoMember(1)]
        public string OutReferenceNumber { get; set; }
        [ProtoMember(2)]
        public string LinkMessageId { get; set; }
        [ProtoMember(3)]
        public string ConfirmCode { get; set; }
        [ProtoMember(4)]
        public string ReasionCode { get; set; }
        [ProtoMember(5)]
        public string ErrorMessage { get; set; }
        [ProtoMember(6)]
        public string Notes { get; set; }
    }
}