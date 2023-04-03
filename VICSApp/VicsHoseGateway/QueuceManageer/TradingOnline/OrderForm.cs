using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GatewayLib;

namespace TradingOnline
{
    public partial class OrderForm : Form
    {
        GatewayDataContext gatewayDataContext = null;
        public OrderForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            HOGW_1C orderCancellation = new HOGW_1C();
            orderCancellation.FIRM = Convert.ToDecimal(txtFirm.Text);
            orderCancellation.MESSAGE_STATUS = 'N';
            orderCancellation.MESSAGE_TYPE = "1C";
            orderCancellation.ORDER_ENTRY_DATE = Convert.ToDecimal(DateTime.Today.ToString("ddMM"));
            orderCancellation.ORDER_NUMBER = Convert.ToDecimal(txtOrderNumber.Text);
            orderCancellation.LAST_MODIFIED = DateTime.Now;
            gatewayDataContext.HOGW_1Cs.InsertOnSubmit(orderCancellation);
            gatewayDataContext.SubmitChanges();
            MessageBox.Show("Place order successfully!");
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            gatewayDataContext = GatewayLib.GatewayManager.GetGatewayContext();
            cboMessageType.SelectedIndex = 0;
        }

        private void btnSubmit1_Click(object sender, EventArgs e)
        {
            HOGW_1D orderChange = new HOGW_1D();
            orderChange.FIRM = Convert.ToDecimal(txtFirm1.Text);
            orderChange.MESSAGE_STATUS = 'N';
            orderChange.MESSAGE_TYPE = "1D";
            orderChange.ORDER_ENTRY_DATE = Convert.ToDecimal(DateTime.Today.ToString("ddMM"));
            orderChange.ORDER_NUMBER = Convert.ToDecimal(txtOrderNumber1.Text);
            orderChange.CLIENT_ID = txtClientID.Text;
            orderChange.LAST_MODIFIED = DateTime.Now;
            orderChange.FILLER = " ";
            gatewayDataContext.HOGW_1Ds.InsertOnSubmit(orderChange);
            gatewayDataContext.SubmitChanges();
            MessageBox.Show("Place order successfully!");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string messageType = string.Empty;
            if (cboMessageType.SelectedIndex > -1)
            {
                messageType = cboMessageType.Items[cboMessageType.SelectedIndex].ToString();
            }
            switch (messageType)
            {
                case "1C":
                    HOGW_1C message1C = new HOGW_1C();
                    message1C.FIRM = 69;
                    message1C.LAST_MODIFIED = DateTime.Today;
                    message1C.MESSAGE_STATUS = 'N';
                    message1C.MESSAGE_TYPE = "1C";
                    message1C.ORDER_ENTRY_DATE = 1506;
                    message1C.ORDER_NUMBER = 1;
                    gatewayDataContext.HOGW_1Cs.InsertOnSubmit(message1C);
                    break;
                case "1D":
                    HOGW_1D message1D = new HOGW_1D();
                    message1D.CLIENT_ID = "CLIENT_ID";
                    message1D.FILLER = " ";
                    message1D.FIRM = 69;
                    message1D.LAST_MODIFIED = DateTime.Today;
                    message1D.MESSAGE_STATUS = 'N';
                    message1D.MESSAGE_TYPE = "1D";
                    message1D.ORDER_ENTRY_DATE = 1506;
                    message1D.ORDER_NUMBER = 1;
                    gatewayDataContext.HOGW_1Ds.InsertOnSubmit(message1D);
                    break;
                case "1E":
                    HOGW_1E message1E = new HOGW_1E();
                    message1E.ADD_CANCEL_FLAG = 'C';
                    message1E.BOARD = 'M';
                    message1E.CONTACT = "HT2D SOFTWARE";
                    message1E.FIRM = 69;
                    message1E.LAST_MODIFIED = DateTime.Today;
                    message1E.MESSAGE_STATUS = 'N';
                    message1E.MESSAGE_TYPE = "1E";
                    message1E.PRICE = 123;
                    message1E.SECURITY_SYMBOL = "SSI";
                    message1E.SIDE = 'S';
                    message1E.TIME = 101010;
                    message1E.TRADER_ID = "999";
                    message1E.VOLUME = 345;
                    gatewayDataContext.HOGW_1Es.InsertOnSubmit(message1E);
              
                    break;
                case "1F":
                    HOGW_1F message1F = new HOGW_1F();
                    message1F.LAST_MODIFIED = DateTime.Today;
                    message1F.MESSAGE_STATUS = 'N';
                    message1F.MESSAGE_TYPE = "1F";
                    message1F.FIRM = 69;
                    message1F.BOARD = 'M';
                    message1F.TRADER_ID = "999";
                    message1F.BUYER_CLIENT_ID = "CLIENT_ID";
                    message1F.BUYER_CLIENT_VOLUME = 99;
                    message1F.BUYER_FOREIGN_VOLUME = 99;
                    message1F.BUYER_MUTUAL_FUND_VOLUME = 99;
                    message1F.BUYER_PORTFOLIO_VOLUME = 99;
                    message1F.DEAL_ID = 20;
                    message1F.FILLER = " ";
                    message1F.FILLER1 = " ";
                    message1F.FILLER2 = " ";
                    message1F.SELLER_CLIENT_ID = "CLIENT_ID";
                    message1F.SELLER_CLIENT_VOLUME = 99;
                    message1F.SELLER_FOREIGN_VOLUME = 99;
                    message1F.SELLER_MUTUAL_FUND_VOLUME = 99;
                    message1F.SELLER_PORTFOLIO_VOLUME = 99;
                    message1F.PRICE = 123;
                    message1F.SECURITY_SYMBOL = "SSI";
                    gatewayDataContext.HOGW_1Fs.InsertOnSubmit(message1F);
                    break;
                case "1G":
                    HOGW_1G message1G = new HOGW_1G();
                    message1G.BOARD = 'M';
                    message1G.BROKER_CLIENT_VOLUME = 1;
                    message1G.BROKER_FOREIGN_VOLUME = 1;
                    message1G.BROKER_MUTUAL_FUND_VOLUME = 1;
                    message1G.BROKER_PORTFOLIO_VOLUME = 1;
                    message1G.BUYER_CONTRA_FIRM = 1;
                    message1G.BUYER_TRADER_ID = "999";
                    message1G.DEAL_ID = 1;
                    message1G.FILLER = " ";
                    message1G.FILLER1 = " ";
                    message1G.LAST_MODIFIED = DateTime.Today;
                    message1G.MESSAGE_STATUS = 'N';
                    message1G.MESSAGE_TYPE = "1G";
                    message1G.PRICE = 234;
                    message1G.SECURITY_SYMBOL = "SSI";
                    message1G.SELLER_CLIENT_ID = "CLIENT_ID";
                    message1G.SELLER_FIRM = 123;
                    message1G.SELLER_TRADER_ID = "999";
                    gatewayDataContext.HOGW_1Gs.InsertOnSubmit(message1G);
                    break;
                case "1I":
                    HOGW_1I message1I = new HOGW_1I();
                    message1I.BOARD = 'M';
                    message1I.CLIENT_ID = "CLIENT_ID";
                    message1I.FILLER = " ";
                    message1I.FILLER1 = " ";
                    message1I.FIRM=69;
                    message1I.LAST_MODIFIED = DateTime.Today;
                    message1I.MESSAGE_STATUS = 'N';
                    message1I.MESSAGE_TYPE = "1I";
                    message1I.ORDER_NUMBER=123;
                    message1I.PORT_CLIENT_FLAG='C';
                    message1I.PRICE="123";
                    message1I.PUBLISHED_VOLUME=123;
                    message1I.SECURITY_SYMBOL="SSI";
                    message1I.SIDE='S';
                    message1I.TRADER_ID="999";
                    message1I.VOLUME=234;
                    gatewayDataContext.HOGW_1Is.InsertOnSubmit(message1I);
                    break;

                case "LO":
                    HOSE_LO messageLO = new HOSE_LO();
                    messageLO.CONFIRM_NUMBER = 1;
                    messageLO.LAST_MODIFIED = DateTime.Today;
                    messageLO.MESSAGE_STATUS = 'N';
                    messageLO.MESSAGE_TYPE = "LO";
                    messageLO.ODD_LOT_VOLUME = 1234;
                    messageLO.PRICE = 123;
                    messageLO.REFERENCE_NUMBER = 123;
                    messageLO.SECURITY_NUMBER = 1234;
                    gatewayDataContext.HOSE_LOs.InsertOnSubmit(messageLO);
                    break;
                default:
                    break;
            }
            gatewayDataContext.SubmitChanges();
            MessageBox.Show("OK");
        }
    }
}
