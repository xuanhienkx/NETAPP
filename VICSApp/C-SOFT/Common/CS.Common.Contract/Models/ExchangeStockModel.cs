using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class ExchangeStockModel : DataContract, ICommonResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public BoardType BoardType { get; set; }//0003
        [ProtoMember(3)]
        public string VsdBoardCode { get; set; }//XSTC
        [ProtoMember(4)]
        public string ShortName { get; set; }//HOSE
        [ProtoMember(5)]
        public string FullName { get; set; }//HOCHIMINH STOCK EXCHANGE
    }
}
