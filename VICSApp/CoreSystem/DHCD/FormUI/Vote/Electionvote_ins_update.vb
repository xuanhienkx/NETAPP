Public Class Electionvote_ins_update
    Dim updateelectioncode As Integer = 0
    Dim updatedelegatecode As Integer = 0
    Dim controlcode = "Add"

    Public Sub New(ByVal controlcode As String, ByVal updateelectioncode As Integer, ByVal updatedelegationcode As Integer)
        InitializeComponent()
        Me.updateelectioncode = updateelectioncode
        Me.updatedelegatecode = updatedelegationcode
        Me.controlcode = controlcode
    End Sub
    Private Sub Electionvote_ins_update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Mainform.workingmeeting
        If controlcode = "Update" Then
            Me.NumericUpDown1.Value = updateelectioncode

            Dim dt As New DataTable
            Try
                dt = Mainform.BenlyDal.Election_getlist(Mainform.workingmeeting, NumericUpDown1.Value)
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            If dt.Rows.Count = 1 Then
                MaskedTextBox3.Text = dt.Rows(0).Item("Electionname")
                MaskedTextBox6.Text = dt.Rows(0).Item("Numofcandidates")

                '================ cho danh sach ung cu vien vao datagridview 

                Dim dt2 As New DataTable
                Try
                    dt2 = Mainform.BenlyDal.Candidates_getlist_4voteupdate(Mainform.workingmeeting, NumericUpDown1.Value, 0, updatedelegatecode)
                Catch ex As Exception
                    MsgBox("Lỗi :" + ex.Message)
                    Exit Sub
                End Try
                'dt2.Columns.Remove("electioncode")
                ' dt2.Columns.Remove("electionname")
                'dt2.Columns.Remove("CandidateAddress")
                DataGridView1.DataSource = dt2
            Else
                MaskedTextBox3.Text = ""
                MaskedTextBox6.Text = ""
                DataGridView1.DataSource = vbNull
            End If


            '===========================================
            Me.MaskedTextBox5.Text = updatedelegatecode

            Dim dt3 As New DataTable
            Dim delecode As Integer = 0
            Try
                delecode = MaskedTextBox5.Text
            Catch ex As Exception
                delecode = 0
            End Try
            Try
                dt3 = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, updatedelegatecode, "")
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            If dt3.Rows.Count = 1 Then
                MaskedTextBox5.Text = dt3.Rows(0).Item("Delegatecode")
                MaskedTextBox2.Text = dt3.Rows(0).Item("IdentityCard")
                MaskedTextBox4.Text = dt3.Rows(0).Item("DelegateName")
                StockTextBox1.Text = dt3.Rows(0).Item("voterights")
                StockTextBox2.Text = (dt3.Rows(0).Item("voterights")) * (MaskedTextBox6.Text)
            Else
                MaskedTextBox5.Text = ""
                MaskedTextBox2.Text = ""
                MaskedTextBox4.Text = ""
                StockTextBox1.Text = ""
                StockTextBox2.Text = ""
            End If


            NumericUpDown1.ReadOnly = True
            MaskedTextBox5.ReadOnly = True
            MaskedTextBox2.ReadOnly = True

            Button1.Text = "Cập nhật"
            Me.Text = "Cập nhật phiếu bầu cử"
            Button2.Enabled = False
        End If

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Election_getlist(Mainform.workingmeeting, NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        If dt.Rows.Count = 1 Then
            MaskedTextBox3.Text = dt.Rows(0).Item("Electionname")
            MaskedTextBox6.Text = dt.Rows(0).Item("Numofcandidates")

            Dim dt2 As New DataTable
            Try
                dt2 = Mainform.BenlyDal.Candidates_getlist(Mainform.workingmeeting, NumericUpDown1.Value, 0)
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            dt2.Columns.Remove("electioncode")
            dt2.Columns.Remove("electionname")
            dt2.Columns.Remove("CandidateAddress")
            DataGridView1.DataSource = dt2
        Else
            MaskedTextBox3.Text = ""
            MaskedTextBox6.Text = ""
            DataGridView1.DataSource = vbNull
        End If
    End Sub

    Private Sub MaskedTextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox5.Leave
        Dim dt As New DataTable
        Dim delecode As Integer = 0
        Try
            delecode = MaskedTextBox5.Text
        Catch ex As Exception
            delecode = 0
        End Try
        Try
            dt = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, delecode, "")
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        If dt.Rows.Count = 1 Then
            MaskedTextBox5.Text = dt.Rows(0).Item("Delegatecode")
            MaskedTextBox2.Text = dt.Rows(0).Item("IdentityCard")
            MaskedTextBox4.Text = dt.Rows(0).Item("DelegateName")
            StockTextBox1.Text = dt.Rows(0).Item("voterights")
            StockTextBox2.Text = (dt.Rows(0).Item("voterights")) * (MaskedTextBox6.Text)
        Else
            MaskedTextBox5.Text = ""
            MaskedTextBox2.Text = ""
            MaskedTextBox4.Text = ""
            StockTextBox1.Text = ""
            StockTextBox2.Text = ""
        End If
    End Sub

    Private Sub MaskedTextBox5_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox5.MaskInputRejected

    End Sub

    Private Sub MaskedTextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave
        Dim dt As New DataTable
        Try
            dt = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox2.Text)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        If dt.Rows.Count = 1 Then
            MaskedTextBox5.Text = dt.Rows(0).Item("Delegatecode")
            MaskedTextBox2.Text = dt.Rows(0).Item("IdentityCard")
            MaskedTextBox4.Text = dt.Rows(0).Item("DelegateName")
            StockTextBox1.Text = dt.Rows(0).Item("voterights")
            StockTextBox2.Text = (dt.Rows(0).Item("voterights")) * (MaskedTextBox6.Text)
        Else
            MaskedTextBox5.Text = ""
            MaskedTextBox2.Text = ""
            MaskedTextBox4.Text = ""
            StockTextBox1.Text = ""
            StockTextBox2.Text = ""
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        ' If MaskedTextBox3.Text <> "" And MaskedTextBox6.Text = "" Then
        Dim candidatechoosen As Integer = 0
        For Each gr As DataGridViewRow In DataGridView1.Rows
            gr.Cells("Votes").Value = ""
            If Convert.ToBoolean(gr.Cells("Choosen").Value) = True Then
                candidatechoosen = candidatechoosen + 1
            End If
        Next
        For Each gr As DataGridViewRow In DataGridView1.Rows
            If gr.Cells("Choosen").Value = True Then
                Dim s As Integer = 0
                s = StockTextBox2.Text
                gr.Cells("Votes").Value = (Convert.ToInt32(s / candidatechoosen)).ToString
            Else
                gr.Cells("Votes").Value = ""
            End If
        Next

        'End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MaskedTextBox5.Text = ""
        MaskedTextBox2.Text = ""
        MaskedTextBox4.Text = ""
        StockTextBox1.Text = ""
        StockTextBox2.Text = ""
        Dim dt2 As New DataTable
        Try
            dt2 = Mainform.BenlyDal.Candidates_getlist(Mainform.workingmeeting, NumericUpDown1.Value, 0)
        Catch ex As Exception
            MsgBox("Lỗi :" + ex.Message)
            Exit Sub
        End Try
        dt2.Columns.Remove("electioncode")
        dt2.Columns.Remove("electionname")
        dt2.Columns.Remove("CandidateAddress")
        DataGridView1.DataSource = dt2
        Button1.Enabled = True
        RadioButton1.Checked = True
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        For Each gr As DataGridViewRow In DataGridView1.Rows
        
            gr.Cells("Votes").Value = 0
            gr.Cells("Choosen").Value = True

        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If RadioButton1.Checked = True Then



            Dim totalvoteingrid As Integer = 0
            Dim totalCandidateingrid As Integer = 0

            For Each dgvr As DataGridViewRow In DataGridView1.Rows
                If Convert.ToBoolean(dgvr.Cells("choosen").Value) = True Then
                    Try
                        totalvoteingrid = totalvoteingrid + dgvr.Cells("Votes").Value
                        totalCandidateingrid = totalCandidateingrid + 1
                    Catch ex As Exception
                        MsgBox("Lỗi :" + ex.Message)
                        Exit Sub
                    End Try
                End If
            Next

            'If totalCandidateingrid > MaskedTextBox6.Text Then
            '    MsgBox("Lỗi : Số ứng viên đã chọn lớn hơn số ứng viên được bầu")
            '    Exit Sub
            'End If
            If totalvoteingrid > StockTextBox2.Text Then
                MsgBox("Lỗi : Số phiếu bầu không hợp lệ")
                Exit Sub
            End If
            If controlcode = "Add" Then
                For Each dgvr As DataGridViewRow In DataGridView1.Rows

                    'Fixed in case the Votes is empty or null
                    'If dgvr.Cells("choosen").Value = True And dgvr.Cells("Votes").Value.ToString <> "" Then
                    If CBool(dgvr.Cells("choosen").Value) = True Then
                        Dim ValueFetchOut As String
                        With Me.DataGridView1
                            ValueFetchOut = dgvr.Cells("Votes").Value
                            ValueFetchOut = ValueFetchOut.Replace(".", "")
                            If ValueFetchOut = "" Then
                                ValueFetchOut = "0"
                            End If
                            Convert.ToInt32(ValueFetchOut)
                        End With

                        Try

                            'Mainform.BenlyDal.ElectionVotes_insert(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox5.Text, dgvr.Cells("Candidatecode").Value, dgvr.Cells("Votes").Value)
                            Mainform.BenlyDal.ElectionVotes_insert(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox5.Text, dgvr.Cells("Candidatecode").Value, Convert.ToInt32(ValueFetchOut))
                        Catch ex As Exception
                            MsgBox("Lỗi :" + ex.Message)
                            Exit Sub
                        End Try
                    Else
                        Try
                            Mainform.BenlyDal.ElectionVotes_insert(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox5.Text, dgvr.Cells("Candidatecode").Value, 0)
                        Catch ex As Exception
                            MsgBox("Lỗi :" + ex.Message)
                            Exit Sub
                        End Try
                    End If

                Next
                Button1.Enabled = False
                Button2.Focus()
            ElseIf controlcode = "Update" Then
                For Each dgvr As DataGridViewRow In DataGridView1.Rows
                    Mainform.BenlyDal.ElectionVotes_delete(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox5.Text, dgvr.Cells("Candidatecode").Value)
                Next
                For Each dgvr As DataGridViewRow In DataGridView1.Rows
                    If Convert.ToBoolean(dgvr.Cells("choosen").Value) = True And Convert.ToInt32(dgvr.Cells("Votes").Value) <> 0 Then
                        Mainform.BenlyDal.ElectionVotes_insert(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox5.Text, dgvr.Cells("Candidatecode").Value, dgvr.Cells("Votes").Value)
                    End If
                Next
                Me.Close()
            End If


        Else
            Try
                Mainform.BenlyDal.IllegalElectionVotes_insert(Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox5.Text)
            Catch ex As Exception
                MsgBox("Lỗi :" + ex.Message)
                Exit Sub
            End Try
            Button1.Enabled = False
            Button2.Focus()
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            DataGridView1.ReadOnly = True
            Button4.Enabled = False
            Button5.Enabled = False
        Else
            DataGridView1.ReadOnly = False
            Button4.Enabled = True
            Button5.Enabled = True
        End If
    End Sub
End Class