Public Class Elections_result

    Private Sub Elections_result_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Mainform
        filldgv()
    End Sub
    Private Sub filldgv()

        Dim dt As New DataTable

        Try
            dt = Mainform.BenlyDal.ElectionVotes_getresult(Mainform.workingmeeting, NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        dt.Columns.Remove("Totalvotes")
        DataGridView1.DataSource = dt
        ToolStripStatusLabel2.Text = DataGridView1.RowCount
        Dim totalright As Decimal = 0
        For Each dr As DataRow In dt.Rows
            totalright = totalright + dr.Item("sumVotes")
        Next

        ToolStripStatusLabel4.Text = Mainform.addthousandseperator(totalright.ToString)

        Dim info As New BenlyDAL.BenlyDAL.DAL.ElectionVoteInfo
        Try
            info = Mainform.BenlyDal.ElectionVotes_Infor_get(Mainform.workingmeeting, NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        ToolStripStatusLabel6.Text = info.numberoflegalVote
        ToolStripStatusLabel8.Text = info.numberoflegalVote.ToString + " "
        ToolStripStatusLabel11.Text = info.numberofIllegalVote.ToString + " "
        If info.SummeetingVoteRight > 0 Then

            ToolStripStatusLabel9.Text = (info.LegalVoteRights * 100 / info.SummeetingVoteRight).ToString("n2") + "%"
            ToolStripStatusLabel12.Text = (info.IllegalVoteRights * 100 / info.SummeetingVoteRight).ToString("n2") + "%"
        End If
        'MsgBox("info.LegalVoteRights" + info.LegalVoteRights.ToString + "   IllegalVoteRights" + info.IllegalVoteRights.ToString + "   SummeetingVoteRight " + info.SummeetingVoteRight.ToString)

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Election_getlist(Mainform.workingmeeting, NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        If dt.Rows.Count = 1 Then
            MaskedTextBox3.Text = dt.Rows(0).Item("Electionname")
            MaskedTextBox6.Text = dt.Rows(0).Item("Numofcandidates")
        End If
        filldgv()


    End Sub
End Class