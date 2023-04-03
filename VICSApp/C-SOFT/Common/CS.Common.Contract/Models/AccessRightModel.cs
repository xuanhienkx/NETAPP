using System.Collections.Generic;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class AccessRightModel : DataContract
    {
        [ProtoMember(1)]
        public AccessRight Name { get; set; }
        [ProtoMember(2)]
        public IList<PermissionModel> Permissions { get; set; }
        // public AccessRightType AccessType { get; set; }
    }

    public class  PermissionBind
    {
        public AccessRight AccessPermission { get; set; }
        public GroupModel Group { get; set; }
        public IList<PermissionModel> AccessTypes { get; set; }
    }

    public class AccessRightBind
    {
        public bool IsSelected { get; set; }
        public AccessType AccessType { get; set; }
    }
}
