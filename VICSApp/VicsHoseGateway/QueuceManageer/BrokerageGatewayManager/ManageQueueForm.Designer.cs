namespace BrokerageGatewayManager
{
    partial class ManageQueueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageQueueForm));
            this.btnViewBadQueue = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkInternalQueue = new System.Windows.Forms.CheckBox();
            this.chkInboxQueue = new System.Windows.Forms.CheckBox();
            this.chkBadQueue = new System.Windows.Forms.CheckBox();
            this.chkOutboxQueue = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewBadQueue
            // 
            this.btnViewBadQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnViewBadQueue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnViewBadQueue.Location = new System.Drawing.Point(12, 210);
            this.btnViewBadQueue.Name = "btnViewBadQueue";
            this.btnViewBadQueue.Size = new System.Drawing.Size(108, 23);
            this.btnViewBadQueue.TabIndex = 21;
            this.btnViewBadQueue.Text = "Xem Bad Queue";
            this.btnViewBadQueue.UseVisualStyleBackColor = false;
            this.btnViewBadQueue.Click += new System.EventHandler(this.btnViewBadQueue_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.chkInternalQueue);
            this.groupBox1.Controls.Add(this.chkInboxQueue);
            this.groupBox1.Controls.Add(this.chkBadQueue);
            this.groupBox1.Controls.Add(this.chkOutboxQueue);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 192);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn queue để xóa";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBox5.Location = new System.Drawing.Point(6, 20);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(212, 73);
            this.textBox5.TabIndex = 18;
            this.textBox5.Text = "Bạn không nên xóa các thông điệp trong các Queue sau trừ trường hợp biết rõ. Đối " +
                "với BadQueue bạn nên thử sử dụng chức năng \"Xem BadQueue\" trước khi xóa các thôn" +
                "g điệp.";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(6, 99);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 40);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkInternalQueue
            // 
            this.chkInternalQueue.AutoSize = true;
            this.chkInternalQueue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkInternalQueue.Location = new System.Drawing.Point(110, 145);
            this.chkInternalQueue.Name = "chkInternalQueue";
            this.chkInternalQueue.Size = new System.Drawing.Size(96, 17);
            this.chkInternalQueue.TabIndex = 17;
            this.chkInternalQueue.Text = "InternalQueue";
            this.chkInternalQueue.UseVisualStyleBackColor = true;
            // 
            // chkInboxQueue
            // 
            this.chkInboxQueue.AutoSize = true;
            this.chkInboxQueue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkInboxQueue.Location = new System.Drawing.Point(111, 99);
            this.chkInboxQueue.Name = "chkInboxQueue";
            this.chkInboxQueue.Size = new System.Drawing.Size(86, 17);
            this.chkInboxQueue.TabIndex = 14;
            this.chkInboxQueue.Text = "InboxQueue";
            this.chkInboxQueue.UseVisualStyleBackColor = true;
            // 
            // chkBadQueue
            // 
            this.chkBadQueue.AutoSize = true;
            this.chkBadQueue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkBadQueue.Location = new System.Drawing.Point(110, 167);
            this.chkBadQueue.Name = "chkBadQueue";
            this.chkBadQueue.Size = new System.Drawing.Size(76, 17);
            this.chkBadQueue.TabIndex = 16;
            this.chkBadQueue.Text = "BadQueue";
            this.chkBadQueue.UseVisualStyleBackColor = true;
            // 
            // chkOutboxQueue
            // 
            this.chkOutboxQueue.AutoSize = true;
            this.chkOutboxQueue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkOutboxQueue.Location = new System.Drawing.Point(110, 122);
            this.chkOutboxQueue.Name = "chkOutboxQueue";
            this.chkOutboxQueue.Size = new System.Drawing.Size(94, 17);
            this.chkOutboxQueue.TabIndex = 15;
            this.chkOutboxQueue.Text = "OutboxQueue";
            this.chkOutboxQueue.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(243, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 220);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chú thích";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBox4.Location = new System.Drawing.Point(6, 163);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(250, 39);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "BadQueue: Là nơi lưu trữ những thông điệp do HOSE gửi  nhưng chương trình không l" +
                "ưu được vào Database vì một lí do nào đấy";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBox3.Location = new System.Drawing.Point(6, 98);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(250, 59);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "InternalQueue: Là nơi lưu trữ tạm thời những thông điệp đang chờ được gửi vào Out" +
                "boxQueue (Nếu thị trường chưa mở cửa thông điệp sẽ được lưu tạm vào InternalQueu" +
                "e)";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBox2.Location = new System.Drawing.Point(6, 58);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(250, 39);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "OutboxQueue: Là nơi lưu trữ những thông điệp sẽ được gửi cho HOSE";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 39);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "InboxQueue: Là nơi lưu trữ những thông điệp do HOSE gửi";
            // 
            // ManageQueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(517, 245);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnViewBadQueue);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageQueueForm";
            this.Text = "Quản lý Queue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageQueueForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewBadQueue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkInternalQueue;
        private System.Windows.Forms.CheckBox chkInboxQueue;
        private System.Windows.Forms.CheckBox chkBadQueue;
        private System.Windows.Forms.CheckBox chkOutboxQueue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox5;
    }
}