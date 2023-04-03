using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace pmDHCD
{
    public partial class ReportViewer
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        public ReportViewer(ReportClass reportDocument) : this()
        {
            CrystalReportViewer1.ReportSource = reportDocument;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            CrystalReportViewer1.Show();
        }

        internal static ReportViewer LoadReport(ReportClass reportDocument, Form owner)
        {
            var v = new ReportViewer(reportDocument);
            v.Show();
            v.WindowState = FormWindowState.Maximized;
            return v;
        }
    }
}