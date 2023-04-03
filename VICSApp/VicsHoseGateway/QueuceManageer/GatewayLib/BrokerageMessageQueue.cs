namespace GatewayLib
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Messaging;
    using System.Text;

    public class BrokerageMessageQueue
    {
        private static MessageQueue badQueue = null;
        private static MessageQueue inboxQueue = null;
        private static MessageQueue internalQueue = null;
        private static MessageQueue outboxQueue = null;

        public static int ClearQueue(string queueName)
        {
            try
            {
                if ((((GetOutboxQueue() == null) || (GetInboxQueue() == null)) || (GetInternalQueue() == null)) || (GetBadQueue() == null))
                {
                    return -1;
                }
                if (queueName == "ALL")
                {
                    inboxQueue.Purge();
                    outboxQueue.Purge();
                    internalQueue.Purge();
                    badQueue.Purge();
                    return 1;
                }
                if (queueName == "InboxQueue")
                {
                    inboxQueue.Purge();
                    return 1;
                }
                if (queueName == "OutboxQueue")
                {
                    outboxQueue.Purge();
                    return 1;
                }
                if (queueName == "InternalQueue")
                {
                    internalQueue.Purge();
                    return 1;
                }
                if (queueName == "BadQueue")
                {
                    badQueue.Purge();
                    return 1;
                }
            }
            catch (MessageQueueException exception)
            {
                GatewayLogManager.Error("Error while clearing queue, Messagae=" + exception.Message);
                return 0;
            }
            return 1;
        }

        public static bool ExistsInInternalQueue(string messageLabel)
        {
            List<string> list = new List<string>();
            if (GetInternalQueue() != null)
            {
                MessageEnumerator enumerator = internalQueue.GetMessageEnumerator2();
                while (enumerator.MoveNext())
                {
                    try
                    {
                        if (enumerator.Current.Label == messageLabel)
                        {
                            return true;
                        }
                    }
                    catch (MessageQueueException exception)
                    {
                        GatewayLogManager.Error("Error:" + exception.Message);
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool ExistsInOutbox(string messageLabel)
        {
            List<string> list = new List<string>();
            if (GetOutboxQueue() != null)
            {
                MessageEnumerator enumerator = outboxQueue.GetMessageEnumerator2();
                while (enumerator.MoveNext())
                {
                    try
                    {
                        if (enumerator.Current.Label == messageLabel)
                        {
                            return true;
                        }
                    }
                    catch (MessageQueueException exception)
                    {
                        GatewayLogManager.Error("Error:" + exception.Message);
                        return false;
                    }
                    catch (Exception exception2)
                    {
                        GatewayLogManager.Error("Error:" + exception2.Message);
                        return false;
                    }
                }
            }
            return false;
        }

        public static List<BadMessage> GetBadMessages()
        {
            if (GetBadQueue() == null)
            {
                return null;
            }
            List<BadMessage> list = new List<BadMessage>();
            Message current = null;
            BadMessage item = null;
            MessageEnumerator enumerator = badQueue.GetMessageEnumerator2();
            while (enumerator.MoveNext())
            {
                try
                {
                    current = enumerator.Current;
                    item = new BadMessage();
                    item.ID = current.Id;
                    item.Label = current.Label;
                    byte[] bytes = MessageConverter.GetBytes(current);
                    item.Content = MessageConverter.ConvertRawFormatToMessage(bytes);
                    list.Add(item);
                }
                catch (MessageQueueException exception)
                {
                    GatewayLogManager.Error("Error:" + exception.Message);
                    return null;
                }
            }
            return list;
        }

        public static MessageQueue GetBadQueue()
        {
            try
            {
                if (badQueue == null)
                {
                    string path = ConfigurationSettings.AppSettings["BadQueue"];
                    if (MessageQueue.Exists(path))
                    {
                        badQueue = new MessageQueue(path);
                    }
                    else
                    {
                        badQueue = MessageQueue.Create(path);
                    }
                }
                return badQueue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static MessageQueue GetBadQueue(ref string errorCode)
        {
            try
            {
                if (badQueue == null)
                {
                    string path = ConfigurationSettings.AppSettings["BadQueue"];
                    if (MessageQueue.Exists(path))
                    {
                        badQueue = new MessageQueue(path);
                    }
                    else
                    {
                        badQueue = MessageQueue.Create(path);
                    }
                }
                errorCode = string.Empty;
                return badQueue;
            }
            catch (Exception exception)
            {
                errorCode = exception.Message;
                return null;
            }
        }

        public static MessageQueue GetInboxQueue()
        {
            try
            {
                if (inboxQueue == null)
                {
                    string path = ConfigurationSettings.AppSettings["InboxQueue"];
                    if (MessageQueue.Exists(path))
                    {
                        inboxQueue = new MessageQueue(path);
                    }
                    else
                    {
                        inboxQueue = MessageQueue.Create(path);
                    }
                }
                return inboxQueue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static MessageQueue GetInboxQueue(ref string errorCode)
        {
            try
            {
                if (inboxQueue == null)
                {
                    string path = ConfigurationSettings.AppSettings["InboxQueue"];
                    if (MessageQueue.Exists(path))
                    {
                        inboxQueue = new MessageQueue(path);
                    }
                    else
                    {
                        inboxQueue = MessageQueue.Create(path);
                    }
                }
                errorCode = string.Empty;
                return inboxQueue;
            }
            catch (Exception exception)
            {
                errorCode = exception.Message;
                return null;
            }
        }

        public static MessageQueue GetInternalQueue()
        {
            try
            {
                if (internalQueue == null)
                {
                    string path = ConfigurationSettings.AppSettings["InternalQueue"];
                    if (MessageQueue.Exists(path))
                    {
                        internalQueue = new MessageQueue(path);
                    }
                    else
                    {
                        internalQueue = MessageQueue.Create(path);
                    }
                }
                return internalQueue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static MessageQueue GetInternalQueue(ref string errorCode)
        {
            try
            {
                if (internalQueue == null)
                {
                    string path = ConfigurationSettings.AppSettings["InternalQueue"];
                    if (MessageQueue.Exists(path))
                    {
                        internalQueue = new MessageQueue(path);
                    }
                    else
                    {
                        internalQueue = MessageQueue.Create(path);
                    }
                }
                errorCode = string.Empty;
                return internalQueue;
            }
            catch (Exception exception)
            {
                errorCode = exception.Message;
                return null;
            }
        }

        public static MessageQueue GetOutboxQueue()
        {
            try
            {
                if (outboxQueue == null)
                {
                    string path = ConfigurationSettings.AppSettings["OutboxQueue"];
                    if (MessageQueue.Exists(path))
                    {
                        outboxQueue = new MessageQueue(path);
                    }
                    else
                    {
                        outboxQueue = MessageQueue.Create(path);
                    }
                }
                return outboxQueue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static MessageQueue GetOutboxQueue(ref string errorCode)
        {
            try
            {
                if (outboxQueue == null)
                {
                    string path = ConfigurationSettings.AppSettings["OutboxQueue"];
                    if (MessageQueue.Exists(path))
                    {
                        outboxQueue = new MessageQueue(path);
                    }
                    else
                    {
                        outboxQueue = MessageQueue.Create(path);
                    }
                }
                errorCode = string.Empty;
                return outboxQueue;
            }
            catch (Exception exception)
            {
                errorCode = exception.Message;
                return null;
            }
        }

        private static string GetSendableMesssages()
        {
            string str = string.Empty;
            switch (MarketInfo.GetCurrentStatus())
            {
                case " ":
                case "I":
                case "J":
                case "H":
                    return string.Empty;

                case "C":
                    return "Except:1I,1C,1D";

                case "K":
                    return "3A";

                case null:
                    return str;
            }
            return "ALL";
        }

        private static void internalQueue_PeekCompleted(object sender, PeekCompletedEventArgs e)
        {
            IAsyncResult result;
            if (GetSendableMesssages().Equals(string.Empty))
            {
                result = ((MessageQueue) e.AsyncResult.AsyncState).BeginPeek(new TimeSpan(1, 0, 0), (MessageQueue) e.AsyncResult.AsyncState);
            }
            else
            {
                result = ((MessageQueue) e.AsyncResult.AsyncState).BeginReceive(new TimeSpan(1, 0, 0), (MessageQueue) e.AsyncResult.AsyncState);
            }
        }

        private static void internalQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            IAsyncResult result;
            string sendableMesssages = GetSendableMesssages();
            try
            {
                Message message = ((MessageQueue) e.AsyncResult.AsyncState).EndReceive(e.AsyncResult);
                if (sendableMesssages != string.Empty)
                {
                    string messageType = Util.GetMessageType(message);
                    if (sendableMesssages == "ALL")
                    {
                        LiveLogManager.LogThisMessage(messageType, true, MessageConverter.ConvertMSMQMessageToHOSEMessage(message));
                        outboxQueue.Send(message, message.Label);
                        MessageController.NumberOfSentMessage++;
                    }
                    else if (sendableMesssages.IndexOf("Except:") > -1)
                    {
                        if (sendableMesssages.IndexOf(messageType) > -1)
                        {
                            SaveMessageToInternalQueue(message);
                        }
                        else
                        {
                            LiveLogManager.LogThisMessage(messageType, true, MessageConverter.ConvertMSMQMessageToHOSEMessage(message));
                            outboxQueue.Send(message, message.Label);
                            MessageController.NumberOfSentMessage++;
                        }
                    }
                    else if (sendableMesssages.IndexOf(messageType) > -1)
                    {
                        LiveLogManager.LogThisMessage(messageType, true, MessageConverter.ConvertMSMQMessageToHOSEMessage(message));
                        outboxQueue.Send(message, message.Label);
                        MessageController.NumberOfSentMessage++;
                    }
                }
                else
                {
                    SaveMessageToInternalQueue(message);
                }
            }
            catch (MessageQueueException exception)
            {
                if (exception.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                {
                    GatewayLogManager.Error("Found no message(s) in Internal Queue during 1 hour");
                }
                else
                {
                    GatewayLogManager.Error(string.Concat(new object[] { "Error while receiving messages from Internal Queue, ErrorCode=", exception.ErrorCode, ", Detail:", exception.Message }));
                }
            }
            if (sendableMesssages.Equals(string.Empty))
            {
                result = ((MessageQueue) e.AsyncResult.AsyncState).BeginPeek(new TimeSpan(1, 0, 0), (MessageQueue) e.AsyncResult.AsyncState);
            }
            else
            {
                result = ((MessageQueue) e.AsyncResult.AsyncState).BeginReceive(new TimeSpan(1, 0, 0), (MessageQueue) e.AsyncResult.AsyncState);
            }
        }

        public static string MessageQueueIsReady()
        {
            string errorCode = string.Empty;
            if (GetInboxQueue(ref errorCode) == null)
            {
                if (!errorCode.Equals(string.Empty))
                {
                    return errorCode;
                }
                return "Kh\x00f4ng khởi tạo được InboxQueue";
            }
            if (GetOutboxQueue(ref errorCode) == null)
            {
                if (!string.IsNullOrEmpty(errorCode))
                {
                    return errorCode;
                }
                return "Kh\x00f4ng khởi tạo được OutboxQueue";
            }
            if (GetInternalQueue(ref errorCode) == null)
            {
                if (!string.IsNullOrEmpty(errorCode))
                {
                    return errorCode;
                }
                return "Kh\x00f4ng khởi tạo được InternalQueue";
            }
            if (GetBadQueue(ref errorCode) == null)
            {
                if (!string.IsNullOrEmpty(errorCode))
                {
                    return errorCode;
                }
                return "Kh\x00f4ng khởi tạo được BadQueue";
            }
            return string.Empty;
        }

        public static void RemoveBadMessage(string id)
        {
            if (GetBadQueue() != null)
            {
                badQueue.ReceiveById(id);
            }
        }

        public static void SaveBadMessage(Message msg, string label)
        {
            try
            {
                if (GetBadQueue() != null)
                {
                    badQueue.Send(msg, label);
                }
            }
            catch (Exception exception)
            {
                GatewayLogManager.Error("Error while saving message to inbox queue, Lable=" + label + ", Error Detail:" + exception.Message);
            }
        }

        public static void SaveBadMessage(object standardMessage, string label)
        {
            try
            {
                if (GetBadQueue() != null)
                {
                    Message message = new Message();
                    byte[] bytes = MessageConverter.ConvertMessageToRawFormat(standardMessage);
                    char[] chars = Encoding.ASCII.GetChars(bytes);
                    byte[] buffer = Encoding.Unicode.GetBytes(chars);
                    message.BodyStream.Write(buffer, 0, buffer.Length);
                    message.BodyType = 8;
                    badQueue.Send(message, label);
                    GatewayLogManager.Debug("send message to bad queue, Label:" + label);
                }
            }
            catch (Exception exception)
            {
                GatewayLogManager.Error("Error while sending message to queue, Lable=" + label + ", Error Detail:" + exception.Message);
            }
        }

        public static void SaveMessageToInbox(Message msg)
        {
            if (GetInboxQueue() != null)
            {
                inboxQueue.Send(msg);
            }
        }

        public static void SaveMessageToInbox(object standardMessage, string label)
        {
            try
            {
                if (GetInboxQueue() != null)
                {
                    Message message = new Message();
                    byte[] bytes = MessageConverter.ConvertMessageToRawFormat(standardMessage);
                    char[] chars = Encoding.ASCII.GetChars(bytes);
                    byte[] buffer = Encoding.Unicode.GetBytes(chars);
                    message.BodyStream.Write(buffer, 0, buffer.Length);
                    message.BodyType = 8;
                    inboxQueue.Send(message, label);
                }
            }
            catch (Exception exception)
            {
                GatewayLogManager.Error("Error while saving message to inbox queue, Lable=" + label + ", Error Detail:" + exception.Message);
            }
        }

        public static void SaveMessageToInternalQueue(Message msg)
        {
            try
            {
                if (GetInternalQueue() == null)
                {
                }
            }
            catch (Exception exception)
            {
                GatewayLogManager.Error("Error while saving message to inbox queue, Error Detail:" + exception.Message);
            }
        }

        public static void SaveMessageToInternalQueue(object standardMessage, string label)
        {
            try
            {
                if (GetInternalQueue() != null)
                {
                    Message message = new Message();
                    byte[] bytes = MessageConverter.ConvertMessageToRawFormat(standardMessage);
                    char[] chars = Encoding.ASCII.GetChars(bytes);
                    byte[] buffer = Encoding.Unicode.GetBytes(chars);
                    message.BodyStream.Write(buffer, 0, buffer.Length);
                    message.BodyType = 8;
                    internalQueue.Send(message, label);
                }
            }
            catch (Exception exception)
            {
                GatewayLogManager.Error("Error while saving message to inbox queue, Label=" + label + ", Error Detail:" + exception.Message);
            }
        }

        public static void SendMessage(object standardMessage, string label)
        {
            try
            {
                if (GetOutboxQueue() != null)
                {
                    Message message = new Message();
                    byte[] bytes = MessageConverter.ConvertMessageToRawFormat(standardMessage);
                    char[] chars = Encoding.ASCII.GetChars(bytes);
                    byte[] buffer = Encoding.Unicode.GetBytes(chars);
                    message.BodyStream.Write(buffer, 0, buffer.Length);
                    message.BodyType = 8;
                    outboxQueue.Send(message, label);
                    GatewayLogManager.Debug("send message to queue, Label:" + label);
                }
            }
            catch (Exception exception)
            {
                GatewayLogManager.Error("Error while sending message to queue, Lable=" + label + ", Error Detail:" + exception.Message);
            }
        }

        public static void StartSendMessagesToOutbox()
        {
            if (GetOutboxQueue() != null)
            {
                IAsyncResult result;
                MessageQueue internalQueue = GetInternalQueue();
                internalQueue.PeekCompleted += new PeekCompletedEventHandler(BrokerageMessageQueue.internalQueue_PeekCompleted);
                internalQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(BrokerageMessageQueue.internalQueue_ReceiveCompleted);
                if (GetSendableMesssages().Equals(string.Empty))
                {
                    result = internalQueue.BeginPeek(new TimeSpan(1, 0, 0), internalQueue);
                }
                else
                {
                    result = internalQueue.BeginReceive(new TimeSpan(1, 0, 0), internalQueue);
                }
            }
        }

        public static void StopSendMessagesToOutbox()
        {
            GetInternalQueue().ReceiveCompleted -= new ReceiveCompletedEventHandler(BrokerageMessageQueue.internalQueue_ReceiveCompleted);
        }
    }
}

