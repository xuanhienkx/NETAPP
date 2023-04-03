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
    public partial class BankForm : FormBase
    {
        public Bank bank;

        public BankForm(Bank updateBank)
        {
            InitializeComponent();
            bank = updateBank;
        }

        public override bool CheckAccess()
        {
            return Util.CheckAccess(AccessPermission.KeToan_DSNganHangChuyenTien);
        }


        private void BankAddEditForm_Load(object sender, EventArgs e)
        {
            if (bank != null) {
                bankCodeTextBox.Enabled = false;
                bankCodeTextBox.Text = bank.BankCode;
                shortNameTextBox.Text = bank.ShortName;
                FullNameTextBox.Text = bank.FullName;
                DelegatePersonTextBox.Text = bank.DelegatePerson;
                DepartmentTextBox.Text = bank.Department;
                PositionTextBox.Text = bank.Position;
                MobileTextBox.Text = bank.Mobile;
                TelTextBox.Text = bank.Tel;
                FaxTextBox.Text = bank.Fax;
                EmailTextBox.Text = bank.Email;
                AddressTextBox.Text = bank.Address;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                ShowError("Dữ liệu chưa hợp lệ, xin vui lòng kiểm tra lại!");
                return;
            }

            bank = new Bank();
            bank.BankCode = bankCodeTextBox.Text;
            bank.ShortName = shortNameTextBox.Text;
            bank.IsPayment = true;
            bank.FullName = FullNameTextBox.Text;
            bank.DelegatePerson = DelegatePersonTextBox.Text;
            bank.Department = DepartmentTextBox.Text;
            bank.Position = PositionTextBox.Text;
            bank.Mobile = MobileTextBox.Text;
            bank.Tel = TelTextBox.Text;
            bank.Fax = FaxTextBox.Text;
            bank.Email = EmailTextBox.Text;
            bank.Address = AddressTextBox.Text;
            bank.Description = DescriptionTextBox.Text;
            try
            {
                if (bankCodeTextBox.Enabled)
                    Util.VRMService.InsertBank(Util.TokenKey, bank);
                else
                    Util.VRMService.UpdateBank(Util.TokenKey, bank);
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
            if (string.IsNullOrEmpty(bankCodeTextBox.Text))
            {
                errorProvider.SetError(bankCodeTextBox, "Mã ngân hàng không được để trống");
                valid = false;
            }

            if (string.IsNullOrEmpty(FullNameTextBox.Text))
            {
                errorProvider.SetError(FullNameTextBox, "Tên ngân hàng không được để trống");
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
