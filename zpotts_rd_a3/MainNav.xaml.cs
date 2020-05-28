using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zpotts_rd_a3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Location = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            SQL_Calls.Initialize();
            ZP_Inventory.InvAtLoc.Clear();
            Inventory.ItemsSource = ZP_Inventory.InvAtLoc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Location >= 1 && Location <= 3) 
            {
                OrderWindow newpage = new OrderWindow(Location);
                newpage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select a Location First!!!!");
            }
        }

        private void LocationPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Location = LocationPicker.SelectedIndex + 1;
            ZP_Inventory.InvAtLoc.Clear();
            ZP_Inventory.InvAtLoc = SQL_Calls.Select_Inventory(Location);
            Inventory.ItemsSource = null;
            Inventory.ItemsSource = ZP_Inventory.InvAtLoc;
        }

        private void RefreshCust_Click(object sender, RoutedEventArgs e)
        {
            CustTable.ItemsSource = null;
            ZP_Customers.CustList.Clear();
            ZP_Customers.CustList = SQL_Calls.Select_Customers();
            CustTable.ItemsSource = ZP_Customers.CustList;
        }

        private void NewCust_Click(object sender, RoutedEventArgs e)
        {
            NewCustomer newpage = new NewCustomer();
            newpage.ShowDialog();
        }

        private void RefreshOrders_Click(object sender, RoutedEventArgs e)
        {
            OrdersTable.ItemsSource = null;
            ZP_Orders.allOrders.Clear();
            ZP_Orders.allOrders = SQL_Calls.Select_OrderInfo();
            OrdersTable.ItemsSource = ZP_Orders.allOrders;
        }

        private void Refund_Click(object sender, RoutedEventArgs e)
        {
            foreach (Order temp in OrdersTable.SelectedItems)
            {
                foreach (OrderItems temp2 in ZP_Orders.contains)
                {
                    SQL_Calls.UpdateReturnInventory(temp2.quantity, temp.branchID, temp2.SKU);
                }
                SQL_Calls.UpdateProductOrder(0, temp.orderID);
                SQL_Calls.UpdateRefundStatus(temp.orderID);
            }
            ZP_Orders.contains.Clear();
            ContentTable.ItemsSource = null;
            ContentTable.ItemsSource = ZP_Orders.contains;
            OrdersTable.ItemsSource = null;
            ZP_Orders.allOrders.Clear();
            ZP_Orders.allOrders = SQL_Calls.Select_OrderInfo();
            OrdersTable.ItemsSource = ZP_Orders.allOrders;
        }

        private void OrdersTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Order temp in OrdersTable.SelectedItems)
            {
                ZP_Orders.contains = SQL_Calls.Select_Product_Order(temp.orderID);
            }
            ContentTable.ItemsSource = null;
            ContentTable.ItemsSource = ZP_Orders.contains;
        }
    }
}
