using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Security
{
   public partial class Login : FormBase
   {
      public Login()
      {
         InitializeComponent();
         Util.MainMDI.UpdateStatus();
      }

      private void btnLogin_Click(object sender, EventArgs e)
      {
         if (!string.IsNullOrEmpty(errorProvider1.GetError(txtPassword)) || 
             !string.IsNullOrEmpty(errorProvider1.GetError(txtUserName)))
            return;

         if (!Util.Authorize(txtUserName.Text, txtPassword.Text))
         {
            MessageBox.Show("Tên đăng nhập hay mật khẩu không đúng", "Dang nhap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUserName.Focus();
            return;
         }
         Util.MainMDI.UpdateStatus();

         this.Close();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
         if (!Util.IsAuthenticated())
            Util.MainMDI.Close();
      }

      private void txtPassword_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            btnLogin_Click(null, null);
      }

      private void txtUsername_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            btnLogin_Click(null, null);
      }

      private void Login_FormClosed(object sender, FormClosedEventArgs e)
      {
         Util.MainMDI.InvisibleMenuItem();
      }

      private void txtPassword_Validating(object sender, CancelEventArgs e)
      {
         if (string.IsNullOrEmpty(txtPassword.Text))
            errorProvider1.SetError(txtPassword, "Mật khẩu đăng nhập không được để trống");
         else
            errorProvider1.Clear();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.None; }
      }

      private void txtUserName_Validated(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(txtUserName.Text))
            errorProvider1.SetError(txtUserName, "Tên đăng nhập không được để trống");
         else
            errorProvider1.Clear();
      }

      private void txtUserName_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
            btnLogin.PerformClick();
      }
   }
}
