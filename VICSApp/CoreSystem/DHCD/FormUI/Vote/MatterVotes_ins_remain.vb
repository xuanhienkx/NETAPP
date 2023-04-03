Public Class MatterVotes_ins_remain
    Dim insertmattercode As Integer
    Public Sub New(ByVal mattercode As Integer)
        InitializeComponent()
        Me.insertmattercode = mattercode
    End Sub
    Private Sub MatterVotes_ins_remain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim info As BenlyDAL.BenlyDAL.DAL.MatterVoteInfo
        info = Mainform.BenlyDal.MatterVotes_Infor_get(Mainform.workingmeeting, insertmattercode)
        MaskedTextBox1.Text = insertmattercode
        MaskedTextBox2.Text = info.mattername
        MaskedTextBox3.Text = info.sumofdelegates
        MaskedTextBox4.Text = info.enteredvotes
        MaskedTextBox5.Text = info.remainvotes
        MaskedTextBox6.Text = info.AgreedDelegates
        MaskedTextBox7.Text = info.DisAgreedDelegates
        MaskedTextBox8.Text = info.Noideaddelegates
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Thao tác này sẽ nhập TẤT CẢ phiếu biểu quyết còn lại, Bạn đã kiểm tra CHẮC CHẮN???", MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "NHẬP HÀNG LOẠT PHIẾU BIỂU QUYẾT") = MsgBoxResult.Ok Then
            Try
                Mainform.BenlyDal.MatterVotes_insert_remain(Mainform.workingmeeting, insertmattercode, 0, RadioButton1.Checked, RadioButton2.Checked, RadioButton3.Checked)
                MsgBox("Đã nhập xong")
            Catch ex As Exception
                MsgBox("Lỗi : " + ex.Message)
                Exit Sub
            End Try

        End If
    End Sub
End Class