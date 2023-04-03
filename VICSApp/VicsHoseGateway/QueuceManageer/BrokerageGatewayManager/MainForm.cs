using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Configuration;
using System.Threading;
using GatewayLib;
using System.Data.SqlClient;

namespace BrokerageGatewayManager
{
    public partial class MainForm : Form
    { 
        private delegate void AddListBoxItemDelegate(object item);

        private delegate void ClearListbox(string msg);

        private delegate void Method1Del(string info);

        private delegate void Method2Del(string info);

        private delegate void Method3Del(string info);

        private delegate void Method4Del(string info);

        private delegate void SetDataCallback(string Data);

        private delegate void UpdateListbox(string msg);

        Thread sendMessageThread = null;

        Thread updateInfoThread = null;

        private int sendMsgEverySeconds = 0;
        private static int synchronizeInternalQueueAndDBEverySeconds = 0;
        public int iLength;
        private bool isRunning = false;
        public MainForm()
        {
            InitializeComponent();

            sendMsgEverySeconds = Convert.ToInt32(ConfigurationSettings.AppSettings["SendMsgEverySeconds"]);
            synchronizeInternalQueueAndDBEverySeconds = Convert.ToInt32(ConfigurationSettings.AppSettings["SynchronizeInternalQueueAndDBEverySeconds"]);
        }
        private void AddListBoxItem(object item)
        {
            if (this.lstGAMessages.InvokeRequired)
            {
                this.lstGAMessages.Invoke(new AddListBoxItemDelegate(this.AddListBoxItem), new object[] { item });
            }
            else
            {
                this.lstGAMessages.Items.Add(item);
            }
        }
        private void Run()
        {
            //do
            //{
            //    try
            //    {
            //        MessageController.GetInstance().SendMessages();
            //    }
            //    catch (Exception ex)
            //    {
            //        GatewayLogManager.Error("Error while sending message, detail:" + ex.Message);
            //        MessageBox.Show(ex.Message);
            //        OnStop();
            //    }
            //    Thread.Sleep(sendMsgEverySeconds * 1000);
            //} while (true);
            while (true)
            {
                try
                {
                    MessageController.GetInstance().SendMessages();
                }
                catch (Exception exception)
                {
                    GatewayLogManager.Error("Error while sending message, detail:" + exception.Message);
                    MessageBox.Show(exception.Message);
                    this.OnStop();
                }
                Thread.Sleep((int)(this.sendMsgEverySeconds * 1000));
            }
        }

        private void UpdateInfo()
        {
           /* do
            {
                Method1(MessageController.NumberOfSentMessage.ToString());
                Method2(MessageController.NumberOfMsgInsertedToDB.ToString());
                Method3(MessageController.NumberOfMsgSentToBadQueue.ToString());
                Method4(MessageController.NumberOfReceivedMsgFromQueue.ToString());
                Thread.Sleep(1000);
            } while (true);*/
            while (true)
            {
                this.Method1(MessageController.NumberOfSentMessage.ToString());
                this.Method2(MessageController.NumberOfMsgInsertedToDB.ToString());
                this.Method3(MessageController.NumberOfMsgSentToBadQueue.ToString());
                this.Method4(MessageController.NumberOfReceivedMsgFromQueue.ToString());
                Thread.Sleep(1000);
            }
        }

        public void Method1(string info)
        {
            if (this.lblNumberOfSentMessages.InvokeRequired)
            {
                Method1Del method = new Method1Del(this.Method1);
                this.lblNumberOfSentMessages.Invoke(method, new object[] { info });
            }
            else
            {
                this.lblNumberOfSentMessages.Text = info;
                this.lblCurrentMarketStatus.Text = MarketInfo.GetCurrentStatus();
            }
        }

        public void Method2(string info)
        {
            if (this.lblNumberOfMsgInsertedToDB.InvokeRequired)
            {
                Method2Del method = new Method2Del(this.Method2);
                this.lblNumberOfMsgInsertedToDB.Invoke(method, new object[] { info });
            }
            else
            {
                this.lblNumberOfMsgInsertedToDB.Text = info;
            }
        }

        public void Method3(string info)
        {
            if (this.lblNumberOfMessageSentToBadQueue.InvokeRequired)
            {
                Method3Del method = new Method3Del(this.Method3);
                this.lblNumberOfMessageSentToBadQueue.Invoke(method, new object[] { info });
            }
            else
            {
                this.lblNumberOfMessageSentToBadQueue.Text = info;
            }
        }

        public void Method4(string info)
        {
            if (this.lblNumberOfMsgFromQueue.InvokeRequired)
            {
                Method4Del method = new Method4Del(this.Method4);
                this.lblNumberOfMsgFromQueue.Invoke(method, new object[] { info });
            }
            else
            {
                this.lblNumberOfMsgFromQueue.Text = info;
            }
        }

        private void OnStart(string[] args)
        {
            if (!this.isRunning)
            {
                string str = BrokerageMessageQueue.MessageQueueIsReady();
                if (!string.IsNullOrEmpty(str))
                {
                    MessageBox.Show(str);
                }
                else
                {
                    try
                    {
                        BrokerageMessageQueue.StartSendMessagesToOutbox();
                        if (this.sendMsgEverySeconds > 0)
                        {
                            this.sendMessageThread = new Thread(new ThreadStart(this.Run));
                            this.sendMessageThread.Start();
                        }
                        this.ReceiveMessage();
                        this.lblGatewayStatus.Text = "Gateway đang hoạt động";
                        this.lblGatewayStatus.ForeColor = Color.Green;
                        this.isRunning = true;
                        this.mnuStart.Enabled = false;
                        this.mnuStop.Enabled = true;
                        this.btnStart.Enabled = false;
                        this.btnStop.Enabled = true;
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(string.Concat(new object[] { "Error:", exception.Message, ", ErrorCode:", exception.ErrorCode }));
                    }
                }
            }
        }

        public void SynchronizeQueueToDB()
        {
           MessageController.GetInstance().SynchronizeQueueToDB();
        }

        public void ReceiveMessage()
        {
            GatewayLib.MessageController.ReceiveMessages();
        }

        void OnStop()
        {
             if (this.isRunning)
            {
                try
                {
                    this.lblNumberOfMsgFromQueue.Text = MessageController.NumberOfReceivedMsgFromQueue.ToString();
                    this.lblNumberOfMessageSentToBadQueue.Text = MessageController.NumberOfMsgSentToBadQueue.ToString();
                    this.lblNumberOfSentMessages.Text = MessageController.NumberOfSentMessage.ToString();
                    this.lblNumberOfMsgInsertedToDB.Text = MessageController.NumberOfMsgInsertedToDB.ToString();
                    MessageController.maxIDOfSent1IMsg = 0L;
                    MarketInfo.ResetMarketStatus();
                    BrokerageMessageQueue.StopSendMessagesToOutbox();
                    this.sendMessageThread.Abort();
                    this.sendMessageThread = null;
                    MessageController.StopReceiveMessage();
                    this.lblGatewayStatus.Text = "Gateway dừng hoạt động";
                    this.lblGatewayStatus.ForeColor = Color.Red;
                    this.isRunning = false;
                    this.mnuStart.Enabled = true;
                    this.mnuStop.Enabled = false;
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;
                    MessageController.InsertMessageToDB();
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(string.Concat(new object[] { "Error:", exception.Message, ", ErrorCode:", exception.ErrorCode }));
                }
                catch (Exception exception2)
                {
                    MessageBox.Show("Error:" + exception2.Message);
                }
            }
        }
        private void OnUpdate(string msg)
        {
            this.lstGAMessages.Items.Add(msg);
            this.lstGAMessages.SelectedIndex = this.lstGAMessages.Items.Count - 1;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            OnStart(null);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.OnStop();
            if (this.tmGAMsg.Enabled)
            {
                this.tmGAMsg.Stop();
                this.tmGAMsg.Enabled = false;
            }

        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            GatewayLogManager.Error("Total sent message(s):" + MessageController.NumberOfSentMessage);
            GatewayLogManager.Error("Total message(s) inserted to DB:" + MessageController.NumberOfMsgInsertedToDB);
            GatewayLogManager.Error("Total message(s) sent to bad queue:" + MessageController.NumberOfMsgSentToBadQueue);
            GatewayLogManager.Error("Total message(s) received from queue:" + MessageController.NumberOfReceivedMsgFromQueue);
            this.Exit();
        }

        private void btnViewBadQueue_Click(object sender, EventArgs e)
        {
            ViewBadQueueForm.Instance.Show();
        }
        private void ClearLB(string newMsg)
        {
            ClearListbox method = new ClearListbox(this.OnClear);
            this.lstGAMessages.Invoke(method, new object[] { newMsg });
        }
        private void OnClear(string msg)
        {
            this.lstGAMessages.Items.Clear();
        }
        private void DisplayData(string Data)
        {
            if (this.lstGAMessages.InvokeRequired)
            {
                SetDataCallback method = new SetDataCallback(this.DisplayData);
                base.Invoke(method, new object[] { Data });
            }
            else
            {
                this.lstGAMessages.Items.Add(Data);
            }
        }
         
        private void mnuStop_Click(object sender, EventArgs e)
        {
            OnStop();
            if (this.tmGAMsg.Enabled)
            {
                this.tmGAMsg.Stop();
                this.tmGAMsg.Enabled = false;
            }

        }

        private void mnuStart_Click(object sender, EventArgs e)
        {
            OnStart(null);
            if (!this.tmGAMsg.Enabled)
            {
                this.tmGAMsg.Enabled = true;
                this.tmGAMsg.Start();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            OnStop();
            Application.Exit();
            Environment.Exit(1);
        }               

        private void mnuManageQueue_Click(object sender, EventArgs e)
        {
            ManageQueueForm.GetInstance.Show(); 
        }

        private void mnuViewLiveLogs_Click(object sender, EventArgs e)
        {
            LiveLogsForm.GetInstance().Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("C\x00f3 chương tr\x00ecnh GatewayManager kh\x00e1c đang chạy. Bạn phải tắt chương tr\x00ecnh đ\x00f3 đi nếu muốn tiếp tục chạy GatewayManager.");
                Application.Exit();
            }
            this.updateInfoThread = new Thread(new ThreadStart(this.UpdateInfo));
            this.updateInfoThread.Start();
            this.tmGAMsg.Enabled = true;
            this.tmGAMsg.Start();

        }

        private void LoadGAMessages()
        {
            // Get GA Messages from DB
            string[] gAMessages = MessageController.GetGAMessages();
            int index = 0;
            int length = gAMessages.Length;
            if (length > this.iLength)
            {
                for (index = this.iLength; index < length; index++)
                {
                    this.UpdateLB(gAMessages[index]);
                    this.iLength++;
                }
            }
        }
        private void UpdateLB(string newMsg)
        {
            UpdateListbox method = new UpdateListbox(this.OnUpdate);
            this.lstGAMessages.Invoke(method, new object[] { newMsg });
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Phải dừng c\x00e1c tiến tr\x00ecnh trước khi tho\x00e1t (v\x00e0i gi\x00e2y). Đồng \x00fd dừng c\x00e1c tiến tr\x00ecnh v\x00e0 tho\x00e1t?", "X\x00e1c nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.tmGAMsg.Stop();
                this.tmGAMsg.Enabled = false;
                this.OnStop();
                Thread.Sleep(0x7d0);
                base.Close();
            }
        }

        private void tmGAMsg_Tick(object sender, EventArgs e)
        {
            LoadGAMessages();
        }
    }
}
