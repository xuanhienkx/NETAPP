using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class AuthorizationsInsert : Form
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
            _StockTextBox2 = new Lapas.Controls.StockTextBox();
            _StockTextBox2.KeyDown += new KeyEventHandler(StockTextBox2_KeyDown);
            Label4 = new Label();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Button2 = new Button();
            _Button2.Click += new EventHandler(Button2_Click);
            Label2 = new Label();
            Label7 = new Label();
            Label3 = new Label();
            MaskedTextBox2 = new MaskedTextBox();
            _MaskedTextBox3 = new MaskedTextBox();
            _MaskedTextBox3.Leave += new EventHandler(MaskedTextBox3_Leave);
            _MaskedTextBox3.KeyUp += new KeyEventHandler(MaskedTextBox3_KeyUp);
            _MaskedTextBox3.KeyDown += new KeyEventHandler(MaskedTextBox3_KeyDown);
            MaskedTextBox4 = new MaskedTextBox();
            Label8 = new Label();
            Label6 = new Label();
            Label5 = new Label();
            Label1 = new Label();
            MaskedTextBox8 = new MaskedTextBox();
            _MaskedTextBox7 = new MaskedTextBox();
            _MaskedTextBox7.KeyDown += new KeyEventHandler(MaskedTextBox7_KeyDown);
            MaskedTextBox6 = new MaskedTextBox();
            StockTextBox1 = new Lapas.Controls.StockTextBox();
            Label9 = new Label();
            Label10 = new Label();
            MaskedTextBox1 = new MaskedTextBox();
            Label11 = new Label();
            SuspendLayout();
            // 
            // StockTextBox2
            // 
            _StockTextBox2.Alarm = false;
            _StockTextBox2.AllowNegativeNumeric = true;
            _StockTextBox2.CustomCulture = false;
            _StockTextBox2.CustomCultureInfo = new System.Globalization.CultureInfo("en-US");
            _StockTextBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _StockTextBox2.Location = new Point(214, 349);
            _StockTextBox2.MaxLength = 25;
            _StockTextBox2.Name = "_StockTextBox2";
            _StockTextBox2.Precision = 0;
            _StockTextBox2.Size = new Size(200, 22);
            _StockTextBox2.TabIndex = 2;
            _StockTextBox2.Text = "0";
            _StockTextBox2.TextAlign = HorizontalAlignment.Right;
            _StockTextBox2.ValueAlarm = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(61, 355);
            Label4.Name = "Label4";
            Label4.Size = new Size(144, 16);
            Label4.TabIndex = 16;
            Label4.Text = "Số quyền BQ ủy quyền";
            // 
            // Button1
            // 
            _Button1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.Location = new Point(188, 398);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(145, 47);
            _Button1.TabIndex = 3;
            _Button1.Text = "Thêm";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            _Button2.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button2.Location = new Point(387, 398);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(145, 47);
            _Button2.TabIndex = 4;
            _Button2.Text = "Thoát";
            _Button2.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(63, 36);
            Label2.Name = "Label2";
            Label2.Size = new Size(78, 16);
            Label2.TabIndex = 9;
            Label2.Text = "Mã đại biểu";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(63, 73);
            Label7.Name = "Label7";
            Label7.Size = new Size(60, 16);
            Label7.TabIndex = 10;
            Label7.Text = "CMT/HC";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(62, 114);
            Label3.Name = "Label3";
            Label3.Size = new Size(83, 16);
            Label3.TabIndex = 11;
            Label3.Text = "Tên đại biểu";
            // 
            // MaskedTextBox2
            // 
            MaskedTextBox2.BackColor = SystemColors.InactiveBorder;
            MaskedTextBox2.Enabled = false;
            MaskedTextBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox2.Location = new Point(215, 30);
            MaskedTextBox2.Name = "MaskedTextBox2";
            MaskedTextBox2.Size = new Size(200, 22);
            MaskedTextBox2.TabIndex = 5;
            MaskedTextBox2.TabStop = false;
            // 
            // MaskedTextBox3
            // 
            _MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _MaskedTextBox3.Location = new Point(215, 73);
            _MaskedTextBox3.Name = "_MaskedTextBox3";
            _MaskedTextBox3.Size = new Size(200, 22);
            _MaskedTextBox3.TabIndex = 0;
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(215, 114);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.ReadOnly = true;
            MaskedTextBox4.Size = new Size(380, 22);
            MaskedTextBox4.TabIndex = 6;
            MaskedTextBox4.TabStop = false;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label8.Location = new Point(61, 192);
            Label8.Name = "Label8";
            Label8.Size = new Size(79, 16);
            Label8.TabIndex = 12;
            Label8.Text = "Mã cổ đông";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(61, 217);
            Label6.Name = "Label6";
            Label6.Size = new Size(60, 16);
            Label6.TabIndex = 13;
            Label6.Text = "CMT/HC";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.Location = new Point(60, 248);
            Label5.Name = "Label5";
            Label5.Size = new Size(84, 16);
            Label5.TabIndex = 14;
            Label5.Text = "Tên cổ đông";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(61, 318);
            Label1.Name = "Label1";
            Label1.Size = new Size(130, 16);
            Label1.TabIndex = 15;
            Label1.Text = "Số quyền biểu quyết";
            // 
            // MaskedTextBox8
            // 
            MaskedTextBox8.BackColor = SystemColors.InactiveBorder;
            MaskedTextBox8.Enabled = false;
            MaskedTextBox8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox8.Location = new Point(213, 186);
            MaskedTextBox8.Name = "MaskedTextBox8";
            MaskedTextBox8.Size = new Size(200, 22);
            MaskedTextBox8.TabIndex = 7;
            MaskedTextBox8.TabStop = false;
            // 
            // MaskedTextBox7
            // 
            _MaskedTextBox7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _MaskedTextBox7.Location = new Point(213, 217);
            _MaskedTextBox7.Name = "_MaskedTextBox7";
            _MaskedTextBox7.Size = new Size(200, 22);
            _MaskedTextBox7.TabIndex = 1;
            // 
            // MaskedTextBox6
            // 
            MaskedTextBox6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox6.Location = new Point(213, 248);
            MaskedTextBox6.Name = "MaskedTextBox6";
            MaskedTextBox6.ReadOnly = true;
            MaskedTextBox6.Size = new Size(380, 22);
            MaskedTextBox6.TabIndex = 8;
            MaskedTextBox6.TabStop = false;
            // 
            // StockTextBox1
            // 
            StockTextBox1.Alarm = false;
            StockTextBox1.AllowNegativeNumeric = true;
            StockTextBox1.CustomCulture = false;
            StockTextBox1.CustomCultureInfo = new System.Globalization.CultureInfo("en-US");
            StockTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            StockTextBox1.Location = new Point(213, 315);
            StockTextBox1.MaxLength = 25;
            StockTextBox1.Name = "StockTextBox1";
            StockTextBox1.Precision = 0;
            StockTextBox1.ReadOnly = true;
            StockTextBox1.Size = new Size(200, 22);
            StockTextBox1.TabIndex = 9;
            StockTextBox1.TabStop = false;
            StockTextBox1.Text = "0";
            StockTextBox1.TextAlign = HorizontalAlignment.Right;
            StockTextBox1.ValueAlarm = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Microsoft Sans Serif", 10.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            Label9.Location = new Point(42, 162);
            Label9.Name = "Label9";
            Label9.Size = new Size(193, 17);
            Label9.TabIndex = 17;
            Label9.Text = "Thông tin người ủy quyền";
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Font = new Font("Microsoft Sans Serif", 10.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            Label10.Location = new Point(42, 9);
            Label10.Name = "Label10";
            Label10.Size = new Size(140, 17);
            Label10.TabIndex = 18;
            Label10.Text = "Thông tin đại biểu";
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(213, 281);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(380, 22);
            MaskedTextBox1.TabIndex = 19;
            MaskedTextBox1.TabStop = false;
            // 
            // Label11
            // 
            Label11.AutoSize = true;
            Label11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label11.Location = new Point(60, 281);
            Label11.Name = "Label11";
            Label11.Size = new Size(48, 16);
            Label11.TabIndex = 20;
            Label11.Text = "Địa chỉ";
            // 
            // AuthorizationsInsert
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 475);
            Controls.Add(MaskedTextBox1);
            Controls.Add(Label11);
            Controls.Add(Label10);
            Controls.Add(Label9);
            Controls.Add(_StockTextBox2);
            Controls.Add(Label4);
            Controls.Add(StockTextBox1);
            Controls.Add(MaskedTextBox4);
            Controls.Add(MaskedTextBox6);
            Controls.Add(_Button2);
            Controls.Add(_MaskedTextBox7);
            Controls.Add(_MaskedTextBox3);
            Controls.Add(MaskedTextBox8);
            Controls.Add(Label1);
            Controls.Add(_Button1);
            Controls.Add(Label5);
            Controls.Add(MaskedTextBox2);
            Controls.Add(Label6);
            Controls.Add(Label3);
            Controls.Add(Label8);
            Controls.Add(Label7);
            Controls.Add(Label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "AuthorizationsInsert";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ủy quyền";
            Load += new EventHandler(AuthorizationsInsert_Load);
            KeyUp += new KeyEventHandler(AuthorizationsInsert_KeyUp);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label Label4;
        private Lapas.Controls.StockTextBox _StockTextBox2;

        internal Lapas.Controls.StockTextBox StockTextBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StockTextBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StockTextBox2 != null)
                {
                    _StockTextBox2.KeyDown -= StockTextBox2_KeyDown;
                }

                _StockTextBox2 = value;
                if (_StockTextBox2 != null)
                {
                    _StockTextBox2.KeyDown += StockTextBox2_KeyDown;
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

        internal Label Label2;
        internal Label Label7;
        internal Label Label3;
        internal MaskedTextBox MaskedTextBox2;
        private MaskedTextBox _MaskedTextBox3;

        internal MaskedTextBox MaskedTextBox3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaskedTextBox3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MaskedTextBox3 != null)
                {
                    _MaskedTextBox3.Leave -= MaskedTextBox3_Leave;
                    _MaskedTextBox3.KeyUp -= MaskedTextBox3_KeyUp;
                    _MaskedTextBox3.KeyDown -= MaskedTextBox3_KeyDown;
                }

                _MaskedTextBox3 = value;
                if (_MaskedTextBox3 != null)
                {
                    _MaskedTextBox3.Leave += MaskedTextBox3_Leave;
                    _MaskedTextBox3.KeyUp += MaskedTextBox3_KeyUp;
                    _MaskedTextBox3.KeyDown += MaskedTextBox3_KeyDown;
                }
            }
        }

        internal MaskedTextBox MaskedTextBox4;
        internal Label Label8;
        internal Label Label6;
        internal Label Label5;
        internal Label Label1;
        internal MaskedTextBox MaskedTextBox8;
        private MaskedTextBox _MaskedTextBox7;

        internal MaskedTextBox MaskedTextBox7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaskedTextBox7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MaskedTextBox7 != null)
                {
                    _MaskedTextBox7.KeyDown -= MaskedTextBox7_KeyDown;
                }

                _MaskedTextBox7 = value;
                if (_MaskedTextBox7 != null)
                {
                    _MaskedTextBox7.KeyDown += MaskedTextBox7_KeyDown;
                }
            }
        }

        internal MaskedTextBox MaskedTextBox6;
        internal Lapas.Controls.StockTextBox StockTextBox1;
        internal Label Label9;
        internal Label Label10;
        internal MaskedTextBox MaskedTextBox1;
        internal Label Label11;
    }
}