namespace VRMApp.Accountant
{
    partial class OnlineTransferHistForm
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
          this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
          this.customerIDToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
          this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
          this.accountIDTolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
          this.trangThaiCombo = new System.Windows.Forms.ToolStripComboBox();
          this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
          this.timer = new System.Windows.Forms.Timer(this.components);
          this.dataGridView1 = new System.Windows.Forms.DataGridView();
          this.onlineTransferBindingSource = new System.Windows.Forms.BindingSource(this.components);
          this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
          this.transferIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.transferDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.toAccountIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.currentAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.transferFeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.bankCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.bankBrachCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.transferTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.userProcessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dateProcessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.mainPanel.SuspendLayout();
          this.toolStrip1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.onlineTransferBindingSource)).BeginInit();
          this.SuspendLayout();
          // 
          // mainPanel
          // 
          this.mainPanel.Controls.Add(this.dataGridView1);
          this.mainPanel.Controls.Add(this.toolStrip1);
          this.mainPanel.Size = new System.Drawing.Size(1120, 582);
          // 
          // toolStrip1
          // 
          this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel4,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.customerIDToolStripTextBox,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.accountIDTolStripTextBox,
            this.toolStripSeparator3,
            this.toolStripLabel5,
            this.trangThaiCombo,
            this.toolStripButton1});
          this.toolStrip1.Location = new System.Drawing.Point(0, 0);
          this.toolStrip1.Name = "toolStrip1";
          this.toolStrip1.Size = new System.Drawing.Size(1120, 25);
          this.toolStrip1.TabIndex = 0;
          this.toolStrip1.Text = "toolStrip1";
          // 
          // toolStripLabel1
          // 
          this.toolStripLabel1.Name = "toolStripLabel1";
          this.toolStripLabel1.Size = new System.Drawing.Size(82, 22);
          this.toolStripLabel1.Text = "Ngày yêu cầu:";
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
          // 
          // toolStripLabel4
          // 
          this.toolStripLabel4.Name = "toolStripLabel4";
          this.toolStripLabel4.Size = new System.Drawing.Size(53, 22);
          this.toolStripLabel4.Text = "tới ngày:";
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
          // 
          // toolStripLabel2
          // 
          this.toolStripLabel2.Name = "toolStripLabel2";
          this.toolStripLabel2.Size = new System.Drawing.Size(92, 22);
          this.toolStripLabel2.Text = "Mã khách hàng:";
          // 
          // customerIDToolStripTextBox
          // 
          this.customerIDToolStripTextBox.Name = "customerIDToolStripTextBox";
          this.customerIDToolStripTextBox.Size = new System.Drawing.Size(100, 25);
          // 
          // toolStripSeparator4
          // 
          this.toolStripSeparator4.Name = "toolStripSeparator4";
          this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
          // 
          // toolStripLabel3
          // 
          this.toolStripLabel3.Name = "toolStripLabel3";
          this.toolStripLabel3.Size = new System.Drawing.Size(75, 22);
          this.toolStripLabel3.Text = "Số tài khoản:";
          // 
          // accountIDTolStripTextBox
          // 
          this.accountIDTolStripTextBox.Name = "accountIDTolStripTextBox";
          this.accountIDTolStripTextBox.Size = new System.Drawing.Size(100, 25);
          // 
          // toolStripSeparator3
          // 
          this.toolStripSeparator3.Name = "toolStripSeparator3";
          this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
          // 
          // toolStripLabel5
          // 
          this.toolStripLabel5.Name = "toolStripLabel5";
          this.toolStripLabel5.Size = new System.Drawing.Size(64, 22);
          this.toolStripLabel5.Text = "Trạng thái:";
          // 
          // trangThaiCombo
          // 
          this.trangThaiCombo.Name = "trangThaiCombo";
          this.trangThaiCombo.Size = new System.Drawing.Size(121, 25);
          // 
          // toolStripButton1
          // 
          this.toolStripButton1.Image = global::VRMApp.Properties.Resources.arrow_refresh;
          this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripButton1.Name = "toolStripButton1";
          this.toolStripButton1.Size = new System.Drawing.Size(84, 22);
          this.toolStripButton1.Text = "Lấy dữ liệu";
          this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
          // 
          // dataGridView1
          // 
          this.dataGridView1.AllowUserToAddRows = false;
          this.dataGridView1.AllowUserToDeleteRows = false;
          this.dataGridView1.AutoGenerateColumns = false;
          this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transferIDDataGridViewTextBoxColumn,
            this.transferDateDataGridViewTextBoxColumn,
            this.customerIDDataGridViewTextBoxColumn,
            this.toAccountIDDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.currentAmountDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.transferFeeDataGridViewTextBoxColumn,
            this.bankCodeDataGridViewTextBoxColumn,
            this.bankBrachCodeDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.transferTypeDataGridViewTextBoxColumn,
            this.userProcessDataGridViewTextBoxColumn,
            this.dateProcessDataGridViewTextBoxColumn});
          this.dataGridView1.DataSource = this.onlineTransferBindingSource;
          this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dataGridView1.Location = new System.Drawing.Point(0, 25);
          this.dataGridView1.Name = "dataGridView1";
          this.dataGridView1.ReadOnly = true;
          this.dataGridView1.Size = new System.Drawing.Size(1120, 557);
          this.dataGridView1.TabIndex = 1;
          this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
          // 
          // onlineTransferBindingSource
          // 
          this.onlineTransferBindingSource.DataSource = typeof(VRMApp.VRMGateway.OnlineTransfer);
          // 
          // backgroundWorker1
          // 
          this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
          this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
          // 
          // transferIDDataGridViewTextBoxColumn
          // 
          this.transferIDDataGridViewTextBoxColumn.DataPropertyName = "TransferID";
          this.transferIDDataGridViewTextBoxColumn.HeaderText = "Mã";
          this.transferIDDataGridViewTextBoxColumn.Name = "transferIDDataGridViewTextBoxColumn";
          this.transferIDDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // transferDateDataGridViewTextBoxColumn
          // 
          this.transferDateDataGridViewTextBoxColumn.DataPropertyName = "TransferDate";
          this.transferDateDataGridViewTextBoxColumn.HeaderText = "Ngày yêu cầu";
          this.transferDateDataGridViewTextBoxColumn.Name = "transferDateDataGridViewTextBoxColumn";
          this.transferDateDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // customerIDDataGridViewTextBoxColumn
          // 
          this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
          this.customerIDDataGridViewTextBoxColumn.FillWeight = 200F;
          this.customerIDDataGridViewTextBoxColumn.HeaderText = "Mã khách hàng";
          this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
          this.customerIDDataGridViewTextBoxColumn.ReadOnly = true;
          this.customerIDDataGridViewTextBoxColumn.Width = 200;
          // 
          // toAccountIDDataGridViewTextBoxColumn
          // 
          this.toAccountIDDataGridViewTextBoxColumn.DataPropertyName = "ToAccountID";
          this.toAccountIDDataGridViewTextBoxColumn.HeaderText = "Tài khoản chuyển đến";
          this.toAccountIDDataGridViewTextBoxColumn.Name = "toAccountIDDataGridViewTextBoxColumn";
          this.toAccountIDDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // amountDataGridViewTextBoxColumn
          // 
          this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
          this.amountDataGridViewTextBoxColumn.HeaderText = "Số tiền";
          this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
          this.amountDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // currentAmountDataGridViewTextBoxColumn
          // 
          this.currentAmountDataGridViewTextBoxColumn.DataPropertyName = "CurrentAmount";
          this.currentAmountDataGridViewTextBoxColumn.HeaderText = "CurrentAmount";
          this.currentAmountDataGridViewTextBoxColumn.Name = "currentAmountDataGridViewTextBoxColumn";
          this.currentAmountDataGridViewTextBoxColumn.ReadOnly = true;
          this.currentAmountDataGridViewTextBoxColumn.Visible = false;
          // 
          // descriptionDataGridViewTextBoxColumn
          // 
          this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
          this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
          this.descriptionDataGridViewTextBoxColumn.FillWeight = 200F;
          this.descriptionDataGridViewTextBoxColumn.HeaderText = "Nội dung chuyển tiền";
          this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
          this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // transferFeeDataGridViewTextBoxColumn
          // 
          this.transferFeeDataGridViewTextBoxColumn.DataPropertyName = "TransferFee";
          this.transferFeeDataGridViewTextBoxColumn.HeaderText = "Phí chuyển";
          this.transferFeeDataGridViewTextBoxColumn.Name = "transferFeeDataGridViewTextBoxColumn";
          this.transferFeeDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // bankCodeDataGridViewTextBoxColumn
          // 
          this.bankCodeDataGridViewTextBoxColumn.DataPropertyName = "BankCode";
          this.bankCodeDataGridViewTextBoxColumn.HeaderText = "BankCode";
          this.bankCodeDataGridViewTextBoxColumn.Name = "bankCodeDataGridViewTextBoxColumn";
          this.bankCodeDataGridViewTextBoxColumn.ReadOnly = true;
          this.bankCodeDataGridViewTextBoxColumn.Visible = false;
          // 
          // bankBrachCodeDataGridViewTextBoxColumn
          // 
          this.bankBrachCodeDataGridViewTextBoxColumn.DataPropertyName = "BankBrachCode";
          this.bankBrachCodeDataGridViewTextBoxColumn.HeaderText = "BankBrachCode";
          this.bankBrachCodeDataGridViewTextBoxColumn.Name = "bankBrachCodeDataGridViewTextBoxColumn";
          this.bankBrachCodeDataGridViewTextBoxColumn.ReadOnly = true;
          this.bankBrachCodeDataGridViewTextBoxColumn.Visible = false;
          // 
          // statusDataGridViewTextBoxColumn
          // 
          this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
          this.statusDataGridViewTextBoxColumn.HeaderText = "Trạng thái";
          this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
          this.statusDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // transferTypeDataGridViewTextBoxColumn
          // 
          this.transferTypeDataGridViewTextBoxColumn.DataPropertyName = "TransferType";
          this.transferTypeDataGridViewTextBoxColumn.HeaderText = "TransferType";
          this.transferTypeDataGridViewTextBoxColumn.Name = "transferTypeDataGridViewTextBoxColumn";
          this.transferTypeDataGridViewTextBoxColumn.ReadOnly = true;
          this.transferTypeDataGridViewTextBoxColumn.Visible = false;
          // 
          // userProcessDataGridViewTextBoxColumn
          // 
          this.userProcessDataGridViewTextBoxColumn.DataPropertyName = "UserProcess";
          this.userProcessDataGridViewTextBoxColumn.HeaderText = "Người xử lý";
          this.userProcessDataGridViewTextBoxColumn.Name = "userProcessDataGridViewTextBoxColumn";
          this.userProcessDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // dateProcessDataGridViewTextBoxColumn
          // 
          this.dateProcessDataGridViewTextBoxColumn.DataPropertyName = "DateProcess";
          this.dateProcessDataGridViewTextBoxColumn.HeaderText = "Ngày xử lý";
          this.dateProcessDataGridViewTextBoxColumn.Name = "dateProcessDataGridViewTextBoxColumn";
          this.dateProcessDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // OnlineTransferHistForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(1120, 604);
          this.Name = "OnlineTransferHistForm";
          this.Text = "Lịch sử chuyển tiền trực tuyến";
          this.mainPanel.ResumeLayout(false);
          this.mainPanel.PerformLayout();
          this.toolStrip1.ResumeLayout(false);
          this.toolStrip1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.onlineTransferBindingSource)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.BindingSource onlineTransferBindingSource;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.Timer timer;
      private System.ComponentModel.BackgroundWorker backgroundWorker1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripTextBox customerIDToolStripTextBox;
      private System.Windows.Forms.ToolStripLabel toolStripLabel3;
      private System.Windows.Forms.ToolStripTextBox accountIDTolStripTextBox;
      private System.Windows.Forms.ToolStripLabel toolStripLabel4;
      private System.Windows.Forms.ToolStripComboBox trangThaiCombo;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripLabel toolStripLabel5;
      private System.Windows.Forms.DataGridViewTextBoxColumn transferIDDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn transferDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn toAccountIDDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn currentAmountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn transferFeeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn bankCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn bankBrachCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn transferTypeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn userProcessDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn dateProcessDataGridViewTextBoxColumn;
   }
}