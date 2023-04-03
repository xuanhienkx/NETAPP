namespace BrokerageGatewayManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblGatewayStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberOfMsgFromQueue = new System.Windows.Forms.Label();
            this.lblNumberOfMsgInsertedToDB = new System.Windows.Forms.Label();
            this.lblNumberOfMessageSentToBadQueue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumberOfSentMessages = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewLiveLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurrentMarketStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstGAMessages = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tmGAMsg = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGatewayStatus
            // 
            this.lblGatewayStatus.AutoSize = true;
            this.lblGatewayStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGatewayStatus.ForeColor = System.Drawing.Color.Red;
            this.lblGatewayStatus.Location = new System.Drawing.Point(221, 41);
            this.lblGatewayStatus.Name = "lblGatewayStatus";
            this.lblGatewayStatus.Size = new System.Drawing.Size(166, 14);
            this.lblGatewayStatus.TabIndex = 2;
            this.lblGatewayStatus.Text = "Gateway dừng hoạt động";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tổng số các messags nhận được từ Queue:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tổng số các message lưu thành công vào DB:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tổng số các message lưu vào Bad Queue:";
            // 
            // lblNumberOfMsgFromQueue
            // 
            this.lblNumberOfMsgFromQueue.AutoSize = true;
            this.lblNumberOfMsgFromQueue.Location = new System.Drawing.Point(241, 23);
            this.lblNumberOfMsgFromQueue.Name = "lblNumberOfMsgFromQueue";
            this.lblNumberOfMsgFromQueue.Size = new System.Drawing.Size(15, 14);
            this.lblNumberOfMsgFromQueue.TabIndex = 6;
            this.lblNumberOfMsgFromQueue.Text = "0";
            // 
            // lblNumberOfMsgInsertedToDB
            // 
            this.lblNumberOfMsgInsertedToDB.AutoSize = true;
            this.lblNumberOfMsgInsertedToDB.Location = new System.Drawing.Point(241, 55);
            this.lblNumberOfMsgInsertedToDB.Name = "lblNumberOfMsgInsertedToDB";
            this.lblNumberOfMsgInsertedToDB.Size = new System.Drawing.Size(15, 14);
            this.lblNumberOfMsgInsertedToDB.TabIndex = 7;
            this.lblNumberOfMsgInsertedToDB.Text = "0";
            // 
            // lblNumberOfMessageSentToBadQueue
            // 
            this.lblNumberOfMessageSentToBadQueue.AutoSize = true;
            this.lblNumberOfMessageSentToBadQueue.Location = new System.Drawing.Point(241, 87);
            this.lblNumberOfMessageSentToBadQueue.Name = "lblNumberOfMessageSentToBadQueue";
            this.lblNumberOfMessageSentToBadQueue.Size = new System.Drawing.Size(15, 14);
            this.lblNumberOfMessageSentToBadQueue.TabIndex = 8;
            this.lblNumberOfMessageSentToBadQueue.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(6, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tổng số message đã gửi:";
            // 
            // lblNumberOfSentMessages
            // 
            this.lblNumberOfSentMessages.AutoSize = true;
            this.lblNumberOfSentMessages.Location = new System.Drawing.Point(241, 118);
            this.lblNumberOfSentMessages.Name = "lblNumberOfSentMessages";
            this.lblNumberOfSentMessages.Size = new System.Drawing.Size(15, 14);
            this.lblNumberOfSentMessages.TabIndex = 10;
            this.lblNumberOfSentMessages.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTool,
            this.mnuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuStop,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.mnuFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mnuFile.Image = global::BrokerageGatewayManager.Properties.Resources.home;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(95, 20);
            this.mnuFile.Text = "Điều khiển";
            // 
            // mnuStart
            // 
            this.mnuStart.Image = global::BrokerageGatewayManager.Properties.Resources.StatusOnline;
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(117, 22);
            this.mnuStart.Text = "Bắt đầu";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.Enabled = false;
            this.mnuStop.Image = global::BrokerageGatewayManager.Properties.Resources.StatusDoNotDisturb;
            this.mnuStop.Name = "mnuStop";
            this.mnuStop.Size = new System.Drawing.Size(117, 22);
            this.mnuStop.Text = "Dừng";
            this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::BrokerageGatewayManager.Properties.Resources.delete;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(117, 22);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuTool
            // 
            this.mnuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewLiveLogs,
            this.mnuManageQueue});
            this.mnuTool.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuTool.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mnuTool.Image = global::BrokerageGatewayManager.Properties.Resources.TOOLICON;
            this.mnuTool.Name = "mnuTool";
            this.mnuTool.Size = new System.Drawing.Size(79, 20);
            this.mnuTool.Text = "Công cụ";
            // 
            // mnuViewLiveLogs
            // 
            this.mnuViewLiveLogs.Image = global::BrokerageGatewayManager.Properties.Resources.REFBARH;
            this.mnuViewLiveLogs.Name = "mnuViewLiveLogs";
            this.mnuViewLiveLogs.Size = new System.Drawing.Size(155, 22);
            this.mnuViewLiveLogs.Text = "Xem Live Logs";
            this.mnuViewLiveLogs.Click += new System.EventHandler(this.mnuViewLiveLogs_Click);
            // 
            // mnuManageQueue
            // 
            this.mnuManageQueue.Image = global::BrokerageGatewayManager.Properties.Resources.NOTEL;
            this.mnuManageQueue.Name = "mnuManageQueue";
            this.mnuManageQueue.Size = new System.Drawing.Size(155, 22);
            this.mnuManageQueue.Text = "Quản lý Queue";
            this.mnuManageQueue.Click += new System.EventHandler(this.mnuManageQueue_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(72, 20);
            this.mnuAbout.Text = "Giới thiệu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "Trạng thái hiện tại của Gateway:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNumberOfSentMessages);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNumberOfMsgFromQueue);
            this.groupBox1.Controls.Add(this.lblNumberOfMessageSentToBadQueue);
            this.groupBox1.Controls.Add(this.lblNumberOfMsgInsertedToDB);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 170);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStart.Location = new System.Drawing.Point(12, 68);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 23);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Bật";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(107, 68);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 23);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "Dừng";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(9, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 14);
            this.label6.TabIndex = 25;
            this.label6.Text = "Trạng thái thị trường";
            // 
            // lblCurrentMarketStatus
            // 
            this.lblCurrentMarketStatus.AutoSize = true;
            this.lblCurrentMarketStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCurrentMarketStatus.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentMarketStatus.Location = new System.Drawing.Point(154, 290);
            this.lblCurrentMarketStatus.Name = "lblCurrentMarketStatus";
            this.lblCurrentMarketStatus.Size = new System.Drawing.Size(16, 15);
            this.lblCurrentMarketStatus.TabIndex = 26;
            this.lblCurrentMarketStatus.Text = "P";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstGAMessages);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(312, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 204);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông điệp GA từ HOSE (Hôm nay)";
            // 
            // lstGAMessages
            // 
            this.lstGAMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstGAMessages.FormattingEnabled = true;
            this.lstGAMessages.HorizontalScrollbar = true;
            this.lstGAMessages.ItemHeight = 14;
            this.lstGAMessages.Location = new System.Drawing.Point(6, 21);
            this.lstGAMessages.Name = "lstGAMessages";
            this.lstGAMessages.Size = new System.Drawing.Size(268, 170);
            this.lstGAMessages.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Location = new System.Drawing.Point(532, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tmGAMsg
            // 
            this.tmGAMsg.Tick += new System.EventHandler(this.tmGAMsg_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(604, 339);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblCurrentMarketStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblGatewayStatus);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RabbitTrade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGatewayStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumberOfMsgFromQueue;
        private System.Windows.Forms.Label lblNumberOfMsgInsertedToDB;
        private System.Windows.Forms.Label lblNumberOfMessageSentToBadQueue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumberOfSentMessages;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuTool;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuViewLiveLogs;
        private System.Windows.Forms.ToolStripMenuItem mnuManageQueue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCurrentMarketStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstGAMessages;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer tmGAMsg;
    }
}

