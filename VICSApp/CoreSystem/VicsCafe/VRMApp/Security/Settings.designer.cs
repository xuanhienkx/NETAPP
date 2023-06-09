namespace VRMApp.Security
{
    partial class Settings
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
         this.propertyGrid = new System.Windows.Forms.PropertyGrid();
         this.btnOk = new System.Windows.Forms.Button();
         this.btnExit = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // propertyGrid
         // 
         this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.propertyGrid.Location = new System.Drawing.Point(12, 12);
         this.propertyGrid.Name = "propertyGrid";
         this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
         this.propertyGrid.Size = new System.Drawing.Size(732, 382);
         this.propertyGrid.TabIndex = 0;
         this.propertyGrid.ToolbarVisible = false;
         // 
         // btnOk
         // 
         this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOk.Image = global::VRMApp.Properties.Resources.disk;
         this.btnOk.Location = new System.Drawing.Point(457, 409);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(96, 30);
         this.btnOk.TabIndex = 1;
         this.btnOk.Text = "&Lưu";
         this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // btnExit
         // 
         this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnExit.Image = global::VRMApp.Properties.Resources.cancel;
         this.btnExit.Location = new System.Drawing.Point(580, 409);
         this.btnExit.Name = "btnExit";
         this.btnExit.Size = new System.Drawing.Size(96, 30);
         this.btnExit.TabIndex = 2;
         this.btnExit.Text = "&Thoát";
         this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.btnExit.UseVisualStyleBackColor = true;
         this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
         // 
         // Settings
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(756, 451);
         this.Controls.Add(this.btnExit);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.propertyGrid);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Settings";
         this.Text = "Thiết lập các tham số trong chương trình";
         this.Load += new System.EventHandler(this.ParamForm_Load);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnExit;
    }
}