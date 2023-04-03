using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class ElectionVoteList
    {
        public ElectionVoteList()
        {
            InitializeComponent();
            _ToolStripButton1.Name = "ToolStripButton1";
            _ToolStripButton2.Name = "ToolStripButton2";
            _ToolStripButton3.Name = "ToolStripButton3";
            _ToolStripButton4.Name = "ToolStripButton4";
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            filldgv();
        }

        public void filldgv()
        {
            var t = new DataTable();
            try
            {
                int delecode = 0;
                int eleccode = 0;
                int candicode = 0;
                try
                {
                    eleccode = Conversions.ToInteger(ToolStripTextBox1.Text);
                }
                catch (Exception ex)
                {
                    eleccode = 0;
                }

                try
                {
                    delecode = Conversions.ToInteger(ToolStripTextBox2.Text);
                }
                catch (Exception ex)
                {
                    delecode = 0;
                }

                try
                {
                    candicode = Conversions.ToInteger(ToolStripTextBox3.Text);
                }
                catch (Exception ex)
                {
                    candicode = 0;
                }

                t = My.MyProject.Forms.Mainform.BenlyDal.ElectionVotes_getlist(My.MyProject.Forms.Mainform.workingmeeting, eleccode, delecode, candicode);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }

            DataGridView1.DataSource = t;
            ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            int totalright = 0;
            foreach (DataRow dr in t.Rows)
                totalright = Conversions.ToInteger(Operators.AddObject(totalright, dr["Votes"]));
            ToolStripStatusLabel16.Text = My.MyProject.Forms.Mainform.addthousandseperator(totalright.ToString());
        }

        private void ElectionVoteList_Load(object sender, EventArgs e)
        {
            MdiParent = My.MyProject.Forms.Mainform;
            filldgv();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
                return;
            }
            else if (Interaction.MsgBox(Operators.AddObject("Bạn có chắc chắn XÓA phiếu bầu của đại biểu : ", DataGridView1.CurrentRow.Cells["Delegatename"].Value), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA CỔ ĐÔNG") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.ElectionVotes_delete_all(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Electioncode"].Value), Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["delegatecode"].Value), Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Candidatecode"].Value));
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi : " + ex.Message);
                }
            }

            filldgv();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new Electionvote_ins_update("Add", 0, 0);
            f.ShowDialog();
            filldgv();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
                return;
            }

            var f = new Electionvote_ins_update("Update", Conversions.ToInteger(DataGridView1.CurrentRow.Cells["Electioncode"].Value), Conversions.ToInteger(DataGridView1.CurrentRow.Cells["delegatecode"].Value));
            f.ShowDialog();
            filldgv();
        }
    }
}