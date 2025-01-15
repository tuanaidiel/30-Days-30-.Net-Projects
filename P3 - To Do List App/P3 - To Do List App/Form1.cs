using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3___To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable toDoList = new DataTable();
        bool isEditing = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {
            //Create columns
            toDoList.Columns.Add("Title");
            toDoList.Columns.Add("Description");

            //Point our datagridview  to our datasource
            toDoListView.DataSource = toDoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextbox.Text = "";
            descriptionTextbox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            //Fill texxt fields with data from table
            titleTextbox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextbox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextbox.Text;
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextbox.Text;
            }
            else
            {
                toDoList.Rows.Add(titleTextbox.Text, descriptionTextbox.Text);
            }

            //Clear fields
            titleTextbox.Text = "";
            descriptionTextbox.Text = "";
            isEditing = false;
        }
    }
}
