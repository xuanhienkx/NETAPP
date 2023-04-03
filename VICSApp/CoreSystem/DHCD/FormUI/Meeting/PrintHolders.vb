Imports System.Windows.Forms
Imports System
Imports System.Data

Public Class PrintHolders

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Holder_getListLimited(Mainform.workingmeeting, Convert.ToInt32(txtFromHolder.Text), Convert.ToInt32(txtToHolder.Text))
            For i = 0 To dt.Rows.Count - 1
                dt.Rows(i)("VoteRights") = Mainform.addthousandseperator(dt.Rows(i)("VoteRights").ToString().Trim())
            Next

            Dim cr_thebieuquyet As New thebieuquyet
            cr_thebieuquyet.SetDataSource(dt)
            cr_thebieuquyet.SetParameterValue("DateMeeting", Mainform.dateMeeting)
            ReportViewer.LoadReport(cr_thebieuquyet, HolderList)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
