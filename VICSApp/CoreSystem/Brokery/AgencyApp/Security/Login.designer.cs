namespace Brokery.Security
{
   partial class Login
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.btnLogin = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.txtPassword = new System.Windows.Forms.TextBox();
         this.txtUserName = new System.Windows.Forms.TextBox();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(24, 60);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(84, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tên đăng nhập:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(53, 88);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(55, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Mật khẩu:";
         // 
         // btnLogin
         // 
         this.btnLogin.Location = new System.Drawing.Point(73, 120);
         this.btnLogin.Name = "btnLogin";
         this.btnLogin.Size = new System.Drawing.Size(82, 25);
         this.btnLogin.TabIndex = 2;
         this.btnLogin.Text = "&Đăng nhập";
         this.btnLogin.UseVisualStyleBackColor = true;
         this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(170, 120);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(82, 25);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "&Thoát";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // pictureBox1
         // 
         this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
         this.pictureBox1.Location = new System.Drawing.Point(114, 6);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(116, 45);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox1.TabIndex = 7;
         this.pictureBox1.TabStop = false;
         // 
         // txtPassword
         // 
         this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtPassword.Location = new System.Drawing.Point(114, 85);
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.PasswordChar = '*';
         this.txtPassword.Size = new System.Drawing.Size(151, 20);
         this.txtPassword.TabIndex = 1;
         this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
         this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
         // 
         // txtUserName
         // 
         this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtUserName.Location = new System.Drawing.Point(114, 57);
         this.txtUserName.Name = "txtUserName";
         this.txtUserName.Size = new System.Drawing.Size(151, 20);
         this.txtUserName.TabIndex = 0;
         this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
         this.txtUserName.Validated += new System.EventHandler(this.txtUserName_Validated);
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // Login
         // 
         this.AcceptButton = this.btnLogin;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(324, 160);
         this.Controls.Add(this.txtUserName);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnLogin);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Login";
         this.Text = "Đăng nhập";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button btnLogin;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.TextBox txtPassword;
      private System.Windows.Forms.TextBox txtUserName;
      private System.Windows.Forms.ErrorProvider errorProvider1;
   }
}