using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using pmDHCD.Report;

namespace pmDHCD
{
    public partial class PrintHolders
    {
        public PrintHolders()
        {
            InitializeComponent();
            _OK_Button.Name = "OK_Button";
            _Cancel_Button.Name = "Cancel_Button";
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Holder_getListLimited(My.MyProject.Forms.Mainform.workingmeeting, Convert.ToInt32(txtFromHolder.Text), Convert.ToInt32(txtToHolder.Text));
                for (int i = 0, loopTo = dt.Rows.Count - 1; i <= loopTo; i++)
                    dt.Rows[i]["VoteRights"] = My.MyProject.Forms.Mainform.addthousandseperator(dt.Rows[i]["VoteRights"].ToString().Trim());
                var cr_thebieuquyet = new thebieuquyet();
                cr_thebieuquyet.SetDataSource(dt);
                cr_thebieuquyet.SetParameterValue("DateMeeting", My.MyProject.Forms.Mainform.dateMeeting);
                cr_thebieuquyet.SetParameterValue("MettingType", My.MyProject.Forms.Mainform.mettingType.ToLower());
                //cr_thebieuquyet.SetParameterValue("Period", My.MyProject.Forms.Mainform.period.ToLower());
                cr_thebieuquyet.SetParameterValue("Year", My.MyProject.Forms.Mainform.year);
                ReportViewer.LoadReport(cr_thebieuquyet, My.MyProject.Forms.HolderList);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }

            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}