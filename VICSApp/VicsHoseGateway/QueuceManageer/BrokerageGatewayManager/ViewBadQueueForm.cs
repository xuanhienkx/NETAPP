using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using System.Reflection;
using System.Threading;
using GatewayLib;

namespace BrokerageGatewayManager
{
    public partial class ViewBadQueueForm : Form
    {
        static ViewBadQueueForm _instance = null;

        List<BadMessage> badMessages = null;
        List<string> badMessagesLabel = null;

        int savedMessagesCount = 0;
        public static ViewBadQueueForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewBadQueueForm();
                }
                return _instance;
            }
        }

        public ViewBadQueueForm()
        {
            InitializeComponent();
        }

        private void ViewBadQueueForm_Load(object sender, EventArgs e)
        {
            badMessages = BrokerageMessageQueue.GetBadMessages();
            if (badMessages == null || badMessages.Count <= 0) return;
            lblMessageCount.Text = badMessages.Count.ToString();
            badMessagesLabel = new List<string>();
            foreach (BadMessage item in badMessages)
            {
                badMessagesLabel.Add(item.Label);
            }
            lstMsg.DataSource = badMessagesLabel;
        }

        private void lstMsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.badMessagesLabel == null) return;
            int selectedIndex = this.lstMsg.SelectedIndex;
            if (selectedIndex < 0) return;
            BadMessage message = this.badMessages[selectedIndex];
            if (message == null) return;
            object content = message.Content;
            if (content == null) return;
            PropertyInfo[] properties = content.GetType().GetProperties();
            if ((properties == null) || (properties.Length == 0)) return;
            object obj3 = null;
            List<Entities.Message> list = new List<Entities.Message>();
            Entities.Message item = null;
            foreach (PropertyInfo info in properties)
            {
                obj3 = info.GetValue(content, null);
                item = new BrokerageGatewayManager.Entities.Message
                {
                    Name = info.Name
                };
                item.Value = obj3 != null ? obj3.ToString() : "null";
                list.Add(item);
            }
            this.grdBadMessageDetails.DataSource = list;
        }

        private void ViewBadQueueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnSaveBadMessages_Click(object sender, EventArgs e)
        {
            if (badMessagesLabel != null)
            {
                this.Cursor = Cursors.WaitCursor;
                int i = 0;
                try
                {
                    savedMessagesCount = 0;
                    for (i = 0; i < badMessages.Count; i++)
                    {
                        BadMessage badMsg = badMessages[i];
                        if (badMsg != null)
                        {
                            object badMsgContent = badMsg.Content;
                            if (badMsgContent != null)
                            {
                                badMsgContent.GetType().GetProperty("LAST_MODIFIED").SetValue(badMsgContent, DateTime.Now, null);
                                badMsgContent.GetType().GetProperty("MESSAGE_STATUS").SetValue(badMsgContent, 'R', null);
                                MessageController.InsertMessageToDB(badMsgContent);
                                MessageController.CommitChanges();
                                badMessagesLabel.RemoveAt(0);
                                BrokerageMessageQueue.RemoveBadMessage(badMsg.ID);
                                savedMessagesCount++;                                
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                    lblSavedMessages.Text = "Có " + savedMessagesCount + " message(s) đã được lưu vào database";
                    lstMsg.DataSource = null;
                    lstMsg.DataSource = badMessagesLabel;
                    MessageBox.Show("Thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstMsg.SelectedIndex;
            if (index >= 0)
            {
                BadMessage badMsg = badMessages[index];
                BrokerageMessageQueue.RemoveBadMessage(badMsg.ID);
                badMessagesLabel.RemoveAt(index);
                badMessages.RemoveAt(index);
                lstMsg.DataSource = null;//??? remove
                lstMsg.DataSource = badMessagesLabel;
                if (index < lstMsg.Items.Count && lstMsg.Items.Count > 0)
                {
                    lstMsg.SelectedIndex = index;
                }
                else if (lstMsg.Items.Count > 0)
                {
                    lstMsg.SelectedIndex = 0;
                }
            }
        }
    }
}
