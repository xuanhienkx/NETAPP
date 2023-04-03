using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Brokery.AgencyWebService;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Security
{
   public partial class UserManager : ListFormBase
   {
      public UserManager()
      {
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_QuanLyNguoiDung; }
      }

      private void UserManager_DeleteButtonClick(object sender, EventArgs e)
      {
         if (userLiteBindingSource.Current == null || ShowQuestion("Bạn có chắc là muốn xóa?") == DialogResult.No)
            return;

         try
         {
            UserLite user = userLiteBindingSource.Current as UserLite;
            Util.AgencyGateway.DeleteUser(Util.TokenKey, user.UserId);
            userLiteBindingSource.RemoveCurrent();
            UpdateStatus(dataGridView);
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
         }
      }

      private void UserManager_EditButtonClick(object sender, EventArgs e)
      {
         if (userLiteBindingSource.Current == null)
            return;

         UserInfo uEdit = new UserInfo(userLiteBindingSource.Current as UserLite);
         uEdit.ShowDialog();
      }

      private void UserManager_NewButtonClick(object sender, EventArgs e)
      {
         UserInfo uEdit = new UserInfo(null);
         uEdit.ShowDialog();
      }

      private void UserManager_Load(object sender, EventArgs e)
      {
         GUIUtil.FormatGridView(dataGridView);
         HideExportButton = HidePrintButton = true;

         if (!Util.CheckAccess(AccessPermission.VICS_QuanLyNguoiDung_CapNhat))
            ModifyButton.Enabled = DeleteButton.Enabled = false;

         userLiteBindingSource.DataSource = new List<UserLite>(Util.AgencyGateway.FindUsers(Util.TokenKey, string.Empty));
         UpdateStatus(dataGridView);
      }

      private void searchButton_Click(object sender, EventArgs e)
      {
         userLiteBindingSource.DataSource = new List<UserLite>(Util.AgencyGateway.FindUsers(Util.TokenKey, customerIdBox.Text.Trim()));
         UpdateStatus(dataGridView);
      }
   }
}
