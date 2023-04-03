namespace Auto_A
{
   partial class Form1
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
         this.checkBox3 = new System.Windows.Forms.CheckBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.label4 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // checkBox3
         // 
         this.checkBox3.AutoSize = true;
         this.checkBox3.Location = new System.Drawing.Point(12, 25);
         this.checkBox3.Name = "checkBox3";
         this.checkBox3.Size = new System.Drawing.Size(236, 17);
         this.checkBox3.TabIndex = 2;
         this.checkBox3.Text = "Chỉ thực hiện với giao dịch có giá trị nhỏ hơn";
         this.checkBox3.UseVisualStyleBackColor = true;
         this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
         // 
         // textBox1
         // 
         this.textBox1.Enabled = false;
         this.textBox1.Location = new System.Drawing.Point(254, 23);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(124, 20);
         this.textBox1.TabIndex = 3;
         this.textBox1.Text = "0";
         this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(384, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(30, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "VNĐ";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(32, 54);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(150, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "Thời gian thực hiện giữa 2 lần:";
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(188, 51);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(89, 20);
         this.textBox2.TabIndex = 6;
         this.textBox2.Text = "3";
         this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(283, 54);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(26, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "giây";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(443, 12);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(131, 40);
         this.button1.TabIndex = 8;
         this.button1.Text = "Bắt đầu chạy";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(443, 65);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(131, 40);
         this.button2.TabIndex = 9;
         this.button2.Text = "Thoát";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // listBox1
         // 
         this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(12, 122);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(588, 316);
         this.listBox1.TabIndex = 10;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 92);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(102, 13);
         this.label4.TabIndex = 11;
         this.label4.Text = "Thông tin thực hiện:";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(614, 454);
         this.ControlBox = false;
         this.Controls.Add(this.label4);
         this.Controls.Add(this.listBox1);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.textBox2);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.checkBox3);
         this.Name = "Form1";
         this.Text = "Auto Approve Orders - Auto-A";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox checkBox3;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Label label4;
   }
}

