Public Class AuthorizationListForSelect
    Dim strHolderIdentifyCard As String
    Dim strDelegateIdentifyCard As String

    Public Property HolderIdentifyCard()
        Get
            Return strHolderIdentifyCard
        End Get
        Set(ByVal value)
            strHolderIdentifyCard = value
        End Set
    End Property

    Public Property DelegateIdentifyCard()
        Get
            Return strDelegateIdentifyCard
        End Get
        Set(ByVal value)
            strDelegateIdentifyCard = value
        End Set
    End Property

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filldgv()
    End Sub
    Private Sub filldgv()
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, 0, "", strDelegateIdentifyCard, strHolderIdentifyCard)

        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
        DataGridView1.DataSource = dt
        ToolStripStatusLabel2.Text = DataGridView1.RowCount
        Dim sumshares As Integer = 0
        Dim sumvoterights As Integer = 0

        For Each dr As DataRow In dt.Rows
            'sumshares = sumshares + dr.Item("Shares")
            sumvoterights = sumvoterights + dr.Item("Delegateright")
        Next
        'ToolStripStatusLabel4.Text = Mainform.addthousandseperator(sumshares.ToString)
        'ToolStripStatusLabel6.Text = Mainform.addthousandseperator(sumvoterights.ToString)
    End Sub


    Private Sub HolderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        filldgv()
        'Me.MdiParent = Mainform
    End Sub


    Private Sub HolderListForSelect_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.Close()
        End If
    End Sub
End Class