using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class DelegateUpdate : Form
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
            MaskedTextBox2 = new MaskedTextBox();
            MaskedTextBox1 = new MaskedTextBox();
            Label2 = new Label();
            Label1 = new Label();
            MaskedTextBox5 = new MaskedTextBox();
            MaskedTextBox4 = new MaskedTextBox();
            MaskedTextBox3 = new MaskedTextBox();
            Label4 = new Label();
            Label3 = new Label();
            Label7 = new Label();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Button2 = new Button();
            _Button2.Click += new EventHandler(Button2_Click);
            SuspendLayout();
            // 
            // MaskedTextBox2
            // 
            MaskedTextBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox2.Location = new Point(164, 44);
            MaskedTextBox2.Name = "MaskedTextBox2";
            MaskedTextBox2.ReadOnly = true;
            MaskedTextBox2.Size = new Size(200, 22);
            MaskedTextBox2.TabIndex = 29;
            MaskedTextBox2.TabStop = false;
            // 
            // MaskedTextBox1
            // 
            MaskedTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox1.Location = new Point(164, 9);
            MaskedTextBox1.Name = "MaskedTextBox1";
            MaskedTextBox1.ReadOnly = true;
            MaskedTextBox1.Size = new Size(200, 22);
            MaskedTextBox1.TabIndex = 30;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(12, 50);
            Label2.Name = "Label2";
            Label2.Size = new Size(78, 16);
            Label2.TabIndex = 32;
            Label2.Text = "Mã đại biểu";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(12, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(85, 16);
            Label1.TabIndex = 31;
            Label1.Text = "Mã cuộc họp";
            // 
            // MaskedTextBox5
            // 
            MaskedTextBox5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox5.Location = new Point(164, 216);
            MaskedTextBox5.Name = "MaskedTextBox5";
            MaskedTextBox5.Size = new Size(380, 22);
            MaskedTextBox5.TabIndex = 2;
            // 
            // MaskedTextBox4
            // 
            MaskedTextBox4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox4.Location = new Point(164, 178);
            MaskedTextBox4.Name = "MaskedTextBox4";
            MaskedTextBox4.Size = new Size(380, 22);
            MaskedTextBox4.TabIndex = 1;
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(164, 132);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.Size = new Size(200, 22);
            MaskedTextBox3.TabIndex = 0;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.Location = new Point(12, 222);
            Label4.Name = "Label4";
            Label4.Size = new Size(48, 16);
            Label4.TabIndex = 36;
            Label4.Text = "Địa chỉ";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.Location = new Point(11, 178);
            Label3.Name = "Label3";
            Label3.Size = new Size(83, 16);
            Label3.TabIndex = 38;
            Label3.Text = "Tên đại biểu";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(12, 134);
            Label7.Name = "Label7";
            Label7.Size = new Size(60, 16);
            Label7.TabIndex = 37;
            Label7.Text = "CMT/HC";
            // 
            // Button1
            // 
            _Button1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.Location = new Point(126, 277);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(127, 47);
            _Button1.TabIndex = 39;
            _Button1.Text = "Cập nhật(Enter)";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            _Button2.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button2.Location = new Point(289, 277);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(127, 47);
            _Button2.TabIndex = 39;
            _Button2.Text = "Đóng(ESC)";
            _Button2.UseVisualStyleBackColor = true;
            // 
            // DelegateUpdate
            // 
            AcceptButton = _Button1;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 374);
            Controls.Add(_Button2);
            Controls.Add(_Button1);
            Controls.Add(MaskedTextBox5);
            Controls.Add(MaskedTextBox4);
            Controls.Add(MaskedTextBox3);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label7);
            Controls.Add(MaskedTextBox2);
            Controls.Add(MaskedTextBox1);
            Controls.Add(Label2);
            Controls.Add(Label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "DelegateUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cập nhật thông tin đại biểu";
            Load += new EventHandler(DelegateUpdate_Load);
            KeyUp += new KeyEventHandler(DelegateUpdate_KeyUp);
            ResumeLayout(false);
            PerformLayout();
        }

        internal MaskedTextBox MaskedTextBox2;
        internal MaskedTextBox MaskedTextBox1;
        internal Label Label2;
        internal Label Label1;
        internal MaskedTextBox MaskedTextBox5;
        internal MaskedTextBox MaskedTextBox4;
        internal MaskedTextBox MaskedTextBox3;
        internal Label Label4;
        internal Label Label3;
        internal Label Label7;
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
    }
}