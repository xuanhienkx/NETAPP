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
using VRMApp.Reports.Accountant;

namespace VRMApp.Accountant
{
   public partial class ShowBalanceAccountForm : FormBase
   {
      public ShowBalanceAccountForm()
      {
         InitializeComponent();
         GUIUtil.FormatDatePicker(fromDatedateTimePicker);
         GUIUtil.FormatDatePicker(toDatedateTimePicker);
         GUIUtil.FormatTextBoxForNumber(textBoxDauNgay);
         maCNtextBox.Text = Util.LoginUser.BranchCode;
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.KeToan_BaoCaoTongHopTaiKhoan);
      }

      private void checkBox1_CheckedChanged(object sender, EventArgs e)
      {
         TKChiTietTextBox.Enabled = !checkBox1.Checked;
         textBoxDauNgay.Enabled = checkBox1.Checked;
      }

      private void exitButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void printButton_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(TKChiTietTextBox.Text.Trim()) && !checkBox1.Checked)
         {
            ShowError("Tài khoản chi tiết không được để trống.");
            TKChiTietTextBox.Focus();
            return;
         }

         ShowWaiting("Đang lấy dữ liệu");

         bool isGetBeginDay = string.IsNullOrEmpty(textBoxDauNgay.Text.Trim()) && checkBox1.Checked;
         DataSet datSet = Util.VRMService.ShowBalanceAccountTransaction(Util.TokenKey, 
            TKTongHopTextBox.Text.Trim(),
            maQuanLyTextBox.Text.Trim(),
            checkBox1.Checked ? string.Empty : TKChiTietTextBox.Text.Trim(), 
            fromDatedateTimePicker.Value, toDatedateTimePicker.Value,
            isGetBeginDay);

         int dataIndex = isGetBeginDay ? 1 : 0;
         if (Reports.ReportUtil.DataNotValidated(datSet.Tables[dataIndex].Rows.Count))
            return;

         LietKetGDTKNoiBang rp = new LietKetGDTKNoiBang();
         rp.SetDataSource(datSet.Tables[dataIndex]);
         decimal balance = 0M;

         if (isGetBeginDay && datSet.Tables[0].Rows.Count > 0 && !datSet.Tables[0].Rows[0].IsNull("balance"))
            balance = (decimal)datSet.Tables[0].Rows[0]["balance"];
         else
            decimal.TryParse(textBoxDauNgay.Text.Trim(), out balance);

         rp.SetParameterValue("dudauky", balance);
         rp.SetParameterValue("fromDate", fromDatedateTimePicker.Value.ToString("dd/MM/yyyy"));
         rp.SetParameterValue("maCN", Util.LoginUser.BranchCode);
         rp.SetParameterValue("maQL", maQuanLyTextBox.Text.Trim());
         rp.SetParameterValue("maTKTH", TKTongHopTextBox.Text.Trim());
         rp.SetParameterValue("TKchitiet", string.IsNullOrEmpty(TKTongHopTextBox.Text.Trim()) ? "Tài khoản tổng" : TKTongHopTextBox.Text.Trim());
         rp.SetParameterValue("toDate", toDatedateTimePicker.Value.ToString("dd/MM/yyyy"));
         rp.SetParameterValue("location", GUIUtil.DateAndPlaceAsString(Util.CurrentTransactionDate, Util.LoginUser.BranchCode));
         rp.SetParameterValue("btortkct", checkBox1.Checked? "TK chi tiết" : "Bút toán");

         Reports.ReportViewerForm.LoadReport(rp, null);
      }
   }
}
