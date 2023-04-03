using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class election_ins_update : Form
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
            TextBox1 = new TextBox();
            _NumericUpDown1 = new NumericUpDown();
            _NumericUpDown1.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
            MaskedTextBox3 = new MaskedTextBox();
            MaskedTextBox1 = new MaskedTextBox();
            Label3 = new Label();
            Label7 = new Label();
            Label2 = new Label();
            Label1 = new Label();
            Label4 = new Label();
            NumericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // Button3
            // 
            _Button3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button3.Location = new Point(497, 433);
            _Button3.Margin = new Padding(4, 4, 4, 4);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(180, 43);
            _Button3.TabIndex = 5;
            _Button3.Text = "Đóng";
            _Button3.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.Location = new Point(123, 433);
            _Button1.Margin = new Padding(4, 4, 4, 4);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(161, 43);
            _Button1.TabIndex = 4;
            _Button1.Text = "Thêm";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // TextBox1
            // 
            TextBox1.Location = new Point(232, 219);
            TextBox1.Margin = new Padding(4, 4, 4, 4);
            TextBox1.Multiline = true;
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(635, 170);
            TextBox1.TabIndex = 3;
            // 
            // NumericUpDown1
            // 
            _NumericUpDown1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _NumericUpDown1.Location = new Point(232, 74);
            _NumericUpDown1.Margin = new Padding(4, 4, 4, 4);
            _NumericUpDown1.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            _NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _NumericUpDown1.Name = "_NumericUpDown1";
            _NumericUpDown1.Size = new Size(81, 29);
            _NumericUpDown1.TabIndex = 0;
            _NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(232, 129);
            MaskedTextBox3.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.Size = new Size(635, 26);
            MaskedTextBox3.TabIndex = 1;
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(232, 33);
            MaskedTextBox1.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(265, 26);
            MaskedTextBox1.TabIndex = 28;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(28, 225);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(75, 20);
            Label3.TabIndex = 32;
            Label3.Text = "Diễn giải";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(29, 129);
            Label7.Margin = new Padding(4, 0, 4, 0);
            Label7.Name = "Label7";
            Label7.Size = new Size(92, 20);
            Label7.TabIndex = 31;
            Label7.Text = "Tên bầu cử";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(29, 84);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(87, 20);
            Label2.TabIndex = 30;
            Label2.Text = "Mã bầu cử";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(29, 33);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(105, 20);
            Label1.TabIndex = 29;
            Label1.Text = "Mã cuộc họp";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(29, 176);
            Label4.Margin = new Padding(4, 0, 4, 0);
            Label4.Name = "Label4";
            Label4.Size = new Size(165, 20);
            Label4.TabIndex = 31;
            Label4.Text = "Số đại biểu được bầu";
            // 
            // NumericUpDown2
            // 
            NumericUpDown2.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            NumericUpDown2.Location = new Point(232, 171);
            NumericUpDown2.Margin = new Padding(4, 4, 4, 4);
            NumericUpDown2.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            NumericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown2.Name = "NumericUpDown2";
            NumericUpDown2.Size = new Size(81, 29);
            NumericUpDown2.TabIndex = 2;
            NumericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // election_ins_update
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 539);
            Controls.Add(_Button3);
            Controls.Add(_Button1);
            Controls.Add(TextBox1);
            Controls.Add(NumericUpDown2);
            Controls.Add(_NumericUpDown1);
            Controls.Add(MaskedTextBox3);
            Controls.Add(MaskedTextBox1);
            Controls.Add(Label3);
            Controls.Add(Label4);
            Controls.Add(Label7);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "election_ins_update";
            Text = "Thêm vấn đề bầu cử";
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown2).EndInit();
            Load += new EventHandler(election_ins_update_Load);
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

        internal TextBox TextBox1;
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
        internal Label Label3;
        internal Label Label7;
        internal Label Label2;
        internal Label Label1;
        internal Label Label4;
        internal NumericUpDown NumericUpDown2;
    }
}