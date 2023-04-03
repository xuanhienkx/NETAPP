using System.Windows.Forms;
using System.ComponentModel;

namespace Brokery.Operation
{
   partial class CustomerInfo
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
         this.inquiryOnlineWorker = new System.ComponentModel.BackgroundWorker();
         this.grpCustomer = new System.Windows.Forms.GroupBox();
         this.customerFeeLinkButton = new System.Windows.Forms.LinkLabel();
         this.customerIdTextBox = new System.Windows.Forms.TextBox();
         this.lblIdentityCard = new System.Windows.Forms.Label();
         this.lblAccountID = new System.Windows.Forms.Label();
         this.identityNumberTextBox = new System.Windows.Forms.TextBox();
         this.findButton = new System.Windows.Forms.Button();
         this.lblAccountName = new System.Windows.Forms.Label();
         this.customerNameTextBox = new System.Windows.Forms.TextBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.customerGrid = new System.Windows.Forms.DataGridView();
         this.TradeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CardIdentity = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.label1 = new System.Windows.Forms.Label();
         this.reservedTextBox = new System.Windows.Forms.TextBox();
         this.serviceGrid = new System.Windows.Forms.DataGridView();
         this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabSign1 = new System.Windows.Forms.TabPage();
         this.picSign1 = new System.Windows.Forms.PictureBox();
         this.tabSign2 = new System.Windows.Forms.TabPage();
         this.picSign2 = new System.Windows.Forms.PictureBox();
         this.label5 = new System.Windows.Forms.Label();
         this.mainGrid = new System.Windows.Forms.DataGridView();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.lblLastTimeInquiry = new System.Windows.Forms.Label();
         this.btnInquiryOnline = new System.Windows.Forms.Button();
         this.bankAvailBalanceLabel = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.customerDebitLabel = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.availBalanceLabel = new System.Windows.Forms.Label();
         this.currentBalanceLabel = new System.Windows.Forms.Label();
         this.boughtCashLabel = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.exitBtn = new System.Windows.Forms.Button();
         this.loLaiDuKienBtn = new System.Windows.Forms.Button();
         this.lichSuGiaoDichLenhBtn = new System.Windows.Forms.Button();
         this.accountSumerizeReporBtn = new System.Windows.Forms.Button();
         this.btListStockTrans = new System.Windows.Forms.Button();
         this.btListMoneyTrans = new System.Windows.Forms.Button();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.bankCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.cIFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.ServiceCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ServiceNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.BeginDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.EndDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.customerServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.inquiryStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.BoardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.StockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.giaoDichCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CamCoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.hanCheCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CKTONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.DayTrading = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.RemainVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.grpCustomer.SuspendLayout();
         this.groupBox3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.serviceGrid)).BeginInit();
         this.tabControl1.SuspendLayout();
         this.tabSign1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picSign1)).BeginInit();
         this.tabSign2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picSign2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.customerServiceBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.inquiryStockBindingSource)).BeginInit();
         this.SuspendLayout();
         // 
         // inquiryOnlineWorker
         // 
         this.inquiryOnlineWorker.WorkerSupportsCancellation = true;
         this.inquiryOnlineWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.inquiryOnlineWorker_DoWork);
         this.inquiryOnlineWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.inquiryOnlineWorker_RunWorkerCompleted);
         // 
         // grpCustomer
         // 
         this.grpCustomer.Controls.Add(this.customerFeeLinkButton);
         this.grpCustomer.Controls.Add(this.customerIdTextBox);
         this.grpCustomer.Controls.Add(this.lblIdentityCard);
         this.grpCustomer.Controls.Add(this.lblAccountID);
         this.grpCustomer.Controls.Add(this.identityNumberTextBox);
         this.grpCustomer.Controls.Add(this.findButton);
         this.grpCustomer.Controls.Add(this.lblAccountName);
         this.grpCustomer.Controls.Add(this.customerNameTextBox);
         this.grpCustomer.Location = new System.Drawing.Point(13, 6);
         this.grpCustomer.Name = "grpCustomer";
         this.grpCustomer.Size = new System.Drawing.Size(914, 58);
         this.grpCustomer.TabIndex = 26;
         this.grpCustomer.TabStop = false;
         this.grpCustomer.Text = "Thông tin Khách hàng";
         // 
         // customerFeeLinkButton
         // 
         this.customerFeeLinkButton.AutoSize = true;
         this.customerFeeLinkButton.Location = new System.Drawing.Point(704, 32);
         this.customerFeeLinkButton.Name = "customerFeeLinkButton";
         this.customerFeeLinkButton.Size = new System.Drawing.Size(109, 13);
         this.customerFeeLinkButton.TabIndex = 99;
         this.customerFeeLinkButton.TabStop = true;
         this.customerFeeLinkButton.Text = "Thông tin phí môi giới";
         this.customerFeeLinkButton.Visible = false;
         // 
         // customerIdTextBox
         // 
         this.customerIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.customerIdTextBox.ForeColor = System.Drawing.Color.Blue;
         this.customerIdTextBox.Location = new System.Drawing.Point(143, 30);
         this.customerIdTextBox.MaxLength = 10;
         this.customerIdTextBox.Name = "customerIdTextBox";
         this.customerIdTextBox.Size = new System.Drawing.Size(97, 20);
         this.customerIdTextBox.TabIndex = 0;
         this.customerIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.customerIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customerIdTextBox_KeyDown);
         // 
         // lblIdentityCard
         // 
         this.lblIdentityCard.AutoSize = true;
         this.lblIdentityCard.Location = new System.Drawing.Point(466, 14);
         this.lblIdentityCard.Name = "lblIdentityCard";
         this.lblIdentityCard.Size = new System.Drawing.Size(90, 13);
         this.lblIdentityCard.TabIndex = 10;
         this.lblIdentityCard.Text = "CMND/Hộ chiếu:";
         // 
         // lblAccountID
         // 
         this.lblAccountID.AutoSize = true;
         this.lblAccountID.Location = new System.Drawing.Point(143, 14);
         this.lblAccountID.Name = "lblAccountID";
         this.lblAccountID.Size = new System.Drawing.Size(85, 13);
         this.lblAccountID.TabIndex = 7;
         this.lblAccountID.Text = "Mã khách hàng:";
         // 
         // identityNumberTextBox
         // 
         this.identityNumberTextBox.Location = new System.Drawing.Point(466, 30);
         this.identityNumberTextBox.MaxLength = 20;
         this.identityNumberTextBox.Name = "identityNumberTextBox";
         this.identityNumberTextBox.Size = new System.Drawing.Size(78, 20);
         this.identityNumberTextBox.TabIndex = 2;
         this.identityNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.identityNumberTextBox_KeyDown);
         // 
         // findButton
         // 
         this.findButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.findButton.Location = new System.Drawing.Point(576, 27);
         this.findButton.Name = "findButton";
         this.findButton.Size = new System.Drawing.Size(91, 23);
         this.findButton.TabIndex = 3;
         this.findButton.Text = "&Tìm";
         this.findButton.UseVisualStyleBackColor = true;
         this.findButton.Click += new System.EventHandler(this.findButton_Click);
         // 
         // lblAccountName
         // 
         this.lblAccountName.AutoSize = true;
         this.lblAccountName.Location = new System.Drawing.Point(265, 14);
         this.lblAccountName.Name = "lblAccountName";
         this.lblAccountName.Size = new System.Drawing.Size(89, 13);
         this.lblAccountName.TabIndex = 8;
         this.lblAccountName.Text = "Tên khách hàng:";
         // 
         // customerNameTextBox
         // 
         this.customerNameTextBox.Location = new System.Drawing.Point(265, 30);
         this.customerNameTextBox.MaxLength = 100;
         this.customerNameTextBox.Name = "customerNameTextBox";
         this.customerNameTextBox.Size = new System.Drawing.Size(180, 20);
         this.customerNameTextBox.TabIndex = 1;
         this.customerNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customerNameTextBox_KeyDown);
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.customerGrid);
         this.groupBox3.Controls.Add(this.label1);
         this.groupBox3.Controls.Add(this.reservedTextBox);
         this.groupBox3.Controls.Add(this.serviceGrid);
         this.groupBox3.Controls.Add(this.tabControl1);
         this.groupBox3.Controls.Add(this.label5);
         this.groupBox3.Controls.Add(this.mainGrid);
         this.groupBox3.Controls.Add(this.groupBox1);
         this.groupBox3.Location = new System.Drawing.Point(12, 68);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(915, 498);
         this.groupBox3.TabIndex = 25;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Thông tin tài khoản";
         // 
         // customerGrid
         // 
         this.customerGrid.AllowUserToAddRows = false;
         this.customerGrid.AllowUserToDeleteRows = false;
         this.customerGrid.AllowUserToOrderColumns = true;
         this.customerGrid.AllowUserToResizeRows = false;
         this.customerGrid.AutoGenerateColumns = false;
         this.customerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.customerGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
         this.customerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.customerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIdDataGridViewTextBoxColumn,
            this.TradeCode,
            this.customerNameDataGridViewTextBoxColumn,
            this.CardIdentity,
            this.bankCodeDataGridViewTextBoxColumn,
            this.cIFDataGridViewTextBoxColumn});
         this.customerGrid.DataSource = this.bindingSource;
         this.customerGrid.Location = new System.Drawing.Point(149, 17);
         this.customerGrid.Name = "customerGrid";
         this.customerGrid.ReadOnly = true;
         this.customerGrid.RowHeadersVisible = false;
         this.customerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.customerGrid.Size = new System.Drawing.Size(755, 142);
         this.customerGrid.TabIndex = 4;
         this.customerGrid.SelectionChanged += new System.EventHandler(this.customerGrid_SelectionChanged);
         this.customerGrid.DoubleClick += new System.EventHandler(this.customerGrid_DoubleClick);
         // 
         // TradeCode
         // 
         this.TradeCode.DataPropertyName = "TradeCode";
         this.TradeCode.HeaderText = "Mã giao dịch";
         this.TradeCode.Name = "TradeCode";
         this.TradeCode.ReadOnly = true;
         // 
         // CardIdentity
         // 
         this.CardIdentity.DataPropertyName = "CardIdentity";
         this.CardIdentity.HeaderText = "CMND/Hộ chiếu";
         this.CardIdentity.Name = "CardIdentity";
         this.CardIdentity.ReadOnly = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
         this.label1.Location = new System.Drawing.Point(15, 400);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 13);
         this.label1.TabIndex = 51;
         this.label1.Text = "Mã đặt lệnh";
         // 
         // reservedTextBox
         // 
         this.reservedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.reservedTextBox.ForeColor = System.Drawing.SystemColors.HotTrack;
         this.reservedTextBox.Location = new System.Drawing.Point(15, 415);
         this.reservedTextBox.Multiline = true;
         this.reservedTextBox.Name = "reservedTextBox";
         this.reservedTextBox.ReadOnly = true;
         this.reservedTextBox.Size = new System.Drawing.Size(124, 73);
         this.reservedTextBox.TabIndex = 50;
         this.reservedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // serviceGrid
         // 
         this.serviceGrid.AllowUserToAddRows = false;
         this.serviceGrid.AllowUserToDeleteRows = false;
         this.serviceGrid.AutoGenerateColumns = false;
         this.serviceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.serviceGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
         this.serviceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceCodeColumn,
            this.ServiceNameColumn,
            this.BeginDateColumn,
            this.EndDateColumn,
            this.Status});
         this.serviceGrid.DataSource = this.customerServiceBindingSource;
         this.serviceGrid.Location = new System.Drawing.Point(145, 414);
         this.serviceGrid.Name = "serviceGrid";
         this.serviceGrid.ReadOnly = true;
         this.serviceGrid.RowHeadersVisible = false;
         this.serviceGrid.Size = new System.Drawing.Size(759, 74);
         this.serviceGrid.TabIndex = 99;
         this.serviceGrid.TabStop = false;
         // 
         // Status
         // 
         this.Status.DataPropertyName = "Status";
         this.Status.HeaderText = "Trạng thái";
         this.Status.Name = "Status";
         this.Status.ReadOnly = true;
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabSign1);
         this.tabControl1.Controls.Add(this.tabSign2);
         this.tabControl1.Location = new System.Drawing.Point(15, 17);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(128, 146);
         this.tabControl1.TabIndex = 46;
         // 
         // tabSign1
         // 
         this.tabSign1.Controls.Add(this.picSign1);
         this.tabSign1.Location = new System.Drawing.Point(4, 22);
         this.tabSign1.Name = "tabSign1";
         this.tabSign1.Padding = new System.Windows.Forms.Padding(3);
         this.tabSign1.Size = new System.Drawing.Size(120, 120);
         this.tabSign1.TabIndex = 0;
         this.tabSign1.Text = "CTK 1";
         this.tabSign1.UseVisualStyleBackColor = true;
         // 
         // picSign1
         // 
         this.picSign1.BackColor = System.Drawing.Color.White;
         this.picSign1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.picSign1.Location = new System.Drawing.Point(0, 1);
         this.picSign1.Name = "picSign1";
         this.picSign1.Size = new System.Drawing.Size(120, 120);
         this.picSign1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.picSign1.TabIndex = 39;
         this.picSign1.TabStop = false;
         // 
         // tabSign2
         // 
         this.tabSign2.Controls.Add(this.picSign2);
         this.tabSign2.Location = new System.Drawing.Point(4, 22);
         this.tabSign2.Name = "tabSign2";
         this.tabSign2.Padding = new System.Windows.Forms.Padding(3);
         this.tabSign2.Size = new System.Drawing.Size(120, 120);
         this.tabSign2.TabIndex = 1;
         this.tabSign2.Text = "CTK 2";
         this.tabSign2.UseVisualStyleBackColor = true;
         // 
         // picSign2
         // 
         this.picSign2.BackColor = System.Drawing.Color.White;
         this.picSign2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.picSign2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.picSign2.Location = new System.Drawing.Point(0, 0);
         this.picSign2.Name = "picSign2";
         this.picSign2.Size = new System.Drawing.Size(120, 120);
         this.picSign2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.picSign2.TabIndex = 40;
         this.picSign2.TabStop = false;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
         this.label5.Location = new System.Drawing.Point(15, 250);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(101, 13);
         this.label5.TabIndex = 31;
         this.label5.Text = "Số dư chứng khoán";
         // 
         // mainGrid
         // 
         this.mainGrid.AllowUserToAddRows = false;
         this.mainGrid.AllowUserToDeleteRows = false;
         this.mainGrid.AutoGenerateColumns = false;
         this.mainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.mainGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.mainGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
         this.mainGrid.ColumnHeadersHeight = 20;
         this.mainGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BoardType,
            this.StockCode,
            this.giaoDichCol,
            this.CamCoCol,
            this.hanCheCol,
            this.CKTONG,
            this.DayTrading,
            this.RemainVolume});
         this.mainGrid.DataSource = this.inquiryStockBindingSource;
         this.mainGrid.Location = new System.Drawing.Point(15, 267);
         this.mainGrid.MultiSelect = false;
         this.mainGrid.Name = "mainGrid";
         this.mainGrid.ReadOnly = true;
         this.mainGrid.RowHeadersVisible = false;
         this.mainGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.mainGrid.Size = new System.Drawing.Size(889, 125);
         this.mainGrid.TabIndex = 99;
         this.mainGrid.TabStop = false;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.lblLastTimeInquiry);
         this.groupBox1.Controls.Add(this.btnInquiryOnline);
         this.groupBox1.Controls.Add(this.bankAvailBalanceLabel);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.customerDebitLabel);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.availBalanceLabel);
         this.groupBox1.Controls.Add(this.currentBalanceLabel);
         this.groupBox1.Controls.Add(this.boughtCashLabel);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label10);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Location = new System.Drawing.Point(15, 167);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(889, 80);
         this.groupBox1.TabIndex = 48;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Số dư tiền";
         // 
         // lblLastTimeInquiry
         // 
         this.lblLastTimeInquiry.ForeColor = System.Drawing.SystemColors.ActiveCaption;
         this.lblLastTimeInquiry.Location = new System.Drawing.Point(613, 64);
         this.lblLastTimeInquiry.Name = "lblLastTimeInquiry";
         this.lblLastTimeInquiry.Size = new System.Drawing.Size(265, 13);
         this.lblLastTimeInquiry.TabIndex = 46;
         this.lblLastTimeInquiry.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // btnInquiryOnline
         // 
         this.btnInquiryOnline.Cursor = System.Windows.Forms.Cursors.Hand;
         this.btnInquiryOnline.Location = new System.Drawing.Point(791, 27);
         this.btnInquiryOnline.Name = "btnInquiryOnline";
         this.btnInquiryOnline.Size = new System.Drawing.Size(91, 23);
         this.btnInquiryOnline.TabIndex = 5;
         this.btnInquiryOnline.Text = "&Vấn tin";
         this.btnInquiryOnline.UseVisualStyleBackColor = true;
         this.btnInquiryOnline.Click += new System.EventHandler(this.btnInquiryOnline_Click);
         // 
         // bankAvailBalanceLabel
         // 
         this.bankAvailBalanceLabel.BackColor = System.Drawing.SystemColors.ControlText;
         this.bankAvailBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.bankAvailBalanceLabel.ForeColor = System.Drawing.Color.LawnGreen;
         this.bankAvailBalanceLabel.Location = new System.Drawing.Point(164, 30);
         this.bankAvailBalanceLabel.Name = "bankAvailBalanceLabel";
         this.bankAvailBalanceLabel.Size = new System.Drawing.Size(145, 20);
         this.bankAvailBalanceLabel.TabIndex = 44;
         this.bankAvailBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(165, 14);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(107, 13);
         this.label6.TabIndex = 43;
         this.label6.Text = "Khả dụng ngân hàng";
         // 
         // customerDebitLabel
         // 
         this.customerDebitLabel.BackColor = System.Drawing.SystemColors.ControlText;
         this.customerDebitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.customerDebitLabel.ForeColor = System.Drawing.Color.Red;
         this.customerDebitLabel.Location = new System.Drawing.Point(476, 30);
         this.customerDebitLabel.Name = "customerDebitLabel";
         this.customerDebitLabel.Size = new System.Drawing.Size(145, 20);
         this.customerDebitLabel.TabIndex = 41;
         this.customerDebitLabel.Text = " ";
         this.customerDebitLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(477, 14);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(123, 13);
         this.label3.TabIndex = 42;
         this.label3.Text = "Số tiền thiếu do đặt lệnh";
         // 
         // availBalanceLabel
         // 
         this.availBalanceLabel.BackColor = System.Drawing.SystemColors.ControlText;
         this.availBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.availBalanceLabel.ForeColor = System.Drawing.Color.LawnGreen;
         this.availBalanceLabel.Location = new System.Drawing.Point(8, 30);
         this.availBalanceLabel.Name = "availBalanceLabel";
         this.availBalanceLabel.Size = new System.Drawing.Size(145, 20);
         this.availBalanceLabel.TabIndex = 32;
         this.availBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // currentBalanceLabel
         // 
         this.currentBalanceLabel.BackColor = System.Drawing.SystemColors.ControlText;
         this.currentBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.currentBalanceLabel.ForeColor = System.Drawing.Color.Red;
         this.currentBalanceLabel.Location = new System.Drawing.Point(320, 30);
         this.currentBalanceLabel.Name = "currentBalanceLabel";
         this.currentBalanceLabel.Size = new System.Drawing.Size(145, 20);
         this.currentBalanceLabel.TabIndex = 40;
         this.currentBalanceLabel.Text = " ";
         this.currentBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // boughtCashLabel
         // 
         this.boughtCashLabel.BackColor = System.Drawing.SystemColors.ControlText;
         this.boughtCashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.boughtCashLabel.ForeColor = System.Drawing.Color.Red;
         this.boughtCashLabel.Location = new System.Drawing.Point(631, 30);
         this.boughtCashLabel.Name = "boughtCashLabel";
         this.boughtCashLabel.Size = new System.Drawing.Size(145, 20);
         this.boughtCashLabel.TabIndex = 33;
         this.boughtCashLabel.Text = " ";
         this.boughtCashLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(322, 14);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(35, 13);
         this.label7.TabIndex = 39;
         this.label7.Text = "Số dư";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(632, 14);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(121, 13);
         this.label10.TabIndex = 34;
         this.label10.Text = "Tiền mua CK trong ngày";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(8, 14);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(95, 13);
         this.label4.TabIndex = 30;
         this.label4.Text = "Khả dụng đặt lệnh";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.exitBtn);
         this.groupBox2.Controls.Add(this.loLaiDuKienBtn);
         this.groupBox2.Controls.Add(this.lichSuGiaoDichLenhBtn);
         this.groupBox2.Controls.Add(this.accountSumerizeReporBtn);
         this.groupBox2.Controls.Add(this.btListStockTrans);
         this.groupBox2.Controls.Add(this.btListMoneyTrans);
         this.groupBox2.Location = new System.Drawing.Point(13, 572);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(914, 58);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Báo cáo";
         // 
         // exitBtn
         // 
         this.exitBtn.Image = global::Brokery.Properties.Resources.cancel;
         this.exitBtn.Location = new System.Drawing.Point(717, 16);
         this.exitBtn.Name = "exitBtn";
         this.exitBtn.Size = new System.Drawing.Size(112, 33);
         this.exitBtn.TabIndex = 11;
         this.exitBtn.Text = "Thoát";
         this.exitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.exitBtn.UseVisualStyleBackColor = true;
         this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
         // 
         // loLaiDuKienBtn
         // 
         this.loLaiDuKienBtn.Image = global::Brokery.Properties.Resources.zone_money;
         this.loLaiDuKienBtn.Location = new System.Drawing.Point(590, 16);
         this.loLaiDuKienBtn.Name = "loLaiDuKienBtn";
         this.loLaiDuKienBtn.Size = new System.Drawing.Size(112, 33);
         this.loLaiDuKienBtn.TabIndex = 10;
         this.loLaiDuKienBtn.Text = "Lỗ lãi dự kiến";
         this.loLaiDuKienBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.loLaiDuKienBtn.UseVisualStyleBackColor = true;
         this.loLaiDuKienBtn.Click += new System.EventHandler(this.loLaiDuKienBtn_Click);
         // 
         // lichSuGiaoDichLenhBtn
         // 
         this.lichSuGiaoDichLenhBtn.Image = global::Brokery.Properties.Resources.page_white_stack;
         this.lichSuGiaoDichLenhBtn.Location = new System.Drawing.Point(463, 16);
         this.lichSuGiaoDichLenhBtn.Name = "lichSuGiaoDichLenhBtn";
         this.lichSuGiaoDichLenhBtn.Size = new System.Drawing.Size(112, 33);
         this.lichSuGiaoDichLenhBtn.TabIndex = 9;
         this.lichSuGiaoDichLenhBtn.Text = "Lịch sử  lệnh";
         this.lichSuGiaoDichLenhBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.lichSuGiaoDichLenhBtn.UseVisualStyleBackColor = true;
         this.lichSuGiaoDichLenhBtn.Click += new System.EventHandler(this.lichSuGiaoDichLenhBtn_Click);
         // 
         // accountSumerizeReporBtn
         // 
         this.accountSumerizeReporBtn.Image = global::Brokery.Properties.Resources.map;
         this.accountSumerizeReporBtn.Location = new System.Drawing.Point(336, 16);
         this.accountSumerizeReporBtn.Name = "accountSumerizeReporBtn";
         this.accountSumerizeReporBtn.Size = new System.Drawing.Size(112, 33);
         this.accountSumerizeReporBtn.TabIndex = 8;
         this.accountSumerizeReporBtn.Text = "Tổng hợp";
         this.accountSumerizeReporBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.accountSumerizeReporBtn.UseVisualStyleBackColor = true;
         this.accountSumerizeReporBtn.Click += new System.EventHandler(this.accountSumerizeReporBtn_Click);
         // 
         // btListStockTrans
         // 
         this.btListStockTrans.Image = global::Brokery.Properties.Resources.package;
         this.btListStockTrans.Location = new System.Drawing.Point(209, 16);
         this.btListStockTrans.Name = "btListStockTrans";
         this.btListStockTrans.Size = new System.Drawing.Size(112, 33);
         this.btListStockTrans.TabIndex = 7;
         this.btListStockTrans.Text = "Chứng khoán";
         this.btListStockTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btListStockTrans.UseVisualStyleBackColor = true;
         this.btListStockTrans.Click += new System.EventHandler(this.btListStockTrans_Click);
         // 
         // btListMoneyTrans
         // 
         this.btListMoneyTrans.Image = global::Brokery.Properties.Resources.money_dollar;
         this.btListMoneyTrans.Location = new System.Drawing.Point(82, 16);
         this.btListMoneyTrans.Name = "btListMoneyTrans";
         this.btListMoneyTrans.Size = new System.Drawing.Size(112, 33);
         this.btListMoneyTrans.TabIndex = 6;
         this.btListMoneyTrans.Text = "Tiền";
         this.btListMoneyTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btListMoneyTrans.UseVisualStyleBackColor = true;
         this.btListMoneyTrans.Click += new System.EventHandler(this.btListMoneyTrans_Click);
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // customerIdDataGridViewTextBoxColumn
         // 
         this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
         this.customerIdDataGridViewTextBoxColumn.HeaderText = "Tài khoản KH";
         this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
         this.customerIdDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // customerNameDataGridViewTextBoxColumn
         // 
         this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
         this.customerNameDataGridViewTextBoxColumn.HeaderText = "Tên khách hàng";
         this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
         this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
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
         // bindingSource
         // 
         this.bindingSource.DataSource = typeof(Brokery.AgencyWebService.Customer);
         // 
         // ServiceCodeColumn
         // 
         this.ServiceCodeColumn.DataPropertyName = "ServiceCode";
         this.ServiceCodeColumn.HeaderText = "Mã dịch vụ";
         this.ServiceCodeColumn.Name = "ServiceCodeColumn";
         this.ServiceCodeColumn.ReadOnly = true;
         // 
         // ServiceNameColumn
         // 
         this.ServiceNameColumn.DataPropertyName = "ServiceName";
         this.ServiceNameColumn.HeaderText = "Tên dịch vụ";
         this.ServiceNameColumn.Name = "ServiceNameColumn";
         this.ServiceNameColumn.ReadOnly = true;
         // 
         // BeginDateColumn
         // 
         this.BeginDateColumn.DataPropertyName = "BeginDate";
         this.BeginDateColumn.HeaderText = "Ngày bắt đầu";
         this.BeginDateColumn.Name = "BeginDateColumn";
         this.BeginDateColumn.ReadOnly = true;
         // 
         // EndDateColumn
         // 
         this.EndDateColumn.DataPropertyName = "EndDate";
         this.EndDateColumn.HeaderText = "Ngày kết thúc";
         this.EndDateColumn.Name = "EndDateColumn";
         this.EndDateColumn.ReadOnly = true;
         // 
         // customerServiceBindingSource
         // 
         this.customerServiceBindingSource.DataSource = typeof(Brokery.AgencyWebService.CustomerService);
         // 
         // inquiryStockBindingSource
         // 
         this.inquiryStockBindingSource.DataSource = typeof(Brokery.AgencyWebService.InquiryStock);
         // 
         // BoardType
         // 
         this.BoardType.DataPropertyName = "BoardType";
         this.BoardType.HeaderText = "Sàn GD";
         this.BoardType.Name = "BoardType";
         this.BoardType.ReadOnly = true;
         // 
         // StockCode
         // 
         this.StockCode.DataPropertyName = "StockCode";
         this.StockCode.HeaderText = "Mã CK";
         this.StockCode.Name = "StockCode";
         this.StockCode.ReadOnly = true;
         // 
         // giaoDichCol
         // 
         this.giaoDichCol.DataPropertyName = "CKGD";
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle2.Format = "N0";
         dataGridViewCellStyle2.NullValue = "0";
         this.giaoDichCol.DefaultCellStyle = dataGridViewCellStyle2;
         this.giaoDichCol.HeaderText = "Giao dịch";
         this.giaoDichCol.Name = "giaoDichCol";
         this.giaoDichCol.ReadOnly = true;
         // 
         // CamCoCol
         // 
         this.CamCoCol.DataPropertyName = "CKCC";
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle3.Format = "N0";
         dataGridViewCellStyle3.NullValue = "0";
         this.CamCoCol.DefaultCellStyle = dataGridViewCellStyle3;
         this.CamCoCol.HeaderText = "Cầm cố";
         this.CamCoCol.Name = "CamCoCol";
         this.CamCoCol.ReadOnly = true;
         // 
         // hanCheCol
         // 
         this.hanCheCol.DataPropertyName = "CKHC";
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle4.Format = "n0";
         this.hanCheCol.DefaultCellStyle = dataGridViewCellStyle4;
         this.hanCheCol.HeaderText = "Hạn chế";
         this.hanCheCol.Name = "hanCheCol";
         this.hanCheCol.ReadOnly = true;
         // 
         // CKTONG
         // 
         this.CKTONG.DataPropertyName = "CKTONG";
         dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle5.Format = "n0";
         this.CKTONG.DefaultCellStyle = dataGridViewCellStyle5;
         this.CKTONG.HeaderText = "Tổng";
         this.CKTONG.Name = "CKTONG";
         this.CKTONG.ReadOnly = true;
         // 
         // DayTrading
         // 
         this.DayTrading.DataPropertyName = "DayTrading";
         dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle6.Format = "n0";
         this.DayTrading.DefaultCellStyle = dataGridViewCellStyle6;
         this.DayTrading.HeaderText = "Bán trong ngày";
         this.DayTrading.Name = "DayTrading";
         this.DayTrading.ReadOnly = true;
         // 
         // RemainVolume
         // 
         this.RemainVolume.DataPropertyName = "RemainVolume";
         dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle7.Format = "n0";
         this.RemainVolume.DefaultCellStyle = dataGridViewCellStyle7;
         this.RemainVolume.HeaderText = "KL còn lại";
         this.RemainVolume.Name = "RemainVolume";
         this.RemainVolume.ReadOnly = true;
         // 
         // CustomerInfo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(941, 644);
         this.Controls.Add(this.grpCustomer);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.KeyPreview = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CustomerInfo";
         this.Text = "Thông tin tài khoản khách hàng";
         this.Load += new System.EventHandler(this.CustomerInfo_Load);
         this.grpCustomer.ResumeLayout(false);
         this.grpCustomer.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.serviceGrid)).EndInit();
         this.tabControl1.ResumeLayout(false);
         this.tabSign1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.picSign1)).EndInit();
         this.tabSign2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.picSign2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.customerServiceBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.inquiryStockBindingSource)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private Button accountSumerizeReporBtn;
      private Label availBalanceLabel;
      private Label bankAvailBalanceLabel;
      private Label boughtCashLabel;
      private Button btListMoneyTrans;
      private Button btListStockTrans;
      private Button btnInquiryOnline;
      private Label currentBalanceLabel;
      private Label customerDebitLabel;
      private LinkLabel customerFeeLinkButton;
      private TextBox customerIdTextBox;
      private TextBox customerNameTextBox;
      private ErrorProvider errorProvider;
      private Button findButton;
      private GroupBox groupBox1;
      private GroupBox groupBox2;
      private GroupBox groupBox3;
      private GroupBox grpCustomer;
      private TextBox identityNumberTextBox;
      private BackgroundWorker inquiryOnlineWorker;
      private Label label1;
      private Label label10;
      private Label label3;
      private Label label4;
      private Label label5;
      private Label label6;
      private Label label7;
      private Label lblAccountID;
      private Label lblAccountName;
      private Label lblIdentityCard;
      private Label lblLastTimeInquiry;
      private Button lichSuGiaoDichLenhBtn;
      private Button loLaiDuKienBtn;
      private DataGridView mainGrid;
      private PictureBox picSign1;
      private PictureBox picSign2;
      private TextBox reservedTextBox;
      private DataGridView serviceGrid;
      private TabControl tabControl1;
      private TabPage tabSign1;
      private TabPage tabSign2;
      private BindingSource bindingSource;
      private DataGridView customerGrid;
      private BindingSource customerServiceBindingSource;
      private BindingSource inquiryStockBindingSource;
      private DataGridViewTextBoxColumn ServiceCodeColumn;
      private DataGridViewTextBoxColumn ServiceNameColumn;
      private DataGridViewTextBoxColumn BeginDateColumn;
      private DataGridViewTextBoxColumn EndDateColumn;
      private DataGridViewTextBoxColumn Status;
      private Button exitBtn;
      private DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn TradeCode;
      private DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn CardIdentity;
      private DataGridViewTextBoxColumn bankCodeDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn cIFDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn BoardType;
      private DataGridViewTextBoxColumn StockCode;
      private DataGridViewTextBoxColumn giaoDichCol;
      private DataGridViewTextBoxColumn CamCoCol;
      private DataGridViewTextBoxColumn hanCheCol;
      private DataGridViewTextBoxColumn CKTONG;
      private DataGridViewTextBoxColumn DayTrading;
      private DataGridViewTextBoxColumn RemainVolume;
   }
}