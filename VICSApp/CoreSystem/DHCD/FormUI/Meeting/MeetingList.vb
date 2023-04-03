Public Class MeetingList

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        filldgv()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim f As New Meeting_ins_update("Add", "")
        f.ShowDialog()
        filldgv()
    End Sub
    Private Sub filldgv()
        Try
            DataGridView1.DataSource = Mainform.BenlyDal.Meeting_getlist(ToolStripTextBox1.Text)
            ToolStripStatusLabel2.Text = DataGridView1.RowCount
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
    End Sub

    Private Sub MeetingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        filldgv()
        Me.MdiParent = Mainform
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
        Else
            Dim f As New Meeting_ins_update("Update", DataGridView1.CurrentRow.Cells("Meetingcode").Value)
            f.ShowDialog()
            filldgv()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc chắn cuộc họp :" + DataGridView1.CurrentRow.Cells("Meetingcode").Value + " ---- " + DataGridView1.CurrentRow.Cells("Meetingname").Value, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA CỔ ĐÔNG") = MsgBoxResult.Ok Then
            Try
                Mainform.BenlyDal.meeting_delete(DataGridView1.CurrentRow.Cells("Meetingcode").Value)
                Mainform.dateMeeting = DateTime.Parse(DataGridView1.CurrentRow.Cells("MeetingTime").Value)
                Mainform.ToolStripStatusLabel2.Text = DataGridView1.CurrentRow.Cells("Meetingcode").Value
                Mainform.ToolStripStatusLabel3.Text = DataGridView1.CurrentRow.Cells("MeetingTime").Value
                filldgv()
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
            End Try

        End If
        
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Mainform.workingmeeting = DataGridView1.CurrentRow.Cells("Meetingcode").Value
        Mainform.dateMeeting = DateTime.Parse(DataGridView1.CurrentRow.Cells("MeetingTime").Value)
        Mainform.ToolStripStatusLabel2.Text = DataGridView1.CurrentRow.Cells("Meetingcode").Value
        Mainform.ToolStripStatusLabel3.Text = DataGridView1.CurrentRow.Cells("MeetingTime").Value
        Me.Close()
    End Sub

    Private Sub MeetingList_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If Not (ToolStripTextBox1.Focused Or ToolStripTextBox1.Focused) Then
            Select Case e.KeyCode
                Case Keys.A
                    ToolStripButton1_Click(sender, e)
                Case Keys.E
                    ToolStripButton2_Click(sender, e)
                Case Keys.D
                    ToolStripButton3_Click(sender, e)
                Case Keys.S
                    ToolStripButton5_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Mainform.workingmeeting = DataGridView1.CurrentRow.Cells("Meetingcode").Value
            Mainform.ToolStripStatusLabel2.Text = DataGridView1.CurrentRow.Cells("Meetingcode").Value
            Mainform.dateMeeting = DateTime.Parse(DataGridView1.CurrentRow.Cells("MeetingTime").Value)
            Mainform.ToolStripStatusLabel2.Text = DataGridView1.CurrentRow.Cells("Meetingcode").Value
            Mainform.ToolStripStatusLabel3.Text = DataGridView1.CurrentRow.Cells("MeetingTime").Value
            Me.Close()
        End If

    End Sub
End Class