using ProtoBuf;
using System;

namespace CS.Common.Contract.Models
{
    public enum MemberType
    {
        Group,
        User
    }

    [ProtoContract]
    public class GroupMemberModel
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        public MemberType MemberType { get; set; }

        [ProtoMember(3)]
        public string FullName { get; set; }
        [ProtoMember(4)]
        public string AccountLogin { get; set; }
        [ProtoMember(5)]
        public string Email { get; set; }
    }
}
