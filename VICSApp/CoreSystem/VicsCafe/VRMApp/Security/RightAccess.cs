using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.Framework;
using System.Data.SqlClient;
using VRMApp.ControlBase;
using VRMApp.VRMGateway;

namespace VRMApp.Security
{
   public partial class RightAccess : FormBase
   {
      public RightAccess()
      {
         InitializeComponent();
         AccessUtil.BindingAllPermission(tvRights);
         GUIUtil.FormatGridView(gridUser);
      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void btnOk_Click(object sender, EventArgs e)
      {
         if (gridUser.SelectedRows.Count <= 0)
            return;

         UserLite user = userLiteBindingSource.Current as UserLite;
         List<string> newRights = new List<string>();
         foreach (TreeNode n in tvRights.Nodes)
         {
            foreach (TreeNode sn in n.Nodes)
            {
               if (sn.Checked)
                  newRights.Add(sn.Name);
            }
         }
         Util.VRMService.UpdateUserAccessString(Util.TokenKey, newRights.ToArray(), user.UserId);

         MessageBox.Show("Phân quyền hoàn tất", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void UpdateRightForCurrentUser(UserLite user)
      {
         List<string> userRights = new List<string>(Util.VRMService.GetUserAccessString(Util.TokenKey, user.UserId));
         tvRights.BeginUpdate();
         bool expend;
         foreach (TreeNode n in tvRights.Nodes)
         {
            expend = false;
            foreach (TreeNode sn in n.Nodes)
            {
               sn.Checked = Util.CheckAccess(sn.Name, userRights);
               if (sn.Checked) expend = true;
            }
            if (expend)
               n.Expand();
            tvRights.BeginUpdate();
            //n.Checked = expend;
            tvRights.EndUpdate();
         }

         tvRights.EndUpdate();
      }

      private void tvRights_AfterCheck(object sender, TreeViewEventArgs e)
      {
         if (e.Node.Checked)
            e.Node.ExpandAll();

         foreach (TreeNode n in e.Node.Nodes)
            n.Checked = n.Parent.Checked;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         userLiteBindingSource.DataSource = Util.VRMService.FindUsers(Util.TokenKey, txtUserName.Text.Trim());
      }

      private void gridUser_SelectionChanged(object sender, EventArgs e)
      {
         if (gridUser.SelectedRows.Count <= 0)
            return;
         UpdateRightForCurrentUser(userLiteBindingSource.Current as UserLite);
      }

      private void txtUserName_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            button1.PerformClick();
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.Quantri_PhanQuyen);
      }
   }
}
