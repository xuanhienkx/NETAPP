using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Domain.Data.Entities
{
    public class BranchSetting
    {
        [Required, Column(TypeName = "varchar(250)")]
        public string Key { get; set; }
        public string Value { get; set; }

        public long BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }
    }
}
