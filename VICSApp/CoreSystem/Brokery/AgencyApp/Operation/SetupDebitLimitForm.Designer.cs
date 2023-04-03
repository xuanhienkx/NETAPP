namespace Brokery.Operation
{
   partial class SetupDebitLimitForm
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
         this.btnClose = new System.Windows.Forms.Button();
         this.btnAccept = new System.Windows.Forms.Button();
         this.txtAmount = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.lblCurrentDebitLimit = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.lblUsedDebitLimitAmount = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.lblTotalDebitAmount = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.cboAgents = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.cboBranches = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label7 = new System.Windows.Forms.Label();
         this.lblAgenDebit = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.lblAgentUsed = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.lblAgentCurrent = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnClose
         // 
         this.btnClose.Image = global::Brokery.Properties.Resources.cancel;
         this.btnClose.Location = new System.Drawing.Point(353, 282);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(80, 30);
         this.btnClose.TabIndex = 14;
         this.btnClose.Text = "Đóng lại";
         this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btnClose.UseVisualStyleBackColor = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // btnAccept
         // 
         this.btnAccept.Image = global::Brokery.Properties.Resources.accept;
         this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnAccept.Location = new System.Drawing.Point(262, 282);
         this.btnAccept.Name = "btnAccept";
         this.btnAccept.Size = new System.Drawing.Size(80, 30);
         this.btnAccept.TabIndex = 13;
         this.btnAccept.Text = "Đồng ý";
         this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btnAccept.UseVisualStyleBackColor = true;
         this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
         // 
         // txtAmount
         // 
         this.txtAmount.Location = new System.Drawing.Point(155, 248);
         this.txtAmount.Name = "txtAmount";
         this.txtAmount.Size = new System.Drawing.Size(139, 20);
         this.txtAmount.TabIndex = 11;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(34, 251);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(115, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Hạn mức tín dụng mới:";
         // 
         // lblCurrentDebitLimit
         // 
         this.lblCurrentDebitLimit.AutoSize = true;
         this.lblCurrentDebitLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCurrentDebitLimit.ForeColor = System.Drawing.Color.Red;
         this.lblCurrentDebitLimit.Location = new System.Drawing.Point(128, 54);
         this.lblCurrentDebitLimit.Name = "lblCurrentDebitLimit";
         this.lblCurrentDebitLimit.Size = new System.Drawing.Size(29, 16);
         this.lblCurrentDebitLimit.TabIndex = 9;
         this.lblCurrentDebitLimit.Text = "0 đ";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(35, 56);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(87, 13);
         this.label6.TabIndex = 8;
         this.label6.Text = "Hạn mức còn lại:";
         // 
         // lblUsedDebitLimitAmount
         // 
         this.lblUsedDebitLimitAmount.AutoSize = true;
         this.lblUsedDebitLimitAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblUsedDebitLimitAmount.ForeColor = System.Drawing.Color.Navy;
         this.lblUsedDebitLimitAmount.Location = new System.Drawing.Point(128, 34);
         this.lblUsedDebitLimitAmount.Name = "lblUsedDebitLimitAmount";
         this.lblUsedDebitLimitAmount.Size = new System.Drawing.Size(29, 16);
         this.lblUsedDebitLimitAmount.TabIndex = 7;
         this.lblUsedDebitLimitAmount.Text = "0 đ";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 36);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(110, 13);
         this.label5.TabIndex = 6;
         this.label5.Text = "Hạn mức đã sử dụng:";
         // 
         // lblTotalDebitAmount
         // 
         this.lblTotalDebitAmount.AutoSize = true;
         this.lblTotalDebitAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTotalDebitAmount.ForeColor = System.Drawing.Color.Green;
         this.lblTotalDebitAmount.Location = new System.Drawing.Point(128, 14);
         this.lblTotalDebitAmount.Name = "lblTotalDebitAmount";
         this.lblTotalDebitAmount.Size = new System.Drawing.Size(29, 16);
         this.lblTotalDebitAmount.TabIndex = 5;
         this.lblTotalDebitAmount.Text = "0 đ";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 16);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(116, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Tổng hạn mức đã cấp:";
         // 
         // cboAgents
         // 
         this.cboAgents.FormattingEnabled = true;
         this.cboAgents.Location = new System.Drawing.Point(155, 130);
         this.cboAgents.Name = "cboAgents";
         this.cboAgents.Size = new System.Drawing.Size(187, 21);
         this.cboAgents.TabIndex = 3;
         this.cboAgents.SelectedIndexChanged += new System.EventHandler(this.cboAgents_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(31, 133);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(118, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Phòng giao dịch/Đại lý:";
         // 
         // cboBranches
         // 
         this.cboBranches.FormattingEnabled = true;
         this.cboBranches.Location = new System.Drawing.Point(155, 15);
         this.cboBranches.Name = "cboBranches";
         this.cboBranches.Size = new System.Drawing.Size(187, 21);
         this.cboBranches.TabIndex = 1;
         this.cboBranches.SelectedIndexChanged += new System.EventHandler(this.cboBranches_SelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(56, 18);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(93, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Hội sở/Chi nhánh:";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.lblTotalDebitAmount);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.lblUsedDebitLimitAmount);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.lblCurrentDebitLimit);
         this.groupBox1.Location = new System.Drawing.Point(155, 42);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(276, 82);
         this.groupBox1.TabIndex = 15;
         this.groupBox1.TabStop = false;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.label7);
         this.groupBox2.Controls.Add(this.lblAgenDebit);
         this.groupBox2.Controls.Add(this.label9);
         this.groupBox2.Controls.Add(this.lblAgentUsed);
         this.groupBox2.Controls.Add(this.label11);
         this.groupBox2.Controls.Add(this.lblAgentCurrent);
         this.groupBox2.Location = new System.Drawing.Point(155, 157);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(276, 82);
         this.groupBox2.TabIndex = 16;
         this.groupBox2.TabStop = false;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(6, 16);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(116, 13);
         this.label7.TabIndex = 4;
         this.label7.Text = "Tổng hạn mức đã cấp:";
         // 
         // lblAgenDebit
         // 
         this.lblAgenDebit.AutoSize = true;
         this.lblAgenDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAgenDebit.ForeColor = System.Drawing.Color.Green;
         this.lblAgenDebit.Location = new System.Drawing.Point(128, 14);
         this.lblAgenDebit.Name = "lblAgenDebit";
         this.lblAgenDebit.Size = new System.Drawing.Size(29, 16);
         this.lblAgenDebit.TabIndex = 5;
         this.lblAgenDebit.Text = "0 đ";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(12, 36);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(110, 13);
         this.label9.TabIndex = 6;
         this.label9.Text = "Hạn mức đã sử dụng:";
         // 
         // lblAgentUsed
         // 
         this.lblAgentUsed.AutoSize = true;
         this.lblAgentUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAgentUsed.ForeColor = System.Drawing.Color.Navy;
         this.lblAgentUsed.Location = new System.Drawing.Point(128, 34);
         this.lblAgentUsed.Name = "lblAgentUsed";
         this.lblAgentUsed.Size = new System.Drawing.Size(29, 16);
         this.lblAgentUsed.TabIndex = 7;
         this.lblAgentUsed.Text = "0 đ";
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(35, 56);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(87, 13);
         this.label11.TabIndex = 8;
         this.label11.Text = "Hạn mức còn lại:";
         // 
         // lblAgentCurrent
         // 
         this.lblAgentCurrent.AutoSize = true;
         this.lblAgentCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAgentCurrent.ForeColor = System.Drawing.Color.Red;
         this.lblAgentCurrent.Location = new System.Drawing.Point(128, 54);
         this.lblAgentCurrent.Name = "lblAgentCurrent";
         this.lblAgentCurrent.Size = new System.Drawing.Size(29, 16);
         this.lblAgentCurrent.TabIndex = 9;
         this.lblAgentCurrent.Text = "0 đ";
         // 
         // SetupDebitLimitForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(468, 334);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.btnAccept);
         this.Controls.Add(this.txtAmount);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.cboAgents);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.cboBranches);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SetupDebitLimitForm";
         this.Text = "Thiết lập hạn mức tín dụng đầu ngày cho chi nhánh/đại lý";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox cboBranches;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox cboAgents;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label lblTotalDebitAmount;
      private System.Windows.Forms.Label lblUsedDebitLimitAmount;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label lblCurrentDebitLimit;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtAmount;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.Button btnAccept;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label lblAgenDebit;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label lblAgentUsed;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label lblAgentCurrent;
   }
}