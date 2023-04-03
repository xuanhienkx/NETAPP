﻿namespace VRMApp.Accountant
{
   partial class BankTransactiontReportForm
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
         this.fromDate = new System.Windows.Forms.DateTimePicker();
         this.label1 = new System.Windows.Forms.Label();
         this.toDate = new System.Windows.Forms.DateTimePicker();
         this.label2 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.label3);
         this.panel1.Controls.Add(this.comboBox1);
         this.panel1.Controls.Add(this.fromDate);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Controls.Add(this.toDate);
         this.panel1.Controls.Add(this.label2);
         this.panel1.Location = new System.Drawing.Point(12, 12);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(303, 117);
         this.panel1.TabIndex = 0;
         // 
         // fromDate
         // 
         this.fromDate.CustomFormat = "dd/MM/yyyy";
         this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.fromDate.Location = new System.Drawing.Point(132, 11);
         this.fromDate.Name = "fromDate";
         this.fromDate.Size = new System.Drawing.Size(101, 20);
         this.fromDate.TabIndex = 5;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(67, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(49, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "Từ ngày:";
         // 
         // toDate
         // 
         this.toDate.CustomFormat = "dd/MM/yyyy";
         this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.toDate.Location = new System.Drawing.Point(132, 44);
         this.toDate.Name = "toDate";
         this.toDate.Size = new System.Drawing.Size(101, 20);
         this.toDate.TabIndex = 3;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(60, 48);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Đến ngày:";
         // 
         // button1
         // 
         this.button1.Image = global::VRMApp.Properties.Resources.printer;
         this.button1.Location = new System.Drawing.Point(104, 154);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(115, 32);
         this.button1.TabIndex = 1;
         this.button1.Text = "In danh sách";
         this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // comboBox1
         // 
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(132, 77);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(121, 21);
         this.comboBox1.TabIndex = 6;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(67, 82);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(49, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Loại HĐ:";
         // 
         // BankTransactiontReportForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(328, 212);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BankTransactiontReportForm";
         this.Text = "DS hợp đồng ƯT với ngân hàng";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DateTimePicker toDate;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.DateTimePicker fromDate;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox comboBox1;
   }
}