namespace VRMApp.Accountant
{
    partial class CustomerIncomeTax
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.fromDate = new VRM.Controls.DataGridColumnExtend.CustomDateTimePicker();
            this.todate = new VRM.Controls.DataGridColumnExtend.CustomDateTimePicker();
            this.gSBS = new System.Windows.Forms.DataGridView();
            this.btSbsIncomTaxGet = new System.Windows.Forms.Button();
            this.btImportData = new System.Windows.Forms.Button();
            this.btKtIncomtaxGet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.gKetoan = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardIdentity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totallsbs = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalTaxSbs = new System.Windows.Forms.ToolStripStatusLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalkt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalTaxKT = new System.Windows.Forms.ToolStripStatusLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rCustody = new System.Windows.Forms.RadioButton();
            this.tax = new System.Windows.Forms.RadioButton();
            this.exportXLS = new System.Windows.Forms.Button();
            this.AccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transactiondate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depcription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardIdentity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gSBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gKetoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi Nhánh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(520, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày bắt đầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày kết thúc";
            // 
            // cbBranch
            // 
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(412, 61);
            this.cbBranch.Margin = new System.Windows.Forms.Padding(2);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(92, 21);
            this.cbBranch.TabIndex = 3;
            // 
            // fromDate
            // 
            this.fromDate.CustomFormat = "dd/MM/yyyy";
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.Location = new System.Drawing.Point(520, 62);
            this.fromDate.Margin = new System.Windows.Forms.Padding(2);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(90, 20);
            this.fromDate.TabIndex = 4;
            // 
            // todate
            // 
            this.todate.CustomFormat = "dd/MM/yyyy";
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.todate.Location = new System.Drawing.Point(622, 62);
            this.todate.Margin = new System.Windows.Forms.Padding(2);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(90, 20);
            this.todate.TabIndex = 5;
            // 
            // gSBS
            // 
            this.gSBS.AllowUserToAddRows = false;
            this.gSBS.AllowUserToDeleteRows = false;
            this.gSBS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gSBS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountId,
            this.AccountName,
            this.BranchCode,
            this.TradeCode,
            this.Amount,
            this.Transactiondate,
            this.Depcription,
            this.TransactionNumber,
            this.CardIdentity});
            this.gSBS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gSBS.Location = new System.Drawing.Point(0, 29);
            this.gSBS.Margin = new System.Windows.Forms.Padding(2);
            this.gSBS.Name = "gSBS";
            this.gSBS.ReadOnly = true;
            this.gSBS.RowTemplate.Height = 24;
            this.gSBS.Size = new System.Drawing.Size(568, 463);
            this.gSBS.TabIndex = 7;
            // 
            // btSbsIncomTaxGet
            // 
            this.btSbsIncomTaxGet.Location = new System.Drawing.Point(3, 56);
            this.btSbsIncomTaxGet.Margin = new System.Windows.Forms.Padding(2);
            this.btSbsIncomTaxGet.Name = "btSbsIncomTaxGet";
            this.btSbsIncomTaxGet.Size = new System.Drawing.Size(106, 26);
            this.btSbsIncomTaxGet.TabIndex = 8;
            this.btSbsIncomTaxGet.Text = "Lấy DL Từ SBS";
            this.btSbsIncomTaxGet.UseVisualStyleBackColor = true;
            this.btSbsIncomTaxGet.Click += new System.EventHandler(this.btSbsIncomTaxGet_Click);
            // 
            // btImportData
            // 
            this.btImportData.Location = new System.Drawing.Point(717, 57);
            this.btImportData.Margin = new System.Windows.Forms.Padding(2);
            this.btImportData.Name = "btImportData";
            this.btImportData.Size = new System.Drawing.Size(65, 26);
            this.btImportData.TabIndex = 9;
            this.btImportData.Text = "Import >>";
            this.btImportData.UseVisualStyleBackColor = true;
            this.btImportData.Click += new System.EventHandler(this.btImportData_Click);
            // 
            // btKtIncomtaxGet
            // 
            this.btKtIncomtaxGet.Location = new System.Drawing.Point(997, 56);
            this.btKtIncomtaxGet.Margin = new System.Windows.Forms.Padding(2);
            this.btKtIncomtaxGet.Name = "btKtIncomtaxGet";
            this.btKtIncomtaxGet.Size = new System.Drawing.Size(117, 26);
            this.btKtIncomtaxGet.TabIndex = 10;
            this.btKtIncomtaxGet.Text = "Lấy DL Từ Kế Toán";
            this.btKtIncomtaxGet.UseVisualStyleBackColor = true;
            this.btKtIncomtaxGet.Click += new System.EventHandler(this.btKtIncomtaxGet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(296, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(558, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Import Thuế TNCN/Phí LƯU KÝ Vào Phần Mềm Kế Toán";
            // 
            // gKetoan
            // 
            this.gKetoan.AllowUserToAddRows = false;
            this.gKetoan.AllowUserToDeleteRows = false;
            this.gKetoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gKetoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Description,
            this.TransactionNumbers,
            this.CardIdentity2,
            this.TradeCode2});
            this.gKetoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gKetoan.Location = new System.Drawing.Point(0, 29);
            this.gKetoan.Margin = new System.Windows.Forms.Padding(2);
            this.gKetoan.Name = "gKetoan";
            this.gKetoan.ReadOnly = true;
            this.gKetoan.RowTemplate.Height = 24;
            this.gKetoan.Size = new System.Drawing.Size(564, 463);
            this.gKetoan.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AccountId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã KH";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên KH";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Tiền Thuế/Phí";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Transactiondate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            dataGridViewCellStyle5.NullValue = "N/A";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "BranchCode";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.HeaderText = "Chi Nhánh";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // TransactionNumbers
            // 
            this.TransactionNumbers.DataPropertyName = "TransactionNumber";
            this.TransactionNumbers.HeaderText = "TransactionNumber";
            this.TransactionNumbers.Name = "TransactionNumbers";
            this.TransactionNumbers.ReadOnly = true;
            this.TransactionNumbers.Visible = false;
            // 
            // CardIdentity2
            // 
            this.CardIdentity2.DataPropertyName = "CardIdentity";
            this.CardIdentity2.HeaderText = "CardIdentity";
            this.CardIdentity2.Name = "CardIdentity2";
            this.CardIdentity2.ReadOnly = true;
            this.CardIdentity2.Visible = false;
            // 
            // TradeCode2
            // 
            this.TradeCode2.DataPropertyName = "TradeCode";
            this.TradeCode2.HeaderText = "TradeCode";
            this.TradeCode2.Name = "TradeCode2";
            this.TradeCode2.ReadOnly = true;
            this.TradeCode2.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gSBS);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip2);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gKetoan);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Size = new System.Drawing.Size(1136, 514);
            this.splitContainer1.SplitterDistance = 568;
            this.splitContainer1.TabIndex = 17;
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.totallsbs,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel3,
            this.totalTaxSbs});
            this.statusStrip2.Location = new System.Drawing.Point(0, 492);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(568, 22);
            this.statusStrip2.TabIndex = 18;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatusLabel2.Text = "Tổng số dòng:";
            // 
            // totallsbs
            // 
            this.totallsbs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.totallsbs.Name = "totallsbs";
            this.totallsbs.Size = new System.Drawing.Size(14, 17);
            this.totallsbs.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel3.Text = "Tổng thuế:";
            // 
            // totalTaxSbs
            // 
            this.totalTaxSbs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.totalTaxSbs.Name = "totalTaxSbs";
            this.totalTaxSbs.Size = new System.Drawing.Size(14, 17);
            this.totalTaxSbs.Text = "0";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Turquoise;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(568, 29);
            this.label8.TabIndex = 6;
            this.label8.Text = "DỮ LIỆU SBS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel5,
            this.totalkt,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel1,
            this.totalTaxKT});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(564, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatusLabel5.Text = "Tổng số dòng:";
            // 
            // totalkt
            // 
            this.totalkt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.totalkt.Name = "totalkt";
            this.totalkt.Size = new System.Drawing.Size(14, 17);
            this.totalkt.Text = "0";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel6.Text = "|";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "Tổng thuế:";
            // 
            // totalTaxKT
            // 
            this.totalTaxKT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.totalTaxKT.Name = "totalTaxKT";
            this.totalTaxKT.Size = new System.Drawing.Size(14, 17);
            this.totalTaxKT.Text = "0";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(564, 29);
            this.label7.TabIndex = 12;
            this.label7.Text = "DỮ LIỆU KẾ TOÁN";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.exportXLS);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.cbBranch);
            this.splitContainer2.Panel1.Controls.Add(this.fromDate);
            this.splitContainer2.Panel1.Controls.Add(this.btKtIncomtaxGet);
            this.splitContainer2.Panel1.Controls.Add(this.todate);
            this.splitContainer2.Panel1.Controls.Add(this.btImportData);
            this.splitContainer2.Panel1.Controls.Add(this.btSbsIncomTaxGet);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1136, 606);
            this.splitContainer2.SplitterDistance = 88;
            this.splitContainer2.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rCustody);
            this.groupBox1.Controls.Add(this.tax);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(207, 44);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tuy chon";
            // 
            // rCustody
            // 
            this.rCustody.AutoSize = true;
            this.rCustody.Location = new System.Drawing.Point(91, 17);
            this.rCustody.Margin = new System.Windows.Forms.Padding(2);
            this.rCustody.Name = "rCustody";
            this.rCustody.Size = new System.Drawing.Size(78, 17);
            this.rCustody.TabIndex = 1;
            this.rCustody.Text = "Phí Lưu Ký";
            this.rCustody.UseVisualStyleBackColor = true;
            // 
            // tax
            // 
            this.tax.AutoSize = true;
            this.tax.Checked = true;
            this.tax.Location = new System.Drawing.Point(5, 18);
            this.tax.Margin = new System.Windows.Forms.Padding(2);
            this.tax.Name = "tax";
            this.tax.Size = new System.Drawing.Size(83, 17);
            this.tax.TabIndex = 0;
            this.tax.TabStop = true;
            this.tax.Text = "Thuế TNCN";
            this.tax.UseVisualStyleBackColor = true;
            // 
            // exportXLS
            // 
            this.exportXLS.Enabled = false;
            this.exportXLS.Location = new System.Drawing.Point(144, 57);
            this.exportXLS.Margin = new System.Windows.Forms.Padding(2);
            this.exportXLS.Name = "exportXLS";
            this.exportXLS.Size = new System.Drawing.Size(106, 26);
            this.exportXLS.TabIndex = 12;
            this.exportXLS.Text = "Export Excel";
            this.exportXLS.UseVisualStyleBackColor = true;
            this.exportXLS.Click += new System.EventHandler(this.exportXLS_Click);
            // 
            // AccountId
            // 
            this.AccountId.DataPropertyName = "AccountId";
            this.AccountId.HeaderText = "Mã KH";
            this.AccountId.Name = "AccountId";
            this.AccountId.ReadOnly = true;
            // 
            // AccountName
            // 
            this.AccountName.DataPropertyName = "AccountName";
            this.AccountName.HeaderText = "Tên KH";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            // 
            // BranchCode
            // 
            this.BranchCode.DataPropertyName = "BranchCode";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.BranchCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.BranchCode.HeaderText = "Chi Nhánh";
            this.BranchCode.Name = "BranchCode";
            this.BranchCode.ReadOnly = true;
            this.BranchCode.Width = 80;
            // 
            // TradeCode
            // 
            this.TradeCode.DataPropertyName = "TradeCode";
            this.TradeCode.HeaderText = "PDG";
            this.TradeCode.Name = "TradeCode";
            this.TradeCode.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Tiền Thuế/Phí";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Transactiondate
            // 
            this.Transactiondate.DataPropertyName = "Transactiondate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = "N/A";
            this.Transactiondate.DefaultCellStyle = dataGridViewCellStyle3;
            this.Transactiondate.HeaderText = "Ngày";
            this.Transactiondate.Name = "Transactiondate";
            this.Transactiondate.ReadOnly = true;
            // 
            // Depcription
            // 
            this.Depcription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Depcription.DataPropertyName = "Description";
            this.Depcription.HeaderText = "Mô tả";
            this.Depcription.Name = "Depcription";
            this.Depcription.ReadOnly = true;
            this.Depcription.Width = 47;
            // 
            // TransactionNumber
            // 
            this.TransactionNumber.DataPropertyName = "TransactionNumber";
            this.TransactionNumber.HeaderText = "TransactionNumber";
            this.TransactionNumber.Name = "TransactionNumber";
            this.TransactionNumber.ReadOnly = true;
            this.TransactionNumber.Visible = false;
            // 
            // CardIdentity
            // 
            this.CardIdentity.DataPropertyName = "CardIdentity";
            this.CardIdentity.HeaderText = "CMND";
            this.CardIdentity.Name = "CardIdentity";
            this.CardIdentity.ReadOnly = true;
            this.CardIdentity.Visible = false;
            // 
            // CustomerIncomeTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 606);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomerIncomeTax";
            this.Text = "CustomerIncomeTax";
            ((System.ComponentModel.ISupportInitialize)(this.gSBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gKetoan)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBranch;
        private VRM.Controls.DataGridColumnExtend.CustomDateTimePicker fromDate;
        private VRM.Controls.DataGridColumnExtend.CustomDateTimePicker todate;
        private System.Windows.Forms.DataGridView gSBS;
        private System.Windows.Forms.Button btSbsIncomTaxGet;
        private System.Windows.Forms.Button btImportData;
        private System.Windows.Forms.Button btKtIncomtaxGet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gKetoan;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel totalTaxSbs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel totalTaxKT;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel totallsbs;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel totalkt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.Button exportXLS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rCustody;
        private System.Windows.Forms.RadioButton tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardIdentity2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transactiondate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depcription;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardIdentity;
    }
}