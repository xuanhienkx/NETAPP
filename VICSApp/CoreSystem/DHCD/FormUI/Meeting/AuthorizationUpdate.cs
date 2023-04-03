using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class AuthorizationUpdate
    {
        private int updatedelegate;
        private string updateholdercode;
        private int initdelegateright;

        public AuthorizationUpdate(int delegatecode, string holdercode, int delegateright)
        {
            InitializeComponent();
            updatedelegate = delegatecode;
            updateholdercode = holdercode;
            initdelegateright = delegateright;
            _Button2.Name = "Button2";
            _Button1.Name = "Button1";
        }

        private void AuthorizationUpdate_Load(object sender, EventArgs e)
        {
            DataTable daibieu;
            DataTable codong;
            try
            {
                daibieu = My.MyProject.Forms.Mainform.BenlyDal.Delegate_getlist(My.MyProject.Forms.Mainform.workingmeeting, updatedelegate, "");
                codong = My.MyProject.Forms.Mainform.BenlyDal.Holder_getlist(My.MyProject.Forms.Mainform.workingmeeting, updateholdercode, "");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi : " + ex.Message);
                return;
            }

            MaskedTextBox2.Text = Conversions.ToString(daibieu.Rows[0]["Delegatecode"]);
            MaskedTextBox3.Text = Conversions.ToString(daibieu.Rows[0]["IdentityCard"]);
            MaskedTextBox4.Text = Conversions.ToString(daibieu.Rows[0]["DelegateName"]);
            MaskedTextBox8.Text = Conversions.ToString(codong.Rows[0]["Holdercode"]);
            MaskedTextBox7.Text = Conversions.ToString(codong.Rows[0]["HolderIdentity"]);
            MaskedTextBox6.Text = Conversions.ToString(codong.Rows[0]["Holdername"]);
            StockTextBox1.Text = Conversions.ToString(codong.Rows[0]["Voterights"]);
            StockTextBox2.Text = initdelegateright.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                My.MyProject.Forms.Mainform.BenlyDal.Authorizations_update(My.MyProject.Forms.Mainform.workingmeeting, MaskedTextBox8.Text, Conversions.ToDecimal(MaskedTextBox2.Text), Conversions.ToDecimal(StockTextBox2.Text));
                Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi" + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}