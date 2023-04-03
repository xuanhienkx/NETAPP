using CS.Common.Enums;
using CS.Common.MessageQueue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using CS.Common.Std;

namespace CS.VSD.Service
{
    public class VsdMessagePublisher : IMessagePublisher
    {
        private readonly IEnumerable<IBusinessActionHandler> messageActionHandlers;
        private readonly ILogger<VsdMessagePublisher> logger;
        private readonly IConfigurationRoot configuration;

        public VsdMessagePublisher(IConfigurationRoot configuration, IEnumerable<IBusinessActionHandler> messageActionHandlers, ILogger<VsdMessagePublisher> logger)
        {
            this.messageActionHandlers = messageActionHandlers ?? throw new ArgumentNullException(nameof(messageActionHandlers));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public bool CanPublish(MessageQueueType messageType) => messageType == MessageQueueType.VsdPublisedMessage;

        public async Task<bool> Publish<T>(Message<T> message, Action<Message<T>> onPublished, Action<Message<T>, Exception> onFailed)
        {
            if (!CanPublish(message.MessageType))
            {
                logger.LogDebug("Cannot handle the message type {0}", message.MessageType);
                return false;
            }

            var actionHandler = messageActionHandlers.FirstOrDefault(x => message.RequestId == x.BussinessId);
            if (actionHandler == null)
            {
                logger.LogError("Cannot handle the message request id {0}", message.RequestId);
                return false;
            }

            logger.LogDebug("{0} starts to handle the request", actionHandler.BussinessId);
            var bag = await actionHandler.PrepareBagToBuildMessage(message.Model);

            bag[BusinessIdProviderConstant.BusinessId] = message.RequestId;
            foreach (var item in message.ExtendData)
                bag[item.Key] = item.Value;

            var messageBody = JsonConvert.SerializeObject(bag);

            // publish the message
            if (TryRequest(message.Command, messageBody))
            {
                onPublished(message);
                return true;
            }
            else
            {
                onFailed(message, new CommunicationException("Cannot communicate to the VSD gateway"));
                return false;
            }
        }

        private bool TryRequest(string command, string message)
        {
            var connectionUrl = configuration["endpoints:vsdGateway:endpointUrl"];
            if (!long.TryParse(configuration["endpoints:vsdGateway:timeoutInMilliseconds"], out long timeout))
                timeout = 1000;

            logger.LogDebug("Publishing to server {0}. Message: {1} - {2}", connectionUrl, command, message);

            using (var publisher = new RequestSocket())
            {
                publisher.Connect(connectionUrl);

                var signal = false;
                
                publisher.SendMoreFrame(command).SendFrame(message);
                publisher.ReceiveReady += (sender, args) =>
                {
                    signal = args.Socket.ReceiveSignal();
                    logger.LogDebug("Server replied SIGNAL ({0})", signal);
                };
                var pollResult = publisher.Poll(TimeSpan.FromMilliseconds(timeout));
                publisher.Disconnect(connectionUrl);
                return pollResult && signal;
            }
        }
    }
}
