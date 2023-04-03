namespace HOGW_PT_Dealer
{
    partial class frmMakeNewPTDeal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMakeNewPTDeal));
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
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
            this.cboSellerTraderID = new System.Windows.Forms.ComboBox();
            this.cboBuyerTraderID = new System.Windows.Forms.ComboBox();
            this.lblCashBalance = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAvailBalance = new System.Windows.Forms.Label();
            this.lblSellerTraderID = new System.Windows.Forms.Label();
            this.lblBuyerTraderID = new System.Windows.Forms.Label();
            this.cboBoardType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.chkHalt = new System.Windows.Forms.CheckBox();
            this.lblDelist = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttipStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cboSecurities = new System.Windows.Forms.ComboBox();
            this.cboSellerClientID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoadSellerClients = new System.Windows.Forms.Button();
            this.chkLoadFromCore = new System.Windows.Forms.CheckBox();
            this.btnGetBalance = new System.Windows.Forms.Button();
            this.lblAvailSecBalance = new System.Windows.Forms.Label();
            this.lblSellerSecBalance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbTotalValue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.txtBuyerTraderID = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboBuyerFirms = new CustomControl.EnhancedComboBox();
            this.cboSellerFirms = new CustomControl.EnhancedComboBox();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.LightCyan;
            this.txtPrice.Location = new System.Drawing.Point(137, 84);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(157, 20);
            this.txtPrice.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Công ty bên bán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã trader bên bán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Công ty bên mua";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Khách hàng bên bán";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mã trader bên mua";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Giá";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Khối lượng";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(137, 110);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(182, 20);
            this.txtVolume.TabIndex = 3;
            this.txtVolume.TextChanged += new System.EventHandler(this.txtVolume_TextChanged);
            this.txtVolume.Leave += new System.EventHandler(this.txtVolume_Leave);
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(136, 472);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(121, 31);
            this.btnEnter.TabIndex = 22;
            this.btnEnter.Text = "&Nhập";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnterClick);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(401, 472);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 31);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Đón&g";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã chứng khoán";
            // 
            // lblCeilingPrice
            // 
            this.lblCeilingPrice.AutoSize = true;
            this.lblCeilingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCeilingPrice.ForeColor = System.Drawing.Color.Magenta;
            this.lblCeilingPrice.Location = new System.Drawing.Point(61, 0);
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
            this.lblFloorPrice.Location = new System.Drawing.Point(412, 0);
            this.lblFloorPrice.Name = "lblFloorPrice";
            this.lblFloorPrice.Size = new System.Drawing.Size(67, 20);
            this.lblFloorPrice.TabIndex = 31;
            this.lblFloorPrice.Text = "label15";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.lblCeilingPrice);
            this.panel1.Controls.Add(this.lblBasicPrice);
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
            this.label18.Location = new System.Drawing.Point(355, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 97;
            this.label18.Text = "Giá sàn";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(4, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 95;
            this.label16.Text = "Giá trần";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(153, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 96;
            this.label17.Text = "Giá tham chiếu";
            // 
            // cboSellerTraderID
            // 
            this.cboSellerTraderID.BackColor = System.Drawing.Color.Khaki;
            this.cboSellerTraderID.FormattingEnabled = true;
            this.cboSellerTraderID.Location = new System.Drawing.Point(137, 167);
            this.cboSellerTraderID.Name = "cboSellerTraderID";
            this.cboSellerTraderID.Size = new System.Drawing.Size(181, 21);
            this.cboSellerTraderID.TabIndex = 5;
            this.cboSellerTraderID.SelectedIndexChanged += new System.EventHandler(this.cboSellerTraderID_SelectedIndexChanged);
            // 
            // cboBuyerTraderID
            // 
            this.cboBuyerTraderID.BackColor = System.Drawing.Color.YellowGreen;
            this.cboBuyerTraderID.Enabled = false;
            this.cboBuyerTraderID.FormattingEnabled = true;
            this.cboBuyerTraderID.Location = new System.Drawing.Point(136, 376);
            this.cboBuyerTraderID.Name = "cboBuyerTraderID";
            this.cboBuyerTraderID.Size = new System.Drawing.Size(181, 21);
            this.cboBuyerTraderID.TabIndex = 11;
            this.cboBuyerTraderID.SelectedIndexChanged += new System.EventHandler(this.cboBuyerTraderID_SelectedIndexChanged);
            // 
            // lblCashBalance
            // 
            this.lblCashBalance.AutoSize = true;
            this.lblCashBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashBalance.ForeColor = System.Drawing.Color.Sienna;
            this.lblCashBalance.Location = new System.Drawing.Point(222, 251);
            this.lblCashBalance.Name = "lblCashBalance";
            this.lblCashBalance.Size = new System.Drawing.Size(85, 13);
            this.lblCashBalance.TabIndex = 40;
            this.lblCashBalance.Text = "Cash Balance";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(74, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "(in VND)";
            // 
            // lblAvailBalance
            // 
            this.lblAvailBalance.AutoSize = true;
            this.lblAvailBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailBalance.ForeColor = System.Drawing.Color.Sienna;
            this.lblAvailBalance.Location = new System.Drawing.Point(222, 277);
            this.lblAvailBalance.Name = "lblAvailBalance";
            this.lblAvailBalance.Size = new System.Drawing.Size(85, 13);
            this.lblAvailBalance.TabIndex = 43;
            this.lblAvailBalance.Text = "Avail Balance";
            // 
            // lblSellerTraderID
            // 
            this.lblSellerTraderID.AutoSize = true;
            this.lblSellerTraderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellerTraderID.Location = new System.Drawing.Point(324, 171);
            this.lblSellerTraderID.Name = "lblSellerTraderID";
            this.lblSellerTraderID.Size = new System.Drawing.Size(102, 13);
            this.lblSellerTraderID.TabIndex = 45;
            this.lblSellerTraderID.Text = "lblSellerTraderID";
            // 
            // lblBuyerTraderID
            // 
            this.lblBuyerTraderID.AutoSize = true;
            this.lblBuyerTraderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerTraderID.Location = new System.Drawing.Point(398, 379);
            this.lblBuyerTraderID.Name = "lblBuyerTraderID";
            this.lblBuyerTraderID.Size = new System.Drawing.Size(102, 13);
            this.lblBuyerTraderID.TabIndex = 46;
            this.lblBuyerTraderID.Text = "lblBuyerTraderID";
            this.lblBuyerTraderID.Visible = false;
            // 
            // cboBoardType
            // 
            this.cboBoardType.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cboBoardType.FormattingEnabled = true;
            this.cboBoardType.Location = new System.Drawing.Point(226, 410);
            this.cboBoardType.Name = "cboBoardType";
            this.cboBoardType.Size = new System.Drawing.Size(89, 21);
            this.cboBoardType.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(133, 413);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "Lô chẵn/lẻ";
            // 
            // chkHalt
            // 
            this.chkHalt.AutoSize = true;
            this.chkHalt.Location = new System.Drawing.Point(377, 412);
            this.chkHalt.Name = "chkHalt";
            this.chkHalt.Size = new System.Drawing.Size(135, 17);
            this.chkHalt.TabIndex = 14;
            this.chkHalt.Text = "Bỏ qua Treo/Dừng GD";
            this.chkHalt.UseVisualStyleBackColor = true;
            this.chkHalt.Visible = false;
            this.chkHalt.CheckedChanged += new System.EventHandler(this.chkHalt_CheckedChanged);
            // 
            // lblDelist
            // 
            this.lblDelist.AutoSize = true;
            this.lblDelist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelist.ForeColor = System.Drawing.Color.Red;
            this.lblDelist.Location = new System.Drawing.Point(355, 33);
            this.lblDelist.Name = "lblDelist";
            this.lblDelist.Size = new System.Drawing.Size(52, 13);
            this.lblDelist.TabIndex = 50;
            this.lblDelist.Text = "lblDelist";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(75, 33);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 51;
            this.label21.Text = "lblHalt";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(149, 33);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 13);
            this.label22.TabIndex = 53;
            this.label22.Text = "lblSuspension";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(274, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 52;
            this.label23.Text = "lblSplit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttipStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 510);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(559, 22);
            this.statusStrip1.TabIndex = 54;
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
            // cboSecurities
            // 
            this.cboSecurities.FormattingEnabled = true;
            this.cboSecurities.Location = new System.Drawing.Point(138, 57);
            this.cboSecurities.Name = "cboSecurities";
            this.cboSecurities.Size = new System.Drawing.Size(411, 21);
            this.cboSecurities.TabIndex = 1;
            this.cboSecurities.SelectedIndexChanged += new System.EventHandler(this.cboSecurities_SelectedIndexChanged);
            this.cboSecurities.Leave += new System.EventHandler(this.cboSecurities_Leave);
            // 
            // cboSellerClientID
            // 
            this.cboSellerClientID.FormattingEnabled = true;
            this.cboSellerClientID.Location = new System.Drawing.Point(137, 221);
            this.cboSellerClientID.Name = "cboSellerClientID";
            this.cboSellerClientID.Size = new System.Drawing.Size(316, 21);
            this.cboSellerClientID.TabIndex = 8;
            this.cboSellerClientID.SelectedIndexChanged += new System.EventHandler(this.cboSellerClientID_SelectedIndexChanged);
            this.cboSellerClientID.Leave += new System.EventHandler(this.cboSellerClientID_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(296, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "(nghìn đồng)";
            // 
            // btnLoadSellerClients
            // 
            this.btnLoadSellerClients.Location = new System.Drawing.Point(353, 193);
            this.btnLoadSellerClients.Name = "btnLoadSellerClients";
            this.btnLoadSellerClients.Size = new System.Drawing.Size(100, 23);
            this.btnLoadSellerClients.TabIndex = 7;
            this.btnLoadSellerClients.Text = "Lấy DSKH";
            this.btnLoadSellerClients.UseVisualStyleBackColor = true;
            this.btnLoadSellerClients.Click += new System.EventHandler(this.btnLoadSellerClients_Click);
            // 
            // chkLoadFromCore
            // 
            this.chkLoadFromCore.AutoSize = true;
            this.chkLoadFromCore.Location = new System.Drawing.Point(162, 197);
            this.chkLoadFromCore.Name = "chkLoadFromCore";
            this.chkLoadFromCore.Size = new System.Drawing.Size(148, 17);
            this.chkLoadFromCore.TabIndex = 6;
            this.chkLoadFromCore.Text = "Lấy DS KH từ CORE SBS";
            this.chkLoadFromCore.UseVisualStyleBackColor = true;
            this.chkLoadFromCore.CheckedChanged += new System.EventHandler(this.chkLoadFromCore_CheckedChanged);
            // 
            // btnGetBalance
            // 
            this.btnGetBalance.Location = new System.Drawing.Point(36, 246);
            this.btnGetBalance.Name = "btnGetBalance";
            this.btnGetBalance.Size = new System.Drawing.Size(93, 23);
            this.btnGetBalance.TabIndex = 9;
            this.btnGetBalance.Text = "Truy vấn số dư";
            this.btnGetBalance.UseVisualStyleBackColor = true;
            this.btnGetBalance.Click += new System.EventHandler(this.btnGetBalance_Click);
            // 
            // lblAvailSecBalance
            // 
            this.lblAvailSecBalance.AutoSize = true;
            this.lblAvailSecBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailSecBalance.ForeColor = System.Drawing.Color.Navy;
            this.lblAvailSecBalance.Location = new System.Drawing.Point(251, 326);
            this.lblAvailSecBalance.Name = "lblAvailSecBalance";
            this.lblAvailSecBalance.Size = new System.Drawing.Size(103, 13);
            this.lblAvailSecBalance.TabIndex = 93;
            this.lblAvailSecBalance.Text = "Security Balance";
            // 
            // lblSellerSecBalance
            // 
            this.lblSellerSecBalance.AutoSize = true;
            this.lblSellerSecBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellerSecBalance.ForeColor = System.Drawing.Color.Navy;
            this.lblSellerSecBalance.Location = new System.Drawing.Point(251, 303);
            this.lblSellerSecBalance.Name = "lblSellerSecBalance";
            this.lblSellerSecBalance.Size = new System.Drawing.Size(103, 13);
            this.lblSellerSecBalance.TabIndex = 91;
            this.lblSellerSecBalance.Text = "Security Balance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(136, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "CK có thể GD";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(135, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 96;
            this.label10.Text = "Số dư CK";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(135, 278);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 95;
            this.label15.Text = "Có thể GD";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(135, 251);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 94;
            this.label14.Text = "Số dư tiền";
            // 
            // lbTotalValue
            // 
            this.lbTotalValue.AutoSize = true;
            this.lbTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalValue.ForeColor = System.Drawing.Color.Sienna;
            this.lbTotalValue.Location = new System.Drawing.Point(225, 434);
            this.lbTotalValue.Name = "lbTotalValue";
            this.lbTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTotalValue.Size = new System.Drawing.Size(78, 13);
            this.lbTotalValue.TabIndex = 103;
            this.lbTotalValue.Text = "lbTotalValue";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(304, 434);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 102;
            this.label11.Text = "(VND)";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(19, 435);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(94, 13);
            this.lbTotal.TabIndex = 101;
            this.lbTotal.Text = "Tổng giá trị GD";
            // 
            // txtBuyerTraderID
            // 
            this.txtBuyerTraderID.Location = new System.Drawing.Point(137, 376);
            this.txtBuyerTraderID.Name = "txtBuyerTraderID";
            this.txtBuyerTraderID.Size = new System.Drawing.Size(182, 20);
            this.txtBuyerTraderID.TabIndex = 11;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(325, 379);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 104;
            this.label20.Text = "(TraderID)";
            // 
            // cboBuyerFirms
            // 
            this.cboBuyerFirms.AutoComplete = true;
            this.cboBuyerFirms.BackColor = System.Drawing.Color.YellowGreen;
            this.cboBuyerFirms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cboBuyerFirms.DataSource = null;
            this.cboBuyerFirms.DisplayMember = "";
            this.cboBuyerFirms.ForeColor = System.Drawing.Color.SteelBlue;
            this.cboBuyerFirms.HasNone = false;
            this.cboBuyerFirms.Location = new System.Drawing.Point(137, 348);
            this.cboBuyerFirms.Name = "cboBuyerFirms";
            this.cboBuyerFirms.SelectedIndex = -1;
            this.cboBuyerFirms.Size = new System.Drawing.Size(412, 22);
            this.cboBuyerFirms.TabIndex = 10;
            this.cboBuyerFirms.TextBoxWidth = 100;
            this.cboBuyerFirms.ValueMember = "";
            this.cboBuyerFirms.SelectedIndexChanged += new System.EventHandler(this.cboBuyerFirms_SelectedIndexChanged);
            // 
            // cboSellerFirms
            // 
            this.cboSellerFirms.AutoComplete = true;
            this.cboSellerFirms.BackColor = System.Drawing.Color.Khaki;
            this.cboSellerFirms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cboSellerFirms.DataSource = null;
            this.cboSellerFirms.DisplayMember = "";
            this.cboSellerFirms.ForeColor = System.Drawing.Color.SteelBlue;
            this.cboSellerFirms.HasNone = false;
            this.cboSellerFirms.Location = new System.Drawing.Point(137, 140);
            this.cboSellerFirms.Name = "cboSellerFirms";
            this.cboSellerFirms.SelectedIndex = -1;
            this.cboSellerFirms.Size = new System.Drawing.Size(412, 22);
            this.cboSellerFirms.TabIndex = 4;
            this.cboSellerFirms.TextBoxWidth = 100;
            this.cboSellerFirms.ValueMember = "";
            this.cboSellerFirms.SelectedIndexChanged += new System.EventHandler(this.cboSellerFirms_SelectedIndexChanged);
            // 
            // frmMakeNewPTDeal
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(559, 532);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtBuyerTraderID);
            this.Controls.Add(this.lbTotalValue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblAvailSecBalance);
            this.Controls.Add(this.lblSellerSecBalance);
            this.Controls.Add(this.btnGetBalance);
            this.Controls.Add(this.chkLoadFromCore);
            this.Controls.Add(this.btnLoadSellerClients);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboSellerClientID);
            this.Controls.Add(this.cboSecurities);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblDelist);
            this.Controls.Add(this.chkHalt);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboBoardType);
            this.Controls.Add(this.lblBuyerTraderID);
            this.Controls.Add(this.lblSellerTraderID);
            this.Controls.Add(this.lblAvailBalance);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCashBalance);
            this.Controls.Add(this.cboBuyerTraderID);
            this.Controls.Add(this.cboSellerTraderID);
            this.Controls.Add(this.cboBuyerFirms);
            this.Controls.Add(this.cboSellerFirms);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMakeNewPTDeal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao dịch thỏa thuận với công ty CK khác";
            this.Load += new System.EventHandler(this.frmMakeNewPTDeal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMakeNewPTDeal_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCeilingPrice;
        private System.Windows.Forms.Label lblBasicPrice;
        private System.Windows.Forms.Label lblFloorPrice;
        private System.Windows.Forms.Panel panel1;
        private CustomControl.EnhancedComboBox cboSellerFirms;
        private CustomControl.EnhancedComboBox cboBuyerFirms;
        private System.Windows.Forms.ComboBox cboSellerTraderID;
        private System.Windows.Forms.ComboBox cboBuyerTraderID;
        private System.Windows.Forms.Label lblCashBalance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAvailBalance;
        private System.Windows.Forms.Label lblSellerTraderID;
        private System.Windows.Forms.Label lblBuyerTraderID;
        private System.Windows.Forms.ComboBox cboBoardType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkHalt;
        private System.Windows.Forms.Label lblDelist;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttipStatus;
        private System.Windows.Forms.ComboBox cboSecurities;
        private System.Windows.Forms.ComboBox cboSellerClientID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadSellerClients;
        private System.Windows.Forms.CheckBox chkLoadFromCore;
        private System.Windows.Forms.Button btnGetBalance;
        private System.Windows.Forms.Label lblAvailSecBalance;
        private System.Windows.Forms.Label lblSellerSecBalance;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbTotalValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.TextBox txtBuyerTraderID;
        private System.Windows.Forms.Label label20;
    }
}
