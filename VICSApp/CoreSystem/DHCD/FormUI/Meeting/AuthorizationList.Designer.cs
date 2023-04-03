using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class AuthorizationList : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationList));
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            var DataGridViewCellStyle2 = new DataGridViewCellStyle();
            var DataGridViewCellStyle3 = new DataGridViewCellStyle();
            var DataGridViewCellStyle4 = new DataGridViewCellStyle();
            ToolStrip1 = new ToolStrip();
            _ToolStripButton1 = new ToolStripButton();
            _ToolStripButton1.Click += new EventHandler(ToolStripButton1_Click);
            _ToolStripButton2 = new ToolStripButton();
            _ToolStripButton2.Click += new EventHandler(ToolStripButton2_Click);
            _ToolStripButton3 = new ToolStripButton();
            _ToolStripButton3.Click += new EventHandler(ToolStripButton3_Click);
            ToolStripSeparator1 = new ToolStripSeparator();
            ToolStripLabel2 = new ToolStripLabel();
            _ToolStripTextBox2 = new ToolStripTextBox();
            _ToolStripTextBox2.KeyUp += new KeyEventHandler(ToolStripTextBox2_KeyUp);
            ToolStripSeparator2 = new ToolStripSeparator();
            ToolStripLabel4 = new ToolStripLabel();
            _ToolStripTextBox4 = new ToolStripTextBox();
            _ToolStripTextBox4.KeyUp += new KeyEventHandler(ToolStripTextBox4_KeyUp);
            ToolStripSeparator3 = new ToolStripSeparator();
            _ToolStripButton5 = new ToolStripButton();
            _ToolStripButton5.Click += new EventHandler(ToolStripButton5_Click);
            _ToolStripButton6 = new ToolStripButton();
            _ToolStripButton6.Click += new EventHandler(ToolStripButton6_Click);
            _ToolStripButton4 = new ToolStripButton();
            _ToolStripButton4.Click += new EventHandler(ToolStripButton4_Click);
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStripSplitButton1 = new ToolStripSplitButton();
            ToolStripStatusLabel3 = new ToolStripStatusLabel();
            ToolStripStatusLabel4 = new ToolStripStatusLabel();
            ToolStripSplitButton2 = new ToolStripSplitButton();
            ToolStripStatusLabel5 = new ToolStripStatusLabel();
            ToolStripStatusLabel6 = new ToolStripStatusLabel();
            DataGridView1 = new DataGridView();
            Holdercode = new DataGridViewTextBoxColumn();
            holdername = new DataGridViewTextBoxColumn();
            HolderIdentity = new DataGridViewTextBoxColumn();
            HolderAddress = new DataGridViewTextBoxColumn();
            Delegatecode = new DataGridViewTextBoxColumn();
            Delegatename = new DataGridViewTextBoxColumn();
            IdentityCard = new DataGridViewTextBoxColumn();
            DelegateAddress = new DataGridViewTextBoxColumn();
            voterights = new DataGridViewTextBoxColumn();
            DelegateRight = new DataGridViewTextBoxColumn();
            ToolStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { _ToolStripButton1, _ToolStripButton2, _ToolStripButton3, ToolStripSeparator1, ToolStripLabel2, _ToolStripTextBox2, ToolStripSeparator2, ToolStripLabel4, _ToolStripTextBox4, ToolStripSeparator3, _ToolStripButton5, _ToolStripButton6, _ToolStripButton4 });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(940, 25);
            ToolStrip1.TabIndex = 4;
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
            // ToolStripLabel2
            // 
            ToolStripLabel2.Name = "ToolStripLabel2";
            ToolStripLabel2.Size = new Size(100, 22);
            ToolStripLabel2.Text = "CMT/HC đại biểu";
            // 
            // ToolStripTextBox2
            // 
            _ToolStripTextBox2.Name = "_ToolStripTextBox2";
            _ToolStripTextBox2.Size = new Size(100, 25);
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripLabel4
            // 
            ToolStripLabel4.Name = "ToolStripLabel4";
            ToolStripLabel4.Size = new Size(137, 22);
            ToolStripLabel4.Text = "CMT/HC/GPKD cổ đông";
            // 
            // ToolStripTextBox4
            // 
            _ToolStripTextBox4.Name = "_ToolStripTextBox4";
            _ToolStripTextBox4.Size = new Size(100, 25);
            // 
            // ToolStripSeparator3
            // 
            ToolStripSeparator3.Name = "ToolStripSeparator3";
            ToolStripSeparator3.Size = new Size(6, 25);
            // 
            // ToolStripButton5
            // 
            _ToolStripButton5.Image = My.Resources.Resources.Search;
            _ToolStripButton5.ImageTransparentColor = Color.Magenta;
            _ToolStripButton5.Name = "_ToolStripButton5";
            _ToolStripButton5.Size = new Size(48, 22);
            _ToolStripButton5.Text = "Tìm";
            // 
            // ToolStripButton6
            // 
            _ToolStripButton6.Image = My.Resources.Resources.Search;
            _ToolStripButton6.ImageTransparentColor = Color.Magenta;
            _ToolStripButton6.Name = "_ToolStripButton6";
            _ToolStripButton6.Size = new Size(76, 22);
            _ToolStripButton6.Text = "In thẻ BQ";
            _ToolStripButton6.Visible = false;
            // 
            // ToolStripButton4
            // 
            _ToolStripButton4.Image = My.Resources.Resources.Search;
            _ToolStripButton4.ImageTransparentColor = Color.Magenta;
            _ToolStripButton4.Name = "_ToolStripButton4";
            _ToolStripButton4.Size = new Size(124, 22);
            _ToolStripButton4.Text = "In giấy x.nhận t.dự";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripSplitButton1, ToolStripStatusLabel3, ToolStripStatusLabel4, ToolStripSplitButton2, ToolStripStatusLabel5, ToolStripStatusLabel6 });
            StatusStrip1.Location = new Point(0, 441);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(940, 22);
            StatusStrip1.TabIndex = 8;
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
            // ToolStripSplitButton1
            // 
            ToolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.None;
            ToolStripSplitButton1.Image = (Image)resources.GetObject("ToolStripSplitButton1.Image");
            ToolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            ToolStripSplitButton1.Name = "ToolStripSplitButton1";
            ToolStripSplitButton1.Size = new Size(16, 20);
            ToolStripSplitButton1.Text = "ToolStripSplitButton1";
            // 
            // ToolStripStatusLabel3
            // 
            ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            ToolStripStatusLabel3.Size = new Size(195, 17);
            ToolStripStatusLabel3.Text = "Tổng số quyền biểu quyết của CĐ : ";
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
            ToolStripStatusLabel5.Size = new Size(236, 17);
            ToolStripStatusLabel5.Text = "Tổng số quyền biểu quyết được ủy quyền : ";
            // 
            // ToolStripStatusLabel6
            // 
            ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            ToolStripStatusLabel6.Size = new Size(121, 17);
            ToolStripStatusLabel6.Text = "ToolStripStatusLabel6";
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridViewCellStyle1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(192)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Holdercode, holdername, HolderIdentity, HolderAddress, Delegatecode, Delegatename, IdentityCard, DelegateAddress, voterights, DelegateRight });
            DataGridView1.Dock = DockStyle.Fill;
            DataGridView1.Location = new Point(0, 25);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.RowHeadersVisible = false;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.Size = new Size(940, 416);
            DataGridView1.TabIndex = 9;
            // 
            // Holdercode
            // 
            Holdercode.DataPropertyName = "Holdercode";
            Holdercode.FillWeight = 11.21656f;
            Holdercode.HeaderText = "Mã cổ đông";
            Holdercode.MinimumWidth = 80;
            Holdercode.Name = "Holdercode";
            Holdercode.ReadOnly = true;
            // 
            // holdername
            // 
            holdername.DataPropertyName = "holdername";
            holdername.FillWeight = 196.5355f;
            holdername.HeaderText = "Tên cổ đông";
            holdername.MinimumWidth = 150;
            holdername.Name = "holdername";
            holdername.ReadOnly = true;
            // 
            // HolderIdentity
            // 
            HolderIdentity.DataPropertyName = "HolderIdentity";
            DataGridViewCellStyle2.Format = "N0";
            DataGridViewCellStyle2.NullValue = null;
            HolderIdentity.DefaultCellStyle = DataGridViewCellStyle2;
            HolderIdentity.FillWeight = 97.21734f;
            HolderIdentity.HeaderText = "CMT/HC/GPKD CĐ";
            HolderIdentity.MinimumWidth = 100;
            HolderIdentity.Name = "HolderIdentity";
            HolderIdentity.ReadOnly = true;
            // 
            // HolderAddress
            // 
            HolderAddress.DataPropertyName = "HolderAddress";
            HolderAddress.HeaderText = "HolderAddress";
            HolderAddress.Name = "HolderAddress";
            HolderAddress.ReadOnly = true;
            HolderAddress.Visible = false;
            // 
            // Delegatecode
            // 
            Delegatecode.DataPropertyName = "Delegatecode";
            Delegatecode.FillWeight = 74.75592f;
            Delegatecode.HeaderText = "Mã đại biểu";
            Delegatecode.MinimumWidth = 80;
            Delegatecode.Name = "Delegatecode";
            Delegatecode.ReadOnly = true;
            // 
            // Delegatename
            // 
            Delegatename.DataPropertyName = "Delegatename";
            Delegatename.FillWeight = 6.621332f;
            Delegatename.HeaderText = "Tên đại biểu";
            Delegatename.MinimumWidth = 200;
            Delegatename.Name = "Delegatename";
            Delegatename.ReadOnly = true;
            // 
            // IdentityCard
            // 
            IdentityCard.DataPropertyName = "IdentityCard";
            IdentityCard.FillWeight = 52.32525f;
            IdentityCard.HeaderText = "CMT/HC ĐB";
            IdentityCard.MinimumWidth = 100;
            IdentityCard.Name = "IdentityCard";
            IdentityCard.ReadOnly = true;
            // 
            // DelegateAddress
            // 
            DelegateAddress.DataPropertyName = "DelegateAddress";
            DelegateAddress.HeaderText = "DelegateAddress";
            DelegateAddress.Name = "DelegateAddress";
            DelegateAddress.ReadOnly = true;
            DelegateAddress.Visible = false;
            // 
            // voterights
            // 
            voterights.DataPropertyName = "voterights";
            DataGridViewCellStyle3.Format = "N0";
            voterights.DefaultCellStyle = DataGridViewCellStyle3;
            voterights.FillWeight = 128.2284f;
            voterights.HeaderText = "Số quyền BQ CĐ";
            voterights.MinimumWidth = 40;
            voterights.Name = "voterights";
            voterights.ReadOnly = true;
            // 
            // DelegateRight
            // 
            DelegateRight.DataPropertyName = "DelegateRight";
            DataGridViewCellStyle4.Format = "N0";
            DelegateRight.DefaultCellStyle = DataGridViewCellStyle4;
            DelegateRight.FillWeight = 169.4455f;
            DelegateRight.HeaderText = "Số quyền BQ ủy quyền";
            DelegateRight.MinimumWidth = 40;
            DelegateRight.Name = "DelegateRight";
            DelegateRight.ReadOnly = true;
            // 
            // AuthorizationList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 463);
            Controls.Add(DataGridView1);
            Controls.Add(StatusStrip1);
            Controls.Add(ToolStrip1);
            KeyPreview = true;
            Name = "AuthorizationList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách ủy quyền";
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            Load += new EventHandler(AuthorizationList_Load);
            KeyUp += new KeyEventHandler(AuthorizationList_KeyUp);
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

        internal ToolStripSeparator ToolStripSeparator2;
        internal ToolStripLabel ToolStripLabel4;
        private ToolStripTextBox _ToolStripTextBox4;

        internal ToolStripTextBox ToolStripTextBox4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripTextBox4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripTextBox4 != null)
                {
                    _ToolStripTextBox4.KeyUp -= ToolStripTextBox4_KeyUp;
                }

                _ToolStripTextBox4 = value;
                if (_ToolStripTextBox4 != null)
                {
                    _ToolStripTextBox4.KeyUp += ToolStripTextBox4_KeyUp;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator3;
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
        internal DataGridView DataGridView1;
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

        internal DataGridViewTextBoxColumn Holdercode;
        internal DataGridViewTextBoxColumn holdername;
        internal DataGridViewTextBoxColumn HolderIdentity;
        internal DataGridViewTextBoxColumn HolderAddress;
        internal DataGridViewTextBoxColumn Delegatecode;
        internal DataGridViewTextBoxColumn Delegatename;
        internal DataGridViewTextBoxColumn IdentityCard;
        internal DataGridViewTextBoxColumn DelegateAddress;
        internal DataGridViewTextBoxColumn voterights;
        internal DataGridViewTextBoxColumn DelegateRight;
    }
}