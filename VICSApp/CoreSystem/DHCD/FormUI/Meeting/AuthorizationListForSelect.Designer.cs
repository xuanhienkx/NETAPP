using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class AuthorizationListForSelect : Form
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
            _DataGridView1 = new DataGridView();
            _DataGridView1.KeyDown += new KeyEventHandler(DataGridView1_KeyDown);
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            holdercode = new DataGridViewTextBoxColumn();
            HolderName = new DataGridViewTextBoxColumn();
            HolderIdentity = new DataGridViewTextBoxColumn();
            HolderAddress = new DataGridViewTextBoxColumn();
            DelegateCode = new DataGridViewTextBoxColumn();
            DelegateName = new DataGridViewTextBoxColumn();
            DelegateRight = new DataGridViewTextBoxColumn();
            IdentityCard = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)_DataGridView1).BeginInit();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridView1
            // 
            _DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = SystemColors.Info;
            _DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            _DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _DataGridView1.Columns.AddRange(new DataGridViewColumn[] { holdercode, HolderName, HolderIdentity, HolderAddress, DelegateCode, DelegateName, DelegateRight, IdentityCard });
            _DataGridView1.Dock = DockStyle.Fill;
            _DataGridView1.Location = new Point(0, 0);
            _DataGridView1.Name = "_DataGridView1";
            _DataGridView1.ReadOnly = true;
            _DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _DataGridView1.Size = new Size(716, 293);
            _DataGridView1.TabIndex = 5;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2 });
            StatusStrip1.Location = new Point(0, 271);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(716, 22);
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
            // holdercode
            // 
            holdercode.DataPropertyName = "holdercode";
            holdercode.FillWeight = 59.08628f;
            holdercode.Frozen = true;
            holdercode.HeaderText = "Mã cổ đông";
            holdercode.Name = "holdercode";
            holdercode.ReadOnly = true;
            holdercode.Width = 50;
            // 
            // HolderName
            // 
            HolderName.DataPropertyName = "HolderName";
            HolderName.FillWeight = 59.08628f;
            HolderName.Frozen = true;
            HolderName.HeaderText = "Tên cổ đông";
            HolderName.Name = "HolderName";
            HolderName.ReadOnly = true;
            HolderName.Width = 120;
            // 
            // HolderIdentity
            // 
            HolderIdentity.DataPropertyName = "HolderIdentity";
            HolderIdentity.FillWeight = 59.08628f;
            HolderIdentity.Frozen = true;
            HolderIdentity.HeaderText = "CMT/GPKD";
            HolderIdentity.Name = "HolderIdentity";
            HolderIdentity.ReadOnly = true;
            HolderIdentity.Width = 94;
            // 
            // HolderAddress
            // 
            HolderAddress.DataPropertyName = "HolderAddress";
            HolderAddress.FillWeight = 200.0f;
            HolderAddress.Frozen = true;
            HolderAddress.HeaderText = "Địa chỉ";
            HolderAddress.Name = "HolderAddress";
            HolderAddress.ReadOnly = true;
            HolderAddress.Width = 150;
            // 
            // DelegateCode
            // 
            DelegateCode.DataPropertyName = "DelegateCode";
            DelegateCode.Frozen = true;
            DelegateCode.HeaderText = "DelegateCode";
            DelegateCode.Name = "DelegateCode";
            DelegateCode.ReadOnly = true;
            DelegateCode.Visible = false;
            DelegateCode.Width = 5;
            // 
            // DelegateName
            // 
            DelegateName.DataPropertyName = "DelegateName";
            DelegateName.Frozen = true;
            DelegateName.HeaderText = "Người đại diện";
            DelegateName.Name = "DelegateName";
            DelegateName.ReadOnly = true;
            DelegateName.Width = 150;
            // 
            // DelegateRight
            // 
            DelegateRight.DataPropertyName = "DelegateRight";
            DelegateRight.Frozen = true;
            DelegateRight.HeaderText = "Số quyền";
            DelegateRight.Name = "DelegateRight";
            DelegateRight.ReadOnly = true;
            // 
            // IdentityCard
            // 
            IdentityCard.DataPropertyName = "IdentityCard";
            IdentityCard.HeaderText = "IdentityCard";
            IdentityCard.Name = "IdentityCard";
            IdentityCard.ReadOnly = true;
            IdentityCard.Visible = false;
            // 
            // AuthorizationListForSelect
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 293);
            Controls.Add(StatusStrip1);
            Controls.Add(_DataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "AuthorizationListForSelect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bỏ phiếu - Chọn cổ đông";
            ((System.ComponentModel.ISupportInitialize)_DataGridView1).EndInit();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            Load += new EventHandler(HolderList_Load);
            KeyUp += new KeyEventHandler(HolderListForSelect_KeyUp);
            ResumeLayout(false);
            PerformLayout();
        }

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

        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal DataGridViewTextBoxColumn holdercode;
        internal DataGridViewTextBoxColumn HolderName;
        internal DataGridViewTextBoxColumn HolderIdentity;
        internal DataGridViewTextBoxColumn HolderAddress;
        internal DataGridViewTextBoxColumn DelegateCode;
        internal DataGridViewTextBoxColumn DelegateName;
        internal DataGridViewTextBoxColumn DelegateRight;
        internal DataGridViewTextBoxColumn IdentityCard;
    }
}