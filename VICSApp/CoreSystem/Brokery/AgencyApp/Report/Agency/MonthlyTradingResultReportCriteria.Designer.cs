using System.Windows.Forms;
using System.ComponentModel;

namespace Brokery.Report.Agency
{
    partial class MonthlyTradingResultReportCriteria
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyTradingResultReportCriteria));
         this.mainProgressBar = new System.Windows.Forms.ProgressBar();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.label4 = new System.Windows.Forms.Label();
         this.branchCodeTextBox = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.tradeCodeBox = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label6 = new System.Windows.Forms.Label();
         this.YearNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.monthComboBox = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.quarterComboBox1 = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.MonthlyradioButton = new System.Windows.Forms.RadioButton();
         this.quarterRadioButton = new System.Windows.Forms.RadioButton();
         this.boardTypeCombo = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.closeButton = new System.Windows.Forms.Button();
         this.printButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.YearNumericUpDown)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainProgressBar
         // 
         this.mainProgressBar.Location = new System.Drawing.Point(1, 198);
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
         this.label4.Location = new System.Drawing.Point(147, 22);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(40, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Mã CN";
         // 
         // branchCodeTextBox
         // 
         this.branchCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.branchCodeTextBox.Location = new System.Drawing.Point(149, 39);
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
         this.label7.Location = new System.Drawing.Point(29, 19);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(68, 13);
         this.label7.TabIndex = 15;
         this.label7.Text = "Mã giao dịch";
         // 
         // tradeCodeBox
         // 
         this.tradeCodeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
         this.tradeCodeBox.Location = new System.Drawing.Point(31, 39);
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
         this.groupBox1.Controls.Add(this.YearNumericUpDown);
         this.groupBox1.Controls.Add(this.monthComboBox);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.quarterComboBox1);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.groupBox2);
         this.groupBox1.Controls.Add(this.boardTypeCombo);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.tradeCodeBox);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.branchCodeTextBox);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(419, 141);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Thông tin lập báo cáo";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(308, 77);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(32, 13);
         this.label6.TabIndex = 29;
         this.label6.Text = "Năm:";
         // 
         // YearNumericUpDown
         // 
         this.YearNumericUpDown.Location = new System.Drawing.Point(340, 74);
         this.YearNumericUpDown.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
         this.YearNumericUpDown.Minimum = new decimal(new int[] {
            2007,
            0,
            0,
            0});
         this.YearNumericUpDown.Name = "YearNumericUpDown";
         this.YearNumericUpDown.Size = new System.Drawing.Size(62, 20);
         this.YearNumericUpDown.TabIndex = 5;
         this.YearNumericUpDown.Value = new decimal(new int[] {
            2008,
            0,
            0,
            0});
         // 
         // monthComboBox
         // 
         this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.monthComboBox.FormattingEnabled = true;
         this.monthComboBox.Location = new System.Drawing.Point(215, 73);
         this.monthComboBox.Name = "monthComboBox";
         this.monthComboBox.Size = new System.Drawing.Size(87, 21);
         this.monthComboBox.TabIndex = 4;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(174, 77);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(41, 13);
         this.label5.TabIndex = 26;
         this.label5.Text = "Tháng:";
         // 
         // quarterComboBox1
         // 
         this.quarterComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.quarterComboBox1.Enabled = false;
         this.quarterComboBox1.FormattingEnabled = true;
         this.quarterComboBox1.Location = new System.Drawing.Point(116, 73);
         this.quarterComboBox1.Name = "quarterComboBox1";
         this.quarterComboBox1.Size = new System.Drawing.Size(55, 21);
         this.quarterComboBox1.TabIndex = 3;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(79, 77);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(29, 13);
         this.label1.TabIndex = 24;
         this.label1.Text = "Quý:";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.MonthlyradioButton);
         this.groupBox2.Controls.Add(this.quarterRadioButton);
         this.groupBox2.Location = new System.Drawing.Point(206, 22);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(196, 38);
         this.groupBox2.TabIndex = 23;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Kiểu lựa chọn";
         // 
         // MonthlyradioButton
         // 
         this.MonthlyradioButton.AutoSize = true;
         this.MonthlyradioButton.Checked = true;
         this.MonthlyradioButton.Location = new System.Drawing.Point(110, 16);
         this.MonthlyradioButton.Name = "MonthlyradioButton";
         this.MonthlyradioButton.Size = new System.Drawing.Size(76, 17);
         this.MonthlyradioButton.TabIndex = 2;
         this.MonthlyradioButton.TabStop = true;
         this.MonthlyradioButton.Text = "Kiểu tháng";
         this.MonthlyradioButton.UseVisualStyleBackColor = true;
         // 
         // quarterRadioButton
         // 
         this.quarterRadioButton.AutoSize = true;
         this.quarterRadioButton.Location = new System.Drawing.Point(10, 16);
         this.quarterRadioButton.Name = "quarterRadioButton";
         this.quarterRadioButton.Size = new System.Drawing.Size(66, 17);
         this.quarterRadioButton.TabIndex = 1;
         this.quarterRadioButton.Text = "Kiểu quý";
         this.quarterRadioButton.UseVisualStyleBackColor = true;
         this.quarterRadioButton.CheckedChanged += new System.EventHandler(this.quarterRadioButton_CheckedChanged);
         // 
         // boardTypeCombo
         // 
         this.boardTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.boardTypeCombo.FormattingEnabled = true;
         this.boardTypeCombo.Location = new System.Drawing.Point(116, 104);
         this.boardTypeCombo.Name = "boardTypeCombo";
         this.boardTypeCombo.Size = new System.Drawing.Size(77, 21);
         this.boardTypeCombo.TabIndex = 6;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(33, 107);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(75, 13);
         this.label2.TabIndex = 18;
         this.label2.Text = "Sàn giao dịch:";
         // 
         // closeButton
         // 
         this.closeButton.Image = global::Brokery.Properties.Resources.cancel;
         this.closeButton.Location = new System.Drawing.Point(334, 160);
         this.closeButton.Name = "closeButton";
         this.closeButton.Size = new System.Drawing.Size(99, 32);
         this.closeButton.TabIndex = 8;
         this.closeButton.Text = "Thoát";
         this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.closeButton.UseVisualStyleBackColor = true;
         this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
         // 
         // printButton
         // 
         this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
         this.printButton.Location = new System.Drawing.Point(204, 160);
         this.printButton.Name = "printButton";
         this.printButton.Size = new System.Drawing.Size(99, 32);
         this.printButton.TabIndex = 7;
         this.printButton.Text = "Xem báo cáo";
         this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.printButton.UseVisualStyleBackColor = true;
         this.printButton.Click += new System.EventHandler(this.printButton_Click);
         // 
         // MonthlyTradingResultReportCriteria
         // 
         this.ClientSize = new System.Drawing.Size(446, 226);
         this.Controls.Add(this.mainProgressBar);
         this.Controls.Add(this.closeButton);
         this.Controls.Add(this.printButton);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MonthlyTradingResultReportCriteria";
         this.Text = "Báo cáo giao dịch tháng, quý";
         this.Load += new System.EventHandler(this.MonthlyTradingResultReportCriteria_Load);
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.YearNumericUpDown)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
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
      private Label label2;
      private ComboBox boardTypeCombo;
      private GroupBox groupBox2;
      private RadioButton quarterRadioButton;
      private Label label6;
      private NumericUpDown YearNumericUpDown;
      private ComboBox monthComboBox;
      private Label label5;
      private ComboBox quarterComboBox1;
      private Label label1;
      private RadioButton MonthlyradioButton;
   }
}