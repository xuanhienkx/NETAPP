namespace VRMApp.Brokerage
{
   partial class CustomerListForm
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
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.maKHBox = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         this.nvchamsoccb = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
         this.dataGridView = new System.Windows.Forms.DataGridView();
         this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.branchCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tradeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.MarginRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.telephoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.mobilePhone1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.mobilePhone2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.takeCareUserNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.introduceUserNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.IsSpecial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.mainPanel.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
         this.SuspendLayout();
         // 
         // mainPanel
         // 
         this.mainPanel.Controls.Add(this.dataGridView);
         this.mainPanel.Controls.Add(this.toolStrip1);
         this.mainPanel.Size = new System.Drawing.Size(1026, 634);
         // 
         // backgroundWorker
         // 
         this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
         this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.maKHBox,
            this.toolStripLabel2,
            this.nvchamsoccb,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripButton4});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(1026, 25);
         this.toolStrip1.TabIndex = 0;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
         this.toolStripLabel1.Text = "Mã KH:";
         // 
         // maKHBox
         // 
         this.maKHBox.Name = "maKHBox";
         this.maKHBox.Size = new System.Drawing.Size(100, 25);
         // 
         // toolStripLabel2
         // 
         this.toolStripLabel2.Name = "toolStripLabel2";
         this.toolStripLabel2.Size = new System.Drawing.Size(77, 22);
         this.toolStripLabel2.Text = "NV chăm sóc";
         // 
         // nvchamsoccb
         // 
         this.nvchamsoccb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.nvchamsoccb.Name = "nvchamsoccb";
         this.nvchamsoccb.Size = new System.Drawing.Size(121, 25);
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Image = global::VRMApp.Properties.Resources.find;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
         this.toolStripButton1.Text = "&Tìm";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton2
         // 
         this.toolStripButton2.Enabled = false;
         this.toolStripButton2.Image = global::VRMApp.Properties.Resources._lock;
         this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton2.Name = "toolStripButton2";
         this.toolStripButton2.Size = new System.Drawing.Size(197, 22);
         this.toolStripButton2.Text = "Đưa vào DS khách hàng đặc biệt";
         this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton3
         // 
         this.toolStripButton3.Enabled = false;
         this.toolStripButton3.Image = global::VRMApp.Properties.Resources.lock_unlock;
         this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton3.Name = "toolStripButton3";
         this.toolStripButton3.Size = new System.Drawing.Size(202, 22);
         this.toolStripButton3.Text = "Loại khỏi DS khách hàng đặc biệt";
         this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton4
         // 
         this.toolStripButton4.Enabled = false;
         this.toolStripButton4.Image = global::VRMApp.Properties.Resources.filter;
         this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton4.Name = "toolStripButton4";
         this.toolStripButton4.Size = new System.Drawing.Size(138, 22);
         this.toolStripButton4.Text = "Lọc ra ds KH đặc biệt";
         this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
         // 
         // dataGridView
         // 
         this.dataGridView.AllowUserToAddRows = false;
         this.dataGridView.AllowUserToDeleteRows = false;
         this.dataGridView.AutoGenerateColumns = false;
         this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIdDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.branchCodeDataGridViewTextBoxColumn,
            this.tradeCodeDataGridViewTextBoxColumn,
            this.MarginRate,
            this.telephoneDataGridViewTextBoxColumn,
            this.mobilePhone1DataGridViewTextBoxColumn,
            this.mobilePhone2DataGridViewTextBoxColumn,
            this.takeCareUserNameDataGridViewTextBoxColumn,
            this.introduceUserNameDataGridViewTextBoxColumn,
            this.IsSpecial});
         this.dataGridView.DataSource = this.customerBindingSource;
         this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView.Location = new System.Drawing.Point(0, 25);
         this.dataGridView.Name = "dataGridView";
         this.dataGridView.ReadOnly = true;
         this.dataGridView.Size = new System.Drawing.Size(1026, 609);
         this.dataGridView.TabIndex = 1;
         this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
         // 
         // customerIdDataGridViewTextBoxColumn
         // 
         this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
         this.customerIdDataGridViewTextBoxColumn.HeaderText = "Mã KH";
         this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
         this.customerIdDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // customerNameDataGridViewTextBoxColumn
         // 
         this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
         this.customerNameDataGridViewTextBoxColumn.HeaderText = "Tên KH";
         this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
         this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // branchCodeDataGridViewTextBoxColumn
         // 
         this.branchCodeDataGridViewTextBoxColumn.DataPropertyName = "BranchCode";
         this.branchCodeDataGridViewTextBoxColumn.HeaderText = "Mã đơn vị";
         this.branchCodeDataGridViewTextBoxColumn.Name = "branchCodeDataGridViewTextBoxColumn";
         this.branchCodeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // tradeCodeDataGridViewTextBoxColumn
         // 
         this.tradeCodeDataGridViewTextBoxColumn.DataPropertyName = "TradeCode";
         this.tradeCodeDataGridViewTextBoxColumn.HeaderText = "Mã giao dịch";
         this.tradeCodeDataGridViewTextBoxColumn.Name = "tradeCodeDataGridViewTextBoxColumn";
         this.tradeCodeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // MarginRate
         // 
         this.MarginRate.DataPropertyName = "MarginRate";
         this.MarginRate.HeaderText = "Tỷ lệ hợp tác  (%)";
         this.MarginRate.Name = "MarginRate";
         this.MarginRate.ReadOnly = true;
         // 
         // telephoneDataGridViewTextBoxColumn
         // 
         this.telephoneDataGridViewTextBoxColumn.DataPropertyName = "Telephone";
         this.telephoneDataGridViewTextBoxColumn.HeaderText = "Điện thoại";
         this.telephoneDataGridViewTextBoxColumn.Name = "telephoneDataGridViewTextBoxColumn";
         this.telephoneDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // mobilePhone1DataGridViewTextBoxColumn
         // 
         this.mobilePhone1DataGridViewTextBoxColumn.DataPropertyName = "MobilePhone1";
         this.mobilePhone1DataGridViewTextBoxColumn.HeaderText = "Di động 1";
         this.mobilePhone1DataGridViewTextBoxColumn.Name = "mobilePhone1DataGridViewTextBoxColumn";
         this.mobilePhone1DataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // mobilePhone2DataGridViewTextBoxColumn
         // 
         this.mobilePhone2DataGridViewTextBoxColumn.DataPropertyName = "MobilePhone2";
         this.mobilePhone2DataGridViewTextBoxColumn.HeaderText = "Di động 2";
         this.mobilePhone2DataGridViewTextBoxColumn.Name = "mobilePhone2DataGridViewTextBoxColumn";
         this.mobilePhone2DataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // takeCareUserNameDataGridViewTextBoxColumn
         // 
         this.takeCareUserNameDataGridViewTextBoxColumn.DataPropertyName = "TakeCareUserName";
         this.takeCareUserNameDataGridViewTextBoxColumn.HeaderText = "Chăm sóc";
         this.takeCareUserNameDataGridViewTextBoxColumn.Name = "takeCareUserNameDataGridViewTextBoxColumn";
         this.takeCareUserNameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // introduceUserNameDataGridViewTextBoxColumn
         // 
         this.introduceUserNameDataGridViewTextBoxColumn.DataPropertyName = "IntroduceUserName";
         this.introduceUserNameDataGridViewTextBoxColumn.HeaderText = "Giới thiệu";
         this.introduceUserNameDataGridViewTextBoxColumn.Name = "introduceUserNameDataGridViewTextBoxColumn";
         this.introduceUserNameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // IsSpecial
         // 
         this.IsSpecial.DataPropertyName = "IsSpecial";
         this.IsSpecial.HeaderText = "KH đặc biệt";
         this.IsSpecial.Name = "IsSpecial";
         this.IsSpecial.ReadOnly = true;
         // 
         // customerBindingSource
         // 
         this.customerBindingSource.DataSource = typeof(VRMApp.VRMGateway.Customer);
         // 
         // CustomerListForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1026, 656);
         this.Name = "CustomerListForm";
         this.Text = "Danh sách khách hàng";
         this.Load += new System.EventHandler(this.CustomerListForm_Load);
         this.mainPanel.ResumeLayout(false);
         this.mainPanel.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.BindingSource customerBindingSource;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.DataGridView dataGridView;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox maKHBox;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.DataGridViewTextBoxColumn bankCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripComboBox nvchamsoccb;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButton3;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn branchCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tradeCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn MarginRate;
      private System.Windows.Forms.DataGridViewTextBoxColumn telephoneDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn mobilePhone1DataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn mobilePhone2DataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn takeCareUserNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn introduceUserNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewCheckBoxColumn IsSpecial;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton toolStripButton4;
   }
}