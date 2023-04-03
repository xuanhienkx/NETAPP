namespace VRMApp.Brokerage
{
   partial class DeferredListForm
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
          this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
          this.toolStrip1 = new System.Windows.Forms.ToolStrip();
          this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
          this.maKHBox = new System.Windows.Forms.ToolStripTextBox();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
          this.nvchamsoccb = new System.Windows.Forms.ToolStripComboBox();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
          this.loaiHDCombo = new System.Windows.Forms.ToolStripComboBox();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
          this.dataGridView = new System.Windows.Forms.DataGridView();
          this.hopdong = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.loaihd = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.customerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tenkhachhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.sodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.tienmua = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.sotienno = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.sotienthieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.nvchamsoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.mainPanel.SuspendLayout();
          this.toolStrip1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.nvchamsoccb,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.loaiHDCombo,
            this.toolStripSeparator3,
            this.toolStripButton1});
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
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
          // 
          // toolStripLabel3
          // 
          this.toolStripLabel3.Name = "toolStripLabel3";
          this.toolStripLabel3.Size = new System.Drawing.Size(87, 22);
          this.toolStripLabel3.Text = "Loại hợp đồng:";
          // 
          // loaiHDCombo
          // 
          this.loaiHDCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.loaiHDCombo.Name = "loaiHDCombo";
          this.loaiHDCombo.Size = new System.Drawing.Size(121, 25);
          // 
          // toolStripSeparator3
          // 
          this.toolStripSeparator3.Name = "toolStripSeparator3";
          this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
          // dataGridView
          // 
          this.dataGridView.AllowUserToAddRows = false;
          this.dataGridView.AllowUserToDeleteRows = false;
          this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hopdong,
            this.loaihd,
            this.customerid,
            this.tenkhachhang,
            this.sodu,
            this.tienmua,
            this.sotienno,
            this.sotienthieu,
            this.nvchamsoc});
          this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dataGridView.Location = new System.Drawing.Point(0, 25);
          this.dataGridView.Name = "dataGridView";
          this.dataGridView.ReadOnly = true;
          this.dataGridView.Size = new System.Drawing.Size(1026, 609);
          this.dataGridView.TabIndex = 1;
          this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
          // 
          // hopdong
          // 
          this.hopdong.DataPropertyName = "ContractID";
          dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
          this.hopdong.DefaultCellStyle = dataGridViewCellStyle1;
          this.hopdong.HeaderText = "Hợp đồng";
          this.hopdong.Name = "hopdong";
          this.hopdong.ReadOnly = true;
          // 
          // loaihd
          // 
          this.loaihd.DataPropertyName = "loaihd";
          dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
          this.loaihd.DefaultCellStyle = dataGridViewCellStyle2;
          this.loaihd.HeaderText = "Loại hợp đồng";
          this.loaihd.Name = "loaihd";
          this.loaihd.ReadOnly = true;
          // 
          // customerid
          // 
          this.customerid.DataPropertyName = "CustomerId";
          dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
          this.customerid.DefaultCellStyle = dataGridViewCellStyle3;
          this.customerid.HeaderText = "Mã khách hàng";
          this.customerid.Name = "customerid";
          this.customerid.ReadOnly = true;
          // 
          // tenkhachhang
          // 
          this.tenkhachhang.DataPropertyName = "CustomerName";
          this.tenkhachhang.HeaderText = "Tên khách hàng";
          this.tenkhachhang.Name = "tenkhachhang";
          this.tenkhachhang.ReadOnly = true;
          // 
          // sodu
          // 
          this.sodu.DataPropertyName = "CurrentBalance";
          dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
          dataGridViewCellStyle4.Format = "n0";
          this.sodu.DefaultCellStyle = dataGridViewCellStyle4;
          this.sodu.HeaderText = "Số dư hiện tại";
          this.sodu.Name = "sodu";
          this.sodu.ReadOnly = true;
          // 
          // tienmua
          // 
          this.tienmua.DataPropertyName = "tienmua";
          dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
          dataGridViewCellStyle5.Format = "n0";
          this.tienmua.DefaultCellStyle = dataGridViewCellStyle5;
          this.tienmua.HeaderText = "Tiền mua trong ngày";
          this.tienmua.Name = "tienmua";
          this.tienmua.ReadOnly = true;
          // 
          // sotienno
          // 
          this.sotienno.DataPropertyName = "tienno";
          dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
          dataGridViewCellStyle6.Format = "n0";
          this.sotienno.DefaultCellStyle = dataGridViewCellStyle6;
          this.sotienno.HeaderText = "Số tiền mua nợ";
          this.sotienno.Name = "sotienno";
          this.sotienno.ReadOnly = true;
          // 
          // sotienthieu
          // 
          this.sotienthieu.DataPropertyName = "tienthieu";
          dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
          dataGridViewCellStyle7.Format = "n0";
          this.sotienthieu.DefaultCellStyle = dataGridViewCellStyle7;
          this.sotienthieu.HeaderText = "Số tiền thiếu";
          this.sotienthieu.Name = "sotienthieu";
          this.sotienthieu.ReadOnly = true;
          // 
          // nvchamsoc
          // 
          this.nvchamsoc.DataPropertyName = "UserName";
          this.nvchamsoc.HeaderText = "NV chăm sóc";
          this.nvchamsoc.Name = "nvchamsoc";
          this.nvchamsoc.ReadOnly = true;
          // 
          // DeferredListForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(1026, 656);
          this.Name = "DeferredListForm";
          this.Text = "Danh sách khách hàng nợ tiền mua ngày T";
          this.Load += new System.EventHandler(this.CustomerListForm_Load);
          this.mainPanel.ResumeLayout(false);
          this.mainPanel.PerformLayout();
          this.toolStrip1.ResumeLayout(false);
          this.toolStrip1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

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
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripLabel toolStripLabel3;
      private System.Windows.Forms.ToolStripComboBox loaiHDCombo;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.DataGridViewTextBoxColumn hopdong;
      private System.Windows.Forms.DataGridViewTextBoxColumn loaihd;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerid;
      private System.Windows.Forms.DataGridViewTextBoxColumn tenkhachhang;
      private System.Windows.Forms.DataGridViewTextBoxColumn sodu;
      private System.Windows.Forms.DataGridViewTextBoxColumn tienmua;
      private System.Windows.Forms.DataGridViewTextBoxColumn sotienno;
      private System.Windows.Forms.DataGridViewTextBoxColumn sotienthieu;
      private System.Windows.Forms.DataGridViewTextBoxColumn nvchamsoc;
   }
}