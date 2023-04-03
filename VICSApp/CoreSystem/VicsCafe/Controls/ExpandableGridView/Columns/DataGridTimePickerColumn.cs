using System.Drawing;
using System.ComponentModel;
using VRM.Controls.DataGridColumnExtend;
using System.Windows.Forms;
using System;

namespace VRM.Controls.DataGridColumnExtend
{
   [System.ComponentModel.DesignerCategory("code"), Designer(typeof(System.Windows.Forms.Design.ControlDesigner)), ComplexBindingProperties(), Docking(DockingBehavior.Ask)]
   public class DataGridTimePickerColumn : DataGridColumnStyle
   {
      private CustomDateTimePicker customDateTimePicker1 = new CustomDateTimePicker();

      // The isEditing field tracks whether or not the user is
      // editing data with the hosted control.
      private bool isEditing;

      public DataGridTimePickerColumn()
         : base()
      {
         customDateTimePicker1.Visible = false;
      }

      protected override void Abort(int rowNum)
      {
         isEditing = false;
         customDateTimePicker1.ValueChanged -= new EventHandler(TimePickerValueChanged);
         Invalidate();
      }

      protected override bool Commit
          (CurrencyManager dataSource, int rowNum)
      {
         customDateTimePicker1.Bounds = Rectangle.Empty;
         customDateTimePicker1.ValueChanged -= new EventHandler(TimePickerValueChanged);

         if (!isEditing)
            return true;

         isEditing = false;

         try
         {
            DateTime value = customDateTimePicker1.Value;
            SetColumnValueAtRow(dataSource, rowNum, value);
         }
         catch (Exception)
         {
            Abort(rowNum);
            return false;
         }

         Invalidate();
         return true;
      }

      protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string displayText, bool cellIsVisible)
      {
         DateTime value = (DateTime)GetColumnValueAtRow(source, rowNum);
         if (cellIsVisible)
         {
            customDateTimePicker1.Bounds = new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width - 4, bounds.Height - 4);
            customDateTimePicker1.Value = value;
            customDateTimePicker1.Visible = true;
            customDateTimePicker1.ValueChanged += new EventHandler(TimePickerValueChanged);
         }
         else
         {
            customDateTimePicker1.Value = value;
            customDateTimePicker1.Visible = false;
         }

         if (customDateTimePicker1.Visible)
            DataGridTableStyle.DataGrid.Invalidate(bounds);

         customDateTimePicker1.Focus();
      }

      protected override Size GetPreferredSize(Graphics g, object value)
      {
         return new Size(100, customDateTimePicker1.PreferredHeight + 4);
      }

      protected override int GetMinimumHeight()
      {
         return customDateTimePicker1.PreferredHeight + 4;
      }

      protected override int GetPreferredHeight(Graphics g, object value)
      {
         return customDateTimePicker1.PreferredHeight + 4;
      }

      protected override void Paint(Graphics g,
          Rectangle bounds,
          CurrencyManager source,
          int rowNum)
      {
         Paint(g, bounds, source, rowNum, false);
      }

      protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight)
      {
         Paint(
             g, bounds,
             source,
             rowNum,
             Brushes.Red,
             Brushes.Blue,
             alignToRight);
      }

      protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
      {
         DateTime date = (DateTime)GetColumnValueAtRow(source, rowNum);
         Rectangle rect = bounds;
         g.FillRectangle(backBrush, rect);
         rect.Offset(0, 2);
         rect.Height -= 2;
         g.DrawString(date.ToString("d"), this.DataGridTableStyle.DataGrid.Font, foreBrush, rect);
      }

      protected override void SetDataGridInColumn(DataGrid value)
      {
         base.SetDataGridInColumn(value);
         if (customDateTimePicker1.Parent != null)
         {
            customDateTimePicker1.Parent.Controls.Remove(customDateTimePicker1);
         }
         if (value != null)
         {
            value.Controls.Add(customDateTimePicker1);
         }
      }

      private void TimePickerValueChanged(object sender, EventArgs e)
      {
         // Remove the handler to prevent it from being called twice in a row.
         customDateTimePicker1.ValueChanged -= new EventHandler(TimePickerValueChanged);
         this.isEditing = true;
         base.ColumnStartedEditing(customDateTimePicker1);
      }
   }
}