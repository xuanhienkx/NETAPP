using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class Holder_ins_update : Form
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
            _Button3 = new Button();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            MaskedTextBox5 = new MaskedTextBox();
            MaskedTextBox4 = new MaskedTextBox();
            MaskedTextBox3 = new MaskedTextBox();
            MaskedTextBox2 = new MaskedTextBox();
            MaskedTextBox1 = new MaskedTextBox();
            Label6 = new Label();
            Label5 = new Label();
            Label4 = new Label();
            Label3 = new Label();
            Label2 = new Label();
            Label1 = new Label();
            Label7 = new Label();
            StockTextBox1 = new Lapas.Controls.StockTextBox();
            StockTextBox2 = new Lapas.Controls.StockTextBox();
            SuspendLayout();
            // 
            // Button3
            // 
            _Button3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button3.Location = new Point(355, 342);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(135, 35);
            _Button3.TabIndex = 7;
            _Button3.Text = "Đóng";
            _Button3.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.Location = new Point(74, 342);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(121, 35);
            _Button1.TabIndex = 6;
            _Button1.Text = "Thêm";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // MaskedTextBox5
            // 
            MaskedTextBox5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox5.Location = new Point(186, 179);
            MaskedTextBox5.Name = "MaskedTextBox5";
            MaskedTextBox5.Size = new Size(343, 22);
            MaskedTextBox5.TabIndex = 3;
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(186, 141);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.Size = new Size(343, 22);
            MaskedTextBox4.TabIndex = 2;
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(186, 100);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.Size = new Size(200, 22);
            MaskedTextBox3.TabIndex = 1;
            // 
            // MaskedTextBox2
            // 
            MaskedTextBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox2.Location = new Point(186, 57);
            MaskedTextBox2.Name = "MaskedTextBox2";
            MaskedTextBox2.Size = new Size(200, 22);
            MaskedTextBox2.TabIndex = 0;
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(186, 22);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(200, 22);
            MaskedTextBox1.TabIndex = 10;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(33, 271);
            Label6.Name = "Label6";
            Label6.Size = new Size(130, 16);
            Label6.TabIndex = 9;
            Label6.Text = "Số quyền biểu quyết";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.Location = new Point(34, 229);
            Label5.Name = "Label5";
            Label5.Size = new Size(76, 16);
            Label5.TabIndex = 8;
            Label5.Text = "Số cổ phần";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(34, 185);
            Label4.Name = "Label4";
            Label4.Size = new Size(48, 16);
            Label4.TabIndex = 11;
            Label4.Text = "Địa chỉ";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(33, 141);
            Label3.Name = "Label3";
            Label3.Size = new Size(84, 16);
            Label3.TabIndex = 14;
            Label3.Text = "Tên cổ đông";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(34, 63);
            Label2.Name = "Label2";
            Label2.Size = new Size(79, 16);
            Label2.TabIndex = 13;
            Label2.Text = "Mã cổ đông";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(34, 22);
            Label1.Name = "Label1";
            Label1.Size = new Size(85, 16);
            Label1.TabIndex = 12;
            Label1.Text = "Mã cuộc họp";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(34, 100);
            Label7.Name = "Label7";
            Label7.Size = new Size(101, 16);
            Label7.TabIndex = 13;
            Label7.Text = "CMT/HC/GPKD";
            // 
            // StockTextBox1
            // 
            StockTextBox1.Alarm = false;
            StockTextBox1.AllowNegativeNumeric = true;
            StockTextBox1.CustomCulture = false;
            StockTextBox1.CustomCultureInfo = new System.Globalization.CultureInfo("en-US");
            StockTextBox1.Location = new Point(186, 229);
            StockTextBox1.MaxLength = 25;
            StockTextBox1.Name = "StockTextBox1";
            StockTextBox1.Precision = 0;
            StockTextBox1.Size = new Size(200, 20);
            StockTextBox1.TabIndex = 4;
            StockTextBox1.Text = "0";
            StockTextBox1.TextAlign = HorizontalAlignment.Right;
            StockTextBox1.ValueAlarm = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // StockTextBox2
            // 
            StockTextBox2.Alarm = false;
            StockTextBox2.AllowNegativeNumeric = true;
            StockTextBox2.CustomCulture = false;
            StockTextBox2.CustomCultureInfo = new System.Globalization.CultureInfo("en-US");
            StockTextBox2.Location = new Point(186, 267);
            StockTextBox2.MaxLength = 25;
            StockTextBox2.Name = "StockTextBox2";
            StockTextBox2.Precision = 0;
            StockTextBox2.Size = new Size(200, 20);
            StockTextBox2.TabIndex = 5;
            StockTextBox2.Text = "0";
            StockTextBox2.TextAlign = HorizontalAlignment.Right;
            StockTextBox2.ValueAlarm = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // Holder_ins_update
            // 
            AcceptButton = _Button1;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 398);
            Controls.Add(StockTextBox2);
            Controls.Add(StockTextBox1);
            Controls.Add(_Button3);
            Controls.Add(_Button1);
            Controls.Add(MaskedTextBox5);
            Controls.Add(MaskedTextBox4);
            Controls.Add(MaskedTextBox3);
            Controls.Add(MaskedTextBox2);
            Controls.Add(MaskedTextBox1);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label7);
            Controls.Add(Label2);
            Controls.Add(Label1);
            KeyPreview = true;
            Name = "Holder_ins_update";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm mã cổ đông";
            Load += new EventHandler(Holder_ins_update_Load);
            KeyUp += new KeyEventHandler(Holder_ins_update_KeyUp);
            ResumeLayout(false);
            PerformLayout();
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

        internal MaskedTextBox MaskedTextBox5;
        internal MaskedTextBox MaskedTextBox4;
        internal MaskedTextBox MaskedTextBox3;
        internal MaskedTextBox MaskedTextBox2;
        internal MaskedTextBox MaskedTextBox1;
        internal Label Label6;
        internal Label Label5;
        internal Label Label4;
        internal Label Label3;
        internal Label Label2;
        internal Label Label1;
        internal Label Label7;
        internal Lapas.Controls.StockTextBox StockTextBox1;
        internal Lapas.Controls.StockTextBox StockTextBox2;
    }
}