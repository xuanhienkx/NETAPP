using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.ControlBase;
using VRMApp.Framework;

namespace VRMApp.Brokerage
{
    public partial class DaySummaryTradingresultForm : FormBase
    {
        DateTimePicker interestDate;
        private DataSet dataSource;
        public DaySummaryTradingresultForm()
        {
            InitializeComponent();
            interestDate = new DateTimePicker();
            interestDate.MaxDate = Util.CurrentTransactionDate;
            GUIUtil.FormatDatePicker(interestDate);
            this.toolStrip1.Items.Insert(2, new ToolStripControlHost(interestDate));
            btExport.Enabled = false;
        }

        public override bool CheckAccess()
        {
            return true;
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            ShowWaiting("Đang lấy dữ liệu ...");
            try
            {
                DateTime callDate = interestDate.Value;
                DataSet result = Util.VRMService.GetSummaryTrading(Util.TokenKey, callDate);
                dataSource = result;
                var summary = result.Tables[0];
                var customers = result.Tables[1];
                var stockCodes = result.Tables[2];
                if(summary.Rows.Count==0)
                    ShowError("Không có dữ liệu");
                grSummary.DataSource = summary;
                grCustomer.DataSource = customers;
                grStockCode.DataSource = stockCodes;
                btExport.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                btExport.Enabled = false;
            }
            CloseWaiting();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaiting("Đang xữ lý ...");
                const string fileName = @"Baocaogiaodich.xls";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                //CsvExport(fileName);
                ExcelExport(dataSource, fileName, true);
                CloseWaiting(); 
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        public void CsvExport(string fileName)
        { 
                StringBuilder sb = new StringBuilder();
                var dt = dataSource.Tables[0];
                IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }
                sb.AppendLine();
                sb.AppendLine();
                var dt1 = dataSource.Tables[1];
                IEnumerable<string> columnNames1 = dt1.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames1));

                foreach (DataRow row in dt1.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }
                sb.AppendLine();
                sb.AppendLine();
                var dt2 = dataSource.Tables[2];
                IEnumerable<string> columnNames2 = dt2.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames2));

                foreach (DataRow row in dt2.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                } 
                File.WriteAllText(fileName, sb.ToString());
                
        }
        private void ExcelExport(DataSet data, string fileName, bool openAfter)
        {
            //export a DataTable to Excel
            DialogResult retry = DialogResult.Retry;

            while (retry == DialogResult.Retry)
            {
                try
                { 
                    using (ExcelWriter writer = new ExcelWriter(fileName))
                    {
                        writer.WriteStartDocument();

                        // Write the worksheet contents
                        int i = 0; 
                        foreach (DataTable table in data.Tables)
                        {
                            switch (i)
                            {
                                case 0:
                                    writer.WriteStartWorksheet("Tonghop");
                                    break;
                                case 1:
                                    writer.WriteStartWorksheet("Top30KH");
                                    break;
                                case 2:
                                    writer.WriteStartWorksheet("Top15Ma");
                                    break;

                            }

                            i++;

                            //Write header row
                            writer.WriteStartRow();
                            foreach (DataColumn col in table.Columns)
                                writer.WriteExcelUnstyledCell(col.Caption);
                            writer.WriteEndRow();

                            //write data
                            foreach (DataRow row in table.Rows)
                            {
                                writer.WriteStartRow();
                                foreach (object o in row.ItemArray)
                                {
                                    writer.WriteExcelAutoStyledCell(o,false);
                                }
                                writer.WriteEndRow();
                            }
                            writer.WriteEndWorksheet();
                        }
                        // Close up the document
                        writer.WriteEndDocument();
                        writer.Close();
                        if (openAfter)
                            OpenFile(fileName);
                        retry = DialogResult.Cancel;
                    }
                }
                catch (Exception myException)
                {
                    retry = MessageBox.Show(myException.Message, "Excel Export", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                } 
            }
        }

        private void OpenFile(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
        }

    }
}
