namespace BrokerageGatewayManager
{
    partial class LiveLogsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveLogsForm));
            this.turnOffLiveLogs = new System.Windows.Forms.Button();
            this.turnOnLiveLogs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstCTCILogs = new System.Windows.Forms.ListBox();
            this.btnTurnOnCTCILogs = new System.Windows.Forms.Button();
            this.btnStopViewCTCILogs = new System.Windows.Forms.Button();
            this.btnClearCTCILogs = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstBroadcastLogs = new System.Windows.Forms.ListBox();
            this.btnTurnOnBroadcastLogs = new System.Windows.Forms.Button();
            this.btnStopViewBroadcastLogs = new System.Windows.Forms.Button();
            this.btnClearBroadcastLogs = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdCTCIDetails = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grdBroadcastDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numCTCITLogSize = new System.Windows.Forms.NumericUpDown();
            this.numBroadcastLogSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNumberOfSentMessages = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNumberOfReceivedMessages = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNumberOfBroadcastMessages = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCTCIDetails)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBroadcastDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCTCITLogSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBroadcastLogSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // turnOffLiveLogs
            // 
            this.turnOffLiveLogs.BackColor = System.Drawing.Color.Red;
            this.turnOffLiveLogs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.turnOffLiveLogs.Location = new System.Drawing.Point(5, 642);
            this.turnOffLiveLogs.Name = "turnOffLiveLogs";
            this.turnOffLiveLogs.Size = new System.Drawing.Size(142, 32);
            this.turnOffLiveLogs.TabIndex = 6;
            this.turnOffLiveLogs.Text = "Tắt chế độ Live Logs";
            this.turnOffLiveLogs.UseVisualStyleBackColor = false;
            this.turnOffLiveLogs.Click += new System.EventHandler(this.turnOffLiveLogs_Click);
            // 
            // turnOnLiveLogs
            // 
            this.turnOnLiveLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.turnOnLiveLogs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.turnOnLiveLogs.Location = new System.Drawing.Point(153, 642);
            this.turnOnLiveLogs.Name = "turnOnLiveLogs";
            this.turnOnLiveLogs.Size = new System.Drawing.Size(148, 32);
            this.turnOnLiveLogs.TabIndex = 7;
            this.turnOnLiveLogs.Text = "Bật chế độ Live Logs";
            this.turnOnLiveLogs.UseVisualStyleBackColor = false;
            this.turnOnLiveLogs.Click += new System.EventHandler(this.turnOnLiveLogs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstCTCILogs);
            this.groupBox1.Controls.Add(this.btnTurnOnCTCILogs);
            this.groupBox1.Controls.Add(this.btnStopViewCTCILogs);
            this.groupBox1.Controls.Add(this.btnClearCTCILogs);
            this.groupBox1.Location = new System.Drawing.Point(5, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 275);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông điệp CTCI";
            // 
            // lstCTCILogs
            // 
            this.lstCTCILogs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCTCILogs.ForeColor = System.Drawing.Color.Red;
            this.lstCTCILogs.FormattingEnabled = true;
            this.lstCTCILogs.Location = new System.Drawing.Point(8, 19);
            this.lstCTCILogs.Name = "lstCTCILogs";
            this.lstCTCILogs.Size = new System.Drawing.Size(378, 212);
            this.lstCTCILogs.TabIndex = 7;
            this.lstCTCILogs.SelectedIndexChanged += new System.EventHandler(this.lstCTCILogs_SelectedIndexChanged);
            // 
            // btnTurnOnCTCILogs
            // 
            this.btnTurnOnCTCILogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTurnOnCTCILogs.Location = new System.Drawing.Point(89, 244);
            this.btnTurnOnCTCILogs.Name = "btnTurnOnCTCILogs";
            this.btnTurnOnCTCILogs.Size = new System.Drawing.Size(75, 23);
            this.btnTurnOnCTCILogs.TabIndex = 6;
            this.btnTurnOnCTCILogs.Text = "Tiếp tục";
            this.btnTurnOnCTCILogs.UseVisualStyleBackColor = false;
            this.btnTurnOnCTCILogs.Click += new System.EventHandler(this.btnTurnOnCTCILogs_Click);
            // 
            // btnStopViewCTCILogs
            // 
            this.btnStopViewCTCILogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStopViewCTCILogs.Enabled = false;
            this.btnStopViewCTCILogs.Location = new System.Drawing.Point(8, 244);
            this.btnStopViewCTCILogs.Name = "btnStopViewCTCILogs";
            this.btnStopViewCTCILogs.Size = new System.Drawing.Size(75, 23);
            this.btnStopViewCTCILogs.TabIndex = 4;
            this.btnStopViewCTCILogs.Text = "Tạm dừng";
            this.btnStopViewCTCILogs.UseVisualStyleBackColor = false;
            this.btnStopViewCTCILogs.Click += new System.EventHandler(this.btnStopViewCTCILogs_Click);
            // 
            // btnClearCTCILogs
            // 
            this.btnClearCTCILogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearCTCILogs.Location = new System.Drawing.Point(311, 244);
            this.btnClearCTCILogs.Name = "btnClearCTCILogs";
            this.btnClearCTCILogs.Size = new System.Drawing.Size(75, 23);
            this.btnClearCTCILogs.TabIndex = 3;
            this.btnClearCTCILogs.Text = "Xóa Logs";
            this.btnClearCTCILogs.UseVisualStyleBackColor = false;
            this.btnClearCTCILogs.Click += new System.EventHandler(this.btnClearCTCILogs_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstBroadcastLogs);
            this.groupBox2.Controls.Add(this.btnTurnOnBroadcastLogs);
            this.groupBox2.Controls.Add(this.btnStopViewBroadcastLogs);
            this.groupBox2.Controls.Add(this.btnClearBroadcastLogs);
            this.groupBox2.Location = new System.Drawing.Point(403, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 275);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông điệp Broadcast";
            // 
            // lstBroadcastLogs
            // 
            this.lstBroadcastLogs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBroadcastLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lstBroadcastLogs.FormattingEnabled = true;
            this.lstBroadcastLogs.Location = new System.Drawing.Point(6, 19);
            this.lstBroadcastLogs.Name = "lstBroadcastLogs";
            this.lstBroadcastLogs.Size = new System.Drawing.Size(373, 212);
            this.lstBroadcastLogs.TabIndex = 9;
            this.lstBroadcastLogs.SelectedIndexChanged += new System.EventHandler(this.lstBroadcastLogs_SelectedIndexChanged);
            // 
            // btnTurnOnBroadcastLogs
            // 
            this.btnTurnOnBroadcastLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTurnOnBroadcastLogs.Location = new System.Drawing.Point(87, 244);
            this.btnTurnOnBroadcastLogs.Name = "btnTurnOnBroadcastLogs";
            this.btnTurnOnBroadcastLogs.Size = new System.Drawing.Size(75, 23);
            this.btnTurnOnBroadcastLogs.TabIndex = 8;
            this.btnTurnOnBroadcastLogs.Text = "Tiếp tục";
            this.btnTurnOnBroadcastLogs.UseVisualStyleBackColor = false;
            this.btnTurnOnBroadcastLogs.Click += new System.EventHandler(this.btnTurnOnBroadcastLogs_Click);
            // 
            // btnStopViewBroadcastLogs
            // 
            this.btnStopViewBroadcastLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStopViewBroadcastLogs.Enabled = false;
            this.btnStopViewBroadcastLogs.Location = new System.Drawing.Point(6, 244);
            this.btnStopViewBroadcastLogs.Name = "btnStopViewBroadcastLogs";
            this.btnStopViewBroadcastLogs.Size = new System.Drawing.Size(75, 23);
            this.btnStopViewBroadcastLogs.TabIndex = 6;
            this.btnStopViewBroadcastLogs.Text = "Tạm dừng";
            this.btnStopViewBroadcastLogs.UseVisualStyleBackColor = false;
            this.btnStopViewBroadcastLogs.Click += new System.EventHandler(this.btnStopViewBroadcastLogs_Click);
            // 
            // btnClearBroadcastLogs
            // 
            this.btnClearBroadcastLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearBroadcastLogs.Location = new System.Drawing.Point(302, 244);
            this.btnClearBroadcastLogs.Name = "btnClearBroadcastLogs";
            this.btnClearBroadcastLogs.Size = new System.Drawing.Size(75, 23);
            this.btnClearBroadcastLogs.TabIndex = 5;
            this.btnClearBroadcastLogs.Text = "Xóa Logs";
            this.btnClearBroadcastLogs.UseVisualStyleBackColor = false;
            this.btnClearBroadcastLogs.Click += new System.EventHandler(this.btnClearBroadcastLogs_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdCTCIDetails);
            this.groupBox3.Location = new System.Drawing.Point(5, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 274);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết";
            // 
            // grdCTCIDetails
            // 
            this.grdCTCIDetails.AutoGenerateColumns = false;
            this.grdCTCIDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCTCIDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grdCTCIDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdCTCIDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCTCIDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.grdCTCIDetails.DataSource = this.messageBindingSource;
            this.grdCTCIDetails.Location = new System.Drawing.Point(8, 19);
            this.grdCTCIDetails.Name = "grdCTCIDetails";
            this.grdCTCIDetails.ReadOnly = true;
            this.grdCTCIDetails.RowHeadersVisible = false;
            this.grdCTCIDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCTCIDetails.Size = new System.Drawing.Size(378, 249);
            this.grdCTCIDetails.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grdBroadcastDetails);
            this.groupBox4.Location = new System.Drawing.Point(403, 362);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 274);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chi tiết";
            // 
            // grdBroadcastDetails
            // 
            this.grdBroadcastDetails.AutoGenerateColumns = false;
            this.grdBroadcastDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdBroadcastDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grdBroadcastDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdBroadcastDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBroadcastDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.grdBroadcastDetails.DataSource = this.messageBindingSource;
            this.grdBroadcastDetails.Location = new System.Drawing.Point(6, 19);
            this.grdBroadcastDetails.Name = "grdBroadcastDetails";
            this.grdBroadcastDetails.ReadOnly = true;
            this.grdBroadcastDetails.RowHeadersVisible = false;
            this.grdBroadcastDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBroadcastDetails.Size = new System.Drawing.Size(373, 249);
            this.grdBroadcastDetails.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Xem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "thông điệp CTCI gần đây nhất";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "thông điệp Broadcast gần đây nhất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Xem";
            // 
            // numCTCITLogSize
            // 
            this.numCTCITLogSize.Location = new System.Drawing.Point(40, 30);
            this.numCTCITLogSize.Name = "numCTCITLogSize";
            this.numCTCITLogSize.Size = new System.Drawing.Size(68, 20);
            this.numCTCITLogSize.TabIndex = 22;
            this.numCTCITLogSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numCTCITLogSize.ValueChanged += new System.EventHandler(this.numCTCITLogSize_ValueChanged);
            // 
            // numBroadcastLogSize
            // 
            this.numBroadcastLogSize.Location = new System.Drawing.Point(438, 30);
            this.numBroadcastLogSize.Name = "numBroadcastLogSize";
            this.numBroadcastLogSize.Size = new System.Drawing.Size(60, 20);
            this.numBroadcastLogSize.TabIndex = 23;
            this.numBroadcastLogSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numBroadcastLogSize.ValueChanged += new System.EventHandler(this.numBroadcastLogSize_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(5, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(762, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "Chức năng \"Xem Live Logs\" cho phép bạn theo dõi những thông điệp trao đổi giữa Ga" +
                "teway và HOSE theo thời gian thực.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Số thông điệp gửi đi:";
            // 
            // lblNumberOfSentMessages
            // 
            this.lblNumberOfSentMessages.AutoSize = true;
            this.lblNumberOfSentMessages.Location = new System.Drawing.Point(117, 65);
            this.lblNumberOfSentMessages.Name = "lblNumberOfSentMessages";
            this.lblNumberOfSentMessages.Size = new System.Drawing.Size(13, 13);
            this.lblNumberOfSentMessages.TabIndex = 26;
            this.lblNumberOfSentMessages.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Số thông điệp nhận được:";
            // 
            // lblNumberOfReceivedMessages
            // 
            this.lblNumberOfReceivedMessages.AutoSize = true;
            this.lblNumberOfReceivedMessages.Location = new System.Drawing.Point(307, 65);
            this.lblNumberOfReceivedMessages.Name = "lblNumberOfReceivedMessages";
            this.lblNumberOfReceivedMessages.Size = new System.Drawing.Size(13, 13);
            this.lblNumberOfReceivedMessages.TabIndex = 28;
            this.lblNumberOfReceivedMessages.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(404, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Số thông điệp Broadcast nhận được:";
            // 
            // lblNumberOfBroadcastMessages
            // 
            this.lblNumberOfBroadcastMessages.AutoSize = true;
            this.lblNumberOfBroadcastMessages.Location = new System.Drawing.Point(593, 65);
            this.lblNumberOfBroadcastMessages.Name = "lblNumberOfBroadcastMessages";
            this.lblNumberOfBroadcastMessages.Size = new System.Drawing.Size(13, 13);
            this.lblNumberOfBroadcastMessages.TabIndex = 30;
            this.lblNumberOfBroadcastMessages.Text = "0";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên thuộc tính";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn2.HeaderText = "Giá trị";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // messageBindingSource
            // 
            this.messageBindingSource.DataSource = typeof(BrokerageGatewayManager.Entities.Message);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Tên thuộc tính";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Giá trị";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // LiveLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(792, 678);
            this.Controls.Add(this.lblNumberOfBroadcastMessages);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblNumberOfReceivedMessages);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblNumberOfSentMessages);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numBroadcastLogSize);
            this.Controls.Add(this.numCTCITLogSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.turnOnLiveLogs);
            this.Controls.Add(this.turnOffLiveLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LiveLogsForm";
            this.Text = "Xem Live Logs";
            this.Load += new System.EventHandler(this.LiveLogsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiveLogsForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCTCIDetails)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBroadcastDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCTCITLogSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBroadcastLogSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button turnOffLiveLogs;
        private System.Windows.Forms.Button turnOnLiveLogs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStopViewCTCILogs;
        private System.Windows.Forms.Button btnClearCTCILogs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStopViewBroadcastLogs;
        private System.Windows.Forms.Button btnClearBroadcastLogs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView grdCTCIDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource messageBindingSource;
        private System.Windows.Forms.DataGridView grdBroadcastDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numCTCITLogSize;
        private System.Windows.Forms.NumericUpDown numBroadcastLogSize;
        private System.Windows.Forms.Button btnTurnOnCTCILogs;
        private System.Windows.Forms.Button btnTurnOnBroadcastLogs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstBroadcastLogs;
        private System.Windows.Forms.ListBox lstCTCILogs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNumberOfSentMessages;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNumberOfReceivedMessages;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNumberOfBroadcastMessages;
    }
}