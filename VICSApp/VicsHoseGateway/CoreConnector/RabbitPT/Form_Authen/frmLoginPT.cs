using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HOGW_PT_Dealer
{
    public partial class frmLoginPT : Form
    {
    	public string Username
    	{
    		get{return txtUsername.Text;}
    	}
    	public string Password
    	{
    		get{return txtPassword.Text;}
    	}    	
        public frmLoginPT()
        {
            InitializeComponent();
        }
        
        void FrmLoginPTLoad(object sender, EventArgs e)
        {        	
        }
    }
}
