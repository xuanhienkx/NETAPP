using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class BranchSettingModel : DataContract
    {
        [ProtoMember(1)]
        public long BranchId { get; set; }
        [ProtoMember(2)]
        public string Key { get; set; }
        [ProtoMember(3)]
        public string Value { get; set; }
    }
}
