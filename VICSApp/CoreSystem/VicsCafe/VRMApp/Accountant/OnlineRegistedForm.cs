using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.VRMGateway;
using VRMApp.Reports;
using VRMApp.Reports.RiskMan;
using System.Collections;


namespace VRMApp.Accountant
{
    public partial class OnlineRegistedForm : FormBase
    {
        public AccountTransfer accountTransfer;


        public OnlineRegistedForm(AccountTransfer updateAccountTransfer)
        {
            InitializeComponent();
            accountTransfer = updateAccountTransfer;
        }

        public override bool CheckAccess()
        {
            return Util.CheckAccess(AccessPermission.KeToan_DangKyChuyenTien);
        }


        private void BankBranchForm_Load(object sender, EventArgs e)
        {
            this.loadProvince();
            this.loadBank();
            this.loadBankBranch(transferBankComboBox.SelectedValue.ToString());
            //provinceComboBox.SelectedValue = Util.VRMService.GetBankBranch(Util.TokenKey,transferBankBranchComboBox.SelectedValue.ToString()).ProvinceCode;
            isAuthorizionComboBox.SelectedIndex = 0;

            if (accountTransfer != null)
            {
                customerIDTextBox.Enabled = false;
                //accountIDTextBox.Enabled = false;

                accountIDTextBox.Text = accountTransfer.AccountID;
                customerIDTextBox.Text=accountTransfer.CustomerID;
                accountTransferNameTextBox.Text=accountTransfer.AccountName;
                if (accountTransfer.isAuthorization == "Y")
                    isAuthorizionComboBox.SelectedIndex = 1;
                transferBankComboBox.SelectedValue= accountTransfer.BankCode;
                transferBankBranchComboBox.SelectedValue=accountTransfer.BankBranchCode;
                cardIdentityTextBox.Text = accountTransfer.CardIdentity;
                cardDateDateTimePicker.Value=accountTransfer.CardDate;
                cardIssuerTextBox.Text=accountTransfer.CardIssuer;

                if (accountTransfer.Active)
                    activeComboBox.SelectedIndex = 0;
                else
                    activeComboBox.SelectedIndex = 1;

                findButton.PerformClick();
            }
        }

        private void loadProvince() {
            provinceComboBox.DataSource = Util.VRMService.GetAllProvince(Util.TokenKey);
            provinceComboBox.DisplayMember = "ProvinceName";
            provinceComboBox.ValueMember = "ProvinceCode";
        }

        private void loadBank()
        {
            Bank bank = new Bank();
            bank.FullName = "-------------Chọn ngân hàng-------------";
            bank.BankCode = "";
            List<Bank> list = new List<Bank>(Util.VRMService.GetBankList(Util.TokenKey));
            list.Insert(0, bank);
            transferBankComboBox.DataSource = list;
            transferBankComboBox.DisplayMember = "FullName";
            transferBankComboBox.ValueMember = "BankCode";
            
        }

        private void loadBankBranch(string bankCode)
        {
            //transferBankBranchComboBox.Items.Insert(0, "---Chọn chi nhánh---");
            transferBankBranchComboBox.DataSource = Util.VRMService.GetBankBranchList(Util.TokenKey, bankCode);
            transferBankBranchComboBox.DisplayMember = "FullName";
            transferBankBranchComboBox.ValueMember = "BankBranchCode";
            

        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                ShowError("Dữ liệu chưa hợp lệ, xin vui lòng kiểm tra lại!");
                return;
            }
            errorProvider.Clear();

            accountTransfer = new AccountTransfer();
            accountTransfer.AccountID = accountIDTextBox.Text;
            accountTransfer.CustomerID = customerIDTextBox.Text;
            accountTransfer.AccountName = accountTransferNameTextBox.Text;
            if (isAuthorizionComboBox.SelectedIndex == 1)
                accountTransfer.isAuthorization = "Y";
            accountTransfer.BankCode = transferBankComboBox.SelectedValue.ToString(); ;
            accountTransfer.BankBranchCode = transferBankBranchComboBox.SelectedValue.ToString();
            accountTransfer.CardIdentity = cardIdentityTextBox.Text;
            accountTransfer.CardDate = cardDateDateTimePicker.Value;
            accountTransfer.CardIssuer = cardIssuerTextBox.Text;
            if (activeComboBox.SelectedIndex == 0)
                accountTransfer.Active = true;
            else
                accountTransfer.Active = false;
            
            try
            {
                if (customerIDTextBox.Enabled)
                    Util.VRMService.InsertAccountTransfer(Util.TokenKey, accountTransfer);
                else
                    Util.VRMService.UpdateAccountTransfer(Util.TokenKey, accountTransfer);
            }
            catch (Exception ex){
                ShowError("Lỗi: " + ex.Message);
                return;
            }
            ShowNotice("Cập nhật thành công");
            this.Close();
        }

        private bool validateData() {
            Boolean valid = true;
            if (string.IsNullOrEmpty(accountTransferNameTextBox.Text))
            {
                errorProvider.SetError(accountTransferNameTextBox, "Tên người thụ hưởng không được để trống");
                valid = false;
            }

            if (string.IsNullOrEmpty(accountIDTextBox.Text))
            {
                errorProvider.SetError(accountIDTextBox, "Số tài khoản không được để trống");
                valid = false;
            }


            if (string.IsNullOrEmpty(customerNameTextBox.Text) || string.IsNullOrEmpty(customerIDTextBox.Text))
            {
                errorProvider.SetError(customerNameTextBox, "Không xác định khách hàng đăng ký dịch vụ");
                valid = false;
            }


            if (string.IsNullOrEmpty(transferBankComboBox.SelectedValue.ToString()))
            {
                errorProvider.SetError(transferBankComboBox, "Không xác định ngân hàng");
                valid = false;
            }


            return valid;
        
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void transferBankComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadBankBranch(transferBankComboBox.SelectedValue.ToString());
        }

        private void findButton_Click(object sender, EventArgs e)
        {
             Customer c = Util.GetCustomer(customerIDTextBox.Text);
             if (c == null)
             {
                 errorProvider.SetError(customerIDTextBox, "Không tìm thấy khách hàng!");
                 customerNameTextBox.Text = string.Empty;
             }
             else
             {
                 customerIDTextBox.Text = c.CustomerId;
                 customerNameTextBox.Text = c.CustomerName;
                 errorProvider.Clear();
             }
        }

        private void transferBankBranchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(transferBankBranchComboBox.SelectedValue.ToString()))
                provinceComboBox.SelectedValue = Util.VRMService.GetBankBranch(Util.TokenKey,transferBankBranchComboBox.SelectedValue.ToString()).ProvinceCode;
        }

        private void TKNoiBoButton_Click(object sender, EventArgs e)
        {
            Customer c = Util.GetCustomer(TKNoiBoTextBox.Text);
            if (c == null)
            {
                errorProvider.SetError(TKNoiBoTextBox, "Không tìm thấy tài khoản!");
                accountTransferNameTextBox.Text = string.Empty;
                cardIdentityTextBox.Text = string.Empty;
                cardIssuerTextBox.Text = string.Empty;
                accountIDTextBox.Text = string.Empty;
            }
            else
            {
                TKNoiBoTextBox.Text = c.CustomerId;
                accountTransferNameTextBox.Text = c.CustomerName;
                cardIdentityTextBox.Text = c.CardIdentity;
                cardIssuerTextBox.Text = c.CardIssuer;
                accountIDTextBox.Text = c.CustomerId;
                DateTime carddate;
                DateTime.TryParseExact(c.CardDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out carddate);
                cardDateDateTimePicker.Value = carddate;
                isAuthorizionComboBox.SelectedIndex = 1;
                activeComboBox.SelectedIndex = 0;
                errorProvider.Clear();
            }

        }

    }
}
