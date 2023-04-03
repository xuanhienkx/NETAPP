using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class Elections_result
    {
        public Elections_result()
        {
            InitializeComponent();
            _NumericUpDown1.Name = "NumericUpDown1";
        }

        private void Elections_result_Load(object sender, EventArgs e)
        {
            MdiParent = My.MyProject.Forms.Mainform;
            filldgv();
        }

        private void filldgv()
        {
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.ElectionVotes_getresult(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            dt.Columns.Remove("Totalvotes");
            DataGridView1.DataSource = dt;
            ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            decimal totalright = 0m;
            foreach (DataRow dr in dt.Rows)
                totalright = Conversions.ToDecimal(Operators.AddObject(totalright, dr["sumVotes"]));
            ToolStripStatusLabel4.Text = My.MyProject.Forms.Mainform.addthousandseperator(totalright.ToString());
            var info = new BenlyDAL.BenlyDAL.DAL.ElectionVoteInfo();
            try
            {
                info = My.MyProject.Forms.Mainform.BenlyDal.ElectionVotes_Infor_get(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            ToolStripStatusLabel6.Text = info.numberoflegalVote.ToString();
            ToolStripStatusLabel8.Text = info.numberoflegalVote.ToString() + " ";
            ToolStripStatusLabel11.Text = info.numberofIllegalVote.ToString() + " ";
            if (info.SummeetingVoteRight > 0m)
            {
                ToolStripStatusLabel9.Text = (info.LegalVoteRights * 100m / info.SummeetingVoteRight).ToString("n2") + "%";
                ToolStripStatusLabel12.Text = (info.IllegalVoteRights * 100m / info.SummeetingVoteRight).ToString("n2") + "%";
            }
            // MsgBox("info.LegalVoteRights" + info.LegalVoteRights.ToString + "   IllegalVoteRights" + info.IllegalVoteRights.ToString + "   SummeetingVoteRight " + info.SummeetingVoteRight.ToString)

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Election_getlist(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            if (dt.Rows.Count == 1)
            {
                MaskedTextBox3.Text = Conversions.ToString(dt.Rows[0]["Electionname"]);
                MaskedTextBox6.Text = Conversions.ToString(dt.Rows[0]["Numofcandidates"]);
            }

            filldgv();
        }
    }
}