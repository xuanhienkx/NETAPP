namespace GatewayLib
{
    using GatewayLib.Data;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Messaging;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;

    public class MessageController
    {
        private static MessageController _instance = new MessageController();
        public static DataTable dHOSE_GAMSGS = new DataTable();
        private static DateTime lastTimeInsertMsgToDB = DateTime.Now;
        private static List<HOGW_2B> ListOf2Bs = new List<HOGW_2B>();
        private static List<HOGW_2C> ListOf2Cs = new List<HOGW_2C>();
        private static List<HOGW_2D> ListOf2Ds = new List<HOGW_2D>();
        private static List<HOGW_2E> ListOf2Es = new List<HOGW_2E>();
        private static List<HOGW_2F> ListOf2Fs = new List<HOGW_2F>();
        private static List<HOGW_2G> ListOf2Gs = new List<HOGW_2G>();
        private static List<HOGW_2I> ListOf2Is = new List<HOGW_2I>();
        private static List<HOGW_2L> ListOf2Ls = new List<HOGW_2L>();
        private static List<HOGW_3A> ListOf3As = new List<HOGW_3A>();
        private static List<HOGW_3B> ListOf3Bs = new List<HOGW_3B>();
        private static List<HOGW_3C> ListOf3Cs = new List<HOGW_3C>();
        private static List<HOGW_3D> ListOf3Ds = new List<HOGW_3D>();
        private static List<HOSE_AA> ListOfAAs = new List<HOSE_AA>();
        private static List<HOSE_BR> ListOfBRs = new List<HOSE_BR>();
        private static List<HOSE_BS> ListOfBSs = new List<HOSE_BS>();
        private static List<HOSE_CO> ListOfCOs = new List<HOSE_CO>();
        private static List<HOSE_DC> ListOfDCs = new List<HOSE_DC>();
        private static List<HOSE_GA> ListOfGAs = new List<HOSE_GA>();
        private static List<HOSE_IU> ListOfIUs = new List<HOSE_IU>();
        private static List<HOSE_LO> ListOfLOs = new List<HOSE_LO>();
        private static List<HOSE_LS> ListOfLSs = new List<HOSE_LS>();
        private static List<HOSE_NH> ListOfNHs = new List<HOSE_NH>();
        private static List<HOSE_NS> ListOfNSs = new List<HOSE_NS>();
        private static List<HOSE_OL> ListOfOLs = new List<HOSE_OL>();
        private static List<HOSE_OS> ListOfOSs = new List<HOSE_OS>();
        private static List<HOSE_PD> ListOfPDs = new List<HOSE_PD>();
        private static List<HOSE_PO> ListOfPOs = new List<HOSE_PO>();
        private static List<HOSE_SC> ListOfSCs = new List<HOSE_SC>();
        private static List<HOSE_SI> ListOfSIs = new List<HOSE_SI>();
        private static List<HOSE_SR> ListOfSRs = new List<HOSE_SR>();
        private static List<HOSE_SS> ListOfSSs = new List<HOSE_SS>();
        private static List<HOSE_SU> ListOfSUs = new List<HOSE_SU>();
        private static List<HOSE_TC> ListOfTCs = new List<HOSE_TC>();
        private static List<HOSE_TP> ListOfTPs = new List<HOSE_TP>();
        private static List<HOSE_TR> ListOfTRs = new List<HOSE_TR>();
        private static List<HOSE_TS> ListOfTSs = new List<HOSE_TS>();
        public static long maxIDOfSent1CMsg = 0L;
        public static long maxIDOfSent1DMsg = 0L;
        public static long maxIDOfSent1EMsg = 0L;
        public static long maxIDOfSent1FMsg = 0L;
        public static long maxIDOfSent1GMsg = 0L;
        public static long maxIDOfSent1IMsg = 0L;
        public static long maxIDOfSent3AMsg = 0L;
        public static long maxIDOfSent3BMsg = 0L;
        public static long maxIDOfSent3CMsg = 0L;
        public static long maxIDOfSent3DMsg = 0L;
        public static long maxIDOfTS = 0L;
        private static int messagesCount = 0;
        public static int NumberOfMsgInsertedToDB = 0;
        public static int NumberOfMsgSentToBadQueue = 0;
        public static int NumberOfReceivedMsgFromQueue = 0;
        public static int NumberOfSentMessage = 0;
        private List<string> sentMessageLabels = null;
        private List<object> sentMessages = null;

        public MessageController()
        {
            this.sentMessages = new List<object>();
            this.sentMessageLabels = new List<string>();
        }

        private static bool CheckOrderDuplicate(object standardMessage, string messageType, out decimal confirmNumber, out decimal dealId)
        { 
            confirmNumber = -1M;
            dealId = -1M;
            GatewayDataContext context = GatewayManager.GetGatewayContext2();
            HOGW_2E msg2E;
            HOGW_2F msg2F;
            HOGW_2I msg2I;
            HOGW_2L msg2L;
            HOGW_3B msg3B;
            HOGW_3C msg3C;
            switch (messageType)
            {
                case "2E":
                {
                    msg2E = (HOGW_2E) standardMessage;

                    var messages2E = from msg in context.HOGW_2Es
                                     where msg.CONFIRM_NUMBER == msg2E.CONFIRM_NUMBER &&
                                     msg.LAST_MODIFIED.Day == DateTime.Now.Day
                                     select msg;
                    if (!messages2E.Any()) return false;
                    confirmNumber = msg2E.CONFIRM_NUMBER;
                    return true;
                }
                case "2F":
                {
                    msg2F = (HOGW_2F) standardMessage;
                     var messages2F = from msg in context.HOGW_2Fs
                                     where msg.CONFIRM_NUMBER == msg2F.CONFIRM_NUMBER &&
                                     msg.LAST_MODIFIED.Day == DateTime.Now.Day
                                     select msg;
                    if (messages2F.Any())
                    {
                        confirmNumber = msg2F.CONFIRM_NUMBER;
                        return true;
                    }
                    return false;
                }
                case "2I":
                {
                    msg2I = (HOGW_2I) standardMessage;

                    var messages2I = from msg in context.HOGW_2Is
                                     where msg.CONFIRM_NUMBER == msg2I.CONFIRM_NUMBER &&
                                     msg.LAST_MODIFIED.Day == DateTime.Now.Day
                                     select msg;
                    if (!messages2I.Any()) return false;
                    confirmNumber = msg2I.CONFIRM_NUMBER;
                    return true;
                }
                case "2L":
                {
                    msg2L = (HOGW_2L) standardMessage;
                    var messages2L = from msg in context.HOGW_2Ls
                                     where msg.CONFIRM_NUMBER == msg2L.CONFIRM_NUMBER &&
                                     msg.LAST_MODIFIED.Day == DateTime.Now.Day
                                     select msg;
                    if (!messages2L.Any()) return false;
                    confirmNumber = msg2L.CONFIRM_NUMBER;
                    return true;
                }
                case "3B":
                {
                    msg3B = (HOGW_3B) standardMessage;
                    var messages3B = from msg in context.HOGW_3Bs
                                     where msg.DEAL_ID == msg3B.DEAL_ID &&
                                     msg.LAST_MODIFIED.Day == DateTime.Now.Day
                                     select msg;
                    if (!messages3B.Any()) return false;
                    dealId = msg3B.DEAL_ID.Value;
                    return true;
                }
                case "3C":
                {
                    msg3C = (HOGW_3C) standardMessage;
                    var messages3C = from msg in context.HOGW_3Cs
                                     where msg.CONFIRM_NUMBER == msg3C.CONFIRM_NUMBER &&
                                     msg.LAST_MODIFIED.Day == DateTime.Now.Day
                                     select msg;
                    if (!messages3C.Any()) return false;
                    confirmNumber = msg3C.CONFIRM_NUMBER.Value;
                    return true;
                }
                case "3D":
                    return false;

                case "DC":
                    return false;

                case "LO":
                    return false;

                case "LS":
                    return false;

                case "PD":
                    return false;
            }
            return false;
        }

        private static void ClearMessagesList()
        {
            ListOf2Bs.Clear();
            ListOf2Cs.Clear();
            ListOf2Ds.Clear();
            ListOf2Es.Clear();
            ListOf2Fs.Clear();
            ListOf2Gs.Clear();
            ListOf2Is.Clear();
            ListOf2Ls.Clear();
            ListOf3As.Clear();
            ListOf3Bs.Clear();
            ListOf3Cs.Clear();
            ListOf3Ds.Clear();
            ListOfAAs.Clear();
            ListOfBRs.Clear();
            ListOfBSs.Clear();
            ListOfCOs.Clear();
            ListOfDCs.Clear();
            ListOfGAs.Clear();
            ListOfIUs.Clear();
            ListOfLOs.Clear();
            ListOfLSs.Clear();
            ListOfNHs.Clear();
            ListOfNSs.Clear();
            ListOfOLs.Clear();
            ListOfOSs.Clear();
            ListOfPDs.Clear();
            ListOfPOs.Clear();
            ListOfSCs.Clear();
            ListOfSIs.Clear();
            ListOfSRs.Clear();
            ListOfSSs.Clear();
            ListOfSUs.Clear();
            ListOfTCs.Clear();
            ListOfTPs.Clear();
            ListOfTRs.Clear();
            ListOfTSs.Clear();
        }

        public static void CommitChanges()
        {
            if (messagesCount != 0)
            {
                try
                {
                    GatewayDataContext context = GatewayManager.GetGatewayContext2();
                    context.HOGW_2Bs.InsertAllOnSubmit<HOGW_2B>(ListOf2Bs);
                    context.HOGW_2Cs.InsertAllOnSubmit<HOGW_2C>(ListOf2Cs);
                    context.HOGW_2Ds.InsertAllOnSubmit<HOGW_2D>(ListOf2Ds);
                    context.HOGW_2Es.InsertAllOnSubmit<HOGW_2E>(ListOf2Es);
                    context.HOGW_2Fs.InsertAllOnSubmit<HOGW_2F>(ListOf2Fs);
                    context.HOGW_2Gs.InsertAllOnSubmit<HOGW_2G>(ListOf2Gs);
                    context.HOGW_2Is.InsertAllOnSubmit<HOGW_2I>(ListOf2Is);
                    context.HOGW_2Ls.InsertAllOnSubmit<HOGW_2L>(ListOf2Ls);
                    context.HOGW_3As.InsertAllOnSubmit<HOGW_3A>(ListOf3As);
                    context.HOGW_3Bs.InsertAllOnSubmit<HOGW_3B>(ListOf3Bs);
                    context.HOGW_3Cs.InsertAllOnSubmit<HOGW_3C>(ListOf3Cs);
                    context.HOGW_3Ds.InsertAllOnSubmit<HOGW_3D>(ListOf3Ds);
                    context.HOSE_AAs.InsertAllOnSubmit<HOSE_AA>(ListOfAAs);
                    context.HOSE_BRs.InsertAllOnSubmit<HOSE_BR>(ListOfBRs);
                    context.HOSE_BS.InsertAllOnSubmit<HOSE_BS>(ListOfBSs);
                    context.HOSE_COs.InsertAllOnSubmit<HOSE_CO>(ListOfCOs);
                    context.HOSE_DCs.InsertAllOnSubmit<HOSE_DC>(ListOfDCs);
                    context.HOSE_GAs.InsertAllOnSubmit<HOSE_GA>(ListOfGAs);
                    context.HOSE_IUs.InsertAllOnSubmit<HOSE_IU>(ListOfIUs);
                    context.HOSE_LOs.InsertAllOnSubmit<HOSE_LO>(ListOfLOs);
                    context.HOSE_LS.InsertAllOnSubmit<HOSE_LS>(ListOfLSs);
                    context.HOSE_NHs.InsertAllOnSubmit<HOSE_NH>(ListOfNHs);
                    context.HOSE_NS.InsertAllOnSubmit<HOSE_NS>(ListOfNSs);
                    context.HOSE_OLs.InsertAllOnSubmit<HOSE_OL>(ListOfOLs);
                    context.HOSE_OS.InsertAllOnSubmit<HOSE_OS>(ListOfOSs);
                    context.HOSE_PDs.InsertAllOnSubmit<HOSE_PD>(ListOfPDs);
                    context.HOSE_POs.InsertAllOnSubmit<HOSE_PO>(ListOfPOs);
                    context.HOSE_SCs.InsertAllOnSubmit<HOSE_SC>(ListOfSCs);
                    context.HOSE_SIs.InsertAllOnSubmit<HOSE_SI>(ListOfSIs);
                    context.HOSE_SRs.InsertAllOnSubmit<HOSE_SR>(ListOfSRs);
                    context.HOSE_SSes.InsertAllOnSubmit<HOSE_SS>(ListOfSSs);
                    context.HOSE_SUs.InsertAllOnSubmit<HOSE_SU>(ListOfSUs);
                    context.HOSE_TCs.InsertAllOnSubmit<HOSE_TC>(ListOfTCs);
                    context.HOSE_TPs.InsertAllOnSubmit<HOSE_TP>(ListOfTPs);
                    context.HOSE_TRs.InsertAllOnSubmit<HOSE_TR>(ListOfTRs);
                    context.HOSE_TS.InsertAllOnSubmit<HOSE_TS>(ListOfTSs);
                    try
                    {
                        context.SubmitChanges();
                    }
                    catch (SqlException exception)
                    {
                        SaveUnInsertedMessagesToInboxQueue();
                        throw exception;
                    }
                    NumberOfMsgInsertedToDB += messagesCount;
                    messagesCount = 0;
                    lastTimeInsertMsgToDB = DateTime.Now;
                    ClearMessagesList();
                }
                catch (Exception exception2)
                {
                    GatewayLogManager.Error("Error while insert message to DB, detail:" + exception2.Message);
                    throw exception2;
                }
            }
        }

        public static string[] GetGAMessages()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GatewayDB"].ConnectionString;
            List<string> list = new List<string>();
            if (SqlDataBase.Connect(connectionString))
            {
                string strSql = "SELECT ID,MESSAGE_STATUS,MESSAGE_TYPE, ADMIN_MESSAGE_LENGTH,ADMIN_MESSAGE_TEXT,LAST_MODIFIED FROM HOSE_GA";
                dHOSE_GAMSGS = SqlDataBase.ReturnDataTable(strSql);
                SqlDataBase.Disconnect();
            }
            IOrderedEnumerable<DataRow> enumerable2 = Enumerable.OrderByDescending<DataRow, object>(Enumerable.Where<DataRow>(DataTableExtensions.AsEnumerable(dHOSE_GAMSGS), delegate (DataRow tableInfo) {
                return DataRowExtensions.Field<DateTime>(tableInfo, "LAST_MODIFIED").Day == DateTime.Today.Day;
            }), delegate (DataRow tableInfo) {
                return tableInfo["ID"];
            });
            foreach (DataRow row in enumerable2)
            {
                list.Insert(0, "[" + row["LAST_MODIFIED"].ToString() + "] " + row["ADMIN_MESSAGE_TEXT"].ToString());
            }
            return list.ToArray();
        }

        public static MessageController GetInstance()
        {
            return _instance;
        }

        private static void inboxQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            Type type = null;
            byte[] bytes = null;
            object obj2 = null;
            string id = "";
            string messageType = "";
            Message message = null;
            bool flag = true;
            bool flag2 = false;
            try
            {
                message = ((MessageQueue) e.AsyncResult.AsyncState).EndReceive(e.AsyncResult);
                id = message.Id;
                bytes = MessageConverter.GetBytes(message);
                messageType = Util.GetMessageType(bytes);
                if (!string.IsNullOrEmpty(messageType))
                {
                    GatewayLogManager.Debug("Start convert raw format to message, MessageType=" + messageType);
                    obj2 = MessageConverter.ConvertRawFormatToMessage(bytes);
                    LiveLogManager.LogThisMessage(messageType, false, obj2);
                    if (obj2 != null)
                    {
                        type = obj2.GetType();
                        type.GetProperty("MESSAGE_STATUS").SetValue(obj2, 'R', null);
                        type.GetProperty("LAST_MODIFIED").SetValue(obj2, DateTime.Now, null);
                        switch (messageType)
                        {
                            case "SC":
                                MarketInfo.SetMarketStatus(type.GetProperty("SYSTEM_CONTROL_CODE").GetValue(obj2, null).ToString());
                                break;

                            case "LS":
                            {  var results = from msg in GatewayLib.GatewayManager.GetGatewayContext3().HOSE_TS
                                              where msg.ID >= maxIDOfTS
                                              select msg;
                            if ((results.Any()))
                                {
                                    HOSE_TS hose_ts = results.ToArray()[results.Count() - 1];
                                    decimal? tIMESTAMP = hose_ts.TIMESTAMP;
                                    maxIDOfTS = hose_ts.ID;
                                    type.GetProperty("TIMESTAMP").SetValue(obj2, tIMESTAMP, null);
                                }
                                break;
                            }
                        }
                        NumberOfReceivedMsgFromQueue++;
                        InsertMessageToDB(obj2);
                        flag = false;
                    }
                }
                else
                {
                    BrokerageMessageQueue.SaveBadMessage(message, "Failed:Message Type is Null or Empty");
                    NumberOfMsgSentToBadQueue++;
                    GatewayLogManager.Error("Failed to convert raw format to message, MessageType=NULL");
                }
            }
            catch (MessageQueueException exception)
            {
                if (message != null)
                {
                    BrokerageMessageQueue.SaveBadMessage(message, "Failed:" + exception.Message);
                    NumberOfMsgSentToBadQueue++;
                }
                if (exception.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                {
                    InsertMessageToDB();
                }
                else
                {
                    GatewayLogManager.Error(string.Concat(new object[] { "Error while reading message from inbox queue, MessageQueueErrorCode=", exception.MessageQueueErrorCode, ", detail:", exception.Message }));
                }
            }
            catch (SqlException exception2)
            {
                if (flag && (message != null))
                {
                    BrokerageMessageQueue.SaveMessageToInbox(message);
                }
                GatewayLogManager.Error(string.Concat(new object[] { "Error while insert message to DB, message=", exception2.Message, ", ErrorCode=", exception2.ErrorCode }));
                flag2 = true;
            }
            catch (Exception exception3)
            {
                GatewayLogManager.Error("Error while insert message to DB, message=" + exception3.Message);
                flag2 = true;
            }
            if (!flag2)
            {
                IAsyncResult result = ((MessageQueue) e.AsyncResult.AsyncState).BeginReceive(new TimeSpan(0, 0, 10), (MessageQueue) e.AsyncResult.AsyncState);
            }
        }

        public static void InsertMessageToDB()
        {
            if (messagesCount > 0)
            {
                try
                {
                    GatewayDataContext context = GatewayManager.GetGatewayContext2();
                    context.HOGW_2Bs.InsertAllOnSubmit<HOGW_2B>(ListOf2Bs);
                    context.HOGW_2Cs.InsertAllOnSubmit<HOGW_2C>(ListOf2Cs);
                    context.HOGW_2Ds.InsertAllOnSubmit<HOGW_2D>(ListOf2Ds);
                    context.HOGW_2Es.InsertAllOnSubmit<HOGW_2E>(ListOf2Es);
                    context.HOGW_2Fs.InsertAllOnSubmit<HOGW_2F>(ListOf2Fs);
                    context.HOGW_2Gs.InsertAllOnSubmit<HOGW_2G>(ListOf2Gs);
                    context.HOGW_2Is.InsertAllOnSubmit<HOGW_2I>(ListOf2Is);
                    context.HOGW_2Ls.InsertAllOnSubmit<HOGW_2L>(ListOf2Ls);
                    context.HOGW_3As.InsertAllOnSubmit<HOGW_3A>(ListOf3As);
                    context.HOGW_3Bs.InsertAllOnSubmit<HOGW_3B>(ListOf3Bs);
                    context.HOGW_3Cs.InsertAllOnSubmit<HOGW_3C>(ListOf3Cs);
                    context.HOGW_3Ds.InsertAllOnSubmit<HOGW_3D>(ListOf3Ds);
                    context.HOSE_AAs.InsertAllOnSubmit<HOSE_AA>(ListOfAAs);
                    context.HOSE_BRs.InsertAllOnSubmit<HOSE_BR>(ListOfBRs);
                    context.HOSE_BS.InsertAllOnSubmit<HOSE_BS>(ListOfBSs);
                    context.HOSE_COs.InsertAllOnSubmit<HOSE_CO>(ListOfCOs);
                    context.HOSE_DCs.InsertAllOnSubmit<HOSE_DC>(ListOfDCs);
                    context.HOSE_GAs.InsertAllOnSubmit<HOSE_GA>(ListOfGAs);
                    context.HOSE_IUs.InsertAllOnSubmit<HOSE_IU>(ListOfIUs);
                    context.HOSE_LOs.InsertAllOnSubmit<HOSE_LO>(ListOfLOs);
                    context.HOSE_LS.InsertAllOnSubmit<HOSE_LS>(ListOfLSs);
                    context.HOSE_NHs.InsertAllOnSubmit<HOSE_NH>(ListOfNHs);
                    context.HOSE_NS.InsertAllOnSubmit<HOSE_NS>(ListOfNSs);
                    context.HOSE_OLs.InsertAllOnSubmit<HOSE_OL>(ListOfOLs);
                    context.HOSE_OS.InsertAllOnSubmit<HOSE_OS>(ListOfOSs);
                    context.HOSE_PDs.InsertAllOnSubmit<HOSE_PD>(ListOfPDs);
                    context.HOSE_POs.InsertAllOnSubmit<HOSE_PO>(ListOfPOs);
                    context.HOSE_SCs.InsertAllOnSubmit<HOSE_SC>(ListOfSCs);
                    context.HOSE_SIs.InsertAllOnSubmit<HOSE_SI>(ListOfSIs);
                    context.HOSE_SRs.InsertAllOnSubmit<HOSE_SR>(ListOfSRs);
                    context.HOSE_SSes.InsertAllOnSubmit<HOSE_SS>(ListOfSSs);
                    context.HOSE_SUs.InsertAllOnSubmit<HOSE_SU>(ListOfSUs);
                    context.HOSE_TCs.InsertAllOnSubmit<HOSE_TC>(ListOfTCs);
                    context.HOSE_TPs.InsertAllOnSubmit<HOSE_TP>(ListOfTPs);
                    context.HOSE_TRs.InsertAllOnSubmit<HOSE_TR>(ListOfTRs);
                    context.HOSE_TS.InsertAllOnSubmit<HOSE_TS>(ListOfTSs);
                    context.SubmitChanges();
                    NumberOfMsgInsertedToDB += messagesCount;
                    messagesCount = 0;
                    lastTimeInsertMsgToDB = DateTime.Now;
                    ClearMessagesList();
                }
                catch (Exception exception)
                {
                    SaveUnInsertedMessagesToInboxQueue();
                    throw exception;
                }
            }
        }

        public static void InsertMessageToDB(object standardMessage)
        {
            try
            {
                string messageType = Util.GetMessageType(standardMessage);
                decimal confirmNumber = -1M;
                decimal dealId = -1M;
                if (CheckOrderDuplicate(standardMessage, messageType, out confirmNumber, out dealId))
                {
                    if (dealId != -1M)
                    {
                        BrokerageMessageQueue.SaveBadMessage(standardMessage, string.Concat(new object[] { "Duplicated,MessageType=", messageType, ",DealId=", dealId, ", Date:", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }));
                    }
                    else
                    {
                        BrokerageMessageQueue.SaveBadMessage(standardMessage, string.Concat(new object[] { "Duplicated,MessageType=", messageType, ",ConfirmNumber=", confirmNumber, ", Date:", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }));
                    }
                    NumberOfMsgSentToBadQueue++;
                }
                else
                {
                    GatewayDataContext context = GatewayManager.GetGatewayContext2();
                    messagesCount++;
                    switch (messageType)
                    {
                        case "2B":
                            ListOf2Bs.Add((HOGW_2B) standardMessage);
                            break;

                        case "2C":
                            ListOf2Cs.Add((HOGW_2C) standardMessage);
                            break;

                        case "2D":
                            ListOf2Ds.Add((HOGW_2D) standardMessage);
                            break;

                        case "2E":
                            ListOf2Es.Add((HOGW_2E) standardMessage);
                            break;

                        case "2F":
                            ListOf2Fs.Add((HOGW_2F) standardMessage);
                            break;

                        case "2G":
                            ListOf2Gs.Add((HOGW_2G) standardMessage);
                            break;

                        case "2I":
                            ListOf2Is.Add((HOGW_2I) standardMessage);
                            break;

                        case "2L":
                            ListOf2Ls.Add((HOGW_2L) standardMessage);
                            break;

                        case "3A":
                            ListOf3As.Add((HOGW_3A) standardMessage);
                            break;

                        case "3B":
                            ListOf3Bs.Add((HOGW_3B) standardMessage);
                            break;

                        case "3C":
                            ListOf3Cs.Add((HOGW_3C) standardMessage);
                            break;

                        case "3D":
                            ListOf3Ds.Add((HOGW_3D) standardMessage);
                            break;

                        case "AA":
                            ListOfAAs.Add((HOSE_AA) standardMessage);
                            break;

                        case "BR":
                            ListOfBRs.Add((HOSE_BR) standardMessage);
                            break;

                        case "BS":
                            ListOfBSs.Add((HOSE_BS) standardMessage);
                            break;

                        case "CO":
                            ListOfCOs.Add((HOSE_CO) standardMessage);
                            break;

                        case "DC":
                            ListOfDCs.Add((HOSE_DC) standardMessage);
                            break;

                        case "GA":
                            ListOfGAs.Add((HOSE_GA) standardMessage);
                            break;

                        case "IU":
                            ListOfIUs.Add((HOSE_IU) standardMessage);
                            break;

                        case "LO":
                            ListOfLOs.Add((HOSE_LO) standardMessage);
                            break;

                        case "LS":
                            ListOfLSs.Add((HOSE_LS) standardMessage);
                            break;

                        case "NH":
                            ListOfNHs.Add((HOSE_NH) standardMessage);
                            break;

                        case "NS":
                            ListOfNSs.Add((HOSE_NS) standardMessage);
                            break;

                        case "OL":
                            ListOfOLs.Add((HOSE_OL) standardMessage);
                            break;

                        case "OS":
                            ListOfOSs.Add((HOSE_OS) standardMessage);
                            break;

                        case "PD":
                            ListOfPDs.Add((HOSE_PD) standardMessage);
                            break;

                        case "PO":
                            ListOfPOs.Add((HOSE_PO) standardMessage);
                            break;

                        case "SC":
                            ListOfSCs.Add((HOSE_SC) standardMessage);
                            break;

                        case "SI":
                            ListOfSIs.Add((HOSE_SI) standardMessage);
                            break;

                        case "SR":
                            ListOfSRs.Add((HOSE_SR) standardMessage);
                            break;

                        case "SS":
                            ListOfSSs.Add((HOSE_SS) standardMessage);
                            break;

                        case "SU":
                            ListOfSUs.Add((HOSE_SU) standardMessage);
                            break;

                        case "TC":
                            ListOfTCs.Add((HOSE_TC) standardMessage);
                            break;

                        case "TP":
                            ListOfTPs.Add((HOSE_TP) standardMessage);
                            break;

                        case "TR":
                            ListOfTRs.Add((HOSE_TR) standardMessage);
                            break;

                        case "TS":
                            ListOfTSs.Add((HOSE_TS) standardMessage);
                            break;

                        default:
                            messagesCount--;
                            break;
                    }
                    if ((messagesCount >= 100) || (Math.Abs((int) (lastTimeInsertMsgToDB.Second - DateTime.Now.Second)) >= 3))
                    {
                        context.HOGW_2Bs.InsertAllOnSubmit<HOGW_2B>(ListOf2Bs);
                        context.HOGW_2Cs.InsertAllOnSubmit<HOGW_2C>(ListOf2Cs);
                        context.HOGW_2Ds.InsertAllOnSubmit<HOGW_2D>(ListOf2Ds);
                        context.HOGW_2Es.InsertAllOnSubmit<HOGW_2E>(ListOf2Es);
                        context.HOGW_2Fs.InsertAllOnSubmit<HOGW_2F>(ListOf2Fs);
                        context.HOGW_2Gs.InsertAllOnSubmit<HOGW_2G>(ListOf2Gs);
                        context.HOGW_2Is.InsertAllOnSubmit<HOGW_2I>(ListOf2Is);
                        context.HOGW_2Ls.InsertAllOnSubmit<HOGW_2L>(ListOf2Ls);
                        context.HOGW_3As.InsertAllOnSubmit<HOGW_3A>(ListOf3As);
                        context.HOGW_3Bs.InsertAllOnSubmit<HOGW_3B>(ListOf3Bs);
                        context.HOGW_3Cs.InsertAllOnSubmit<HOGW_3C>(ListOf3Cs);
                        context.HOGW_3Ds.InsertAllOnSubmit<HOGW_3D>(ListOf3Ds);
                        context.HOSE_AAs.InsertAllOnSubmit<HOSE_AA>(ListOfAAs);
                        context.HOSE_BRs.InsertAllOnSubmit<HOSE_BR>(ListOfBRs);
                        context.HOSE_BS.InsertAllOnSubmit<HOSE_BS>(ListOfBSs);
                        context.HOSE_COs.InsertAllOnSubmit<HOSE_CO>(ListOfCOs);
                        context.HOSE_DCs.InsertAllOnSubmit<HOSE_DC>(ListOfDCs);
                        context.HOSE_GAs.InsertAllOnSubmit<HOSE_GA>(ListOfGAs);
                        context.HOSE_IUs.InsertAllOnSubmit<HOSE_IU>(ListOfIUs);
                        context.HOSE_LOs.InsertAllOnSubmit<HOSE_LO>(ListOfLOs);
                        context.HOSE_LS.InsertAllOnSubmit<HOSE_LS>(ListOfLSs);
                        context.HOSE_NHs.InsertAllOnSubmit<HOSE_NH>(ListOfNHs);
                        context.HOSE_NS.InsertAllOnSubmit<HOSE_NS>(ListOfNSs);
                        context.HOSE_OLs.InsertAllOnSubmit<HOSE_OL>(ListOfOLs);
                        context.HOSE_OS.InsertAllOnSubmit<HOSE_OS>(ListOfOSs);
                        context.HOSE_PDs.InsertAllOnSubmit<HOSE_PD>(ListOfPDs);
                        context.HOSE_POs.InsertAllOnSubmit<HOSE_PO>(ListOfPOs);
                        context.HOSE_SCs.InsertAllOnSubmit<HOSE_SC>(ListOfSCs);
                        context.HOSE_SIs.InsertAllOnSubmit<HOSE_SI>(ListOfSIs);
                        context.HOSE_SRs.InsertAllOnSubmit<HOSE_SR>(ListOfSRs);
                        context.HOSE_SSes.InsertAllOnSubmit<HOSE_SS>(ListOfSSs);
                        context.HOSE_SUs.InsertAllOnSubmit<HOSE_SU>(ListOfSUs);
                        context.HOSE_TCs.InsertAllOnSubmit<HOSE_TC>(ListOfTCs);
                        context.HOSE_TPs.InsertAllOnSubmit<HOSE_TP>(ListOfTPs);
                        context.HOSE_TRs.InsertAllOnSubmit<HOSE_TR>(ListOfTRs);
                        context.HOSE_TS.InsertAllOnSubmit<HOSE_TS>(ListOfTSs);
                        try
                        {
                            context.SubmitChanges();
                        }
                        catch (SqlException exception)
                        {
                            SaveUnInsertedMessagesToInboxQueue();
                            throw exception;
                        }
                        NumberOfMsgInsertedToDB += messagesCount;
                        messagesCount = 0;
                        lastTimeInsertMsgToDB = DateTime.Now;
                        ClearMessagesList();
                    }
                }
            }
            catch (Exception exception2)
            {
                GatewayLogManager.Error("Error while insert message to DB, Message Type=" + Util.GetMessageType(standardMessage) + ", detail:" + exception2.Message);
                throw exception2;
            }
        }

        public static void ReceiveMessages()
        {
            MessageQueue inboxQueue = BrokerageMessageQueue.GetInboxQueue();
            inboxQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MessageController.inboxQueue_ReceiveCompleted);
            IAsyncResult result = inboxQueue.BeginReceive(new TimeSpan(0, 0, 10), inboxQueue);
        }

        private static void SaveUnInsertedMessagesToInboxQueue()
        {
            foreach (HOGW_2B hogw_b in ListOf2Bs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_b, "");
            }
            foreach (HOGW_2C hogw_c in ListOf2Cs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_c, "");
            }
            foreach (HOGW_2D hogw_d in ListOf2Ds)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_d, "");
            }
            foreach (HOGW_2E hogw_e in ListOf2Es)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_e, "");
            }
            foreach (HOGW_2F hogw_f in ListOf2Fs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_f, "");
            }
            foreach (HOGW_2G hogw_g in ListOf2Gs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_g, "");
            }
            foreach (HOGW_2I hogw_i in ListOf2Is)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_i, "");
            }
            foreach (HOGW_2L hogw_l in ListOf2Ls)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_l, "");
            }
            foreach (HOGW_3A hogw_a in ListOf3As)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_a, "");
            }
            foreach (HOGW_3B hogw_b2 in ListOf3Bs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_b2, "");
            }
            foreach (HOGW_3C hogw_c2 in ListOf3Cs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_c2, "");
            }
            foreach (HOGW_3D hogw_d2 in ListOf3Ds)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hogw_d2, "");
            }
            foreach (HOSE_AA hose_aa in ListOfAAs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_aa, "");
            }
            foreach (HOSE_BR hose_br in ListOfBRs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_br, "");
            }
            foreach (HOSE_BS hose_bs in ListOfBSs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_bs, "");
            }
            foreach (HOSE_CO hose_co in ListOfCOs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_co, "");
            }
            foreach (HOSE_DC hose_dc in ListOfDCs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_dc, "");
            }
            foreach (HOSE_GA hose_ga in ListOfGAs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_ga, "");
            }
            foreach (HOSE_IU hose_iu in ListOfIUs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_iu, "");
            }
            foreach (HOSE_LO hose_lo in ListOfLOs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_lo, "");
            }
            foreach (HOSE_LS hose_ls in ListOfLSs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_ls, hose_ls.CONFIRM_NUMBER.ToString());
            }
            foreach (HOSE_NH hose_nh in ListOfNHs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_nh, "");
            }
            foreach (HOSE_NS hose_ns in ListOfNSs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_ns, "");
            }
            foreach (HOSE_OL hose_ol in ListOfOLs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_ol, "");
            }
            foreach (HOSE_OS hose_os in ListOfOSs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_os, "");
            }
            foreach (HOSE_PD hose_pd in ListOfPDs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_pd, "");
            }
            foreach (HOSE_PO hose_po in ListOfPOs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_po, "");
            }
            foreach (HOSE_SC hose_sc in ListOfSCs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_sc, "");
            }
            foreach (HOSE_SI hose_si in ListOfSIs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_si, "");
            }
            foreach (HOSE_SR hose_sr in ListOfSRs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_sr, "");
            }
            foreach (HOSE_SS hose_ss in ListOfSSs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_ss, "");
            }
            foreach (HOSE_SU hose_su in ListOfSUs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_su, "");
            }
            foreach (HOSE_TC hose_tc in ListOfTCs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_tc, "");
            }
            foreach (HOSE_TP hose_tp in ListOfTPs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_tp, "");
            }
            foreach (HOSE_TR hose_tr in ListOfTRs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_tr, "");
            }
            foreach (HOSE_TS hose_ts in ListOfTSs)
            {
                BrokerageMessageQueue.SaveMessageToInbox(hose_ts, "");
            }
            ClearMessagesList();
        }
        #region Porsee message
        /*
       * Send 1C Message(s)
       */
        #region Send 1C Message(s)
        public void Send1CMessages()
        { 
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_1C> list = new List<HOGW_1C>();
               var messages = from msg in gatewayContext.HOGW_1Cs
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if (!messages.Any()) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_1C Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_1C hogw_c in messages)
            {
                list.Add(hogw_c);
                builder.Append(hogw_c.ID).Append(",");
                if (iD < hogw_c.ID)
                {
                    iD = hogw_c.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                maxIDOfSent1CMsg = iD;
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {
                var messages1 = from msg in gatewayContext.HOGW_1Cs
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent1CMsg
                                select msg;
                if (!messages1.Any())return;
                list.Clear();
                foreach (HOGW_1C hogw_c in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_c, hogw_c.MESSAGE_TYPE + ":" + hogw_c.ID);
                }
            }
        }
        #endregion
        /*
         * Send 1D Message(s)
         */
        #region Send 1D Message(s)
     
        public void Send1DMessages()
        { 
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_1D> list = new List<HOGW_1D>();
             var messages = from msg in gatewayContext.HOGW_1Ds
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if ((!messages.Any())) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_1D Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_1D hogw_d in messages)
            {
                list.Add(hogw_d);
                builder.Append(hogw_d.ID).Append(",");
                if (iD < hogw_d.ID)
                {
                    iD = hogw_d.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {
                 var messages1 = from msg in gatewayContext.HOGW_1Ds
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent1DMsg
                                select msg;
                if ((Queryable.Count<HOGW_1D>(messages1) > 0))
                {
                    list.Clear();
                    foreach (HOGW_1D hogw_d in messages1)
                    {
                        BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_d, hogw_d.MESSAGE_TYPE + ":" + hogw_d.ID);
                    }
                }
            }
        }
        #endregion
        /*
         * Send 1E Message(s)
         */
        #region Send 1E Message(s)
       
        public void Send1EMessages()
        {
         
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_1E> list = new List<HOGW_1E>();
           
            var messages = from msg in gatewayContext.HOGW_1Es
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if ((!messages.Any())) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_1E Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_1E hogw_e in messages)
            {
                list.Add(hogw_e);
                builder.Append(hogw_e.ID).Append(",");
                if (iD < hogw_e.ID)
                {
                    iD = hogw_e.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {
                  var messages1 = from msg in gatewayContext.HOGW_1Es
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent1EMsg
                                select msg;
                if ((!messages1.Any())) return;
                list.Clear();
                foreach (HOGW_1E hogw_e in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_e, hogw_e.MESSAGE_TYPE + ":" + hogw_e.ID);
                }
            }
        }
        #endregion
        /*
         * Send 1F Message(s)
         */
        #region Send 1F Message(s)
        public void Send1FMessages()
        {
            ParameterExpression expression;
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_1F> list = new List<HOGW_1F>();
            var messages = from msg in gatewayContext.HOGW_1Fs
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if ((!messages.Any())) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_1F Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_1F hogw_f in messages)
            {
                list.Add(hogw_f);
                builder.Append(hogw_f.ID).Append(",");
                if (iD < hogw_f.ID)
                {
                    iD = hogw_f.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {

                var messages1 = from msg in gatewayContext.HOGW_1Fs
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent1FMsg
                                select msg;
                if ((!messages1.Any())) return;
                list.Clear();
                foreach (HOGW_1F hogw_f in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_f, hogw_f.MESSAGE_TYPE + ":" + hogw_f.ID);
                }
            }
        }
        #endregion
        /*
         * Send 1G Message(s)
         */
        #region Send 1G Message(s) 
        public void Send1GMessages()
        {
           
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_1G> list = new List<HOGW_1G>();

            var messages = from msg in gatewayContext.HOGW_1Gs
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if ((!messages.Any())) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_1G Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_1G hogw_g in messages)
            {
                list.Add(hogw_g);
                builder.Append(hogw_g.ID).Append(",");
                if (iD < hogw_g.ID)
                {
                    iD = hogw_g.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {
                var messages1 = from msg in gatewayContext.HOGW_1Gs
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent1GMsg
                                select msg;
                if (!messages1.Any())return;
                list.Clear();
                foreach (HOGW_1G hogw_g in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_g, hogw_g.MESSAGE_TYPE + ":" + hogw_g.ID);
                }
            }
        }
        #endregion
        /*
        * Send 1I Message(s)
        */
        #region Send 1I Message(s)
        public void Send1IMessages()
        { 
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_1I> list = new List<HOGW_1I>();
             var messages = from msg in gatewayContext.HOGW_1Is
                           where msg.MESSAGE_STATUS == 'N' && msg.ID > maxIDOfSent1IMsg
                           select msg;
            if (!messages.Any()) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append(",");
            foreach (HOGW_1I hogw_i in messages)
            {
                list.Add(hogw_i);
                builder.Append(hogw_i.ID).Append(",");
                if (iD < hogw_i.ID)
                {
                    iD = hogw_i.ID;
                }
            }
            int num3 = gatewayContext.ExecuteCommand("UPDATE HOGW_1I Set MESSAGE_STATUS='S' WHERE ID in (0" + builder.ToString() + "0)", new object[0]);
            if (num3 == list.Count)
            {
                maxIDOfSent1IMsg = iD;
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {

                var messages1 = from msg in gatewayContext.HOGW_1Is
                    where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent1IMsg
                    select msg;
                if ((!messages1.Any())) return;
                list.Clear();
                foreach (HOGW_1I hogw_i in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_i, hogw_i.MESSAGE_TYPE + ":" + hogw_i.ID);
                }
            }
        }
        #endregion
        /*
         * Send 3A Message(s)
         */
        #region Send 3A Message(s)
        public void Send3AMessages()
        {
            ParameterExpression expression;
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_3A> list = new List<HOGW_3A>();
            var messages = from msg in gatewayContext.HOGW_3As
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if (!messages.Any()) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_3A Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_3A hogw_a in messages)
            {
                list.Add(hogw_a);
                builder.Append(hogw_a.ID).Append(",");
                if (iD < hogw_a.ID)
                {
                    iD = hogw_a.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {
                  var messages1 = from msg in gatewayContext.HOGW_3As
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent3AMsg
                                select msg;
                if (!messages1.Any()) return;
                list.Clear();
                foreach (HOGW_3A hogw_a in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_a, hogw_a.MESSAGE_TYPE + ":" + hogw_a.ID);
                }
            }
        }
        #endregion
        /*
         * Send 3B Message(s)
         */
        #region Send 3B Message(s)
        public void Send3BMessages()
        {
            ParameterExpression expression;
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_3B> list = new List<HOGW_3B>();
            var messages = from msg in gatewayContext.HOGW_3Bs
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if (!messages.Any()) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_3B Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_3B hogw_b in messages)
            {
                list.Add(hogw_b);
                builder.Append(hogw_b.ID).Append(",");
                if (iD < hogw_b.ID)
                {
                    iD = hogw_b.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {
                var messages1 = from msg in gatewayContext.HOGW_3Bs
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent3BMsg
                                select msg;
                if (!messages1.Any()) return;
                list.Clear();
                foreach (HOGW_3B hogw_b in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_b, hogw_b.MESSAGE_TYPE + ":" + hogw_b.ID);
                }
            }
        }
        #endregion
        #region Send 3C Message(s)
        public void Send3CMessages()
        {
            
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_3C> list = new List<HOGW_3C>();
            var messages = from msg in gatewayContext.HOGW_3Cs
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if (!messages.Any()) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_3C Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_3C hogw_c in messages)
            {
                list.Add(hogw_c);
                builder.Append(hogw_c.ID).Append(",");
                if (iD < hogw_c.ID)
                {
                    iD = hogw_c.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {
                var messages1 = from msg in gatewayContext.HOGW_3Cs
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent3CMsg
                                select msg;
                if (!messages1.Any()) return;
                list.Clear();
                foreach (HOGW_3C hogw_c in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_c, hogw_c.MESSAGE_TYPE + ":" + hogw_c.ID);
                }
            }
        }
        #endregion
        /*
         * Send 3D Message(s)
         */
        #region Send 3D Message(s)
        public void Send3DMessages()
        { 
            long iD = 0L;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            List<HOGW_3D> list = new List<HOGW_3D>();
            var messages = from msg in gatewayContext.HOGW_3Ds
                           where msg.MESSAGE_STATUS == 'N'
                           select msg;
            if (!messages.Any()) return;
            int num2 = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE HOGW_3D Set MESSAGE_STATUS='S' WHERE ID in (");
            foreach (HOGW_3D hogw_d in messages)
            {
                list.Add(hogw_d);
                builder.Append(hogw_d.ID).Append(",");
                if (iD < hogw_d.ID)
                {
                    iD = hogw_d.ID;
                }
            }
            builder.Append(0).Append(")");
            int num3 = gatewayContext.ExecuteCommand(builder.ToString(), new object[0]);
            if (num3 == list.Count)
            {
                for (num2 = 0; num2 < list.Count; num2++)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(list[num2], list[num2].MESSAGE_TYPE + ":" + list[num2].ID);
                }
            }
            else if ((num3 > 0) && (num3 < list.Count))
            {
                var messages1 = from msg in gatewayContext.HOGW_3Ds
                                where msg.MESSAGE_STATUS == 'S' && msg.ID > maxIDOfSent3DMsg
                                select msg;
                if (!messages1.Any()) return;
                list.Clear();
                foreach (HOGW_3D hogw_d in messages1)
                {
                    BrokerageMessageQueue.SaveMessageToInternalQueue(hogw_d, hogw_d.MESSAGE_TYPE + ":" + hogw_d.ID);
                }
            }
        }
        #endregion
        public void SendMessages()
        {
            
            string currentStatus = MarketInfo.GetCurrentStatus();
            if ((string.IsNullOrEmpty(currentStatus) || currentStatus == MarketStatusConst.NOT_APPLICABLE ||
                 ((currentStatus == MarketStatusConst.I) || (currentStatus == MarketStatusConst.J))) ||
                currentStatus == MarketStatusConst.H) return; 

            if ((currentStatus != "C") && (currentStatus != "K"))
            {
                this.Send1IMessages();
                this.Send1CMessages();
                this.Send1DMessages();
            }
            if (currentStatus != "K")
            {
                this.Send1EMessages();
                this.Send1FMessages();
                this.Send1GMessages();
                this.Send3BMessages();
                this.Send3CMessages();
                this.Send3DMessages();
            }
            this.Send3AMessages();
        }
        #endregion
        public static void StopReceiveMessage()
        { 
            BrokerageMessageQueue.GetInboxQueue().ReceiveCompleted -= new ReceiveCompletedEventHandler(MessageController.inboxQueue_ReceiveCompleted);
        }

        /// <summary>
        /// SynchronizeQueueToDB
        /// </summary>

        #region SynchronizeQueueToDB
        public void SynchronizeQueueToDB()
        {
            ParameterExpression expression;
            GatewayDataContext context = GatewayManager.GetGatewayContext3();

            // Table 1I
            var messages1 = from msg in context.HOGW_1Is
                            where msg.MESSAGE_STATUS == 'Q'
                            select msg;
            foreach (HOGW_1I hogw_i in messages1)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_i.MESSAGE_TYPE + ":" + hogw_i.ID))
                {
                    hogw_i.MESSAGE_STATUS = 'S';
                }
            }
            // Table 1C
            var messages2 = from msg in context.HOGW_1Cs
                            where msg.MESSAGE_STATUS == 'Q'
                            select msg;
            foreach (HOGW_1C hogw_c in messages2)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_c.MESSAGE_TYPE + ":" + hogw_c.ID))
                {
                    hogw_c.MESSAGE_STATUS = 'S';
                }
            }
             // Table 1D
            var messages3 = from msg in context.HOGW_1Ds
                            where msg.MESSAGE_STATUS == 'Q'
                            select msg;
            foreach (HOGW_1D hogw_d in messages3)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_d.MESSAGE_TYPE + ":" + hogw_d.ID))
                {
                    hogw_d.MESSAGE_STATUS = 'S';
                }
            }
                // Table 1E
            var messages4 = from msg in context.HOGW_1Es
                            where msg.MESSAGE_STATUS == 'Q'
                            select msg;
            foreach (HOGW_1E hogw_e in messages4)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_e.MESSAGE_TYPE + ":" + hogw_e.ID))
                {
                    hogw_e.MESSAGE_STATUS = 'S';
                }
            }
            // Table 1F
            var messagesf = from msg in context.HOGW_1Fs
                            where msg.MESSAGE_STATUS == 'Q'
                            select msg;
            foreach (HOGW_1F hogw_f in messagesf)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_f.MESSAGE_TYPE + ":" + hogw_f.ID))
                {
                    hogw_f.MESSAGE_STATUS = 'S';
                }
            }

            // Table 1G
            var messagesg = from msg in context.HOGW_1Gs
                            where msg.MESSAGE_STATUS == 'Q'
                            select msg;
            foreach (HOGW_1G hogw_g in messagesg)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_g.MESSAGE_TYPE + ":" + hogw_g.ID))
                {
                    hogw_g.MESSAGE_STATUS = 'S';
                }
            }
            // Table 3A
            var messages3a = from msg in context.HOGW_3As
                            where msg.MESSAGE_STATUS == 'Q'
                            select msg;
            foreach (HOGW_3A hogw_a in messages3a)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_a.MESSAGE_TYPE + ":" + hogw_a.ID))
                {
                    hogw_a.MESSAGE_STATUS = 'S';
                }
            }
              // Table 3B
            var messages3b = from msg in context.HOGW_3Bs
                             where msg.MESSAGE_STATUS == 'Q'
                             select msg;
            foreach (HOGW_3B hogw_b in messages3b)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_b.MESSAGE_TYPE + ":" + hogw_b.ID))
                {
                    hogw_b.MESSAGE_STATUS = 'S';
                }
            }
             // Table 3c
            var messages3C = from msg in context.HOGW_3Cs
                             where msg.MESSAGE_STATUS == 'Q'
                             select msg;
            foreach (HOGW_3C hogw_c2 in messages3C)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_c2.MESSAGE_TYPE + ":" + hogw_c2.ID))
                {
                    hogw_c2.MESSAGE_STATUS = 'S';
                }
            }

            // Table 3D
            var messages3D= from msg in context.HOGW_3Ds
                             where msg.MESSAGE_STATUS == 'Q'
                             select msg;
            foreach (HOGW_3D hogw_d2 in messages3D)
            {
                if (!BrokerageMessageQueue.ExistsInInternalQueue(hogw_d2.MESSAGE_TYPE + ":" + hogw_d2.ID))
                {
                    hogw_d2.MESSAGE_STATUS = 'S';
                }
            }
            context.SubmitChanges();
        }
        #endregion
        private void UpdateChanges()
        {
            int num3;
            int num = 0;
            GatewayDataContext gatewayContext = GatewayManager.GetGatewayContext();
            int num2 = 0;
            while (num2 < this.sentMessages.Count)
            {
                this.sentMessages[num2].GetType().GetProperty("MESSAGE_STATUS").SetValue(this.sentMessages[num2], 'S', null);
                if ((num2 > 0) && ((num2 % 400) == 0))
                {
                    try
                    {
                        gatewayContext.SubmitChanges();
                        num3 = num;
                        while (num3 <= num2)
                        {
                            BrokerageMessageQueue.SaveMessageToInternalQueue(this.sentMessages[num3], this.sentMessageLabels[num3]);
                            num3++;
                        }
                    }
                    catch (Exception exception)
                    {
                        GatewayLogManager.Error("Error while update Order Status from 'N' to 'S', message=" + exception.Message);
                        throw exception;
                    }
                    num = num2 + 1;
                }
                num2++;
            }
            if ((num2 > 0) && (((num2 - 1) % 400) != 0))
            {
                gatewayContext.SubmitChanges();
            }
            for (num3 = num; num3 < num2; num3++)
            {
                BrokerageMessageQueue.SaveMessageToInternalQueue(this.sentMessages[num3], this.sentMessageLabels[num3]);
            }
            this.sentMessages.Clear();
            this.sentMessageLabels.Clear();
        }
    }
}

