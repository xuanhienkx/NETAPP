Public Class Delegate_ins


    Private Sub Delegate_ins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Mainform.workingmeeting
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim holders As New DataTable
        Try
            holders = Mainform.BenlyDal.Holder_getlist(Mainform.workingmeeting, "", MaskedTextBox3.Text)
        Catch ex As Exception
            MsgBox("Lỗi tìm cổ đông : " + ex.Message)
        End Try
        If holders.Rows.Count = 1 Then
            MaskedTextBox3.Text = holders.Rows(0).Item("HolderIdentity")
            MaskedTextBox4.Text = holders.Rows(0).Item("HolderName")
            MaskedTextBox5.Text = holders.Rows(0).Item("HolderAddress")
            MaskedTextBox6.Text = holders.Rows(0).Item("HolderCode")
            StockTextBox1.Text = holders.Rows(0).Item("Shares")
            StockTextBox2.Text = holders.Rows(0).Item("Voterights")
            Button1.Focus()
        ElseIf holders.Rows.Count > 1 Then
            Dim objHolderListForSelect As New HolderListForSelect()
            objHolderListForSelect.IdentifyCard = MaskedTextBox3.Text
            objHolderListForSelect.ShowDialog()
            MaskedTextBox3.Text = objHolderListForSelect.DataGridView1.CurrentRow.Cells("HolderIdentity").Value.ToString()
            Button4_Click(sender, e)
        ElseIf holders.Rows.Count = 0 Then
            MessageBox.Show("Không tìm thấy cổ đông !")
            MaskedTextBox3.Focus()
            MaskedTextBox3.SelectAll()
        End If

    End Sub

    Private Sub MaskedTextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button4_Click(sender, e)
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MaskedTextBox6.Text <> "" Then
            Dim outdele As Integer
            Try
                outdele = Mainform.BenlyDal.Delegate_insert(Mainform.workingmeeting, MaskedTextBox4.Text, MaskedTextBox3.Text, MaskedTextBox5.Text)
                MaskedTextBox2.Text = outdele
                Button1.Enabled = False
                Button2.Enabled = False
                Mainform.BenlyDal.Authorizations_insert(Mainform.workingmeeting, MaskedTextBox6.Text, outdele, StockTextBox2.Text)
                Button3.Focus()
                'In phieu xac nhan tham du
                'If (MessageBox.Show("Bạn có muốn in phiếu xác nhận tham dự không?", "In phiếu xác nhận tham dự", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                '    Me.InPhieuXacNhan(MaskedTextBox4.Text, MaskedTextBox2.Text, MaskedTextBox4.Text, MaskedTextBox3.Text, MaskedTextBox5.Text, StockTextBox2.Text)
                'End If
            Catch ex As Exception
                MsgBox("Lỗi: " + ex.Message)
                MaskedTextBox3.Focus()
                MaskedTextBox3.SelectAll()
            End Try

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button1.Enabled = True
        Button2.Enabled = True
        MaskedTextBox3.Text = ""
        MaskedTextBox4.Text = ""
        MaskedTextBox5.Text = ""
        MaskedTextBox6.Text = ""
        StockTextBox1.Text = ""
        StockTextBox2.Text = ""
        MaskedTextBox3.Focus()
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MaskedTextBox3.Text = "" Then
            MessageBox.Show("Số CMT không được để trống")
            MaskedTextBox3.Focus()
            Return
        End If
        If MaskedTextBox6.Text = "" Then
            Dim outdele As Integer
            Try
                outdele = Mainform.BenlyDal.Delegate_insert(Mainform.workingmeeting, MaskedTextBox4.Text, MaskedTextBox3.Text, MaskedTextBox5.Text)
                MaskedTextBox2.Text = outdele
                Button1.Enabled = False
                Button2.Enabled = False
                Button3.Focus()
            Catch ex As Exception
                MsgBox("Lỗi: " + ex.Message)
            End Try

        End If
    End Sub

    Private Sub Delegate_ins_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim cr_thebieuquyet As New thebieuquyet_2
        Dim objCommon As New clsCommon()

        Dim strDelegateCode As String = MaskedTextBox2.Text
        Dim strDelegateName As String = MaskedTextBox4.Text.ToUpper()
        Dim strIdentityCard As String = MaskedTextBox3.Text
        Dim DelegateAddress As String = MaskedTextBox5.Text
        Dim strHoldercode As String
        'Dim strVoterights As String = Mainform.addthousandseperator(StockTextBox2.Text)
        Dim strVoteRightString As String = objCommon.num2Text(StockTextBox2.Text)
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, MaskedTextBox2.Text, "", "", "")
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
        cr_thebieuquyet.SetParameterValue("Delegatename", strDelegateName)
        cr_thebieuquyet.SetParameterValue("IdentityCard", strIdentityCard)
        cr_thebieuquyet.SetParameterValue("DelegateAddress", DelegateAddress)
        cr_thebieuquyet.SetParameterValue("Holdercode", strHoldercode)
        cr_thebieuquyet.SetParameterValue("voterights", StockTextBox2.Text)
        cr_thebieuquyet.PrintToPrinter(1, True, 1, 1)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

    End Sub

    Private Sub InPhieuXacNhan(ByVal strHolderName As String, ByVal strDelegateCode As String, ByVal strDelegateName As String, ByVal strIndentityCard As String, ByVal strAddress As String, ByVal strVoteRight As String)

        Dim cr As New PhieuXacNhan
        Try
            cr.SetParameterValue("HolderName", strHolderName.ToUpper())
            cr.SetParameterValue("Delegatecode", strDelegateCode)
            cr.SetParameterValue("Delegatename", strDelegateName.ToUpper())
            cr.SetParameterValue("IdentityCard", strIndentityCard)
            cr.SetParameterValue("Address", strAddress)
            cr.SetParameterValue("voterights", strVoteRight)
            cr.PrintToPrinter(1, True, 1, 10)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try

    End Sub
End Class