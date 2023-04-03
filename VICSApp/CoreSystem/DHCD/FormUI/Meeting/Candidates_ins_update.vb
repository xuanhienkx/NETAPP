Public Class Candidates_ins_update
    Dim controlcode As String
    Dim updateelectioncode As Integer
    Dim updatecandidatecode As Integer
    Public Sub New(ByVal controlcode As String, ByVal electioncode As Integer, ByVal candidatecode As Integer)
        Me.controlcode = controlcode
        Me.updateelectioncode = electioncode
        Me.updatecandidatecode = candidatecode
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Candidates_ins_update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Mainform.workingmeeting
        If controlcode = "Update" Then
            NumericUpDown1.Value = Me.updateelectioncode
            NumericUpDown1.ReadOnly = True
            NumericUpDown2.Value = Me.updatecandidatecode
            NumericUpDown2.ReadOnly = True
            Button1.Text = "Cập nhật"
            Me.Text = "Cập nhật thông tin ứng viên"
            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Candidates_getlist(Mainform.workingmeeting, updateelectioncode, updatecandidatecode)
            Catch ex As Exception
                MsgBox("lỗi" + ex.Message)
                Exit Sub
            End Try
            MaskedTextBox3.Text = dt.Rows(0).Item("Electionname")
            MaskedTextBox2.Text = dt.Rows(0).Item("Candidatename")
            MaskedTextBox4.Text = dt.Rows(0).Item("Candidateaddress")
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Election_getlist(Mainform.workingmeeting, NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox("lỗi" + ex.Message)
            Exit Sub
        End Try
        If dt.Rows.Count = 1 Then
            MaskedTextBox3.Text = dt.Rows(0).Item("electionname")
        Else
            MaskedTextBox3.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If controlcode = "Add" Then
            Try
                Mainform.BenlyDal.Candidate_insert(Mainform.workingmeeting, NumericUpDown1.Value, NumericUpDown2.Value, MaskedTextBox2.Text, MaskedTextBox4.Text)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try
        ElseIf controlcode = "Update" Then
            Try
                Mainform.BenlyDal.Candidate_update(Mainform.workingmeeting, NumericUpDown1.Value, NumericUpDown2.Value, MaskedTextBox2.Text, MaskedTextBox4.Text)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class