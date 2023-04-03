Public Class CandidateList
    WithEvents nud1 As New NumericUpDown
    Private Sub CandidateList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Mainform
        filldgv()
        nud1.Minimum = 1
        nud1.Maximum = 10
        nud1.Increment = 1
        ToolStrip1.Items.Insert(6, New ToolStripControlHost(nud1))
    End Sub
    Private Sub filldgv()
        Try
            DataGridView1.DataSource = Mainform.BenlyDal.Candidates_getlist(Mainform.workingmeeting, nud1.Value, 0)
            ToolStripStatusLabel2.Text = DataGridView1.RowCount
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        filldgv()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim f As New Candidates_ins_update("Add", 0, 0)
        f.Show()
        filldgv()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
        Else
            Dim f As New Candidates_ins_update("Update", DataGridView1.CurrentRow.Cells("Electioncode").Value, DataGridView1.CurrentRow.Cells("Candidatecode").Value)
            f.Show()

        End If
        filldgv()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
        Else
            If MsgBox("Bạn có chắc chắn XÓA ứng viên :" + DataGridView1.CurrentRow.Cells("candidatename").Value, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA CỔ ĐÔNG") = MsgBoxResult.Ok Then
                Try
                    Mainform.BenlyDal.Candidate_delete(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Electioncode").Value, DataGridView1.CurrentRow.Cells("Candidatecode").Value)
                Catch ex As Exception
                    MsgBox("Lỗi :" + ex.Message)
                End Try
            End If
           
        End If
        filldgv()
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nud1.ValueChanged
        filldgv()
    End Sub
End Class