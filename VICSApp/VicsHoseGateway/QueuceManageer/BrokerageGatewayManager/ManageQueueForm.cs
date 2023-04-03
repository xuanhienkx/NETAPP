using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GatewayLib;

namespace BrokerageGatewayManager
{
    public partial class ManageQueueForm : Form
    {
        static ManageQueueForm _instance = null;

        public static ManageQueueForm GetInstance       
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManageQueueForm();
                }
                return _instance;
            }
        }

        public ManageQueueForm()
        {
            InitializeComponent();
        }

        private void btnViewBadQueue_Click(object sender, EventArgs e)
        {
            ViewBadQueueForm.Instance.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            #region oldecode
            /*int retValue = -2;
            if (chkInboxQueue.Checked)
            {
                retValue = BrokerageMessageQueue.ClearQueue("InboxQueue");
                if (retValue == 1)
                {
                    MessageBox.Show("Clear InboxQueue thành công");
                }
                else if (retValue == 0)
                {
                    MessageBox.Show("Có lỗi khi xóa InboxQueue. Hãy check file Log.txt");
                }
                else if (retValue == -1)
                {
                    MessageBox.Show("InboxQueue không tồn tại");
                }
            }
            if (chkOutboxQueue.Checked)
            {
                retValue = BrokerageMessageQueue.ClearQueue("OutboxQueue");
                if (retValue == 1)
                {
                    MessageBox.Show("Clear OutboxQueue thành công");
                }
                else if (retValue == 0)
                {
                    MessageBox.Show("Có lỗi khi xóa OutboxQueue. Hãy check file Log.txt");
                }
                else if (retValue == -1)
                {
                    MessageBox.Show("OutboxQueue không tồn tại");
                }
            }
            if (chkInternalQueue.Checked)
            {
                retValue = BrokerageMessageQueue.ClearQueue("InternalQueue");
                if (retValue == 1)
                {
                    MessageBox.Show("Clear InternalQueue thành công");
                }
                else if (retValue == 0)
                {
                    MessageBox.Show("Có lỗi khi xóa InternalQueue. Hãy check file Log.txt");
                }
                else if (retValue == -1)
                {
                    MessageBox.Show("InternalQueue không tồn tại");
                }
            }
            if (chkBadQueue.Checked)
            {
                retValue = BrokerageMessageQueue.ClearQueue("BadQueue");
                if (retValue == 1)
                {
                    MessageBox.Show("Clear BadQueue thành công");
                }
                else if (retValue == 0)
                {
                    MessageBox.Show("Có lỗi khi xóa BadQueue. Hãy check file Log.txt");
                }
                else if (retValue == -1)
                {
                    MessageBox.Show("BadQueue không tồn tại");
                }
            }*/
            #endregion
            if (this.chkInboxQueue.Checked)
            {
                switch (BrokerageMessageQueue.ClearQueue("InboxQueue"))
                {
                    case 1:
                        MessageBox.Show(@"Clear InboxQueue thành công");
                        break;

                    case 0:
                        MessageBox.Show(@"Có lỗi khi xóa InboxQueue. Hãy check file Log.txt");
                        break;

                    case -1:
                        MessageBox.Show(@"InboxQueue không tồn tại");
                        break;
                }
            }
            if (this.chkOutboxQueue.Checked)
            {
                switch (BrokerageMessageQueue.ClearQueue("OutboxQueue"))
                {
                    case 1:
                        MessageBox.Show(@"Clear OutboxQueue thành công");
                        break;

                    case 0:
                        MessageBox.Show(@"Có lỗi khi xóa OutboxQueue. Hãy check file Log.txt");
                        break;

                    case -1:
                        MessageBox.Show(@"OutboxQueue không tồn tại");
                        break;
                }
            }
            if (this.chkInternalQueue.Checked)
            {
                switch (BrokerageMessageQueue.ClearQueue("InternalQueue"))
                {
                    case 1:
                        MessageBox.Show(@"Clear InternalQueue thành công");
                        break;

                    case 0:
                        MessageBox.Show(@"Có lỗi khi xóa InternalQueue. Hãy check file Log.txt");
                        break;

                    case -1:
                        MessageBox.Show(@"InternalQueue không tồn tại");
                        break;
                }
            }
            if (this.chkBadQueue.Checked)
            {
                switch (BrokerageMessageQueue.ClearQueue("BadQueue"))
                {
                    case 1:
                        MessageBox.Show(@"Clear BadQueue thành công");
                        break;

                    case 0:
                        MessageBox.Show(@"Có lỗi khi xóa BadQueue. Hãy check file Log.txt");
                        break;

                    case -1:
                        MessageBox.Show(@"BadQueue không tồn tại");
                        break;
                }
            }
        }

        private void ManageQueueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
