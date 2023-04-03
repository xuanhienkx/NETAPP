namespace Brokery.Operation
{
   partial class DebitLimitListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtCustomerId = new System.Windows.Forms.ToolStripTextBox();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNote = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.currentLimitValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDebitLimitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.transDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beforeLimitValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentLimitValueDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userEnterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDebitTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDebitLimitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDebitTransactionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.toolStripSeparator1,
            this.btnViewHistory});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(645, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Brokery.Properties.Resources.coin_single_gold_edit;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(146, 22);
            this.btnEdit.Text = "&Cấp hạn mức tín dụng";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Image = global::Brokery.Properties.Resources.page_white_stack;
            this.btnViewHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(208, 22);
            this.btnViewHistory.Text = "&Xem lịch sử cấp hạn mức tín dụng";
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtCustomerId,
            this.btnFind});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(645, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(127, 22);
            this.toolStripLabel1.Text = "Tài khoản khách hàng:";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(100, 25);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::Brokery.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(48, 22);
            this.btnFind.Text = "&Tìm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNote});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(645, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNote
            // 
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(46, 17);
            this.lblNote.Text = "lblNote";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(645, 402);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIDDataGridViewTextBoxColumn,
            this.limitValueDataGridViewTextBoxColumn,
            this.fromDateDataGridViewTextBoxColumn,
            this.toDateDataGridViewTextBoxColumn,
            this.activateDataGridViewCheckBoxColumn,
            this.currentLimitValueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.customerDebitLimitBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(645, 208);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.customerIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "Khách hàng";
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            this.customerIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // limitValueDataGridViewTextBoxColumn
            // 
            this.limitValueDataGridViewTextBoxColumn.DataPropertyName = "LimitValue";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "n0";
            this.limitValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.limitValueDataGridViewTextBoxColumn.HeaderText = "Giới hạn tín dụng";
            this.limitValueDataGridViewTextBoxColumn.Name = "limitValueDataGridViewTextBoxColumn";
            this.limitValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromDateDataGridViewTextBoxColumn
            // 
            this.fromDateDataGridViewTextBoxColumn.DataPropertyName = "FromDate";
            this.fromDateDataGridViewTextBoxColumn.HeaderText = "Từ ngày";
            this.fromDateDataGridViewTextBoxColumn.Name = "fromDateDataGridViewTextBoxColumn";
            this.fromDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toDateDataGridViewTextBoxColumn
            // 
            this.toDateDataGridViewTextBoxColumn.DataPropertyName = "ToDate";
            this.toDateDataGridViewTextBoxColumn.HeaderText = "Đến ngày";
            this.toDateDataGridViewTextBoxColumn.Name = "toDateDataGridViewTextBoxColumn";
            this.toDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activateDataGridViewCheckBoxColumn
            // 
            this.activateDataGridViewCheckBoxColumn.DataPropertyName = "Activate";
            this.activateDataGridViewCheckBoxColumn.HeaderText = "Có hiệu lực";
            this.activateDataGridViewCheckBoxColumn.Name = "activateDataGridViewCheckBoxColumn";
            this.activateDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // currentLimitValueDataGridViewTextBoxColumn
            // 
            this.currentLimitValueDataGridViewTextBoxColumn.DataPropertyName = "CurrentLimitValue";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "n0";
            this.currentLimitValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.currentLimitValueDataGridViewTextBoxColumn.HeaderText = "Số tiền thiếu";
            this.currentLimitValueDataGridViewTextBoxColumn.Name = "currentLimitValueDataGridViewTextBoxColumn";
            this.currentLimitValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerDebitLimitBindingSource
            // 
            this.customerDebitLimitBindingSource.DataSource = typeof(Brokery.AgencyWebService.CustomerDebitLimit);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transDateDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.beforeLimitValueDataGridViewTextBoxColumn,
            this.currentLimitValueDataGridViewTextBoxColumn1,
            this.userEnterDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.customerDebitTransactionBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(645, 190);
            this.dataGridView2.TabIndex = 0;
            // 
            // transDateDataGridViewTextBoxColumn
            // 
            this.transDateDataGridViewTextBoxColumn.DataPropertyName = "TransDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.transDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.transDateDataGridViewTextBoxColumn.HeaderText = "Ngày giao dịch";
            this.transDateDataGridViewTextBoxColumn.Name = "transDateDataGridViewTextBoxColumn";
            this.transDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "n0";
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Giới hạn tín dụng";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.typeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.typeDataGridViewTextBoxColumn.HeaderText = "Loại tính dụng";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // beforeLimitValueDataGridViewTextBoxColumn
            // 
            this.beforeLimitValueDataGridViewTextBoxColumn.DataPropertyName = "BeforeLimitValue";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "n0";
            this.beforeLimitValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.beforeLimitValueDataGridViewTextBoxColumn.HeaderText = "Trước giao dịch";
            this.beforeLimitValueDataGridViewTextBoxColumn.Name = "beforeLimitValueDataGridViewTextBoxColumn";
            this.beforeLimitValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentLimitValueDataGridViewTextBoxColumn1
            // 
            this.currentLimitValueDataGridViewTextBoxColumn1.DataPropertyName = "CurrentLimitValue";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "n0";
            this.currentLimitValueDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.currentLimitValueDataGridViewTextBoxColumn1.HeaderText = "Sau giao dịch";
            this.currentLimitValueDataGridViewTextBoxColumn1.Name = "currentLimitValueDataGridViewTextBoxColumn1";
            this.currentLimitValueDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // userEnterDataGridViewTextBoxColumn
            // 
            this.userEnterDataGridViewTextBoxColumn.DataPropertyName = "UserEnter";
            this.userEnterDataGridViewTextBoxColumn.HeaderText = "Người nhập";
            this.userEnterDataGridViewTextBoxColumn.Name = "userEnterDataGridViewTextBoxColumn";
            this.userEnterDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerDebitTransactionBindingSource
            // 
            this.customerDebitTransactionBindingSource.DataSource = typeof(Brokery.AgencyWebService.CustomerDebitTransaction);
            // 
            // DebitLimitListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 474);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DebitLimitListForm";
            this.Text = "Quản lý hạn mức tín dụng";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDebitLimitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDebitTransactionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton btnEdit;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton btnViewHistory;
      private System.Windows.Forms.ToolStrip toolStrip2;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox txtCustomerId;
      private System.Windows.Forms.ToolStripButton btnFind;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel lblNote;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.BindingSource customerDebitLimitBindingSource;
      private System.Windows.Forms.DataGridView dataGridView2;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn limitValueDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn fromDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn toDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewCheckBoxColumn activateDataGridViewCheckBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn currentLimitValueDataGridViewTextBoxColumn;
      private System.Windows.Forms.BindingSource customerDebitTransactionBindingSource;
      private System.Windows.Forms.DataGridViewTextBoxColumn transDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn beforeLimitValueDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn currentLimitValueDataGridViewTextBoxColumn1;
      private System.Windows.Forms.DataGridViewTextBoxColumn userEnterDataGridViewTextBoxColumn;
   }
}