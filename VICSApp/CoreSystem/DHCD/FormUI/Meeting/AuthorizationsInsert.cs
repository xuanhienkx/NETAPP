using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using pmDHCD.Report;

namespace pmDHCD
{
    public partial class AuthorizationsInsert
    {
        public AuthorizationsInsert()
        {
            InitializeComponent();
            _StockTextBox2.Name = "StockTextBox2";
            _Button1.Name = "Button1";
            _Button2.Name = "Button2";
            _MaskedTextBox3.Name = "MaskedTextBox3";
            _MaskedTextBox7.Name = "MaskedTextBox7";
        }

        private void AuthorizationsInsert_Load(object sender, EventArgs e)
        {
            MaskedTextBox3.Focus();
        }

        private void MaskedTextBox3_Leave(object sender, EventArgs e)
        {
        }

        private void TimDaiBieu()
        {
            var daibieu = new DataTable();
            try
            {
                // daibieu = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox3.Text)
                daibieu = My.MyProject.Forms.Mainform.BenlyDal.Delegate_getlist(My.MyProject.Forms.Mainform.workingmeeting, 0m, MaskedTextBox3.Text);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi" + ex.Message);
                return;
            }

            if (daibieu.Rows.Count == 1)
            {
                MaskedTextBox2.Text = Conversions.ToString(daibieu.Rows[0]["DelegateCode"]);
                MaskedTextBox3.Text = Conversions.ToString(daibieu.Rows[0]["IdentityCard"]);
                MaskedTextBox4.Text = Conversions.ToString(daibieu.Rows[0]["DelegateName"]);
                MaskedTextBox7.Focus();
            }
            else if (daibieu.Rows.Count > 1)
            {
                var objDelegateListForSelect = new DelegateListForSelect();
                objDelegateListForSelect.IdentifyCard = MaskedTextBox3.Text;
                objDelegateListForSelect.ShowDialog();
                MaskedTextBox3.Text = objDelegateListForSelect.DataGridView1.CurrentRow.Cells["IdentityCard"].Value.ToString();
                TimDaiBieu();
            }
            else if (daibieu.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đại biểu !");
                MaskedTextBox7.Focus();
                MaskedTextBox7.SelectAll();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                My.MyProject.Forms.Mainform.BenlyDal.Authorizations_insert(My.MyProject.Forms.Mainform.workingmeeting, MaskedTextBox8.Text, Conversions.ToDecimal(MaskedTextBox2.Text), Conversions.ToDecimal(StockTextBox2.Text));

                // If (MessageBox.Show("Bạn có muốn in phiếu xác nhận tham dự không?", "In phiếu xác nhận tham dự", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                // Me.InPhieuXacNhan(MaskedTextBox6.Text, MaskedTextBox2.Text, MaskedTextBox4.Text, MaskedTextBox7.Text, MaskedTextBox1.Text, StockTextBox2.Text)
                // End If
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

        private void AuthorizationsInsert_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void MaskedTextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MaskedTextBox7.Focus();
            }
        }

        private void MaskedTextBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienUyQuyen();
            }
        }

        private void ThucHienUyQuyen()
        {
            var codong = new DataTable();
            try
            {
                codong = My.MyProject.Forms.Mainform.BenlyDal.Holder_getlist(My.MyProject.Forms.Mainform.workingmeeting, "", MaskedTextBox7.Text);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi" + ex.Message);
                return;
            }

            if (codong.Rows.Count == 1)
            {
                MaskedTextBox8.Text = Conversions.ToString(codong.Rows[0]["Holdercode"]);
                MaskedTextBox7.Text = Conversions.ToString(codong.Rows[0]["HolderIdentity"]);
                MaskedTextBox6.Text = Conversions.ToString(codong.Rows[0]["Holdername"]);
                MaskedTextBox1.Text = Conversions.ToString(codong.Rows[0]["HolderAddress"]);
                StockTextBox1.Text = Conversions.ToString(codong.Rows[0]["Shares"]);
                StockTextBox2.Text = Conversions.ToString(codong.Rows[0]["Voterights"]);
                StockTextBox2.Focus();
            }
            else if (codong.Rows.Count > 1)
            {
                var objHolderListForSelect = new HolderListForSelect();
                objHolderListForSelect.IdentifyCard = MaskedTextBox7.Text;
                objHolderListForSelect.ShowDialog();
                MaskedTextBox7.Text = objHolderListForSelect.DataGridView1.CurrentRow.Cells["HolderIdentity"].Value.ToString();
                ThucHienUyQuyen();
            }
            else if (codong.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy cổ đông !");
                MaskedTextBox7.Focus();
                MaskedTextBox7.SelectAll();
            }
        }

        private void StockTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1.Focus();
            }
        }

        private void MaskedTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimDaiBieu();
            }
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