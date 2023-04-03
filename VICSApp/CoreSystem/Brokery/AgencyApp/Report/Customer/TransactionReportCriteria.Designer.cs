using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System;
namespace AgencyApp.Report
{
   partial class TransactionReportCriteria
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionReportCriteria));
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.tradeCodeBox = new System.Windows.Forms.TextBox();
          this.label7 = new System.Windows.Forms.Label();
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this.multiBalanceTransaction = new System.Windows.Forms.RadioButton();
          this.balanceTransactionRadio = new System.Windows.Forms.RadioButton();
          this.label6 = new System.Windows.Forms.Label();
          this.branchCodeTextBox = new System.Windows.Forms.TextBox();
          this.accountIdTextBox = new System.Windows.Forms.TextBox();
          this.sectionGLTextBox = new System.Windows.Forms.TextBox();
          this.bankGLTextBox = new System.Windows.Forms.TextBox();
          this.label5 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
          this.toDatePicker = new System.Windows.Forms.DateTimePicker();
          this.lblBankGL = new System.Windows.Forms.Label();
          this.accountNameLabel = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.mainProgressBar = new System.Windows.Forms.ProgressBar();
          this.closeButton = new System.Windows.Forms.Button();
          this.printButton = new System.Windows.Forms.Button();
          this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
          this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
          this.groupBox1.SuspendLayout();
          this.groupBox2.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
          this.SuspendLayout();
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.tradeCodeBox);
          this.groupBox1.Controls.Add(this.label7);
          this.groupBox1.Controls.Add(this.groupBox2);
          this.groupBox1.Controls.Add(this.label6);
          this.groupBox1.Controls.Add(this.branchCodeTextBox);
          this.groupBox1.Controls.Add(this.accountIdTextBox);
          this.groupBox1.Controls.Add(this.sectionGLTextBox);
          this.groupBox1.Controls.Add(this.bankGLTextBox);
          this.groupBox1.Controls.Add(this.label5);
          this.groupBox1.Controls.Add(this.label4);
          this.groupBox1.Controls.Add(this.fromDatePicker);
          this.groupBox1.Controls.Add(this.toDatePicker);
          this.groupBox1.Controls.Add(this.lblBankGL);
          this.groupBox1.Controls.Add(this.accountNameLabel);
          this.groupBox1.Controls.Add(this.label3);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Location = new System.Drawing.Point(12, 12);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(419, 214);
          this.groupBox1.TabIndex = 0;
          this.groupBox1.TabStop = false;
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
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(13, 16);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(68, 13);
          this.label7.TabIndex = 15;
          this.label7.Text = "Mã giao dịch";
          // 
          // groupBox2
          // 
          this.groupBox2.Controls.Add(this.multiBalanceTransaction);
          this.groupBox2.Controls.Add(this.balanceTransactionRadio);
          this.groupBox2.Location = new System.Drawing.Point(117, 138);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(190, 63);
          this.groupBox2.TabIndex = 14;
          this.groupBox2.TabStop = false;
          // 
          // multiBalanceTransaction
          // 
          this.multiBalanceTransaction.AutoSize = true;
          this.multiBalanceTransaction.Enabled = false;
          this.multiBalanceTransaction.Location = new System.Drawing.Point(14, 37);
          this.multiBalanceTransaction.Name = "multiBalanceTransaction";
          this.multiBalanceTransaction.Size = new System.Drawing.Size(157, 17);
          this.multiBalanceTransaction.TabIndex = 7;
          this.multiBalanceTransaction.Text = "Liệt kê theo nhóm tài khoản";
          this.multiBalanceTransaction.UseVisualStyleBackColor = true;
          // 
          // balanceTransactionRadio
          // 
          this.balanceTransactionRadio.AutoSize = true;
          this.balanceTransactionRadio.Checked = true;
          this.balanceTransactionRadio.Location = new System.Drawing.Point(14, 12);
          this.balanceTransactionRadio.Name = "balanceTransactionRadio";
          this.balanceTransactionRadio.Size = new System.Drawing.Size(155, 17);
          this.balanceTransactionRadio.TabIndex = 5;
          this.balanceTransactionRadio.TabStop = true;
          this.balanceTransactionRadio.Text = "Liệt kê chính xác tài khoản";
          this.balanceTransactionRadio.UseVisualStyleBackColor = true;
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
          // accountIdTextBox
          // 
          this.accountIdTextBox.BackColor = System.Drawing.SystemColors.Window;
          this.accountIdTextBox.Location = new System.Drawing.Point(326, 40);
          this.accountIdTextBox.MaxLength = 10;
          this.accountIdTextBox.Name = "accountIdTextBox";
          this.accountIdTextBox.Size = new System.Drawing.Size(76, 20);
          this.accountIdTextBox.TabIndex = 2;
          this.accountIdTextBox.Validated += new System.EventHandler(this.accountIdTextBox_Validated);
          // 
          // sectionGLTextBox
          // 
          this.sectionGLTextBox.BackColor = System.Drawing.SystemColors.Window;
          this.sectionGLTextBox.Enabled = false;
          this.sectionGLTextBox.Location = new System.Drawing.Point(261, 40);
          this.sectionGLTextBox.MaxLength = 4;
          this.sectionGLTextBox.Name = "sectionGLTextBox";
          this.sectionGLTextBox.Size = new System.Drawing.Size(47, 20);
          this.sectionGLTextBox.TabIndex = 1;
          // 
          // bankGLTextBox
          // 
          this.bankGLTextBox.BackColor = System.Drawing.SystemColors.Window;
          this.bankGLTextBox.Enabled = false;
          this.bankGLTextBox.Location = new System.Drawing.Point(189, 40);
          this.bankGLTextBox.MaxLength = 6;
          this.bankGLTextBox.Name = "bankGLTextBox";
          this.bankGLTextBox.Size = new System.Drawing.Size(54, 20);
          this.bankGLTextBox.TabIndex = 0;
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(257, 16);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(59, 13);
          this.label5.TabIndex = 2;
          this.label5.Text = "Mã quản lý";
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
          // fromDatePicker
          // 
          this.fromDatePicker.CustomFormat = "dd/MM/yyyy";
          this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
          this.fromDatePicker.Location = new System.Drawing.Point(117, 112);
          this.fromDatePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
          this.fromDatePicker.Name = "fromDatePicker";
          this.fromDatePicker.Size = new System.Drawing.Size(93, 20);
          this.fromDatePicker.TabIndex = 3;
          this.fromDatePicker.Value = new System.DateTime(2007, 5, 27, 11, 13, 20, 483);
          // 
          // toDatePicker
          // 
          this.toDatePicker.CustomFormat = "dd/MM/yyyy";
          this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
          this.toDatePicker.Location = new System.Drawing.Point(307, 112);
          this.toDatePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
          this.toDatePicker.Name = "toDatePicker";
          this.toDatePicker.Size = new System.Drawing.Size(93, 20);
          this.toDatePicker.TabIndex = 4;
          this.toDatePicker.Value = new System.DateTime(2007, 5, 27, 11, 13, 20, 483);
          // 
          // lblBankGL
          // 
          this.lblBankGL.AutoSize = true;
          this.lblBankGL.Location = new System.Drawing.Point(184, 16);
          this.lblBankGL.Name = "lblBankGL";
          this.lblBankGL.Size = new System.Drawing.Size(66, 13);
          this.lblBankGL.TabIndex = 1;
          this.lblBankGL.Text = "TK tổng hợp";
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
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(325, 16);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(55, 13);
          this.label3.TabIndex = 3;
          this.label3.Text = "TK chi tiết";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(249, 115);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(56, 13);
          this.label2.TabIndex = 12;
          this.label2.Text = "Đến ngày:";
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(66, 115);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(49, 13);
          this.label1.TabIndex = 10;
          this.label1.Text = "Từ ngày:";
          // 
          // mainProgressBar
          // 
          this.mainProgressBar.Location = new System.Drawing.Point(0, 271);
          this.mainProgressBar.Name = "mainProgressBar";
          this.mainProgressBar.Size = new System.Drawing.Size(445, 13);
          this.mainProgressBar.TabIndex = 3;
          // 
          // closeButton
          // 
          this.closeButton.Image = global::AgencyApp.Properties.Resources.cancel;
          this.closeButton.Location = new System.Drawing.Point(332, 232);
          this.closeButton.Name = "closeButton";
          this.closeButton.Size = new System.Drawing.Size(99, 32);
          this.closeButton.TabIndex = 7;
          this.closeButton.Text = "Thoát";
          this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
          this.closeButton.UseVisualStyleBackColor = true;
          this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
          // 
          // printButton
          // 
          this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
          this.printButton.Location = new System.Drawing.Point(202, 232);
          this.printButton.Name = "printButton";
          this.printButton.Size = new System.Drawing.Size(99, 32);
          this.printButton.TabIndex = 6;
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
          // TransactionReportCriteria
          // 
          this.ClientSize = new System.Drawing.Size(445, 296);
          this.Controls.Add(this.mainProgressBar);
          this.Controls.Add(this.closeButton);
          this.Controls.Add(this.printButton);
          this.Controls.Add(this.groupBox1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "TransactionReportCriteria";
          this.Text = "Liệt kê giao dịch tiền";
          this.Load += new System.EventHandler(this.TransactionReportCriteria_Load);
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.groupBox2.ResumeLayout(false);
          this.groupBox2.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private TextBox accountIdTextBox;
      private Label accountNameLabel;
      private RadioButton balanceTransactionRadio;
      private TextBox bankGLTextBox;
      private TextBox branchCodeTextBox;
      private Button closeButton;
      private DateTimePicker fromDatePicker;
      private GroupBox groupBox1;
      private GroupBox groupBox2;
      private Label label1;
      private Label label2;
      private Label label3;
      private Label label4;
      private Label label5;
      private Label label6;
      private Label lblBankGL;
      private RadioButton multiBalanceTransaction;
      private Button printButton;
      private TextBox sectionGLTextBox;
      private DateTimePicker toDatePicker;
      private ProgressBar mainProgressBar;
      private TextBox tradeCodeBox;
      private Label label7;
      private ErrorProvider errorProvider;
      private BackgroundWorker backgroundWorker;
   }
}