namespace DSoft.Common.Shared.Interfaces;

public interface IWebSocketService
{
    Task SendHangfire(string userId, string hfId, string message);
    Task SendHangfire(string hfId, string message);
}