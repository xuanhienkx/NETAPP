using MediatR;

namespace DSoft.Common.Shared.Interfaces
{
    public interface IDomainDataHandler
    {

        Task StartTransaction(string requestPath);
        void Commit(string requestPath);
        void Rollback(string requestPath);
        void RaiseError(string errorMessage, string notifierKey = null);
        bool HasError(out IList<string> errorMessages);

        Task<T> SendCommand<T>(IRequest<T> command);
        Task SendCommand(IRequest command);
        Task PublishCommand(INotification command);
        //  UserModel GetUserLogin();

        /// <summary>
        /// Send a notificate message to the current client
        /// </summary>
        /// <param name="message"></param>
        void SendNotification(string message);
        /// <summary>
        /// Broadcast the message to all connected client
        /// </summary>
        /// <param name="message"></param>
        void Broadcast(string message);
    }
}
