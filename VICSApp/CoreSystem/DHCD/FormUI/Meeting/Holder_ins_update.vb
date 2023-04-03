Public Class Holder_ins_update
    Private controlcode As String = "Add"
    Private updateholdercode As String
    Public Sub New(ByVal controlcode As String, ByVal holdercode As String)
        Me.controlcode = controlcode
        Me.updateholdercode = holdercode
        InitializeComponent()

    End Sub
    Private Sub Holder_ins_update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Mainform.workingmeeting
        If controlcode = "Update" Then
            MaskedTextBox2.Text = Me.updateholdercode
            MaskedTextBox2.ReadOnly = True
            Button1.Text = "Cập nhật"
            Me.Text = "Cập nhật cổ đông"
            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Holder_getlist(Mainform.workingmeeting, updateholdercode, "")
            Catch ex As Exception
                MsgBox("lỗi" + ex.Message)
                Exit Sub
            End Try
            MaskedTextBox2.Text = dt.Rows(0)("Holdercode")
            MaskedTextBox3.Text = dt.Rows(0)("HolderIdentity")
            MaskedTextBox4.Text = dt.Rows(0)("Holdername")
            MaskedTextBox5.Text = dt.Rows(0)("HolderAddress")
            StockTextBox1.Text = dt.Rows(0)("Shares")
            StockTextBox2.Text = dt.Rows(0)("Voterights")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If controlcode = "Add" Then
            Try
                Mainform.BenlyDal.holder_insert(MaskedTextBox1.Text, MaskedTextBox2.Text, MaskedTextBox3.Text, MaskedTextBox4.Text, MaskedTextBox5.Text, StockTextBox1.Text, StockTextBox2.Text)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try
        ElseIf controlcode = "Update" Then
            Try
                Mainform.BenlyDal.holder_update(MaskedTextBox1.Text, MaskedTextBox2.Text, MaskedTextBox3.Text, MaskedTextBox4.Text, MaskedTextBox5.Text, StockTextBox1.Text, StockTextBox2.Text)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try

        End If
    End Sub

    Private Sub Holder_ins_update_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class