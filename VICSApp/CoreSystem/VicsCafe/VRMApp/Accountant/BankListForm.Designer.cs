namespace VRMApp.Accountant
{
   partial class BankListForm
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
          this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
          this.comboStatus = new System.Windows.Forms.ToolStripComboBox();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
          this.dataGridView1 = new System.Windows.Forms.DataGridView();
          this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.isPaymentDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
          this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.bankBindingSource = new System.Windows.Forms.BindingSource(this.components);
          this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.delBranchButton = new System.Windows.Forms.Button();
          this.editBranchButton = new System.Windows.Forms.Button();
          this.addBranchButton = new System.Windows.Forms.Button();
          this.bankBranchDataGridView = new System.Windows.Forms.DataGridView();
          this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.bankBranchBindingSource = new System.Windows.Forms.BindingSource(this.components);
          this.mainPanel.SuspendLayout();
          this.toolStrip1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).BeginInit();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.bankBranchDataGridView)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.bankBranchBindingSource)).BeginInit();
          this.SuspendLayout();
          // 
          // mainPanel
          // 
          this.mainPanel.Controls.Add(this.groupBox1);
          this.mainPanel.Controls.Add(this.dataGridView1);
          this.mainPanel.Controls.Add(this.toolStrip1);
          this.mainPanel.Size = new System.Drawing.Size(856, 648);
          this.mainPanel.Controls.SetChildIndex(this.toolStrip1, 0);
          this.mainPanel.Controls.SetChildIndex(this.dataGridView1, 0);
          this.mainPanel.Controls.SetChildIndex(this.groupBox1, 0);
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
            this.toolStripButton1});
          this.toolStrip1.Location = new System.Drawing.Point(0, 25);
          this.toolStrip1.Name = "toolStrip1";
          this.toolStrip1.Size = new System.Drawing.Size(1005, 25);
          this.toolStrip1.TabIndex = 2;
          this.toolStrip1.Text = "toolStrip1";
          this.toolStrip1.Visible = false;
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
          this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
          this.toolStripLabel1.Text = "Từ ngày:";
          // 
          // toolStripLabel2
          // 
          this.toolStripLabel2.Name = "toolStripLabel2";
          this.toolStripLabel2.Size = new System.Drawing.Size(60, 22);
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
          this.toolStripLabel4.Size = new System.Drawing.Size(64, 22);
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
          this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
          this.toolStripButton1.Text = "&Tìm";
          this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
          // 
          // dataGridView1
          // 
          this.dataGridView1.AllowUserToAddRows = false;
          this.dataGridView1.AllowUserToDeleteRows = false;
          this.dataGridView1.AutoGenerateColumns = false;
          this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.isPaymentDataGridViewCheckBoxColumn,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25});
          this.dataGridView1.DataSource = this.bankBindingSource;
          this.dataGridView1.Location = new System.Drawing.Point(0, 25);
          this.dataGridView1.Name = "dataGridView1";
          this.dataGridView1.ReadOnly = true;
          this.dataGridView1.Size = new System.Drawing.Size(844, 324);
          this.dataGridView1.TabIndex = 3;
          this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
          this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
          // 
          // dataGridViewTextBoxColumn14
          // 
          this.dataGridViewTextBoxColumn14.DataPropertyName = "BankCode";
          this.dataGridViewTextBoxColumn14.HeaderText = "Mã";
          this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
          this.dataGridViewTextBoxColumn14.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn15
          // 
          this.dataGridViewTextBoxColumn15.DataPropertyName = "FullName";
          this.dataGridViewTextBoxColumn15.FillWeight = 200F;
          this.dataGridViewTextBoxColumn15.HeaderText = "Tên ngân hàng";
          this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
          this.dataGridViewTextBoxColumn15.ReadOnly = true;
          this.dataGridViewTextBoxColumn15.Width = 200;
          // 
          // dataGridViewTextBoxColumn16
          // 
          this.dataGridViewTextBoxColumn16.DataPropertyName = "ShortName";
          this.dataGridViewTextBoxColumn16.HeaderText = "Tên viết tắt";
          this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
          this.dataGridViewTextBoxColumn16.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn17
          // 
          this.dataGridViewTextBoxColumn17.DataPropertyName = "Description";
          this.dataGridViewTextBoxColumn17.HeaderText = "Description";
          this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
          this.dataGridViewTextBoxColumn17.ReadOnly = true;
          this.dataGridViewTextBoxColumn17.Visible = false;
          // 
          // isPaymentDataGridViewCheckBoxColumn
          // 
          this.isPaymentDataGridViewCheckBoxColumn.DataPropertyName = "IsPayment";
          this.isPaymentDataGridViewCheckBoxColumn.HeaderText = "IsPayment";
          this.isPaymentDataGridViewCheckBoxColumn.Name = "isPaymentDataGridViewCheckBoxColumn";
          this.isPaymentDataGridViewCheckBoxColumn.ReadOnly = true;
          this.isPaymentDataGridViewCheckBoxColumn.Visible = false;
          // 
          // dataGridViewTextBoxColumn18
          // 
          this.dataGridViewTextBoxColumn18.DataPropertyName = "DelegatePerson";
          this.dataGridViewTextBoxColumn18.HeaderText = "DelegatePerson";
          this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
          this.dataGridViewTextBoxColumn18.ReadOnly = true;
          this.dataGridViewTextBoxColumn18.Visible = false;
          // 
          // dataGridViewTextBoxColumn19
          // 
          this.dataGridViewTextBoxColumn19.DataPropertyName = "Department";
          this.dataGridViewTextBoxColumn19.HeaderText = "Department";
          this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
          this.dataGridViewTextBoxColumn19.ReadOnly = true;
          this.dataGridViewTextBoxColumn19.Visible = false;
          // 
          // dataGridViewTextBoxColumn20
          // 
          this.dataGridViewTextBoxColumn20.DataPropertyName = "Position";
          this.dataGridViewTextBoxColumn20.HeaderText = "Position";
          this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
          this.dataGridViewTextBoxColumn20.ReadOnly = true;
          this.dataGridViewTextBoxColumn20.Visible = false;
          // 
          // dataGridViewTextBoxColumn21
          // 
          this.dataGridViewTextBoxColumn21.DataPropertyName = "Mobile";
          this.dataGridViewTextBoxColumn21.HeaderText = "Mobile";
          this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
          this.dataGridViewTextBoxColumn21.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn22
          // 
          this.dataGridViewTextBoxColumn22.DataPropertyName = "Tel";
          this.dataGridViewTextBoxColumn22.HeaderText = "Tel";
          this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
          this.dataGridViewTextBoxColumn22.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn23
          // 
          this.dataGridViewTextBoxColumn23.DataPropertyName = "Fax";
          this.dataGridViewTextBoxColumn23.HeaderText = "Fax";
          this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
          this.dataGridViewTextBoxColumn23.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn24
          // 
          this.dataGridViewTextBoxColumn24.DataPropertyName = "Email";
          this.dataGridViewTextBoxColumn24.HeaderText = "Email";
          this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
          this.dataGridViewTextBoxColumn24.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn25
          // 
          this.dataGridViewTextBoxColumn25.DataPropertyName = "Address";
          this.dataGridViewTextBoxColumn25.HeaderText = "Address";
          this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
          this.dataGridViewTextBoxColumn25.ReadOnly = true;
          // 
          // bankBindingSource
          // 
          this.bankBindingSource.DataSource = typeof(VRMApp.VRMGateway.Bank);
          // 
          // backgroundWorker
          // 
          this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
          this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.delBranchButton);
          this.groupBox1.Controls.Add(this.editBranchButton);
          this.groupBox1.Controls.Add(this.addBranchButton);
          this.groupBox1.Controls.Add(this.bankBranchDataGridView);
          this.groupBox1.Location = new System.Drawing.Point(3, 364);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(841, 281);
          this.groupBox1.TabIndex = 8;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Chi nhánh";
          // 
          // delBranchButton
          // 
          this.delBranchButton.Image = global::VRMApp.Properties.Resources.cross;
          this.delBranchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.delBranchButton.Location = new System.Drawing.Point(172, 20);
          this.delBranchButton.Name = "delBranchButton";
          this.delBranchButton.Size = new System.Drawing.Size(75, 23);
          this.delBranchButton.TabIndex = 11;
          this.delBranchButton.Text = "Xóa";
          this.delBranchButton.UseVisualStyleBackColor = true;
          this.delBranchButton.Click += new System.EventHandler(this.delBranchButton_Click);
          // 
          // editBranchButton
          // 
          this.editBranchButton.Image = global::VRMApp.Properties.Resources.application_edit;
          this.editBranchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.editBranchButton.Location = new System.Drawing.Point(91, 20);
          this.editBranchButton.Name = "editBranchButton";
          this.editBranchButton.Size = new System.Drawing.Size(75, 23);
          this.editBranchButton.TabIndex = 10;
          this.editBranchButton.Text = "Sửa";
          this.editBranchButton.UseVisualStyleBackColor = true;
          this.editBranchButton.Click += new System.EventHandler(this.editBranchButton_Click);
          // 
          // addBranchButton
          // 
          this.addBranchButton.Image = global::VRMApp.Properties.Resources.add;
          this.addBranchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.addBranchButton.Location = new System.Drawing.Point(10, 20);
          this.addBranchButton.Name = "addBranchButton";
          this.addBranchButton.Size = new System.Drawing.Size(75, 23);
          this.addBranchButton.TabIndex = 9;
          this.addBranchButton.Text = "Thêm";
          this.addBranchButton.UseVisualStyleBackColor = true;
          this.addBranchButton.Click += new System.EventHandler(this.addBranchButton_Click);
          // 
          // bankBranchDataGridView
          // 
          this.bankBranchDataGridView.AllowUserToAddRows = false;
          this.bankBranchDataGridView.AllowUserToDeleteRows = false;
          this.bankBranchDataGridView.AutoGenerateColumns = false;
          this.bankBranchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.bankBranchDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
          this.bankBranchDataGridView.DataSource = this.bankBranchBindingSource;
          this.bankBranchDataGridView.Location = new System.Drawing.Point(10, 48);
          this.bankBranchDataGridView.Name = "bankBranchDataGridView";
          this.bankBranchDataGridView.ReadOnly = true;
          this.bankBranchDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.bankBranchDataGridView.Size = new System.Drawing.Size(825, 227);
          this.bankBranchDataGridView.TabIndex = 8;
          // 
          // dataGridViewTextBoxColumn1
          // 
          this.dataGridViewTextBoxColumn1.DataPropertyName = "BankBranchCode";
          this.dataGridViewTextBoxColumn1.HeaderText = "Mã chi nhánh";
          this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
          this.dataGridViewTextBoxColumn1.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn2
          // 
          this.dataGridViewTextBoxColumn2.DataPropertyName = "FullName";
          this.dataGridViewTextBoxColumn2.FillWeight = 250F;
          this.dataGridViewTextBoxColumn2.HeaderText = "Tên chi nhánh";
          this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
          this.dataGridViewTextBoxColumn2.ReadOnly = true;
          this.dataGridViewTextBoxColumn2.Width = 250;
          // 
          // dataGridViewTextBoxColumn3
          // 
          this.dataGridViewTextBoxColumn3.DataPropertyName = "ShortName";
          this.dataGridViewTextBoxColumn3.HeaderText = "Tên viết tắt";
          this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
          this.dataGridViewTextBoxColumn3.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn4
          // 
          this.dataGridViewTextBoxColumn4.DataPropertyName = "Address";
          this.dataGridViewTextBoxColumn4.FillWeight = 200F;
          this.dataGridViewTextBoxColumn4.HeaderText = "Địa chỉ";
          this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
          this.dataGridViewTextBoxColumn4.ReadOnly = true;
          this.dataGridViewTextBoxColumn4.Width = 200;
          // 
          // dataGridViewTextBoxColumn5
          // 
          this.dataGridViewTextBoxColumn5.DataPropertyName = "DelegatePerson";
          this.dataGridViewTextBoxColumn5.HeaderText = "Người đại diện";
          this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
          this.dataGridViewTextBoxColumn5.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn6
          // 
          this.dataGridViewTextBoxColumn6.DataPropertyName = "Department";
          this.dataGridViewTextBoxColumn6.HeaderText = "Phòng ban";
          this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
          this.dataGridViewTextBoxColumn6.ReadOnly = true;
          this.dataGridViewTextBoxColumn6.Visible = false;
          // 
          // dataGridViewTextBoxColumn7
          // 
          this.dataGridViewTextBoxColumn7.DataPropertyName = "Position";
          this.dataGridViewTextBoxColumn7.HeaderText = "Chức vụ";
          this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
          this.dataGridViewTextBoxColumn7.ReadOnly = true;
          this.dataGridViewTextBoxColumn7.Visible = false;
          // 
          // dataGridViewTextBoxColumn8
          // 
          this.dataGridViewTextBoxColumn8.DataPropertyName = "Mobile";
          this.dataGridViewTextBoxColumn8.HeaderText = "Mobile";
          this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
          this.dataGridViewTextBoxColumn8.ReadOnly = true;
          this.dataGridViewTextBoxColumn8.Visible = false;
          // 
          // dataGridViewTextBoxColumn9
          // 
          this.dataGridViewTextBoxColumn9.DataPropertyName = "Tel";
          this.dataGridViewTextBoxColumn9.HeaderText = "Tel";
          this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
          this.dataGridViewTextBoxColumn9.ReadOnly = true;
          this.dataGridViewTextBoxColumn9.Visible = false;
          // 
          // dataGridViewTextBoxColumn10
          // 
          this.dataGridViewTextBoxColumn10.DataPropertyName = "Fax";
          this.dataGridViewTextBoxColumn10.HeaderText = "Fax";
          this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
          this.dataGridViewTextBoxColumn10.ReadOnly = true;
          this.dataGridViewTextBoxColumn10.Visible = false;
          // 
          // dataGridViewTextBoxColumn11
          // 
          this.dataGridViewTextBoxColumn11.DataPropertyName = "Email";
          this.dataGridViewTextBoxColumn11.HeaderText = "Email";
          this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
          this.dataGridViewTextBoxColumn11.ReadOnly = true;
          this.dataGridViewTextBoxColumn11.Visible = false;
          // 
          // dataGridViewTextBoxColumn12
          // 
          this.dataGridViewTextBoxColumn12.DataPropertyName = "Description";
          this.dataGridViewTextBoxColumn12.HeaderText = "Thông tin khác";
          this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
          this.dataGridViewTextBoxColumn12.ReadOnly = true;
          // 
          // dataGridViewTextBoxColumn13
          // 
          this.dataGridViewTextBoxColumn13.DataPropertyName = "IsPayment";
          this.dataGridViewTextBoxColumn13.HeaderText = "IsPayment";
          this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
          this.dataGridViewTextBoxColumn13.ReadOnly = true;
          this.dataGridViewTextBoxColumn13.Visible = false;
          // 
          // bankBranchBindingSource
          // 
          this.bankBranchBindingSource.DataSource = typeof(VRMApp.VRMGateway.BankBranch);
          // 
          // BankListForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(856, 670);
          this.HideDeleteButton = false;
          this.HideExportButton = false;
          this.HidePrintButton = false;
          this.Name = "BankListForm";
          this.Text = "Danh sách ngân hàng";
          this.DeleteButtonClick += new System.EventHandler(this.ContractListForm_DeleteButtonClick);
          this.EditButtonClick += new System.EventHandler(this.BankListForm_EditButtonClick);
          this.NewButtonClick += new System.EventHandler(this.BankListForm_NewButtonClick);
          this.mainPanel.ResumeLayout(false);
          this.mainPanel.PerformLayout();
          this.toolStrip1.ResumeLayout(false);
          this.toolStrip1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).EndInit();
          this.groupBox1.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.bankBranchDataGridView)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.bankBranchBindingSource)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.DataGridViewTextBoxColumn producTypeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn expireDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn approveDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn approveByDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripLabel toolStripLabel3;
      private System.Windows.Forms.ToolStripTextBox maKHBox;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripLabel toolStripLabel4;
      private System.Windows.Forms.ToolStripComboBox comboStatus;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.BindingSource bankBranchBindingSource;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button delBranchButton;
      private System.Windows.Forms.Button editBranchButton;
      private System.Windows.Forms.Button addBranchButton;
      private System.Windows.Forms.DataGridView bankBranchDataGridView;
      private System.Windows.Forms.DataGridViewTextBoxColumn bankCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn shortNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn delegatePersonDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn mobileDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn telDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn faxDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn isPaymentDataGridViewTextBoxColumn;
      private System.Windows.Forms.BindingSource bankBindingSource;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
      private System.Windows.Forms.DataGridViewCheckBoxColumn isPaymentDataGridViewCheckBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

   }
}