using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using InterStock;
using GWStock;

namespace HOGW_CoreConnector
{
    public partial class frmTestCaseExec : Form
    {

        private Database DbHOGW;

        public frmTestCaseExec()
        {
            this.InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStockCode.Text))
            {
                MessageBox.Show("Null or Empty security symbol!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtStockCode.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtCustomerID.Text))
            {
                MessageBox.Show("Null or Empty CustomerID!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCustomerID.Focus();
            }
            else if (this.txtCustomerID.Text.Trim().Length != 10)
            {
                MessageBox.Show("CustomerID's length is invalid (#10)!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCustomerID.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtVolume.Text))
            {
                MessageBox.Show("Null or Empty volume!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtVolume.Focus();
            }
            else if (this.cboOrderType.SelectedIndex < 0)
            {
                MessageBox.Show("OrderType is in invalid index!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboOrderType.Focus();
            }
            else if (MessageBox.Show("Really want to enter this batch of orders!", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                int num;
                if (this.cboOrderType.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(this.txtPrice.Text))
                    {
                        MessageBox.Show("Null or Empty price!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    string[] strArray = this.txtStockCode.Text.Split(new char[] { ',' });
                    if (strArray.Length > 1)
                    {
                        if (MessageBox.Show("Only ONE stock code can be inserted with LO order. Do you want to insert order with the first stock code?", "Validation", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                        long orderNumber = Convert.ToInt64(this.txtOrderNumber.Text);
                        for (num = 0; num < this.udOrderCount.Value; num++)
                        {
                            this.InsertOrder(orderNumber, this.txtCustomerID.Text, strArray[0], this.cboOrderSide.Text, Convert.ToInt32(this.txtVolume.Text), this.txtPrice.Text);
                            orderNumber += 1L;
                        }
                        this.txtOrderNumber.Text = orderNumber.ToString();
                    }
                    else
                    {
                        long num3 = Convert.ToInt64(this.txtOrderNumber.Text);
                        for (num = 0; num < this.udOrderCount.Value; num++)
                        {
                            this.InsertOrder(num3, this.txtCustomerID.Text, strArray[0], this.cboOrderSide.Text, Convert.ToInt32(this.txtVolume.Text), this.txtPrice.Text);
                            num3 += 1L;
                        }
                        this.txtOrderNumber.Text = num3.ToString();
                    }
                }
                else
                {
                    string[] stockCodes = this.txtStockCode.Text.Split(new char[] { ',' });
                    long orderNumberBegin = Convert.ToInt64(this.txtOrderNumber.Text);
                    for (num = 0; num < this.udOrderCount.Value; num++)
                    {
                        orderNumberBegin = this.InsertOrders(orderNumberBegin, this.txtCustomerID.Text, stockCodes, this.cboOrderSide.Text, Convert.ToInt32(this.txtVolume.Text), this.cboOrderType.Text);
                    }
                    this.txtOrderNumber.Text = orderNumberBegin.ToString();
                }
                MessageBox.Show("MATCHING ORDER - Successfully inserted!");
            }
        }

        private void btnEnter1FirmDeal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStockCode1Firm.Text))
            {
                MessageBox.Show("Null or Empty security symbol!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtStockCode1Firm.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtVolume1Firm.Text))
            {
                MessageBox.Show("Null or Empty volume!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtVolume1Firm.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtSellerClientID1Firm.Text))
            {
                MessageBox.Show("Null or Empty Seller Client ID!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSellerClientID1Firm.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtBuyerClientID1Firm.Text))
            {
                MessageBox.Show("Null or Empty Buyer Client ID!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtBuyerClientID1Firm.Focus();
            }
            else if (this.cboOrderType1Firm.SelectedIndex < 0)
            {
                MessageBox.Show("OrderType is in invalid index!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboOrderType1Firm.Focus();
            }
            else if (MessageBox.Show("Really want to enter this batch of ONE-FIRM DEALS!", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                int num;
                if (this.cboOrderType1Firm.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(this.txtPrice1Firm.Text))
                    {
                        MessageBox.Show("Null or Empty price!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    string[] strArray = this.txtStockCode1Firm.Text.Split(new char[] { ',' });
                    if (strArray.Length > 1)
                    {
                        if (MessageBox.Show("Only ONE stock code can be inserted with LO order. Do you want to insert order with the first stock code?", "Validation", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                        long dealID = Convert.ToInt64(this.txtDealID1Firm.Text);
                        for (num = 0; num < this.ud1FirmDealCount.Value; num++)
                        {
                            this.Insert1Firm(strArray[0], Convert.ToInt64(this.txtVolume1Firm.Text), Convert.ToDouble(this.txtPrice1Firm.Text), this.txtSellerClientID1Firm.Text, this.txtBuyerClientID1Firm.Text, this.cboBoardType1Firm.Text, dealID);
                            dealID += 3L;
                        }
                        this.txtDealID1Firm.Text = dealID.ToString();
                    }
                    else
                    {
                        long num3 = Convert.ToInt64(this.txtDealID1Firm.Text);
                        for (num = 0; num < this.ud1FirmDealCount.Value; num++)
                        {
                            this.Insert1Firm(strArray[0], Convert.ToInt64(this.txtVolume1Firm.Text), Convert.ToDouble(this.txtPrice1Firm.Text), this.txtSellerClientID1Firm.Text, this.txtBuyerClientID1Firm.Text, this.cboBoardType1Firm.Text, num3);
                            num3 += 3L;
                        }
                        this.txtDealID1Firm.Text = num3.ToString();
                    }
                }
                else
                {
                    string[] stockCodes = this.txtStockCode1Firm.Text.Split(new char[] { ',' });
                    long dealIDBegin = Convert.ToInt64(this.txtDealID1Firm.Text);
                    for (num = 0; num < this.ud1FirmDealCount.Value; num++)
                    {
                        dealIDBegin = this.Insert1Firms(stockCodes, Convert.ToInt64(this.txtVolume1Firm.Text), this.cboOrderType1Firm.Text, this.txtSellerClientID1Firm.Text, this.txtBuyerClientID1Firm.Text, this.cboBoardType1Firm.Text, dealIDBegin);
                    }
                    this.txtDealID1Firm.Text = dealIDBegin.ToString();
                }
                MessageBox.Show("1 FIRM DEAL - Successfully inserted!");
            }
        }

        private void btnEnter2FirmDeal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStockCode2Firm.Text))
            {
                MessageBox.Show("Null or Empty security symbol!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtStockCode2Firm.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtVolume2Firm.Text))
            {
                MessageBox.Show("Null or Empty volume!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtVolume2Firm.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtSellerClient2Firm.Text))
            {
                MessageBox.Show("Null or Empty Seller Client ID!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSellerClient2Firm.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtBuyerFirm2Firm.Text))
            {
                MessageBox.Show("Null or Empty Buyer Firm!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtBuyerClientID1Firm.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtBuyerTraderID2Firm.Text))
            {
                MessageBox.Show("Null or Empty Buyer Trader ID!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtBuyerTraderID2Firm.Focus();
            }
            else if (this.cboOrderType2Firm.SelectedIndex < 0)
            {
                MessageBox.Show("OrderType is in invalid index!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboOrderType2Firm.Focus();
            }
            else if (MessageBox.Show("Really want to enter this batch of TWO-FIRM DEALS!", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                int num;
                if (this.cboOrderType2Firm.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(this.txtPrice2Firm.Text))
                    {
                        MessageBox.Show("Null or Empty price!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    string[] strArray = this.txtStockCode2Firm.Text.Split(new char[] { ',' });
                    if (strArray.Length > 1)
                    {
                        if (MessageBox.Show("Only ONE stock code can be inserted with LO order. Do you want to insert order with the first stock code?", "Validation", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                        long dealID = Convert.ToInt64(this.txtDealID2Firm.Text);
                        for (num = 0; num < this.ud2FirmDealCount.Value; num++)
                        {
                            this.Insert2Firm(strArray[0], Convert.ToInt64(this.txtVolume2Firm.Text), Convert.ToDouble(this.txtPrice2Firm.Text), this.txtSellerClient2Firm.Text, Convert.ToInt32(this.txtBuyerFirm2Firm.Text), this.txtBuyerTraderID2Firm.Text, this.cboBoardType2Firm.Text, dealID);
                            dealID += 3L;
                        }
                        this.txtDealID2Firm.Text = dealID.ToString();
                    }
                    else
                    {
                        long num3 = Convert.ToInt64(this.txtDealID2Firm.Text);
                        for (num = 0; num < this.ud2FirmDealCount.Value; num++)
                        {
                            this.Insert2Firm(strArray[0], Convert.ToInt64(this.txtVolume2Firm.Text), Convert.ToDouble(this.txtPrice2Firm.Text), this.txtSellerClient2Firm.Text, Convert.ToInt32(this.txtBuyerFirm2Firm.Text), this.txtBuyerTraderID2Firm.Text, this.cboBoardType2Firm.Text, num3);
                            num3 += 3L;
                        }
                        this.txtDealID2Firm.Text = num3.ToString();
                    }
                }
                else
                {
                    string[] stockCodes = this.txtStockCode2Firm.Text.Split(new char[] { ',' });
                    long dealIDBegin = Convert.ToInt64(this.txtDealID2Firm.Text);
                    for (num = 0; num < this.ud2FirmDealCount.Value; num++)
                    {
                        dealIDBegin = this.Insert2Firms(stockCodes, Convert.ToInt64(this.txtVolume1Firm.Text), this.cboOrderType2Firm.Text, this.txtSellerClient2Firm.Text, Convert.ToInt32(this.txtBuyerFirm2Firm.Text), this.txtBuyerTraderID2Firm.Text, this.cboBoardType2Firm.Text, dealIDBegin);
                    }
                    this.txtDealID2Firm.Text = dealIDBegin.ToString();
                }
                MessageBox.Show("2 FIRM DEAL - Successfully inserted!");
            }
        }

        private void btnEnterAdv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStockCodeAdv.Text))
            {
                MessageBox.Show("Null or Empty security symbol!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtStockCodeAdv.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtVolumeAdv.Text))
            {
                MessageBox.Show("Null or Empty volume!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtVolumeAdv.Focus();
            }
            else if (this.cboOrderTypeAdv.SelectedIndex < 0)
            {
                MessageBox.Show("OrderType is in invalid index!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboOrderTypeAdv.Focus();
            }
            else if (MessageBox.Show("Really want to enter this batch of ADVERTISEMENT!", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                int num;
                if (this.cboOrderTypeAdv.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(this.txtPriceAdv.Text))
                    {
                        MessageBox.Show("Null or Empty price!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    string[] strArray = this.txtStockCodeAdv.Text.Split(new char[] { ',' });
                    if (strArray.Length > 1)
                    {
                        if (MessageBox.Show("Only ONE stock code can be inserted with LO order. Do you want to insert order with the first stock code?", "Validation", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                        for (num = 0; num < this.udAdvCount.Value; num++)
                        {
                            this.InsertAdv(strArray[0], this.cboSideAdv.Text, Convert.ToInt64(this.txtVolumeAdv.Text), Convert.ToDouble(this.txtPriceAdv.Text), this.cboAddOrCancel.Text, this.cboBoardTypeAdv.Text);
                        }
                    }
                    else
                    {
                        num = 0;
                        while (num < this.udAdvCount.Value)
                        {
                            this.InsertAdv(strArray[0], this.cboSideAdv.Text, Convert.ToInt64(this.txtVolumeAdv.Text), Convert.ToDouble(this.txtPriceAdv.Text), this.cboAddOrCancel.Text, this.cboBoardTypeAdv.Text);
                            num++;
                        }
                    }
                }
                else
                {
                    string[] stockCodes = this.txtStockCodeAdv.Text.Split(new char[] { ',' });
                    for (num = 0; num < this.udAdvCount.Value; num++)
                    {
                        this.InsertAdvs(stockCodes, this.cboSideAdv.Text, Convert.ToInt64(this.txtVolumeAdv.Text), this.cboOrderTypeAdv.Text, this.cboAddOrCancel.Text, this.cboBoardTypeAdv.Text);
                    }
                }
                MessageBox.Show("ADVERTISEMENT - Successfully inserted!");
            }
        }

        private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboOrderType.SelectedIndex != 0)
            {
                this.txtPrice.BackColor = Color.Gray;
                this.txtPrice.Enabled = false;
            }
            else
            {
                this.txtPrice.BackColor = Color.White;
                this.txtPrice.Enabled = true;
            }
        }

        private void cboOrderType1Firm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboOrderType1Firm.SelectedIndex != 0)
            {
                this.txtPrice1Firm.BackColor = Color.Gray;
                this.txtPrice1Firm.Enabled = false;
            }
            else
            {
                this.txtPrice1Firm.BackColor = Color.White;
                this.txtPrice1Firm.Enabled = true;
            }
        }

        private void cboOrderType2Firm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboOrderType2Firm.SelectedIndex != 0)
            {
                this.txtPrice2Firm.BackColor = Color.Gray;
                this.txtPrice2Firm.Enabled = false;
            }
            else
            {
                this.txtPrice2Firm.BackColor = Color.White;
                this.txtPrice2Firm.Enabled = true;
            }
        }

        private void cboOrderTypeAdv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboOrderTypeAdv.SelectedIndex != 0)
            {
                this.txtPriceAdv.BackColor = Color.Gray;
                this.txtPriceAdv.Enabled = false;
            }
            else
            {
                this.txtPriceAdv.BackColor = Color.White;
                this.txtPriceAdv.Enabled = true;
            }
        }


        private void frmTestCaseExec_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    this.btnEnter_Click(sender, e);
                    return;

                case Keys.F2:
                    this.btnEnterAdv_Click(sender, e);
                    return;

                case Keys.F3:
                    this.btnEnter1FirmDeal_Click(sender, e);
                    return;

                case Keys.F4:
                    this.btnEnter2FirmDeal_Click(sender, e);
                    return;

                case Keys.F5:
                    this.txtStockCode.Focus();
                    return;

                case Keys.F6:
                    this.txtStockCodeAdv.Focus();
                    return;

                case Keys.F7:
                    this.txtStockCode1Firm.Focus();
                    return;

                case Keys.F8:
                    this.txtStockCode2Firm.Focus();
                    return;
            }
        }

        private void frmTestCaseExec_Load(object sender, EventArgs e)
        {
            this.DbHOGW = DatabaseFactory.CreateDatabase();
            if (this.DbHOGW != null)
            {
                this.ttipStatus.Text = "All database are connected!";
                this.timerMarketStatus.Enabled = true;
            }
            else
            {
                this.ttipStatus.Text = "All database are not connected!";
                this.timerMarketStatus.Enabled = false;
            }
            this.ttipMarketStatus.Text = "Last SU day: " + GWMarket.getLastTradingDaySU(this.DbHOGW) + ", Market status: " + GWMarket.getMarketStatusHOSE(this.DbHOGW);
            this.ttipSystem.Text = "";
            this.timerSystem.Enabled = true;
            this.ttipTimer.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.cboOrderSide.Items.Clear();
            this.cboOrderSide.Items.Add("B");
            this.cboOrderSide.Items.Add("S");
            this.cboOrderSide.SelectedIndex = 0;
            this.cboOrderType.Items.Clear();
            this.cboOrderType.Items.Add("LO");
            this.cboOrderType.Items.Add("ATO");
            this.cboOrderType.Items.Add("ATC");
            this.cboOrderType.Items.Add("MP");
            this.cboOrderType.Items.Add("REFERENCE");
            this.cboOrderType.Items.Add("CEILING");
            this.cboOrderType.Items.Add("FLOOR");
            this.cboOrderType.Items.Add("AVGERAGE ( REF , CEILING )");
            this.cboOrderType.Items.Add("AVGERAGE ( REF, FLOOR )");
            this.cboOrderType.SelectedIndex = 0;
            this.txtStockCode.Text = "";
            this.txtVolume.Text = "1000";
            object obj2 = this.DbHOGW.ExecuteScalar(CommandType.Text, "select isnull(max(Order_Number),0)+1 from HOGW_1I");
            if (obj2 != null)
            {
                this.txtOrderNumber.Text = obj2.ToString().Trim();
            }
            this.cboSideAdv.Items.Clear();
            this.cboSideAdv.Items.Add("B");
            this.cboSideAdv.Items.Add("S");
            this.cboSideAdv.SelectedIndex = 0;
            this.cboOrderTypeAdv.Items.Clear();
            this.cboOrderTypeAdv.Items.Add("LO");
            this.cboOrderTypeAdv.Items.Add("REFERENCE");
            this.cboOrderTypeAdv.Items.Add("CEILING");
            this.cboOrderTypeAdv.Items.Add("FLOOR");
            this.cboOrderTypeAdv.Items.Add("AVGERAGE ( REF , CEILING )");
            this.cboOrderTypeAdv.Items.Add("AVGERAGE ( REF, FLOOR )");
            this.cboOrderTypeAdv.SelectedIndex = 0;
            this.txtStockCodeAdv.Text = "";
            this.txtVolumeAdv.Text = "50000";
            this.cboAddOrCancel.Items.Clear();
            this.cboAddOrCancel.Items.Add("A");
            this.cboAddOrCancel.Items.Add("C");
            this.cboAddOrCancel.SelectedIndex = 0;
            this.cboBoardTypeAdv.Items.Clear();
            this.cboBoardTypeAdv.Items.Add(CommonSettings.BoardPT);
            this.cboBoardTypeAdv.Items.Add(CommonSettings.BoardOdd);
            this.cboBoardTypeAdv.SelectedIndex = 0;
            this.cboOrderType1Firm.Items.Clear();
            this.cboOrderType1Firm.Items.Add("LO");
            this.cboOrderType1Firm.Items.Add("REFERENCE");
            this.cboOrderType1Firm.Items.Add("CEILING");
            this.cboOrderType1Firm.Items.Add("FLOOR");
            this.cboOrderType1Firm.Items.Add("AVGERAGE ( REF , CEILING )");
            this.cboOrderType1Firm.Items.Add("AVGERAGE ( REF, FLOOR )");
            this.cboOrderType1Firm.SelectedIndex = 0;
            this.txtStockCode1Firm.Text = "";
            this.txtVolume1Firm.Text = "20000";
            this.cboBoardType1Firm.Items.Clear();
            this.cboBoardType1Firm.Items.Add(CommonSettings.BoardPT);
            this.cboBoardType1Firm.Items.Add(CommonSettings.BoardOdd);
            this.cboBoardType1Firm.SelectedIndex = 0;
            obj2 = this.DbHOGW.ExecuteScalar(CommandType.Text, "select 3*(Convert(int,isnull(max(deal_id),0)/3)+1)+1 from HOGW_1F");
            if (obj2 != null)
            {
                this.txtDealID1Firm.Text = obj2.ToString().Trim();
            }
            this.cboOrderType2Firm.Items.Clear();
            this.cboOrderType2Firm.Items.Add("LO");
            this.cboOrderType2Firm.Items.Add("REFERENCE");
            this.cboOrderType2Firm.Items.Add("CEILING");
            this.cboOrderType2Firm.Items.Add("FLOOR");
            this.cboOrderType2Firm.Items.Add("AVGERAGE ( REF , CEILING )");
            this.cboOrderType2Firm.Items.Add("AVGERAGE ( REF, FLOOR )");
            this.cboOrderType2Firm.SelectedIndex = 0;
            this.cboOrderType2Firm.Text = "";
            this.txtVolume2Firm.Text = "40000";
            this.cboBoardType2Firm.Items.Clear();
            this.cboBoardType2Firm.Items.Add(CommonSettings.BoardPT);
            this.cboBoardType2Firm.Items.Add(CommonSettings.BoardOdd);
            this.cboBoardType2Firm.SelectedIndex = 0;
            obj2 = this.DbHOGW.ExecuteScalar(CommandType.Text, "select 3*(Convert(int,isnull(max(deal_id),0)/3)+1)+2 from HOGW_1G");
            if (obj2 != null)
            {
                this.txtDealID2Firm.Text = obj2.ToString().Trim();
            }
        }

        private void frmTestCaseExec_SizeChanged(object sender, EventArgs e)
        {
            int num = 3;
            int width = base.Width;
            int height = base.Height;
            int num4 = (width - (4 * num)) - 10;
            int num5 = ((height - this.toolStripStatusLabel1.Height) - (4 * num)) - 30;
            int num6 = (num4 / 2) - 1;
            int num7 = (num5 / 2) - 1;
            this.groupBox1.Top = num;
            this.groupBox1.Left = num;
            this.groupBox1.Width = num6;
            this.groupBox1.Height = num7;
            this.groupBox2.Top = this.groupBox1.Top;
            this.groupBox2.Left = (this.groupBox1.Left + num6) + num;
            this.groupBox2.Width = num6;
            this.groupBox2.Height = num7;
            this.groupBox3.Top = (this.groupBox1.Top + num7) + num;
            this.groupBox3.Left = this.groupBox1.Left;
            this.groupBox3.Width = num6;
            this.groupBox3.Height = num7;
            this.groupBox4.Top = this.groupBox3.Top;
            this.groupBox4.Left = this.groupBox2.Left;
            this.groupBox4.Width = num6;
            this.groupBox4.Height = num7;
        }

        private string getLOPrice(string orderType, bool isPT)
        {
            if (isPT)
            {
                switch (orderType)
                {
                    case "REFERENCE":
                        return "CONVERT(VARCHAR,1000000 * CONVERT(NUMERIC(12,1),(F.CEILING_PRICE + F.FLOOR_PRICE)/2)) AS PRICE ";

                    case "CEILING":
                        return "CONVERT(VARCHAR,1000000 * CONVERT(NUMERIC(12,1),F.CEILING_PRICE)) AS PRICE ";

                    case "FLOOR":
                        return "CONVERT(VARCHAR,1000000 * CONVERT(NUMERIC(12,1),F.FLOOR_PRICE)) AS PRICE ";

                    case "CEILING - 1":
                        return "CONVERT(VARCHAR,1000000*CONVERT(NUMERIC(12,1),F.CEILING_PRICE - 1)) AS PRICE ";

                    case "FLOOR + 1":
                        return "CONVERT(VARCHAR,1000000*CONVERT(NUMERIC(12,1),F.FLOOR_PRICE + 1)) AS PRICE ";

                    case "AVGERAGE ( REF , CEILING )":
                        return "CONVERT(VARCHAR,1000000*CONVERT(NUMERIC(12,1),(3*F.CEILING_PRICE + F.FLOOR_PRICE)/4)) AS PRICE ";

                    case "AVGERAGE ( REF, FLOOR )":
                        return "CONVERT(VARCHAR,1000000*CONVERT(NUMERIC(12,1),(F.CEILING_PRICE + 3*F.FLOOR_PRICE)/4)) AS PRICE ";

                    case "REFERENCE + 1":
                        return "CONVERT(VARCHAR,1000000*CONVERT(NUMERIC(12,1),(F.CEILING_PRICE + F.FLOOR_PRICE)/2+1)) AS PRICE ";

                    case "REFERENCE - 1":
                        return "CONVERT(VARCHAR,1000000*CONVERT(NUMERIC(12,1),(F.CEILING_PRICE + F.FLOOR_PRICE)/2-1)) AS PRICE ";
                }
                return "CONVERT(VARCHAR,1000000*CONVERT(NUMERIC(12,1),(F.CEILING_PRICE + F.FLOOR_PRICE)/2)) AS PRICE ";
            }
            switch (orderType)
            {
                case "REFERENCE":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),(F.CEILING_PRICE + F.FLOOR_PRICE)/2)) AS PRICE ";

                case "CEILING":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),F.CEILING_PRICE)) AS PRICE ";

                case "FLOOR":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),F.FLOOR_PRICE)) AS PRICE ";

                case "CEILING - 1":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),F.CEILING_PRICE - 1)) AS PRICE ";

                case "FLOOR + 1":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),F.FLOOR_PRICE + 1)) AS PRICE ";

                case "AVGERAGE ( REF , CEILING )":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),(3*F.CEILING_PRICE + F.FLOOR_PRICE)/4)) AS PRICE ";

                case "AVGERAGE ( REF, FLOOR )":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),(F.CEILING_PRICE + 3*F.FLOOR_PRICE)/4)) AS PRICE ";

                case "REFERENCE + 1":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),(F.CEILING_PRICE + F.FLOOR_PRICE)/2+1)) AS PRICE ";

                case "REFERENCE - 1":
                    return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),(F.CEILING_PRICE + F.FLOOR_PRICE)/2-1)) AS PRICE ";
            }
            return "CONVERT(VARCHAR,CONVERT(NUMERIC(6,1),(F.CEILING_PRICE + F.FLOOR_PRICE)/2)) AS PRICE ";
        }


        private void Insert1Firm(string StockCode, long Volume, double Price, string SellerClientID, string BuyerClientID, string BoardType, long DealID)
        {
            long num2;
            long num3;
            long num4;
            long num5;
            long num6;
            long num7;
            long num8;
            long buyerClientVolume = num2 = num3 = num4 = num5 = num6 = num7 = num8 = 0L;
            if (BuyerClientID.Contains("P"))
            {
                num7 = Volume;
            }
            else if (BuyerClientID.Contains("M"))
            {
                num5 = Volume;
            }
            else if (BuyerClientID.Contains("F"))
            {
                num3 = Volume;
            }
            else
            {
                buyerClientVolume = Volume;
            }
            if (SellerClientID.Contains("P"))
            {
                num8 = Volume;
            }
            else if (SellerClientID.Contains("M"))
            {
                num6 = Volume;
            }
            else if (SellerClientID.Contains("F"))
            {
                num4 = Volume;
            }
            else
            {
                num2 = Volume;
            }
            this.DbHOGW = DatabaseFactory.CreateDatabase();
            GWMessageUtil.insert1F(this.DbHOGW, CommonSettings.FirmID, GWMessageUtil.GetTraderIDByTradeCode(this.DbHOGW, "Default").ToString(), BuyerClientID, SellerClientID, StockCode.Trim(), Price, BoardType, DealID, num7, buyerClientVolume, num5, num3, num8, num2, num6, num4);
        }

        private long Insert1Firms(string[] StockCodes, long Volume, string PriceType, string SellerClientID, string BuyerClientID, string BoardType, long DealIDBegin)
        {
            long num3;
            long num4;
            long num5;
            long num6;
            long num7;
            long num8;
            long num9;
            string str = "INSERT INTO HOGW_1F(LAST_MODIFIED,MESSAGE_STATUS,MESSAGE_TYPE ,FIRM,TRADER_ID, BUYER_CLIENT_ID, SELLER_CLIENT_ID, SECURITY_SYMBOL ,PRICE,BOARD, DEAL_ID, [BUYER_PORTFOLIO_VOLUME],[BUYER_CLIENT_VOLUME] ,[BUYER_MUTUAL_FUND_VOLUME],[BUYER_FOREIGN_VOLUME],[SELLER_PORTFOLIO_VOLUME] ,[SELLER_CLIENT_VOLUME],[SELLER_MUTUAL_FUND_VOLUME],[SELLER_FOREIGN_VOLUME]) SELECT getdate() LAST_MODIFIED,'N' MESSAGE_STATUS,'1F' MESSAGE_TYPE, @Firm , @TraderID, @Buyer, @Seller, F.SECURITY_SYMBOL , ";
            string str2 = ",@Board, @DealID, @pvol1, @cvol1, @mvol1, @fvol1, @pvol2, @cvol2, @mvol2, @fvol2 FROM  ( select case when last_date_su >= last_date_ss then last_date_su else last_date_ss end as last_modified, last_date_su, last_date_ss, security_symbol, security_name, par_value, security_type, board_lot,  case when last_date_su >= last_date_ss then ceiling_price_su else ceiling_price_ss end as ceiling_price, case when last_date_su >= last_date_ss then floor_price_su else floor_price_ss end as floor_price, case when last_date_su >= last_date_ss then last_sale_price_su else prior_close_price_ss end as prior_close_price from ( select a.last_modified last_date_ss, b.last_modified last_date_su, ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, a.board_lot,  a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su\t from ( select * from (select dense_rank()  over(partition by security_number order by security_number, last_modified desc) as RankNum , * from hose_ss) X  where RankNum = 1 ) a, ( select * from (select dense_rank()  over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum , * from hose_su) X  where RankNum = 1 ) b where a.security_number = b.security_number_new  and b.security_symbol = @StockCode ) X ) F";
            string str3 = this.getLOPrice(PriceType, true);
            string query = str + str3 + str2;
            long num = DealIDBegin;
            long num2 = num3 = num4 = num5 = num6 = num7 = num8 = num9 = 0L;
            if (BuyerClientID.Contains("P"))
            {
                num8 = Volume;
            }
            else if (BuyerClientID.Contains("M"))
            {
                num6 = Volume;
            }
            else if (BuyerClientID.Contains("F"))
            {
                num4 = Volume;
            }
            else
            {
                num2 = Volume;
            }
            if (SellerClientID.Contains("P"))
            {
                num9 = Volume;
            }
            else if (SellerClientID.Contains("M"))
            {
                num7 = Volume;
            }
            else if (SellerClientID.Contains("F"))
            {
                num5 = Volume;
            }
            else
            {
                num3 = Volume;
            }
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(query);
            database.AddInParameter(sqlStringCommand, "@Firm", DbType.Int32);
            database.AddInParameter(sqlStringCommand, "@TraderID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Buyer", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Seller", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Board", DbType.String);
            database.AddInParameter(sqlStringCommand, "@DealID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@pvol1", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@cvol1", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@mvol1", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@fvol1", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@pvol2", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@cvol2", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@mvol2", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@fvol2", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@StockCode", DbType.String);
            foreach (string str5 in StockCodes)
            {
                database.SetParameterValue(sqlStringCommand, "@Firm", CommonSettings.FirmID);
                database.SetParameterValue(sqlStringCommand, "@TraderID", CommonSettings.FirmID.ToString() + "1");
                database.SetParameterValue(sqlStringCommand, "@Buyer", BuyerClientID);
                database.SetParameterValue(sqlStringCommand, "@Seller", SellerClientID);
                database.SetParameterValue(sqlStringCommand, "@Board", BoardType);
                database.SetParameterValue(sqlStringCommand, "@DealID", num);
                database.SetParameterValue(sqlStringCommand, "@pvol1", num8);
                database.SetParameterValue(sqlStringCommand, "@cvol1", num2);
                database.SetParameterValue(sqlStringCommand, "@mvol1", num6);
                database.SetParameterValue(sqlStringCommand, "@fvol1", num4);
                database.SetParameterValue(sqlStringCommand, "@pvol2", num9);
                database.SetParameterValue(sqlStringCommand, "@cvol2", num3);
                database.SetParameterValue(sqlStringCommand, "@mvol2", num7);
                database.SetParameterValue(sqlStringCommand, "@fvol2", num5);
                database.SetParameterValue(sqlStringCommand, "@StockCode", str5);
                database.ExecuteNonQuery(sqlStringCommand);
                num += 3L;
            }
            return num;
        }

        private void Insert2Firm(string StockCode, long Volume, double Price, string SellerClientID, int BuyerFirm, string BuyerTraderID, string BoardType, long DealID)
        {
            long num2;
            long num3;
            long num4;
            long brokerClientVolume = num2 = num3 = num4 = 0L;
            if (SellerClientID.Contains("P"))
            {
                num4 = Volume;
            }
            else if (SellerClientID.Contains("M"))
            {
                num3 = Volume;
            }
            else if (SellerClientID.Contains("F"))
            {
                num2 = Volume;
            }
            else
            {
                brokerClientVolume = Volume;
            }
            this.DbHOGW = DatabaseFactory.CreateDatabase();
            GWMessageUtil.insert1G(this.DbHOGW, CommonSettings.FirmID, GWMessageUtil.GetTraderIDByTradeCode(this.DbHOGW, "Default").ToString(), SellerClientID, BuyerFirm, BuyerTraderID, StockCode.Trim(), Price, BoardType, DealID, num4, brokerClientVolume, num3, num2);
        }

        private long Insert2Firms(string[] StockCodes, long Volume, string PriceType, string SellerClientID, int BuyerFirm, string BuyerTraderID, string BoardType, long DealIDBegin)
        {
            long num3;
            long num4;
            long num5;
            string str = "INSERT INTO HOGW_1G(LAST_MODIFIED,MESSAGE_STATUS,MESSAGE_TYPE ,SELLER_FIRM, SELLER_TRADER_ID, SELLER_CLIENT_ID, BUYER_CONTRA_FIRM, BUYER_TRADER_ID, SECURITY_SYMBOL ,PRICE,BOARD, DEAL_ID, [BROKER_PORTFOLIO_VOLUME],[BROKER_CLIENT_VOLUME] ,[BROKER_MUTUAL_FUND_VOLUME],[BROKER_FOREIGN_VOLUME]) SELECT getdate() LAST_MODIFIED,'N' MESSAGE_STATUS,'1G' MESSAGE_TYPE, @SellerFirm , @SellerTraderID, @SellerClientID, @BuyerContraFirm, @BuyerTraderID, F.SECURITY_SYMBOL , ";
            string str2 = ",@Board, @DealID, @pvol1, @cvol1, @mvol1, @fvol1 FROM  ( select case when last_date_su >= last_date_ss then last_date_su else last_date_ss end as last_modified, last_date_su, last_date_ss, security_symbol, security_name, par_value, security_type, board_lot,  case when last_date_su >= last_date_ss then ceiling_price_su else ceiling_price_ss end as ceiling_price, case when last_date_su >= last_date_ss then floor_price_su else floor_price_ss end as floor_price, case when last_date_su >= last_date_ss then last_sale_price_su else prior_close_price_ss end as prior_close_price from ( select a.last_modified last_date_ss, b.last_modified last_date_su, ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, a.board_lot,  a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su\t from ( select * from (select dense_rank()  over(partition by security_number order by security_number, last_modified desc) as RankNum , * from hose_ss) X  where RankNum = 1 ) a, ( select * from (select dense_rank()  over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum , * from hose_su) X  where RankNum = 1 ) b where a.security_number = b.security_number_new  and b.security_symbol = @StockCode ) X ) F";
            string str3 = this.getLOPrice(PriceType, true);
            string query = str + str3 + str2;
            long num = DealIDBegin;
            long num2 = num3 = num4 = num5 = 0L;
            if (SellerClientID.Contains("P"))
            {
                num5 = Volume;
            }
            else if (SellerClientID.Contains("M"))
            {
                num4 = Volume;
            }
            else if (SellerClientID.Contains("F"))
            {
                num3 = Volume;
            }
            else
            {
                num2 = Volume;
            }
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(query);
            database.AddInParameter(sqlStringCommand, "@SellerFirm", DbType.Int32);
            database.AddInParameter(sqlStringCommand, "@SellerTraderID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@SellerClientID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@BuyerContraFirm", DbType.String);
            database.AddInParameter(sqlStringCommand, "@BuyerTraderID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Board", DbType.String);
            database.AddInParameter(sqlStringCommand, "@DealID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@pvol1", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@cvol1", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@mvol1", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@fvol1", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@StockCode", DbType.String);
            foreach (string str5 in StockCodes)
            {
                database.SetParameterValue(sqlStringCommand, "@SellerFirm", CommonSettings.FirmID);
                database.SetParameterValue(sqlStringCommand, "@SellerTraderID", CommonSettings.FirmID.ToString() + "1");
                database.SetParameterValue(sqlStringCommand, "@SellerClientID", SellerClientID);
                database.SetParameterValue(sqlStringCommand, "@BuyerContraFirm", BuyerFirm);
                database.SetParameterValue(sqlStringCommand, "@BuyerTraderID", BuyerTraderID);
                database.SetParameterValue(sqlStringCommand, "@Board", BoardType);
                database.SetParameterValue(sqlStringCommand, "@DealID", num);
                database.SetParameterValue(sqlStringCommand, "@pvol1", num5);
                database.SetParameterValue(sqlStringCommand, "@cvol1", num2);
                database.SetParameterValue(sqlStringCommand, "@mvol1", num4);
                database.SetParameterValue(sqlStringCommand, "@fvol1", num3);
                database.SetParameterValue(sqlStringCommand, "@StockCode", str5);
                database.ExecuteNonQuery(sqlStringCommand);
                num += 3L;
            }
            return num;
        }

        private void InsertAdv(string StockCode, string Side, long Volume, double Price, string AddCancel, string BoardType)
        {
            try
            {
                this.DbHOGW = DatabaseFactory.CreateDatabase();
                GWMessageUtil.insert1E(this.DbHOGW, CommonSettings.FirmID, GWMessageUtil.GetTraderIDByTradeCode(this.DbHOGW, "Default").ToString(), StockCode.Trim(), Side, Volume, Price, BoardType, DateTime.Now.ToString("HHmmss"), AddCancel, CommonSettings.ContactAddress);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void InsertAdvs(string[] StockCodes, string Side, long Volume, string PriceType, string AddCancel, string BoardType)
        {
            string str = "INSERT INTO HOGW_1E(LAST_MODIFIED,MESSAGE_STATUS,MESSAGE_TYPE ,FIRM,TRADER_ID,SECURITY_SYMBOL ,SIDE,VOLUME,PRICE,BOARD,TIME, ADD_CANCEL_FLAG, CONTACT) SELECT getdate() LAST_MODIFIED,'N' MESSAGE_STATUS,'1E' MESSAGE_TYPE, @Firm , @TraderID, F.SECURITY_SYMBOL ,@Side, @Volume, ";
            string str2 = ",@Board, @Time, @AddCancel, @Contact FROM  ( select case when last_date_su >= last_date_ss then last_date_su else last_date_ss end as last_modified, last_date_su, last_date_ss, security_symbol, security_name, par_value, security_type, board_lot,  case when last_date_su >= last_date_ss then ceiling_price_su else ceiling_price_ss end as ceiling_price, case when last_date_su >= last_date_ss then floor_price_su else floor_price_ss end as floor_price, case when last_date_su >= last_date_ss then last_sale_price_su else prior_close_price_ss end as prior_close_price from ( select a.last_modified last_date_ss, b.last_modified last_date_su, ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, a.board_lot,  a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su\t from ( select * from (select dense_rank()  over(partition by security_number order by security_number, last_modified desc) as RankNum , * from hose_ss) X  where RankNum = 1 ) a, ( select * from (select dense_rank()  over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum , * from hose_su) X  where RankNum = 1 ) b where a.security_number = b.security_number_new  and b.security_symbol = @StockCode ) X ) F";
            string str3 = this.getLOPrice(PriceType, true);
            string query = str + str3 + str2;
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(query);
            database.AddInParameter(sqlStringCommand, "@Firm", DbType.Int32);
            database.AddInParameter(sqlStringCommand, "@TraderID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Side", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Volume", DbType.Int32);
            database.AddInParameter(sqlStringCommand, "@Board", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Time", DbType.String);
            database.AddInParameter(sqlStringCommand, "@AddCancel", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Contact", DbType.String);
            database.AddInParameter(sqlStringCommand, "@StockCode", DbType.String);
            foreach (string str5 in StockCodes)
            {
                database.SetParameterValue(sqlStringCommand, "@Firm", CommonSettings.FirmID);
                database.SetParameterValue(sqlStringCommand, "@TraderID", CommonSettings.FirmID.ToString() + "1");
                database.SetParameterValue(sqlStringCommand, "@Side", Side);
                database.SetParameterValue(sqlStringCommand, "@Volume", Volume);
                database.SetParameterValue(sqlStringCommand, "@Board", BoardType);
                database.SetParameterValue(sqlStringCommand, "@Time", DateTime.Now.ToString("HHmmss"));
                database.SetParameterValue(sqlStringCommand, "@AddCancel", AddCancel);
                database.SetParameterValue(sqlStringCommand, "@Contact", CommonSettings.ContactAddress);
                database.SetParameterValue(sqlStringCommand, "@StockCode", str5);
                database.ExecuteNonQuery(sqlStringCommand);
            }
        }

        private void InsertOrder(long OrderNumber, string CustomerID, string StockCode, string Side, int Volume, string Price)
        {
            try
            {
                string str;
                this.DbHOGW = DatabaseFactory.CreateDatabase();
                if (CustomerID.Contains("P"))
                {
                    str = "P";
                }
                else if (CustomerID.Contains("M"))
                {
                    str = "M";
                }
                else if (CustomerID.Contains("F"))
                {
                    str = "F";
                }
                else
                {
                    str = "C";
                }
                GWMessageUtil.insert1I(this.DbHOGW, CommonSettings.FirmID, GWMessageUtil.GetTraderIDByTradeCode(this.DbHOGW, "Default").ToString(), OrderNumber, CustomerID, StockCode.Trim(), Side, Volume, Volume, Price.Trim(), CommonSettings.Board, str, "");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private long InsertOrders(long OrderNumberBegin, string CustomerID, string[] StockCodes, string Side, int Volume, string PriceType)
        {
            string str = "INSERT INTO HOGW_1I(LAST_MODIFIED,MESSAGE_STATUS,MESSAGE_TYPE ,FIRM,TRADER_ID,ORDER_NUMBER,CLIENT_ID,SECURITY_SYMBOL ,SIDE,VOLUME,PUBLISHED_VOLUME,PRICE,BOARD,PORT_CLIENT_FLAG) SELECT getdate() LAST_MODIFIED,'N' MESSAGE_STATUS,'1I' MESSAGE_TYPE, @Firm , @TraderID, @OrderNumber, @CustomerID, F.SECURITY_SYMBOL ,@Side, @Volume, @Volume, ";
            string str2 = ",@Board, @PCFlag FROM  ( select case when last_date_su >= last_date_ss then last_date_su else last_date_ss end as last_modified, last_date_su, last_date_ss, security_symbol, security_name, par_value, security_type, board_lot,  case when last_date_su >= last_date_ss then ceiling_price_su else ceiling_price_ss end as ceiling_price, case when last_date_su >= last_date_ss then floor_price_su else floor_price_ss end as floor_price, case when last_date_su >= last_date_ss then last_sale_price_su else prior_close_price_ss end as prior_close_price from ( select a.last_modified last_date_ss, b.last_modified last_date_su, ltrim(rtrim(b.security_symbol)) as security_symbol, b.security_name, b.par_value/100 as par_value, b.security_type, a.board_lot,  a.ceiling_price/100 as ceiling_price_ss, a.floor_price/100 as floor_price_ss, a.prior_close_price/100 as prior_close_price_ss, b.ceiling_price/100 as ceiling_price_su, b.floor_price/100 as floor_price_su, b.last_sale_price/100 as last_sale_price_su\t from ( select * from (select dense_rank()  over(partition by security_number order by security_number, last_modified desc) as RankNum , * from hose_ss) X  where RankNum = 1 ) a, ( select * from (select dense_rank()  over(partition by security_symbol order by security_symbol, last_modified desc) as RankNum , * from hose_su) X  where RankNum = 1 ) b where a.security_number = b.security_number_new  and b.security_symbol = @StockCode ) X ) F";
            string str3 = "";
            long orderNumber = OrderNumberBegin;
            if (((PriceType == "ATO") || (PriceType == "ATC")) || (PriceType == "MP"))
            {
                foreach (string str4 in StockCodes)
                {
                    this.InsertOrder(orderNumber, CustomerID, str4, Side, Volume, PriceType);
                    orderNumber += 1L;
                }
                return orderNumber;
            }
            str3 = this.getLOPrice(PriceType, false);
            string query = str + str3 + str2;
            Database database = DatabaseFactory.CreateDatabase();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(query);
            database.AddInParameter(sqlStringCommand, "@Firm", DbType.Int32);
            database.AddInParameter(sqlStringCommand, "@TraderID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@OrderNumber", DbType.Int64);
            database.AddInParameter(sqlStringCommand, "@CustomerID", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Side", DbType.String);
            database.AddInParameter(sqlStringCommand, "@Volume", DbType.Int32);
            database.AddInParameter(sqlStringCommand, "@Board", DbType.String);
            database.AddInParameter(sqlStringCommand, "@PCFlag", DbType.String);
            database.AddInParameter(sqlStringCommand, "@StockCode", DbType.String);
            foreach (string str6 in StockCodes)
            {
                string str7;
                database.SetParameterValue(sqlStringCommand, "@Firm", CommonSettings.FirmID);
                database.SetParameterValue(sqlStringCommand, "@TraderID", CommonSettings.FirmID.ToString() + "1");
                database.SetParameterValue(sqlStringCommand, "@OrderNumber", orderNumber);
                database.SetParameterValue(sqlStringCommand, "@CustomerID", CustomerID);
                database.SetParameterValue(sqlStringCommand, "@Side", Side);
                database.SetParameterValue(sqlStringCommand, "@Volume", Volume);
                database.SetParameterValue(sqlStringCommand, "@Board", CommonSettings.Board);
                if (CustomerID.Contains("P"))
                {
                    str7 = "P";
                }
                else if (CustomerID.Contains("M"))
                {
                    str7 = "M";
                }
                else if (CustomerID.Contains("F"))
                {
                    str7 = "F";
                }
                else
                {
                    str7 = "C";
                }
                database.SetParameterValue(sqlStringCommand, "@PCFlag", str7);
                database.SetParameterValue(sqlStringCommand, "@StockCode", str6);
                database.ExecuteNonQuery(sqlStringCommand);
                orderNumber += 1L;
            }
            return orderNumber;
        }

        private void timerMarketStatus_Tick(object sender, EventArgs e)
        {
            this.ttipMarketStatus.Text = "Last SU day: " + GWMarket.getLastTradingDaySU(this.DbHOGW) + ", Market status: " + GWMarket.getMarketStatusHOSE(this.DbHOGW);
        }

        private void timerSystem_Tick(object sender, EventArgs e)
        {
            this.ttipTimer.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
