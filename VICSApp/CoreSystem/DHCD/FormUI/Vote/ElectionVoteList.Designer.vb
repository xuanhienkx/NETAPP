<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ElectionVoteList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElectionVoteList))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripSplitButton3 = New System.Windows.Forms.ToolStripSplitButton
        Me.ToolStripStatusLabel15 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel16 = New System.Windows.Forms.ToolStripStatusLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Electioncode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.electionname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.delegatecode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Delegatename = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.candidatecode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.candidatename = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Votes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.ToolStripTextBox2, Me.ToolStripSeparator3, Me.ToolStripLabel3, Me.ToolStripTextBox3, Me.ToolStripSeparator4, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(833, 25)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.pmDHCD.My.Resources.Resources.Add
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripButton1.Text = "Thêm"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = Global.pmDHCD.My.Resources.Resources.Document
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripButton2.Text = "Sửa"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.pmDHCD.My.Resources.Resources.Delete
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButton3.Text = "Xóa"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(57, 22)
        Me.ToolStripLabel1.Text = "Mã bầu cử"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripLabel2.Text = "Mã đại biểu"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripLabel3.Text = "Mã ứng viên : "
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.pmDHCD.My.Resources.Resources.Search
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripButton4.Text = "Tìm"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripSplitButton3, Me.ToolStripStatusLabel15, Me.ToolStripStatusLabel16})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 497)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(833, 22)
        Me.StatusStrip1.TabIndex = 14
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
        'ToolStripSplitButton3
        '
        Me.ToolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripSplitButton3.Image = CType(resources.GetObject("ToolStripSplitButton3.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton3.Name = "ToolStripSplitButton3"
        Me.ToolStripSplitButton3.Size = New System.Drawing.Size(16, 20)
        Me.ToolStripSplitButton3.Text = "ToolStripSplitButton3"
        '
        'ToolStripStatusLabel15
        '
        Me.ToolStripStatusLabel15.Name = "ToolStripStatusLabel15"
        Me.ToolStripStatusLabel15.Size = New System.Drawing.Size(105, 17)
        Me.ToolStripStatusLabel15.Text = "Tổng số phiếu bầu : "
        '
        'ToolStripStatusLabel16
        '
        Me.ToolStripStatusLabel16.Name = "ToolStripStatusLabel16"
        Me.ToolStripStatusLabel16.Size = New System.Drawing.Size(117, 17)
        Me.ToolStripStatusLabel16.Text = "ToolStripStatusLabel16"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Electioncode, Me.electionname, Me.delegatecode, Me.Delegatename, Me.candidatecode, Me.candidatename, Me.Votes})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(833, 472)
        Me.DataGridView1.TabIndex = 15
        '
        'Electioncode
        '
        Me.Electioncode.DataPropertyName = "Electioncode"
        Me.Electioncode.FillWeight = 59.08628!
        Me.Electioncode.HeaderText = "Mã bầu cử"
        Me.Electioncode.Name = "Electioncode"
        Me.Electioncode.ReadOnly = True
        '
        'electionname
        '
        Me.electionname.DataPropertyName = "electionname"
        Me.electionname.FillWeight = 59.08628!
        Me.electionname.HeaderText = "Tên bầu cử"
        Me.electionname.Name = "electionname"
        Me.electionname.ReadOnly = True
        '
        'delegatecode
        '
        Me.delegatecode.DataPropertyName = "delegatecode"
        Me.delegatecode.HeaderText = "Mã đại biểu"
        Me.delegatecode.Name = "delegatecode"
        Me.delegatecode.ReadOnly = True
        '
        'Delegatename
        '
        Me.Delegatename.DataPropertyName = "Delegatename"
        Me.Delegatename.HeaderText = "Tên đại biểu"
        Me.Delegatename.Name = "Delegatename"
        Me.Delegatename.ReadOnly = True
        '
        'candidatecode
        '
        Me.candidatecode.DataPropertyName = "candidatecode"
        DataGridViewCellStyle2.Format = "N0"
        Me.candidatecode.DefaultCellStyle = DataGridViewCellStyle2
        Me.candidatecode.HeaderText = "Mã ứng viên"
        Me.candidatecode.Name = "candidatecode"
        Me.candidatecode.ReadOnly = True
        '
        'candidatename
        '
        Me.candidatename.DataPropertyName = "candidatename"
        Me.candidatename.HeaderText = "Tên ứng viên"
        Me.candidatename.Name = "candidatename"
        Me.candidatename.ReadOnly = True
        '
        'Votes
        '
        Me.Votes.DataPropertyName = "Votes"
        DataGridViewCellStyle3.Format = "N0"
        Me.Votes.DefaultCellStyle = DataGridViewCellStyle3
        Me.Votes.HeaderText = "Số phiếu bầu"
        Me.Votes.Name = "Votes"
        Me.Votes.ReadOnly = True
        '
        'ElectionVoteList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 519)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "ElectionVoteList"
        Me.Text = "Danh sách phiếu bầu cử"
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
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSplitButton3 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripStatusLabel15 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel16 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Electioncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents electionname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents delegatecode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delegatename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents candidatecode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents candidatename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Votes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
