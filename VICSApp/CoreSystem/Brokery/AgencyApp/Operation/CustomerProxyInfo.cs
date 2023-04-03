using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using Customer = Brokery.AgencyWebService.Customer;
using CustomerProxy = Brokery.AgencyWebService.CustomerProxy;

namespace Brokery.Operation
{
    public partial class CustomerProxyInfo : FormBase
    {
        Customer currentCustomer;
        public Customer CurentCustomer
        {
         get { return currentCustomer; }
         set { currentCustomer = value; }
        }

        public CustomerProxyInfo():this(null){}
        public CustomerProxyInfo(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;

        }

        public override IEnumerable<AccessPermission> AccessKey
        {
         get { yield return AccessPermission.VICS_VanTinChiTiet; }
        }

        private void CustomerProxyInfo_Load(object sender, EventArgs e)
        {
            if (!Util.CheckAccess(this.AccessKey))
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }

            this.bindData();
        }

        private void bindData() {
            CustomerProxy customerProxy = Util.AgencyGateway.GetCustomerProxy(Util.TokenKey, currentCustomer.CustomerId);
            if (customerProxy == null)
                return;

            customerIDTextBox.Text = currentCustomer.CustomerId;
            customerNameVietTextBox.Text = currentCustomer.CustomerNameViet;
            proxyNameTextBox.Text = customerProxy.ProxyName;
            proxyNameVietTextBox.Text = customerProxy.ProxyNameViet;

            if (customerProxy.BeginProxyDate != DateTime.MinValue)
                beginProxyDateDateTimePicker.Value = customerProxy.BeginProxyDate;
            else
                beginProxyDateDateTimePicker.CustomFormat = "''";

            if (customerProxy.EndProxyDate != DateTime.MinValue)
                endProxyDateDateTimePicker.Value = customerProxy.EndProxyDate;
            else
                endProxyDateDateTimePicker.CustomFormat = "''";

            proxyCustomerIDTextBox.Text = customerProxy.ProxyCustomerId;

            if (customerProxy.Dob != DateTime.MinValue)
                dobDateTimePicker.Value = customerProxy.Dob;
            else
                dobDateTimePicker.CustomFormat = "''";

            cardIdentityTextBox.Text = customerProxy.CardIdentity;

            if (customerProxy.CardDate != DateTime.MinValue)
                cardDateDateTimePicker.Value = customerProxy.CardDate;
            else
                cardDateDateTimePicker.CustomFormat = "''";

            cardIssuerTextBox.Text = customerProxy.CardIssuer;
            addressTextBox.Text = customerProxy.Address;
            addressVietTextBox.Text = customerProxy.AddressViet;
            MobileTextBox.Text = customerProxy.Mobile;
            emailTextBox.Text = customerProxy.Email;
            this.picSign1.Image = ParseFromByte(customerProxy.SignatureImage1);
            proxyTypeCheckBox1.Checked = customerProxy.ProxyType.Substring(0, 1)=="1"?true:false ;
            proxyTypeCheckBox2.Checked = customerProxy.ProxyType.Substring(1, 1) == "1" ? true : false;
            proxyTypeCheckBox3.Checked = customerProxy.ProxyType.Substring(2, 1) == "1" ? true : false;


        }

        public static Image ParseFromByte(byte[] data)
        {
            if (data == null)
                return null;

            System.IO.MemoryStream stream = new System.IO.MemoryStream(data);
            return Image.FromStream(stream);
        }


    }
}
