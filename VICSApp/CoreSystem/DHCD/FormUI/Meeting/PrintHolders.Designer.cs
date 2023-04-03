using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class PrintHolders : Form
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
            components = new System.ComponentModel.Container();
            TableLayoutPanel1 = new TableLayoutPanel();
            _OK_Button = new Button();
            _OK_Button.Click += new EventHandler(OK_Button_Click);
            _Cancel_Button = new Button();
            _Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            txtFromHolder = new TextBox();
            txtToHolder = new TextBox();
            Label1 = new Label();
            Label2 = new Label();
            ErrorProvider1 = new ErrorProvider(components);
            TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TableLayoutPanel1.ColumnCount = 2;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Controls.Add(_OK_Button, 0, 0);
            TableLayoutPanel1.Controls.Add(_Cancel_Button, 1, 0);
            TableLayoutPanel1.Location = new Point(173, 90);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Size = new Size(146, 29);
            TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
            _OK_Button.Location = new Point(3, 3);
            _OK_Button.Name = "_OK_Button";
            _OK_Button.Size = new Size(67, 23);
            _OK_Button.TabIndex = 0;
            _OK_Button.Text = "OK";
            // 
            // Cancel_Button
            // 
            _Cancel_Button.Anchor = AnchorStyles.None;
            _Cancel_Button.DialogResult = DialogResult.Cancel;
            _Cancel_Button.Location = new Point(76, 3);
            _Cancel_Button.Name = "_Cancel_Button";
            _Cancel_Button.Size = new Size(67, 23);
            _Cancel_Button.TabIndex = 1;
            _Cancel_Button.Text = "Cancel";
            // 
            // txtFromHolder
            // 
            txtFromHolder.Location = new Point(41, 34);
            txtFromHolder.Name = "txtFromHolder";
            txtFromHolder.Size = new Size(100, 20);
            txtFromHolder.TabIndex = 1;
            txtFromHolder.Text = "0";
            // 
            // txtToHolder
            // 
            txtToHolder.Location = new Point(196, 34);
            txtToHolder.Name = "txtToHolder";
            txtToHolder.Size = new Size(100, 20);
            txtToHolder.TabIndex = 2;
            txtToHolder.Text = "1";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(38, 18);
            Label1.Name = "Label1";
            Label1.Size = new Size(80, 13);
            Label1.TabIndex = 3;
            Label1.Text = "Từ mã cổ đông";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(189, 18);
            Label2.Name = "Label2";
            Label2.Size = new Size(82, 13);
            Label2.TabIndex = 4;
            Label2.Text = "Tới mã cổ đông";
            // 
            // ErrorProvider1
            // 
            ErrorProvider1.ContainerControl = this;
            // 
            // PrintHolders
            // 
            AcceptButton = _OK_Button;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _Cancel_Button;
            ClientSize = new Size(331, 131);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(txtToHolder);
            Controls.Add(txtFromHolder);
            Controls.Add(TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PrintHolders";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "In thẻ biểu quyết";
            TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ErrorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        internal TableLayoutPanel TableLayoutPanel1;
        private Button _OK_Button;

        internal Button OK_Button
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OK_Button;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OK_Button != null)
                {
                    _OK_Button.Click -= OK_Button_Click;
                }

                _OK_Button = value;
                if (_OK_Button != null)
                {
                    _OK_Button.Click += OK_Button_Click;
                }
            }
        }

        private Button _Cancel_Button;

        internal Button Cancel_Button
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Cancel_Button;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Cancel_Button != null)
                {
                    _Cancel_Button.Click -= Cancel_Button_Click;
                }

                _Cancel_Button = value;
                if (_Cancel_Button != null)
                {
                    _Cancel_Button.Click += Cancel_Button_Click;
                }
            }
        }

        internal TextBox txtFromHolder;
        internal TextBox txtToHolder;
        internal Label Label1;
        internal Label Label2;
        internal ErrorProvider ErrorProvider1;
    }
}