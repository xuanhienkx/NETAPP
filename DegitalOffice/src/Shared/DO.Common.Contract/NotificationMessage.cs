using ProtoBuf;

namespace DO.Common.Contract
{
    public enum NotificationType
    {
        Alert,
        Error,
        Inform,
        Drilldown,
        Content
    }

    [ProtoContract]
    public class NotificationMessage
    {
        [ProtoMember(1)]
        public NotificationType Type { get; set; }
        [ProtoMember(2)]
        public string Content { get; set; }
        [ProtoMember(3)]
        public string RequestId { get; set; }

        public string Icon => GetIcon(Type);
        public string Foreground => GetColor(Type);

        private string GetColor(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Alert:
                    return "Yellow";
                case NotificationType.Error:
                    return "Red";
                default:
                    return "Blue";
            }
        }

        private static string GetIcon(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Alert:
                    return "AlertCircleOutline";
                case NotificationType.Error:
                    return "AlertOutline";
                default:
                    return "InformationOutline";
            }
        }
    }
}
