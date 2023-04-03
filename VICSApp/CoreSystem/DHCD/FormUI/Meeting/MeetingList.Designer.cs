using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class MeetingList : Form
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
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            var DataGridViewCellStyle2 = new DataGridViewCellStyle();
            ToolStrip1 = new ToolStrip();
            _ToolStripButton1 = new ToolStripButton();
            _ToolStripButton1.Click += new EventHandler(ToolStripButton1_Click);
            _ToolStripButton2 = new ToolStripButton();
            _ToolStripButton2.Click += new EventHandler(ToolStripButton2_Click);
            _ToolStripButton3 = new ToolStripButton();
            _ToolStripButton3.Click += new EventHandler(ToolStripButton3_Click);
            ToolStripSeparator1 = new ToolStripSeparator();
            ToolStripLabel1 = new ToolStripLabel();
            ToolStripTextBox1 = new ToolStripTextBox();
            _ToolStripButton4 = new ToolStripButton();
            _ToolStripButton4.Click += new EventHandler(ToolStripButton4_Click);
            ToolStripSeparator2 = new ToolStripSeparator();
            _ToolStripButton5 = new ToolStripButton();
            _ToolStripButton5.Click += new EventHandler(ToolStripButton5_Click);
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            _DataGridView1 = new DataGridView();
            _DataGridView1.KeyDown += new KeyEventHandler(DataGridView1_KeyDown);
            Meetingcode = new DataGridViewTextBoxColumn();
            Meetingname = new DataGridViewTextBoxColumn();
            CompanyName = new DataGridViewTextBoxColumn();
            CompanyAddress = new DataGridViewTextBoxColumn();
            Meetingaddress = new DataGridViewTextBoxColumn();
            meetingtime = new DataGridViewTextBoxColumn();
            ToolStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { _ToolStripButton1, _ToolStripButton2, _ToolStripButton3, ToolStripSeparator1, ToolStripLabel1, ToolStripTextBox1, _ToolStripButton4, ToolStripSeparator2, _ToolStripButton5 });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(898, 25);
            ToolStrip1.TabIndex = 1;
            ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton1
            // 
            _ToolStripButton1.Image = My.Resources.Resources.Add;
            _ToolStripButton1.ImageTransparentColor = Color.Magenta;
            _ToolStripButton1.Name = "_ToolStripButton1";
            _ToolStripButton1.Size = new Size(74, 22);
            _ToolStripButton1.Text = "Thêm(A)";
            // 
            // ToolStripButton2
            // 
            _ToolStripButton2.Image = My.Resources.Resources.Document;
            _ToolStripButton2.ImageTransparentColor = Color.Magenta;
            _ToolStripButton2.Name = "_ToolStripButton2";
            _ToolStripButton2.Size = new Size(60, 22);
            _ToolStripButton2.Text = "Sửa(E)";
            // 
            // ToolStripButton3
            // 
            _ToolStripButton3.Image = My.Resources.Resources.Delete;
            _ToolStripButton3.ImageTransparentColor = Color.Magenta;
            _ToolStripButton3.Name = "_ToolStripButton3";
            _ToolStripButton3.Size = new Size(63, 22);
            _ToolStripButton3.Text = "Xóa(D)";
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolStripLabel1
            // 
            ToolStripLabel1.Name = "ToolStripLabel1";
            ToolStripLabel1.Size = new Size(77, 22);
            ToolStripLabel1.Text = "Mã cuộc họp";
            // 
            // ToolStripTextBox1
            // 
            ToolStripTextBox1.Name = "ToolStripTextBox1";
            ToolStripTextBox1.Size = new Size(100, 25);
            // 
            // ToolStripButton4
            // 
            _ToolStripButton4.Image = My.Resources.Resources.Search;
            _ToolStripButton4.ImageTransparentColor = Color.Magenta;
            _ToolStripButton4.Name = "_ToolStripButton4";
            _ToolStripButton4.Size = new Size(48, 22);
            _ToolStripButton4.Text = "Tìm";
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripButton5
            // 
            _ToolStripButton5.Image = My.Resources.Resources.officemac01;
            _ToolStripButton5.ImageTransparentColor = Color.Magenta;
            _ToolStripButton5.Name = "_ToolStripButton5";
            _ToolStripButton5.Size = new Size(167, 22);
            _ToolStripButton5.Text = "Chọn cuộc họp(S or Enter)";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2 });
            StatusStrip1.Location = new Point(0, 415);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(898, 22);
            StatusStrip1.TabIndex = 3;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(106, 17);
            ToolStripStatusLabel1.Text = "Số lượng bản ghi : ";
            // 
            // ToolStripStatusLabel2
            // 
            ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            ToolStripStatusLabel2.Size = new Size(0, 17);
            // 
            // DataGridView1
            // 
            _DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            _DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            _DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Meetingcode, Meetingname, CompanyName, CompanyAddress, Meetingaddress, meetingtime });
            _DataGridView1.Dock = DockStyle.Fill;
            _DataGridView1.Location = new Point(0, 25);
            _DataGridView1.Name = "_DataGridView1";
            _DataGridView1.ReadOnly = true;
            _DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _DataGridView1.Size = new Size(898, 390);
            _DataGridView1.TabIndex = 4;
            // 
            // Meetingcode
            // 
            Meetingcode.DataPropertyName = "Meetingcode";
            Meetingcode.FillWeight = 59.37841f;
            Meetingcode.HeaderText = "Mã cuộc họp";
            Meetingcode.Name = "Meetingcode";
            Meetingcode.ReadOnly = true;
            // 
            // Meetingname
            // 
            Meetingname.DataPropertyName = "Meetingname";
            Meetingname.FillWeight = 65.68176f;
            Meetingname.HeaderText = "Tên cuộc họp";
            Meetingname.MinimumWidth = 100;
            Meetingname.Name = "Meetingname";
            Meetingname.ReadOnly = true;
            // 
            // CompanyName
            // 
            CompanyName.DataPropertyName = "CompanyName";
            CompanyName.FillWeight = 138.3765f;
            CompanyName.HeaderText = "Tên công ty";
            CompanyName.MinimumWidth = 8;
            CompanyName.Name = "CompanyName";
            CompanyName.ReadOnly = true;
            // 
            // CompanyAddress
            // 
            CompanyAddress.DataPropertyName = "CompanyAddress";
            CompanyAddress.FillWeight = 79.50503f;
            CompanyAddress.HeaderText = "Đ/C công ty";
            CompanyAddress.Name = "CompanyAddress";
            CompanyAddress.ReadOnly = true;
            // 
            // Meetingaddress
            // 
            Meetingaddress.DataPropertyName = "Meetingaddress";
            Meetingaddress.FillWeight = 24.77251f;
            Meetingaddress.HeaderText = "Địa điểm tổ chức";
            Meetingaddress.Name = "Meetingaddress";
            Meetingaddress.ReadOnly = true;
            Meetingaddress.Visible = false;
            // 
            // meetingtime
            // 
            meetingtime.DataPropertyName = "meetingtime";
            DataGridViewCellStyle2.NullValue = null;
            meetingtime.DefaultCellStyle = DataGridViewCellStyle2;
            meetingtime.FillWeight = 38.75047f;
            meetingtime.HeaderText = "Thời gian tổ chức";
            meetingtime.Name = "meetingtime";
            meetingtime.ReadOnly = true;
            // 
            // MeetingList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 437);
            Controls.Add(_DataGridView1);
            Controls.Add(StatusStrip1);
            Controls.Add(ToolStrip1);
            KeyPreview = true;
            Name = "MeetingList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách cuộc họp";
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_DataGridView1).EndInit();
            Load += new EventHandler(MeetingList_Load);
            KeyUp += new KeyEventHandler(MeetingList_KeyUp);
            ResumeLayout(false);
            PerformLayout();
        }

        internal ToolStrip ToolStrip1;
        private ToolStripButton _ToolStripButton1;

        internal ToolStripButton ToolStripButton1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton1 != null)
                {
                    _ToolStripButton1.Click -= ToolStripButton1_Click;
                }

                _ToolStripButton1 = value;
                if (_ToolStripButton1 != null)
                {
                    _ToolStripButton1.Click += ToolStripButton1_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButton2;

        internal ToolStripButton ToolStripButton2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton2 != null)
                {
                    _ToolStripButton2.Click -= ToolStripButton2_Click;
                }

                _ToolStripButton2 = value;
                if (_ToolStripButton2 != null)
                {
                    _ToolStripButton2.Click += ToolStripButton2_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButton3;

        internal ToolStripButton ToolStripButton3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton3 != null)
                {
                    _ToolStripButton3.Click -= ToolStripButton3_Click;
                }

                _ToolStripButton3 = value;
                if (_ToolStripButton3 != null)
                {
                    _ToolStripButton3.Click += ToolStripButton3_Click;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripLabel ToolStripLabel1;
        internal ToolStripTextBox ToolStripTextBox1;
        private ToolStripButton _ToolStripButton4;

        internal ToolStripButton ToolStripButton4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton4 != null)
                {
                    _ToolStripButton4.Click -= ToolStripButton4_Click;
                }

                _ToolStripButton4 = value;
                if (_ToolStripButton4 != null)
                {
                    _ToolStripButton4.Click += ToolStripButton4_Click;
                }
            }
        }

        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        private DataGridView _DataGridView1;

        internal DataGridView DataGridView1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DataGridView1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DataGridView1 != null)
                {
                    _DataGridView1.KeyDown -= DataGridView1_KeyDown;
                }

                _DataGridView1 = value;
                if (_DataGridView1 != null)
                {
                    _DataGridView1.KeyDown += DataGridView1_KeyDown;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator2;
        private ToolStripButton _ToolStripButton5;

        internal ToolStripButton ToolStripButton5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton5 != null)
                {
                    _ToolStripButton5.Click -= ToolStripButton5_Click;
                }

                _ToolStripButton5 = value;
                if (_ToolStripButton5 != null)
                {
                    _ToolStripButton5.Click += ToolStripButton5_Click;
                }
            }
        }

        internal DataGridViewTextBoxColumn Meetingcode;
        internal DataGridViewTextBoxColumn Meetingname;
        internal DataGridViewTextBoxColumn CompanyName;
        internal DataGridViewTextBoxColumn CompanyAddress;
        internal DataGridViewTextBoxColumn Meetingaddress;
        internal DataGridViewTextBoxColumn meetingtime;
    }
}