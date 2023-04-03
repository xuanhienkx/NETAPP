using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class Elections_result : Form
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
            var DataGridViewCellStyle4 = new DataGridViewCellStyle();
            var DataGridViewCellStyle5 = new DataGridViewCellStyle();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Elections_result));
            GroupBox1 = new GroupBox();
            _NumericUpDown1 = new NumericUpDown();
            _NumericUpDown1.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
            MaskedTextBox6 = new MaskedTextBox();
            MaskedTextBox3 = new MaskedTextBox();
            Label8 = new Label();
            Label7 = new Label();
            Label2 = new Label();
            GroupBox2 = new GroupBox();
            DataGridView1 = new DataGridView();
            Candidatecode = new DataGridViewTextBoxColumn();
            CandidateName = new DataGridViewTextBoxColumn();
            Votes = new DataGridViewTextBoxColumn();
            percentvote = new DataGridViewTextBoxColumn();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStripSplitButton1 = new ToolStripSplitButton();
            ToolStripStatusLabel5 = new ToolStripStatusLabel();
            ToolStripStatusLabel6 = new ToolStripStatusLabel();
            ToolStripSplitButton2 = new ToolStripSplitButton();
            ToolStripStatusLabel3 = new ToolStripStatusLabel();
            ToolStripStatusLabel4 = new ToolStripStatusLabel();
            StatusStrip2 = new StatusStrip();
            ToolStripStatusLabel7 = new ToolStripStatusLabel();
            ToolStripStatusLabel8 = new ToolStripStatusLabel();
            ToolStripStatusLabel9 = new ToolStripStatusLabel();
            ToolStripSplitButton3 = new ToolStripSplitButton();
            ToolStripStatusLabel10 = new ToolStripStatusLabel();
            ToolStripStatusLabel11 = new ToolStripStatusLabel();
            ToolStripStatusLabel12 = new ToolStripStatusLabel();
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).BeginInit();
            GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            StatusStrip1.SuspendLayout();
            StatusStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(_NumericUpDown1);
            GroupBox1.Controls.Add(MaskedTextBox6);
            GroupBox1.Controls.Add(MaskedTextBox3);
            GroupBox1.Controls.Add(Label8);
            GroupBox1.Controls.Add(Label7);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Location = new Point(1, 2);
            GroupBox1.Margin = new Padding(4, 4, 4, 4);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(4, 4, 4, 4);
            GroupBox1.Size = new Size(1039, 165);
            GroupBox1.TabIndex = 57;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Vấn đề bầu cử";
            // 
            // NumericUpDown1
            // 
            _NumericUpDown1.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _NumericUpDown1.Location = new Point(217, 16);
            _NumericUpDown1.Margin = new Padding(4, 4, 4, 4);
            _NumericUpDown1.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            _NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _NumericUpDown1.Name = "_NumericUpDown1";
            _NumericUpDown1.Size = new Size(81, 29);
            _NumericUpDown1.TabIndex = 0;
            _NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MaskedTextBox6
            // 
            MaskedTextBox6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox6.Location = new Point(217, 108);
            MaskedTextBox6.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox6.Name = "MaskedTextBox6";
            MaskedTextBox6.ReadOnly = true;
            MaskedTextBox6.Size = new Size(265, 26);
            MaskedTextBox6.TabIndex = 23;
            // 
            // MaskedTextBox3
            // 
            MaskedTextBox3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            MaskedTextBox3.Location = new Point(217, 64);
            MaskedTextBox3.Margin = new Padding(4, 4, 4, 4);
            MaskedTextBox3.Name = "MaskedTextBox3";
            MaskedTextBox3.ReadOnly = true;
            MaskedTextBox3.Size = new Size(635, 26);
            MaskedTextBox3.TabIndex = 23;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label8.Location = new Point(13, 116);
            Label8.Margin = new Padding(4, 0, 4, 0);
            Label8.Name = "Label8";
            Label8.Size = new Size(169, 20);
            Label8.TabIndex = 27;
            Label8.Text = "Số ứng viên được bầu";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(15, 64);
            Label7.Margin = new Padding(4, 0, 4, 0);
            Label7.Name = "Label7";
            Label7.Size = new Size(92, 20);
            Label7.TabIndex = 27;
            Label7.Text = "Tên bầu cử";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.Location = new Point(15, 22);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(87, 20);
            Label2.TabIndex = 26;
            Label2.Text = "Mã bầu cử";
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(DataGridView1);
            GroupBox2.Location = new Point(1, 176);
            GroupBox2.Margin = new Padding(4, 4, 4, 4);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Padding = new Padding(4, 4, 4, 4);
            GroupBox2.Size = new Size(1039, 460);
            GroupBox2.TabIndex = 58;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Kết quả";
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Candidatecode, CandidateName, Votes, percentvote });
            DataGridView1.Dock = DockStyle.Fill;
            DataGridView1.Location = new Point(4, 19);
            DataGridView1.Margin = new Padding(4, 4, 4, 4);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.Size = new Size(1031, 437);
            DataGridView1.TabIndex = 14;
            // 
            // Candidatecode
            // 
            Candidatecode.DataPropertyName = "Candidatecode";
            DataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Candidatecode.DefaultCellStyle = DataGridViewCellStyle2;
            Candidatecode.FillWeight = 59.08628f;
            Candidatecode.HeaderText = "Mã ứng viên";
            Candidatecode.Name = "Candidatecode";
            Candidatecode.ReadOnly = true;
            // 
            // CandidateName
            // 
            CandidateName.DataPropertyName = "CandidateName";
            DataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            CandidateName.DefaultCellStyle = DataGridViewCellStyle3;
            CandidateName.FillWeight = 59.08628f;
            CandidateName.HeaderText = "Tên ứng viên";
            CandidateName.Name = "CandidateName";
            CandidateName.ReadOnly = true;
            // 
            // Votes
            // 
            Votes.DataPropertyName = "sumVotes";
            DataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle4.Format = "N0";
            Votes.DefaultCellStyle = DataGridViewCellStyle4;
            Votes.HeaderText = "Số phiếu bầu";
            Votes.Name = "Votes";
            Votes.ReadOnly = true;
            // 
            // percentvote
            // 
            percentvote.DataPropertyName = "percentvote";
            DataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle5.Format = "n2";
            percentvote.DefaultCellStyle = DataGridViewCellStyle5;
            percentvote.HeaderText = "Tỷ lệ (%)";
            percentvote.Name = "percentvote";
            percentvote.ReadOnly = true;
            // 
            // StatusStrip1
            // 
            StatusStrip1.ImageScalingSize = new Size(20, 20);
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripSplitButton1, ToolStripStatusLabel5, ToolStripStatusLabel6, ToolStripSplitButton2, ToolStripStatusLabel3, ToolStripStatusLabel4 });
            StatusStrip1.Location = new Point(0, 670);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Padding = new Padding(1, 0, 19, 0);
            StatusStrip1.Size = new Size(1056, 25);
            StatusStrip1.TabIndex = 59;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Font = new Font("Tahoma", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(131, 20);
            ToolStripStatusLabel1.Text = "Số lượng bản ghi : ";
            // 
            // ToolStripStatusLabel2
            // 
            ToolStripStatusLabel2.Font = new Font("Tahoma", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            ToolStripStatusLabel2.Size = new Size(0, 20);
            // 
            // ToolStripSplitButton1
            // 
            ToolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.None;
            ToolStripSplitButton1.Name = "ToolStripSplitButton1";
            ToolStripSplitButton1.Size = new Size(19, 23);
            ToolStripSplitButton1.Text = "ToolStripSplitButton1";
            // 
            // ToolStripStatusLabel5
            // 
            ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            ToolStripStatusLabel5.Size = new Size(124, 20);
            ToolStripStatusLabel5.Text = "Số phiếu hợp lệ : ";
            // 
            // ToolStripStatusLabel6
            // 
            ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            ToolStripStatusLabel6.Size = new Size(153, 20);
            ToolStripStatusLabel6.Text = "ToolStripStatusLabel6";
            // 
            // ToolStripSplitButton2
            // 
            ToolStripSplitButton2.DisplayStyle = ToolStripItemDisplayStyle.None;
            ToolStripSplitButton2.Name = "ToolStripSplitButton2";
            ToolStripSplitButton2.Size = new Size(19, 23);
            ToolStripSplitButton2.Text = "ToolStripSplitButton2";
            // 
            // ToolStripStatusLabel3
            // 
            ToolStripStatusLabel3.Font = new Font("Tahoma", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            ToolStripStatusLabel3.Size = new Size(145, 20);
            ToolStripStatusLabel3.Text = "Tổng số phiếu bầu : ";
            // 
            // ToolStripStatusLabel4
            // 
            ToolStripStatusLabel4.Font = new Font("Tahoma", 9.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            ToolStripStatusLabel4.Size = new Size(146, 20);
            ToolStripStatusLabel4.Text = "ToolStripStatusLabel4";
            // 
            // StatusStrip2
            // 
            StatusStrip2.ImageScalingSize = new Size(20, 20);
            StatusStrip2.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel7, ToolStripStatusLabel8, ToolStripStatusLabel9, ToolStripSplitButton3, ToolStripStatusLabel10, ToolStripStatusLabel11, ToolStripStatusLabel12 });
            StatusStrip2.Location = new Point(0, 645);
            StatusStrip2.Name = "StatusStrip2";
            StatusStrip2.Padding = new Padding(1, 0, 19, 0);
            StatusStrip2.Size = new Size(1056, 25);
            StatusStrip2.TabIndex = 60;
            StatusStrip2.Text = "StatusStrip2";
            // 
            // ToolStripStatusLabel7
            // 
            ToolStripStatusLabel7.Name = "ToolStripStatusLabel7";
            ToolStripStatusLabel7.Size = new Size(124, 20);
            ToolStripStatusLabel7.Text = "Số phiếu hợp lệ : ";
            // 
            // ToolStripStatusLabel8
            // 
            ToolStripStatusLabel8.Name = "ToolStripStatusLabel8";
            ToolStripStatusLabel8.Size = new Size(153, 20);
            ToolStripStatusLabel8.Text = "ToolStripStatusLabel8";
            // 
            // ToolStripStatusLabel9
            // 
            ToolStripStatusLabel9.Name = "ToolStripStatusLabel9";
            ToolStripStatusLabel9.Size = new Size(153, 20);
            ToolStripStatusLabel9.Text = "ToolStripStatusLabel9";
            // 
            // ToolStripSplitButton3
            // 
            ToolStripSplitButton3.DisplayStyle = ToolStripItemDisplayStyle.None;
            ToolStripSplitButton3.Image = (Image)resources.GetObject("ToolStripSplitButton3.Image");
            ToolStripSplitButton3.ImageTransparentColor = Color.Magenta;
            ToolStripSplitButton3.Name = "ToolStripSplitButton3";
            ToolStripSplitButton3.Size = new Size(19, 23);
            ToolStripSplitButton3.Text = "ToolStripSplitButton3";
            // 
            // ToolStripStatusLabel10
            // 
            ToolStripStatusLabel10.Name = "ToolStripStatusLabel10";
            ToolStripStatusLabel10.Size = new Size(169, 20);
            ToolStripStatusLabel10.Text = "Số phiếu không hợp lệ : ";
            // 
            // ToolStripStatusLabel11
            // 
            ToolStripStatusLabel11.Name = "ToolStripStatusLabel11";
            ToolStripStatusLabel11.Size = new Size(161, 20);
            ToolStripStatusLabel11.Text = "ToolStripStatusLabel11";
            // 
            // ToolStripStatusLabel12
            // 
            ToolStripStatusLabel12.Name = "ToolStripStatusLabel12";
            ToolStripStatusLabel12.Size = new Size(161, 20);
            ToolStripStatusLabel12.Text = "ToolStripStatusLabel12";
            // 
            // Elections_result
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 695);
            Controls.Add(StatusStrip2);
            Controls.Add(StatusStrip1);
            Controls.Add(GroupBox2);
            Controls.Add(GroupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Elections_result";
            Text = "Kết quả bầu cử";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericUpDown1).EndInit();
            GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            StatusStrip2.ResumeLayout(false);
            StatusStrip2.PerformLayout();
            Load += new EventHandler(Elections_result_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal GroupBox GroupBox1;
        private NumericUpDown _NumericUpDown1;

        internal NumericUpDown NumericUpDown1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericUpDown1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericUpDown1 != null)
                {
                    _NumericUpDown1.ValueChanged -= NumericUpDown1_ValueChanged;
                }

                _NumericUpDown1 = value;
                if (_NumericUpDown1 != null)
                {
                    _NumericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
                }
            }
        }

        internal MaskedTextBox MaskedTextBox6;
        internal MaskedTextBox MaskedTextBox3;
        internal Label Label8;
        internal Label Label7;
        internal Label Label2;
        internal GroupBox GroupBox2;
        internal DataGridView DataGridView1;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        internal ToolStripStatusLabel ToolStripStatusLabel3;
        internal ToolStripStatusLabel ToolStripStatusLabel4;
        internal ToolStripSplitButton ToolStripSplitButton1;
        internal ToolStripStatusLabel ToolStripStatusLabel5;
        internal ToolStripStatusLabel ToolStripStatusLabel6;
        internal ToolStripSplitButton ToolStripSplitButton2;
        internal StatusStrip StatusStrip2;
        internal ToolStripStatusLabel ToolStripStatusLabel7;
        internal ToolStripStatusLabel ToolStripStatusLabel8;
        internal ToolStripStatusLabel ToolStripStatusLabel9;
        internal ToolStripSplitButton ToolStripSplitButton3;
        internal ToolStripStatusLabel ToolStripStatusLabel10;
        internal ToolStripStatusLabel ToolStripStatusLabel11;
        internal ToolStripStatusLabel ToolStripStatusLabel12;
        internal DataGridViewTextBoxColumn Candidatecode;
        internal DataGridViewTextBoxColumn CandidateName;
        internal DataGridViewTextBoxColumn Votes;
        internal DataGridViewTextBoxColumn percentvote;
    }
}