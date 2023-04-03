using System;
using System.Windows.Forms;
using VRMApp.Framework;
using CrystalDecisions.CrystalReports.Engine;
using VRMApp.ControlBase;

namespace VRMApp.Reports
{
   public partial class ReportViewerForm : Form
   {
      public ReportViewerForm()
      {
         InitializeComponent();
      }

      public ReportViewerForm(ReportClass reportDocument)
         : this()
      {
         crystalReportViewer1.ReportSource = reportDocument;
      }

      private void ReportViewer_Load(object sender, EventArgs e)
      {
          WaitingForm.HideMe();
         crystalReportViewer1.Show();
      }
           
      internal static ReportViewerForm LoadReport(ReportClass reportDocument, Form owner)
      {
         ReportViewerForm v = new ReportViewerForm(reportDocument);

         v.Show();
         v.WindowState = FormWindowState.Maximized;
         return v;
      }
   }
}
