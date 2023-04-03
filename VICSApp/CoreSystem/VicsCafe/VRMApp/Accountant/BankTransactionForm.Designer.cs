namespace VRMApp.Accountant
{
   partial class BankTransactionForm
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
         this.label3 = new System.Windows.Forms.Label();
         this.txtBank = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.txtSection = new System.Windows.Forms.TextBox();
         this.NgayGDdateTimePicker = new System.Windows.Forms.DateTimePicker();
         this.label2 = new System.Windows.Forms.Label();
         this.TKTextBox = new System.Windows.Forms.TextBox();
         this.TKlabel = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.label3);
         this.panel1.Controls.Add(this.txtBank);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Controls.Add(this.txtSection);
         this.panel1.Controls.Add(this.NgayGDdateTimePicker);
         this.panel1.Controls.Add(this.label2);
         this.panel1.Controls.Add(this.TKTextBox);
         this.panel1.Controls.Add(this.TKlabel);
         this.panel1.Location = new System.Drawing.Point(12, 12);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(303, 105);
         this.panel1.TabIndex = 0;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(201, 18);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(89, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Tài khoản chi tiết";
         // 
         // txtBank
         // 
         this.txtBank.Location = new System.Drawing.Point(114, 35);
         this.txtBank.MaxLength = 4;
         this.txtBank.Name = "txtBank";
         this.txtBank.Size = new System.Drawing.Size(73, 20);
         this.txtBank.TabIndex = 2;
         this.txtBank.Text = "9999";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(111, 18);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(59, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "Mã quản lý";
         // 
         // txtSection
         // 
         this.txtSection.Location = new System.Drawing.Point(19, 35);
         this.txtSection.MaxLength = 6;
         this.txtSection.Name = "txtSection";
         this.txtSection.Size = new System.Drawing.Size(73, 20);
         this.txtSection.TabIndex = 1;
         this.txtSection.Text = "112356";
         // 
         // NgayGDdateTimePicker
         // 
         this.NgayGDdateTimePicker.CustomFormat = "dd/MM/yyyy";
         this.NgayGDdateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.NgayGDdateTimePicker.Location = new System.Drawing.Point(103, 66);
         this.NgayGDdateTimePicker.Name = "NgayGDdateTimePicker";
         this.NgayGDdateTimePicker.Size = new System.Drawing.Size(101, 20);
         this.NgayGDdateTimePicker.TabIndex = 4;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(16, 69);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(81, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Ngày giao dịch:";
         // 
         // TKTextBox
         // 
         this.TKTextBox.Location = new System.Drawing.Point(204, 35);
         this.TKTextBox.MaxLength = 10;
         this.TKTextBox.Name = "TKTextBox";
         this.TKTextBox.Size = new System.Drawing.Size(77, 20);
         this.TKTextBox.TabIndex = 3;
         this.TKTextBox.Text = "1123560001";
         // 
         // TKlabel
         // 
         this.TKlabel.AutoSize = true;
         this.TKlabel.Location = new System.Drawing.Point(16, 18);
         this.TKlabel.Name = "TKlabel";
         this.TKlabel.Size = new System.Drawing.Size(76, 13);
         this.TKlabel.TabIndex = 0;
         this.TKlabel.Text = "Mã ngân hàng";
         // 
         // button1
         // 
         this.button1.Image = global::VRMApp.Properties.Resources.printer;
         this.button1.Location = new System.Drawing.Point(127, 133);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(84, 32);
         this.button1.TabIndex = 5;
         this.button1.Text = "Liệt kê";
         this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // BankTransactionForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(328, 183);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BankTransactionForm";
         this.Text = "Liệt kê giao dịch tiền ngân hàng An Bình";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.TextBox TKTextBox;
      private System.Windows.Forms.Label TKlabel;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DateTimePicker NgayGDdateTimePicker;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtBank;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtSection;
   }
}