Public Class ElectionList

    Private Sub ElectionList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Mainform
        filldgv()
    End Sub
    Private Sub filldgv()
        Try
            DataGridView1.DataSource = Mainform.BenlyDal.Election_getlist(Mainform.workingmeeting, 0)
            ToolStripStatusLabel2.Text = DataGridView1.RowCount
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim f As New election_ins_update("Add", 1)
        f.ShowDialog()
        filldgv()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn một bản ghi")
        Else
            Dim f As New election_ins_update("Update", DataGridView1.CurrentRow.Cells("Electioncode").Value)
            f.ShowDialog()
            filldgv()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn một bản ghi")
        Else
            If MsgBox("Bạn có chắc chắn XÓA cuộc bầu cử :" + DataGridView1.CurrentRow.Cells("Electionname").Value, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA CUỘC BẦU CỬ") = MsgBoxResult.Ok Then
                Try
                    Mainform.BenlyDal.Election_delete(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("electioncode").Value)
                Catch ex As Exception
                    MsgBox("Lỗi" + ex.Message)
                End Try
            End If
            
            filldgv()
        End If
    End Sub
End Class