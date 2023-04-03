using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class DelegateUpdate
    {
        private int updatedelegatecode;

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DelegateUpdate_Load(object sender, EventArgs e)
        {
            MaskedTextBox1.Text = My.MyProject.Forms.Mainform.workingmeeting;
            MaskedTextBox2.Text = updatedelegatecode.ToString();
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Delegate_getlist(My.MyProject.Forms.Mainform.workingmeeting, updatedelegatecode, "");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi : " + ex.Message);
                return;
            }

            MaskedTextBox3.Text = Conversions.ToString(dt.Rows[0]["IdentityCard"]);
            MaskedTextBox4.Text = Conversions.ToString(dt.Rows[0]["Delegatename"]);
            MaskedTextBox5.Text = Conversions.ToString(dt.Rows[0]["DelegateAddress"]);
        }

        public DelegateUpdate(int delegatecode)
        {
            updatedelegatecode = delegatecode;
            InitializeComponent();
            _Button1.Name = "Button1";
            _Button2.Name = "Button2";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                My.MyProject.Forms.Mainform.BenlyDal.Delegate_update(My.MyProject.Forms.Mainform.workingmeeting, updatedelegatecode, MaskedTextBox4.Text, MaskedTextBox3.Text, MaskedTextBox5.Text);
                Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi : " + ex.Message);
            }
        }

        private void DelegateUpdate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}