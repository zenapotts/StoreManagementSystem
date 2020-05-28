using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zpotts_rd_a3
{
    public static class SQL_Calls
    {
        public static int OrderID = 0;
        public static int CustomerID = 0;
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        public static void Initialize()
        {
            server = "127.0.0.1";
            database = "ZPWally";
            uid = "root";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }

        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        //TMSLogger.LogIt("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public static List<InventoryEntry> Select_Inventory(int choice)
        {
            string query = "SELECT Inventory.BranchID, Inventory.SKU, Inventory.Quantity, Product.WholesalePrice, Product.ProductName FROM Inventory LEFT JOIN Product ON Inventory.SKU = Product.SKU HAVING BranchID =" + choice + ";";

            //Create a list to store the result
            List<InventoryEntry> list = new List<InventoryEntry>();

            //Open connection
            if (SQL_Calls.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    InventoryEntry temp = new InventoryEntry();
                    temp.branchID = dataReader["BranchID"] + "";
                    temp.SKU = dataReader["SKU"] + "";
                    temp.quantity = int.Parse(dataReader["Quantity"] + "");
                    temp.price = double.Parse(dataReader["WholesalePrice"] + "");
                    temp.pName = dataReader["ProductName"] + "";
                    list.Add(temp);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                SQL_Calls.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public static List<CustomerEntry> Select_Customers()
        {
            string query = "SELECT * FROM Customer;";

            //Create a list to store the result
            List<CustomerEntry> list = new List<CustomerEntry>();

            //Open connection
            if (SQL_Calls.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    CustomerEntry temp = new CustomerEntry();
                    temp.custID = dataReader["CustomerID"] + "";
                    temp.fName = dataReader["FirstName"] + "";
                    temp.lName = dataReader["LastName"] + "";
                    temp.tNumber = dataReader["Telephone"] + "";
                    CustomerID = int.Parse(temp.custID);
                    list.Add(temp);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                SQL_Calls.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
        public static void AddNewCustomer(string fname, string lname, string phone)
        {
            int tempCustID = CustomerID + 1;
            string query = "INSERT INTO Customer (CustomerID, FirstName, LastName, Telephone) VALUES('" + tempCustID + "','" + fname + "','" + lname + "','" + phone + "');";

            //create command and assign the query and connection from the constructor

            if (SQL_Calls.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command
                var r = cmd.ExecuteNonQuery();
            }

            //close Connection
            SQL_Calls.CloseConnection();
        }

        public static void AddNewOrder(string OrderID, string Order_Date, string CustomerID, string Order_Status, string BranchID)
        {
            string query = "INSERT INTO Orders (OrderID, OrderDate, CustomerID, OrderStatus, BranchID) VALUES('" + OrderID + "','" + Order_Date + "','" + CustomerID + "','" + Order_Status + "','" + BranchID + "');";
            if (SQL_Calls.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                var r = cmd.ExecuteNonQuery();
            }
            SQL_Calls.CloseConnection();
        }

        public static void AddNewProductToOrder(string OrderID, string SKU, int Quantity)
        {
            string query = "INSERT INTO ProductOrder (OrderID, SKU, Quantity) VALUES(" +
                OrderID + "," +
                SKU + "," +
                Quantity + ");";
            if (SQL_Calls.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                var r = cmd.ExecuteNonQuery();
            }
            //close Connection
            SQL_Calls.CloseConnection();
        }

        public static void UpdateInventory(int Quantity, string BranchID, string SKU)
        {
            string query = "UPDATE Inventory SET Quantity = " + Quantity.ToString() + " WHERE BranchID = '" + BranchID + "' and SKU = '" + SKU + "';";
            if (SQL_Calls.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                var r = cmd.ExecuteNonQuery();
            }
            SQL_Calls.CloseConnection();
        }
        public static void UpdateReturnInventory(int Quantity, string BranchID, string SKU)
        {
            string query = "UPDATE Inventory SET Quantity = Quantity +" + Quantity.ToString() + " WHERE BranchID = '" + BranchID + "' and SKU = '" + SKU + "';";
            if (SQL_Calls.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                var r = cmd.ExecuteNonQuery();
            }
            //close Connection
            SQL_Calls.CloseConnection();
        }

        public static void MaxOrderID()
        {
            string query = "SELECT OrderID FROM Orders WHERE OrderID = (SELECT MAX(OrderID) from Orders);";

            if (SQL_Calls.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                OrderID = dataReader.GetInt32(0);
                OrderID++;
                dataReader.Close();
            }
            SQL_Calls.CloseConnection();
        }

        public static List<Order> Select_OrderInfo()
        {
            string query = "SELECT * FROM Orders;";

            //Create a list to store the result
            List<Order> list = new List<Order>();

            //Open connection
            if (SQL_Calls.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Order temp = new Order();
                    temp.orderID = dataReader["OrderID"] + "";
                    temp.date = dataReader["OrderDate"] + "";
                    temp.custID = dataReader["CustomerID"] + "";
                    temp.status = dataReader["OrderStatus"] + "";
                    temp.branchID = dataReader["BranchID"] + "";
                    list.Add(temp);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                SQL_Calls.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public static List<OrderItems> Select_Product_Order(string choice)
        {
            string query = "SELECT * FROM ProductOrder WHERE OrderID = '" + choice + "';";

            //Create a list to store the result
            List<OrderItems> list = new List<OrderItems>();

            //Open connection
            if (SQL_Calls.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    OrderItems temp = new OrderItems();
                    temp.orderID = dataReader["OrderID"] + "";
                    temp.SKU = dataReader["SKU"] + "";
                    temp.quantity = int.Parse(dataReader["Quantity"] + "");
                    list.Add(temp);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                SQL_Calls.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public static void UpdateRefundStatus(string OrderID)
        {
            string query = "UPDATE Orders SET OrderStatus = 'RFND' WHERE OrderID = '" + OrderID + "';";
            if (SQL_Calls.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                var r = cmd.ExecuteNonQuery();
            }
            //close Connection
            SQL_Calls.CloseConnection();
        }

        public static void UpdateProductOrder(int Quantity, string OrderID)
        {
            string query = "UPDATE ProductOrder SET Quantity = '" + Quantity + "' WHERE OrderID = '" + OrderID + "';";
            if (SQL_Calls.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                var r = cmd.ExecuteNonQuery();
            }
            //close Connection
            SQL_Calls.CloseConnection();
        }

    }
}