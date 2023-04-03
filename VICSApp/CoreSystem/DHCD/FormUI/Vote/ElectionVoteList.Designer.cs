using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class ElectionVoteList : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ElectionVoteList));
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            var DataGridViewCellStyle2 = new DataGridViewCellStyle();
            var DataGridViewCellStyle3 = new DataGridViewCellStyle();
            ToolStrip1 = new ToolStrip();
            _ToolStripButton1 = new ToolStripButton();
            _ToolStripButton1.Click += new EventHandler(ToolStripButton1_Click);
            _ToolStripButton2 = new ToolStripButton();
            _ToolStripButton2.Click += new EventHandler(ToolStripButton2_Click);
            _ToolStripButton3 = new ToolStripButton();
            _ToolStripButton3.Click += new EventHandler(ToolStripButton3_Click);
            ToolStripSeparator2 = new ToolStripSeparator();
            ToolStripLabel1 = new ToolStripLabel();
            ToolStripTextBox1 = new ToolStripTextBox();
            ToolStripSeparator1 = new ToolStripSeparator();
            ToolStripLabel2 = new ToolStripLabel();
            ToolStripTextBox2 = new ToolStripTextBox();
            ToolStripSeparator3 = new ToolStripSeparator();
            ToolStripLabel3 = new ToolStripLabel();
            ToolStripTextBox3 = new ToolStripTextBox();
            ToolStripSeparator4 = new ToolStripSeparator();
            _ToolStripButton4 = new ToolStripButton();
            _ToolStripButton4.Click += new EventHandler(ToolStripButton4_Click);
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStripSplitButton3 = new ToolStripSplitButton();
            ToolStripStatusLabel15 = new ToolStripStatusLabel();
            ToolStripStatusLabel16 = new ToolStripStatusLabel();
            DataGridView1 = new DataGridView();
            Electioncode = new DataGridViewTextBoxColumn();
            electionname = new DataGridViewTextBoxColumn();
            delegatecode = new DataGridViewTextBoxColumn();
            Delegatename = new DataGridViewTextBoxColumn();
            candidatecode = new DataGridViewTextBoxColumn();
            candidatename = new DataGridViewTextBoxColumn();
            Votes = new DataGridViewTextBoxColumn();
            ToolStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { _ToolStripButton1, _ToolStripButton2, _ToolStripButton3, ToolStripSeparator2, ToolStripLabel1, ToolStripTextBox1, ToolStripSeparator1, ToolStripLabel2, ToolStripTextBox2, ToolStripSeparator3, ToolStripLabel3, ToolStripTextBox3, ToolStripSeparator4, _ToolStripButton4 });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(833, 25);
            ToolStrip1.TabIndex = 12;
            ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton1
            // 
            _ToolStripButton1.Image = My.Resources.Resources.Add;
            _ToolStripButton1.ImageTransparentColor = Color.Magenta;
            _ToolStripButton1.Name = "_ToolStripButton1";
            _ToolStripButton1.Size = new Size(53, 22);
            _ToolStripButton1.Text = "Thêm";
            // 
            // ToolStripButton2
            // 
            _ToolStripButton2.Enabled = false;
            _ToolStripButton2.Image = My.Resources.Resources.Document;
            _ToolStripButton2.ImageTransparentColor = Color.Magenta;
            _ToolStripButton2.Name = "_ToolStripButton2";
            _ToolStripButton2.Size = new Size(46, 22);
            _ToolStripButton2.Text = "Sửa";
            // 
            // ToolStripButton3
            // 
            _ToolStripButton3.Image = My.Resources.Resources.Delete;
            _ToolStripButton3.ImageTransparentColor = Color.Magenta;
            _ToolStripButton3.Name = "_ToolStripButton3";
            _ToolStripButton3.Size = new Size(45, 22);
            _ToolStripButton3.Text = "Xóa";
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripLabel1
            // 
            ToolStripLabel1.Name = "ToolStripLabel1";
            ToolStripLabel1.Size = new Size(57, 22);
            ToolStripLabel1.Text = "Mã bầu cử";
            // 
            // ToolStripTextBox1
            // 
            ToolStripTextBox1.Name = "ToolStripTextBox1";
            ToolStripTextBox1.Size = new Size(100, 25);
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolStripLabel2
            // 
            ToolStripLabel2.Name = "ToolStripLabel2";
            ToolStripLabel2.Size = new Size(61, 22);
            ToolStripLabel2.Text = "Mã đại biểu";
            // 
            // ToolStripTextBox2
            // 
            ToolStripTextBox2.Name = "ToolStripTextBox2";
            ToolStripTextBox2.Size = new Size(100, 25);
            // 
            // ToolStripSeparator3
            // 
            ToolStripSeparator3.Name = "ToolStripSeparator3";
            ToolStripSeparator3.Size = new Size(6, 25);
            // 
            // ToolStripLabel3
            // 
            ToolStripLabel3.Name = "ToolStripLabel3";
            ToolStripLabel3.Size = new Size(76, 22);
            ToolStripLabel3.Text = "Mã ứng viên : ";
            // 
            // ToolStripTextBox3
            // 
            ToolStripTextBox3.Name = "ToolStripTextBox3";
            ToolStripTextBox3.Size = new Size(100, 25);
            // 
            // ToolStripSeparator4
            // 
            ToolStripSeparator4.Name = "ToolStripSeparator4";
            ToolStripSeparator4.Size = new Size(6, 25);
            // 
            // ToolStripButton4
            // 
            _ToolStripButton4.Image = My.Resources.Resources.Search;
            _ToolStripButton4.ImageTransparentColor = Color.Magenta;
            _ToolStripButton4.Name = "_ToolStripButton4";
            _ToolStripButton4.Size = new Size(43, 22);
            _ToolStripButton4.Text = "Tìm";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripSplitButton3, ToolStripStatusLabel15, ToolStripStatusLabel16 });
            StatusStrip1.Location = new Point(0, 497);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(833, 22);
            StatusStrip1.TabIndex = 14;
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
            // ToolStripSplitButton3
            // 
            ToolStripSplitButton3.DisplayStyle = ToolStripItemDisplayStyle.None;
            ToolStripSplitButton3.Image = (Image)resources.GetObject("ToolStripSplitButton3.Image");
            ToolStripSplitButton3.ImageTransparentColor = Color.Magenta;
            ToolStripSplitButton3.Name = "ToolStripSplitButton3";
            ToolStripSplitButton3.Size = new Size(16, 20);
            ToolStripSplitButton3.Text = "ToolStripSplitButton3";
            // 
            // ToolStripStatusLabel15
            // 
            ToolStripStatusLabel15.Name = "ToolStripStatusLabel15";
            ToolStripStatusLabel15.Size = new Size(105, 17);
            ToolStripStatusLabel15.Text = "Tổng số phiếu bầu : ";
            // 
            // ToolStripStatusLabel16
            // 
            ToolStripStatusLabel16.Name = "ToolStripStatusLabel16";
            ToolStripStatusLabel16.Size = new Size(117, 17);
            ToolStripStatusLabel16.Text = "ToolStripStatusLabel16";
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Electioncode, electionname, delegatecode, Delegatename, candidatecode, candidatename, Votes });
            DataGridView1.Dock = DockStyle.Fill;
            DataGridView1.Location = new Point(0, 25);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.Size = new Size(833, 472);
            DataGridView1.TabIndex = 15;
            // 
            // Electioncode
            // 
            Electioncode.DataPropertyName = "Electioncode";
            Electioncode.FillWeight = 59.08628f;
            Electioncode.HeaderText = "Mã bầu cử";
            Electioncode.Name = "Electioncode";
            Electioncode.ReadOnly = true;
            // 
            // electionname
            // 
            electionname.DataPropertyName = "electionname";
            electionname.FillWeight = 59.08628f;
            electionname.HeaderText = "Tên bầu cử";
            electionname.Name = "electionname";
            electionname.ReadOnly = true;
            // 
            // delegatecode
            // 
            delegatecode.DataPropertyName = "delegatecode";
            delegatecode.HeaderText = "Mã đại biểu";
            delegatecode.Name = "delegatecode";
            delegatecode.ReadOnly = true;
            // 
            // Delegatename
            // 
            Delegatename.DataPropertyName = "Delegatename";
            Delegatename.HeaderText = "Tên đại biểu";
            Delegatename.Name = "Delegatename";
            Delegatename.ReadOnly = true;
            // 
            // candidatecode
            // 
            candidatecode.DataPropertyName = "candidatecode";
            DataGridViewCellStyle2.Format = "N0";
            candidatecode.DefaultCellStyle = DataGridViewCellStyle2;
            candidatecode.HeaderText = "Mã ứng viên";
            candidatecode.Name = "candidatecode";
            candidatecode.ReadOnly = true;
            // 
            // candidatename
            // 
            candidatename.DataPropertyName = "candidatename";
            candidatename.HeaderText = "Tên ứng viên";
            candidatename.Name = "candidatename";
            candidatename.ReadOnly = true;
            // 
            // Votes
            // 
            Votes.DataPropertyName = "Votes";
            DataGridViewCellStyle3.Format = "N0";
            Votes.DefaultCellStyle = DataGridViewCellStyle3;
            Votes.HeaderText = "Số phiếu bầu";
            Votes.Name = "Votes";
            Votes.ReadOnly = true;
            // 
            // ElectionVoteList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 519);
            Controls.Add(DataGridView1);
            Controls.Add(StatusStrip1);
            Controls.Add(ToolStrip1);
            Name = "ElectionVoteList";
            Text = "Danh sách phiếu bầu cử";
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            Load += new EventHandler(ElectionVoteList_Load);
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

        internal ToolStripSeparator ToolStripSeparator2;
        internal ToolStripLabel ToolStripLabel1;
        internal ToolStripTextBox ToolStripTextBox1;
        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripLabel ToolStripLabel2;
        internal ToolStripTextBox ToolStripTextBox2;
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
        internal ToolStripSplitButton ToolStripSplitButton3;
        internal ToolStripStatusLabel ToolStripStatusLabel15;
        internal ToolStripStatusLabel ToolStripStatusLabel16;
        internal ToolStripSeparator ToolStripSeparator3;
        internal ToolStripLabel ToolStripLabel3;
        internal ToolStripTextBox ToolStripTextBox3;
        internal ToolStripSeparator ToolStripSeparator4;
        internal DataGridView DataGridView1;
        internal DataGridViewTextBoxColumn Electioncode;
        internal DataGridViewTextBoxColumn electionname;
        internal DataGridViewTextBoxColumn delegatecode;
        internal DataGridViewTextBoxColumn Delegatename;
        internal DataGridViewTextBoxColumn candidatecode;
        internal DataGridViewTextBoxColumn candidatename;
        internal DataGridViewTextBoxColumn Votes;
    }
}