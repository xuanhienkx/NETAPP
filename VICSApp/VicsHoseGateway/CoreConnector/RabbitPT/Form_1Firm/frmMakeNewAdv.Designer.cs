namespace HOGW_PT_Dealer
{
    partial class frmMakeNewAdv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMakeNewAdv));
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCeilingPrice = new System.Windows.Forms.Label();
            this.lblBasicPrice = new System.Windows.Forms.Label();
            this.lblFloorPrice = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTraderID = new System.Windows.Forms.ComboBox();
            this.lblTraderID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.cboSide = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAddOrCancel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cboBoardType = new System.Windows.Forms.ComboBox();
            this.lblSuspension = new System.Windows.Forms.Label();
            this.lblSplit = new System.Windows.Forms.Label();
            this.lblHalt = new System.Windows.Forms.Label();
            this.lblDelist = new System.Windows.Forms.Label();
            this.chkHalt = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttipStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cboSecurities = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTotalValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.LightCyan;
            this.txtPrice.Location = new System.Drawing.Point(127, 94);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(153, 20);
            this.txtPrice.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Trader ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Giá";
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(154, 249);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(121, 31);
            this.btnEnter.TabIndex = 22;
            this.btnEnter.Text = "&Nhập";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnterClick);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(313, 249);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 31);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Đón&g";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(27, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Chứng khoán";
            // 
            // lblCeilingPrice
            // 
            this.lblCeilingPrice.AutoSize = true;
            this.lblCeilingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCeilingPrice.ForeColor = System.Drawing.Color.Magenta;
            this.lblCeilingPrice.Location = new System.Drawing.Point(66, 0);
            this.lblCeilingPrice.Name = "lblCeilingPrice";
            this.lblCeilingPrice.Size = new System.Drawing.Size(57, 20);
            this.lblCeilingPrice.TabIndex = 29;
            this.lblCeilingPrice.Text = "label5";
            // 
            // lblBasicPrice
            // 
            this.lblBasicPrice.AutoSize = true;
            this.lblBasicPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicPrice.ForeColor = System.Drawing.Color.Yellow;
            this.lblBasicPrice.Location = new System.Drawing.Point(236, 0);
            this.lblBasicPrice.Name = "lblBasicPrice";
            this.lblBasicPrice.Size = new System.Drawing.Size(67, 20);
            this.lblBasicPrice.TabIndex = 30;
            this.lblBasicPrice.Text = "label14";
            // 
            // lblFloorPrice
            // 
            this.lblFloorPrice.AutoSize = true;
            this.lblFloorPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloorPrice.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lblFloorPrice.Location = new System.Drawing.Point(414, 0);
            this.lblFloorPrice.Name = "lblFloorPrice";
            this.lblFloorPrice.Size = new System.Drawing.Size(67, 20);
            this.lblFloorPrice.TabIndex = 31;
            this.lblFloorPrice.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(7, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Giá trần";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(156, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Giá tham chiếu";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(358, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Giá sàn";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Controls.Add(this.lblCeilingPrice);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.lblBasicPrice);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.lblFloorPrice);
            this.panel1.Location = new System.Drawing.Point(15, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 22);
            this.panel1.TabIndex = 35;
            // 
            // cboTraderID
            // 
            this.cboTraderID.BackColor = System.Drawing.Color.SkyBlue;
            this.cboTraderID.FormattingEnabled = true;
            this.cboTraderID.Location = new System.Drawing.Point(126, 173);
            this.cboTraderID.Name = "cboTraderID";
            this.cboTraderID.Size = new System.Drawing.Size(154, 21);
            this.cboTraderID.TabIndex = 6;
            this.cboTraderID.SelectedIndexChanged += new System.EventHandler(this.cboTraderID_SelectedIndexChanged);
            // 
            // lblTraderID
            // 
            this.lblTraderID.AutoSize = true;
            this.lblTraderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraderID.Location = new System.Drawing.Point(286, 176);
            this.lblTraderID.Name = "lblTraderID";
            this.lblTraderID.Size = new System.Drawing.Size(70, 13);
            this.lblTraderID.TabIndex = 45;
            this.lblTraderID.Text = "lblTraderID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Khối lượng";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(126, 120);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(154, 20);
            this.txtVolume.TabIndex = 3;
            this.txtVolume.TextChanged += new System.EventHandler(this.txtVolume_TextChanged);
            this.txtVolume.Leave += new System.EventHandler(this.txtVolume_Leave);
            // 
            // cboSide
            // 
            this.cboSide.BackColor = System.Drawing.Color.White;
            this.cboSide.FormattingEnabled = true;
            this.cboSide.Location = new System.Drawing.Point(126, 146);
            this.cboSide.Name = "cboSide";
            this.cboSide.Size = new System.Drawing.Size(106, 21);
            this.cboSide.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Mua/bán";
            // 
            // cboAddOrCancel
            // 
            this.cboAddOrCancel.BackColor = System.Drawing.Color.White;
            this.cboAddOrCancel.FormattingEnabled = true;
            this.cboAddOrCancel.Location = new System.Drawing.Point(433, 146);
            this.cboAddOrCancel.Name = "cboAddOrCancel";
            this.cboAddOrCancel.Size = new System.Drawing.Size(106, 21);
            this.cboAddOrCancel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Thêm/hủy";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(27, 204);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 75;
            this.label21.Text = "Lô chẵn/lẻ";
            // 
            // cboBoardType
            // 
            this.cboBoardType.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cboBoardType.FormattingEnabled = true;
            this.cboBoardType.Location = new System.Drawing.Point(126, 201);
            this.cboBoardType.Name = "cboBoardType";
            this.cboBoardType.Size = new System.Drawing.Size(89, 21);
            this.cboBoardType.TabIndex = 7;
            // 
            // lblSuspension
            // 
            this.lblSuspension.AutoSize = true;
            this.lblSuspension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuspension.ForeColor = System.Drawing.Color.Red;
            this.lblSuspension.Location = new System.Drawing.Point(373, 39);
            this.lblSuspension.Name = "lblSuspension";
            this.lblSuspension.Size = new System.Drawing.Size(85, 13);
            this.lblSuspension.TabIndex = 79;
            this.lblSuspension.Text = "lblSuspension";
            // 
            // lblSplit
            // 
            this.lblSplit.AutoSize = true;
            this.lblSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplit.ForeColor = System.Drawing.Color.Red;
            this.lblSplit.Location = new System.Drawing.Point(281, 39);
            this.lblSplit.Name = "lblSplit";
            this.lblSplit.Size = new System.Drawing.Size(45, 13);
            this.lblSplit.TabIndex = 78;
            this.lblSplit.Text = "lblSplit";
            // 
            // lblHalt
            // 
            this.lblHalt.AutoSize = true;
            this.lblHalt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalt.ForeColor = System.Drawing.Color.Red;
            this.lblHalt.Location = new System.Drawing.Point(189, 39);
            this.lblHalt.Name = "lblHalt";
            this.lblHalt.Size = new System.Drawing.Size(43, 13);
            this.lblHalt.TabIndex = 77;
            this.lblHalt.Text = "lblHalt";
            // 
            // lblDelist
            // 
            this.lblDelist.AutoSize = true;
            this.lblDelist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelist.ForeColor = System.Drawing.Color.Red;
            this.lblDelist.Location = new System.Drawing.Point(96, 39);
            this.lblDelist.Name = "lblDelist";
            this.lblDelist.Size = new System.Drawing.Size(52, 13);
            this.lblDelist.TabIndex = 76;
            this.lblDelist.Text = "lblDelist";
            // 
            // chkHalt
            // 
            this.chkHalt.AutoSize = true;
            this.chkHalt.Location = new System.Drawing.Point(15, 257);
            this.chkHalt.Name = "chkHalt";
            this.chkHalt.Size = new System.Drawing.Size(135, 17);
            this.chkHalt.TabIndex = 8;
            this.chkHalt.Text = "Bỏ qua Treo/Dừng GD";
            this.chkHalt.UseVisualStyleBackColor = true;
            this.chkHalt.Visible = false;
            this.chkHalt.CheckedChanged += new System.EventHandler(this.chkHalt_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttipStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 292);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(563, 22);
            this.statusStrip1.TabIndex = 81;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttipStatus
            // 
            this.ttipStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ttipStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ttipStatus.Name = "ttipStatus";
            this.ttipStatus.Size = new System.Drawing.Size(130, 17);
            this.ttipStatus.Text = "toolStripStatusLabel1";
            // 
            // cboSecurities
            // 
            this.cboSecurities.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSecurities.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboSecurities.BackColor = System.Drawing.Color.White;
            this.cboSecurities.FormattingEnabled = true;
            this.cboSecurities.Location = new System.Drawing.Point(127, 65);
            this.cboSecurities.Name = "cboSecurities";
            this.cboSecurities.Size = new System.Drawing.Size(412, 21);
            this.cboSecurities.TabIndex = 1;
            this.cboSecurities.SelectedIndexChanged += new System.EventHandler(this.cboSecurities_SelectedIndexChanged);
            this.cboSecurities.Leave += new System.EventHandler(this.cboSecurities_Leave);
            this.cboSecurities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSecurities_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(286, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "(nghìn đồng)";
            // 
            // lbTotalValue
            // 
            this.lbTotalValue.AutoSize = true;
            this.lbTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalValue.ForeColor = System.Drawing.Color.Sienna;
            this.lbTotalValue.Location = new System.Drawing.Point(129, 230);
            this.lbTotalValue.Name = "lbTotalValue";
            this.lbTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTotalValue.Size = new System.Drawing.Size(78, 13);
            this.lbTotalValue.TabIndex = 97;
            this.lbTotalValue.Text = "lbTotalValue";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(208, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "(VND)";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(27, 230);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(94, 13);
            this.lbTotal.TabIndex = 95;
            this.lbTotal.Text = "Tổng giá trị GD";
            // 
            // frmMakeNewAdv
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(563, 314);
            this.Controls.Add(this.lbTotalValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboSecurities);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkHalt);
            this.Controls.Add(this.lblSuspension);
            this.Controls.Add(this.lblSplit);
            this.Controls.Add(this.lblHalt);
            this.Controls.Add(this.lblDelist);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cboBoardType);
            this.Controls.Add(this.cboAddOrCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboSide);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.lblTraderID);
            this.Controls.Add(this.cboTraderID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMakeNewAdv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quảng cáo mua/bán chứng khoán";
            this.Load += new System.EventHandler(this.frmMakeNewPTDeal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMakeNewAdv_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCeilingPrice;
        private System.Windows.Forms.Label lblBasicPrice;
        private System.Windows.Forms.Label lblFloorPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTraderID;
        private System.Windows.Forms.Label lblTraderID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.ComboBox cboSide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAddOrCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboBoardType;
        private System.Windows.Forms.Label lblSuspension;
        private System.Windows.Forms.Label lblSplit;
        private System.Windows.Forms.Label lblHalt;
        private System.Windows.Forms.Label lblDelist;
        private System.Windows.Forms.CheckBox chkHalt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttipStatus;
        private System.Windows.Forms.ComboBox cboSecurities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTotalValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbTotal;
    }
}
