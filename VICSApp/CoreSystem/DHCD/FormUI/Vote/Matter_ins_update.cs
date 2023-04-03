using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class Matter_ins_update
    {
        private string controlcode;
        private int updatemattercode;

        public Matter_ins_update(string controlcode, int mattercode)
        {
            this.controlcode = controlcode;
            updatemattercode = mattercode;
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
            // Add any initialization after the InitializeComponent() call.

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Matter_ins_update_Load(object sender, EventArgs e)
        {
            MaskedTextBox1.Text = My.MyProject.Forms.Mainform.workingmeeting;
            if (controlcode == "Update")
            {
                NumericUpDown1.Value = updatemattercode;
                NumericUpDown1.ReadOnly = true;
                Button1.Text = "Cập nhật";
                Text = "Cập nhật vấn đề biểu quyết";
                var dt = new DataTable();
                try
                {
                    dt = My.MyProject.Forms.Mainform.BenlyDal.Matter_getlist(My.MyProject.Forms.Mainform.workingmeeting, updatemattercode);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("lỗi" + ex.Message);
                    return;
                }

                MaskedTextBox3.Text = Conversions.ToString(dt.Rows[0]["Mattername"]);
                TextBox1.Text = Conversions.ToString(dt.Rows[0]["MatterDescription"]);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (controlcode == "Add")
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.Matter_insert(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value.ToString(), MaskedTextBox3.Text, TextBox1.Text);
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
                    My.MyProject.Forms.Mainform.BenlyDal.Matter_update(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value.ToString(), MaskedTextBox3.Text, TextBox1.Text);
                    Close();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi : " + ex.Message);
                }
            }
        }
    }
}