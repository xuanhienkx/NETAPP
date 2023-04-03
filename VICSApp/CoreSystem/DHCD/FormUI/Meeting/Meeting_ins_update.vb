Imports System.Globalization
Public Class Meeting_ins_update
    Private controlcode As String = "Add"
    Private updatemeetingcode As String
    Public Sub New(ByVal controlcode As String, ByVal meetingcode As String)
        Me.controlcode = controlcode
        Me.updatemeetingcode = meetingcode
        InitializeComponent()

    End Sub
    Private Sub Meeting_ins_update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If controlcode = "Update" Then
            MaskedTextBox1.Text = Me.updatemeetingcode
            MaskedTextBox1.ReadOnly = True
            Button1.Text = "Cập nhật"
            Me.Text = "Cập nhật cuộc họp"
            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Meeting_getlist(updatemeetingcode)
            Catch ex As Exception
                MsgBox("lỗi" + ex.Message)
                Exit Sub
            End Try
            MaskedTextBox2.Text = dt.Rows(0)("meetingname")
            MaskedTextBox3.Text = dt.Rows(0)("companyname")
            MaskedTextBox4.Text = dt.Rows(0)("CompanyAddress")
            MaskedTextBox5.Text = dt.Rows(0)("meetingAddress")

            'DateTimePicker1.Value = Convert.ToDateTime(dt.Rows(0)("meetingtime"))
            DateTimePicker1.Value = DateTime.Parse(dt.Rows(0)("meetingtime"), New CultureInfo("vi-VN"))
        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If controlcode = "Add" Then
            Try
                Mainform.BenlyDal.meeting_insert(MaskedTextBox1.Text, MaskedTextBox2.Text, MaskedTextBox3.Text, MaskedTextBox4.Text, MaskedTextBox5.Text, DateTimePicker1.Value.Date)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try
        ElseIf controlcode = "Update" Then
            Try
                Mainform.BenlyDal.meeting_update(MaskedTextBox1.Text, MaskedTextBox2.Text, MaskedTextBox3.Text, MaskedTextBox4.Text, MaskedTextBox5.Text, DateTimePicker1.Value.Date)
                Me.Close()
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
            End Try

        End If
    End Sub

    Private Sub Meeting_ins_update_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class