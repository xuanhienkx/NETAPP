namespace Brokery.Operation
{
   partial class AgencyFeeAddEdit
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
          this.closeButton = new System.Windows.Forms.Button();
          this.oKButton = new System.Windows.Forms.Button();
          this.tradeCodeBox = new System.Windows.Forms.TextBox();
          this.label7 = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.valueFromTextBox = new System.Windows.Forms.TextBox();
          this.toValueTextBox = new System.Windows.Forms.TextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.agencyFeeTextBox = new System.Windows.Forms.TextBox();
          this.label3 = new System.Windows.Forms.Label();
          this.noteTextBox = new System.Windows.Forms.TextBox();
          this.label4 = new System.Windows.Forms.Label();
          this.label5 = new System.Windows.Forms.Label();
          this.label6 = new System.Windows.Forms.Label();
          this.label8 = new System.Windows.Forms.Label();
          this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
          this.SuspendLayout();
          // 
          // closeButton
          // 
          this.closeButton.Image = global::Brokery.Properties.Resources.delete;
          this.closeButton.Location = new System.Drawing.Point(250, 154);
          this.closeButton.Name = "closeButton";
          this.closeButton.Size = new System.Drawing.Size(83, 32);
          this.closeButton.TabIndex = 13;
          this.closeButton.Text = "Hủy bỏ";
          this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
          this.closeButton.UseVisualStyleBackColor = true;
          this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
          // 
          // oKButton
          // 
          this.oKButton.Image = global::Brokery.Properties.Resources.add;
          this.oKButton.Location = new System.Drawing.Point(148, 154);
          this.oKButton.Name = "oKButton";
          this.oKButton.Size = new System.Drawing.Size(83, 32);
          this.oKButton.TabIndex = 12;
          this.oKButton.Text = "Đồng ý";
          this.oKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
          this.oKButton.UseVisualStyleBackColor = true;
          this.oKButton.Click += new System.EventHandler(this.oKButton_Click);
          // 
          // tradeCodeBox
          // 
          this.tradeCodeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.tradeCodeBox.Location = new System.Drawing.Point(84, 12);
          this.tradeCodeBox.MaxLength = 3;
          this.tradeCodeBox.Name = "tradeCodeBox";
          this.tradeCodeBox.ReadOnly = true;
          this.tradeCodeBox.Size = new System.Drawing.Size(100, 20);
          this.tradeCodeBox.TabIndex = 18;
          this.tradeCodeBox.TabStop = false;
          this.tradeCodeBox.Text = "VICSHCM";
          this.tradeCodeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(10, 15);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(71, 13);
          this.label7.TabIndex = 17;
          this.label7.Text = "Mã giao dịch:";
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(10, 43);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(68, 13);
          this.label1.TabIndex = 19;
          this.label1.Text = "Giá trị GD từ:";
          // 
          // valueFromTextBox
          // 
          this.valueFromTextBox.Location = new System.Drawing.Point(84, 40);
          this.valueFromTextBox.Name = "valueFromTextBox";
          this.valueFromTextBox.Size = new System.Drawing.Size(100, 20);
          this.valueFromTextBox.TabIndex = 20;
          // 
          // toValueTextBox
          // 
          this.toValueTextBox.Location = new System.Drawing.Point(84, 66);
          this.toValueTextBox.Name = "toValueTextBox";
          this.toValueTextBox.Size = new System.Drawing.Size(100, 20);
          this.toValueTextBox.TabIndex = 22;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(10, 69);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(50, 13);
          this.label2.TabIndex = 21;
          this.label2.Text = "Đến dưới";
          // 
          // agencyFeeTextBox
          // 
          this.agencyFeeTextBox.Location = new System.Drawing.Point(84, 92);
          this.agencyFeeTextBox.Name = "agencyFeeTextBox";
          this.agencyFeeTextBox.Size = new System.Drawing.Size(100, 20);
          this.agencyFeeTextBox.TabIndex = 24;
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(10, 95);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(55, 13);
          this.label3.TabIndex = 23;
          this.label3.Text = "Phí đại lý:";
          // 
          // noteTextBox
          // 
          this.noteTextBox.Location = new System.Drawing.Point(84, 118);
          this.noteTextBox.Name = "noteTextBox";
          this.noteTextBox.Size = new System.Drawing.Size(229, 20);
          this.noteTextBox.TabIndex = 26;
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(10, 121);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(47, 13);
          this.label4.TabIndex = 25;
          this.label4.Text = "Ghi chú:";
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(190, 43);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(95, 13);
          this.label5.TabIndex = 27;
          this.label5.Text = "(đơn vị: triệu VNĐ)";
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(190, 95);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(57, 13);
          this.label6.TabIndex = 28;
          this.label6.Text = "(đơn vị: %)";
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Location = new System.Drawing.Point(190, 69);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(95, 13);
          this.label8.TabIndex = 29;
          this.label8.Text = "(đơn vị: triệu VNĐ)";
          // 
          // errorProvider1
          // 
          this.errorProvider1.ContainerControl = this;
          // 
          // AgencyFeeAddEdit
          // 
          this.AcceptButton = this.closeButton;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(345, 196);
          this.Controls.Add(this.label8);
          this.Controls.Add(this.label6);
          this.Controls.Add(this.label5);
          this.Controls.Add(this.noteTextBox);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.agencyFeeTextBox);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.toValueTextBox);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.valueFromTextBox);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.tradeCodeBox);
          this.Controls.Add(this.label7);
          this.Controls.Add(this.closeButton);
          this.Controls.Add(this.oKButton);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AgencyFeeAddEdit";
          this.Text = "Cập nhật phí đại lý";
          this.Load += new System.EventHandler(this.AgencyFeeAddEdit_Load);
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button closeButton;
      private System.Windows.Forms.Button oKButton;
      private System.Windows.Forms.TextBox tradeCodeBox;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox valueFromTextBox;
      private System.Windows.Forms.TextBox toValueTextBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox agencyFeeTextBox;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox noteTextBox;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.ErrorProvider errorProvider1;
   }
}