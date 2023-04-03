using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using pmDHCD.Report;

namespace pmDHCD
{
    public partial class DelegateList
    {
        public DelegateList()
        {
            InitializeComponent();
            _ToolStripButton1.Name = "ToolStripButton1";
            _ToolStripButton2.Name = "ToolStripButton2";
            _ToolStripButton3.Name = "ToolStripButton3";
            _ToolStripTextBox1.Name = "ToolStripTextBox1";
            _ToolStripTextBox2.Name = "ToolStripTextBox2";
            _ToolStripButton4.Name = "ToolStripButton4";
            _ToolStripButton5.Name = "ToolStripButton5";
            _ToolStripButton10.Name = "ToolStripButton10";
            _ToolStripButton7.Name = "ToolStripButton7";
            _InPhieuBauBKS.Name = "InPhieuBauBKS";
            _InPhieuBauHDQT.Name = "InPhieuBauHDQT";
        }

        private DateTime dateMeeting = My.MyProject.Forms.Mainform.dateMeeting;

        private void DelegateList_Load(object sender, EventArgs e)
        {
            MdiParent = My.MyProject.Forms.Mainform;
            filldgv();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            filldgv();
        }

        private void filldgv()
        {
            int delegatecode = 0;
            var dt = new DataTable();
            if (string.IsNullOrEmpty(ToolStripTextBox1.Text))
            {
                delegatecode = 0;
            }
            else
            {
                try
                {
                    delegatecode = Convert.ToInt32(ToolStripTextBox1.Text);
                }
                catch (Exception ex)
                {
                    delegatecode = 0;
                }
            }

            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Delegate_getlist(My.MyProject.Forms.Mainform.workingmeeting, delegatecode, ToolStripTextBox2.Text);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            DataGridView1.DataSource = dt;
            ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            int totalright = 0;
            foreach (DataRow dr in dt.Rows)
                totalright = Conversions.ToInteger(Operators.AddObject(totalright, dr["Voterights"]));
            ToolStripStatusLabel4.Text = My.MyProject.Forms.Mainform.addthousandseperator(totalright.ToString());
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
                return;
            }

            if (Interaction.MsgBox(Operators.AddObject("Bạn có chắc chắn XÓA đại biểu :" + DataGridView1.CurrentRow.Cells["Delegatecode"].Value.ToString() + " ---- ", DataGridView1.CurrentRow.Cells["Delegatename"].Value), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA CỔ ĐÔNG") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.Delegate_delete(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToString(DataGridView1.CurrentRow.Cells["Delegatecode"].Value));
                    filldgv();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                }
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var fr = new Delegate_ins();
            fr.ShowDialog();
            filldgv();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            var cr = new thebieuquyet_2();
            cr.SetParameterValue("HolderName", DataGridView1.CurrentRow.Cells["Delegatename"].Value);
            cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells["Delegatecode"].Value);
            cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells["Delegatename"].Value.ToString().ToUpper());
            cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells["IdentityCard"].Value);
            cr.SetParameterValue("Address", DataGridView1.CurrentRow.Cells["DelegateAddress"].Value);
            cr.SetParameterValue("DateMeeting", dateMeeting);
            cr.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToLower());
            cr.SetParameterValue("Year", My.MyProject.Forms.Mainform.year);
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Authorizations_getlist(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Delegatecode"].Value), "", "", "");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            string str = "";
            if (dt.Rows.Count == 1)
            {
                str = Conversions.ToString(dt.Rows[0]["Holdercode"]);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                    str = str + dr["Holdercode"].ToString() + " (" + My.MyProject.Forms.Mainform.addthousandseperator(dr["DelegateRight"].ToString()) + " CP); ";
            }

            cr.SetParameterValue("Holdercode", str);
            cr.SetParameterValue("voterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["voterights"].Value)));
            // cr.PrintToPrinter(1, True, 1, 1)
            ReportViewer.LoadReport(cr, this);
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
                return;
            }

            var du = new DelegateUpdate(Conversions.ToInteger(DataGridView1.CurrentRow.Cells["Delegatecode"].Value));
            du.ShowDialog();
            filldgv();
        }

        // In phieu bieu quyet
        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            var cr = new phieubieuquyet1();
            try
            {
                cr.SetDataSource(My.MyProject.Forms.Mainform.BenlyDal.Matter_getlist(My.MyProject.Forms.Mainform.workingmeeting, 0m));
                cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells["Delegatecode"].Value);
                cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells["Delegatename"].Value.ToString().ToUpper());
                cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells["IdentityCard"].Value);
                cr.SetParameterValue("DelegateAddress", DataGridView1.CurrentRow.Cells["DelegateAddress"].Value);
                cr.SetParameterValue("DateMeeting", dateMeeting);
                cr.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToLower());
                var dt = new DataTable();
                try
                {
                    dt = My.MyProject.Forms.Mainform.BenlyDal.Authorizations_getlist(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Delegatecode"].Value), "", "", "");
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                    return;
                }

                string str = "";
                if (dt.Rows.Count == 1)
                {
                    str = Conversions.ToString(dt.Rows[0]["Holdercode"]);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                        str = str + dr["Holdercode"].ToString() + " (" + My.MyProject.Forms.Mainform.addthousandseperator(dr["DelegateRight"].ToString()) + " CP); ";
                }

                cr.SetParameterValue("Holdercode", str);
                cr.SetParameterValue("voterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["voterights"].Value)));
                // cr.PrintToPrinter(1, True, 1, 10)
                ReportViewer.LoadReport(cr, this);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {
            var cr = new phieubieuquyet2();
            cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells["Delegatecode"].Value);
            cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells["Delegatename"].Value);
            cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells["IdentityCard"].Value);
            cr.SetParameterValue("DateMeeting", dateMeeting);
            cr.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToLower());
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Authorizations_getlist(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Delegatecode"].Value), "", "", "");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            string str = "";
            if (dt.Rows.Count == 1)
            {
                str = Conversions.ToString(dt.Rows[0]["Holdercode"]);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                    str = str + dr["Holdercode"].ToString() + " (" + My.MyProject.Forms.Mainform.addthousandseperator(dr["DelegateRight"].ToString()) + " CP); ";
            }

            cr.SetParameterValue("Holdercode", str);
            cr.SetParameterValue("voterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["voterights"].Value)));
            // cr.PrintToPrinter(1, True, 1, 1)
            ReportViewer.LoadReport(cr, this);
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            // Dim cr As New phieubau2
            // cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells("Delegatecode").Value)
            // cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells("Delegatename").Value)
            // cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells("IdentityCard").Value)
            // Dim dt As New DataTable
            // Try
            // dt = Mainform.BenlyDal.Authorizations_getlist(Mainform.workingmeeting, DataGridView1.CurrentRow.Cells("Delegatecode").Value, "", "", "")
            // Catch ex As Exception
            // MsgBox("Lỗi :" + ex.Message)
            // Exit Sub
            // End Try
            // Dim str As String = ""
            // If dt.Rows.Count = 1 Then
            // str = dt.Rows(0).Item("Holdercode")
            // Else
            // For Each dr As DataRow In dt.Rows
            // str = str + dr.Item("Holdercode").ToString + " (" + Mainform.addthousandseperator(dr.Item("DelegateRight").ToString) + " CP); "
            // Next
            // End If

            // cr.SetParameterValue("Holdercode", str)
            // cr.SetParameterValue("voterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
            // cr.SetParameterValue("sumvoterights", Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
            // cr.PrintToPrinter(1, True, 1, 1)
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("abc");
        }

        private void DelegateList_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(ToolStripTextBox1.Focused | ToolStripTextBox2.Focused))
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        {
                            ToolStripButton1_Click(sender, e);
                            break;
                        }

                    case Keys.E:
                        {
                            ToolStripButton2_Click(sender, e);
                            break;
                        }

                    case Keys.D:
                        {
                            ToolStripButton3_Click(sender, e);
                            break;
                        }

                    case Keys.S:
                        {
                            ToolStripButton4_Click(sender, e);
                            break;
                        }

                    case Keys.B:
                        {
                            ToolStripButton5_Click(sender, e);
                            break;
                        }

                    case Keys.P:
                        {
                            ToolStripButton7_Click(sender, e);
                            break;
                        }

                    case Keys.Escape:
                        {
                            Close();
                            break;
                        }
                }
            }
        }

        private void ToolStripTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filldgv();
            }
        }

        private void ToolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filldgv();
            }
        }

        private void ToolStripButton10_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow == null) return;
            string strHolders = My.MyProject.Forms.Mainform.BenlyDal.getAuthorizationByDelegateCode(My.MyProject.Forms.Mainform.workingmeeting, DataGridView1.CurrentRow.Cells["DelegateCode"].Value.ToString());
            try
            {
                // Me.InPhieuXacNhan(DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper(), DataGridView1.CurrentRow.Cells("Delegatename").Value.ToString.ToUpper(), DataGridView1.CurrentRow.Cells("IdentityCard").Value, DataGridView1.CurrentRow.Cells("DelegateAddress").Value, Mainform.addthousandseperator(DataGridView1.CurrentRow.Cells("voterights").Value))
                InPhieuXacNhan(strHolders.ToUpper(), Conversions.ToString(DataGridView1.CurrentRow.Cells["Delegatecode"].Value), DataGridView1.CurrentRow.Cells["Delegatename"].Value.ToString().ToUpper(), Conversions.ToString(DataGridView1.CurrentRow.Cells["IdentityCard"].Value), Conversions.ToString(DataGridView1.CurrentRow.Cells["DelegateAddress"].Value), My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["voterights"].Value)));
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }

        private void InPhieuXacNhan(string strHolderName, string strDelegateCode, string strDelegateName, string strIndentityCard, string strAddress, string strVoteRight)
        {
            if (DataGridView1.CurrentRow == null) return;
            var cr = new PhieuXacNhan();
            try
            {
                var holderName = strHolderName.Split(',');
                if (holderName.Length > 1)
                {
                    for (int i = 0, loopTo = holderName.Length - 1; i <= loopTo; i++)
                        holderName[i] = (i + 1).ToString() + ". " + holderName[i].Trim();
                }

                cr.SetParameterValue("HolderName", string.Join(Environment.NewLine, holderName).ToUpper());
                cr.SetParameterValue("Delegatecode", "VIG " + strDelegateCode.ToUpper().PadLeft(2, Conversions.ToChar("000")));
                cr.SetParameterValue("Delegatename", strDelegateName.ToUpper());
                cr.SetParameterValue("IdentityCard", strIndentityCard);
                cr.SetParameterValue("Address", strAddress);
                cr.SetParameterValue("DateMeeting", dateMeeting);
                cr.SetParameterValue("voterights", strVoteRight);
                cr.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToUpper());
                // cr.PrintToPrinter(1, True, 1, 10)
                ReportViewer.LoadReport(cr, this);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }

        private void InPhieuBauBKS_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow == null) return;
            var cr = new phieubauBKS();
            const string pram = "ban kiểm soát";
            var dt = My.MyProject.Forms.Mainform.BenlyDal.GetVoteSenate(pram, My.MyProject.Forms.Mainform.workingmeeting);
            if (dt.Rows.Count <= 0)
            {

                Interaction.MsgBox("Không có thanh viên để bầu cử trong kỳ đại hội này!");
                return;
            }
            cr.SetDataSource(dt);
            cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells["Delegatecode"].Value.ToString().PadLeft(2, Conversions.ToChar("000")));
            cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells["Delegatename"].Value);
            cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells["IdentityCard"].Value);
            cr.SetParameterValue("DelegateAddress", DataGridView1.CurrentRow.Cells["DelegateAddress"].Value);
            cr.SetParameterValue("DateMeeting", dateMeeting);
            cr.SetParameterValue("CountCandidate", dt.Rows.Count.ToString());
            cr.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToLower());
            cr.SetParameterValue("Period", My.MyProject.Forms.Mainform.period.ToLower());
            cr.SetParameterValue("Year", My.MyProject.Forms.Mainform.year);
            cr.SetParameterValue("Voterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["Voterights"].Value)));
            cr.SetParameterValue("sumvoterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(Operators.MultiplyObject(DataGridView1.CurrentRow.Cells["voterights"].Value, dt.Rows.Count))));
            ReportViewer.LoadReport(cr, this);
        }

        private void InPhieuBauHDQT_Click(object sender, EventArgs e)
        {
            var cr = new phieubauHDQT();
            const string pram = "Hội Đồng Quản trị";
            var dt = My.MyProject.Forms.Mainform.BenlyDal.GetVoteSenate(pram, My.MyProject.Forms.Mainform.workingmeeting);
            if (dt.Rows.Count <= 0)
            {

                Interaction.MsgBox("Không có thanh viên để bầu cử trong kỳ đại hội này!");
                return;
            }
            cr.SetDataSource(dt);
            cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells["Delegatecode"].Value.ToString().PadLeft(2, Conversions.ToChar("000")));
            cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells["Delegatename"].Value);
            cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells["IdentityCard"].Value);
            cr.SetParameterValue("CountCandidate", dt.Rows.Count.ToString());
            cr.SetParameterValue("DelegateAddress", DataGridView1.CurrentRow.Cells["DelegateAddress"].Value);
            cr.SetParameterValue("dateMeeting", dateMeeting);
            cr.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToLower());
            cr.SetParameterValue("Period", My.MyProject.Forms.Mainform.period.ToLower());
            cr.SetParameterValue("Year", My.MyProject.Forms.Mainform.year);
            cr.SetParameterValue("Voterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["Voterights"].Value)));
            cr.SetParameterValue("sumvoterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(Operators.MultiplyObject(DataGridView1.CurrentRow.Cells["voterights"].Value, dt.Rows.Count))));
            ReportViewer.LoadReport(cr, this);
        }

        private void ToolStripButton7_Click_1(object sender, EventArgs e)
        {
            var cr = new phieubieuquyet1();
            try
            {
                cr.SetDataSource(My.MyProject.Forms.Mainform.BenlyDal.Matter_getlist(My.MyProject.Forms.Mainform.workingmeeting, 0m));
                cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells["Delegatecode"].Value.ToString().PadLeft(2, Conversions.ToChar("000")));
                cr.SetParameterValue("Delegatename", DataGridView1.CurrentRow.Cells["Delegatename"].Value.ToString().ToUpper());
                cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells["IdentityCard"].Value);
                cr.SetParameterValue("DelegateAddress", DataGridView1.CurrentRow.Cells["DelegateAddress"].Value);
                cr.SetParameterValue("DateMeeting", dateMeeting);
                cr.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToLower());
                cr.SetParameterValue("Year", My.MyProject.Forms.Mainform.year);
                var dt = new DataTable();
                try
                {
                    dt = My.MyProject.Forms.Mainform.BenlyDal.Authorizations_getlist(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Delegatecode"].Value), "", "", "");
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                    return;
                }

                string str = "";
                if (dt.Rows.Count == 1)
                {
                    str = Conversions.ToString(dt.Rows[0]["Holdercode"]);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                        str = str + dr["Holdercode"].ToString() + " (" + My.MyProject.Forms.Mainform.addthousandseperator(dr["DelegateRight"].ToString()) + " CP); ";
                }

                cr.SetParameterValue("Holdercode", str);
                cr.SetParameterValue("voterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["voterights"].Value)));
                ReportViewer.LoadReport(cr, this);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }
       
    }
}