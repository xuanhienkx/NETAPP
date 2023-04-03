using ProtoBuf;

namespace DO.Common.Domain
{
    [ProtoContract]
    public class NotificationContext
    {
        public NotificationContext()
        {
            Data = new Dictionary<string, string>();
        }

        public NotificationContext(Guid userId, string connectionId)
            : this()
        {
            UserId = userId;
            ConnectionId = connectionId;
        }

        [ProtoMember(1)]
        public IDictionary<string, string> Data { get; }
        [ProtoMember(2)]
        public Guid UserId { get; set; }
        [ProtoMember(3)]
        public string ConnectionId { get; set; }
        public string RequestedId { get; set; }
    }
}