namespace VRMApp.ControlBase
{
   partial class StdForm
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
         this.statusStrip = new System.Windows.Forms.StatusStrip();
         this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.mainPanel = new System.Windows.Forms.Panel();
         this.statusStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // statusStrip
         // 
         this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
         this.statusStrip.Location = new System.Drawing.Point(0, 303);
         this.statusStrip.Name = "statusStrip";
         this.statusStrip.Size = new System.Drawing.Size(562, 22);
         this.statusStrip.TabIndex = 0;
         // 
         // statusLabel
         // 
         this.statusLabel.Name = "statusLabel";
         this.statusLabel.Size = new System.Drawing.Size(0, 17);
         // 
         // mainPanel
         // 
         this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.mainPanel.Location = new System.Drawing.Point(0, 0);
         this.mainPanel.Name = "mainPanel";
         this.mainPanel.Size = new System.Drawing.Size(562, 303);
         this.mainPanel.TabIndex = 1;
         // 
         // StdForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(562, 325);
         this.Controls.Add(this.mainPanel);
         this.Controls.Add(this.statusStrip);
         this.Name = "StdForm";
         this.Text = "StdForm";
         this.statusStrip.ResumeLayout(false);
         this.statusStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStripStatusLabel statusLabel;
      protected System.Windows.Forms.StatusStrip statusStrip;
      protected System.Windows.Forms.Panel mainPanel;
   }
}