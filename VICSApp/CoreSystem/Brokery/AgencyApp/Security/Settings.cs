using System;
using System.Collections.Generic;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Security
{
   public partial class Settings : FormBase
   {
      public Settings()
      {
         InitializeComponent();
      }

      private void ParamForm_Load(object sender, EventArgs e)
      {
         this.propertyGrid.SelectedObject = Util.Parameters;
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

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_ThietLapThamSo; }
      }
   }
}