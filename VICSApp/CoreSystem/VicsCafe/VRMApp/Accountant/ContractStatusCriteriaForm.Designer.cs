namespace VRMApp.Accountant
{
   partial class ContractStatusCriteriaForm
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
         this.hetnoRadio = new System.Windows.Forms.RadioButton();
         this.coNoRadio = new System.Windows.Forms.RadioButton();
         this.tatcaRadio = new System.Windows.Forms.RadioButton();
         this.label6 = new System.Windows.Forms.Label();
         this.tranDatePicker = new System.Windows.Forms.DateTimePicker();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.maKHBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.tongHopButton = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.checkBox = new System.Windows.Forms.CheckBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.checkBox);
         this.groupBox1.Controls.Add(this.hetnoRadio);
         this.groupBox1.Controls.Add(this.coNoRadio);
         this.groupBox1.Controls.Add(this.tatcaRadio);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.tranDatePicker);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.maKHBox);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(312, 201);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Xem hết báo cáo với:";
         // 
         // hetnoRadio
         // 
         this.hetnoRadio.AutoSize = true;
         this.hetnoRadio.Location = new System.Drawing.Point(113, 167);
         this.hetnoRadio.Name = "hetnoRadio";
         this.hetnoRadio.Size = new System.Drawing.Size(140, 17);
         this.hetnoRadio.TabIndex = 19;
         this.hetnoRadio.Text = "Chỉ chưa thanh toán phí";
         this.hetnoRadio.UseVisualStyleBackColor = true;
         // 
         // coNoRadio
         // 
         this.coNoRadio.AutoSize = true;
         this.coNoRadio.Location = new System.Drawing.Point(113, 144);
         this.coNoRadio.Name = "coNoRadio";
         this.coNoRadio.Size = new System.Drawing.Size(174, 17);
         this.coNoRadio.TabIndex = 18;
         this.coNoRadio.Text = "Chưa thanh toán nợ gốc và phí";
         this.coNoRadio.UseVisualStyleBackColor = true;
         // 
         // tatcaRadio
         // 
         this.tatcaRadio.AutoSize = true;
         this.tatcaRadio.Checked = true;
         this.tatcaRadio.Location = new System.Drawing.Point(113, 121);
         this.tatcaRadio.Name = "tatcaRadio";
         this.tatcaRadio.Size = new System.Drawing.Size(81, 17);
         this.tatcaRadio.TabIndex = 17;
         this.tatcaRadio.TabStop = true;
         this.tatcaRadio.Text = "Đang có nợ";
         this.tatcaRadio.UseVisualStyleBackColor = true;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(33, 121);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(58, 13);
         this.label6.TabIndex = 16;
         this.label6.Text = "Tình trạng:";
         // 
         // tranDatePicker
         // 
         this.tranDatePicker.Location = new System.Drawing.Point(113, 63);
         this.tranDatePicker.Name = "tranDatePicker";
         this.tranDatePicker.Size = new System.Drawing.Size(135, 20);
         this.tranDatePicker.TabIndex = 12;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(33, 67);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(74, 13);
         this.label3.TabIndex = 11;
         this.label3.Text = "Ngày hết hạn:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.ForeColor = System.Drawing.Color.Tomato;
         this.label2.Location = new System.Drawing.Point(121, 42);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(122, 13);
         this.label2.TabIndex = 10;
         this.label2.Text = "* Bỏ trống để xem tất cả";
         // 
         // maKHBox
         // 
         this.maKHBox.Location = new System.Drawing.Point(124, 19);
         this.maKHBox.MaxLength = 10;
         this.maKHBox.Name = "maKHBox";
         this.maKHBox.Size = new System.Drawing.Size(135, 20);
         this.maKHBox.TabIndex = 9;
         this.maKHBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(33, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(85, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Mã khách hàng:";
         // 
         // tongHopButton
         // 
         this.tongHopButton.Image = global::VRMApp.Properties.Resources.find;
         this.tongHopButton.Location = new System.Drawing.Point(118, 228);
         this.tongHopButton.Name = "tongHopButton";
         this.tongHopButton.Size = new System.Drawing.Size(97, 28);
         this.tongHopButton.TabIndex = 1;
         this.tongHopButton.Text = "Xem tổng hợp";
         this.tongHopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.tongHopButton.UseVisualStyleBackColor = true;
         this.tongHopButton.Click += new System.EventHandler(this.tongHopButton_Click);
         // 
         // button1
         // 
         this.button1.Image = global::VRMApp.Properties.Resources.find;
         this.button1.Location = new System.Drawing.Point(227, 228);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(97, 28);
         this.button1.TabIndex = 2;
         this.button1.Text = "Xem chi tiết";
         this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // backgroundWorker
         // 
         this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
         this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
         // 
         // checkBox
         // 
         this.checkBox.AutoSize = true;
         this.checkBox.Checked = true;
         this.checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox.Location = new System.Drawing.Point(124, 89);
         this.checkBox.Name = "checkBox";
         this.checkBox.Size = new System.Drawing.Size(136, 17);
         this.checkBox.TabIndex = 20;
         this.checkBox.Text = "Lấy đúng ngày hết hạn";
         this.checkBox.UseVisualStyleBackColor = true;
         // 
         // ContractStatusCriteriaForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(339, 275);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.tongHopButton);
         this.Controls.Add(this.groupBox1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ContractStatusCriteriaForm";
         this.Text = "HĐKD không kỳ hạn: Chọn dữ liệu";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.DateTimePicker tranDatePicker;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox maKHBox;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.RadioButton coNoRadio;
      private System.Windows.Forms.RadioButton tatcaRadio;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Button tongHopButton;
      private System.Windows.Forms.Button button1;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.RadioButton hetnoRadio;
      private System.Windows.Forms.CheckBox checkBox;

   }
}