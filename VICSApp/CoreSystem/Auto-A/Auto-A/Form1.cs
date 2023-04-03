using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Auto_A
{
   public partial class Form1 : Form
   {
      Thread oT;
      public Form1()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         if (oT != null && oT.IsAlive)
         {
            oT.Abort();
            oT = null;
            if (AccessFactory.CurrentInstance() != null)
            {
               AccessFactory.CurrentInstance().Commit();
               AccessFactory.CurrentInstance().Dispose();
            }

            button1.Text = "Bắt đầu";
            AddMessage("Thread stoped by user.");
            button2.Enabled = true;
         }
         else
         {
            button2.Enabled = false;
            button1.Text = "Dừng lại";
            AddMessage("Thread started!");
            try
            {
               Worker w = new Worker(new UpdateMessage(AddMessage), new GetArguments(GetArgs));
               oT = new Thread(new ThreadStart(w.Run));
               oT.Start();
            }
            catch (Exception ex)
            {
               AddMessage("Thread stoped due to error");
               AddMessage("- [Error Message]: " + ex.Message);
               button1.Text = "Bắt đầu";
               AccessFactory.CurrentInstance().Abort();
               button2.Enabled = true;
            }
         }
      }

      private void AddMessage(string msg)
      {
         if (listBox1.InvokeRequired)
            listBox1.Invoke(new UpdateMessage(AddMessage), new object[] { msg });
         else
            listBox1.Items.Insert(0, string.Format("[{0}] {1}", DateTime.Now.ToLongTimeString(), msg));
      }

      private Arg GetArgs()
      {
         if (InvokeRequired)
            return Invoke(new GetArguments(GetArgs)) as Arg;
         else
         {
            return new Arg(
               decimal.Parse(textBox1.Text),
               int.Parse(textBox2.Text));
         }
      }

      private void checkBox3_CheckedChanged(object sender, EventArgs e)
      {
         if (!checkBox3.Checked)
            textBox1.Text = "0";
         textBox1.Enabled = checkBox3.Checked;
      }

      private void button2_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         textBox1.KeyPress += new KeyPressEventHandler(NumberTextBox_KeyPress);
         textBox1.TextChanged += new EventHandler(NumberTextBox_TextChanged);
      }

      internal static void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         e.Handled = !(char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar));
      }

      internal static void NumberTextBox_TextChanged(object sender, EventArgs e)
      {
         TextBox me = sender as TextBox;
         string str = me.Text;
         int iStart = me.SelectionStart;

         if (string.IsNullOrEmpty(str))
            return;
         else if (str.StartsWith("."))
         {
            str = str.Substring(1);
            if (iStart > 0)
               me.SelectionStart = --iStart;
         }
         str = me.Text;
         int idx = str.IndexOf(".");
         me.Text = string.Format("{0:#,##0}", decimal.Parse(str));

         if (str.Length < me.Text.Length && idx <= iStart)
            me.SelectionStart = ++iStart;
         else if (str.Length > me.Text.Length && me.SelectionStart > 0)
            me.SelectionStart = --iStart;
         else
            me.SelectionStart = iStart;
      }
   }
}
