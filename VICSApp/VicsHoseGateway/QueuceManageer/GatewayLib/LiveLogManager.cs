namespace GatewayLib
{
    using GatewayLib.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class LiveLogManager
    {
        private static bool _broadcastLogIsOn = false;
        private static List<LogMessage> _broadcastLogMessages = new List<LogMessage>();
        private static List<string> _broadcastLogMessagesStr = new List<string>();
        private static int _broadcastLogSize = 50;
        private static bool _ctciLogIsOn = false;
        private static List<LogMessage> _ctciLogMessages = new List<LogMessage>();
        private static List<string> _ctciLogMessagesStr = new List<string>();
        private static int _ctciLogSize = 50;
        private static int _numberOfBroadcastMessages = 0;
        private static int _numberOfReceivedMessages = 0;
        private static int _numberOfSentMessages = 0;
        private static List<object> registeredBroadcastControls = new List<object>();
        private static List<object> registeredCTCIControls = new List<object>();
        private static List<ListBox> registeredGAControls = new List<ListBox>();

        public static void ClearBroadcastLogs()
        {
            _broadcastLogMessages.Clear();
            _broadcastLogMessagesStr.Clear();
        }

        public static void ClearCTCILogs()
        {
            _ctciLogMessages.Clear();
            _ctciLogMessagesStr.Clear();
        }

        private static void ExecuteCallbackMethod(bool ctciOrBroadcast, string messageType, string info, string comments)
        {
            int num = 0;
            ListBox box = null;
            if (ctciOrBroadcast)
            {
                box = (ListBox) registeredCTCIControls[0];
                num = _ctciLogSize;
            }
            else
            {
                box = (ListBox) registeredBroadcastControls[0];
                num = _broadcastLogSize;
            }
            if (box.InvokeRequired)
            {
                CallbackMethod method = new CallbackMethod(LiveLogManager.ExecuteCallbackMethod);
                box.Invoke(method, new object[] { ctciOrBroadcast, messageType, info, comments });
            }
            else
            {
                if (messageType == "GA")
                {
                    int num2 = 0;
                    for (num2 = 0; num2 < registeredGAControls.Count; num2++)
                    {
                        registeredGAControls[num2].Items.Insert(0, comments);
                    }
                }
                box.Items.Insert(0, info);
                if (num < box.Items.Count)
                {
                    box.Items.RemoveAt(box.Items.Count - 1);
                }
                if (ctciOrBroadcast)
                {
                    int num3;
                    Label label = (Label) registeredCTCIControls[1];
                    Label label2 = (Label) registeredCTCIControls[2];
                    if (info.Substring(0, 3) == "-->")
                    {
                        if (label.Text.Trim() == "")
                        {
                            label.Text = "1";
                        }
                        else
                        {
                            num3 = int.Parse(label.Text.Trim()) + 1;
                            label.Text = num3.ToString();
                        }
                    }
                    else if (info.Substring(0, 3) == "<--")
                    {
                        if (label2.Text.Trim() == "")
                        {
                            label2.Text = "1";
                        }
                        else
                        {
                            num3 = int.Parse(label2.Text.Trim()) + 1;
                            label2.Text = num3.ToString();
                        }
                    }
                }
                else
                {
                    Label label3 = (Label) registeredBroadcastControls[1];
                    if (label3.Text.Trim() == "")
                    {
                        label3.Text = "1";
                    }
                    else
                    {
                        label3.Text = (int.Parse(label3.Text.Trim()) + 1).ToString();
                    }
                }
            }
        }

        public static List<LogMessage> GetAllBroadcastLogMessages()
        {
            return _broadcastLogMessages;
        }

        public static List<LogMessage> GetAllCTCILogMessages()
        {
            return _ctciLogMessages;
        }

        public static LogMessage GetBroadcastLogMessage(int index)
        {
            try
            {
                if (_broadcastLogMessages.Count > 0)
                {
                    return _broadcastLogMessages[index];
                }
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        public static List<string> GetBroadcastLogMessageStr()
        {
            return _broadcastLogMessagesStr;
        }

        public static LogMessage GetCTCILogMessage(int index)
        {
            if (_ctciLogMessages.Count > 0)
            {
                return _ctciLogMessages[index];
            }
            return null;
        }

        public static List<string> GetCTCILogMessageStr()
        {
            return _ctciLogMessagesStr;
        }

        public static bool LiveLogIsOn()
        {
            return (_ctciLogIsOn || _broadcastLogIsOn);
        }

        public static void LogThisMessage(string messageType, bool sentOrReceived, object message)
        {
            if (_ctciLogIsOn || _broadcastLogIsOn)
            {
                string str;
                HOSE_GA hose_ga;
                bool flag = true;
                List<LogMessage> list = null;
                List<string> source = null;
                switch (messageType)
                {
                    case "AA":
                    case "BR":
                    case "BS":
                    case "CO":
                    case "DC":
                    case "GA":
                    case "IU":
                    case "LO":
                    case "LS":
                    case "NH":
                    case "NS":
                    case "OL":
                    case "OS":
                    case "PD":
                    case "PO":
                    case "SC":
                    case "SI":
                    case "SR":
                    case "SS":
                    case "SU":
                    case "TC":
                    case "TP":
                    case "TR":
                    case "TS":
                        _numberOfBroadcastMessages++;
                        flag = false;
                        list = _broadcastLogMessages;
                        source = _broadcastLogMessagesStr;
                        break;

                    default:
                        if (sentOrReceived)
                        {
                            _numberOfSentMessages++;
                        }
                        else
                        {
                            _numberOfReceivedMessages++;
                        }
                        list = _ctciLogMessages;
                        source = _ctciLogMessagesStr;
                        break;
                }
                int num = _ctciLogSize;
                if (!flag)
                {
                    if (!_broadcastLogIsOn)
                    {
                        return;
                    }
                    num = _broadcastLogSize;
                }
                else if (!_ctciLogIsOn)
                {
                    return;
                }
                LogMessage item = new LogMessage();
                item.Date = DateTime.Now;
                item.MessageContent = message;
                item.MessageType = messageType;
                item.SentOrReceived = sentOrReceived;
                list.Insert(0, item);
                if (list.Count < num)
                {
                    str = sentOrReceived ? "-->" : "<--";
                    source.Insert(0, str + "[" + item.Date.ToString("yyyy-MM-dd HH:mm:ss") + "]:MessageType=" + item.MessageType);
                }
                else
                {
                    list.RemoveAt(list.Count - 1);
                    str = sentOrReceived ? "-->" : "<--";
                    source.Insert(0, str + "[" + item.Date.ToString("yyyy-MM-dd HH:mm:ss") + "]:MessageType=" + item.MessageType);
                    source.RemoveAt(Enumerable.Count<string>(source) - 1);
                }
                if (flag)
                {
                    if (messageType.Equals("GA"))
                    {
                        hose_ga = message as HOSE_GA;
                        ExecuteCallbackMethod(true, messageType, source[0], "[" + hose_ga.LAST_MODIFIED.ToString("HH:mm:ss") + "] " + hose_ga.ADMIN_MESSAGE_TEXT);
                    }
                    else
                    {
                        ExecuteCallbackMethod(true, messageType, source[0], "");
                    }
                }
                else if (messageType.Equals("GA"))
                {
                    hose_ga = message as HOSE_GA;
                    ExecuteCallbackMethod(false, messageType, source[0], "[" + hose_ga.LAST_MODIFIED.ToString("HH:mm:ss") + "] " + hose_ga.ADMIN_MESSAGE_TEXT);
                }
                else
                {
                    ExecuteCallbackMethod(false, messageType, source[0], "");
                }
            }
        }

        public static int NumberOfBroadcastMessages()
        {
            return _numberOfBroadcastMessages;
        }

        public static int NumberOfReceivedMessages()
        {
            return _numberOfReceivedMessages;
        }

        public static int NumberOfSentMessages()
        {
            return _numberOfSentMessages;
        }

        public static void RegisterCallbackControl(bool ctciOrBroadcast, object control)
        {
            if (ctciOrBroadcast)
            {
                registeredCTCIControls.Add(control);
            }
            else
            {
                registeredBroadcastControls.Add(control);
            }
        }

        public static void RegisterGACallbackControl(ListBox listbox)
        {
            registeredGAControls.Add(listbox);
        }

        public static void SetBroadcastLogSize(int logSize)
        {
            _broadcastLogSize = logSize;
        }

        public static void SetCTCILogSize(int logSize)
        {
            _ctciLogSize = logSize;
        }

        public static void TurnOffBroadcastLog()
        {
            _broadcastLogIsOn = false;
        }

        public static void TurnOffCTCILog()
        {
            _ctciLogIsOn = false;
        }

        public static void TurnOffLiveLog()
        {
            _ctciLogIsOn = false;
            _broadcastLogIsOn = false;
        }

        public static void TurnOnBroadcastLog()
        {
            _broadcastLogIsOn = true;
        }

        public static void TurnOnCTCILog()
        {
            _ctciLogIsOn = true;
        }

        public static void TurnOnLiveLog()
        {
            _ctciLogIsOn = true;
            _broadcastLogIsOn = true;
        }

        public static void UnRegisterCallbackControls(bool ctciOrBroadcast)
        {
            if (ctciOrBroadcast)
            {
                registeredCTCIControls.Clear();
            }
            else
            {
                registeredBroadcastControls.Clear();
            }
        }

        private delegate void CallbackMethod(bool ctciOrBroadcast, string messageType, string info, string comments);
    }
}

