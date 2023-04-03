namespace VRMApp.Depository
{
   partial class ExecRightRegisterForm
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.lblTotalHoding = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         this.lblTotalReceived = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.txtStockCode = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         this.txtCustomerID = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
         this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.noidung = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.statusStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalHoding,
            this.toolStripStatusLabel1,
            this.lblTotalReceived});
         this.statusStrip1.Location = new System.Drawing.Point(0, 608);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(1007, 22);
         this.statusStrip1.TabIndex = 0;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // lblTotalHoding
         // 
         this.lblTotalHoding.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblTotalHoding.Name = "lblTotalHoding";
         this.lblTotalHoding.Size = new System.Drawing.Size(112, 17);
         this.lblTotalHoding.Text = "Tổng số lượng: n/a";
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
         this.toolStripStatusLabel1.Text = "|";
         // 
         // lblTotalReceived
         // 
         this.lblTotalReceived.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblTotalReceived.Name = "lblTotalReceived";
         this.lblTotalReceived.Size = new System.Drawing.Size(97, 17);
         this.lblTotalReceived.Text = "Tổng giá trị: n/a";
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtStockCode,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txtCustomerID,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.toolStripButton2});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(1007, 25);
         this.toolStrip1.TabIndex = 1;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(41, 22);
         this.toolStripLabel1.Text = "Mã CK:";
         // 
         // txtStockCode
         // 
         this.txtStockCode.Name = "txtStockCode";
         this.txtStockCode.Size = new System.Drawing.Size(100, 25);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripLabel2
         // 
         this.toolStripLabel2.Name = "toolStripLabel2";
         this.toolStripLabel2.Size = new System.Drawing.Size(41, 22);
         this.toolStripLabel2.Text = "Mã KH:";
         // 
         // txtCustomerID
         // 
         this.txtCustomerID.Name = "txtCustomerID";
         this.txtCustomerID.Size = new System.Drawing.Size(100, 25);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Image = global::VRMApp.Properties.Resources.find;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(43, 22);
         this.toolStripButton1.Text = "&Tìm";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton2
         // 
         this.toolStripButton2.Image = global::VRMApp.Properties.Resources.delete;
         this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton2.Name = "toolStripButton2";
         this.toolStripButton2.Size = new System.Drawing.Size(46, 22);
         this.toolStripButton2.Text = "Hủy";
         this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.noidung,
            this.Column1,
            this.Column2,
            this.Column11,
            this.Column3,
            this.Column4,
            this.CustomerId,
            this.Column6,
            this.Column12,
            this.Column14,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column15,
            this.Column13});
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point(0, 25);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.Size = new System.Drawing.Size(1007, 583);
         this.dataGridView1.TabIndex = 2;
         // 
         // backgroundWorker1
         // 
         this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
         this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
         // 
         // id
         // 
         this.id.DataPropertyName = "id";
         this.id.HeaderText = " id";
         this.id.Name = "id";
         this.id.ReadOnly = true;
         this.id.Visible = false;
         // 
         // noidung
         // 
         this.noidung.DataPropertyName = "description";
         this.noidung.HeaderText = "Nội dung";
         this.noidung.Name = "noidung";
         this.noidung.ReadOnly = true;
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
         this.Column2.DataPropertyName = "RightType";
         this.Column2.HeaderText = "Loại hình";
         this.Column2.Name = "Column2";
         this.Column2.ReadOnly = true;
         // 
         // Column11
         // 
         this.Column11.DataPropertyName = "DateNoRight";
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle1.Format = "dd/MM/yyyy";
         this.Column11.DefaultCellStyle = dataGridViewCellStyle1;
         this.Column11.HeaderText = "Ngày không hưởng quyền";
         this.Column11.Name = "Column11";
         this.Column11.ReadOnly = true;
         // 
         // Column3
         // 
         this.Column3.DataPropertyName = "DateOwnerConfirm";
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle2.Format = "dd/MM/yyyy";
         this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
         this.Column3.HeaderText = "Ngày chốt";
         this.Column3.Name = "Column3";
         this.Column3.ReadOnly = true;
         // 
         // Column4
         // 
         this.Column4.DataPropertyName = "DatePay";
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle3.Format = "dd/MM/yyyy";
         this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
         this.Column4.HeaderText = "Ngày thanh toán";
         this.Column4.Name = "Column4";
         this.Column4.ReadOnly = true;
         // 
         // CustomerId
         // 
         this.CustomerId.DataPropertyName = "CustomerId";
         this.CustomerId.HeaderText = "Tài khoản";
         this.CustomerId.Name = "CustomerId";
         this.CustomerId.ReadOnly = true;
         // 
         // Column6
         // 
         this.Column6.DataPropertyName = "CustomerNameViet";
         this.Column6.HeaderText = "Tên tài khoản";
         this.Column6.Name = "Column6";
         this.Column6.ReadOnly = true;
         // 
         // Column12
         // 
         this.Column12.DataPropertyName = "Status";
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.Column12.DefaultCellStyle = dataGridViewCellStyle4;
         this.Column12.HeaderText = "Trạng thái";
         this.Column12.Name = "Column12";
         this.Column12.ReadOnly = true;
         // 
         // Column14
         // 
         this.Column14.DataPropertyName = "quantity";
         dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle5.Format = "n0";
         this.Column14.DefaultCellStyle = dataGridViewCellStyle5;
         this.Column14.HeaderText = "SL sở hữu";
         this.Column14.Name = "Column14";
         this.Column14.ReadOnly = true;
         // 
         // Column7
         // 
         this.Column7.DataPropertyName = "OutTransferQuantity";
         dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle6.Format = "n0";
         this.Column7.DefaultCellStyle = dataGridViewCellStyle6;
         this.Column7.HeaderText = "SL CN";
         this.Column7.Name = "Column7";
         this.Column7.ReadOnly = true;
         // 
         // Column8
         // 
         this.Column8.DataPropertyName = "InTransferQuantity";
         dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle7.Format = "n0";
         this.Column8.DefaultCellStyle = dataGridViewCellStyle7;
         this.Column8.HeaderText = "SL nhận CN";
         this.Column8.Name = "Column8";
         this.Column8.ReadOnly = true;
         // 
         // Column9
         // 
         this.Column9.DataPropertyName = "AllowBuyQuantity";
         dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle8.Format = "n0";
         this.Column9.DefaultCellStyle = dataGridViewCellStyle8;
         this.Column9.HeaderText = "SL được mua";
         this.Column9.Name = "Column9";
         this.Column9.ReadOnly = true;
         // 
         // Column10
         // 
         this.Column10.DataPropertyName = "RegisteredQuantity";
         dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle9.Format = "n0";
         this.Column10.DefaultCellStyle = dataGridViewCellStyle9;
         this.Column10.HeaderText = "SL đăng ký";
         this.Column10.Name = "Column10";
         this.Column10.ReadOnly = true;
         // 
         // Column15
         // 
         this.Column15.DataPropertyName = "rightexecprice";
         dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle10.Format = "n0";
         this.Column15.DefaultCellStyle = dataGridViewCellStyle10;
         this.Column15.HeaderText = "Giá phát hành";
         this.Column15.Name = "Column15";
         this.Column15.ReadOnly = true;
         // 
         // Column13
         // 
         this.Column13.DataPropertyName = "RegisteredAmount";
         dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle11.Format = "n0";
         this.Column13.DefaultCellStyle = dataGridViewCellStyle11;
         this.Column13.HeaderText = "Thành tiền";
         this.Column13.Name = "Column13";
         this.Column13.ReadOnly = true;
         // 
         // ExecRightRegisterForm
         // 
         this.ClientSize = new System.Drawing.Size(1007, 630);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.statusStrip1);
         this.Name = "ExecRightRegisterForm";
         this.Text = "Danh sách theo dỏi quyền mua phát hành thêm";
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
      private System.Windows.Forms.ToolStripStatusLabel lblTotalHoding;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
      private System.Windows.Forms.ToolStripStatusLabel lblTotalReceived;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox txtStockCode;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripTextBox txtCustomerID;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.ComponentModel.BackgroundWorker backgroundWorker1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.DataGridViewTextBoxColumn id;
      private System.Windows.Forms.DataGridViewTextBoxColumn noidung;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
      private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
   }
}
