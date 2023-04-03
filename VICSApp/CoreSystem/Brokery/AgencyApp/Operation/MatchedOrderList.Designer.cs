using System.Windows.Forms;

namespace Brokery.Operation
{
   partial class MatchedOrderList
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;
      private ToolStripComboBox boardTypeBox;
      private BindingSource orderBindingSource = new BindingSource();
      private DataGridViewTextBoxColumn OrderDate;
      private DataGridViewTextBoxColumn OrderSeq;
      private ToolStripComboBox orderSideBox;
      private DataGridViewTextBoxColumn OrderTime;
      private ToolStrip toolStrip1;
      private ToolStripLabel toolStripLabel3;
      private ToolStripLabel toolStripLabel4;
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
         this.OrderSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.sumOfRecodeLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
         this.boardTypeBox = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
         this.orderSideBox = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.StockCodeLabel = new System.Windows.Forms.ToolStripLabel();
         this.StockCodeBox = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.CustomerIDLabel = new System.Windows.Forms.ToolStripLabel();
         this.CustomerIDBox = new System.Windows.Forms.ToolStripTextBox();
         this.findBtn = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.gridOrder = new System.Windows.Forms.DataGridView();
         this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.BoardTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.StockCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderVolumeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.MatchedVolumeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.MatchedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.panel1 = new System.Windows.Forms.Panel();
         this.label1 = new System.Windows.Forms.Label();
         this.dataGridMatchedOrder = new System.Windows.Forms.DataGridView();
         this.boardTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.StockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.orderSideVietDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.matchedVolumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.matchedPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.matchedValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.feeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.bindingSourceOrderMatched = new System.Windows.Forms.BindingSource(this.components);
         this.panel2 = new System.Windows.Forms.Panel();
         this.label2 = new System.Windows.Forms.Label();
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.statusStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridMatchedOrder)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOrderMatched)).BeginInit();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // OrderSeq
         // 
         this.OrderSeq.DataPropertyName = "OrderSeq";
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle1.Format = "N0";
         this.OrderSeq.DefaultCellStyle = dataGridViewCellStyle1;
         this.OrderSeq.HeaderText = "SHL";
         this.OrderSeq.MinimumWidth = 50;
         this.OrderSeq.Name = "OrderSeq";
         this.OrderSeq.ReadOnly = true;
         this.OrderSeq.Width = 50;
         // 
         // OrderTime
         // 
         this.OrderTime.DataPropertyName = "OrderTime";
         this.OrderTime.HeaderText = "OrderTime";
         this.OrderTime.Name = "OrderTime";
         this.OrderTime.Visible = false;
         // 
         // OrderDate
         // 
         this.OrderDate.DataPropertyName = "OrderDate";
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle2.Format = "dd/MM/yyyy";
         this.OrderDate.DefaultCellStyle = dataGridViewCellStyle2;
         this.OrderDate.HeaderText = "Ngày";
         this.OrderDate.MinimumWidth = 70;
         this.OrderDate.Name = "OrderDate";
         this.OrderDate.ReadOnly = true;
         this.OrderDate.Width = 70;
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sumOfRecodeLabel});
         this.statusStrip1.Location = new System.Drawing.Point(0, 611);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(1182, 22);
         this.statusStrip1.TabIndex = 9;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // sumOfRecodeLabel
         // 
         this.sumOfRecodeLabel.Name = "sumOfRecodeLabel";
         this.sumOfRecodeLabel.Size = new System.Drawing.Size(0, 17);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.boardTypeBox,
            this.toolStripSeparator4,
            this.toolStripLabel4,
            this.orderSideBox,
            this.toolStripSeparator1,
            this.StockCodeLabel,
            this.StockCodeBox,
            this.toolStripSeparator3,
            this.CustomerIDLabel,
            this.CustomerIDBox,
            this.findBtn,
            this.toolStripSeparator2,
            this.toolStripButton1});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(1182, 25);
         this.toolStrip1.TabIndex = 2;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripLabel3
         // 
         this.toolStripLabel3.Name = "toolStripLabel3";
         this.toolStripLabel3.Size = new System.Drawing.Size(26, 22);
         this.toolStripLabel3.Text = "Sàn";
         // 
         // boardTypeBox
         // 
         this.boardTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.boardTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
         this.boardTypeBox.Items.AddRange(new object[] {
            "<<Tất cả>>",
            "HOSE",
            "HASTC",
            "OTC"});
         this.boardTypeBox.Name = "boardTypeBox";
         this.boardTypeBox.Size = new System.Drawing.Size(85, 25);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripLabel4
         // 
         this.toolStripLabel4.Name = "toolStripLabel4";
         this.toolStripLabel4.Size = new System.Drawing.Size(56, 22);
         this.toolStripLabel4.Text = "Mua/bán";
         // 
         // orderSideBox
         // 
         this.orderSideBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.orderSideBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
         this.orderSideBox.Items.AddRange(new object[] {
            "<<Tất cả>>",
            "Mua",
            "Bán"});
         this.orderSideBox.Name = "orderSideBox";
         this.orderSideBox.Size = new System.Drawing.Size(85, 25);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // StockCodeLabel
         // 
         this.StockCodeLabel.Name = "StockCodeLabel";
         this.StockCodeLabel.Size = new System.Drawing.Size(42, 22);
         this.StockCodeLabel.Text = "Mã CK";
         // 
         // StockCodeBox
         // 
         this.StockCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.StockCodeBox.MaxLength = 20;
         this.StockCodeBox.Name = "StockCodeBox";
         this.StockCodeBox.Size = new System.Drawing.Size(100, 25);
         this.StockCodeBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // CustomerIDLabel
         // 
         this.CustomerIDLabel.Name = "CustomerIDLabel";
         this.CustomerIDLabel.Size = new System.Drawing.Size(59, 22);
         this.CustomerIDLabel.Text = "Tài khoản";
         // 
         // CustomerIDBox
         // 
         this.CustomerIDBox.BackColor = System.Drawing.Color.White;
         this.CustomerIDBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.CustomerIDBox.MaxLength = 10;
         this.CustomerIDBox.Name = "CustomerIDBox";
         this.CustomerIDBox.Size = new System.Drawing.Size(100, 25);
         this.CustomerIDBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // findBtn
         // 
         this.findBtn.Image = global::Brokery.Properties.Resources.find;
         this.findBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.findBtn.Name = "findBtn";
         this.findBtn.Size = new System.Drawing.Size(64, 22);
         this.findBtn.Text = "&Vấn tin";
         this.findBtn.ToolTipText = "Tìm";
         this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripButton1.Image = global::Brokery.Properties.Resources.slides_stack;
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(80, 22);
         this.toolStripButton1.Text = "&Hiện đối ứng";
         this.toolStripButton1.ToolTipText = "Tìm";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 25);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.gridOrder);
         this.splitContainer1.Panel1.Controls.Add(this.panel1);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.dataGridMatchedOrder);
         this.splitContainer1.Panel2.Controls.Add(this.panel2);
         this.splitContainer1.Size = new System.Drawing.Size(1182, 586);
         this.splitContainer1.SplitterDistance = 551;
         this.splitContainer1.TabIndex = 10;
         // 
         // gridOrder
         // 
         this.gridOrder.AllowUserToAddRows = false;
         this.gridOrder.AllowUserToDeleteRows = false;
         this.gridOrder.AllowUserToResizeRows = false;
         this.gridOrder.AutoGenerateColumns = false;
         this.gridOrder.BackgroundColor = System.Drawing.SystemColors.ControlDark;
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.gridOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
         this.gridOrder.ColumnHeadersHeight = 30;
         this.gridOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNo,
            this.BoardTypeColumn,
            this.CustomerId,
            this.StockCodeColumn,
            this.OrderTypeCol,
            this.OrderSide,
            this.OrderVolumeCol,
            this.OrderPriceCol,
            this.MatchedVolumeCol,
            this.MatchedValue});
         this.gridOrder.DataSource = this.bindingSource;
         this.gridOrder.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gridOrder.Location = new System.Drawing.Point(0, 31);
         this.gridOrder.MultiSelect = false;
         this.gridOrder.Name = "gridOrder";
         this.gridOrder.ReadOnly = true;
         this.gridOrder.RowHeadersVisible = false;
         this.gridOrder.RowTemplate.Height = 24;
         this.gridOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.gridOrder.Size = new System.Drawing.Size(551, 555);
         this.gridOrder.TabIndex = 11;
         this.gridOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrder_CellClick);
         // 
         // OrderNo
         // 
         this.OrderNo.HeaderText = "OrderNo";
         this.OrderNo.Name = "OrderNo";
         this.OrderNo.ReadOnly = true;
         this.OrderNo.Visible = false;
         // 
         // BoardTypeColumn
         // 
         this.BoardTypeColumn.DataPropertyName = "BoardType";
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.BoardTypeColumn.DefaultCellStyle = dataGridViewCellStyle4;
         this.BoardTypeColumn.HeaderText = "Sàn";
         this.BoardTypeColumn.Name = "BoardTypeColumn";
         this.BoardTypeColumn.ReadOnly = true;
         this.BoardTypeColumn.Width = 40;
         // 
         // CustomerId
         // 
         this.CustomerId.DataPropertyName = "CustomerId";
         this.CustomerId.HeaderText = "Mã KH";
         this.CustomerId.Name = "CustomerId";
         this.CustomerId.ReadOnly = true;
         this.CustomerId.Width = 80;
         // 
         // StockCodeColumn
         // 
         this.StockCodeColumn.DataPropertyName = "StockCode";
         dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.StockCodeColumn.DefaultCellStyle = dataGridViewCellStyle5;
         this.StockCodeColumn.HeaderText = "Mã CK";
         this.StockCodeColumn.Name = "StockCodeColumn";
         this.StockCodeColumn.ReadOnly = true;
         this.StockCodeColumn.Width = 60;
         // 
         // OrderTypeCol
         // 
         this.OrderTypeCol.DataPropertyName = "OrderType";
         dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.OrderTypeCol.DefaultCellStyle = dataGridViewCellStyle6;
         this.OrderTypeCol.HeaderText = "Lệnh";
         this.OrderTypeCol.MinimumWidth = 40;
         this.OrderTypeCol.Name = "OrderTypeCol";
         this.OrderTypeCol.ReadOnly = true;
         this.OrderTypeCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
         this.OrderTypeCol.Width = 40;
         // 
         // OrderSide
         // 
         this.OrderSide.DataPropertyName = "OrderSideViet";
         dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.OrderSide.DefaultCellStyle = dataGridViewCellStyle7;
         this.OrderSide.HeaderText = "M/B";
         this.OrderSide.Name = "OrderSide";
         this.OrderSide.ReadOnly = true;
         this.OrderSide.Width = 40;
         // 
         // OrderVolumeCol
         // 
         this.OrderVolumeCol.DataPropertyName = "Volume";
         dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle8.Format = "N0";
         this.OrderVolumeCol.DefaultCellStyle = dataGridViewCellStyle8;
         this.OrderVolumeCol.HeaderText = "KL đặt";
         this.OrderVolumeCol.Name = "OrderVolumeCol";
         this.OrderVolumeCol.ReadOnly = true;
         this.OrderVolumeCol.Width = 60;
         // 
         // OrderPriceCol
         // 
         this.OrderPriceCol.DataPropertyName = "Price";
         dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle9.Format = "N1";
         dataGridViewCellStyle9.NullValue = null;
         this.OrderPriceCol.DefaultCellStyle = dataGridViewCellStyle9;
         this.OrderPriceCol.HeaderText = "Giá đặt";
         this.OrderPriceCol.Name = "OrderPriceCol";
         this.OrderPriceCol.ReadOnly = true;
         this.OrderPriceCol.Width = 50;
         // 
         // MatchedVolumeCol
         // 
         this.MatchedVolumeCol.DataPropertyName = "MatchedVolume";
         dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle10.ForeColor = System.Drawing.Color.DarkGreen;
         dataGridViewCellStyle10.Format = "N0";
         this.MatchedVolumeCol.DefaultCellStyle = dataGridViewCellStyle10;
         this.MatchedVolumeCol.HeaderText = "KL đã khớp";
         this.MatchedVolumeCol.MinimumWidth = 70;
         this.MatchedVolumeCol.Name = "MatchedVolumeCol";
         this.MatchedVolumeCol.ReadOnly = true;
         this.MatchedVolumeCol.Width = 70;
         // 
         // MatchedValue
         // 
         this.MatchedValue.DataPropertyName = "MatchedValue";
         dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle11.Format = "n0";
         this.MatchedValue.DefaultCellStyle = dataGridViewCellStyle11;
         this.MatchedValue.HeaderText = "Giá trị khớp";
         this.MatchedValue.Name = "MatchedValue";
         this.MatchedValue.ReadOnly = true;
         // 
         // bindingSource
         // 
         this.bindingSource.AllowNew = true;
         this.bindingSource.DataSource = typeof(Brokery.AgencyWebService.Order);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.label1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(551, 31);
         this.panel1.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
         this.label1.Location = new System.Drawing.Point(0, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(551, 31);
         this.label1.TabIndex = 0;
         this.label1.Text = "LỆNH NHẬP";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // dataGridMatchedOrder
         // 
         this.dataGridMatchedOrder.AllowUserToAddRows = false;
         this.dataGridMatchedOrder.AllowUserToDeleteRows = false;
         this.dataGridMatchedOrder.AllowUserToResizeRows = false;
         this.dataGridMatchedOrder.AutoGenerateColumns = false;
         this.dataGridMatchedOrder.BackgroundColor = System.Drawing.SystemColors.ControlDark;
         dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.dataGridMatchedOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
         this.dataGridMatchedOrder.ColumnHeadersHeight = 30;
         this.dataGridMatchedOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.boardTypeDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.StockCode,
            this.orderSideVietDataGridViewTextBoxColumn,
            this.matchedVolumeDataGridViewTextBoxColumn,
            this.matchedPriceDataGridViewTextBoxColumn,
            this.matchedValueDataGridViewTextBoxColumn,
            this.feeDataGridViewTextBoxColumn});
         this.dataGridMatchedOrder.DataSource = this.bindingSourceOrderMatched;
         this.dataGridMatchedOrder.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridMatchedOrder.Location = new System.Drawing.Point(0, 31);
         this.dataGridMatchedOrder.MultiSelect = false;
         this.dataGridMatchedOrder.Name = "dataGridMatchedOrder";
         this.dataGridMatchedOrder.ReadOnly = true;
         this.dataGridMatchedOrder.RowHeadersVisible = false;
         this.dataGridMatchedOrder.RowTemplate.Height = 24;
         this.dataGridMatchedOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridMatchedOrder.Size = new System.Drawing.Size(627, 555);
         this.dataGridMatchedOrder.TabIndex = 13;
         // 
         // boardTypeDataGridViewTextBoxColumn
         // 
         this.boardTypeDataGridViewTextBoxColumn.DataPropertyName = "BoardType";
         this.boardTypeDataGridViewTextBoxColumn.HeaderText = "Sàn";
         this.boardTypeDataGridViewTextBoxColumn.Name = "boardTypeDataGridViewTextBoxColumn";
         this.boardTypeDataGridViewTextBoxColumn.ReadOnly = true;
         this.boardTypeDataGridViewTextBoxColumn.Width = 40;
         // 
         // customerIdDataGridViewTextBoxColumn
         // 
         this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
         this.customerIdDataGridViewTextBoxColumn.HeaderText = "Mã KH";
         this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
         this.customerIdDataGridViewTextBoxColumn.ReadOnly = true;
         this.customerIdDataGridViewTextBoxColumn.Width = 80;
         // 
         // StockCode
         // 
         this.StockCode.DataPropertyName = "StockCode";
         dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.StockCode.DefaultCellStyle = dataGridViewCellStyle13;
         this.StockCode.HeaderText = "Mã CK";
         this.StockCode.Name = "StockCode";
         this.StockCode.ReadOnly = true;
         this.StockCode.Width = 60;
         // 
         // orderSideVietDataGridViewTextBoxColumn
         // 
         this.orderSideVietDataGridViewTextBoxColumn.DataPropertyName = "OrderSideViet";
         dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.orderSideVietDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
         this.orderSideVietDataGridViewTextBoxColumn.HeaderText = "M/B";
         this.orderSideVietDataGridViewTextBoxColumn.Name = "orderSideVietDataGridViewTextBoxColumn";
         this.orderSideVietDataGridViewTextBoxColumn.ReadOnly = true;
         this.orderSideVietDataGridViewTextBoxColumn.Width = 40;
         // 
         // matchedVolumeDataGridViewTextBoxColumn
         // 
         this.matchedVolumeDataGridViewTextBoxColumn.DataPropertyName = "MatchedVolume";
         dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle15.Format = "n0";
         this.matchedVolumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
         this.matchedVolumeDataGridViewTextBoxColumn.HeaderText = "KL khớp";
         this.matchedVolumeDataGridViewTextBoxColumn.Name = "matchedVolumeDataGridViewTextBoxColumn";
         this.matchedVolumeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // matchedPriceDataGridViewTextBoxColumn
         // 
         this.matchedPriceDataGridViewTextBoxColumn.DataPropertyName = "MatchedPrice";
         dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle16.Format = "n1";
         this.matchedPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
         this.matchedPriceDataGridViewTextBoxColumn.HeaderText = "Giá khớp";
         this.matchedPriceDataGridViewTextBoxColumn.Name = "matchedPriceDataGridViewTextBoxColumn";
         this.matchedPriceDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // matchedValueDataGridViewTextBoxColumn
         // 
         this.matchedValueDataGridViewTextBoxColumn.DataPropertyName = "MatchedValue";
         dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle17.Format = "n0";
         this.matchedValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
         this.matchedValueDataGridViewTextBoxColumn.HeaderText = "Giá trị khớp";
         this.matchedValueDataGridViewTextBoxColumn.Name = "matchedValueDataGridViewTextBoxColumn";
         this.matchedValueDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // feeDataGridViewTextBoxColumn
         // 
         this.feeDataGridViewTextBoxColumn.DataPropertyName = "FeeRate";
         dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle18.Format = "n4";
         this.feeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18;
         this.feeDataGridViewTextBoxColumn.HeaderText = "Phí";
         this.feeDataGridViewTextBoxColumn.Name = "feeDataGridViewTextBoxColumn";
         this.feeDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // bindingSourceOrderMatched
         // 
         this.bindingSourceOrderMatched.DataSource = typeof(Brokery.AgencyWebService.Order);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.label2);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(0, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(627, 31);
         this.panel2.TabIndex = 12;
         // 
         // label2
         // 
         this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
         this.label2.Location = new System.Drawing.Point(0, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(627, 31);
         this.label2.TabIndex = 1;
         this.label2.Text = "LỆNH KHỚP";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // backgroundWorker
         // 
         this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
         this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
         // 
         // MatchedOrderList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1182, 633);
         this.Controls.Add(this.splitContainer1);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.toolStrip1);
         this.Name = "MatchedOrderList";
         this.Text = "Theo dõi kết quả giao dịch";
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
         this.panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridMatchedOrder)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOrderMatched)).EndInit();
         this.panel2.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private ToolStripSeparator toolStripSeparator4;
      private BindingSource bindingSource;
      private DataGridViewTextBoxColumn MatchedPriceColumn;
      private StatusStrip statusStrip1;
      private ToolStripStatusLabel sumOfRecodeLabel;
      private ToolStripSeparator toolStripSeparator1;
      private ToolStripLabel StockCodeLabel;
      private ToolStripTextBox StockCodeBox;
      private ToolStripSeparator toolStripSeparator3;
      private ToolStripLabel CustomerIDLabel;
      private ToolStripTextBox CustomerIDBox;
      private ToolStripButton findBtn;
      private SplitContainer splitContainer1;
      private DataGridView gridOrder;
      private Panel panel1;
      private DataGridView dataGridMatchedOrder;
      private Panel panel2;
      private Label label1;
      private Label label2;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private BindingSource bindingSourceOrderMatched;
      private DataGridViewTextBoxColumn boardTypeDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn StockCode;
      private DataGridViewTextBoxColumn orderSideVietDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn matchedVolumeDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn matchedPriceDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn matchedValueDataGridViewTextBoxColumn;
      private DataGridViewTextBoxColumn feeDataGridViewTextBoxColumn;
      private ToolStripSeparator toolStripSeparator2;
      private ToolStripButton toolStripButton1;
      private DataGridViewTextBoxColumn OrderNo;
      private DataGridViewTextBoxColumn BoardTypeColumn;
      private DataGridViewTextBoxColumn CustomerId;
      private DataGridViewTextBoxColumn StockCodeColumn;
      private DataGridViewTextBoxColumn OrderTypeCol;
      private DataGridViewTextBoxColumn OrderSide;
      private DataGridViewTextBoxColumn OrderVolumeCol;
      private DataGridViewTextBoxColumn OrderPriceCol;
      private DataGridViewTextBoxColumn MatchedVolumeCol;
      private DataGridViewTextBoxColumn MatchedValue;
   }
}