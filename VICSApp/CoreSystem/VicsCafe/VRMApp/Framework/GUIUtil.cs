using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;

namespace VRMApp.Framework
{
   public static class GUIUtil
   {
      public static System.Drawing.Image CheckedImage = VRMApp.Properties.Resources.action_check;
      public static string AccountHeader = System.Configuration.ConfigurationManager.AppSettings["AccountHeader"];

      public static void ToUpcaseKeyPress(object sender, KeyPressEventArgs e)
      {
         if (('a' <= e.KeyChar) && (e.KeyChar <= 'z'))
         {
            e.KeyChar = (char)(e.KeyChar - ' ');
         }
      }

      public static void FormatGridView(DataGridView grid)
      {
         FormatGridView(grid, false);
      }

      public static void FormatGridView(DataGridView grid, bool isMultiSelection)
      {
         grid.BackgroundColor = System.Drawing.Color.AntiqueWhite;
         System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle defaultStyle = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle alternateStyle = new System.Windows.Forms.DataGridViewCellStyle();

         headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         headerStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

         defaultStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

         defaultStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         defaultStyle.SelectionForeColor = defaultStyle.ForeColor = System.Drawing.Color.Black;
         defaultStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;

         defaultStyle.BackColor = Util.Parameters.DefaultRowBackColor;
         defaultStyle.SelectionBackColor = Util.Parameters.DefaultSelectedRowBackColor;
         alternateStyle.BackColor = Util.Parameters.AlternateRowBackColor;
         alternateStyle.SelectionBackColor = Util.Parameters.AlternateSelectedRowBackColor;

         alternateStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         alternateStyle.ForeColor = alternateStyle.SelectionForeColor = System.Drawing.Color.Black;
         alternateStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

         grid.ColumnHeadersDefaultCellStyle = headerStyle;
         grid.DefaultCellStyle = defaultStyle;
         grid.AlternatingRowsDefaultCellStyle = alternateStyle;

         grid.AllowUserToResizeColumns = true;
         grid.AllowUserToAddRows = false;
         grid.AllowUserToDeleteRows = false;
         grid.AllowUserToOrderColumns = true;
         grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));

         grid.RowHeadersWidth = 20;
         grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         grid.MultiSelect = isMultiSelection;
         grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         grid.AutoGenerateColumns = false;

         foreach (DataGridViewColumn c in grid.Columns)
            c.ReadOnly = true;
      }

      public static void AddContextMenuOnColumns(DataGridView grid)
      {
         grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
         ContextMenuStrip menu = new ContextMenuStrip();
         foreach (DataGridViewColumn c in grid.Columns)
         {
            if (!string.IsNullOrEmpty(c.HeaderText))
               menu.Items.Add(c.HeaderText, CheckedImage);
         }

         grid.MouseUp += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
         {
            if (e.Button == MouseButtons.Right && grid.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader)
               menu.Show(grid, new System.Drawing.Point(e.X, e.Y));
         });
         menu.ItemClicked += new ToolStripItemClickedEventHandler(delegate(object sender, ToolStripItemClickedEventArgs e)
         {
            e.ClickedItem.Image = (e.ClickedItem.Image == null) ? CheckedImage : null;
            foreach (DataGridViewColumn c in grid.Columns)
            {
               if (c.HeaderText != e.ClickedItem.Text)
                  continue;

               c.Visible = !c.Visible;
               break;
            }
         });
      }

      public static void AlignmentColumn(DataGridViewColumn column, System.Windows.Forms.DataGridViewContentAlignment alignment)
      {
         column.DefaultCellStyle.Alignment = alignment;
      }

      public static void FormatTextBoxForNumber(TextBox ctr)
      {
         ctr.TextAlign = HorizontalAlignment.Right;
         ctr.KeyPress += new KeyPressEventHandler(GUIHelper.NumberTextBox_KeyPress);
         ctr.TextChanged += new EventHandler(GUIHelper.NumberTextBox_TextChanged);
      }

      public static void FormatTextBoxForCurrency(TextBox ctr)
      {
         ctr.TextAlign = HorizontalAlignment.Right;
         ctr.KeyPress += new KeyPressEventHandler(GUIHelper.CurrencyTextBox_KeyPress);
         ctr.TextChanged += new EventHandler(GUIHelper.CurrencyTextBox_TextChanged);
      }

      public static void AddContextMenuOnColumns(DataGridView grid, ContextMenuStrip menu)
      {
         foreach (DataGridViewColumn c in grid.Columns)
         {
            if (!string.IsNullOrEmpty(c.HeaderText))
               menu.Items.Add(c.HeaderText, CheckedImage);
         }

         grid.MouseUp += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
            {
               if (e.Button == MouseButtons.Right && grid.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader)
                  menu.Show(grid, new System.Drawing.Point(e.X, e.Y));
            });
         menu.ItemClicked += new ToolStripItemClickedEventHandler(delegate(object sender, ToolStripItemClickedEventArgs e)
            {
               e.ClickedItem.Image = (e.ClickedItem.Image == null) ? CheckedImage : null;
               foreach (DataGridViewColumn c in grid.Columns)
               {
                  if (c.HeaderText != e.ClickedItem.Text)
                     continue;

                  c.Visible = !c.Visible;
                  break;
               }
            });
      }

      internal static string UserAsString(VRMApp.VRMGateway.UserLite user)
      {
         return string.Format("{0} ({1})", user.FullName, user.UserName);
      }

      internal static string BranchCodeAsString(string branch)
      {
         if (string.IsNullOrEmpty(branch))
            return "Tất cả";
         else if (branch == "100")
            return "Hội sở";
         else if (branch == "200")
            return "CN Tp.Hồ Chí Minh";
         else if (branch == "300")
            return "Chi nhánh Huế";
         else
            return string.Empty;
      }

      internal static string MarketStatusAsString(string code)
      {
         if (code == "P")
            return "P : Thị trường chưa mở cửa giao dịch";
         else if (code == "O")
            return "O : Thị trường ĐANG giao dịch";
         else if (code == "C")
            return "C : Thị trường đã đóng cửa. Chưa hạch toán ngày T";
         else if (code == "E")
            return "E : Thị trường đóng cửa. Đã hạch toán xong ngày T";
         return "Không xác định";
      }

      internal static string EmptyStringOrDefault(string customerId, string defaultString)
      {
         if (string.IsNullOrEmpty(customerId))
            return defaultString;
         return customerId;
      }

      internal static object DateAndPlaceAsString(DateTime dateTime, string branchCode)
      {
         return string.Format("{0}, ngày {1} tháng {2} năm {3}",
            (branchCode == "100") ? "Hà nội" : "Tp. Hồ Chí Minh",
            dateTime.Day,
            dateTime.Month,
            dateTime.Year);
      }

      internal static object DateAsString(DateTime dateTime)
      {
         return string.Format("ngày {0} tháng {1} năm {2}",
            dateTime.Day,
            dateTime.Month,
            dateTime.Year);
      }

      internal static string ValidateCustomerId(string shortCustomerId)
      {
         if (shortCustomerId.Length >= 10)
            return shortCustomerId.Substring(shortCustomerId.Length - 10, 10);

         string result = string.Empty;
         for (int i = 0; i < AccountHeader.Length; i++)
         {
            result = result.PadRight(i + 1, AccountHeader[i]);
            if (result.Length + shortCustomerId.Length == 10)
               break;
         }
         if (result.Length + shortCustomerId.Length < 10)
            result = result.PadRight(10 - shortCustomerId.Length, '0');
         return result + shortCustomerId;
      }

      internal static void FormatDatePicker(DateTimePicker datePicker)
      {
         datePicker.Format = DateTimePickerFormat.Custom;
         datePicker.CustomFormat = "dd/MM/yyyy";
         datePicker.Value = Util.CurrentTransactionDate;
         datePicker.Size = new System.Drawing.Size(90, 25);
      }

      public static string MoneyAsString(decimal? money)
      {
         if (!money.HasValue)
            money = 0M;
         return string.Format("{0:c0}", decimal.Round(money.Value));
      }

      public static string FormatNumber(decimal? d)
      {
         if (!d.HasValue)
            d = 0M;
         return string.Format("{0:n0}", d);
      }

      public static string FormatRate(decimal? d, bool isPercent)
      {
         return FormatRate(d, 0, isPercent);
      }

      public static string FormatRate(decimal? d, int decimalDigits, bool isPercent)
      {
         //if (d == null || d == 0M)
         //   return string.Empty;

         CultureInfo provider = Util.CurrentCulture.Clone() as CultureInfo;
         provider.NumberFormat.PercentDecimalDigits = decimalDigits;

         if (isPercent)
            return string.Format(provider, "{0:p}", d);
         return string.Format(provider, "{0:0.0####}", d);
      }  

      internal static string FormatDate(DateTime? d)
      {
         if (!d.HasValue || d.Value == DateTime.MinValue || d.Value == DateTime.MaxValue)
            return string.Empty;
         return d.Value.ToString("dd/MM/yyyy");
      }
   }

   internal static class GUIHelper
   {
      internal static void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         e.Handled = !(char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar));
      }

      internal static void NumberTextBox_TextChanged(object sender, EventArgs e)
      {
         TextBox me = sender as TextBox;
         string str = me.Text;
         int iStart = me.SelectionStart;

         if (string.IsNullOrEmpty(str))
            return;
         else if (str.StartsWith(Util.CurrentCulture.NumberFormat.NumberGroupSeparator))
         {
            str = str.Substring(1);
            if (iStart > 0)
               me.SelectionStart = --iStart;
         }
         str = me.Text;
         int idx = str.IndexOf(Util.CurrentCulture.NumberFormat.NumberGroupSeparator);
         me.Text = string.Format("{0:n0}", decimal.Parse(str.Replace(".", string.Empty)));

         if (str.Length < me.Text.Length && idx <= iStart)
            me.SelectionStart = ++iStart;
         else if (str.Length > me.Text.Length && me.SelectionStart > 0)
            me.SelectionStart = --iStart;
         else
            me.SelectionStart = iStart;
      }

      internal static void CurrencyTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         e.Handled = !(char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar));

         string key = e.KeyChar.ToString();
         if (key == Util.CurrentCulture.NumberFormat.CurrencyDecimalSeparator ||
             key == Util.CurrentCulture.NumberFormat.CurrencyGroupSeparator)
         {
            (sender as TextBox).SelectionStart++;
         }
      }

      internal static void CurrencyTextBox_TextChanged(object sender, EventArgs e)
      {
         TextBox me = sender as TextBox;
         string str = me.Text;

         int iStart = me.SelectionStart;
         if (str.StartsWith(Util.CurrentCulture.NumberFormat.CurrencyGroupSeparator))
         {
            str = str.Substring(1);
            if (iStart > 0)
               me.SelectionStart = --iStart;
         }
         int idx = str.IndexOf(Util.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
         me.Text = string.Format("{0:n4}", decimal.Parse(str.Replace(".", string.Empty)));

         if (idx < 0 && iStart == str.Length)
            me.SelectionStart = iStart;
         else if (str.Length < me.Text.Length && idx <= iStart)
            me.SelectionStart = ++iStart;
         else if (iStart > me.Text.Length)
            me.SelectionStart = --iStart;
         else
            me.SelectionStart = iStart;
      }
   }
}
