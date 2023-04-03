using System;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    public class DE065Model : ICsvDataReport
    {
        [ProtoMember(1)]
        public long PinNumber { get; set; }
        [ProtoMember(2)]
        public string ShortName { get; set; }
        [ProtoMember(3)]
        public string FullName { get; set; }
        [ProtoMember(4)]
        public string CardIdentity { get; set; }
        [ProtoMember(6)]
        public string StockCode { get; set; }
        [ProtoMember(7)]
        public string StockName { get; set; }
        [ProtoMember(8)]
        public DateTime CardIssuedDate { get; set; }
        [ProtoMember(9)]
        public string Nationality { get; set; }
        [ProtoMember(10)]
        public string CustomerNumber { get; set; }
        [ProtoMember(12)]
        public string StockBangGl { get; set; }
        [ProtoMember(13)]
        public string AccountType { get; set; }
        [ProtoMember(14)]
        public long Quantity { get; set; }
        [ProtoMember(15)]
        public string Notes { get; set; } 
        public string Membercode { get; set; }
        public string MemberName { get; set; }
    }
}