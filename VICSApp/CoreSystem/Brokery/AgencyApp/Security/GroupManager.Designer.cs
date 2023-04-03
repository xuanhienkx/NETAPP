using System.Windows.Forms;

namespace Brokery.Security
{
   partial class GroupManager
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
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.userGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.userGrid = new System.Windows.Forms.DataGridView();
         this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.branchCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tradeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.userLiteBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.groupGrid = new System.Windows.Forms.DataGridView();
         this.panel1.SuspendLayout();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(groupGrid)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.userGroupBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.userGrid)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.userLiteBindingSource)).BeginInit();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.splitContainer1);
         this.panel1.Size = new System.Drawing.Size(827, 388);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(groupGrid);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.userGrid);
         this.splitContainer1.Size = new System.Drawing.Size(827, 388);
         this.splitContainer1.SplitterDistance = 275;
         this.splitContainer1.TabIndex = 0;
         // 
         // groupGrid
         // 
         groupGrid.AllowUserToAddRows = false;
         groupGrid.AllowUserToDeleteRows = false;
         groupGrid.AutoGenerateColumns = false;
         groupGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         groupGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         groupGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupNameDataGridViewTextBoxColumn});
         groupGrid.DataSource = this.userGroupBindingSource;
         groupGrid.Dock = System.Windows.Forms.DockStyle.Fill;
         groupGrid.Location = new System.Drawing.Point(0, 0);
         groupGrid.MultiSelect = false;
         groupGrid.Name = "groupGrid";
         groupGrid.ReadOnly = true;
         groupGrid.RowHeadersWidth = 20;
         groupGrid.Size = new System.Drawing.Size(275, 388);
         groupGrid.TabIndex = 0;
         groupGrid.CurrentCellChanged += new System.EventHandler(this.groupGrid_CurrentCellChanged);
         // 
         // groupNameDataGridViewTextBoxColumn
         // 
         this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "GroupName";
         this.groupNameDataGridViewTextBoxColumn.HeaderText = "Nhóm làm việc";
         this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
         this.groupNameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // userGroupBindingSource
         // 
         this.userGroupBindingSource.DataSource = typeof(Brokery.AgencyWebService.UserGroup);
         // 
         // userGrid
         // 
         this.userGrid.AllowUserToAddRows = false;
         this.userGrid.AllowUserToDeleteRows = false;
         this.userGrid.AutoGenerateColumns = false;
         this.userGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.userGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.userGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.branchCodeDataGridViewTextBoxColumn,
            this.tradeCodeDataGridViewTextBoxColumn});
         this.userGrid.DataSource = this.userLiteBindingSource;
         this.userGrid.Dock = System.Windows.Forms.DockStyle.Fill;
         this.userGrid.Location = new System.Drawing.Point(0, 0);
         this.userGrid.Name = "userGrid";
         this.userGrid.ReadOnly = true;
         this.userGrid.RowHeadersVisible = false;
         this.userGrid.RowHeadersWidth = 20;
         this.userGrid.Size = new System.Drawing.Size(548, 388);
         this.userGrid.TabIndex = 0;
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
         // GroupManager
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(827, 435);
         this.HideDeleteButton = false;
         this.HideExportButton = true;
         this.HidePrintButton = true;
         this.Name = "GroupManager";
         this.Text = "Quản lý nhóm người sử dụng";
         this.Load += new System.EventHandler(this.GroupManager_Load);
         this.DeleteButtonClick += new System.EventHandler(this.GroupManager_DeleteButtonClick);
         this.EditButtonClick += new System.EventHandler(this.GroupManager_EditButtonClick);
         this.NewButtonClick += new System.EventHandler(this.GroupManager_NewButtonClick);
         this.panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(groupGrid)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.userGroupBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.userGrid)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.userLiteBindingSource)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private SplitContainer splitContainer1;
      private BindingSource userGroupBindingSource;
      private DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
      private DataGridView userGrid;
      private DataGridView groupGrid;
      private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn branchCodeDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn tradeCodeDataGridViewTextBoxColumn;
      private BindingSource userLiteBindingSource;
   }
}