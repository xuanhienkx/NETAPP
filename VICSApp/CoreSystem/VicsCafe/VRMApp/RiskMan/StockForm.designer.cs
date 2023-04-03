namespace VRMApp.RiskMan
{
   partial class StockForm
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
         this.label8 = new System.Windows.Forms.Label();
         this.findButton = new System.Windows.Forms.Button();
         this.priceText = new System.Windows.Forms.TextBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.giatriNumberUpDown = new System.Windows.Forms.NumericUpDown();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.exitButton = new System.Windows.Forms.Button();
         this.saveButton = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.giatriNumberUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.findButton);
         this.groupBox1.Controls.Add(this.priceText);
         this.groupBox1.Controls.Add(this.textBox1);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.giatriNumberUpDown);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(347, 129);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(208, 94);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(57, 13);
         this.label8.TabIndex = 22;
         this.label8.Text = "ngàn VND";
         // 
         // findButton
         // 
         this.findButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.findButton.Image = global::VRMApp.Properties.Resources.find;
         this.findButton.Location = new System.Drawing.Point(250, 17);
         this.findButton.Name = "findButton";
         this.findButton.Size = new System.Drawing.Size(76, 28);
         this.findButton.TabIndex = 5;
         this.findButton.Text = "&Tìm";
         this.findButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.findButton.UseVisualStyleBackColor = true;
         this.findButton.Click += new System.EventHandler(this.findButton_Click);
         // 
         // priceText
         // 
         this.priceText.Location = new System.Drawing.Point(127, 91);
         this.priceText.Name = "priceText";
         this.priceText.Size = new System.Drawing.Size(75, 20);
         this.priceText.TabIndex = 21;
         // 
         // textBox1
         // 
         this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox1.Location = new System.Drawing.Point(109, 20);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(131, 23);
         this.textBox1.TabIndex = 1;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(20, 94);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(101, 13);
         this.label7.TabIndex = 20;
         this.label7.Text = "Giá trần khống chế:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(18, 25);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(91, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Mã chứng khoán:";
         // 
         // giatriNumberUpDown
         // 
         this.giatriNumberUpDown.Location = new System.Drawing.Point(127, 60);
         this.giatriNumberUpDown.Name = "giatriNumberUpDown";
         this.giatriNumberUpDown.Size = new System.Drawing.Size(48, 20);
         this.giatriNumberUpDown.TabIndex = 18;
         this.giatriNumberUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(181, 62);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(15, 13);
         this.label3.TabIndex = 17;
         this.label3.Text = "%";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(18, 62);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(103, 13);
         this.label2.TabIndex = 15;
         this.label2.Text = "Tỉ lệ giá trị đảm bảo:";
         // 
         // exitButton
         // 
         this.exitButton.Image = global::VRMApp.Properties.Resources.cancel;
         this.exitButton.Location = new System.Drawing.Point(197, 158);
         this.exitButton.Name = "exitButton";
         this.exitButton.Size = new System.Drawing.Size(85, 31);
         this.exitButton.TabIndex = 15;
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
         this.saveButton.TabIndex = 14;
         this.saveButton.Text = "&Lưu";
         this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.saveButton.UseVisualStyleBackColor = true;
         this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
         // 
         // StockForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(371, 209);
         this.Controls.Add(this.exitButton);
         this.Controls.Add(this.saveButton);
         this.Controls.Add(this.groupBox1);
         this.Name = "StockForm";
         this.Text = "Chứng khoán hợp tác";
         this.Load += new System.EventHandler(this.StockForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.giatriNumberUpDown)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown giatriNumberUpDown;
      private System.Windows.Forms.Button exitButton;
      private System.Windows.Forms.Button saveButton;
      private System.Windows.Forms.Button findButton;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.TextBox priceText;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
   }
}