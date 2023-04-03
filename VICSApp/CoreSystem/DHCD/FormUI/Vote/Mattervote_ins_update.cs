using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class Mattervote_ins_update
    {
        private string controlcode;
        private int updatemattercode;
        private int updatedelegatecode;

        public Mattervote_ins_update(string controlcode, int mattercode, int delegatecode)
        {
            this.controlcode = controlcode;
            updatemattercode = mattercode;
            updatedelegatecode = delegatecode;
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            _NumericUpDown1.Name = "NumericUpDown1";
            _HolderIdentifyMaskedTextBox2.Name = "HolderIdentifyMaskedTextBox2";
            _HolderCodeMaskedTextBox.Name = "HolderCodeMaskedTextBox";
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
            _Button2.Name = "Button2";
            _Button4.Name = "Button4";
            // Add any initialization after the InitializeComponent() call.

        }

        private void Mattervote_ins_update_Load(object sender, EventArgs e)
        {
            MaskedTextBox1.Text = My.MyProject.Forms.Mainform.workingmeeting;
            if (controlcode == "Update")
            {
                Button1.Text = "Cập nhật";
                Text = "Cập nhật phiếu biểu quyết";
                var dt1 = new DataTable();
                try
                {
                    dt1 = My.MyProject.Forms.Mainform.BenlyDal.Matter_getlist(My.MyProject.Forms.Mainform.workingmeeting, updatemattercode);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                    return;
                }

                var dt2 = new DataTable();
                try
                {
                    dt2 = My.MyProject.Forms.Mainform.BenlyDal.Delegate_getlist(My.MyProject.Forms.Mainform.workingmeeting, updatedelegatecode, "");
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                    return;
                }
                var identityCard = Conversions.ToString(dt2.Rows[0]["IdentityCard"]);
                NumericUpDown1.Value = Conversions.ToDecimal(dt1.Rows[0]["Mattercode"]);
                MaskedTextBox3.Text = Conversions.ToString(dt1.Rows[0]["Mattername"]);
                NumericUpDown1.ReadOnly = true;
                HolderCodeMaskedTextBox.Text = Conversions.ToString(dt2.Rows[0]["Delegatecode"]);
                HolderIdentifyMaskedTextBox2.Text = identityCard;
                MaskedTextBox4.Text = Conversions.ToString(dt2.Rows[0]["Delegatename"]);
                HolderCodeMaskedTextBox.ReadOnly = true;
                HolderIdentifyMaskedTextBox2.ReadOnly = true;
                var dt3 = new DataTable();
                try
                {
                    dt3 = My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_getlist(My.MyProject.Forms.Mainform.workingmeeting, updatemattercode, identityCard);
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                    return;
                }

                RadioButton1.Checked = Conversions.ToBoolean(dt3.Rows[0]["Agree"]);
                RadioButton2.Checked = Conversions.ToBoolean(dt3.Rows[0]["DisAgree"]);
                RadioButton3.Checked = Conversions.ToBoolean(dt3.Rows[0]["Noidea"]);
                Button2.Visible = false;
                CheckBox1.Visible = false;
            }
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
        }

        private void MaskedTextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var dt = new DataTable();
                try
                {
                    dt = My.MyProject.Forms.Mainform.BenlyDal.Delegate_getlist(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(HolderCodeMaskedTextBox.Text), "");
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi :" + ex.Message);
                    return;
                }

                if (dt.Rows.Count == 1)
                {
                    HolderCodeMaskedTextBox.Text = Conversions.ToString(dt.Rows[0]["Delegatecode"]);
                    HolderIdentifyMaskedTextBox2.Text = Conversions.ToString(dt.Rows[0]["IdentityCard"]);
                    MaskedTextBox4.Text = Conversions.ToString(dt.Rows[0]["Delegatename"]);
                    StockTextBox1.Text = Conversions.ToString(dt.Rows[0]["voterights"]);
                }
                else
                {
                    HolderCodeMaskedTextBox.Text = "";
                    HolderIdentifyMaskedTextBox2.Text = "";
                    MaskedTextBox4.Text = "";
                    StockTextBox1.Text = "";
                }

                if (CheckBox1.Checked == true)
                {
                    insert();
                    HolderCodeMaskedTextBox.Focus();
                    HolderCodeMaskedTextBox.SelectAll();
                }
                else
                {
                    Button1.Focus();
                }
            }
        }

        private void MaskedTextBox5_Leave(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Delegate_getlist(My.MyProject.Forms.Mainform.workingmeeting, Conversions.ToDecimal(HolderCodeMaskedTextBox.Text), "");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
                return;
            }

            if (dt.Rows.Count == 1)
            {
                HolderCodeMaskedTextBox.Text = Conversions.ToString(dt.Rows[0]["Delegatecode"]);
                HolderIdentifyMaskedTextBox2.Text = Conversions.ToString(dt.Rows[0]["IdentityCard"]);
                MaskedTextBox4.Text = Conversions.ToString(dt.Rows[0]["Delegatename"]);
                StockTextBox1.Text = Conversions.ToString(dt.Rows[0]["voterights"]);
            }
            else
            {
                HolderCodeMaskedTextBox.Text = "";
                HolderIdentifyMaskedTextBox2.Text = "";
                MaskedTextBox4.Text = "";
                StockTextBox1.Text = "";
            }
        }

        private void insert()
        {
            try
            {
                My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_insert(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value, Conversions.ToDecimal(HolderCodeMaskedTextBox.Text), Conversions.ToDecimal(delegateCodeMaskedTextBox.Text), RadioButton1.Checked, RadioButton2.Checked, RadioButton3.Checked);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }

        private void Updatemattervote()
        {
            try
            {
                My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_update(My.MyProject.Forms.Mainform.workingmeeting, NumericUpDown1.Value, Conversions.ToDecimal(HolderCodeMaskedTextBox.Text), RadioButton1.Checked, RadioButton2.Checked, RadioButton3.Checked);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }
        }

        private void MaskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (HolderIdentifyMaskedTextBox2.Text is object && !string.IsNullOrEmpty(HolderIdentifyMaskedTextBox2.Text))
                {
                    TimDaiBieu();
                }

                // Dim dt As New DataTable
                // Try
                // dt = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox2.Text)
                // Catch ex As Exception
                // MsgBox("Lỗi :" + ex.Message)
                // Exit Sub
                // End Try
                // If dt.Rows.Count = 1 Then
                // MaskedTextBox5.Text = dt.Rows(0).Item("Delegatecode")
                // MaskedTextBox2.Text = dt.Rows(0).Item("IdentityCard")
                // MaskedTextBox4.Text = dt.Rows(0).Item("Delegatename")
                // StockTextBox1.Text = dt.Rows(0).Item("voterights")
                // Else
                // MaskedTextBox5.Text = ""
                // MaskedTextBox2.Text = ""
                // MaskedTextBox4.Text = ""
                // StockTextBox1.Text = ""
                // End If

                if (CheckBox1.Checked == true)
                {
                    insert();
                    HolderCodeMaskedTextBox.Focus();
                }
                else
                {
                    Button1.Focus();
                }
            }
        }

        private void TimDaiBieu()
        {
            var daibieu = new DataTable();
            try
            {
                //daibieu = Mainform.BenlyDal.Delegate_getlist(Mainform.workingmeeting, 0, MaskedTextBox3.Text)
                daibieu = My.MyProject.Forms.Mainform.BenlyDal.Delegate_getlist(My.MyProject.Forms.Mainform.workingmeeting, 0, HolderIdentifyMaskedTextBox2.Text);
                daibieu = My.MyProject.Forms.Mainform.BenlyDal.Authorizations_getlist(My.MyProject.Forms.Mainform.workingmeeting, 0m, "",  HolderIdentifyMaskedTextBox2.Text, delegateIdentityTextBox.Text);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi" + ex.Message);
                return;
            }

            if (daibieu.Rows.Count == 1)
            {
                HolderCodeMaskedTextBox.Text = Conversions.ToString(daibieu.Rows[0]["HolderCode"]);
                delegateCodeMaskedTextBox.Text = Conversions.ToString(daibieu.Rows[0]["DelegateCode"]);
                HolderIdentifyMaskedTextBox2.Text = Conversions.ToString(daibieu.Rows[0]["HolderIdentity"]);
                MaskedTextBox4.Text = Conversions.ToString(daibieu.Rows[0]["HolderName"]);
                StockTextBox1.Text = Conversions.ToString(daibieu.Rows[0]["Delegateright"]);
                delegateIdentityTextBox.Text = ""; // daibieu.Rows(0).Item("IdentityCard")
                delegateNameTextbox.Text = Conversions.ToString(daibieu.Rows[0]["DelegateName"]);
            }
            else if (daibieu.Rows.Count > 1)
            {
                var objListForSelect = new AuthorizationListForSelect();
                objListForSelect.HolderIdentifyCard = HolderIdentifyMaskedTextBox2.Text;
                objListForSelect.DelegateIdentifyCard = delegateIdentityTextBox.Text;
                objListForSelect.ShowDialog();
                HolderIdentifyMaskedTextBox2.Text = objListForSelect.DataGridView1.CurrentRow.Cells["HolderIdentity"].Value.ToString();
                delegateIdentityTextBox.Text = objListForSelect.DataGridView1.CurrentRow.Cells["IdentityCard"].Value.ToString();
                TimDaiBieu();
            }
            else if (daibieu.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đại biểu !");
                HolderCodeMaskedTextBox.Text = "";
                HolderIdentifyMaskedTextBox2.Text = "";
                MaskedTextBox4.Text = "";
                StockTextBox1.Text = "";
                HolderCodeMaskedTextBox.Focus();
                HolderCodeMaskedTextBox.SelectAll();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (controlcode == "Add")
            {
                insert();
                Button2.Focus();
            }
            else if (controlcode == "Update")
            {
                Updatemattervote();
                Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            HolderCodeMaskedTextBox.Text = "";
            HolderIdentifyMaskedTextBox2.Text = "";
            MaskedTextBox4.Text = "";
            StockTextBox1.Text = "";
            delegateNameTextbox.Text = "";
            HolderIdentifyMaskedTextBox2.Focus();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var f = new MatterVotes_ins_remain((int)Math.Round(NumericUpDown1.Value));
            f.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MaskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void Mattervote_ins_update_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}