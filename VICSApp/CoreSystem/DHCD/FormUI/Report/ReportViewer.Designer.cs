using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace pmDHCD
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ReportViewer : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            CrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            SuspendLayout();
            // 
            // CrystalReportViewer1
            // 
            CrystalReportViewer1.ActiveViewIndex = -1;
            CrystalReportViewer1.BorderStyle = BorderStyle.FixedSingle;
            CrystalReportViewer1.Cursor = Cursors.Default;
            CrystalReportViewer1.Dock = DockStyle.Fill;
            CrystalReportViewer1.Location = new Point(0, 0);
            CrystalReportViewer1.Name = "CrystalReportViewer1";
            CrystalReportViewer1.Size = new Size(1323, 743);
            CrystalReportViewer1.TabIndex = 0;
            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportViewer
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 743);
            Controls.Add(CrystalReportViewer1);
            Name = "ReportViewer";
            Text = "Xem Phiếu";
            ResumeLayout(false);
        }

        internal CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer1;
    }
}