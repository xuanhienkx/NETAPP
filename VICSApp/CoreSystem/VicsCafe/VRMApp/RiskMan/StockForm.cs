using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.VRMGateway;
using VRMApp.Framework;

namespace VRMApp.RiskMan
{
   public partial class StockForm : FormBase
   {
      Stock stock;
      public bool IsUpdateable = true;
      public StockForm()
      {
         InitializeComponent();
         GUIUtil.FormatTextBoxForCurrency(priceText);
      }

      public StockForm(Stock stock)
         : this()
      {
         this.stock = stock;
      }

      private void UpdateDataInfo(Stock stock)
      {
         textBox1.Text = stock.StockCode;
         giatriNumberUpDown.Value = (decimal)stock.ValueRate;
         priceText.Text = stock.CellingFixedPrice.ToString();
      }

      private void findButton_Click(object sender, EventArgs e)
      {
         try
         {
            stock = Util.VRMService.GetStock(Util.TokenKey, textBox1.Text.Trim());
            if (stock == null)
               throw new Exception();
            UpdateDataInfo(stock);
         }
         catch
         {
            ShowError("Không thấy mã chứng khoán");
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
            textBox1.Focus();
            return;
         }
      }

      private void saveButton_Click(object sender, EventArgs e)
      {
         if (stock == null)
         {
            stock = Util.VRMService.GetStock(Util.TokenKey, textBox1.Text.Trim());
            if (stock == null)
            {
               ShowError("Chứng khoán này không tồn tại trong hệ thống");
               return;
            }
         }
         stock.StockCode = textBox1.Text.Trim().ToUpper();
         stock.CellingFixedPrice = decimal.Parse(priceText.Text);
         stock.ValueRate = (int)giatriNumberUpDown.Value;
         if (stock.CreatedDate != DateTime.MinValue)
         {
            stock.ModifiedBy = Util.LoginUser.UserName;
            stock.ModifiedDate = DateTime.Now.Add(-DateTime.Now.TimeOfDay);
         }
         Util.VRMService.SaveStock(Util.TokenKey, stock);

         if (findButton.Visible)
         {
            if (ShowQuestion("Bạn tiếp tục thêm chứng khoán cầm cố nữa chứ?") == DialogResult.Yes)
            {
               stock = new Stock();
               UpdateDataInfo(stock);
               IsUpdateable = false;
               return;
            }
         }
         this.Close();
      }

      private void exitButton_Click(object sender, EventArgs e)
      {
         IsUpdateable = false;
         this.Close();
      }

      private void StockForm_Load(object sender, EventArgs e)
      {
         if (stock != null)
         {
            UpdateDataInfo(stock);
            textBox1.ReadOnly = true;
            findButton.Visible = false;
         }
      }

      public override bool CheckAccess()
      {
         return Util.CheckAccess(AccessPermission.QTRR_ThietLapDSCKCamCo);
      }
   }
}
