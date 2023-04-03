Public Class Matter_ins_update
    Dim controlcode As String
    Dim updatemattercode As Integer
    Public Sub New(ByVal controlcode As String, ByVal mattercode As Integer)
        Me.controlcode = controlcode
        Me.updatemattercode = mattercode
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Matter_ins_update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Mainform.workingmeeting
        If controlcode = "Update" Then
            NumericUpDown1.Value = Me.updatemattercode
            NumericUpDown1.ReadOnly = True
            Button1.Text = "Cập nhật"
            Me.Text = "Cập nhật vấn đề biểu quyết"
            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Matter_getlist(Mainform.workingmeeting, updatemattercode)
            Catch ex As Exception
                MsgBox("lỗi" + ex.Message)
                Exit Sub
            End Try
            MaskedTextBox3.Text = dt.Rows(0).Item("Mattername")
            TextBox1.Text = dt.Rows(0).Item("MatterDescription")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If controlcode = "Add" Then
            Try
                Mainform.BenlyDal.Matter_insert(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox3.Text, TextBox1.Text)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try
        ElseIf controlcode = "Update" Then
            Try
                Mainform.BenlyDal.Matter_update(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox3.Text, TextBox1.Text)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try

        End If
    End Sub
End Class