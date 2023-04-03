namespace VRMApp.RiskMan
{
   partial class StockListForm
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
         this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.maCKTextBox = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.stockCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.valueRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.cellingFixedPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.modifiedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.modifiedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.mainPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // mainPanel
         // 
         this.mainPanel.Controls.Add(this.dataGridView1);
         this.mainPanel.Controls.Add(this.toolStrip1);
         this.mainPanel.Size = new System.Drawing.Size(982, 536);
         this.mainPanel.Controls.SetChildIndex(this.toolStrip1, 0);
         this.mainPanel.Controls.SetChildIndex(this.dataGridView1, 0);
         // 
         // stockBindingSource
         // 
         this.stockBindingSource.DataSource = typeof(VRMApp.VRMGateway.Stock);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.maCKTextBox,
            this.toolStripButton1});
         this.toolStrip1.Location = new System.Drawing.Point(0, 25);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(982, 25);
         this.toolStrip1.TabIndex = 4;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
         this.toolStripLabel1.Text = "Mã CK:";
         // 
         // maCKTextBox
         // 
         this.maCKTextBox.Name = "maCKTextBox";
         this.maCKTextBox.Size = new System.Drawing.Size(100, 25);
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.Image = global::VRMApp.Properties.Resources.find;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
         this.toolStripButton1.Text = "&Tìm";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.AutoGenerateColumns = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockCodeDataGridViewTextBoxColumn,
            this.valueRateDataGridViewTextBoxColumn,
            this.cellingFixedPriceDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.modifiedByDataGridViewTextBoxColumn,
            this.modifiedDateDataGridViewTextBoxColumn});
         this.dataGridView1.DataSource = this.stockBindingSource;
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point(0, 50);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.Size = new System.Drawing.Size(982, 486);
         this.dataGridView1.TabIndex = 5;
         // 
         // stockCodeDataGridViewTextBoxColumn
         // 
         this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "StockCode";
         this.stockCodeDataGridViewTextBoxColumn.HeaderText = "Mã CK";
         this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
         this.stockCodeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // valueRateDataGridViewTextBoxColumn
         // 
         this.valueRateDataGridViewTextBoxColumn.DataPropertyName = "ValueRate";
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle1.Format = "n0";
         this.valueRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
         this.valueRateDataGridViewTextBoxColumn.HeaderText = "% giá trị";
         this.valueRateDataGridViewTextBoxColumn.Name = "valueRateDataGridViewTextBoxColumn";
         this.valueRateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // cellingFixedPriceDataGridViewTextBoxColumn
         // 
         this.cellingFixedPriceDataGridViewTextBoxColumn.DataPropertyName = "CellingFixedPrice";
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle2.Format = "n0";
         this.cellingFixedPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
         this.cellingFixedPriceDataGridViewTextBoxColumn.HeaderText = "Giá kịch trần";
         this.cellingFixedPriceDataGridViewTextBoxColumn.Name = "cellingFixedPriceDataGridViewTextBoxColumn";
         this.cellingFixedPriceDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // createdByDataGridViewTextBoxColumn
         // 
         this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
         this.createdByDataGridViewTextBoxColumn.HeaderText = "Tạo bởi";
         this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
         this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // createdDateDataGridViewTextBoxColumn
         // 
         this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle3.Format = "dd/MM/yyyy";
         this.createdDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
         this.createdDateDataGridViewTextBoxColumn.HeaderText = "Ngày tạo";
         this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
         this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // modifiedByDataGridViewTextBoxColumn
         // 
         this.modifiedByDataGridViewTextBoxColumn.DataPropertyName = "ModifiedBy";
         this.modifiedByDataGridViewTextBoxColumn.HeaderText = "Sửa bởi";
         this.modifiedByDataGridViewTextBoxColumn.Name = "modifiedByDataGridViewTextBoxColumn";
         this.modifiedByDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // modifiedDateDataGridViewTextBoxColumn
         // 
         this.modifiedDateDataGridViewTextBoxColumn.DataPropertyName = "ModifiedDate";
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle4.Format = "dd/MM/yyyy";
         this.modifiedDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
         this.modifiedDateDataGridViewTextBoxColumn.HeaderText = "Ngày sửa";
         this.modifiedDateDataGridViewTextBoxColumn.Name = "modifiedDateDataGridViewTextBoxColumn";
         this.modifiedDateDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // StockListForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(982, 558);
         this.HideDeleteButton = false;
         this.HideExportButton = false;
         this.HidePrintButton = false;
         this.Name = "StockListForm";
         this.Text = "Danh sách chứng khoán hợp tác";
         this.Load += new System.EventHandler(this.StockListForm_Load);
         this.DeleteButtonClick += new System.EventHandler(this.StockListForm_DeleteButtonClick);
         this.EditButtonClick += new System.EventHandler(this.StockListForm_EditButtonClick);
         this.NewButtonClick += new System.EventHandler(this.StockListForm_NewButtonClick);
         this.mainPanel.ResumeLayout(false);
         this.mainPanel.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.BindingSource stockBindingSource;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox maCKTextBox;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn valueRateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn cellingFixedPriceDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn modifiedByDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDateDataGridViewTextBoxColumn;
   }
}