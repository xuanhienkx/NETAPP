using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace pmDHCD
{
    public partial class HolderListForSelect
    {
        public HolderListForSelect()
        {
            InitializeComponent();
            _DataGridView1.Name = "DataGridView1";
        }

        private string strIdentifyCard;

        public object IdentifyCard
        {
            get
            {
                return strIdentifyCard;
            }

            set
            {
                strIdentifyCard = Conversions.ToString(value);
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            filldgv();
        }

        private void filldgv()
        {
            var dt = new DataTable();
            try
            {
                dt = My.MyProject.Forms.Mainform.BenlyDal.Holder_getlist(My.MyProject.Forms.Mainform.workingmeeting, "", Conversions.ToString(IdentifyCard));
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Lỗi :" + ex.Message);
            }

            DataGridView1.DataSource = dt;
            ToolStripStatusLabel2.Text = DataGridView1.RowCount.ToString();
            int sumshares = 0;
            int sumvoterights = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sumshares = Conversions.ToInteger(Operators.AddObject(sumshares, dr["Shares"]));
                sumvoterights = Conversions.ToInteger(Operators.AddObject(sumvoterights, dr["Voterights"]));
            }
            // ToolStripStatusLabel4.Text = Mainform.addthousandseperator(sumshares.ToString)
            // ToolStripStatusLabel6.Text = Mainform.addthousandseperator(sumvoterights.ToString)
        }

        private void HolderList_Load(object sender, EventArgs e)
        {
            filldgv();
            // Me.MdiParent = Mainform
        }

        private void HolderListForSelect_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Close();
            }
        }
    }
}