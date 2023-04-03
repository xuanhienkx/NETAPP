using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using pmDHCD.Report;

namespace pmDHCD
{
    public partial class MeetingInfoshow
    {
        public MeetingInfoshow()
        {
            InitializeComponent();
            _PrintButton1.Name = "PrintButton1";
            _MaskedTextBox11.Name = "MaskedTextBox11";
            _MaskedTextBox10.Name = "MaskedTextBox10";
        }

        private DateTime dateMeeting = My.MyProject.Forms.Mainform.dateMeeting;

        private void MaskedTextBox10_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void MeetingInfoshow_Load(object sender, EventArgs e)
        {
            var info = new BenlyDAL.BenlyDAL.DAL.MeetingInfo();
            try
            {
                info = My.MyProject.Forms.Mainform.BenlyDal.Meeting_Infor_get(My.MyProject.Forms.Mainform.workingmeeting);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi : " + ex.Message);
            }

            MaskedTextBox1.Text = info.companyname;
            MaskedTextBox2.Text = info.meetingname;
            MaskedTextBox3.Text = My.MyProject.Forms.Mainform.addthousandseperator(info.sumofholders.ToString());
            MaskedTextBox4.Text = My.MyProject.Forms.Mainform.addthousandseperator(info.sumofshares.ToString());
            MaskedTextBox5.Text = My.MyProject.Forms.Mainform.addthousandseperator(info.sumofvoterights.ToString());
            MaskedTextBox6.Text = My.MyProject.Forms.Mainform.addthousandseperator(info.numofdelegates.ToString());
            MaskedTextBox7.Text = My.MyProject.Forms.Mainform.addthousandseperator(info.numofholderparticipated.ToString());
            MaskedTextBox8.Text = My.MyProject.Forms.Mainform.addthousandseperator(info.numofholderAuthorised.ToString());
            MaskedTextBox9.Text = My.MyProject.Forms.Mainform.addthousandseperator(info.sumofholderAndAuthorizatedUser.ToString());
            MaskedTextBox10.Text = My.MyProject.Forms.Mainform.addthousandseperator(info.sumofparticipedVoterights.ToString());
            MaskedTextBox11.Text = Math.Round(info.sumofparticipedVoterights / info.sumofvoterights * 100m, 2).ToString() + " %";
        }

        private void MeetingInfoshow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void PrintButton1_Click(object sender, EventArgs e)
        {
            var cr = new ThongTinCuocHop();
            cr.SetParameterValue("TenCongTy", MaskedTextBox1.Text);
            cr.SetParameterValue("dateMeeting", dateMeeting);
            cr.SetParameterValue("CuocHop", MaskedTextBox2.Text);
            cr.SetParameterValue("SoCoDong", MaskedTextBox3.Text);
            cr.SetParameterValue("SoCoPhan", MaskedTextBox4.Text);
            cr.SetParameterValue("QuyenBieuQuyet", MaskedTextBox5.Text);
            cr.SetParameterValue("SoDaiBieu", MaskedTextBox6.Text);
            cr.SetParameterValue("SoCoDongTrucTiep", MaskedTextBox7.Text);
            cr.SetParameterValue("SoCoDongUyQuyen", MaskedTextBox8.Text);
            cr.SetParameterValue("TongSo", MaskedTextBox9.Text);
            cr.SetParameterValue("SoQuyenBQ", MaskedTextBox10.Text);
            cr.SetParameterValue("TyLe", MaskedTextBox11.Text);
            ReportViewer.LoadReport(cr, this);
        }
    }
}