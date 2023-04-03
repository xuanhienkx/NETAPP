using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using pmDHCD.Report;

namespace pmDHCD
{
    public partial class Delegate_ins
    {
        public Delegate_ins()
        {
            InitializeComponent();
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
            _MaskedTextBox3.Name = "MaskedTextBox3";
            _Button2.Name = "Button2";
            _Button4.Name = "Button4";
            _Button5.Name = "Button5";
            _Button6.Name = "Button6";
            _Button7.Name = "Button7";
        }

        private void Delegate_ins_Load(object sender, EventArgs e)
        {
            MaskedTextBox1.Text = My.MyProject.Forms.Mainform.workingmeeting;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var holders = new DataTable();
            try
            {
                holders = My.MyProject.Forms.Mainform.BenlyDal.Holder_getlist(My.MyProject.Forms.Mainform.workingmeeting, "", MaskedTextBox3.Text);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi tìm cổ đông : " + ex.Message);
            }

            if (holders.Rows.Count == 1)
            {
                MaskedTextBox3.Text = Conversions.ToString(holders.Rows[0]["HolderIdentity"]);
                MaskedTextBox4.Text = Conversions.ToString(holders.Rows[0]["HolderName"]);
                MaskedTextBox5.Text = Conversions.ToString(holders.Rows[0]["HolderAddress"]);
                MaskedTextBox6.Text = Conversions.ToString(holders.Rows[0]["HolderCode"]);
                StockTextBox1.Text = Conversions.ToString(holders.Rows[0]["Shares"]);
                StockTextBox2.Text = Conversions.ToString(holders.Rows[0]["Voterights"]);
                Button1.Focus();
            }
            else if (holders.Rows.Count > 1)
            {
                var objHolderListForSelect = new HolderListForSelect();
                objHolderListForSelect.IdentifyCard = MaskedTextBox3.Text;
                objHolderListForSelect.ShowDialog();
                MaskedTextBox3.Text = objHolderListForSelect.DataGridView1.CurrentRow.Cells["HolderIdentity"].Value.ToString();
                Button4_Click(sender, e);
            }
            else if (holders.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy cổ đông !");
                MaskedTextBox3.Focus();
                MaskedTextBox3.SelectAll();
            }
        }

        private void MaskedTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button4_Click(sender, e);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MaskedTextBox6.Text))
            {
                int outdele;
                try
                {
                    outdele = (int)Math.Round(My.MyProject.Forms.Mainform.BenlyDal.Delegate_insert(My.MyProject.Forms.Mainform.workingmeeting, MaskedTextBox4.Text, MaskedTextBox3.Text, MaskedTextBox5.Text));
                    MaskedTextBox2.Text = outdele.ToString();
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                    My.MyProject.Forms.Mainform.BenlyDal.Authorizations_insert(My.MyProject.Forms.Mainform.workingmeeting, MaskedTextBox6.Text, outdele, Conversions.ToDecimal(StockTextBox2.Text));
                    Button3.Focus();
                }
                // In phieu xac nhan tham du
                // If (MessageBox.Show("Bạn có muốn in phiếu xác nhận tham dự không?", "In phiếu xác nhận tham dự", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                // Me.InPhieuXacNhan(MaskedTextBox4.Text, MaskedTextBox2.Text, MaskedTextBox4.Text, MaskedTextBox3.Text, MaskedTextBox5.Text, StockTextBox2.Text)
                // End If
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi: " + ex.Message);
                    MaskedTextBox3.Focus();
                    MaskedTextBox3.SelectAll();
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Button1.Enabled = true;
            Button2.Enabled = true;
            MaskedTextBox3.Text = "";
            MaskedTextBox4.Text = "";
            MaskedTextBox5.Text = "";
            MaskedTextBox6.Text = "";
            StockTextBox1.Text = "";
            StockTextBox2.Text = "";
            MaskedTextBox3.Focus();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaskedTextBox3.Text))
            {
                MessageBox.Show("Số CMT không được để trống");
                MaskedTextBox3.Focus();
                return;
            }

            if (string.IsNullOrEmpty(MaskedTextBox6.Text))
            {
                int outdele;
                try
                {
                    outdele = (int)Math.Round(My.MyProject.Forms.Mainform.BenlyDal.Delegate_insert(My.MyProject.Forms.Mainform.workingmeeting, MaskedTextBox4.Text, MaskedTextBox3.Text, MaskedTextBox5.Text));
                    MaskedTextBox2.Text = outdele.ToString();
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                    Button3.Focus();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi: " + ex.Message);
                }
            }
        }

        private void Delegate_ins_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var cr_thebieuquyet = new thebieuquyet_2();
            var objCommon = new clsCommon();
            string strDelegateCode = MaskedTextBox2.Text;
            string strDelegateName = MaskedTextBox4.Text.ToUpper();
            string strIdentityCard = MaskedTextBox3.Text;
            string DelegateAddress = MaskedTextBox5.Text;
            string strHoldercode;
            // Dim strVoterights As String = Mainform.addthousandseperator(StockTextBox2.Text)
            string strVoteRightString = objCommon.num2Text(StockTextBox2.Text);
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Authorizations_getlist(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(MaskedTextBox2.Text), "", "", "");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            string str = "";
            if (dt.Rows.Count == 1)
            {
                str = Conversions.ToString(dt.Rows[0]["Holdercode"]);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                    str = str + dr["Holdercode"].ToString() + " (" + My.MyProject.Forms.Mainform.addthousandseperator(dr["voterights"].ToString()) + " CP); ";
            }

            strHoldercode = str;
            cr_thebieuquyet.SetParameterValue("Delegatecode", strDelegateCode);
            cr_thebieuquyet.SetParameterValue("Delegatename", strDelegateName);
            cr_thebieuquyet.SetParameterValue("IdentityCard", strIdentityCard);
            cr_thebieuquyet.SetParameterValue("DelegateAddress", DelegateAddress);
            cr_thebieuquyet.SetParameterValue("Holdercode", strHoldercode);
            cr_thebieuquyet.SetParameterValue("voterights", StockTextBox2.Text);
            cr_thebieuquyet.PrintToPrinter(1, true, 1, 1);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
        }

        private void InPhieuXacNhan(string strHolderName, string strDelegateCode, string strDelegateName, string strIndentityCard, string strAddress, string strVoteRight)
        {
            var cr = new PhieuXacNhan();
            try
            {
                cr.SetParameterValue("HolderName", strHolderName.ToUpper());
                cr.SetParameterValue("Delegatecode", strDelegateCode);
                cr.SetParameterValue("Delegatename", strDelegateName.ToUpper());
                cr.SetParameterValue("IdentityCard", strIndentityCard);
                cr.SetParameterValue("Address", strAddress);
                cr.SetParameterValue("voterights", strVoteRight);
                cr.PrintToPrinter(1, true, 1, 10);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }
    }
}