using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Brokery.AgencyWebService;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Security
{
   public partial class UserInfo : FormBase
   {
      UserLite user;
      public UserInfo(UserLite user)
      {
         InitializeComponent();
         this.user = user;
      }

      public UserLite User
      {
         get 
         {
            if (user == null)
               user = new UserLite();
            return user;
         }
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.VICS_QuanLyNguoiDung_CapNhat; }
      }

      private void UserInfo_Load(object sender, EventArgs e)
      {
         BindData();
         BindUserInfo();
      }

      private void BindUserInfo()
      {
         if (user == null)
            return;

         nameTextBox.Text = user.UserName;
         passwordTextBox.Text = user.Password;
         fullNameTextBox.Text = user.FullName;
         userTransCodeTextBox.Text = user.UserTransCode;
         departmentCombo.SelectedValue = user.DepartmentId;
         groupCombo.SelectedValue = user.GroupId;
         statusComboBox.SelectedValue = user.Status;
         userTransCodeTextBox.Enabled = false;
         passwordTextBox.ReadOnly = true;
         passwordTextBox.BackColor = Color.White;
         lblResetPassword.Visible = true;
         generateUserTransCode.Visible = false;
      }

      private void BindData()
      {
         lblAgency.Text = string.Format("{0} - Mã đơn vị: {1} - Mã giao dịch: {2}", 
            Util.LoginUser.AgencyName.ToUpper(), Util.LoginUser.BranchCode, Util.LoginUser.TradeCode);
         statusComboBox.DataSource = new DropDownObject[] 
         { 
            new DropDownObject("O", "Mở"),
            new DropDownObject("C", "Đóng")
         };
         statusComboBox.ValueMember = "Code";
         statusComboBox.DisplayMember = "Description";

         departmentCombo.DataSource = Util.AgencyGateway.GetDepartmentList(Util.TokenKey);
         departmentCombo.ValueMember = "Id";
         departmentCombo.DisplayMember = "Name";

         groupCombo.DataSource = Util.AgencyGateway.GetGroups(Util.TokenKey);
         groupCombo.ValueMember = "GroupId";
         groupCombo.DisplayMember = "GroupName";
      }

      private void generateUserTransCode_Click(object sender, EventArgs e)
      {
         byte[] data = new byte[3];
         new RNGCryptoServiceProvider().GetBytes(data);
         StringBuilder builder = new StringBuilder();
         for (int i = 0; i < data.Length; i++)
            builder.Append(string.Format("{0:X2}", data[i]));
         userTransCodeTextBox.Text = builder.ToString();
      }

      private void oKButton_Click(object sender, EventArgs e)
      {
         errorProvider.Clear();
         if (departmentCombo.SelectedValue == null)
         {
            errorProvider.SetError(departmentCombo, "Phải chọn phòng ban cho người sử dụng");
            departmentCombo.Focus();
            return;
         }
         if (nameTextBox.Text.Trim().Length == 0)
         {
            errorProvider.SetError(nameTextBox, "Không được để trống");
            nameTextBox.Focus();
            nameTextBox.SelectAll();
            return;
         }
         if (fullNameTextBox.Text.Trim().Length == 0)
         {
            errorProvider.SetError(fullNameTextBox, "Không được để trống");
            fullNameTextBox.Focus();
            fullNameTextBox.SelectAll();
            return;
         }
         if (userTransCodeTextBox.Text.Trim().Length == 0)
         {
            errorProvider.SetError(userTransCodeTextBox, "Không được để trống");
            userTransCodeTextBox.Focus();
            userTransCodeTextBox.SelectAll();
            return;
         }
         if (userTransCodeTextBox.Text.Trim().Length != 6)
         {
            errorProvider.SetError(userTransCodeTextBox, "Mã giao dịch phải đủ 6 ký tự");
            userTransCodeTextBox.Focus();
            userTransCodeTextBox.SelectAll();
            return;
         }
         if (statusComboBox.SelectedIndex == -1)
         {
            errorProvider.SetError(statusComboBox, "Hãy chọn trạng thái");
            statusComboBox.Select();
            return;
         }

         User.UserName = nameTextBox.Text.Trim();
         User.Password = Util.Encrypt(passwordTextBox.Text.Trim());
         User.FullName = fullNameTextBox.Text.Trim();
         User.UserTransCode = userTransCodeTextBox.Text.Trim();
         User.DepartmentId = (int)departmentCombo.SelectedValue;
         User.GroupId = (int)groupCombo.SelectedValue;
         User.Status = statusComboBox.SelectedValue.ToString();
         User.BranchCode = Util.LoginUser.BranchCode;
         User.TradeCode = Util.LoginUser.TradeCode;
         try
         {
            Util.AgencyGateway.InsertOrUpdateUser(Util.TokenKey, User);
            ShowNotice("Thông tin người dừng được cập nhật thành công");
         }
         catch (Exception ex)
         {
            ShowError(ex.Message);
         }
      }

      private void closeButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void lblResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         if (User.UserId == 0)
            return;

         while (true)
         {
            InputDiaglogBox.Result result = InputDiaglogBox.Show("Nhập password mới:", string.Empty, "Đổi password", true);
            if (!result.IsOK)
               break;

            string password = result.InputMessage;
            if (string.IsNullOrEmpty(password))
            {
               if (ShowQuestion("Password mới không được để trống. Bạn có muốn đổi tiếp không?") == DialogResult.No)
                  break;
            }
            try
            {
               user.Password = Util.Encrypt(password);
               Util.AgencyGateway.ChangeUserPassword(Util.TokenKey, User.UserId, user.Password);
               ShowNotice("Password mới đã được cập nhật");
               break;
            }
            catch (Exception ex)
            {
               ShowError(ex.Message);
            }
         }
      }
   }
}