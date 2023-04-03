using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using pmDHCD.Report;

namespace pmDHCD
{
    public partial class AuthorizationList
    {
        public AuthorizationList()
        {
            InitializeComponent();
            _ToolStripButton1.Name = "ToolStripButton1";
            _ToolStripButton2.Name = "ToolStripButton2";
            _ToolStripButton3.Name = "ToolStripButton3";
            _ToolStripTextBox2.Name = "ToolStripTextBox2";
            _ToolStripTextBox4.Name = "ToolStripTextBox4";
            _ToolStripButton5.Name = "ToolStripButton5";
            _ToolStripButton6.Name = "ToolStripButton6";
            _ToolStripButton4.Name = "ToolStripButton4";
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow == null) return;
            InPhieuXacNhan(DataGridView1.CurrentRow.Cells["HolderName"].Value.ToString().ToUpper(), DataGridView1.CurrentRow.Cells["Delegatecode"].Value.ToString().ToUpper(), DataGridView1.CurrentRow.Cells["Delegatename"].Value.ToString().ToUpper(), Conversions.ToString(DataGridView1.CurrentRow.Cells["HolderIdentity"].Value), Conversions.ToString(DataGridView1.CurrentRow.Cells["HolderAddress"].Value), Conversions.ToString(DataGridView1.CurrentRow.Cells["DelegateRight"].Value));
        }

        private void AuthorizationList_Load(object sender, EventArgs e)
        {
            MdiParent = My.MyProject.Forms.Mainform;
            filldgv();
        }

        private void filldgv()
        {
            int delegatecode = 0;
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Authorizations_getlist(My.MyProject.Forms.Mainform.workingmeeting, delegatecode, "", ToolStripTextBox2.Text, ToolStripTextBox4.Text);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }

            DataGridView1.DataSource = dt;
            ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            int sumholdervoteright = 0;
            int sumdelegatevoteright = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sumholdervoteright = Conversions.ToInteger(Operators.AddObject(sumholdervoteright, dr["voterights"]));
                sumdelegatevoteright = Conversions.ToInteger(Operators.AddObject(sumdelegatevoteright, dr["DelegateRight"]));
            }

            ToolStripStatusLabel4.Text = My.MyProject.Forms.Mainform.addthousandseperator(sumholdervoteright.ToString());
            ToolStripStatusLabel6.Text = My.MyProject.Forms.Mainform.addthousandseperator(sumdelegatevoteright.ToString());
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new AuthorizationsInsert();
            f.ShowDialog();
            filldgv();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Bạn có chắc chắn XÓA thông tin Ủy quyền", (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA CỔ ĐÔNG") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.Authorizations_delete(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Delegatecode"].Value), Conversions.ToString(DataGridView1.CurrentRow.Cells["holdercode"].Value));
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                }
            }

            filldgv();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            var f = new AuthorizationUpdate(Conversions.ToInteger(DataGridView1.CurrentRow.Cells["Delegatecode"].Value), Conversions.ToString(DataGridView1.CurrentRow.Cells["holdercode"].Value), Conversions.ToInteger(DataGridView1.CurrentRow.Cells["DelegateRight"].Value));
            f.ShowDialog();
            filldgv();
        }

        private void AuthorizationList_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(ToolStripTextBox2.Focused | ToolStripTextBox4.Focused))
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

        private void ToolStripTextBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filldgv();
            }
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            var cr = new thebieuquyet_2();
            cr.SetParameterValue("HolderName", DataGridView1.CurrentRow.Cells["HolderName"].Value.ToString().ToUpper());
            cr.SetParameterValue("Delegatecode", DataGridView1.CurrentRow.Cells["Delegatecode"].Value);
            cr.SetParameterValue("DelegateName", DataGridView1.CurrentRow.Cells["Delegatename"].Value.ToString().ToUpper());
            cr.SetParameterValue("IdentityCard", DataGridView1.CurrentRow.Cells["HolderIdentity"].Value);
            cr.SetParameterValue("Address", DataGridView1.CurrentRow.Cells["HolderAddress"].Value);
            cr.SetParameterValue("Holdercode", "");
            cr.SetParameterValue("voterights", My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["DelegateRight"].Value)));
            // cr.PrintToPrinter(1, True, 1, 1)
            ReportViewer.LoadReport(cr, this);
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            filldgv();
        }

        private void InPhieuXacNhan(string strHolderName, string strDelegateCode, string strDelegateName, string strIndentityCard, string strAddress, string strVoteRight)
        {
            var cr = new PhieuXacNhan();
            try
            {
                cr.SetParameterValue("HolderName", strHolderName.ToUpper());
                cr.SetParameterValue("Delegatecode", strDelegateCode);
                cr.SetParameterValue("Delegatename", strDelegateName.ToUpper());
                cr.SetParameterValue("IdentityCard", strIndentityCard);
                cr.SetParameterValue("Address", strAddress);
                cr.SetParameterValue("voterights", strVoteRight);
                cr.PrintToPrinter(1, true, 1, 10);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }
    }
}