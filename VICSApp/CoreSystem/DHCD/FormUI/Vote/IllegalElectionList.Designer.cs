using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class IllegalElectionList : Form
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
            var DataGridViewCellStyle9 = new DataGridViewCellStyle();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(IllegalElectionList));
            var DataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridView1 = new DataGridView();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStripSplitButton3 = new ToolStripSplitButton();
            ToolStripStatusLabel15 = new ToolStripStatusLabel();
            ToolStripStatusLabel16 = new ToolStripStatusLabel();
            ToolStrip1 = new ToolStrip();
            ToolStripButton1 = new ToolStripButton();
            ToolStripButton2 = new ToolStripButton();
            _ToolStripButton3 = new ToolStripButton();
            _ToolStripButton3.Click += new EventHandler(ToolStripButton3_Click);
            ToolStripSeparator2 = new ToolStripSeparator();
            ToolStripLabel1 = new ToolStripLabel();
            ToolStripSeparator4 = new ToolStripSeparator();
            _ToolStripButton4 = new ToolStripButton();
            _ToolStripButton4.Click += new EventHandler(ToolStripButton4_Click);
            ToolStripSeparator1 = new ToolStripSeparator();
            ToolStripTextBox2 = new ToolStripTextBox();
            ToolStripLabel2 = new ToolStripLabel();
            Electioncode = new DataGridViewTextBoxColumn();
            electionname = new DataGridViewTextBoxColumn();
            delegatecode = new DataGridViewTextBoxColumn();
            Delegatename = new DataGridViewTextBoxColumn();
            Votes = new DataGridViewTextBoxColumn();
            ToolStripTextBox1 = new ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            StatusStrip1.SuspendLayout();
            ToolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle9.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Electioncode, electionname, delegatecode, Delegatename, Votes });
            DataGridView1.Dock = DockStyle.Fill;
            DataGridView1.Location = new Point(0, 25);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.Size = new Size(885, 498);
            DataGridView1.TabIndex = 18;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripSplitButton3, ToolStripStatusLabel15, ToolStripStatusLabel16 });
            StatusStrip1.Location = new Point(0, 523);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(885, 22);
            StatusStrip1.TabIndex = 17;
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
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { ToolStripButton1, ToolStripButton2, _ToolStripButton3, ToolStripSeparator2, ToolStripLabel1, ToolStripTextBox1, ToolStripSeparator1, ToolStripLabel2, ToolStripTextBox2, ToolStripSeparator4, _ToolStripButton4 });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(885, 25);
            ToolStrip1.TabIndex = 16;
            ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton1
            // 
            ToolStripButton1.Image = My.Resources.Resources.Add;
            ToolStripButton1.ImageTransparentColor = Color.Magenta;
            ToolStripButton1.Name = "ToolStripButton1";
            ToolStripButton1.Size = new Size(53, 22);
            ToolStripButton1.Text = "Thêm";
            // 
            // ToolStripButton2
            // 
            ToolStripButton2.Enabled = false;
            ToolStripButton2.Image = My.Resources.Resources.Document;
            ToolStripButton2.ImageTransparentColor = Color.Magenta;
            ToolStripButton2.Name = "ToolStripButton2";
            ToolStripButton2.Size = new Size(46, 22);
            ToolStripButton2.Text = "Sửa";
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
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolStripTextBox2
            // 
            ToolStripTextBox2.Name = "ToolStripTextBox2";
            ToolStripTextBox2.Size = new Size(100, 25);
            // 
            // ToolStripLabel2
            // 
            ToolStripLabel2.Name = "ToolStripLabel2";
            ToolStripLabel2.Size = new Size(61, 22);
            ToolStripLabel2.Text = "Mã đại biểu";
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
            // Votes
            // 
            Votes.DataPropertyName = "Votes";
            DataGridViewCellStyle10.Format = "N0";
            Votes.DefaultCellStyle = DataGridViewCellStyle10;
            Votes.HeaderText = "Số phiếu bầu";
            Votes.Name = "Votes";
            Votes.ReadOnly = true;
            // 
            // ToolStripTextBox1
            // 
            ToolStripTextBox1.Name = "ToolStripTextBox1";
            ToolStripTextBox1.Size = new Size(100, 25);
            // 
            // IllegalElectionList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 545);
            Controls.Add(DataGridView1);
            Controls.Add(StatusStrip1);
            Controls.Add(ToolStrip1);
            Name = "IllegalElectionList";
            Text = "Danh sách phiếu bầu cử KHÔNG hợp lệ";
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            Load += new EventHandler(IllegalElectionList_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal DataGridView DataGridView1;
        internal DataGridViewTextBoxColumn Electioncode;
        internal DataGridViewTextBoxColumn electionname;
        internal DataGridViewTextBoxColumn delegatecode;
        internal DataGridViewTextBoxColumn Delegatename;
        internal DataGridViewTextBoxColumn Votes;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        internal ToolStripSplitButton ToolStripSplitButton3;
        internal ToolStripStatusLabel ToolStripStatusLabel15;
        internal ToolStripStatusLabel ToolStripStatusLabel16;
        internal ToolStrip ToolStrip1;
        internal ToolStripButton ToolStripButton1;
        internal ToolStripButton ToolStripButton2;
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
        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripLabel ToolStripLabel2;
        internal ToolStripTextBox ToolStripTextBox2;
        internal ToolStripSeparator ToolStripSeparator4;
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

        internal ToolStripTextBox ToolStripTextBox1;
    }
}