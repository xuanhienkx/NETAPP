using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Domain.Data.Entities
{
    [Table("BusinessAccountSetting")]
    public class BusinessAccountSetting
    {
        public long AccountId { get; set; }
        public long BusinessId { get; set; }
        public byte Type { get; set; }
        public string XmlSetting { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(BusinessId))]
        public virtual BusinessUnit BusinessUnit { get; set; }
    }
}
