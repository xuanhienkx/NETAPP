using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class CandidateList : Form
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
            DataGridView1 = new DataGridView();
            electioncode = new DataGridViewTextBoxColumn();
            electionName = new DataGridViewTextBoxColumn();
            candidatecode = new DataGridViewTextBoxColumn();
            candidatename = new DataGridViewTextBoxColumn();
            candidateaddress = new DataGridViewTextBoxColumn();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStrip1 = new ToolStrip();
            _ToolStripButton1 = new ToolStripButton();
            _ToolStripButton1.Click += new EventHandler(ToolStripButton1_Click);
            _ToolStripButton2 = new ToolStripButton();
            _ToolStripButton2.Click += new EventHandler(ToolStripButton2_Click);
            _ToolStripButton3 = new ToolStripButton();
            _ToolStripButton3.Click += new EventHandler(ToolStripButton3_Click);
            ToolStripSeparator2 = new ToolStripSeparator();
            ToolStripLabel1 = new ToolStripLabel();
            _ToolStripButton4 = new ToolStripButton();
            _ToolStripButton4.Click += new EventHandler(ToolStripButton4_Click);
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            StatusStrip1.SuspendLayout();
            ToolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { electioncode, electionName, candidatecode, candidatename, candidateaddress });
            DataGridView1.Location = new Point(0, 28);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.Size = new Size(839, 424);
            DataGridView1.TabIndex = 8;
            // 
            // electioncode
            // 
            electioncode.DataPropertyName = "electioncode";
            electioncode.FillWeight = 59.08628f;
            electioncode.HeaderText = "Mã bầu cử";
            electioncode.Name = "electioncode";
            electioncode.ReadOnly = true;
            // 
            // electionName
            // 
            electionName.DataPropertyName = "electionName";
            electionName.FillWeight = 59.08628f;
            electionName.HeaderText = "Tên bầu cử";
            electionName.Name = "electionName";
            electionName.ReadOnly = true;
            // 
            // candidatecode
            // 
            candidatecode.DataPropertyName = "candidatecode";
            candidatecode.FillWeight = 59.08628f;
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
            // candidateaddress
            // 
            candidateaddress.DataPropertyName = "candidateaddress";
            candidateaddress.HeaderText = "Địa chỉ";
            candidateaddress.Name = "candidateaddress";
            candidateaddress.ReadOnly = true;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2 });
            StatusStrip1.Location = new Point(0, 455);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(839, 22);
            StatusStrip1.TabIndex = 9;
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
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { _ToolStripButton1, _ToolStripButton2, _ToolStripButton3, ToolStripSeparator2, ToolStripLabel1, _ToolStripButton4 });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(839, 25);
            ToolStrip1.TabIndex = 10;
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
            // ToolStripButton4
            // 
            _ToolStripButton4.Image = My.Resources.Resources.Search;
            _ToolStripButton4.ImageTransparentColor = Color.Magenta;
            _ToolStripButton4.Name = "_ToolStripButton4";
            _ToolStripButton4.Size = new Size(43, 22);
            _ToolStripButton4.Text = "Tìm";
            // 
            // CandidateList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 477);
            Controls.Add(ToolStrip1);
            Controls.Add(StatusStrip1);
            Controls.Add(DataGridView1);
            Name = "CandidateList";
            Text = "Danh sách ứng viên bầu cử";
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            Load += new EventHandler(CandidateList_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal DataGridView DataGridView1;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
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

        internal DataGridViewTextBoxColumn electioncode;
        internal DataGridViewTextBoxColumn electionName;
        internal DataGridViewTextBoxColumn candidatecode;
        internal DataGridViewTextBoxColumn candidatename;
        internal DataGridViewTextBoxColumn candidateaddress;
        internal ToolStripLabel ToolStripLabel1;
    }
}