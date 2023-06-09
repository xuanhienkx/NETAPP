//EnhancedComboBox Control
//Written by Chau Tuan
//Created Date: 19-11-2006
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class EnhancedComboBox : UserControl
    {        
        public delegate void EventHandle(Object sender, KeyEventArgs e);
        public delegate void EventHandleLeave(Object sender, EventArgs e);
        public delegate void EventHandlePress(Object sender, KeyPressEventArgs e);
        protected bool mIsAutoCompleteProcessed;
        protected bool mIsAutoComplete;
        public event EventHandle TextBoxKeyDown;
        public event EventHandleLeave TextBoxLeave;
        public event EventHandlePress TextBoxKeyPress;
        protected bool mHasNone;

        public bool HasNone
        {
            get{return mHasNone;}
            set { mHasNone = value; }
        }
        public bool AutoComplete
        {
            get
            {
                return mIsAutoComplete;
            }
            set
            {
                mIsAutoComplete = value;
                if (mIsAutoComplete == true)
                    theTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                else
                    theTextBox.AutoCompleteSource = AutoCompleteSource.None;
            }
        }
        public void SelectAllText()
        {
            theTextBox.SelectAll();
        }
        public int TextBoxWidth
        {
            get
            {
                return theTextBox.Width;
            }
            set
            {
                int delta = value - theTextBox.Width;
                theComboBox.Left += delta;
                theComboBox.Width += -delta;
                theTextBox.Width = value;
            }
        }

        public override string Text
        {
            get
            {
                return theTextBox.Text;
            }
            set
            {
                theTextBox.Text = value;
            }
        }

        public bool IsTextInValueList()
        {
            foreach (Object obj in theComboBox.Items)
            {
                if (theTextBox.Text == ((DataRowView)obj).Row[theComboBox.ValueMember].ToString())
                    return true;
            }
            return false;
        }

        public bool IsTextInValueList(string inText)
        {
            foreach (Object obj in theComboBox.Items)
            {
                if (inText == ((DataRowView)obj).Row[theComboBox.ValueMember].ToString())
                    return true;
            }
            return false;
        }

        public CharacterCasing CharacterCasing
        {
            get
            {
                return theTextBox.CharacterCasing;
            }
            set
            {
                theTextBox.CharacterCasing = value;
            }
        }
        public string ValueMember
        {
            get
            {
                return theComboBox.ValueMember;
            }
            set
            {
                theComboBox.ValueMember = value;
            }
        }
        public string DisplayMember
        {
            get
            {
                return theComboBox.DisplayMember;
            }
            set
            {
                theComboBox.DisplayMember = value;
            }
        }
        public int SelectedIndex
        {
            get
            {
                return theComboBox.SelectedIndex;
            }
            set
            {
                theComboBox.SelectedIndex = value;
                
            }
        }
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return theComboBox.Items;
            }
        }
        //public void SelectText()
        //{
        //    theTextBox.Select(0, theTextBox.Text.Length);
        //}

        public Object DataSource
        {
            get
            {
                return theComboBox.DataSource;
            }
            set
            {
                //Automatically change the display values of the Combobox
                if (value != null && value.GetType().ToString() == "System.Data.DataTable")
                {
                    DataTable table = (DataTable)value;
                    if (table.Columns.Count < 2)
                        return;

                    
                    //Be cautious with this
                    if ((theComboBox.ValueMember == "") && (theComboBox.DisplayMember == ""))
                    {
                        theComboBox.ValueMember = table.Columns[0].ColumnName;
                        theComboBox.DisplayMember = table.Columns[1].ColumnName;
                    }
                    else if (theComboBox.ValueMember == "")
                    {
                        theComboBox.ValueMember = table.Columns[0].ColumnName;
                    }
                    else if (theComboBox.DisplayMember == "")
                    {
                        theComboBox.DisplayMember = table.Columns[1].ColumnName;
                    }
                    

                    AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                    foreach (DataRow row in table.Rows)
                    {
                        row[theComboBox.DisplayMember] = row[theComboBox.ValueMember].ToString() + " - " + row[theComboBox.DisplayMember].ToString();
                        col.Add(row[theComboBox.ValueMember].ToString());
                    }
                    theTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    theTextBox.AutoCompleteCustomSource = col;

                    if (mIsAutoComplete == true)
                        theTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    else
                        theTextBox.AutoCompleteSource = AutoCompleteSource.None;

                    if (mHasNone == true)
                    {
                        DataRow emptyRow = table.NewRow();
                        emptyRow[theComboBox.ValueMember] = "";
                        emptyRow[theComboBox.DisplayMember] = "(Tất cả)";
                        table.Rows.InsertAt(emptyRow, 0);
                    }
                }
                //------- List<>                                
                
                theComboBox.DataSource = value;
               
            }
        }
        /*public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return theTextBox.AutoCompleteCustomSource;
            }
            set
            {
                theTextBox.AutoCompleteCustomSource = value;
            }
        }
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return theTextBox.AutoCompleteMode;
            }
            set
            {
                theTextBox.AutoCompleteMode = value;
            }
        }

        public AutoCompleteSource AutoCompleteSource 
        {
            get
            {
                return theTextBox.AutoCompleteSource;
            }
            set
            {
                theTextBox.AutoCompleteSource = value;
            }
        }*/
        public EnhancedComboBox()
        {
            mIsAutoCompleteProcessed = false;
            mIsAutoComplete = true;
            mHasNone = false;
            InitializeComponent();
            
        }

        public event EventHandler TextBoxTextChanged;
        private void theTextBox_TextChanged(object sender, EventArgs e)
        {
            //To not raise the event theComboBox_SelectedIndexChanged when AutoComplete is processed
            mIsAutoCompleteProcessed = true;
            int index = theComboBox.FindString(theTextBox.Text);
            if (index >= 0)
                theComboBox.SelectedIndex = index;
            
            mIsAutoCompleteProcessed = false;
            if (TextBoxTextChanged != null)
                TextBoxTextChanged(sender, e);
        }

        public event EventHandler SelectedIndexChanged;


        private void theComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Do not change the TextBox when AutoComplete is processed
            if (mIsAutoCompleteProcessed == false)
            {
                DataRowView selectedRow;
                selectedRow = (DataRowView)(theComboBox.SelectedItem);
                theTextBox.Text = selectedRow[theComboBox.ValueMember].ToString();
            }
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(sender, e);
        }

        private void theTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxKeyDown != null)
                TextBoxKeyDown(sender, e);
        }

        private void theTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBoxKeyPress != null)
                TextBoxKeyPress(sender, e);
        }

        private void theTextBox_Leave(object sender, EventArgs e)
        {
            if (TextBoxLeave != null)
                TextBoxLeave(sender, e);
            
        }

        
    }
}