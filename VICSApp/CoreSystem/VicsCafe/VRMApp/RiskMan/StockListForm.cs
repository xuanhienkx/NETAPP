using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.VRMGateway;

namespace VRMApp.RiskMan
{
   public partial class StockListForm : ListFormBase
   {
      public StockListForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView1);
         maCKTextBox.KeyPress += new KeyPressEventHandler(GUIUtil.ToUpcaseKeyPress);

         DeleteButton.Enabled = NewButton.Enabled = ModifyButton.Enabled = Util.CheckAccess(AccessPermission.QTRR_ThietLapDSCKCamCo);
         HideExportButton = true;
         HidePrintButton = true;
      }

      private void StockListForm_DeleteButtonClick(object sender, EventArgs e)
      {
         if (stockBindingSource.Current == null)
            return;
         if (ShowQuestion("Bạn có chắc muốn xóa không?") == DialogResult.No)
            return;
         Stock s = stockBindingSource.Current as Stock;
         Util.VRMService.DeleteStock(Util.TokenKey, s);
      }

      private void StockListForm_EditButtonClick(object sender, EventArgs e)
      {
         if (stockBindingSource.Current == null)
            return;
         Stock s = stockBindingSource.Current as Stock;
         StockForm sF = new StockForm(s);
         sF.ShowDialog();
         if (sF.IsUpdateable)
            stockBindingSource.ResetCurrentItem();
      }

      private void StockListForm_NewButtonClick(object sender, EventArgs e)
      {
         StockForm sF = new StockForm();
         sF.ShowDialog();
         UpdateList();
      }

      private void StockListForm_Load(object sender, EventArgs e)
      {
         UpdateList();
      }

      private void UpdateList()
      {
         stockBindingSource.DataSource = new List<Stock>(Util.VRMService.GetStockList(Util.TokenKey, maCKTextBox.Text.Trim()));
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         UpdateList();
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.QTRR_XemDanhSachCKCamCo);
      }
   }
}
