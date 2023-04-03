using System;
using Microsoft.VisualBasic;

namespace pmDHCD
{
    public partial class MatterVotes_ins_remain
    {
        private int insertmattercode;

        public MatterVotes_ins_remain(int mattercode)
        {
            InitializeComponent();
            insertmattercode = mattercode;
            _Button3.Name = "Button3";
            _Button1.Name = "Button1";
        }

        private void MatterVotes_ins_remain_Load(object sender, EventArgs e)
        {
            BenlyDAL.BenlyDAL.DAL.MatterVoteInfo info;
            info = My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_Infor_get(My.MyProject.Forms.Mainform.workingmeeting, insertmattercode);
            MaskedTextBox1.Text = insertmattercode.ToString();
            MaskedTextBox2.Text = info.mattername;
            MaskedTextBox3.Text = info.sumofdelegates.ToString();
            MaskedTextBox4.Text = info.enteredvotes.ToString();
            MaskedTextBox5.Text = info.remainvotes.ToString();
            MaskedTextBox6.Text = info.AgreedDelegates.ToString();
            MaskedTextBox7.Text = info.DisAgreedDelegates.ToString();
            MaskedTextBox8.Text = info.Noideaddelegates.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Thao tác này sẽ nhập TẤT CẢ phiếu biểu quyết còn lại, Bạn đã kiểm tra CHẮC CHẮN???", (MsgBoxStyle)((int)MsgBoxStyle.OkCancel + (int)MsgBoxStyle.Critical + (int)MsgBoxStyle.ApplicationModal + (int)MsgBoxStyle.DefaultButton2), "NHẬP HÀNG LOẠT PHIẾU BIỂU QUYẾT") == MsgBoxResult.Ok)
            {
                try
                {
                    My.MyProject.Forms.Mainform.BenlyDal.MatterVotes_insert_remain(My.MyProject.Forms.Mainform.workingmeeting, insertmattercode, 0m, RadioButton1.Checked, RadioButton2.Checked, RadioButton3.Checked);
                    Interaction.MsgBox("Đã nhập xong");
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Lỗi : " + ex.Message);
                    return;
                }
            }
        }
    }
}