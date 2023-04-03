using api.common.Models;
using api.common.Shared;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using api.common.Shared.Base;

namespace api.domain.Commands
{
    public class MeetingGroupUpdateCommand : BaseCommand<MeetingGroup>
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public MediaResource Logo { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
    }
}