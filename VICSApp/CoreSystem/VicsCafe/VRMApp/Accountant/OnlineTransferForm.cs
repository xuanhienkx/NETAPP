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
using System.Globalization;


namespace VRMApp.Accountant
{
    public partial class OnlineTransferForm : FormBase
    {
        public OnlineTransfer onlineTransfer;
        public bool viewOnly = false;


        public OnlineTransferForm(OnlineTransfer updateOnlineTransfer)
        {
            InitializeComponent();
            onlineTransfer = updateOnlineTransfer;

            if (onlineTransfer.Status == "T")
                viewOnly = true;

            trangThaiCombo.DataSource = new DropDownObject[] {
            new DropDownObject("O", "O - Chờ xử lý"),
            new DropDownObject("A", "A - Đang xử lý"),
            new DropDownObject("E", "E - Bị từ chối"),
            new DropDownObject("T", "T - Đã thực hiện"),
            new DropDownObject("X", "X - Đã bị hủy"),
            
            
         };
            trangThaiCombo.DisplayMember = "Description";
            trangThaiCombo.ValueMember = "Code";

        }

        public override bool CheckAccess()
        {
            return Util.CheckAccess(AccessPermission.KeToan_DuyetGiaoDichChuyenTien);
        }


        private void OnlineTransferForm_Load(object sender, EventArgs e)
        {
            if (viewOnly) {
                trangThaiCombo.Enabled = false;
                UpdateButton.Enabled = false;
                transferfeeTextBox.ReadOnly = true;
                rejectTextBox.ReadOnly = true;
            }

            this.loadProvince();
            this.loadBank();
            this.loadBankBranch(transferBankComboBox.SelectedValue.ToString());
            if (transferBankBranchComboBox.SelectedValue!= null)
                provinceComboBox.SelectedValue = Util.VRMService.GetBankBranch(Util.TokenKey,transferBankBranchComboBox.SelectedValue.ToString()).ProvinceCode;

            isAuthorizionComboBox.SelectedIndex = 0;

            if (onlineTransfer != null)
            {
                //customerIDTextBox.Enabled = false;
                //accountIDTextBox.Enabled = false;
                
                //Thong tin khach hang
                customerIDTextBox.Text = onlineTransfer.CustomerID;
                Customer customer = Util.GetCustomer(onlineTransfer.CustomerID);
                customerNameTextBox.Text = customer.CustomerName;

                //Thong tin nguoi thu huong
                AccountTransfer accountTransfer = Util.VRMService.GetAccountTransfer(Util.TokenKey, onlineTransfer.ToAccountID, onlineTransfer.CustomerID);
                if (accountTransfer.isAuthorization == "Y")
                    isAuthorizionComboBox.SelectedIndex = 1;
                else
                    isAuthorizionComboBox.SelectedIndex = 0;

                accountTransferNameTextBox.Text = accountTransfer.AccountName;
                cardIdentityTextBox.Text = accountTransfer.CardIdentity;
                cardDateDateTimePicker.Value = accountTransfer.CardDate;
                cardIssuerTextBox.Text = accountTransfer.CardIssuer;

                //Ngan hang nguoi thu huong
                accountIDTextBox.Text = onlineTransfer.ToAccountID;
                transferBankComboBox.SelectedValue = onlineTransfer.BankCode;
                transferBankBranchComboBox.SelectedValue = onlineTransfer.BankBrachCode;

                //Thong tin chuyen tien
                transferdateDateTimePicker.Value = onlineTransfer.TransferDate;
                amountTextBox.Text = onlineTransfer.Amount.ToString();
                transferfeeTextBox.Text = string.IsNullOrEmpty(onlineTransfer.TransferFee.ToString()) ? "0" : onlineTransfer.TransferFee.ToString();
                remainTextBox.Text = (Convert.ToInt32(amountTextBox.Text) - Convert.ToInt32(transferfeeTextBox.Text)).ToString();
                descriptionTextBox.Text = onlineTransfer.Description;
                rejectTextBox.Text = onlineTransfer.Reject;
                ContractIDTextBox.Text = onlineTransfer.ContractID;
                //Trang thai yc

                switch (onlineTransfer.Status)
                {
                    case "O":
                        trangThaiCombo.SelectedIndex = 0;
                        break;
                    case "A":
                        trangThaiCombo.SelectedIndex = 1;
                        break;
                    case "E":
                        trangThaiCombo.SelectedIndex = 2;
                        break;
                    case "T":
                        trangThaiCombo.SelectedIndex = 3;
                        break;
                    case "X":
                        trangThaiCombo.SelectedIndex = 4;
                        break;
                    default:
                        throw new Exception("Không rõ trạng thái yêu cầu !");
                }

            }
        }

        private void loadProvince() {
            provinceComboBox.DataSource = Util.VRMService.GetAllProvince(Util.TokenKey);
            provinceComboBox.DisplayMember = "ProvinceName";
            provinceComboBox.ValueMember = "ProvinceCode";
        }

        private void loadBank()
        {
            transferBankComboBox.DataSource = Util.VRMService.GetBankList(Util.TokenKey);
            transferBankComboBox.DisplayMember = "FullName";
            transferBankComboBox.ValueMember = "BankCode";
        }

        private void loadBankBranch(string bankCode)
        {
            transferBankBranchComboBox.DataSource = Util.VRMService.GetBankBranchList(Util.TokenKey,bankCode);
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

            onlineTransfer.Status = trangThaiCombo.SelectedValue.ToString();
            onlineTransfer.Reject = rejectTextBox.Text;
            onlineTransfer.TransferFee =  Convert.ToDecimal(transferfeeTextBox.Text);
            Util.VRMService.OnlineTransferChangeStatus(Util.TokenKey, onlineTransfer.TransferID, trangThaiCombo.SelectedValue.ToString(), rejectTextBox.Text, onlineTransfer.TransferFee);

            //accountTransfer = new AccountTransfer();
            //accountTransfer.AccountID = accountIDTextBox.Text;
            //accountTransfer.CustomerID = customerIDTextBox.Text;
            //accountTransfer.AccountName = accountTransferNameTextBox.Text;
            //if (isAuthorizionComboBox.SelectedIndex == 1)
            //    accountTransfer.isAuthorization = "Y";
            //accountTransfer.BankCode = transferBankComboBox.SelectedValue.ToString(); ;
            //accountTransfer.BankBranchCode = transferBankBranchComboBox.SelectedValue.ToString();
            //accountTransfer.CardIdentity = cardIdentityTextBox.Text;
            //accountTransfer.CardDate = cardDateDateTimePicker.Value;
            //accountTransfer.CardIssuer = cardIssuerTextBox.Text;
            
            //try
            //{
            //    if (customerIDTextBox.Enabled)
            //        Util.VRMService.InsertAccountTransfer(Util.TokenKey, accountTransfer);
            //    else
            //        Util.VRMService.UpdateAccountTransfer(Util.TokenKey, accountTransfer);
            //}
            //catch (Exception ex){
            //    ShowError("Lỗi: " + ex.Message);
            //    return;
            //}
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

            if (string.IsNullOrEmpty(transferfeeTextBox.Text))
            {
                errorProvider.SetError(transferfeeTextBox, "Phí chuyển tiền không được để trống");
                valid = false;
            }

            decimal transfee;
            if (!decimal.TryParse(transferfeeTextBox.Text, out transfee))
            {
                errorProvider.SetError(transferfeeTextBox, "Phí chuyển tiền không hợp lệ");
                valid = false;
            }

            if (transfee < 0)
            {
                errorProvider.SetError(transferfeeTextBox, "Phí chuyển tiền lớn hơn 0");
                valid = false;
            }


            if (string.IsNullOrEmpty(customerNameTextBox.Text) || string.IsNullOrEmpty(customerIDTextBox.Text))
            {
                errorProvider.SetError(customerNameTextBox, "Không xác định khách hàng đăng ký dịch vụ");
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


        private void transferBankBranchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(transferBankBranchComboBox.SelectedValue.ToString()))
                provinceComboBox.SelectedValue = Util.VRMService.GetBankBranch(Util.TokenKey,transferBankBranchComboBox.SelectedValue.ToString()).ProvinceCode;
        }

        private void transferfeeTextBox_Validated(object sender, EventArgs e)
        {
            if (!validateData())
            {
                ShowError("Dữ liệu chưa hợp lệ, xin vui lòng kiểm tra lại!");
                return;
            }
            errorProvider.Clear();

            onlineTransfer.TransferFee = Convert.ToInt32(transferfeeTextBox.Text);
            remainTextBox.Text = (Convert.ToInt32(amountTextBox.Text) - Convert.ToInt32(transferfeeTextBox.Text)).ToString();
        }

        private void printContractButton_Click(object sender, EventArgs e)
        {
            ShowWaiting();
            CrystalDecisions.CrystalReports.Engine.ReportClass rp;
            rp = new VRMApp.Reports.Accountant.YeuCauChuyenTienOnline();
            rp.SetParameterValue("CustomerID", customerIDTextBox.Text);
            rp.SetParameterValue("CustomerName", customerNameTextBox.Text);
            rp.SetParameterValue("AccountType", isAuthorizionComboBox.Text);
            rp.SetParameterValue("AccountName", accountTransferNameTextBox.Text);
            rp.SetParameterValue("CardIdentity", cardIdentityTextBox.Text);
            rp.SetParameterValue("CardDate", cardDateDateTimePicker.Value.ToString("dd/MM/yyyy"));
            rp.SetParameterValue("CardIssuer", cardIssuerTextBox.Text);
            rp.SetParameterValue("AccountID", accountIDTextBox.Text);
            rp.SetParameterValue("Bank", transferBankComboBox.Text);
            rp.SetParameterValue("BankBranch", transferBankBranchComboBox.Text);
            rp.SetParameterValue("Province", provinceComboBox.Text);
            rp.SetParameterValue("ContractNumber", ContractIDTextBox.Text);
            rp.SetParameterValue("DateRequest", String.Format("{0:d/M/yyyy - HH:mm:ss}", transferdateDateTimePicker.Value));
            rp.SetParameterValue("ShortDateRequest", String.Format("{0:d/M/yyyy}", transferdateDateTimePicker.Value)); 
            
            rp.SetParameterValue("Amount", onlineTransfer.Amount.ToString("0,0", CultureInfo.CreateSpecificCulture("vi-VN")) + " VNĐ");
            rp.SetParameterValue("Fee", onlineTransfer.TransferFee.ToString("0,0", CultureInfo.CreateSpecificCulture("vi-VN")) + " VNĐ");
            decimal remain = onlineTransfer.Amount - onlineTransfer.TransferFee;
            rp.SetParameterValue("Remain", remain.ToString("0,0", CultureInfo.CreateSpecificCulture("vi-VN")) + " VNĐ");
            

            //rp.SetParameterValue("RemainText",Util.ConverNumberToMoney((onlineTransfer.Amount - onlineTransfer.TransferFee).ToString()));
            rp.SetParameterValue("RemainText", Util.ConverNumberToMoney(remain.ToString("0,0", CultureInfo.CreateSpecificCulture("vi-VN"))));

            rp.SetParameterValue("Description", descriptionTextBox.Text);
            rp.SetParameterValue("Note", rejectTextBox.Text);

            Reports.ReportViewerForm.LoadReport(rp, null);

            CloseWaiting();
        }




    }
}
