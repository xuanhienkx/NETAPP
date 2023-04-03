namespace VRMApp.Accountant
{
   partial class ShowBalanceAccountForm
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.label8 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.textBoxDauNgay = new System.Windows.Forms.TextBox();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.toDatedateTimePicker = new System.Windows.Forms.DateTimePicker();
         this.label7 = new System.Windows.Forms.Label();
         this.fromDatedateTimePicker = new System.Windows.Forms.DateTimePicker();
         this.label6 = new System.Windows.Forms.Label();
         this.TKChiTietTextBox = new System.Windows.Forms.TextBox();
         this.maQuanLyTextBox = new System.Windows.Forms.TextBox();
         this.TKTongHopTextBox = new System.Windows.Forms.TextBox();
         this.maCNtextBox = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.printButton = new System.Windows.Forms.Button();
         this.exitButton = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.label8);
         this.panel1.Controls.Add(this.label5);
         this.panel1.Controls.Add(this.textBoxDauNgay);
         this.panel1.Controls.Add(this.checkBox1);
         this.panel1.Controls.Add(this.toDatedateTimePicker);
         this.panel1.Controls.Add(this.label7);
         this.panel1.Controls.Add(this.fromDatedateTimePicker);
         this.panel1.Controls.Add(this.label6);
         this.panel1.Controls.Add(this.TKChiTietTextBox);
         this.panel1.Controls.Add(this.maQuanLyTextBox);
         this.panel1.Controls.Add(this.TKTongHopTextBox);
         this.panel1.Controls.Add(this.maCNtextBox);
         this.panel1.Controls.Add(this.label4);
         this.panel1.Controls.Add(this.label3);
         this.panel1.Controls.Add(this.label2);
         this.panel1.Controls.Add(this.label1);
         this.panel1.ImeMode = System.Windows.Forms.ImeMode.Alpha;
         this.panel1.Location = new System.Drawing.Point(12, 12);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(378, 188);
         this.panel1.TabIndex = 0;
         // 
         // label8
         // 
         this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.label8.ForeColor = System.Drawing.Color.Red;
         this.label8.Location = new System.Drawing.Point(41, 51);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(297, 43);
         this.label8.TabIndex = 15;
         this.label8.Text = "Lưu ý: Khi liệt kê tài khoản tổng, nếu bạn đã có sẵn số dư đầu ngày thì vui lòng " +
             "nhập vào để chương trình lấy dữ liệu được nhanh hơn";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(97, 29);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(72, 13);
         this.label5.TabIndex = 14;
         this.label5.Text = "Dư đầu ngày:";
         // 
         // textBoxDauNgay
         // 
         this.textBoxDauNgay.Enabled = false;
         this.textBoxDauNgay.Location = new System.Drawing.Point(183, 22);
         this.textBoxDauNgay.Name = "textBoxDauNgay";
         this.textBoxDauNgay.Size = new System.Drawing.Size(100, 20);
         this.textBoxDauNgay.TabIndex = 1;
         this.textBoxDauNgay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(44, 8);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(129, 17);
         this.checkBox1.TabIndex = 0;
         this.checkBox1.Text = "Liệt kê tài khoản tổng";
         this.checkBox1.UseVisualStyleBackColor = true;
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // toDatedateTimePicker
         // 
         this.toDatedateTimePicker.CustomFormat = "";
         this.toDatedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.toDatedateTimePicker.Location = new System.Drawing.Point(255, 152);
         this.toDatedateTimePicker.Name = "toDatedateTimePicker";
         this.toDatedateTimePicker.Size = new System.Drawing.Size(87, 20);
         this.toDatedateTimePicker.TabIndex = 5;
         this.toDatedateTimePicker.Value = new System.DateTime(2010, 9, 16, 14, 54, 51, 0);
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(190, 158);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(59, 13);
         this.label7.TabIndex = 12;
         this.label7.Text = "Đến ngày :";
         // 
         // fromDatedateTimePicker
         // 
         this.fromDatedateTimePicker.CustomFormat = "";
         this.fromDatedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.fromDatedateTimePicker.Location = new System.Drawing.Point(88, 152);
         this.fromDatedateTimePicker.Name = "fromDatedateTimePicker";
         this.fromDatedateTimePicker.Size = new System.Drawing.Size(87, 20);
         this.fromDatedateTimePicker.TabIndex = 4;
         this.fromDatedateTimePicker.Value = new System.DateTime(2010, 9, 16, 14, 54, 51, 0);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(30, 158);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(52, 13);
         this.label6.TabIndex = 10;
         this.label6.Text = "Từ ngày :";
         // 
         // TKChiTietTextBox
         // 
         this.TKChiTietTextBox.Location = new System.Drawing.Point(248, 121);
         this.TKChiTietTextBox.MaxLength = 10;
         this.TKChiTietTextBox.Name = "TKChiTietTextBox";
         this.TKChiTietTextBox.Size = new System.Drawing.Size(90, 20);
         this.TKChiTietTextBox.TabIndex = 2;
         // 
         // maQuanLyTextBox
         // 
         this.maQuanLyTextBox.Location = new System.Drawing.Point(183, 121);
         this.maQuanLyTextBox.MaxLength = 4;
         this.maQuanLyTextBox.Name = "maQuanLyTextBox";
         this.maQuanLyTextBox.Size = new System.Drawing.Size(43, 20);
         this.maQuanLyTextBox.TabIndex = 3;
         // 
         // TKTongHopTextBox
         // 
         this.TKTongHopTextBox.Location = new System.Drawing.Point(100, 121);
         this.TKTongHopTextBox.MaxLength = 6;
         this.TKTongHopTextBox.Name = "TKTongHopTextBox";
         this.TKTongHopTextBox.Size = new System.Drawing.Size(63, 20);
         this.TKTongHopTextBox.TabIndex = 2;
         // 
         // maCNtextBox
         // 
         this.maCNtextBox.Location = new System.Drawing.Point(44, 122);
         this.maCNtextBox.Name = "maCNtextBox";
         this.maCNtextBox.ReadOnly = true;
         this.maCNtextBox.Size = new System.Drawing.Size(37, 20);
         this.maCNtextBox.TabIndex = 4;
         this.maCNtextBox.TabStop = false;
         this.maCNtextBox.Text = "200";
         this.maCNtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(245, 105);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(54, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "Tk chi tiết";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(180, 105);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(59, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Mã quản lý";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(97, 105);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(66, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "TK tổng hợp";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(41, 105);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(40, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Mã CN";
         // 
         // printButton
         // 
         this.printButton.Image = global::VRMApp.Properties.Resources.printer;
         this.printButton.Location = new System.Drawing.Point(200, 215);
         this.printButton.Name = "printButton";
         this.printButton.Size = new System.Drawing.Size(85, 31);
         this.printButton.TabIndex = 6;
         this.printButton.Text = "&In báo cáo";
         this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.printButton.UseVisualStyleBackColor = true;
         this.printButton.Click += new System.EventHandler(this.printButton_Click);
         // 
         // exitButton
         // 
         this.exitButton.Image = global::VRMApp.Properties.Resources.cancel;
         this.exitButton.Location = new System.Drawing.Point(305, 215);
         this.exitButton.Name = "exitButton";
         this.exitButton.Size = new System.Drawing.Size(85, 31);
         this.exitButton.TabIndex = 7;
         this.exitButton.Text = "&Thoát";
         this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.exitButton.UseVisualStyleBackColor = true;
         this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
         // 
         // ShowBalanceAccountForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(402, 266);
         this.Controls.Add(this.printButton);
         this.Controls.Add(this.exitButton);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "ShowBalanceAccountForm";
         this.Text = "Liệt kê tài khoản nội bảng";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.TextBox maCNtextBox;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox TKChiTietTextBox;
      private System.Windows.Forms.TextBox maQuanLyTextBox;
      private System.Windows.Forms.TextBox TKTongHopTextBox;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.DateTimePicker fromDatedateTimePicker;
      private System.Windows.Forms.DateTimePicker toDatedateTimePicker;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Button printButton;
      private System.Windows.Forms.Button exitButton;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox textBoxDauNgay;
      private System.Windows.Forms.Label label8;
   }
}