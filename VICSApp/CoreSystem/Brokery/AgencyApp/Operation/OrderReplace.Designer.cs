namespace Brokery.Operation
{
   partial class OrderReplace
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
         this.lblSHL2 = new System.Windows.Forms.Label();
         this.lblSHL = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.txtVolume = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.txtExtra = new System.Windows.Forms.TextBox();
         this.lblExtra = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.txtPrice = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.lblTaiKhoan = new System.Windows.Forms.Label();
         this.lblMaChungKhoan = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.lblCeilingPrice = new System.Windows.Forms.Label();
         this.lblPreClosedPrice = new System.Windows.Forms.Label();
         this.lblFloorPrice = new System.Windows.Forms.Label();
         this.lblLoaiLenh = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.btnSubmit = new System.Windows.Forms.Button();
         this.btnUndo = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.lblGiadat = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.lblKhoiLuongDat = new System.Windows.Forms.Label();
         this.lblExtraInfo = new System.Windows.Forms.Label();
         this.lblThongTinKhac = new System.Windows.Forms.Label();
         this.sendRequestProcess = new System.ComponentModel.BackgroundWorker();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.lblSide = new System.Windows.Forms.Label();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // lblSHL2
         // 
         this.lblSHL2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblSHL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSHL2.ForeColor = System.Drawing.Color.Green;
         this.lblSHL2.Location = new System.Drawing.Point(397, 7);
         this.lblSHL2.Name = "lblSHL2";
         this.lblSHL2.Size = new System.Drawing.Size(107, 23);
         this.lblSHL2.TabIndex = 5;
         this.lblSHL2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblSHL
         // 
         this.lblSHL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblSHL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSHL.ForeColor = System.Drawing.Color.Green;
         this.lblSHL.Location = new System.Drawing.Point(310, 7);
         this.lblSHL.Name = "lblSHL";
         this.lblSHL.Size = new System.Drawing.Size(81, 23);
         this.lblSHL.TabIndex = 4;
         this.lblSHL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(273, 12);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(31, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "SHL:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(238, 189);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(80, 13);
         this.label3.TabIndex = 23;
         this.label3.Text = "Khối lượng sửa:";
         // 
         // txtVolume
         // 
         this.txtVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtVolume.Location = new System.Drawing.Point(241, 206);
         this.txtVolume.Name = "txtVolume";
         this.txtVolume.Size = new System.Drawing.Size(125, 32);
         this.txtVolume.TabIndex = 2;
         this.txtVolume.Text = "0";
         this.txtVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtVolume.Validated += new System.EventHandler(this.txtVolume_Validated);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(9, 127);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(91, 13);
         this.label2.TabIndex = 21;
         this.label2.Text = "Mã chứng khoán:";
         // 
         // txtExtra
         // 
         this.txtExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtExtra.Location = new System.Drawing.Point(379, 206);
         this.txtExtra.MaxLength = 10;
         this.txtExtra.Name = "txtExtra";
         this.txtExtra.Size = new System.Drawing.Size(125, 32);
         this.txtExtra.TabIndex = 3;
         this.txtExtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtExtra.Visible = false;
         this.txtExtra.TextChanged += new System.EventHandler(this.txtExtra_TextChanged);
         // 
         // lblExtra
         // 
         this.lblExtra.AutoSize = true;
         this.lblExtra.Location = new System.Drawing.Point(376, 189);
         this.lblExtra.Name = "lblExtra";
         this.lblExtra.Size = new System.Drawing.Size(82, 13);
         this.lblExtra.TabIndex = 28;
         this.lblExtra.Text = "Thông tin khác:";
         this.lblExtra.Visible = false;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(121, 189);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(46, 13);
         this.label5.TabIndex = 27;
         this.label5.Text = "Giá sửa:";
         // 
         // txtPrice
         // 
         this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtPrice.Location = new System.Drawing.Point(124, 205);
         this.txtPrice.Name = "txtPrice";
         this.txtPrice.Size = new System.Drawing.Size(104, 32);
         this.txtPrice.TabIndex = 1;
         this.txtPrice.Text = "0,0";
         this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtPrice.Validated += new System.EventHandler(this.txtPrice_Validated);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(12, 12);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(118, 13);
         this.label6.TabIndex = 32;
         this.label6.Text = "Tài khoản khách hàng:";
         // 
         // lblTaiKhoan
         // 
         this.lblTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTaiKhoan.ForeColor = System.Drawing.SystemColors.Highlight;
         this.lblTaiKhoan.Location = new System.Drawing.Point(12, 29);
         this.lblTaiKhoan.Name = "lblTaiKhoan";
         this.lblTaiKhoan.Size = new System.Drawing.Size(230, 32);
         this.lblTaiKhoan.TabIndex = 31;
         this.lblTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblMaChungKhoan
         // 
         this.lblMaChungKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblMaChungKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblMaChungKhoan.ForeColor = System.Drawing.SystemColors.Highlight;
         this.lblMaChungKhoan.Location = new System.Drawing.Point(12, 144);
         this.lblMaChungKhoan.Name = "lblMaChungKhoan";
         this.lblMaChungKhoan.Size = new System.Drawing.Size(100, 32);
         this.lblMaChungKhoan.TabIndex = 33;
         this.lblMaChungKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
         this.panel1.Controls.Add(this.lblCeilingPrice);
         this.panel1.Controls.Add(this.lblPreClosedPrice);
         this.panel1.Controls.Add(this.lblFloorPrice);
         this.panel1.Location = new System.Drawing.Point(194, 79);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(310, 41);
         this.panel1.TabIndex = 34;
         // 
         // lblCeilingPrice
         // 
         this.lblCeilingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCeilingPrice.ForeColor = System.Drawing.Color.Lime;
         this.lblCeilingPrice.Location = new System.Drawing.Point(210, 3);
         this.lblCeilingPrice.Name = "lblCeilingPrice";
         this.lblCeilingPrice.Size = new System.Drawing.Size(92, 34);
         this.lblCeilingPrice.TabIndex = 2;
         this.lblCeilingPrice.Text = "0,0";
         this.lblCeilingPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblPreClosedPrice
         // 
         this.lblPreClosedPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPreClosedPrice.ForeColor = System.Drawing.Color.Yellow;
         this.lblPreClosedPrice.Location = new System.Drawing.Point(109, 3);
         this.lblPreClosedPrice.Name = "lblPreClosedPrice";
         this.lblPreClosedPrice.Size = new System.Drawing.Size(92, 34);
         this.lblPreClosedPrice.TabIndex = 1;
         this.lblPreClosedPrice.Text = "0,0";
         this.lblPreClosedPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblFloorPrice
         // 
         this.lblFloorPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFloorPrice.ForeColor = System.Drawing.Color.Red;
         this.lblFloorPrice.Location = new System.Drawing.Point(8, 3);
         this.lblFloorPrice.Name = "lblFloorPrice";
         this.lblFloorPrice.Size = new System.Drawing.Size(92, 34);
         this.lblFloorPrice.TabIndex = 0;
         this.lblFloorPrice.Text = "0,0";
         this.lblFloorPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblLoaiLenh
         // 
         this.lblLoaiLenh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblLoaiLenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblLoaiLenh.ForeColor = System.Drawing.SystemColors.Highlight;
         this.lblLoaiLenh.Location = new System.Drawing.Point(103, 84);
         this.lblLoaiLenh.Name = "lblLoaiLenh";
         this.lblLoaiLenh.Size = new System.Drawing.Size(84, 32);
         this.lblLoaiLenh.TabIndex = 24;
         this.lblLoaiLenh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(100, 68);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(53, 13);
         this.label10.TabIndex = 25;
         this.label10.Text = "Loại lệnh:";
         // 
         // btnSubmit
         // 
         this.btnSubmit.Enabled = false;
         this.btnSubmit.Image = global::Brokery.Properties.Resources.add;
         this.btnSubmit.Location = new System.Drawing.Point(300, 254);
         this.btnSubmit.Name = "btnSubmit";
         this.btnSubmit.Size = new System.Drawing.Size(91, 34);
         this.btnSubmit.TabIndex = 4;
         this.btnSubmit.Text = "&Gửi yêu cầu";
         this.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btnSubmit.UseVisualStyleBackColor = true;
         this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
         // 
         // btnUndo
         // 
         this.btnUndo.Image = global::Brokery.Properties.Resources.cancel;
         this.btnUndo.Location = new System.Drawing.Point(413, 254);
         this.btnUndo.Name = "btnUndo";
         this.btnUndo.Size = new System.Drawing.Size(91, 34);
         this.btnUndo.TabIndex = 5;
         this.btnUndo.Text = "&Bỏ qua";
         this.btnUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btnUndo.UseVisualStyleBackColor = true;
         this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(121, 127);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(61, 13);
         this.label4.TabIndex = 38;
         this.label4.Text = "Giá đã đặt:";
         // 
         // lblGiadat
         // 
         this.lblGiadat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblGiadat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblGiadat.ForeColor = System.Drawing.SystemColors.Highlight;
         this.lblGiadat.Location = new System.Drawing.Point(124, 144);
         this.lblGiadat.Name = "lblGiadat";
         this.lblGiadat.Size = new System.Drawing.Size(104, 32);
         this.lblGiadat.TabIndex = 37;
         this.lblGiadat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(238, 127);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(95, 13);
         this.label9.TabIndex = 40;
         this.label9.Text = "Khối lượng đã đặt:";
         // 
         // lblKhoiLuongDat
         // 
         this.lblKhoiLuongDat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblKhoiLuongDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblKhoiLuongDat.ForeColor = System.Drawing.SystemColors.Highlight;
         this.lblKhoiLuongDat.Location = new System.Drawing.Point(240, 144);
         this.lblKhoiLuongDat.Name = "lblKhoiLuongDat";
         this.lblKhoiLuongDat.Size = new System.Drawing.Size(125, 32);
         this.lblKhoiLuongDat.TabIndex = 39;
         this.lblKhoiLuongDat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblExtraInfo
         // 
         this.lblExtraInfo.AutoSize = true;
         this.lblExtraInfo.Location = new System.Drawing.Point(376, 127);
         this.lblExtraInfo.Name = "lblExtraInfo";
         this.lblExtraInfo.Size = new System.Drawing.Size(79, 13);
         this.lblExtraInfo.TabIndex = 42;
         this.lblExtraInfo.Text = "Thông tin khác";
         // 
         // lblThongTinKhac
         // 
         this.lblThongTinKhac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblThongTinKhac.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblThongTinKhac.ForeColor = System.Drawing.SystemColors.Highlight;
         this.lblThongTinKhac.Location = new System.Drawing.Point(377, 144);
         this.lblThongTinKhac.Name = "lblThongTinKhac";
         this.lblThongTinKhac.Size = new System.Drawing.Size(125, 32);
         this.lblThongTinKhac.TabIndex = 41;
         this.lblThongTinKhac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // sendRequestProcess
         // 
         this.sendRequestProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendRequestProcess_DoWork);
         this.sendRequestProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sendRequestProcess_RunWorkerCompleted);
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // lblSide
         // 
         this.lblSide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSide.ForeColor = System.Drawing.SystemColors.Highlight;
         this.lblSide.Location = new System.Drawing.Point(12, 84);
         this.lblSide.Name = "lblSide";
         this.lblSide.Size = new System.Drawing.Size(84, 32);
         this.lblSide.TabIndex = 43;
         this.lblSide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // OrderReplace
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(518, 304);
         this.Controls.Add(this.lblSide);
         this.Controls.Add(this.lblExtraInfo);
         this.Controls.Add(this.lblThongTinKhac);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.lblKhoiLuongDat);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.lblGiadat);
         this.Controls.Add(this.btnUndo);
         this.Controls.Add(this.btnSubmit);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.lblMaChungKhoan);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.lblTaiKhoan);
         this.Controls.Add(this.txtExtra);
         this.Controls.Add(this.lblExtra);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.txtPrice);
         this.Controls.Add(this.label10);
         this.Controls.Add(this.lblLoaiLenh);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.txtVolume);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.lblSHL2);
         this.Controls.Add(this.lblSHL);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OrderReplace";
         this.Text = "Yêu cầu sửa lệnh giao dịch";
         this.Load += new System.EventHandler(this.OrderReplace_Load);
         this.panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblSHL2;
      private System.Windows.Forms.Label lblSHL;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtVolume;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtExtra;
      private System.Windows.Forms.Label lblExtra;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox txtPrice;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label lblTaiKhoan;
      private System.Windows.Forms.Label lblMaChungKhoan;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label lblCeilingPrice;
      private System.Windows.Forms.Label lblPreClosedPrice;
      private System.Windows.Forms.Label lblFloorPrice;
      private System.Windows.Forms.Label lblLoaiLenh;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Button btnSubmit;
      private System.Windows.Forms.Button btnUndo;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label lblGiadat;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label lblKhoiLuongDat;
      private System.Windows.Forms.Label lblExtraInfo;
      private System.Windows.Forms.Label lblThongTinKhac;
      private System.ComponentModel.BackgroundWorker sendRequestProcess;
      private System.Windows.Forms.ErrorProvider errorProvider;
      private System.Windows.Forms.Label lblSide;
   }
}