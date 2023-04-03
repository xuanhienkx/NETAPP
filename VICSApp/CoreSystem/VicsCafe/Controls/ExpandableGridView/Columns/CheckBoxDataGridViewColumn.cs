﻿using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;

namespace VRM.Controls.DataGridColumnExtend
{
   [ToolboxItem(false),DesignTimeVisible(false)]
   public class CheckBoxDataGridViewColumn : DataGridViewColumnHeaderCell
   {
      private Rectangle CheckBoxRegion;
      private bool checkAll = false;

      protected override void Paint(Graphics graphics,
          Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
          DataGridViewElementStates dataGridViewElementState,
          object value, object formattedValue, string errorText,
          DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
          DataGridViewPaintParts paintParts)
      {

         base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value,
             formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

         graphics.FillRectangle(new SolidBrush(cellStyle.BackColor), cellBounds);

         CheckBoxRegion = new Rectangle(
             cellBounds.Location.X + 1,
             cellBounds.Location.Y + 2,
             18, cellBounds.Size.Height - 7);


         if (this.checkAll)
            ControlPaint.DrawCheckBox(graphics, CheckBoxRegion, ButtonState.Checked);
         else
            ControlPaint.DrawCheckBox(graphics, CheckBoxRegion, ButtonState.Normal);

         Rectangle normalRegion =
             new Rectangle(
             cellBounds.Location.X + 1 + 25,
             cellBounds.Location.Y,
             cellBounds.Size.Width - 26,
             cellBounds.Size.Height);

         graphics.DrawString(value.ToString(), cellStyle.Font, new SolidBrush(cellStyle.ForeColor), normalRegion);
      }

      protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
      {
         //Convert the CheckBoxRegion 
         Rectangle rec = new Rectangle(new Point(0, 0), this.CheckBoxRegion.Size);
         this.checkAll = !this.checkAll;
         if (rec.Contains(e.Location))
         {
            this.DataGridView.Invalidate();
         }
         base.OnMouseClick(e);
      }

      public bool CheckAll
      {
         get { return this.checkAll; }
         set { this.checkAll = value; }
      }
   }
}
