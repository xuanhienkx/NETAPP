using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class CandidateList
    {
        public CandidateList()
        {
            nud1 = new NumericUpDown();
            InitializeComponent();
            _ToolStripButton1.Name = "ToolStripButton1";
            _ToolStripButton2.Name = "ToolStripButton2";
            _ToolStripButton3.Name = "ToolStripButton3";
            _ToolStripButton4.Name = "ToolStripButton4";
        }

        private NumericUpDown _nud1;

        private NumericUpDown nud1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _nud1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_nud1 != null)
                {
                    _nud1.ValueChanged -= NumericUpDown1_ValueChanged;
                }

                _nud1 = value;
                if (_nud1 != null)
                {
                    _nud1.ValueChanged += NumericUpDown1_ValueChanged;
                }
            }
        }

        private void CandidateList_Load(object sender, EventArgs e)
        {
            MdiParent = My.MyProject.Forms.Mainform;
            filldgv();
            nud1.Minimum = 1m;
            nud1.Maximum = 10m;
            nud1.Increment = 1m;
            ToolStrip1.Items.Insert(6, new ToolStripControlHost(nud1));
        }

        private void filldgv()
        {
            try
            {
                DataGridView1.DataSource = My.MyProject.Forms.Mainform.BenlyDal.Candidates_getlist(My.MyProject.Forms.Mainform.workingmeeting, nud1.Value, 0m);
                ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            filldgv();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new Candidates_ins_update("Add", 0, 0);
            f.Show();
            filldgv();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
            }
            else
            {
                var f = new Candidates_ins_update("Update", Conversions.ToInteger(DataGridView1.CurrentRow.Cells["Electioncode"].Value), Conversions.ToInteger(DataGridView1.CurrentRow.Cells["Candidatecode"].Value));
                f.Show();
            }

            filldgv();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
            }
            else if (Interaction.MsgBox(Operators.AddObject("Bạn có chắc chắn XÓA ứng viên :", DataGridView1.CurrentRow.Cells["candidatename"].Value), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA CỔ ĐÔNG") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.Candidate_delete(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Electioncode"].Value), Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Candidatecode"].Value));
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                }
            }

            filldgv();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            filldgv();
        }
    }
}