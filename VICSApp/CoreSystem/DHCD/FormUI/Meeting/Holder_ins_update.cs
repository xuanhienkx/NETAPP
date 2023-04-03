using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class Holder_ins_update
    {
        private string controlcode = "Add";
        private string updateholdercode;

        public Holder_ins_update(string controlcode, string holdercode)
        {
            this.controlcode = controlcode;
            updateholdercode = holdercode;
            InitializeComponent();
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
        }

        private void Holder_ins_update_Load(object sender, EventArgs e)
        {
            MaskedTextBox1.Text = My.MyProject.Forms.Mainform.workingmeeting;
            if (controlcode == "Update")
            {
                MaskedTextBox2.Text = updateholdercode;
                MaskedTextBox2.ReadOnly = true;
                Button1.Text = "Cập nhật";
                Text = "Cập nhật cổ đông";
                var dt = new DataTable();
                try
                {
                    dt = My.MyProject.Forms.Mainform.BenlyDal.Holder_getlist(My.MyProject.Forms.Mainform.workingmeeting, updateholdercode, "");
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("lỗi" + ex.Message);
                    return;
                }

                MaskedTextBox2.Text = Conversions.ToString(dt.Rows[0]["Holdercode"]);
                MaskedTextBox3.Text = Conversions.ToString(dt.Rows[0]["HolderIdentity"]);
                MaskedTextBox4.Text = Conversions.ToString(dt.Rows[0]["Holdername"]);
                MaskedTextBox5.Text = Conversions.ToString(dt.Rows[0]["HolderAddress"]);
                StockTextBox1.Text = Conversions.ToString(dt.Rows[0]["Shares"]);
                StockTextBox2.Text = Conversions.ToString(dt.Rows[0]["Voterights"]);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (controlcode == "Add")
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.holder_insert(MaskedTextBox1.Text, MaskedTextBox2.Text, MaskedTextBox3.Text, MaskedTextBox4.Text, MaskedTextBox5.Text, Conversions.ToDecimal(StockTextBox1.Text), Conversions.ToDecimal(StockTextBox2.Text));
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
                    My.MyProject.Forms.Mainform.BenlyDal.holder_update(MaskedTextBox1.Text, MaskedTextBox2.Text, MaskedTextBox3.Text, MaskedTextBox4.Text, MaskedTextBox5.Text, Conversions.ToDecimal(StockTextBox1.Text), Conversions.ToDecimal(StockTextBox2.Text));
                    Close();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi : " + ex.Message);
                }
            }
        }

        private void Holder_ins_update_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}