using System.Windows.Forms;
using System.ComponentModel;

namespace Brokery.Report.Agency
{
    partial class StockOrderListReportCriteria
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockOrderListReportCriteria));
         this.mainProgressBar = new System.Windows.Forms.ProgressBar();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.label4 = new System.Windows.Forms.Label();
         this.branchCodeTextBox = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.tradeCodeBox = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.orderSideCombo = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.boardTypeCombo = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.tradingDatePicker = new System.Windows.Forms.DateTimePicker();
         this.label1 = new System.Windows.Forms.Label();
         this.closeButton = new System.Windows.Forms.Button();
         this.printButton = new System.Windows.Forms.Button();
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
         this.label4.Location = new System.Drawing.Point(151, 29);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(40, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Mã CN";
         // 
         // branchCodeTextBox
         // 
         this.branchCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.branchCodeTextBox.Location = new System.Drawing.Point(153, 46);
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
         this.label7.Location = new System.Drawing.Point(33, 26);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(68, 13);
         this.label7.TabIndex = 15;
         this.label7.Text = "Mã giao dịch";
         // 
         // tradeCodeBox
         // 
         this.tradeCodeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
         this.tradeCodeBox.Location = new System.Drawing.Point(35, 46);
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
         this.groupBox1.Controls.Add(this.orderSideCombo);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.boardTypeCombo);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.tradingDatePicker);
         this.groupBox1.Controls.Add(this.tradeCodeBox);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.branchCodeTextBox);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(419, 114);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Thông tin lập báo cáo";
         // 
         // orderSideCombo
         // 
         this.orderSideCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.orderSideCombo.FormattingEnabled = true;
         this.orderSideCombo.Location = new System.Drawing.Point(307, 78);
         this.orderSideCombo.Name = "orderSideCombo";
         this.orderSideCombo.Size = new System.Drawing.Size(93, 21);
         this.orderSideCombo.TabIndex = 2;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(229, 83);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(53, 13);
         this.label3.TabIndex = 20;
         this.label3.Text = "Loại lệnh:";
         // 
         // boardTypeCombo
         // 
         this.boardTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.boardTypeCombo.FormattingEnabled = true;
         this.boardTypeCombo.Location = new System.Drawing.Point(114, 78);
         this.boardTypeCombo.Name = "boardTypeCombo";
         this.boardTypeCombo.Size = new System.Drawing.Size(77, 21);
         this.boardTypeCombo.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(33, 83);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(75, 13);
         this.label2.TabIndex = 18;
         this.label2.Text = "Sàn giao dịch:";
         // 
         // tradingDatePicker
         // 
         this.tradingDatePicker.CustomFormat = "dd/MM/yyyy";
         this.tradingDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.tradingDatePicker.Location = new System.Drawing.Point(307, 46);
         this.tradingDatePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
         this.tradingDatePicker.Name = "tradingDatePicker";
         this.tradingDatePicker.Size = new System.Drawing.Size(93, 20);
         this.tradingDatePicker.TabIndex = 0;
         this.tradingDatePicker.Value = new System.DateTime(2007, 5, 27, 11, 13, 20, 483);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(223, 50);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(81, 13);
         this.label1.TabIndex = 12;
         this.label1.Text = "Ngày giao dịch:";
         // 
         // closeButton
         // 
         this.closeButton.Image = global::Brokery.Properties.Resources.cancel;
         this.closeButton.Location = new System.Drawing.Point(334, 140);
         this.closeButton.Name = "closeButton";
         this.closeButton.Size = new System.Drawing.Size(99, 32);
         this.closeButton.TabIndex = 4;
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
         this.printButton.TabIndex = 3;
         this.printButton.Text = "Xem báo cáo";
         this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.printButton.UseVisualStyleBackColor = true;
         this.printButton.Click += new System.EventHandler(this.printButton_Click);
         // 
         // StockOrderListReportCriteria
         // 
         this.ClientSize = new System.Drawing.Size(445, 204);
         this.Controls.Add(this.mainProgressBar);
         this.Controls.Add(this.closeButton);
         this.Controls.Add(this.printButton);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "StockOrderListReportCriteria";
         this.Text = "Sổ lệnh nhập theo ngày";
         this.Load += new System.EventHandler(this.StockOrderListReportCriteria_Load);
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
      private TextBox branchCodeTextBox;
      private Label label4;
      private DateTimePicker tradingDatePicker;
      private Label label1;
      private Label label2;
      private ComboBox orderSideCombo;
      private Label label3;
      private ComboBox boardTypeCombo;
   }
}