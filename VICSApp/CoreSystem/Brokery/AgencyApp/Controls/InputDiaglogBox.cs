using System;
using System.Windows.Forms;
using Brokery.AgencyWebService;
using Brokery.Framework;

namespace Brokery.Controls
{
   /// <summary>
   /// Hien thi imputbox mot cach don gian nhat
   /// http://www.oronno.co.cc/C-Sharp-Tips-and-Tutorials.php
   /// </summary>
   public class InputDiaglogBox : Form
   {
      private Result result;
      public Result ResultMessage
      {
         get
         {
            return result;
         }
         set
         {
            result = value;
            textBox1.Text = result.InputMessage;
         }
      }

      public bool useTextMask
      {
         get { return !string.IsNullOrEmpty(textBox1.PasswordChar.ToString()); }
         set { textBox1.PasswordChar = value ? '*' : char.MinValue; }
      }

      public InputDiaglogBox(string headerText)
      {
         InitializeComponent();
         label1.Text = headerText;
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         ResultMessage.IsOK = true;
         ResultMessage.InputMessage = textBox1.Text;
         this.Close();
      }

      // The textBox1_KeyPress method uses the KeyChar property to check 
      // whether the ENTER key is pressed. 
      private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)Keys.Return)
         {
            okButton_Click(sender, e);
         }
      }

      private PictureBox pictureBox1;
      private Button button1;

      /// 
      /// Required designer variable.
      /// 
      private System.ComponentModel.IContainer components = null;

      /// 
      /// Clean up any resources being used.
      /// 
      /// true if managed resources should be disposed; otherwise, false.
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         ResultMessage.IsOK = false;
         ResultMessage.InputMessage = string.Empty;
         this.Close();
      }

      #region Windows Form Designer generated code

      /// 
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// 
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDiaglogBox));
         this.label1 = new System.Windows.Forms.Label();
         this.okButton = new System.Windows.Forms.Button();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.button1 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(82, 12);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(59, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Enter Text:";
         // 
         // okButton
         // 
         this.okButton.Image = global::Brokery.Properties.Resources.accept;
         this.okButton.Location = new System.Drawing.Point(99, 78);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(85, 28);
         this.okButton.TabIndex = 2;
         this.okButton.Text = "Ok";
         this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.okButton_Click);
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(85, 37);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(218, 20);
         this.textBox1.TabIndex = 1;
         this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
         this.pictureBox1.Location = new System.Drawing.Point(12, 12);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(67, 69);
         this.pictureBox1.TabIndex = 3;
         this.pictureBox1.TabStop = false;
         // 
         // button1
         // 
         this.button1.Image = global::Brokery.Properties.Resources.cancel;
         this.button1.Location = new System.Drawing.Point(201, 78);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(85, 28);
         this.button1.TabIndex = 4;
         this.button1.Text = "Thoát";
         this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // InputDiaglogBox
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(315, 118);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.okButton);
         this.Controls.Add(this.label1);
         this.ForeColor = System.Drawing.SystemColors.WindowFrame;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InputDiaglogBox";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Ghi dữ liệu";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button okButton;
      private System.Windows.Forms.TextBox textBox1;

      /// 
      /// Shows a question-message dialog requesting input from the user.
      /// 
      /// The text display in the message box
      /// Return String that user enter. If no such input given, string with zero length will return
      public static Result Show(String text)
      {
         return Show(text, string.Empty, string.Empty, false);
      }

      /// 
      /// Shows a question-message dialog requesting input from the user.
      /// 
      /// The text display in the message box
      /// the value used to initialize the input text field
      /// Return String that user enter. If no such input given, string with zero length will return
      public static Result Show(String text, String inputText)
      {
         return Show(text, inputText, string.Empty, false);
      }

      /// 
      /// Shows a question-message dialog requesting input from the user.
      /// 
      /// The text display in the message box
      /// the value used to initialize the input text field
      /// The text to display in the title bar of the message box.
      /// Return String that user enter. If no such input given, string with zero length will return
      public static Result Show(string text, string inputText, string caption)
      {
         return Show(text, inputText, caption, false);
      }

      public static Result Show(string text, string inputText, string caption, bool useTextMask)
      {
         InputDiaglogBox inputBox = new InputDiaglogBox(text);
         if (!string.IsNullOrEmpty(caption))
            inputBox.Text = caption;
         Result result = new Result();
         result.InputMessage = inputText;
         inputBox.ResultMessage = result;
         inputBox.useTextMask = useTextMask;
         inputBox.ShowDialog();
         return inputBox.ResultMessage;
      }

      public static Result ShowModifyPrice(Order order)
      {
         Result result = new Result();
         result.InputMessage = order.PublishedPrice.ToString();

         string content = string.Format("TK: {0} - {1} {2} {3} - Giá: {4}",
                  order.CustomerId,
                  order.OrderSideViet,
                  order.PublishedVolume,
                  order.StockCode,
                  order.PublishedPrice);

         InputDiaglogBox inputBox = new InputDiaglogBox(content);
         GUIUtil.FormatTextBoxForCurrency(inputBox.textBox1);
         inputBox.Text = "Sửa giá"; 
         inputBox.ResultMessage = result;
         inputBox.ShowDialog();
         return inputBox.ResultMessage;
      }

      public sealed class Result
      {
         public bool IsOK;
         public string InputMessage;
      }
   }
}
