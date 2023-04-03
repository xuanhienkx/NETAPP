<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MeetingList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Meetingcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Meetingname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompanyAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Meetingaddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.meetingtime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripButton4, Me.ToolStripSeparator2, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(898, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.pmDHCD.My.Resources.Resources.Add
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripButton1.Text = "Thêm(A)"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.pmDHCD.My.Resources.Resources.Document
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton2.Text = "Sửa(E)"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.pmDHCD.My.Resources.Resources.Delete
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripButton3.Text = "Xóa(D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(77, 22)
        Me.ToolStripLabel1.Text = "Mã cuộc họp"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.pmDHCD.My.Resources.Resources.Search
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(48, 22)
        Me.ToolStripButton4.Text = "Tìm"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.pmDHCD.My.Resources.Resources.officemac01
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripButton5.Text = "Chọn cuộc họp(S or Enter)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 415)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(898, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(106, 17)
        Me.ToolStripStatusLabel1.Text = "Số lượng bản ghi : "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Meetingcode, Me.Meetingname, Me.CompanyName, Me.CompanyAddress, Me.Meetingaddress, Me.meetingtime})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(898, 390)
        Me.DataGridView1.TabIndex = 4
        '
        'Meetingcode
        '
        Me.Meetingcode.DataPropertyName = "Meetingcode"
        Me.Meetingcode.FillWeight = 59.37841!
        Me.Meetingcode.HeaderText = "Mã cuộc họp"
        Me.Meetingcode.Name = "Meetingcode"
        Me.Meetingcode.ReadOnly = True
        '
        'Meetingname
        '
        Me.Meetingname.DataPropertyName = "Meetingname"
        Me.Meetingname.FillWeight = 65.68176!
        Me.Meetingname.HeaderText = "Tên cuộc họp"
        Me.Meetingname.MinimumWidth = 100
        Me.Meetingname.Name = "Meetingname"
        Me.Meetingname.ReadOnly = True
        '
        'CompanyName
        '
        Me.CompanyName.DataPropertyName = "CompanyName"
        Me.CompanyName.FillWeight = 138.3765!
        Me.CompanyName.HeaderText = "Tên công ty"
        Me.CompanyName.MinimumWidth = 8
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.ReadOnly = True
        '
        'CompanyAddress
        '
        Me.CompanyAddress.DataPropertyName = "CompanyAddress"
        Me.CompanyAddress.FillWeight = 79.50503!
        Me.CompanyAddress.HeaderText = "Đ/C công ty"
        Me.CompanyAddress.Name = "CompanyAddress"
        Me.CompanyAddress.ReadOnly = True
        '
        'Meetingaddress
        '
        Me.Meetingaddress.DataPropertyName = "Meetingaddress"
        Me.Meetingaddress.FillWeight = 24.77251!
        Me.Meetingaddress.HeaderText = "Địa điểm tổ chức"
        Me.Meetingaddress.Name = "Meetingaddress"
        Me.Meetingaddress.ReadOnly = True
        Me.Meetingaddress.Visible = False
        '
        'meetingtime
        '
        Me.meetingtime.DataPropertyName = "meetingtime"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.meetingtime.DefaultCellStyle = DataGridViewCellStyle2
        Me.meetingtime.FillWeight = 38.75047!
        Me.meetingtime.HeaderText = "Thời gian tổ chức"
        Me.meetingtime.Name = "meetingtime"
        Me.meetingtime.ReadOnly = True
        '
        'MeetingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 437)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "MeetingList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh sách cuộc họp"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Meetingcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Meetingname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Meetingaddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents meetingtime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
