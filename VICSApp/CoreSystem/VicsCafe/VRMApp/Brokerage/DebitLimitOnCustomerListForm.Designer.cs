namespace VRMApp.Brokerage
{
   partial class DebitLimitOnCustomerListForm
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
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
          this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
          this.toolStrip1 = new System.Windows.Forms.ToolStrip();
          this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
          this.maKHBox = new System.Windows.Forms.ToolStripTextBox();
          this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
          this.nvchamsoccb = new System.Windows.Forms.ToolStripComboBox();
          this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
          this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
          this.dataGridView = new System.Windows.Forms.DataGridView();
          this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.NVChamSoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tongNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tongTSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tyLeF1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tyLeF2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tyLeHopTacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tyLeNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.hanMucToiDaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.hanmuctoidadacap = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.custAssetInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
          this.mainPanel.SuspendLayout();
          this.toolStrip1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.custAssetInfoBindingSource)).BeginInit();
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
            this.toolStripButton2});
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
          this.toolStripButton2.Image = global::VRMApp.Properties.Resources.money_dollar;
          this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripButton2.Name = "toolStripButton2";
          this.toolStripButton2.Size = new System.Drawing.Size(98, 22);
          this.toolStripButton2.Text = "&Cấp hạn mức";
          this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
          // 
          // backgroundWorker1
          // 
          this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
          this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
          // 
          // dataGridView
          // 
          this.dataGridView.AllowUserToAddRows = false;
          this.dataGridView.AllowUserToDeleteRows = false;
          this.dataGridView.AutoGenerateColumns = false;
          this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIDDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.NVChamSoc,
            this.tongNoDataGridViewTextBoxColumn,
            this.tongTSDataGridViewTextBoxColumn,
            this.tyLeF1DataGridViewTextBoxColumn,
            this.tyLeF2DataGridViewTextBoxColumn,
            this.tyLeHopTacDataGridViewTextBoxColumn,
            this.tyLeNoDataGridViewTextBoxColumn,
            this.hanMucToiDaDataGridViewTextBoxColumn,
            this.hanmuctoidadacap});
          this.dataGridView.DataSource = this.custAssetInfoBindingSource;
          this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dataGridView.Location = new System.Drawing.Point(0, 25);
          this.dataGridView.Name = "dataGridView";
          this.dataGridView.ReadOnly = true;
          this.dataGridView.Size = new System.Drawing.Size(1026, 609);
          this.dataGridView.TabIndex = 1;
          // 
          // customerIDDataGridViewTextBoxColumn
          // 
          this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
          this.customerIDDataGridViewTextBoxColumn.HeaderText = "Mã KH";
          this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
          this.customerIDDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // customerNameDataGridViewTextBoxColumn
          // 
          this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
          this.customerNameDataGridViewTextBoxColumn.HeaderText = "Tên KH";
          this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
          this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // NVChamSoc
          // 
          this.NVChamSoc.DataPropertyName = "NVChamSoc";
          this.NVChamSoc.HeaderText = "NV chăm sóc";
          this.NVChamSoc.Name = "NVChamSoc";
          this.NVChamSoc.ReadOnly = true;
          // 
          // tongNoDataGridViewTextBoxColumn
          // 
          this.tongNoDataGridViewTextBoxColumn.DataPropertyName = "TongNo";
          dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
          dataGridViewCellStyle1.Format = "n0";
          this.tongNoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
          this.tongNoDataGridViewTextBoxColumn.HeaderText = "Tổng nợ";
          this.tongNoDataGridViewTextBoxColumn.Name = "tongNoDataGridViewTextBoxColumn";
          this.tongNoDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // tongTSDataGridViewTextBoxColumn
          // 
          this.tongTSDataGridViewTextBoxColumn.DataPropertyName = "TongTS";
          dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
          dataGridViewCellStyle2.Format = "n0";
          this.tongTSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
          this.tongTSDataGridViewTextBoxColumn.HeaderText = "Tổng TS";
          this.tongTSDataGridViewTextBoxColumn.Name = "tongTSDataGridViewTextBoxColumn";
          this.tongTSDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // tyLeF1DataGridViewTextBoxColumn
          // 
          this.tyLeF1DataGridViewTextBoxColumn.DataPropertyName = "TyLeF1";
          dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
          dataGridViewCellStyle3.Format = "n0";
          this.tyLeF1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
          this.tyLeF1DataGridViewTextBoxColumn.HeaderText = "Tỉ lệ F1";
          this.tyLeF1DataGridViewTextBoxColumn.Name = "tyLeF1DataGridViewTextBoxColumn";
          this.tyLeF1DataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // tyLeF2DataGridViewTextBoxColumn
          // 
          this.tyLeF2DataGridViewTextBoxColumn.DataPropertyName = "TyLeF2";
          dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
          dataGridViewCellStyle4.Format = "n0";
          this.tyLeF2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
          this.tyLeF2DataGridViewTextBoxColumn.HeaderText = "Tỉ lệ F2";
          this.tyLeF2DataGridViewTextBoxColumn.Name = "tyLeF2DataGridViewTextBoxColumn";
          this.tyLeF2DataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // tyLeHopTacDataGridViewTextBoxColumn
          // 
          this.tyLeHopTacDataGridViewTextBoxColumn.DataPropertyName = "TyLeHopTac";
          dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
          dataGridViewCellStyle5.Format = "n0";
          this.tyLeHopTacDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
          this.tyLeHopTacDataGridViewTextBoxColumn.HeaderText = "Tỉ lệ HT";
          this.tyLeHopTacDataGridViewTextBoxColumn.Name = "tyLeHopTacDataGridViewTextBoxColumn";
          this.tyLeHopTacDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // tyLeNoDataGridViewTextBoxColumn
          // 
          this.tyLeNoDataGridViewTextBoxColumn.DataPropertyName = "TyLeNo";
          dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
          dataGridViewCellStyle6.Format = "n0";
          this.tyLeNoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
          this.tyLeNoDataGridViewTextBoxColumn.HeaderText = "Tỉ lệ nợ";
          this.tyLeNoDataGridViewTextBoxColumn.Name = "tyLeNoDataGridViewTextBoxColumn";
          this.tyLeNoDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // hanMucToiDaDataGridViewTextBoxColumn
          // 
          this.hanMucToiDaDataGridViewTextBoxColumn.DataPropertyName = "HanMucToiDa";
          dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
          dataGridViewCellStyle7.Format = "n0";
          this.hanMucToiDaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
          this.hanMucToiDaDataGridViewTextBoxColumn.HeaderText = "Hạn mức tối đa";
          this.hanMucToiDaDataGridViewTextBoxColumn.Name = "hanMucToiDaDataGridViewTextBoxColumn";
          this.hanMucToiDaDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // hanmuctoidadacap
          // 
          dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
          dataGridViewCellStyle8.Format = "n0";
          this.hanmuctoidadacap.DefaultCellStyle = dataGridViewCellStyle8;
          this.hanmuctoidadacap.HeaderText = "Hạn mức tối đa đã cấp";
          this.hanmuctoidadacap.Name = "hanmuctoidadacap";
          this.hanmuctoidadacap.ReadOnly = true;
          // 
          // custAssetInfoBindingSource
          // 
          this.custAssetInfoBindingSource.DataSource = typeof(VRMApp.VRMGateway.CustAssetInfo);
          // 
          // DebitLimitOnCustomerListForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(1026, 656);
          this.Name = "DebitLimitOnCustomerListForm";
          this.Text = "Danh sách khách hàng cấp hạn mức tín dụng";
          this.Load += new System.EventHandler(this.CustomerListForm_Load);
          this.mainPanel.ResumeLayout(false);
          this.mainPanel.PerformLayout();
          this.toolStrip1.ResumeLayout(false);
          this.toolStrip1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.custAssetInfoBindingSource)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox maKHBox;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.DataGridViewTextBoxColumn bankCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripComboBox nvchamsoccb;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.ComponentModel.BackgroundWorker backgroundWorker1;
      private System.Windows.Forms.DataGridView dataGridView;
      private System.Windows.Forms.BindingSource custAssetInfoBindingSource;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn NVChamSoc;
      private System.Windows.Forms.DataGridViewTextBoxColumn tongNoDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tongTSDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tyLeF1DataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tyLeF2DataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tyLeHopTacDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tyLeNoDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn hanMucToiDaDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn hanmuctoidadacap;
   }
}