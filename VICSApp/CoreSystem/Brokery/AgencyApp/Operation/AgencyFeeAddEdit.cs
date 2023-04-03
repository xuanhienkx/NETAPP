using System;
using System.Collections.Generic;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Operation
{
   public partial class AgencyFeeAddEdit : FormBase
   {
      private int _feeID=0;
      public int FeeID
      {
          get
          {
              return _feeID;
          }
          set
          {
              _feeID = value;
          }
      }

      public AgencyFeeAddEdit()
      {
         InitializeComponent();
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
          get { yield return AccessPermission.VICS_CapNhatPhiDaiLy; }
      }


      private void oKButton_Click(object sender, EventArgs e)
      {
          if (!validateAllData())
              return;

          if (FeeID != 0)
          { //Update
              Util.AgencyGateway.EditAgencyFee(
                  Util.TokenKey, 
                  FeeID, 
                  Convert.ToInt32(valueFromTextBox.Text), 
                  Convert.ToInt32(toValueTextBox.Text),
                  Convert.ToDecimal(agencyFeeTextBox.Text),
                  noteTextBox.Text);
          }
          else { //new
              Util.AgencyGateway.NewAgencyFee(
                  Util.TokenKey,
                  Convert.ToInt32(valueFromTextBox.Text),
                  Convert.ToInt32(toValueTextBox.Text),
                  Convert.ToDecimal(agencyFeeTextBox.Text),
                  noteTextBox.Text);
          }
         ShowNotice("Cập nhật thành công");
         this.Close();
      }

      private void closeButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void AgencyFeeAddEdit_Load(object sender, EventArgs e)
      {
          tradeCodeBox.Text = Util.LoginUser.TradeCode;
          if (FeeID != 0) {
              Brokery.AgencyWebService.AgencyFee agencyFee = new Brokery.AgencyWebService.AgencyFee();
              agencyFee = Util.AgencyGateway.GetAgencyFee(Util.TokenKey, FeeID);
              valueFromTextBox.Text = agencyFee.ValueFrom.ToString();
              toValueTextBox.Text = agencyFee.ToValue.ToString();
              agencyFeeTextBox.Text = agencyFee.Fee.ToString();
              noteTextBox.Text = agencyFee.Note;
          }
      }

      private bool validateAllData() {
          if (string.IsNullOrEmpty(valueFromTextBox.Text))
          {
              errorProvider1.SetError(valueFromTextBox, "Không được để trống");
              return false;
          }
          if (string.IsNullOrEmpty(valueFromTextBox.Text)) {
              try {
                  int i = int.Parse(valueFromTextBox.Text);
                  if (i < 0) {
                      errorProvider1.SetError(toValueTextBox, "Dữ liệu phải >=0");
                      return false;
                  }
              }
              catch {
                  errorProvider1.SetError(toValueTextBox, "Dữ liệu không hợp lệ");
                  return false;
              }
          }

          if (string.IsNullOrEmpty(toValueTextBox.Text))
          {
              errorProvider1.SetError(toValueTextBox, "Không được để trống");
              return false;
          }
          if (string.IsNullOrEmpty(toValueTextBox.Text))
          {
              try
              {
                  int i = int.Parse(toValueTextBox.Text);
                  if (i < 0)
                  {
                      errorProvider1.SetError(toValueTextBox, "Dữ liệu phải >=0");
                      return false;
                  }
              }
              catch
              {
                  errorProvider1.SetError(toValueTextBox, "Dữ liệu không hợp lệ");
                  return false;
              }
          }

          if (string.IsNullOrEmpty(agencyFeeTextBox.Text))
          {
              errorProvider1.SetError(agencyFeeTextBox, "Không được để trống");
              return false;
          }
          if (string.IsNullOrEmpty(agencyFeeTextBox.Text))
          {
              try
              {
                  int i = int.Parse(agencyFeeTextBox.Text);
                  if (i < 0)
                  {
                      errorProvider1.SetError(agencyFeeTextBox, "Dữ liệu phải >=0");
                      return false;
                  }
              }
              catch
              {
                  errorProvider1.SetError(agencyFeeTextBox, "Dữ liệu không hợp lệ");
                  return false;
              }
          }
          return true;

      }

   }
}
