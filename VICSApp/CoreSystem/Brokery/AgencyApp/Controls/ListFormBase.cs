using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Controls
{
   public class ListFormBase : FormBase
   {
      private ToolStripButton deleteButton;
      private ToolStripButton exportButton;
      protected ToolStripStatusLabel listFormStatusLabel;
      protected StatusStrip mainStatusStrip;
      protected ToolStrip mainToolStrip;
      private ToolStripButton modifyButton;
      private ToolStripSeparator toolStripSeparator1;
      private ToolStripSeparator toolStripSeparator2;
      private ToolStripButton printButton;
      protected Panel panel1;
      private System.ComponentModel.IContainer components;
      private ToolStripButton newButton;
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
         this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
         this.listFormStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.panel1 = new System.Windows.Forms.Panel();
         this.mainToolStrip.SuspendLayout();
         this.mainStatusStrip.SuspendLayout();
         this.SuspendLayout();
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
         this.mainToolStrip.TabIndex = 0;
         this.mainToolStrip.Text = "toolStrip1";
         // 
         // newButton
         // 
         this.newButton.Image = global::Brokery.Properties.Resources.add;
         this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.newButton.Name = "newButton";
         this.newButton.Size = new System.Drawing.Size(53, 22);
         this.newButton.Text = "&Thêm";
         // 
         // modifyButton
         // 
         this.modifyButton.Image = global::Brokery.Properties.Resources.application_edit;
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
         this.deleteButton.Image = global::Brokery.Properties.Resources.delete;
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
         this.exportButton.Image = global::Brokery.Properties.Resources.page_excel;
         this.exportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.exportButton.Name = "exportButton";
         this.exportButton.Size = new System.Drawing.Size(59, 22);
         this.exportButton.Text = "&Export";
         // 
         // printButton
         // 
         this.printButton.Image = global::Brokery.Properties.Resources.printer;
         this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.printButton.Name = "printButton";
         this.printButton.Size = new System.Drawing.Size(37, 22);
         this.printButton.Text = "&In";
         // 
         // mainStatusStrip
         // 
         this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listFormStatusLabel});
         this.mainStatusStrip.Location = new System.Drawing.Point(0, 325);
         this.mainStatusStrip.Name = "mainStatusStrip";
         this.mainStatusStrip.Size = new System.Drawing.Size(475, 22);
         this.mainStatusStrip.TabIndex = 1;
         this.mainStatusStrip.Text = "statusStrip1";
         // 
         // listFormStatusLabel
         // 
         this.listFormStatusLabel.Name = "listFormStatusLabel";
         this.listFormStatusLabel.Size = new System.Drawing.Size(0, 17);
         // 
         // panel1
         // 
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(0, 25);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(475, 300);
         this.panel1.TabIndex = 2;
         // 
         // ListFormBase
         // 
         this.ClientSize = new System.Drawing.Size(475, 347);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.mainStatusStrip);
         this.Controls.Add(this.mainToolStrip);
         this.KeyPreview = true;
         this.MinimizeBox = false;
         this.Name = "ListFormBase";
         this.mainToolStrip.ResumeLayout(false);
         this.mainToolStrip.PerformLayout();
         this.mainStatusStrip.ResumeLayout(false);
         this.mainStatusStrip.PerformLayout();
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
            this.DeleteButton.Visible = !value;
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

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { throw new NotImplementedException(); }
      }

      protected void UpdateStatus(DataGridView mainGrid)
      {
         if (mainGrid != null)
            this.listFormStatusLabel.Text = string.Format("Tổng cộng có {0} bản ghi.", mainGrid.RowCount.ToString("n0"));
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
