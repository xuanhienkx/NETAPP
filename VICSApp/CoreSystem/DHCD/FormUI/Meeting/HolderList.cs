using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using pmDHCD.Report;

namespace pmDHCD
{
    public partial class HolderList
    {
        public HolderList()
        {
            InitializeComponent();
            _ToolStripButton1.Name = "ToolStripButton1";
            _ToolStripButton2.Name = "ToolStripButton2";
            _ToolStripButton3.Name = "ToolStripButton3";
            _ToolStripTextBox1.Name = "ToolStripTextBox1";
            _ToolStripTextBox2.Name = "ToolStripTextBox2";
            _ToolStripButton4.Name = "ToolStripButton4";
            _ToolStripButton6.Name = "ToolStripButton6";
            _ToolStripButton5.Name = "ToolStripButton5";
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            filldgv();
        }

        private void filldgv()
        {
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Holder_getlist(My.MyProject.Forms.Mainform.workingmeeting, ToolStripTextBox1.Text, ToolStripTextBox2.Text);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }

            DataGridView1.DataSource = dt;
            ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            int sumshares = 0;
            int sumvoterights = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sumshares = Conversions.ToInteger(Operators.AddObject(sumshares, dr["Shares"]));
                sumvoterights = Conversions.ToInteger(Operators.AddObject(sumvoterights, dr["Voterights"]));
            }

            ToolStripStatusLabel4.Text = My.MyProject.Forms.Mainform.addthousandseperator(sumshares.ToString());
            ToolStripStatusLabel6.Text = My.MyProject.Forms.Mainform.addthousandseperator(sumvoterights.ToString());
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
                return;
            }

            if (Interaction.MsgBox(Operators.AddObject(Operators.AddObject(Operators.AddObject("Bạn có chắc chắn XÓA cổ đông :", DataGridView1.CurrentRow.Cells["Holdercode"].Value), " ---- "), DataGridView1.CurrentRow.Cells["Holdername"].Value), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA CỔ ĐÔNG") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.Holder_delete(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToString(DataGridView1.CurrentRow.Cells["Holdercode"].Value));
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
            var f = new Holder_ins_update("Add", "");
            f.ShowDialog();
            filldgv();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            var f = new Holder_ins_update("Update", Conversions.ToString(DataGridView1.CurrentRow.Cells["Holdercode"].Value));
            f.ShowDialog();
            filldgv();
        }

        private void HolderList_Load(object sender, EventArgs e)
        {
            filldgv();
            MdiParent = My.MyProject.Forms.Mainform;
        }

        private void HolderList_KeyUp(object sender, KeyEventArgs e)
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

                    case Keys.P:
                        {
                            ToolStripButton5_Click(sender, e);
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

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            var objPrintHolders = new PrintHolders();
            objPrintHolders.ShowDialog();
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow == null) return;
            var cr_thebieuquyet = new thebieuquyet_2();
            var objCommon = new clsCommon();
            string strDelegateCode = Conversions.ToString(DataGridView1.CurrentRow.Cells["holdercode"].Value);
            string strDelegateName = DataGridView1.CurrentRow.Cells["HolderName"].Value.ToString().ToUpper();
            string strIdentityCard = Conversions.ToString(DataGridView1.CurrentRow.Cells["HolderIdentity"].Value);
            string DelegateAddress = Conversions.ToString(DataGridView1.CurrentRow.Cells["HolderAddress"].Value);
            string strHoldercode;
            string strVoterights = My.MyProject.Forms.Mainform.addthousandseperator(Conversions.ToString(DataGridView1.CurrentRow.Cells["voterights"].Value));
            string strVoteRightString = objCommon.num2Text(DataGridView1.CurrentRow.Cells["voterights"].Value.ToString());
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Authorizations_getlist(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["holdercode"].Value), "", "", "");
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
                    str = str + dr["Holdercode"].ToString() + " (" + My.MyProject.Forms.Mainform.addthousandseperator(dr["voterights"].ToString()) + " CP); ";
            }

            strHoldercode = str;
            cr_thebieuquyet.SetParameterValue("Delegatecode", strDelegateCode);
            cr_thebieuquyet.SetParameterValue("HolderName", strDelegateName);
            cr_thebieuquyet.SetParameterValue("Delegatename", strDelegateName);
            cr_thebieuquyet.SetParameterValue("IdentityCard", strIdentityCard);
            cr_thebieuquyet.SetParameterValue("Address", DelegateAddress);
            cr_thebieuquyet.SetParameterValue("Holdercode", strHoldercode);
            cr_thebieuquyet.SetParameterValue("voterights", strVoterights);
            cr_thebieuquyet.SetParameterValue("DateMeeting", My.MyProject.Forms.Mainform.dateMeeting);
            cr_thebieuquyet.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToLower());
           // cr_thebieuquyet.SetParameterValue("Period", My.MyProject.Forms.Mainform.period.ToLower());
            cr_thebieuquyet.SetParameterValue("Year", My.MyProject.Forms.Mainform.year);
            ReportViewer.LoadReport(cr_thebieuquyet, this);
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
    }
}