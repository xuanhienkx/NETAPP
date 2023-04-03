Public Class AuthorizationList

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Me.InPhieuXacNhan(DataGridView1.CurrentRow.Cells("HolderName").Value.ToString.ToUpper(), DataGridView1.CurrentRow.Cells("Delegatecode").Value.ToString.ToUpper(), DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper(), DataGridView1.CurrentRow.Cells("HolderIdentity").Value, DataGridView1.CurrentRow.Cells("HolderAddress").Value, DataGridView1.CurrentRow.Cells("DelegateRight").Value)

    End Sub

    Private Sub AuthorizationList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Mainform
        filldgv()
    End Sub
    Private Sub filldgv()
        Dim delegatecode = 0
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, delegatecode, "", ToolStripTextBox2.Text, ToolStripTextBox4.Text)

        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
        DataGridView1.DataSource = dt
        ToolStripStatusLabel2.Text = DataGridView1.RowCount

        Dim sumholdervoteright As Integer = 0
        Dim sumdelegatevoteright As Integer = 0

        For Each dr As DataRow In dt.Rows
            sumholdervoteright = sumholdervoteright + dr.Item("voterights")
            sumdelegatevoteright = sumdelegatevoteright + dr.Item("DelegateRight")
        Next
        ToolStripStatusLabel4.Text = Mainform.addthousandseperator(sumholdervoteright.ToString)
        ToolStripStatusLabel6.Text = Mainform.addthousandseperator(sumdelegatevoteright.ToString)


    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim f As New AuthorizationsInsert()
        f.ShowDialog()
        filldgv()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If MsgBox("Bạn có chắc chắn XÓA thông tin Ủy quyền", MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA CỔ ĐÔNG") = MsgBoxResult.Ok Then
            Try
                Mainform.BenlyDal.Authorizations_delete(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Delegatecode").Value, DataGridView1.CurrentRow.Cells("holdercode").Value)
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
            End Try
        End If
        
        filldgv()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim f As New AuthorizationUpdate(DataGridView1.CurrentRow.Cells("Delegatecode").Value, DataGridView1.CurrentRow.Cells("holdercode").Value, DataGridView1.CurrentRow.Cells("DelegateRight").Value)
        f.ShowDialog()
        filldgv()
    End Sub

    Private Sub AuthorizationList_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

        If Not (ToolStripTextBox2.Focused Or ToolStripTextBox4.Focused) Then
            Select Case e.KeyCode
                Case Keys.A
                    ToolStripButton1_Click(sender, e)
                Case Keys.E
                    ToolStripButton2_Click(sender, e)
                Case Keys.D
                    ToolStripButton3_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
        End If


    End Sub

    Private Sub ToolStripTextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox2.KeyUp
        If e.KeyCode = Keys.Enter Then
            filldgv()
        End If
    End Sub

    Private Sub ToolStripTextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox4.KeyUp
        If e.KeyCode = Keys.Enter Then
            filldgv()
        End If

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Dim cr As New thebieuquyet_2
        cr.SetParameterValue("HolderName", DataGridView1.CurrentRow.Cells("HolderName").Value.ToString.ToUpper())
        cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value)
        cr.SetParameterValue("DelegateName", DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper())
        cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("HolderIdentity").Value)
        cr.SetParameterValue("Address", DataGridView1.CurrentRow.Cells("HolderAddress").Value)

        cr.SetParameterValue("Holdercode", "")
        cr.SetParameterValue("voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("DelegateRight").Value))
        'cr.PrintToPrinter(1, True, 1, 1)
        ReportViewer.LoadReport(cr, Me)
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        filldgv()
    End Sub

    Private Sub InPhieuXacNhan(ByVal strHolderName As String, ByVal strDelegateCode As String, ByVal strDelegateName As String, ByVal strIndentityCard As String, ByVal strAddress As String, ByVal strVoteRight As String)

        Dim cr As New PhieuXacNhan
        Try
            cr.SetParameterValue("HolderName", strHolderName.ToUpper())
            cr.SetParameterValue("Delegatecode", strDelegateCode)
            cr.SetParameterValue("Delegatename", strDelegateName.ToUpper())
            cr.SetParameterValue("IdentityCard", strIndentityCard)
            cr.SetParameterValue("Address", strAddress)
            cr.SetParameterValue("voterights", strVoteRight)
            cr.PrintToPrinter(1, True, 1, 10)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try

    End Sub
End Class