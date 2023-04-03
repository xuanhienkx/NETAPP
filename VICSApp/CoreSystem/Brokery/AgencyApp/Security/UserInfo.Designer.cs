using System.Windows.Forms;

namespace Brokery.Security
{
   partial class UserInfo
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
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.lblAgency = new System.Windows.Forms.Label();
         this.generateUserTransCode = new System.Windows.Forms.Button();
         this.lblResetPassword = new System.Windows.Forms.LinkLabel();
         this.statusComboBox = new System.Windows.Forms.ComboBox();
         this.label6 = new System.Windows.Forms.Label();
         this.departmentCombo = new System.Windows.Forms.ComboBox();
         this.label14 = new System.Windows.Forms.Label();
         this.userTransCodeTextBox = new System.Windows.Forms.TextBox();
         this.groupCombo = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.fullNameTextBox = new System.Windows.Forms.TextBox();
         this.passwordTextBox = new System.Windows.Forms.TextBox();
         this.nameTextBox = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.closeButton = new System.Windows.Forms.Button();
         this.oKButton = new System.Windows.Forms.Button();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.lblAgency);
         this.groupBox2.Controls.Add(this.generateUserTransCode);
         this.groupBox2.Controls.Add(this.lblResetPassword);
         this.groupBox2.Controls.Add(this.statusComboBox);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Controls.Add(this.departmentCombo);
         this.groupBox2.Controls.Add(this.label14);
         this.groupBox2.Controls.Add(this.userTransCodeTextBox);
         this.groupBox2.Controls.Add(this.groupCombo);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.fullNameTextBox);
         this.groupBox2.Controls.Add(this.passwordTextBox);
         this.groupBox2.Controls.Add(this.nameTextBox);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.label3);
         this.groupBox2.Controls.Add(this.label2);
         this.groupBox2.Controls.Add(this.label1);
         this.groupBox2.Location = new System.Drawing.Point(12, 5);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(563, 177);
         this.groupBox2.TabIndex = 0;
         this.groupBox2.TabStop = false;
         // 
         // lblAgency
         // 
         this.lblAgency.BackColor = System.Drawing.Color.Black;
         this.lblAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblAgency.ForeColor = System.Drawing.Color.Lime;
         this.lblAgency.Location = new System.Drawing.Point(23, 16);
         this.lblAgency.Name = "lblAgency";
         this.lblAgency.Size = new System.Drawing.Size(516, 28);
         this.lblAgency.TabIndex = 20;
         this.lblAgency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // generateUserTransCode
         // 
         this.generateUserTransCode.Image = global::Brokery.Properties.Resources.slides_stack;
         this.generateUserTransCode.Location = new System.Drawing.Point(165, 142);
         this.generateUserTransCode.Name = "generateUserTransCode";
         this.generateUserTransCode.Size = new System.Drawing.Size(99, 21);
         this.generateUserTransCode.TabIndex = 5;
         this.generateUserTransCode.Text = "Sinh tự động";
         this.generateUserTransCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.generateUserTransCode.UseVisualStyleBackColor = true;
         this.generateUserTransCode.Click += new System.EventHandler(this.generateUserTransCode_Click);
         // 
         // lblResetPassword
         // 
         this.lblResetPassword.AutoSize = true;
         this.lblResetPassword.Location = new System.Drawing.Point(443, 146);
         this.lblResetPassword.Name = "lblResetPassword";
         this.lblResetPassword.Size = new System.Drawing.Size(96, 13);
         this.lblResetPassword.TabIndex = 9;
         this.lblResetPassword.TabStop = true;
         this.lblResetPassword.Text = "Thay đổi mật khẩu";
         this.lblResetPassword.Visible = false;
         this.lblResetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblResetPassword_LinkClicked);
         // 
         // statusComboBox
         // 
         this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.statusComboBox.FormattingEnabled = true;
         this.statusComboBox.Location = new System.Drawing.Point(351, 54);
         this.statusComboBox.Name = "statusComboBox";
         this.statusComboBox.Size = new System.Drawing.Size(89, 21);
         this.statusComboBox.TabIndex = 6;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(287, 57);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(58, 13);
         this.label6.TabIndex = 12;
         this.label6.Text = "Trạng thái:";
         // 
         // departmentCombo
         // 
         this.departmentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.departmentCombo.FormattingEnabled = true;
         this.departmentCombo.Location = new System.Drawing.Point(351, 84);
         this.departmentCombo.Name = "departmentCombo";
         this.departmentCombo.Size = new System.Drawing.Size(188, 21);
         this.departmentCombo.TabIndex = 7;
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(23, 147);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(71, 13);
         this.label14.TabIndex = 16;
         this.label14.Text = "Mã giao dịch:";
         // 
         // userTransCodeTextBox
         // 
         this.userTransCodeTextBox.Location = new System.Drawing.Point(103, 143);
         this.userTransCodeTextBox.MaxLength = 6;
         this.userTransCodeTextBox.Name = "userTransCodeTextBox";
         this.userTransCodeTextBox.Size = new System.Drawing.Size(56, 20);
         this.userTransCodeTextBox.TabIndex = 4;
         this.userTransCodeTextBox.Text = "A1B2C3";
         // 
         // groupCombo
         // 
         this.groupCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.groupCombo.FormattingEnabled = true;
         this.groupCombo.Location = new System.Drawing.Point(351, 112);
         this.groupCombo.Name = "groupCombo";
         this.groupCombo.Size = new System.Drawing.Size(188, 21);
         this.groupCombo.TabIndex = 8;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(304, 88);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(41, 13);
         this.label5.TabIndex = 2;
         this.label5.Text = "Phòng:";
         // 
         // fullNameTextBox
         // 
         this.fullNameTextBox.Location = new System.Drawing.Point(103, 110);
         this.fullNameTextBox.Name = "fullNameTextBox";
         this.fullNameTextBox.Size = new System.Drawing.Size(161, 20);
         this.fullNameTextBox.TabIndex = 3;
         // 
         // passwordTextBox
         // 
         this.passwordTextBox.Location = new System.Drawing.Point(103, 82);
         this.passwordTextBox.Name = "passwordTextBox";
         this.passwordTextBox.PasswordChar = '*';
         this.passwordTextBox.Size = new System.Drawing.Size(126, 20);
         this.passwordTextBox.TabIndex = 2;
         // 
         // nameTextBox
         // 
         this.nameTextBox.Location = new System.Drawing.Point(103, 54);
         this.nameTextBox.MaxLength = 20;
         this.nameTextBox.Name = "nameTextBox";
         this.nameTextBox.Size = new System.Drawing.Size(101, 20);
         this.nameTextBox.TabIndex = 1;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(307, 115);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(38, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Nhóm:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(37, 112);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(57, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "Họ và tên:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(39, 83);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(55, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Mật khẩu:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(18, 57);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(76, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tên truy nhập:";
         // 
         // closeButton
         // 
         this.closeButton.Image = global::Brokery.Properties.Resources.delete;
         this.closeButton.Location = new System.Drawing.Point(492, 195);
         this.closeButton.Name = "closeButton";
         this.closeButton.Size = new System.Drawing.Size(83, 32);
         this.closeButton.TabIndex = 11;
         this.closeButton.Text = "Hủy bỏ";
         this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.closeButton.UseVisualStyleBackColor = true;
         this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
         // 
         // oKButton
         // 
         this.oKButton.Image = global::Brokery.Properties.Resources.add;
         this.oKButton.Location = new System.Drawing.Point(390, 195);
         this.oKButton.Name = "oKButton";
         this.oKButton.Size = new System.Drawing.Size(83, 32);
         this.oKButton.TabIndex = 10;
         this.oKButton.Text = "Đồng ý";
         this.oKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.oKButton.UseVisualStyleBackColor = true;
         this.oKButton.Click += new System.EventHandler(this.oKButton_Click);
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // UserInfo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(588, 239);
         this.Controls.Add(this.closeButton);
         this.Controls.Add(this.oKButton);
         this.Controls.Add(this.groupBox2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UserInfo";
         this.Text = "Cập nhật thông tin người dùng";
         this.Load += new System.EventHandler(this.UserInfo_Load);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private Button closeButton;
      private ComboBox departmentCombo;
      private TextBox fullNameTextBox;
      private Button generateUserTransCode;
      private GroupBox groupBox2;
      private ComboBox groupCombo;
      private Label label1;
      private Label label14;
      private Label label2;
      private Label label3;
      private Label label4;
      private Label label5;
      private Label label6;
      private LinkLabel lblResetPassword;
      private TextBox nameTextBox;
      private Button oKButton;
      private TextBox passwordTextBox;
      private ComboBox statusComboBox;
      private TextBox userTransCodeTextBox;
      private Label lblAgency;
      private ErrorProvider errorProvider;
   }
}