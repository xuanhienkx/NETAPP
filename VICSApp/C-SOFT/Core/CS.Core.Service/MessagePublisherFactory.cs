using CS.Common;
using CS.Common.Domain.Interfaces;
using CS.Common.Enums;
using CS.Common.MessageQueue;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Core.Service
{
    public interface IMessagePublisherFactory
    {
        Task<bool> Publish<T>(Message<T> message, IList<MessageQueueType> messageInformTypes);
    }

    public class MessagePublisherFactory : IMessagePublisherFactory
    {
        private readonly IDomainDataHandler domainDataHandler;
        private readonly ILogger<MessagePublisherFactory> logger;
        private readonly IEnumerable<IMessagePublisher> publishers;

        public MessagePublisherFactory(IEnumerable<IMessagePublisher> publishers, IDomainDataHandler domainDataHandler, ILogger<MessagePublisherFactory> logger)
        {
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.publishers = publishers ?? throw new ArgumentNullException(nameof(publishers));
        }

        public async Task<bool> Publish<T>(Message<T> message, IList<MessageQueueType> messageInformTypes)
        {
            foreach (var messageInformType in messageInformTypes)
            {
                var publisher = publishers.SingleOrDefault(x => x.CanPublish(messageInformType));
                if (publisher != null)
                {
                    message.MessageType = messageInformType;
                    if (!await PublishMessage(publisher, message))
                        return false;
                }
            }
            return true;
        }

        private async Task<bool> PublishMessage<T>(IMessagePublisher publisher, Message<T> message)
        {
            var messageQueue = new CS.Domain.Audit.Entities.MessageQueue()
            {
                Type = message.MessageType,
                ClrType = message.Model.GetType().AssemblyQualifiedName,
                Content = message.GetMessageBody(),
                CreateDate = message.CreatedDate
            };

            return await publisher.Publish(message, async m =>
             { 
                 logger.LogDebug("Publish message successfull");
                 messageQueue.PublishedDate = DateTime.UtcNow;

                 // log the message queue
                 logger.LogDebug("Set auditing the message");
                 await domainDataHandler.SendCommand(new AuditEventCommand(messageQueue));

             }, (m, exception) =>
             {
                 logger.LogDebug("Publish message failed");
                 domainDataHandler.RaiseError(exception.Message);
             });
        }
    }
}
