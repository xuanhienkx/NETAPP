using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class MatterVotes_ins_remain : Form
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
            MaskedTextBox1 = new MaskedTextBox();
            Label1 = new Label();
            Label2 = new Label();
            MaskedTextBox2 = new MaskedTextBox();
            Label3 = new Label();
            MaskedTextBox3 = new MaskedTextBox();
            Label4 = new Label();
            MaskedTextBox4 = new MaskedTextBox();
            Label5 = new Label();
            MaskedTextBox5 = new MaskedTextBox();
            GroupBox2 = new GroupBox();
            Label6 = new Label();
            MaskedTextBox6 = new MaskedTextBox();
            Label7 = new Label();
            MaskedTextBox7 = new MaskedTextBox();
            Label8 = new Label();
            MaskedTextBox8 = new MaskedTextBox();
            GroupBox3 = new GroupBox();
            _Button3 = new Button();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            RadioButton3 = new RadioButton();
            RadioButton2 = new RadioButton();
            RadioButton1 = new RadioButton();
            GroupBox1.SuspendLayout();
            GroupBox2.SuspendLayout();
            GroupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(MaskedTextBox5);
            GroupBox1.Controls.Add(MaskedTextBox4);
            GroupBox1.Controls.Add(Label5);
            GroupBox1.Controls.Add(MaskedTextBox3);
            GroupBox1.Controls.Add(Label4);
            GroupBox1.Controls.Add(MaskedTextBox2);
            GroupBox1.Controls.Add(Label3);
            GroupBox1.Controls.Add(MaskedTextBox1);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Location = new Point(1, 0);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(541, 206);
            GroupBox1.TabIndex = 0;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Thông tin vấn đề";
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(208, 16);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(200, 22);
            MaskedTextBox1.TabIndex = 26;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(11, 16);
            Label1.Name = "Label1";
            Label1.Size = new Size(71, 16);
            Label1.TabIndex = 27;
            Label1.Text = "Mã vấn đề";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(11, 53);
            Label2.Name = "Label2";
            Label2.Size = new Size(76, 16);
            Label2.TabIndex = 27;
            Label2.Text = "Tên vấn đề";
            // 
            // MaskedTextBox2
            // 
            MaskedTextBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox2.Location = new Point(208, 53);
            MaskedTextBox2.Name = "MaskedTextBox2";
            MaskedTextBox2.ReadOnly = true;
            MaskedTextBox2.Size = new Size(200, 22);
            MaskedTextBox2.TabIndex = 26;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(11, 95);
            Label3.Name = "Label3";
            Label3.Size = new Size(109, 16);
            Label3.TabIndex = 27;
            Label3.Text = "Tổng số đại biểu";
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(208, 95);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.ReadOnly = true;
            MaskedTextBox3.Size = new Size(200, 22);
            MaskedTextBox3.TabIndex = 26;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(11, 134);
            Label4.Name = "Label4";
            Label4.Size = new Size(113, 16);
            Label4.TabIndex = 27;
            Label4.Text = "Số phiếu đã nhập";
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(208, 134);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.ReadOnly = true;
            MaskedTextBox4.Size = new Size(200, 22);
            MaskedTextBox4.TabIndex = 26;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.Location = new Point(11, 173);
            Label5.Name = "Label5";
            Label5.Size = new Size(103, 16);
            Label5.TabIndex = 27;
            Label5.Text = "Số phiếu còn lại";
            // 
            // MaskedTextBox5
            // 
            MaskedTextBox5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox5.Location = new Point(208, 173);
            MaskedTextBox5.Name = "MaskedTextBox5";
            MaskedTextBox5.ReadOnly = true;
            MaskedTextBox5.Size = new Size(200, 22);
            MaskedTextBox5.TabIndex = 26;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(MaskedTextBox8);
            GroupBox2.Controls.Add(Label8);
            GroupBox2.Controls.Add(MaskedTextBox7);
            GroupBox2.Controls.Add(Label7);
            GroupBox2.Controls.Add(MaskedTextBox6);
            GroupBox2.Controls.Add(Label6);
            GroupBox2.Location = new Point(1, 209);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(541, 163);
            GroupBox2.TabIndex = 1;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Thông tin về các phiếu đã nhập";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(11, 34);
            Label6.Name = "Label6";
            Label6.Size = new Size(105, 16);
            Label6.TabIndex = 27;
            Label6.Text = "Số lượng đồng ý";
            // 
            // MaskedTextBox6
            // 
            MaskedTextBox6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox6.Location = new Point(208, 34);
            MaskedTextBox6.Name = "MaskedTextBox6";
            MaskedTextBox6.ReadOnly = true;
            MaskedTextBox6.Size = new Size(200, 22);
            MaskedTextBox6.TabIndex = 26;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(11, 73);
            Label7.Name = "Label7";
            Label7.Size = new Size(145, 16);
            Label7.TabIndex = 27;
            Label7.Text = "Số lượng không đồng ý";
            // 
            // MaskedTextBox7
            // 
            MaskedTextBox7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox7.Location = new Point(208, 73);
            MaskedTextBox7.Name = "MaskedTextBox7";
            MaskedTextBox7.ReadOnly = true;
            MaskedTextBox7.Size = new Size(200, 22);
            MaskedTextBox7.TabIndex = 26;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label8.Location = new Point(11, 113);
            Label8.Name = "Label8";
            Label8.Size = new Size(139, 16);
            Label8.TabIndex = 27;
            Label8.Text = "Số lượng không ý kiến";
            // 
            // MaskedTextBox8
            // 
            MaskedTextBox8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox8.Location = new Point(208, 113);
            MaskedTextBox8.Name = "MaskedTextBox8";
            MaskedTextBox8.ReadOnly = true;
            MaskedTextBox8.Size = new Size(200, 22);
            MaskedTextBox8.TabIndex = 26;
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(RadioButton3);
            GroupBox3.Controls.Add(RadioButton2);
            GroupBox3.Controls.Add(RadioButton1);
            GroupBox3.Location = new Point(1, 373);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Size = new Size(541, 56);
            GroupBox3.TabIndex = 2;
            GroupBox3.TabStop = false;
            // 
            // Button3
            // 
            _Button3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button3.Location = new Point(308, 457);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(160, 43);
            _Button3.TabIndex = 8;
            _Button3.Text = "Đóng";
            _Button3.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.ForeColor = Color.Red;
            _Button1.Location = new Point(38, 457);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(142, 43);
            _Button1.TabIndex = 7;
            _Button1.Text = "Nhập phần còn lại";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // RadioButton3
            // 
            RadioButton3.AutoSize = true;
            RadioButton3.Location = new Point(407, 20);
            RadioButton3.Name = "RadioButton3";
            RadioButton3.Size = new Size(87, 17);
            RadioButton3.TabIndex = 7;
            RadioButton3.Text = "Không ý kiến";
            RadioButton3.UseVisualStyleBackColor = true;
            // 
            // RadioButton2
            // 
            RadioButton2.AutoSize = true;
            RadioButton2.Location = new Point(208, 20);
            RadioButton2.Name = "RadioButton2";
            RadioButton2.Size = new Size(92, 17);
            RadioButton2.TabIndex = 6;
            RadioButton2.Text = "Không đồng ý";
            RadioButton2.UseVisualStyleBackColor = true;
            // 
            // RadioButton1
            // 
            RadioButton1.AutoSize = true;
            RadioButton1.Checked = true;
            RadioButton1.Location = new Point(37, 20);
            RadioButton1.Name = "RadioButton1";
            RadioButton1.Size = new Size(59, 17);
            RadioButton1.TabIndex = 5;
            RadioButton1.TabStop = true;
            RadioButton1.Text = "Đồng ý";
            RadioButton1.UseVisualStyleBackColor = true;
            // 
            // MatterVotes_ins_remain
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 536);
            Controls.Add(_Button3);
            Controls.Add(_Button1);
            Controls.Add(GroupBox3);
            Controls.Add(GroupBox2);
            Controls.Add(GroupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MatterVotes_ins_remain";
            Text = "Nhập TẤT CẢ phiếu biểu quyết CÒN LẠI";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            GroupBox3.ResumeLayout(false);
            GroupBox3.PerformLayout();
            Load += new EventHandler(MatterVotes_ins_remain_Load);
            ResumeLayout(false);
        }

        internal GroupBox GroupBox1;
        internal MaskedTextBox MaskedTextBox5;
        internal MaskedTextBox MaskedTextBox4;
        internal Label Label5;
        internal MaskedTextBox MaskedTextBox3;
        internal Label Label4;
        internal MaskedTextBox MaskedTextBox2;
        internal Label Label3;
        internal MaskedTextBox MaskedTextBox1;
        internal Label Label2;
        internal Label Label1;
        internal GroupBox GroupBox2;
        internal MaskedTextBox MaskedTextBox8;
        internal Label Label8;
        internal MaskedTextBox MaskedTextBox7;
        internal Label Label7;
        internal MaskedTextBox MaskedTextBox6;
        internal Label Label6;
        internal GroupBox GroupBox3;
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

        internal RadioButton RadioButton3;
        internal RadioButton RadioButton2;
        internal RadioButton RadioButton1;
    }
}