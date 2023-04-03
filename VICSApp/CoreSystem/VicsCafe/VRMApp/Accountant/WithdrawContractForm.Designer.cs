namespace VRMApp.Accountant
{
   partial class WithdrawContractForm
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
         this.grpCustomer = new System.Windows.Forms.GroupBox();
         this.customerIdTextBox = new System.Windows.Forms.TextBox();
         this.lblAccountID = new System.Windows.Forms.Label();
         this.findButton = new System.Windows.Forms.Button();
         this.lblAccountName = new System.Windows.Forms.Label();
         this.customerNameTextBox = new System.Windows.Forms.TextBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.textBoxSoHD = new System.Windows.Forms.TextBox();
         this.label13 = new System.Windows.Forms.Label();
         this.labelSoDuTien = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.lblTiLeNo = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.tongTSLbl = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.tileHopTacLbl = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.tongNoLbl = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.trangThaiLbl = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.exitButton = new System.Windows.Forms.Button();
         this.withdrawButton = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.button1 = new System.Windows.Forms.Button();
         this.labelTongGoc = new System.Windows.Forms.Label();
         this.label22 = new System.Windows.Forms.Label();
         this.labelTongPhi = new System.Windows.Forms.Label();
         this.label19 = new System.Windows.Forms.Label();
         this.textBoxPhiTraCham = new System.Windows.Forms.TextBox();
         this.label18 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.textBoxPhiHT = new System.Windows.Forms.TextBox();
         this.label17 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxLaiPhat = new System.Windows.Forms.TextBox();
         this.label14 = new System.Windows.Forms.Label();
         this.label15 = new System.Windows.Forms.Label();
         this.textBoxLaiNgay = new System.Windows.Forms.TextBox();
         this.label16 = new System.Windows.Forms.Label();
         this.textBoxGocPhaiThu = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this.textBoxNgayQuaHan = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.ngayHTTextBox = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.lblToDate = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.lblFromDate = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.grpCustomer.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // grpCustomer
         // 
         this.grpCustomer.Controls.Add(this.customerIdTextBox);
         this.grpCustomer.Controls.Add(this.lblAccountID);
         this.grpCustomer.Controls.Add(this.findButton);
         this.grpCustomer.Controls.Add(this.lblAccountName);
         this.grpCustomer.Controls.Add(this.customerNameTextBox);
         this.grpCustomer.Location = new System.Drawing.Point(17, 12);
         this.grpCustomer.Name = "grpCustomer";
         this.grpCustomer.Size = new System.Drawing.Size(487, 72);
         this.grpCustomer.TabIndex = 33;
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
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.textBoxSoHD);
         this.groupBox2.Controls.Add(this.label13);
         this.groupBox2.Controls.Add(this.labelSoDuTien);
         this.groupBox2.Controls.Add(this.label12);
         this.groupBox2.Controls.Add(this.lblTiLeNo);
         this.groupBox2.Controls.Add(this.label8);
         this.groupBox2.Controls.Add(this.tongTSLbl);
         this.groupBox2.Controls.Add(this.label11);
         this.groupBox2.Controls.Add(this.tileHopTacLbl);
         this.groupBox2.Controls.Add(this.label9);
         this.groupBox2.Controls.Add(this.tongNoLbl);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Controls.Add(this.trangThaiLbl);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Location = new System.Drawing.Point(17, 90);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(487, 179);
         this.groupBox2.TabIndex = 32;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Thông tin QTRR";
         // 
         // textBoxSoHD
         // 
         this.textBoxSoHD.BackColor = System.Drawing.Color.Cornsilk;
         this.textBoxSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBoxSoHD.ForeColor = System.Drawing.SystemColors.ControlText;
         this.textBoxSoHD.Location = new System.Drawing.Point(149, 19);
         this.textBoxSoHD.MaxLength = 100;
         this.textBoxSoHD.Name = "textBoxSoHD";
         this.textBoxSoHD.ReadOnly = true;
         this.textBoxSoHD.Size = new System.Drawing.Size(180, 20);
         this.textBoxSoHD.TabIndex = 27;
         this.textBoxSoHD.TabStop = false;
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(99, 22);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(42, 13);
         this.label13.TabIndex = 26;
         this.label13.Text = "Số HĐ:";
         // 
         // labelSoDuTien
         // 
         this.labelSoDuTien.AutoEllipsis = true;
         this.labelSoDuTien.BackColor = System.Drawing.Color.Chocolate;
         this.labelSoDuTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelSoDuTien.ForeColor = System.Drawing.Color.MintCream;
         this.labelSoDuTien.Location = new System.Drawing.Point(176, 143);
         this.labelSoDuTien.Name = "labelSoDuTien";
         this.labelSoDuTien.Size = new System.Drawing.Size(204, 23);
         this.labelSoDuTien.TabIndex = 25;
         this.labelSoDuTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(75, 148);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(95, 13);
         this.label12.TabIndex = 24;
         this.label12.Text = "Số dư tiền hiện tại:";
         // 
         // lblTiLeNo
         // 
         this.lblTiLeNo.AutoEllipsis = true;
         this.lblTiLeNo.BackColor = System.Drawing.Color.DarkGoldenrod;
         this.lblTiLeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTiLeNo.ForeColor = System.Drawing.Color.MintCream;
         this.lblTiLeNo.Location = new System.Drawing.Point(316, 111);
         this.lblTiLeNo.Name = "lblTiLeNo";
         this.lblTiLeNo.Size = new System.Drawing.Size(64, 23);
         this.lblTiLeNo.TabIndex = 9;
         this.lblTiLeNo.Text = "%";
         this.lblTiLeNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(316, 89);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(64, 13);
         this.label8.TabIndex = 8;
         this.label8.Text = "Tỷ lệ nợ/TS";
         // 
         // tongTSLbl
         // 
         this.tongTSLbl.AutoEllipsis = true;
         this.tongTSLbl.BackColor = System.Drawing.Color.DarkGoldenrod;
         this.tongTSLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tongTSLbl.ForeColor = System.Drawing.Color.MintCream;
         this.tongTSLbl.Location = new System.Drawing.Point(36, 111);
         this.tongTSLbl.Name = "tongTSLbl";
         this.tongTSLbl.Size = new System.Drawing.Size(117, 23);
         this.tongTSLbl.TabIndex = 7;
         this.tongTSLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(36, 89);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(105, 13);
         this.label11.TabIndex = 6;
         this.label11.Text = "Tổng tài sản của KH";
         // 
         // tileHopTacLbl
         // 
         this.tileHopTacLbl.AutoEllipsis = true;
         this.tileHopTacLbl.BackColor = System.Drawing.Color.DarkGreen;
         this.tileHopTacLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tileHopTacLbl.ForeColor = System.Drawing.Color.MintCream;
         this.tileHopTacLbl.Location = new System.Drawing.Point(403, 111);
         this.tileHopTacLbl.Name = "tileHopTacLbl";
         this.tileHopTacLbl.Size = new System.Drawing.Size(64, 23);
         this.tileHopTacLbl.TabIndex = 5;
         this.tileHopTacLbl.Text = "%";
         this.tileHopTacLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(403, 89);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(69, 13);
         this.label9.TabIndex = 4;
         this.label9.Text = "Tỷ lệ hợp tác";
         // 
         // tongNoLbl
         // 
         this.tongNoLbl.AutoEllipsis = true;
         this.tongNoLbl.BackColor = System.Drawing.Color.DarkGoldenrod;
         this.tongNoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tongNoLbl.ForeColor = System.Drawing.Color.MintCream;
         this.tongNoLbl.Location = new System.Drawing.Point(176, 111);
         this.tongNoLbl.Name = "tongNoLbl";
         this.tongNoLbl.Size = new System.Drawing.Size(117, 23);
         this.tongNoLbl.TabIndex = 3;
         this.tongNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(176, 89);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(128, 13);
         this.label6.TabIndex = 2;
         this.label6.Text = "Tổng nợ (Số tiền hợp tác)";
         // 
         // trangThaiLbl
         // 
         this.trangThaiLbl.AutoEllipsis = true;
         this.trangThaiLbl.BackColor = System.Drawing.Color.Red;
         this.trangThaiLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.trangThaiLbl.ForeColor = System.Drawing.Color.MintCream;
         this.trangThaiLbl.Location = new System.Drawing.Point(149, 52);
         this.trangThaiLbl.Name = "trangThaiLbl";
         this.trangThaiLbl.Size = new System.Drawing.Size(144, 23);
         this.trangThaiLbl.TabIndex = 1;
         this.trangThaiLbl.Text = "NONE";
         this.trangThaiLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(36, 57);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(107, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Tình trạng hợp đồng:";
         // 
         // exitButton
         // 
         this.exitButton.Image = global::VRMApp.Properties.Resources.cancel;
         this.exitButton.Location = new System.Drawing.Point(413, 509);
         this.exitButton.Name = "exitButton";
         this.exitButton.Size = new System.Drawing.Size(91, 31);
         this.exitButton.TabIndex = 38;
         this.exitButton.Text = "&Thoát";
         this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.exitButton.UseVisualStyleBackColor = true;
         this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
         // 
         // withdrawButton
         // 
         this.withdrawButton.Enabled = false;
         this.withdrawButton.Image = global::VRMApp.Properties.Resources.axdown;
         this.withdrawButton.Location = new System.Drawing.Point(294, 509);
         this.withdrawButton.Name = "withdrawButton";
         this.withdrawButton.Size = new System.Drawing.Size(91, 31);
         this.withdrawButton.TabIndex = 37;
         this.withdrawButton.Text = "&Thanh lý";
         this.withdrawButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.withdrawButton.UseVisualStyleBackColor = true;
         this.withdrawButton.Click += new System.EventHandler(this.withdrawButton_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.button1);
         this.groupBox1.Controls.Add(this.labelTongGoc);
         this.groupBox1.Controls.Add(this.label22);
         this.groupBox1.Controls.Add(this.labelTongPhi);
         this.groupBox1.Controls.Add(this.label19);
         this.groupBox1.Controls.Add(this.textBoxPhiTraCham);
         this.groupBox1.Controls.Add(this.label18);
         this.groupBox1.Controls.Add(this.panel1);
         this.groupBox1.Controls.Add(this.textBoxPhiHT);
         this.groupBox1.Controls.Add(this.label17);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.textBoxLaiPhat);
         this.groupBox1.Controls.Add(this.label14);
         this.groupBox1.Controls.Add(this.label15);
         this.groupBox1.Controls.Add(this.textBoxLaiNgay);
         this.groupBox1.Controls.Add(this.label16);
         this.groupBox1.Controls.Add(this.textBoxGocPhaiThu);
         this.groupBox1.Controls.Add(this.label10);
         this.groupBox1.Controls.Add(this.textBoxNgayQuaHan);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.ngayHTTextBox);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.lblToDate);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.lblFromDate);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(17, 275);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(487, 218);
         this.groupBox1.TabIndex = 39;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Thanh lý hợp đồng";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(284, 140);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 48;
         this.button1.Text = "Tính phí";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // labelTongGoc
         // 
         this.labelTongGoc.AutoEllipsis = true;
         this.labelTongGoc.BackColor = System.Drawing.Color.Blue;
         this.labelTongGoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelTongGoc.ForeColor = System.Drawing.Color.MintCream;
         this.labelTongGoc.Location = new System.Drawing.Point(322, 180);
         this.labelTongGoc.Name = "labelTongGoc";
         this.labelTongGoc.Size = new System.Drawing.Size(150, 23);
         this.labelTongGoc.TabIndex = 47;
         this.labelTongGoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label22
         // 
         this.label22.AutoSize = true;
         this.label22.Location = new System.Drawing.Point(254, 185);
         this.label22.Name = "label22";
         this.label22.Size = new System.Drawing.Size(67, 13);
         this.label22.TabIndex = 46;
         this.label22.Text = "TỔNG THU:";
         // 
         // labelTongPhi
         // 
         this.labelTongPhi.AutoEllipsis = true;
         this.labelTongPhi.BackColor = System.Drawing.Color.Blue;
         this.labelTongPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelTongPhi.ForeColor = System.Drawing.Color.MintCream;
         this.labelTongPhi.Location = new System.Drawing.Point(88, 180);
         this.labelTongPhi.Name = "labelTongPhi";
         this.labelTongPhi.Size = new System.Drawing.Size(150, 23);
         this.labelTongPhi.TabIndex = 45;
         this.labelTongPhi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label19
         // 
         this.label19.AutoSize = true;
         this.label19.Location = new System.Drawing.Point(20, 185);
         this.label19.Name = "label19";
         this.label19.Size = new System.Drawing.Size(62, 13);
         this.label19.TabIndex = 44;
         this.label19.Text = "TỔNG PHÍ:";
         // 
         // textBoxPhiTraCham
         // 
         this.textBoxPhiTraCham.Enabled = false;
         this.textBoxPhiTraCham.Location = new System.Drawing.Point(353, 116);
         this.textBoxPhiTraCham.Name = "textBoxPhiTraCham";
         this.textBoxPhiTraCham.Size = new System.Drawing.Size(114, 20);
         this.textBoxPhiTraCham.TabIndex = 43;
         // 
         // label18
         // 
         this.label18.AutoSize = true;
         this.label18.Location = new System.Drawing.Point(278, 119);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(71, 13);
         this.label18.TabIndex = 42;
         this.label18.Text = "Phí trả chậm:";
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Location = new System.Drawing.Point(23, 103);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(449, 2);
         this.panel1.TabIndex = 41;
         // 
         // textBoxPhiHT
         // 
         this.textBoxPhiHT.Enabled = false;
         this.textBoxPhiHT.Location = new System.Drawing.Point(124, 116);
         this.textBoxPhiHT.Name = "textBoxPhiHT";
         this.textBoxPhiHT.Size = new System.Drawing.Size(114, 20);
         this.textBoxPhiHT.TabIndex = 40;
         // 
         // label17
         // 
         this.label17.AutoSize = true;
         this.label17.Location = new System.Drawing.Point(49, 119);
         this.label17.Name = "label17";
         this.label17.Size = new System.Drawing.Size(66, 13);
         this.label17.TabIndex = 39;
         this.label17.Text = "Phí hợp tác:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(344, 80);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(15, 13);
         this.label3.TabIndex = 38;
         this.label3.Text = "%";
         // 
         // textBoxLaiPhat
         // 
         this.textBoxLaiPhat.Enabled = false;
         this.textBoxLaiPhat.Location = new System.Drawing.Point(291, 77);
         this.textBoxLaiPhat.Name = "textBoxLaiPhat";
         this.textBoxLaiPhat.Size = new System.Drawing.Size(47, 20);
         this.textBoxLaiPhat.TabIndex = 37;
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(211, 80);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(74, 13);
         this.label14.TabIndex = 36;
         this.label14.Text = "Lãi phạt ngày:";
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.Location = new System.Drawing.Point(173, 77);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(15, 13);
         this.label15.TabIndex = 35;
         this.label15.Text = "%";
         // 
         // textBoxLaiNgay
         // 
         this.textBoxLaiNgay.Enabled = false;
         this.textBoxLaiNgay.Location = new System.Drawing.Point(124, 74);
         this.textBoxLaiNgay.Name = "textBoxLaiNgay";
         this.textBoxLaiNgay.Size = new System.Drawing.Size(47, 20);
         this.textBoxLaiNgay.TabIndex = 34;
         // 
         // label16
         // 
         this.label16.AutoSize = true;
         this.label16.Location = new System.Drawing.Point(42, 77);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(73, 13);
         this.label16.TabIndex = 33;
         this.label16.Text = "Lãi suất ngày:";
         // 
         // textBoxGocPhaiThu
         // 
         this.textBoxGocPhaiThu.Location = new System.Drawing.Point(124, 142);
         this.textBoxGocPhaiThu.Name = "textBoxGocPhaiThu";
         this.textBoxGocPhaiThu.Size = new System.Drawing.Size(144, 20);
         this.textBoxGocPhaiThu.TabIndex = 32;
         this.textBoxGocPhaiThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(30, 145);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(93, 13);
         this.label10.TabIndex = 31;
         this.label10.Text = "Tiền gốc phải thu:";
         // 
         // textBoxNgayQuaHan
         // 
         this.textBoxNgayQuaHan.Location = new System.Drawing.Point(291, 48);
         this.textBoxNgayQuaHan.Name = "textBoxNgayQuaHan";
         this.textBoxNgayQuaHan.Size = new System.Drawing.Size(47, 20);
         this.textBoxNgayQuaHan.TabIndex = 30;
         this.textBoxNgayQuaHan.Text = "0";
         this.textBoxNgayQuaHan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(194, 51);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(91, 13);
         this.label7.TabIndex = 29;
         this.label7.Text = "Số ngày quá hạn:";
         // 
         // ngayHTTextBox
         // 
         this.ngayHTTextBox.Location = new System.Drawing.Point(124, 48);
         this.ngayHTTextBox.Name = "ngayHTTextBox";
         this.ngayHTTextBox.Size = new System.Drawing.Size(47, 20);
         this.ngayHTTextBox.TabIndex = 28;
         this.ngayHTTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(30, 51);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(88, 13);
         this.label4.TabIndex = 27;
         this.label4.Text = "Số ngày hợp tác:";
         // 
         // lblToDate
         // 
         this.lblToDate.AutoSize = true;
         this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblToDate.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
         this.lblToDate.Location = new System.Drawing.Point(313, 26);
         this.lblToDate.Name = "lblToDate";
         this.lblToDate.Size = new System.Drawing.Size(51, 13);
         this.lblToDate.TabIndex = 26;
         this.lblToDate.Text = "--/--/----";
         this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(252, 26);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(55, 13);
         this.label2.TabIndex = 25;
         this.label2.Text = "đến ngày:";
         // 
         // lblFromDate
         // 
         this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFromDate.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
         this.lblFromDate.Location = new System.Drawing.Point(174, 26);
         this.lblFromDate.Name = "lblFromDate";
         this.lblFromDate.Size = new System.Drawing.Size(72, 13);
         this.lblFromDate.TabIndex = 24;
         this.lblFromDate.Text = "--/--/----";
         this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(30, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(141, 13);
         this.label1.TabIndex = 23;
         this.label1.Text = "Thời gian hợp đồng từ ngày:";
         // 
         // WithdrawContractForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(520, 557);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.exitButton);
         this.Controls.Add(this.withdrawButton);
         this.Controls.Add(this.grpCustomer);
         this.Controls.Add(this.groupBox2);
         this.MaximizeBox = false;
         this.Name = "WithdrawContractForm";
         this.Text = "Thanh lý HĐ HTKD";
         this.Load += new System.EventHandler(this.WithdrawContractForm_Load);
         this.grpCustomer.ResumeLayout(false);
         this.grpCustomer.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox grpCustomer;
      private System.Windows.Forms.TextBox customerIdTextBox;
      private System.Windows.Forms.Label lblAccountID;
      private System.Windows.Forms.Button findButton;
      private System.Windows.Forms.Label lblAccountName;
      private System.Windows.Forms.TextBox customerNameTextBox;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label lblTiLeNo;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label tongTSLbl;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label tileHopTacLbl;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label tongNoLbl;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label trangThaiLbl;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Button exitButton;
      private System.Windows.Forms.Button withdrawButton;
      private System.Windows.Forms.Label labelSoDuTien;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.TextBox textBoxSoHD;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox textBoxGocPhaiThu;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox textBoxNgayQuaHan;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox ngayHTTextBox;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label lblToDate;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lblFromDate;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.TextBox textBoxPhiHT;
      private System.Windows.Forms.Label label17;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox textBoxLaiPhat;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.TextBox textBoxLaiNgay;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.Label labelTongGoc;
      private System.Windows.Forms.Label label22;
      private System.Windows.Forms.Label labelTongPhi;
      private System.Windows.Forms.Label label19;
      private System.Windows.Forms.TextBox textBoxPhiTraCham;
      private System.Windows.Forms.Label label18;
      private System.Windows.Forms.Button button1;
   }
}