using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class MatterVoteList : Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatterVoteList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this._ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this._ToolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripStatusLabel15 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel16 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip2 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel12 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel13 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel14 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Mattercode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delegatename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voterights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Disagree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Noidea = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DelegateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.StatusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripButton1,
            this._ToolStripButton2,
            this._ToolStripButton3,
            this.ToolStripSeparator2,
            this.ToolStripLabel1,
            this.ToolStripTextBox1,
            this.ToolStripSeparator1,
            this.ToolStripLabel2,
            this.ToolStripTextBox2,
            this._ToolStripButton4});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(852, 27);
            this.ToolStrip1.TabIndex = 11;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // _ToolStripButton1
            // 
            this._ToolStripButton1.Image = global::pmDHCD.My.Resources.Resources.Add;
            this._ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButton1.Name = "_ToolStripButton1";
            this._ToolStripButton1.Size = new System.Drawing.Size(77, 24);
            this._ToolStripButton1.Text = "Thêm(A)";
            this._ToolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // _ToolStripButton2
            // 
            this._ToolStripButton2.Image = global::pmDHCD.My.Resources.Resources.Document;
            this._ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButton2.Name = "_ToolStripButton2";
            this._ToolStripButton2.Size = new System.Drawing.Size(64, 24);
            this._ToolStripButton2.Text = "Sửa(E)";
            this._ToolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // _ToolStripButton3
            // 
            this._ToolStripButton3.Image = global::pmDHCD.My.Resources.Resources.Delete;
            this._ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButton3.Name = "_ToolStripButton3";
            this._ToolStripButton3.Size = new System.Drawing.Size(67, 24);
            this._ToolStripButton3.Text = "Xóa(D)";
            this._ToolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(104, 24);
            this.ToolStripLabel1.Text = "Mã v/đ biểu quyết";
            // 
            // ToolStripTextBox1
            // 
            this.ToolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ToolStripTextBox1.Name = "ToolStripTextBox1";
            this.ToolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // ToolStripLabel2
            // 
            this.ToolStripLabel2.Name = "ToolStripLabel2";
            this.ToolStripLabel2.Size = new System.Drawing.Size(54, 24);
            this.ToolStripLabel2.Text = "CMT/HC";
            // 
            // ToolStripTextBox2
            // 
            this.ToolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ToolStripTextBox2.Name = "ToolStripTextBox2";
            this.ToolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            // 
            // _ToolStripButton4
            // 
            this._ToolStripButton4.Image = global::pmDHCD.My.Resources.Resources.Search;
            this._ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButton4.Name = "_ToolStripButton4";
            this._ToolStripButton4.Size = new System.Drawing.Size(51, 24);
            this._ToolStripButton4.Text = "Tìm";
            this._ToolStripButton4.Click += new System.EventHandler(this.ToolStripButton4_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mattercode,
            this.MatterName,
            this.Delegatename,
            this.IdentityCard,
            this.Voterights,
            this.agree,
            this.Disagree,
            this.Noidea,
            this.DelegateCode,
            this.HolderCode});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 27);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(852, 469);
            this.DataGridView1.TabIndex = 12;
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentDoubleClick);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2,
            this.ToolStripSplitButton3,
            this.ToolStripStatusLabel15,
            this.ToolStripStatusLabel16});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 474);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(852, 22);
            this.StatusStrip1.TabIndex = 13;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(106, 17);
            this.ToolStripStatusLabel1.Text = "Số lượng bản ghi : ";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStripSplitButton3
            // 
            this.ToolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.ToolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripSplitButton3.Image")));
            this.ToolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSplitButton3.Name = "ToolStripSplitButton3";
            this.ToolStripSplitButton3.Size = new System.Drawing.Size(16, 20);
            this.ToolStripSplitButton3.Text = "ToolStripSplitButton3";
            // 
            // ToolStripStatusLabel15
            // 
            this.ToolStripStatusLabel15.Name = "ToolStripStatusLabel15";
            this.ToolStripStatusLabel15.Size = new System.Drawing.Size(153, 17);
            this.ToolStripStatusLabel15.Text = "Tổng số quyền biểu quyết : ";
            // 
            // ToolStripStatusLabel16
            // 
            this.ToolStripStatusLabel16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel16.Name = "ToolStripStatusLabel16";
            this.ToolStripStatusLabel16.Size = new System.Drawing.Size(133, 17);
            this.ToolStripStatusLabel16.Text = "ToolStripStatusLabel16";
            // 
            // StatusStrip2
            // 
            this.StatusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel3,
            this.ToolStripStatusLabel4,
            this.ToolStripStatusLabel5,
            this.ToolStripStatusLabel6,
            this.ToolStripSplitButton1,
            this.ToolStripStatusLabel7,
            this.ToolStripStatusLabel8,
            this.ToolStripStatusLabel9,
            this.ToolStripStatusLabel10,
            this.ToolStripSplitButton2,
            this.ToolStripStatusLabel11,
            this.ToolStripStatusLabel12,
            this.ToolStripStatusLabel13,
            this.ToolStripStatusLabel14});
            this.StatusStrip2.Location = new System.Drawing.Point(0, 452);
            this.StatusStrip2.Name = "StatusStrip2";
            this.StatusStrip2.Size = new System.Drawing.Size(852, 22);
            this.StatusStrip2.TabIndex = 14;
            this.StatusStrip2.Text = "StatusStrip2";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(58, 17);
            this.ToolStripStatusLabel3.Text = "Đồng ý : ";
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStripStatusLabel5
            // 
            this.ToolStripStatusLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            this.ToolStripStatusLabel5.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStripStatusLabel6
            // 
            this.ToolStripStatusLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            this.ToolStripStatusLabel6.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStripSplitButton1
            // 
            this.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.ToolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripSplitButton1.Image")));
            this.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSplitButton1.Name = "ToolStripSplitButton1";
            this.ToolStripSplitButton1.Size = new System.Drawing.Size(16, 20);
            this.ToolStripSplitButton1.Text = "ToolStripSplitButton1";
            // 
            // ToolStripStatusLabel7
            // 
            this.ToolStripStatusLabel7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7";
            this.ToolStripStatusLabel7.Size = new System.Drawing.Size(96, 17);
            this.ToolStripStatusLabel7.Text = "Không đồng ý : ";
            // 
            // ToolStripStatusLabel8
            // 
            this.ToolStripStatusLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8";
            this.ToolStripStatusLabel8.Size = new System.Drawing.Size(126, 17);
            this.ToolStripStatusLabel8.Text = "ToolStripStatusLabel8";
            // 
            // ToolStripStatusLabel9
            // 
            this.ToolStripStatusLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9";
            this.ToolStripStatusLabel9.Size = new System.Drawing.Size(126, 17);
            this.ToolStripStatusLabel9.Text = "ToolStripStatusLabel9";
            // 
            // ToolStripStatusLabel10
            // 
            this.ToolStripStatusLabel10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel10.Name = "ToolStripStatusLabel10";
            this.ToolStripStatusLabel10.Size = new System.Drawing.Size(133, 17);
            this.ToolStripStatusLabel10.Text = "ToolStripStatusLabel10";
            // 
            // ToolStripSplitButton2
            // 
            this.ToolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.ToolStripSplitButton2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripSplitButton2.Image")));
            this.ToolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSplitButton2.Name = "ToolStripSplitButton2";
            this.ToolStripSplitButton2.Size = new System.Drawing.Size(16, 20);
            this.ToolStripSplitButton2.Text = "ToolStripSplitButton2";
            // 
            // ToolStripStatusLabel11
            // 
            this.ToolStripStatusLabel11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11";
            this.ToolStripStatusLabel11.Size = new System.Drawing.Size(90, 17);
            this.ToolStripStatusLabel11.Text = "Không ý kiến : ";
            // 
            // ToolStripStatusLabel12
            // 
            this.ToolStripStatusLabel12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel12.Name = "ToolStripStatusLabel12";
            this.ToolStripStatusLabel12.Size = new System.Drawing.Size(133, 17);
            this.ToolStripStatusLabel12.Text = "ToolStripStatusLabel12";
            // 
            // ToolStripStatusLabel13
            // 
            this.ToolStripStatusLabel13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel13.Name = "ToolStripStatusLabel13";
            this.ToolStripStatusLabel13.Size = new System.Drawing.Size(31, 17);
            this.ToolStripStatusLabel13.Text = "Tool";
            // 
            // ToolStripStatusLabel14
            // 
            this.ToolStripStatusLabel14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel14.Name = "ToolStripStatusLabel14";
            this.ToolStripStatusLabel14.Size = new System.Drawing.Size(133, 17);
            this.ToolStripStatusLabel14.Text = "ToolStripStatusLabel14";
            // 
            // Mattercode
            // 
            this.Mattercode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Mattercode.DataPropertyName = "Mattercode";
            this.Mattercode.FillWeight = 59.08628F;
            this.Mattercode.Frozen = true;
            this.Mattercode.HeaderText = "Mã vấn đề";
            this.Mattercode.Name = "Mattercode";
            this.Mattercode.ReadOnly = true;
            this.Mattercode.Width = 70;
            // 
            // MatterName
            // 
            this.MatterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MatterName.DataPropertyName = "MatterName";
            this.MatterName.FillWeight = 59.08628F;
            this.MatterName.Frozen = true;
            this.MatterName.HeaderText = "Tên vấn đề";
            this.MatterName.Name = "MatterName";
            this.MatterName.ReadOnly = true;
            this.MatterName.Width = 150;
            // 
            // Delegatename
            // 
            this.Delegatename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delegatename.DataPropertyName = "Delegatename";
            this.Delegatename.HeaderText = "Cổ đông/Người đại diện";
            this.Delegatename.Name = "Delegatename";
            this.Delegatename.ReadOnly = true;
            this.Delegatename.Width = 150;
            // 
            // IdentityCard
            // 
            this.IdentityCard.DataPropertyName = "IdentityCard";
            this.IdentityCard.HeaderText = "CMT/HC";
            this.IdentityCard.Name = "IdentityCard";
            this.IdentityCard.ReadOnly = true;
            // 
            // Voterights
            // 
            this.Voterights.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Voterights.DataPropertyName = "Voterights";
            dataGridViewCellStyle3.Format = "N0";
            this.Voterights.DefaultCellStyle = dataGridViewCellStyle3;
            this.Voterights.HeaderText = "Số quyền biểu quyết";
            this.Voterights.Name = "Voterights";
            this.Voterights.ReadOnly = true;
            // 
            // agree
            // 
            this.agree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.agree.DataPropertyName = "agree";
            this.agree.FillWeight = 59.08628F;
            this.agree.HeaderText = "Đồng ý";
            this.agree.Name = "agree";
            this.agree.ReadOnly = true;
            this.agree.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.agree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.agree.Width = 70;
            // 
            // Disagree
            // 
            this.Disagree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Disagree.DataPropertyName = "Disagree";
            this.Disagree.HeaderText = "Không đồng ý";
            this.Disagree.Name = "Disagree";
            this.Disagree.ReadOnly = true;
            this.Disagree.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Disagree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Disagree.Width = 70;
            // 
            // Noidea
            // 
            this.Noidea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Noidea.DataPropertyName = "Noidea";
            this.Noidea.HeaderText = "Không ý kiến";
            this.Noidea.Name = "Noidea";
            this.Noidea.ReadOnly = true;
            this.Noidea.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Noidea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Noidea.Width = 70;
            // 
            // DelegateCode
            // 
            this.DelegateCode.DataPropertyName = "DelegateCode";
            this.DelegateCode.HeaderText = "DelegateCode";
            this.DelegateCode.Name = "DelegateCode";
            this.DelegateCode.ReadOnly = true;
            this.DelegateCode.Visible = false;
            // 
            // HolderCode
            // 
            this.HolderCode.DataPropertyName = "HolderCode";
            this.HolderCode.HeaderText = "HolderCode";
            this.HolderCode.Name = "HolderCode";
            this.HolderCode.ReadOnly = true;
            this.HolderCode.Visible = false;
            // 
            // MatterVoteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 496);
            this.Controls.Add(this.StatusStrip2);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.ToolStrip1);
            this.KeyPreview = true;
            this.Name = "MatterVoteList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phiếu biểu quyết";
            this.Load += new System.EventHandler(this.MatterVoteList_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MatterVoteList_KeyUp);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.StatusStrip2.ResumeLayout(false);
            this.StatusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        internal DataGridView DataGridView1;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripLabel ToolStripLabel2;
        internal ToolStripTextBox ToolStripTextBox2;
        internal StatusStrip StatusStrip2;
        internal ToolStripStatusLabel ToolStripStatusLabel3;
        internal ToolStripStatusLabel ToolStripStatusLabel4;
        internal ToolStripStatusLabel ToolStripStatusLabel5;
        internal ToolStripStatusLabel ToolStripStatusLabel6;
        internal ToolStripSplitButton ToolStripSplitButton1;
        internal ToolStripStatusLabel ToolStripStatusLabel7;
        internal ToolStripSplitButton ToolStripSplitButton3;
        internal ToolStripStatusLabel ToolStripStatusLabel15;
        internal ToolStripStatusLabel ToolStripStatusLabel16;
        internal ToolStripStatusLabel ToolStripStatusLabel8;
        internal ToolStripStatusLabel ToolStripStatusLabel9;
        internal ToolStripStatusLabel ToolStripStatusLabel10;
        internal ToolStripSplitButton ToolStripSplitButton2;
        internal ToolStripStatusLabel ToolStripStatusLabel11;
        internal ToolStripStatusLabel ToolStripStatusLabel12;
        internal ToolStripStatusLabel ToolStripStatusLabel13;
        internal ToolStripStatusLabel ToolStripStatusLabel14;
        private DataGridViewTextBoxColumn Mattercode;
        private DataGridViewTextBoxColumn MatterName;
        private DataGridViewTextBoxColumn Delegatename;
        private DataGridViewTextBoxColumn IdentityCard;
        private DataGridViewTextBoxColumn Voterights;
        private DataGridViewCheckBoxColumn agree;
        private DataGridViewCheckBoxColumn Disagree;
        private DataGridViewCheckBoxColumn Noidea;
        private DataGridViewTextBoxColumn DelegateCode;
        private DataGridViewTextBoxColumn HolderCode;
    }
}