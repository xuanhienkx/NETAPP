using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class Meeting_ins_update : Form
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.MaskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.MaskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.MaskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.MaskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this._Button1 = new System.Windows.Forms.Button();
            this._Button3 = new System.Windows.Forms.Button();
            this.MaskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtPeriod = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbMettingType = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(13, 40);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(85, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Mã cuộc họp";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(13, 81);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(90, 16);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Tên cuộc họp";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(12, 127);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(78, 16);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Tên công ty";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(13, 171);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(94, 16);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Địa chỉ công ty";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(13, 215);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(106, 16);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Địa điểm tổ chức";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(12, 248);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(86, 16);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Ngày tổ chức";
            // 
            // MaskedTextBox1
            // 
            this.MaskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskedTextBox1.Location = new System.Drawing.Point(165, 40);
            this.MaskedTextBox1.Name = "MaskedTextBox1";
            this.MaskedTextBox1.Size = new System.Drawing.Size(142, 22);
            this.MaskedTextBox1.TabIndex = 0;
            // 
            // MaskedTextBox2
            // 
            this.MaskedTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskedTextBox2.Location = new System.Drawing.Point(165, 75);
            this.MaskedTextBox2.Name = "MaskedTextBox2";
            this.MaskedTextBox2.Size = new System.Drawing.Size(343, 22);
            this.MaskedTextBox2.TabIndex = 1;
            // 
            // MaskedTextBox3
            // 
            this.MaskedTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskedTextBox3.Location = new System.Drawing.Point(165, 121);
            this.MaskedTextBox3.Name = "MaskedTextBox3";
            this.MaskedTextBox3.Size = new System.Drawing.Size(343, 22);
            this.MaskedTextBox3.TabIndex = 2;
            // 
            // MaskedTextBox4
            // 
            this.MaskedTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskedTextBox4.Location = new System.Drawing.Point(165, 165);
            this.MaskedTextBox4.Name = "MaskedTextBox4";
            this.MaskedTextBox4.Size = new System.Drawing.Size(343, 22);
            this.MaskedTextBox4.TabIndex = 3;
            // 
            // _Button1
            // 
            this._Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Button1.Location = new System.Drawing.Point(53, 363);
            this._Button1.Name = "_Button1";
            this._Button1.Size = new System.Drawing.Size(121, 35);
            this._Button1.TabIndex = 6;
            this._Button1.Text = "Thêm";
            this._Button1.UseVisualStyleBackColor = true;
            this._Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // _Button3
            // 
            this._Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Button3.Location = new System.Drawing.Point(334, 363);
            this._Button3.Name = "_Button3";
            this._Button3.Size = new System.Drawing.Size(135, 35);
            this._Button3.TabIndex = 7;
            this._Button3.Text = "Đóng";
            this._Button3.UseVisualStyleBackColor = true;
            this._Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // MaskedTextBox5
            // 
            this.MaskedTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaskedTextBox5.Location = new System.Drawing.Point(165, 209);
            this.MaskedTextBox5.Name = "MaskedTextBox5";
            this.MaskedTextBox5.Size = new System.Drawing.Size(343, 22);
            this.MaskedTextBox5.TabIndex = 4;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.DateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker1.Location = new System.Drawing.Point(165, 248);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.DateTimePicker1.TabIndex = 5;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriod.Location = new System.Drawing.Point(165, 285);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(108, 22);
            this.txtPeriod.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Nhiệm kỳ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Loại hình";
            // 
            // cbMettingType
            // 
            this.cbMettingType.FormattingEnabled = true;
            this.cbMettingType.Items.AddRange(new object[] {
            "Thường Niên",
            "Bất Thường"});
            this.cbMettingType.Location = new System.Drawing.Point(164, 313);
            this.cbMettingType.Name = "cbMettingType";
            this.cbMettingType.Size = new System.Drawing.Size(121, 21);
            this.cbMettingType.TabIndex = 12;
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(400, 285);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(108, 22);
            this.txtYear.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(314, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Năm Đại hội";
            this.label9.UseWaitCursor = true;
            // 
            // Meeting_ins_update
            // 
            this.AcceptButton = this._Button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 441);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbMettingType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPeriod);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._Button3);
            this.Controls.Add(this._Button1);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.MaskedTextBox5);
            this.Controls.Add(this.MaskedTextBox4);
            this.Controls.Add(this.MaskedTextBox3);
            this.Controls.Add(this.MaskedTextBox2);
            this.Controls.Add(this.MaskedTextBox1);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Meeting_ins_update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mã cuộc họp";
            this.Load += new System.EventHandler(this.Meeting_ins_update_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Meeting_ins_update_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal Label Label6;
        internal MaskedTextBox MaskedTextBox1;
        internal MaskedTextBox MaskedTextBox2;
        internal MaskedTextBox MaskedTextBox3;
        internal MaskedTextBox MaskedTextBox4;
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

        internal MaskedTextBox MaskedTextBox5;
        internal DateTimePicker DateTimePicker1;
        internal MaskedTextBox txtPeriod;
        internal Label label7;
        internal Label label8;
        private ComboBox cbMettingType;
        internal MaskedTextBox txtYear;
        internal Label label9;
    }
}