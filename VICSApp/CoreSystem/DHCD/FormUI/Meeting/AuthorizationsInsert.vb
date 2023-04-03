Public Class AuthorizationsInsert

    Private Sub AuthorizationsInsert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox3.Focus()
    End Sub

    Private Sub MaskedTextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox3.Leave

    End Sub

    Private Sub TimDaiBieu()
        Dim daibieu As New DataTable
        Try
            'daibieu = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox3.Text)
            daibieu = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox3.Text)
        Catch ex As Exception
            MsgBox("Lỗi" + ex.Message)
            Exit Sub
        End Try
        If daibieu.Rows.Count = 1 Then
            MaskedTextBox2.Text = daibieu.Rows(0).Item("DelegateCode")
            MaskedTextBox3.Text = daibieu.Rows(0).Item("IdentityCard")
            MaskedTextBox4.Text = daibieu.Rows(0).Item("DelegateName")
            MaskedTextBox7.Focus()
        ElseIf daibieu.Rows.Count > 1 Then
            Dim objDelegateListForSelect As New DelegateListForSelect()
            objDelegateListForSelect.IdentifyCard = MaskedTextBox3.Text
            objDelegateListForSelect.ShowDialog()
            MaskedTextBox3.Text = objDelegateListForSelect.DataGridView1.CurrentRow.Cells("IdentityCard").Value.ToString()
            TimDaiBieu()
        ElseIf daibieu.Rows.Count = 0 Then
            MessageBox.Show("Không tìm thấy đại biểu !")
            MaskedTextBox7.Focus()
            MaskedTextBox7.SelectAll()
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Mainform.BenlyDal.Authorizations_insert(Mainform.workingmeeting, MaskedTextBox8.Text, MaskedTextBox2.Text, StockTextBox2.Text)

            'If (MessageBox.Show("Bạn có muốn in phiếu xác nhận tham dự không?", "In phiếu xác nhận tham dự", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
            '    Me.InPhieuXacNhan(MaskedTextBox6.Text, MaskedTextBox2.Text, MaskedTextBox4.Text, MaskedTextBox7.Text, MaskedTextBox1.Text, StockTextBox2.Text)
            'End If
            Me.Close()
        Catch ex As Exception
            MsgBox("Lỗi" + ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub AuthorizationsInsert_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub MaskedTextBox3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox3.KeyUp
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox7.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ThucHienUyQuyen()
        End If

    End Sub

    Private Sub ThucHienUyQuyen()
        Dim codong As New DataTable
        Try
            codong = Mainform.BenlyDal.Holder_getlist(Mainform.workingmeeting, "", MaskedTextBox7.Text)
        Catch ex As Exception
            MsgBox("Lỗi" + ex.Message)
            Exit Sub
        End Try
        If codong.Rows.Count = 1 Then
            MaskedTextBox8.Text = codong.Rows(0).Item("Holdercode")
            MaskedTextBox7.Text = codong.Rows(0).Item("HolderIdentity")
            MaskedTextBox6.Text = codong.Rows(0).Item("Holdername")
            MaskedTextBox1.Text = codong.Rows(0).Item("HolderAddress")
            StockTextBox1.Text = codong.Rows(0).Item("Shares")
            StockTextBox2.Text = codong.Rows(0).Item("Voterights")
            StockTextBox2.Focus()
        ElseIf codong.Rows.Count > 1 Then
            Dim objHolderListForSelect As New HolderListForSelect()
            objHolderListForSelect.IdentifyCard = MaskedTextBox7.Text
            objHolderListForSelect.ShowDialog()
            MaskedTextBox7.Text = objHolderListForSelect.DataGridView1.CurrentRow.Cells("HolderIdentity").Value.ToString()
            ThucHienUyQuyen()
        ElseIf codong.Rows.Count = 0 Then
            MessageBox.Show("Không tìm thấy cổ đông !")
            MaskedTextBox7.Focus()
            MaskedTextBox7.SelectAll()
        End If

    End Sub

    Private Sub StockTextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles StockTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If

    End Sub

    Private Sub MaskedTextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TimDaiBieu()
        End If

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