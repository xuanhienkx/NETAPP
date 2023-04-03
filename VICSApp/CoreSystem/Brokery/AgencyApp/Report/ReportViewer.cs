using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Brokery.Controls;
using Brokery.Framework;
using CommonDomain;
using CrystalDecisions.CrystalReports.Engine;

namespace Brokery.Report
{
   public partial class ReportViewer : FormBase
   {
      public ReportViewer()
      {
         InitializeComponent();
      }

      public ReportViewer(ReportClass reportDocument)
         : this()
      {
         crystalReportViewer1.ReportSource = reportDocument;
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.None; }
      }

      private void ReportViewer_Load(object sender, EventArgs e)
      {
         crystalReportViewer1.Show();
      }

      internal static ReportViewer LoadReport(ReportClass reportDocument, Form owner)
      {
         ReportViewer v = new ReportViewer(reportDocument);
         v.MdiParent = Util.MainMDI;
         v.Show();
         v.WindowState = FormWindowState.Maximized;
         return v;
      }
   }
}
