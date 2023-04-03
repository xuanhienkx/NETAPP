<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainform))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HệThốngToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuộcHọpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchCuộcHọpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchCổĐôngToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchĐạiBiểuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchỦyQuyềnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThôngTinCuộcHọpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BiểuQuyếtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KếtQuảBiểuQuyếtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BầuCửToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchVấnĐềBầuCửToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchỨngViênToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchPhiếuBầuCửToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KếtQuảBầuCửToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HiểnThịToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.MainStatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HệThốngToolStripMenuItem, Me.CuộcHọpToolStripMenuItem, Me.BiểuQuyếtToolStripMenuItem, Me.BầuCửToolStripMenuItem, Me.HiểnThịToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1456, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HệThốngToolStripMenuItem
        '
        Me.HệThốngToolStripMenuItem.Name = "HệThốngToolStripMenuItem"
        Me.HệThốngToolStripMenuItem.Size = New System.Drawing.Size(94, 24)
        Me.HệThốngToolStripMenuItem.Text = "&1.Hệ thống"
        '
        'CuộcHọpToolStripMenuItem
        '
        Me.CuộcHọpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DanhSáchCuộcHọpToolStripMenuItem, Me.DanhSáchCổĐôngToolStripMenuItem, Me.DanhSáchĐạiBiểuToolStripMenuItem, Me.DanhSáchỦyQuyềnToolStripMenuItem, Me.ThôngTinCuộcHọpToolStripMenuItem})
        Me.CuộcHọpToolStripMenuItem.Name = "CuộcHọpToolStripMenuItem"
        Me.CuộcHọpToolStripMenuItem.Size = New System.Drawing.Size(99, 24)
        Me.CuộcHọpToolStripMenuItem.Text = "&2.Cuộc họp "
        '
        'DanhSáchCuộcHọpToolStripMenuItem
        '
        Me.DanhSáchCuộcHọpToolStripMenuItem.Name = "DanhSáchCuộcHọpToolStripMenuItem"
        Me.DanhSáchCuộcHọpToolStripMenuItem.Size = New System.Drawing.Size(226, 24)
        Me.DanhSáchCuộcHọpToolStripMenuItem.Text = "1. Danh sách cuộc họp"
        '
        'DanhSáchCổĐôngToolStripMenuItem
        '
        Me.DanhSáchCổĐôngToolStripMenuItem.Name = "DanhSáchCổĐôngToolStripMenuItem"
        Me.DanhSáchCổĐôngToolStripMenuItem.Size = New System.Drawing.Size(226, 24)
        Me.DanhSáchCổĐôngToolStripMenuItem.Text = "2. Danh sách cổ đông"
        '
        'DanhSáchĐạiBiểuToolStripMenuItem
        '
        Me.DanhSáchĐạiBiểuToolStripMenuItem.Name = "DanhSáchĐạiBiểuToolStripMenuItem"
        Me.DanhSáchĐạiBiểuToolStripMenuItem.Size = New System.Drawing.Size(226, 24)
        Me.DanhSáchĐạiBiểuToolStripMenuItem.Text = "3. Danh sách đại biểu"
        '
        'DanhSáchỦyQuyềnToolStripMenuItem
        '
        Me.DanhSáchỦyQuyềnToolStripMenuItem.Name = "DanhSáchỦyQuyềnToolStripMenuItem"
        Me.DanhSáchỦyQuyềnToolStripMenuItem.Size = New System.Drawing.Size(226, 24)
        Me.DanhSáchỦyQuyềnToolStripMenuItem.Text = "4. Danh sách ủy quyền"
        '
        'ThôngTinCuộcHọpToolStripMenuItem
        '
        Me.ThôngTinCuộcHọpToolStripMenuItem.Name = "ThôngTinCuộcHọpToolStripMenuItem"
        Me.ThôngTinCuộcHọpToolStripMenuItem.Size = New System.Drawing.Size(226, 24)
        Me.ThôngTinCuộcHọpToolStripMenuItem.Text = "5. Thông tin cuộc họp"
        '
        'BiểuQuyếtToolStripMenuItem
        '
        Me.BiểuQuyếtToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem, Me.ToolStripMenuItem1, Me.KếtQuảBiểuQuyếtToolStripMenuItem})
        Me.BiểuQuyếtToolStripMenuItem.Name = "BiểuQuyếtToolStripMenuItem"
        Me.BiểuQuyếtToolStripMenuItem.Size = New System.Drawing.Size(102, 24)
        Me.BiểuQuyếtToolStripMenuItem.Text = "&3.Biểu quyết"
        '
        'DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem
        '
        Me.DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Name = "DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem"
        Me.DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Size = New System.Drawing.Size(283, 24)
        Me.DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem.Text = "1. Danh sách vấn đề biểu quyết"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(283, 24)
        Me.ToolStripMenuItem1.Text = "2. Danh sách phiếu biểu quyết"
        '
        'KếtQuảBiểuQuyếtToolStripMenuItem
        '
        Me.KếtQuảBiểuQuyếtToolStripMenuItem.Name = "KếtQuảBiểuQuyếtToolStripMenuItem"
        Me.KếtQuảBiểuQuyếtToolStripMenuItem.Size = New System.Drawing.Size(283, 24)
        Me.KếtQuảBiểuQuyếtToolStripMenuItem.Text = "3. Kết quả biểu quyết"
        '
        'BầuCửToolStripMenuItem
        '
        Me.BầuCửToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DanhSáchVấnĐềBầuCửToolStripMenuItem, Me.DanhSáchỨngViênToolStripMenuItem, Me.DanhSáchPhiếuBầuCửToolStripMenuItem, Me.KếtQuảBầuCửToolStripMenuItem, Me.DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem})
        Me.BầuCửToolStripMenuItem.Name = "BầuCửToolStripMenuItem"
        Me.BầuCửToolStripMenuItem.Size = New System.Drawing.Size(77, 24)
        Me.BầuCửToolStripMenuItem.Text = "&4.Bầu cử"
        '
        'DanhSáchVấnĐềBầuCửToolStripMenuItem
        '
        Me.DanhSáchVấnĐềBầuCửToolStripMenuItem.Name = "DanhSáchVấnĐềBầuCửToolStripMenuItem"
        Me.DanhSáchVấnĐềBầuCửToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.DanhSáchVấnĐềBầuCửToolStripMenuItem.Text = "1. Danh sách vấn đề bầu cử"
        '
        'DanhSáchỨngViênToolStripMenuItem
        '
        Me.DanhSáchỨngViênToolStripMenuItem.Name = "DanhSáchỨngViênToolStripMenuItem"
        Me.DanhSáchỨngViênToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.DanhSáchỨngViênToolStripMenuItem.Text = "2. Danh sách ứng viên"
        '
        'DanhSáchPhiếuBầuCửToolStripMenuItem
        '
        Me.DanhSáchPhiếuBầuCửToolStripMenuItem.Name = "DanhSáchPhiếuBầuCửToolStripMenuItem"
        Me.DanhSáchPhiếuBầuCửToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.DanhSáchPhiếuBầuCửToolStripMenuItem.Text = "3. Danh sách phiếu bầu cử"
        '
        'KếtQuảBầuCửToolStripMenuItem
        '
        Me.KếtQuảBầuCửToolStripMenuItem.Name = "KếtQuảBầuCửToolStripMenuItem"
        Me.KếtQuảBầuCửToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.KếtQuảBầuCửToolStripMenuItem.Text = "4. Kết quả bầu cử"
        '
        'DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem
        '
        Me.DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Name = "DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem"
        Me.DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem.Text = "5. Danh sách phiếu bầu KHÔNG hợp lệ"
        '
        'HiểnThịToolStripMenuItem
        '
        Me.HiểnThịToolStripMenuItem.Name = "HiểnThịToolStripMenuItem"
        Me.HiểnThịToolStripMenuItem.Size = New System.Drawing.Size(84, 24)
        Me.HiểnThịToolStripMenuItem.Text = "&5.Hiển thị"
        Me.HiểnThịToolStripMenuItem.Visible = False
        '
        'MainStatusStrip
        '
        Me.MainStatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.MainStatusStrip.Location = New System.Drawing.Point(0, 827)
        Me.MainStatusStrip.Name = "MainStatusStrip"
        Me.MainStatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.MainStatusStrip.Size = New System.Drawing.Size(1456, 25)
        Me.MainStatusStrip.TabIndex = 1
        Me.MainStatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(106, 20)
        Me.ToolStripStatusLabel1.Text = "Mã cuộc họp : "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 20)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1456, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(154, 20)
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'Mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1456, 852)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MainStatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Mainform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Phần mềm họp đại hội cổ đông"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MainStatusStrip.ResumeLayout(False)
        Me.MainStatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HệThốngToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuộcHọpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchCuộcHọpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BiểuQuyếtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BầuCửToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchCổĐôngToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchĐạiBiểuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchỦyQuyềnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchVấnĐềBiểuQuyếtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KếtQuảBiểuQuyếtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchVấnĐềBầuCửToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchỨngViênToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KếtQuảBầuCửToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HiểnThịToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchPhiếuBầuCửToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThôngTinCuộcHọpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchPhiếuBầuKhôngHợpLệToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel

End Class
