namespace HOGW_CoreConnector
{
    partial class frmMainConnector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainConnector));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvLog = new System.Windows.Forms.ListView();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colDetails = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rd5 = new System.Windows.Forms.RadioButton();
            this.rd4 = new System.Windows.Forms.RadioButton();
            this.btnResetPRSMessages = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.btnResetCTCIMessages = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCoreDB = new System.Windows.Forms.Label();
            this.lblPTDB = new System.Windows.Forms.Label();
            this.lblHOGWDB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestCaseExec = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttipSystem = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttipTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttipMarketStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerMarketStatus = new System.Windows.Forms.Timer(this.components);
            this.timerSystem = new System.Windows.Forms.Timer(this.components);
            this.btnTestCancelOrders = new System.Windows.Forms.Button();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conMenuNotiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.conMenuNotiRunThreads = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuNotiStop = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuNotiRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.conMenuNotiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrderPicker = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnStart.Location = new System.Drawing.Point(377, 44);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Create th&read(s)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnStop.Location = new System.Drawing.Point(570, 44);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(132, 35);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Sto&p";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(671, 573);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 26);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.clearLogToolStripMenuItem.Text = "Clear log";
            // 
            // lvLog
            // 
            this.lvLog.BackColor = System.Drawing.Color.Black;
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colTime,
            this.colDetails});
            this.lvLog.ContextMenuStrip = this.contextMenuStrip1;
            this.lvLog.ForeColor = System.Drawing.Color.White;
            this.lvLog.FullRowSelect = true;
            this.lvLog.GridLines = true;
            this.lvLog.LargeImageList = this.imageList1;
            this.lvLog.Location = new System.Drawing.Point(6, 208);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(776, 328);
            this.lvLog.SmallImageList = this.imageList1;
            this.lvLog.StateImageList = this.imageList1;
            this.lvLog.TabIndex = 6;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 140;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 80;
            // 
            // colDetails
            // 
            this.colDetails.Text = "Details";
            this.colDetails.Width = 500;
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
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageMain);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 568);
            this.tabControl1.TabIndex = 7;
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.groupBox3);
            this.pageMain.Controls.Add(this.groupBox1);
            this.pageMain.Controls.Add(this.groupBox2);
            this.pageMain.Controls.Add(this.lvLog);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(790, 542);
            this.pageMain.TabIndex = 0;
            this.pageMain.Text = "Application";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.rd5);
            this.groupBox3.Controls.Add(this.rd4);
            this.groupBox3.Controls.Add(this.btnResetPRSMessages);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(376, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 77);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reset PRS messages (HOSE_xx,GA,SU,SS,SC,IU,TP,TS...)";
            // 
            // rd5
            // 
            this.rd5.AutoSize = true;
            this.rd5.Location = new System.Drawing.Point(93, 43);
            this.rd5.Name = "rd5";
            this.rd5.Size = new System.Drawing.Size(159, 17);
            this.rd5.TabIndex = 12;
            this.rd5.TabStop = true;
            this.rd5.Text = "Clear all DATA, reset identity";
            this.rd5.UseVisualStyleBackColor = true;
            // 
            // rd4
            // 
            this.rd4.AutoSize = true;
            this.rd4.Location = new System.Drawing.Point(93, 20);
            this.rd4.Name = "rd4";
            this.rd4.Size = new System.Drawing.Size(226, 17);
            this.rd4.TabIndex = 11;
            this.rd4.TabStop = true;
            this.rd4.Text = "Keep the last date DATA, not reset identity";
            this.rd4.UseVisualStyleBackColor = true;
            // 
            // btnResetPRSMessages
            // 
            this.btnResetPRSMessages.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnResetPRSMessages.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnResetPRSMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPRSMessages.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnResetPRSMessages.Location = new System.Drawing.Point(7, 20);
            this.btnResetPRSMessages.Name = "btnResetPRSMessages";
            this.btnResetPRSMessages.Size = new System.Drawing.Size(71, 45);
            this.btnResetPRSMessages.TabIndex = 7;
            this.btnResetPRSMessages.Text = "Reset &PRS messages";
            this.btnResetPRSMessages.UseVisualStyleBackColor = true;
            this.btnResetPRSMessages.Click += new System.EventHandler(this.btnResetPRSMessages_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.rd2);
            this.groupBox1.Controls.Add(this.rd3);
            this.groupBox1.Controls.Add(this.rd1);
            this.groupBox1.Controls.Add(this.btnResetCTCIMessages);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(9, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 77);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset CTCI messages (HOGW_xx,RN,RP,RQ)";
            // 
            // rd2
            // 
            this.rd2.AutoSize = true;
            this.rd2.Location = new System.Drawing.Point(91, 35);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(238, 17);
            this.rd2.TabIndex = 10;
            this.rd2.TabStop = true;
            this.rd2.Text = "Backup and Clear all DATA, not reset identity";
            this.rd2.UseVisualStyleBackColor = true;
            // 
            // rd3
            // 
            this.rd3.AutoSize = true;
            this.rd3.Location = new System.Drawing.Point(91, 54);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(220, 17);
            this.rd3.TabIndex = 9;
            this.rd3.TabStop = true;
            this.rd3.Text = "Backup and Clear all DATA, reset identity";
            this.rd3.UseVisualStyleBackColor = true;
            // 
            // rd1
            // 
            this.rd1.AutoSize = true;
            this.rd1.Location = new System.Drawing.Point(91, 16);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(226, 17);
            this.rd1.TabIndex = 8;
            this.rd1.TabStop = true;
            this.rd1.Text = "Keep the last date DATA, not reset identity";
            this.rd1.UseVisualStyleBackColor = true;
            // 
            // btnResetCTCIMessages
            // 
            this.btnResetCTCIMessages.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnResetCTCIMessages.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnResetCTCIMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetCTCIMessages.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnResetCTCIMessages.Location = new System.Drawing.Point(7, 20);
            this.btnResetCTCIMessages.Name = "btnResetCTCIMessages";
            this.btnResetCTCIMessages.Size = new System.Drawing.Size(71, 45);
            this.btnResetCTCIMessages.TabIndex = 7;
            this.btnResetCTCIMessages.Text = "&Reset CTCI messages";
            this.btnResetCTCIMessages.UseVisualStyleBackColor = true;
            this.btnResetCTCIMessages.Click += new System.EventHandler(this.btnResetMessages_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.lblCoreDB);
            this.groupBox2.Controls.Add(this.lblPTDB);
            this.groupBox2.Controls.Add(this.lblHOGWDB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Location = new System.Drawing.Point(6, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 111);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // lblCoreDB
            // 
            this.lblCoreDB.AutoSize = true;
            this.lblCoreDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoreDB.ForeColor = System.Drawing.Color.White;
            this.lblCoreDB.Location = new System.Drawing.Point(115, 87);
            this.lblCoreDB.Name = "lblCoreDB";
            this.lblCoreDB.Size = new System.Drawing.Size(89, 13);
            this.lblCoreDB.TabIndex = 13;
            this.lblCoreDB.Text = "Core database";
            // 
            // lblPTDB
            // 
            this.lblPTDB.AutoSize = true;
            this.lblPTDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPTDB.ForeColor = System.Drawing.Color.White;
            this.lblPTDB.Location = new System.Drawing.Point(115, 66);
            this.lblPTDB.Name = "lblPTDB";
            this.lblPTDB.Size = new System.Drawing.Size(79, 13);
            this.lblPTDB.TabIndex = 12;
            this.lblPTDB.Text = "PT database";
            // 
            // lblHOGWDB
            // 
            this.lblHOGWDB.AutoSize = true;
            this.lblHOGWDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHOGWDB.ForeColor = System.Drawing.Color.White;
            this.lblHOGWDB.Location = new System.Drawing.Point(115, 44);
            this.lblHOGWDB.Name = "lblHOGWDB";
            this.lblHOGWDB.Size = new System.Drawing.Size(106, 13);
            this.lblHOGWDB.TabIndex = 11;
            this.lblHOGWDB.Text = "HOGW database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Core database";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "PT database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "HOGW database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hose gateway - Core adapter";
            // 
            // btnTestCaseExec
            // 
            this.btnTestCaseExec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTestCaseExec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnTestCaseExec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestCaseExec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestCaseExec.ForeColor = System.Drawing.Color.SkyBlue;
            this.btnTestCaseExec.Location = new System.Drawing.Point(11, 571);
            this.btnTestCaseExec.Name = "btnTestCaseExec";
            this.btnTestCaseExec.Size = new System.Drawing.Size(179, 28);
            this.btnTestCaseExec.TabIndex = 14;
            this.btnTestCaseExec.Text = "Test Case &Executive";
            this.btnTestCaseExec.UseVisualStyleBackColor = true;
            this.btnTestCaseExec.Click += new System.EventHandler(this.btnTestCaseExec_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttipSystem,
            this.ttipTimer,
            this.toolStripStatusLabel1,
            this.ttipMarketStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 603);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(798, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttipSystem
            // 
            this.ttipSystem.BackColor = System.Drawing.Color.Black;
            this.ttipSystem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ttipSystem.ForeColor = System.Drawing.Color.White;
            this.ttipSystem.Name = "ttipSystem";
            this.ttipSystem.Size = new System.Drawing.Size(70, 17);
            this.ttipSystem.Text = "ttipSystem";
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
            this.ttipMarketStatus.ForeColor = System.Drawing.Color.LawnGreen;
            this.ttipMarketStatus.Name = "ttipMarketStatus";
            this.ttipMarketStatus.Size = new System.Drawing.Size(105, 17);
            this.ttipMarketStatus.Text = "ttipMarketStatus";
            // 
            // timerMarketStatus
            // 
            this.timerMarketStatus.Interval = 60000;
            this.timerMarketStatus.Tick += new System.EventHandler(this.timerMarketStatus_Tick);
            // 
            // timerSystem
            // 
            this.timerSystem.Interval = 1000;
            this.timerSystem.Tick += new System.EventHandler(this.timerSystem_Tick);
            // 
            // btnTestCancelOrders
            // 
            this.btnTestCancelOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTestCancelOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnTestCancelOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestCancelOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestCancelOrders.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnTestCancelOrders.Location = new System.Drawing.Point(196, 571);
            this.btnTestCancelOrders.Name = "btnTestCancelOrders";
            this.btnTestCancelOrders.Size = new System.Drawing.Size(178, 28);
            this.btnTestCancelOrders.TabIndex = 15;
            this.btnTestCancelOrders.Text = "Test Case &Cancel order(s)";
            this.btnTestCancelOrders.UseVisualStyleBackColor = true;
            this.btnTestCancelOrders.Click += new System.EventHandler(this.btnTestCancelOrders_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconMain.BalloonTipText = "TipText";
            this.notifyIconMain.BalloonTipTitle = "TipTitle";
            this.notifyIconMain.ContextMenuStrip = this.contextMenuNotify;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Double click to restore CoreAdapter";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.DoubleClick += new System.EventHandler(this.notifyIconMain_DoubleClick);
            // 
            // contextMenuNotify
            // 
            this.contextMenuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conMenuNotiShow,
            this.toolStripSeparator1,
            this.conMenuNotiRunThreads,
            this.conMenuNotiStop,
            this.conMenuNotiRestart,
            this.toolStripSeparator2,
            this.conMenuNotiExit});
            this.contextMenuNotify.Name = "contextMenuNotify";
            this.contextMenuNotify.Size = new System.Drawing.Size(205, 126);
            // 
            // conMenuNotiShow
            // 
            this.conMenuNotiShow.Name = "conMenuNotiShow";
            this.conMenuNotiShow.Size = new System.Drawing.Size(204, 22);
            this.conMenuNotiShow.Text = "Show CoreAdapter window";
            this.conMenuNotiShow.Click += new System.EventHandler(this.conMenuNotiShow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // conMenuNotiRunThreads
            // 
            this.conMenuNotiRunThreads.Name = "conMenuNotiRunThreads";
            this.conMenuNotiRunThreads.Size = new System.Drawing.Size(204, 22);
            this.conMenuNotiRunThreads.Text = "Create and start threads";
            this.conMenuNotiRunThreads.Click += new System.EventHandler(this.conMenuNotiRunThreads_Click);
            // 
            // conMenuNotiStop
            // 
            this.conMenuNotiStop.Name = "conMenuNotiStop";
            this.conMenuNotiStop.Size = new System.Drawing.Size(204, 22);
            this.conMenuNotiStop.Text = "Stop threads";
            this.conMenuNotiStop.Click += new System.EventHandler(this.conMenuNotiStop_Click);
            // 
            // conMenuNotiRestart
            // 
            this.conMenuNotiRestart.Name = "conMenuNotiRestart";
            this.conMenuNotiRestart.Size = new System.Drawing.Size(204, 22);
            this.conMenuNotiRestart.Text = "Restart threads";
            this.conMenuNotiRestart.Click += new System.EventHandler(this.conMenuNotiRestart_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // conMenuNotiExit
            // 
            this.conMenuNotiExit.Name = "conMenuNotiExit";
            this.conMenuNotiExit.Size = new System.Drawing.Size(204, 22);
            this.conMenuNotiExit.Text = "Stop and Exit";
            this.conMenuNotiExit.Click += new System.EventHandler(this.conMenuNotiExit_Click);
            // 
            // btnOrderPicker
            // 
            this.btnOrderPicker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOrderPicker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnOrderPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderPicker.ForeColor = System.Drawing.Color.Orange;
            this.btnOrderPicker.Location = new System.Drawing.Point(387, 571);
            this.btnOrderPicker.Name = "btnOrderPicker";
            this.btnOrderPicker.Size = new System.Drawing.Size(130, 28);
            this.btnOrderPicker.TabIndex = 16;
            this.btnOrderPicker.Text = "Order &picker";
            this.btnOrderPicker.UseVisualStyleBackColor = true;
            this.btnOrderPicker.Click += new System.EventHandler(this.btnOrderPicker_Click);
            // 
            // frmMainConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(798, 625);
            this.Controls.Add(this.btnOrderPicker);
            this.Controls.Add(this.btnTestCancelOrders);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnTestCaseExec);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMainConnector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rabbit core adapter (with SBS)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Resize += new System.EventHandler(this.frmMainConnector_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colDetails;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnResetCTCIMessages;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttipSystem;
        private System.Windows.Forms.ToolStripStatusLabel ttipTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ttipMarketStatus;
        private System.Windows.Forms.Timer timerMarketStatus;
        private System.Windows.Forms.Timer timerSystem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCoreDB;
        private System.Windows.Forms.Label lblPTDB;
        private System.Windows.Forms.Label lblHOGWDB;
        private System.Windows.Forms.Button btnTestCaseExec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnResetPRSMessages;
        private System.Windows.Forms.RadioButton rd3;
        private System.Windows.Forms.RadioButton rd1;
        private System.Windows.Forms.RadioButton rd2;
        private System.Windows.Forms.RadioButton rd5;
        private System.Windows.Forms.RadioButton rd4;
        private System.Windows.Forms.Button btnTestCancelOrders;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotify;
        private System.Windows.Forms.ToolStripMenuItem conMenuNotiShow;
        private System.Windows.Forms.ToolStripMenuItem conMenuNotiRunThreads;
        private System.Windows.Forms.ToolStripMenuItem conMenuNotiStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem conMenuNotiRestart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem conMenuNotiExit;
        private System.Windows.Forms.Button btnOrderPicker;
    }
}

