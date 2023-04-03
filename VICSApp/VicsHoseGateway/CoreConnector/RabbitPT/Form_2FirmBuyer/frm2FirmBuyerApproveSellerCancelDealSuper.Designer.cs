namespace HOGW_PT_Dealer
{
    partial class frm2FirmBuyerApproveSellerCancelDealSuper
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
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.cboApproveType = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisapprove = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.EmbeddedNavigator.Name = "";
            this.grdData.Location = new System.Drawing.Point(12, 40);
            this.grdData.LookAndFeel.SkinName = "Black";
            this.grdData.MainView = this.gridView1;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(923, 435);
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
            // btnApprove
            // 
            this.btnApprove.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApprove.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnApprove.Appearance.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnApprove.Appearance.Options.UseBackColor = true;
            this.btnApprove.Appearance.Options.UseForeColor = true;
            this.btnApprove.Location = new System.Drawing.Point(280, 492);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(147, 27);
            this.btnApprove.TabIndex = 67;
            this.btnApprove.Text = "&Hủy";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(801, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 27);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "&Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(156, 492);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(105, 27);
            this.btnSelectAll.TabIndex = 69;
            this.btnSelectAll.Text = "Chọn &tất cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cboApproveType
            // 
            this.cboApproveType.FormattingEnabled = true;
            this.cboApproveType.Location = new System.Drawing.Point(40, 13);
            this.cboApproveType.Name = "cboApproveType";
            this.cboApproveType.Size = new System.Drawing.Size(172, 21);
            this.cboApproveType.TabIndex = 76;
            this.cboApproveType.SelectedIndexChanged += new System.EventHandler(this.cboApproveType_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(19, 13);
            this.labelControl1.TabIndex = 75;
            this.labelControl1.Text = "Loại";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(15, 492);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(122, 27);
            this.btnRefresh.TabIndex = 77;
            this.btnRefresh.Text = "&Cập nhật danh sách";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDisapprove
            // 
            this.btnDisapprove.Appearance.BackColor = System.Drawing.Color.White;
            this.btnDisapprove.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnDisapprove.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnDisapprove.Appearance.Options.UseBackColor = true;
            this.btnDisapprove.Appearance.Options.UseForeColor = true;
            this.btnDisapprove.Location = new System.Drawing.Point(473, 492);
            this.btnDisapprove.Name = "btnDisapprove";
            this.btnDisapprove.Size = new System.Drawing.Size(147, 27);
            this.btnDisapprove.TabIndex = 78;
            this.btnDisapprove.Text = "Từ chố&i";
            this.btnDisapprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // frm2FirmBuyerApproveSellerCancelDealSuper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 531);
            this.Controls.Add(this.btnDisapprove);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboApproveType);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.grdData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm2FirmBuyerApproveSellerCancelDealSuper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyệt lệnh hủy từ bên BÁN - cho kiểm soát";
            this.Load += new System.EventHandler(this.frm2FirmDealApprove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ComboBox cboApproveType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDisapprove;
    }
}