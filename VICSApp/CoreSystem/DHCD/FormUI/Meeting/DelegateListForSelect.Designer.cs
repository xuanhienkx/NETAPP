﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class DelegateListForSelect : Form
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
            delegatecode = new DataGridViewTextBoxColumn();
            DelegateName = new DataGridViewTextBoxColumn();
            IdentityCard = new DataGridViewTextBoxColumn();
            DelegateAddress = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)_DataGridView1).BeginInit();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridView1
            // 
            _DataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = SystemColors.Info;
            _DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            _DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _DataGridView1.Columns.AddRange(new DataGridViewColumn[] { delegatecode, DelegateName, IdentityCard, DelegateAddress });
            _DataGridView1.Dock = DockStyle.Fill;
            _DataGridView1.Location = new Point(0, 0);
            _DataGridView1.Name = "_DataGridView1";
            _DataGridView1.ReadOnly = true;
            _DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _DataGridView1.Size = new Size(625, 290);
            _DataGridView1.TabIndex = 5;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2 });
            StatusStrip1.Location = new Point(0, 268);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(625, 22);
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
            // delegatecode
            // 
            delegatecode.DataPropertyName = "delegatecode";
            delegatecode.FillWeight = 59.08628f;
            delegatecode.HeaderText = "Mã đại biểu";
            delegatecode.Name = "delegatecode";
            delegatecode.ReadOnly = true;
            // 
            // DelegateName
            // 
            DelegateName.DataPropertyName = "DelegateName";
            DelegateName.FillWeight = 59.08628f;
            DelegateName.HeaderText = "Tên đại biểu";
            DelegateName.Name = "DelegateName";
            DelegateName.ReadOnly = true;
            DelegateName.Width = 120;
            // 
            // IdentityCard
            // 
            IdentityCard.DataPropertyName = "IdentityCard";
            IdentityCard.FillWeight = 59.08628f;
            IdentityCard.HeaderText = "CMT/GPKD";
            IdentityCard.Name = "IdentityCard";
            IdentityCard.ReadOnly = true;
            IdentityCard.Width = 94;
            // 
            // DelegateAddress
            // 
            DelegateAddress.DataPropertyName = "DelegateAddress";
            DelegateAddress.FillWeight = 200.0f;
            DelegateAddress.HeaderText = "Địa chỉ";
            DelegateAddress.Name = "DelegateAddress";
            DelegateAddress.ReadOnly = true;
            DelegateAddress.Width = 300;
            // 
            // DelegateListForSelect
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 290);
            Controls.Add(StatusStrip1);
            Controls.Add(_DataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "DelegateListForSelect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chọn đại biểu";
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
        internal DataGridViewTextBoxColumn delegatecode;
        internal DataGridViewTextBoxColumn DelegateName;
        internal DataGridViewTextBoxColumn IdentityCard;
        internal DataGridViewTextBoxColumn DelegateAddress;
    }
}