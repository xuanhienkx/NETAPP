using System;
using System.Linq;
using System.Windows.Forms;

namespace Brokery.Framework
{
    public static class GUIUtil
    {
        public static System.Drawing.Image CheckedImage = Properties.Resources.action_check;
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
            FormatGridView(grid, false, true);
        }

        public static void FormatGridView(DataGridView grid, bool isMultiSelection, bool isReadOnly)
        {
            grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle defaultStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternateStyle = new System.Windows.Forms.DataGridViewCellStyle();

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

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


            foreach (DataGridViewColumn c in grid.Columns)
            {
                c.ReadOnly = isReadOnly;
                if (c.HasDefaultCellStyle) c.DefaultCellStyle.Font = defaultStyle.Font;
            }
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
            ctr.KeyPress += GUIHelper.CurrencyTextBox_KeyPress;
            ctr.TextChanged += GUIHelper.CurrencyTextBox_TextChanged;
            //ctr.LostFocus += GUIHelper.CurrencyTextBox_TextLostFocus;
        }

        public static void AddVisibilityContextMenuOnColumns(DataGridView grid)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (DataGridViewColumn c in grid.Columns)
            {
                if (!string.IsNullOrEmpty(c.HeaderText))
                    menu.Items.Add(c.HeaderText, c.Visible ? CheckedImage : null);
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


        internal static string BranchCodeAsString(string branch)
        {
            if (string.IsNullOrEmpty(branch))
                return "Tất cả";
            else if (branch == "100")
                return "Hội sở";
            else if (branch == "200")
                return "Chi nhánh Tp.Hồ Chí Minh";
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
        }

        internal static void FormatDropDownList(ComboBox comboBox)
        {
            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "Code";
        }

        internal static string AsCurrency(this decimal value)
        {
            return string.Format("{0:c0}", value);
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

            if (str.StartsWith(Util.CurrentCulture.NumberFormat.NumberGroupSeparator))
            {
                str = str.Substring(1);
                if (iStart > 0)
                    me.SelectionStart = --iStart;
            }
            else
                str = me.Text;

            int idx = str.IndexOf(Util.CurrentCulture.NumberFormat.NumberGroupSeparator);
            me.Text = string.Format("{0:#,##0}", decimal.Parse(str));

            if (str.Length < me.Text.Length && idx <= iStart)
                me.SelectionStart = ++iStart;
            else if (str.Length > me.Text.Length && me.SelectionStart > 0)
                me.SelectionStart = --iStart;
            else
                me.SelectionStart = iStart;
        }

        internal static void CurrencyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var me = sender as TextBox;

            string key = e.KeyChar.ToString();
            if (key == Util.CurrentCulture.NumberFormat.CurrencyDecimalSeparator ||
                key == Util.CurrentCulture.NumberFormat.CurrencyGroupSeparator)
            {
                me.SelectionStart++;
            }
            else if ((Keys) e.KeyChar == Keys.Back)
            {
                me.Tag = "Keys.Back";
            }

            e.Handled = !(char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar));
        }

        internal static void CurrencyTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox me = sender as TextBox;
            if ("CurrencyTextBox_TextChanged".Equals(me.Tag)
                || "CurrencyTextBox_TextLostFocus".Equals(me.Tag))
            {
                me.Tag = null;
                return;
            }

            string str = me.Text;

            if (string.IsNullOrEmpty(str) || str == "0,0")
            {
                me.Text = "0,0";
                return;
            }

            int iStart = me.SelectionStart;

            if ("Keys.Back".Equals(me.Tag))
            {
                if (str.EndsWith(".") || str.EndsWith(","))
                    str = str.Remove(str.Length - 1, 1);
                else
                    str = str.Remove(str.Length - 1, 1) + "0";
                iStart--;
            }
            
            if (str.StartsWith(Util.CurrentCulture.NumberFormat.CurrencyGroupSeparator))
            {
                str = str.Substring(1);
                if (iStart > 0)
                    me.SelectionStart = --iStart;
            }
            int idx = str.IndexOf(Util.CurrentCulture.NumberFormat.CurrencyDecimalSeparator, StringComparison.OrdinalIgnoreCase);
            me.Tag = "CurrencyTextBox_TextChanged";
            me.Text = string.Format("{0:###,##0.000}", decimal.Parse(str));

            if (str.Length < me.Text.Length)
            {
                var dotCount = me.Text.Count(c => c == '.') - str.Count(c => c == '.');
                iStart += dotCount;
                if (idx >= iStart)
                    iStart++;
            }

            me.SelectionStart = iStart;
            me.SelectionLength = me.TextLength - me.SelectionStart;
        }

        public static void CurrencyTextBox_TextLostFocus(object sender, EventArgs e)
        {
            TextBox me = sender as TextBox;
            me.Tag = "CurrencyTextBox_TextLostFocus";
            me.Text = string.Format("{0:###,##0.000}", decimal.Parse(me.Text));
        }
    }
}
