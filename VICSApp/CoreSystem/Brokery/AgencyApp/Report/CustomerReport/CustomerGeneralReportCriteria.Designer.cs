using System.Windows.Forms;
using System.ComponentModel;

namespace Brokery.Report.CustomerReport
{
    partial class CustomerGeneralReportCriteria
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerGeneralReportCriteria));
         this.mainProgressBar = new System.Windows.Forms.ProgressBar();
         this.closeButton = new System.Windows.Forms.Button();
         this.printButton = new System.Windows.Forms.Button();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.label3 = new System.Windows.Forms.Label();
         this.accountNameLabel = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.accountIdTextBox = new System.Windows.Forms.TextBox();
         this.branchCodeTextBox = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.tradeCodeBox = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.TransactionDatePicker = new System.Windows.Forms.DateTimePicker();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainProgressBar
         // 
         this.mainProgressBar.Location = new System.Drawing.Point(0, 182);
         this.mainProgressBar.Name = "mainProgressBar";
         this.mainProgressBar.Size = new System.Drawing.Size(445, 13);
         this.mainProgressBar.TabIndex = 3;
         // 
         // closeButton
         // 
         this.closeButton.Image = global::Brokery.Properties.Resources.cancel;
         this.closeButton.Location = new System.Drawing.Point(334, 140);
         this.closeButton.Name = "closeButton";
         this.closeButton.Size = new System.Drawing.Size(99, 32);
         this.closeButton.TabIndex = 3;
         this.closeButton.Text = "Thoát";
         this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.closeButton.UseVisualStyleBackColor = true;
         this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
         // 
         // printButton
         // 
         this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
         this.printButton.Location = new System.Drawing.Point(204, 140);
         this.printButton.Name = "printButton";
         this.printButton.Size = new System.Drawing.Size(99, 32);
         this.printButton.TabIndex = 2;
         this.printButton.Text = "Xem báo cáo";
         this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.printButton.UseVisualStyleBackColor = true;
         this.printButton.Click += new System.EventHandler(this.printButton_Click);
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
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(202, 16);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(55, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "TK chi tiết";
         // 
         // accountNameLabel
         // 
         this.accountNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.accountNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.accountNameLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
         this.accountNameLabel.Location = new System.Drawing.Point(117, 76);
         this.accountNameLabel.Name = "accountNameLabel";
         this.accountNameLabel.Size = new System.Drawing.Size(285, 23);
         this.accountNameLabel.TabIndex = 9;
         this.accountNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(131, 16);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(40, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Mã CN";
         // 
         // accountIdTextBox
         // 
         this.accountIdTextBox.BackColor = System.Drawing.SystemColors.Window;
         this.accountIdTextBox.Location = new System.Drawing.Point(205, 40);
         this.accountIdTextBox.MaxLength = 10;
         this.accountIdTextBox.Name = "accountIdTextBox";
         this.accountIdTextBox.Size = new System.Drawing.Size(76, 20);
         this.accountIdTextBox.TabIndex = 0;
         this.accountIdTextBox.Validated += new System.EventHandler(this.accountIdTextBox_Validated);
         // 
         // branchCodeTextBox
         // 
         this.branchCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.branchCodeTextBox.Location = new System.Drawing.Point(133, 40);
         this.branchCodeTextBox.MaxLength = 3;
         this.branchCodeTextBox.Name = "branchCodeTextBox";
         this.branchCodeTextBox.ReadOnly = true;
         this.branchCodeTextBox.Size = new System.Drawing.Size(38, 20);
         this.branchCodeTextBox.TabIndex = 4;
         this.branchCodeTextBox.TabStop = false;
         this.branchCodeTextBox.Text = "200";
         this.branchCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(39, 80);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(76, 13);
         this.label6.TabIndex = 8;
         this.label6.Text = "Tên tài khoản:";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(13, 16);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(68, 13);
         this.label7.TabIndex = 15;
         this.label7.Text = "Mã giao dịch";
         // 
         // tradeCodeBox
         // 
         this.tradeCodeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
         this.tradeCodeBox.Location = new System.Drawing.Point(15, 40);
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
         this.groupBox1.Controls.Add(this.TransactionDatePicker);
         this.groupBox1.Controls.Add(this.tradeCodeBox);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.branchCodeTextBox);
         this.groupBox1.Controls.Add(this.accountIdTextBox);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.accountNameLabel);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(419, 114);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // TransactionDatePicker
         // 
         this.TransactionDatePicker.CustomFormat = "dd/MM/yyyy";
         this.TransactionDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.TransactionDatePicker.Location = new System.Drawing.Point(309, 40);
         this.TransactionDatePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
         this.TransactionDatePicker.Name = "TransactionDatePicker";
         this.TransactionDatePicker.Size = new System.Drawing.Size(93, 20);
         this.TransactionDatePicker.TabIndex = 1;
         this.TransactionDatePicker.Value = new System.DateTime(2007, 5, 27, 11, 13, 20, 483);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(306, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(78, 13);
         this.label1.TabIndex = 12;
         this.label1.Text = "Ngày giao dịch";
         // 
         // CustomerGeneralReportCriteria
         // 
         this.ClientSize = new System.Drawing.Size(445, 204);
         this.Controls.Add(this.mainProgressBar);
         this.Controls.Add(this.closeButton);
         this.Controls.Add(this.printButton);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CustomerGeneralReportCriteria";
         this.Text = "Báo cáo tổng hợp tài khoản";
         this.Load += new System.EventHandler(this.TransactionReportCriteria_Load);
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
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
      private Label label6;
      private TextBox branchCodeTextBox;
      private TextBox accountIdTextBox;
      private Label label4;
      private Label accountNameLabel;
      private Label label3;
      private DateTimePicker TransactionDatePicker;
      private Label label1;
   }
}