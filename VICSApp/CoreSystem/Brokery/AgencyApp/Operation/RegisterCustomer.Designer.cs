namespace Brokery.Operation
{
    partial class RegisterCustomer
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
         this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.customerIdText = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.dataGridView = new System.Windows.Forms.DataGridView();
         this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.customerNameVietDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.accountStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.branchCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tradeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.bankCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.cIFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         this.cboUnitTrade = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.dataGridView);
         this.panel1.Controls.Add(this.toolStrip1);
         this.panel1.Size = new System.Drawing.Size(879, 594);
         // 
         // customerBindingSource
         // 
         this.customerBindingSource.DataSource = typeof(Brokery.AgencyWebService.Customer);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cboUnitTrade,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.customerIdText,
            this.toolStripButton1});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(879, 25);
         this.toolStrip1.TabIndex = 1;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(92, 22);
         this.toolStripLabel1.Text = "Mã khách hàng:";
         // 
         // customerIdText
         // 
         this.customerIdText.Name = "customerIdText";
         this.customerIdText.Size = new System.Drawing.Size(100, 25);
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Image = global::Brokery.Properties.Resources.find;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
         this.toolStripButton1.Text = "&Tìm";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // dataGridView
         // 
         this.dataGridView.AllowUserToAddRows = false;
         this.dataGridView.AllowUserToDeleteRows = false;
         this.dataGridView.AutoGenerateColumns = false;
         this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIdDataGridViewTextBoxColumn,
            this.customerNameVietDataGridViewTextBoxColumn,
            this.accountStatusDataGridViewTextBoxColumn,
            this.branchCodeDataGridViewTextBoxColumn,
            this.tradeCodeDataGridViewTextBoxColumn,
            this.bankCodeDataGridViewTextBoxColumn,
            this.cIFDataGridViewTextBoxColumn});
         this.dataGridView.DataSource = this.customerBindingSource;
         this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView.Location = new System.Drawing.Point(0, 25);
         this.dataGridView.Name = "dataGridView";
         this.dataGridView.ReadOnly = true;
         this.dataGridView.RowHeadersWidth = 20;
         this.dataGridView.Size = new System.Drawing.Size(879, 569);
         this.dataGridView.TabIndex = 2;
         // 
         // customerIdDataGridViewTextBoxColumn
         // 
         this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
         this.customerIdDataGridViewTextBoxColumn.HeaderText = "Mã KH";
         this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
         this.customerIdDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // customerNameVietDataGridViewTextBoxColumn
         // 
         this.customerNameVietDataGridViewTextBoxColumn.DataPropertyName = "CustomerNameViet";
         this.customerNameVietDataGridViewTextBoxColumn.HeaderText = "Tên khách hàng";
         this.customerNameVietDataGridViewTextBoxColumn.Name = "customerNameVietDataGridViewTextBoxColumn";
         this.customerNameVietDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // accountStatusDataGridViewTextBoxColumn
         // 
         this.accountStatusDataGridViewTextBoxColumn.DataPropertyName = "AccountStatus";
         this.accountStatusDataGridViewTextBoxColumn.HeaderText = "Trạng thái";
         this.accountStatusDataGridViewTextBoxColumn.Name = "accountStatusDataGridViewTextBoxColumn";
         this.accountStatusDataGridViewTextBoxColumn.ReadOnly = true;
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
         // bankCodeDataGridViewTextBoxColumn
         // 
         this.bankCodeDataGridViewTextBoxColumn.DataPropertyName = "BankCode";
         this.bankCodeDataGridViewTextBoxColumn.HeaderText = "Tài khoản NH";
         this.bankCodeDataGridViewTextBoxColumn.Name = "bankCodeDataGridViewTextBoxColumn";
         this.bankCodeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // cIFDataGridViewTextBoxColumn
         // 
         this.cIFDataGridViewTextBoxColumn.DataPropertyName = "CIF";
         this.cIFDataGridViewTextBoxColumn.HeaderText = "CIF";
         this.cIFDataGridViewTextBoxColumn.Name = "cIFDataGridViewTextBoxColumn";
         this.cIFDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // backgroundWorker
         // 
         this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
         this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
         // 
         // toolStripLabel2
         // 
         this.toolStripLabel2.Name = "toolStripLabel2";
         this.toolStripLabel2.Size = new System.Drawing.Size(86, 22);
         this.toolStripLabel2.Text = "Đơn vị quản lý:";
         // 
         // cboUnitTrade
         // 
         this.cboUnitTrade.Name = "cboUnitTrade";
         this.cboUnitTrade.Size = new System.Drawing.Size(121, 25);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // RegisterCustomer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(879, 641);
         this.HideDeleteButton = false;
         this.HideExportButton = false;
         this.HidePrintButton = false;
         this.Name = "RegisterCustomer";
         this.Text = "Danh sách khách hàng";
         this.NewButtonClick += new System.EventHandler(this.RegisterCustomer_NewButtonClick);
         this.DeleteButtonClick += new System.EventHandler(this.RegisterCustomer_DeleteButtonClick);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.BindingSource customerBindingSource;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox customerIdText;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.DataGridView dataGridView;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerNameVietDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn accountStatusDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn branchCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tradeCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn bankCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn cIFDataGridViewTextBoxColumn;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripComboBox cboUnitTrade;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
   }
}