namespace VRMApp.Depository
{
   partial class MissingStockForm
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
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.lblSoCK = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.statusStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSoCK});
         this.statusStrip1.Location = new System.Drawing.Point(0, 535);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(847, 22);
         this.statusStrip1.TabIndex = 0;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // lblSoCK
         // 
         this.lblSoCK.Name = "lblSoCK";
         this.lblSoCK.Size = new System.Drawing.Size(107, 17);
         this.lblSoCK.Text = "Số chứng khoán: n/a";
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(847, 25);
         this.toolStrip1.TabIndex = 2;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point(0, 25);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.Size = new System.Drawing.Size(847, 510);
         this.dataGridView1.TabIndex = 3;
         // 
         // Column1
         // 
         this.Column1.DataPropertyName = "stockcode";
         this.Column1.HeaderText = "Mã CK";
         this.Column1.Name = "Column1";
         this.Column1.ReadOnly = true;
         // 
         // Column2
         // 
         this.Column2.DataPropertyName = "boardtype";
         this.Column2.HeaderText = "Sàn giao dịch";
         this.Column2.Name = "Column2";
         this.Column2.ReadOnly = true;
         // 
         // Column3
         // 
         this.Column3.DataPropertyName = "openprice";
         this.Column3.HeaderText = "Giá mở cửa";
         this.Column3.Name = "Column3";
         this.Column3.ReadOnly = true;
         // 
         // Column4
         // 
         this.Column4.DataPropertyName = "closeprice";
         this.Column4.HeaderText = "Giá đóng cửa";
         this.Column4.Name = "Column4";
         this.Column4.ReadOnly = true;
         // 
         // Column5
         // 
         this.Column5.DataPropertyName = "basicprice";
         this.Column5.HeaderText = "Giá tham chiếu";
         this.Column5.Name = "Column5";
         this.Column5.ReadOnly = true;
         // 
         // Column6
         // 
         this.Column6.DataPropertyName = "stocktype";
         this.Column6.HeaderText = "Loại chứng khoán";
         this.Column6.Name = "Column6";
         this.Column6.ReadOnly = true;
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Image = global::VRMApp.Properties.Resources.arrow_refresh;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(79, 22);
         this.toolStripButton1.Text = "&Lấy dữ liệu";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // MissingStockForm
         // 
         this.ClientSize = new System.Drawing.Size(847, 557);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.statusStrip1);
         this.Name = "MissingStockForm";
         this.Text = "Danh sách chứng khoán niêm yết không có trong hệ thống";
         this.Load += new System.EventHandler(this.MissingStockForm_Load);
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel lblSoCK;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
   }
}
