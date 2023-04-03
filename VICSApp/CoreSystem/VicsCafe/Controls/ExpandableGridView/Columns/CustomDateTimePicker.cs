using System.Windows.Forms;
using System.ComponentModel;

namespace VRM.Controls.DataGridColumnExtend
{
   [System.ComponentModel.DesignerCategory("code"), Designer(typeof(System.Windows.Forms.Design.ControlDesigner)), ComplexBindingProperties(), Docking(DockingBehavior.Ask)]
   public class CustomDateTimePicker : DateTimePicker
   {
      protected override bool ProcessKeyMessage(ref Message m)
      {
         // Keep all the keys for the DateTimePicker.
         return ProcessKeyEventArgs(ref m);
      }
   }
}
