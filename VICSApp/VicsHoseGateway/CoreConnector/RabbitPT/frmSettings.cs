using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace HOGW_PT_Dealer
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            
            Program.sets = clsSettings.Load(Program.GetSettingPath());
            PropertyInfo[] pros = Program.sets.AppRelated.GetType().GetProperties();
            int left = 2;
            const int top = 2;
            const int verticalDistance = 22;
            const int witdh1 = 130;
            const int witdh2 = 250;
            const int height = 20;
            const int delta = 20;

            int fieldCount = pros.Length;
            //can chinh lai form
            this.Height = top + (fieldCount+1) * verticalDistance + delta + btnApply.Height + delta;
            this.Width = left * 3 + witdh1 + witdh2 + delta;
            int horizon = 0;
            for (int i = 0; i < fieldCount; i++)
            {
                Label lbl = new Label();
                lbl.Parent = this;
                lbl.Top = top + verticalDistance * i;
                lbl.Left = left;
                lbl.Width = witdh1;
                lbl.Height = height;
                lbl.Name = "lbl" + pros[i].Name;
                lbl.Text = pros[i].Name;
                //
                TextBox txt = new TextBox();
                txt.Parent = this;
                txt.Top = top + verticalDistance * i;
                txt.Left = 2 * left + witdh1;
                txt.Width = witdh2;
                txt.Height = height;
                object o = Program.sets.AppRelated.GetType().InvokeMember(pros[i].Name, BindingFlags.GetProperty, null, Program.sets.AppRelated, null);
                txt.Text = o == null ? "" : o.ToString();
                txt.Name = "txt" + pros[i].Name;
                //
                horizon = lbl.Top;
            }
            horizon += verticalDistance + delta;                        
            //can chinh lai cac buttons
            btnApply.Top = horizon;
            btnCancel.Top = horizon;
            btnOK.Top = horizon;
            left = 10;
            int btnw = this.Width / 3 - 2 * left;
            btnApply.Width = btnw;
            btnOK.Width = btnw;
            btnCancel.Width = btnw;
            btnApply.Left = left;
            btnOK.Left = btnw + 2 * left;
            btnCancel.Left = btnOK.Left + btnw + left;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            PropertyInfo[] pros = Program.sets.AppRelated.GetType().GetProperties();            
            //save into XML file
            foreach (PropertyInfo info in pros)
            {
                foreach(Control con in this.Controls)
                {
                    if ("txt" + info.Name == con.Name)
                    {
                        if(!string.IsNullOrEmpty(con.Text))
                            info.SetValue(Program.sets.AppRelated, Convert.ChangeType(con.Text,info.PropertyType), null);
                    }
                }                
            }
            Program.sets.Save(Program.GetSettingPath());
            /*
            Program.sets.AppRelated.AdminMobiles = "84912591416";
            Program.sets.AppRelated.AppName = "HOGW_PT_Dealer";
            Program.sets.AppRelated.Board = "B";
            Program.sets.AppRelated.BoardOdd = "O";
            Program.sets.AppRelated.ContactAddress = "SHS - 162 Thai Ha, Dong Da, Ha Noi";
            Program.sets.AppRelated.FirmID = 69;
            Program.sets.AppRelated.MatchingOrderInterval = 5000;
            Program.sets.AppRelated.MaxNumThread = 1;
            Program.sets.AppRelated.PriceMultipleOperand = 1;
            Program.sets.AppRelated.PtOrderInterval = 10000;
            Program.sets.AppRelated.SbsGatewayPassword = "pm";
            Program.sets.AppRelated.SbsGatewayUsername = "pm";*/            
        }
    }
}