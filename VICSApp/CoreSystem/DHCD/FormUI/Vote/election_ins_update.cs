using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class election_ins_update
    {
        private string controlcode;
        private int updateelectioncode;

        public election_ins_update(string controlcode, int electioncode)
        {
            this.controlcode = controlcode;
            updateelectioncode = electioncode;
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
            _NumericUpDown1.Name = "NumericUpDown1";
            // Add any initialization after the InitializeComponent() call.

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (controlcode == "Add")
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.Election_insert(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value, MaskedTextBox3.Text, TextBox1.Text, NumericUpDown2.Value);
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
                    My.MyProject.Forms.Mainform.BenlyDal.Election_update(My.MyProject.Forms.Mainform.workingmeeting, updateelectioncode, MaskedTextBox3.Text, TextBox1.Text, NumericUpDown2.Value);
                    Close();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi : " + ex.Message);
                }
            }
        }

        private void election_ins_update_Load(object sender, EventArgs e)
        {
            MaskedTextBox1.Text = My.MyProject.Forms.Mainform.workingmeeting;
            if (controlcode == "Update")
            {
                NumericUpDown1.Value = updateelectioncode;
                NumericUpDown1.ReadOnly = true;
                Button1.Text = "Cập nhật";
                Text = "Cập nhật vấn đề bầu cử";
                var dt = new DataTable();
                try
                {
                    dt = My.MyProject.Forms.Mainform.BenlyDal.Election_getlist(My.MyProject.Forms.Mainform.workingmeeting, updateelectioncode);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("lỗi" + ex.Message);
                    return;
                }

                MaskedTextBox3.Text = Conversions.ToString(dt.Rows[0]["Electionname"]);
                TextBox1.Text = Conversions.ToString(dt.Rows[0]["ElectionDescription"]);
                NumericUpDown2.Value = Conversions.ToDecimal(dt.Rows[0]["numofcandidates"]);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}