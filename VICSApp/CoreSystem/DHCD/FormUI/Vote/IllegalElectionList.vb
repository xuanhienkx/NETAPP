Public Class IllegalElectionList

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        filldgv()
    End Sub

    Private Sub IllegalElectionList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Mainform
        filldgv()
    End Sub
    Public Sub filldgv()
        Dim t As New DataTable
        Try
            Dim delecode As Integer = 0
            Dim eleccode As Integer = 0
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

            t = Mainform.BenlyDal.IllegalElectionVotes_getlist(Mainform.workingmeeting, eleccode, delecode)

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

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
            Exit Sub
        Else
            If MsgBox("Bạn có chắc chắn XÓA phiếu bầu KHÔNG HỢP LỆ của đại biểu : " + DataGridView1.CurrentRow.Cells("Delegatename").Value, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA CỔ ĐÔNG") = MsgBoxResult.Ok Then
                Try
                    Mainform.BenlyDal.IllegalElectionVotes_delete(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Electioncode").Value, DataGridView1.CurrentRow.Cells("delegatecode").Value)
                Catch ex As Exception
                    MsgBox("Lỗi : " + ex.Message)
                End Try
            End If

        End If
        filldgv()
    End Sub
End Class