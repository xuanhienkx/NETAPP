namespace TradingOnline
{
    partial class OrderForm
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
            this.grpCancelOrder = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpChangeOrder = new System.Windows.Forms.GroupBox();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSubmit1 = new System.Windows.Forms.Button();
            this.txtOrderNumber1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirm1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMessageType = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.grpCancelOrder.SuspendLayout();
            this.grpChangeOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCancelOrder
            // 
            this.grpCancelOrder.Controls.Add(this.btnSubmit);
            this.grpCancelOrder.Controls.Add(this.txtOrderNumber);
            this.grpCancelOrder.Controls.Add(this.label2);
            this.grpCancelOrder.Controls.Add(this.txtFirm);
            this.grpCancelOrder.Controls.Add(this.label1);
            this.grpCancelOrder.Location = new System.Drawing.Point(12, 12);
            this.grpCancelOrder.Name = "grpCancelOrder";
            this.grpCancelOrder.Size = new System.Drawing.Size(326, 111);
            this.grpCancelOrder.TabIndex = 0;
            this.grpCancelOrder.TabStop = false;
            this.grpCancelOrder.Text = "Cancel Order";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(100, 76);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(100, 50);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.txtOrderNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order Number:";
            // 
            // txtFirm
            // 
            this.txtFirm.Location = new System.Drawing.Point(100, 25);
            this.txtFirm.Name = "txtFirm";
            this.txtFirm.Size = new System.Drawing.Size(100, 20);
            this.txtFirm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firm:";
            // 
            // grpChangeOrder
            // 
            this.grpChangeOrder.Controls.Add(this.txtClientID);
            this.grpChangeOrder.Controls.Add(this.label7);
            this.grpChangeOrder.Controls.Add(this.btnSubmit1);
            this.grpChangeOrder.Controls.Add(this.txtOrderNumber1);
            this.grpChangeOrder.Controls.Add(this.label5);
            this.grpChangeOrder.Controls.Add(this.txtFirm1);
            this.grpChangeOrder.Controls.Add(this.label6);
            this.grpChangeOrder.Location = new System.Drawing.Point(12, 129);
            this.grpChangeOrder.Name = "grpChangeOrder";
            this.grpChangeOrder.Size = new System.Drawing.Size(326, 135);
            this.grpChangeOrder.TabIndex = 1;
            this.grpChangeOrder.TabStop = false;
            this.grpChangeOrder.Text = "Change Order";
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(100, 77);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(100, 20);
            this.txtClientID.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Client ID:";
            // 
            // btnSubmit1
            // 
            this.btnSubmit1.Location = new System.Drawing.Point(100, 103);
            this.btnSubmit1.Name = "btnSubmit1";
            this.btnSubmit1.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit1.TabIndex = 13;
            this.btnSubmit1.Text = "submit";
            this.btnSubmit1.UseVisualStyleBackColor = true;
            this.btnSubmit1.Click += new System.EventHandler(this.btnSubmit1_Click);
            // 
            // txtOrderNumber1
            // 
            this.txtOrderNumber1.Location = new System.Drawing.Point(100, 51);
            this.txtOrderNumber1.Name = "txtOrderNumber1";
            this.txtOrderNumber1.Size = new System.Drawing.Size(100, 20);
            this.txtOrderNumber1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Order Number:";
            // 
            // txtFirm1
            // 
            this.txtFirm1.Location = new System.Drawing.Point(100, 26);
            this.txtFirm1.Name = "txtFirm1";
            this.txtFirm1.Size = new System.Drawing.Size(100, 20);
            this.txtFirm1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Firm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Choose a message type:";
            // 
            // cboMessageType
            // 
            this.cboMessageType.FormattingEnabled = true;
            this.cboMessageType.Items.AddRange(new object[] {
            "1C",
            "1D",
            "1E",
            "1F",
            "1G",
            "1I",
            "3A",
            "3B",
            "3C",
            "3D",
            "RN",
            "RP",
            "RQ",
            "AA",
            "BR",
            "BS",
            "CO",
            "DC",
            "GA",
            "IU",
            "LO",
            "LS",
            "NH",
            "NS",
            "OL",
            "OS",
            "PD",
            "PO",
            "SC",
            "SI",
            "SR",
            "SS",
            "SU",
            "TC",
            "TP",
            "TR",
            "TS"});
            this.cboMessageType.Location = new System.Drawing.Point(129, 268);
            this.cboMessageType.Name = "cboMessageType";
            this.cboMessageType.Size = new System.Drawing.Size(83, 21);
            this.cboMessageType.TabIndex = 3;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(12, 296);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 14;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 332);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.cboMessageType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpChangeOrder);
            this.Controls.Add(this.grpCancelOrder);
            this.Name = "OrderForm";
            this.Text = "ORDER MANAGEMENT";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.grpCancelOrder.ResumeLayout(false);
            this.grpCancelOrder.PerformLayout();
            this.grpChangeOrder.ResumeLayout(false);
            this.grpChangeOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCancelOrder;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpChangeOrder;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSubmit1;
        private System.Windows.Forms.TextBox txtOrderNumber1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirm1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMessageType;
        private System.Windows.Forms.Button btnInsert;
    }
}

