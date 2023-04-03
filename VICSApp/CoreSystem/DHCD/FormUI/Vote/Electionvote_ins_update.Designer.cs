using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class Electionvote_ins_update : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            var DataGridViewCellStyle2 = new DataGridViewCellStyle();
            GroupBox1 = new GroupBox();
            _NumericUpDown1 = new NumericUpDown();
            _NumericUpDown1.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
            MaskedTextBox6 = new MaskedTextBox();
            MaskedTextBox3 = new MaskedTextBox();
            MaskedTextBox1 = new MaskedTextBox();
            Label8 = new Label();
            Label7 = new Label();
            Label2 = new Label();
            Label1 = new Label();
            GroupBox2 = new GroupBox();
            StockTextBox2 = new Lapas.Controls.StockTextBox();
            StockTextBox1 = new Lapas.Controls.StockTextBox();
            MaskedTextBox4 = new MaskedTextBox();
            _MaskedTextBox2 = new MaskedTextBox();
            _MaskedTextBox2.Leave += new EventHandler(MaskedTextBox2_Leave);
            _MaskedTextBox5 = new MaskedTextBox();
            _MaskedTextBox5.Leave += new EventHandler(MaskedTextBox5_Leave);
            _MaskedTextBox5.MaskInputRejected += new MaskInputRejectedEventHandler(MaskedTextBox5_MaskInputRejected);
            Label9 = new Label();
            Label6 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            GroupBox3 = new GroupBox();
            DataGridView1 = new DataGridView();
            Candidatecode = new DataGridViewTextBoxColumn();
            CandidateName = new DataGridViewTextBoxColumn();
            Choosen = new DataGridViewCheckBoxColumn();
            Votes = new DataGridViewTextBoxColumn();
            _Button2 = new Button();
            _Button2.Click += new EventHandler(Button2_Click);
            _Button3 = new Button();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Button4 = new Button();
            _Button4.Click += new EventHandler(Button4_Click);
            _Button5 = new Button();
            _Button5.Click += new EventHandler(Button5_Click);
            GroupBox4 = new GroupBox();
            _RadioButton2 = new RadioButton();
            _RadioButton2.CheckedChanged += new EventHandler(RadioButton2_CheckedChanged);
            RadioButton1 = new RadioButton();
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).BeginInit();
            GroupBox2.SuspendLayout();
            GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            GroupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(_NumericUpDown1);
            GroupBox1.Controls.Add(MaskedTextBox6);
            GroupBox1.Controls.Add(MaskedTextBox3);
            GroupBox1.Controls.Add(MaskedTextBox1);
            GroupBox1.Controls.Add(Label8);
            GroupBox1.Controls.Add(Label7);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Location = new Point(1, 2);
            GroupBox1.Margin = new Padding(4, 4, 4, 4);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(4, 4, 4, 4);
            GroupBox1.Size = new Size(932, 198);
            GroupBox1.TabIndex = 56;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Vấn đề bầu cử";
            // 
            // NumericUpDown1
            // 
            _NumericUpDown1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _NumericUpDown1.Location = new Point(217, 58);
            _NumericUpDown1.Margin = new Padding(4, 4, 4, 4);
            _NumericUpDown1.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            _NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _NumericUpDown1.Name = "_NumericUpDown1";
            _NumericUpDown1.Size = new Size(81, 29);
            _NumericUpDown1.TabIndex = 0;
            _NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MaskedTextBox6
            // 
            MaskedTextBox6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox6.Location = new Point(217, 154);
            MaskedTextBox6.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox6.Name = "MaskedTextBox6";
            MaskedTextBox6.ReadOnly = true;
            MaskedTextBox6.Size = new Size(265, 26);
            MaskedTextBox6.TabIndex = 23;
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(217, 110);
            MaskedTextBox3.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.ReadOnly = true;
            MaskedTextBox3.Size = new Size(635, 26);
            MaskedTextBox3.TabIndex = 23;
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(217, 22);
            MaskedTextBox1.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(635, 26);
            MaskedTextBox1.TabIndex = 24;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label8.Location = new Point(13, 161);
            Label8.Margin = new Padding(4, 0, 4, 0);
            Label8.Name = "Label8";
            Label8.Size = new Size(169, 20);
            Label8.TabIndex = 27;
            Label8.Text = "Số ứng viên được bầu";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(15, 110);
            Label7.Margin = new Padding(4, 0, 4, 0);
            Label7.Name = "Label7";
            Label7.Size = new Size(92, 20);
            Label7.TabIndex = 27;
            Label7.Text = "Tên bầu cử";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(15, 68);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(87, 20);
            Label2.TabIndex = 26;
            Label2.Text = "Mã bầu cử";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(15, 22);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(105, 20);
            Label1.TabIndex = 25;
            Label1.Text = "Mã cuộc họp";
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(StockTextBox2);
            GroupBox2.Controls.Add(StockTextBox1);
            GroupBox2.Controls.Add(MaskedTextBox4);
            GroupBox2.Controls.Add(_MaskedTextBox2);
            GroupBox2.Controls.Add(_MaskedTextBox5);
            GroupBox2.Controls.Add(Label9);
            GroupBox2.Controls.Add(Label6);
            GroupBox2.Controls.Add(Label3);
            GroupBox2.Controls.Add(Label4);
            GroupBox2.Controls.Add(Label5);
            GroupBox2.Location = new Point(1, 202);
            GroupBox2.Margin = new Padding(4, 4, 4, 4);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Padding = new Padding(4, 4, 4, 4);
            GroupBox2.Size = new Size(687, 238);
            GroupBox2.TabIndex = 57;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Đại biểu";
            // 
            // StockTextBox2
            // 
            StockTextBox2.Alarm = false;
            StockTextBox2.AllowNegativeNumeric = true;
            StockTextBox2.CustomCulture = false;
            StockTextBox2.CustomCultureInfo = new System.Globalization.CultureInfo("en-US");
            StockTextBox2.Location = new Point(217, 198);
            StockTextBox2.Margin = new Padding(4, 4, 4, 4);
            StockTextBox2.MaxLength = 25;
            StockTextBox2.Name = "StockTextBox2";
            StockTextBox2.Precision = 0;
            StockTextBox2.ReadOnly = true;
            StockTextBox2.Size = new Size(265, 22);
            StockTextBox2.TabIndex = 38;
            StockTextBox2.Text = "0";
            StockTextBox2.TextAlign = HorizontalAlignment.Right;
            StockTextBox2.ValueAlarm = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // StockTextBox1
            // 
            StockTextBox1.Alarm = false;
            StockTextBox1.AllowNegativeNumeric = true;
            StockTextBox1.CustomCulture = false;
            StockTextBox1.CustomCultureInfo = new System.Globalization.CultureInfo("en-US");
            StockTextBox1.Location = new Point(217, 154);
            StockTextBox1.Margin = new Padding(4, 4, 4, 4);
            StockTextBox1.MaxLength = 25;
            StockTextBox1.Name = "StockTextBox1";
            StockTextBox1.Precision = 0;
            StockTextBox1.ReadOnly = true;
            StockTextBox1.Size = new Size(265, 22);
            StockTextBox1.TabIndex = 38;
            StockTextBox1.Text = "0";
            StockTextBox1.TextAlign = HorizontalAlignment.Right;
            StockTextBox1.ValueAlarm = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(217, 110);
            MaskedTextBox4.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.ReadOnly = true;
            MaskedTextBox4.Size = new Size(265, 26);
            MaskedTextBox4.TabIndex = 32;
            // 
            // MaskedTextBox2
            // 
            _MaskedTextBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _MaskedTextBox2.Location = new Point(217, 64);
            _MaskedTextBox2.Margin = new Padding(4, 4, 4, 4);
            _MaskedTextBox2.Name = "_MaskedTextBox2";
            _MaskedTextBox2.Size = new Size(265, 26);
            _MaskedTextBox2.TabIndex = 2;
            // 
            // MaskedTextBox5
            // 
            _MaskedTextBox5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _MaskedTextBox5.Location = new Point(217, 16);
            _MaskedTextBox5.Margin = new Padding(4, 4, 4, 4);
            _MaskedTextBox5.Name = "_MaskedTextBox5";
            _MaskedTextBox5.Size = new Size(265, 26);
            _MaskedTextBox5.TabIndex = 1;
            _MaskedTextBox5.TabStop = false;
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label9.Location = new Point(15, 198);
            Label9.Margin = new Padding(4, 0, 4, 0);
            Label9.Name = "Label9";
            Label9.Size = new Size(106, 20);
            Label9.TabIndex = 36;
            Label9.Text = "Số phiếu bầu";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(15, 159);
            Label6.Margin = new Padding(4, 0, 4, 0);
            Label6.Name = "Label6";
            Label6.Size = new Size(159, 20);
            Label6.TabIndex = 36;
            Label6.Text = "Số quyền biểu quyết";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(13, 110);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(100, 20);
            Label3.TabIndex = 36;
            Label3.Text = "Tên đại biểu";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(15, 64);
            Label4.Margin = new Padding(4, 0, 4, 0);
            Label4.Name = "Label4";
            Label4.Size = new Size(75, 20);
            Label4.TabIndex = 35;
            Label4.Text = "CMT/HC";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.Location = new Point(15, 23);
            Label5.Margin = new Padding(4, 0, 4, 0);
            Label5.Name = "Label5";
            Label5.Size = new Size(95, 20);
            Label5.TabIndex = 34;
            Label5.Text = "Mã đại biểu";
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(DataGridView1);
            GroupBox3.Location = new Point(1, 447);
            GroupBox3.Margin = new Padding(4, 4, 4, 4);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Padding = new Padding(4, 4, 4, 4);
            GroupBox3.Size = new Size(932, 287);
            GroupBox3.TabIndex = 58;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "Bầu chọn";
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Candidatecode, CandidateName, Choosen, Votes });
            DataGridView1.Dock = DockStyle.Fill;
            DataGridView1.Location = new Point(4, 19);
            DataGridView1.Margin = new Padding(4, 4, 4, 4);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.Size = new Size(924, 264);
            DataGridView1.TabIndex = 13;
            // 
            // Candidatecode
            // 
            Candidatecode.DataPropertyName = "Candidatecode";
            Candidatecode.FillWeight = 59.08628f;
            Candidatecode.HeaderText = "Mã ứng viên";
            Candidatecode.Name = "Candidatecode";
            Candidatecode.ReadOnly = true;
            // 
            // CandidateName
            // 
            CandidateName.DataPropertyName = "CandidateName";
            CandidateName.FillWeight = 59.08628f;
            CandidateName.HeaderText = "Tên ứng viên";
            CandidateName.Name = "CandidateName";
            CandidateName.ReadOnly = true;
            // 
            // Choosen
            // 
            Choosen.DataPropertyName = "Choosen";
            Choosen.FillWeight = 59.08628f;
            Choosen.HeaderText = "Chọn";
            Choosen.Name = "Choosen";
            Choosen.Resizable = DataGridViewTriState.True;
            Choosen.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Votes
            // 
            Votes.DataPropertyName = "Votes";
            DataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Votes.DefaultCellStyle = DataGridViewCellStyle2;
            Votes.HeaderText = "Số phiếu bầu";
            Votes.Name = "Votes";
            // 
            // Button2
            // 
            _Button2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button2.Location = new Point(571, 738);
            _Button2.Margin = new Padding(4, 4, 4, 4);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(168, 43);
            _Button2.TabIndex = 60;
            _Button2.Text = "Tiếp tục";
            _Button2.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            _Button3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button3.Location = new Point(776, 738);
            _Button3.Margin = new Padding(4, 4, 4, 4);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(153, 43);
            _Button3.TabIndex = 61;
            _Button3.Text = "Đóng";
            _Button3.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.Location = new Point(5, 738);
            _Button1.Margin = new Padding(4, 4, 4, 4);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(152, 43);
            _Button1.TabIndex = 59;
            _Button1.Text = "Thêm";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            _Button4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button4.Location = new Point(179, 738);
            _Button4.Margin = new Padding(4, 4, 4, 4);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(160, 43);
            _Button4.TabIndex = 60;
            _Button4.Text = "Chia đều phiếu";
            _Button4.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            _Button5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button5.Location = new Point(363, 738);
            _Button5.Margin = new Padding(4, 4, 4, 4);
            _Button5.Name = "_Button5";
            _Button5.Size = new Size(168, 43);
            _Button5.TabIndex = 60;
            _Button5.Text = "Để trống phiếu";
            _Button5.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            GroupBox4.Controls.Add(_RadioButton2);
            GroupBox4.Controls.Add(RadioButton1);
            GroupBox4.Location = new Point(696, 202);
            GroupBox4.Margin = new Padding(4, 4, 4, 4);
            GroupBox4.Name = "GroupBox4";
            GroupBox4.Padding = new Padding(4, 4, 4, 4);
            GroupBox4.Size = new Size(233, 238);
            GroupBox4.TabIndex = 39;
            GroupBox4.TabStop = false;
            GroupBox4.Text = "TRẠNG THÁI PHIẾU";
            // 
            // RadioButton2
            // 
            _RadioButton2.AutoSize = true;
            _RadioButton2.Location = new Point(39, 132);
            _RadioButton2.Margin = new Padding(4, 4, 4, 4);
            _RadioButton2.Name = "_RadioButton2";
            _RadioButton2.Size = new Size(123, 21);
            _RadioButton2.TabIndex = 0;
            _RadioButton2.Text = "KHÔNG hợp lệ";
            _RadioButton2.UseVisualStyleBackColor = true;
            // 
            // RadioButton1
            // 
            RadioButton1.AutoSize = true;
            RadioButton1.Checked = true;
            RadioButton1.Location = new Point(39, 43);
            RadioButton1.Margin = new Padding(4, 4, 4, 4);
            RadioButton1.Name = "RadioButton1";
            RadioButton1.Size = new Size(70, 21);
            RadioButton1.TabIndex = 0;
            RadioButton1.TabStop = true;
            RadioButton1.Text = "Hợp lệ";
            RadioButton1.UseVisualStyleBackColor = true;
            // 
            // Electionvote_ins_update
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 796);
            Controls.Add(GroupBox4);
            Controls.Add(_Button4);
            Controls.Add(_Button5);
            Controls.Add(_Button2);
            Controls.Add(_Button3);
            Controls.Add(_Button1);
            Controls.Add(GroupBox3);
            Controls.Add(GroupBox2);
            Controls.Add(GroupBox1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Electionvote_ins_update";
            Text = "Thêm phiếu bầu cử";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).EndInit();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            GroupBox4.ResumeLayout(false);
            GroupBox4.PerformLayout();
            Load += new EventHandler(Electionvote_ins_update_Load);
            ResumeLayout(false);
        }

        internal GroupBox GroupBox1;
        private NumericUpDown _NumericUpDown1;

        internal NumericUpDown NumericUpDown1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericUpDown1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericUpDown1 != null)
                {
                    _NumericUpDown1.ValueChanged -= NumericUpDown1_ValueChanged;
                }

                _NumericUpDown1 = value;
                if (_NumericUpDown1 != null)
                {
                    _NumericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
                }
            }
        }

        internal MaskedTextBox MaskedTextBox3;
        internal MaskedTextBox MaskedTextBox1;
        internal Label Label7;
        internal Label Label2;
        internal Label Label1;
        internal GroupBox GroupBox2;
        internal Lapas.Controls.StockTextBox StockTextBox1;
        internal MaskedTextBox MaskedTextBox4;
        private MaskedTextBox _MaskedTextBox2;

        internal MaskedTextBox MaskedTextBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaskedTextBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MaskedTextBox2 != null)
                {
                    _MaskedTextBox2.Leave -= MaskedTextBox2_Leave;
                }

                _MaskedTextBox2 = value;
                if (_MaskedTextBox2 != null)
                {
                    _MaskedTextBox2.Leave += MaskedTextBox2_Leave;
                }
            }
        }

        private MaskedTextBox _MaskedTextBox5;

        internal MaskedTextBox MaskedTextBox5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaskedTextBox5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MaskedTextBox5 != null)
                {
                    _MaskedTextBox5.Leave -= MaskedTextBox5_Leave;
                    _MaskedTextBox5.MaskInputRejected -= MaskedTextBox5_MaskInputRejected;
                }

                _MaskedTextBox5 = value;
                if (_MaskedTextBox5 != null)
                {
                    _MaskedTextBox5.Leave += MaskedTextBox5_Leave;
                    _MaskedTextBox5.MaskInputRejected += MaskedTextBox5_MaskInputRejected;
                }
            }
        }

        internal Label Label6;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal GroupBox GroupBox3;
        internal DataGridView DataGridView1;
        private Button _Button2;

        internal Button Button2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button2 != null)
                {
                    _Button2.Click -= Button2_Click;
                }

                _Button2 = value;
                if (_Button2 != null)
                {
                    _Button2.Click += Button2_Click;
                }
            }
        }

        private Button _Button3;

        internal Button Button3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button3 != null)
                {
                    _Button3.Click -= Button3_Click;
                }

                _Button3 = value;
                if (_Button3 != null)
                {
                    _Button3.Click += Button3_Click;
                }
            }
        }

        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        private Button _Button4;

        internal Button Button4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button4 != null)
                {
                    _Button4.Click -= Button4_Click;
                }

                _Button4 = value;
                if (_Button4 != null)
                {
                    _Button4.Click += Button4_Click;
                }
            }
        }

        internal MaskedTextBox MaskedTextBox6;
        internal Label Label8;
        internal Lapas.Controls.StockTextBox StockTextBox2;
        internal Label Label9;
        internal DataGridViewTextBoxColumn Candidatecode;
        internal DataGridViewTextBoxColumn CandidateName;
        internal DataGridViewCheckBoxColumn Choosen;
        internal DataGridViewTextBoxColumn Votes;
        private Button _Button5;

        internal Button Button5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button5 != null)
                {
                    _Button5.Click -= Button5_Click;
                }

                _Button5 = value;
                if (_Button5 != null)
                {
                    _Button5.Click += Button5_Click;
                }
            }
        }

        internal GroupBox GroupBox4;
        private RadioButton _RadioButton2;

        internal RadioButton RadioButton2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RadioButton2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RadioButton2 != null)
                {
                    _RadioButton2.CheckedChanged -= RadioButton2_CheckedChanged;
                }

                _RadioButton2 = value;
                if (_RadioButton2 != null)
                {
                    _RadioButton2.CheckedChanged += RadioButton2_CheckedChanged;
                }
            }
        }

        internal RadioButton RadioButton1;
    }
}