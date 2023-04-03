using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class MatterVoteList
    {
        public MatterVoteList()
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

        private void MatterVoteList_Load(object sender, EventArgs e)
        {
            MdiParent = My.MyProject.Forms.Mainform;
            filldgv();
        }

        private void filldgv()
        {
            var t = new DataTable();
            try
            {
                string HolderIdentify;
                int mattcode = 0;
                try
                {
                    mattcode = Conversions.ToInteger(ToolStripTextBox1.Text);
                }
                catch (Exception ex)
                {
                    mattcode = 0;
                }

                try
                {
                    HolderIdentify = ToolStripTextBox2.Text;
                }
                catch (Exception ex)
                {
                    HolderIdentify = "";
                }

                t = My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_getlist(My.MyProject.Forms.Mainform.workingmeeting, mattcode, HolderIdentify);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }

            int totalright = 0;
            int agreecount = 0;
            int agreeright = 0;
            int disagreecount = 0;
            int disagreeright = 0;
            int noideacount = 0;
            int noidearight = 0;
            foreach (DataRow dr in t.Rows)
            {
                totalright = Conversions.ToInteger(Operators.AddObject(totalright, dr["Voterights"]));
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Agree"], true, false)))
                {
                    agreecount = agreecount + 1;
                    agreeright = Conversions.ToInteger(Operators.AddObject(agreeright, dr["Voterights"]));
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["DisAgree"], true, false)))
                {
                    disagreecount = disagreecount + 1;
                    disagreeright = Conversions.ToInteger(Operators.AddObject(disagreeright, dr["Voterights"]));
                }
                else
                {
                    noideacount = noideacount + 1;
                    noidearight = Conversions.ToInteger(Operators.AddObject(noidearight, dr["Voterights"]));
                }
            }

            DataGridView1.DataSource = t;
            ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            ToolStripStatusLabel16.Text = My.MyProject.Forms.Mainform.addthousandseperator(totalright.ToString());
            // --------
            ToolStripStatusLabel4.Text = My.MyProject.Forms.Mainform.addthousandseperator(agreecount.ToString()) + " -- ";
            ToolStripStatusLabel5.Text = My.MyProject.Forms.Mainform.addthousandseperator(agreeright.ToString()) + " -- ";
            ToolStripStatusLabel8.Text = My.MyProject.Forms.Mainform.addthousandseperator(disagreecount.ToString()) + " -- ";
            ToolStripStatusLabel9.Text = My.MyProject.Forms.Mainform.addthousandseperator(disagreeright.ToString()) + " -- ";
            ToolStripStatusLabel12.Text = My.MyProject.Forms.Mainform.addthousandseperator(noideacount.ToString()) + " -- ";
            ToolStripStatusLabel13.Text = My.MyProject.Forms.Mainform.addthousandseperator(noidearight.ToString()) + " -- ";
            if (totalright > 0)
            {
                ToolStripStatusLabel6.Text = Math.Round(agreeright / (double)totalright * 100d, 2).ToString() + "% ";
                ToolStripStatusLabel10.Text = Math.Round(disagreeright / (double)totalright * 100d, 2).ToString() + "% ";
                ToolStripStatusLabel14.Text = Math.Round(noidearight / (double)totalright * 100d, 2).ToString() + "% ";
            }
            else
            {
                ToolStripStatusLabel6.Text = "";
                ToolStripStatusLabel10.Text = "";
                ToolStripStatusLabel14.Text = "";
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            int matcode = 0;
            int delecode = 0;
            try
            {
                matcode = Conversions.ToInteger(ToolStripTextBox1.Text);
            }
            catch (Exception ex)
            {
                matcode = 0;
            }

            try
            {
                delecode = Conversions.ToInteger(ToolStripTextBox2.Text);
            }
            catch (Exception ex)
            {
                delecode = 0;
            }

            var f = new Mattervote_ins_update("Add", matcode, delecode);
            f.ShowDialog();
            filldgv();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            var f = new Mattervote_ins_update("Update", Conversions.ToInteger(DataGridView1.CurrentRow.Cells["Mattercode"].Value), Conversions.ToInteger(DataGridView1.CurrentRow.Cells["delegatecode"].Value));
            f.ShowDialog();
            filldgv();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0)
            {
                Interaction.MsgBox("Bạn phải chọn ít nhất một bản ghi");
                return;
            }

            if (Interaction.MsgBox(Operators.AddObject(Operators.AddObject(Operators.AddObject("Bạn có chắc chắn XÓA Phiếu biểu quyết vấn đề :", DataGridView1.CurrentRow.Cells["mattername"].Value), " của đb "), DataGridView1.CurrentRow.Cells["Delegatename"].Value), (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "XÓA PHIẾU BIỂU QUYẾT") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_delete(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["Mattercode"].Value), Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["delegatecode"].Value), Conversions.ToDecimal(DataGridView1.CurrentRow.Cells["HolderCode"].Value));
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                }
            }

            filldgv();
        }

        private void MatterVoteList_KeyUp(object sender, KeyEventArgs e)
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

                    case Keys.Escape:
                        {
                            Close();
                            break;
                        }
                }
            }
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var f = new Mattervote_ins_update("Update", Conversions.ToInteger(DataGridView1.CurrentRow.Cells["Mattercode"].Value), Conversions.ToInteger(DataGridView1.CurrentRow.Cells["delegatecode"].Value));
            f.ShowDialog();
            filldgv();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.CurrentRow == null || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var rowIndex = e.RowIndex; //CurrentRow.Index;
            var colIndex = e.ColumnIndex;
            DataGridViewRow row = DataGridView1.Rows[rowIndex];
            var currentValue = row.Cells[colIndex]?.Value?.ToString();
            string columnName = DataGridView1.Columns[colIndex].Name.ToString();
            bool isAgree = false, isDisAgree = false, isNoidea = false;
            if (columnName == "agree" || columnName == "Disagree" || columnName == "Noidea")
            {
                bool iscurrentValue = Conversions.ToBoolean(currentValue);

                switch (columnName)
                {
                    case "agree":
                        isAgree = true;
                        isDisAgree = isNoidea = !isAgree;
                        break;
                    case "Disagree":
                        isDisAgree = true;
                        isAgree = isNoidea = !isDisAgree;
                        break;
                    case "Noidea":
                        isNoidea = true;
                        isAgree = isDisAgree = !isNoidea;
                        break;
                    default:
                        break;
                }

                try
                {
                    string meetingcode = My.MyProject.Forms.Mainform.workingmeeting;
                    decimal mattercode = Conversions.ToDecimal(row.Cells["Mattercode"].Value.ToString());
                    decimal delegatecode = Conversions.ToDecimal(row.Cells["Delegatecode"].Value.ToString());

                    My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_update(meetingcode, mattercode, delegatecode, isAgree, isDisAgree, isNoidea);
                    filldgv();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                }
            }
        }
    }
}