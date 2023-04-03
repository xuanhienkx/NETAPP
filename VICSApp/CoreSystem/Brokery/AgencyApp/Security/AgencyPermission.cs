using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Brokery.AgencyWebService;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Security
{
   public partial class AgencyPermission : FormBase
   {
      private delegate void UpdateTreeOnGUI(string[] userRights);
      private delegate void UpdateGridOnGUI(UserLite[] userLites);
      List<UserGroup> groups;

      public AgencyPermission()
      {
         InitializeComponent();
         GUIUtil.FormatGridView(gridUser);

         groups = new List<UserGroup>(Util.AgencyGateway.GetGroups(Util.TokenKey));
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_PhanQuyen; }
      }

      private void AgencyPermission_Load(object sender, EventArgs e)
      {
         AccessBuilding.BindingAllPermission(rootTreeNode);
         BindingGroups();
      }

      private void BindingGroups()
      {
         TreeNode node = new TreeNode(string.Format("Nhóm quyền {0}", Util.LoginUser.AgencyName), 0, 0);
         this.userGroupTreeView.Nodes.Add(node);

         foreach (UserGroup g in groups)
         {
            TreeNode child = new TreeNode(g.GroupName, 1, 1);
            child.Tag = g;
            node.Nodes.Add(child);
         }

         this.userGroupTreeView.Nodes[0].Expand();
         this.totalGroupLabel.Text = string.Format("Có {0:n0} nhóm quyền", this.userGroupTreeView.Nodes[0].Nodes.Count);
      }

      private void userGroupTreeView_AfterSelect(object sender, TreeViewEventArgs e)
      {
         if (e.Action == TreeViewAction.Collapse || e.Node.SelectedImageIndex == 0)
            rootTreeNode.Enabled = false;
         else
         {
            rootTreeNode.Enabled = true;
            if (!bindingDataWorker.IsBusy && !bindingDataWorker.CancellationPending)
               bindingDataWorker.RunWorkerAsync(e.Node.Tag as UserGroup);
         }
      }

      private void bindingDataWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         UserGroup g = e.Argument as UserGroup;
         string[] rules = Util.AgencyGateway.GetGroupPermission(Util.TokenKey, g.GroupId);
         UpdateOnTree(rules);
         
         UpdateDataOnGrid(Util.AgencyGateway.GetUserList(Util.TokenKey, g.GroupId));
      }

      private void UpdateDataOnGrid(UserLite[] userLite)
      {
         if (gridUser.InvokeRequired)
            gridUser.Invoke(new UpdateGridOnGUI(UpdateDataOnGrid), new object[]{userLite});
         else
            userLiteBindingSource.DataSource = userLite;
      }

      private void bindingDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Error != null)
            ShowError(e.Error.Message);
      }

      private void UpdateOnTree(string[] rights)
      {
         if (rootTreeNode.InvokeRequired)
         {
            rootTreeNode.Invoke(new UpdateTreeOnGUI(UpdateOnTree), new object[] { rights });
         }
         else
         {
            rootTreeNode.BeginUpdate();

            bool isChecked;
            foreach (TreeNode n in rootTreeNode.Nodes)
            {
               isChecked = false;
               foreach (TreeNode sn in n.Nodes)
               {
                  sn.Checked = rights.Contains(sn.Name);
                  if (sn.Checked)
                     isChecked = true;
               }
               n.Checked = isChecked;
            }

            rootTreeNode.EndUpdate();
         }
      }

      private void rootTreeNode_AfterCheck(object sender, TreeViewEventArgs e)
      {
         if (e.Node.Checked)
            e.Node.ExpandAll();

         foreach (TreeNode n in e.Node.Nodes)
            n.Checked = n.Parent.Checked;
      }

      private void saveButton_Click(object sender, EventArgs e)
      {
         if (userGroupTreeView.SelectedNode == null)
            return;
         UserGroup g = userGroupTreeView.SelectedNode.Tag as UserGroup;
         List<string> rights = new List<string>();
         foreach (TreeNode n in rootTreeNode.Nodes)
         {
            foreach (TreeNode sn in n.Nodes)
            {
               if (sn.Checked)
                  rights.Add(sn.Name);
            }
         }

         try
         {
            Util.AgencyGateway.SetGroupPermission(Util.TokenKey, g.GroupId, rights.ToArray());
            ShowNotice("Phân quyền hoàn tất.");
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
         }
      }
   }
}
