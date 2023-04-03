<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuthorizationList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AuthorizationList))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripTextBox4 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripSplitButton2 = New System.Windows.Forms.ToolStripSplitButton
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Holdercode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.holdername = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HolderIdentity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HolderAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Delegatecode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Delegatename = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdentityCard = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelegateAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.voterights = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelegateRight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.ToolStripTextBox2, Me.ToolStripSeparator2, Me.ToolStripLabel4, Me.ToolStripTextBox4, Me.ToolStripSeparator3, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(940, 25)
        Me.ToolStrip1.TabIndex = 4
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
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripLabel2.Text = "CMT/HC đại biểu"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(137, 22)
        Me.ToolStripLabel4.Text = "CMT/HC/GPKD cổ đông"
        '
        'ToolStripTextBox4
        '
        Me.ToolStripTextBox4.Name = "ToolStripTextBox4"
        Me.ToolStripTextBox4.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.pmDHCD.My.Resources.Resources.Search
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(48, 22)
        Me.ToolStripButton5.Text = "Tìm"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = Global.pmDHCD.My.Resources.Resources.Search
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripButton6.Text = "In thẻ BQ"
        Me.ToolStripButton6.Visible = False
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.pmDHCD.My.Resources.Resources.Search
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripButton4.Text = "In giấy x.nhận t.dự"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripSplitButton1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripSplitButton2, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 441)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(940, 22)
        Me.StatusStrip1.TabIndex = 8
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
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(16, 20)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(195, 17)
        Me.ToolStripStatusLabel3.Text = "Tổng số quyền biểu quyết của CĐ : "
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripSplitButton2
        '
        Me.ToolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripSplitButton2.Image = CType(resources.GetObject("ToolStripSplitButton2.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton2.Name = "ToolStripSplitButton2"
        Me.ToolStripSplitButton2.Size = New System.Drawing.Size(16, 20)
        Me.ToolStripSplitButton2.Text = "ToolStripSplitButton2"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(236, 17)
        Me.ToolStripStatusLabel5.Text = "Tổng số quyền biểu quyết được ủy quyền : "
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel6.Text = "ToolStripStatusLabel6"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Holdercode, Me.holdername, Me.HolderIdentity, Me.HolderAddress, Me.Delegatecode, Me.Delegatename, Me.IdentityCard, Me.DelegateAddress, Me.voterights, Me.DelegateRight})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(940, 416)
        Me.DataGridView1.TabIndex = 9
        '
        'Holdercode
        '
        Me.Holdercode.DataPropertyName = "Holdercode"
        Me.Holdercode.FillWeight = 11.21656!
        Me.Holdercode.HeaderText = "Mã cổ đông"
        Me.Holdercode.MinimumWidth = 80
        Me.Holdercode.Name = "Holdercode"
        Me.Holdercode.ReadOnly = True
        '
        'holdername
        '
        Me.holdername.DataPropertyName = "holdername"
        Me.holdername.FillWeight = 196.5355!
        Me.holdername.HeaderText = "Tên cổ đông"
        Me.holdername.MinimumWidth = 150
        Me.holdername.Name = "holdername"
        Me.holdername.ReadOnly = True
        '
        'HolderIdentity
        '
        Me.HolderIdentity.DataPropertyName = "HolderIdentity"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.HolderIdentity.DefaultCellStyle = DataGridViewCellStyle2
        Me.HolderIdentity.FillWeight = 97.21734!
        Me.HolderIdentity.HeaderText = "CMT/HC/GPKD CĐ"
        Me.HolderIdentity.MinimumWidth = 100
        Me.HolderIdentity.Name = "HolderIdentity"
        Me.HolderIdentity.ReadOnly = True
        '
        'HolderAddress
        '
        Me.HolderAddress.DataPropertyName = "HolderAddress"
        Me.HolderAddress.HeaderText = "HolderAddress"
        Me.HolderAddress.Name = "HolderAddress"
        Me.HolderAddress.ReadOnly = True
        Me.HolderAddress.Visible = False
        '
        'Delegatecode
        '
        Me.Delegatecode.DataPropertyName = "Delegatecode"
        Me.Delegatecode.FillWeight = 74.75592!
        Me.Delegatecode.HeaderText = "Mã đại biểu"
        Me.Delegatecode.MinimumWidth = 80
        Me.Delegatecode.Name = "Delegatecode"
        Me.Delegatecode.ReadOnly = True
        '
        'Delegatename
        '
        Me.Delegatename.DataPropertyName = "Delegatename"
        Me.Delegatename.FillWeight = 6.621332!
        Me.Delegatename.HeaderText = "Tên đại biểu"
        Me.Delegatename.MinimumWidth = 200
        Me.Delegatename.Name = "Delegatename"
        Me.Delegatename.ReadOnly = True
        '
        'IdentityCard
        '
        Me.IdentityCard.DataPropertyName = "IdentityCard"
        Me.IdentityCard.FillWeight = 52.32525!
        Me.IdentityCard.HeaderText = "CMT/HC ĐB"
        Me.IdentityCard.MinimumWidth = 100
        Me.IdentityCard.Name = "IdentityCard"
        Me.IdentityCard.ReadOnly = True
        '
        'DelegateAddress
        '
        Me.DelegateAddress.DataPropertyName = "DelegateAddress"
        Me.DelegateAddress.HeaderText = "DelegateAddress"
        Me.DelegateAddress.Name = "DelegateAddress"
        Me.DelegateAddress.ReadOnly = True
        Me.DelegateAddress.Visible = False
        '
        'voterights
        '
        Me.voterights.DataPropertyName = "voterights"
        DataGridViewCellStyle3.Format = "N0"
        Me.voterights.DefaultCellStyle = DataGridViewCellStyle3
        Me.voterights.FillWeight = 128.2284!
        Me.voterights.HeaderText = "Số quyền BQ CĐ"
        Me.voterights.MinimumWidth = 40
        Me.voterights.Name = "voterights"
        Me.voterights.ReadOnly = True
        '
        'DelegateRight
        '
        Me.DelegateRight.DataPropertyName = "DelegateRight"
        DataGridViewCellStyle4.Format = "N0"
        Me.DelegateRight.DefaultCellStyle = DataGridViewCellStyle4
        Me.DelegateRight.FillWeight = 169.4455!
        Me.DelegateRight.HeaderText = "Số quyền BQ ủy quyền"
        Me.DelegateRight.MinimumWidth = 40
        Me.DelegateRight.Name = "DelegateRight"
        Me.DelegateRight.ReadOnly = True
        '
        'AuthorizationList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 463)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "AuthorizationList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh sách ủy quyền"
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
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox4 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSplitButton2 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Holdercode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents holdername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HolderIdentity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HolderAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delegatecode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delegatename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdentityCard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelegateAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents voterights As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelegateRight As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
