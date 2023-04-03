using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VRMApp.ControlBase
{
   public partial class StdForm : FormBase
   {
      public StdForm()
      {
         InitializeComponent();
      }

      protected void UpdateStatus(DataGridView dataGrid)
      {
         if (dataGrid != null)
            this.statusLabel.Text = string.Format("Tổng cộng có {0} bản ghi.", dataGrid.RowCount.ToString("n0"));
      }
   }
}
