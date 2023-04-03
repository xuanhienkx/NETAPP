namespace VRMApp.Brokerage
{
   partial class ContractListForm
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
         this.maKHBox = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
         this.comboStatus = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.giahanButton = new System.Windows.Forms.ToolStripButton();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.ContractID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ContractType = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ContractStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.BranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.TradeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ContractDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ExpiredDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.interestRatePerDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.interestRatePenaltyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.registeredAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.approvalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ApprovedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.disbursedAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.DisbursedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.DisbursedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.withdrawAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.WithdrawBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.WithdrawDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.interestAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.contractBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.mainPanel.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).BeginInit();
         this.SuspendLayout();
         // 
         // mainPanel
         // 
         this.mainPanel.Controls.Add(this.dataGridView1);
         this.mainPanel.Controls.Add(this.toolStrip1);
         this.mainPanel.Size = new System.Drawing.Size(1005, 647);
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
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.toolStripLabel4,
            this.comboStatus,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.giahanButton});
         this.toolStrip1.Location = new System.Drawing.Point(0, 25);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(1005, 25);
         this.toolStrip1.TabIndex = 2;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel3
         // 
         this.toolStripLabel3.Name = "toolStripLabel3";
         this.toolStripLabel3.Size = new System.Drawing.Size(41, 22);
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
         this.toolStripLabel1.Size = new System.Drawing.Size(51, 22);
         this.toolStripLabel1.Text = "Từ ngày:";
         // 
         // toolStripLabel2
         // 
         this.toolStripLabel2.Name = "toolStripLabel2";
         this.toolStripLabel2.Size = new System.Drawing.Size(58, 22);
         this.toolStripLabel2.Text = "Đến ngày:";
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripLabel4
         // 
         this.toolStripLabel4.Name = "toolStripLabel4";
         this.toolStripLabel4.Size = new System.Drawing.Size(60, 22);
         this.toolStripLabel4.Text = "Trạng thái:";
         // 
         // comboStatus
         // 
         this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboStatus.Name = "comboStatus";
         this.comboStatus.Size = new System.Drawing.Size(121, 25);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Image = global::VRMApp.Properties.Resources.find;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(43, 22);
         this.toolStripButton1.Text = "&Tìm";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
         // 
         // giahanButton
         // 
         this.giahanButton.Enabled = false;
         this.giahanButton.Image = global::VRMApp.Properties.Resources.arrow_rotate_clockwise;
         this.giahanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.giahanButton.Name = "giahanButton";
         this.giahanButton.Size = new System.Drawing.Size(111, 22);
         this.giahanButton.Text = "Gia hạn hợp đồng";
         this.giahanButton.Click += new System.EventHandler(this.giahanButton_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.AutoGenerateColumns = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractID,
            this.CustomerID,
            this.CustomerName,
            this.ContractType,
            this.ContractStatus,
            this.BranchCode,
            this.TradeCode,
            this.ContractDueDate,
            this.ExpiredDate,
            this.interestRatePerDayDataGridViewTextBoxColumn,
            this.interestRatePenaltyDataGridViewTextBoxColumn,
            this.registeredAmountDataGridViewTextBoxColumn,
            this.CreatedBy,
            this.CreatedDate,
            this.approvalAmountDataGridViewTextBoxColumn,
            this.ApprovedBy,
            this.ApprovedDate,
            this.disbursedAmountDataGridViewTextBoxColumn,
            this.DisbursedBy,
            this.DisbursedDate,
            this.withdrawAmountDataGridViewTextBoxColumn,
            this.WithdrawBy,
            this.WithdrawDate,
            this.interestAmountDataGridViewTextBoxColumn});
         this.dataGridView1.DataSource = this.contractBindingSource;
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point(0, 50);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.Size = new System.Drawing.Size(1005, 597);
         this.dataGridView1.TabIndex = 3;
         this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
         this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
         // 
         // ContractID
         // 
         this.ContractID.DataPropertyName = "ContractID";
         this.ContractID.HeaderText = "Số HĐ";
         this.ContractID.Name = "ContractID";
         this.ContractID.ReadOnly = true;
         // 
         // CustomerID
         // 
         this.CustomerID.DataPropertyName = "CustomerID";
         this.CustomerID.HeaderText = "Mã KH";
         this.CustomerID.Name = "CustomerID";
         this.CustomerID.ReadOnly = true;
         // 
         // CustomerName
         // 
         this.CustomerName.DataPropertyName = "CustomerName";
         this.CustomerName.HeaderText = "Tên KH";
         this.CustomerName.Name = "CustomerName";
         this.CustomerName.ReadOnly = true;
         // 
         // ContractType
         // 
         this.ContractType.DataPropertyName = "ContractType";
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.ContractType.DefaultCellStyle = dataGridViewCellStyle1;
         this.ContractType.HeaderText = "Loại HĐ";
         this.ContractType.Name = "ContractType";
         this.ContractType.ReadOnly = true;
         // 
         // ContractStatus
         // 
         this.ContractStatus.DataPropertyName = "ContractStatus";
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.ContractStatus.DefaultCellStyle = dataGridViewCellStyle2;
         this.ContractStatus.HeaderText = "Trạng thái";
         this.ContractStatus.Name = "ContractStatus";
         this.ContractStatus.ReadOnly = true;
         // 
         // BranchCode
         // 
         this.BranchCode.DataPropertyName = "BranchCode";
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.BranchCode.DefaultCellStyle = dataGridViewCellStyle3;
         this.BranchCode.HeaderText = "Mã đơn vị";
         this.BranchCode.Name = "BranchCode";
         this.BranchCode.ReadOnly = true;
         // 
         // TradeCode
         // 
         this.TradeCode.DataPropertyName = "TradeCode";
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.TradeCode.DefaultCellStyle = dataGridViewCellStyle4;
         this.TradeCode.HeaderText = "Mã GD";
         this.TradeCode.Name = "TradeCode";
         this.TradeCode.ReadOnly = true;
         // 
         // ContractDueDate
         // 
         this.ContractDueDate.DataPropertyName = "ContractDueDate";
         dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle5.Format = "dd/MM/yyyy";
         this.ContractDueDate.DefaultCellStyle = dataGridViewCellStyle5;
         this.ContractDueDate.HeaderText = "Ngày HĐ";
         this.ContractDueDate.Name = "ContractDueDate";
         this.ContractDueDate.ReadOnly = true;
         // 
         // ExpiredDate
         // 
         this.ExpiredDate.DataPropertyName = "ExpiredDate";
         dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle6.Format = "dd/MM/yyyy";
         this.ExpiredDate.DefaultCellStyle = dataGridViewCellStyle6;
         this.ExpiredDate.HeaderText = "Ngày hết hạn";
         this.ExpiredDate.Name = "ExpiredDate";
         this.ExpiredDate.ReadOnly = true;
         // 
         // interestRatePerDayDataGridViewTextBoxColumn
         // 
         this.interestRatePerDayDataGridViewTextBoxColumn.DataPropertyName = "InterestRatePerDay";
         this.interestRatePerDayDataGridViewTextBoxColumn.HeaderText = "Phí HT";
         this.interestRatePerDayDataGridViewTextBoxColumn.Name = "interestRatePerDayDataGridViewTextBoxColumn";
         this.interestRatePerDayDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // interestRatePenaltyDataGridViewTextBoxColumn
         // 
         this.interestRatePenaltyDataGridViewTextBoxColumn.DataPropertyName = "InterestRatePenalty";
         this.interestRatePenaltyDataGridViewTextBoxColumn.HeaderText = "Phí trả chậm";
         this.interestRatePenaltyDataGridViewTextBoxColumn.Name = "interestRatePenaltyDataGridViewTextBoxColumn";
         this.interestRatePenaltyDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // registeredAmountDataGridViewTextBoxColumn
         // 
         this.registeredAmountDataGridViewTextBoxColumn.DataPropertyName = "RegisteredAmount";
         dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle7.Format = "n0";
         this.registeredAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
         this.registeredAmountDataGridViewTextBoxColumn.HeaderText = "Số tiền ĐK HT";
         this.registeredAmountDataGridViewTextBoxColumn.Name = "registeredAmountDataGridViewTextBoxColumn";
         this.registeredAmountDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // CreatedBy
         // 
         this.CreatedBy.DataPropertyName = "CreatedBy";
         this.CreatedBy.HeaderText = "Tạo bởi";
         this.CreatedBy.Name = "CreatedBy";
         this.CreatedBy.ReadOnly = true;
         // 
         // CreatedDate
         // 
         this.CreatedDate.DataPropertyName = "CreatedDate";
         dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle8.Format = "dd/MM/yyyy";
         this.CreatedDate.DefaultCellStyle = dataGridViewCellStyle8;
         this.CreatedDate.HeaderText = "Ngày tạo";
         this.CreatedDate.Name = "CreatedDate";
         this.CreatedDate.ReadOnly = true;
         // 
         // approvalAmountDataGridViewTextBoxColumn
         // 
         this.approvalAmountDataGridViewTextBoxColumn.DataPropertyName = "ApprovalAmount";
         dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle9.Format = "n0";
         this.approvalAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
         this.approvalAmountDataGridViewTextBoxColumn.HeaderText = "Số tiền được duyệt";
         this.approvalAmountDataGridViewTextBoxColumn.Name = "approvalAmountDataGridViewTextBoxColumn";
         this.approvalAmountDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // ApprovedBy
         // 
         this.ApprovedBy.DataPropertyName = "ApprovedBy";
         this.ApprovedBy.HeaderText = "Duyệt bởi";
         this.ApprovedBy.Name = "ApprovedBy";
         this.ApprovedBy.ReadOnly = true;
         // 
         // ApprovedDate
         // 
         this.ApprovedDate.DataPropertyName = "ApprovedDate";
         dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle10.Format = "dd/MM/yyyy";
         this.ApprovedDate.DefaultCellStyle = dataGridViewCellStyle10;
         this.ApprovedDate.HeaderText = "Ngày duyệt";
         this.ApprovedDate.Name = "ApprovedDate";
         this.ApprovedDate.ReadOnly = true;
         // 
         // disbursedAmountDataGridViewTextBoxColumn
         // 
         this.disbursedAmountDataGridViewTextBoxColumn.DataPropertyName = "DisbursedAmount";
         dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle11.Format = "n0";
         this.disbursedAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
         this.disbursedAmountDataGridViewTextBoxColumn.HeaderText = "Số tiền được giải ngân";
         this.disbursedAmountDataGridViewTextBoxColumn.Name = "disbursedAmountDataGridViewTextBoxColumn";
         this.disbursedAmountDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // DisbursedBy
         // 
         this.DisbursedBy.DataPropertyName = "DisbursedBy";
         this.DisbursedBy.HeaderText = "Giải ngân bởi";
         this.DisbursedBy.Name = "DisbursedBy";
         this.DisbursedBy.ReadOnly = true;
         // 
         // DisbursedDate
         // 
         this.DisbursedDate.DataPropertyName = "DisbursedDate";
         dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle12.Format = "dd/MM/yyyy";
         this.DisbursedDate.DefaultCellStyle = dataGridViewCellStyle12;
         this.DisbursedDate.HeaderText = "Ngày giải ngân";
         this.DisbursedDate.Name = "DisbursedDate";
         this.DisbursedDate.ReadOnly = true;
         // 
         // withdrawAmountDataGridViewTextBoxColumn
         // 
         this.withdrawAmountDataGridViewTextBoxColumn.DataPropertyName = "WithdrawAmount";
         dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle13.Format = "n0";
         this.withdrawAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
         this.withdrawAmountDataGridViewTextBoxColumn.HeaderText = "Số tiền thanh lý";
         this.withdrawAmountDataGridViewTextBoxColumn.Name = "withdrawAmountDataGridViewTextBoxColumn";
         this.withdrawAmountDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // WithdrawBy
         // 
         this.WithdrawBy.DataPropertyName = "WithdrawBy";
         this.WithdrawBy.HeaderText = "Thanh lý bởi";
         this.WithdrawBy.Name = "WithdrawBy";
         this.WithdrawBy.ReadOnly = true;
         // 
         // WithdrawDate
         // 
         this.WithdrawDate.DataPropertyName = "WithdrawDate";
         dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle14.Format = "dd/MM/yyyy";
         this.WithdrawDate.DefaultCellStyle = dataGridViewCellStyle14;
         this.WithdrawDate.HeaderText = "Ngày thanh lý";
         this.WithdrawDate.Name = "WithdrawDate";
         this.WithdrawDate.ReadOnly = true;
         // 
         // interestAmountDataGridViewTextBoxColumn
         // 
         this.interestAmountDataGridViewTextBoxColumn.DataPropertyName = "InterestAmount";
         dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle15.Format = "n2";
         this.interestAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
         this.interestAmountDataGridViewTextBoxColumn.HeaderText = "Phí thu được";
         this.interestAmountDataGridViewTextBoxColumn.Name = "interestAmountDataGridViewTextBoxColumn";
         this.interestAmountDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // contractBindingSource
         // 
         this.contractBindingSource.DataSource = typeof(VRMApp.VRMGateway.Contract);
         // 
         // backgroundWorker
         // 
         this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
         this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
         // 
         // ContractListForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1005, 669);
         this.HideDeleteButton = false;
         this.HideExportButton = false;
         this.HidePrintButton = false;
         this.Name = "ContractListForm";
         this.Text = "Hợp đồng hợp tác kinh doanh";
         this.DeleteButtonClick += new System.EventHandler(this.ContractListForm_DeleteButtonClick);
         this.PrintButtonClick += new System.EventHandler(this.ContractListForm_PrintButtonClick);
         this.EditButtonClick += new System.EventHandler(this.ContractListForm_EditButtonClick);
         this.NewButtonClick += new System.EventHandler(this.ContractListForm_NewButtonClick);
         this.mainPanel.ResumeLayout(false);
         this.mainPanel.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.DataGridViewTextBoxColumn producTypeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn expireDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn approveDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn approveByDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripLabel toolStripLabel3;
      private System.Windows.Forms.ToolStripTextBox maKHBox;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.BindingSource contractBindingSource;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripLabel toolStripLabel4;
      private System.Windows.Forms.ToolStripComboBox comboStatus;
      private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn ContractID;
      private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
      private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
      private System.Windows.Forms.DataGridViewTextBoxColumn ContractType;
      private System.Windows.Forms.DataGridViewTextBoxColumn ContractStatus;
      private System.Windows.Forms.DataGridViewTextBoxColumn BranchCode;
      private System.Windows.Forms.DataGridViewTextBoxColumn TradeCode;
      private System.Windows.Forms.DataGridViewTextBoxColumn ContractDueDate;
      private System.Windows.Forms.DataGridViewTextBoxColumn ExpiredDate;
      private System.Windows.Forms.DataGridViewTextBoxColumn interestRatePerDayDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn interestRatePenaltyDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn registeredAmountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
      private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
      private System.Windows.Forms.DataGridViewTextBoxColumn approvalAmountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn ApprovedBy;
      private System.Windows.Forms.DataGridViewTextBoxColumn ApprovedDate;
      private System.Windows.Forms.DataGridViewTextBoxColumn disbursedAmountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn DisbursedBy;
      private System.Windows.Forms.DataGridViewTextBoxColumn DisbursedDate;
      private System.Windows.Forms.DataGridViewTextBoxColumn withdrawAmountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn WithdrawBy;
      private System.Windows.Forms.DataGridViewTextBoxColumn WithdrawDate;
      private System.Windows.Forms.DataGridViewTextBoxColumn interestAmountDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripButton giahanButton;

   }
}