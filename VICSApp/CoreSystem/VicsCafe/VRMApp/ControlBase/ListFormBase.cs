using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRMApp.Framework;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace VRMApp.ControlBase
{
   public class ListFormBase : StdForm
   {
      protected ToolStrip mainToolStrip;
      private ToolStripButton newButton;
      private ToolStripButton modifyButton;
      private ToolStripSeparator toolStripSeparator1;
      private ToolStripButton deleteButton;
      private ToolStripSeparator toolStripSeparator2;
      private ToolStripButton exportButton;
      private ToolStripButton printButton;
      protected ListFormBase()
      {
         this.InitializeComponent();
      }

      private void InitializeComponent()
      {
         this.mainToolStrip = new System.Windows.Forms.ToolStrip();
         this.newButton = new System.Windows.Forms.ToolStripButton();
         this.modifyButton = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.deleteButton = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.exportButton = new System.Windows.Forms.ToolStripButton();
         this.printButton = new System.Windows.Forms.ToolStripButton();
         this.mainPanel.SuspendLayout();
         this.mainToolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainPanel
         // 
         this.mainPanel.Controls.Add(this.mainToolStrip);
         this.mainPanel.Size = new System.Drawing.Size(475, 325);
         // 
         // mainToolStrip
         // 
         this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.modifyButton,
            this.toolStripSeparator1,
            this.deleteButton,
            this.toolStripSeparator2,
            this.exportButton,
            this.printButton});
         this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
         this.mainToolStrip.Name = "mainToolStrip";
         this.mainToolStrip.Size = new System.Drawing.Size(475, 25);
         this.mainToolStrip.TabIndex = 1;
         this.mainToolStrip.Text = "toolStrip1";
         // 
         // newButton
         // 
         this.newButton.Image = global::VRMApp.Properties.Resources.add;
         this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.newButton.Name = "newButton";
         this.newButton.Size = new System.Drawing.Size(53, 22);
         this.newButton.Text = "&Thêm";
         // 
         // modifyButton
         // 
         this.modifyButton.Image = global::VRMApp.Properties.Resources.application_edit;
         this.modifyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.modifyButton.Name = "modifyButton";
         this.modifyButton.Size = new System.Drawing.Size(46, 22);
         this.modifyButton.Text = "&Sửa";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // deleteButton
         // 
         this.deleteButton.Image = global::VRMApp.Properties.Resources.delete;
         this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.deleteButton.Name = "deleteButton";
         this.deleteButton.Size = new System.Drawing.Size(45, 22);
         this.deleteButton.Text = "&Xóa";
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // exportButton
         // 
         this.exportButton.Image = global::VRMApp.Properties.Resources.page_excel;
         this.exportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.exportButton.Name = "exportButton";
         this.exportButton.Size = new System.Drawing.Size(59, 22);
         this.exportButton.Text = "&Export";
         // 
         // printButton
         // 
         this.printButton.Image = global::VRMApp.Properties.Resources.printer;
         this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.printButton.Name = "printButton";
         this.printButton.Size = new System.Drawing.Size(37, 22);
         this.printButton.Text = "&In";
         // 
         // ListFormBase
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.ClientSize = new System.Drawing.Size(475, 347);
         this.KeyPreview = true;
         this.MinimizeBox = false;
         this.Name = "ListFormBase";
         this.mainPanel.ResumeLayout(false);
         this.mainPanel.PerformLayout();
         this.mainToolStrip.ResumeLayout(false);
         this.mainToolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      protected ToolStripButton DeleteButton
      {
         get
         {
            return this.deleteButton;
         }
      }

      protected ToolStripButton PrintButton
      {
         get
         {
            return this.printButton;
         }
      }


      protected ToolStripButton ExportButton
      {
         get
         {
            return this.exportButton;
         }
      }

      public bool HideDeleteButton
      {
         get
         {
            return !this.DeleteButton.Visible;
         }
         set
         {
            toolStripSeparator1.Visible = this.DeleteButton.Visible = !value;
         }
      }

      public bool HidePrintButton
      {
         get
         {
            return !this.PrintButton.Visible;
         }
         set
         {
            this.PrintButton.Visible = !value;
         }
      }

      public bool HideExportButton
      {
         get
         {
            return !this.ExportButton.Visible;
         }
         set
         {
            this.ExportButton.Visible = !value;
         }
      }

      protected ToolStrip ListFormToolStrip
      {
         get
         {
            return this.mainToolStrip;
         }
      }

      protected ToolStripButton ModifyButton
      {
         get
         {
            return this.modifyButton;
         }
      }

      protected ToolStripButton NewButton
      {
         get
         {
            return this.newButton;
         }
      }

      public event EventHandler NewButtonClick;
      public event EventHandler EditButtonClick;
      public event EventHandler DeleteButtonClick;
      public event EventHandler ExportButtonClick;
      public event EventHandler PrintButtonClick;

      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad(e);

         if (NewButtonClick != null)
            newButton.Click += NewButtonClick;
         if (EditButtonClick != null)
            modifyButton.Click += EditButtonClick;
         if (DeleteButtonClick != null && !HideDeleteButton)
            DeleteButton.Click += DeleteButtonClick;
         if (ExportButtonClick != null && !HideExportButton)
            ExportButton.Click += ExportButtonClick;
         if (PrintButtonClick != null && !HidePrintButton)
            PrintButton.Click += PrintButtonClick;
      }
   }
}
