using MediatR;

namespace BO.Core.DataCommon.Events
{
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
}