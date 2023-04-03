using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class MeetingList
    {
        public MeetingList()
        {
            InitializeComponent();
            _ToolStripButton1.Name = "ToolStripButton1";
            _ToolStripButton2.Name = "ToolStripButton2";
            _ToolStripButton3.Name = "ToolStripButton3";
            _ToolStripButton4.Name = "ToolStripButton4";
            _ToolStripButton5.Name = "ToolStripButton5";
            _DataGridView1.Name = "DataGridView1";
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            filldgv();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new Meeting_ins_update("Add", "");
            f.ShowDialog();
            filldgv();
        }

        private void filldgv()
        {
            try
            {
                DataGridView1.DataSource = My.MyProject.Forms.Mainform.BenlyDal.Meeting_getlist(ToolStripTextBox1.Text);
                ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }

        private void MeetingList_Load(object sender, EventArgs e)
        {
            filldgv();
            MdiParent = My.MyProject.Forms.Mainform;
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
            }
            else
            {
                var f = new Meeting_ins_update("Update", Conversions.ToString(DataGridView1.CurrentRow.Cells["Meetingcode"].Value));
                f.ShowDialog();
                filldgv();
            }
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
                return;
            }

            if (Interaction.MsgBox(Operators.AddObject(Operators.AddObject(Operators.AddObject("Bạn có chắc chắn cuộc họp :", DataGridView1.CurrentRow.Cells["Meetingcode"].Value), " ---- "), DataGridView1.CurrentRow.Cells["Meetingname"].Value), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA CỔ ĐÔNG") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.meeting_delete(Conversions.ToString(DataGridView1.CurrentRow.Cells["Meetingcode"].Value));
                    My.MyProject.Forms.Mainform.dateMeeting = DateTime.Parse(Conversions.ToString(DataGridView1.CurrentRow.Cells["MeetingTime"].Value));
                    My.MyProject.Forms.Mainform.ToolStripStatusLabel2.Text = Conversions.ToString(DataGridView1.CurrentRow.Cells["Meetingcode"].Value);
                    My.MyProject.Forms.Mainform.ToolStripStatusLabel3.Text = Conversions.ToString(DataGridView1.CurrentRow.Cells["MeetingTime"].Value);
                    filldgv();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                }
            }
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.Mainform.workingmeeting = Conversions.ToString(DataGridView1.CurrentRow.Cells["Meetingcode"].Value);
            My.MyProject.Forms.Mainform.period = Conversions.ToString(DataGridView1.CurrentRow.Cells["Period"].Value);
            My.MyProject.Forms.Mainform.mettingType = Conversions.ToString(DataGridView1.CurrentRow.Cells["MettingType"].Value);
            My.MyProject.Forms.Mainform.year = Conversions.ToString(DataGridView1.CurrentRow.Cells["YearMeeting"].Value);
            My.MyProject.Forms.Mainform.dateMeeting = DateTime.Parse(Conversions.ToString(DataGridView1.CurrentRow.Cells["MeetingTime"].Value));
            My.MyProject.Forms.Mainform.ToolStripStatusLabel2.Text = Conversions.ToString(DataGridView1.CurrentRow.Cells["Meetingcode"].Value);
            My.MyProject.Forms.Mainform.ToolStripStatusLabel3.Text = Conversions.ToString(DataGridView1.CurrentRow.Cells["MeetingTime"].Value);
            Close();
        }

        private void MeetingList_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(ToolStripTextBox1.Focused | ToolStripTextBox1.Focused))
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

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                My.MyProject.Forms.Mainform.workingmeeting = Conversions.ToString(DataGridView1.CurrentRow.Cells["Meetingcode"].Value);
                My.MyProject.Forms.Mainform.ToolStripStatusLabel2.Text = Conversions.ToString(DataGridView1.CurrentRow.Cells["Meetingcode"].Value);
                My.MyProject.Forms.Mainform.dateMeeting = DateTime.Parse(Conversions.ToString(DataGridView1.CurrentRow.Cells["MeetingTime"].Value));
                My.MyProject.Forms.Mainform.ToolStripStatusLabel2.Text = Conversions.ToString(DataGridView1.CurrentRow.Cells["Meetingcode"].Value);
                My.MyProject.Forms.Mainform.ToolStripStatusLabel3.Text = Conversions.ToString(DataGridView1.CurrentRow.Cells["MeetingTime"].Value);
                Close();
            }
        }
    }
}