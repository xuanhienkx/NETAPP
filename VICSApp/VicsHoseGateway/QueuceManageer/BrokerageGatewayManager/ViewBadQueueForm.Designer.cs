namespace BrokerageGatewayManager
{
    partial class ViewBadQueueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewBadQueueForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessageCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.grdBadMessageDetails = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveBadMessages = new System.Windows.Forms.Button();
            this.lblSavedMessages = new System.Windows.Forms.Label();
            this.messageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdBadMessageDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Có tổng cộng ";
            // 
            // lblMessageCount
            // 
            this.lblMessageCount.AutoSize = true;
            this.lblMessageCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMessageCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessageCount.Location = new System.Drawing.Point(114, 9);
            this.lblMessageCount.Name = "lblMessageCount";
            this.lblMessageCount.Size = new System.Drawing.Size(15, 14);
            this.lblMessageCount.TabIndex = 1;
            this.lblMessageCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(146, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "message(s) trong BadQueue";
            // 
            // lstMsg
            // 
            this.lstMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lstMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.Location = new System.Drawing.Point(4, 40);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstMsg.Size = new System.Drawing.Size(466, 366);
            this.lstMsg.TabIndex = 3;
            this.lstMsg.SelectedIndexChanged += new System.EventHandler(this.lstMsg_SelectedIndexChanged);
            // 
            // grdBadMessageDetails
            // 
            this.grdBadMessageDetails.AllowUserToResizeRows = false;
            this.grdBadMessageDetails.AutoGenerateColumns = false;
            this.grdBadMessageDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdBadMessageDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grdBadMessageDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBadMessageDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.grdBadMessageDetails.DataSource = this.messageBindingSource;
            this.grdBadMessageDetails.GridColor = System.Drawing.Color.Gray;
            this.grdBadMessageDetails.Location = new System.Drawing.Point(476, 40);
            this.grdBadMessageDetails.MultiSelect = false;
            this.grdBadMessageDetails.Name = "grdBadMessageDetails";
            this.grdBadMessageDetails.ReadOnly = true;
            this.grdBadMessageDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdBadMessageDetails.RowHeadersVisible = false;
            this.grdBadMessageDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBadMessageDetails.Size = new System.Drawing.Size(264, 366);
            this.grdBadMessageDetails.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.Location = new System.Drawing.Point(599, 413);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(141, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa message đã chọn";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveBadMessages
            // 
            this.btnSaveBadMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSaveBadMessages.Location = new System.Drawing.Point(4, 413);
            this.btnSaveBadMessages.Name = "btnSaveBadMessages";
            this.btnSaveBadMessages.Size = new System.Drawing.Size(205, 30);
            this.btnSaveBadMessages.TabIndex = 6;
            this.btnSaveBadMessages.Text = "Lưu tất cả message trên vào database";
            this.btnSaveBadMessages.UseVisualStyleBackColor = false;
            this.btnSaveBadMessages.Click += new System.EventHandler(this.btnSaveBadMessages_Click);
            // 
            // lblSavedMessages
            // 
            this.lblSavedMessages.AutoSize = true;
            this.lblSavedMessages.Location = new System.Drawing.Point(13, 429);
            this.lblSavedMessages.Name = "lblSavedMessages";
            this.lblSavedMessages.Size = new System.Drawing.Size(0, 13);
            this.lblSavedMessages.TabIndex = 7;
            // 
            // messageBindingSource
            // 
            this.messageBindingSource.DataSource = typeof(BrokerageGatewayManager.Entities.Message);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nameDataGridViewTextBoxColumn.FillWeight = 70F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Tên thuộc tính";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.valueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.valueDataGridViewTextBoxColumn.FillWeight = 30F;
            this.valueDataGridViewTextBoxColumn.HeaderText = "Giá trị";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ViewBadQueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(744, 455);
            this.Controls.Add(this.lblSavedMessages);
            this.Controls.Add(this.btnSaveBadMessages);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grdBadMessageDetails);
            this.Controls.Add(this.lstMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMessageCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ViewBadQueueForm";
            this.Text = "Xem Bad Queue";
            this.Load += new System.EventHandler(this.ViewBadQueueForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewBadQueueForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdBadMessageDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMessageCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.DataGridView grdBadMessageDetails;
        private System.Windows.Forms.BindingSource messageBindingSource;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveBadMessages;
        private System.Windows.Forms.Label lblSavedMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}