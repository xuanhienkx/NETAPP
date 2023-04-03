using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using InterStock;
using GWStock;
using GWStock.Business;
//------
using OrderChecker;
using HOGW_CoreConnector.Forms;
using HOGW_CoreConnector.HosePTConnector;
using HOGW_CoreConnector.CoreConnector;
using OrderChecker.Business;

namespace HOGW_CoreConnector
{
    public partial class frmMainConnector : Form
    {

        private Database db;

        private static Log logMatchingOrder = new Log();
        private static Log logPTReceiver = new Log();
        private static Log logPTSender = new Log();
        private int maxNumThread = Convert.ToInt32(ConfigurationManager.AppSettings["MaxNumThread"].ToString());

        private MasterThread threadMasterMatchingOrder = new MasterThread();
        private MasterThread threadMasterPTReceiver = new MasterThread();
        private MasterThread threadMasterPTSender = new MasterThread();

        public frmMainConnector()
        {
            this.InitializeComponent();
            this.db = DatabaseFactory.CreateDatabase();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOrderPicker_Click(object sender, EventArgs e)
        {
            new frmOrderPicker2HOGW().Show();
        }

        private void btnResetMessages_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Only do it right after trading day finished. Be sure you choose the correct reset option. Do you want to continue?", "Confirmation", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
            {
                try
                {
                    string text = null;
                    if (this.rd1.Checked)
                    {
                        GWMessageUtil.resetCTCITables();
                        text = "Reset CTCI messsages (Keep the last date DATA, not reset identity) successfully!";
                    }
                    else if (this.rd2.Checked)
                    {
                        GWMessageUtil.resetCTCITablesFlush();
                        text = "Reset CTCI messsages (Backup and Clear all DATA, not reset identity) successfully!";
                    }
                    else if (this.rd3.Checked)
                    {
                        GWMessageUtil.resetIdentityCTCITables();
                        text = "Reset CTCI messsages (Backup and Clear all DATA, reset identity) successfully!";
                    }
                    if (text != null)
                    {
                        writeLogMatchingOrder(text);
                        writeLogPTReceiver(text);
                        writeLogPTSender(text);
                        this.writeLogScreen(text, ErrorStatus.OK);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btnResetPRSMessages_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Only do it right after trading day finished. Be sure you choose the correct reset option. Do you want to continue?", "Confirmation", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
            {
                try
                {
                    string text = null;
                    if (this.rd4.Checked)
                    {
                        GWMessageUtil.resetPRSTables();
                        text = "Reset PRS messsages (Keep the last date DATA, not reset identity) successfully!";
                    }
                    else if (this.rd5.Checked)
                    {
                        GWMessageUtil.resetIdentityPRSTables();
                        text = "Reset PRS messsages (Clear all DATA, reset identity) successfully!";
                    }
                    if (text != null)
                    {
                        writeLogMatchingOrder(text);
                        writeLogPTReceiver(text);
                        writeLogPTSender(text);
                        this.writeLogScreen(text, ErrorStatus.OK);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.threadMasterMatchingOrder.CountThread < this.maxNumThread)
            {
                Thread thread = new Thread(new ThreadStart(this.ProcessMatchingOrdersViaWS));
                thread.Start();
                this.threadMasterMatchingOrder.AddThread(thread);
                this.writeLogScreen("A new matching order thread has been started!", ErrorStatus.OK);
                writeLogMatchingOrder("A new matching order thread has been started!");
            }
            else
            {
                MessageBox.Show("Can only create maximum " + this.maxNumThread.ToString() + " matching order threads. Change this value in App.config");
            }
            if (this.threadMasterPTReceiver.CountThread < CommonSettings.MaxNumThread)
            {
                Thread thread2 = new Thread(new ThreadStart(frmMainConnector.ProcessPTReceiverViaWS));
                thread2.Start();
                this.threadMasterPTReceiver.AddThread(thread2);
                this.writeLogScreen("A new threadPTReceiver has been started!", ErrorStatus.OK);
                writeLogPTReceiver("A new threadPTReceiver has been started!");
            }
            else
            {
                MessageBox.Show("Can only create maximum " + CommonSettings.MaxNumThread.ToString() + " threadPTReceivers. Change this value in AppName.config");
            }
            if (this.threadMasterPTSender.CountThread < CommonSettings.MaxNumThread)
            {
                Thread thread3 = new Thread(new ThreadStart(frmMainConnector.ProcessPTSenderViaWS));
                thread3.Start();
                this.threadMasterPTSender.AddThread(thread3);
                this.writeLogScreen("A new threadPTSender has been started!", ErrorStatus.OK);
                writeLogPTSender("A new threadPTSender has been started!");
            }
            else
            {
                MessageBox.Show("Can only create maximum " + CommonSettings.MaxNumThread.ToString() + " threadPTSenders. Change this value in AppName.config");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.StopThreads();
            this.writeLogScreen("All threads have just been STOPPED!", ErrorStatus.Help);
        }

        private void btnTestCancelOrders_Click(object sender, EventArgs e)
        {
            new frmTestCancelOrder().Show();
        }

        private void btnTestCaseExec_Click(object sender, EventArgs e)
        {
            new frmTestCaseExec().Show();
        }

        private void conMenuNotiExit_Click(object sender, EventArgs e)
        {
            this.btnClose_Click(sender, e);
        }

        private void conMenuNotiRestart_Click(object sender, EventArgs e)
        {
            this.btnStop_Click(sender, e);
            this.btnStart_Click(sender, e);
        }

        private void conMenuNotiRunThreads_Click(object sender, EventArgs e)
        {
            this.btnStart_Click(sender, e);
        }

        private void conMenuNotiShow_Click(object sender, EventArgs e)
        {
            base.Visible = true;
            this.notifyIconMain.Visible = false;
        }

        private void conMenuNotiStop_Click(object sender, EventArgs e)
        {
            this.btnStop_Click(sender, e);
        }



        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.StopThreads();
            writeLogPTSender("APPLICATION STOPPED! CloseReason: " + e.CloseReason.ToString());
            writeLogPTReceiver("APPLICATION STOPPED! CloseReason: " + e.CloseReason.ToString());
            writeLogMatchingOrder("APPLICATION STOPPED! CloseReason: " + e.CloseReason.ToString());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                int num;
                lock (logMatchingOrder)
                {
                    logMatchingOrder.LogFilePath = Directory.GetCurrentDirectory() + @"\Logs\HOGW_MatchingOrderSender" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                }
                lock (logPTSender)
                {
                    logPTSender.LogFilePath = Directory.GetCurrentDirectory() + @"\Logs\HOGW_PT_Sender" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                }
                lock (logPTReceiver)
                {
                    logPTReceiver.LogFilePath = Directory.GetCurrentDirectory() + @"\Logs\HOGW_PT_Receiver" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                }
                writeLogPTSender("APPLICATION STARTED!");
                writeLogPTReceiver("APPLICATION STARTED!");
                writeLogMatchingOrder("APPLICATION STARTED!");
                this.writeLogScreen("APPLICATION STARTED!", ErrorStatus.Help);
                if (!int.TryParse(ConfigurationManager.AppSettings["IsTest"], out num))
                {
                    num = 1;
                }
                if (num != 1)
                {
                    this.btnTestCaseExec.Enabled = false;
                    this.btnTestCancelOrders.Enabled = false;
                    this.btnOrderPicker.Enabled = false;
                }
                this.ttipMarketStatus.Text = "Market status: " + GWMarket.getMarketStatusHOSE(this.db);
                this.timerSystem.Enabled = true;
                this.ttipSystem.Text = "";
                this.ttipTimer.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                this.timerMarketStatus.Enabled = true;
                this.rd1.Checked = true;
                this.rd4.Checked = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void frmMainConnector_Resize(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.Visible = false;
                this.notifyIconMain.Visible = true;
            }
        }


        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {
            base.Visible = true;
            this.notifyIconMain.Visible = false;
        }

        private void ProcessMatchingOrdersViaWS()
        {
            int num4;
            int num5;
            int matchingOrderInterval = CommonSettings.MatchingOrderInterval;
            int firmID = CommonSettings.FirmID;
            int basicOrderNumber = CommonSettings.BasicOrderNumber;
            CoreConnectorWS rws = new CoreConnectorWS();
            string str = "";
            string marketStatus = "";
            if (!int.TryParse(ConfigurationManager.AppSettings["PriceMultipleOperand"].ToString(), out num4))
            {
                num4 = 1;
            }
            if (!int.TryParse(ConfigurationManager.AppSettings["IsCheckTime"].ToString(), out num5))
            {
                num5 = 1;
            }
            bool flag = false;
        Label_0069:
            try
            {
                lock (logMatchingOrder)
                {
                    logMatchingOrder.LogFilePath = Directory.GetCurrentDirectory() + @"\Logs\HOGW_MatchingOrderSender" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                }
                Database db = DatabaseFactory.CreateDatabase();
                int traderIDByTradeCode = GWMessageUtil.GetTraderIDByTradeCode(db, "Default");
                GWBrokerStatus status = GWMarket.getBrokerStatus(db, firmID);
                if ((status != null) && (status.MatchingHalt == "A"))
                {
                    writeLogMatchingOrder("FirmID " + firmID.ToString() + " is HALTED!");
                    Thread.Sleep(matchingOrderInterval);
                    goto Label_0069;
                }
                HOGWValidation validation = new HOGWValidation(db);
                marketStatus = validation.getCurrentMarketInfo(db).SystemControlCode;
                if (marketStatus != str)
                {
                    str = marketStatus;
                }
                if (!validation.IsMarketAvailable(marketStatus, false, false) && CommonSettings.ValidateOrderSession)
                {
                    if ((DateTime.Now.Hour <= 10) || ((!(marketStatus == "K") && !(marketStatus == "C")) && (!(marketStatus == "G") && !(marketStatus == "J"))))
                    {
                        goto Label_0069;
                    }
                    StockOrder[] orderArray = rws.GetStockOrders("S");
                    if (orderArray == null)
                    {
                        return;
                    }
                    foreach (StockOrder order in orderArray)
                    {
                        if (rws.UpdateOrderStatusBySeq(order.OrderSeq, "D", "Market is CLOSED") > 0)
                        {
                            writeLogMatchingOrder("Market is closed. Cancel order with SEQ=" + order.OrderSeq.ToString() + " by update status to D");
                        }
                        else
                        {
                            writeLogMatchingOrder("Market is closed. Cannot cancel order with SEQ=" + order.OrderSeq.ToString() + " by update status to D");
                        }
                    }
                }
                if ((num5 == 1) && (((DateTime.Now.Hour < 8) || (DateTime.Now.Hour >= 12)) || ((DateTime.Now.DayOfWeek == DayOfWeek.Saturday) || (DateTime.Now.DayOfWeek == DayOfWeek.Sunday))))
                {
                    goto Label_0069;
                }
                string text = "";
                if ((DateTime.Now.Hour >= 18) && !flag)
                {
                    GWMessageUtil.resetIdentityCTCITables();
                    GWMessageUtil.resetPRSTables();
                    flag = true;
                    text = "Auto-Reset CTCI messsages (Backup and Clear all DATA, reset identity) successfully!";
                    writeLogMatchingOrder(text);
                    writeLogPTReceiver(text);
                    writeLogPTSender(text);
                    text = "Auto-Reset PRS messsages (Keep the last date DATA, not reset identity) successfully!";
                    writeLogMatchingOrder(text);
                    writeLogPTReceiver(text);
                    writeLogPTSender(text);
                }
                if ((DateTime.Now.Hour < 8) && flag)//test
                {
                    text = "Set reset-flag to FALSE successfully! Ready to reset in the next time.";
                    writeLogMatchingOrder(text);
                    writeLogPTReceiver(text);
                    writeLogPTSender(text);
                    flag = false;
                }
                StockOrder[] stockOrders = rws.GetStockOrders("S");
                if (stockOrders != null)
                {
                    foreach (StockOrder order2 in stockOrders)
                    {
                        int traderid = GWMessageUtil.GetTraderIDByTradeCode(db, order2.TradeCode);
                        if (traderid == -1)
                        {
                            traderid = traderIDByTradeCode;
                        }
                        GWTraderStatus status2 = GWMarket.getTraderStatus(db, traderid);
                        if ((status2 != null) && (status2.TraderStatus.Trim().ToUpper() == "S"))
                        {
                            string str7 = "Trader " + traderid.ToString() + " is SUSPENDED!";
                            writeLogMatchingOrder(str7);
                            rws.UpdateOrderStatusBySeq(order2.OrderSeq, "P", str7);
                            Thread.Sleep(matchingOrderInterval);
                            continue;
                        }
                        string str9 = order2.OrderType.Trim().ToUpper();
                        if (str9 == null)
                        {
                            goto Label_04A8;
                        }
                        if (!(str9 == "MP"))
                        {
                            if (str9 == "ATO")
                            {
                                goto Label_044B;
                            }
                            if (str9 == "ATC")
                            {
                                goto Label_045B;
                            }
                            if (str9 == "PT")
                            {
                                goto Label_046B;
                            }
                            if (str9 == "LO")
                            {
                                goto Label_047B;
                            }
                            goto Label_04A8;
                        }
                        string price = "MP";
                        string pricetype = "MP";
                        goto Label_04D3;
                    Label_044B:
                        price = "ATO";
                        pricetype = "ATO";
                        goto Label_04D3;
                    Label_045B:
                        price = "ATC";
                        pricetype = "ATC";
                        goto Label_04D3;
                    Label_046B:
                        price = "0";
                        pricetype = "PT";
                        goto Label_04D3;
                    Label_047B:
                        price = string.Format("{0:F3}", order2.OrderPrice * num4);
                        pricetype = "LO";
                        goto Label_04D3;
                    Label_04A8:
                        price = string.Format("{0:F3}", order2.OrderPrice * num4);
                        pricetype = "LO";
                    Label_04D3:
                        if (pricetype != "PT")
                        {
                            marketStatus = validation.getCurrentMarketInfo(db).SystemControlCode;
                            if (marketStatus != str)
                            {
                                str = marketStatus;
                                validation = new HOGWValidation(db);
                            }
                            HOGWValidInput orderIn = new HOGWValidInput(order2.CustomerID, order2.StockCode, pricetype, marketStatus, "N", order2.OrderSide.ToString(), traderid, Convert.ToDecimal(order2.OrderPrice) * num4, Convert.ToDouble(order2.OrderVolume), Convert.ToDouble(order2.OrderVolume), 0, marketStatus);
                            HOGWValidOutput output = validation.CheckOrder(orderIn);


                            if (output.IsOK)
                            {
                                if (rws.UpdateOrderStatusBySeq(order2.OrderSeq, "E", null) > 0)
                                {
                                    string str8;
                                    if ((string.IsNullOrEmpty(marketStatus) || (marketStatus == " ")) || (marketStatus == ""))
                                    {
                                        str8 = "P";
                                    }
                                    else
                                    {
                                        str8 = marketStatus;
                                    }
                                    try
                                    {
                                        GWMessageUtil.insert1I(db, firmID, traderid, basicOrderNumber + order2.OrderSeq,
                                            order2.CustomerID, order2.StockCode, order2.OrderSide, order2.OrderVolume,
                                            order2.OrderVolume, price, order2.BoardType, output.PCFlag, str8);
                                    }
                                    catch (SqlException ex)
                                    {
                                        var noteMessage = "Cannot insert 1I message!";
                                        if (ex.Message.Contains("LO # session."))
                                            noteMessage = ex.Message;
                                        writeLogMatchingOrder("Cannot insert 1I message with SEQ=" + order2.OrderSeq +
                                                              " Err: " + ex.Message);
                                        if (rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", noteMessage) <= 0)
                                        {
                                            writeLogMatchingOrder(
                                                "After inserting into HOGW fails, cannot CANCEL (update in SBS.CORE -> D) the order with SEQ=" +
                                                order2.OrderSeq.ToString());
                                        }
                                        else
                                        {
                                            writeLogMatchingOrder(
                                                "After inserting into HOGW fails, update SBS.CORE order -> D with SEQ=" +
                                                order2.OrderSeq);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        writeLogMatchingOrder("Cannot insert 1I message with SEQ=" + order2.OrderSeq +
                                                              " Err: " + ex.Message);
                                    }

                                }
                                else
                                {
                                    writeLogMatchingOrder("Cannot update order in SBS.CORE S -> E (SEQ=" + order2.OrderSeq.ToString() + ")");
                                }
                            }
                            else
                            {
                                string str10 = orderIn.getDescription("VALID_ERROR - 1I");
                                string str5 = str10 + " [ErrCode: " + output.ErrCode.ToString() + " - " + output.ErrDesc + "]";
                                switch (output.ErrCode)
                                {
                                    case 0x29:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "Vol>ROOM");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x6f:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "Forbid matching order for bonds.");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 13:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "Wrong price spread.");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 14:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "Wrong board lot.");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x1f:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "New-listed stock. Cannot trade by PT method in the first day.");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x20:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "> ceiling");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x21:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "< floor");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x22:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "P", "PT for stock is only in session C");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x79:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "> ceiling");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x7a:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "< floor");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x3e7:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "Vol >= 20000");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x8a3:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "ATO # session.");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x8ad:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "ATC # session.");
                                        writeLogMatchingOrder(str5);
                                        break;

                                    case 0x8b6:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "MP # session.");
                                        writeLogMatchingOrder(str5);
                                        break;
                                    case 42:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", "LO # session. Trong phiên khớp lệnh định kỳ");
                                        writeLogMatchingOrder(str5);
                                        break;
                                    case 43:
                                        rws.UpdateOrderStatusBySeq(order2.OrderSeq, "D", string.Format("Lenh huy khong duoc phep trong phien {0}", output.ErrDesc));
                                        writeLogMatchingOrder(str5 + "Lệnh hủy trong phiên" + output.ErrDesc);
                                        break;
                                }
                            }
                        }
                    }
                    DataTable table = GWMessageUtil.get2GMessageFor1I(db);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow row = table.Rows[i];
                        if (rws.UpdateOrderStatusBySeq(Convert.ToInt32(row["ORDER_NUMBER"]) - CommonSettings.BasicOrderNumber, "D", "HOSE rejects - " + row["REJECT_REASON_NAME"].ToString()) > 0)
                        {
                            GWMessageUtil.updateMessageStatus(db, "2G", row["ID"], "D");
                        }
                        writeLogMatchingOrder(string.Concat(new object[] { "2G to 1I: OrderNumber=", row["ORDER_NUMBER"], ". REASON: ", row["REJECT_REASON_NAME"].ToString() }));
                    }
                    Thread.Sleep(matchingOrderInterval);
                    goto Label_0069;
                }
            }
            catch (Exception exception)
            {
                writeLogMatchingOrder(exception.Message);
                goto Label_0069;
            }
        }

        private static void ProcessPTReceiverViaWS()
        {
            int pTDealInterval = CommonSettings.PTDealInterval;
            PTConnectorWS rws = new PTConnectorWS();
        Label_000C:
            try
            {
                logPTReceiver.LogFilePath = Directory.GetCurrentDirectory() + @"\Logs\HOGW_PT_Receiver" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                Database db = DatabaseFactory.CreateDatabase();
                DataTable table = GWMessageUtil.getMessage(db, "1F2L");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    if (rws.Update1Firm(Convert.ToInt64(row["DEAL_ID"]), "M", Convert.ToInt32(row["CONFIRM_NUMBER"])) > 0)
                    {
                        GWMessageUtil.updateMessageStatus(db, "2L", row["ID_2L"], "D");
                    }
                }
                DataTable table2 = GWMessageUtil.getMessage(db, "1G2L");
                for (int j = 0; j < table2.Rows.Count; j++)
                {
                    DataRow row2 = table2.Rows[j];
                    if (rws.UpdateSeller(Convert.ToInt64(row2["DEAL_ID"]), "M", Convert.ToInt32(row2["CONFIRM_NUMBER"]), row2["SIDE"].ToString()) > 0)
                    {
                        GWMessageUtil.updateMessageStatus(db, "2L", row2["ID_2L"], "D");
                    }
                }
                DataTable table3 = GWMessageUtil.getData1G3B("C");
                for (int k = 0; k < table3.Rows.Count; k++)
                {
                    DataRow row3 = table3.Rows[k];
                    int num7 = rws.UpdateSellerStatus(Convert.ToInt64(row3["DEAL_ID"]), "NC");
                    int num8 = rws.UpdateSellerConfirmNumber(Convert.ToInt64(row3["DEAL_ID"]), Convert.ToInt32(row3["CONFIRM_NUMBER"]));
                    if ((num7 > 0) && (num8 > 0))
                    {
                        GWMessageUtil.updateMessageStatus(db, "3B", row3["ID_3B"], "D");
                    }
                }
                DataTable table4 = GWMessageUtil.getMessage(db, "3D");
                string branchcode = "100";
                string currentTranDay = ConnectToSBSFacade.GetCurrentTranDay(branchcode);
                for (int m = 0; m < table4.Rows.Count; m++)
                {
                    DataRow row4 = table4.Rows[m];
                    if (row4["REPLY_CODE"].ToString() == "A")
                    {
                        int num10 = Convert.ToInt32(row4["CONFIRM_NUMBER"]);
                        if (rws.UpdateSellerStatusByConfirmNumber(num10, "MXD") <= 0)
                        {
                            if (rws.Update1FirmStatusByConfirmNumber(num10, "MXD") <= 0)
                            {
                                if (rws.UpdateBuyerStatusByConfirmNumber(num10, "MXD") > 0)
                                {
                                    DeleteOrderResult result = ConnectToSBSFacade.deleteOrder(currentTranDay, rws.GetBuyerOrderSeq(num10).ToString());
                                    if (result.Transtate == 0)
                                    {
                                        GWMessageUtil.updateMessageStatus(db, "3D", row4["ID"], "D");
                                    }
                                    else
                                    {
                                        writeLogPTReceiver("Delete 2-firm buyer error: " + result.Message);
                                    }
                                }
                            }
                            else
                            {
                                DeleteOrderResult result2 = ConnectToSBSFacade.deleteOrder(currentTranDay, rws.Get1FirmOrderSeqSell(num10).ToString());
                                DeleteOrderResult result3 = ConnectToSBSFacade.deleteOrder(currentTranDay, rws.Get1FirmOrderSeqBuy(num10).ToString());
                                if ((result2.Transtate == 0) && (result3.Transtate == 0))
                                {
                                    GWMessageUtil.updateMessageStatus(db, "3D", row4["ID"], "D");
                                }
                                else
                                {
                                    writeLogPTReceiver("Delete 1-firm error, SELL: " + result2.Message + ", BUY: " + result3.Message);
                                }
                            }
                        }
                        else
                        {
                            DeleteOrderResult result4 = ConnectToSBSFacade.deleteOrder(currentTranDay, rws.GetSellerOrderSeq(num10).ToString());
                            if (result4.Transtate == 0)
                            {
                                GWMessageUtil.updateMessageStatus(db, "3D", row4["ID"], "D");
                            }
                            else
                            {
                                writeLogPTReceiver("Delete 2-firm seller error: " + result4.Message);
                            }
                        }
                    }
                    else if (row4["REPLY_CODE"].ToString() == "S")
                    {
                        int num15;
                        int num16;
                        int num14 = num15 = num16 = -1;
                        num14 = rws.UpdateSellerStatusByConfirmNumber(Convert.ToInt32(row4["CONFIRM_NUMBER"]), "MS");
                        if (num14 <= 0)
                        {
                            num15 = rws.Update1FirmStatusByConfirmNumber(Convert.ToInt32(row4["CONFIRM_NUMBER"]), "MS");
                            if (num15 <= 0)
                            {
                                num16 = rws.UpdateBuyerStatusByConfirmNumber(Convert.ToInt32(row4["CONFIRM_NUMBER"]), "MS");
                            }
                        }
                        if (((num14 > 0) || (num15 > 0)) || (num16 > 0))
                        {
                            GWMessageUtil.updateMessageStatus(db, "3D", row4["ID"], "D");
                        }
                    }
                    else if (row4["REPLY_CODE"].ToString() == "C")
                    {
                        int num18;
                        int num19;
                        int num17 = num18 = num19 = -1;
                        num17 = rws.UpdateSellerStatusByConfirmNumber(Convert.ToInt32(row4["CONFIRM_NUMBER"]), "MC");
                        if (num17 <= 0)
                        {
                            num18 = rws.Update1FirmStatusByConfirmNumber(Convert.ToInt32(row4["CONFIRM_NUMBER"]), "MC");
                            if (num18 <= 0)
                            {
                                num19 = rws.UpdateBuyerStatusByConfirmNumber(Convert.ToInt32(row4["CONFIRM_NUMBER"]), "MC");
                            }
                        }
                        if (((num17 > 0) || (num18 > 0)) || (num19 > 0))
                        {
                            GWMessageUtil.updateMessageStatus(db, "3D", row4["ID"], "D");
                        }
                    }
                }
                DataTable table5 = GWMessageUtil.getMessage(db, "2F");
                foreach (DataRow row5 in table5.Rows)
                {
                    GWBrokerStatus status = GWMarket.getBrokerStatus(db, Convert.ToInt32(row5["BUYER_FIRM"]));
                    GWBrokerStatus status2 = GWMarket.getBrokerStatus(db, Convert.ToInt32(row5["SELLER_CONTRA_FIRM"]));
                    if (((status2 == null) || (status2.PTHalt != "A")) && ((status == null) || (status.PTHalt != "A")))
                    {
                        GWTraderStatus status3 = GWMarket.getTraderStatus(db, Convert.ToInt32(row5["BUYER_TRADER_ID"]));
                        GWTraderStatus status4 = GWMarket.getTraderStatus(db, Convert.ToInt32(row5["SELLER_TRADER_ID"]));
                        if ((((status3 == null) || (status3.TraderStatus != "S")) && ((status4 == null) || (status4.TraderStatus != "S"))) && (rws.InsertBuyerDeal("RP", Convert.ToInt32(row5["BUYER_FIRM"]), Convert.ToInt32(row5["BUYER_TRADER_ID"]), row5["SIDE"].ToString(), Convert.ToInt32(row5["SELLER_CONTRA_FIRM"]), Convert.ToInt32(row5["SELLER_TRADER_ID"]), row5["SECURITY_SYMBOL"].ToString(), Convert.ToDouble(row5["VOLUME"]), Convert.ToDouble(row5["PRICE"]) / ((double)CommonSettings.PriceMultipleOperandPT), row5["BOARD"].ToString(), Convert.ToInt32(row5["CONFIRM_NUMBER"]), CommonSettings.CoreOnlineUser, "") > 0))
                        {
                            GWMessageUtil.updateMessageStatus(db, "2F", row5["ID"], "D");
                        }
                    }
                }
                GWMessageUtil.getMessage(db, "3B");
                foreach (DataRow row6 in table5.Rows)
                {
                    if ((row6["REPLY_CODE"].ToString().ToUpper() == "C") && (rws.UpdateBuyerStatus(Convert.ToInt64(row6["DEAL_ID"]), "XD") > 0))
                    {
                        GWMessageUtil.updateMessageStatus(db, "3B", row6["ID"], "D");
                    }
                }
                foreach (DataRow row7 in GWMessageUtil.getData2L3B().Rows)
                {
                    if (rws.UpdateBuyerStatus(Convert.ToInt64(row7["DEAL_ID"]), "M") > 0)
                    {
                        GWMessageUtil.updateMessageStatus(db, "3B", row7["ID_3B"], "D");
                        GWMessageUtil.updateMessageStatus(db, "2L", row7["ID_2L"], "D");
                    }
                }
                DataTable table7 = GWMessageUtil.getMessage(db, "3C");
                for (int n = 0; n < table7.Rows.Count; n++)
                {
                    DataRow row8 = table7.Rows[n];
                    if (rws.UpdateBuyerStatusByConfirmNumber(Convert.ToInt32(row8["CONFIRM_NUMBER"]), "MX") > 0)
                    {
                        GWMessageUtil.updateMessageStatus(db, "3C", row8["ID"], "D");
                    }
                }
                DataTable table8 = GWMessageUtil.getMessage(db, "AA");
                for (int num25 = 0; num25 < table8.Rows.Count; num25++)
                {
                    DataRow row9 = table8.Rows[num25];
                    if (rws.InsertAdvAnnouncement(row9["MESSAGE_STATUS"].ToString(), Convert.ToInt32(row9["FIRM"]), Convert.ToInt32(row9["TRADER"]), row9["security_symbol"].ToString(), row9["side"].ToString(), Convert.ToDouble(row9["volume"]), Convert.ToDouble(row9["price"]), row9["BOARD"].ToString(), row9["time"].ToString(), row9["add_cancel_flag"].ToString(), row9["contact"].ToString(), CommonSettings.CoreOnlineUser, "") > 0)
                    {
                        GWMessageUtil.updateMessageStatus(db, "AA", row9["ID"], "D");
                    }
                }
                Thread.Sleep(pTDealInterval);
                goto Label_000C;
            }
            catch (Exception exception)
            {
                writeLogPTReceiver(exception.Message);
                goto Label_000C;
            }
        }

        private static void ProcessPTSenderViaWS()
        {
            int pTDealInterval = CommonSettings.PTDealInterval;
            int firmID = CommonSettings.FirmID;
            PTConnectorWS rws = new PTConnectorWS();
        Label_0012:
            try
            {
                logPTSender.LogFilePath = Directory.GetCurrentDirectory() + @"\Logs\HOGW_PT_Sender" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                Database db = DatabaseFactory.CreateDatabase();
                GWBrokerStatus status = GWMarket.getBrokerStatus(db, firmID);
                if ((status != null) && (status.PTHalt == "A"))
                {
                    writeLogPTSender("PT SENDER WARNING - FIRMID " + firmID.ToString() + " IS HALTED!");
                    Thread.Sleep(pTDealInterval);
                }
                else
                {
                    HOGWValidation validation = new HOGWValidation(db);
                    string marketStatus = GWMarket.getMarketStatusHOSE(db);
                    if (!validation.IsMarketAvailable(marketStatus, true, true) && CommonSettings.ValidateOrderSession)
                    {
                        Thread.Sleep(pTDealInterval);
                    }
                    else
                    {
                        double? pRICE;
                        double priceMultipleOperandPT;
                        double? nullable3;
                        string str5;
                        foreach (ONE_FIRM_DEAL one_firm_deal in rws.Get1FirmOrdersByStatus("S"))
                        {
                            GWTraderStatus status2 = GWMarket.getTraderStatus(db, one_firm_deal.TRADER_ID.Value);
                            if ((status2 != null) && (status2.TraderStatus == "S"))
                            {
                                writeLogPTSender("PT 1 firm deal (sends 1F) - TRADER " + one_firm_deal.TRADER_ID.ToString() + " is in SUSPENSION!");
                                Thread.Sleep(pTDealInterval);
                            }
                            else
                            {
                                HOGWValidInput orderIn = null;
                                if ((one_firm_deal.SELLER_CLIENT_ID[3] == 'P') || (one_firm_deal.SELLER_CLIENT_ID[3] == 'p'))
                                {
                                    orderIn = new HOGWValidInput(one_firm_deal.SELLER_CLIENT_ID, one_firm_deal.SECURITY_SYMBOL, null, marketStatus, "N", "S", one_firm_deal.TRADER_ID.Value, Convert.ToDecimal(one_firm_deal.PRICE), Convert.ToDouble(one_firm_deal.SELLER_PORTFOLIO_VOLUME), Convert.ToDouble(one_firm_deal.SELLER_PORTFOLIO_VOLUME), 1, "");
                                }
                                else if ((one_firm_deal.SELLER_CLIENT_ID[3] == 'M') || (one_firm_deal.SELLER_CLIENT_ID[3] == 'm'))
                                {
                                    orderIn = new HOGWValidInput(one_firm_deal.SELLER_CLIENT_ID, one_firm_deal.SECURITY_SYMBOL, null, marketStatus, "N", "S", one_firm_deal.TRADER_ID.Value, Convert.ToDecimal(one_firm_deal.PRICE), Convert.ToDouble(one_firm_deal.SELLER_MUTUAL_FUND_VOLUME), Convert.ToDouble(one_firm_deal.SELLER_MUTUAL_FUND_VOLUME), 1, "");
                                }
                                else if ((one_firm_deal.SELLER_CLIENT_ID[3] == 'F') || (one_firm_deal.SELLER_CLIENT_ID[3] == 'f'))
                                {
                                    orderIn = new HOGWValidInput(one_firm_deal.SELLER_CLIENT_ID, one_firm_deal.SECURITY_SYMBOL, null, marketStatus, "N", "S", one_firm_deal.TRADER_ID.Value, Convert.ToDecimal(one_firm_deal.PRICE), Convert.ToDouble(one_firm_deal.SELLER_FOREIGN_VOLUME), Convert.ToDouble(one_firm_deal.SELLER_FOREIGN_VOLUME), 1, "");
                                }
                                else
                                {
                                    orderIn = new HOGWValidInput(one_firm_deal.SELLER_CLIENT_ID, one_firm_deal.SECURITY_SYMBOL, null, marketStatus, "N", "S", one_firm_deal.TRADER_ID.Value, Convert.ToDecimal(one_firm_deal.PRICE), Convert.ToDouble(one_firm_deal.SELLER_CLIENT_VOLUME), Convert.ToDouble(one_firm_deal.SELLER_CLIENT_VOLUME), 1, "");
                                }
                                HOGWValidOutput output = validation.CheckOrder(orderIn);
                                if (output.IsOK)
                                {
                                    pRICE = one_firm_deal.PRICE;
                                    priceMultipleOperandPT = CommonSettings.PriceMultipleOperandPT;
                                    GWMessageUtil.insert1F(db, one_firm_deal.FIRM, one_firm_deal.TRADER_ID, one_firm_deal.BUYER_CLIENT_ID, one_firm_deal.SELLER_CLIENT_ID, one_firm_deal.SECURITY_SYMBOL, pRICE.HasValue ? new double?(pRICE.GetValueOrDefault() * priceMultipleOperandPT) : (nullable3 = null), one_firm_deal.BOARD, one_firm_deal.DEAL_ID, one_firm_deal.BUYER_PORTFOLIO_VOLUME, one_firm_deal.BUYER_CLIENT_VOLUME, one_firm_deal.BUYER_MUTUAL_FUND_VOLUME, one_firm_deal.BUYER_FOREIGN_VOLUME, one_firm_deal.SELLER_PORTFOLIO_VOLUME, one_firm_deal.SELLER_CLIENT_VOLUME, one_firm_deal.SELLER_MUTUAL_FUND_VOLUME, one_firm_deal.SELLER_FOREIGN_VOLUME);
                                    rws.Update1FirmStatus((long)one_firm_deal.DEAL_ID, "E");
                                }
                                else
                                {
                                    rws.Update1FirmStatus((long)one_firm_deal.DEAL_ID, "ERR");
                                    str5 = orderIn.getDescription("VALID_ERROR - 1F");
                                    writeLogPTSender(str5 + " [ErrCode: " + output.ErrCode.ToString() + " - " + output.ErrDesc + "]");
                                }
                            }
                        }
                        foreach (ONE_FIRM_DEAL one_firm_deal2 in rws.Get1FirmOrdersByStatus("MXS"))
                        {
                            GWTraderStatus status3 = GWMarket.getTraderStatus(db, one_firm_deal2.TRADER_ID.Value);
                            if ((status3 != null) && (status3.TraderStatus == "S"))
                            {
                                writeLogPTSender("PT 1 firm deal (cancel 3C) - TRADER " + one_firm_deal2.TRADER_ID.ToString() + " is in SUSPENSION!");
                                Thread.Sleep(pTDealInterval);
                            }
                            else if ((!one_firm_deal2.CONFIRM_NUMBER.HasValue || !one_firm_deal2.FIRM.HasValue) || (!one_firm_deal2.TRADER_ID.HasValue || string.IsNullOrEmpty(one_firm_deal2.SECURITY_SYMBOL)))
                            {
                                rws.Update1FirmStatus((long)one_firm_deal2.DEAL_ID, "ERR");
                            }
                            else
                            {
                                GWMessageUtil.insert3C(db, one_firm_deal2.FIRM, one_firm_deal2.FIRM, one_firm_deal2.TRADER_ID, one_firm_deal2.CONFIRM_NUMBER, one_firm_deal2.SECURITY_SYMBOL, "X");
                                rws.Update1FirmStatus((long)one_firm_deal2.DEAL_ID, "MXE");
                            }
                        }
                        marketStatus = GWMarket.getMarketStatusHOSE(db);
                        if (!validation.IsMarketAvailable(marketStatus, true, true) && CommonSettings.ValidateOrderSession)
                        {
                            Thread.Sleep(pTDealInterval);
                        }
                        else
                        {
                            foreach (TWO_FIRM_DEAL_SELLER two_firm_deal_seller in rws.GetSellerOrdersByStatus("S"))
                            {
                                GWTraderStatus status4 = GWMarket.getTraderStatus(db, two_firm_deal_seller.BUYER_TRADER_ID.Value);
                                GWTraderStatus status5 = GWMarket.getTraderStatus(db, two_firm_deal_seller.SELLER_TRADER_ID.Value);
                                if ((status4 != null) && (status4.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal (SELLER sends 1G) - BUYER TRADER " + two_firm_deal_seller.BUYER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else if ((status5 != null) && (status5.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal (SELLER sends 1G) - SELLER TRADER " + two_firm_deal_seller.SELLER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else
                                {
                                    HOGWValidInput input2 = null;
                                    if ((two_firm_deal_seller.SELLER_CLIENT_ID[3] == 'P') || (two_firm_deal_seller.SELLER_CLIENT_ID[3] == 'p'))
                                    {
                                        input2 = new HOGWValidInput(two_firm_deal_seller.SELLER_CLIENT_ID, two_firm_deal_seller.SECURITY_SYMBOL, null, marketStatus, "N", "S", two_firm_deal_seller.SELLER_TRADER_ID.Value, Convert.ToDecimal(two_firm_deal_seller.PRICE), Convert.ToDouble(two_firm_deal_seller.BROKER_PORTFOLIO_VOLUME), Convert.ToDouble(two_firm_deal_seller.BROKER_PORTFOLIO_VOLUME), 2, "");
                                    }
                                    else if ((two_firm_deal_seller.SELLER_CLIENT_ID[3] == 'M') || (two_firm_deal_seller.SELLER_CLIENT_ID[3] == 'm'))
                                    {
                                        input2 = new HOGWValidInput(two_firm_deal_seller.SELLER_CLIENT_ID, two_firm_deal_seller.SECURITY_SYMBOL, null, marketStatus, "N", "S", two_firm_deal_seller.SELLER_TRADER_ID.Value, Convert.ToDecimal(two_firm_deal_seller.PRICE), Convert.ToDouble(two_firm_deal_seller.BROKER_MUTUAL_FUND_VOLUME), Convert.ToDouble(two_firm_deal_seller.BROKER_MUTUAL_FUND_VOLUME), 2, "");
                                    }
                                    else if ((two_firm_deal_seller.SELLER_CLIENT_ID[3] == 'F') || (two_firm_deal_seller.SELLER_CLIENT_ID[3] == 'f'))
                                    {
                                        input2 = new HOGWValidInput(two_firm_deal_seller.SELLER_CLIENT_ID, two_firm_deal_seller.SECURITY_SYMBOL, null, marketStatus, "N", "S", two_firm_deal_seller.SELLER_TRADER_ID.Value, Convert.ToDecimal(two_firm_deal_seller.PRICE), Convert.ToDouble(two_firm_deal_seller.BROKER_FOREIGN_VOLUME), Convert.ToDouble(two_firm_deal_seller.BROKER_FOREIGN_VOLUME), 2, "");
                                    }
                                    else
                                    {
                                        input2 = new HOGWValidInput(two_firm_deal_seller.SELLER_CLIENT_ID, two_firm_deal_seller.SECURITY_SYMBOL, null, marketStatus, "N", "S", two_firm_deal_seller.SELLER_TRADER_ID.Value, Convert.ToDecimal(two_firm_deal_seller.PRICE), Convert.ToDouble(two_firm_deal_seller.BROKER_CLIENT_VOLUME), Convert.ToDouble(two_firm_deal_seller.BROKER_CLIENT_VOLUME), 2, "");
                                    }
                                    HOGWValidOutput output2 = validation.CheckOrder(input2);
                                    if (output2.IsOK)
                                    {
                                        pRICE = two_firm_deal_seller.PRICE;
                                        priceMultipleOperandPT = CommonSettings.PriceMultipleOperandPT;
                                        GWMessageUtil.insert1G(db, two_firm_deal_seller.SELLER_FIRM, two_firm_deal_seller.SELLER_TRADER_ID, two_firm_deal_seller.SELLER_CLIENT_ID, two_firm_deal_seller.BUYER_FIRM, two_firm_deal_seller.BUYER_TRADER_ID, two_firm_deal_seller.SECURITY_SYMBOL, pRICE.HasValue ? new double?(pRICE.GetValueOrDefault() * priceMultipleOperandPT) : (nullable3 = null), two_firm_deal_seller.BOARD, two_firm_deal_seller.DEAL_ID, two_firm_deal_seller.BROKER_PORTFOLIO_VOLUME, two_firm_deal_seller.BROKER_CLIENT_VOLUME, two_firm_deal_seller.BROKER_MUTUAL_FUND_VOLUME, two_firm_deal_seller.BROKER_FOREIGN_VOLUME);
                                        rws.UpdateSellerStatus((long)two_firm_deal_seller.DEAL_ID, "E");
                                    }
                                    else
                                    {
                                        rws.UpdateSellerStatus((long)two_firm_deal_seller.DEAL_ID, "ERR");
                                        str5 = input2.getDescription("VALID_ERROR - 1G");
                                        writeLogPTSender(str5 + " [ErrCode: " + output2.ErrCode.ToString() + " - " + output2.ErrDesc + "]");
                                    }
                                }
                            }
                            foreach (TWO_FIRM_DEAL_BUYER two_firm_deal_buyer in rws.GetBuyerOrdersByStatus("SC"))
                            {
                                GWTraderStatus status6 = GWMarket.getTraderStatus(db, two_firm_deal_buyer.BUYER_TRADER_ID.Value);
                                GWTraderStatus status7 = GWMarket.getTraderStatus(db, two_firm_deal_buyer.SELLER_TRADER_ID.Value);
                                if ((status6 != null) && (status6.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal, buyer sends 3B(C) - BUYER TRADER " + two_firm_deal_buyer.BUYER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else if ((status7 != null) && (status7.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal, buyer sends 3B(C) - SELLER TRADER " + two_firm_deal_buyer.SELLER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else
                                {
                                    decimal num4;
                                    decimal num5;
                                    decimal num6;
                                    decimal num7;
                                    decimal num3 = (decimal)two_firm_deal_buyer.VOLUME.Value;
                                    string str3 = two_firm_deal_buyer.BUYER_CLIENT_ID;
                                    if (string.IsNullOrEmpty(str3))
                                    {
                                        num4 = num3;
                                        num5 = num7 = num6 = 0M;
                                    }
                                    else if (str3.Contains("P"))
                                    {
                                        num7 = num3;
                                        num5 = num4 = num6 = 0M;
                                    }
                                    else if (str3.Contains("M"))
                                    {
                                        num6 = num3;
                                        num5 = num4 = num7 = 0M;
                                    }
                                    else if (str3.Contains("F"))
                                    {
                                        num5 = num3;
                                        num7 = num4 = num6 = 0M;
                                    }
                                    else
                                    {
                                        num4 = num3;
                                        num5 = num7 = num6 = 0M;
                                    }
                                    GWMessageUtil.insert3B(db, two_firm_deal_buyer.BUYER_FIRM, two_firm_deal_buyer.CONFIRM_NUMBER, two_firm_deal_buyer.DEAL_ID, str3, "C", num7, num4, num6, num5);
                                    rws.UpdateBuyerStatus((long)two_firm_deal_buyer.DEAL_ID, "XD");
                                }
                            }
                            foreach (TWO_FIRM_DEAL_BUYER two_firm_deal_buyer2 in rws.GetBuyerOrdersByStatus("SP"))
                            {
                                GWTraderStatus status8 = GWMarket.getTraderStatus(db, two_firm_deal_buyer2.BUYER_TRADER_ID.Value);
                                GWTraderStatus status9 = GWMarket.getTraderStatus(db, two_firm_deal_buyer2.SELLER_TRADER_ID.Value);
                                if ((status8 != null) && (status8.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal, buyer sends 3B(A) - BUYER TRADER " + two_firm_deal_buyer2.BUYER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else if ((status9 != null) && (status9.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal, buyer sends 3B(A) - SELLER TRADER " + two_firm_deal_buyer2.SELLER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else
                                {
                                    decimal num9;
                                    decimal num10;
                                    decimal num11;
                                    decimal num12;
                                    decimal num8 = (decimal)two_firm_deal_buyer2.VOLUME.Value;
                                    string str4 = two_firm_deal_buyer2.BUYER_CLIENT_ID;
                                    if (string.IsNullOrEmpty(str4))
                                    {
                                        num9 = num8;
                                        num10 = num12 = num11 = 0M;
                                    }
                                    else if (str4.Contains("P"))
                                    {
                                        num12 = num8;
                                        num10 = num9 = num11 = 0M;
                                    }
                                    else if (str4.Contains("M"))
                                    {
                                        num11 = num8;
                                        num10 = num9 = num12 = 0M;
                                    }
                                    else if (str4.Contains("F"))
                                    {
                                        num10 = num8;
                                        num12 = num9 = num11 = 0M;
                                    }
                                    else
                                    {
                                        num9 = num8;
                                        num10 = num12 = num11 = 0M;
                                    }
                                    GWMessageUtil.insert3B(db, two_firm_deal_buyer2.BUYER_FIRM, two_firm_deal_buyer2.CONFIRM_NUMBER, two_firm_deal_buyer2.DEAL_ID, str4, "A", num12, num9, num11, num10);
                                    rws.UpdateBuyerStatus((long)two_firm_deal_buyer2.DEAL_ID, "E");
                                }
                            }
                            foreach (TWO_FIRM_DEAL_SELLER two_firm_deal_seller2 in rws.GetSellerOrdersByStatus("MXS"))
                            {
                                GWTraderStatus status10 = GWMarket.getTraderStatus(db, two_firm_deal_seller2.BUYER_TRADER_ID.Value);
                                GWTraderStatus status11 = GWMarket.getTraderStatus(db, two_firm_deal_seller2.SELLER_TRADER_ID.Value);
                                if ((status10 != null) && (status10.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal (SELLER sends cancel 3C) - BUYER TRADER " + two_firm_deal_seller2.BUYER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else if ((status11 != null) && (status11.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal (SELLER sends cancel 3C) - SELLER TRADER " + two_firm_deal_seller2.SELLER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else if ((!two_firm_deal_seller2.CONFIRM_NUMBER.HasValue || !two_firm_deal_seller2.BUYER_FIRM.HasValue) || ((!two_firm_deal_seller2.SELLER_FIRM.HasValue || !two_firm_deal_seller2.SELLER_TRADER_ID.HasValue) || string.IsNullOrEmpty(two_firm_deal_seller2.SECURITY_SYMBOL)))
                                {
                                    rws.UpdateSellerStatus((long)two_firm_deal_seller2.DEAL_ID, "ERR");
                                }
                                else
                                {
                                    GWMessageUtil.insert3C(db, two_firm_deal_seller2.SELLER_FIRM, two_firm_deal_seller2.BUYER_FIRM, two_firm_deal_seller2.SELLER_TRADER_ID, two_firm_deal_seller2.CONFIRM_NUMBER, two_firm_deal_seller2.SECURITY_SYMBOL, two_firm_deal_seller2.SIDE);
                                    rws.UpdateSellerStatus((long)two_firm_deal_seller2.DEAL_ID, "MXE");
                                }
                            }
                            foreach (TWO_FIRM_DEAL_BUYER two_firm_deal_buyer3 in rws.GetBuyerOrdersByStatus("MXS"))
                            {
                                GWTraderStatus status12 = GWMarket.getTraderStatus(db, two_firm_deal_buyer3.SELLER_TRADER_ID.Value);
                                if ((status12 != null) && (status12.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal (buyer sends 3D code A) - SELLER TRADER " + two_firm_deal_buyer3.SELLER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else
                                {
                                    GWMessageUtil.insert3D(db, two_firm_deal_buyer3.BUYER_FIRM, two_firm_deal_buyer3.CONFIRM_NUMBER, "A");
                                    rws.UpdateBuyerStatus((long)two_firm_deal_buyer3.DEAL_ID, "MXE");
                                }
                            }
                            foreach (TWO_FIRM_DEAL_BUYER two_firm_deal_buyer4 in rws.GetBuyerOrdersByStatus("MXCS"))
                            {
                                GWTraderStatus status13 = GWMarket.getTraderStatus(db, two_firm_deal_buyer4.SELLER_TRADER_ID.Value);
                                if ((status13 != null) && (status13.TraderStatus == "S"))
                                {
                                    writeLogPTSender("PT 2 firm deal (buyer sends 3D code C) - SELLER TRADER " + two_firm_deal_buyer4.SELLER_TRADER_ID.ToString() + " is in SUSPENSION!");
                                    Thread.Sleep(pTDealInterval);
                                }
                                else
                                {
                                    GWMessageUtil.insert3D(db, two_firm_deal_buyer4.BUYER_FIRM, two_firm_deal_buyer4.CONFIRM_NUMBER, "C");
                                    rws.UpdateBuyerStatus((long)two_firm_deal_buyer4.DEAL_ID, "MXE");
                                }
                            }
                            marketStatus = GWMarket.getMarketStatusHOSE(db);
                            if (!validation.IsMarketAvailable(marketStatus, true, true) && CommonSettings.ValidateOrderSession)
                            {
                                Thread.Sleep(pTDealInterval);
                            }
                            else
                            {
                                foreach (ADVERTISEMENT advertisement in rws.GetAdvOrdersByStatus("S"))
                                {
                                    GWTraderStatus status14 = GWMarket.getTraderStatus(db, advertisement.TRADER_ID.Value);
                                    if ((status14 != null) && (status14.TraderStatus == "S"))
                                    {
                                        writeLogPTSender("PT Advertisement, send 1E(A) - TRADER " + advertisement.TRADER_ID.ToString() + " is in SUSPENSION!");
                                        Thread.Sleep(pTDealInterval);
                                    }
                                    else
                                    {
                                        HOGWValidInput input3 = new HOGWValidInput(null, advertisement.SECURITY_SYMBOL, null, marketStatus, "N", advertisement.SIDE.ToString(), advertisement.TRADER_ID.Value, Convert.ToDecimal(advertisement.PRICE), Convert.ToDouble(advertisement.VOLUME), Convert.ToDouble(advertisement.VOLUME), 3, "");
                                        HOGWValidOutput output3 = validation.CheckOrder(input3);
                                        if (output3.IsOK)
                                        {
                                            pRICE = advertisement.PRICE;
                                            priceMultipleOperandPT = CommonSettings.PriceMultipleOperandPT;
                                            GWMessageUtil.insert1E(db, advertisement.FIRM, advertisement.TRADER_ID, advertisement.SECURITY_SYMBOL, advertisement.SIDE, advertisement.VOLUME, pRICE.HasValue ? new double?(pRICE.GetValueOrDefault() * priceMultipleOperandPT) : (nullable3 = null), advertisement.BOARD, advertisement.TIME, advertisement.ADD_CANCEL_FLAG, advertisement.CONTACT);
                                            rws.UpdateAdvStatus((long)advertisement.ID, "E");
                                        }
                                        else
                                        {
                                            rws.UpdateAdvStatus((long)advertisement.ID, "ERR");
                                            str5 = input3.getDescription("VALID_ERROR - 1E");
                                            writeLogPTSender(str5 + " [ErrCode: " + output3.ErrCode.ToString() + " - " + output3.ErrDesc + "]");
                                        }
                                    }
                                }
                                foreach (ADVERTISEMENT advertisement2 in rws.GetAdvOrdersByStatus("MXS"))
                                {
                                    GWTraderStatus status15 = GWMarket.getTraderStatus(db, advertisement2.TRADER_ID.Value);
                                    if ((status15 != null) && (status15.TraderStatus == "S"))
                                    {
                                        writeLogPTSender("PT Advertisement, send 1E(C) - TRADER " + advertisement2.TRADER_ID.ToString() + " is in SUSPENSION!");
                                        Thread.Sleep(pTDealInterval);
                                    }
                                    else
                                    {
                                        pRICE = advertisement2.PRICE;
                                        priceMultipleOperandPT = CommonSettings.PriceMultipleOperandPT;
                                        GWMessageUtil.insert1E(db, advertisement2.FIRM, advertisement2.TRADER_ID, advertisement2.SECURITY_SYMBOL, advertisement2.SIDE, advertisement2.VOLUME, pRICE.HasValue ? new double?(pRICE.GetValueOrDefault() * priceMultipleOperandPT) : (nullable3 = null), advertisement2.BOARD, advertisement2.TIME, advertisement2.ADD_CANCEL_FLAG, advertisement2.CONTACT);
                                        rws.UpdateAdvStatus((long)advertisement2.ID, "X");
                                    }
                                }
                                Thread.Sleep(pTDealInterval);
                            }
                        }
                    }
                }
                goto Label_0012;
            }
            catch (Exception exception)
            {
                writeLogPTSender(exception.Message);
                goto Label_0012;
            }
        }

        private void StopThreads()
        {
            try
            {
                this.writeLogScreen("Wait for shutting down the threads...", ErrorStatus.Help);
                this.threadMasterMatchingOrder.StopThreads();
                this.threadMasterPTReceiver.StopThreads();
                this.threadMasterPTSender.StopThreads();
                writeLogPTSender("All threads have just been stopped!");
                writeLogPTReceiver("All threads have just been stopped!");
                writeLogMatchingOrder("All threads have just been stopped!");
            }
            catch (ThreadAbortException exception)
            {
                string text = exception.Message + "; Inner Exception: " + exception.InnerException.Message;
                writeLogPTSender(text);
                writeLogPTReceiver(text);
                writeLogMatchingOrder(text);
            }
        }

        private void timerMarketStatus_Tick(object sender, EventArgs e)
        {
            this.ttipMarketStatus.Text = "Market status: " + GWMarket.getMarketStatusHOSE(this.db);
        }

        private void timerSystem_Tick(object sender, EventArgs e)
        {
            this.ttipTimer.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private static void writeLogMatchingOrder(string text)
        {
            lock (logMatchingOrder)
            {
                logMatchingOrder.writeLog(text);
            }
        }

        private static void writeLogPTReceiver(string text)
        {
            lock (logPTReceiver)
            {
                logPTReceiver.writeLog(text);
            }
        }

        private static void writeLogPTSender(string text)
        {
            lock (logPTSender)
            {
                logPTSender.writeLog(text);
            }
        }

        private void writeLogScreen(string text, ErrorStatus status)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToString("yyyy/MM/dd"));
            item.SubItems.Add(DateTime.Now.ToString("HH:mm:ss"));
            item.SubItems.Add(text);
            switch (status)
            {
                case ErrorStatus.Critical:
                    item.ImageIndex = 3;
                    break;

                case ErrorStatus.Medium:
                    item.ImageIndex = 0;
                    break;

                case ErrorStatus.Low:
                    item.ImageIndex = 2;
                    break;

                case ErrorStatus.Help:
                    item.ImageIndex = 4;
                    break;

                case ErrorStatus.OK:
                    item.ImageIndex = 1;
                    break;

                case ErrorStatus.Info:
                    item.ImageIndex = 6;
                    break;
            }
            this.lvLog.Items.Add(item);
        }

        public enum ErrorStatus
        {
            Critical,
            Medium,
            Low,
            Help,
            OK,
            Info
        }
    }
}
