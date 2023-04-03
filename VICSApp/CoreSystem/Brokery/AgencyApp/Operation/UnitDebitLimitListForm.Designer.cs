namespace Brokery.Operation
{
   partial class UnitDebitLimitListForm
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
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.lblNote = new System.Windows.Forms.ToolStripStatusLabel();
         this.btnEdit = new System.Windows.Forms.ToolStripButton();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.groupDebitLimitBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.branchCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tradeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.debitLimitAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.debitLimitDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.currentDebitLimitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.modifiedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.modifiedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.statusStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupDebitLimitBindingSource)).BeginInit();
         this.SuspendLayout();
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNote});
         this.statusStrip1.Location = new System.Drawing.Point(0, 452);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(932, 22);
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
         // btnEdit
         // 
         this.btnEdit.Image = global::Brokery.Properties.Resources.coin_stack_silver_edit;
         this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnEdit.Name = "btnEdit";
         this.btnEdit.Size = new System.Drawing.Size(173, 22);
         this.btnEdit.Text = "&Cập nhật hạn mức tín dụng";
         this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.toolStripSeparator1,
            this.toolStripButton1});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(932, 25);
         this.toolStrip1.TabIndex = 0;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Image = global::Brokery.Properties.Resources.arrow_refresh;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(64, 22);
         this.toolStripButton1.Text = "Vấn tin";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.AutoGenerateColumns = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.branchCodeDataGridViewTextBoxColumn,
            this.tradeCodeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.debitLimitAmountDataGridViewTextBoxColumn,
            this.debitLimitDayDataGridViewTextBoxColumn,
            this.currentDebitLimitDataGridViewTextBoxColumn,
            this.modifiedDateDataGridViewTextBoxColumn,
            this.modifiedByDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn});
         this.dataGridView1.DataSource = this.groupDebitLimitBindingSource;
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point(0, 25);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.Size = new System.Drawing.Size(932, 427);
         this.dataGridView1.TabIndex = 3;
         // 
         // groupDebitLimitBindingSource
         // 
         this.groupDebitLimitBindingSource.DataSource = typeof(Brokery.AgencyWebService.GroupDebitLimit);
         // 
         // branchCodeDataGridViewTextBoxColumn
         // 
         this.branchCodeDataGridViewTextBoxColumn.DataPropertyName = "BranchCode";
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.branchCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
         this.branchCodeDataGridViewTextBoxColumn.HeaderText = "Mã chi nhánh";
         this.branchCodeDataGridViewTextBoxColumn.Name = "branchCodeDataGridViewTextBoxColumn";
         this.branchCodeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // tradeCodeDataGridViewTextBoxColumn
         // 
         this.tradeCodeDataGridViewTextBoxColumn.DataPropertyName = "TradeCode";
         this.tradeCodeDataGridViewTextBoxColumn.HeaderText = "Mã giao dịch";
         this.tradeCodeDataGridViewTextBoxColumn.Name = "tradeCodeDataGridViewTextBoxColumn";
         this.tradeCodeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // nameDataGridViewTextBoxColumn
         // 
         this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
         this.nameDataGridViewTextBoxColumn.HeaderText = "Tên";
         this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
         this.nameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // debitLimitAmountDataGridViewTextBoxColumn
         // 
         this.debitLimitAmountDataGridViewTextBoxColumn.DataPropertyName = "DebitLimitAmount";
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle2.Format = "n0";
         this.debitLimitAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
         this.debitLimitAmountDataGridViewTextBoxColumn.HeaderText = "Tổng hạn mức";
         this.debitLimitAmountDataGridViewTextBoxColumn.Name = "debitLimitAmountDataGridViewTextBoxColumn";
         this.debitLimitAmountDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // debitLimitDayDataGridViewTextBoxColumn
         // 
         this.debitLimitDayDataGridViewTextBoxColumn.DataPropertyName = "DebitLimitDay";
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle3.Format = "n0";
         this.debitLimitDayDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
         this.debitLimitDayDataGridViewTextBoxColumn.HeaderText = "Hạn mức đã sử dụng";
         this.debitLimitDayDataGridViewTextBoxColumn.Name = "debitLimitDayDataGridViewTextBoxColumn";
         this.debitLimitDayDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // currentDebitLimitDataGridViewTextBoxColumn
         // 
         this.currentDebitLimitDataGridViewTextBoxColumn.DataPropertyName = "CurrentDebitLimit";
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle4.Format = "n0";
         this.currentDebitLimitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
         this.currentDebitLimitDataGridViewTextBoxColumn.HeaderText = "Hạn mức còn lại";
         this.currentDebitLimitDataGridViewTextBoxColumn.Name = "currentDebitLimitDataGridViewTextBoxColumn";
         this.currentDebitLimitDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // modifiedDateDataGridViewTextBoxColumn
         // 
         this.modifiedDateDataGridViewTextBoxColumn.DataPropertyName = "ModifiedDate";
         dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle5.Format = "HH:mm:ssf";
         this.modifiedDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
         this.modifiedDateDataGridViewTextBoxColumn.HeaderText = "Giờ cập nhật";
         this.modifiedDateDataGridViewTextBoxColumn.Name = "modifiedDateDataGridViewTextBoxColumn";
         this.modifiedDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // modifiedByDataGridViewTextBoxColumn
         // 
         this.modifiedByDataGridViewTextBoxColumn.DataPropertyName = "ModifiedBy";
         this.modifiedByDataGridViewTextBoxColumn.HeaderText = "Sửa lại bởi";
         this.modifiedByDataGridViewTextBoxColumn.Name = "modifiedByDataGridViewTextBoxColumn";
         this.modifiedByDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // createdDateDataGridViewTextBoxColumn
         // 
         this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
         dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle6.Format = "dd/MM/yyyy HH:mm:ssf";
         this.createdDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
         this.createdDateDataGridViewTextBoxColumn.HeaderText = "Ngày tạo";
         this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
         this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // createdByDataGridViewTextBoxColumn
         // 
         this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
         this.createdByDataGridViewTextBoxColumn.HeaderText = "Tạo bởi";
         this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
         this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // UnitDebitLimitListForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(932, 474);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.toolStrip1);
         this.Name = "UnitDebitLimitListForm";
         this.Text = "Thiết lập hạn mức tín dụng đầu ngày cho chi nhánh/đại lý";
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupDebitLimitBindingSource)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel lblNote;
      private System.Windows.Forms.ToolStripButton btnEdit;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.BindingSource groupDebitLimitBindingSource;
      private System.Windows.Forms.DataGridViewTextBoxColumn branchCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn tradeCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn debitLimitAmountDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn debitLimitDayDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn currentDebitLimitDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn modifiedByDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
   }
}