using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class ElectionList
    {
        public ElectionList()
        {
            InitializeComponent();
            _ToolStripButton1.Name = "ToolStripButton1";
            _ToolStripButton2.Name = "ToolStripButton2";
            _ToolStripButton3.Name = "ToolStripButton3";
        }

        private void ElectionList_Load(object sender, EventArgs e)
        {
            MdiParent = My.MyProject.Forms.Mainform;
            filldgv();
        }

        private void filldgv()
        {
            try
            {
                DataGridView1.DataSource = My.MyProject.Forms.Mainform.BenlyDal.Election_getlist(My.MyProject.Forms.Mainform.workingmeeting, 0m);
                ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new election_ins_update("Add", 1);
            f.ShowDialog();
            filldgv();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn một bản ghi");
            }
            else
            {
                var f = new election_ins_update("Update", Conversions.ToInteger(DataGridView1.CurrentRow.Cells["Electioncode"].Value));
                f.ShowDialog();
                filldgv();
            }
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn một bản ghi");
            }
            else
            {
                if (Interaction.MsgBox(Operators.AddObject("Bạn có chắc chắn XÓA cuộc bầu cử :", DataGridView1.CurrentRow.Cells["Electionname"].Value), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA CUỘC BẦU CỬ") == MsgBoxResult.Ok)
                {
                    try
                    {
                        My.MyProject.Forms.Mainform.BenlyDal.Election_delete(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["electioncode"].Value));
                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox("Lỗi" + ex.Message);
                    }
                }

                filldgv();
            }
        }
    }
}