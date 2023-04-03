Public Class DelegateList
    Private dateMeeting As DateTime = Mainform.dateMeeting
    Private Sub DelegateList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Mainform
        filldgv()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        filldgv()
    End Sub

    Private Sub filldgv()
        Dim delegatecode = 0
        Dim dt As New DataTable
        If ToolStripTextBox1.Text = "" Then
            delegatecode = 0
        Else
            Try
                delegatecode = Convert.ToInt32(ToolStripTextBox1.Text)
            Catch ex As Exception
                delegatecode = 0
            End Try
        End If

        Try
            dt = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, delegatecode, ToolStripTextBox2.Text)

        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try

        DataGridView1.DataSource = dt
        ToolStripStatusLabel2.Text = DataGridView1.RowCount
        Dim totalright As Integer = 0
        For Each dr As DataRow In dt.Rows
            totalright = totalright + dr.Item("Voterights")
        Next
        ToolStripStatusLabel4.Text = Mainform.addthousandseperator(totalright.ToString)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc chắn XÓA đại biểu :" + DataGridView1.CurrentRow.Cells("Delegatecode").Value.ToString + " ---- " + DataGridView1.CurrentRow.Cells("Delegatename").Value, MsgBoxStyle.OkCancel + MsgBoxStyle.Critical + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton2, "XÓA CỔ ĐÔNG") = MsgBoxResult.Ok Then
            Try
                Mainform.BenlyDal.Delegate_delete(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Delegatecode").Value)
                filldgv()
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim fr As New Delegate_ins()
        fr.ShowDialog()
        filldgv()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim cr As New thebieuquyet_2
        cr.SetParameterValue("HolderName", DataGridView1.CurrentRow.Cells("Delegatename").Value)
        cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value)
        cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper())
        cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("IdentityCard").Value)
        cr.SetParameterValue("Address", DataGridView1.CurrentRow.Cells("DelegateAddress").Value)
        cr.SetParameterValue("DateMeeting", dateMeeting)
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Delegatecode").Value, "", "", "")
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        Dim str As String = ""
        If dt.Rows.Count = 1 Then
            str = dt.Rows(0).Item("Holdercode")
        Else
            For Each dr As DataRow In dt.Rows
                str = str + dr.Item("Holdercode").ToString + " (" + Mainform.addthousandseperator(dr.Item("DelegateRight").ToString) + " CP); "
            Next
        End If

        cr.SetParameterValue("Holdercode", str)
        cr.SetParameterValue("voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
        ' cr.PrintToPrinter(1, True, 1, 1)
        ReportViewer.LoadReport(cr, Me)

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Bạn phải chọn ít nhất một bản ghi")
            Exit Sub
        End If
        Dim du As New DelegateUpdate(DataGridView1.CurrentRow.Cells("Delegatecode").Value)
        du.ShowDialog()
        filldgv()
    End Sub

    'In phieu bieu quyet
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cr As New phieubieuquyet1
        Try
            cr.SetDataSource(Mainform.BenlyDal.Matter_getlist(Mainform.workingmeeting, 0))
            cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value)
            cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper())
            cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("IdentityCard").Value)
            cr.SetParameterValue("DelegateAddress", DataGridView1.CurrentRow.Cells("DelegateAddress").Value)
            cr.SetParameterValue("DateMeeting", dateMeeting)

            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Delegatecode").Value, "", "", "")
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            Dim str As String = ""
            If dt.Rows.Count = 1 Then
                str = dt.Rows(0).Item("Holdercode")
            Else
                For Each dr As DataRow In dt.Rows
                    str = str + dr.Item("Holdercode").ToString + " (" + Mainform.addthousandseperator(dr.Item("DelegateRight").ToString) + " CP); "
                Next
            End If

            cr.SetParameterValue("Holdercode", str)
            cr.SetParameterValue("voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
            'cr.PrintToPrinter(1, True, 1, 10)
            ReportViewer.LoadReport(cr, Me)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try



    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Dim cr As New phieubieuquyet2
        cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value)
        cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells("Delegatename").Value)
        cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("IdentityCard").Value)
        cr.SetParameterValue("DateMeeting", dateMeeting)
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Delegatecode").Value, "", "", "")
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        Dim str As String = ""
        If dt.Rows.Count = 1 Then
            str = dt.Rows(0).Item("Holdercode")
        Else
            For Each dr As DataRow In dt.Rows
                str = str + dr.Item("Holdercode").ToString + " (" + Mainform.addthousandseperator(dr.Item("DelegateRight").ToString) + " CP); "
            Next
        End If

        cr.SetParameterValue("Holdercode", str)
        cr.SetParameterValue("voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
        'cr.PrintToPrinter(1, True, 1, 1)
        ReportViewer.LoadReport(cr, Me)
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        'Dim cr As New phieubau2
        'cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value)
        'cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells("Delegatename").Value)
        'cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("IdentityCard").Value)
        'Dim dt As New DataTable
        'Try
        '    dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Delegatecode").Value, "", "", "")
        'Catch ex As Exception
        '    MsgBox("Lỗi :" + ex.Message)
        '    Exit Sub
        'End Try
        'Dim str As String = ""
        'If dt.Rows.Count = 1 Then
        '    str = dt.Rows(0).Item("Holdercode")
        'Else
        '    For Each dr As DataRow In dt.Rows
        '        str = str + dr.Item("Holdercode").ToString + " (" + Mainform.addthousandseperator(dr.Item("DelegateRight").ToString) + " CP); "
        '    Next
        'End If

        'cr.SetParameterValue("Holdercode", str)
        'cr.SetParameterValue("voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
        'cr.SetParameterValue("sumvoterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
        'cr.PrintToPrinter(1, True, 1, 1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("abc")
    End Sub

    Private Sub DelegateList_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If Not (ToolStripTextBox1.Focused Or ToolStripTextBox2.Focused) Then
            Select Case e.KeyCode
                Case Keys.A
                    ToolStripButton1_Click(sender, e)
                Case Keys.E
                    ToolStripButton2_Click(sender, e)
                Case Keys.D
                    ToolStripButton3_Click(sender, e)
                Case Keys.S
                    ToolStripButton4_Click(sender, e)
                Case Keys.B
                    ToolStripButton5_Click(sender, e)
                Case Keys.P
                    ToolStripButton7_Click(sender, e)
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

    Private Sub ToolStripTextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            filldgv()
        End If

    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click

        Dim strHolders As String = Mainform.BenlyDal.getAuthorizationByDelegateCode(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("DelegateCode").Value.ToString())
        Try
            'Me.InPhieuXacNhan(DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper(), DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper(), DataGridView1.CurrentRow.Cells("IdentityCard").Value, DataGridView1.CurrentRow.Cells("DelegateAddress").Value, Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
            Me.InPhieuXacNhan(strHolders.ToUpper(), DataGridView1.CurrentRow.Cells("Delegatecode").Value, DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper(), DataGridView1.CurrentRow.Cells("IdentityCard").Value, DataGridView1.CurrentRow.Cells("DelegateAddress").Value, Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try


    End Sub

    Private Sub InPhieuXacNhan(ByVal strHolderName As String, ByVal strDelegateCode As String, ByVal strDelegateName As String, ByVal strIndentityCard As String, ByVal strAddress As String, ByVal strVoteRight As String)

        Dim cr As New PhieuXacNhan
        Try
            dim holderName() as String = strHolderName.Split(",")
            if (holderName.Length > 1)
                For i As Integer = 0 To holderName.Length - 1
                    holderName(i) = (i+1).ToString() + ". " + holderName(i).Trim()
                Next
            End If
            
            cr.SetParameterValue("HolderName", String.Join(Environment.NewLine, holderName).ToUpper())
            cr.SetParameterValue("Delegatecode", "VIG " & strDelegateCode.ToUpper().PadLeft(2, "000"))
            cr.SetParameterValue("Delegatename", strDelegateName.ToUpper())
            cr.SetParameterValue("IdentityCard", strIndentityCard)
            cr.SetParameterValue("Address", strAddress)
            cr.SetParameterValue("DateMeeting", dateMeeting)
            cr.SetParameterValue("voterights", strVoteRight)
            'cr.PrintToPrinter(1, True, 1, 10)
            ReportViewer.LoadReport(cr, Me)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try

    End Sub

    Private Sub InPhieuBauBKS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InPhieuBauBKS.Click
        Dim cr As New phieubauBKS
        Const pram As String = "ban kiểm soát"
        Dim dt As DataTable = Mainform.BenlyDal.GetVoteSenate(pram)
        cr.SetDataSource(dt)
        cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value.ToString().PadLeft(2, "000"))
        cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells("Delegatename").Value)
        cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("IdentityCard").Value)
        cr.SetParameterValue("DelegateAddress", DataGridView1.CurrentRow.Cells("DelegateAddress").Value)
        cr.SetParameterValue("DateMeeting", dateMeeting)
        cr.SetParameterValue("CountCandidate", dt.Rows.Count.ToString())
        cr.SetParameterValue("Voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("Voterights").Value))
        cr.SetParameterValue("sumvoterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value * dt.Rows.Count))
        ReportViewer.LoadReport(cr, Me)
    End Sub

    Private Sub InPhieuBauHDQT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InPhieuBauHDQT.Click
        Dim cr As New phieubauHDQT
        Const pram As String = "Hội Đồng Quản trị"
        Dim dt As DataTable = Mainform.BenlyDal.GetVoteSenate(pram)
        cr.SetDataSource(dt)
        cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value.ToString().PadLeft(2, "000"))
        cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells("Delegatename").Value)
        cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("IdentityCard").Value)
        cr.SetParameterValue("CountCandidate", dt.Rows.Count.ToString())
        cr.SetParameterValue("DelegateAddress", DataGridView1.CurrentRow.Cells("DelegateAddress").Value)
        cr.SetParameterValue("dateMeeting", dateMeeting)
        cr.SetParameterValue("Voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("Voterights").Value))
        cr.SetParameterValue("sumvoterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value * dt.Rows.Count))
        ReportViewer.LoadReport(cr, Me)

    End Sub

    Private Sub ToolStripButton7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim cr As New phieubieuquyet1
        Try
            cr.SetDataSource(Mainform.BenlyDal.Matter_getlist(Mainform.workingmeeting, 0))
            cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value.ToString().PadLeft(2, "000"))
            cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper())
            cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("IdentityCard").Value)
            cr.SetParameterValue("DelegateAddress", DataGridView1.CurrentRow.Cells("DelegateAddress").Value)
            cr.SetParameterValue("DateMeeting", dateMeeting)
            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Delegatecode").Value, "", "", "")
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            Dim str As String = ""
            If dt.Rows.Count = 1 Then
                str = dt.Rows(0).Item("Holdercode")
            Else
                For Each dr As DataRow In dt.Rows
                    str = str + dr.Item("Holdercode").ToString + " (" + Mainform.addthousandseperator(dr.Item("DelegateRight").ToString) + " CP); "
                Next
            End If

            cr.SetParameterValue("Holdercode", str)
            cr.SetParameterValue("voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
            ReportViewer.LoadReport(cr, Me)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
        End Try
       

    End Sub
End Class