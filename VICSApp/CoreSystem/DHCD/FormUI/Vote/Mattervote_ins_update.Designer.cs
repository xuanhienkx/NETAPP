using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class Mattervote_ins_update : Form
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
            GroupBox1 = new GroupBox();
            _NumericUpDown1 = new NumericUpDown();
            _NumericUpDown1.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
            MaskedTextBox3 = new MaskedTextBox();
            MaskedTextBox1 = new MaskedTextBox();
            Label7 = new Label();
            Label2 = new Label();
            Label1 = new Label();
            StockTextBox1 = new Lapas.Controls.StockTextBox();
            CheckBox1 = new CheckBox();
            MaskedTextBox4 = new MaskedTextBox();
            _HolderIdentifyMaskedTextBox2 = new MaskedTextBox();
            _HolderIdentifyMaskedTextBox2.KeyDown += new KeyEventHandler(MaskedTextBox2_KeyDown);
            _HolderCodeMaskedTextBox = new MaskedTextBox();
            _HolderCodeMaskedTextBox.KeyDown += new KeyEventHandler(MaskedTextBox5_KeyDown);
            _HolderCodeMaskedTextBox.Leave += new EventHandler(MaskedTextBox5_Leave);
            _HolderCodeMaskedTextBox.MaskInputRejected += new MaskInputRejectedEventHandler(MaskedTextBox5_MaskInputRejected);
            Label6 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            GroupBox3 = new GroupBox();
            RadioButton3 = new RadioButton();
            RadioButton2 = new RadioButton();
            RadioButton1 = new RadioButton();
            _Button3 = new Button();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Button2 = new Button();
            _Button2.Click += new EventHandler(Button2_Click);
            _Button4 = new Button();
            _Button4.Click += new EventHandler(Button4_Click);
            delegateNameTextbox = new MaskedTextBox();
            Label8 = new Label();
            delegateIdentityTextBox = new MaskedTextBox();
            delegateCodeMaskedTextBox = new MaskedTextBox();
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).BeginInit();
            GroupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(_NumericUpDown1);
            GroupBox1.Controls.Add(MaskedTextBox3);
            GroupBox1.Controls.Add(MaskedTextBox1);
            GroupBox1.Controls.Add(Label7);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Location = new Point(1, 1);
            GroupBox1.Margin = new Padding(4, 4, 4, 4);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(4, 4, 4, 4);
            GroupBox1.Size = new Size(932, 188);
            GroupBox1.TabIndex = 55;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Vấn đề biểu quyết";
            // 
            // NumericUpDown1
            // 
            _NumericUpDown1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _NumericUpDown1.Location = new Point(217, 78);
            _NumericUpDown1.Margin = new Padding(4, 4, 4, 4);
            _NumericUpDown1.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            _NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _NumericUpDown1.Name = "_NumericUpDown1";
            _NumericUpDown1.Size = new Size(81, 29);
            _NumericUpDown1.TabIndex = 2;
            _NumericUpDown1.TabStop = false;
            _NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(217, 133);
            MaskedTextBox3.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.ReadOnly = true;
            MaskedTextBox3.Size = new Size(635, 26);
            MaskedTextBox3.TabIndex = 23;
            MaskedTextBox3.TabStop = false;
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(217, 37);
            MaskedTextBox1.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(265, 26);
            MaskedTextBox1.TabIndex = 24;
            MaskedTextBox1.TabStop = false;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(15, 133);
            Label7.Margin = new Padding(4, 0, 4, 0);
            Label7.Name = "Label7";
            Label7.Size = new Size(91, 20);
            Label7.TabIndex = 27;
            Label7.Text = "Tên vấn đề";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(15, 87);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(86, 20);
            Label2.TabIndex = 26;
            Label2.Text = "Mã vấn đề";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(15, 37);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(105, 20);
            Label1.TabIndex = 25;
            Label1.Text = "Mã cuộc họp";
            // 
            // StockTextBox1
            // 
            StockTextBox1.Alarm = false;
            StockTextBox1.AllowNegativeNumeric = true;
            StockTextBox1.CustomCulture = false;
            StockTextBox1.CustomCultureInfo = new System.Globalization.CultureInfo("en-US");
            StockTextBox1.Location = new Point(237, 384);
            StockTextBox1.Margin = new Padding(4, 4, 4, 4);
            StockTextBox1.MaxLength = 25;
            StockTextBox1.Name = "StockTextBox1";
            StockTextBox1.Precision = 0;
            StockTextBox1.ReadOnly = true;
            StockTextBox1.Size = new Size(265, 22);
            StockTextBox1.TabIndex = 3;
            StockTextBox1.TabStop = false;
            StockTextBox1.Text = "0";
            StockTextBox1.TextAlign = HorizontalAlignment.Right;
            StockTextBox1.ValueAlarm = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Location = new Point(605, 220);
            CheckBox1.Margin = new Padding(4, 4, 4, 4);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(155, 21);
            CheckBox1.TabIndex = 37;
            CheckBox1.TabStop = false;
            CheckBox1.Text = "Chế độ nhập nhanh";
            CheckBox1.UseVisualStyleBackColor = true;
            CheckBox1.Visible = false;
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(237, 297);
            MaskedTextBox4.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.ReadOnly = true;
            MaskedTextBox4.Size = new Size(635, 26);
            MaskedTextBox4.TabIndex = 2;
            MaskedTextBox4.TabStop = false;
            // 
            // HolderIdentifyMaskedTextBox2
            // 
            _HolderIdentifyMaskedTextBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _HolderIdentifyMaskedTextBox2.Location = new Point(237, 260);
            _HolderIdentifyMaskedTextBox2.Margin = new Padding(4, 4, 4, 4);
            _HolderIdentifyMaskedTextBox2.Name = "_HolderIdentifyMaskedTextBox2";
            _HolderIdentifyMaskedTextBox2.Size = new Size(265, 26);
            _HolderIdentifyMaskedTextBox2.TabIndex = 1;
            // 
            // HolderCodeMaskedTextBox
            // 
            _HolderCodeMaskedTextBox.BackColor = SystemColors.InactiveBorder;
            _HolderCodeMaskedTextBox.Enabled = false;
            _HolderCodeMaskedTextBox.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _HolderCodeMaskedTextBox.Location = new Point(237, 220);
            _HolderCodeMaskedTextBox.Margin = new Padding(4, 4, 4, 4);
            _HolderCodeMaskedTextBox.Name = "_HolderCodeMaskedTextBox";
            _HolderCodeMaskedTextBox.Size = new Size(265, 26);
            _HolderCodeMaskedTextBox.TabIndex = 0;
            _HolderCodeMaskedTextBox.TabStop = false;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(35, 384);
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
            Label3.Location = new Point(33, 302);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(101, 20);
            Label3.TabIndex = 36;
            Label3.Text = "Tên cổ đông";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(35, 267);
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
            Label5.Location = new Point(35, 228);
            Label5.Margin = new Padding(4, 0, 4, 0);
            Label5.Name = "Label5";
            Label5.Size = new Size(96, 20);
            Label5.TabIndex = 34;
            Label5.Text = "Mã cổ đông";
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(RadioButton3);
            GroupBox3.Controls.Add(RadioButton2);
            GroupBox3.Controls.Add(RadioButton1);
            GroupBox3.Location = new Point(17, 452);
            GroupBox3.Margin = new Padding(4, 4, 4, 4);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Padding = new Padding(4, 4, 4, 4);
            GroupBox3.Size = new Size(916, 92);
            GroupBox3.TabIndex = 57;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "Biểu quyết";
            // 
            // RadioButton3
            // 
            RadioButton3.AutoSize = true;
            RadioButton3.Location = new Point(663, 41);
            RadioButton3.Margin = new Padding(4, 4, 4, 4);
            RadioButton3.Name = "RadioButton3";
            RadioButton3.Size = new Size(111, 21);
            RadioButton3.TabIndex = 2;
            RadioButton3.Text = "Không ý kiến";
            RadioButton3.UseVisualStyleBackColor = true;
            // 
            // RadioButton2
            // 
            RadioButton2.AutoSize = true;
            RadioButton2.Location = new Point(348, 41);
            RadioButton2.Margin = new Padding(4, 4, 4, 4);
            RadioButton2.Name = "RadioButton2";
            RadioButton2.Size = new Size(117, 21);
            RadioButton2.TabIndex = 1;
            RadioButton2.Text = "Không đồng ý";
            RadioButton2.UseVisualStyleBackColor = true;
            // 
            // RadioButton1
            // 
            RadioButton1.AutoSize = true;
            RadioButton1.Checked = true;
            RadioButton1.Location = new Point(39, 41);
            RadioButton1.Margin = new Padding(4, 4, 4, 4);
            RadioButton1.Name = "RadioButton1";
            RadioButton1.Size = new Size(74, 21);
            RadioButton1.TabIndex = 0;
            RadioButton1.TabStop = true;
            RadioButton1.Text = "Đồng ý";
            RadioButton1.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            _Button3.Font = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button3.ForeColor = Color.Blue;
            _Button3.Location = new Point(467, 559);
            _Button3.Margin = new Padding(4, 4, 4, 4);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(188, 43);
            _Button3.TabIndex = 7;
            _Button3.Text = "Nhập phần còn lại";
            _Button3.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.Location = new Point(36, 559);
            _Button1.Margin = new Padding(4, 4, 4, 4);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(153, 43);
            _Button1.TabIndex = 4;
            _Button1.Text = "Thêm";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            _Button2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button2.Location = new Point(256, 559);
            _Button2.Margin = new Padding(4, 4, 4, 4);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(161, 43);
            _Button2.TabIndex = 5;
            _Button2.Text = "Tiếp tục";
            _Button2.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            _Button4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button4.Location = new Point(780, 559);
            _Button4.Margin = new Padding(4, 4, 4, 4);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(153, 43);
            _Button4.TabIndex = 6;
            _Button4.TabStop = false;
            _Button4.Text = "Đóng";
            _Button4.UseVisualStyleBackColor = true;
            // 
            // delegateNameTextbox
            // 
            delegateNameTextbox.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            delegateNameTextbox.Location = new Point(237, 338);
            delegateNameTextbox.Margin = new Padding(4, 4, 4, 4);
            delegateNameTextbox.Name = "delegateNameTextbox";
            delegateNameTextbox.ReadOnly = true;
            delegateNameTextbox.Size = new Size(635, 26);
            delegateNameTextbox.TabIndex = 58;
            delegateNameTextbox.TabStop = false;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label8.Location = new Point(33, 343);
            Label8.Margin = new Padding(4, 0, 4, 0);
            Label8.Name = "Label8";
            Label8.Size = new Size(115, 20);
            Label8.TabIndex = 59;
            Label8.Text = "Người đại diện";
            // 
            // delegateIdentityTextBox
            // 
            delegateIdentityTextBox.BackColor = SystemColors.InactiveBorder;
            delegateIdentityTextBox.Enabled = false;
            delegateIdentityTextBox.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            delegateIdentityTextBox.Location = new Point(733, 373);
            delegateIdentityTextBox.Margin = new Padding(4, 4, 4, 4);
            delegateIdentityTextBox.Name = "delegateIdentityTextBox";
            delegateIdentityTextBox.Size = new Size(139, 26);
            delegateIdentityTextBox.TabIndex = 60;
            delegateIdentityTextBox.TabStop = false;
            delegateIdentityTextBox.Visible = false;
            // 
            // delegateCodeMaskedTextBox
            // 
            delegateCodeMaskedTextBox.BackColor = SystemColors.InactiveBorder;
            delegateCodeMaskedTextBox.Enabled = false;
            delegateCodeMaskedTextBox.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            delegateCodeMaskedTextBox.Location = new Point(588, 373);
            delegateCodeMaskedTextBox.Margin = new Padding(4, 4, 4, 4);
            delegateCodeMaskedTextBox.Name = "delegateCodeMaskedTextBox";
            delegateCodeMaskedTextBox.Size = new Size(124, 26);
            delegateCodeMaskedTextBox.TabIndex = 61;
            delegateCodeMaskedTextBox.TabStop = false;
            delegateCodeMaskedTextBox.Visible = false;
            // 
            // Mattervote_ins_update
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 645);
            Controls.Add(delegateCodeMaskedTextBox);
            Controls.Add(delegateIdentityTextBox);
            Controls.Add(delegateNameTextbox);
            Controls.Add(Label8);
            Controls.Add(StockTextBox1);
            Controls.Add(_Button2);
            Controls.Add(CheckBox1);
            Controls.Add(_Button4);
            Controls.Add(MaskedTextBox4);
            Controls.Add(_Button3);
            Controls.Add(_HolderIdentifyMaskedTextBox2);
            Controls.Add(_Button1);
            Controls.Add(_HolderCodeMaskedTextBox);
            Controls.Add(Label6);
            Controls.Add(GroupBox3);
            Controls.Add(Label3);
            Controls.Add(Label4);
            Controls.Add(GroupBox1);
            Controls.Add(Label5);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Mattervote_ins_update";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm phiếu biểu quyết";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).EndInit();
            GroupBox3.ResumeLayout(false);
            GroupBox3.PerformLayout();
            Load += new EventHandler(Mattervote_ins_update_Load);
            KeyUp += new KeyEventHandler(Mattervote_ins_update_KeyUp);
            ResumeLayout(false);
            PerformLayout();
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
        internal MaskedTextBox MaskedTextBox4;
        private MaskedTextBox _HolderIdentifyMaskedTextBox2;

        internal MaskedTextBox HolderIdentifyMaskedTextBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HolderIdentifyMaskedTextBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HolderIdentifyMaskedTextBox2 != null)
                {
                    _HolderIdentifyMaskedTextBox2.KeyDown -= MaskedTextBox2_KeyDown;
                }

                _HolderIdentifyMaskedTextBox2 = value;
                if (_HolderIdentifyMaskedTextBox2 != null)
                {
                    _HolderIdentifyMaskedTextBox2.KeyDown += MaskedTextBox2_KeyDown;
                }
            }
        }

        private MaskedTextBox _HolderCodeMaskedTextBox;

        internal MaskedTextBox HolderCodeMaskedTextBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HolderCodeMaskedTextBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HolderCodeMaskedTextBox != null)
                {
                    _HolderCodeMaskedTextBox.KeyDown -= MaskedTextBox5_KeyDown;
                    _HolderCodeMaskedTextBox.Leave -= MaskedTextBox5_Leave;
                    _HolderCodeMaskedTextBox.MaskInputRejected -= MaskedTextBox5_MaskInputRejected;
                }

                _HolderCodeMaskedTextBox = value;
                if (_HolderCodeMaskedTextBox != null)
                {
                    _HolderCodeMaskedTextBox.KeyDown += MaskedTextBox5_KeyDown;
                    _HolderCodeMaskedTextBox.Leave += MaskedTextBox5_Leave;
                    _HolderCodeMaskedTextBox.MaskInputRejected += MaskedTextBox5_MaskInputRejected;
                }
            }
        }

        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal GroupBox GroupBox3;
        internal RadioButton RadioButton3;
        internal RadioButton RadioButton2;
        internal RadioButton RadioButton1;
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

        internal CheckBox CheckBox1;
        internal Lapas.Controls.StockTextBox StockTextBox1;
        internal Label Label6;
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

        internal MaskedTextBox delegateNameTextbox;
        internal Label Label8;
        internal MaskedTextBox delegateIdentityTextBox;
        internal MaskedTextBox delegateCodeMaskedTextBox;
    }
}