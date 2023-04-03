namespace VRMApp.Accountant
{
   partial class ContractReportForm
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
         this.label3 = new System.Windows.Forms.Label();
         this.comboBox = new System.Windows.Forms.ComboBox();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.comboBox);
         this.panel1.Controls.Add(this.label3);
         this.panel1.Controls.Add(this.fromDate);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Controls.Add(this.toDate);
         this.panel1.Controls.Add(this.label2);
         this.panel1.Location = new System.Drawing.Point(12, 12);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(303, 112);
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
         this.toDate.Location = new System.Drawing.Point(132, 46);
         this.toDate.Name = "toDate";
         this.toDate.Size = new System.Drawing.Size(101, 20);
         this.toDate.TabIndex = 3;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(60, 50);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Đến ngày:";
         // 
         // button1
         // 
         this.button1.Image = global::VRMApp.Properties.Resources.printer;
         this.button1.Location = new System.Drawing.Point(107, 141);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(115, 32);
         this.button1.TabIndex = 1;
         this.button1.Text = "In danh sách";
         this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(75, 81);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(41, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Đơn vị:";
         // 
         // comboBox
         // 
         this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox.FormattingEnabled = true;
         this.comboBox.Location = new System.Drawing.Point(132, 78);
         this.comboBox.Name = "comboBox";
         this.comboBox.Size = new System.Drawing.Size(143, 21);
         this.comboBox.TabIndex = 7;
         // 
         // ContractReportForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(328, 185);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ContractReportForm";
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
      private System.Windows.Forms.ComboBox comboBox;
      private System.Windows.Forms.Label label3;
   }
}