using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GWStock;
using InterStock;
using HOGW_CoreConnector.CoreConnector;

namespace HOGW_CoreConnector
{
    public partial class frmTestCancelOrder : Form
    {

        private CoreConnectorWS coreService = new CoreConnectorWS();
        private DataTable tbl;


        public frmTestCancelOrder()
        {
            this.InitializeComponent();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (this.gridData.SelectedRows != null)
            {
                string query = "INSERT INTO HOGW_1C(LAST_MODIFIED,MESSAGE_STATUS,MESSAGE_TYPE,FIRM,ORDER_NUMBER,ORDER_ENTRY_DATE) values(getdate(),'N','1C',@FIRM,@ORDER_NUMBER,@ORDER_ENTRY_DATE )";
                Database db = DatabaseFactory.CreateDatabase("ConnStrHOGW");
                SqlCommand sqlStringCommand = (SqlCommand)db.GetSqlStringCommand(query);
                try
                {
                    foreach (DataGridViewRow row in this.gridData.SelectedRows)
                    {
                        string str2 = row.Cells["FIRM"].Value.ToString();
                        string str3 = row.Cells["ORDER_NUMBER"].Value.ToString();
                        string str4 = row.Cells["ORDER_ENTRY_DATE"].Value.ToString();
                        if (MessageBox.Show("You are about to cancel order with FIRM=" + str2 + ", ORDER_NUMBER=" + str3 + ", ORDER_ENTRY_DATE=" + str4 + ". Are you sure?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            GWMessageUtil.insert1C(db, Convert.ToInt32(str2), Convert.ToInt32(str3), Convert.ToInt32(str4));
                            GWMessageUtil.updateMessageStatus(db, "1I", row.Cells["ID_1I"].Value, "C");
                        }
                    }
                    this.RefreshData();
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btnChangeOrder_Click(object sender, EventArgs e)
        {
            if (this.gridData.SelectedRows != null)
            {
                string query = "INSERT INTO HOGW_1C(LAST_MODIFIED,MESSAGE_STATUS,MESSAGE_TYPE,FIRM,ORDER_NUMBER,ORDER_ENTRY_DATE) values(getdate(),'N','1C',@FIRM,@ORDER_NUMBER,@ORDER_ENTRY_DATE )";
                Database db = DatabaseFactory.CreateDatabase("ConnStrHOGW");
                SqlCommand sqlStringCommand = (SqlCommand)db.GetSqlStringCommand(query);
                try
                {
                    if (this.cboCustomers.SelectedIndex >= 0)
                    {
                        DataGridViewRow row = this.gridData.SelectedRows[0];
                        string str2 = row.Cells["FIRM"].Value.ToString();
                        string str3 = row.Cells["ORDER_NUMBER"].Value.ToString();
                        string str4 = row.Cells["ORDER_ENTRY_DATE"].Value.ToString();
                        if (MessageBox.Show("You are about to cancel order with FIRM=" + str2 + ", ORDER_NUMBER=" + str3 + ", ORDER_ENTRY_DATE=" + str4 + ". Are you sure?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            GWMessageUtil.insert1D(db, Convert.ToInt32(str2), Convert.ToInt32(str3), Convert.ToInt32(str4), this.cboCustomers.SelectedValue.ToString());
                            GWMessageUtil.updateMessageStatus(db, "1I", row.Cells["ID_1I"].Value, "D");
                            this.RefreshData();
                        }
                    }
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void cboSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtCustomerID_TextChanged(sender, e);
        }



        protected void FillClients()
        {
            try
            {
                Customer[] allCustomers = this.coreService.GetAllCustomers();
                if ((allCustomers == null) || (allCustomers.Length <= 0))
                {
                    MessageBox.Show("Error when getting seller customer data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    List<Customer> list = new List<Customer>();
                    foreach (Customer customer in allCustomers)
                    {
                        list.Add(customer);
                    }
                    this.cboCustomers.ValueMember = "CustomerID";
                    this.cboCustomers.DisplayMember = "CustomerNameViet";
                    this.cboCustomers.DataSource = list;
                }
            }
            catch (SystemException exception)
            {
                MessageBox.Show(exception.Message, "Error when getting seller customer data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void frmTestCancelOrder_Load(object sender, EventArgs e)
        {
            this.gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gridData.EnableHeadersVisualStyles = false;
            this.gridData.AutoGenerateColumns = false;
            this.gridData.Columns.Clear();
            DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn
            {
                Width = 50,
                HeaderText = "ID_1I",
                Name = "ID_1I",
                DataPropertyName = "ID_1I"
            };
            this.gridData.Columns.Add(dataGridViewColumn);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn
            {
                Width = 50,
                HeaderText = "ID_2B",
                Name = "ID_2B",
                DataPropertyName = "ID_2B"
            };
            this.gridData.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn
            {
                Width = 50,
                HeaderText = "Firm",
                Name = "FIRM",
                DataPropertyName = "FIRM"
            };
            this.gridData.Columns.Add(column3);
            DataGridViewCellStyle style = new DataGridViewCellStyle
            {
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.Black
            };
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn
            {
                Width = 90,
                HeaderText = "OrderNumber",
                Name = "ORDER_NUMBER",
                DataPropertyName = "ORDER_NUMBER"
            };
            column4.HeaderCell.Style = style;
            column4.DefaultCellStyle = style;
            this.gridData.Columns.Add(column4);
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn
            {
                Width = 80,
                HeaderText = "ClientID",
                Name = "CLIENT_ID",
                DataPropertyName = "CLIENT_ID"
            };
            this.gridData.Columns.Add(column5);
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            style = new DataGridViewCellStyle
            {
                ForeColor = Color.SteelBlue,
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0)
            };
            column6.Width = 60;
            column6.HeaderText = "Stock";
            column6.Name = "SECURITY_SYMBOL";
            column6.DataPropertyName = "SECURITY_SYMBOL";
            column6.HeaderCell.Style = style;
            column6.DefaultCellStyle = style;
            this.gridData.Columns.Add(column6);
            style = new DataGridViewCellStyle
            {
                ForeColor = Color.Green,
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn
            {
                Width = 40,
                HeaderText = "Side",
                Name = "SIDE",
                DataPropertyName = "SIDE"
            };
            column7.HeaderCell.Style = style;
            column7.DefaultCellStyle = style;
            this.gridData.Columns.Add(column7);
            style = new DataGridViewCellStyle
            {
                ForeColor = Color.Blue,
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn
            {
                Width = 70,
                HeaderText = "Volume",
                Name = "VOLUME",
                DataPropertyName = "VOLUME"
            };
            column8.HeaderCell.Style = style;
            column8.DefaultCellStyle = style;
            this.gridData.Columns.Add(column8);
            style = new DataGridViewCellStyle
            {
                ForeColor = Color.Blue,
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn
            {
                Width = 60,
                HeaderText = "Price",
                Name = "PRICE",
                DataPropertyName = "PRICE"
            };
            column9.HeaderCell.Style = style;
            column9.DefaultCellStyle = style;
            this.gridData.Columns.Add(column9);
            style = new DataGridViewCellStyle
            {
                ForeColor = Color.OrangeRed,
                Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn
            {
                Width = 100,
                HeaderText = "OrderEntryDate",
                Name = "ORDER_ENTRY_DATE",
                DataPropertyName = "ORDER_ENTRY_DATE"
            };
            column10.HeaderCell.Style = style;
            column10.DefaultCellStyle = style;
            this.gridData.Columns.Add(column10);
            DataGridViewTextBoxColumn column11 = new DataGridViewTextBoxColumn
            {
                Width = 140,
                HeaderText = "InsertDate",
                Name = "INSERT_DATE",
                DataPropertyName = "INSERT_DATE"
            };
            this.gridData.Columns.Add(column11);
            DataGridViewTextBoxColumn column12 = new DataGridViewTextBoxColumn
            {
                Width = 140,
                HeaderText = "ReplyDate",
                Name = "REPLY_DATE",
                DataPropertyName = "REPLY_DATE"
            };
            this.gridData.Columns.Add(column12);
            DataGridViewTextBoxColumn column13 = new DataGridViewTextBoxColumn
            {
                Width = 30,
                HeaderText = "Status",
                Name = "MESSAGE_STATUS",
                DataPropertyName = "MESSAGE_STATUS"
            };
            this.gridData.Columns.Add(column13);
            this.cboSide.SelectedIndexChanged -= new EventHandler(this.cboSide_SelectedIndexChanged);
            this.cboSide.Items.Clear();
            this.cboSide.Items.Add("B");
            this.cboSide.Items.Add("S");
            this.cboSide.SelectedIndex = 0;
            this.cboSide.SelectedIndexChanged += new EventHandler(this.cboSide_SelectedIndexChanged);
            this.tbl = GWMessageUtil.getUnmatchedOrders();
            if (this.tbl != null)
            {
                this.gridData.DataSource = this.tbl;
                this.FillClients();
            }
        }


        private void RefreshData()
        {
            this.tbl = GWMessageUtil.getUnmatchedOrders();
            if (this.tbl == null)
            {
                MessageBox.Show("Data table is null", "Error when getting unmatched orders");
            }
            else
            {
                this.gridData.DataSource = this.tbl;
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (this.tbl != null)
            {
                string str2;
                string str3;
                string str4;
                string str5;
                DataView defaultView = this.tbl.DefaultView;
                if (this.txtCustomerID.Text != "")
                {
                    str2 = "Client_id like '%" + this.txtCustomerID.Text + "' and";
                }
                else
                {
                    str2 = " true and";
                }
                if (this.txtStockCode.Text != "")
                {
                    str3 = " security_symbol like '" + this.txtStockCode.Text + "%' and";
                }
                else
                {
                    str3 = " true and";
                }
                if (this.txtOrderEntryDate.Text != "")
                {
                    str5 = " order_entry_date = " + this.txtOrderEntryDate.Text + " and";
                }
                else
                {
                    str5 = " true and";
                }
                if (this.cboSide.Text != "")
                {
                    str4 = " side like '%" + this.cboSide.Text + "'";
                }
                else
                {
                    str4 = " true";
                }
                string str = str2 + str3 + str5 + str4;
                defaultView.RowFilter = str;
                this.gridData.DataSource = defaultView;
            }
        }

        private void txtOrderEntryDate_TextChanged(object sender, EventArgs e)
        {
            this.txtCustomerID_TextChanged(sender, e);
        }

        private void txtStockCode_TextChanged(object sender, EventArgs e)
        {
            this.txtCustomerID_TextChanged(sender, e);
        }
    }
}
