using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class IllegalElectionList
    {
        public IllegalElectionList()
        {
            InitializeComponent();
            _ToolStripButton3.Name = "ToolStripButton3";
            _ToolStripButton4.Name = "ToolStripButton4";
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            filldgv();
        }

        private void IllegalElectionList_Load(object sender, EventArgs e)
        {
            MdiParent = My.MyProject.Forms.Mainform;
            filldgv();
        }

        public void filldgv()
        {
            var t = new DataTable();
            try
            {
                int delecode = 0;
                int eleccode = 0;
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

                t = My.MyProject.Forms.Mainform.BenlyDal.IllegalElectionVotes_getlist(My.MyProject.Forms.Mainform.workingmeeting, eleccode, delecode);
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

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
                return;
            }
            else if (Interaction.MsgBox(Operators.AddObject("Bạn có chắc chắn XÓA phiếu bầu KHÔNG HỢP LỆ của đại biểu : ", DataGridView1.CurrentRow.Cells["Delegatename"].Value), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA CỔ ĐÔNG") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.IllegalElectionVotes_delete(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Electioncode"].Value), Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["delegatecode"].Value));
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi : " + ex.Message);
                }
            }

            filldgv();
        }
    }
}