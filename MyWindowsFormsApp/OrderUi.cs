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

    public partial class OrderUi : Form
    {
        OrderManager _orderManager = new OrderManager();
        public OrderUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Mandatory
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Qunatity can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(totalPriceTextBox.Text))
            {
                MessageBox.Show("Total Price can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(itemIdTextBox.Text))
            {
                MessageBox.Show("Item ID can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(customerIdTextBox.Text))
            {
                MessageBox.Show("Customer ID can not be Empty!!");
                return;
            }

            //Unique
            //if (_itemManager.IsNameExist(idTextBox.Text))
            //{
            //    MessageBox.Show(nameTextBox.Text + " Already Exist!!");
            //    return;
            //}

            //Add/Insert
            if (_orderManager.Add(Convert.ToInt32(quantityTextBox.Text), Convert.ToDouble(totalPriceTextBox.Text), Convert.ToInt32(itemIdTextBox.Text), Convert.ToInt32(customerIdTextBox.Text)))
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
            DataTable dataTable = _orderManager.Display();
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
            if (_orderManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            DataTable dataTable = _orderManager.Display();
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
            //Mandatory
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Qunatity can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(totalPriceTextBox.Text))
            {
                MessageBox.Show("Total Price can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(itemIdTextBox.Text))
            {
                MessageBox.Show("Item ID can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(customerIdTextBox.Text))
            {
                MessageBox.Show("Customer ID can not be Empty!!");
                return;
            }


            if (_orderManager.Update(Convert.ToInt32(quantityTextBox.Text), Convert.ToDouble(totalPriceTextBox.Text), Convert.ToInt32(itemIdTextBox.Text), Convert.ToInt32(customerIdTextBox.Text), Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
                DataTable dataTable = _orderManager.Display();
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
            DataTable dataTable = _orderManager.Search(Convert.ToInt32(customerIdTextBox.Text));
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






