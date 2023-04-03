using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Brokery.AgencyWebService;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Security
{
   public partial class GroupManager : ListFormBase
   {
      public GroupManager()
      {
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_QuanLyNhom; }
      }

      private void GroupManager_NewButtonClick(object sender, EventArgs e)
      {
         InputDiaglogBox.Result result = InputDiaglogBox.Show("Nhập tên nhóm mới:", string.Empty, "Thêm mới nhóm");
         if (!result.IsOK)
            return;

         UserGroup group = new UserGroup();
         group.GroupName = result.InputMessage;
         group = Util.AgencyGateway.InsertOrUpdateUserGroup(Util.TokenKey, group);
         userGroupBindingSource.Add(group);
         UpdateStatus(groupGrid);
      }

      private void GroupManager_EditButtonClick(object sender, EventArgs e)
      {
         if (userGroupBindingSource.Current == null)
            return;
         UserGroup group = userGroupBindingSource.Current as UserGroup;
         InputDiaglogBox.Result result = InputDiaglogBox.Show("Nhập tên nhóm mới:", group.GroupName, "Sửa tên nhóm");
         if (!result.IsOK || string.IsNullOrEmpty(result.InputMessage))
            return;
         group.GroupName = result.InputMessage;
         
         Util.AgencyGateway.InsertOrUpdateUserGroup(Util.TokenKey, group);
         (userGroupBindingSource.Current as UserGroup).GroupName = group.GroupName;
         UpdateStatus(groupGrid);
      }

      private void GroupManager_DeleteButtonClick(object sender, EventArgs e)
      {
         if (userGroupBindingSource.Current == null || ShowQuestion("Bạn có chắc là muốn xóa?") == DialogResult.No)
            return;
         
         UserGroup group = userGroupBindingSource.Current as UserGroup;
         try
         {
            Util.AgencyGateway.DeleteUserGroup(Util.TokenKey, group.GroupId);
            userGroupBindingSource.RemoveCurrent();
            UpdateStatus(groupGrid);
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
         }
      }

      private void GroupManager_Load(object sender, EventArgs e)
      {
         GUIUtil.FormatGridView(userGrid);
         GUIUtil.FormatGridView(groupGrid);
         
         if (!Util.CheckAccess(AccessPermission.VICS_QuanLyNguoiDung_CapNhat))
            ModifyButton.Enabled = DeleteButton.Enabled = false;

         userGroupBindingSource.DataSource = new List<UserGroup>(Util.AgencyGateway.GetGroups(Util.TokenKey));
         UpdateStatus(groupGrid);
      }

      private void groupGrid_CurrentCellChanged(object sender, EventArgs e)
      {
         if (this.groupGrid.CurrentRow != null)
            userLiteBindingSource.DataSource = Util.AgencyGateway.GetUserList(Util.TokenKey, (userGroupBindingSource.Current as UserGroup).GroupId);
         else
            userLiteBindingSource.DataSource = null;
      }
   }
}
