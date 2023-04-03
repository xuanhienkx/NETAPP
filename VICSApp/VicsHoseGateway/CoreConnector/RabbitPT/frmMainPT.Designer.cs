namespace HOGW_PT_Dealer
{
    partial class frmMainPT
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainPT));
           this.btnClose = new System.Windows.Forms.Button();
           this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
           this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.imageList1 = new System.Windows.Forms.ImageList(this.components);
           this.menuStrip1 = new System.Windows.Forms.MenuStrip();
           this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.pageMain = new System.Windows.Forms.TabPage();
           this.grbAdmin = new System.Windows.Forms.GroupBox();
           this.rd1 = new System.Windows.Forms.RadioButton();
           this.rd2 = new System.Windows.Forms.RadioButton();
           this.btnResetDealTables = new System.Windows.Forms.Button();
           this.tabControlFunctions = new System.Windows.Forms.TabControl();
           this.tabSellerDeals = new System.Windows.Forms.TabPage();
           this.groupBox3 = new System.Windows.Forms.GroupBox();
           this.label13 = new System.Windows.Forms.Label();
           this.label14 = new System.Windows.Forms.Label();
           this.btnView2FirmSellerDeals = new System.Windows.Forms.Button();
           this.label8 = new System.Windows.Forms.Label();
           this.label9 = new System.Windows.Forms.Label();
           this.pictureBox2 = new System.Windows.Forms.PictureBox();
           this.btnCancel2FirmDeal = new System.Windows.Forms.Button();
           this.btnApprove2FirmDeal = new System.Windows.Forms.Button();
           this.btnMake2FirmDeal = new System.Windows.Forms.Button();
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this.btnView1FirmDeals = new System.Windows.Forms.Button();
           this.label7 = new System.Windows.Forms.Label();
           this.label5 = new System.Windows.Forms.Label();
           this.label10 = new System.Windows.Forms.Label();
           this.label6 = new System.Windows.Forms.Label();
           this.pictureBox1 = new System.Windows.Forms.PictureBox();
           this.btnCancel1FirmDeal = new System.Windows.Forms.Button();
           this.btnApprove1FirmDeal = new System.Windows.Forms.Button();
           this.btnMake1FirmDeal = new System.Windows.Forms.Button();
           this.tabPage2 = new System.Windows.Forms.TabPage();
           this.label11 = new System.Windows.Forms.Label();
           this.btnBuyerBrowseDeals = new System.Windows.Forms.Button();
           this.label3 = new System.Windows.Forms.Label();
           this.label4 = new System.Windows.Forms.Label();
           this.btnBuyerApproveSellerCancel = new System.Windows.Forms.Button();
           this.btnBuyerApproveSeller = new System.Windows.Forms.Button();
           this.tabPage1 = new System.Windows.Forms.TabPage();
           this.label16 = new System.Windows.Forms.Label();
           this.btnAdvAnnounce = new System.Windows.Forms.Button();
           this.label15 = new System.Windows.Forms.Label();
           this.btnViewAdv = new System.Windows.Forms.Button();
           this.label12 = new System.Windows.Forms.Label();
           this.btnCancelAdv = new System.Windows.Forms.Button();
           this.label2 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this.btnMakeNewAdv = new System.Windows.Forms.Button();
           this.btnApproveAdv = new System.Windows.Forms.Button();
           this.statusStrip1 = new System.Windows.Forms.StatusStrip();
           this.ttipSystem = new System.Windows.Forms.ToolStripStatusLabel();
           this.ttipStatus = new System.Windows.Forms.ToolStripStatusLabel();
           this.ttipTimer = new System.Windows.Forms.ToolStripStatusLabel();
           this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
           this.ttipMarketStatus = new System.Windows.Forms.ToolStripStatusLabel();
           this.lvLog = new System.Windows.Forms.ListView();
           this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
           this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
           this.colDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
           this.tabControlApplication = new System.Windows.Forms.TabControl();
           this.timerSystem = new System.Windows.Forms.Timer(this.components);
           this.timerMarketStatus = new System.Windows.Forms.Timer(this.components);
           this.timerBuyerTasks = new System.Windows.Forms.Timer(this.components);
           this.contextMenuStrip1.SuspendLayout();
           this.menuStrip1.SuspendLayout();
           this.pageMain.SuspendLayout();
           this.grbAdmin.SuspendLayout();
           this.tabControlFunctions.SuspendLayout();
           this.tabSellerDeals.SuspendLayout();
           this.groupBox3.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
           this.groupBox1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
           this.tabPage2.SuspendLayout();
           this.tabPage1.SuspendLayout();
           this.statusStrip1.SuspendLayout();
           this.tabControlApplication.SuspendLayout();
           this.SuspendLayout();
           // 
           // btnClose
           // 
           this.btnClose.Location = new System.Drawing.Point(635, 532);
           this.btnClose.Name = "btnClose";
           this.btnClose.Size = new System.Drawing.Size(113, 25);
           this.btnClose.TabIndex = 3;
           this.btnClose.Text = "Clo&se";
           this.btnClose.UseVisualStyleBackColor = true;
           this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
           // 
           // contextMenuStrip1
           // 
           this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem});
           this.contextMenuStrip1.Name = "contextMenuStrip1";
           this.contextMenuStrip1.Size = new System.Drawing.Size(128, 26);
           // 
           // clearLogToolStripMenuItem
           // 
           this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
           this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
           this.clearLogToolStripMenuItem.Text = "Clear log";
           this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
           // 
           // imageList1
           // 
           this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
           this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
           this.imageList1.Images.SetKeyName(0, "lock.png");
           this.imageList1.Images.SetKeyName(1, "accept.png");
           this.imageList1.Images.SetKeyName(2, "asterisk_orange.png");
           this.imageList1.Images.SetKeyName(3, "cancel.png");
           this.imageList1.Images.SetKeyName(4, "help.png");
           this.imageList1.Images.SetKeyName(5, "panel-control.ico");
           this.imageList1.Images.SetKeyName(6, "Office.ico");
           this.imageList1.Images.SetKeyName(7, "removable usb.ico");
           this.imageList1.Images.SetKeyName(8, "cd rom.ico");
           this.imageList1.Images.SetKeyName(9, "directory accept.ico");
           this.imageList1.Images.SetKeyName(10, "directory visiting.ico");
           this.imageList1.Images.SetKeyName(11, "executable.ico");
           this.imageList1.Images.SetKeyName(12, "floppy.ico");
           this.imageList1.Images.SetKeyName(13, "ipod.ico");
           this.imageList1.Images.SetKeyName(14, "loading icon.ico");
           this.imageList1.Images.SetKeyName(15, "regular.ico");
           this.imageList1.Images.SetKeyName(16, "web.ico");
           this.imageList1.Images.SetKeyName(17, "files_text.ico");
           this.imageList1.Images.SetKeyName(18, "forward.ico");
           this.imageList1.Images.SetKeyName(19, "up.ico");
           this.imageList1.Images.SetKeyName(20, "zip_file.ico");
           this.imageList1.Images.SetKeyName(21, "recycle_bin_empty.ico");
           this.imageList1.Images.SetKeyName(22, "iCal.ico");
           this.imageList1.Images.SetKeyName(23, "iPod_Blue__.ico");
           this.imageList1.Images.SetKeyName(24, "iPod_Green.ico");
           this.imageList1.Images.SetKeyName(25, "quicktime.ico");
           this.imageList1.Images.SetKeyName(26, "Addressbook.ico");
           // 
           // menuStrip1
           // 
           this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem});
           this.menuStrip1.Location = new System.Drawing.Point(0, 0);
           this.menuStrip1.Name = "menuStrip1";
           this.menuStrip1.Size = new System.Drawing.Size(974, 24);
           this.menuStrip1.TabIndex = 8;
           this.menuStrip1.Text = "menuStrip1";
           // 
           // systemToolStripMenuItem
           // 
           this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.exitToolStripMenuItem});
           this.systemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemToolStripMenuItem.Image")));
           this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
           this.systemToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
           this.systemToolStripMenuItem.Text = "&Hệ thống";
           // 
           // loginToolStripMenuItem
           // 
           this.loginToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loginToolStripMenuItem.Image")));
           this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
           this.loginToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
           this.loginToolStripMenuItem.Text = "Đăng &nhập";
           this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
           // 
           // exitToolStripMenuItem
           // 
           this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
           this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
           this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
           this.exitToolStripMenuItem.Text = "&Thoát";
           this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
           // 
           // pageMain
           // 
           this.pageMain.Controls.Add(this.grbAdmin);
           this.pageMain.Controls.Add(this.tabControlFunctions);
           this.pageMain.Controls.Add(this.statusStrip1);
           this.pageMain.Controls.Add(this.lvLog);
           this.pageMain.Location = new System.Drawing.Point(4, 22);
           this.pageMain.Name = "pageMain";
           this.pageMain.Padding = new System.Windows.Forms.Padding(3);
           this.pageMain.Size = new System.Drawing.Size(966, 543);
           this.pageMain.TabIndex = 0;
           this.pageMain.Text = "Application";
           this.pageMain.UseVisualStyleBackColor = true;
           // 
           // grbAdmin
           // 
           this.grbAdmin.Controls.Add(this.rd1);
           this.grbAdmin.Controls.Add(this.rd2);
           this.grbAdmin.Controls.Add(this.btnResetDealTables);
           this.grbAdmin.Location = new System.Drawing.Point(13, 125);
           this.grbAdmin.Name = "grbAdmin";
           this.grbAdmin.Size = new System.Drawing.Size(612, 77);
           this.grbAdmin.TabIndex = 11;
           this.grbAdmin.TabStop = false;
           this.grbAdmin.Text = "Thực hiện xử lý dữ liệu theo ngày (xóa, backup ADV, 1FIRM, 2FIRM SELLER và BUYER " +
               "deals và reset deal_id về 0)";
           // 
           // rd1
           // 
           this.rd1.AutoSize = true;
           this.rd1.Location = new System.Drawing.Point(300, 24);
           this.rd1.Name = "rd1";
           this.rd1.Size = new System.Drawing.Size(189, 17);
           this.rd1.TabIndex = 15;
           this.rd1.TabStop = true;
           this.rd1.Text = "Reset identity để deal_id chạy từ 0";
           this.rd1.UseVisualStyleBackColor = true;
           // 
           // rd2
           // 
           this.rd2.AutoSize = true;
           this.rd2.Location = new System.Drawing.Point(300, 47);
           this.rd2.Name = "rd2";
           this.rd2.Size = new System.Drawing.Size(241, 17);
           this.rd2.TabIndex = 14;
           this.rd2.TabStop = true;
           this.rd2.Text = "KO reset identity, deal_id tăng tiếp từ giá trị cũ";
           this.rd2.UseVisualStyleBackColor = true;
           // 
           // btnResetDealTables
           // 
           this.btnResetDealTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnResetDealTables.ImageIndex = 11;
           this.btnResetDealTables.ImageList = this.imageList1;
           this.btnResetDealTables.Location = new System.Drawing.Point(21, 34);
           this.btnResetDealTables.Name = "btnResetDealTables";
           this.btnResetDealTables.Size = new System.Drawing.Size(257, 27);
           this.btnResetDealTables.TabIndex = 13;
           this.btnResetDealTables.Text = "Reset các bảng LỆNH để bắt đầu ngày mới";
           this.btnResetDealTables.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnResetDealTables.UseVisualStyleBackColor = true;
           this.btnResetDealTables.Click += new System.EventHandler(this.btnResetDealTables_Click);
           // 
           // tabControlFunctions
           // 
           this.tabControlFunctions.Controls.Add(this.tabSellerDeals);
           this.tabControlFunctions.Controls.Add(this.tabPage2);
           this.tabControlFunctions.Controls.Add(this.tabPage1);
           this.tabControlFunctions.Dock = System.Windows.Forms.DockStyle.Top;
           this.tabControlFunctions.ImageList = this.imageList1;
           this.tabControlFunctions.Location = new System.Drawing.Point(3, 3);
           this.tabControlFunctions.Name = "tabControlFunctions";
           this.tabControlFunctions.SelectedIndex = 0;
           this.tabControlFunctions.Size = new System.Drawing.Size(960, 116);
           this.tabControlFunctions.TabIndex = 10;
           // 
           // tabSellerDeals
           // 
           this.tabSellerDeals.Controls.Add(this.groupBox3);
           this.tabSellerDeals.Controls.Add(this.groupBox1);
           this.tabSellerDeals.ForeColor = System.Drawing.SystemColors.ControlText;
           this.tabSellerDeals.ImageIndex = 18;
           this.tabSellerDeals.Location = new System.Drawing.Point(4, 23);
           this.tabSellerDeals.Name = "tabSellerDeals";
           this.tabSellerDeals.Padding = new System.Windows.Forms.Padding(3);
           this.tabSellerDeals.Size = new System.Drawing.Size(952, 89);
           this.tabSellerDeals.TabIndex = 0;
           this.tabSellerDeals.Text = "CÔNG TY CK LÀ BÊN BÁN - F1";
           this.tabSellerDeals.UseVisualStyleBackColor = true;
           // 
           // groupBox3
           // 
           this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
           this.groupBox3.Controls.Add(this.label13);
           this.groupBox3.Controls.Add(this.label14);
           this.groupBox3.Controls.Add(this.btnView2FirmSellerDeals);
           this.groupBox3.Controls.Add(this.label8);
           this.groupBox3.Controls.Add(this.label9);
           this.groupBox3.Controls.Add(this.pictureBox2);
           this.groupBox3.Controls.Add(this.btnCancel2FirmDeal);
           this.groupBox3.Controls.Add(this.btnApprove2FirmDeal);
           this.groupBox3.Controls.Add(this.btnMake2FirmDeal);
           this.groupBox3.Location = new System.Drawing.Point(474, 3);
           this.groupBox3.Name = "groupBox3";
           this.groupBox3.Size = new System.Drawing.Size(475, 81);
           this.groupBox3.TabIndex = 2;
           this.groupBox3.TabStop = false;
           this.groupBox3.Text = "BÁN CHO CÔNG TY KHÁC";
           // 
           // label13
           // 
           this.label13.AutoSize = true;
           this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label13.Location = new System.Drawing.Point(373, 57);
           this.label13.Name = "label13";
           this.label13.Size = new System.Drawing.Size(40, 13);
           this.label13.TabIndex = 24;
           this.label13.Text = "Ctrl + 8";
           // 
           // label14
           // 
           this.label14.AutoSize = true;
           this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label14.Location = new System.Drawing.Point(278, 57);
           this.label14.Name = "label14";
           this.label14.Size = new System.Drawing.Size(40, 13);
           this.label14.TabIndex = 23;
           this.label14.Text = "Ctrl + 7";
           // 
           // btnView2FirmSellerDeals
           // 
           this.btnView2FirmSellerDeals.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnView2FirmSellerDeals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnView2FirmSellerDeals.ImageIndex = 2;
           this.btnView2FirmSellerDeals.ImageList = this.imageList1;
           this.btnView2FirmSellerDeals.Location = new System.Drawing.Point(349, 19);
           this.btnView2FirmSellerDeals.Name = "btnView2FirmSellerDeals";
           this.btnView2FirmSellerDeals.Size = new System.Drawing.Size(104, 35);
           this.btnView2FirmSellerDeals.TabIndex = 22;
           this.btnView2FirmSellerDeals.Text = "X&em lệnh";
           this.btnView2FirmSellerDeals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnView2FirmSellerDeals.UseVisualStyleBackColor = true;
           this.btnView2FirmSellerDeals.Click += new System.EventHandler(this.btnView2FirmSellerDeals_Click);
           // 
           // label8
           // 
           this.label8.AutoSize = true;
           this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label8.Location = new System.Drawing.Point(179, 57);
           this.label8.Name = "label8";
           this.label8.Size = new System.Drawing.Size(40, 13);
           this.label8.TabIndex = 21;
           this.label8.Text = "Ctrl + 6";
           // 
           // label9
           // 
           this.label9.AutoSize = true;
           this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label9.Location = new System.Drawing.Point(70, 57);
           this.label9.Name = "label9";
           this.label9.Size = new System.Drawing.Size(40, 13);
           this.label9.TabIndex = 20;
           this.label9.Text = "Ctrl + 5";
           // 
           // pictureBox2
           // 
           this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
           this.pictureBox2.Location = new System.Drawing.Point(6, 15);
           this.pictureBox2.Name = "pictureBox2";
           this.pictureBox2.Size = new System.Drawing.Size(31, 48);
           this.pictureBox2.TabIndex = 13;
           this.pictureBox2.TabStop = false;
           // 
           // btnCancel2FirmDeal
           // 
           this.btnCancel2FirmDeal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnCancel2FirmDeal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnCancel2FirmDeal.ImageIndex = 3;
           this.btnCancel2FirmDeal.ImageList = this.imageList1;
           this.btnCancel2FirmDeal.Location = new System.Drawing.Point(255, 19);
           this.btnCancel2FirmDeal.Name = "btnCancel2FirmDeal";
           this.btnCancel2FirmDeal.Size = new System.Drawing.Size(87, 35);
           this.btnCancel2FirmDeal.TabIndex = 12;
           this.btnCancel2FirmDeal.Text = "Hủy lệ&nh";
           this.btnCancel2FirmDeal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnCancel2FirmDeal.UseVisualStyleBackColor = true;
           this.btnCancel2FirmDeal.Click += new System.EventHandler(this.btnCancel2FirmDeal_Click);
           // 
           // btnApprove2FirmDeal
           // 
           this.btnApprove2FirmDeal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnApprove2FirmDeal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnApprove2FirmDeal.ImageIndex = 1;
           this.btnApprove2FirmDeal.ImageList = this.imageList1;
           this.btnApprove2FirmDeal.Location = new System.Drawing.Point(153, 19);
           this.btnApprove2FirmDeal.Name = "btnApprove2FirmDeal";
           this.btnApprove2FirmDeal.Size = new System.Drawing.Size(95, 35);
           this.btnApprove2FirmDeal.TabIndex = 11;
           this.btnApprove2FirmDeal.Text = "D&uyệt lệnh";
           this.btnApprove2FirmDeal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnApprove2FirmDeal.UseVisualStyleBackColor = true;
           this.btnApprove2FirmDeal.Click += new System.EventHandler(this.btnApprove2FirmDeal_Click);
           // 
           // btnMake2FirmDeal
           // 
           this.btnMake2FirmDeal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnMake2FirmDeal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnMake2FirmDeal.ImageIndex = 18;
           this.btnMake2FirmDeal.ImageList = this.imageList1;
           this.btnMake2FirmDeal.Location = new System.Drawing.Point(44, 19);
           this.btnMake2FirmDeal.Name = "btnMake2FirmDeal";
           this.btnMake2FirmDeal.Size = new System.Drawing.Size(103, 35);
           this.btnMake2FirmDeal.TabIndex = 10;
           this.btnMake2FirmDeal.Text = "Đặt &lệnh";
           this.btnMake2FirmDeal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnMake2FirmDeal.UseVisualStyleBackColor = true;
           this.btnMake2FirmDeal.Click += new System.EventHandler(this.btnMake2FirmDeal_Click);
           // 
           // groupBox1
           // 
           this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
           this.groupBox1.Controls.Add(this.btnView1FirmDeals);
           this.groupBox1.Controls.Add(this.label7);
           this.groupBox1.Controls.Add(this.label5);
           this.groupBox1.Controls.Add(this.label10);
           this.groupBox1.Controls.Add(this.label6);
           this.groupBox1.Controls.Add(this.pictureBox1);
           this.groupBox1.Controls.Add(this.btnCancel1FirmDeal);
           this.groupBox1.Controls.Add(this.btnApprove1FirmDeal);
           this.groupBox1.Controls.Add(this.btnMake1FirmDeal);
           this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
           this.groupBox1.Location = new System.Drawing.Point(3, 3);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(468, 81);
           this.groupBox1.TabIndex = 1;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "MUA VÀ BÁN TRONG CÙNG CÔNG TY CK";
           // 
           // btnView1FirmDeals
           // 
           this.btnView1FirmDeals.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnView1FirmDeals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnView1FirmDeals.ImageIndex = 2;
           this.btnView1FirmDeals.ImageList = this.imageList1;
           this.btnView1FirmDeals.Location = new System.Drawing.Point(364, 19);
           this.btnView1FirmDeals.Name = "btnView1FirmDeals";
           this.btnView1FirmDeals.Size = new System.Drawing.Size(97, 35);
           this.btnView1FirmDeals.TabIndex = 19;
           this.btnView1FirmDeals.Text = "&Xem lệnh";
           this.btnView1FirmDeals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnView1FirmDeals.UseVisualStyleBackColor = true;
           this.btnView1FirmDeals.Click += new System.EventHandler(this.btnView1FirmDeals_Click);
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label7.Location = new System.Drawing.Point(294, 57);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(40, 13);
           this.label7.TabIndex = 18;
           this.label7.Text = "Ctrl + 3";
           // 
           // label5
           // 
           this.label5.AutoSize = true;
           this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label5.Location = new System.Drawing.Point(192, 57);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(40, 13);
           this.label5.TabIndex = 17;
           this.label5.Text = "Ctrl + 2";
           // 
           // label10
           // 
           this.label10.AutoSize = true;
           this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label10.Location = new System.Drawing.Point(393, 57);
           this.label10.Name = "label10";
           this.label10.Size = new System.Drawing.Size(40, 13);
           this.label10.TabIndex = 19;
           this.label10.Text = "Ctrl + 4";
           // 
           // label6
           // 
           this.label6.AutoSize = true;
           this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label6.Location = new System.Drawing.Point(80, 57);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(40, 13);
           this.label6.TabIndex = 16;
           this.label6.Text = "Ctrl + 1";
           // 
           // pictureBox1
           // 
           this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
           this.pictureBox1.Location = new System.Drawing.Point(11, 15);
           this.pictureBox1.Name = "pictureBox1";
           this.pictureBox1.Size = new System.Drawing.Size(31, 48);
           this.pictureBox1.TabIndex = 10;
           this.pictureBox1.TabStop = false;
           // 
           // btnCancel1FirmDeal
           // 
           this.btnCancel1FirmDeal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnCancel1FirmDeal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnCancel1FirmDeal.ImageIndex = 3;
           this.btnCancel1FirmDeal.ImageList = this.imageList1;
           this.btnCancel1FirmDeal.Location = new System.Drawing.Point(268, 19);
           this.btnCancel1FirmDeal.Name = "btnCancel1FirmDeal";
           this.btnCancel1FirmDeal.Size = new System.Drawing.Size(90, 35);
           this.btnCancel1FirmDeal.TabIndex = 9;
           this.btnCancel1FirmDeal.Text = "&Hủy lệnh";
           this.btnCancel1FirmDeal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnCancel1FirmDeal.UseVisualStyleBackColor = true;
           this.btnCancel1FirmDeal.Click += new System.EventHandler(this.btnCancel1FirmDeal_Click);
           // 
           // btnApprove1FirmDeal
           // 
           this.btnApprove1FirmDeal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnApprove1FirmDeal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnApprove1FirmDeal.ImageIndex = 1;
           this.btnApprove1FirmDeal.ImageList = this.imageList1;
           this.btnApprove1FirmDeal.Location = new System.Drawing.Point(162, 19);
           this.btnApprove1FirmDeal.Name = "btnApprove1FirmDeal";
           this.btnApprove1FirmDeal.Size = new System.Drawing.Size(100, 35);
           this.btnApprove1FirmDeal.TabIndex = 8;
           this.btnApprove1FirmDeal.Text = "&Duyệt lệnh";
           this.btnApprove1FirmDeal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnApprove1FirmDeal.UseVisualStyleBackColor = true;
           this.btnApprove1FirmDeal.Click += new System.EventHandler(this.btnApprove1FirmDeal_Click);
           // 
           // btnMake1FirmDeal
           // 
           this.btnMake1FirmDeal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnMake1FirmDeal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnMake1FirmDeal.ImageIndex = 18;
           this.btnMake1FirmDeal.ImageList = this.imageList1;
           this.btnMake1FirmDeal.Location = new System.Drawing.Point(50, 19);
           this.btnMake1FirmDeal.Name = "btnMake1FirmDeal";
           this.btnMake1FirmDeal.Size = new System.Drawing.Size(105, 35);
           this.btnMake1FirmDeal.TabIndex = 7;
           this.btnMake1FirmDeal.Text = "Đặ&t lệnh";
           this.btnMake1FirmDeal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           this.btnMake1FirmDeal.UseVisualStyleBackColor = true;
           this.btnMake1FirmDeal.Click += new System.EventHandler(this.btnMake1FirmDeal_Click);
           // 
           // tabPage2
           // 
           this.tabPage2.Controls.Add(this.label11);
           this.tabPage2.Controls.Add(this.btnBuyerBrowseDeals);
           this.tabPage2.Controls.Add(this.label3);
           this.tabPage2.Controls.Add(this.label4);
           this.tabPage2.Controls.Add(this.btnBuyerApproveSellerCancel);
           this.tabPage2.Controls.Add(this.btnBuyerApproveSeller);
           this.tabPage2.ImageIndex = 20;
           this.tabPage2.Location = new System.Drawing.Point(4, 23);
           this.tabPage2.Name = "tabPage2";
           this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
           this.tabPage2.Size = new System.Drawing.Size(952, 89);
           this.tabPage2.TabIndex = 1;
           this.tabPage2.Text = "CÔNG TY CK LÀ BÊN MUA - F2";
           this.tabPage2.UseVisualStyleBackColor = true;
           // 
           // label11
           // 
           this.label11.AutoSize = true;
           this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label11.Location = new System.Drawing.Point(564, 65);
           this.label11.Name = "label11";
           this.label11.Size = new System.Drawing.Size(40, 13);
           this.label11.TabIndex = 19;
           this.label11.Text = "Ctrl + 3";
           // 
           // btnBuyerBrowseDeals
           // 
           this.btnBuyerBrowseDeals.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnBuyerBrowseDeals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnBuyerBrowseDeals.ImageIndex = 2;
           this.btnBuyerBrowseDeals.ImageList = this.imageList1;
           this.btnBuyerBrowseDeals.Location = new System.Drawing.Point(481, 11);
           this.btnBuyerBrowseDeals.Name = "btnBuyerBrowseDeals";
           this.btnBuyerBrowseDeals.Size = new System.Drawing.Size(209, 51);
           this.btnBuyerBrowseDeals.TabIndex = 18;
           this.btnBuyerBrowseDeals.Text = "&Xem lệnh";
           this.btnBuyerBrowseDeals.UseVisualStyleBackColor = true;
           this.btnBuyerBrowseDeals.Click += new System.EventHandler(this.btnBuyerBrowseDeals_Click);
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label3.Location = new System.Drawing.Point(347, 65);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(40, 13);
           this.label3.TabIndex = 17;
           this.label3.Text = "Ctrl + 2";
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label4.Location = new System.Drawing.Point(92, 65);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(40, 13);
           this.label4.TabIndex = 16;
           this.label4.Text = "Ctrl + 1";
           // 
           // btnBuyerApproveSellerCancel
           // 
           this.btnBuyerApproveSellerCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnBuyerApproveSellerCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnBuyerApproveSellerCancel.ImageIndex = 3;
           this.btnBuyerApproveSellerCancel.ImageList = this.imageList1;
           this.btnBuyerApproveSellerCancel.Location = new System.Drawing.Point(268, 11);
           this.btnBuyerApproveSellerCancel.Name = "btnBuyerApproveSellerCancel";
           this.btnBuyerApproveSellerCancel.Size = new System.Drawing.Size(191, 51);
           this.btnBuyerApproveSellerCancel.TabIndex = 11;
           this.btnBuyerApproveSellerCancel.Text = "&Hủy lệnh";
           this.btnBuyerApproveSellerCancel.UseVisualStyleBackColor = true;
           this.btnBuyerApproveSellerCancel.Click += new System.EventHandler(this.btnBuyerApproveSellerCancel_Click);
           // 
           // btnBuyerApproveSeller
           // 
           this.btnBuyerApproveSeller.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnBuyerApproveSeller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnBuyerApproveSeller.ImageIndex = 1;
           this.btnBuyerApproveSeller.ImageList = this.imageList1;
           this.btnBuyerApproveSeller.Location = new System.Drawing.Point(14, 11);
           this.btnBuyerApproveSeller.Name = "btnBuyerApproveSeller";
           this.btnBuyerApproveSeller.Size = new System.Drawing.Size(203, 51);
           this.btnBuyerApproveSeller.TabIndex = 10;
           this.btnBuyerApproveSeller.Text = "&Duyệt lệnh từ bên bán gửi sang";
           this.btnBuyerApproveSeller.UseVisualStyleBackColor = true;
           this.btnBuyerApproveSeller.Click += new System.EventHandler(this.btnBuyerApproveSeller_Click);
           // 
           // tabPage1
           // 
           this.tabPage1.Controls.Add(this.label16);
           this.tabPage1.Controls.Add(this.btnAdvAnnounce);
           this.tabPage1.Controls.Add(this.label15);
           this.tabPage1.Controls.Add(this.btnViewAdv);
           this.tabPage1.Controls.Add(this.label12);
           this.tabPage1.Controls.Add(this.btnCancelAdv);
           this.tabPage1.Controls.Add(this.label2);
           this.tabPage1.Controls.Add(this.label1);
           this.tabPage1.Controls.Add(this.btnMakeNewAdv);
           this.tabPage1.Controls.Add(this.btnApproveAdv);
           this.tabPage1.ImageIndex = 16;
           this.tabPage1.Location = new System.Drawing.Point(4, 23);
           this.tabPage1.Name = "tabPage1";
           this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
           this.tabPage1.Size = new System.Drawing.Size(952, 89);
           this.tabPage1.TabIndex = 2;
           this.tabPage1.Text = "QUẢNG CÁO - F3";
           this.tabPage1.UseVisualStyleBackColor = true;
           // 
           // label16
           // 
           this.label16.AutoSize = true;
           this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label16.Location = new System.Drawing.Point(784, 66);
           this.label16.Name = "label16";
           this.label16.Size = new System.Drawing.Size(40, 13);
           this.label16.TabIndex = 21;
           this.label16.Text = "Ctrl + 5";
           // 
           // btnAdvAnnounce
           // 
           this.btnAdvAnnounce.BackColor = System.Drawing.Color.WhiteSmoke;
           this.btnAdvAnnounce.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnAdvAnnounce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnAdvAnnounce.ImageIndex = 8;
           this.btnAdvAnnounce.ImageList = this.imageList1;
           this.btnAdvAnnounce.Location = new System.Drawing.Point(713, 16);
           this.btnAdvAnnounce.Name = "btnAdvAnnounce";
           this.btnAdvAnnounce.Size = new System.Drawing.Size(223, 42);
           this.btnAdvAnnounce.TabIndex = 20;
           this.btnAdvAnnounce.Text = "Xem lệnh quảng cáo của các công ty gửi lên HOSE";
           this.btnAdvAnnounce.UseVisualStyleBackColor = false;
           this.btnAdvAnnounce.Click += new System.EventHandler(this.btnAdvAnnounce_Click);
           // 
           // label15
           // 
           this.label15.AutoSize = true;
           this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label15.Location = new System.Drawing.Point(594, 66);
           this.label15.Name = "label15";
           this.label15.Size = new System.Drawing.Size(40, 13);
           this.label15.TabIndex = 19;
           this.label15.Text = "Ctrl + 4";
           // 
           // btnViewAdv
           // 
           this.btnViewAdv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnViewAdv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnViewAdv.ImageIndex = 2;
           this.btnViewAdv.ImageList = this.imageList1;
           this.btnViewAdv.Location = new System.Drawing.Point(545, 16);
           this.btnViewAdv.Name = "btnViewAdv";
           this.btnViewAdv.Size = new System.Drawing.Size(153, 42);
           this.btnViewAdv.TabIndex = 18;
           this.btnViewAdv.Text = "Xem lệnh quảng cáo của công ty";
           this.btnViewAdv.UseVisualStyleBackColor = true;
           this.btnViewAdv.Click += new System.EventHandler(this.btnViewAdv_Click);
           // 
           // label12
           // 
           this.label12.AutoSize = true;
           this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label12.Location = new System.Drawing.Point(433, 66);
           this.label12.Name = "label12";
           this.label12.Size = new System.Drawing.Size(40, 13);
           this.label12.TabIndex = 17;
           this.label12.Text = "Ctrl + 3";
           // 
           // btnCancelAdv
           // 
           this.btnCancelAdv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnCancelAdv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnCancelAdv.ImageIndex = 3;
           this.btnCancelAdv.ImageList = this.imageList1;
           this.btnCancelAdv.Location = new System.Drawing.Point(368, 16);
           this.btnCancelAdv.Name = "btnCancelAdv";
           this.btnCancelAdv.Size = new System.Drawing.Size(161, 42);
           this.btnCancelAdv.TabIndex = 16;
           this.btnCancelAdv.Text = "&Hủy lệnh quảng cáo";
           this.btnCancelAdv.UseVisualStyleBackColor = true;
           this.btnCancelAdv.Click += new System.EventHandler(this.btnCancelAdv_Click);
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label2.Location = new System.Drawing.Point(248, 66);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(40, 13);
           this.label2.TabIndex = 15;
           this.label2.Text = "Ctrl + 2";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
           this.label1.Location = new System.Drawing.Point(63, 66);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(40, 13);
           this.label1.TabIndex = 14;
           this.label1.Text = "Ctrl + 1";
           // 
           // btnMakeNewAdv
           // 
           this.btnMakeNewAdv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnMakeNewAdv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnMakeNewAdv.ImageIndex = 18;
           this.btnMakeNewAdv.ImageList = this.imageList1;
           this.btnMakeNewAdv.Location = new System.Drawing.Point(14, 16);
           this.btnMakeNewAdv.Name = "btnMakeNewAdv";
           this.btnMakeNewAdv.Size = new System.Drawing.Size(155, 42);
           this.btnMakeNewAdv.TabIndex = 13;
           this.btnMakeNewAdv.Text = "Đặt lệnh &quảng cáo";
           this.btnMakeNewAdv.UseVisualStyleBackColor = true;
           this.btnMakeNewAdv.Click += new System.EventHandler(this.btnMakeNewAdv_Click);
           // 
           // btnApproveAdv
           // 
           this.btnApproveAdv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
           this.btnApproveAdv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.btnApproveAdv.ImageIndex = 1;
           this.btnApproveAdv.ImageList = this.imageList1;
           this.btnApproveAdv.Location = new System.Drawing.Point(188, 16);
           this.btnApproveAdv.Name = "btnApproveAdv";
           this.btnApproveAdv.Size = new System.Drawing.Size(165, 42);
           this.btnApproveAdv.TabIndex = 12;
           this.btnApproveAdv.Text = "&Duyệt lệnh quảng cáo";
           this.btnApproveAdv.UseVisualStyleBackColor = true;
           this.btnApproveAdv.Click += new System.EventHandler(this.btnApproveAdv_Click);
           // 
           // statusStrip1
           // 
           this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttipSystem,
            this.ttipStatus,
            this.ttipTimer,
            this.toolStripStatusLabel1,
            this.ttipMarketStatus});
           this.statusStrip1.Location = new System.Drawing.Point(3, 518);
           this.statusStrip1.Name = "statusStrip1";
           this.statusStrip1.Size = new System.Drawing.Size(960, 22);
           this.statusStrip1.TabIndex = 9;
           this.statusStrip1.Text = "statusStrip1";
           // 
           // ttipSystem
           // 
           this.ttipSystem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
           this.ttipSystem.Name = "ttipSystem";
           this.ttipSystem.Size = new System.Drawing.Size(70, 17);
           this.ttipSystem.Text = "ttipSystem";
           // 
           // ttipStatus
           // 
           this.ttipStatus.ForeColor = System.Drawing.Color.DarkGreen;
           this.ttipStatus.Name = "ttipStatus";
           this.ttipStatus.Size = new System.Drawing.Size(57, 17);
           this.ttipStatus.Text = "ttipStatus";
           // 
           // ttipTimer
           // 
           this.ttipTimer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
           this.ttipTimer.ForeColor = System.Drawing.Color.DodgerBlue;
           this.ttipTimer.Name = "ttipTimer";
           this.ttipTimer.Size = new System.Drawing.Size(60, 17);
           this.ttipTimer.Text = "ttipTimer";
           // 
           // toolStripStatusLabel1
           // 
           this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
           this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 17);
           this.toolStripStatusLabel1.Text = "           ";
           // 
           // ttipMarketStatus
           // 
           this.ttipMarketStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
           this.ttipMarketStatus.Name = "ttipMarketStatus";
           this.ttipMarketStatus.Size = new System.Drawing.Size(105, 17);
           this.ttipMarketStatus.Text = "ttipMarketStatus";
           // 
           // lvLog
           // 
           this.lvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colTime,
            this.colDetails});
           this.lvLog.ContextMenuStrip = this.contextMenuStrip1;
           this.lvLog.FullRowSelect = true;
           this.lvLog.GridLines = true;
           this.lvLog.LargeImageList = this.imageList1;
           this.lvLog.Location = new System.Drawing.Point(6, 208);
           this.lvLog.Name = "lvLog";
           this.lvLog.Size = new System.Drawing.Size(952, 296);
           this.lvLog.SmallImageList = this.imageList1;
           this.lvLog.StateImageList = this.imageList1;
           this.lvLog.TabIndex = 6;
           this.lvLog.UseCompatibleStateImageBehavior = false;
           this.lvLog.View = System.Windows.Forms.View.Details;
           // 
           // colDate
           // 
           this.colDate.Text = "Ngày";
           this.colDate.Width = 140;
           // 
           // colTime
           // 
           this.colTime.Text = "Giờ";
           this.colTime.Width = 80;
           // 
           // colDetails
           // 
           this.colDetails.Text = "Nội dung";
           this.colDetails.Width = 500;
           // 
           // tabControlApplication
           // 
           this.tabControlApplication.Controls.Add(this.pageMain);
           this.tabControlApplication.Dock = System.Windows.Forms.DockStyle.Fill;
           this.tabControlApplication.Location = new System.Drawing.Point(0, 0);
           this.tabControlApplication.Name = "tabControlApplication";
           this.tabControlApplication.SelectedIndex = 0;
           this.tabControlApplication.Size = new System.Drawing.Size(974, 569);
           this.tabControlApplication.TabIndex = 7;
           // 
           // timerSystem
           // 
           this.timerSystem.Interval = 1000;
           this.timerSystem.Tick += new System.EventHandler(this.timerSystem_Tick);
           // 
           // timerMarketStatus
           // 
           this.timerMarketStatus.Interval = 60000;
           this.timerMarketStatus.Tick += new System.EventHandler(this.timerMarketStatus_Tick);
           // 
           // timerBuyerTasks
           // 
           this.timerBuyerTasks.Interval = 10000;
           this.timerBuyerTasks.Tick += new System.EventHandler(this.timerBuyerTasks_Tick);
           // 
           // frmMainPT
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(974, 569);
           this.Controls.Add(this.menuStrip1);
           this.Controls.Add(this.tabControlApplication);
           this.Controls.Add(this.btnClose);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.KeyPreview = true;
           this.Name = "frmMainPT";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "RabbitPT - Chương trình quản lý lệnh thỏa thuận";
           this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
           this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
           this.Load += new System.EventHandler(this.frmMain_Load);
           this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
           this.contextMenuStrip1.ResumeLayout(false);
           this.menuStrip1.ResumeLayout(false);
           this.menuStrip1.PerformLayout();
           this.pageMain.ResumeLayout(false);
           this.pageMain.PerformLayout();
           this.grbAdmin.ResumeLayout(false);
           this.grbAdmin.PerformLayout();
           this.tabControlFunctions.ResumeLayout(false);
           this.tabSellerDeals.ResumeLayout(false);
           this.groupBox3.ResumeLayout(false);
           this.groupBox3.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
           this.tabPage2.ResumeLayout(false);
           this.tabPage2.PerformLayout();
           this.tabPage1.ResumeLayout(false);
           this.tabPage1.PerformLayout();
           this.statusStrip1.ResumeLayout(false);
           this.statusStrip1.PerformLayout();
           this.tabControlApplication.ResumeLayout(false);
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.TabControl tabControlFunctions;
        private System.Windows.Forms.TabPage tabSellerDeals;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel2FirmDeal;
        private System.Windows.Forms.Button btnApprove2FirmDeal;
        private System.Windows.Forms.Button btnMake2FirmDeal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel1FirmDeal;
        private System.Windows.Forms.Button btnApprove1FirmDeal;
        private System.Windows.Forms.Button btnMake1FirmDeal;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBuyerApproveSellerCancel;
        private System.Windows.Forms.Button btnBuyerApproveSeller;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMakeNewAdv;
        private System.Windows.Forms.Button btnApproveAdv;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttipSystem;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colDetails;
        private System.Windows.Forms.TabControl tabControlApplication;
        private System.Windows.Forms.ToolStripStatusLabel ttipStatus;
        private System.Windows.Forms.ToolStripStatusLabel ttipTimer;
        private System.Windows.Forms.Timer timerSystem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ttipMarketStatus;
        private System.Windows.Forms.Timer timerMarketStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerBuyerTasks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBuyerBrowseDeals;
        private System.Windows.Forms.Button btnView2FirmSellerDeals;
        private System.Windows.Forms.Button btnView1FirmDeals;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancelAdv;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnViewAdv;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAdvAnnounce;
        private System.Windows.Forms.GroupBox grbAdmin;
        private System.Windows.Forms.RadioButton rd1;
        private System.Windows.Forms.RadioButton rd2;
        private System.Windows.Forms.Button btnResetDealTables;
    }
}

