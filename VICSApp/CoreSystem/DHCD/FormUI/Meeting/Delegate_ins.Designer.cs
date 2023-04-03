using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class Delegate_ins : Form
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
            StockTextBox2 = new Lapas.Controls.StockTextBox();
            StockTextBox1 = new Lapas.Controls.StockTextBox();
            _Button3 = new Button();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            MaskedTextBox5 = new MaskedTextBox();
            MaskedTextBox4 = new MaskedTextBox();
            _MaskedTextBox3 = new MaskedTextBox();
            _MaskedTextBox3.KeyDown += new KeyEventHandler(MaskedTextBox3_KeyDown);
            MaskedTextBox2 = new MaskedTextBox();
            MaskedTextBox1 = new MaskedTextBox();
            Label6 = new Label();
            Label5 = new Label();
            Label4 = new Label();
            Label3 = new Label();
            Label7 = new Label();
            Label2 = new Label();
            Label1 = new Label();
            _Button2 = new Button();
            _Button2.Click += new EventHandler(Button2_Click);
            _Button4 = new Button();
            _Button4.Click += new EventHandler(Button4_Click);
            Label8 = new Label();
            MaskedTextBox6 = new MaskedTextBox();
            _Button5 = new Button();
            _Button5.Click += new EventHandler(Button5_Click);
            _Button6 = new Button();
            _Button6.Click += new EventHandler(Button6_Click);
            _Button7 = new Button();
            _Button7.Click += new EventHandler(Button7_Click);
            SuspendLayout();
            // 
            // StockTextBox2
            // 
            StockTextBox2.Alarm = false;
            StockTextBox2.AllowNegativeNumeric = true;
            StockTextBox2.CustomCulture = false;
            StockTextBox2.CustomCultureInfo = new System.Globalization.CultureInfo("en-US");
            StockTextBox2.Location = new Point(175, 280);
            StockTextBox2.MaxLength = 25;
            StockTextBox2.Name = "StockTextBox2";
            StockTextBox2.Precision = 0;
            StockTextBox2.ReadOnly = true;
            StockTextBox2.Size = new Size(200, 20);
            StockTextBox2.TabIndex = 20;
            StockTextBox2.TabStop = false;
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
            StockTextBox1.Location = new Point(175, 242);
            StockTextBox1.MaxLength = 25;
            StockTextBox1.Name = "StockTextBox1";
            StockTextBox1.Precision = 0;
            StockTextBox1.ReadOnly = true;
            StockTextBox1.Size = new Size(200, 20);
            StockTextBox1.TabIndex = 19;
            StockTextBox1.TabStop = false;
            StockTextBox1.Text = "0";
            StockTextBox1.TextAlign = HorizontalAlignment.Right;
            StockTextBox1.ValueAlarm = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // Button3
            // 
            _Button3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button3.Location = new Point(430, 339);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(149, 61);
            _Button3.TabIndex = 5;
            _Button3.Text = "Tiếp tục";
            _Button3.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.Location = new Point(63, 339);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(142, 61);
            _Button1.TabIndex = 3;
            _Button1.Text = "Thêm đại biểu và tự ủy quyền";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // MaskedTextBox5
            // 
            MaskedTextBox5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox5.Location = new Point(175, 176);
            MaskedTextBox5.Name = "MaskedTextBox5";
            MaskedTextBox5.Size = new Size(380, 22);
            MaskedTextBox5.TabIndex = 2;
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(175, 138);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.Size = new Size(380, 22);
            MaskedTextBox4.TabIndex = 1;
            // 
            // MaskedTextBox3
            // 
            _MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _MaskedTextBox3.Location = new Point(175, 97);
            _MaskedTextBox3.Name = "_MaskedTextBox3";
            _MaskedTextBox3.Size = new Size(200, 22);
            _MaskedTextBox3.TabIndex = 0;
            // 
            // MaskedTextBox2
            // 
            MaskedTextBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox2.Location = new Point(175, 54);
            MaskedTextBox2.Name = "MaskedTextBox2";
            MaskedTextBox2.ReadOnly = true;
            MaskedTextBox2.Size = new Size(200, 22);
            MaskedTextBox2.TabIndex = 15;
            MaskedTextBox2.TabStop = false;
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(175, 19);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(200, 22);
            MaskedTextBox1.TabIndex = 25;
            MaskedTextBox1.TabStop = false;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(22, 284);
            Label6.Name = "Label6";
            Label6.Size = new Size(130, 16);
            Label6.TabIndex = 24;
            Label6.Text = "Số quyền biểu quyết";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.Location = new Point(23, 242);
            Label5.Name = "Label5";
            Label5.Size = new Size(76, 16);
            Label5.TabIndex = 23;
            Label5.Text = "Số cổ phần";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(23, 182);
            Label4.Name = "Label4";
            Label4.Size = new Size(48, 16);
            Label4.TabIndex = 26;
            Label4.Text = "Địa chỉ";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(22, 138);
            Label3.Name = "Label3";
            Label3.Size = new Size(83, 16);
            Label3.TabIndex = 30;
            Label3.Text = "Tên đại biểu";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(23, 97);
            Label7.Name = "Label7";
            Label7.Size = new Size(60, 16);
            Label7.TabIndex = 29;
            Label7.Text = "CMT/HC";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(23, 60);
            Label2.Name = "Label2";
            Label2.Size = new Size(78, 16);
            Label2.TabIndex = 28;
            Label2.Text = "Mã đại biểu";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(23, 19);
            Label1.Name = "Label1";
            Label1.Size = new Size(85, 16);
            Label1.TabIndex = 27;
            Label1.Text = "Mã cuộc họp";
            // 
            // Button2
            // 
            _Button2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button2.Location = new Point(238, 339);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(142, 61);
            _Button2.TabIndex = 4;
            _Button2.Text = "Thêm đại biểu không có cổ phần";
            _Button2.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            _Button4.Location = new Point(402, 95);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(153, 24);
            _Button4.TabIndex = 31;
            _Button4.Text = "Tìm trong DS cổ đông";
            _Button4.UseVisualStyleBackColor = true;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label8.Location = new Point(22, 213);
            Label8.Name = "Label8";
            Label8.Size = new Size(79, 16);
            Label8.TabIndex = 26;
            Label8.Text = "Mã cổ đông";
            // 
            // MaskedTextBox6
            // 
            MaskedTextBox6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox6.Location = new Point(175, 207);
            MaskedTextBox6.Name = "MaskedTextBox6";
            MaskedTextBox6.ReadOnly = true;
            MaskedTextBox6.Size = new Size(200, 22);
            MaskedTextBox6.TabIndex = 16;
            MaskedTextBox6.TabStop = false;
            // 
            // Button5
            // 
            _Button5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button5.Location = new Point(63, 418);
            _Button5.Name = "_Button5";
            _Button5.Size = new Size(142, 44);
            _Button5.TabIndex = 6;
            _Button5.Text = "&In thẻ biểu quyết";
            _Button5.UseVisualStyleBackColor = true;
            // 
            // Button6
            // 
            _Button6.Enabled = false;
            _Button6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button6.Location = new Point(238, 418);
            _Button6.Name = "_Button6";
            _Button6.Size = new Size(142, 44);
            _Button6.TabIndex = 7;
            _Button6.Text = "In &phiếu bầu";
            _Button6.UseVisualStyleBackColor = true;
            // 
            // Button7
            // 
            _Button7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button7.Location = new Point(430, 418);
            _Button7.Name = "_Button7";
            _Button7.Size = new Size(149, 44);
            _Button7.TabIndex = 8;
            _Button7.Text = "Thoát(Esc)";
            _Button7.UseVisualStyleBackColor = true;
            // 
            // Delegate_ins
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 479);
            Controls.Add(_Button4);
            Controls.Add(StockTextBox2);
            Controls.Add(StockTextBox1);
            Controls.Add(_Button3);
            Controls.Add(_Button2);
            Controls.Add(_Button7);
            Controls.Add(_Button6);
            Controls.Add(_Button5);
            Controls.Add(_Button1);
            Controls.Add(MaskedTextBox5);
            Controls.Add(MaskedTextBox4);
            Controls.Add(MaskedTextBox6);
            Controls.Add(_MaskedTextBox3);
            Controls.Add(MaskedTextBox2);
            Controls.Add(MaskedTextBox1);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label8);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label7);
            Controls.Add(Label2);
            Controls.Add(Label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "Delegate_ins";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm đại biểu";
            Load += new EventHandler(Delegate_ins_Load);
            KeyUp += new KeyEventHandler(Delegate_ins_KeyUp);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Lapas.Controls.StockTextBox StockTextBox2;
        internal Lapas.Controls.StockTextBox StockTextBox1;
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

        internal MaskedTextBox MaskedTextBox5;
        internal MaskedTextBox MaskedTextBox4;
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
                    _MaskedTextBox3.KeyDown -= MaskedTextBox3_KeyDown;
                }

                _MaskedTextBox3 = value;
                if (_MaskedTextBox3 != null)
                {
                    _MaskedTextBox3.KeyDown += MaskedTextBox3_KeyDown;
                }
            }
        }

        internal MaskedTextBox MaskedTextBox2;
        internal MaskedTextBox MaskedTextBox1;
        internal Label Label6;
        internal Label Label5;
        internal Label Label4;
        internal Label Label3;
        internal Label Label7;
        internal Label Label2;
        internal Label Label1;
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

        internal Label Label8;
        internal MaskedTextBox MaskedTextBox6;
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

        private Button _Button6;

        internal Button Button6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button6 != null)
                {
                    _Button6.Click -= Button6_Click;
                }

                _Button6 = value;
                if (_Button6 != null)
                {
                    _Button6.Click += Button6_Click;
                }
            }
        }

        private Button _Button7;

        internal Button Button7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button7 != null)
                {
                    _Button7.Click -= Button7_Click;
                }

                _Button7 = value;
                if (_Button7 != null)
                {
                    _Button7.Click += Button7_Click;
                }
            }
        }
    }
}