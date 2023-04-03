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
    public partial class OrderEntry : Form
    {
        public OrderEntry()
        {
            InitializeComponent();
        }

        private void OrderEntry_Load(object sender, EventArgs e)
        {
            cboAlertCode.SelectedIndex = 0;
            cboOrderStatus.SelectedIndex = 0;
            cboOrderType.SelectedIndex = 0;
            cboStockCode.SelectedIndex = 0;
        }

        private void btnEnterOrder_Click(object sender, EventArgs e)
        {
            GatewayDataContext gateway = GatewayLib.GatewayManager.GetGatewayContext();
            /*SHS_StockOrder stockOrder = new SHS_StockOrder();

            stockOrder.AlertCode = cboAlertCode.Text[0];
            stockOrder.ApprovedBy = txtApprovedBy.Text;
            stockOrder.BoardType = txtBoardType.Text[0];
            stockOrder.BranchCode = txtBranchCode.Text;
            stockOrder.CustomerID = txtCustomerID.Text;
            stockOrder.Notes = txtNotes.Text;
            stockOrder.OrderDate = DateTime.Today.ToString("dd/MM/yyyy");
            stockOrder.OrderFee = Convert.ToDecimal(txtOrderFee.Text);
            stockOrder.OrderNo = txtOrderNo.Text;
            stockOrder.OrderPrice = Convert.ToDecimal(txtOrderPrice.Text);
            stockOrder.OrderSeq = Convert.ToInt32(txtOrderSequence.Text);
            stockOrder.OrderSide = txtOrderSide.Text[0];
            stockOrder.OrderStatus = cboOrderStatus.Text[0];
            stockOrder.OrderTime = DateTime.Now.ToString("HH:mm:ss:fff");
            stockOrder.OrderType = cboOrderType.Text;
            stockOrder.OrderValue = Convert.ToDecimal(txtOrderValue.Text);
            stockOrder.OrderVolume = Convert.ToDecimal(txtOrderVolume.Text);
            stockOrder.ReceivedBy = txtReceivedBy.Text;
            stockOrder.StockCode = cboStockCode.Text;
            stockOrder.TradeCode = txtTradeCode.Text;
            gateway.SHS_StockOrders.InsertOnSubmit(stockOrder);
            gateway.SubmitChanges();*/
            MessageBox.Show("Lệnh được đặt thành công!");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            OrderForm order = new OrderForm();
            order.ShowDialog();
        }
    }
}
