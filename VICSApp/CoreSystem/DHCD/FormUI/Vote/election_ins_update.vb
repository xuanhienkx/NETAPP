Public Class election_ins_update
    Dim controlcode As String
    Dim updateelectioncode As Integer
    Public Sub New(ByVal controlcode As String, ByVal electioncode As Integer)
        Me.controlcode = controlcode
        Me.updateelectioncode = electioncode
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If controlcode = "Add" Then
            Try
                Mainform.BenlyDal.Election_insert(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox3.Text, TextBox1.Text, NumericUpDown2.Value)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try
        ElseIf controlcode = "Update" Then
            Try
                Mainform.BenlyDal.Election_update(Mainform.workingmeeting, updateelectioncode, MaskedTextBox3.Text, TextBox1.Text, NumericUpDown2.Value)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try

        End If
    End Sub

    Private Sub election_ins_update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Mainform.workingmeeting
        If controlcode = "Update" Then
            NumericUpDown1.Value = Me.updateelectioncode
            NumericUpDown1.ReadOnly = True
            Button1.Text = "Cập nhật"
            Me.Text = "Cập nhật vấn đề bầu cử"
            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Election_getlist(Mainform.workingmeeting, updateelectioncode)
            Catch ex As Exception
                MsgBox("lỗi" + ex.Message)
                Exit Sub
            End Try
            MaskedTextBox3.Text = dt.Rows(0).Item("Electionname")
            TextBox1.Text = dt.Rows(0).Item("ElectionDescription")
            NumericUpDown2.Value = dt.Rows(0).Item("numofcandidates")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub
End Class