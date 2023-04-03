namespace HOGW_PT_Dealer
{
    partial class frm2FirmBuyerBrowseDeals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2FirmBuyerBrowseDeals));
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.udAutoRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.timerRefreshData = new System.Windows.Forms.Timer(this.components);
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAutoRefreshInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.EmbeddedNavigator.Name = "";
            this.grdData.Location = new System.Drawing.Point(12, 46);
            this.grdData.LookAndFeel.SkinName = "Black";
            this.grdData.MainView = this.gridView1;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1022, 516);
            this.grdData.TabIndex = 66;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(900, 582);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 27);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "&Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.udAutoRefreshInterval);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.chkAutoRefresh);
            this.groupBox1.Location = new System.Drawing.Point(12, 568);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 42);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "giây";
            // 
            // udAutoRefreshInterval
            // 
            this.udAutoRefreshInterval.Location = new System.Drawing.Point(254, 14);
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(133, 27);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = "&Cập nhật danh sách";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Location = new System.Drawing.Point(155, 16);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(86, 17);
            this.chkAutoRefresh.TabIndex = 72;
            this.chkAutoRefresh.Text = "Tự động sau";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // timerRefreshData
            // 
            this.timerRefreshData.Interval = 1000;
            this.timerRefreshData.Tick += new System.EventHandler(this.timerRefreshData_Tick);
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(90, 12);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(330, 21);
            this.cboStatus.TabIndex = 92;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(13, 15);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 91;
            this.label25.Text = "Trạng thái";
            // 
            // frm2FirmBuyerBrowseDeals
            // 
            this.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 623);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm2FirmBuyerBrowseDeals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lệnh thỏa thuận - bên MUA";
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
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown udAutoRefreshInterval;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Timer timerRefreshData;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label25;
    }
}