using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using Customer = Brokery.AgencyWebService.Customer;
using CustomerDetail = Brokery.AgencyWebService.CustomerDetail;

namespace Brokery.Operation
{
    public partial class CustomerDetailInfo : FormBase
    {
        Customer currentCustomer;
        public Customer CurentCustomer
        {
         get { return currentCustomer; }
         set { currentCustomer = value; }
        }

        public CustomerDetailInfo():this(null){}
        public CustomerDetailInfo(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;
        }

        public override IEnumerable<AccessPermission> AccessKey
        {
            get { yield return AccessPermission.VICS_VanTinChiTiet; }
        }

        private void CustomerDetail_Load(object sender, EventArgs e)
        {
            if (!Util.CheckAccess(this.AccessKey))
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }

            this.bindDetailData();
        }

        
        private void uyQuyenLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerProxyInfo objF = new CustomerProxyInfo(currentCustomer);
            objF.ShowDialog();

        }

        private void bindDetailData() {

            CustomerDetail customerDetail = Util.AgencyGateway.GetCustomerDetail(Util.TokenKey, currentCustomer.CustomerId);
            if (currentCustomer == null)
                return;

            customerIDTextBox.Text = currentCustomer.CustomerId;
            customerNameTextBox.Text = currentCustomer.CustomerName;
            customerNameVietTextBox.Text = currentCustomer.CustomerNameViet;

            userIntroduceTextBox.Text = customerDetail.UserIntroduceName;
            userTakeCareTextBox.Text = customerDetail.UserTakeCaredName;
            brokerNameTextBox.Text = customerDetail.BrokerName;
            if (customerDetail.ProxyStatus != 0)
            {
                uyQuyenLink.Enabled = true;
            }
            else {
                uyQuyenLink.Text = "Không có";
                uyQuyenLink.Enabled = false;
            }

            if (dobDateTimePicker.Value != DateTime.MinValue)
                dobDateTimePicker.Value = customerDetail.Dob;
            else
                dobDateTimePicker.CustomFormat = "''";

            sexComboBox.SelectedIndex = customerDetail.Sex == "M" ? 0 : 1;
            contractNumberTextBox.Text = customerDetail.ContractNumber;
            cardIdentityTextBox.Text = currentCustomer.CardIdentity;

            if (cardDateDateTimePicker.Value != DateTime.MinValue)
                cardDateDateTimePicker.Value = customerDetail.CardDate;
            else
                cardDateDateTimePicker.CustomFormat = "''";

            cardIssuerTextBox.Text = customerDetail.CardIssuer;
            cardTypeTextBox.Text = customerDetail.CardType == 1 ? "CMT" : "Hộ chiếu";
            countryTextBox.Text = customerDetail.Country;
            addressTextBox.Text = customerDetail.Address;
            addressVietTextBox.Text = customerDetail.AddressViet;
            mobileTextBox.Text = customerDetail.Mobile;
            emailTextBox.Text = customerDetail.Email;
            MoneyDepositeNumberTextBox.Text = customerDetail.MoneyDepositeNumber;
            MoneyDepositeLocaltionTextBox.Text = customerDetail.MoneyDepositeLocation;
            notesTextBox.Text = customerDetail.Notes;
        }
    }
}
