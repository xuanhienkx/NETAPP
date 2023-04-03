using DO.Common.Contract.Enums;
using DO.Common.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO.Core.DataCommon.Entities;

public class MarketInfoRequest : IdentityEntityBase, ICommonEntity<long>
{
    [MaxLength(125)]
    public string MessageName { get; set; }
    public ActionType ActionType { get; set; }
    public string TradingDate { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}