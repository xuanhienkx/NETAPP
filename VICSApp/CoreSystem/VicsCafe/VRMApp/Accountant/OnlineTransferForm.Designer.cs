namespace VRMApp.Accountant
{
    partial class OnlineTransferForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cardDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.isAuthorizionComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cardIssuerTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cardIdentityTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.accountTransferNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.customerIDTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.provinceComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.transferBankBranchComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.transferBankComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.accountIDTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.remainTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ContractIDTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.transferfeeTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rejectTextBox = new System.Windows.Forms.TextBox();
            this.transferdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.trangThaiCombo = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.printContractButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cardDateDateTimePicker);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.isAuthorizionComboBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cardIssuerTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cardIdentityTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.accountTransferNameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin người thụ hưởng";
            // 
            // cardDateDateTimePicker
            // 
            this.cardDateDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.cardDateDateTimePicker.Enabled = false;
            this.cardDateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cardDateDateTimePicker.Location = new System.Drawing.Point(260, 81);
            this.cardDateDateTimePicker.Name = "cardDateDateTimePicker";
            this.cardDateDateTimePicker.Size = new System.Drawing.Size(104, 20);
            this.cardDateDateTimePicker.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(202, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Ngày cấp:";
            // 
            // isAuthorizionComboBox
            // 
            this.isAuthorizionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.isAuthorizionComboBox.Enabled = false;
            this.isAuthorizionComboBox.FormattingEnabled = true;
            this.isAuthorizionComboBox.Items.AddRange(new object[] {
            "Chính chủ",
            "Ủy quyền"});
            this.isAuthorizionComboBox.Location = new System.Drawing.Point(97, 26);
            this.isAuthorizionComboBox.Name = "isAuthorizionComboBox";
            this.isAuthorizionComboBox.Size = new System.Drawing.Size(121, 21);
            this.isAuthorizionComboBox.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Loại tài khoản:";
            // 
            // cardIssuerTextBox
            // 
            this.cardIssuerTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.cardIssuerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardIssuerTextBox.ForeColor = System.Drawing.Color.Black;
            this.cardIssuerTextBox.Location = new System.Drawing.Point(419, 80);
            this.cardIssuerTextBox.Name = "cardIssuerTextBox";
            this.cardIssuerTextBox.ReadOnly = true;
            this.cardIssuerTextBox.Size = new System.Drawing.Size(166, 20);
            this.cardIssuerTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nơi cấp:";
            // 
            // cardIdentityTextBox
            // 
            this.cardIdentityTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.cardIdentityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardIdentityTextBox.ForeColor = System.Drawing.Color.Black;
            this.cardIdentityTextBox.Location = new System.Drawing.Point(97, 81);
            this.cardIdentityTextBox.Name = "cardIdentityTextBox";
            this.cardIdentityTextBox.ReadOnly = true;
            this.cardIdentityTextBox.Size = new System.Drawing.Size(99, 20);
            this.cardIdentityTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số CMT";
            // 
            // accountTransferNameTextBox
            // 
            this.accountTransferNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.accountTransferNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountTransferNameTextBox.ForeColor = System.Drawing.Color.Black;
            this.accountTransferNameTextBox.Location = new System.Drawing.Point(97, 53);
            this.accountTransferNameTextBox.Name = "accountTransferNameTextBox";
            this.accountTransferNameTextBox.ReadOnly = true;
            this.accountTransferNameTextBox.Size = new System.Drawing.Size(488, 20);
            this.accountTransferNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.customerIDTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.customerNameTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 78);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng:";
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.customerIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIDTextBox.ForeColor = System.Drawing.Color.Black;
            this.customerIDTextBox.Location = new System.Drawing.Point(97, 19);
            this.customerIDTextBox.Name = "customerIDTextBox";
            this.customerIDTextBox.ReadOnly = true;
            this.customerIDTextBox.Size = new System.Drawing.Size(117, 20);
            this.customerIDTextBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mã khách hàng:";
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.customerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNameTextBox.ForeColor = System.Drawing.Color.Black;
            this.customerNameTextBox.Location = new System.Drawing.Point(97, 46);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.ReadOnly = true;
            this.customerNameTextBox.Size = new System.Drawing.Size(488, 20);
            this.customerNameTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Họ tên:";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Image = global::VRMApp.Properties.Resources.axdown;
            this.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.Location = new System.Drawing.Point(207, 473);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 3;
            this.UpdateButton.Text = "Cập nhật";
            this.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(534, 473);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Đóng lại";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.provinceComboBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.transferBankBranchComboBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.transferBankComboBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.accountIDTextBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(610, 91);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ngân hàng người thụ hưởng";
            // 
            // provinceComboBox
            // 
            this.provinceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provinceComboBox.Enabled = false;
            this.provinceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provinceComboBox.FormattingEnabled = true;
            this.provinceComboBox.Location = new System.Drawing.Point(463, 53);
            this.provinceComboBox.Name = "provinceComboBox";
            this.provinceComboBox.Size = new System.Drawing.Size(127, 21);
            this.provinceComboBox.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(410, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tỉnh/ TP:";
            // 
            // transferBankBranchComboBox
            // 
            this.transferBankBranchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transferBankBranchComboBox.Enabled = false;
            this.transferBankBranchComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferBankBranchComboBox.FormattingEnabled = true;
            this.transferBankBranchComboBox.Location = new System.Drawing.Point(97, 53);
            this.transferBankBranchComboBox.Name = "transferBankBranchComboBox";
            this.transferBankBranchComboBox.Size = new System.Drawing.Size(301, 21);
            this.transferBankBranchComboBox.TabIndex = 2;
            this.transferBankBranchComboBox.SelectedIndexChanged += new System.EventHandler(this.transferBankBranchComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Chi nhánh:";
            // 
            // transferBankComboBox
            // 
            this.transferBankComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transferBankComboBox.Enabled = false;
            this.transferBankComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferBankComboBox.FormattingEnabled = true;
            this.transferBankComboBox.Location = new System.Drawing.Point(366, 26);
            this.transferBankComboBox.Name = "transferBankComboBox";
            this.transferBankComboBox.Size = new System.Drawing.Size(223, 21);
            this.transferBankComboBox.TabIndex = 1;
            this.transferBankComboBox.SelectedIndexChanged += new System.EventHandler(this.transferBankComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ngân hàng:";
            // 
            // accountIDTextBox
            // 
            this.accountIDTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.accountIDTextBox.ForeColor = System.Drawing.Color.Blue;
            this.accountIDTextBox.Location = new System.Drawing.Point(97, 26);
            this.accountIDTextBox.Name = "accountIDTextBox";
            this.accountIDTextBox.ReadOnly = true;
            this.accountIDTextBox.Size = new System.Drawing.Size(182, 20);
            this.accountIDTextBox.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Số tài khoản:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.remainTextBox);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.ContractIDTextBox);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.transferfeeTextBox);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.rejectTextBox);
            this.groupBox4.Controls.Add(this.transferdateDateTimePicker);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.amountTextBox);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.descriptionTextBox);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(611, 147);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin chuyển tiền:";
            // 
            // remainTextBox
            // 
            this.remainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainTextBox.ForeColor = System.Drawing.Color.Red;
            this.remainTextBox.Location = new System.Drawing.Point(469, 45);
            this.remainTextBox.Name = "remainTextBox";
            this.remainTextBox.ReadOnly = true;
            this.remainTextBox.Size = new System.Drawing.Size(121, 23);
            this.remainTextBox.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(380, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Tiền cần chuyển:";
            // 
            // ContractIDTextBox
            // 
            this.ContractIDTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.ContractIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractIDTextBox.ForeColor = System.Drawing.Color.Black;
            this.ContractIDTextBox.Location = new System.Drawing.Point(97, 18);
            this.ContractIDTextBox.Name = "ContractIDTextBox";
            this.ContractIDTextBox.ReadOnly = true;
            this.ContractIDTextBox.Size = new System.Drawing.Size(173, 20);
            this.ContractIDTextBox.TabIndex = 18;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(13, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "Số hợp đồng:";
            // 
            // transferfeeTextBox
            // 
            this.transferfeeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferfeeTextBox.ForeColor = System.Drawing.Color.Red;
            this.transferfeeTextBox.Location = new System.Drawing.Point(266, 44);
            this.transferfeeTextBox.Name = "transferfeeTextBox";
            this.transferfeeTextBox.Size = new System.Drawing.Size(98, 23);
            this.transferfeeTextBox.TabIndex = 16;
            this.transferfeeTextBox.Validated += new System.EventHandler(this.transferfeeTextBox_Validated);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(235, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Phí:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Phản hồi:";
            // 
            // rejectTextBox
            // 
            this.rejectTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejectTextBox.Location = new System.Drawing.Point(97, 104);
            this.rejectTextBox.Multiline = true;
            this.rejectTextBox.Name = "rejectTextBox";
            this.rejectTextBox.Size = new System.Drawing.Size(494, 34);
            this.rejectTextBox.TabIndex = 14;
            // 
            // transferdateDateTimePicker
            // 
            this.transferdateDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.transferdateDateTimePicker.Enabled = false;
            this.transferdateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.transferdateDateTimePicker.Location = new System.Drawing.Point(364, 19);
            this.transferdateDateTimePicker.Name = "transferdateDateTimePicker";
            this.transferdateDateTimePicker.Size = new System.Drawing.Size(104, 20);
            this.transferdateDateTimePicker.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(286, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Ngày yêu cầu:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.amountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountTextBox.ForeColor = System.Drawing.Color.Red;
            this.amountTextBox.Location = new System.Drawing.Point(97, 45);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.ReadOnly = true;
            this.amountTextBox.Size = new System.Drawing.Size(121, 23);
            this.amountTextBox.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Số tiền:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.ForeColor = System.Drawing.Color.Black;
            this.descriptionTextBox.Location = new System.Drawing.Point(97, 77);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(493, 20);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Nội dung:";
            // 
            // trangThaiCombo
            // 
            this.trangThaiCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trangThaiCombo.FormattingEnabled = true;
            this.trangThaiCombo.Items.AddRange(new object[] {
            "Chính chủ",
            "Ủy quyền"});
            this.trangThaiCombo.Location = new System.Drawing.Point(76, 475);
            this.trangThaiCombo.Name = "trangThaiCombo";
            this.trangThaiCombo.Size = new System.Drawing.Size(121, 21);
            this.trangThaiCombo.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 479);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Trạng thái:";
            // 
            // printContractButton
            // 
            this.printContractButton.Image = global::VRMApp.Properties.Resources.printer;
            this.printContractButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printContractButton.Location = new System.Drawing.Point(292, 473);
            this.printContractButton.Name = "printContractButton";
            this.printContractButton.Size = new System.Drawing.Size(88, 23);
            this.printContractButton.TabIndex = 11;
            this.printContractButton.Text = "In hợp đồng";
            this.printContractButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printContractButton.UseVisualStyleBackColor = true;
            this.printContractButton.Click += new System.EventHandler(this.printContractButton_Click);
            // 
            // OnlineTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 506);
            this.Controls.Add(this.printContractButton);
            this.Controls.Add(this.trangThaiCombo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OnlineTransferForm";
            this.Text = "Xử lý yêu cầu chuyển tiền internet";
            this.Load += new System.EventHandler(this.OnlineTransferForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox accountTransferNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox cardIssuerTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cardIdentityTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customerIDTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox isAuthorizionComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox provinceComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox transferBankBranchComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox transferBankComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox accountIDTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker cardDateDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker transferdateDateTimePicker;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox rejectTextBox;
        private System.Windows.Forms.ComboBox trangThaiCombo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox transferfeeTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button printContractButton;
        private System.Windows.Forms.TextBox ContractIDTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox remainTextBox;
        private System.Windows.Forms.Label label19;
    }
}