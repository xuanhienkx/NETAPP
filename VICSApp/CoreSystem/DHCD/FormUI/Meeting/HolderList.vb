Public Class HolderList

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        filldgv()
    End Sub
    Private Sub filldgv()
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Holder_getlist(Mainform.workingmeeting, ToolStripTextBox1.Text, ToolStripTextBox2.Text)

        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
        DataGridView1.DataSource = dt
        ToolStripStatusLabel2.Text = DataGridView1.RowCount
        Dim sumshares As Integer = 0
        Dim sumvoterights As Integer = 0

        For Each dr As DataRow In dt.Rows
            sumshares = sumshares + dr.Item("Shares")
            sumvoterights = sumvoterights + dr.Item("Voterights")
        Next
        ToolStripStatusLabel4.Text = Mainform.addthousandseperator(sumshares.ToString)
        ToolStripStatusLabel6.Text = Mainform.addthousandseperator(sumvoterights.ToString)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc chắn XÓA cổ đông :" + DataGridView1.CurrentRow.Cells("Holdercode").Value + " ---- " + DataGridView1.CurrentRow.Cells("Holdername").Value, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA CỔ ĐÔNG") = MsgBoxResult.Ok Then
            Try
                Mainform.BenlyDal.Holder_delete(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Holdercode").Value)
                filldgv()
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
            End Try
        End If

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim f As New Holder_ins_update("Add", "")
        f.ShowDialog()
        filldgv()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim f As New Holder_ins_update("Update", DataGridView1.CurrentRow.Cells("Holdercode").Value)
        f.ShowDialog()
        filldgv()
    End Sub

    Private Sub HolderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        filldgv()
        Me.MdiParent = Mainform
    End Sub

    Private Sub HolderList_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If Not (ToolStripTextBox1.Focused Or ToolStripTextBox2.Focused) Then
            Select Case e.KeyCode
                Case Keys.A
                    ToolStripButton1_Click(sender, e)
                Case Keys.E
                    ToolStripButton2_Click(sender, e)
                Case Keys.D
                    ToolStripButton3_Click(sender, e)
                Case Keys.P
                    ToolStripButton5_Click(sender, e)
                Case Keys.Escape

                    Me.Close()
            End Select
        End If

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim objPrintHolders As New PrintHolders()
        objPrintHolders.ShowDialog()


    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click

        Dim cr_thebieuquyet As New thebieuquyet_2
        Dim objCommon As New clsCommon()

        Dim strDelegateCode As String = DataGridView1.CurrentRow.Cells("holdercode").Value
        Dim strDelegateName As String = DataGridView1.CurrentRow.Cells("HolderName").Value.ToString.ToUpper()
        Dim strIdentityCard As String = DataGridView1.CurrentRow.Cells("HolderIdentity").Value
        Dim DelegateAddress As String = DataGridView1.CurrentRow.Cells("HolderAddress").Value
        Dim strHoldercode As String
        Dim strVoterights As String = Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value)
        Dim strVoteRightString As String = objCommon.num2Text(DataGridView1.CurrentRow.Cells("voterights").Value.ToString())
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("holdercode").Value, "", "", "")
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        Dim str As String = ""
        If dt.Rows.Count = 1 Then
            str = dt.Rows(0).Item("Holdercode")
        Else
            For Each dr As DataRow In dt.Rows
                str = str + dr.Item("Holdercode").ToString + " (" + Mainform.addthousandseperator(dr.Item("voterights").ToString) + " CP); "
            Next
        End If
        strHoldercode = str
        cr_thebieuquyet.SetParameterValue("Delegatecode", strDelegateCode)
        cr_thebieuquyet.SetParameterValue("HolderName", strDelegateName)
        cr_thebieuquyet.SetParameterValue("Delegatename", strDelegateName)
        cr_thebieuquyet.SetParameterValue("IdentityCard", strIdentityCard)
        cr_thebieuquyet.SetParameterValue("Address", DelegateAddress)
        cr_thebieuquyet.SetParameterValue("Holdercode", strHoldercode)
        cr_thebieuquyet.SetParameterValue("voterights", strVoterights)
        cr_thebieuquyet.SetParameterValue("DateMeeting", Mainform.dateMeeting)
        ReportViewer.LoadReport(cr_thebieuquyet, Me)
        End Sub


    Private Sub ToolStripTextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox2.KeyUp
        If e.KeyCode = Keys.Enter Then
            filldgv()
        End If
    End Sub

    Private Sub ToolStripTextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            filldgv()
        End If

    End Sub
End Class