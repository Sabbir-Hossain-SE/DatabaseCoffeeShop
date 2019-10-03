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
    class OrderRepository
    {

        //Method
        public bool Add(int quantity,double totalPrice,string custName,string itemName)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Orders (Quantity, TotalPrice,CustomerName,ItemName) Values (" + quantity + ", " + totalPrice + ",'" + custName + "', '" + itemName + "')";
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
        public bool IsNameExist(string custName)
        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Orders WHERE Name='" + custName + "'";
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
                string commandString = @"DELETE FROM Orders WHERE ID = " + id + "";
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

        public bool Update(int quantity,double totalPrice,string custName,string itemName, int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE Orders SET Quantity =  " + quantity + " , TotalPrice = " + totalPrice + ", CustomerName = '" + custName + "', ItemName = '" + itemName + "' WHERE ID = " + id + "";
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
            string commandString = @"SELECT * FROM Orders";
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
        public DataTable Search(string custName)
        {
            // try
            // {
            //Connection
            string connectionString = @"Server=SABBIR; Database=CoffeeShop1; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Orders WHERE CustomerName='" + custName + "'";
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
