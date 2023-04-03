using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GatewayLib;
using GatewayLib.Data.Entities;
using System.Reflection;

namespace BrokerageGatewayManager
{
    public partial class LiveLogsForm : Form
    {
        static LiveLogsForm _instance = null; 
        public static LiveLogsForm GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LiveLogsForm();
            }
            return _instance;
        }

        public LiveLogsForm()
        {
            InitializeComponent();
        }

        private void LiveLogsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LiveLogManager.TurnOffLiveLog();
            LiveLogManager.UnRegisterCallbackControls(true);
            LiveLogManager.UnRegisterCallbackControls(false);
            _instance = null;
        }

        private void numCTCITLogSize_ValueChanged(object sender, EventArgs e)
        {
            LiveLogManager.SetCTCILogSize((int)numCTCITLogSize.Value);
        }

        private void numBroadcastLogSize_ValueChanged(object sender, EventArgs e)
        {
            LiveLogManager.SetBroadcastLogSize((int)numBroadcastLogSize.Value);
        }

        private void turnOffLiveLogs_Click(object sender, EventArgs e)
        {
            turnOffLiveLogs.Enabled = false;
            turnOnLiveLogs.Enabled = true;
            LiveLogManager.TurnOffLiveLog();
        }

        private void turnOnLiveLogs_Click(object sender, EventArgs e)
        {
            btnTurnOnBroadcastLogs.Enabled = false;
            btnTurnOnCTCILogs.Enabled = false;
            btnStopViewBroadcastLogs.Enabled = true;
            btnStopViewCTCILogs.Enabled = true;

            LiveLogManager.SetCTCILogSize((int)numCTCITLogSize.Value);
            LiveLogManager.SetBroadcastLogSize((int)numBroadcastLogSize.Value);

            turnOffLiveLogs.Enabled = true;
            turnOnLiveLogs.Enabled = false;
            //viewLogTimer.Enabled = true;
            LiveLogManager.TurnOnLiveLog();
            LiveLogManager.RegisterCallbackControl(true, lstCTCILogs);
            LiveLogManager.RegisterCallbackControl(true, lblNumberOfSentMessages);
            LiveLogManager.RegisterCallbackControl(true, lblNumberOfReceivedMessages);

            LiveLogManager.RegisterCallbackControl(false, lstBroadcastLogs);
            LiveLogManager.RegisterCallbackControl(false, lblNumberOfBroadcastMessages);
        }

        private void btnClearCTCILogs_Click(object sender, EventArgs e)
        {
            lstCTCILogs.Items.Clear();
            LiveLogManager.ClearCTCILogs();
        }

        private void btnClearBroadcastLogs_Click(object sender, EventArgs e)
        {
            lstBroadcastLogs.Items.Clear();
            LiveLogManager.ClearBroadcastLogs();
        }

        private void btnStopViewCTCILogs_Click(object sender, EventArgs e)
        {
            btnStopViewCTCILogs.Enabled = false;
            btnTurnOnCTCILogs.Enabled = true;
            LiveLogManager.TurnOffCTCILog();
        }

        private void btnTurnOnCTCILogs_Click(object sender, EventArgs e)
        {
            btnStopViewCTCILogs.Enabled = true;
            btnTurnOnCTCILogs.Enabled = false;
            LiveLogManager.TurnOnCTCILog();
        }

        private void btnStopViewBroadcastLogs_Click(object sender, EventArgs e)
        {
            btnStopViewBroadcastLogs.Enabled = false;
            btnTurnOnBroadcastLogs.Enabled = true;
            LiveLogManager.TurnOffBroadcastLog();
        }

        private void btnTurnOnBroadcastLogs_Click(object sender, EventArgs e)
        {
            btnStopViewBroadcastLogs.Enabled = true;
            btnTurnOnBroadcastLogs.Enabled = false;
            LiveLogManager.TurnOnBroadcastLog();
        }

        private void LiveLogsForm_Load(object sender, EventArgs e)
        {
            if (LiveLogManager.LiveLogIsOn())
            {
                turnOffLiveLogs.Enabled = true;
                turnOnLiveLogs.Enabled = false;

                //viewLogTimer.Enabled = true;
                //viewLogTimer.Start();
            }
            else
            {
                turnOffLiveLogs.Enabled = false;
                turnOnLiveLogs.Enabled = true;

                //viewLogTimer.Enabled = false;
            }
        }

        private void ViewCTCILogsDetail()
        {
            int selectedIndex = lstCTCILogs.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            }
            LogMessage cTCILogMessage = LiveLogManager.GetCTCILogMessage(selectedIndex);
            if (cTCILogMessage != null)
            {
                object messageContent = cTCILogMessage.MessageContent;
                if (messageContent != null)
                {
                    PropertyInfo[] properties = messageContent.GetType().GetProperties();
                    if ((properties != null) && (properties.Length != 0))
                    {
                        object obj3 = null;
                        List<BrokerageGatewayManager.Entities.Message> list = new List<BrokerageGatewayManager.Entities.Message>();
                        BrokerageGatewayManager.Entities.Message item = null;
                        foreach (PropertyInfo info in properties)
                        {
                            obj3 = info.GetValue(messageContent, null);
                            item = new BrokerageGatewayManager.Entities.Message
                            {
                                Name = info.Name
                            };
                            if (obj3 != null)
                            {
                                item.Value = obj3.ToString();
                            }
                            else
                            {
                                item.Value = "null";
                            }
                            list.Add(item);
                        }
                        this.grdCTCIDetails.DataSource = list;
                    }
                }
            }
        }

        private void ViewBroadcastLogsDetail()
        {
            int selectedIndex = lstBroadcastLogs.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            } 
            LogMessage broadcastLogMessage = LiveLogManager.GetBroadcastLogMessage(selectedIndex);
            if (broadcastLogMessage != null)
            {
                object messageContent = broadcastLogMessage.MessageContent;
                if (messageContent != null)
                {
                    PropertyInfo[] properties = messageContent.GetType().GetProperties();
                    if ((properties != null) && (properties.Length != 0))
                    {
                        object obj3 = null;
                        List<BrokerageGatewayManager.Entities.Message> list = new List<BrokerageGatewayManager.Entities.Message>();
                        BrokerageGatewayManager.Entities.Message item = null;
                        foreach (PropertyInfo info in properties)
                        {
                            obj3 = info.GetValue(messageContent, null);
                            item = new BrokerageGatewayManager.Entities.Message
                            {
                                Name = info.Name
                            };
                            if (obj3 != null)
                            {
                                item.Value = obj3.ToString();
                            }
                            else
                            {
                                item.Value = "null";
                            }
                            list.Add(item);
                        }
                        this.grdBroadcastDetails.DataSource = list;
                    }
                }
            }
        }

        private void lstCTCILogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewCTCILogsDetail();
        }

        private void lstBroadcastLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewBroadcastLogsDetail();
        }        
    }
}
