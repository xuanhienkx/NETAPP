using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class ElectionList : Form
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
            ToolStrip1 = new ToolStrip();
            _ToolStripButton1 = new ToolStripButton();
            _ToolStripButton1.Click += new EventHandler(ToolStripButton1_Click);
            _ToolStripButton2 = new ToolStripButton();
            _ToolStripButton2.Click += new EventHandler(ToolStripButton2_Click);
            _ToolStripButton3 = new ToolStripButton();
            _ToolStripButton3.Click += new EventHandler(ToolStripButton3_Click);
            ToolStripSeparator2 = new ToolStripSeparator();
            DataGridView1 = new DataGridView();
            electioncode = new DataGridViewTextBoxColumn();
            electionName = new DataGridViewTextBoxColumn();
            electiondescription = new DataGridViewTextBoxColumn();
            numofregisted = new DataGridViewTextBoxColumn();
            numofcandidates = new DataGridViewTextBoxColumn();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { _ToolStripButton1, _ToolStripButton2, _ToolStripButton3, ToolStripSeparator2 });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(808, 25);
            ToolStrip1.TabIndex = 4;
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
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { electioncode, electionName, electiondescription, numofregisted, numofcandidates });
            DataGridView1.Dock = DockStyle.Fill;
            DataGridView1.Location = new Point(0, 25);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.Size = new Size(808, 381);
            DataGridView1.TabIndex = 7;
            // 
            // electioncode
            // 
            electioncode.DataPropertyName = "electioncode";
            electioncode.FillWeight = 59.08628f;
            electioncode.HeaderText = "Mã vấn đề";
            electioncode.Name = "electioncode";
            electioncode.ReadOnly = true;
            // 
            // electionName
            // 
            electionName.DataPropertyName = "electionName";
            electionName.FillWeight = 59.08628f;
            electionName.HeaderText = "Tên vấn đề";
            electionName.Name = "electionName";
            electionName.ReadOnly = true;
            // 
            // electiondescription
            // 
            electiondescription.DataPropertyName = "electiondescription";
            electiondescription.FillWeight = 59.08628f;
            electiondescription.HeaderText = "Diễn giải";
            electiondescription.Name = "electiondescription";
            electiondescription.ReadOnly = true;
            // 
            // numofregisted
            // 
            numofregisted.DataPropertyName = "numofregisted";
            numofregisted.HeaderText = "Số ứng viên đăng ký";
            numofregisted.Name = "numofregisted";
            numofregisted.ReadOnly = true;
            // 
            // numofcandidates
            // 
            numofcandidates.DataPropertyName = "numofcandidates";
            numofcandidates.HeaderText = "Số lượng được bầu";
            numofcandidates.Name = "numofcandidates";
            numofcandidates.ReadOnly = true;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2 });
            StatusStrip1.Location = new Point(0, 384);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(808, 22);
            StatusStrip1.TabIndex = 8;
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
            // ElectionList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 406);
            Controls.Add(StatusStrip1);
            Controls.Add(DataGridView1);
            Controls.Add(ToolStrip1);
            Name = "ElectionList";
            Text = "Danh sách vấn đề bầu cử";
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            Load += new EventHandler(ElectionList_Load);
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
        internal DataGridView DataGridView1;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        internal DataGridViewTextBoxColumn electioncode;
        internal DataGridViewTextBoxColumn electionName;
        internal DataGridViewTextBoxColumn electiondescription;
        internal DataGridViewTextBoxColumn numofregisted;
        internal DataGridViewTextBoxColumn numofcandidates;
    }
}