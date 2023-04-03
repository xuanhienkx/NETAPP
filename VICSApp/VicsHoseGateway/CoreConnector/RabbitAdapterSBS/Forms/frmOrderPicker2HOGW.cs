using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using InterStock;
using GWStock;
using OrderChecker;
using GWStock.Business;
using HOGW_CoreConnector.CoreConnector;
using OrderChecker.Business;

namespace HOGW_CoreConnector.Forms
{
    public partial class frmOrderPicker2HOGW : Form
    {

        private CoreConnectorWS coreService = new CoreConnectorWS();

        private static Log logOrderPicker = new Log();
        private List<Branch> lstBranches = new List<Branch>();
        private List<StockOrder> lstStockOrders = new List<StockOrder>();
        private List<StockOrder> lstStockOrdersFiltered = new List<StockOrder>();
        private string selectedBranch = "";
        private string selectedCustomerID = "";
        private string selectedOrderType = "";
        private string selectedSide = "";
        private string selectedStockCode = "";
        private double selectedVolumePivot;


        public frmOrderPicker2HOGW()
        {
            this.InitializeComponent();
        }

        private void btnEnterGW_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                int traderIDByTradeCode = GWMessageUtil.GetTraderIDByTradeCode(db, "Default");
                int pTDealInterval = CommonSettings.PTDealInterval;
                int firmID = CommonSettings.FirmID;
                int basicOrderNumber = CommonSettings.BasicOrderNumber;
                lock (logOrderPicker)
                {
                    logOrderPicker.LogFilePath = Directory.GetCurrentDirectory() + @"\Logs\HOGW_MatchingOrderPicker" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                }
                HOGWValidation validation = new HOGWValidation(db);
                MarketInfo info = validation.getCurrentMarketInfo(db);
                foreach (DataGridViewRow row in (IEnumerable)this.gridData.Rows)
                {
                    if (((row.Cells["Check"] == null) || (row.Cells["Check"].Value == null)) || !((bool)row.Cells["Check"].Value))
                    {
                        continue;
                    }
                    string tradeCode = row.Cells["TradeCode"].Value.ToString();
                    int traderid = GWMessageUtil.GetTraderIDByTradeCode(db, tradeCode);
                    if (traderid == -1)
                    {
                        traderid = traderIDByTradeCode;
                    }
                    int orderSeq = Convert.ToInt32(row.Cells["OrderSeq"].Value.ToString());
                    GWTraderStatus status = GWMarket.getTraderStatus(db, traderid);
                    if ((status != null) && (status.TraderStatus.Trim().ToUpper() == "S"))
                    {
                        string text = "Trader " + traderid.ToString() + " is SUSPENDED!";
                        writeLogMatchingOrderPicker(text);
                        this.coreService.UpdateOrderStatusBySeq(orderSeq, "P", text);
                        Thread.Sleep(pTDealInterval);
                        continue;
                    }
                    string str6 = row.Cells["OrderType"].Value.ToString();
                    string str7 = row.Cells["OrderPrice"].Value.ToString();
                    string str8 = row.Cells["OrderVolume"].Value.ToString();
                    string side = row.Cells["OrderSide"].Value.ToString();
                    string customerid = row.Cells["CustomerID"].Value.ToString();
                    string board = row.Cells["BoardType"].Value.ToString();
                    string stockcode = row.Cells["StockCode"].Value.ToString();
                    string str15 = str6.Trim().ToUpper();
                    if (str15 == null)
                    {
                        goto Label_032E;
                    }
                    if (!(str15 == "MP"))
                    {
                        if (str15 == "ATO")
                        {
                            goto Label_02E7;
                        }
                        if (str15 == "ATC")
                        {
                            goto Label_02F7;
                        }
                        if (str15 == "PT")
                        {
                            goto Label_0307;
                        }
                        if (str15 == "LO")
                        {
                            goto Label_0317;
                        }
                        goto Label_032E;
                    }
                    string price = "MP";
                    string pricetype = "MP";
                    goto Label_0343;
                Label_02E7:
                    price = "ATO";
                    pricetype = "ATO";
                    goto Label_0343;
                Label_02F7:
                    price = "ATC";
                    pricetype = "ATC";
                    goto Label_0343;
                Label_0307:
                    price = "0";
                    pricetype = "PT";
                    goto Label_0343;
                Label_0317:
                    price = string.Format("{0:F3}", str7);
                    pricetype = "LO";
                    goto Label_0343;
                Label_032E:
                    price = string.Format("{0:F3}", str7);
                    pricetype = "LO";
                Label_0343:
                    if (pricetype != "PT")
                    {
                        string systemControlCode = validation.getCurrentMarketInfo(db).SystemControlCode;
                        HOGWValidInput orderIn = new HOGWValidInput(customerid, stockcode, pricetype, systemControlCode, "N", side.ToString(), traderid, Convert.ToDecimal(str7), Convert.ToDouble(str8), Convert.ToDouble(str8), 0, systemControlCode);
                        HOGWValidOutput output = validation.CheckOrder(orderIn);
                        
                        if (output.IsOK || (output.ErrCode == 0x8ae))
                        {
                            if (this.coreService.UpdateOrderStatusBySeq(orderSeq, "E", null) > 0)
                            {
                                string str14;
                                if ((string.IsNullOrEmpty(systemControlCode) || (systemControlCode == " ")) || (systemControlCode == ""))
                                {
                                    str14 = "P";
                                }
                                else
                                {
                                    str14 = systemControlCode;
                                }
                                if (GWMessageUtil.insert1I(db, firmID, traderid, basicOrderNumber + orderSeq, customerid, stockcode, side, str8, str8, price, board, output.PCFlag, str14) <= 0)
                                {
                                    writeLogMatchingOrderPicker("Cannot insert 1I message with SEQ=" + orderSeq.ToString());
                                    if (this.coreService.UpdateOrderStatusBySeq(orderSeq, "D", "Cannot insert 1I message!") <= 0)
                                    {
                                        writeLogMatchingOrderPicker("After inserting into HOGW fails, cannot CANCEL (update in SBS.CORE -> D) the order with SEQ=" + orderSeq.ToString());
                                    }
                                    else
                                    {
                                        writeLogMatchingOrderPicker("After inserting into HOGW fails, update SBS.CORE order -> D with SEQ=" + orderSeq.ToString());
                                    }
                                }
                            }
                            else
                            {
                                writeLogMatchingOrderPicker("Cannot update order in SBS.CORE S -> E (SEQ=" + orderSeq.ToString() + ")");
                            }
                        }
                        else
                        {
                            string str16 = orderIn.getDescription("VALID_ERROR - 1I");
                            string str3 = str16 + " [ErrCode: " + output.ErrCode.ToString() + " - " + output.ErrDesc + "]";
                            writeLogMatchingOrderPicker(str3);
                            MessageBox.Show(str3, "Lỗi, kh\x00f4ng update trạng th\x00e1i lệnh trong SBS th\x00e0nh D", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
                MessageBox.Show("Ho\x00e0n th\x00e0nh. Lấy lại dữ liệu...");
                this.refreshDataView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.refreshDataView();
            }
        }

        private void btnGetOrders_Click(object sender, EventArgs e)
        {
            this.refreshDataView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void cboBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedBranch = (this.cboBranches.SelectedValue == null) ? "0" : this.cboBranches.SelectedValue.ToString();
        }

        private void cboOrderSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboOrderSide.SelectedIndex == 0)
            {
                this.selectedSide = "";
            }
            else if (this.cboOrderSide.SelectedIndex == 1)
            {
                this.selectedSide = "B";
            }
            else
            {
                this.selectedSide = "S";
            }
        }

        private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboOrderType.SelectedIndex == 0)
            {
                this.selectedOrderType = "";
            }
            else if (this.cboOrderType.SelectedIndex == 1)
            {
                this.selectedOrderType = "ATO";
            }
            else if (this.cboOrderType.SelectedIndex == 2)
            {
                this.selectedOrderType = "LO";
            }
            else
            {
                this.selectedOrderType = "ATC";
            }
        }



        private bool FindCondition(StockOrder order)
        {
            return (((order.CustomerID.Contains(this.selectedCustomerID) && order.BranchCode.Contains(this.selectedBranch)) && (order.OrderSide.ToString().Contains(this.selectedSide) && order.OrderType.Contains(this.selectedOrderType))) && (order.StockCode.Contains(this.selectedStockCode) && (order.OrderVolume >= ((decimal)this.selectedVolumePivot))));
        }

        private void frmOrderPicker2HOGW_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    this.btnEnterGW_Click(sender, e);
                    break;

                case Keys.F5:
                    this.refreshDataView();
                    break;
            }
        }

        private void frmOrderPicker2HOGW_Load(object sender, EventArgs e)
        {
            this.gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gridData.EnableHeadersVisualStyles = false;
            this.gridData.AutoGenerateColumns = false;
            this.gridData.Columns.Clear();
            DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn
            {
                Width = 30,
                HeaderText = "Chọn",
                Name = "Check"
            };
            this.gridData.Columns.Add(dataGridViewColumn);
            DataGridViewCellStyle style = new DataGridViewCellStyle
            {
                ForeColor = Color.Violet,
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn
            {
                Width = 120,
                HeaderText = "M\x00e3 kh\x00e1ch h\x00e0ng",
                Name = "CustomerID",
                DataPropertyName = "CustomerID"
            };
            column2.HeaderCell.Style = style;
            column2.DefaultCellStyle = style;
            this.gridData.Columns.Add(column2);
            style.ForeColor = Color.Blue;
            style.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn
            {
                Width = 70,
                HeaderText = "M\x00e3 CK",
                Name = "StockCode",
                DataPropertyName = "StockCode"
            };
            column3.HeaderCell.Style = style;
            column3.DefaultCellStyle = style;
            this.gridData.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn
            {
                Width = 40,
                HeaderText = "S\x00e0n",
                Name = "BoardType",
                DataPropertyName = "BoardType"
            };
            this.gridData.Columns.Add(column4);
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn
            {
                Width = 30,
                HeaderText = "B/S",
                Name = "OrderSide",
                DataPropertyName = "OrderSide"
            };
            this.gridData.Columns.Add(column5);
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn
            {
                Width = 50,
                HeaderText = "Loại lệnh",
                Name = "OrderType",
                DataPropertyName = "OrderType"
            };
            this.gridData.Columns.Add(column6);
            style = new DataGridViewCellStyle
            {
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn
            {
                Width = 70,
                HeaderText = "Gi\x00e1",
                Name = "OrderPrice",
                DataPropertyName = "OrderPrice",
                DefaultCellStyle = style
            };
            column7.HeaderCell.Style = style;
            this.gridData.Columns.Add(column7);
            style = new DataGridViewCellStyle
            {
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn
            {
                Width = 70,
                HeaderText = "KL đặt",
                Name = "OrderVolume",
                DataPropertyName = "OrderVolume",
                DefaultCellStyle = style
            };
            column8.HeaderCell.Style = style;
            this.gridData.Columns.Add(column8);
            DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn
            {
                Width = 0x55,
                HeaderText = "Thời gian",
                Name = "OrderTime",
                DataPropertyName = "OrderTime"
            };
            this.gridData.Columns.Add(column9);
            DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn
            {
                Width = 50,
                HeaderText = "SHL",
                Name = "OrderSeq",
                DataPropertyName = "OrderSeq"
            };
            this.gridData.Columns.Add(column10);
            DataGridViewTextBoxColumn column11 = new DataGridViewTextBoxColumn
            {
                Width = 60,
                HeaderText = "M\x00e3 CN",
                Name = "BranchCode",
                DataPropertyName = "BranchCode"
            };
            this.gridData.Columns.Add(column11);
            DataGridViewTextBoxColumn column12 = new DataGridViewTextBoxColumn
            {
                Width = 70,
                HeaderText = "M\x00e3 GD",
                Name = "TradeCode",
                DataPropertyName = "TradeCode"
            };
            this.gridData.Columns.Add(column12);
            DataGridViewTextBoxColumn column13 = new DataGridViewTextBoxColumn
            {
                Width = 80,
                HeaderText = "Nhận bởi",
                Name = "ReceivedBy",
                DataPropertyName = "ReceivedBy"
            };
            this.gridData.Columns.Add(column13);
            DataGridViewTextBoxColumn column14 = new DataGridViewTextBoxColumn
            {
                Width = 90,
                HeaderText = "Duyệt bởi",
                Name = "ApprovedBy",
                DataPropertyName = "ApprovedBy"
            };
            this.gridData.Columns.Add(column14);
            Branch[] branches = this.coreService.GetBranches();
            if (branches == null)
            {
                MessageBox.Show("Lỗi lấy dữ liệu chi nh\x00e1nh");
            }
            else
            {
                this.lstBranches.Clear();
                Branch item = new Branch
                {
                    BranchCode = "0",
                    BranchName = "Tất cả"
                };
                this.lstBranches.Add(item);
                foreach (Branch branch2 in branches)
                {
                    this.lstBranches.Add(branch2);
                }
                this.cboBranches.DisplayMember = "BranchName";
                this.cboBranches.ValueMember = "BranchCode";
                this.cboBranches.DataSource = this.lstBranches;
                this.cboOrderSide.Items.Clear();
                this.cboOrderSide.Items.Add("---");
                this.cboOrderSide.Items.Add("BUY");
                this.cboOrderSide.Items.Add("SELL");
                this.cboOrderSide.SelectedIndex = 0;
                this.cboOrderType.Items.Clear();
                this.cboOrderType.Items.Add("---");
                this.cboOrderType.Items.Add("ATO");
                this.cboOrderType.Items.Add("LO");
                this.cboOrderType.Items.Add("ATC");
                this.cboOrderType.SelectedIndex = 0;
                this.selectedBranch = (this.cboBranches.SelectedValue == null) ? "0" : this.cboBranches.SelectedValue.ToString();
                if (this.cboOrderSide.SelectedIndex == 0)
                {
                    this.selectedSide = "";
                }
                else if (this.cboOrderSide.SelectedIndex == 1)
                {
                    this.selectedSide = "B";
                }
                else
                {
                    this.selectedSide = "S";
                }
                this.selectedCustomerID = this.txtCustomerID.Text.Trim();
                this.refreshDataView();
            }
        }

        private void refreshDataView()
        {
            StockOrder[] stockOrders = this.coreService.GetStockOrders("S");
            if (stockOrders == null)
            {
                MessageBox.Show("Lỗi lấy dữ liệu giao dịch");
            }
            else
            {
                this.lstStockOrders.Clear();
                foreach (StockOrder order in stockOrders)
                {
                    this.lstStockOrders.Add(order);
                }
                this.lstStockOrdersFiltered = this.lstStockOrders.FindAll(new Predicate<StockOrder>(this.FindCondition));
                this.gridData.DataSource = this.lstStockOrdersFiltered;
                this.lblOrderCount.Text = this.lstStockOrdersFiltered.Count.ToString();
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            this.selectedCustomerID = this.txtCustomerID.Text.Trim();
        }

        private void txtStockCode_TextChanged(object sender, EventArgs e)
        {
            this.selectedStockCode = this.txtStockCode.Text.Trim();
        }

        private void txtVolumePivot_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(this.txtVolumePivot.Text.Trim(), out num))
            {
                num = 0.0;
            }
            this.selectedVolumePivot = num;
        }

        public static void writeLogMatchingOrderPicker(string text)
        {
            lock (logOrderPicker)
            {
                logOrderPicker.writeLog(text);
            }
        }
    }
}
