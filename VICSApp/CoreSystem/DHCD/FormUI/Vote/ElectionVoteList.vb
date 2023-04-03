Public Class ElectionVoteList

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        filldgv()
    End Sub

    Public Sub filldgv()
        Dim t As New DataTable
        Try
            Dim delecode As Integer = 0
            Dim eleccode As Integer = 0
            Dim candicode As Integer = 0
            Try
                eleccode = ToolStripTextBox1.Text
            Catch ex As Exception
                eleccode = 0
            End Try
            Try
                delecode = ToolStripTextBox2.Text
            Catch ex As Exception
                delecode = 0
            End Try

            Try
                candicode = ToolStripTextBox3.Text
            Catch ex As Exception
                candicode = 0
            End Try

            t = Mainform.BenlyDal.ElectionVotes_getlist(Mainform.workingmeeting, eleccode, delecode, candicode)

        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
        DataGridView1.DataSource = t
        ToolStripStatusLabel2.Text = DataGridView1.RowCount
        Dim totalright As Integer = 0
        For Each dr As DataRow In t.Rows
            totalright = totalright + dr.Item("Votes")
        Next

        ToolStripStatusLabel16.Text = Mainform.addthousandseperator(totalright.ToString)


    End Sub

    Private Sub ElectionVoteList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Mainform
        filldgv()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
            Exit Sub
        Else
            If MsgBox("Bạn có chắc chắn XÓA phiếu bầu của đại biểu : " + DataGridView1.CurrentRow.Cells("Delegatename").Value, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA CỔ ĐÔNG") = MsgBoxResult.Ok Then
                Try
                    Mainform.BenlyDal.ElectionVotes_delete_all(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Electioncode").Value, DataGridView1.CurrentRow.Cells("delegatecode").Value, DataGridView1.CurrentRow.Cells("Candidatecode").Value)
                Catch ex As Exception
                    MsgBox("Lỗi : " + ex.Message)
                End Try
            End If

        End If
        filldgv()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim f As New Electionvote_ins_update("Add", 0, 0)
        f.ShowDialog()
        filldgv()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
            Exit Sub
        End If
        Dim f As New Electionvote_ins_update("Update", DataGridView1.CurrentRow.Cells("Electioncode").Value, DataGridView1.CurrentRow.Cells("delegatecode").Value)
        f.ShowDialog()
        filldgv()
    End Sub
End Class