using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyWindowsFormsApp.Manager;
namespace MyWindowsFormsApp.Repository
{
    class CustomerRepository
    {

        //Method
        public bool Add(string name, string address, string phone)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Customers (Name, Address, Phone) Values ('" + name + "', '" + address + "','" + phone + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }



                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                // MessageBox.Show(exeption.Message);
            }

            return isAdded;
        }
        public bool IsNameExist(string name)
        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customers WHERE Name='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                // MessageBox.Show(exeption.Message);
            }
            return isExist;
        }
        public bool Delete(int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //DELETE FROM Items WHERE ID = 3
                string commandString = @"DELETE FROM Customers WHERE ID = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Delete
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return false;
        }

        public bool Update(string name, string address,string phone, int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE Customers SET Name =  '" + name + "' , Address = '" + address + "',Phone = '" + phone + "' WHERE ID = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                // MessageBox.Show(exeption.Message);
            }
            return false;
        }

        public DataTable Display()
        {
            //try
            //{
            //    //Connection
            string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //   // MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();

            //}
            //catch (Exception exeption)
            //{
            //    ///MessageBox.Show(exeption.Message);
            //}
            return dataTable;
        }
        public DataTable Search(string name)
        {
            // try
            // {
            //Connection
            string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Customers WHERE Name='" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //   //*if (dataTable.Rows.Count > 0)
            //    {
            //        showDataGridView.DataSource = dataTable;
            //    }
            //    else
            //    {
            //        MessageBox.Show("No Data Found");
            //    }

            //    //Close
            sqlConnection.Close();

            //}
            //catch (Exception exeption)
            //{
            //    MessageBox.Show(exeption.Message);
            //}
            return dataTable;
        }
    }
}
