using System;
using System.Collections.Generic;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract] 
    public class PermissionAccess
    {
        public PermissionAccess()
        {  }

        public PermissionAccess(AccessRight right, AccessType type = AccessType.Allow)
        {
            Name = right;
            Type = type;
        }

        [ProtoMember(1)] public AccessRight Name { get; set; }
        [ProtoMember(2)] public AccessType Type { get; set; }
    }

    [ProtoContract] 
    public class PermissionModel : DataContract
    {
        [ProtoMember(1)]
        public GroupModel Group { get; set; }
        [ProtoMember(2)]
        public IList<PermissionAccess> Permissions { get; set; }
    }
}