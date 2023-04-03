using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;
using VRMApp.VRMGateway;
using VRMApp.Reports;
using VRMApp.Reports.RiskMan;


namespace VRMApp.Accountant
{
    public partial class BankBranchForm : FormBase
    {
        public BankBranch bankBranch;
        public string BankCode;

        public BankBranchForm(BankBranch updateBranch,string bankCode)
        {
            InitializeComponent();
            bankBranch = updateBranch;
            BankCode = bankCode;
        }

        public override bool CheckAccess()
        {
            return Util.CheckAccess(AccessPermission.KeToan_DSChiNhanhChuyenTien);
        }


        private void BankBranchForm_Load(object sender, EventArgs e)
        {
            this.loadProvince();
            if (bankBranch != null)
            {
                bankBranchCodeTextBox.Enabled = false;
                bankBranchCodeTextBox.Text = bankBranch.BankBranchCode;
                shortNameTextBox.Text = bankBranch.ShortName;
                FullNameTextBox.Text = bankBranch.FullName;
                DelegatePersonTextBox.Text = bankBranch.DelegatePerson;
                DepartmentTextBox.Text = bankBranch.Department;
                PositionTextBox.Text = bankBranch.Position;
                MobileTextBox.Text = bankBranch.Mobile;
                TelTextBox.Text = bankBranch.Tel;
                FaxTextBox.Text = bankBranch.Fax;
                EmailTextBox.Text = bankBranch.Email;
                AddressTextBox.Text = bankBranch.Address;
                provinceComboBox.SelectedValue = bankBranch.ProvinceCode;
                bankBranch.BankCode = BankCode;
            }
        }

        private void loadProvince() {

            provinceComboBox.DataSource = Util.VRMService.GetAllProvince(Util.TokenKey);
            provinceComboBox.DisplayMember = "ProvinceName";
            provinceComboBox.ValueMember = "ProvinceCode";
        
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                ShowError("Dữ liệu chưa hợp lệ, xin vui lòng kiểm tra lại!");
                return;
            }
            errorProvider.Clear();

            bankBranch = new BankBranch();
            bankBranch.BankBranchCode = bankBranchCodeTextBox.Text;
            bankBranch.ShortName = shortNameTextBox.Text;
            bankBranch.IsPayment = true;
            bankBranch.FullName = FullNameTextBox.Text;
            bankBranch.DelegatePerson = DelegatePersonTextBox.Text;
            bankBranch.Department = DepartmentTextBox.Text;
            bankBranch.Position = PositionTextBox.Text;
            bankBranch.Mobile = MobileTextBox.Text;
            bankBranch.Tel = TelTextBox.Text;
            bankBranch.Fax = FaxTextBox.Text;
            bankBranch.Email = EmailTextBox.Text;
            bankBranch.Address = AddressTextBox.Text;
            bankBranch.Description = DescriptionTextBox.Text;
            bankBranch.ProvinceCode = provinceComboBox.SelectedValue.ToString();
            bankBranch.BankCode = BankCode;

            try
            {
                if (bankBranchCodeTextBox.Enabled)
                    Util.VRMService.InsertBankBranch(Util.TokenKey, bankBranch);
                else
                    Util.VRMService.UpdateBankBranch(Util.TokenKey, bankBranch);
            }
            catch (Exception ex) {
                ShowError("Lỗi: " + ex.Message);
                return;
            }
            
            ShowNotice("Cập nhật thành công");
            this.Close();
        }

        private bool validateData() {
            Boolean valid = true;
            if (string.IsNullOrEmpty(bankBranchCodeTextBox.Text))
            {
                errorProvider.SetError(bankBranchCodeTextBox, "Mã chi nhánh không được để trống");
                valid = false;
            }

            if (string.IsNullOrEmpty(FullNameTextBox.Text))
            {
                errorProvider.SetError(FullNameTextBox, "Tên chi nhánh không được để trống");
                valid = false;
            }

            if (string.IsNullOrEmpty(shortNameTextBox.Text))
            {
                errorProvider.SetError(shortNameTextBox, "Tên viết tắt không được để trống");
                valid = false;
            }
            return valid;
        
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
