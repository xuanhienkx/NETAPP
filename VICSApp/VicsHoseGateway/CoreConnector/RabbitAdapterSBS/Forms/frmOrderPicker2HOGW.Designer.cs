namespace HOGW_CoreConnector.Forms
{
    partial class frmOrderPicker2HOGW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderPicker2HOGW));
            this.gridData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboOrderSide = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBranches = new System.Windows.Forms.ComboBox();
            this.btnGetOrders = new System.Windows.Forms.Button();
            this.btnEnterGW = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOrderType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVolumePivot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToOrderColumns = true;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Location = new System.Drawing.Point(13, 95);
            this.gridData.Name = "gridData";
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridData.Size = new System.Drawing.Size(1010, 518);
            this.gridData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tài khoản";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(409, 12);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(99, 20);
            this.txtCustomerID.TabIndex = 3;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bên";
            // 
            // cboOrderSide
            // 
            this.cboOrderSide.FormattingEnabled = true;
            this.cboOrderSide.Location = new System.Drawing.Point(262, 12);
            this.cboOrderSide.Name = "cboOrderSide";
            this.cboOrderSide.Size = new System.Drawing.Size(83, 21);
            this.cboOrderSide.TabIndex = 2;
            this.cboOrderSide.SelectedIndexChanged += new System.EventHandler(this.cboOrderSide_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chi nhánh";
            // 
            // cboBranches
            // 
            this.cboBranches.FormattingEnabled = true;
            this.cboBranches.Location = new System.Drawing.Point(73, 12);
            this.cboBranches.Name = "cboBranches";
            this.cboBranches.Size = new System.Drawing.Size(142, 21);
            this.cboBranches.TabIndex = 1;
            this.cboBranches.SelectedIndexChanged += new System.EventHandler(this.cboBranches_SelectedIndexChanged);
            // 
            // btnGetOrders
            // 
            this.btnGetOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnGetOrders.Image")));
            this.btnGetOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetOrders.Location = new System.Drawing.Point(434, 52);
            this.btnGetOrders.Name = "btnGetOrders";
            this.btnGetOrders.Size = new System.Drawing.Size(141, 32);
            this.btnGetOrders.TabIndex = 8;
            this.btnGetOrders.Text = "&Lấy dữ liệu mới (F5)";
            this.btnGetOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetOrders.UseVisualStyleBackColor = true;
            this.btnGetOrders.Click += new System.EventHandler(this.btnGetOrders_Click);
            // 
            // btnEnterGW
            // 
            this.btnEnterGW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterGW.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnEnterGW.Image = ((System.Drawing.Image)(resources.GetObject("btnEnterGW.Image")));
            this.btnEnterGW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnterGW.Location = new System.Drawing.Point(13, 52);
            this.btnEnterGW.Name = "btnEnterGW";
            this.btnEnterGW.Size = new System.Drawing.Size(141, 33);
            this.btnEnterGW.TabIndex = 7;
            this.btnEnterGW.Text = "Đẩy vào &Gateway (F1)";
            this.btnEnterGW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnterGW.UseVisualStyleBackColor = true;
            this.btnEnterGW.Click += new System.EventHandler(this.btnEnterGW_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(696, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "&Thoát (Ctrl+F4)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblOrderCount
            // 
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCount.ForeColor = System.Drawing.Color.Red;
            this.lblOrderCount.Location = new System.Drawing.Point(973, 15);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(50, 13);
            this.lblOrderCount.TabIndex = 17;
            this.lblOrderCount.Text = "Số lệnh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(931, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Số lệnh: ";
            // 
            // cboOrderType
            // 
            this.cboOrderType.FormattingEnabled = true;
            this.cboOrderType.Location = new System.Drawing.Point(568, 12);
            this.cboOrderType.Name = "cboOrderType";
            this.cboOrderType.Size = new System.Drawing.Size(83, 21);
            this.cboOrderType.TabIndex = 4;
            this.cboOrderType.SelectedIndexChanged += new System.EventHandler(this.cboOrderType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Loại lệnh";
            // 
            // txtVolumePivot
            // 
            this.txtVolumePivot.Location = new System.Drawing.Point(692, 12);
            this.txtVolumePivot.Name = "txtVolumePivot";
            this.txtVolumePivot.Size = new System.Drawing.Size(110, 20);
            this.txtVolumePivot.TabIndex = 5;
            this.txtVolumePivot.TextChanged += new System.EventHandler(this.txtVolumePivot_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(657, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "KL >=";
            // 
            // txtStockCode
            // 
            this.txtStockCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStockCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockCode.ForeColor = System.Drawing.Color.Green;
            this.txtStockCode.Location = new System.Drawing.Point(842, 12);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(85, 20);
            this.txtStockCode.TabIndex = 6;
            this.txtStockCode.TextChanged += new System.EventHandler(this.txtStockCode_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(805, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Mã CK";
            // 
            // frmOrderPicker2HOGW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 625);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVolumePivot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboOrderType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblOrderCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEnterGW);
            this.Controls.Add(this.btnGetOrders);
            this.Controls.Add(this.cboBranches);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboOrderSide);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmOrderPicker2HOGW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn lệnh đẩy vào Gateway";
            this.Load += new System.EventHandler(this.frmOrderPicker2HOGW_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderPicker2HOGW_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOrderSide;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBranches;
        private System.Windows.Forms.Button btnGetOrders;
        private System.Windows.Forms.Button btnEnterGW;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblOrderCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOrderType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVolumePivot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Label label7;
    }
}