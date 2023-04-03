namespace Brokery.Security
{
   partial class UserManager
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
         this.dataGridView = new System.Windows.Forms.DataGridView();
         this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.UserTransCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.branchCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tradeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.userLiteBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.customerIdBox = new System.Windows.Forms.ToolStripTextBox();
         this.searchButton = new System.Windows.Forms.ToolStripButton();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.userLiteBindingSource)).BeginInit();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.dataGridView);
         this.panel1.Controls.Add(this.toolStrip1);
         this.panel1.Size = new System.Drawing.Size(817, 480);
         // 
         // dataGridView
         // 
         this.dataGridView.AutoGenerateColumns = false;
         this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.UserTransCode,
            this.branchCodeDataGridViewTextBoxColumn,
            this.tradeCodeDataGridViewTextBoxColumn,
            this.Status});
         this.dataGridView.DataSource = this.userLiteBindingSource;
         this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView.Location = new System.Drawing.Point(0, 25);
         this.dataGridView.MultiSelect = false;
         this.dataGridView.Name = "dataGridView";
         this.dataGridView.RowHeadersWidth = 20;
         this.dataGridView.Size = new System.Drawing.Size(817, 455);
         this.dataGridView.TabIndex = 3;
         // 
         // userNameDataGridViewTextBoxColumn
         // 
         this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
         this.userNameDataGridViewTextBoxColumn.HeaderText = "Tên đăng nhập";
         this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
         // 
         // fullNameDataGridViewTextBoxColumn
         // 
         this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
         this.fullNameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
         this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
         // 
         // UserTransCode
         // 
         this.UserTransCode.DataPropertyName = "UserTransCode";
         this.UserTransCode.HeaderText = "Mã giao dịch";
         this.UserTransCode.Name = "UserTransCode";
         // 
         // branchCodeDataGridViewTextBoxColumn
         // 
         this.branchCodeDataGridViewTextBoxColumn.DataPropertyName = "BranchCode";
         this.branchCodeDataGridViewTextBoxColumn.HeaderText = "Mã đơn vị";
         this.branchCodeDataGridViewTextBoxColumn.Name = "branchCodeDataGridViewTextBoxColumn";
         // 
         // tradeCodeDataGridViewTextBoxColumn
         // 
         this.tradeCodeDataGridViewTextBoxColumn.DataPropertyName = "TradeCode";
         this.tradeCodeDataGridViewTextBoxColumn.HeaderText = "Mã giao dịch";
         this.tradeCodeDataGridViewTextBoxColumn.Name = "tradeCodeDataGridViewTextBoxColumn";
         // 
         // Status
         // 
         this.Status.DataPropertyName = "Status";
         this.Status.HeaderText = "Trạng thái";
         this.Status.Name = "Status";
         // 
         // userLiteBindingSource
         // 
         this.userLiteBindingSource.DataSource = typeof(Brokery.AgencyWebService.UserLite);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.customerIdBox,
            this.searchButton});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(817, 25);
         this.toolStrip1.TabIndex = 2;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
         this.toolStripLabel1.Text = "Tên truy cập";
         // 
         // customerIdBox
         // 
         this.customerIdBox.Name = "customerIdBox";
         this.customerIdBox.Size = new System.Drawing.Size(100, 25);
         // 
         // searchButton
         // 
         this.searchButton.Image = global::Brokery.Properties.Resources.find;
         this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.searchButton.Name = "searchButton";
         this.searchButton.Size = new System.Drawing.Size(67, 22);
         this.searchButton.Text = "&Tìm kiếm";
         this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
         // 
         // UserManager
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(817, 527);
         this.HideDeleteButton = false;
         this.HideExportButton = false;
         this.HidePrintButton = false;
         this.Name = "UserManager";
         this.Text = "Quản lý người dùng";
         this.Load += new System.EventHandler(this.UserManager_Load);
         this.DeleteButtonClick += new System.EventHandler(this.UserManager_DeleteButtonClick);
         this.EditButtonClick += new System.EventHandler(this.UserManager_EditButtonClick);
         this.NewButtonClick += new System.EventHandler(this.UserManager_NewButtonClick);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.userLiteBindingSource)).EndInit();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DataGridView dataGridView;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox customerIdBox;
      private System.Windows.Forms.ToolStripButton searchButton;
      private System.Windows.Forms.BindingSource userLiteBindingSource;
      private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn UserTransCode;
      private System.Windows.Forms.DataGridViewTextBoxColumn branchCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tradeCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn Status;
   }
}