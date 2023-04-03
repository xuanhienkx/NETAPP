namespace BO.Core.DataCommon.Shared.Interfaces
{
    public interface IWebSocketService
    {
        Task SendHangfire(string userId, string hfId, string message);
    }
}
