using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class DelegateList : Form
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
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this._ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this._ToolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this._ToolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this._ToolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this._InPhieuBauBKS = new System.Windows.Forms.ToolStripButton();
            this._InPhieuBauHDQT = new System.Windows.Forms.ToolStripButton();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Delegatecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delegatename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelegateAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voterights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripButton1,
            this._ToolStripButton2,
            this._ToolStripButton3,
            this.ToolStripSeparator1,
            this.ToolStripLabel1,
            this._ToolStripTextBox1,
            this.ToolStripSeparator2,
            this.ToolStripLabel2,
            this._ToolStripTextBox2,
            this._ToolStripButton4,
            this.ToolStripSeparator3,
            this._ToolStripButton5,
            this._ToolStripButton10,
            this._ToolStripButton7,
            this._InPhieuBauBKS,
            this._InPhieuBauHDQT});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(982, 27);
            this.ToolStrip1.TabIndex = 3;
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
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(69, 24);
            this.ToolStripLabel1.Text = "Mã đại biểu";
            // 
            // _ToolStripTextBox1
            // 
            this._ToolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._ToolStripTextBox1.Name = "_ToolStripTextBox1";
            this._ToolStripTextBox1.Size = new System.Drawing.Size(50, 27);
            this._ToolStripTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ToolStripTextBox1_KeyUp);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ToolStripLabel2
            // 
            this.ToolStripLabel2.Name = "ToolStripLabel2";
            this.ToolStripLabel2.Size = new System.Drawing.Size(67, 24);
            this.ToolStripLabel2.Text = "CMT/GPKD";
            // 
            // _ToolStripTextBox2
            // 
            this._ToolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._ToolStripTextBox2.Name = "_ToolStripTextBox2";
            this._ToolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            this._ToolStripTextBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ToolStripTextBox2_KeyUp);
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
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // _ToolStripButton5
            // 
            this._ToolStripButton5.Image = global::pmDHCD.My.Resources.Resources.Printer;
            this._ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButton5.Name = "_ToolStripButton5";
            this._ToolStripButton5.Size = new System.Drawing.Size(80, 24);
            this._ToolStripButton5.Text = "In thẻ BQ";
            this._ToolStripButton5.Click += new System.EventHandler(this.ToolStripButton5_Click);
            // 
            // _ToolStripButton10
            // 
            this._ToolStripButton10.Image = global::pmDHCD.My.Resources.Resources.Printer;
            this._ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButton10.Name = "_ToolStripButton10";
            this._ToolStripButton10.Size = new System.Drawing.Size(105, 24);
            this._ToolStripButton10.Text = "P.XN tham dự";
            this._ToolStripButton10.Click += new System.EventHandler(this.ToolStripButton10_Click);
            // 
            // _ToolStripButton7
            // 
            this._ToolStripButton7.Image = global::pmDHCD.My.Resources.Resources.Printer;
            this._ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButton7.Name = "_ToolStripButton7";
            this._ToolStripButton7.Size = new System.Drawing.Size(89, 24);
            this._ToolStripButton7.Text = "Phiếu BQ 1";
            this._ToolStripButton7.Click += new System.EventHandler(this.ToolStripButton7_Click_1);
            // 
            // _InPhieuBauBKS
            // 
            this._InPhieuBauBKS.Image = global::pmDHCD.My.Resources.Resources.Printer;
            this._InPhieuBauBKS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._InPhieuBauBKS.Name = "_InPhieuBauBKS";
            this._InPhieuBauBKS.Size = new System.Drawing.Size(87, 24);
            this._InPhieuBauBKS.Text = "P. Bầu BSK";
            this._InPhieuBauBKS.Click += new System.EventHandler(this.InPhieuBauBKS_Click);
            // 
            // _InPhieuBauHDQT
            // 
            this._InPhieuBauHDQT.Image = global::pmDHCD.My.Resources.Resources.Printer;
            this._InPhieuBauHDQT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._InPhieuBauHDQT.Name = "_InPhieuBauHDQT";
            this._InPhieuBauHDQT.Size = new System.Drawing.Size(98, 24);
            this._InPhieuBauHDQT.Text = "P. Bầu HDQT";
            this._InPhieuBauHDQT.Click += new System.EventHandler(this.InPhieuBauHDQT_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delegatecode,
            this.Delegatename,
            this.IdentityCard,
            this.DelegateAddress,
            this.Voterights});
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 27);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(982, 520);
            this.DataGridView1.TabIndex = 6;
            // 
            // Delegatecode
            // 
            this.Delegatecode.DataPropertyName = "Delegatecode";
            this.Delegatecode.FillWeight = 59.08628F;
            this.Delegatecode.HeaderText = "Mã đại biểu";
            this.Delegatecode.Name = "Delegatecode";
            this.Delegatecode.ReadOnly = true;
            // 
            // Delegatename
            // 
            this.Delegatename.DataPropertyName = "Delegatename";
            this.Delegatename.FillWeight = 59.08628F;
            this.Delegatename.HeaderText = "Tên đại biểu";
            this.Delegatename.Name = "Delegatename";
            this.Delegatename.ReadOnly = true;
            // 
            // IdentityCard
            // 
            this.IdentityCard.DataPropertyName = "IdentityCard";
            this.IdentityCard.FillWeight = 59.08628F;
            this.IdentityCard.HeaderText = "CMT/GPKD";
            this.IdentityCard.Name = "IdentityCard";
            this.IdentityCard.ReadOnly = true;
            // 
            // DelegateAddress
            // 
            this.DelegateAddress.DataPropertyName = "DelegateAddress";
            this.DelegateAddress.FillWeight = 200F;
            this.DelegateAddress.HeaderText = "Địa chỉ";
            this.DelegateAddress.Name = "DelegateAddress";
            this.DelegateAddress.ReadOnly = true;
            // 
            // Voterights
            // 
            this.Voterights.DataPropertyName = "Voterights";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Voterights.DefaultCellStyle = dataGridViewCellStyle2;
            this.Voterights.FillWeight = 59.08628F;
            this.Voterights.HeaderText = "Tổng  quyền b.quyết";
            this.Voterights.Name = "Voterights";
            this.Voterights.ReadOnly = true;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2,
            this.ToolStripSplitButton1,
            this.ToolStripStatusLabel3,
            this.ToolStripStatusLabel4});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 525);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(982, 22);
            this.StatusStrip1.TabIndex = 7;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(112, 17);
            this.ToolStripStatusLabel1.Text = "Số lượng bản ghi : ";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStripSplitButton1
            // 
            this.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.ToolStripSplitButton1.Name = "ToolStripSplitButton1";
            this.ToolStripSplitButton1.Size = new System.Drawing.Size(16, 20);
            this.ToolStripSplitButton1.Text = "ToolStripSplitButton1";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(153, 17);
            this.ToolStripStatusLabel3.Text = "Tổng số quyền biểu quyết";
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(126, 17);
            this.ToolStripStatusLabel4.Text = "ToolStripStatusLabel4";
            // 
            // DelegateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 547);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "DelegateList";
            this.Text = "Danh sách đại biểu";
            this.Load += new System.EventHandler(this.DelegateList_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DelegateList_KeyUp);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
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
        internal ToolStripSeparator ToolStripSeparator3;
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
        internal ToolStripStatusLabel ToolStripStatusLabel3;
        internal ToolStripStatusLabel ToolStripStatusLabel4;
        internal ToolStripSplitButton ToolStripSplitButton1;

       
        private ToolStripButton _ToolStripButton10;

        internal ToolStripButton ToolStripButton10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton10 != null)
                {
                    _ToolStripButton10.Click -= ToolStripButton10_Click;
                }

                _ToolStripButton10 = value;
                if (_ToolStripButton10 != null)
                {
                    _ToolStripButton10.Click += ToolStripButton10_Click;
                }
            }
        }

        internal DataGridViewTextBoxColumn Delegatecode;
        internal DataGridViewTextBoxColumn Delegatename;
        internal DataGridViewTextBoxColumn IdentityCard;
        internal DataGridViewTextBoxColumn DelegateAddress;
        internal DataGridViewTextBoxColumn Voterights;
        private ToolStripButton _InPhieuBauBKS;

        internal ToolStripButton InPhieuBauBKS
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _InPhieuBauBKS;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_InPhieuBauBKS != null)
                {
                    _InPhieuBauBKS.Click -= InPhieuBauBKS_Click;
                }

                _InPhieuBauBKS = value;
                if (_InPhieuBauBKS != null)
                {
                    _InPhieuBauBKS.Click += InPhieuBauBKS_Click;
                }
            }
        }

        private ToolStripButton _InPhieuBauHDQT;

        internal ToolStripButton InPhieuBauHDQT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _InPhieuBauHDQT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_InPhieuBauHDQT != null)
                {
                    _InPhieuBauHDQT.Click -= InPhieuBauHDQT_Click;
                }

                _InPhieuBauHDQT = value;
                if (_InPhieuBauHDQT != null)
                {
                    _InPhieuBauHDQT.Click += InPhieuBauHDQT_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButton7;

        internal ToolStripButton ToolStripButton7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButton7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButton7 != null)
                {
                    _ToolStripButton7.Click -= ToolStripButton7_Click_1;
                }

                _ToolStripButton7 = value;
                if (_ToolStripButton7 != null)
                {
                    _ToolStripButton7.Click += ToolStripButton7_Click_1;
                }
            }
        }
    }
}