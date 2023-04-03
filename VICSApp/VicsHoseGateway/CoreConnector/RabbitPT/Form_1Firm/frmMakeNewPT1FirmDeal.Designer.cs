namespace HOGW_PT_Dealer
{
    partial class frmMakeNewPT1FirmDeal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMakeNewPT1FirmDeal));
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCeilingPrice = new System.Windows.Forms.Label();
            this.lblBasicPrice = new System.Windows.Forms.Label();
            this.lblFloorPrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSellerTraderID = new System.Windows.Forms.ComboBox();
            this.lblSellerBalance = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSellerAvailBalance = new System.Windows.Forms.Label();
            this.lblSellerTraderID = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblBuyerAvailBalance = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblBuyerBalance = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cboBoardType = new System.Windows.Forms.ComboBox();
            this.chkHalt = new System.Windows.Forms.CheckBox();
            this.lblSuspension = new System.Windows.Forms.Label();
            this.lblSplit = new System.Windows.Forms.Label();
            this.lblHalt = new System.Windows.Forms.Label();
            this.lblDelist = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttipStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cboSellerClientID = new System.Windows.Forms.ComboBox();
            this.cboBuyerClientID = new System.Windows.Forms.ComboBox();
            this.cboSecurities = new System.Windows.Forms.ComboBox();
            this.chkLoadFromCore = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSellerSecBalance = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAvailSecBalance = new System.Windows.Forms.Label();
            this.btnLoadClientsFromCore = new System.Windows.Forms.Button();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTotalValue = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.LightCyan;
            this.txtPrice.Location = new System.Drawing.Point(123, 96);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(171, 20);
            this.txtPrice.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã trader";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Khách hàng bán";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Giá";
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(125, 495);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(121, 31);
            this.btnEnter.TabIndex = 20;
            this.btnEnter.Text = "&Nhập";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnterClick);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(385, 495);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 31);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Đón&g";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Chứng khoán";
            // 
            // lblCeilingPrice
            // 
            this.lblCeilingPrice.AutoSize = true;
            this.lblCeilingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCeilingPrice.ForeColor = System.Drawing.Color.Magenta;
            this.lblCeilingPrice.Location = new System.Drawing.Point(65, 0);
            this.lblCeilingPrice.Name = "lblCeilingPrice";
            this.lblCeilingPrice.Size = new System.Drawing.Size(57, 20);
            this.lblCeilingPrice.TabIndex = 29;
            this.lblCeilingPrice.Text = "label5";
            // 
            // lblBasicPrice
            // 
            this.lblBasicPrice.AutoSize = true;
            this.lblBasicPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicPrice.ForeColor = System.Drawing.Color.Yellow;
            this.lblBasicPrice.Location = new System.Drawing.Point(236, 0);
            this.lblBasicPrice.Name = "lblBasicPrice";
            this.lblBasicPrice.Size = new System.Drawing.Size(67, 20);
            this.lblBasicPrice.TabIndex = 30;
            this.lblBasicPrice.Text = "label14";
            // 
            // lblFloorPrice
            // 
            this.lblFloorPrice.AutoSize = true;
            this.lblFloorPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloorPrice.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lblFloorPrice.Location = new System.Drawing.Point(414, 0);
            this.lblFloorPrice.Name = "lblFloorPrice";
            this.lblFloorPrice.Size = new System.Drawing.Size(67, 20);
            this.lblFloorPrice.TabIndex = 31;
            this.lblFloorPrice.Text = "label15";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.lblCeilingPrice);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblBasicPrice);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.lblFloorPrice);
            this.panel1.Location = new System.Drawing.Point(15, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 22);
            this.panel1.TabIndex = 35;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(359, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 94;
            this.label18.Text = "Giá sàn";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(8, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 92;
            this.label16.Text = "Giá trần";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(157, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 93;
            this.label17.Text = "Giá tham chiếu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(293, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "(nghìn đồng)";
            // 
            // cboSellerTraderID
            // 
            this.cboSellerTraderID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSellerTraderID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSellerTraderID.BackColor = System.Drawing.Color.SkyBlue;
            this.cboSellerTraderID.FormattingEnabled = true;
            this.cboSellerTraderID.Location = new System.Drawing.Point(123, 155);
            this.cboSellerTraderID.Name = "cboSellerTraderID";
            this.cboSellerTraderID.Size = new System.Drawing.Size(170, 21);
            this.cboSellerTraderID.TabIndex = 4;
            this.cboSellerTraderID.SelectedIndexChanged += new System.EventHandler(this.cboSellerTraderID_SelectedIndexChanged);
            // 
            // lblSellerBalance
            // 
            this.lblSellerBalance.AutoSize = true;
            this.lblSellerBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellerBalance.ForeColor = System.Drawing.Color.Sienna;
            this.lblSellerBalance.Location = new System.Drawing.Point(205, 333);
            this.lblSellerBalance.Name = "lblSellerBalance";
            this.lblSellerBalance.Size = new System.Drawing.Size(85, 13);
            this.lblSellerBalance.TabIndex = 40;
            this.lblSellerBalance.Text = "Cash Balance";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(121, 333);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Số dư tiền";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(63, 360);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "(VND)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(121, 360);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Có thể GD";
            // 
            // lblSellerAvailBalance
            // 
            this.lblSellerAvailBalance.AutoSize = true;
            this.lblSellerAvailBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellerAvailBalance.ForeColor = System.Drawing.Color.Sienna;
            this.lblSellerAvailBalance.Location = new System.Drawing.Point(205, 360);
            this.lblSellerAvailBalance.Name = "lblSellerAvailBalance";
            this.lblSellerAvailBalance.Size = new System.Drawing.Size(85, 13);
            this.lblSellerAvailBalance.TabIndex = 43;
            this.lblSellerAvailBalance.Text = "Avail Balance";
            // 
            // lblSellerTraderID
            // 
            this.lblSellerTraderID.AutoSize = true;
            this.lblSellerTraderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellerTraderID.Location = new System.Drawing.Point(299, 159);
            this.lblSellerTraderID.Name = "lblSellerTraderID";
            this.lblSellerTraderID.Size = new System.Drawing.Size(70, 13);
            this.lblSellerTraderID.TabIndex = 45;
            this.lblSellerTraderID.Text = "lblTraderID";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(120, 268);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 13);
            this.label20.TabIndex = 71;
            this.label20.Text = "Có thể GD";
            // 
            // lblBuyerAvailBalance
            // 
            this.lblBuyerAvailBalance.AutoSize = true;
            this.lblBuyerAvailBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerAvailBalance.ForeColor = System.Drawing.Color.Sienna;
            this.lblBuyerAvailBalance.Location = new System.Drawing.Point(205, 268);
            this.lblBuyerAvailBalance.Name = "lblBuyerAvailBalance";
            this.lblBuyerAvailBalance.Size = new System.Drawing.Size(85, 13);
            this.lblBuyerAvailBalance.TabIndex = 70;
            this.lblBuyerAvailBalance.Text = "Avail Balance";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label22.Location = new System.Drawing.Point(63, 268);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 69;
            this.label22.Text = "(VND)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(121, 243);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 13);
            this.label23.TabIndex = 68;
            this.label23.Text = "Số dư tiền";
            // 
            // lblBuyerBalance
            // 
            this.lblBuyerBalance.AutoSize = true;
            this.lblBuyerBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerBalance.ForeColor = System.Drawing.Color.Sienna;
            this.lblBuyerBalance.Location = new System.Drawing.Point(205, 243);
            this.lblBuyerBalance.Name = "lblBuyerBalance";
            this.lblBuyerBalance.Size = new System.Drawing.Size(85, 13);
            this.lblBuyerBalance.TabIndex = 67;
            this.lblBuyerBalance.Text = "Cash Balance";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(15, 213);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(102, 13);
            this.label25.TabIndex = 66;
            this.label25.Text = "Khách hàng mua";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(121, 444);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 73;
            this.label21.Text = "Lô chẵn/lẻ";
            // 
            // cboBoardType
            // 
            this.cboBoardType.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cboBoardType.FormattingEnabled = true;
            this.cboBoardType.Location = new System.Drawing.Point(215, 441);
            this.cboBoardType.Name = "cboBoardType";
            this.cboBoardType.Size = new System.Drawing.Size(89, 21);
            this.cboBoardType.TabIndex = 13;
            // 
            // chkHalt
            // 
            this.chkHalt.AutoSize = true;
            this.chkHalt.Location = new System.Drawing.Point(361, 444);
            this.chkHalt.Name = "chkHalt";
            this.chkHalt.Size = new System.Drawing.Size(135, 17);
            this.chkHalt.TabIndex = 14;
            this.chkHalt.Text = "Bỏ qua Treo/Dừng GD";
            this.chkHalt.UseVisualStyleBackColor = true;
            this.chkHalt.Visible = false;
            this.chkHalt.CheckedChanged += new System.EventHandler(this.chkHalt_CheckedChanged);
            // 
            // lblSuspension
            // 
            this.lblSuspension.AutoSize = true;
            this.lblSuspension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuspension.ForeColor = System.Drawing.Color.Red;
            this.lblSuspension.Location = new System.Drawing.Point(272, 42);
            this.lblSuspension.Name = "lblSuspension";
            this.lblSuspension.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSuspension.Size = new System.Drawing.Size(85, 13);
            this.lblSuspension.TabIndex = 84;
            this.lblSuspension.Text = "lblSuspension";
            this.lblSuspension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSplit
            // 
            this.lblSplit.AutoSize = true;
            this.lblSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplit.ForeColor = System.Drawing.Color.Red;
            this.lblSplit.Location = new System.Drawing.Point(395, 42);
            this.lblSplit.Name = "lblSplit";
            this.lblSplit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSplit.Size = new System.Drawing.Size(45, 13);
            this.lblSplit.TabIndex = 83;
            this.lblSplit.Text = "lblSplit";
            this.lblSplit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHalt
            // 
            this.lblHalt.AutoSize = true;
            this.lblHalt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalt.ForeColor = System.Drawing.Color.Red;
            this.lblHalt.Location = new System.Drawing.Point(193, 42);
            this.lblHalt.Name = "lblHalt";
            this.lblHalt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblHalt.Size = new System.Drawing.Size(43, 13);
            this.lblHalt.TabIndex = 82;
            this.lblHalt.Text = "lblHalt";
            this.lblHalt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDelist
            // 
            this.lblDelist.AutoSize = true;
            this.lblDelist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelist.ForeColor = System.Drawing.Color.Red;
            this.lblDelist.Location = new System.Drawing.Point(110, 42);
            this.lblDelist.Name = "lblDelist";
            this.lblDelist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDelist.Size = new System.Drawing.Size(52, 13);
            this.lblDelist.TabIndex = 81;
            this.lblDelist.Text = "lblDelist";
            this.lblDelist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttipStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(562, 22);
            this.statusStrip1.TabIndex = 86;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttipStatus
            // 
            this.ttipStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ttipStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ttipStatus.Name = "ttipStatus";
            this.ttipStatus.Size = new System.Drawing.Size(130, 17);
            this.ttipStatus.Text = "toolStripStatusLabel1";
            // 
            // cboSellerClientID
            // 
            this.cboSellerClientID.ForeColor = System.Drawing.Color.SaddleBrown;
            this.cboSellerClientID.FormattingEnabled = true;
            this.cboSellerClientID.Location = new System.Drawing.Point(123, 298);
            this.cboSellerClientID.Name = "cboSellerClientID";
            this.cboSellerClientID.Size = new System.Drawing.Size(356, 21);
            this.cboSellerClientID.TabIndex = 9;
            this.cboSellerClientID.SelectedIndexChanged += new System.EventHandler(this.cboSellerClientID_SelectedIndexChanged);
            this.cboSellerClientID.Leave += new System.EventHandler(this.cboSellerClientID_Leave);
            // 
            // cboBuyerClientID
            // 
            this.cboBuyerClientID.ForeColor = System.Drawing.Color.DarkGreen;
            this.cboBuyerClientID.FormattingEnabled = true;
            this.cboBuyerClientID.Location = new System.Drawing.Point(123, 208);
            this.cboBuyerClientID.Name = "cboBuyerClientID";
            this.cboBuyerClientID.Size = new System.Drawing.Size(356, 21);
            this.cboBuyerClientID.TabIndex = 6;
            this.cboBuyerClientID.SelectedIndexChanged += new System.EventHandler(this.cboBuyerClientID_SelectedIndexChanged);
            this.cboBuyerClientID.Leave += new System.EventHandler(this.cboBuyerClientID_Leave);
            // 
            // cboSecurities
            // 
            this.cboSecurities.FormattingEnabled = true;
            this.cboSecurities.Location = new System.Drawing.Point(123, 67);
            this.cboSecurities.Name = "cboSecurities";
            this.cboSecurities.Size = new System.Drawing.Size(412, 21);
            this.cboSecurities.TabIndex = 1;
            this.cboSecurities.SelectedIndexChanged += new System.EventHandler(this.cboSecurities_SelectedIndexChanged);
            this.cboSecurities.Leave += new System.EventHandler(this.cboSecurities_Leave);
            // 
            // chkLoadFromCore
            // 
            this.chkLoadFromCore.AutoSize = true;
            this.chkLoadFromCore.Location = new System.Drawing.Point(124, 185);
            this.chkLoadFromCore.Name = "chkLoadFromCore";
            this.chkLoadFromCore.Size = new System.Drawing.Size(225, 17);
            this.chkLoadFromCore.TabIndex = 5;
            this.chkLoadFromCore.Text = "Lấy danh sách khách hàng từ CORE SBS";
            this.chkLoadFromCore.UseVisualStyleBackColor = true;
            this.chkLoadFromCore.CheckedChanged += new System.EventHandler(this.chkLoadFromCore_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Khối lượng";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(123, 125);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(171, 20);
            this.txtVolume.TabIndex = 3;
            this.txtVolume.TextChanged += new System.EventHandler(this.txtVolume_TextChanged);
            this.txtVolume.Leave += new System.EventHandler(this.txtVolume_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Số dư CK";
            // 
            // lblSellerSecBalance
            // 
            this.lblSellerSecBalance.AutoSize = true;
            this.lblSellerSecBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellerSecBalance.ForeColor = System.Drawing.Color.Navy;
            this.lblSellerSecBalance.Location = new System.Drawing.Point(237, 385);
            this.lblSellerSecBalance.Name = "lblSellerSecBalance";
            this.lblSellerSecBalance.Size = new System.Drawing.Size(120, 13);
            this.lblSellerSecBalance.TabIndex = 87;
            this.lblSellerSecBalance.Text = "lblSellerSecBalance";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Truy vấn số dư";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 328);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Truy vấn số dư";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(122, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 90;
            this.label6.Text = "CK có thể GD";
            // 
            // lblAvailSecBalance
            // 
            this.lblAvailSecBalance.AutoSize = true;
            this.lblAvailSecBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailSecBalance.ForeColor = System.Drawing.Color.Navy;
            this.lblAvailSecBalance.Location = new System.Drawing.Point(237, 410);
            this.lblAvailSecBalance.Name = "lblAvailSecBalance";
            this.lblAvailSecBalance.Size = new System.Drawing.Size(116, 13);
            this.lblAvailSecBalance.TabIndex = 89;
            this.lblAvailSecBalance.Text = "lblAvailSecBalance";
            // 
            // btnLoadClientsFromCore
            // 
            this.btnLoadClientsFromCore.Location = new System.Drawing.Point(330, 252);
            this.btnLoadClientsFromCore.Name = "btnLoadClientsFromCore";
            this.btnLoadClientsFromCore.Size = new System.Drawing.Size(149, 23);
            this.btnLoadClientsFromCore.TabIndex = 91;
            this.btnLoadClientsFromCore.Text = "Lấy danh sách KH";
            this.btnLoadClientsFromCore.UseVisualStyleBackColor = true;
            this.btnLoadClientsFromCore.Click += new System.EventHandler(this.btnLoadClientsFromCore_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(15, 472);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(94, 13);
            this.lbTotal.TabIndex = 92;
            this.lbTotal.Text = "Tổng giá trị GD";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(299, 472);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 93;
            this.label7.Text = "(VND)";
            // 
            // lbTotalValue
            // 
            this.lbTotalValue.AutoSize = true;
            this.lbTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalValue.ForeColor = System.Drawing.Color.Sienna;
            this.lbTotalValue.Location = new System.Drawing.Point(208, 472);
            this.lbTotalValue.Name = "lbTotalValue";
            this.lbTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTotalValue.Size = new System.Drawing.Size(78, 13);
            this.lbTotalValue.TabIndex = 94;
            this.lbTotalValue.Text = "lbTotalValue";
            // 
            // frmMakeNewPT1FirmDeal
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(562, 558);
            this.Controls.Add(this.lbTotalValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.btnLoadClientsFromCore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAvailSecBalance);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSellerSecBalance);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.chkLoadFromCore);
            this.Controls.Add(this.cboSecurities);
            this.Controls.Add(this.cboBuyerClientID);
            this.Controls.Add(this.cboSellerClientID);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkHalt);
            this.Controls.Add(this.lblSuspension);
            this.Controls.Add(this.lblSplit);
            this.Controls.Add(this.lblHalt);
            this.Controls.Add(this.lblDelist);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cboBoardType);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblBuyerAvailBalance);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lblBuyerBalance);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSellerTraderID);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblSellerAvailBalance);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblSellerBalance);
            this.Controls.Add(this.cboSellerTraderID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMakeNewPT1FirmDeal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập giao dịch thỏa thuận cùng công ty";
            this.Load += new System.EventHandler(this.frmMakeNewPTDeal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMakeNewPT1FirmDeal_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCeilingPrice;
        private System.Windows.Forms.Label lblBasicPrice;
        private System.Windows.Forms.Label lblFloorPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSellerTraderID;
        private System.Windows.Forms.Label lblSellerBalance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSellerAvailBalance;
        private System.Windows.Forms.Label lblSellerTraderID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblBuyerAvailBalance;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblBuyerBalance;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboBoardType;
        private System.Windows.Forms.CheckBox chkHalt;
        private System.Windows.Forms.Label lblSuspension;
        private System.Windows.Forms.Label lblSplit;
        private System.Windows.Forms.Label lblHalt;
        private System.Windows.Forms.Label lblDelist;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttipStatus;
        private System.Windows.Forms.ComboBox cboSellerClientID;
        private System.Windows.Forms.ComboBox cboBuyerClientID;
        private System.Windows.Forms.ComboBox cboSecurities;
        private System.Windows.Forms.CheckBox chkLoadFromCore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSellerSecBalance;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAvailSecBalance;
        private System.Windows.Forms.Button btnLoadClientsFromCore;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbTotalValue;
    }
}
