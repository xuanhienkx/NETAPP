namespace VRMApp.Brokerage
{
   partial class ContractForm
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
         this.grpCustomer = new System.Windows.Forms.GroupBox();
         this.customerIdTextBox = new System.Windows.Forms.TextBox();
         this.lblAccountID = new System.Windows.Forms.Label();
         this.findButton = new System.Windows.Forms.Button();
         this.lblAccountName = new System.Windows.Forms.Label();
         this.customerNameTextBox = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.labelSoTienDeNghi = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.textBoxLaiPhat = new System.Windows.Forms.TextBox();
         this.label14 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.textBoxLaiNgay = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this.textBoxAmount = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.textBoxSoHD = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.expriedDate = new System.Windows.Forms.DateTimePicker();
         this.label4 = new System.Windows.Forms.Label();
         this.fromDate = new System.Windows.Forms.DateTimePicker();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.thangKyHanNumber = new System.Windows.Forms.NumericUpDown();
         this.trangThaiLbl = new System.Windows.Forms.Label();
         this.coKyHanOption = new System.Windows.Forms.RadioButton();
         this.khongKyHanOption = new System.Windows.Forms.RadioButton();
         this.label1 = new System.Windows.Forms.Label();
         this.approvedButton = new System.Windows.Forms.Button();
         this.saveButton = new System.Windows.Forms.Button();
         this.exitButton = new System.Windows.Forms.Button();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.printButton = new System.Windows.Forms.Button();
         this.label6 = new System.Windows.Forms.Label();
         this.tongNoLbl = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.tileHopTacLbl = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.tongTSLbl = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.lblTiLeNo = new System.Windows.Forms.Label();
         this.soTienToiDaTextBox = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.grpCustomer.SuspendLayout();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.thangKyHanNumber)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // grpCustomer
         // 
         this.grpCustomer.Controls.Add(this.customerIdTextBox);
         this.grpCustomer.Controls.Add(this.lblAccountID);
         this.grpCustomer.Controls.Add(this.findButton);
         this.grpCustomer.Controls.Add(this.lblAccountName);
         this.grpCustomer.Controls.Add(this.customerNameTextBox);
         this.grpCustomer.Location = new System.Drawing.Point(12, 12);
         this.grpCustomer.Name = "grpCustomer";
         this.grpCustomer.Size = new System.Drawing.Size(487, 72);
         this.grpCustomer.TabIndex = 27;
         this.grpCustomer.TabStop = false;
         // 
         // customerIdTextBox
         // 
         this.customerIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.customerIdTextBox.ForeColor = System.Drawing.Color.Blue;
         this.customerIdTextBox.Location = new System.Drawing.Point(33, 33);
         this.customerIdTextBox.MaxLength = 10;
         this.customerIdTextBox.Name = "customerIdTextBox";
         this.customerIdTextBox.Size = new System.Drawing.Size(97, 20);
         this.customerIdTextBox.TabIndex = 0;
         this.customerIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.customerIdTextBox.Validated += new System.EventHandler(this.customerIdTextBox_Validated);
         // 
         // lblAccountID
         // 
         this.lblAccountID.AutoSize = true;
         this.lblAccountID.Location = new System.Drawing.Point(30, 18);
         this.lblAccountID.Name = "lblAccountID";
         this.lblAccountID.Size = new System.Drawing.Size(85, 13);
         this.lblAccountID.TabIndex = 7;
         this.lblAccountID.Text = "Mã khách hàng:";
         // 
         // findButton
         // 
         this.findButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.findButton.Image = global::VRMApp.Properties.Resources.find;
         this.findButton.Location = new System.Drawing.Point(354, 29);
         this.findButton.Name = "findButton";
         this.findButton.Size = new System.Drawing.Size(91, 28);
         this.findButton.TabIndex = 1;
         this.findButton.Text = "&Tìm";
         this.findButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.findButton.UseVisualStyleBackColor = true;
         this.findButton.Click += new System.EventHandler(this.findButton_Click);
         // 
         // lblAccountName
         // 
         this.lblAccountName.AutoSize = true;
         this.lblAccountName.Location = new System.Drawing.Point(149, 18);
         this.lblAccountName.Name = "lblAccountName";
         this.lblAccountName.Size = new System.Drawing.Size(89, 13);
         this.lblAccountName.TabIndex = 8;
         this.lblAccountName.Text = "Tên khách hàng:";
         // 
         // customerNameTextBox
         // 
         this.customerNameTextBox.BackColor = System.Drawing.Color.DarkKhaki;
         this.customerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.customerNameTextBox.ForeColor = System.Drawing.SystemColors.Info;
         this.customerNameTextBox.Location = new System.Drawing.Point(152, 34);
         this.customerNameTextBox.MaxLength = 100;
         this.customerNameTextBox.Name = "customerNameTextBox";
         this.customerNameTextBox.ReadOnly = true;
         this.customerNameTextBox.Size = new System.Drawing.Size(180, 20);
         this.customerNameTextBox.TabIndex = 1;
         this.customerNameTextBox.TabStop = false;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.labelSoTienDeNghi);
         this.groupBox1.Controls.Add(this.label13);
         this.groupBox1.Controls.Add(this.textBoxLaiPhat);
         this.groupBox1.Controls.Add(this.label14);
         this.groupBox1.Controls.Add(this.label12);
         this.groupBox1.Controls.Add(this.textBoxLaiNgay);
         this.groupBox1.Controls.Add(this.label10);
         this.groupBox1.Controls.Add(this.textBoxAmount);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.textBoxSoHD);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.expriedDate);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.fromDate);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.thangKyHanNumber);
         this.groupBox1.Controls.Add(this.trangThaiLbl);
         this.groupBox1.Controls.Add(this.coKyHanOption);
         this.groupBox1.Controls.Add(this.khongKyHanOption);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 219);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(487, 234);
         this.groupBox1.TabIndex = 28;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Thông tin sản phẩm hợp tác kinh doanh";
         // 
         // labelSoTienDeNghi
         // 
         this.labelSoTienDeNghi.AutoSize = true;
         this.labelSoTienDeNghi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelSoTienDeNghi.ForeColor = System.Drawing.Color.Navy;
         this.labelSoTienDeNghi.Location = new System.Drawing.Point(273, 171);
         this.labelSoTienDeNghi.Name = "labelSoTienDeNghi";
         this.labelSoTienDeNghi.Size = new System.Drawing.Size(0, 13);
         this.labelSoTienDeNghi.TabIndex = 18;
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(364, 199);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(15, 13);
         this.label13.TabIndex = 17;
         this.label13.Text = "%";
         // 
         // textBoxLaiPhat
         // 
         this.textBoxLaiPhat.Enabled = false;
         this.textBoxLaiPhat.Location = new System.Drawing.Point(314, 196);
         this.textBoxLaiPhat.Name = "textBoxLaiPhat";
         this.textBoxLaiPhat.Size = new System.Drawing.Size(44, 20);
         this.textBoxLaiPhat.TabIndex = 16;
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(237, 199);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(74, 13);
         this.label14.TabIndex = 15;
         this.label14.Text = "Lãi phạt ngày:";
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(181, 199);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(15, 13);
         this.label12.TabIndex = 14;
         this.label12.Text = "%";
         // 
         // textBoxLaiNgay
         // 
         this.textBoxLaiNgay.Enabled = false;
         this.textBoxLaiNgay.Location = new System.Drawing.Point(131, 196);
         this.textBoxLaiNgay.Name = "textBoxLaiNgay";
         this.textBoxLaiNgay.Size = new System.Drawing.Size(44, 20);
         this.textBoxLaiNgay.TabIndex = 13;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(52, 199);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(73, 13);
         this.label10.TabIndex = 12;
         this.label10.Text = "Lãi suất ngày:";
         // 
         // textBoxAmount
         // 
         this.textBoxAmount.Enabled = false;
         this.textBoxAmount.Location = new System.Drawing.Point(131, 168);
         this.textBoxAmount.Name = "textBoxAmount";
         this.textBoxAmount.Size = new System.Drawing.Size(124, 20);
         this.textBoxAmount.TabIndex = 11;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(43, 171);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(82, 13);
         this.label5.TabIndex = 10;
         this.label5.Text = "Số tiền hợp tác:";
         // 
         // textBoxSoHD
         // 
         this.textBoxSoHD.BackColor = System.Drawing.Color.Cornsilk;
         this.textBoxSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBoxSoHD.ForeColor = System.Drawing.SystemColors.ControlText;
         this.textBoxSoHD.Location = new System.Drawing.Point(131, 26);
         this.textBoxSoHD.MaxLength = 100;
         this.textBoxSoHD.Name = "textBoxSoHD";
         this.textBoxSoHD.ReadOnly = true;
         this.textBoxSoHD.Size = new System.Drawing.Size(180, 20);
         this.textBoxSoHD.TabIndex = 9;
         this.textBoxSoHD.TabStop = false;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(74, 29);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(42, 13);
         this.label7.TabIndex = 8;
         this.label7.Text = "Số HĐ:";
         // 
         // expriedDate
         // 
         this.expriedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.expriedDate.Location = new System.Drawing.Point(301, 138);
         this.expriedDate.Name = "expriedDate";
         this.expriedDate.Size = new System.Drawing.Size(103, 20);
         this.expriedDate.TabIndex = 6;
         this.expriedDate.Validated += new System.EventHandler(this.expriedDate_Validated);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(112, 142);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(161, 13);
         this.label4.TabIndex = 7;
         this.label4.Text = "Thời gian hợp đồng hết hiệu lực:";
         // 
         // fromDate
         // 
         this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.fromDate.Location = new System.Drawing.Point(301, 107);
         this.fromDate.Name = "fromDate";
         this.fromDate.Size = new System.Drawing.Size(103, 20);
         this.fromDate.TabIndex = 5;
         this.fromDate.Validated += new System.EventHandler(this.fromDate_Validated);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(112, 111);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(183, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = "Thời gian hợp đồng bắt đầu hiệu lực:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(328, 83);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(34, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "tháng";
         // 
         // thangKyHanNumber
         // 
         this.thangKyHanNumber.Enabled = false;
         this.thangKyHanNumber.Location = new System.Drawing.Point(290, 79);
         this.thangKyHanNumber.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
         this.thangKyHanNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.thangKyHanNumber.Name = "thangKyHanNumber";
         this.thangKyHanNumber.Size = new System.Drawing.Size(32, 20);
         this.thangKyHanNumber.TabIndex = 4;
         this.thangKyHanNumber.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
         this.thangKyHanNumber.ValueChanged += new System.EventHandler(this.thangKyHanNumber_ValueChanged);
         // 
         // trangThaiLbl
         // 
         this.trangThaiLbl.AutoEllipsis = true;
         this.trangThaiLbl.BackColor = System.Drawing.Color.Red;
         this.trangThaiLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.trangThaiLbl.ForeColor = System.Drawing.Color.MintCream;
         this.trangThaiLbl.Location = new System.Drawing.Point(324, 26);
         this.trangThaiLbl.Name = "trangThaiLbl";
         this.trangThaiLbl.Size = new System.Drawing.Size(146, 23);
         this.trangThaiLbl.TabIndex = 1;
         this.trangThaiLbl.Text = "NONE";
         this.trangThaiLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // coKyHanOption
         // 
         this.coKyHanOption.AutoSize = true;
         this.coKyHanOption.Location = new System.Drawing.Point(115, 79);
         this.coKyHanOption.Name = "coKyHanOption";
         this.coKyHanOption.Size = new System.Drawing.Size(169, 17);
         this.coKyHanOption.TabIndex = 3;
         this.coKyHanOption.Text = "Hợp tác kinh doanh có kỳ hạn";
         this.coKyHanOption.UseVisualStyleBackColor = true;
         this.coKyHanOption.CheckedChanged += new System.EventHandler(this.coKyHanOption_CheckedChanged);
         // 
         // khongKyHanOption
         // 
         this.khongKyHanOption.AutoSize = true;
         this.khongKyHanOption.Checked = true;
         this.khongKyHanOption.Location = new System.Drawing.Point(115, 55);
         this.khongKyHanOption.Name = "khongKyHanOption";
         this.khongKyHanOption.Size = new System.Drawing.Size(329, 17);
         this.khongKyHanOption.TabIndex = 2;
         this.khongKyHanOption.TabStop = true;
         this.khongKyHanOption.Text = "Hợp tác kinh doanh không kỳ hạn (thời hạn không quá 30 ngày)";
         this.khongKyHanOption.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(30, 55);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(79, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Loại sản phẩm:";
         // 
         // approvedButton
         // 
         this.approvedButton.Enabled = false;
         this.approvedButton.Image = global::VRMApp.Properties.Resources.accept;
         this.approvedButton.Location = new System.Drawing.Point(42, 470);
         this.approvedButton.Name = "approvedButton";
         this.approvedButton.Size = new System.Drawing.Size(87, 28);
         this.approvedButton.TabIndex = 7;
         this.approvedButton.Text = "&Duyệt";
         this.approvedButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.approvedButton.UseVisualStyleBackColor = true;
         this.approvedButton.Click += new System.EventHandler(this.approvedButton_Click);
         // 
         // saveButton
         // 
         this.saveButton.Image = global::VRMApp.Properties.Resources.disk;
         this.saveButton.Location = new System.Drawing.Point(289, 470);
         this.saveButton.Name = "saveButton";
         this.saveButton.Size = new System.Drawing.Size(85, 31);
         this.saveButton.TabIndex = 8;
         this.saveButton.Text = "&Lưu";
         this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.saveButton.UseVisualStyleBackColor = true;
         this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
         // 
         // exitButton
         // 
         this.exitButton.Image = global::VRMApp.Properties.Resources.cancel;
         this.exitButton.Location = new System.Drawing.Point(397, 470);
         this.exitButton.Name = "exitButton";
         this.exitButton.Size = new System.Drawing.Size(85, 31);
         this.exitButton.TabIndex = 9;
         this.exitButton.Text = "&Thoát";
         this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.exitButton.UseVisualStyleBackColor = true;
         this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // printButton
         // 
         this.printButton.Image = global::VRMApp.Properties.Resources.printer;
         this.printButton.Location = new System.Drawing.Point(182, 470);
         this.printButton.Name = "printButton";
         this.printButton.Size = new System.Drawing.Size(85, 31);
         this.printButton.TabIndex = 30;
         this.printButton.Text = "&In HĐ";
         this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.printButton.UseVisualStyleBackColor = true;
         this.printButton.Click += new System.EventHandler(this.printButton_Click);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(167, 25);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(106, 13);
         this.label6.TabIndex = 2;
         this.label6.Text = "Tổng tiền nợ của KH";
         // 
         // tongNoLbl
         // 
         this.tongNoLbl.AutoEllipsis = true;
         this.tongNoLbl.BackColor = System.Drawing.Color.DarkGoldenrod;
         this.tongNoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tongNoLbl.ForeColor = System.Drawing.Color.MintCream;
         this.tongNoLbl.Location = new System.Drawing.Point(167, 47);
         this.tongNoLbl.Name = "tongNoLbl";
         this.tongNoLbl.Size = new System.Drawing.Size(117, 23);
         this.tongNoLbl.TabIndex = 3;
         this.tongNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(394, 25);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(69, 13);
         this.label9.TabIndex = 4;
         this.label9.Text = "Tỷ lệ hợp tác";
         // 
         // tileHopTacLbl
         // 
         this.tileHopTacLbl.AutoEllipsis = true;
         this.tileHopTacLbl.BackColor = System.Drawing.Color.DarkGreen;
         this.tileHopTacLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tileHopTacLbl.ForeColor = System.Drawing.Color.MintCream;
         this.tileHopTacLbl.Location = new System.Drawing.Point(394, 47);
         this.tileHopTacLbl.Name = "tileHopTacLbl";
         this.tileHopTacLbl.Size = new System.Drawing.Size(64, 23);
         this.tileHopTacLbl.TabIndex = 5;
         this.tileHopTacLbl.Text = "%";
         this.tileHopTacLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(27, 25);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(105, 13);
         this.label11.TabIndex = 6;
         this.label11.Text = "Tổng tài sản của KH";
         // 
         // tongTSLbl
         // 
         this.tongTSLbl.AutoEllipsis = true;
         this.tongTSLbl.BackColor = System.Drawing.Color.DarkGoldenrod;
         this.tongTSLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tongTSLbl.ForeColor = System.Drawing.Color.MintCream;
         this.tongTSLbl.Location = new System.Drawing.Point(27, 47);
         this.tongTSLbl.Name = "tongTSLbl";
         this.tongTSLbl.Size = new System.Drawing.Size(117, 23);
         this.tongTSLbl.TabIndex = 7;
         this.tongTSLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(307, 25);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(64, 13);
         this.label8.TabIndex = 8;
         this.label8.Text = "Tỷ lệ nợ/TS";
         // 
         // lblTiLeNo
         // 
         this.lblTiLeNo.AutoEllipsis = true;
         this.lblTiLeNo.BackColor = System.Drawing.Color.DarkGoldenrod;
         this.lblTiLeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTiLeNo.ForeColor = System.Drawing.Color.MintCream;
         this.lblTiLeNo.Location = new System.Drawing.Point(307, 47);
         this.lblTiLeNo.Name = "lblTiLeNo";
         this.lblTiLeNo.Size = new System.Drawing.Size(64, 23);
         this.lblTiLeNo.TabIndex = 9;
         this.lblTiLeNo.Text = "%";
         this.lblTiLeNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // soTienToiDaTextBox
         // 
         this.soTienToiDaTextBox.AutoSize = true;
         this.soTienToiDaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.soTienToiDaTextBox.ForeColor = System.Drawing.Color.Red;
         this.soTienToiDaTextBox.Location = new System.Drawing.Point(30, 91);
         this.soTienToiDaTextBox.Name = "soTienToiDaTextBox";
         this.soTienToiDaTextBox.Size = new System.Drawing.Size(198, 17);
         this.soTienToiDaTextBox.TabIndex = 38;
         this.soTienToiDaTextBox.Text = "Số tiền hợp tác tối đa có thể: -";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.soTienToiDaTextBox);
         this.groupBox2.Controls.Add(this.lblTiLeNo);
         this.groupBox2.Controls.Add(this.label8);
         this.groupBox2.Controls.Add(this.tongTSLbl);
         this.groupBox2.Controls.Add(this.label11);
         this.groupBox2.Controls.Add(this.tileHopTacLbl);
         this.groupBox2.Controls.Add(this.label9);
         this.groupBox2.Controls.Add(this.tongNoLbl);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Location = new System.Drawing.Point(12, 90);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(487, 123);
         this.groupBox2.TabIndex = 29;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Thông tin QTRR";
         // 
         // ContractForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(511, 525);
         this.Controls.Add(this.printButton);
         this.Controls.Add(this.exitButton);
         this.Controls.Add(this.approvedButton);
         this.Controls.Add(this.saveButton);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.grpCustomer);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ContractForm";
         this.Text = "Tạo mới hợp đồng HTKD";
         this.Load += new System.EventHandler(this.ContractForm_Load);
         this.grpCustomer.ResumeLayout(false);
         this.grpCustomer.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.thangKyHanNumber)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox grpCustomer;
      private System.Windows.Forms.TextBox customerIdTextBox;
      private System.Windows.Forms.Label lblAccountID;
      private System.Windows.Forms.Button findButton;
      private System.Windows.Forms.Label lblAccountName;
      private System.Windows.Forms.TextBox customerNameTextBox;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown thangKyHanNumber;
      private System.Windows.Forms.RadioButton coKyHanOption;
      private System.Windows.Forms.RadioButton khongKyHanOption;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DateTimePicker expriedDate;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.DateTimePicker fromDate;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label trangThaiLbl;
      private System.Windows.Forms.Button approvedButton;
      private System.Windows.Forms.Button saveButton;
      private System.Windows.Forms.Button exitButton;
      private System.Windows.Forms.ErrorProvider errorProvider;
      private System.Windows.Forms.TextBox textBoxSoHD;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Button printButton;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.TextBox textBoxLaiNgay;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox textBoxAmount;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.TextBox textBoxLaiPhat;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.Label labelSoTienDeNghi;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label soTienToiDaTextBox;
      private System.Windows.Forms.Label lblTiLeNo;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label tongTSLbl;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label tileHopTacLbl;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label tongNoLbl;
      private System.Windows.Forms.Label label6;

   }
}