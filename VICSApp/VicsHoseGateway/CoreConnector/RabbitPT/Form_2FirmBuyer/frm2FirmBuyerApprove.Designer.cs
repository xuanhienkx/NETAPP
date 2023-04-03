namespace HOGW_PT_Dealer
{
    partial class frm2FirmBuyerApprove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2FirmBuyerApprove));
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisapprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.timerRefreshData = new System.Windows.Forms.Timer(this.components);
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.udAutoRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.cboBuyerClientID = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblBuyerAvailBalance = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblBuyerBalance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkLoadFromCore = new System.Windows.Forms.CheckBox();
            this.btnLoadClients = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRefresh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAutoRefreshInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.EmbeddedNavigator.Name = "";
            this.grdData.Location = new System.Drawing.Point(12, 69);
            this.grdData.LookAndFeel.SkinName = "Black";
            this.grdData.MainView = this.gridView1;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1001, 441);
            this.grdData.TabIndex = 66;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // btnApprove
            // 
            this.btnApprove.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApprove.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnApprove.Appearance.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnApprove.Appearance.Options.UseBackColor = true;
            this.btnApprove.Appearance.Options.UseForeColor = true;
            this.btnApprove.Location = new System.Drawing.Point(438, 528);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(147, 27);
            this.btnApprove.TabIndex = 67;
            this.btnApprove.Text = "&Duyệt";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(904, 528);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "&Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(309, 528);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(94, 27);
            this.btnSelectAll.TabIndex = 69;
            this.btnSelectAll.Text = "Chọn &tất cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDisapprove
            // 
            this.btnDisapprove.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnDisapprove.Appearance.Options.UseForeColor = true;
            this.btnDisapprove.Location = new System.Drawing.Point(622, 528);
            this.btnDisapprove.Name = "btnDisapprove";
            this.btnDisapprove.Size = new System.Drawing.Size(139, 27);
            this.btnDisapprove.TabIndex = 70;
            this.btnDisapprove.Text = "Từ chố&i";
            this.btnDisapprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 27);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = "Cập nhật danh sách";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // timerRefreshData
            // 
            this.timerRefreshData.Interval = 5000;
            this.timerRefreshData.Tick += new System.EventHandler(this.timerRefreshData_Tick);
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Location = new System.Drawing.Point(120, 15);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(86, 17);
            this.chkAutoRefresh.TabIndex = 72;
            this.chkAutoRefresh.Text = "Tự động sau";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.udAutoRefreshInterval);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.chkAutoRefresh);
            this.groupBox1.Location = new System.Drawing.Point(13, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 42);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "giây";
            // 
            // udAutoRefreshInterval
            // 
            this.udAutoRefreshInterval.Location = new System.Drawing.Point(209, 13);
            this.udAutoRefreshInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udAutoRefreshInterval.Name = "udAutoRefreshInterval";
            this.udAutoRefreshInterval.Size = new System.Drawing.Size(51, 20);
            this.udAutoRefreshInterval.TabIndex = 73;
            this.udAutoRefreshInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // cboBuyerClientID
            // 
            this.cboBuyerClientID.FormattingEnabled = true;
            this.cboBuyerClientID.Location = new System.Drawing.Point(124, 17);
            this.cboBuyerClientID.Name = "cboBuyerClientID";
            this.cboBuyerClientID.Size = new System.Drawing.Size(330, 21);
            this.cboBuyerClientID.TabIndex = 90;
            this.cboBuyerClientID.SelectedIndexChanged += new System.EventHandler(this.cboBuyerClientID_SelectedIndexChanged);
            this.cboBuyerClientID.Leave += new System.EventHandler(this.cboBuyerClientID_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(0, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(122, 13);
            this.label25.TabIndex = 89;
            this.label25.Text = "Mã khách hàng mua";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(460, 38);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(97, 13);
            this.label20.TabIndex = 95;
            this.label20.Text = "Số dư khả dụng";
            // 
            // lblBuyerAvailBalance
            // 
            this.lblBuyerAvailBalance.AutoSize = true;
            this.lblBuyerAvailBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerAvailBalance.ForeColor = System.Drawing.Color.Sienna;
            this.lblBuyerAvailBalance.Location = new System.Drawing.Point(595, 38);
            this.lblBuyerAvailBalance.Name = "lblBuyerAvailBalance";
            this.lblBuyerAvailBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBuyerAvailBalance.Size = new System.Drawing.Size(85, 13);
            this.lblBuyerAvailBalance.TabIndex = 94;
            this.lblBuyerAvailBalance.Text = "Avail Balance";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label22.Location = new System.Drawing.Point(720, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 93;
            this.label22.Text = "(VND)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(460, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 13);
            this.label23.TabIndex = 92;
            this.label23.Text = "Số dư tiền";
            // 
            // lblBuyerBalance
            // 
            this.lblBuyerBalance.AutoSize = true;
            this.lblBuyerBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerBalance.ForeColor = System.Drawing.Color.Sienna;
            this.lblBuyerBalance.Location = new System.Drawing.Point(595, 20);
            this.lblBuyerBalance.Name = "lblBuyerBalance";
            this.lblBuyerBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBuyerBalance.Size = new System.Drawing.Size(85, 13);
            this.lblBuyerBalance.TabIndex = 91;
            this.lblBuyerBalance.Text = "Cash Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(472, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "Chỉ hiển thị các lệnh gửi đến cho Trader với Username đã đăng nhập";
            // 
            // chkLoadFromCore
            // 
            this.chkLoadFromCore.AutoSize = true;
            this.chkLoadFromCore.Location = new System.Drawing.Point(124, 46);
            this.chkLoadFromCore.Name = "chkLoadFromCore";
            this.chkLoadFromCore.Size = new System.Drawing.Size(170, 17);
            this.chkLoadFromCore.TabIndex = 98;
            this.chkLoadFromCore.Text = "Lấy danh sách KH từ core SBS";
            this.chkLoadFromCore.UseVisualStyleBackColor = true;
            this.chkLoadFromCore.CheckedChanged += new System.EventHandler(this.chkLoadFromCore_CheckedChanged);
            // 
            // btnLoadClients
            // 
            this.btnLoadClients.Location = new System.Drawing.Point(309, 42);
            this.btnLoadClients.Name = "btnLoadClients";
            this.btnLoadClients.Size = new System.Drawing.Size(100, 23);
            this.btnLoadClients.TabIndex = 97;
            this.btnLoadClients.Text = "Thực hiện";
            this.btnLoadClients.UseVisualStyleBackColor = true;
            this.btnLoadClients.Click += new System.EventHandler(this.btnLoadClients_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(720, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "(VND)";
            // 
            // lbRefresh
            // 
            this.lbRefresh.AutoSize = true;
            this.lbRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRefresh.Location = new System.Drawing.Point(773, 535);
            this.lbRefresh.Name = "lbRefresh";
            this.lbRefresh.Size = new System.Drawing.Size(124, 13);
            this.lbRefresh.TabIndex = 100;
            this.lbRefresh.Text = "Tự động cập nhật: 0";
            // 
            // frm2FirmBuyerApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 567);
            this.Controls.Add(this.lbRefresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkLoadFromCore);
            this.Controls.Add(this.btnLoadClients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblBuyerAvailBalance);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lblBuyerBalance);
            this.Controls.Add(this.cboBuyerClientID);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDisapprove);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.grdData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm2FirmBuyerApprove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyệt các lệnh từ bên bán - dành cho Broker";
            this.Load += new System.EventHandler(this.frm2FirmDealApprove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAutoRefreshInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnDisapprove;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.Timer timerRefreshData;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown udAutoRefreshInterval;
        private System.Windows.Forms.ComboBox cboBuyerClientID;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblBuyerAvailBalance;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblBuyerBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkLoadFromCore;
        private System.Windows.Forms.Button btnLoadClients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRefresh;
    }
}