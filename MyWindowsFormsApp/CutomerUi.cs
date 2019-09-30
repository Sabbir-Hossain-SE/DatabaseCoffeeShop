using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.Manager;

namespace MyWindowsFormsApp
{
    public partial class CutomerUi : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CutomerUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Mandatory
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Phone NUmber can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Phone NUmber can not be Empty!!");
                return;
            }

            //Unique
            if (_customerManager.IsNameExist(nameTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exist!!");
                return;
            }

            //Add/Insert
            if (_customerManager.Add(nameTextBox.Text, addressTextBox.Text, phoneTextBox.Text))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = _customerManager.Display();
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_customerManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            DataTable dataTable = _customerManager.Display();
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No Data Found");
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Set Price as Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Phone NUmber can not be Empty!!");
                return;
            }

            if (_customerManager.Update(nameTextBox.Text, addressTextBox.Text, phoneTextBox.Text, Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
                DataTable dataTable = _customerManager.Display();
                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = _customerManager.Search(nameTextBox.Text);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
        }
    }
}
