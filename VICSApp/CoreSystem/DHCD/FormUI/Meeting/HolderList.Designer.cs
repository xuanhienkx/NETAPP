using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class HolderList : Form
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
            var DataGridViewCellStyle3 = new DataGridViewCellStyle();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(HolderList));
            ToolStrip1 = new ToolStrip();
            _ToolStripButton1 = new ToolStripButton();
            _ToolStripButton1.Click += new EventHandler(ToolStripButton1_Click);
            _ToolStripButton2 = new ToolStripButton();
            _ToolStripButton2.Click += new EventHandler(ToolStripButton2_Click);
            _ToolStripButton3 = new ToolStripButton();
            _ToolStripButton3.Click += new EventHandler(ToolStripButton3_Click);
            ToolStripSeparator1 = new ToolStripSeparator();
            ToolStripLabel1 = new ToolStripLabel();
            _ToolStripTextBox1 = new ToolStripTextBox();
            _ToolStripTextBox1.KeyUp += new KeyEventHandler(ToolStripTextBox1_KeyUp);
            ToolStripSeparator2 = new ToolStripSeparator();
            ToolStripLabel2 = new ToolStripLabel();
            _ToolStripTextBox2 = new ToolStripTextBox();
            _ToolStripTextBox2.KeyUp += new KeyEventHandler(ToolStripTextBox2_KeyUp);
            _ToolStripButton4 = new ToolStripButton();
            _ToolStripButton4.Click += new EventHandler(ToolStripButton4_Click);
            _ToolStripButton6 = new ToolStripButton();
            _ToolStripButton6.Click += new EventHandler(ToolStripButton6_Click);
            _ToolStripButton5 = new ToolStripButton();
            _ToolStripButton5.Click += new EventHandler(ToolStripButton5_Click);
            DataGridView1 = new DataGridView();
            holdercode = new DataGridViewTextBoxColumn();
            HolderName = new DataGridViewTextBoxColumn();
            HolderIdentity = new DataGridViewTextBoxColumn();
            HolderAddress = new DataGridViewTextBoxColumn();
            Shares = new DataGridViewTextBoxColumn();
            Voterights = new DataGridViewTextBoxColumn();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStripSplitButton1 = new ToolStripSplitButton();
            ToolStripStatusLabel3 = new ToolStripStatusLabel();
            ToolStripStatusLabel4 = new ToolStripStatusLabel();
            ToolStripSplitButton2 = new ToolStripSplitButton();
            ToolStripStatusLabel5 = new ToolStripStatusLabel();
            ToolStripStatusLabel6 = new ToolStripStatusLabel();
            ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { _ToolStripButton1, _ToolStripButton2, _ToolStripButton3, ToolStripSeparator1, ToolStripLabel1, _ToolStripTextBox1, ToolStripSeparator2, ToolStripLabel2, _ToolStripTextBox2, _ToolStripButton4, _ToolStripButton6, _ToolStripButton5 });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(832, 25);
            ToolStrip1.TabIndex = 2;
            ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton1
            // 
            _ToolStripButton1.Image = My.Resources.Resources.Add;
            _ToolStripButton1.ImageTransparentColor = Color.Magenta;
            _ToolStripButton1.Name = "_ToolStripButton1";
            _ToolStripButton1.Size = new Size(68, 22);
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
            _ToolStripButton3.Size = new Size(60, 22);
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
            ToolStripLabel1.Size = new Size(62, 22);
            ToolStripLabel1.Text = "Mã cổ đông";
            // 
            // ToolStripTextBox1
            // 
            _ToolStripTextBox1.Name = "_ToolStripTextBox1";
            _ToolStripTextBox1.Size = new Size(100, 25);
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripLabel2
            // 
            ToolStripLabel2.Name = "ToolStripLabel2";
            ToolStripLabel2.Size = new Size(58, 22);
            ToolStripLabel2.Text = "CMT/GPKD";
            // 
            // ToolStripTextBox2
            // 
            _ToolStripTextBox2.Name = "_ToolStripTextBox2";
            _ToolStripTextBox2.Size = new Size(100, 25);
            // 
            // ToolStripButton4
            // 
            _ToolStripButton4.Image = My.Resources.Resources.Search;
            _ToolStripButton4.ImageTransparentColor = Color.Magenta;
            _ToolStripButton4.Name = "_ToolStripButton4";
            _ToolStripButton4.Size = new Size(43, 22);
            _ToolStripButton4.Text = "Tìm";
            // 
            // ToolStripButton6
            // 
            _ToolStripButton6.Image = My.Resources.Resources.Printer;
            _ToolStripButton6.ImageTransparentColor = Color.Magenta;
            _ToolStripButton6.Name = "_ToolStripButton6";
            _ToolStripButton6.Size = new Size(93, 22);
            _ToolStripButton6.Text = "In tài liệu..(P)";
            // 
            // ToolStripButton5
            // 
            _ToolStripButton5.Image = My.Resources.Resources.Printer;
            _ToolStripButton5.ImageTransparentColor = Color.Magenta;
            _ToolStripButton5.Name = "_ToolStripButton5";
            _ToolStripButton5.Size = new Size(84, 22);
            _ToolStripButton5.Text = "In nhiều CĐ";
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { holdercode, HolderName, HolderIdentity, HolderAddress, Shares, Voterights });
            DataGridView1.Dock = DockStyle.Fill;
            DataGridView1.Location = new Point(0, 25);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.Size = new Size(832, 440);
            DataGridView1.TabIndex = 5;
            // 
            // holdercode
            // 
            holdercode.DataPropertyName = "holdercode";
            holdercode.FillWeight = 59.08628f;
            holdercode.HeaderText = "Mã cổ đông";
            holdercode.Name = "holdercode";
            holdercode.ReadOnly = true;
            holdercode.Width = 50;
            // 
            // HolderName
            // 
            HolderName.DataPropertyName = "HolderName";
            HolderName.FillWeight = 59.08628f;
            HolderName.HeaderText = "Tên cổ đông";
            HolderName.Name = "HolderName";
            HolderName.ReadOnly = true;
            HolderName.Width = 120;
            // 
            // HolderIdentity
            // 
            HolderIdentity.DataPropertyName = "HolderIdentity";
            HolderIdentity.FillWeight = 59.08628f;
            HolderIdentity.HeaderText = "CMT/GPKD";
            HolderIdentity.Name = "HolderIdentity";
            HolderIdentity.ReadOnly = true;
            HolderIdentity.Width = 94;
            // 
            // HolderAddress
            // 
            HolderAddress.DataPropertyName = "HolderAddress";
            HolderAddress.FillWeight = 200.0f;
            HolderAddress.HeaderText = "Địa chỉ";
            HolderAddress.Name = "HolderAddress";
            HolderAddress.ReadOnly = true;
            HolderAddress.Width = 319;
            // 
            // Shares
            // 
            Shares.DataPropertyName = "Shares";
            DataGridViewCellStyle2.Format = "N0";
            Shares.DefaultCellStyle = DataGridViewCellStyle2;
            Shares.FillWeight = 59.08628f;
            Shares.HeaderText = "Số cổ phần";
            Shares.Name = "Shares";
            Shares.ReadOnly = true;
            Shares.Width = 94;
            // 
            // Voterights
            // 
            Voterights.DataPropertyName = "Voterights";
            DataGridViewCellStyle3.Format = "N0";
            DataGridViewCellStyle3.NullValue = null;
            Voterights.DefaultCellStyle = DataGridViewCellStyle3;
            Voterights.FillWeight = 59.08628f;
            Voterights.HeaderText = "Số quyền biểu quyết";
            Voterights.Name = "Voterights";
            Voterights.ReadOnly = true;
            Voterights.Width = 94;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripSplitButton1, ToolStripStatusLabel3, ToolStripStatusLabel4, ToolStripSplitButton2, ToolStripStatusLabel5, ToolStripStatusLabel6 });
            StatusStrip1.Location = new Point(0, 443);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(832, 22);
            StatusStrip1.TabIndex = 6;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(97, 17);
            ToolStripStatusLabel1.Text = "Số lượng bản ghi : ";
            // 
            // ToolStripStatusLabel2
            // 
            ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            ToolStripStatusLabel2.Size = new Size(0, 17);
            // 
            // ToolStripSplitButton1
            // 
            ToolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.None;
            ToolStripSplitButton1.Name = "ToolStripSplitButton1";
            ToolStripSplitButton1.Size = new Size(16, 20);
            ToolStripSplitButton1.Text = "ToolStripSplitButton1";
            // 
            // ToolStripStatusLabel3
            // 
            ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            ToolStripStatusLabel3.Size = new Size(96, 17);
            ToolStripStatusLabel3.Text = "Tổng số cổ phần : ";
            // 
            // ToolStripStatusLabel4
            // 
            ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            ToolStripStatusLabel4.Size = new Size(0, 17);
            // 
            // ToolStripSplitButton2
            // 
            ToolStripSplitButton2.DisplayStyle = ToolStripItemDisplayStyle.None;
            ToolStripSplitButton2.Image = (Image)resources.GetObject("ToolStripSplitButton2.Image");
            ToolStripSplitButton2.ImageTransparentColor = Color.Magenta;
            ToolStripSplitButton2.Name = "ToolStripSplitButton2";
            ToolStripSplitButton2.Size = new Size(16, 20);
            ToolStripSplitButton2.Text = "ToolStripSplitButton2";
            // 
            // ToolStripStatusLabel5
            // 
            ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            ToolStripStatusLabel5.Size = new Size(142, 17);
            ToolStripStatusLabel5.Text = "Tổng số quyền biểu quyết : ";
            // 
            // ToolStripStatusLabel6
            // 
            ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            ToolStripStatusLabel6.Size = new Size(0, 17);
            // 
            // HolderList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 465);
            Controls.Add(StatusStrip1);
            Controls.Add(DataGridView1);
            Controls.Add(ToolStrip1);
            KeyPreview = true;
            Name = "HolderList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách cổ đông";
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            Load += new EventHandler(HolderList_Load);
            KeyUp += new KeyEventHandler(HolderList_KeyUp);
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
        private ToolStripTextBox _ToolStripTextBox1;

        internal ToolStripTextBox ToolStripTextBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripTextBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripTextBox1 != null)
                {
                    _ToolStripTextBox1.KeyUp -= ToolStripTextBox1_KeyUp;
                }

                _ToolStripTextBox1 = value;
                if (_ToolStripTextBox1 != null)
                {
                    _ToolStripTextBox1.KeyUp += ToolStripTextBox1_KeyUp;
                }
            }
        }

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

        internal ToolStripSeparator ToolStripSeparator2;
        internal ToolStripLabel ToolStripLabel2;
        private ToolStripTextBox _ToolStripTextBox2;

        internal ToolStripTextBox ToolStripTextBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripTextBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripTextBox2 != null)
                {
                    _ToolStripTextBox2.KeyUp -= ToolStripTextBox2_KeyUp;
                }

                _ToolStripTextBox2 = value;
                if (_ToolStripTextBox2 != null)
                {
                    _ToolStripTextBox2.KeyUp += ToolStripTextBox2_KeyUp;
                }
            }
        }

        internal DataGridView DataGridView1;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        internal ToolStripSplitButton ToolStripSplitButton1;
        internal ToolStripStatusLabel ToolStripStatusLabel3;
        internal ToolStripStatusLabel ToolStripStatusLabel4;
        internal ToolStripSplitButton ToolStripSplitButton2;
        internal ToolStripStatusLabel ToolStripStatusLabel5;
        internal ToolStripStatusLabel ToolStripStatusLabel6;
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

        internal DataGridViewTextBoxColumn holdercode;
        internal DataGridViewTextBoxColumn HolderName;
        internal DataGridViewTextBoxColumn HolderIdentity;
        internal DataGridViewTextBoxColumn HolderAddress;
        internal DataGridViewTextBoxColumn Shares;
        internal DataGridViewTextBoxColumn Voterights;
        private ToolStripButton _ToolStripButton6;

        internal ToolStripButton ToolStripButton6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton6 != null)
                {
                    _ToolStripButton6.Click -= ToolStripButton6_Click;
                }

                _ToolStripButton6 = value;
                if (_ToolStripButton6 != null)
                {
                    _ToolStripButton6.Click += ToolStripButton6_Click;
                }
            }
        }
    }
}