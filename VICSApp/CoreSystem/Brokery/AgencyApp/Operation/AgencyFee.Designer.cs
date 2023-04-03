namespace Brokery.Operation
{
   partial class AgencyFee
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
          this.dataGridView = new System.Windows.Forms.DataGridView();
          this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
          this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.agencyTradeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.valueFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.toValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.feeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
          this.panel1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
          this.SuspendLayout();
          // 
          // panel1
          // 
          this.panel1.Controls.Add(this.dataGridView);
          this.panel1.Size = new System.Drawing.Size(642, 354);
          // 
          // dataGridView
          // 
          this.dataGridView.AllowUserToAddRows = false;
          this.dataGridView.AllowUserToDeleteRows = false;
          this.dataGridView.AutoGenerateColumns = false;
          this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
          this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.agencyTradeCodeDataGridViewTextBoxColumn,
            this.valueFromDataGridViewTextBoxColumn,
            this.toValueDataGridViewTextBoxColumn,
            this.feeDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn});
          this.dataGridView.DataSource = this.customerBindingSource;
          this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dataGridView.Location = new System.Drawing.Point(0, 0);
          this.dataGridView.Name = "dataGridView";
          this.dataGridView.ReadOnly = true;
          this.dataGridView.RowHeadersWidth = 20;
          this.dataGridView.Size = new System.Drawing.Size(642, 354);
          this.dataGridView.TabIndex = 2;
          // 
          // backgroundWorker
          // 
          this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
          this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
          // 
          // idDataGridViewTextBoxColumn
          // 
          this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
          this.idDataGridViewTextBoxColumn.HeaderText = "Id";
          this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
          this.idDataGridViewTextBoxColumn.ReadOnly = true;
          this.idDataGridViewTextBoxColumn.Visible = false;
          // 
          // agencyTradeCodeDataGridViewTextBoxColumn
          // 
          this.agencyTradeCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
          this.agencyTradeCodeDataGridViewTextBoxColumn.DataPropertyName = "AgencyTradeCode";
          this.agencyTradeCodeDataGridViewTextBoxColumn.HeaderText = "Mã giao dịch";
          this.agencyTradeCodeDataGridViewTextBoxColumn.Name = "agencyTradeCodeDataGridViewTextBoxColumn";
          this.agencyTradeCodeDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // valueFromDataGridViewTextBoxColumn
          // 
          this.valueFromDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
          this.valueFromDataGridViewTextBoxColumn.DataPropertyName = "ValueFrom";
          this.valueFromDataGridViewTextBoxColumn.HeaderText = "Giá trị GD từ";
          this.valueFromDataGridViewTextBoxColumn.MinimumWidth = 100;
          this.valueFromDataGridViewTextBoxColumn.Name = "valueFromDataGridViewTextBoxColumn";
          this.valueFromDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // toValueDataGridViewTextBoxColumn
          // 
          this.toValueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
          this.toValueDataGridViewTextBoxColumn.DataPropertyName = "ToValue";
          this.toValueDataGridViewTextBoxColumn.HeaderText = "đến";
          this.toValueDataGridViewTextBoxColumn.Name = "toValueDataGridViewTextBoxColumn";
          this.toValueDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // feeDataGridViewTextBoxColumn
          // 
          this.feeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
          this.feeDataGridViewTextBoxColumn.DataPropertyName = "Fee";
          this.feeDataGridViewTextBoxColumn.HeaderText = "Tỷ lệ (%)";
          this.feeDataGridViewTextBoxColumn.Name = "feeDataGridViewTextBoxColumn";
          this.feeDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // noteDataGridViewTextBoxColumn
          // 
          this.noteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
          this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
          this.noteDataGridViewTextBoxColumn.FillWeight = 150F;
          this.noteDataGridViewTextBoxColumn.HeaderText = "Ghi chú";
          this.noteDataGridViewTextBoxColumn.MinimumWidth = 100;
          this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
          this.noteDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // customerBindingSource
          // 
          this.customerBindingSource.DataSource = typeof(Brokery.AgencyWebService.AgencyFee);
          // 
          // AgencyFee
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(642, 401);
          this.HideDeleteButton = false;
          this.HideExportButton = false;
          this.HidePrintButton = false;
          this.Name = "AgencyFee";
          this.Text = "Cập nhật phí đại lý";
          this.Load += new System.EventHandler(this.AgencyFee_Load);
          this.DeleteButtonClick += new System.EventHandler(this.AgencyFee_DeleteButtonClick);
          this.EditButtonClick += new System.EventHandler(this.AgencyFee_EditButtonClick);
          this.NewButtonClick += new System.EventHandler(this.AgencyFee_NewButtonClick);
          this.panel1.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.BindingSource customerBindingSource;
      private System.Windows.Forms.DataGridView dataGridView;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn agencyTradeCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn valueFromDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn toValueDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn feeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
   }
}