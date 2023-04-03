using System;
using System.Collections.Generic;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using Order = Brokery.AgencyWebService.Order;

namespace Brokery.Operation
{
   public partial class MatchedOrderList : FormBase
   {
      private List<Order> orders;
      private bool showInPair = false;

      public MatchedOrderList()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(gridOrder);
         GUIUtil.FormatGridView(dataGridMatchedOrder);
         BindingDropDownListDetail();
         toolStripButton1.Text = showInPair ? "Liệt kê hết" : "Hiện đối ứng";
      }

      private void BindingDropDownListDetail()
      {
         // board type
         List<DropDownObject> items = new List<DropDownObject>();
         items.Add(new DropDownObject(string.Empty, "<Tất cả>"));
         items.Add(new DropDownObject(Util.HOSEBoard, "Sàn HOSE"));
         items.Add(new DropDownObject(Util.HNXBoard, "Sàn HNX"));
         items.Add(new DropDownObject(Util.UPCOMBoard, "Sàn OTC"));
         boardTypeBox.ComboBox.DataSource = items;
         boardTypeBox.ComboBox.DisplayMember = "Description";
         boardTypeBox.ComboBox.ValueMember = "Code";

         // order side
         items = new List<DropDownObject>();
         items.Add(new DropDownObject(string.Empty, "<Tất cả>"));
         items.Add(new DropDownObject(AgencyWebService.OrderSide.B.ToString(), "Mua"));
         items.Add(new DropDownObject(AgencyWebService.OrderSide.S.ToString(), "Bán"));
         orderSideBox.ComboBox.DataSource = items;
         orderSideBox.ComboBox.DisplayMember = "Description";
         orderSideBox.ComboBox.ValueMember = "Code";
      }

      private void findBtn_Click(object sender, EventArgs e)
      {
         ShowWaiting("Đang tìm kiếm ...");

         findBtn.Enabled = false;

         if (!(this.backgroundWorker.IsBusy || this.backgroundWorker.CancellationPending))
            backgroundWorker.RunWorkerAsync(new string[]
                                               {
                                                  this.CustomerIDBox.Text.Trim(),
                                                  this.StockCodeBox.Text.Trim(),
                                                  this.orderSideBox.ComboBox.SelectedValue.ToString(),
                                                  this.boardTypeBox.ComboBox.SelectedValue.ToString()
                                               });

      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_XemLenh; }
      }

      private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
      {
         var args = e.Argument as string[];
         e.Result = Util.AgencyGateway.GetMatchedOrderList(
            Util.TokenKey,
            Util.CurrentTransactionDate,
            args[0],args[1],args[2],args[3]);
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
      {
         CloseWaiting();
         findBtn.Enabled = true;

         if (e.Error!=null)
         {
            ShowError(e.Error.Message);
            orders = new List<Order>();
         }
         else
         {
            orders = new List<Order>(e.Result as Order[]);
         }

         ShowOrders();
      }

      private void ShowOrders()
      {
         if (orders == null)
            orders = new List<Order>();

         var tradingOrders = new List<Order>(); 
         orders.ForEach(o=>
                           {
                              if (tradingOrders.Find(x=>x.OrderNo == o.OrderNo) == null)
                                 tradingOrders.Add(o);
                           });

         bindingSource.DataSource = new SortableBindingList<Order>(new List<Order>(tradingOrders));

         ShowMatchedOrders();
         
         sumOfRecodeLabel.Text = string.Format("Tổng số có {0} bản ghi.", gridOrder.Rows.Count.ToString());
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         showInPair = !showInPair;
         toolStripButton1.Text = showInPair ? "Liệt kê hết" : "Hiện đối ứng";

         ShowMatchedOrders();
      }

      private void gridOrder_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
      {
         ShowMatchedOrders();
      }

      private void ShowMatchedOrders()
      {
         if (orders == null)
            return;

         var matchedOrders = new List<Order>();
         if (showInPair)
         {
            var selectedOrderNo = GetSelectedOrderNo();
            orders.ForEach(o =>
                              {
                                 if (selectedOrderNo == o.OrderNo)
                                    matchedOrders.Add(o);
                              });
         }
         else
         {
            matchedOrders = orders;
         }
         bindingSourceOrderMatched.DataSource = new SortableBindingList<Order>(new List<Order>(matchedOrders));
      }

      private string GetSelectedOrderNo()
      {
         if (gridOrder.SelectedRows.Count == 0)
            return string.Empty;
         var selectedOrder = gridOrder.SelectedRows[0].DataBoundItem as Order;
         if (selectedOrder == null)
            return string.Empty;

         return selectedOrder.OrderNo;
      }
   }
}