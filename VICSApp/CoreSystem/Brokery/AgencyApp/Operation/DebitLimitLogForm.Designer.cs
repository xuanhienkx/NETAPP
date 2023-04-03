namespace Brokery.Operation
{
   partial class DebitLimitLogForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
         this.txtCustomerId = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.btnFind = new System.Windows.Forms.ToolStripButton();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.transactionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.transactionTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.oldLimitValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.limitValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.oldFromDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.fromDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.oldToDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.toDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.userEnterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.customerDebitLimitLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.customerDebitLimitLogBindingSource)).BeginInit();
         this.SuspendLayout();
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.txtCustomerId,
            this.toolStripSeparator1,
            this.btnFind});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(919, 25);
         this.toolStrip1.TabIndex = 0;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
         this.toolStripLabel1.Text = "Từ ngày:";
         // 
         // toolStripLabel2
         // 
         this.toolStripLabel2.Name = "toolStripLabel2";
         this.toolStripLabel2.Size = new System.Drawing.Size(60, 22);
         this.toolStripLabel2.Text = "Đến ngày:";
         // 
         // toolStripLabel3
         // 
         this.toolStripLabel3.Name = "toolStripLabel3";
         this.toolStripLabel3.Size = new System.Drawing.Size(127, 22);
         this.toolStripLabel3.Text = "Tài khoản khách hàng:";
         // 
         // txtCustomerId
         // 
         this.txtCustomerId.Name = "txtCustomerId";
         this.txtCustomerId.Size = new System.Drawing.Size(100, 25);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // btnFind
         // 
         this.btnFind.Image = global::Brokery.Properties.Resources.find;
         this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnFind.Name = "btnFind";
         this.btnFind.Size = new System.Drawing.Size(48, 22);
         this.btnFind.Text = "Tìm";
         this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.AutoGenerateColumns = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transactionDateDataGridViewTextBoxColumn,
            this.transactionTimeDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.oldLimitValueDataGridViewTextBoxColumn,
            this.limitValueDataGridViewTextBoxColumn,
            this.oldFromDateDataGridViewTextBoxColumn,
            this.fromDateDataGridViewTextBoxColumn,
            this.oldToDateDataGridViewTextBoxColumn,
            this.toDateDataGridViewTextBoxColumn,
            this.userEnterDataGridViewTextBoxColumn});
         this.dataGridView1.DataSource = this.customerDebitLimitLogBindingSource;
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point(0, 25);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.Size = new System.Drawing.Size(919, 497);
         this.dataGridView1.TabIndex = 1;
         // 
         // transactionDateDataGridViewTextBoxColumn
         // 
         this.transactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate";
         dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle10.Format = "dd/MM/yyyy";
         this.transactionDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
         this.transactionDateDataGridViewTextBoxColumn.HeaderText = "Ngày";
         this.transactionDateDataGridViewTextBoxColumn.Name = "transactionDateDataGridViewTextBoxColumn";
         this.transactionDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // transactionTimeDataGridViewTextBoxColumn
         // 
         this.transactionTimeDataGridViewTextBoxColumn.DataPropertyName = "TransactionTime";
         dataGridViewCellStyle11.Format = "mm:sss";
         this.transactionTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
         this.transactionTimeDataGridViewTextBoxColumn.HeaderText = "Giờ giao dịch";
         this.transactionTimeDataGridViewTextBoxColumn.Name = "transactionTimeDataGridViewTextBoxColumn";
         this.transactionTimeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // customerIdDataGridViewTextBoxColumn
         // 
         this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
         dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.customerIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
         this.customerIdDataGridViewTextBoxColumn.HeaderText = "Tài khoản";
         this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
         this.customerIdDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // customerNameDataGridViewTextBoxColumn
         // 
         this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
         this.customerNameDataGridViewTextBoxColumn.HeaderText = "Tên khách hàng";
         this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
         this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // oldLimitValueDataGridViewTextBoxColumn
         // 
         this.oldLimitValueDataGridViewTextBoxColumn.DataPropertyName = "OldLimitValue";
         dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle13.Format = "n0";
         this.oldLimitValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
         this.oldLimitValueDataGridViewTextBoxColumn.HeaderText = "Giới hạn TD cũ";
         this.oldLimitValueDataGridViewTextBoxColumn.Name = "oldLimitValueDataGridViewTextBoxColumn";
         this.oldLimitValueDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // limitValueDataGridViewTextBoxColumn
         // 
         this.limitValueDataGridViewTextBoxColumn.DataPropertyName = "LimitValue";
         dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle14.Format = "n0";
         this.limitValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
         this.limitValueDataGridViewTextBoxColumn.HeaderText = "Giới hạn TD";
         this.limitValueDataGridViewTextBoxColumn.Name = "limitValueDataGridViewTextBoxColumn";
         this.limitValueDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // oldFromDateDataGridViewTextBoxColumn
         // 
         this.oldFromDateDataGridViewTextBoxColumn.DataPropertyName = "OldFromDate";
         dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle15.Format = "dd/MM/yyyy";
         this.oldFromDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
         this.oldFromDateDataGridViewTextBoxColumn.HeaderText = "Ngày DB cũ";
         this.oldFromDateDataGridViewTextBoxColumn.Name = "oldFromDateDataGridViewTextBoxColumn";
         this.oldFromDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // fromDateDataGridViewTextBoxColumn
         // 
         this.fromDateDataGridViewTextBoxColumn.DataPropertyName = "FromDate";
         dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle16.Format = "dd/MM/yyyy";
         this.fromDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
         this.fromDateDataGridViewTextBoxColumn.HeaderText = "Ngày DB";
         this.fromDateDataGridViewTextBoxColumn.Name = "fromDateDataGridViewTextBoxColumn";
         this.fromDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // oldToDateDataGridViewTextBoxColumn
         // 
         this.oldToDateDataGridViewTextBoxColumn.DataPropertyName = "OldToDate";
         dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle17.Format = "dd/MM/yyyy";
         this.oldToDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
         this.oldToDateDataGridViewTextBoxColumn.HeaderText = "Ngày KT cũ";
         this.oldToDateDataGridViewTextBoxColumn.Name = "oldToDateDataGridViewTextBoxColumn";
         this.oldToDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // toDateDataGridViewTextBoxColumn
         // 
         this.toDateDataGridViewTextBoxColumn.DataPropertyName = "ToDate";
         dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle18.Format = "dd/MM/yyyy";
         this.toDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18;
         this.toDateDataGridViewTextBoxColumn.HeaderText = "Ngày KT";
         this.toDateDataGridViewTextBoxColumn.Name = "toDateDataGridViewTextBoxColumn";
         this.toDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // userEnterDataGridViewTextBoxColumn
         // 
         this.userEnterDataGridViewTextBoxColumn.DataPropertyName = "UserEnter";
         this.userEnterDataGridViewTextBoxColumn.HeaderText = "Người cập nhật";
         this.userEnterDataGridViewTextBoxColumn.Name = "userEnterDataGridViewTextBoxColumn";
         this.userEnterDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // customerDebitLimitLogBindingSource
         // 
         this.customerDebitLimitLogBindingSource.DataSource = typeof(Brokery.AgencyWebService.CustomerDebitLimitLog);
         // 
         // DebitLimitLogForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(919, 522);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.toolStrip1);
         this.Name = "DebitLimitLogForm";
         this.Text = "Lịch sử cấp hạn mức tín dụng";
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.customerDebitLimitLogBindingSource)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripLabel toolStripLabel3;
      private System.Windows.Forms.ToolStripTextBox txtCustomerId;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton btnFind;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn transactionTimeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn oldLimitValueDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn limitValueDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn oldFromDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn fromDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn oldToDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn toDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn userEnterDataGridViewTextBoxColumn;
      private System.Windows.Forms.BindingSource customerDebitLimitLogBindingSource;
   }
}