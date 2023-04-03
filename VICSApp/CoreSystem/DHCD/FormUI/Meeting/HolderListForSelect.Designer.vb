<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HolderListForSelect
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.holdercode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HolderName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HolderIdentity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HolderAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.holdercode, Me.HolderName, Me.HolderIdentity, Me.HolderAddress})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(625, 290)
        Me.DataGridView1.TabIndex = 5
        '
        'holdercode
        '
        Me.holdercode.DataPropertyName = "holdercode"
        Me.holdercode.FillWeight = 59.08628!
        Me.holdercode.HeaderText = "Mã cổ đông"
        Me.holdercode.Name = "holdercode"
        Me.holdercode.ReadOnly = True
        Me.holdercode.Width = 50
        '
        'HolderName
        '
        Me.HolderName.DataPropertyName = "HolderName"
        Me.HolderName.FillWeight = 59.08628!
        Me.HolderName.HeaderText = "Tên cổ đông"
        Me.HolderName.Name = "HolderName"
        Me.HolderName.ReadOnly = True
        Me.HolderName.Width = 120
        '
        'HolderIdentity
        '
        Me.HolderIdentity.DataPropertyName = "HolderIdentity"
        Me.HolderIdentity.FillWeight = 59.08628!
        Me.HolderIdentity.HeaderText = "CMT/GPKD"
        Me.HolderIdentity.Name = "HolderIdentity"
        Me.HolderIdentity.ReadOnly = True
        Me.HolderIdentity.Width = 94
        '
        'HolderAddress
        '
        Me.HolderAddress.DataPropertyName = "HolderAddress"
        Me.HolderAddress.FillWeight = 200.0!
        Me.HolderAddress.HeaderText = "Địa chỉ"
        Me.HolderAddress.Name = "HolderAddress"
        Me.HolderAddress.ReadOnly = True
        Me.HolderAddress.Width = 319
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 268)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(625, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(97, 17)
        Me.ToolStripStatusLabel1.Text = "Số lượng bản ghi : "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'HolderListForSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 290)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "HolderListForSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn cổ đông"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents holdercode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HolderName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HolderIdentity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HolderAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
