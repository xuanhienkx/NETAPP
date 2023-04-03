using DSoft.Common.Models;
using MediatR;

namespace DSoft.Common.Events;

public enum SessionState
{
    Start,
    End,
    Error
}

public class ClientSessionEvent : INotification
{
    public string RequestPath { get; }
    public SessionState State { get; }

    public ClientSessionEvent(string requestPath, SessionState state)
    {
        RequestPath = requestPath;
        State = state;
    }
}
public class MarketInfoEvent : INotification
{
    public string HfId { get; }
    public MarketInfo MarketInfo { get; }
    public string UserId { get; }

    public MarketInfoEvent(string hfId, MarketInfo marketInfo, string userId)
    {
        HfId = hfId;
        MarketInfo = marketInfo;
        UserId = userId;
    }
}
