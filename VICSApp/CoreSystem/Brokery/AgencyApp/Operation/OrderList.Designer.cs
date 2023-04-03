﻿using System.Windows.Forms;

namespace Brokery.Operation
{
   partial class OrderList
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;
      private ToolStripComboBox boardTypeBox;
      private ToolStripTextBox CustomerIDBox;
      private ToolStripLabel CustomerIDLabel;
      private ToolStripButton findBtn;
      private BindingSource orderBindingSource = new BindingSource();
      private DataGridViewTextBoxColumn OrderDate;
      private DataGridViewTextBoxColumn OrderSeq;
      private ToolStripComboBox orderSideBox;
      private ToolStripComboBox orderStatusBox;
      private DataGridViewTextBoxColumn OrderTime;
      private ToolStripTextBox StockCodeBox;
      private ToolStripLabel StockCodeLabel;
      private ToolStrip toolStrip1;
      private ToolStrip toolStrip2;
      private ToolStripLabel toolStripLabel3;
      private ToolStripLabel toolStripLabel4;
      private ToolStripLabel toolStripLabel5;
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
         this.OrderSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gridOrder = new System.Windows.Forms.DataGridView();
         this.orderSeqCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.orderTimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderStatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.BoardTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderSideDisplay = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.StockCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderVolumeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.StopPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.IcebergVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.MatchedVolumeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.PublishedVolumeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.PublishedPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CancelledVolumeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ReceivedByCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ApprovedByCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.sumOfRecodeLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStrip2 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
         this.orderStatusBox = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.StockCodeLabel = new System.Windows.Forms.ToolStripLabel();
         this.StockCodeBox = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.CustomerIDLabel = new System.Windows.Forms.ToolStripLabel();
         this.CustomerIDBox = new System.Windows.Forms.ToolStripTextBox();
         this.findBtn = new System.Windows.Forms.ToolStripButton();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
         this.boardTypeBox = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
         this.orderSideBox = new System.Windows.Forms.ToolStripComboBox();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).BeginInit();
         this.statusStrip1.SuspendLayout();
         this.toolStrip2.SuspendLayout();
         this.toolStrip1.SuspendLayout();
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
         // bindingSource
         // 
         this.bindingSource.DataSource = typeof(Brokery.AgencyWebService.Order);
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
            this.orderSeqCol,
            this.orderTimeCol,
            this.OrderStatusColumn,
            this.BoardTypeColumn,
            this.CustomerId,
            this.OrderSideDisplay,
            this.StockCodeColumn,
            this.OrderVolumeCol,
            this.OrderPriceCol,
            this.StopPrice,
            this.IcebergVolume,
            this.OrderTypeCol,
            this.MatchedVolumeCol,
            this.PublishedVolumeCol,
            this.PublishedPriceCol,
            this.CancelledVolumeCol,
            this.Notes,
            this.ReceivedByCol,
            this.ApprovedByCol,
            this.OrderNo});
         this.gridOrder.DataSource = this.bindingSource;
         this.gridOrder.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gridOrder.Location = new System.Drawing.Point(0, 50);
         this.gridOrder.MultiSelect = false;
         this.gridOrder.Name = "gridOrder";
         this.gridOrder.ReadOnly = true;
         this.gridOrder.RowHeadersVisible = false;
         this.gridOrder.RowTemplate.Height = 24;
         this.gridOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.gridOrder.Size = new System.Drawing.Size(1182, 561);
         this.gridOrder.TabIndex = 10;
         // 
         // orderSeqCol
         // 
         this.orderSeqCol.DataPropertyName = "OrderSeq";
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         this.orderSeqCol.DefaultCellStyle = dataGridViewCellStyle4;
         this.orderSeqCol.HeaderText = "SHL";
         this.orderSeqCol.Name = "orderSeqCol";
         this.orderSeqCol.ReadOnly = true;
         this.orderSeqCol.Width = 40;
         // 
         // orderTimeCol
         // 
         this.orderTimeCol.DataPropertyName = "OrderTime";
         dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.orderTimeCol.DefaultCellStyle = dataGridViewCellStyle5;
         this.orderTimeCol.HeaderText = "Giờ";
         this.orderTimeCol.Name = "orderTimeCol";
         this.orderTimeCol.ReadOnly = true;
         this.orderTimeCol.Width = 75;
         // 
         // OrderStatusColumn
         // 
         this.OrderStatusColumn.DataPropertyName = "OrderStatus";
         this.OrderStatusColumn.HeaderText = "Trạng thái";
         this.OrderStatusColumn.Name = "OrderStatusColumn";
         this.OrderStatusColumn.ReadOnly = true;
         this.OrderStatusColumn.Width = 40;
         // 
         // BoardTypeColumn
         // 
         this.BoardTypeColumn.DataPropertyName = "BoardType";
         dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.BoardTypeColumn.DefaultCellStyle = dataGridViewCellStyle6;
         this.BoardTypeColumn.HeaderText = "Sàn";
         this.BoardTypeColumn.Name = "BoardTypeColumn";
         this.BoardTypeColumn.ReadOnly = true;
         this.BoardTypeColumn.Width = 30;
         // 
         // CustomerId
         // 
         this.CustomerId.DataPropertyName = "CustomerId";
         this.CustomerId.HeaderText = "Mã KH";
         this.CustomerId.Name = "CustomerId";
         this.CustomerId.ReadOnly = true;
         this.CustomerId.Width = 80;
         // 
         // OrderSideDisplay
         // 
         this.OrderSideDisplay.DataPropertyName = "OrderSideViet";
         dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
         dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.OrderSideDisplay.DefaultCellStyle = dataGridViewCellStyle7;
         this.OrderSideDisplay.HeaderText = "Loại";
         this.OrderSideDisplay.Name = "OrderSideDisplay";
         this.OrderSideDisplay.ReadOnly = true;
         this.OrderSideDisplay.Width = 50;
         // 
         // StockCodeColumn
         // 
         this.StockCodeColumn.DataPropertyName = "StockCode";
         dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.StockCodeColumn.DefaultCellStyle = dataGridViewCellStyle8;
         this.StockCodeColumn.HeaderText = "Mã CK";
         this.StockCodeColumn.Name = "StockCodeColumn";
         this.StockCodeColumn.ReadOnly = true;
         this.StockCodeColumn.Width = 60;
         // 
         // OrderVolumeCol
         // 
         this.OrderVolumeCol.DataPropertyName = "Volume";
         dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle9.Format = "N0";
         this.OrderVolumeCol.DefaultCellStyle = dataGridViewCellStyle9;
         this.OrderVolumeCol.HeaderText = "KL đặt";
         this.OrderVolumeCol.Name = "OrderVolumeCol";
         this.OrderVolumeCol.ReadOnly = true;
         this.OrderVolumeCol.Width = 60;
         // 
         // OrderPriceCol
         // 
         this.OrderPriceCol.DataPropertyName = "Price";
         dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle10.Format = "N1";
         dataGridViewCellStyle10.NullValue = null;
         this.OrderPriceCol.DefaultCellStyle = dataGridViewCellStyle10;
         this.OrderPriceCol.HeaderText = "Giá đặt";
         this.OrderPriceCol.Name = "OrderPriceCol";
         this.OrderPriceCol.ReadOnly = true;
         this.OrderPriceCol.Width = 50;
         // 
         // StopPrice
         // 
         this.StopPrice.DataPropertyName = "StopPrice";
         dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle11.Format = "N1";
         this.StopPrice.DefaultCellStyle = dataGridViewCellStyle11;
         this.StopPrice.HeaderText = "Giá dừng (SO)";
         this.StopPrice.Name = "StopPrice";
         this.StopPrice.ReadOnly = true;
         // 
         // IcebergVolume
         // 
         this.IcebergVolume.DataPropertyName = "IcebergVolume";
         dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle12.Format = "N0";
         this.IcebergVolume.DefaultCellStyle = dataGridViewCellStyle12;
         this.IcebergVolume.HeaderText = "KL đỉnh (IO)";
         this.IcebergVolume.Name = "IcebergVolume";
         this.IcebergVolume.ReadOnly = true;
         this.IcebergVolume.Visible = false;
         // 
         // OrderTypeCol
         // 
         this.OrderTypeCol.DataPropertyName = "OrderType";
         dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         this.OrderTypeCol.DefaultCellStyle = dataGridViewCellStyle13;
         this.OrderTypeCol.HeaderText = "Lệnh";
         this.OrderTypeCol.MinimumWidth = 40;
         this.OrderTypeCol.Name = "OrderTypeCol";
         this.OrderTypeCol.ReadOnly = true;
         this.OrderTypeCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
         this.OrderTypeCol.Width = 40;
         // 
         // MatchedVolumeCol
         // 
         this.MatchedVolumeCol.DataPropertyName = "MatchedVolume";
         dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle14.ForeColor = System.Drawing.Color.DarkGreen;
         dataGridViewCellStyle14.Format = "N0";
         this.MatchedVolumeCol.DefaultCellStyle = dataGridViewCellStyle14;
         this.MatchedVolumeCol.HeaderText = "KL đã khớp";
         this.MatchedVolumeCol.MinimumWidth = 70;
         this.MatchedVolumeCol.Name = "MatchedVolumeCol";
         this.MatchedVolumeCol.ReadOnly = true;
         this.MatchedVolumeCol.Width = 70;
         // 
         // PublishedVolumeCol
         // 
         this.PublishedVolumeCol.DataPropertyName = "PublishedVolume";
         dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         this.PublishedVolumeCol.DefaultCellStyle = dataGridViewCellStyle15;
         this.PublishedVolumeCol.HeaderText = "KL chờ khớp";
         this.PublishedVolumeCol.Name = "PublishedVolumeCol";
         this.PublishedVolumeCol.ReadOnly = true;
         this.PublishedVolumeCol.Width = 70;
         // 
         // PublishedPriceCol
         // 
         this.PublishedPriceCol.DataPropertyName = "PublishedPrice";
         dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle16.Format = "N1";
         this.PublishedPriceCol.DefaultCellStyle = dataGridViewCellStyle16;
         this.PublishedPriceCol.HeaderText = "Giá chờ khớp";
         this.PublishedPriceCol.MinimumWidth = 80;
         this.PublishedPriceCol.Name = "PublishedPriceCol";
         this.PublishedPriceCol.ReadOnly = true;
         this.PublishedPriceCol.Width = 80;
         // 
         // CancelledVolumeCol
         // 
         this.CancelledVolumeCol.DataPropertyName = "CancelledVolume";
         dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
         dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
         dataGridViewCellStyle17.Format = "N0";
         this.CancelledVolumeCol.DefaultCellStyle = dataGridViewCellStyle17;
         this.CancelledVolumeCol.HeaderText = "KL hủy";
         this.CancelledVolumeCol.MinimumWidth = 60;
         this.CancelledVolumeCol.Name = "CancelledVolumeCol";
         this.CancelledVolumeCol.ReadOnly = true;
         this.CancelledVolumeCol.Width = 60;
         // 
         // Notes
         // 
         this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
         this.Notes.DataPropertyName = "Notes";
         this.Notes.HeaderText = "Lưu ý";
         this.Notes.MinimumWidth = 100;
         this.Notes.Name = "Notes";
         this.Notes.ReadOnly = true;
         // 
         // ReceivedByCol
         // 
         this.ReceivedByCol.DataPropertyName = "ReceivedBy";
         this.ReceivedByCol.HeaderText = "Người nhập";
         this.ReceivedByCol.Name = "ReceivedByCol";
         this.ReceivedByCol.ReadOnly = true;
         this.ReceivedByCol.Width = 70;
         // 
         // ApprovedByCol
         // 
         this.ApprovedByCol.DataPropertyName = "ApprovedBy";
         this.ApprovedByCol.HeaderText = "Người duyệt";
         this.ApprovedByCol.Name = "ApprovedByCol";
         this.ApprovedByCol.ReadOnly = true;
         this.ApprovedByCol.Width = 70;
         // 
         // OrderNo
         // 
         this.OrderNo.DataPropertyName = "OrderNo";
         this.OrderNo.HeaderText = "OrderNo";
         this.OrderNo.Name = "OrderNo";
         this.OrderNo.ReadOnly = true;
         this.OrderNo.Visible = false;
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
         // toolStrip2
         // 
         this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.orderStatusBox,
            this.toolStripSeparator2,
            this.StockCodeLabel,
            this.StockCodeBox,
            this.toolStripSeparator3,
            this.CustomerIDLabel,
            this.CustomerIDBox,
            this.findBtn});
         this.toolStrip2.Location = new System.Drawing.Point(0, 25);
         this.toolStrip2.Name = "toolStrip2";
         this.toolStrip2.Size = new System.Drawing.Size(1182, 25);
         this.toolStrip2.TabIndex = 4;
         this.toolStrip2.Text = "toolStrip2";
         // 
         // toolStripLabel5
         // 
         this.toolStripLabel5.Name = "toolStripLabel5";
         this.toolStripLabel5.Size = new System.Drawing.Size(87, 22);
         this.toolStripLabel5.Text = "Trạng thái lệnh";
         // 
         // orderStatusBox
         // 
         this.orderStatusBox.AutoSize = false;
         this.orderStatusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.orderStatusBox.DropDownWidth = 300;
         this.orderStatusBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
         this.orderStatusBox.Name = "orderStatusBox";
         this.orderStatusBox.Size = new System.Drawing.Size(150, 23);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
         this.findBtn.Size = new System.Drawing.Size(48, 22);
         this.findBtn.Text = "Tì&m";
         this.findBtn.ToolTipText = "Tìm";
         this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.boardTypeBox,
            this.toolStripSeparator4,
            this.toolStripLabel4,
            this.orderSideBox});
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
         // OrderList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1182, 633);
         this.Controls.Add(this.gridOrder);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.toolStrip2);
         this.Controls.Add(this.toolStrip1);
         this.Name = "OrderList";
         this.Text = "Danh sách các lệnh trong hệ thống";
         ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).EndInit();
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.toolStrip2.ResumeLayout(false);
         this.toolStrip2.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private ToolStripSeparator toolStripSeparator4;
      private ToolStripSeparator toolStripSeparator2;
      private ToolStripSeparator toolStripSeparator3;
      private BindingSource bindingSource;
      private DataGridViewTextBoxColumn MatchedPriceColumn;
      private StatusStrip statusStrip1;
      private ToolStripStatusLabel sumOfRecodeLabel;
      private DataGridView gridOrder;
      private DataGridViewTextBoxColumn orderSeqCol;
      private DataGridViewTextBoxColumn orderTimeCol;
      private DataGridViewTextBoxColumn OrderStatusColumn;
      private DataGridViewTextBoxColumn BoardTypeColumn;
      private DataGridViewTextBoxColumn CustomerId;
      private DataGridViewTextBoxColumn OrderSideDisplay;
      private DataGridViewTextBoxColumn StockCodeColumn;
      private DataGridViewTextBoxColumn OrderVolumeCol;
      private DataGridViewTextBoxColumn OrderPriceCol;
      private DataGridViewTextBoxColumn StopPrice;
      private DataGridViewTextBoxColumn IcebergVolume;
      private DataGridViewTextBoxColumn OrderTypeCol;
      private DataGridViewTextBoxColumn MatchedVolumeCol;
      private DataGridViewTextBoxColumn PublishedVolumeCol;
      private DataGridViewTextBoxColumn PublishedPriceCol;
      private DataGridViewTextBoxColumn CancelledVolumeCol;
      private DataGridViewTextBoxColumn Notes;
      private DataGridViewTextBoxColumn ReceivedByCol;
      private DataGridViewTextBoxColumn ApprovedByCol;
      private DataGridViewTextBoxColumn OrderNo;
   }
}