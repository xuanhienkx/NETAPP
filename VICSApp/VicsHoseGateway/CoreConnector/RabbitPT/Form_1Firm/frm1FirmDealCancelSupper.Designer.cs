namespace HOGW_PT_Dealer
{
    partial class frm1FirmDealCancelSupper
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
            this.btnDisapprove = new DevExpress.XtraEditors.SimpleButton();
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
            // btnApprove
            // 
            this.btnApprove.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApprove.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnApprove.Appearance.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnApprove.Appearance.Options.UseBackColor = true;
            this.btnApprove.Appearance.Options.UseForeColor = true;
            this.btnApprove.Location = new System.Drawing.Point(257, 492);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(147, 27);
            this.btnApprove.TabIndex = 67;
            this.btnApprove.Text = "&Hủy";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
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
            this.btnSelectAll.Location = new System.Drawing.Point(140, 492);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(84, 27);
            this.btnSelectAll.TabIndex = 69;
            this.btnSelectAll.Text = "Chọn &tất cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDisapprove
            // 
            this.btnDisapprove.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnDisapprove.Appearance.Options.UseForeColor = true;
            this.btnDisapprove.Location = new System.Drawing.Point(445, 492);
            this.btnDisapprove.Name = "btnDisapprove";
            this.btnDisapprove.Size = new System.Drawing.Size(139, 27);
            this.btnDisapprove.TabIndex = 70;
            this.btnDisapprove.Text = "Từ chố&i";
            this.btnDisapprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 492);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 27);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = "&Cập nhật danh sách";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frm1FirmDealCancelSupper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 531);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDisapprove);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.grdData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm1FirmDealCancelSupper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyệt hoặc từ chối lệnh hủy \"Lệnh cùng công ty\" - cho Kiểm soát";
            this.Load += new System.EventHandler(this.frm2FirmDealApprove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnDisapprove;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}