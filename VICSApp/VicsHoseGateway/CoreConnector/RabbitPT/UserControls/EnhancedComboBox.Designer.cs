namespace CustomControl
{
    partial class EnhancedComboBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.theComboBox = new System.Windows.Forms.ComboBox();
            this.theTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // theComboBox
            // 
            this.theComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.theComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.theComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.theComboBox.FormattingEnabled = true;
            this.theComboBox.Location = new System.Drawing.Point(102, 0);
            this.theComboBox.Name = "theComboBox";
            this.theComboBox.Size = new System.Drawing.Size(222, 21);
            this.theComboBox.TabIndex = 1;
            this.theComboBox.TabStop = false;
            this.theComboBox.SelectedIndexChanged += new System.EventHandler(this.theComboBox_SelectedIndexChanged);
            // 
            // theTextBox
            // 
            this.theTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.theTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.theTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.theTextBox.Location = new System.Drawing.Point(0, 0);
            this.theTextBox.Name = "theTextBox";
            this.theTextBox.Size = new System.Drawing.Size(100, 20);
            this.theTextBox.TabIndex = 0;
            this.theTextBox.Leave += new System.EventHandler(this.theTextBox_Leave);
            this.theTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.theTextBox_KeyPress);
            this.theTextBox.TextChanged += new System.EventHandler(this.theTextBox_TextChanged);
            this.theTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.theTextBox_KeyDown);
            // 
            // EnhancedComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.theTextBox);
            this.Controls.Add(this.theComboBox);
            this.Name = "EnhancedComboBox";
            this.Size = new System.Drawing.Size(324, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox theComboBox;
        private System.Windows.Forms.TextBox theTextBox;
    }
}
