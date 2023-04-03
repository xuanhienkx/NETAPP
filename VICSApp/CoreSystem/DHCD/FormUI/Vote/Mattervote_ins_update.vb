Public Class Mattervote_ins_update
    Dim controlcode As String
    Dim updatemattercode As Integer
    Dim updatedelegatecode As Integer
    Public Sub New(ByVal controlcode As String, ByVal mattercode As Integer, ByVal delegatecode As Integer)
        Me.controlcode = controlcode
        Me.updatemattercode = mattercode
        Me.updatedelegatecode = delegatecode
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Mattervote_ins_update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Mainform.workingmeeting
        If controlcode = "Update" Then
            Button1.Text = "Cập nhật"
            Me.Text = "Cập nhật phiếu biểu quyết"
            Dim dt1 As New DataTable
            Try
                dt1 = Mainform.BenlyDal.Matter_getlist(Mainform.workingmeeting, updatemattercode)
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            Dim dt2 As New DataTable
            Try
                dt2 = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, updatedelegatecode, "")
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            NumericUpDown1.Value = dt1.Rows(0).Item("Mattercode")
            MaskedTextBox3.Text = dt1.Rows(0).Item("Mattername")
            NumericUpDown1.ReadOnly = True

            HolderCodeMaskedTextBox.Text = dt2.Rows(0).Item("Delegatecode")
            HolderIdentifyMaskedTextBox2.Text = dt2.Rows(0).Item("IdentityCard")
            MaskedTextBox4.Text = dt2.Rows(0).Item("Delegatename")
            HolderCodeMaskedTextBox.ReadOnly = True
            HolderIdentifyMaskedTextBox2.ReadOnly = True

            Dim dt3 As New DataTable
            Try
                dt3 = Mainform.BenlyDal.MatterVotes_getlist(Mainform.workingmeeting, updatemattercode, updatedelegatecode)
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            RadioButton1.Checked = dt3.Rows(0).Item("Agree")
            RadioButton2.Checked = dt3.Rows(0).Item("DisAgree")
            RadioButton3.Checked = dt3.Rows(0).Item("Noidea")

            Button2.Visible = False
            CheckBox1.Visible = False
        End If
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

    End Sub

    Private Sub MaskedTextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles HolderCodeMaskedTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, HolderCodeMaskedTextBox.Text, "")
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            If dt.Rows.Count = 1 Then
                HolderCodeMaskedTextBox.Text = dt.Rows(0).Item("Delegatecode")
                HolderIdentifyMaskedTextBox2.Text = dt.Rows(0).Item("IdentityCard")
                MaskedTextBox4.Text = dt.Rows(0).Item("Delegatename")
                StockTextBox1.Text = dt.Rows(0).Item("voterights")
            Else
                HolderCodeMaskedTextBox.Text = ""
                HolderIdentifyMaskedTextBox2.Text = ""
                MaskedTextBox4.Text = ""
                StockTextBox1.Text = ""
            End If

            If CheckBox1.Checked = True Then
                insert()
                HolderCodeMaskedTextBox.Focus()
                HolderCodeMaskedTextBox.SelectAll()
            Else
                Button1.Focus()
            End If

        End If
    End Sub


    Private Sub MaskedTextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles HolderCodeMaskedTextBox.Leave
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, HolderCodeMaskedTextBox.Text, "")
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        If dt.Rows.Count = 1 Then
            HolderCodeMaskedTextBox.Text = dt.Rows(0).Item("Delegatecode")
            HolderIdentifyMaskedTextBox2.Text = dt.Rows(0).Item("IdentityCard")
            MaskedTextBox4.Text = dt.Rows(0).Item("Delegatename")
            StockTextBox1.Text = dt.Rows(0).Item("voterights")
        Else
            HolderCodeMaskedTextBox.Text = ""
            HolderIdentifyMaskedTextBox2.Text = ""
            MaskedTextBox4.Text = ""
            StockTextBox1.Text = ""
        End If

    End Sub

    Private Sub insert()
        Try
            Mainform.BenlyDal.MatterVotes_insert(Mainform.workingmeeting, NumericUpDown1.Value, HolderCodeMaskedTextBox.Text, delegateCodeMaskedTextBox.Text, RadioButton1.Checked, RadioButton2.Checked, RadioButton3.Checked)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
    End Sub
    Private Sub Updatemattervote()
        Try
            Mainform.BenlyDal.MatterVotes_update(Mainform.workingmeeting, NumericUpDown1.Value, HolderCodeMaskedTextBox.Text, RadioButton1.Checked, RadioButton2.Checked, RadioButton3.Checked)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
    End Sub
    Private Sub MaskedTextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles HolderIdentifyMaskedTextBox2.KeyDown

        If e.KeyCode = Keys.Enter Then

            If Not HolderIdentifyMaskedTextBox2.Text Is Nothing AndAlso HolderIdentifyMaskedTextBox2.Text <> "" Then
                Me.TimDaiBieu()
            End If

            'Dim dt As New DataTable
            'Try
            '    dt = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox2.Text)
            'Catch ex As Exception
            '    MsgBox("Lỗi :" + ex.Message)
            '    Exit Sub
            'End Try
            'If dt.Rows.Count = 1 Then
            '    MaskedTextBox5.Text = dt.Rows(0).Item("Delegatecode")
            '    MaskedTextBox2.Text = dt.Rows(0).Item("IdentityCard")
            '    MaskedTextBox4.Text = dt.Rows(0).Item("Delegatename")
            '    StockTextBox1.Text = dt.Rows(0).Item("voterights")
            'Else
            '    MaskedTextBox5.Text = ""
            '    MaskedTextBox2.Text = ""
            '    MaskedTextBox4.Text = ""
            '    StockTextBox1.Text = ""
            'End If

            If CheckBox1.Checked = True Then
                insert()
                HolderCodeMaskedTextBox.Focus()
            Else
                Button1.Focus()
            End If
        End If
    End Sub

    Private Sub TimDaiBieu()
        Dim daibieu As New DataTable
        Try
            'daibieu = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox3.Text)
            'daibieu = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox2.Text)
            daibieu = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, 0, "", delegateIdentityTextBox.Text, HolderIdentifyMaskedTextBox2.Text)
        Catch ex As Exception
            MsgBox("Lỗi" + ex.Message)
            Exit Sub
        End Try
        If daibieu.Rows.Count = 1 Then
            HolderCodeMaskedTextBox.Text = daibieu.Rows(0).Item("HolderCode")
            delegateCodeMaskedTextBox.Text = daibieu.Rows(0).Item("DelegateCode")
            HolderIdentifyMaskedTextBox2.Text = daibieu.Rows(0).Item("HolderIdentity")
            MaskedTextBox4.Text = daibieu.Rows(0).Item("HolderName")
            StockTextBox1.Text = daibieu.Rows(0).Item("Delegateright")
            delegateIdentityTextBox.Text = "" 'daibieu.Rows(0).Item("IdentityCard")
            delegateNameTextbox.Text = daibieu.Rows(0).Item("DelegateName")

        ElseIf daibieu.Rows.Count > 1 Then
            Dim objListForSelect As New AuthorizationListForSelect()
            objListForSelect.HolderIdentifyCard = HolderIdentifyMaskedTextBox2.Text
            objListForSelect.DelegateIdentifyCard = delegateIdentityTextBox.Text
            objListForSelect.ShowDialog()
            HolderIdentifyMaskedTextBox2.Text = objListForSelect.DataGridView1.CurrentRow.Cells("HolderIdentity").Value.ToString()
            delegateIdentityTextBox.Text = objListForSelect.DataGridView1.CurrentRow.Cells("IdentityCard").Value.ToString()
            TimDaiBieu()
        ElseIf daibieu.Rows.Count = 0 Then
            MessageBox.Show("Không tìm thấy đại biểu !")
            HolderCodeMaskedTextBox.Text = ""
            HolderIdentifyMaskedTextBox2.Text = ""
            MaskedTextBox4.Text = ""
            StockTextBox1.Text = ""
            HolderCodeMaskedTextBox.Focus()
            HolderCodeMaskedTextBox.SelectAll()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If controlcode = "Add" Then
            insert()
            Button2.Focus()
        ElseIf controlcode = "Update" Then
            Updatemattervote()
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        HolderCodeMaskedTextBox.Text = ""
        HolderIdentifyMaskedTextBox2.Text = ""
        MaskedTextBox4.Text = ""
        StockTextBox1.Text = ""
        delegateNameTextbox.Text = ""
        HolderIdentifyMaskedTextBox2.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim f As New MatterVotes_ins_remain(NumericUpDown1.Value)
        f.ShowDialog()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
    Private Sub MaskedTextBox5_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles HolderCodeMaskedTextBox.MaskInputRejected

    End Sub

    Private Sub Mattervote_ins_update_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class