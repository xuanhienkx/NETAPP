using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;

namespace VRMApp.Security
{
   public partial class Settings : FormBase
   {
      public Settings()
      {
         InitializeComponent();
      }

      private void ParamForm_Load(object sender, EventArgs e)
      {
         this.propertyGrid.SelectedObject = VRMApp.Framework.Util.Parameters;
      }

      private void btnOk_Click(object sender, EventArgs e)
      {
         (this.propertyGrid.SelectedObject as Parameter).Save();
         ShowNotice("Đã lưu lại thành công");
      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         this.Close();
         this.Dispose();
      }

      public override bool CheckAccess()
      {
         return true;
      }
   }
}