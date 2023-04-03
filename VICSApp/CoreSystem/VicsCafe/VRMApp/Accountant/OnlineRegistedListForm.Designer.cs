namespace VRMApp.Accountant
{
   partial class OnlineRegistedListForm
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
          this.toolStrip1 = new System.Windows.Forms.ToolStrip();
          this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
          this.maKHBox = new System.Windows.Forms.ToolStripTextBox();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
          this.accountIDToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
          this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
          this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
          this.dataGridView1 = new System.Windows.Forms.DataGridView();
          this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.accountIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.accountNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.isAuthorizationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.bankCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.bankBranchCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.cardIdentityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.cardDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.cardIssuerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.userCreateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dateCreateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.ActiveTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.accountTransferBindingSource = new System.Windows.Forms.BindingSource(this.components);
          this.mainPanel.SuspendLayout();
          this.toolStrip1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.accountTransferBindingSource)).BeginInit();
          this.SuspendLayout();
          // 
          // mainPanel
          // 
          this.mainPanel.Controls.Add(this.dataGridView1);
          this.mainPanel.Controls.Add(this.toolStrip1);
          this.mainPanel.Size = new System.Drawing.Size(1022, 648);
          this.mainPanel.Controls.SetChildIndex(this.toolStrip1, 0);
          this.mainPanel.Controls.SetChildIndex(this.dataGridView1, 0);
          // 
          // toolStrip1
          // 
          this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.maKHBox,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.accountIDToolStripTextBox,
            this.toolStripButton1});
          this.toolStrip1.Location = new System.Drawing.Point(0, 25);
          this.toolStrip1.Name = "toolStrip1";
          this.toolStrip1.Size = new System.Drawing.Size(1022, 25);
          this.toolStrip1.TabIndex = 2;
          this.toolStrip1.Text = "toolStrip1";
          // 
          // toolStripLabel3
          // 
          this.toolStripLabel3.Name = "toolStripLabel3";
          this.toolStripLabel3.Size = new System.Drawing.Size(46, 22);
          this.toolStripLabel3.Text = "Mã KH:";
          // 
          // maKHBox
          // 
          this.maKHBox.Name = "maKHBox";
          this.maKHBox.Size = new System.Drawing.Size(100, 25);
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
          // 
          // toolStripLabel1
          // 
          this.toolStripLabel1.Name = "toolStripLabel1";
          this.toolStripLabel1.Size = new System.Drawing.Size(75, 22);
          this.toolStripLabel1.Text = "Số tài khoản:";
          // 
          // accountIDToolStripTextBox
          // 
          this.accountIDToolStripTextBox.Name = "accountIDToolStripTextBox";
          this.accountIDToolStripTextBox.Size = new System.Drawing.Size(150, 25);
          // 
          // toolStripButton1
          // 
          this.toolStripButton1.Image = global::VRMApp.Properties.Resources.find;
          this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripButton1.Name = "toolStripButton1";
          this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
          this.toolStripButton1.Text = "&Tìm";
          this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
          // 
          // backgroundWorker
          // 
          this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
          this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
          // 
          // dataGridView1
          // 
          this.dataGridView1.AllowUserToAddRows = false;
          this.dataGridView1.AllowUserToDeleteRows = false;
          this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.dataGridView1.AutoGenerateColumns = false;
          this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIDDataGridViewTextBoxColumn,
            this.accountIDDataGridViewTextBoxColumn,
            this.accountNameDataGridViewTextBoxColumn,
            this.isAuthorizationDataGridViewTextBoxColumn,
            this.bankCodeDataGridViewTextBoxColumn,
            this.bankBranchCodeDataGridViewTextBoxColumn,
            this.cardIdentityDataGridViewTextBoxColumn,
            this.cardDateDataGridViewTextBoxColumn,
            this.cardIssuerDataGridViewTextBoxColumn,
            this.userCreateDataGridViewTextBoxColumn,
            this.dateCreateDataGridViewTextBoxColumn,
            this.ActiveTextBox});
          this.dataGridView1.DataSource = this.accountTransferBindingSource;
          this.dataGridView1.Location = new System.Drawing.Point(0, 53);
          this.dataGridView1.Name = "dataGridView1";
          this.dataGridView1.ReadOnly = true;
          this.dataGridView1.Size = new System.Drawing.Size(1010, 592);
          this.dataGridView1.TabIndex = 3;
          this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
          this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
          // 
          // customerIDDataGridViewTextBoxColumn
          // 
          this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
          this.customerIDDataGridViewTextBoxColumn.HeaderText = "Mã khách hàng";
          this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
          this.customerIDDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // accountIDDataGridViewTextBoxColumn
          // 
          this.accountIDDataGridViewTextBoxColumn.DataPropertyName = "AccountID";
          this.accountIDDataGridViewTextBoxColumn.HeaderText = "Số tài khoản";
          this.accountIDDataGridViewTextBoxColumn.Name = "accountIDDataGridViewTextBoxColumn";
          this.accountIDDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // accountNameDataGridViewTextBoxColumn
          // 
          this.accountNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
          this.accountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName";
          this.accountNameDataGridViewTextBoxColumn.FillWeight = 150F;
          this.accountNameDataGridViewTextBoxColumn.HeaderText = "Tên tài khoản";
          this.accountNameDataGridViewTextBoxColumn.Name = "accountNameDataGridViewTextBoxColumn";
          this.accountNameDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // isAuthorizationDataGridViewTextBoxColumn
          // 
          this.isAuthorizationDataGridViewTextBoxColumn.DataPropertyName = "isAuthorization";
          this.isAuthorizationDataGridViewTextBoxColumn.FillWeight = 80F;
          this.isAuthorizationDataGridViewTextBoxColumn.HeaderText = "Ủy quyền";
          this.isAuthorizationDataGridViewTextBoxColumn.Name = "isAuthorizationDataGridViewTextBoxColumn";
          this.isAuthorizationDataGridViewTextBoxColumn.ReadOnly = true;
          this.isAuthorizationDataGridViewTextBoxColumn.Width = 80;
          // 
          // bankCodeDataGridViewTextBoxColumn
          // 
          this.bankCodeDataGridViewTextBoxColumn.DataPropertyName = "BankCode";
          this.bankCodeDataGridViewTextBoxColumn.HeaderText = "Ngân hàng";
          this.bankCodeDataGridViewTextBoxColumn.Name = "bankCodeDataGridViewTextBoxColumn";
          this.bankCodeDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // bankBranchCodeDataGridViewTextBoxColumn
          // 
          this.bankBranchCodeDataGridViewTextBoxColumn.DataPropertyName = "BankBranchCode";
          this.bankBranchCodeDataGridViewTextBoxColumn.HeaderText = "Chi nhánh";
          this.bankBranchCodeDataGridViewTextBoxColumn.Name = "bankBranchCodeDataGridViewTextBoxColumn";
          this.bankBranchCodeDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // cardIdentityDataGridViewTextBoxColumn
          // 
          this.cardIdentityDataGridViewTextBoxColumn.DataPropertyName = "CardIdentity";
          this.cardIdentityDataGridViewTextBoxColumn.HeaderText = "Số CMT";
          this.cardIdentityDataGridViewTextBoxColumn.Name = "cardIdentityDataGridViewTextBoxColumn";
          this.cardIdentityDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // cardDateDataGridViewTextBoxColumn
          // 
          this.cardDateDataGridViewTextBoxColumn.DataPropertyName = "CardDate";
          this.cardDateDataGridViewTextBoxColumn.HeaderText = "Ngày cấp";
          this.cardDateDataGridViewTextBoxColumn.Name = "cardDateDataGridViewTextBoxColumn";
          this.cardDateDataGridViewTextBoxColumn.ReadOnly = true;
          this.cardDateDataGridViewTextBoxColumn.Visible = false;
          // 
          // cardIssuerDataGridViewTextBoxColumn
          // 
          this.cardIssuerDataGridViewTextBoxColumn.DataPropertyName = "CardIssuer";
          this.cardIssuerDataGridViewTextBoxColumn.HeaderText = "Nơi cấp";
          this.cardIssuerDataGridViewTextBoxColumn.Name = "cardIssuerDataGridViewTextBoxColumn";
          this.cardIssuerDataGridViewTextBoxColumn.ReadOnly = true;
          this.cardIssuerDataGridViewTextBoxColumn.Visible = false;
          // 
          // userCreateDataGridViewTextBoxColumn
          // 
          this.userCreateDataGridViewTextBoxColumn.DataPropertyName = "UserCreate";
          this.userCreateDataGridViewTextBoxColumn.HeaderText = "Người tạo";
          this.userCreateDataGridViewTextBoxColumn.Name = "userCreateDataGridViewTextBoxColumn";
          this.userCreateDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // dateCreateDataGridViewTextBoxColumn
          // 
          this.dateCreateDataGridViewTextBoxColumn.DataPropertyName = "DateCreate";
          this.dateCreateDataGridViewTextBoxColumn.HeaderText = "Ngày tạo";
          this.dateCreateDataGridViewTextBoxColumn.Name = "dateCreateDataGridViewTextBoxColumn";
          this.dateCreateDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // ActiveTextBox
          // 
          this.ActiveTextBox.DataPropertyName = "Active";
          this.ActiveTextBox.HeaderText = "Trạng thái";
          this.ActiveTextBox.Name = "ActiveTextBox";
          this.ActiveTextBox.ReadOnly = true;
          this.ActiveTextBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
          this.ActiveTextBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
          // 
          // accountTransferBindingSource
          // 
          this.accountTransferBindingSource.DataSource = typeof(VRMApp.VRMGateway.AccountTransfer);
          // 
          // OnlineRegistedListForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(1022, 670);
          this.HideDeleteButton = false;
          this.HidePrintButton = false;
          this.Name = "OnlineRegistedListForm";
          this.Text = "Danh sách tài khoản đăng ký dịch vụ chuyển tiền";
          this.DeleteButtonClick += new System.EventHandler(this.ContractListForm_DeleteButtonClick);
          this.PrintButtonClick += new System.EventHandler(this.OnlineRegistedListForm_PrintButtonClick);
          this.EditButtonClick += new System.EventHandler(this.BankListForm_EditButtonClick);
          this.NewButtonClick += new System.EventHandler(this.BankListForm_NewButtonClick);
          this.mainPanel.ResumeLayout(false);
          this.mainPanel.PerformLayout();
          this.toolStrip1.ResumeLayout(false);
          this.toolStrip1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.accountTransferBindingSource)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.DataGridViewTextBoxColumn producTypeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn expireDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn approveDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn approveByDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.BindingSource accountTransferBindingSource;
      private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripLabel toolStripLabel3;
      private System.Windows.Forms.ToolStripTextBox maKHBox;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox accountIDToolStripTextBox;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn accountIDDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn accountNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn isAuthorizationDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn bankCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn bankBranchCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn cardIdentityDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn cardDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn cardIssuerDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn userCreateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn dateCreateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn ActiveTextBox;

   }
}