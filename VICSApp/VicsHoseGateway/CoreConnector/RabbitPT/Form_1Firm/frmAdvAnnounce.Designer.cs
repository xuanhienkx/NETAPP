namespace HOGW_PT_Dealer
{
    partial class frmAdvAnnounce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvAnnounce));
            this.lvAdvBuyReceived = new System.Windows.Forms.ListView();
            this.timerAdvReceived = new System.Windows.Forms.Timer(this.components);
            this.lvAdvSellReceived = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerRefreshData = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.udAutoRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAutoRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvAdvBuyReceived
            // 
            this.lvAdvBuyReceived.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lvAdvBuyReceived.ForeColor = System.Drawing.SystemColors.Window;
            this.lvAdvBuyReceived.FullRowSelect = true;
            this.lvAdvBuyReceived.GridLines = true;
            this.lvAdvBuyReceived.HideSelection = false;
            this.lvAdvBuyReceived.Location = new System.Drawing.Point(12, 496);
            this.lvAdvBuyReceived.Name = "lvAdvBuyReceived";
            this.lvAdvBuyReceived.Size = new System.Drawing.Size(513, 153);
            this.lvAdvBuyReceived.TabIndex = 0;
            this.lvAdvBuyReceived.UseCompatibleStateImageBehavior = false;
            this.lvAdvBuyReceived.View = System.Windows.Forms.View.Details;
            // 
            // timerAdvReceived
            // 
            this.timerAdvReceived.Interval = 5000;
            this.timerAdvReceived.Tick += new System.EventHandler(this.timerAdvReceived_Tick);
            // 
            // lvAdvSellReceived
            // 
            this.lvAdvSellReceived.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lvAdvSellReceived.ForeColor = System.Drawing.SystemColors.Window;
            this.lvAdvSellReceived.FullRowSelect = true;
            this.lvAdvSellReceived.GridLines = true;
            this.lvAdvSellReceived.HideSelection = false;
            this.lvAdvSellReceived.Location = new System.Drawing.Point(531, 496);
            this.lvAdvSellReceived.Name = "lvAdvSellReceived";
            this.lvAdvSellReceived.Size = new System.Drawing.Size(497, 153);
            this.lvAdvSellReceived.TabIndex = 1;
            this.lvAdvSellReceived.UseCompatibleStateImageBehavior = false;
            this.lvAdvSellReceived.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(13, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "BÊN MUA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(536, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "BÊN BÁN";
            // 
            // timerRefreshData
            // 
            this.timerRefreshData.Interval = 1000;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.udAutoRefreshInterval);
            this.groupBox1.Controls.Add(this.chkAutoRefresh);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Location = new System.Drawing.Point(12, 430);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 37);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "giây";
            // 
            // udAutoRefreshInterval
            // 
            this.udAutoRefreshInterval.Location = new System.Drawing.Point(242, 9);
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
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Location = new System.Drawing.Point(150, 12);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(86, 17);
            this.chkAutoRefresh.TabIndex = 72;
            this.chkAutoRefresh.Text = "Tự động sau";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(135, 23);
            this.btnRefresh.TabIndex = 68;
            this.btnRefresh.Text = "Cập nhật danh sách";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(146, 12);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(882, 416);
            this.gridControl1.TabIndex = 77;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 416);
            this.panel1.TabIndex = 76;
            // 
            // frmAdvAnnounce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 654);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvAdvSellReceived);
            this.Controls.Add(this.lvAdvBuyReceived);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdvAnnounce";
            this.Text = "Lệnh quảng cáo của tất cả các công ty từ HOSE";
            this.Load += new System.EventHandler(this.PTLiveBoard_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PTLiveBoard_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAutoRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAdvBuyReceived;
        private System.Windows.Forms.Timer timerAdvReceived;
        private System.Windows.Forms.ListView lvAdvSellReceived;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerRefreshData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udAutoRefreshInterval;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panel1;
    }
}