using CS.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VSDGateway
{
    public class MessageSubscriberTask : ITargetTask
    {
        private readonly IGatewayService gatewayService;
        private readonly ILogger<MessageSubscriberTask> logger;
        private readonly string bindingAddress;

        private NetMQPoller poller;
        private ResponseSocket pullSocket;

        public MessageSubscriberTask(IGatewayService gatewayService, IConfigurationRoot configuration, ILogger<MessageSubscriberTask> logger)
        {
            this.gatewayService = gatewayService ?? throw new ArgumentNullException(nameof(gatewayService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            bindingAddress = GetComputerLanIp();
            var portNumber = configuration["gateway:subscriberPortNumber"];
            if (string.IsNullOrEmpty(portNumber))
                portNumber = "8888";

            bindingAddress = $"tcp://{bindingAddress}:{portNumber}";
            ConsoleHelper.WriteLine("Binding to {0}", ConsoleColor.DarkYellow, bindingAddress);
        }

        public int Priority => 100;
        public string Name => "Subscriber new message";

        public Task Start(CancellationToken token)
        {
            if (poller != null)
                return Task.CompletedTask;

            if (string.IsNullOrEmpty(bindingAddress))
            {
                logger.LogError("Wrong IP address");
                return Task.CompletedTask;
            }

            CreatePollerPullSocket(token);
            return Task.CompletedTask;
        }

        private void CreatePollerPullSocket(CancellationToken token)
        {
            using (pullSocket = new ResponseSocket(bindingAddress))
            using (poller = new NetMQPoller { pullSocket })
            {
                pullSocket.ReceiveReady += async (s, a) =>
                {
                    var msg = a.Socket.ReceiveMultipartMessage(2);
                    if (msg != null)
                    {
                        var command = msg[0].ConvertToString(Encoding.UTF8);
                        var data = msg[1].ConvertToString(Encoding.UTF8);
                        logger.LogInformation("Message received: {0} - {1}", command, data);
                        if (string.IsNullOrEmpty(command) || string.IsNullOrEmpty(data))
                            a.Socket.SignalError();
                        else
                        {
                            a.Socket.SignalOK();
                            await gatewayService.ProcessRequest(command, data);
                        }
                    }
                };

                poller.Run();
            }
        }

        public bool Stop()
        {
            //do nothing
            logger.LogInformation("Subscriber keeps binding to {0}. The task is not STOPPED in reset mode.", bindingAddress) ;
            return false;
        }

        private static string GetComputerLanIp()
        {
            var strHostName = Dns.GetHostName();
            var ipEntry = Dns.GetHostEntry(strHostName);

            var ipAddress = ipEntry.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            return ipAddress?.ToString();
        }
    }
}
