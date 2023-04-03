using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class Candidates_ins_update
    {
        private string controlcode;
        private int updateelectioncode;
        private int updatecandidatecode;

        public Candidates_ins_update(string controlcode, int electioncode, int candidatecode)
        {
            this.controlcode = controlcode;
            updateelectioncode = electioncode;
            updatecandidatecode = candidatecode;
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            _NumericUpDown1.Name = "NumericUpDown1";
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
            // Add any initialization after the InitializeComponent() call.

        }

        private void Candidates_ins_update_Load(object sender, EventArgs e)
        {
            MaskedTextBox1.Text = My.MyProject.Forms.Mainform.workingmeeting;
            if (controlcode == "Update")
            {
                NumericUpDown1.Value = updateelectioncode;
                NumericUpDown1.ReadOnly = true;
                NumericUpDown2.Value = updatecandidatecode;
                NumericUpDown2.ReadOnly = true;
                Button1.Text = "Cập nhật";
                Text = "Cập nhật thông tin ứng viên";
                var dt = new DataTable();
                try
                {
                    dt = My.MyProject.Forms.Mainform.BenlyDal.Candidates_getlist(My.MyProject.Forms.Mainform.workingmeeting, updateelectioncode, updatecandidatecode);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("lỗi" + ex.Message);
                    return;
                }

                MaskedTextBox3.Text = Conversions.ToString(dt.Rows[0]["Electionname"]);
                MaskedTextBox2.Text = Conversions.ToString(dt.Rows[0]["Candidatename"]);
                MaskedTextBox4.Text = Conversions.ToString(dt.Rows[0]["Candidateaddress"]);
            }
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
                Interaction.MsgBox("lỗi" + ex.Message);
                return;
            }

            if (dt.Rows.Count == 1)
            {
                MaskedTextBox3.Text = Conversions.ToString(dt.Rows[0]["electionname"]);
            }
            else
            {
                MaskedTextBox3.Text = "";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (controlcode == "Add")
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.Candidate_insert(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value, NumericUpDown2.Value, MaskedTextBox2.Text, MaskedTextBox4.Text);
                    Close();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi : " + ex.Message);
                }
            }
            else if (controlcode == "Update")
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.Candidate_update(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value, NumericUpDown2.Value, MaskedTextBox2.Text, MaskedTextBox4.Text);
                    Close();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi : " + ex.Message);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}