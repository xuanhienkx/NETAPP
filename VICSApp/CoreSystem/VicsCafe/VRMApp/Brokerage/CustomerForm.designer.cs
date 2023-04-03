namespace VRMApp.Brokerage
{
   partial class CustomerForm
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.findButton = new System.Windows.Forms.Button();
         this.tilyNumberUpDown = new System.Windows.Forms.NumericUpDown();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.lblCustomerName = new System.Windows.Forms.Label();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.exitButton = new System.Windows.Forms.Button();
         this.saveButton = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tilyNumberUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.findButton);
         this.groupBox1.Controls.Add(this.tilyNumberUpDown);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.lblCustomerName);
         this.groupBox1.Controls.Add(this.textBox1);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(347, 131);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // findButton
         // 
         this.findButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.findButton.Image = global::VRMApp.Properties.Resources.find;
         this.findButton.Location = new System.Drawing.Point(250, 17);
         this.findButton.Name = "findButton";
         this.findButton.Size = new System.Drawing.Size(76, 28);
         this.findButton.TabIndex = 11;
         this.findButton.Text = "&Tìm";
         this.findButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.findButton.UseVisualStyleBackColor = true;
         this.findButton.Click += new System.EventHandler(this.findButton_Click);
         // 
         // tilyNumberUpDown
         // 
         this.tilyNumberUpDown.Location = new System.Drawing.Point(145, 92);
         this.tilyNumberUpDown.Name = "tilyNumberUpDown";
         this.tilyNumberUpDown.Size = new System.Drawing.Size(57, 20);
         this.tilyNumberUpDown.TabIndex = 10;
         this.tilyNumberUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(208, 94);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(15, 13);
         this.label3.TabIndex = 9;
         this.label3.Text = "%";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(14, 94);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(125, 13);
         this.label2.TabIndex = 8;
         this.label2.Text = "Tỉ lệ hợp tác kinh doanh:";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(14, 58);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(89, 13);
         this.label6.TabIndex = 4;
         this.label6.Text = "Tên khách hàng:";
         // 
         // lblCustomerName
         // 
         this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCustomerName.ForeColor = System.Drawing.SystemColors.Desktop;
         this.lblCustomerName.Location = new System.Drawing.Point(109, 55);
         this.lblCustomerName.Name = "lblCustomerName";
         this.lblCustomerName.Size = new System.Drawing.Size(217, 20);
         this.lblCustomerName.TabIndex = 3;
         // 
         // textBox1
         // 
         this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox1.Location = new System.Drawing.Point(109, 20);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(131, 23);
         this.textBox1.TabIndex = 1;
         this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(21, 25);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(82, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Mã khách hàng";
         // 
         // exitButton
         // 
         this.exitButton.Image = global::VRMApp.Properties.Resources.cancel;
         this.exitButton.Location = new System.Drawing.Point(197, 158);
         this.exitButton.Name = "exitButton";
         this.exitButton.Size = new System.Drawing.Size(85, 31);
         this.exitButton.TabIndex = 17;
         this.exitButton.Text = "&Thoát";
         this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.exitButton.UseVisualStyleBackColor = true;
         this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
         // 
         // saveButton
         // 
         this.saveButton.Image = global::VRMApp.Properties.Resources.disk;
         this.saveButton.Location = new System.Drawing.Point(89, 158);
         this.saveButton.Name = "saveButton";
         this.saveButton.Size = new System.Drawing.Size(85, 31);
         this.saveButton.TabIndex = 16;
         this.saveButton.Text = "&Lưu";
         this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.saveButton.UseVisualStyleBackColor = true;
         this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
         // 
         // CustomerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(371, 206);
         this.Controls.Add(this.exitButton);
         this.Controls.Add(this.saveButton);
         this.Controls.Add(this.groupBox1);
         this.MaximizeBox = false;
         this.Name = "CustomerForm";
         this.Text = "Khách hàng hợp tác kinh doanh";
         this.Load += new System.EventHandler(this.CustomerForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tilyNumberUpDown)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label lblCustomerName;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.NumericUpDown tilyNumberUpDown;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button exitButton;
      private System.Windows.Forms.Button saveButton;
      private System.Windows.Forms.Button findButton;
   }
}