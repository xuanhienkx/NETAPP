using System.Windows.Forms;
using System.ComponentModel;

namespace Brokery.Security
{
   partial class AgencyPermission
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgencyPermission));
          this.bottomPanel = new System.Windows.Forms.Panel();
          this.allPermissionCheckBox = new System.Windows.Forms.CheckBox();
          this.saveButton = new System.Windows.Forms.Button();
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.userGroupTreeView = new System.Windows.Forms.TreeView();
          this.imageList = new System.Windows.Forms.ImageList(this.components);
          this.userGroupToolStrip = new System.Windows.Forms.ToolStrip();
          this.totalGroupLabel = new System.Windows.Forms.ToolStripLabel();
          this.splitContainer2 = new System.Windows.Forms.SplitContainer();
          this.rootTreeNode = new System.Windows.Forms.TreeView();
          this.permissionToolStrip = new System.Windows.Forms.ToolStrip();
          this.groupNameLabel = new System.Windows.Forms.ToolStripLabel();
          this.gridUser = new System.Windows.Forms.DataGridView();
          this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.branchCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tradeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.userLiteBindingSource = new System.Windows.Forms.BindingSource(this.components);
          this.bindingDataWorker = new System.ComponentModel.BackgroundWorker();
          this.bottomPanel.SuspendLayout();
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          this.userGroupToolStrip.SuspendLayout();
          this.splitContainer2.Panel1.SuspendLayout();
          this.splitContainer2.Panel2.SuspendLayout();
          this.splitContainer2.SuspendLayout();
          this.permissionToolStrip.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.userLiteBindingSource)).BeginInit();
          this.SuspendLayout();
          // 
          // bottomPanel
          // 
          this.bottomPanel.Controls.Add(this.allPermissionCheckBox);
          this.bottomPanel.Controls.Add(this.saveButton);
          this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
          this.bottomPanel.Location = new System.Drawing.Point(0, 0);
          this.bottomPanel.Name = "bottomPanel";
          this.bottomPanel.Size = new System.Drawing.Size(550, 38);
          this.bottomPanel.TabIndex = 0;
          // 
          // allPermissionCheckBox
          // 
          this.allPermissionCheckBox.AutoSize = true;
          this.allPermissionCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
          this.allPermissionCheckBox.Location = new System.Drawing.Point(17, 12);
          this.allPermissionCheckBox.Name = "allPermissionCheckBox";
          this.allPermissionCheckBox.Size = new System.Drawing.Size(113, 17);
          this.allPermissionCheckBox.TabIndex = 6;
          this.allPermissionCheckBox.Text = "Chọn tất cả quyền";
          this.allPermissionCheckBox.UseVisualStyleBackColor = true;
          // 
          // saveButton
          // 
          this.saveButton.Cursor = System.Windows.Forms.Cursors.Default;
          this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
          this.saveButton.Location = new System.Drawing.Point(345, 7);
          this.saveButton.Name = "saveButton";
          this.saveButton.Size = new System.Drawing.Size(114, 25);
          this.saveButton.TabIndex = 1;
          this.saveButton.Text = "Cập nhật    ";
          this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
          this.saveButton.UseVisualStyleBackColor = true;
          this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
          // 
          // splitContainer1
          // 
          this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer1.Location = new System.Drawing.Point(0, 0);
          this.splitContainer1.Name = "splitContainer1";
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this.userGroupTreeView);
          this.splitContainer1.Panel1.Controls.Add(this.userGroupToolStrip);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
          this.splitContainer1.Size = new System.Drawing.Size(792, 499);
          this.splitContainer1.SplitterDistance = 238;
          this.splitContainer1.TabIndex = 1;
          // 
          // userGroupTreeView
          // 
          this.userGroupTreeView.BackColor = System.Drawing.SystemColors.Control;
          this.userGroupTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.userGroupTreeView.HideSelection = false;
          this.userGroupTreeView.ImageIndex = 0;
          this.userGroupTreeView.ImageList = this.imageList;
          this.userGroupTreeView.Location = new System.Drawing.Point(0, 0);
          this.userGroupTreeView.Name = "userGroupTreeView";
          this.userGroupTreeView.SelectedImageIndex = 0;
          this.userGroupTreeView.Size = new System.Drawing.Size(238, 474);
          this.userGroupTreeView.TabIndex = 0;
          this.userGroupTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.userGroupTreeView_AfterSelect);
          // 
          // imageList
          // 
          this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
          this.imageList.TransparentColor = System.Drawing.Color.Transparent;
          this.imageList.Images.SetKeyName(0, "sitemap.png");
          this.imageList.Images.SetKeyName(1, "group.png");
          // 
          // userGroupToolStrip
          // 
          this.userGroupToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.userGroupToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalGroupLabel});
          this.userGroupToolStrip.Location = new System.Drawing.Point(0, 474);
          this.userGroupToolStrip.Name = "userGroupToolStrip";
          this.userGroupToolStrip.Size = new System.Drawing.Size(238, 25);
          this.userGroupToolStrip.TabIndex = 1;
          this.userGroupToolStrip.Text = "toolStrip1";
          // 
          // totalGroupLabel
          // 
          this.totalGroupLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
          this.totalGroupLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
          this.totalGroupLabel.ForeColor = System.Drawing.SystemColors.Highlight;
          this.totalGroupLabel.Name = "totalGroupLabel";
          this.totalGroupLabel.Size = new System.Drawing.Size(126, 22);
          this.totalGroupLabel.Text = "Tổng cộng có 0 nhóm";
          // 
          // splitContainer2
          // 
          this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer2.Location = new System.Drawing.Point(0, 0);
          this.splitContainer2.Name = "splitContainer2";
          this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // splitContainer2.Panel1
          // 
          this.splitContainer2.Panel1.Controls.Add(this.rootTreeNode);
          this.splitContainer2.Panel1.Controls.Add(this.bottomPanel);
          this.splitContainer2.Panel1.Controls.Add(this.permissionToolStrip);
          // 
          // splitContainer2.Panel2
          // 
          this.splitContainer2.Panel2.Controls.Add(this.gridUser);
          this.splitContainer2.Size = new System.Drawing.Size(550, 499);
          this.splitContainer2.SplitterDistance = 310;
          this.splitContainer2.TabIndex = 2;
          // 
          // rootTreeNode
          // 
          this.rootTreeNode.BackColor = System.Drawing.Color.WhiteSmoke;
          this.rootTreeNode.CheckBoxes = true;
          this.rootTreeNode.Dock = System.Windows.Forms.DockStyle.Fill;
          this.rootTreeNode.Location = new System.Drawing.Point(0, 38);
          this.rootTreeNode.Name = "rootTreeNode";
          this.rootTreeNode.Size = new System.Drawing.Size(550, 247);
          this.rootTreeNode.TabIndex = 1;
          this.rootTreeNode.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.rootTreeNode_AfterCheck);
          // 
          // permissionToolStrip
          // 
          this.permissionToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.permissionToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupNameLabel});
          this.permissionToolStrip.Location = new System.Drawing.Point(0, 285);
          this.permissionToolStrip.Name = "permissionToolStrip";
          this.permissionToolStrip.Size = new System.Drawing.Size(550, 25);
          this.permissionToolStrip.TabIndex = 2;
          // 
          // groupNameLabel
          // 
          this.groupNameLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
          this.groupNameLabel.ForeColor = System.Drawing.SystemColors.Highlight;
          this.groupNameLabel.Name = "groupNameLabel";
          this.groupNameLabel.Size = new System.Drawing.Size(193, 22);
          this.groupNameLabel.Text = "Danh sách nhân viên thuộc nhóm";
          // 
          // gridUser
          // 
          this.gridUser.AllowUserToAddRows = false;
          this.gridUser.AllowUserToDeleteRows = false;
          this.gridUser.AutoGenerateColumns = false;
          this.gridUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
          this.gridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.gridUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.branchCodeDataGridViewTextBoxColumn,
            this.tradeCodeDataGridViewTextBoxColumn});
          this.gridUser.DataSource = this.userLiteBindingSource;
          this.gridUser.Dock = System.Windows.Forms.DockStyle.Fill;
          this.gridUser.Location = new System.Drawing.Point(0, 0);
          this.gridUser.Name = "gridUser";
          this.gridUser.ReadOnly = true;
          this.gridUser.RowHeadersVisible = false;
          this.gridUser.Size = new System.Drawing.Size(550, 185);
          this.gridUser.TabIndex = 6;
          // 
          // userNameDataGridViewTextBoxColumn
          // 
          this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
          this.userNameDataGridViewTextBoxColumn.HeaderText = "Tên đăng nhập";
          this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
          this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // fullNameDataGridViewTextBoxColumn
          // 
          this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
          this.fullNameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
          this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
          this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // branchCodeDataGridViewTextBoxColumn
          // 
          this.branchCodeDataGridViewTextBoxColumn.DataPropertyName = "BranchCode";
          this.branchCodeDataGridViewTextBoxColumn.HeaderText = "Mã đơn vị";
          this.branchCodeDataGridViewTextBoxColumn.Name = "branchCodeDataGridViewTextBoxColumn";
          this.branchCodeDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // tradeCodeDataGridViewTextBoxColumn
          // 
          this.tradeCodeDataGridViewTextBoxColumn.DataPropertyName = "TradeCode";
          this.tradeCodeDataGridViewTextBoxColumn.HeaderText = "Mã giao dịch";
          this.tradeCodeDataGridViewTextBoxColumn.Name = "tradeCodeDataGridViewTextBoxColumn";
          this.tradeCodeDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // userLiteBindingSource
          // 
          this.userLiteBindingSource.DataSource = typeof(Brokery.AgencyWebService.UserLite);
          // 
          // bindingDataWorker
          // 
          this.bindingDataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bindingDataWorker_DoWork);
          this.bindingDataWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bindingDataWorker_RunWorkerCompleted);
          // 
          // AgencyPermission
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(792, 499);
          this.Controls.Add(this.splitContainer1);
          this.KeyPreview = true;
          this.MinimizeBox = false;
          this.Name = "AgencyPermission";
          this.Text = "Quản lý phân quyền";
          this.Load += new System.EventHandler(this.AgencyPermission_Load);
          this.bottomPanel.ResumeLayout(false);
          this.bottomPanel.PerformLayout();
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel1.PerformLayout();
          this.splitContainer1.Panel2.ResumeLayout(false);
          this.splitContainer1.ResumeLayout(false);
          this.userGroupToolStrip.ResumeLayout(false);
          this.userGroupToolStrip.PerformLayout();
          this.splitContainer2.Panel1.ResumeLayout(false);
          this.splitContainer2.Panel1.PerformLayout();
          this.splitContainer2.Panel2.ResumeLayout(false);
          this.splitContainer2.ResumeLayout(false);
          this.permissionToolStrip.ResumeLayout(false);
          this.permissionToolStrip.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.userLiteBindingSource)).EndInit();
          this.ResumeLayout(false);

      }
      #endregion

      private CheckBox allPermissionCheckBox;
      private Panel bottomPanel;
      private TreeView rootTreeNode;
      private Button saveButton;
      private SplitContainer splitContainer1;
      private SplitContainer splitContainer2;
      private ToolStripLabel totalGroupLabel;
      private ToolStrip userGroupToolStrip;
      private TreeView userGroupTreeView;
      private ToolStrip permissionToolStrip;
      private ToolStripLabel groupNameLabel;
      private DataGridView gridUser;
      private BackgroundWorker bindingDataWorker;
      private ImageList imageList;
      private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn branchCodeDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn tradeCodeDataGridViewTextBoxColumn;
      private BindingSource userLiteBindingSource;
   }
}