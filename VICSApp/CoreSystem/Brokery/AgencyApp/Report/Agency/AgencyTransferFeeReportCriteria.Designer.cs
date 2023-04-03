using System.Windows.Forms;
using System.ComponentModel;

namespace Brokery.Report.Agency
{
    partial class AgencyTransferFeeReportCriteria
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgencyTransferFeeReportCriteria));
          this.mainProgressBar = new System.Windows.Forms.ProgressBar();
          this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
          this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
          this.label4 = new System.Windows.Forms.Label();
          this.branchCodeTextBox = new System.Windows.Forms.TextBox();
          this.label7 = new System.Windows.Forms.Label();
          this.tradeCodeBox = new System.Windows.Forms.TextBox();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.label6 = new System.Windows.Forms.Label();
          this.transferFee = new System.Windows.Forms.NumericUpDown();
          this.toDatePicker = new System.Windows.Forms.DateTimePicker();
          this.label2 = new System.Windows.Forms.Label();
          this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
          this.label1 = new System.Windows.Forms.Label();
          this.closeButton = new System.Windows.Forms.Button();
          this.printButton = new System.Windows.Forms.Button();
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.transferFee)).BeginInit();
          this.SuspendLayout();
          // 
          // mainProgressBar
          // 
          this.mainProgressBar.Location = new System.Drawing.Point(1, 156);
          this.mainProgressBar.Name = "mainProgressBar";
          this.mainProgressBar.Size = new System.Drawing.Size(445, 13);
          this.mainProgressBar.TabIndex = 3;
          // 
          // errorProvider
          // 
          this.errorProvider.ContainerControl = this;
          // 
          // backgroundWorker
          // 
          this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
          this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(225, 20);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(43, 13);
          this.label4.TabIndex = 0;
          this.label4.Text = "Mã CN:";
          // 
          // branchCodeTextBox
          // 
          this.branchCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
          this.branchCodeTextBox.Location = new System.Drawing.Point(271, 17);
          this.branchCodeTextBox.MaxLength = 3;
          this.branchCodeTextBox.Name = "branchCodeTextBox";
          this.branchCodeTextBox.ReadOnly = true;
          this.branchCodeTextBox.Size = new System.Drawing.Size(38, 20);
          this.branchCodeTextBox.TabIndex = 4;
          this.branchCodeTextBox.TabStop = false;
          this.branchCodeTextBox.Text = "200";
          this.branchCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(8, 20);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(71, 13);
          this.label7.TabIndex = 15;
          this.label7.Text = "Mã giao dịch:";
          // 
          // tradeCodeBox
          // 
          this.tradeCodeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.tradeCodeBox.Location = new System.Drawing.Point(82, 17);
          this.tradeCodeBox.MaxLength = 3;
          this.tradeCodeBox.Name = "tradeCodeBox";
          this.tradeCodeBox.ReadOnly = true;
          this.tradeCodeBox.Size = new System.Drawing.Size(100, 20);
          this.tradeCodeBox.TabIndex = 16;
          this.tradeCodeBox.TabStop = false;
          this.tradeCodeBox.Text = "VICSHCM";
          this.tradeCodeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.label6);
          this.groupBox1.Controls.Add(this.transferFee);
          this.groupBox1.Controls.Add(this.toDatePicker);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.fromDatePicker);
          this.groupBox1.Controls.Add(this.tradeCodeBox);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Controls.Add(this.label7);
          this.groupBox1.Controls.Add(this.branchCodeTextBox);
          this.groupBox1.Controls.Add(this.label4);
          this.groupBox1.Location = new System.Drawing.Point(12, 8);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(419, 104);
          this.groupBox1.TabIndex = 0;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Thông tin lập báo cáo";
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(173, 83);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(95, 13);
          this.label6.TabIndex = 31;
          this.label6.Text = "Phí chuyển khoản";
          this.label6.Visible = false;
          // 
          // transferFee
          // 
          this.transferFee.DecimalPlaces = 2;
          this.transferFee.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
          this.transferFee.Location = new System.Drawing.Point(271, 79);
          this.transferFee.Name = "transferFee";
          this.transferFee.Size = new System.Drawing.Size(59, 20);
          this.transferFee.TabIndex = 2;
          this.transferFee.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
          this.transferFee.Visible = false;
          // 
          // toDatePicker
          // 
          this.toDatePicker.CustomFormat = "dd/MM/yyyy";
          this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
          this.toDatePicker.Location = new System.Drawing.Point(271, 48);
          this.toDatePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
          this.toDatePicker.Name = "toDatePicker";
          this.toDatePicker.Size = new System.Drawing.Size(93, 20);
          this.toDatePicker.TabIndex = 1;
          this.toDatePicker.Value = new System.DateTime(2007, 5, 27, 11, 13, 20, 483);
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(212, 52);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(56, 13);
          this.label2.TabIndex = 18;
          this.label2.Text = "Đến ngày:";
          // 
          // fromDatePicker
          // 
          this.fromDatePicker.CustomFormat = "dd/MM/yyyy";
          this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
          this.fromDatePicker.Location = new System.Drawing.Point(82, 48);
          this.fromDatePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
          this.fromDatePicker.Name = "fromDatePicker";
          this.fromDatePicker.Size = new System.Drawing.Size(100, 20);
          this.fromDatePicker.TabIndex = 0;
          this.fromDatePicker.Value = new System.DateTime(2007, 5, 27, 11, 13, 20, 483);
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(27, 52);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(49, 13);
          this.label1.TabIndex = 12;
          this.label1.Text = "Từ ngày:";
          // 
          // closeButton
          // 
          this.closeButton.Image = global::Brokery.Properties.Resources.cancel;
          this.closeButton.Location = new System.Drawing.Point(334, 120);
          this.closeButton.Name = "closeButton";
          this.closeButton.Size = new System.Drawing.Size(99, 32);
          this.closeButton.TabIndex = 6;
          this.closeButton.Text = "Thoát";
          this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
          this.closeButton.UseVisualStyleBackColor = true;
          this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
          // 
          // printButton
          // 
          this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
          this.printButton.Location = new System.Drawing.Point(204, 120);
          this.printButton.Name = "printButton";
          this.printButton.Size = new System.Drawing.Size(99, 32);
          this.printButton.TabIndex = 5;
          this.printButton.Text = "Xem báo cáo";
          this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
          this.printButton.UseVisualStyleBackColor = true;
          this.printButton.Click += new System.EventHandler(this.printButton_Click);
          // 
          // AgencyTransferFeeReportCriteria
          // 
          this.ClientSize = new System.Drawing.Size(445, 181);
          this.Controls.Add(this.mainProgressBar);
          this.Controls.Add(this.closeButton);
          this.Controls.Add(this.printButton);
          this.Controls.Add(this.groupBox1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AgencyTransferFeeReportCriteria";
          this.Text = "Báo cáo phí đại lý";
          this.Load += new System.EventHandler(this.AgencyTransferFeeReportCriteria_Load);
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.transferFee)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private Button closeButton;
      private Button printButton;
      private ProgressBar mainProgressBar;
      private ErrorProvider errorProvider;
      private BackgroundWorker backgroundWorker;
      private GroupBox groupBox1;
      private TextBox tradeCodeBox;
      private Label label7;
      private TextBox branchCodeTextBox;
      private Label label4;
      private DateTimePicker fromDatePicker;
      private Label label1;
      private DateTimePicker toDatePicker;
      private Label label2;
      private Label label6;
      private NumericUpDown transferFee;
   }
}