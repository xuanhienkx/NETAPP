using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    [DesignerGenerated()]
    public partial class Mainform : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            MenuStrip1 = new MenuStrip();
            HệThốngToolStripMenuItem = new ToolStripMenuItem();
            CuộcHọpToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchCuộcHọpToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchCuộcHọpToolStripMenuItem.Click += new EventHandler(DanhSáchCuộcHọpToolStripMenuItem_Click);
            _DanhSáchCổĐôngToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchCổĐôngToolStripMenuItem.Click += new EventHandler(DanhSáchCổĐôngToolStripMenuItem_Click);
            _DanhSáchĐạiBiểuToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchĐạiBiểuToolStripMenuItem.Click += new EventHandler(DanhSáchĐạiBiểuToolStripMenuItem_Click);
            _DanhSáchỦyQuyềnToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchỦyQuyềnToolStripMenuItem.Click += new EventHandler(DanhSáchỦyQuyềnToolStripMenuItem_Click);
            _ThôngTinCuộcHọpToolStripMenuItem = new ToolStripMenuItem();
            _ThôngTinCuộcHọpToolStripMenuItem.Click += new EventHandler(ThôngTinCuộcHọpToolStripMenuItem_Click);
            _BiểuQuyếtToolStripMenuItem = new ToolStripMenuItem();
            _BiểuQuyếtToolStripMenuItem.Click += new EventHandler(BiểuQuyếtToolStripMenuItem_Click);
            _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Click += new EventHandler(DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem_Click);
            _ToolStripMenuItem1 = new ToolStripMenuItem();
            _ToolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click);
            _KếtQuảBiểuQuyếtToolStripMenuItem = new ToolStripMenuItem();
            _KếtQuảBiểuQuyếtToolStripMenuItem.Click += new EventHandler(KếtQuảBiểuQuyếtToolStripMenuItem_Click);
            BầuCửToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchVấnĐềBầuCửToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchVấnĐềBầuCửToolStripMenuItem.Click += new EventHandler(DanhSáchVấnĐềBầuCửToolStripMenuItem_Click);
            _DanhSáchỨngViênToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchỨngViênToolStripMenuItem.Click += new EventHandler(DanhSáchỨngViênToolStripMenuItem_Click);
            _DanhSáchPhiếuBầuCửToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchPhiếuBầuCửToolStripMenuItem.Click += new EventHandler(DanhSáchPhiếuBầuCửToolStripMenuItem_Click);
            _KếtQuảBầuCửToolStripMenuItem = new ToolStripMenuItem();
            _KếtQuảBầuCửToolStripMenuItem.Click += new EventHandler(KếtQuảBầuCửToolStripMenuItem_Click);
            _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem = new ToolStripMenuItem();
            _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Click += new EventHandler(DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem_Click);
            HiểnThịToolStripMenuItem = new ToolStripMenuItem();
            MainStatusStrip = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStrip1 = new ToolStrip();
            ToolStripStatusLabel3 = new ToolStripStatusLabel();
            MenuStrip1.SuspendLayout();
            MainStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip1
            // 
            MenuStrip1.ImageScalingSize = new Size(20, 20);
            MenuStrip1.Items.AddRange(new ToolStripItem[] { HệThốngToolStripMenuItem, CuộcHọpToolStripMenuItem, _BiểuQuyếtToolStripMenuItem, BầuCửToolStripMenuItem, HiểnThịToolStripMenuItem });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Padding = new Padding(8, 2, 0, 2);
            MenuStrip1.Size = new Size(1456, 28);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "MenuStrip1";
            // 
            // HệThốngToolStripMenuItem
            // 
            HệThốngToolStripMenuItem.Name = "HệThốngToolStripMenuItem";
            HệThốngToolStripMenuItem.Size = new Size(94, 24);
            HệThốngToolStripMenuItem.Text = "&1.Hệ thống";
            // 
            // CuộcHọpToolStripMenuItem
            // 
            CuộcHọpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DanhSáchCuộcHọpToolStripMenuItem, _DanhSáchCổĐôngToolStripMenuItem, _DanhSáchĐạiBiểuToolStripMenuItem, _DanhSáchỦyQuyềnToolStripMenuItem, _ThôngTinCuộcHọpToolStripMenuItem });
            CuộcHọpToolStripMenuItem.Name = "CuộcHọpToolStripMenuItem";
            CuộcHọpToolStripMenuItem.Size = new Size(99, 24);
            CuộcHọpToolStripMenuItem.Text = "&2.Cuộc họp ";
            // 
            // DanhSáchCuộcHọpToolStripMenuItem
            // 
            _DanhSáchCuộcHọpToolStripMenuItem.Name = "_DanhSáchCuộcHọpToolStripMenuItem";
            _DanhSáchCuộcHọpToolStripMenuItem.Size = new Size(226, 24);
            _DanhSáchCuộcHọpToolStripMenuItem.Text = "1. Danh sách cuộc họp";
            // 
            // DanhSáchCổĐôngToolStripMenuItem
            // 
            _DanhSáchCổĐôngToolStripMenuItem.Name = "_DanhSáchCổĐôngToolStripMenuItem";
            _DanhSáchCổĐôngToolStripMenuItem.Size = new Size(226, 24);
            _DanhSáchCổĐôngToolStripMenuItem.Text = "2. Danh sách cổ đông";
            // 
            // DanhSáchĐạiBiểuToolStripMenuItem
            // 
            _DanhSáchĐạiBiểuToolStripMenuItem.Name = "_DanhSáchĐạiBiểuToolStripMenuItem";
            _DanhSáchĐạiBiểuToolStripMenuItem.Size = new Size(226, 24);
            _DanhSáchĐạiBiểuToolStripMenuItem.Text = "3. Danh sách đại biểu";
            // 
            // DanhSáchỦyQuyềnToolStripMenuItem
            // 
            _DanhSáchỦyQuyềnToolStripMenuItem.Name = "_DanhSáchỦyQuyềnToolStripMenuItem";
            _DanhSáchỦyQuyềnToolStripMenuItem.Size = new Size(226, 24);
            _DanhSáchỦyQuyềnToolStripMenuItem.Text = "4. Danh sách ủy quyền";
            // 
            // ThôngTinCuộcHọpToolStripMenuItem
            // 
            _ThôngTinCuộcHọpToolStripMenuItem.Name = "_ThôngTinCuộcHọpToolStripMenuItem";
            _ThôngTinCuộcHọpToolStripMenuItem.Size = new Size(226, 24);
            _ThôngTinCuộcHọpToolStripMenuItem.Text = "5. Thông tin cuộc họp";
            // 
            // BiểuQuyếtToolStripMenuItem
            // 
            _BiểuQuyếtToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem, _ToolStripMenuItem1, _KếtQuảBiểuQuyếtToolStripMenuItem });
            _BiểuQuyếtToolStripMenuItem.Name = "_BiểuQuyếtToolStripMenuItem";
            _BiểuQuyếtToolStripMenuItem.Size = new Size(102, 24);
            _BiểuQuyếtToolStripMenuItem.Text = "&3.Biểu quyết";
            // 
            // DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem
            // 
            _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Name = "_DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem";
            _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Size = new Size(283, 24);
            _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Text = "1. Danh sách vấn đề biểu quyết";
            // 
            // ToolStripMenuItem1
            // 
            _ToolStripMenuItem1.Name = "_ToolStripMenuItem1";
            _ToolStripMenuItem1.Size = new Size(283, 24);
            _ToolStripMenuItem1.Text = "2. Danh sách phiếu biểu quyết";
            // 
            // KếtQuảBiểuQuyếtToolStripMenuItem
            // 
            _KếtQuảBiểuQuyếtToolStripMenuItem.Name = "_KếtQuảBiểuQuyếtToolStripMenuItem";
            _KếtQuảBiểuQuyếtToolStripMenuItem.Size = new Size(283, 24);
            _KếtQuảBiểuQuyếtToolStripMenuItem.Text = "3. Kết quả biểu quyết";
            // 
            // BầuCửToolStripMenuItem
            // 
            BầuCửToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DanhSáchVấnĐềBầuCửToolStripMenuItem, _DanhSáchỨngViênToolStripMenuItem, _DanhSáchPhiếuBầuCửToolStripMenuItem, _KếtQuảBầuCửToolStripMenuItem, _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem });
            BầuCửToolStripMenuItem.Name = "BầuCửToolStripMenuItem";
            BầuCửToolStripMenuItem.Size = new Size(77, 24);
            BầuCửToolStripMenuItem.Text = "&4.Bầu cử";
            // 
            // DanhSáchVấnĐềBầuCửToolStripMenuItem
            // 
            _DanhSáchVấnĐềBầuCửToolStripMenuItem.Name = "_DanhSáchVấnĐềBầuCửToolStripMenuItem";
            _DanhSáchVấnĐềBầuCửToolStripMenuItem.Size = new Size(333, 24);
            _DanhSáchVấnĐềBầuCửToolStripMenuItem.Text = "1. Danh sách vấn đề bầu cử";
            // 
            // DanhSáchỨngViênToolStripMenuItem
            // 
            _DanhSáchỨngViênToolStripMenuItem.Name = "_DanhSáchỨngViênToolStripMenuItem";
            _DanhSáchỨngViênToolStripMenuItem.Size = new Size(333, 24);
            _DanhSáchỨngViênToolStripMenuItem.Text = "2. Danh sách ứng viên";
            // 
            // DanhSáchPhiếuBầuCửToolStripMenuItem
            // 
            _DanhSáchPhiếuBầuCửToolStripMenuItem.Name = "_DanhSáchPhiếuBầuCửToolStripMenuItem";
            _DanhSáchPhiếuBầuCửToolStripMenuItem.Size = new Size(333, 24);
            _DanhSáchPhiếuBầuCửToolStripMenuItem.Text = "3. Danh sách phiếu bầu cử";
            // 
            // KếtQuảBầuCửToolStripMenuItem
            // 
            _KếtQuảBầuCửToolStripMenuItem.Name = "_KếtQuảBầuCửToolStripMenuItem";
            _KếtQuảBầuCửToolStripMenuItem.Size = new Size(333, 24);
            _KếtQuảBầuCửToolStripMenuItem.Text = "4. Kết quả bầu cử";
            // 
            // DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem
            // 
            _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Name = "_DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem";
            _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Size = new Size(333, 24);
            _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Text = "5. Danh sách phiếu bầu KHÔNG hợp lệ";
            // 
            // HiểnThịToolStripMenuItem
            // 
            HiểnThịToolStripMenuItem.Name = "HiểnThịToolStripMenuItem";
            HiểnThịToolStripMenuItem.Size = new Size(84, 24);
            HiểnThịToolStripMenuItem.Text = "&5.Hiển thị";
            HiểnThịToolStripMenuItem.Visible = false;
            // 
            // MainStatusStrip
            // 
            MainStatusStrip.ImageScalingSize = new Size(20, 20);
            MainStatusStrip.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripStatusLabel3 });
            MainStatusStrip.Location = new Point(0, 827);
            MainStatusStrip.Name = "MainStatusStrip";
            MainStatusStrip.Padding = new Padding(1, 0, 19, 0);
            MainStatusStrip.Size = new Size(1456, 25);
            MainStatusStrip.TabIndex = 1;
            MainStatusStrip.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(106, 20);
            ToolStripStatusLabel1.Text = "Mã cuộc họp : ";
            // 
            // ToolStripStatusLabel2
            // 
            ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            ToolStripStatusLabel2.Size = new Size(0, 20);
            // 
            // ToolStrip1
            // 
            ToolStrip1.ImageScalingSize = new Size(20, 20);
            ToolStrip1.Location = new Point(0, 28);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(1456, 25);
            ToolStrip1.TabIndex = 2;
            ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripStatusLabel3
            // 
            ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            ToolStripStatusLabel3.Size = new Size(154, 20);
            ToolStripStatusLabel3.Text = "ToolStripStatusLabel3";
            // 
            // Mainform
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1456, 852);
            Controls.Add(ToolStrip1);
            Controls.Add(MainStatusStrip);
            Controls.Add(MenuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = MenuStrip1;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Mainform";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phần mềm họp đại hội cổ đông";
            WindowState = FormWindowState.Maximized;
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            MainStatusStrip.ResumeLayout(false);
            MainStatusStrip.PerformLayout();
            Load += new EventHandler(Mainform_Load);
            Shown += new EventHandler(Mainform_Shown);
            ResumeLayout(false);
            PerformLayout();
        }

        internal MenuStrip MenuStrip1;
        internal ToolStripMenuItem HệThốngToolStripMenuItem;
        internal ToolStripMenuItem CuộcHọpToolStripMenuItem;
        private ToolStripMenuItem _DanhSáchCuộcHọpToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchCuộcHọpToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchCuộcHọpToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchCuộcHọpToolStripMenuItem != null)
                {
                    _DanhSáchCuộcHọpToolStripMenuItem.Click -= DanhSáchCuộcHọpToolStripMenuItem_Click;
                }

                _DanhSáchCuộcHọpToolStripMenuItem = value;
                if (_DanhSáchCuộcHọpToolStripMenuItem != null)
                {
                    _DanhSáchCuộcHọpToolStripMenuItem.Click += DanhSáchCuộcHọpToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _BiểuQuyếtToolStripMenuItem;

        internal ToolStripMenuItem BiểuQuyếtToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BiểuQuyếtToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BiểuQuyếtToolStripMenuItem != null)
                {
                    _BiểuQuyếtToolStripMenuItem.Click -= BiểuQuyếtToolStripMenuItem_Click;
                }

                _BiểuQuyếtToolStripMenuItem = value;
                if (_BiểuQuyếtToolStripMenuItem != null)
                {
                    _BiểuQuyếtToolStripMenuItem.Click += BiểuQuyếtToolStripMenuItem_Click;
                }
            }
        }

        internal ToolStripMenuItem BầuCửToolStripMenuItem;
        private ToolStripMenuItem _DanhSáchCổĐôngToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchCổĐôngToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchCổĐôngToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchCổĐôngToolStripMenuItem != null)
                {
                    _DanhSáchCổĐôngToolStripMenuItem.Click -= DanhSáchCổĐôngToolStripMenuItem_Click;
                }

                _DanhSáchCổĐôngToolStripMenuItem = value;
                if (_DanhSáchCổĐôngToolStripMenuItem != null)
                {
                    _DanhSáchCổĐôngToolStripMenuItem.Click += DanhSáchCổĐôngToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DanhSáchĐạiBiểuToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchĐạiBiểuToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchĐạiBiểuToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchĐạiBiểuToolStripMenuItem != null)
                {
                    _DanhSáchĐạiBiểuToolStripMenuItem.Click -= DanhSáchĐạiBiểuToolStripMenuItem_Click;
                }

                _DanhSáchĐạiBiểuToolStripMenuItem = value;
                if (_DanhSáchĐạiBiểuToolStripMenuItem != null)
                {
                    _DanhSáchĐạiBiểuToolStripMenuItem.Click += DanhSáchĐạiBiểuToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DanhSáchỦyQuyềnToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchỦyQuyềnToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchỦyQuyềnToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchỦyQuyềnToolStripMenuItem != null)
                {
                    _DanhSáchỦyQuyềnToolStripMenuItem.Click -= DanhSáchỦyQuyềnToolStripMenuItem_Click;
                }

                _DanhSáchỦyQuyềnToolStripMenuItem = value;
                if (_DanhSáchỦyQuyềnToolStripMenuItem != null)
                {
                    _DanhSáchỦyQuyềnToolStripMenuItem.Click += DanhSáchỦyQuyềnToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem != null)
                {
                    _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Click -= DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem_Click;
                }

                _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem = value;
                if (_DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem != null)
                {
                    _DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Click += DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _KếtQuảBiểuQuyếtToolStripMenuItem;

        internal ToolStripMenuItem KếtQuảBiểuQuyếtToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _KếtQuảBiểuQuyếtToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_KếtQuảBiểuQuyếtToolStripMenuItem != null)
                {
                    _KếtQuảBiểuQuyếtToolStripMenuItem.Click -= KếtQuảBiểuQuyếtToolStripMenuItem_Click;
                }

                _KếtQuảBiểuQuyếtToolStripMenuItem = value;
                if (_KếtQuảBiểuQuyếtToolStripMenuItem != null)
                {
                    _KếtQuảBiểuQuyếtToolStripMenuItem.Click += KếtQuảBiểuQuyếtToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DanhSáchVấnĐềBầuCửToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchVấnĐềBầuCửToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchVấnĐềBầuCửToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchVấnĐềBầuCửToolStripMenuItem != null)
                {
                    _DanhSáchVấnĐềBầuCửToolStripMenuItem.Click -= DanhSáchVấnĐềBầuCửToolStripMenuItem_Click;
                }

                _DanhSáchVấnĐềBầuCửToolStripMenuItem = value;
                if (_DanhSáchVấnĐềBầuCửToolStripMenuItem != null)
                {
                    _DanhSáchVấnĐềBầuCửToolStripMenuItem.Click += DanhSáchVấnĐềBầuCửToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DanhSáchỨngViênToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchỨngViênToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchỨngViênToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchỨngViênToolStripMenuItem != null)
                {
                    _DanhSáchỨngViênToolStripMenuItem.Click -= DanhSáchỨngViênToolStripMenuItem_Click;
                }

                _DanhSáchỨngViênToolStripMenuItem = value;
                if (_DanhSáchỨngViênToolStripMenuItem != null)
                {
                    _DanhSáchỨngViênToolStripMenuItem.Click += DanhSáchỨngViênToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _KếtQuảBầuCửToolStripMenuItem;

        internal ToolStripMenuItem KếtQuảBầuCửToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _KếtQuảBầuCửToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_KếtQuảBầuCửToolStripMenuItem != null)
                {
                    _KếtQuảBầuCửToolStripMenuItem.Click -= KếtQuảBầuCửToolStripMenuItem_Click;
                }

                _KếtQuảBầuCửToolStripMenuItem = value;
                if (_KếtQuảBầuCửToolStripMenuItem != null)
                {
                    _KếtQuảBầuCửToolStripMenuItem.Click += KếtQuảBầuCửToolStripMenuItem_Click;
                }
            }
        }

        internal ToolStripMenuItem HiểnThịToolStripMenuItem;
        internal StatusStrip MainStatusStrip;
        internal ToolStrip ToolStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        private ToolStripMenuItem _ToolStripMenuItem1;

        internal ToolStripMenuItem ToolStripMenuItem1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem1 != null)
                {
                    _ToolStripMenuItem1.Click -= ToolStripMenuItem1_Click;
                }

                _ToolStripMenuItem1 = value;
                if (_ToolStripMenuItem1 != null)
                {
                    _ToolStripMenuItem1.Click += ToolStripMenuItem1_Click;
                }
            }
        }

        private ToolStripMenuItem _DanhSáchPhiếuBầuCửToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchPhiếuBầuCửToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchPhiếuBầuCửToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchPhiếuBầuCửToolStripMenuItem != null)
                {
                    _DanhSáchPhiếuBầuCửToolStripMenuItem.Click -= DanhSáchPhiếuBầuCửToolStripMenuItem_Click;
                }

                _DanhSáchPhiếuBầuCửToolStripMenuItem = value;
                if (_DanhSáchPhiếuBầuCửToolStripMenuItem != null)
                {
                    _DanhSáchPhiếuBầuCửToolStripMenuItem.Click += DanhSáchPhiếuBầuCửToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ThôngTinCuộcHọpToolStripMenuItem;

        internal ToolStripMenuItem ThôngTinCuộcHọpToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ThôngTinCuộcHọpToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ThôngTinCuộcHọpToolStripMenuItem != null)
                {
                    _ThôngTinCuộcHọpToolStripMenuItem.Click -= ThôngTinCuộcHọpToolStripMenuItem_Click;
                }

                _ThôngTinCuộcHọpToolStripMenuItem = value;
                if (_ThôngTinCuộcHọpToolStripMenuItem != null)
                {
                    _ThôngTinCuộcHọpToolStripMenuItem.Click += ThôngTinCuộcHọpToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem;

        internal ToolStripMenuItem DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem != null)
                {
                    _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Click -= DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem_Click;
                }

                _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem = value;
                if (_DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem != null)
                {
                    _DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Click += DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem_Click;
                }
            }
        }

        internal ToolStripStatusLabel ToolStripStatusLabel3;
    }
}