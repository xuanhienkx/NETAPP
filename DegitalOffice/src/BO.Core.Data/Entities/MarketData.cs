using DO.Common.Contract.Enums;
using DO.Common.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO.Core.DataCommon.Entities;

public class MarketData : UniqueIdentityEntityBase, ICommonEntity<Guid>
{
    public string JsonData { get; set; }
    public BoardType BoardType { get; set; }
    public MarketType MarketType { get; set; }
    public string MessageName { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime CreatedTime { get; set; }

}
