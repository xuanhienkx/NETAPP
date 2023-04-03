using DO.Common.Enums;
using DO.Common.Std.Extensions;

namespace DO.Common.MessageQueue;

public class Message<T>
{
    public Message(string requestId, string command)
    {
        RequestId = requestId;
        Command = command;
        CreatedDate = DateTime.UtcNow;
        ExtendData = new Dictionary<string, object>();
    }

    public string RequestId { get; }
    public string Command { get; }
    public MessageQueueType MessageType { get; set; }
    public T Model { get; set; }
    public string ModelClrType { get; set; }
    public IDictionary<string, object> ExtendData { get; }

    public DateTime CreatedDate { get; }
    private string messageBody;

    public string GetMessageBody()
    {
        if (string.IsNullOrEmpty(messageBody))
            messageBody = Model.Base64ProtoBufSerialize();
        return messageBody;
    }
}
