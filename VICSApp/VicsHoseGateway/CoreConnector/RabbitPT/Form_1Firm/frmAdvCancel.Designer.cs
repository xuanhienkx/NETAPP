namespace HOGW_PT_Dealer
{
    partial class frmAdvCancel
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
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCancelAdv = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.EmbeddedNavigator.Name = "";
            this.grdData.Location = new System.Drawing.Point(12, 12);
            this.grdData.LookAndFeel.SkinName = "Black";
            this.grdData.MainView = this.gridView1;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(863, 463);
            this.grdData.TabIndex = 66;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            // 
            // btnCancelAdv
            // 
            this.btnCancelAdv.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCancelAdv.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnCancelAdv.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnCancelAdv.Appearance.Options.UseBackColor = true;
            this.btnCancelAdv.Appearance.Options.UseForeColor = true;
            this.btnCancelAdv.Location = new System.Drawing.Point(257, 492);
            this.btnCancelAdv.Name = "btnCancelAdv";
            this.btnCancelAdv.Size = new System.Drawing.Size(163, 27);
            this.btnCancelAdv.TabIndex = 67;
            this.btnCancelAdv.Text = "Hủy lệnh quảng cáo đã chọn";
            this.btnCancelAdv.Click += new System.EventHandler(this.btnSendCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(740, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 27);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "&Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(148, 492);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(84, 27);
            this.btnSelectAll.TabIndex = 69;
            this.btnSelectAll.Text = "Chọn &tất cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 492);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 27);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = "&Cập nhật danh sách";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmAdvCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 531);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancelAdv);
            this.Controls.Add(this.grdData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAdvCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyệt hoặc từ chối lệnh hủy cho \"Lệnh mua bán cùng công ty\"  - cho Broker";
            this.Load += new System.EventHandler(this.frm2FirmDealApprove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraEditors.SimpleButton btnCancelAdv;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}