using System;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    public class CS078Model : ICsvDataReport
    {
        [ProtoMember(1)]
        public string CurrencyUnit { get; set; }
        [ProtoMember(2)]
        public string BondOrStockFund { get; set; }
        [ProtoMember(3)]
        public string PaymentPeriod { get; set; }
        [ProtoMember(4)]
        public DateTime? DateOfValidity { get; set; }
        [ProtoMember(5)]
        public string Membercode { get; set; }
        [ProtoMember(6)]
        public string MemberName { get; set; }
        [ProtoMember(7)]
        public string Exchange { get; set; }
        [ProtoMember(8)]
        public long CompanyBuy { get; set; }
        [ProtoMember(9)]
        public long CompanySell { get; set; }
        [ProtoMember(10)]
        public long CompanyPay { get; set; }
        [ProtoMember(11)]
        public long CompanyReceived { get; set; }
        [ProtoMember(12)]
        public long BuyBroker { get; set; }
        [ProtoMember(13)]
        public long SellBroker { get; set; }
        [ProtoMember(14)]
        public long BrokerPay { get; set; }
        [ProtoMember(15)]
        public long BrokerReceived { get; set; }
        [ProtoMember(16)]
        public long BuyForeignBroker { get; set; }
        [ProtoMember(17)]
        public long SellForeignBroker { get; set; }
        [ProtoMember(18)]
        public long ForeignBrokerPay { get; set; }
        [ProtoMember(19)]
        public long ForeignBrokerReceived { get; set; }
        [ProtoMember(20)]
        public long BuyQuantity { get; set; }
        [ProtoMember(21)]
        public long SellQuantity { get; set; }
        [ProtoMember(22)]
        public long PaymentQuantity { get; set; }
        [ProtoMember(23)]
        public long ReceivedQuantity { get; set; }
    }
}