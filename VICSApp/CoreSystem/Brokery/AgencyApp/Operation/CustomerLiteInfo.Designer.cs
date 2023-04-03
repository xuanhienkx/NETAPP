namespace Brokery.Operation
{
   partial class CustomerLiteInfo
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
         this.label1 = new System.Windows.Forms.Label();
         this.txtCustomerId = new System.Windows.Forms.TextBox();
         this.findButon = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.cboAgents = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.cboBranches = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.statusLabel = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.nameLabel = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.closeButton = new System.Windows.Forms.Button();
         this.oKButton = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 18);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(85, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Mã khách hàng:";
         // 
         // txtCustomerId
         // 
         this.txtCustomerId.Location = new System.Drawing.Point(103, 15);
         this.txtCustomerId.Name = "txtCustomerId";
         this.txtCustomerId.Size = new System.Drawing.Size(122, 20);
         this.txtCustomerId.TabIndex = 1;
         this.txtCustomerId.Validated += new System.EventHandler(this.textBox1_Validated);
         // 
         // findButon
         // 
         this.findButon.Image = global::Brokery.Properties.Resources.find;
         this.findButon.Location = new System.Drawing.Point(240, 9);
         this.findButon.Name = "findButon";
         this.findButon.Size = new System.Drawing.Size(75, 30);
         this.findButon.TabIndex = 2;
         this.findButon.Text = "&Tìm";
         this.findButon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.findButon.UseVisualStyleBackColor = true;
         this.findButon.Click += new System.EventHandler(this.findButon_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.cboAgents);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.cboBranches);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.statusLabel);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.nameLabel);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Location = new System.Drawing.Point(15, 45);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(349, 141);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Thông tin";
         // 
         // cboAgents
         // 
         this.cboAgents.FormattingEnabled = true;
         this.cboAgents.Location = new System.Drawing.Point(136, 108);
         this.cboAgents.Name = "cboAgents";
         this.cboAgents.Size = new System.Drawing.Size(192, 21);
         this.cboAgents.TabIndex = 7;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 112);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(118, 13);
         this.label5.TabIndex = 6;
         this.label5.Text = "Phòng giao dịch/Đại lý:";
         // 
         // cboBranches
         // 
         this.cboBranches.FormattingEnabled = true;
         this.cboBranches.Location = new System.Drawing.Point(136, 78);
         this.cboBranches.Name = "cboBranches";
         this.cboBranches.Size = new System.Drawing.Size(192, 21);
         this.cboBranches.TabIndex = 5;
         this.cboBranches.SelectedIndexChanged += new System.EventHandler(this.cboBranches_SelectedIndexChanged);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(37, 81);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(93, 13);
         this.label4.TabIndex = 4;
         this.label4.Text = "Hội sở/Chi nhánh:";
         // 
         // statusLabel
         // 
         this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
         this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.statusLabel.Location = new System.Drawing.Point(136, 46);
         this.statusLabel.Name = "statusLabel";
         this.statusLabel.Size = new System.Drawing.Size(192, 23);
         this.statusLabel.TabIndex = 3;
         this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(55, 50);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(75, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Tình trạng TK:";
         // 
         // nameLabel
         // 
         this.nameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
         this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.nameLabel.Location = new System.Drawing.Point(135, 14);
         this.nameLabel.Name = "nameLabel";
         this.nameLabel.Size = new System.Drawing.Size(192, 23);
         this.nameLabel.TabIndex = 1;
         this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(101, 19);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(29, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Tên:";
         // 
         // closeButton
         // 
         this.closeButton.Image = global::Brokery.Properties.Resources.delete;
         this.closeButton.Location = new System.Drawing.Point(281, 204);
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
         this.oKButton.Location = new System.Drawing.Point(179, 204);
         this.oKButton.Name = "oKButton";
         this.oKButton.Size = new System.Drawing.Size(83, 32);
         this.oKButton.TabIndex = 12;
         this.oKButton.Text = "Đồng ý";
         this.oKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.oKButton.UseVisualStyleBackColor = true;
         this.oKButton.Click += new System.EventHandler(this.oKButton_Click);
         // 
         // CustomerLiteInfo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(382, 248);
         this.Controls.Add(this.closeButton);
         this.Controls.Add(this.oKButton);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.findButon);
         this.Controls.Add(this.txtCustomerId);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CustomerLiteInfo";
         this.Text = "Khách hàng";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtCustomerId;
      private System.Windows.Forms.Button findButon;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label nameLabel;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label statusLabel;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button closeButton;
      private System.Windows.Forms.Button oKButton;
      private System.Windows.Forms.ComboBox cboBranches;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox cboAgents;
      private System.Windows.Forms.Label label5;
   }
}