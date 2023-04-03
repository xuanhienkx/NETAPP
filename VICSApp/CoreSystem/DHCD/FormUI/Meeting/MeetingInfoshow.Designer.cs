using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class MeetingInfoshow : Form
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
            MaskedTextBox5 = new MaskedTextBox();
            Label5 = new Label();
            MaskedTextBox4 = new MaskedTextBox();
            Label4 = new Label();
            MaskedTextBox3 = new MaskedTextBox();
            Label3 = new Label();
            MaskedTextBox2 = new MaskedTextBox();
            Label2 = new Label();
            MaskedTextBox1 = new MaskedTextBox();
            Label1 = new Label();
            GroupBox2 = new GroupBox();
            _PrintButton1 = new Button();
            _PrintButton1.Click += new EventHandler(PrintButton1_Click);
            _MaskedTextBox11 = new MaskedTextBox();
            _MaskedTextBox11.MaskInputRejected += new MaskInputRejectedEventHandler(MaskedTextBox10_MaskInputRejected);
            _MaskedTextBox10 = new MaskedTextBox();
            _MaskedTextBox10.MaskInputRejected += new MaskInputRejectedEventHandler(MaskedTextBox10_MaskInputRejected);
            MaskedTextBox8 = new MaskedTextBox();
            MaskedTextBox9 = new MaskedTextBox();
            MaskedTextBox7 = new MaskedTextBox();
            Label11 = new Label();
            Label10 = new Label();
            Label8 = new Label();
            Label6 = new Label();
            MaskedTextBox6 = new MaskedTextBox();
            Label9 = new Label();
            Label7 = new Label();
            GroupBox1.SuspendLayout();
            GroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            GroupBox1.AutoSize = true;
            GroupBox1.Controls.Add(MaskedTextBox5);
            GroupBox1.Controls.Add(Label5);
            GroupBox1.Controls.Add(MaskedTextBox4);
            GroupBox1.Controls.Add(Label4);
            GroupBox1.Controls.Add(MaskedTextBox3);
            GroupBox1.Controls.Add(Label3);
            GroupBox1.Controls.Add(MaskedTextBox2);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Controls.Add(MaskedTextBox1);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            GroupBox1.Location = new Point(5, -1);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(813, 263);
            GroupBox1.TabIndex = 0;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Thông tin công ty";
            // 
            // MaskedTextBox5
            // 
            MaskedTextBox5.BackColor = SystemColors.Info;
            MaskedTextBox5.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox5.Location = new Point(191, 216);
            MaskedTextBox5.Name = "MaskedTextBox5";
            MaskedTextBox5.ReadOnly = true;
            MaskedTextBox5.Size = new Size(174, 26);
            MaskedTextBox5.TabIndex = 1;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.Location = new Point(7, 219);
            Label5.Name = "Label5";
            Label5.Size = new Size(153, 20);
            Label5.TabIndex = 0;
            Label5.Text = "Số quyền biểu quyết";
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.BackColor = SystemColors.Info;
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(191, 167);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.ReadOnly = true;
            MaskedTextBox4.Size = new Size(174, 26);
            MaskedTextBox4.TabIndex = 1;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(7, 170);
            Label4.Name = "Label4";
            Label4.Size = new Size(90, 20);
            Label4.TabIndex = 0;
            Label4.Text = "Số cổ phần";
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.BackColor = SystemColors.Info;
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(191, 115);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.ReadOnly = true;
            MaskedTextBox3.Size = new Size(174, 26);
            MaskedTextBox3.TabIndex = 1;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(7, 117);
            Label3.Name = "Label3";
            Label3.Size = new Size(90, 20);
            Label3.TabIndex = 0;
            Label3.Text = "Số cổ đông";
            // 
            // MaskedTextBox2
            // 
            MaskedTextBox2.BackColor = SystemColors.Info;
            MaskedTextBox2.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox2.Location = new Point(191, 68);
            MaskedTextBox2.Name = "MaskedTextBox2";
            MaskedTextBox2.ReadOnly = true;
            MaskedTextBox2.Size = new Size(609, 26);
            MaskedTextBox2.TabIndex = 1;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(7, 69);
            Label2.Name = "Label2";
            Label2.Size = new Size(77, 20);
            Label2.TabIndex = 0;
            Label2.Text = "Cuộc họp";
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.BackColor = SystemColors.Info;
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(191, 21);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(609, 26);
            MaskedTextBox1.TabIndex = 1;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(7, 22);
            Label1.Name = "Label1";
            Label1.Size = new Size(95, 20);
            Label1.TabIndex = 0;
            Label1.Text = "Tên công ty ";
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(_PrintButton1);
            GroupBox2.Controls.Add(_MaskedTextBox11);
            GroupBox2.Controls.Add(_MaskedTextBox10);
            GroupBox2.Controls.Add(MaskedTextBox8);
            GroupBox2.Controls.Add(MaskedTextBox9);
            GroupBox2.Controls.Add(MaskedTextBox7);
            GroupBox2.Controls.Add(Label11);
            GroupBox2.Controls.Add(Label10);
            GroupBox2.Controls.Add(Label8);
            GroupBox2.Controls.Add(Label6);
            GroupBox2.Controls.Add(MaskedTextBox6);
            GroupBox2.Controls.Add(Label9);
            GroupBox2.Controls.Add(Label7);
            GroupBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            GroupBox2.Location = new Point(5, 274);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(813, 326);
            GroupBox2.TabIndex = 0;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Thông tin cuộc họp";
            // 
            // PrintButton1
            // 
            _PrintButton1.BackColor = SystemColors.MenuBar;
            _PrintButton1.Image = My.Resources.Resources.Printer;
            _PrintButton1.Location = new Point(766, 280);
            _PrintButton1.Name = "_PrintButton1";
            _PrintButton1.Size = new Size(41, 40);
            _PrintButton1.TabIndex = 2;
            _PrintButton1.UseVisualStyleBackColor = false;
            // 
            // MaskedTextBox11
            // 
            _MaskedTextBox11.BackColor = SystemColors.Info;
            _MaskedTextBox11.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _MaskedTextBox11.Location = new Point(350, 274);
            _MaskedTextBox11.Name = "_MaskedTextBox11";
            _MaskedTextBox11.ReadOnly = true;
            _MaskedTextBox11.Size = new Size(174, 26);
            _MaskedTextBox11.TabIndex = 1;
            // 
            // MaskedTextBox10
            // 
            _MaskedTextBox10.BackColor = SystemColors.Info;
            _MaskedTextBox10.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _MaskedTextBox10.Location = new Point(350, 232);
            _MaskedTextBox10.Name = "_MaskedTextBox10";
            _MaskedTextBox10.ReadOnly = true;
            _MaskedTextBox10.Size = new Size(174, 26);
            _MaskedTextBox10.TabIndex = 1;
            // 
            // MaskedTextBox8
            // 
            MaskedTextBox8.BackColor = SystemColors.Info;
            MaskedTextBox8.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox8.Location = new Point(351, 132);
            MaskedTextBox8.Name = "MaskedTextBox8";
            MaskedTextBox8.ReadOnly = true;
            MaskedTextBox8.Size = new Size(174, 26);
            MaskedTextBox8.TabIndex = 1;
            // 
            // MaskedTextBox9
            // 
            MaskedTextBox9.BackColor = SystemColors.Info;
            MaskedTextBox9.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox9.Location = new Point(350, 183);
            MaskedTextBox9.Name = "MaskedTextBox9";
            MaskedTextBox9.ReadOnly = true;
            MaskedTextBox9.Size = new Size(174, 26);
            MaskedTextBox9.TabIndex = 1;
            // 
            // MaskedTextBox7
            // 
            MaskedTextBox7.BackColor = SystemColors.Info;
            MaskedTextBox7.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox7.Location = new Point(351, 83);
            MaskedTextBox7.Name = "MaskedTextBox7";
            MaskedTextBox7.ReadOnly = true;
            MaskedTextBox7.Size = new Size(174, 26);
            MaskedTextBox7.TabIndex = 1;
            // 
            // Label11
            // 
            Label11.AutoSize = true;
            Label11.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label11.Location = new Point(7, 280);
            Label11.Name = "Label11";
            Label11.Size = new Size(103, 20);
            Label11.TabIndex = 0;
            Label11.Text = "Tỷ lệ tham dự";
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label10.Location = new Point(6, 235);
            Label10.Name = "Label10";
            Label10.Size = new Size(153, 20);
            Label10.TabIndex = 0;
            Label10.Text = "Số quyền biểu quyết";
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label8.Location = new Point(7, 135);
            Label8.Name = "Label8";
            Label8.Size = new Size(204, 20);
            Label8.TabIndex = 0;
            Label8.Text = "Số cổ đông ủy quyền hợp lệ";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(7, 33);
            Label6.Name = "Label6";
            Label6.Size = new Size(88, 20);
            Label6.TabIndex = 0;
            Label6.Text = "Số đại biểu";
            // 
            // MaskedTextBox6
            // 
            MaskedTextBox6.BackColor = SystemColors.Info;
            MaskedTextBox6.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox6.Location = new Point(351, 31);
            MaskedTextBox6.Name = "MaskedTextBox6";
            MaskedTextBox6.ReadOnly = true;
            MaskedTextBox6.Size = new Size(174, 26);
            MaskedTextBox6.TabIndex = 1;
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label9.Location = new Point(6, 186);
            Label9.Name = "Label9";
            Label9.Size = new Size(337, 20);
            Label9.TabIndex = 0;
            Label9.Text = "Tổng số cổ đông tham dự và cổ đông ủy quyền";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(7, 86);
            Label7.Name = "Label7";
            Label7.Size = new Size(213, 20);
            Label7.TabIndex = 0;
            Label7.Text = "Số cổ đông trực tiếp tham dự";
            // 
            // MeetingInfoshow
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 614);
            Controls.Add(GroupBox2);
            Controls.Add(GroupBox1);
            KeyPreview = true;
            Name = "MeetingInfoshow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin cuộc họp";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            Load += new EventHandler(MeetingInfoshow_Load);
            KeyUp += new KeyEventHandler(MeetingInfoshow_KeyUp);
            ResumeLayout(false);
            PerformLayout();
        }

        internal GroupBox GroupBox1;
        internal MaskedTextBox MaskedTextBox1;
        internal Label Label1;
        internal GroupBox GroupBox2;
        internal MaskedTextBox MaskedTextBox5;
        internal Label Label5;
        internal MaskedTextBox MaskedTextBox4;
        internal Label Label4;
        internal MaskedTextBox MaskedTextBox3;
        internal Label Label3;
        internal MaskedTextBox MaskedTextBox2;
        internal Label Label2;
        private MaskedTextBox _MaskedTextBox10;

        internal MaskedTextBox MaskedTextBox10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaskedTextBox10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MaskedTextBox10 != null)
                {
                    _MaskedTextBox10.MaskInputRejected -= MaskedTextBox10_MaskInputRejected;
                }

                _MaskedTextBox10 = value;
                if (_MaskedTextBox10 != null)
                {
                    _MaskedTextBox10.MaskInputRejected += MaskedTextBox10_MaskInputRejected;
                }
            }
        }

        internal MaskedTextBox MaskedTextBox8;
        internal MaskedTextBox MaskedTextBox9;
        internal MaskedTextBox MaskedTextBox7;
        internal Label Label10;
        internal Label Label8;
        internal Label Label6;
        internal MaskedTextBox MaskedTextBox6;
        internal Label Label9;
        internal Label Label7;
        internal Label Label11;
        private MaskedTextBox _MaskedTextBox11;

        internal MaskedTextBox MaskedTextBox11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MaskedTextBox11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MaskedTextBox11 != null)
                {
                    _MaskedTextBox11.MaskInputRejected -= MaskedTextBox10_MaskInputRejected;
                }

                _MaskedTextBox11 = value;
                if (_MaskedTextBox11 != null)
                {
                    _MaskedTextBox11.MaskInputRejected += MaskedTextBox10_MaskInputRejected;
                }
            }
        }

        private Button _PrintButton1;

        internal Button PrintButton1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PrintButton1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PrintButton1 != null)
                {
                    _PrintButton1.Click -= PrintButton1_Click;
                }

                _PrintButton1 = value;
                if (_PrintButton1 != null)
                {
                    _PrintButton1.Click += PrintButton1_Click;
                }
            }
        }
    }
}