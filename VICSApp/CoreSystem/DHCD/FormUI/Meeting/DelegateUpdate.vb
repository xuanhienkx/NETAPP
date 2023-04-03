Public Class DelegateUpdate
    Dim updatedelegatecode As Integer
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub DelegateUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Mainform.workingmeeting
        MaskedTextBox2.Text = updatedelegatecode
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, updatedelegatecode, "")
        Catch ex As Exception
            MsgBox("Lỗi : " + ex.Message)
            Exit Sub
        End Try
        MaskedTextBox3.Text = dt.Rows(0).Item("IdentityCard")
        MaskedTextBox4.Text = dt.Rows(0).Item("Delegatename")
        MaskedTextBox5.Text = dt.Rows(0).Item("DelegateAddress")
    End Sub
    Public Sub New(ByVal delegatecode As Integer)
        Me.updatedelegatecode = delegatecode
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Mainform.BenlyDal.Delegate_update(Mainform.workingmeeting, updatedelegatecode, MaskedTextBox4.Text, MaskedTextBox3.Text, MaskedTextBox5.Text)
            Me.Close()
        Catch ex As Exception
            MsgBox("Lỗi : " + ex.Message)
        End Try
    End Sub

    Private Sub DelegateUpdate_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub
End Class