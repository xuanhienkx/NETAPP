using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class MatterVoteResult : Form
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
            Label7 = new Label();
            Label2 = new Label();
            Label1 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            Label8 = new Label();
            MaskedTextBox1 = new MaskedTextBox();
            MaskedTextBox2 = new MaskedTextBox();
            MaskedTextBox4 = new MaskedTextBox();
            MaskedTextBox5 = new MaskedTextBox();
            MaskedTextBox6 = new MaskedTextBox();
            MaskedTextBox7 = new MaskedTextBox();
            MaskedTextBox8 = new MaskedTextBox();
            MaskedTextBox9 = new MaskedTextBox();
            MaskedTextBox10 = new MaskedTextBox();
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(_NumericUpDown1);
            GroupBox1.Controls.Add(MaskedTextBox3);
            GroupBox1.Controls.Add(Label7);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            GroupBox1.Location = new Point(63, 23);
            GroupBox1.Margin = new Padding(4, 4, 4, 4);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(4, 4, 4, 4);
            GroupBox1.Size = new Size(1056, 117);
            GroupBox1.TabIndex = 58;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Vấn đề biểu quyết";
            // 
            // NumericUpDown1
            // 
            _NumericUpDown1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _NumericUpDown1.Location = new Point(217, 16);
            _NumericUpDown1.Margin = new Padding(4, 4, 4, 4);
            _NumericUpDown1.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            _NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _NumericUpDown1.Name = "_NumericUpDown1";
            _NumericUpDown1.Size = new Size(81, 34);
            _NumericUpDown1.TabIndex = 0;
            _NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.BackColor = Color.LightYellow;
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(217, 64);
            MaskedTextBox3.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.ReadOnly = true;
            MaskedTextBox3.Size = new Size(812, 34);
            MaskedTextBox3.TabIndex = 23;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(15, 64);
            Label7.Margin = new Padding(4, 0, 4, 0);
            Label7.Name = "Label7";
            Label7.Size = new Size(111, 25);
            Label7.TabIndex = 27;
            Label7.Text = "Tên vấn đề";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(15, 22);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(104, 25);
            Label2.TabIndex = 26;
            Label2.Text = "Mã vấn đề";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(129, 279);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(135, 29);
            Label1.TabIndex = 27;
            Label1.Text = "Số đại biểu";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(397, 217);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(88, 29);
            Label3.TabIndex = 27;
            Label3.Text = "Đồng ý";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(669, 217);
            Label4.Margin = new Padding(4, 0, 4, 0);
            Label4.Name = "Label4";
            Label4.Size = new Size(161, 29);
            Label4.TabIndex = 27;
            Label4.Text = "Không đồng ý";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.Location = new Point(957, 217);
            Label5.Margin = new Padding(4, 0, 4, 0);
            Label5.Name = "Label5";
            Label5.Size = new Size(151, 29);
            Label5.TabIndex = 27;
            Label5.Text = "Không ý kiến";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(129, 425);
            Label6.Margin = new Padding(4, 0, 4, 0);
            Label6.Name = "Label6";
            Label6.Size = new Size(155, 29);
            Label6.TabIndex = 27;
            Label6.Text = "Số quyền BQ";
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label8.Location = new Point(129, 556);
            Label8.Margin = new Padding(4, 0, 4, 0);
            Label8.Name = "Label8";
            Label8.Size = new Size(66, 29);
            Label8.TabIndex = 27;
            Label8.Text = "Tỷ lệ";
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.BackColor = Color.LightYellow;
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(355, 276);
            MaskedTextBox1.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(189, 34);
            MaskedTextBox1.TabIndex = 59;
            // 
            // MaskedTextBox2
            // 
            MaskedTextBox2.BackColor = Color.LightYellow;
            MaskedTextBox2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox2.Location = new Point(653, 278);
            MaskedTextBox2.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox2.Name = "MaskedTextBox2";
            MaskedTextBox2.ReadOnly = true;
            MaskedTextBox2.Size = new Size(189, 34);
            MaskedTextBox2.TabIndex = 59;
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.BackColor = Color.LightYellow;
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(943, 278);
            MaskedTextBox4.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.ReadOnly = true;
            MaskedTextBox4.Size = new Size(189, 34);
            MaskedTextBox4.TabIndex = 59;
            // 
            // MaskedTextBox5
            // 
            MaskedTextBox5.BackColor = Color.LightYellow;
            MaskedTextBox5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox5.Location = new Point(355, 418);
            MaskedTextBox5.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox5.Name = "MaskedTextBox5";
            MaskedTextBox5.ReadOnly = true;
            MaskedTextBox5.Size = new Size(189, 34);
            MaskedTextBox5.TabIndex = 59;
            // 
            // MaskedTextBox6
            // 
            MaskedTextBox6.BackColor = Color.LightYellow;
            MaskedTextBox6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox6.Location = new Point(653, 421);
            MaskedTextBox6.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox6.Name = "MaskedTextBox6";
            MaskedTextBox6.ReadOnly = true;
            MaskedTextBox6.Size = new Size(189, 34);
            MaskedTextBox6.TabIndex = 59;
            // 
            // MaskedTextBox7
            // 
            MaskedTextBox7.BackColor = Color.LightYellow;
            MaskedTextBox7.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox7.Location = new Point(943, 421);
            MaskedTextBox7.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox7.Name = "MaskedTextBox7";
            MaskedTextBox7.ReadOnly = true;
            MaskedTextBox7.Size = new Size(189, 34);
            MaskedTextBox7.TabIndex = 59;
            // 
            // MaskedTextBox8
            // 
            MaskedTextBox8.BackColor = Color.LightYellow;
            MaskedTextBox8.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox8.Location = new Point(355, 550);
            MaskedTextBox8.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox8.Name = "MaskedTextBox8";
            MaskedTextBox8.ReadOnly = true;
            MaskedTextBox8.Size = new Size(189, 34);
            MaskedTextBox8.TabIndex = 59;
            // 
            // MaskedTextBox9
            // 
            MaskedTextBox9.BackColor = Color.LightYellow;
            MaskedTextBox9.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox9.Location = new Point(653, 553);
            MaskedTextBox9.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox9.Name = "MaskedTextBox9";
            MaskedTextBox9.ReadOnly = true;
            MaskedTextBox9.Size = new Size(189, 34);
            MaskedTextBox9.TabIndex = 59;
            // 
            // MaskedTextBox10
            // 
            MaskedTextBox10.BackColor = Color.LightYellow;
            MaskedTextBox10.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox10.Location = new Point(943, 553);
            MaskedTextBox10.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox10.Name = "MaskedTextBox10";
            MaskedTextBox10.ReadOnly = true;
            MaskedTextBox10.Size = new Size(189, 34);
            MaskedTextBox10.TabIndex = 59;
            // 
            // MatterVoteResult
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 745);
            Controls.Add(MaskedTextBox10);
            Controls.Add(MaskedTextBox9);
            Controls.Add(MaskedTextBox7);
            Controls.Add(MaskedTextBox6);
            Controls.Add(MaskedTextBox8);
            Controls.Add(MaskedTextBox4);
            Controls.Add(MaskedTextBox5);
            Controls.Add(MaskedTextBox2);
            Controls.Add(MaskedTextBox1);
            Controls.Add(GroupBox1);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label8);
            Controls.Add(Label6);
            Controls.Add(Label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "MatterVoteResult";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kết quả biểu quyết";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).EndInit();
            Load += new EventHandler(MatterVoteResult_Load);
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
        internal Label Label7;
        internal Label Label2;
        internal Label Label1;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal Label Label6;
        internal Label Label8;
        internal MaskedTextBox MaskedTextBox1;
        internal MaskedTextBox MaskedTextBox2;
        internal MaskedTextBox MaskedTextBox4;
        internal MaskedTextBox MaskedTextBox5;
        internal MaskedTextBox MaskedTextBox6;
        internal MaskedTextBox MaskedTextBox7;
        internal MaskedTextBox MaskedTextBox8;
        internal MaskedTextBox MaskedTextBox9;
        internal MaskedTextBox MaskedTextBox10;
    }
}