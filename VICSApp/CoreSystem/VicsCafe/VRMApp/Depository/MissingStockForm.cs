using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;

namespace VRMApp.Depository
{
   public partial class MissingStockForm : FormBase
   {
      public MissingStockForm()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(dataGridView1);
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         dataGridView1.DataSource = Util.VRMService.GetMissingStocks(Util.TokenKey);
         lblSoCK.Text = string.Format("Số chứng khoán bị thiếu {0}", GUIUtil.FormatNumber(dataGridView1.Rows.Count));
      }

      private void MissingStockForm_Load(object sender, EventArgs e)
      {
         toolStripButton1.PerformClick();
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.LuuKy_XemDanhSachChungKhoanBiThieu);
      }
   }
}
