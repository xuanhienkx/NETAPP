using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using Order = Brokery.AgencyWebService.Order;
using OrderSide = Brokery.AgencyWebService.OrderSide;

namespace Brokery.Operation
{
   public partial class OrderManager : FormBase
   {
      string boardType;

      public OrderManager(string boardType)
      {
         InitializeComponent();

         this.orderSideBox.ComboBox.DataSource = new Controls.DropDownObject[] 
         { 
            new DropDownObject(string.Empty, "<Tất cả>"),
            new DropDownObject(OrderSide.B.ToString(), "Mua"),
            new DropDownObject(OrderSide.S.ToString(), "Bán")
         };
         orderSideBox.ComboBox.DisplayMember = "Description";
         orderSideBox.ComboBox.ValueMember = "Code";

         GUIUtil.FormatGridView(cancelOrderGrid);
         GUIUtil.FormatGridView(modifyGrid);
         cancelOrderGrid.Columns[0].ReadOnly = false;

         this.boardType = boardType;
         if (boardType == Util.HOSEBoard)
         {
            this.Text = "Hủy lệnh sàn HOSE";
            modifyButton.Enabled = false;
         }
         else if (boardType == Util.HNXBoard)
         {
            this.Text = "Hủy lệnh sàn HNX";
            modifyButton.Enabled = true;
         }
         else if (boardType == Util.UPCOMBoard)
         {
            this.Text = "Hủy lệnh sàn UPCOM";
            modifyButton.Enabled = true;
         }
         else
            throw new NotImplementedException("Không xác định được sàn giao dịch");
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get
         {
            if (boardType == Util.HOSEBoard)
               yield return AccessPermission.VICS_HuyLenhHOSE;
            else if (boardType == Util.HNXBoard)
               yield return AccessPermission.VICS_HuyLenhHNX;
            else if (boardType == Util.UPCOMBoard)
               yield return AccessPermission.VICS_HuyLenhUPCOM;
            else
               yield return AccessPermission.None;
         }
      }

      private void findBtn_Click(object sender, EventArgs e)
      {
         if (!(queryDataWorker.IsBusy || queryDataWorker.CancellationPending))
            queryDataWorker.RunWorkerAsync(new string[]
               {
                  this.CustomerIDBox.Text.Trim(),
                  this.StockCodeBox.Text.Trim(),
                  ((DropDownObject)this.orderSideBox.SelectedItem).Code
               });
      }

      private void queryDataWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         string[] arg = (string[])e.Argument;
         try
         {
            e.Result = new List<Order>(Util.AgencyGateway.GetListForCancel(Util.TokenKey, boardType, arg[0], arg[1], arg[2], Util.CurrentTransactionDate));
         }
         catch (System.Web.Services.Protocols.SoapException ex)
         {
            throw new ArgumentException(ex.Detail.ChildNodes[0].Attributes[1].Value);
         }
      }

      private void queryDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(e.Error.Message);
            return;
         }
         orderBindingSource.DataSource = e.Result as List<Order>;
         sumOfOrderToolStripLabel.Text = string.Format(sumOfOrderToolStripLabel.Text, cancelOrderGrid.Rows.Count.ToString());
         sumOfOrderToolStripLabel.Visible = true;
      }

      private void cancelOrderGrid_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex < 0)
            return;
         DataGridViewRow row = cancelOrderGrid.Rows[e.RowIndex];
         if (row.Cells[0].Value == null)
            row.Cells[0].Value = false;

         bool chk = !(bool)row.Cells[0].Value;
         row.Cells[0].Value = chk;
         UpdateRowStyle(row, chk);

         foreach (DataGridViewRow r in cancelOrderGrid.Rows)
         {
            if (!r.Equals(row))
            {
               r.Cells[0].Value = false;
               UpdateRowStyle(r, false);
            }
         }

         UpdateCommandStateAndReturnOrder();
      }

      private void UpdateRowStyle(DataGridViewRow row, bool isChecked)
      {
         if (isChecked)
         {
            row.DefaultCellStyle.BackColor = row.DefaultCellStyle.SelectionBackColor = Color.Red;
         }
         else
         {
            if (row.Index % 2 == 0)
            {
               row.DefaultCellStyle.BackColor = cancelOrderGrid.DefaultCellStyle.BackColor;
               row.DefaultCellStyle.SelectionBackColor = cancelOrderGrid.DefaultCellStyle.SelectionBackColor;
            }
            else
            {
               row.DefaultCellStyle.BackColor = cancelOrderGrid.AlternatingRowsDefaultCellStyle.BackColor;
               row.DefaultCellStyle.SelectionBackColor = cancelOrderGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor;
            }
         }
      }

      private void cancelButton_Click(object sender, EventArgs e)
      {
         if (UpdateCommandStateAndReturnOrder() == null)
         {
            ShowWaring("Trạng thái giao dịch hiện tại không cho phép hủy lệnh");
            cancelButton.Enabled = false;
            return;
         }

         if (ShowQuestion("Bạn có thực sự muốn hủy lệnh được chọn?") == DialogResult.No)
         {
            return;
         }

         if (!(cancelOrderWorker.IsBusy || cancelOrderWorker.CancellationPending))
         {
            cancelOrderWorker.RunWorkerAsync(orderBindingSource.Current as Order);
         }
      }

      private void cancelOrderWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         Util.AgencyGateway.CancelOrder(Util.TokenKey, boardType, (e.Argument as Order).OrderNo);
      }

      private void cancelOrderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error == null)
         {
            findBtn.PerformClick();
            ShowNotice("Lệnh hủy đã được đưa vào hệ thống.");
            tabControl1.SelectedIndex = 0;
            refreshButton.PerformClick();
         }
         else
            ShowError(e.Error.Message);
      }

      private void refreshButton_Click(object sender, EventArgs e)
      {
         if (boardType == Util.HOSEBoard)
            tabControl1.SelectedIndex = 0;

         if (!(dayCancelWorker.IsBusy || dayCancelWorker.CancellationPending))
         {
            tabControl1.Enabled = false;
            dayCancelWorker.RunWorkerAsync(tabControl1.SelectedIndex == 0);
         }
      }

      private void dayCancelWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         e.Result = new List<Order>(Util.AgencyGateway.GetDayCanceledOrModifiedList(Util.TokenKey, boardType, (bool)e.Argument, Util.CurrentTransactionDate));
      }

      private void dayCancelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
         {
            ShowError(e.Error.Message);
            tabControl1.Enabled = true;
            return;
         }
         if (tabControl1.SelectedIndex == 0)
         {
            orderCancelBindingSource.DataSource = e.Result as List<Order>;
            sumOfCanceledOrderToolStripLabel.Text = string.Format("Tổng số bản ghi {0:n0}  ", orderCancelBindingSource.Count);
         }
         else
         {
            orderModifyBindingSource.DataSource = e.Result as List<Order>;
            sumOfCanceledOrderToolStripLabel.Text = string.Format("Tổng số bản ghi {0:n0}  ", orderModifyBindingSource.Count);
         }
         sumOfCanceledOrderToolStripLabel.Visible = true;
         tabControl1.Enabled = true;
      }

      public string GetBoardType()
      {
         return boardType;
      }

      private void modifyButton_Click(object sender, EventArgs e)
      {
         var order = UpdateCommandStateAndReturnOrder();
         if (order == null)
         {
            ShowWaring("Trạng thái giao dịch hiện tại không cho phép sửa lệnh");
            modifyButton.Enabled = false;
            return;
         }

         var replaceOrderForm = new OrderReplace(order);
         var result = replaceOrderForm.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            ShowNotice("Lệnh sửa đã đưa vào hệ thống.");
            tabControl1.SelectedIndex = 1;
            findBtn.PerformClick();
         }
      }

      private Order UpdateCommandStateAndReturnOrder()
      {
         var order = orderBindingSource.Current as Order;
         if (order == null)
         {
            cancelButton.Enabled = modifyButton.Enabled = false;
            return null;
         }

         var tradingStatus = TradingSession.GetCurrentSession(order.StockCode, order.BoardType);
         if (tradingStatus.SessionType == SessionType.None ||
             tradingStatus.SessionType == SessionType.PostCloseSession ||
             tradingStatus.SessionType == SessionType.EndSession ||
             tradingStatus.SessionStatus == SessionStatus.NotEdit)
         {
            cancelButton.Enabled = modifyButton.Enabled = false;
            return null;
         }

         cancelButton.Enabled = order.OrderType != "MOK" && order.OrderType != "MAK";
         modifyButton.Enabled = order.OrderType != "MOK" && order.OrderType != "MAK" && order.OrderType != "ATO" &&
                                order.OrderType != "ATC";
         return order;
      }
   }
}
