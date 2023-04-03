using DO.Common.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO.Domain.Audit.Entities
{

    [Table("MarketRequestHistory")]
    public class MarketRequestHistory : IHistorySource
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string MessageName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
        public string UpdateType { get; set; }
        public string TradingDate { get; set; }
        public DateTime ProcessTime => DateTime.Now;
    }
}
