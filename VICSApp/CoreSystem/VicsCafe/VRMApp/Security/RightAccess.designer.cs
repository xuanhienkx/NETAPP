namespace VRMApp.Security
{
   partial class RightAccess
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RightAccess));
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.gridUser = new System.Windows.Forms.DataGridView();
         this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.userLiteBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.button1 = new System.Windows.Forms.Button();
         this.txtUserName = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.tvRights = new System.Windows.Forms.TreeView();
         this.panel2 = new System.Windows.Forms.Panel();
         this.btnExit = new System.Windows.Forms.Button();
         this.btnOk = new System.Windows.Forms.Button();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.userLiteBindingSource)).BeginInit();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.gridUser);
         this.splitContainer1.Panel1.Controls.Add(this.button1);
         this.splitContainer1.Panel1.Controls.Add(this.txtUserName);
         this.splitContainer1.Panel1.Controls.Add(this.label1);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.tvRights);
         this.splitContainer1.Panel2.Controls.Add(this.panel2);
         this.splitContainer1.Size = new System.Drawing.Size(885, 512);
         this.splitContainer1.SplitterDistance = 294;
         this.splitContainer1.TabIndex = 0;
         // 
         // gridUser
         // 
         this.gridUser.AllowUserToAddRows = false;
         this.gridUser.AllowUserToDeleteRows = false;
         this.gridUser.AutoGenerateColumns = false;
         this.gridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.gridUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn});
         this.gridUser.DataSource = this.userLiteBindingSource;
         this.gridUser.Location = new System.Drawing.Point(3, 52);
         this.gridUser.Name = "gridUser";
         this.gridUser.ReadOnly = true;
         this.gridUser.Size = new System.Drawing.Size(288, 457);
         this.gridUser.TabIndex = 5;
         this.gridUser.SelectionChanged += new System.EventHandler(this.gridUser_SelectionChanged);
         // 
         // userNameDataGridViewTextBoxColumn
         // 
         this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
         this.userNameDataGridViewTextBoxColumn.HeaderText = "Mã đăng nhập";
         this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
         this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // fullNameDataGridViewTextBoxColumn
         // 
         this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
         this.fullNameDataGridViewTextBoxColumn.HeaderText = "Tên người dùng";
         this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
         this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // userLiteBindingSource
         // 
         this.userLiteBindingSource.DataSource = typeof(VRMApp.VRMGateway.UserLite);
         // 
         // button1
         // 
         this.button1.Image = global::VRMApp.Properties.Resources.find;
         this.button1.Location = new System.Drawing.Point(182, 9);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(62, 27);
         this.button1.TabIndex = 4;
         this.button1.Text = "Tìm";
         this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // txtUserName
         // 
         this.txtUserName.Location = new System.Drawing.Point(76, 13);
         this.txtUserName.Name = "txtUserName";
         this.txtUserName.Size = new System.Drawing.Size(100, 20);
         this.txtUserName.TabIndex = 3;
         this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Username:";
         // 
         // tvRights
         // 
         this.tvRights.CheckBoxes = true;
         this.tvRights.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tvRights.FullRowSelect = true;
         this.tvRights.Location = new System.Drawing.Point(0, 0);
         this.tvRights.Name = "tvRights";
         this.tvRights.ShowNodeToolTips = true;
         this.tvRights.Size = new System.Drawing.Size(587, 467);
         this.tvRights.TabIndex = 2;
         this.tvRights.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvRights_AfterCheck);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.btnExit);
         this.panel2.Controls.Add(this.btnOk);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel2.Location = new System.Drawing.Point(0, 467);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(587, 45);
         this.panel2.TabIndex = 1;
         // 
         // btnExit
         // 
         this.btnExit.Image = global::VRMApp.Properties.Resources.cancel;
         this.btnExit.Location = new System.Drawing.Point(312, 8);
         this.btnExit.Name = "btnExit";
         this.btnExit.Size = new System.Drawing.Size(88, 28);
         this.btnExit.TabIndex = 11;
         this.btnExit.Text = "&Thoát";
         this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btnExit.UseVisualStyleBackColor = true;
         this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
         // 
         // btnOk
         // 
         this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.btnOk.Image = global::VRMApp.Properties.Resources.disk;
         this.btnOk.Location = new System.Drawing.Point(186, 8);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(88, 28);
         this.btnOk.TabIndex = 10;
         this.btnOk.Text = "&Lưu";
         this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // RightAccess
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(885, 512);
         this.Controls.Add(this.splitContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "RightAccess";
         this.Text = "Thiết lập quyền truy cập";
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.userLiteBindingSource)).EndInit();
         this.panel2.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.TreeView tvRights;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button btnExit;
      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox txtUserName;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DataGridView gridUser;
      private System.Windows.Forms.BindingSource userLiteBindingSource;
      private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;

   }
}