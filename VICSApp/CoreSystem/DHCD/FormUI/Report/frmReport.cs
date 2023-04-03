using pmDHCD.Report;
using System;

namespace pmDHCD
{
    public partial class frmReport
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private phieubieuquyet1 cr = new phieubieuquyet1();

        public object Phieubieuquyet
        {
            get
            {
                return cr;
            }

            set
            {
                cr = (phieubieuquyet1)value;
            }
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            CrystalReportViewer1.ReportSource = cr;
            CrystalReportViewer1.Show();
        }
    }
}