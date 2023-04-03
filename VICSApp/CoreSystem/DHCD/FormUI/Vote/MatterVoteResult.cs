using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class MatterVoteResult
    {
        public MatterVoteResult()
        {
            InitializeComponent();
            _NumericUpDown1.Name = "NumericUpDown1";
        }

        private void MatterVoteResult_Load(object sender, EventArgs e)
        {
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Matter_getlist(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            if (dt.Rows.Count == 1)
            {
                MaskedTextBox3.Text = Conversions.ToString(dt.Rows[0]["Mattername"]);
            }
            else
            {
                MaskedTextBox3.Text = "";
            }

            filltextbox();
        }

        public void filltextbox()
        {
            var t = new DataTable();
            try
            {
                t = My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_getlist(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value, "");
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

            MaskedTextBox1.Text = My.MyProject.Forms.Mainform.addthousandseperator(agreecount.ToString());
            MaskedTextBox2.Text = My.MyProject.Forms.Mainform.addthousandseperator(disagreecount.ToString());
            MaskedTextBox4.Text = My.MyProject.Forms.Mainform.addthousandseperator(noideacount.ToString());
            MaskedTextBox5.Text = My.MyProject.Forms.Mainform.addthousandseperator(agreeright.ToString());
            MaskedTextBox6.Text = My.MyProject.Forms.Mainform.addthousandseperator(disagreeright.ToString());
            MaskedTextBox7.Text = My.MyProject.Forms.Mainform.addthousandseperator(noidearight.ToString());
            if (totalright > 0)
            {
                MaskedTextBox8.Text = Math.Round(agreeright / (double)totalright * 100d, 2).ToString() + "% ";
                MaskedTextBox9.Text = Math.Round(disagreeright / (double)totalright * 100d, 2).ToString() + "% ";
                MaskedTextBox10.Text = Math.Round(noidearight / (double)totalright * 100d, 2).ToString() + "% ";
            }
            else
            {
                MaskedTextBox8.Text = "";
                MaskedTextBox9.Text = "";
                MaskedTextBox10.Text = "";
            }
        }
    }
}