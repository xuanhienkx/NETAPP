using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.Domain.Data.Entities
{
    [Table("UserGroup")]
    public class UserGroup
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }

        public Group Group{ get; set; }
        public User User{ get; set; }
    }
}
