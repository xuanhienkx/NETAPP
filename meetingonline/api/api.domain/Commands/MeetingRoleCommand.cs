using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;

namespace api.domain.Commands
{
    public abstract class MeetingRoleCommandBase : BaseCommand<MeetingRole>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public List<string> Permissions { get; set; }
    }

    public class MeetingRoleCreateCommand : MeetingRoleCommandBase
    {
        public MeetingType MeetingType { get; set; }
    }

    public class MeetingRoleUpdateCommand : MeetingRoleCommandBase
    {
        [Required]
        public string Id { get; set; }
    }

    
}
