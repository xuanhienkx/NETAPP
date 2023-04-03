Public Class MatterVoteList


    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        filldgv()
    End Sub

    Private Sub MatterVoteList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Mainform
        filldgv()
    End Sub
    Private Sub filldgv()
        Dim t As New DataTable
        Try
            Dim HolderIdentify As String
            Dim mattcode As Integer = 0
            Try
                mattcode = ToolStripTextBox1.Text
            Catch ex As Exception
                mattcode = 0
            End Try
            Try
                HolderIdentify = ToolStripTextBox2.Text
            Catch ex As Exception
                HolderIdentify = ""
            End Try

            t = Mainform.BenlyDal.MatterVotes_getlist(Mainform.workingmeeting, mattcode, HolderIdentify)

        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try

        Dim totalright As Integer = 0
        Dim agreecount As Integer = 0
        Dim agreeright As Integer = 0
        Dim disagreecount As Integer = 0
        Dim disagreeright As Integer = 0
        Dim noideacount As Integer = 0
        Dim noidearight As Integer = 0

        For Each dr As DataRow In t.Rows
            totalright = totalright + dr.Item("Voterights")
            If dr.Item("Agree") = True Then
                agreecount = agreecount + 1
                agreeright = agreeright + dr.Item("Voterights")
            ElseIf dr.Item("DisAgree") = True Then
                disagreecount = disagreecount + 1
                disagreeright = disagreeright + dr.Item("Voterights")
            Else
                noideacount = noideacount + 1
                noidearight = noidearight + dr.Item("Voterights")
            End If
        Next
        DataGridView1.DataSource = t
        ToolStripStatusLabel2.Text = DataGridView1.RowCount
        ToolStripStatusLabel16.Text = Mainform.addthousandseperator(totalright.ToString)
        '--------
        ToolStripStatusLabel4.Text = Mainform.addthousandseperator(agreecount.ToString) + " -- "
        ToolStripStatusLabel5.Text = Mainform.addthousandseperator(agreeright.ToString) + " -- "
        ToolStripStatusLabel8.Text = Mainform.addthousandseperator(disagreecount.ToString) + " -- "
        ToolStripStatusLabel9.Text = Mainform.addthousandseperator(disagreeright.ToString) + " -- "

        ToolStripStatusLabel12.Text = Mainform.addthousandseperator(noideacount.ToString) + " -- "
        ToolStripStatusLabel13.Text = Mainform.addthousandseperator(noidearight.ToString) + " -- "
        If totalright > 0 Then
            ToolStripStatusLabel6.Text = (Math.Round(((agreeright / totalright) * 100), 2)).ToString + "% "
            ToolStripStatusLabel10.Text = (Math.Round(((disagreeright / totalright) * 100), 2)).ToString + "% "
            ToolStripStatusLabel14.Text = (Math.Round(((noidearight / totalright) * 100), 2)).ToString + "% "
        Else
            ToolStripStatusLabel6.Text = ""
            ToolStripStatusLabel10.Text = ""
            ToolStripStatusLabel14.Text = ""
        End If

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim matcode As Integer = 0
        Dim delecode As Integer = 0
        Try
            matcode = ToolStripTextBox1.Text
        Catch ex As Exception
            matcode = 0
        End Try
        Try
            delecode = ToolStripTextBox2.Text
        Catch ex As Exception
            delecode = 0
        End Try
        Dim f As New Mattervote_ins_update("Add", matcode, delecode)
        f.ShowDialog()
        filldgv()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim f As New Mattervote_ins_update("Update", DataGridView1.CurrentRow.Cells("Mattercode").Value, DataGridView1.CurrentRow.Cells("delegatecode").Value)
        f.ShowDialog()
        filldgv()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc chắn XÓA Phiếu biểu quyết vấn đề :" + DataGridView1.CurrentRow.Cells("mattername").Value + " của đb " + DataGridView1.CurrentRow.Cells("Delegatename").Value, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA PHIẾU BIỂU QUYẾT") = MsgBoxResult.Ok Then
            Try
                Mainform.BenlyDal.MatterVotes_delete(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Mattercode").Value, DataGridView1.CurrentRow.Cells("delegatecode").Value, DataGridView1.CurrentRow.Cells("HolderCode").Value)
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
            End Try
        End If
        filldgv()
    End Sub

    Private Sub MatterVoteList_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If Not (ToolStripTextBox1.Focused Or ToolStripTextBox2.Focused) Then
            Select Case e.KeyCode
                Case Keys.A
                    ToolStripButton1_Click(sender, e)
                Case Keys.E
                    ToolStripButton2_Click(sender, e)
                Case Keys.D
                    ToolStripButton3_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
        End If

    End Sub

End Class