Public Class MatterVoteResult

    Private Sub MatterVoteResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Matter_getlist(Mainform.workingmeeting, NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        If dt.Rows.Count = 1 Then
            MaskedTextBox3.Text = dt.Rows(0).Item("Mattername")
        Else
            MaskedTextBox3.Text = ""
        End If
        filltextbox()
    End Sub
    Public Sub filltextbox()
        Dim t As New DataTable
        Try
            t = Mainform.BenlyDal.MatterVotes_getlist(Mainform.workingmeeting, NumericUpDown1.Value, "")
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


        MaskedTextBox1.Text = Mainform.addthousandseperator(agreecount.ToString)
        MaskedTextBox2.Text = Mainform.addthousandseperator(disagreecount.ToString)
        MaskedTextBox4.Text = Mainform.addthousandseperator(noideacount.ToString)

        MaskedTextBox5.Text = Mainform.addthousandseperator(agreeright.ToString)
        MaskedTextBox6.Text = Mainform.addthousandseperator(disagreeright.ToString)
        MaskedTextBox7.Text = Mainform.addthousandseperator(noidearight.ToString)

        If totalright > 0 Then
            MaskedTextBox8.Text = (Math.Round(((agreeright / totalright) * 100), 2)).ToString + "% "
            MaskedTextBox9.Text = (Math.Round(((disagreeright / totalright) * 100), 2)).ToString + "% "
            MaskedTextBox10.Text = (Math.Round(((noidearight / totalright) * 100), 2)).ToString + "% "
        Else
            MaskedTextBox8.Text = ""
            MaskedTextBox9.Text = ""
            MaskedTextBox10.Text = ""
        End If
    End Sub
End Class