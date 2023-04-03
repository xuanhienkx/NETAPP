Public Class MeetingInfoshow
    Private dateMeeting As DateTime = Mainform.dateMeeting
    Private Sub MaskedTextBox10_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox10.MaskInputRejected, MaskedTextBox11.MaskInputRejected

    End Sub

    Private Sub MeetingInfoshow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim info As New BenlyDAL.BenlyDAL.DAL.MeetingInfo
        Try
            info = Mainform.BenlyDal.Meeting_Infor_get(Mainform.workingmeeting)
        Catch ex As Exception
            MsgBox("Lỗi : " + ex.Message)
        End Try

        MaskedTextBox1.Text = info.companyname
        MaskedTextBox2.Text = info.meetingname
        MaskedTextBox3.Text = Mainform.addthousandseperator(info.sumofholders.ToString)
        MaskedTextBox4.Text = Mainform.addthousandseperator(info.sumofshares.ToString)
        MaskedTextBox5.Text = Mainform.addthousandseperator(info.sumofvoterights.ToString)


        MaskedTextBox6.Text = Mainform.addthousandseperator(info.numofdelegates.ToString)
        MaskedTextBox7.Text = Mainform.addthousandseperator(info.numofholderparticipated.ToString)
        MaskedTextBox8.Text = Mainform.addthousandseperator(info.numofholderAuthorised.ToString)
        MaskedTextBox9.Text = Mainform.addthousandseperator(info.sumofholderAndAuthorizatedUser.ToString)
        MaskedTextBox10.Text = Mainform.addthousandseperator(info.sumofparticipedVoterights.ToString)

        MaskedTextBox11.Text = (Math.Round(((info.sumofparticipedVoterights / info.sumofvoterights) * 100), 2)).ToString + " %"

    End Sub

    Private Sub MeetingInfoshow_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub PrintButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintButton1.Click
        Dim cr As New ThongTinCuocHop

        cr.SetParameterValue("TenCongTy", MaskedTextBox1.Text)
        cr.SetParameterValue("dateMeeting", dateMeeting)
        cr.SetParameterValue("CuocHop", MaskedTextBox2.Text)
        cr.SetParameterValue("SoCoDong", MaskedTextBox3.Text)
        cr.SetParameterValue("SoCoPhan", MaskedTextBox4.Text)
        cr.SetParameterValue("QuyenBieuQuyet", MaskedTextBox5.Text)
        cr.SetParameterValue("SoDaiBieu", MaskedTextBox6.Text)
        cr.SetParameterValue("SoCoDongTrucTiep", MaskedTextBox7.Text)
        cr.SetParameterValue("SoCoDongUyQuyen", MaskedTextBox8.Text)
        cr.SetParameterValue("TongSo", MaskedTextBox9.Text)
        cr.SetParameterValue("SoQuyenBQ", MaskedTextBox10.Text)
        cr.SetParameterValue("TyLe", MaskedTextBox11.Text)
        ReportViewer.LoadReport(cr, Me) 

    End Sub
End Class